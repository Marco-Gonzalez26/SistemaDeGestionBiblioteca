using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaDeGestionBiblioteca.Views.Home
{
    public partial class UC_Home : UserControl
    {
        public UC_Home()
        {
            InitializeComponent();
        }

        private void userLoanReport_Load(object sender, EventArgs e)
        {

        }

        private void UC_Home_Load(object sender, EventArgs e)
        {
            this.vista_PrestamosTableAdapter.Fill(this.sistemaGestionBibliotecaDataSet.Vista_Prestamos);
            this.report.RefreshReport();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            this.vista_PrestamosTableAdapter.FillBySearch(this.sistemaGestionBibliotecaDataSet.Vista_Prestamos, txtSearch.Text);
            this.report.RefreshReport();
        }
    }
}
