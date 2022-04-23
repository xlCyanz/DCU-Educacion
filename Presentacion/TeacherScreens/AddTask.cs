using System;
using System.Windows.Forms;

using Datos;

namespace Presentacion.TeacherScreens
{
    public partial class AddTask : Form
    {
        public AddTask()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string name = textBox1.Text;
            string description = textBox2.Text;

            if(name == "" || description == "" )
            {
                string box_msg = "Rellena todos los campos disponibles";
                string box_title = "Hubo un error.";

                MessageBox.Show(box_msg, box_title);
            } else
            {
                DateTime limit = dateTimePicker1.Value;

                ServicioTask servicioTask = new ServicioTask();
                bool added = servicioTask.Agregar(name, description, limit);

                if (added)
                {
                    string box_msg = "La tarea fue agregada exitosamente.";
                    string box_title = "Agregada";

                    MessageBox.Show(box_msg, box_title);
                    this.Close();
                } else
                {
                    string box_msg = "No se pudo agregar la nueva tarea.";
                    string box_title = "Hubo un error";

                    MessageBox.Show(box_msg, box_title);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
