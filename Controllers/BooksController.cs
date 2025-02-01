



namespace SistemaDeGestionBiblioteca.Controllers
{
    using SistemaDeGestionBiblioteca.Models;
    using System.Collections.Generic;
    using System.Data.SqlClient;
    using Config;
    using System.Windows.Forms;

    public class BooksController
    {
        private BookModel bookModel = new BookModel();
        private readonly DbConnection cn = new DbConnection();

        public List<BookModel> getAll()
        {
            var books = new List<BookModel>();
            using (var connection = cn.getConnection())
            {
                connection.Open();
                string queryString = $"SELECT * FROM libros ;";
                using (var command = new SqlCommand(queryString, connection))
                {

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var book = new BookModel
                            {
                                id_libro = (int)reader["id_libro"],
                                titulo = reader["titulo"].ToString(),
                                autor = reader["autor"].ToString(),
                                cantidad_disponible = (int)reader["cantidad_disponible"],
                                editorial = reader["editorial"].ToString(),
                                anio_publicacion = (int)reader["anio_publicacion"],
                                isbn = reader["isbn"].ToString()

                            };

                            books.Add(book);
                        }
                    }
                }
            }
            return books;
        }
        public BookModel getOne(int Id_Book)
        {
            var book = new BookModel();
            using (var connection = cn.getConnection())
            {
                connection.Open();
                string queryString = $"SELECT * FROM libros WHERE libros.id_libro = @BookId;";
                using (var command = new SqlCommand(queryString, connection))
                {
                    command.Parameters.Add(new SqlParameter("@BookId", Id_Book));
                    using (var reader = command.ExecuteReader())
                    {
                        if (!reader.Read()) return null;


                        book = new BookModel
                        {
                            id_libro = (int)reader["id_libro"],
                            titulo = reader["titulo"].ToString(),
                            autor = reader["autor"].ToString(),
                            cantidad_disponible = (int)reader["cantidad_disponible"],
                            editorial = reader["editorial"].ToString(),
                            anio_publicacion = (int)reader["anio_publicacion"],
                            isbn = reader["isbn"].ToString()
                        };



                    }
                }
                return book;
            }
        }

        public string insert(BookModel bookToAdd)
        {
            string queryString = $"INSERT INTO libros (titulo, autor, editorial, anio_publicacion, isbn, cantidad_disponible) " +
                $"VALUES(@Title, @Author, @Editorial, @Year, @ISBN, @Stock)";
            using (var connection = cn.getConnection())
            {
                using (var command = new SqlCommand(queryString, connection))
                {

                    command.Parameters.Add(new SqlParameter("@Title", bookToAdd.titulo));
                    command.Parameters.Add(new SqlParameter("@Author", bookToAdd.autor));
                    command.Parameters.Add(new SqlParameter("@Editorial", bookToAdd.editorial));
                    command.Parameters.Add(new SqlParameter("@Year", bookToAdd.anio_publicacion));
                    command.Parameters.Add(new SqlParameter("@ISBN", bookToAdd.isbn));
                    command.Parameters.Add(new SqlParameter("@Stock", bookToAdd.cantidad_disponible));
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
        public string updateOne(BookModel bookToUpdate)
        {
            string queryString= $"UPDATE libros " +
                           $"SET titulo = @Title, autor = @Author, editorial = @Editorial, " +
                           $"anio_publicacion = @Year, isbn = @ISBN, cantidad_disponible = @Stock " +
                           $"WHERE id_libro = @BookId";

            using (var connection = cn.getConnection())
            {
                using (var command = new SqlCommand(queryString, connection))
                {
                    command.Parameters.Add(new SqlParameter("@Title", bookToUpdate.titulo));
                    command.Parameters.Add(new SqlParameter("@Author", bookToUpdate.autor));
                    command.Parameters.Add(new SqlParameter("@Editorial", bookToUpdate.editorial));
                    command.Parameters.Add(new SqlParameter("@Year", bookToUpdate.anio_publicacion));
                    command.Parameters.Add(new SqlParameter("@ISBN", bookToUpdate.isbn));
                    command.Parameters.Add(new SqlParameter("@Stock", bookToUpdate.cantidad_disponible));
                    command.Parameters.Add(new SqlParameter("@BookId", bookToUpdate.id_libro));

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
        public string updateStock(BookModel bookToUpdate, string mode)
        {
            string queryString = $"UPDATE libros " +
                           $"SET cantidad_disponible = @Stock " +
                           $"WHERE id_libro = @BookId";

            using (var connection = cn.getConnection())
            {
                using (var command = new SqlCommand(queryString, connection))
                {
                    var stock = bookToUpdate.cantidad_disponible;

                    if (mode == "prestado")
                    {
                        stock = stock - 1;

                    }
                    else if (mode == "devuelto") {
                        stock = stock + 1;

                    }
                    MessageBox.Show("Id Libro - " + bookToUpdate.id_libro + "Stock - " + stock);
                    command.Parameters.Add(new SqlParameter("@Stock", stock));
                    command.Parameters.Add(new SqlParameter("@BookId", bookToUpdate.id_libro));

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
        public string deleteOne(int bookId)
        {
            string queryString = $"DELETE FROM libros  " +
                    $"WHERE id_libro = @Book_Id;";
            using (var connection = cn.getConnection())
            {
                using (var command = new SqlCommand(queryString, connection))
                {

                    command.Parameters.Add(new SqlParameter("@Book_Id", bookId));
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
        public List<BookModel> search(string query)
        {
            var books = new List<BookModel>();
            using (var connection = cn.getConnection())
            {
                connection.Open();
                string queryString = $"SELECT * FROM libros " +
                    $"WHERE titulo LIKE @Query;";
                using (var command = new SqlCommand(queryString, connection))
                {
                    command.Parameters.Add(new SqlParameter("@Query", $"%{query}%"));
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var book = new BookModel
                            {
                                id_libro = (int)reader["id_libro"],
                                titulo = reader["titulo"].ToString(),
                                autor = reader["autor"].ToString(),
                                cantidad_disponible = (int)reader["cantidad_disponible"],
                                editorial = reader["editorial"].ToString(),
                                anio_publicacion = (int)reader["anio_publicacion"],
                                isbn = reader["isbn"].ToString()
                            };

                            books.Add(book);
                        }
                    }
                }
            }
            return books;
        }
    }
}
