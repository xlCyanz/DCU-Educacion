using System;
using System.Windows.Forms;

using Datos;

namespace Presentacion.TeacherScreens
{
    public partial class DashboardTeacher : Form
    {
        public DashboardTeacher()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AddTask screen = new AddTask();
            screen.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ResetTasks();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int columnIndex = dataGridView1.CurrentCell.ColumnIndex;
            int rowIndex = dataGridView1.CurrentCell.RowIndex;

            string _id = Convert.ToString(dataGridView1[columnIndex, rowIndex].Value);
            Console.WriteLine(_id);

            ServicioTask servicioTask = new ServicioTask();
            bool deleted = servicioTask.Borrar(_id);

            if (deleted)
            {
                ResetTasks();
            }
            else
            {
                string box_msg = "Ha ocurrido un error esto puede deberse a un fallo en la conexion o no existe este registro.";
                string box_title = "Hubo un error.";

                MessageBox.Show(box_msg, box_title);
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void DashboardTeacher_Load(object sender, EventArgs e)
        {
            ResetTasks();
        }

        private void ResetTasks()
        {
            ServicioTask servicioTask = new ServicioTask();
            this.dataGridView1.DataSource = servicioTask.BuscarTodos();
        }

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            string value = dataGridView1[e.ColumnIndex, e.RowIndex].Value.ToString();
            string column = dataGridView1.Columns[e.ColumnIndex].Name;
            string _id = Convert.ToString(dataGridView1[0, e.RowIndex].Value);

            ServicioTask servicioTask = new ServicioTask();

            bool updated = servicioTask.Actualizar(_id, column.ToLower(), value);

            if (updated)
            {
                ResetTasks();
            }
            else
            {
                string box_msg = "Ha ocurrido un error esto puede deberse a un fallo en la conexion o este campo no se puede editar.";
                string box_title = "Hubo un error.";

                MessageBox.Show(box_msg, box_title);

                ResetTasks();
            }
        }
    }
}
