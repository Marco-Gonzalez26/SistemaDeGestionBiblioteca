

namespace SistemaDeGestionBiblioteca.Views.Loans
{
    using SistemaDeGestionBiblioteca.Controllers;
    using SistemaDeGestionBiblioteca.Models;
    using System;
    using System.Windows.Forms;
    public partial class Loan : Form
    {
        bool edit = false;
        int? loanId = null;
        UsersController usersController = new UsersController();
        BooksController booksController = new BooksController();
        LoansController loansController = new LoansController();

        public Loan(bool edit, int? loanId)
        {

            this.edit = edit;
            if (loanId != null)
            {
                this.loanId = loanId;
            }
            InitializeComponent();
        }

        public void loadData() {

            cmbBook.DataSource = booksController.getAll();
            cmbBook.ValueMember = "id_libro";
            cmbBook.DisplayMember = "titulo";

            cmbUsers.DataSource = usersController.getAll();
            cmbUsers.ValueMember = "id_usuario";
            cmbUsers.DisplayMember = "nombre";

            if (edit) 
            {
                var loan = loansController.getOne((int)loanId);

                cmbBook.SelectedValue = loan.id_libro;
                cmbUsers.SelectedValue = loan.id_usuario;
                dtpReturnDate.Value = DateTime.Parse(loan.fecha_devolucion);
                dtpStartDate.Value = DateTime.Parse(loan.fecha_prestamo);
                dtpStartDate.Enabled = false;
                cmbBook.Enabled = false;
                cmbUsers.Enabled = false;
                cbStatus.Checked = loan.estado == "devuelto" ? true : false;
            }



            

        }

        private void Loan_Load(object sender, EventArgs e)
        {
            loadData();
        }

        private void clear()
        {
            cmbBook.SelectedIndex = 0;
            cmbUsers.SelectedIndex = 0;
            cbStatus.Checked = false;
            dtpStartDate.Value = DateTime.Now;
            dtpReturnDate.Value = DateTime.Now;
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            LoanModel loanModel = new LoanModel
            {
                id_libro = (int)cmbBook.SelectedValue,
                id_usuario = (int)cmbUsers.SelectedValue,
                fecha_prestamo = dtpReturnDate.Text,
                fecha_devolucion = dtpReturnDate.Text,
                estado = cbStatus.Checked ? "devuelto" : "prestado"
            };

            if (!edit)
            {
                var messsage = loansController.insert(loanModel);

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
                loanModel.id_prestamo = (int)loanId;
                var messsage = loansController.updateOne(loanModel);


               
                if (messsage.Contains("OK"))
                {
                    MessageBox.Show("El registro se actualizó correctamente");
                }
                else
                {
                    MessageBox.Show("Ah ocurrido un error");
                }
            }
            BookModel book = booksController.getOne(loanModel.id_libro);
            booksController.updateStock(book, loanModel.estado);
            clear();
            this.Close();
        }
        public void changeStatus()
        {
            if (cbStatus.Checked)
            {
                cbStatus.Text = "Devuelto";
            }
            else
            {
                cbStatus.Text = "Prestado";
            }
        }
        private void cbStatus_CheckedChanged(object sender, EventArgs e)
        {
            changeStatus();
        }
    }
}
