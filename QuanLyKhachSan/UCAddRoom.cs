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
    }
}
