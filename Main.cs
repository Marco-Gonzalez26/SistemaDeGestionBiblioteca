

namespace SistemaDeGestionBiblioteca
{
    using System;
    using System.Windows.Forms;
    using SistemaDeGestionBiblioteca.Views.Books;
    using SistemaDeGestionBiblioteca.Views.Home;
    using SistemaDeGestionBiblioteca.Views.Loans;
    using SistemaDeGestionBiblioteca.Views.Users;

    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            UC_Home home = new UC_Home();
            MainContainer.Controls.Clear();
            MainContainer.Controls.Add(home);
        }

        private void btnUsers_Click(object sender, EventArgs e)
        {
        }

        private void btnBooks_Click(object sender, EventArgs e)
        {
            UC_Books books = new UC_Books();
            MainContainer.Controls.Clear();
            MainContainer.Controls.Add(books);
        }

        private void btnLoans_Click(object sender, EventArgs e)
        {
            UC_Loans loans = new UC_Loans();
            MainContainer.Controls.Clear();
            MainContainer.Controls.Add(loans);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnUsers_Click_1(object sender, EventArgs e)
        {
            UC_Users users = new UC_Users();
            MainContainer.Controls.Clear();
            MainContainer.Controls.Add(users);
        }

        private void Main_Load(object sender, EventArgs e)
        {
            UC_Home home = new UC_Home();
            MainContainer.Controls.Clear();
            MainContainer.Controls.Add(home);
        }
    }
}
