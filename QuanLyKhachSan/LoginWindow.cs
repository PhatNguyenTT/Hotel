using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyKhachSan
{
    public partial class LoginWindow : Form
    {
        string connectionString = "Data Source=AAAAA;Initial Catalog=QuanLyKhachSan;Integrated Security=True;Encrypt=True;TrustServerCertificate=True";
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
            string query = @"SELECT userName, pass FROM Employee
                     WHERE userName = @userName AND pass = @password";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@userName", txtUsername.Text);
                    cmd.Parameters.AddWithValue("@password", txtPassword.Text);

                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataSet dataSet = new DataSet();

                    conn.Open();
                    adapter.Fill(dataSet);

                    if (dataSet.Tables[0].Rows.Count != 0)
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

    }
}
