

namespace SistemaDeGestionBiblioteca.Views.Users
{
    using SistemaDeGestionBiblioteca.Controllers;
    using SistemaDeGestionBiblioteca.Models;
    using System;
    using System.Text.RegularExpressions;
    using System.Windows.Forms;
    public partial class UC_Users : UserControl
    {
        private UsersController usersController = new UsersController();
        private UserModel userModel = new UserModel();
        public UC_Users()
        {
            InitializeComponent();
        }
        private void loadUsers()
        {

            var users = usersController.getAll();
            lstUsers.DataSource = users;


            lstUsers.ValueMember = "id_usuario";
            lstUsers.DisplayMember = "Nombre";
            lstUsers.ClearSelected();
        }

        public void edit()
        {
            if (lstUsers.SelectedIndex == -1)
            {
                MessageBox.Show("Elija a un usuario de la lista");
                return;
            }

            userModel = usersController.getOne((int)lstUsers.SelectedValue);
            txtName.Text = userModel.nombre;
            txtLastname.Text = userModel.apellido;
            txtPhoneNum.Text = userModel.telefono;
            txtEmail.Text = userModel.email;
            
        }
        private void clear()
        {
            txtName.Text = "";
            txtLastname.Text = "";
            txtPhoneNum.Text = "";
            txtEmail.Text = "";
        }
        bool isValidEmail(string email)
        {
            string pattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";
            return Regex.IsMatch(email, pattern);
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtEmail.Text == "" ||
                txtName.Text == "" ||
                txtLastname.Text == "" ||
                txtPhoneNum.Text == "" ) {
                MessageBox.Show("Rellene todos los campos");
                return;
            }

            if (!isValidEmail(txtEmail.Text.Trim())) {
                MessageBox.Show("Formato de correo electronico no valido");
                return;
            }
            if (txtPhoneNum.Text.Length < 10) {
                MessageBox.Show("Numero de telefono invalido");
                return;
            }
            var message = "";

                if (userModel.id_usuario == 0)
                {
                    userModel = new UserModel
                    {
                        nombre = txtName.Text,
                        apellido = txtLastname.Text,
                       
                        email = txtEmail.Text,
                        telefono = txtPhoneNum.Text
                    };
                    message = usersController.insert(userModel);
                    clear();

                } 
                else
                {
                    userModel.nombre = txtName.Text;
                    userModel.apellido = txtLastname.Text;
                    userModel.email = txtEmail.Text;
                    userModel.telefono = txtPhoneNum.Text;
                    message = usersController.updateOne(userModel);
                }

                if (message == "OK")
                {
                    MessageBox.Show("Se ha guardado exitosamente");
                    loadUsers();
                }
                else
                {
                    MessageBox.Show("Ocurrió un error al guardar");
                }
            
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            edit();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (lstUsers.SelectedIndex == -1)
            {
                MessageBox.Show("Elija un usuario para la eliminación");
                return;
            }

            var userId = lstUsers.SelectedValue;

            DialogResult dialogBox = MessageBox.Show("¿Está seguro?, esta operacion no se puede revertir", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (dialogBox == DialogResult.Yes)
            {
                var message = usersController.deleteOne((int)userId);

                if (message.Contains("OK"))
                {
                    MessageBox.Show("Registro eliminado correctamente");
                    loadUsers();
                    clear();
                }
                else
                {
                    MessageBox.Show($"{message} - No se pudo eliminar el registro");
                }
            }
        }

        private void lstUsers_DoubleClick(object sender, EventArgs e)
        {
            edit();
        }

        private void UC_Users_Load(object sender, EventArgs e)
        {
            loadUsers();
            lstUsers.ClearSelected();
        }

        private void txtName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar))
            {
                e.Handled = true;

            }
        }

        private void txtLastname_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar))
            {
                e.Handled = true;

            }
        }

        private void txtPhoneNum_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;

            }
        }
    }
}
