using System;
using System.Windows.Forms;

using Datos;

namespace Presentacion.TeacherScreens
{
    public partial class LoginTeacher : Form
    {
        public LoginTeacher()
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

            if(email == "" || password == "")
            {
                string box_msg = "Rellena todos los campos correctamente.";
                string box_title = "Autenticacion fallida.";

                MessageBox.Show(box_msg, box_title);
            } else
            {
                ServicioTeacher servicioTeacher = new ServicioTeacher();
                bool logged = servicioTeacher.Login(email, password);
                
                if(logged)
                {
                    DashboardTeacher screen = new DashboardTeacher();
                    this.Hide();
                    screen.ShowDialog();
                    this.Close();
                } else
                {
                    string box_msg = "Hubo un error al buscar la cuenta o verificar la contraseña.";
                    string box_title = "Autenticacion fallida.";

                    MessageBox.Show(box_msg, box_title);
                }
            }
        }
    }
}
