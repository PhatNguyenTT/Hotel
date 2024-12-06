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
    public partial class UCEmployee : UserControl
    {
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
            DataSet dataSet = func.getDataSet(query);

            if (dataSet.Tables[0].Rows[0][0].ToString() != "")
            {
                Int64 num = Int64.Parse(dataSet.Tables[0].Rows[0][0].ToString());
                lbl_ID.Text = (num + 1).ToString();        
            }

        }

        private void btnRegistration_Click(object sender, EventArgs e)
        {
            if (txtName.Text != "" && txtPhoneNumber.Text != "" && cboGender.Text != "" && txtEmail.Text != "" && txtUsername.Text != "" && txtPassword.Text != "" && txtRePassword.Text == txtPassword.Text)
            {
                string name = txtName.Text;
                Int64 mobile = Int64.Parse(txtPhoneNumber.Text);
                string gender = cboGender.Text;
                string email = txtEmail.Text;
                string username = txtUsername.Text;
                string password = txtPassword.Text;

                query = $@"INSERT INTO Employee (employeeName, mobile, gender, emailID, userName, pass) VALUES
                        ('{name}', '{mobile}', '{gender}', '{email}', '{username}', '{password}')";
                func.setData(query, "Đăng ký thành công!");

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
            DataSet dataSet = func.getDataSet(query);
            dtgv.DataSource = dataSet.Tables[0];
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if(txtEmployeeID.Text != "")
            {
                if(MessageBox.Show("Bạn có chắc chắn muốn xóa?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    query = $@"DELETE FROM Employee WHERE employeeID = '{txtEmployeeID.Text}'";
                    func.setData(query, "Thông tin nhân viên đã được xóa thành công!");
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
