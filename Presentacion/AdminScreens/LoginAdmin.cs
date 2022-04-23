using System;
using System.Windows.Forms;

using CryptoLib;

namespace Presentacion.AdminScreens
{
    public partial class LoginAdmin : Form
    {
        public LoginAdmin()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MainScreen screen = new MainScreen();
            this.Hide();
            screen.ShowDialog();
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string password = textBox2.Text;
            string passwordEncrypted = Encryptor.MD5Hash(password);
            string passwordAdmin = "00223482d264a6a879ce196b8984d03f";

            if (passwordEncrypted != passwordAdmin)
            {
                string box_msg = "La contraseña de administrador es incorrecta.";
                string box_title = "Autenticacion fallida.";

                MessageBox.Show(box_msg, box_title);
            } else
            {
                DashboardAdmin screen = new DashboardAdmin();
                this.Hide();
                screen.ShowDialog();
                this.Close();
            }
        }
    }
}
