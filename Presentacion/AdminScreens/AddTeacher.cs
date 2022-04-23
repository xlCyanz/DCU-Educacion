using System;
using System.Windows.Forms;

using Datos;

namespace Presentacion.AdminScreens
{
    public partial class AddTeacher : Form
    {
        public AddTeacher()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string name = textBox1.Text;
            string lastname = textBox2.Text;

            if(name == "" || lastname == "")
            {
                string box_msg = "Rellena todos los campos disponibles";
                string box_title = "Hubo un error.";

                MessageBox.Show(box_msg, box_title);
            } else
            {
                string email = textBox3.Text;
                string password = textBox4.Text;

                ServicioTeacher servicioTeacher = new ServicioTeacher();
                bool added = servicioTeacher.Agregar(name, lastname, email, password);

                if (added)
                {
                    string box_msg = "No te olvides apuntar la contraseña ya que sera cifrada y no se podra usar. Contraseña: " + password;
                    string box_title = "Cuidado.";

                    MessageBox.Show(box_msg, box_title);
                    this.Close();
                }
                else
                {
                    string box_msg = "No se pudo agregar la nueva cuenta, verifica que todos los campos esten llenos y no se repitan";
                    string box_title = "Hubo un error.";

                    MessageBox.Show(box_msg, box_title);
                }
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            textBox3.Text = textBox1.Text.ToLower() + GenerateRandomNo() + "@edu.com";
        }

        public int GenerateRandomNo()
        {
            int _min = 1000;
            int _max = 9999;
            Random _rdm = new Random();
            return _rdm.Next(_min, _max);
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            textBox4.Text = textBox2.Text.ToLower() + GenerateRandomNo();
        }
    }
}
