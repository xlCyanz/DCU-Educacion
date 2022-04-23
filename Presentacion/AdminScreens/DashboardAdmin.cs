using System;
using System.Windows.Forms;

using Datos;

namespace Presentacion.AdminScreens
{
    public partial class DashboardAdmin : Form
    {
        private int childFormNumber = 0;

        public DashboardAdmin()
        {
            InitializeComponent();
        }

        private void ShowNewForm(object sender, EventArgs e)
        {
            Form childForm = new Form();
            childForm.MdiParent = this;
            childForm.Text = "Ventana " + childFormNumber++;
            childForm.Show();
        }

        private void ExitToolsStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void estudianteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddStudent screen = new AddStudent();
            screen.ShowDialog();
        }

        private void profesorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddTeacher screen = new AddTeacher();
            screen.ShowDialog();
        }

        private void DashboardAdmin_Load(object sender, EventArgs e)
        {
            ResetDataTeacher();
            ResetDataStudent();
        }

        public void ResetDataTeacher()
        {
            ServicioTeacher servicioTeacher = new ServicioTeacher();
            this.dataGridView2.DataSource = servicioTeacher.BuscarTodos();
        }

        public void ResetDataStudent()
        {
            ServicioStudent servicioStudent = new ServicioStudent();
            this.dataGridView1.DataSource = servicioStudent.BuscarTodos();
        }

        private void dataGridView2_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            string value = dataGridView2[e.ColumnIndex, e.RowIndex].Value.ToString();
            string column = dataGridView2.Columns[e.ColumnIndex].Name;
            string _id = Convert.ToString(dataGridView2[0, e.RowIndex].Value);

            ServicioTeacher servicioTeacher = new ServicioTeacher();

            bool updated = servicioTeacher.Actualizar(_id, column.ToLower(), value);
            
            if(!updated)
            {
                string box_msg = "Ha ocurrido un error esto puede deberse a un fallo en la conexion o este campo no se puede editar.";
                string box_title = "Hubo un error.";

                MessageBox.Show(box_msg, box_title);
            }
            
            ResetDataTeacher();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int columnIndex = dataGridView2.CurrentCell.ColumnIndex;
            int rowIndex = dataGridView2.CurrentCell.RowIndex;

            string _id = Convert.ToString(dataGridView2[columnIndex, rowIndex].Value);
            
            ServicioTeacher servicioTeacher = new ServicioTeacher();
            bool deleted = servicioTeacher.Borrar(_id);

            if(deleted)
            {
                ResetDataTeacher();
            } else
            {
                string box_msg = "Ha ocurrido un error esto puede deberse a un fallo en la conexion o no existe este registro.";
                string box_title = "Hubo un error.";

                MessageBox.Show(box_msg, box_title);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int columnIndex = dataGridView2.CurrentCell.ColumnIndex;
            int rowIndex = dataGridView2.CurrentCell.RowIndex;

            string _id = Convert.ToString(dataGridView2[columnIndex, rowIndex].Value);

            ServicioStudent servicioStudent = new ServicioStudent();
            bool deleted = servicioStudent.Borrar(_id);

            if (deleted)
            {
                ResetDataStudent();
            }
            else
            {
                string box_msg = "Ha ocurrido un error esto puede deberse a un fallo en la conexion o no existe este registro.";
                string box_title = "Hubo un error.";

                MessageBox.Show(box_msg, box_title);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ResetDataStudent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ResetDataTeacher();
        }

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            string value = dataGridView2[e.ColumnIndex, e.RowIndex].Value.ToString();
            string column = dataGridView2.Columns[e.ColumnIndex].Name;
            string _id = Convert.ToString(dataGridView2[0, e.RowIndex].Value);

            ServicioStudent servicioStudent = new ServicioStudent();

            bool updated = servicioStudent.Actualizar(_id, column.ToLower(), value);

            if (updated)
            {
                ResetDataStudent();
            }
            else
            {
                string box_msg = "Ha ocurrido un error esto puede deberse a un fallo en la conexion o este campo no se puede editar.";
                string box_title = "Hubo un error.";

                MessageBox.Show(box_msg, box_title);

                ResetDataStudent();
            }
        }
    }
}
