

namespace SistemaDeGestionBiblioteca.Views.Loans
{
    using SistemaDeGestionBiblioteca.Controllers;
    using System;
    using System.Windows.Forms;
    public partial class UC_Loans : UserControl
    {
        public UC_Loans()
        {
            InitializeComponent();
        }
        LoansController loansController = new LoansController();


        public void fillGridView(bool search)
        {
            
            dgvLoans.DataSource = "";
            dgvLoans.Columns.Clear();
            if (!search)
            {

                dgvLoans.DataSource = loansController.getAll();
            }
            else 
            {
                dgvLoans.DataSource = loansController.search(txtSearch.Text.Trim());

            }


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

            dgvLoans.Columns["tituloLibro"].HeaderText = "Libro";
            dgvLoans.Columns["nombreUsuario"].HeaderText = "Usuario";
            dgvLoans.Columns["estado"].HeaderText = "Estado";

            dgvLoans.Columns["fecha_devolucion"].HeaderText = "Fecha de devolución";
            dgvLoans.Columns["fecha_prestamo"].Visible = false;
            dgvLoans.Columns["id_prestamo"].Visible = false;
            dgvLoans.Columns["id_usuario"].Visible = false;
            dgvLoans.Columns["id_libro"].Visible = false;

            dgvLoans.Columns.Add(btnEdit);
            dgvLoans.Columns.Add(btnDelete);

        }
        private void editLoan(int id)
        {
            Loan loan = new Loan(true, id);
            loan.ShowDialog();
        }
        public void deleteLoan(int id)
        {
            DialogResult dialogResult = MessageBox.Show("¿Esta seguro?", "Eliminar Préstamo", MessageBoxButtons.YesNo);

            if (dialogResult == DialogResult.Yes)
            {
                var result = loansController.deleteOne(id);

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

        private void dgvLoans_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
        }

        private void dgvLoans_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;
            if (dgvLoans.Columns[e.ColumnIndex] is DataGridViewButtonColumn)
            {
                var selectedRow = dgvLoans.Rows[e.RowIndex];
                var loanId = selectedRow.Cells["id_prestamo"].Value;


                if (dgvLoans.Columns[e.ColumnIndex].HeaderText == "Editar")
                {
                    editLoan((int)loanId);
                }

                if (dgvLoans.Columns[e.ColumnIndex].HeaderText == "Eliminar")
                {
                    deleteLoan((int)loanId);
                }

            }
        }

        private void btnAddLoan_Click(object sender, EventArgs e)
        {
            Loan loan = new Loan(false, null);
            loan.ShowDialog();
            fillGridView(false);
        }

        private void UC_Loans_Load(object sender, EventArgs e)
        {
            fillGridView(false);
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            fillGridView(true);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            fillGridView(true);
        }
    }
}
