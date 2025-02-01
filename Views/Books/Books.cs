
namespace SistemaDeGestionBiblioteca.Views.Books
{
    using SistemaDeGestionBiblioteca.Controllers;
    using SistemaDeGestionBiblioteca.Models;
    using System;
    using System.Windows.Forms;

    public partial class Books : Form
    {
        bool edit = false;
        int? bookId = null;
        BooksController booksController = new BooksController();
        public Books(bool edit, int? bookId)
        {
            if (edit)
            {
                this.edit = true;
                this.bookId = bookId;
            }
            InitializeComponent();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
        private void clear() {
            txtTitle.Text = "";
            txtAuthor.Text = "";
            txtPublisher.Text = "";
            txtStock.Text = "";
            txtISBN.Text = "";
            txtYear.Text = "";
        }


        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtTitle.Text == "" || txtAuthor.Text == ""
                || txtPublisher.Text == "" || txtStock.Text == "" ||
                txtPublisher.Text == "" || txtYear.Text == ""
                ) 
            {
                MessageBox.Show("Debe rellenear todos los campos");
                return;
            }
            if (Convert.ToInt32(txtStock.Text) < 1) {
                MessageBox.Show("La cantidad disponible debe ser al menos uno");
                return;
            }
            if (Convert.ToInt32(txtYear.Text) < 1)
            {
                MessageBox.Show("El año de publicación debe ser mayor a cero");
                return;
            }
            BookModel bookModel = new BookModel
            {
                titulo = txtTitle.Text,
                autor = txtAuthor.Text,
                editorial = txtPublisher.Text,
                cantidad_disponible = Convert.ToInt32(txtStock.Text),
                isbn = txtISBN.Text,
                anio_publicacion = Convert.ToInt32(txtYear.Text)
            };

            if (!edit)
            {
                var messsage = booksController.insert(bookModel);

                if (messsage.Contains("OK"))
                {
                    MessageBox.Show("El registro se agregó correctamente");
                }
                else
                {
                    MessageBox.Show("Ah ocurrido un error");
                }
            }
            else
            {
                bookModel.id_libro = (int)bookId;
                var messsage = booksController.updateOne(bookModel);

                if (messsage.Contains("OK"))
                {
                    MessageBox.Show("El registro se actualizó correctamente");
                }
                else
                {
                    MessageBox.Show("Ah ocurrido un error");
                }
            }
            clear();
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Books_Load(object sender, EventArgs e)
        {
            if(edit)
            {
                var book = booksController.getOne((int)bookId);
                txtTitle.Text = book.titulo;
                txtAuthor.Text = book.autor;
                txtPublisher.Text = book.editorial;
                txtStock.Text = book.cantidad_disponible.ToString();
                txtISBN.Text = book.isbn;
                txtYear.Text = book.anio_publicacion.ToString();
            }

        }

        private void txtAuthor_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtAuthor_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar))
            {
                e.Handled = true;

            }

        }

        private void txtPublisher_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar))
            {
                e.Handled = true;

            }
        }
    }
}
