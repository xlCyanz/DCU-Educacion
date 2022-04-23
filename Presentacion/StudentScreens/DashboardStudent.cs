using System;
using System.Windows.Forms;

using Datos;

namespace Presentacion.StudentScreens
{
    public partial class DashboardStudent : Form
    {
        public DashboardStudent()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ResetTasks();
        }

        private void DashboardStudent_Load(object sender, EventArgs e)
        {
            ResetTasks();
        }

        private void ResetTasks()
        {
            ServicioTask servicioTask = new ServicioTask();
            this.dataGridView1.DataSource = servicioTask.BuscarTodos();
        }
    }
}
