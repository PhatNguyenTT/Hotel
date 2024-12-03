using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyKhachSan
{
    public partial class MainWindow : Form
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void MainWindow_Load(object sender, EventArgs e)
        {
            ucAddRoom1.Visible = false;
            ucRegistration1.Visible = false;
        }

        private void btnAddRoom_Click(object sender, EventArgs e)
        {
            PanelMoving.Left = btnAddRoom.Left + 25;
            ucAddRoom1.Visible = true;
            ucAddRoom1.BringToFront();
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            PanelMoving.Left = btnRegister.Left + 25;
            ucRegistration1.Visible = true;
            ucRegistration1.BringToFront();
        }

        private void btnMinimize_Click(object sender, EventArgs e)
        {

        }
    }
}
