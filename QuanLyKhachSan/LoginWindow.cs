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
    public partial class LoginWindow : Form
    {
        public LoginWindow()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if(txtUsername.Text == "a" &&  txtPassword.Text == "")
            {
                lblError.Visible = false;
                MainWindow window = new MainWindow(); 
                this.Hide();
                window.Show();
            }
            else
            {
                lblError.Visible = true;
                txtPassword.Text = "";
            }
        }
    }
}
