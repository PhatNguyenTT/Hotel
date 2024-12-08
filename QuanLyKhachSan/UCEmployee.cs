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
    public partial class UCEmployee : UserControl
    {
        string connectionString = "Data Source=AAAAA;Initial Catalog=QuanLyKhachSan;Integrated Security=True;Encrypt=True;TrustServerCertificate=True";
        function func = new function();
        string query;
        public UCEmployee()
        {
            InitializeComponent();
        }

        private void UCEmployee_Load(object sender, EventArgs e)
        {
            getMaxID();
        }


        //
        public void getMaxID()
        {
            query = "SELECT MAX(employeeID) FROM Employee";

            using (SqlConnection con = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(query, con))
            {
                con.Open();
                object result = cmd.ExecuteScalar();

                if (result != DBNull.Value)
                {
                    Int64 num = Convert.ToInt64(result);
                    lbl_ID.Text = (num + 1).ToString();
                }
            }
        }


        private void btnRegistration_Click(object sender, EventArgs e)
        {
            if (txtName.Text != "" && txtPhoneNumber.Text != "" && cboGender.Text != "" && txtEmail.Text != "" && txtUsername.Text != "" && txtPassword.Text != "" && txtRePassword.Text == txtPassword.Text)
            {
                string name = txtName.Text;
                string mobile = txtPhoneNumber.Text; 
                string gender = cboGender.Text;
                string email = txtEmail.Text;
                string username = txtUsername.Text;
                string password = txtPassword.Text;

                string query = @"INSERT INTO Employee (employeeName, mobile, gender, emailID, userName, pass) 
                         VALUES (@name, @mobile, @gender, @Email, @Username, @Password)";

                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@name", name);
                        cmd.Parameters.AddWithValue("@mobile", mobile);
                        cmd.Parameters.AddWithValue("@gender", gender);
                        cmd.Parameters.AddWithValue("@Email", email);
                        cmd.Parameters.AddWithValue("@Username", username);
                        cmd.Parameters.AddWithValue("@Password", password);

                        cmd.ExecuteNonQuery(); 
                    }
                }

                MessageBox.Show("Đăng ký thành công!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                clearData(); 
                getMaxID(); 
            }
            else
            {
                MessageBox.Show("Bạn chưa điền đủ thông tin hoặc mật khẩu nhập lại chưa đúng!", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }


        public void clearData()
        {
            txtName.Clear();
            txtPhoneNumber.Clear();
            cboGender.SelectedIndex = -1;
            txtUsername.Clear();
            txtEmail.Clear();
            txtPassword.Clear();
            txtRePassword.Clear();
        }

        private void tabEmployee_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabEmployee.SelectedIndex == 1)
            {
                setEmployee(dtgvCustomerDetails);
            }
            else if (tabEmployee.SelectedIndex == 2)
            {
                setEmployee(dtgvCustomerDelete);
            }
        }

        public void setEmployee(DataGridView dtgv)
        {
            query = "SELECT * FROM Employee";

            using (SqlConnection con = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(query, con))
            using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
            {
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                dtgv.DataSource = dataTable;
            }
        }


        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (txtEmployeeID.Text != "")
            {
                if (MessageBox.Show("Bạn có chắc chắn muốn xóa?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    query = "DELETE FROM Employee WHERE employeeID = @employeeID";

                    using (SqlConnection con = new SqlConnection(connectionString))
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@employeeID", txtEmployeeID.Text);

                        con.Open();
                        cmd.ExecuteNonQuery();
                    }

                    MessageBox.Show("Thông tin nhân viên đã được xóa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    tabEmployee_SelectedIndexChanged(this, null);
                }
            }
        }


        private void UCEmployee_Leave(object sender, EventArgs e)
        {
            clearData();
        }
    }
}
