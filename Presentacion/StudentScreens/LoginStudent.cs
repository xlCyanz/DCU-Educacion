using System;
using System.Windows.Forms;

using Datos;

namespace Presentacion.StudentScreens
{
    public partial class LoginStudent : Form
    {
        public LoginStudent()
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
            string email = textBox1.Text;
            string password = textBox2.Text;

            if (email == "" || password == "")
            {
                string box_msg = "Rellena todos los campos correctamente.";
                string box_title = "Autenticacion fallida.";

                MessageBox.Show(box_msg, box_title);
            }
            else
            {
                ServicioStudent servicioStudent = new ServicioStudent();
                bool logged = servicioStudent.Login(email, password);

                if (logged)
                {
                    DashboardStudent screen = new DashboardStudent();
                    this.Hide();
                    screen.ShowDialog();
                    this.Close();
                }
                else
                {
                    string box_msg = "Hubo un error al buscar la cuenta o verificar la contraseña.";
                    string box_title = "Autenticacion fallida.";

                    MessageBox.Show(box_msg, box_title);
                }
            }
        }
    }
}
