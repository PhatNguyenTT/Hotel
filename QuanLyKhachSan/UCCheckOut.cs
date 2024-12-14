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
        string connectionString = "Data Source=AAAAA;Initial Catalog=QuanLyKhachSan;Integrated Security=True;Encrypt=True;TrustServerCertificate=True";
        function func = new function();
        string query;
        public UCCheckOut()
        {
            InitializeComponent();
        }

        private void UCCheckOut_Load(object sender, EventArgs e)
        {
            query = @"SELECT Customer.customerID, Customer.customerName, Customer.mobile, Customer.nationality, Customer.gender, Customer.dob, Customer.idProof, customer.address,
            customer.checkin, Rooms.roomNo, Rooms.roomType, Rooms.bed, Rooms.price
            FROM Customer INNER JOIN Rooms
            ON Customer.roomID = Rooms.roomID
            WHERE checkoutStatus = @CheckoutStatus";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@CheckoutStatus", "NO");

                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataSet dataSet = new DataSet();
                    adapter.Fill(dataSet);

                    dtgvCheckOut.DataSource = dataSet.Tables[0];
                }
            }
        }


        private void txtSearchName_TextChanged(object sender, EventArgs e)
        {
            query = @"SELECT Customer.customerID, Customer.customerName, Customer.mobile, Customer.nationality, Customer.gender, Customer.dob, Customer.idProof, customer.address,
            customer.checkin, Rooms.roomNo, Rooms.roomType, Rooms.bed, Rooms.price
            FROM Customer INNER JOIN Rooms
            ON Customer.roomID = Rooms.roomID
            WHERE customerName LIKE @CustomerName AND checkoutStatus = @CheckoutStatus";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@CustomerName", txtSearchName.Text + "%");
                    cmd.Parameters.Add("@CheckoutStatus", SqlDbType.NVarChar).Value = "NO";

                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataSet dataSet = new DataSet();
                    adapter.Fill(dataSet);

                    dtgvCheckOut.DataSource = dataSet.Tables[0];
                }
            }
        }


        int ID;
        private void dtgvCheckOut_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dtgvCheckOut.Rows[e.RowIndex].Cells[e.RowIndex].Value != null)
            {
                ID = int.Parse(dtgvCheckOut.Rows[e.RowIndex].Cells[0].Value.ToString());
                txtName.Text = dtgvCheckOut.Rows[e.RowIndex].Cells[1].Value.ToString();
                txtRoomNumber.Text = dtgvCheckOut.Rows[e.RowIndex].Cells[9].Value.ToString();
            }
        }

        private void btnCheckOut_Click(object sender, EventArgs e)
        {
            if (txtName.Text != "")
            {
                if (MessageBox.Show("Bạn có chắc chắn muốn thanh toán?", "Xác nhận", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    string customerDate = dtpCheckOut.Value.ToString("yyyy-MM-dd");

                    using (SqlConnection conn = new SqlConnection(connectionString))
                    {
                        conn.Open();
                        using (SqlTransaction transaction = conn.BeginTransaction())
                        {
                            try
                            {
                                string updateCustomerQuery = @"UPDATE Customer 
                                                       SET checkoutStatus = @CheckoutStatus, 
                                                           checkout = @CheckoutDate 
                                                       WHERE customerID = @CustomerID";

                                using (SqlCommand cmd = new SqlCommand(updateCustomerQuery, conn, transaction))
                                {
                                    cmd.Parameters.AddWithValue("@CheckoutStatus", "YES");
                                    cmd.Parameters.AddWithValue("@CheckoutDate", customerDate);
                                    cmd.Parameters.AddWithValue("@CustomerID", ID);
                                    cmd.ExecuteNonQuery();
                                }

                                string updateRoomQuery = @"UPDATE Rooms 
                                                   SET booked = @Booked 
                                                   WHERE roomNo = @RoomNumber";

                                using (SqlCommand cmd = new SqlCommand(updateRoomQuery, conn, transaction))
                                {
                                    cmd.Parameters.AddWithValue("@Booked", "NO");
                                    cmd.Parameters.AddWithValue("@RoomNumber", txtRoomNumber.Text);
                                    cmd.ExecuteNonQuery();
                                }

                                transaction.Commit();
                                MessageBox.Show("Thanh toán thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                UCCheckOut_Load(this, null);
                                clearData();
                            }
                            catch (Exception ex)
                            {
                                transaction.Rollback();
                                MessageBox.Show("Đã xảy ra lỗi trong quá trình thanh toán: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
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
