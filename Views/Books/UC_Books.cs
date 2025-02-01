using SistemaDeGestionBiblioteca.Controllers;
using SistemaDeGestionBiblioteca.Views.Loans;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaDeGestionBiblioteca.Views.Books
{
    public partial class UC_Books : UserControl
    {
        private BooksController booksController = new BooksController();
        public UC_Books()
        {
            InitializeComponent();
        }

        public void fillGridView(bool search)
        {

            dgvBooks.DataSource = "";
            dgvBooks.Columns.Clear();
            if (!search)
            {

                dgvBooks.DataSource = booksController.getAll();
            }
            else
            {
                dgvBooks.DataSource = booksController.search(txtSearch.Text.Trim());

            }

            dgvBooks.Columns["titulo"].HeaderText = "Título";
            dgvBooks.Columns["autor"].HeaderText = "Autor";
            dgvBooks.Columns["anio_publicacion"].HeaderText = "Año";
            dgvBooks.Columns["isbn"].HeaderText = "ISBN";
            dgvBooks.Columns["cantidad_disponible"].HeaderText = "Disponibles";
            dgvBooks.Columns["id_libro"].Visible = false;
            dgvBooks.Columns["anio_publicacion"].Visible = false;
            dgvBooks.Columns["editorial"].Visible = false;

            var btnEdit = new DataGridViewButtonColumn
            {
                HeaderText = "Editar",
                Text = "Editar",
                UseColumnTextForButtonValue = true
            };

            var btnDelete = new DataGridViewButtonColumn
            {
                HeaderText = "Eliminar",
                Text = "Eliminar",
                UseColumnTextForButtonValue = true
            };

            dgvBooks.Columns.Add(btnEdit);
            dgvBooks.Columns.Add(btnDelete);
        }
        public void editBook(int id)
        {
            Books book = new Books(true, id);
            book.ShowDialog();
            fillGridView(false);
        }
        public void deleteBook(int id)
        {
            DialogResult dialogResult = MessageBox.Show("¿Esta seguro?", "Eliminar Préstamo", MessageBoxButtons.YesNo);

            if (dialogResult == DialogResult.Yes)
            {
                var result = booksController.deleteOne(id);

                if (result.Contains("OK"))
                {
                    MessageBox.Show("Registro se ha eliminado correctamente");
                    this.fillGridView(false);
                }
                else
                {
                    MessageBox.Show("Ha ocurrido un error al eliminar");
                }
            }
            else
            {
                MessageBox.Show("El usuario canceló la eliminación");
            }
        }

        private void dgvBooks_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {


        }

        private void dgvBooks_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;
            if (dgvBooks.Columns[e.ColumnIndex] is DataGridViewButtonColumn)
            {
                var selectedRow = dgvBooks.Rows[e.RowIndex];
                var bookId = selectedRow.Cells["id_libro"].Value;


                if (dgvBooks.Columns[e.ColumnIndex].HeaderText == "Editar")
                {
                    editBook((int)bookId);
                }

                if (dgvBooks.Columns[e.ColumnIndex].HeaderText == "Eliminar")
                {
                    deleteBook((int)bookId);
                }

            }
        }

        private void btnAddBook_Click(object sender, EventArgs e)
        {
            Books book = new Books(false, null);
            book.ShowDialog();
            fillGridView(false);
        }

        private void UC_Books_Load(object sender, EventArgs e)
        {
            fillGridView(false);


        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            fillGridView(true);
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            fillGridView(true);
        }
    }
}
