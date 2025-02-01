
namespace SistemaDeGestionBiblioteca.Models
{
    public class UserModel
    {
        public int id_usuario { get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }
        public string email { get; set; }
        public string telefono { get; set; }
        public string fecha_registro { get; set; }


    }
}

/*
     id_usuario INT AUTO_INCREMENT PRIMARY KEY,
    nombre VARCHAR(100) NOT NULL,
    apellido VARCHAR(100) NOT NULL,
    email VARCHAR(100) UNIQUE NOT NULL,
    telefono VARCHAR(20) NULL,
    fecha_registro TIMESTAMP DEFAULT CURRENT_TIMESTAMP
 */