

namespace SistemaDeGestionBiblioteca.Models
{
    public class LoanModel
    {
        public int id_prestamo { get; set; }
        public int id_usuario { get; set; }
        public int id_libro { get; set; }
        public string nombreUsuario { get; set; }
        public string tituloLibro { get; set; }
        public string fecha_prestamo { get; set; }
        public string fecha_devolucion { get; set; }
        public string estado { get; set; }


    }
}
/*
 CREATE TABLE prestamos (
    id_prestamo INT AUTO_INCREMENT PRIMARY KEY,
    id_usuario INT,
    id_libro INT,
    fecha_prestamo DATE NOT NULL DEFAULT (CURDATE()),
    fecha_devolucion DATE NULL,
    estado ENUM('prestado', 'devuelto') DEFAULT 'prestado',
 */