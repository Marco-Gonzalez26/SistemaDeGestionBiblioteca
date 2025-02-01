



namespace SistemaDeGestionBiblioteca.Controllers
{
    using System.Collections.Generic;
    using System.Data.SqlClient;
    using System;
    using SistemaDeGestionBiblioteca.Models;
    using SistemaDeGestionBiblioteca.Config;


    class UsersController
    {
        private UserModel userModel = new UserModel();
        private readonly DbConnection cn = new DbConnection();
        
        public List<UserModel> getAll()
        {
            var users = new List<UserModel>();
            using (var connection = cn.getConnection())
            {
                connection.Open();
                string queryString = $"SELECT * FROM usuarios ;";
                using (var command = new SqlCommand(queryString, connection))
                {

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var user = new UserModel
                            {
                                id_usuario = (int)reader["id_usuario"],
                                nombre = reader["nombre"].ToString(),
                                apellido = reader["apellido"].ToString(),
                                fecha_registro = reader["fecha_registro"].ToString(),
                                email = reader["email"].ToString(),
                                telefono = reader["telefono"].ToString()
                            };

                            users.Add(user);
                        }
                    }
                }
            }
            return users;
        }
        public UserModel getOne(int Id_User)
        {
            var user = new UserModel();
            using (var connection = cn.getConnection())
            {
                connection.Open();
                string queryString = $"SELECT * FROM usuarios WHERE usuarios.id_usuario = @UserId;";
                using (var command = new SqlCommand(queryString, connection))
                {
                    command.Parameters.Add(new SqlParameter("@UserId", Id_User));
                    using (var reader = command.ExecuteReader())
                    {
                        if (!reader.Read()) return null;


                        user = new UserModel
                        {
                            id_usuario = (int)reader["id_usuario"],

                            nombre = reader["nombre"].ToString(),
                            apellido = reader["apellido"].ToString(),
                            fecha_registro = reader["fecha_registro"].ToString(),
                            email = reader["email"].ToString(),
                            telefono = reader["telefono"].ToString(),
                        };



                    }
                }
                return user;
            }
        }

        public string insert(UserModel userToAdd)
        {
            string queryString = $"INSERT INTO Usuarios(nombre, apellido, email, telefono) " +
                $"Values(@Name, @Lastname, @Email, @PhoneNumber);";
            using (var connection = cn.getConnection())
            {
                using (var command = new SqlCommand(queryString, connection))
                {
                    
                    command.Parameters.Add(new SqlParameter("@Name", userToAdd.nombre));
                    command.Parameters.Add(new SqlParameter("@Lastname", userToAdd.apellido));
                    command.Parameters.Add(new SqlParameter("@Email", userToAdd.email));
                    command.Parameters.Add(new SqlParameter("@PhoneNumber", userToAdd.telefono));
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
        public string updateOne(UserModel userToUpdate)
        {
            string queryString = $"UPDATE usuarios SET nombre=@Name, apellido=@Lastname, email=@Email, telefono=@PhoneNumber " +
                $"WHERE id_usuario = @Id_User;";
            using (var connection = cn.getConnection())
            {
                using (var command = new SqlCommand(queryString, connection))
                {

                    command.Parameters.Add(new SqlParameter("@Name", userToUpdate.nombre));
                    command.Parameters.Add(new SqlParameter("@Lastname", userToUpdate.apellido));
                    command.Parameters.Add(new SqlParameter("@Email", userToUpdate.email));
                    command.Parameters.Add(new SqlParameter("@PhoneNumber", userToUpdate.telefono));
                    command.Parameters.Add(new SqlParameter("@Id_User", userToUpdate.id_usuario));

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
        public string deleteOne(int userId)
        {
            string queryString = $"DELETE FROM Usuarios  " +
                    $"WHERE id_usuario = @User_Id;";
            using (var connection = cn.getConnection())
            {
                using (var command = new SqlCommand(queryString, connection))
                {

                    command.Parameters.Add(new SqlParameter("@User_Id", userId));
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
    }
}
