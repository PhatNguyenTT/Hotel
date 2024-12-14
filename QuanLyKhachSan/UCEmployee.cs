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
            if (tabControl.SelectedIndex == 1)
            {
                setEmployee(dtgvCustomerDetails);
            }
            else if (tabControl.SelectedIndex == 2)
            {
                setEmployee(dtgvCustomerDelete);
            }
            else if(tabControl.SelectedIndex == 3)
            {
                setEmployee(dtgvEmployeeChangePass);
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

        private void dtgvCustomerDelete_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dtgvCustomerDelete.Rows[e.RowIndex];

                txtEmployeeID.Text = row.Cells["employeeID"].Value.ToString();
                txtEmployeeName.Text = row.Cells["employeeName"].Value.ToString();
                txtEmployeePhone.Text = row.Cells["mobile"].Value.ToString();
                txtEmployeeEmail.Text = row.Cells["emailID"].Value.ToString();
                cboEmployeeGender.Text = row.Cells["gender"].Value.ToString();
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (txtEmployeeID.Text != "") 
            {
                if (MessageBox.Show("Bạn có chắc chắn muốn cập nhật thông tin?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    string employeeID = txtEmployeeID.Text;
                    string name = txtEmployeeName.Text;
                    string phone = txtEmployeePhone.Text;
                    string email = txtEmployeeEmail.Text;
                    string gender = cboEmployeeGender.Text;

                    if (name != "" && phone != "" && email != "" && gender != "")
                    {
                        string query = @"UPDATE Employee SET employeeName = @name, mobile = @phone, emailID = @Email, gender = @Gender
                                         WHERE employeeID = @employeeID";

                        using (SqlConnection con = new SqlConnection(connectionString))
                        using (SqlCommand cmd = new SqlCommand(query, con))
                        {
                            cmd.Parameters.AddWithValue("@employeeID", employeeID);
                            cmd.Parameters.AddWithValue("@name", name);
                            cmd.Parameters.AddWithValue("@phone", phone);
                            cmd.Parameters.AddWithValue("@Email", email);
                            cmd.Parameters.AddWithValue("@Gender", gender);

                            con.Open();
                            int rowsAffected = cmd.ExecuteNonQuery();

                            if (rowsAffected > 0)
                            {
                                MessageBox.Show("Thông tin nhân viên đã được cập nhật thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                tabEmployee_SelectedIndexChanged(this, null); 
                                clearData(); 
                            }
                            else
                            {
                                MessageBox.Show("Cập nhật thất bại! Vui lòng thử lại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Vui lòng nhập đầy đủ thông tin nhân viên!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn nhân viên cần chỉnh sửa!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnChangePassword_Click(object sender, EventArgs e)
        {
            if (txtChangePassID.Text != "") 
            {
                string newPassword = txtNewPass.Text;
                string reNewPassword = txtReNewPass.Text;

                if (!string.IsNullOrEmpty(newPassword) && newPassword == reNewPassword)
                {
                    string query = @"UPDATE Employee SET pass = @newPassword
                                    WHERE employeeID = @employeeID";

                    using (SqlConnection con = new SqlConnection(connectionString))
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@newPassword", newPassword);
                        cmd.Parameters.AddWithValue("@employeeID", txtChangePassID.Text); 

                        try
                        {
                            con.Open();
                            int rowsAffected = cmd.ExecuteNonQuery();

                            if (rowsAffected > 0)
                            {
                                MessageBox.Show("Đổi mật khẩu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                txtNewPass.Clear();
                                txtReNewPass.Clear();
                            }
                            else
                            {
                                MessageBox.Show("Không tìm thấy nhân viên! Vui lòng kiểm tra lại ID.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Lỗi trong quá trình đổi mật khẩu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Mật khẩu mới không khớp hoặc trống! Vui lòng kiểm tra lại.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn nhân viên cần đổi mật khẩu!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }


        private void dtgvEmployeeChangePass_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dtgvEmployeeChangePass.Rows[e.RowIndex];

                txtChangePassID.Text = row.Cells["employeeID"].Value.ToString();
                txtChangePassUsername.Text = row.Cells["userName"].Value.ToString();
            }
        }
    }
}
