using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
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
            ucAddRoom1.Visible = true;
            ucRegistration1.Visible = false;
            ucCheckOut1.Visible = false;
            ucCustomerDetails1.Visible = false;
            ucEmployee1.Visible = false;
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
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnCheckOut_Click(object sender, EventArgs e)
        {
            PanelMoving.Left = btnCheckOut.Left + 25;
            ucCheckOut1.Visible = true;
            ucCheckOut1.BringToFront();
        }

        private void btnCustomerDetails_Click(object sender, EventArgs e)
        {
            PanelMoving.Left = btnCustomerDetails.Left + 25;
            ucCustomerDetails1.Visible = true;
            ucCustomerDetails1.BringToFront();
        }

        private void btnEmployee_Click(object sender, EventArgs e)
        {
            PanelMoving.Left = btnEmployee.Left + 25;
            ucEmployee1.Visible = true;
            ucEmployee1.BringToFront();
        }

        private void btnAddRoom_MouseEnter(object sender, EventArgs e)
        {
            btnAddRoom.FillColor = Color.FromArgb(255, 123, 123);
        }

        private void btnAddRoom_MouseLeave(object sender, EventArgs e)
        {
            btnAddRoom.FillColor = Color.DodgerBlue;
        }

        private void btnRegister_MouseEnter(object sender, EventArgs e)
        {
            btnRegister.FillColor = Color.FromArgb(255, 123, 123);
        }

        private void btnRegister_MouseLeave(object sender, EventArgs e)
        {
            btnRegister.FillColor = Color.DodgerBlue;
        }

        private void btnCheckOut_MouseEnter(object sender, EventArgs e)
        {
            btnCheckOut.FillColor = Color.FromArgb(255, 123, 123);
        }

        private void btnCheckOut_MouseLeave(object sender, EventArgs e)
        {
            btnCheckOut.FillColor = Color.DodgerBlue;
        }

        private void btnCustomerDetails_MouseEnter(object sender, EventArgs e)
        {
            btnCustomerDetails.FillColor = Color.FromArgb(255, 123, 123);
        }

        private void btnCustomerDetails_MouseLeave(object sender, EventArgs e)
        {
            btnCustomerDetails.FillColor = Color.DodgerBlue;
        }

        private void btnEmployee_MouseEnter(object sender, EventArgs e)
        {
            btnEmployee.FillColor = Color.FromArgb(255, 123, 123);
        }

        private void btnEmployee_MouseLeave(object sender, EventArgs e)
        {
            btnEmployee.FillColor = Color.DodgerBlue;
        }   
    }
}
