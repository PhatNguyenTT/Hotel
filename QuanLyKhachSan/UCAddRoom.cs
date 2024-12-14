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

    public partial class UCAddRoom : UserControl
    {
        string connectionString = "Data Source=AAAAA;Initial Catalog=QuanLyKhachSan;Integrated Security=True;Encrypt=True;TrustServerCertificate=True";
        function func = new function();
        string query;
        public UCAddRoom()
        {
            InitializeComponent();
        }

        private void UCAddRoom_Load(object sender, EventArgs e)
        {
            query = $@"SELECT * FROM Rooms";
            DataSet dataSet = func.getDataSet(query);
            dtgvAddRoom.DataSource = dataSet.Tables[0]; 
        }

        private void btnRoomAdd_Click(object sender, EventArgs e)
        {
            if (txtRoomNo.Text != "" && cboRoomType.Text != "" && cboRoomBed.Text != "" && txtRoomPrice.Text != "")
            {
                string no = txtRoomNo.Text;
                string type = cboRoomType.Text;
                string bed = cboRoomBed.Text;
                string price = txtRoomPrice.Text;

                string query = "INSERT INTO ROOMS (roomNo, roomType, bed, price) VALUES (@roomNo, @roomType, @bed, @price)";

                using (SqlConnection con = new SqlConnection(connectionString))
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@roomNo", no);
                    cmd.Parameters.AddWithValue("@roomType", type);
                    cmd.Parameters.AddWithValue("@bed", bed);
                    cmd.Parameters.AddWithValue("@price", price);

                    con.Open();
                    cmd.ExecuteNonQuery();
                }

                MessageBox.Show("Phòng đã được thêm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                UCAddRoom_Load(this, null);
                clearData();
            }
            else
            {
                MessageBox.Show("Bạn chưa điền đủ thông tin!", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }


        public void clearData()
        {
            txtRoomNo.Clear();
            cboRoomBed.SelectedIndex = -1;
            cboRoomType.SelectedIndex = -1;
            txtRoomPrice.Clear();
        }

        private void UCAddRoom_Leave(object sender, EventArgs e)
        {
            clearData();
        }

        private void UCAddRoom_Enter(object sender, EventArgs e)
        {
            UCAddRoom_Load(this, null);
        }

        private void btnRoomDelete_Click(object sender, EventArgs e)
        {
            if (txtRoomNo.Text != "")
            {
                string roomNo = txtRoomNo.Text;

                DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa phòng này?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question) ;

                if (result == DialogResult.No)
                    return;
                

                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    string queryCheck = @"SELECT COUNT(*) FROM Customer 
                                        WHERE roomID = (SELECT roomID FROM Rooms WHERE roomNo = @roomNo) 
                                        AND checkOutStatus = 'NO'";

                    SqlCommand cmdCheck = new SqlCommand(queryCheck, con);
                    cmdCheck.Parameters.AddWithValue("@roomNo", roomNo);

                    con.Open();
                    int count = (int)cmdCheck.ExecuteScalar();

                    if (count > 0)
                    {
                        MessageBox.Show("Không thể xóa phòng này vì đang có khách ở!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }

                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    string queryDelete = "DELETE FROM Rooms WHERE roomNo = @roomNo";
                    SqlCommand cmdDelete = new SqlCommand(queryDelete, con);
                    cmdDelete.Parameters.AddWithValue("@roomNo", roomNo);

                    con.Open();
                    cmdDelete.ExecuteNonQuery();
                }

                MessageBox.Show("Phòng đã được xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                UCAddRoom_Load(this, null);
            }
            else
            {
                MessageBox.Show("Bạn chưa chọn phòng để xóa!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRoomEdit_Click(object sender, EventArgs e)
        {
            if (txtRoomNo.Text != "" && cboRoomType.Text != "" && cboRoomBed.Text != "" && txtRoomPrice.Text != "")
            {
                string no = txtRoomNo.Text;
                string type = cboRoomType.Text;
                string bed = cboRoomBed.Text;
                string price = txtRoomPrice.Text;

                string query = @"UPDATE ROOMS 
                                SET roomType = @roomType, bed = @bed, price = @price
                                WHERE roomNo = @roomNo";

                using (SqlConnection con = new SqlConnection(connectionString))
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@roomNo", no);
                    cmd.Parameters.AddWithValue("@roomType", type);
                    cmd.Parameters.AddWithValue("@bed", bed);
                    cmd.Parameters.AddWithValue("@price", price);

                    try
                    {
                        con.Open();
                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)                        
                            MessageBox.Show("Phòng đã được cập nhật!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        
                        else
                            MessageBox.Show("Không tìm thấy phòng để cập nhật!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Đã xảy ra lỗi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

                UCAddRoom_Load(this, null);
                clearData();
            }
            else
            {
                MessageBox.Show("Bạn chưa điền đủ thông tin!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void dtgvAddRoom_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dtgvAddRoom.Rows[e.RowIndex];

                txtRoomNo.Text = row.Cells["roomNo"].Value.ToString();
                cboRoomType.Text = row.Cells["roomType"].Value.ToString();
                cboRoomBed.Text = row.Cells["bed"].Value.ToString();
                txtRoomPrice.Text = row.Cells["price"].Value.ToString();
            }
        }
    }
}
