using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyKhachSan
{
    public partial class UCCheckOut : UserControl
    {
        function func = new function();
        string query;
        public UCCheckOut()
        {
            InitializeComponent();
        }

        private void UCCheckOut_Load(object sender, EventArgs e)
        {
            query = $@"SELECT Customer.customerID, Customer.customerName, Customer.mobile, Customer.nationality, Customer.gender, Customer.dob, Customer.idProof, customer.address,
                    customer.checkin, Rooms.roomNo, Rooms.roomType, Rooms.bed, Rooms.price
                    FROM Customer INNER JOIN Rooms
                    ON Customer.roomID = Rooms.roomID
                    WHERE checkoutStatus = 'NO'";
            DataSet dataSet = func.getDataSet(query);
            dtgvCheckOut.DataSource = dataSet.Tables[0];
        }

        private void txtSearchName_TextChanged(object sender, EventArgs e)
        {
            query = $@"SELECT Customer.customerID, Customer.customerName, Customer.mobile, Customer.nationality, Customer.gender, Customer.dob, Customer.idProof, customer.address,
                    customer.checkin, Rooms.roomNo, Rooms.roomType, Rooms.bed, Rooms.price
                    FROM Customer INNER JOIN Rooms
                    ON Customer.roomID = Rooms.roomID
                    WHERE customerName LIKE '{txtSearchName.Text}%'
                    AND checkoutStatus = 'NO'";

            DataSet dataSet = func.getDataSet(query);
            dtgvCheckOut.DataSource = dataSet.Tables[0];
        }

        int ID;
        private void dtgvCheckOut_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dtgvCheckOut.Rows[e.RowIndex].Cells[e.RowIndex].Value != null)
            {
                ID = int.Parse(dtgvCheckOut.Rows[e.RowIndex].Cells[0].Value.ToString());
                txtName.Text = dtgvCheckOut.Rows[e.RowIndex].Cells[1].Value.ToString();
                txtRoomNumber.Text = dtgvCheckOut.Rows[e.RowIndex].Cells[2].Value.ToString();
            }
        }

        private void btnCheckOut_Click(object sender, EventArgs e)
        {
            if (txtName.Text != "")
            {
                if(MessageBox.Show("Bạn có chắc chắn muốn thanh toán?", "Xác nhận", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    string customerDate = dtpCheckOut.Value.ToString("yyyy-MM-dd");
                    query = $@"UPDATE Customer
                            SET checkoutStatus = 'YES', 
                                checkout = '{customerDate}' WHERE customerID = '{ID}' 
                                                            UPDATE Rooms SET booked = 'NO' WHERE roomNo = '{txtRoomNumber.Text}'";
                    func.setData(query, "Thanh toán thành công!");
                    UCCheckOut_Load(this, null);
                    clearData();
                } 
            }
            else
            {
                MessageBox.Show("Không có khách hàng phù hợp!", "Thông tin", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        public void clearData()
        {
            txtName.Clear();
            txtSearchName.Clear();
            txtRoomNumber.Clear();
            dtpCheckOut.ResetText();
        }

        private void UCCheckOut_Leave(object sender, EventArgs e)
        {
            clearData();
        }
    }
}
