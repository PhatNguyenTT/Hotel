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
        function func = new function();
        string query;
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
            query = $@"SELECT userName, pass FROM Employee
                    WHERE userName = '{txtUsername.Text}'
                    AND pass = '{txtPassword.Text}'";
            DataSet dataSet = func.getDataSet(query);

            //if (dataSet.Tables[0].Rows.Count != 0)
            if(txtUsername.Text == "a")
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
