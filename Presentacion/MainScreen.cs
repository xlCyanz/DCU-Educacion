using System;
using System.Windows.Forms;

using Presentacion.StudentScreens;
using Presentacion.TeacherScreens;
using Presentacion.AdminScreens;

namespace Presentacion
{
    public partial class MainScreen : Form
    {
        public MainScreen()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            LoginStudent screen = new LoginStudent();
            this.Hide();
            screen.ShowDialog();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            LoginTeacher screen = new LoginTeacher();
            this.Hide();
            screen.ShowDialog();
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            LoginAdmin screen = new LoginAdmin();
            this.Hide();
            screen.ShowDialog();
            this.Close();
        }
    }
}
