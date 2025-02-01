



namespace SistemaDeGestionBiblioteca.Controllers
{
    using SistemaDeGestionBiblioteca.Models;
    using System.Collections.Generic;
    using System.Data.SqlClient;
    using SistemaDeGestionBiblioteca.Config;
    using System;
    using System.Windows.Forms;

    public class LoansController
    {
        private LoanModel loanModel = new LoanModel();
        private readonly DbConnection cn = new DbConnection();

        public List<LoanModel> getAll()
        {
            var loans = new List<LoanModel>();
            using (var connection = cn.getConnection())
            {
                connection.Open();
                string queryString = $"SELECT p.id_prestamo, " +
                    $"p.id_libro, " +
                    $"p.id_usuario, " +
                    $"l.titulo AS tituloLibro, " +
                    $"u.nombre AS nombreUsuario, " +
                    $"p.estado, p.fecha_prestamo, " +
                    $"p.fecha_devolucion FROM prestamos p " +
                    $"JOIN libros l ON p.id_libro = l.id_libro " +
                    $"JOIN usuarios u ON p.id_usuario = u.id_usuario;";
                using (var command = new SqlCommand(queryString, connection))
                {

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var loan = new LoanModel
                            {
                                id_prestamo = (int)reader["id_prestamo"],
                                id_libro = (int)reader["id_libro"],
                                id_usuario = (int)reader["id_usuario"],
                                tituloLibro = reader["tituloLibro"].ToString(),
                                nombreUsuario = reader["nombreUsuario"].ToString(),
                                estado = reader["estado"].ToString(),
                                fecha_devolucion = reader["fecha_devolucion"].ToString(),
                                fecha_prestamo = reader["fecha_prestamo"].ToString()
                            };

                            loans.Add(loan);
                        }
                    }
                }
            }
            return loans;
        }
        public LoanModel getOne(int Id_loan)
        {
            var loan = new LoanModel();
            using (var connection = cn.getConnection())
            {
                connection.Open();
                string queryString = $"SELECT p.id_prestamo, " +
                    $"p.id_libro, " +
                    $"p.id_usuario, " +
                    $"l.titulo AS tituloLibro, " +
                    $"u.nombre AS nombreUsuario, " +
                    $"p.estado, p.fecha_prestamo, " +
                    $"p.fecha_devolucion FROM prestamos p " +
                    $"JOIN libros l ON p.id_libro = l.id_libro " +
                    $"JOIN usuarios u ON p.id_usuario = u.id_usuario " +
                    $"WHERE p.id_prestamo = @LoanId;";
                using (var command = new SqlCommand(queryString, connection))
                {
                    command.Parameters.Add(new SqlParameter("@loanId", Id_loan));
                    using (var reader = command.ExecuteReader())
                    {
                        if (!reader.Read()) return null;


                        loan = new LoanModel
                        {
                            id_prestamo = (int)reader["id_prestamo"],
                            id_libro = (int)reader["id_libro"],
                            id_usuario = (int)reader["id_usuario"],
                            tituloLibro = reader["tituloLibro"].ToString(),
                            nombreUsuario = reader["nombreUsuario"].ToString(),
                            estado = reader["estado"].ToString(),
                            fecha_devolucion = reader["fecha_devolucion"].ToString(),
                            fecha_prestamo = reader["fecha_prestamo"].ToString()
                        };



                    }
                }
                return loan;
            }
        }

        public string insert(LoanModel loanToAdd)
        {
            string queryString = $"INSERT INTO prestamos (id_usuario, id_libro, fecha_prestamo, fecha_devolucion, estado) " +
                       $"VALUES (@UserId, @BookId, @LoanDate, @ReturnDate, @Status)";
            using (var connection = cn.getConnection())
            {
                using (var command = new SqlCommand(queryString, connection))
                {
                    MessageBox.Show(loanToAdd.id_usuario.ToString());
                    command.Parameters.Add(new SqlParameter("@UserId", loanToAdd.id_usuario));
                    command.Parameters.Add(new SqlParameter("@BookId", loanToAdd.id_libro));
                    command.Parameters.Add(new SqlParameter("@LoanDate", DateTime.Parse(loanToAdd.fecha_prestamo)));
                    command.Parameters.Add(new SqlParameter("@ReturnDate", DateTime.Parse(loanToAdd.fecha_devolucion)));
                    command.Parameters.Add(new SqlParameter("@Status", loanToAdd.estado));

                    connection.Open();
                    if (command.ExecuteNonQuery() != 0)
                    {
                        return "OK";
                    }
                    else
                    {
                        return "Error";
                    }
                }

            }
        }
        public string updateOne(LoanModel loanToUpdate)
        {
            string queryString = $"UPDATE prestamos " +
               $"SET fecha_devolucion = @ReturnDate, estado = @Status " +
               $"WHERE id_prestamo = @LoanId";

            using (var connection = cn.getConnection())
            {
                using (var command = new SqlCommand(queryString, connection))
                {
                    command.Parameters.Add(new SqlParameter("@ReturnDate", DateTime.Parse(loanToUpdate.fecha_devolucion)));
                    command.Parameters.Add(new SqlParameter("@Status", loanToUpdate.estado));
                    command.Parameters.Add(new SqlParameter("@LoanId", loanToUpdate.id_prestamo));
                    connection.Open();
                    if (command.ExecuteNonQuery() != 0)
                    {
                        return "OK";
                    }
                    else
                    {
                        return "Error";
                    }
                }

            }
        }
        public string deleteOne(int loanId)
        {
            string queryString = $"DELETE FROM prestamos  " +
                    $"WHERE id_prestamo = @Loan_Id;";
            using (var connection = cn.getConnection())
            {
                using (var command = new SqlCommand(queryString, connection))
                {

                    command.Parameters.Add(new SqlParameter("@Loan_Id", loanId));
                    connection.Open();
                    if (command.ExecuteNonQuery() != 0)
                    {
                        return "OK";
                    }
                    else
                    {
                        return "Error";
                    }
                }

            }

        }
        public List<LoanModel> search(string query)
        {
            var loans = new List<LoanModel>();
            using (var connection = cn.getConnection())
            {
                connection.Open();
                string queryString = $"SELECT prestamo.id_prestamo,prestamo.id_libro,prestamo.id_usuario," +
                    $"libro.titulo AS tituloLibro,usuario.nombre AS nombreUsuario,prestamo.estado, prestamos.fecha_prestamo, prestamos.fecha_devolucion" +
                    $" FROM prestamos " +
                    $"JOIN libros  ON prestamos.id_libro = libro.id_libro " +
                    $"JOIN usuarios ON prestamo.id_usuario = usuario.id_usuario " +
                    $"WHERE nombreUsuario like @Query;";
                using (var command = new SqlCommand(queryString, connection))
                {
                    command.Parameters.Add(new SqlParameter("@Query", $"%{query}%"));
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var loan = new LoanModel
                            {
                                id_prestamo = (int)reader["id_prestamo"],
                                id_libro = (int)reader["id_libro"],
                                id_usuario = (int)reader["id_usuario"],
                                tituloLibro = reader["tituloLibro"].ToString(),
                                nombreUsuario = reader["nombreUsuario"].ToString(),
                                estado = reader["estado"].ToString(),
                                fecha_devolucion = reader["fecha_devolucion"].ToString(),
                                fecha_prestamo = reader["fecha_prestamo"].ToString()
                            };

                            loans.Add(loan);
                        }
                    }
                }
            }
            return loans;
        }
    }
}
