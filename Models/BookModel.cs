

namespace SistemaDeGestionBiblioteca.Models
{
    public class BookModel
    {
        public int id_libro { get; set; }
        public string titulo { get; set; }
        public string autor { get; set; }
        public string editorial { get; set; }
        public int anio_publicacion { get; set; }
        public string isbn { get; set; }
        public int cantidad_disponible { get; set; }


    }
}

/*
 CREATE TABLE libros (
    id_libro INT AUTO_INCREMENT PRIMARY KEY,
    titulo VARCHAR(255) NOT NULL,
    autor VARCHAR(255) NOT NULL,
    editorial VARCHAR(100) NULL,
    anio_publicacion YEAR CHECK (anio_publicacion > 0),
    isbn VARCHAR(20) UNIQUE NULL,
    cantidad_disponible INT DEFAULT 1 CHECK (cantidad_disponible >= 0)
);
 */