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
    public partial class UCRegistration : UserControl
    {
        string connectionString = "Data Source=AAAAA;Initial Catalog=QuanLyKhachSan;Integrated Security=True;Encrypt=True;TrustServerCertificate=True";
        function func = new function();
        string query;
        public UCRegistration()
        {
            InitializeComponent();
        }

        public void setComboBox(string query, ComboBox cbo)
        {
            SqlDataReader dataReader = func.getForCombo(query);
            while(dataReader.Read())
            {
                for(int i = 0; i <  dataReader.FieldCount; i++)
                    cbo.Items.Add(dataReader.GetString(i));
            }
            dataReader.Close();
        }

        private void cboRoomBed_SelectedIndexChanged(object sender, EventArgs e)
        {
            cboRoomType.SelectedIndex = -1;
            cboRoomNo.Items.Clear();
            txtRoomPrice.Clear();
        }

        private void cboRoomType_SelectedIndexChanged(object sender, EventArgs e)
        {
            cboRoomNo.Items.Clear();

            string query = @"SELECT roomNo FROM Rooms 
                     WHERE bed = @bed
                     AND roomType = @roomType
                     AND booked = 'NO'";

            using (SqlConnection con = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(query, con))
            {
                cmd.Parameters.AddWithValue("@bed", cboRoomBed.Text);
                cmd.Parameters.AddWithValue("@roomType", cboRoomType.Text);

                con.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        cboRoomNo.Items.Add(reader["roomNo"].ToString());
                    }
                }
            }
        }


        int roomID;
        private void cboRoomNo_SelectedIndexChanged(object sender, EventArgs e)
        {
            string query = @"SELECT price, roomID FROM Rooms
                     WHERE roomNo = @roomNo";

            using (SqlConnection con = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(query, con))
            {
                cmd.Parameters.AddWithValue("@roomNo", cboRoomNo.Text);

                con.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        txtRoomPrice.Text = reader["price"].ToString();
                        roomID = int.Parse(reader["roomID"].ToString());
                    }
                }
            }
        }


        private void btnAllotCustomer_Click(object sender, EventArgs e)
        {
            if (txtName.Text != "" && txtPhoneNumber.Text != "" && txtNationality.Text != "" && cboGender.Text != "" &&
                dtpDob.Text != "" && txtIDProof.Text != "" && txtAddress.Text != "" && dtpCheckin.Text != "" &&
                txtRoomPrice.Text != "")
            {
                string name = txtName.Text;
                string phone = txtPhoneNumber.Text;
                string nationality = txtNationality.Text;
                string gender = cboGender.Text;
                string dob = dtpDob.Value.ToString("yyyy-MM-dd");
                string idproof = txtIDProof.Text;
                string address = txtAddress.Text;
                string checkin = dtpCheckin.Value.ToString("yyyy-MM-dd");

                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();
                    using (SqlTransaction transaction = con.BeginTransaction())
                    {
                        try
                        {
                            string customerQuery = @"INSERT INTO Customer (customerName, mobile, nationality, gender, dob, idproof, address, checkin, roomID) 
                                             VALUES (@name, @phone, @nationality, @gender, @dob, @idproof, @address, @checkin, @roomID)";

                            using (SqlCommand cmd = new SqlCommand(customerQuery, con, transaction))
                            {
                                cmd.Parameters.AddWithValue("@name", name);
                                cmd.Parameters.AddWithValue("@phone", phone);
                                cmd.Parameters.AddWithValue("@nationality", nationality);
                                cmd.Parameters.AddWithValue("@gender", gender);
                                cmd.Parameters.AddWithValue("@dob", dob);
                                cmd.Parameters.AddWithValue("@idproof", idproof);
                                cmd.Parameters.AddWithValue("@address", address);
                                cmd.Parameters.AddWithValue("@checkin", checkin);
                                cmd.Parameters.AddWithValue("@roomID", roomID);

                                cmd.ExecuteNonQuery();
                            }

                            string updateRoomQuery = @"UPDATE Rooms
                                               SET booked = 'YES'
                                               WHERE roomNo = @roomNo";

                            using (SqlCommand cmd = new SqlCommand(updateRoomQuery, con, transaction))
                            {
                                cmd.Parameters.AddWithValue("@roomNo", cboRoomNo.Text);
                                cmd.ExecuteNonQuery();
                            }

                            transaction.Commit();
                            MessageBox.Show("Bạn đã đăng ký phòng " + cboRoomNo.Text + " thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        catch
                        {
                            transaction.Rollback();
                            MessageBox.Show("Có lỗi xảy ra trong quá trình đăng ký phòng!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }

                clearData();
            }
            else
            {
                MessageBox.Show("Bạn chưa điền đủ thông tin!", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        public void clearData()
        {
            txtName.Clear();
            txtPhoneNumber.Clear();
            txtNationality.Clear();
            cboGender.SelectedIndex = -1;
            dtpDob.ResetText();
            txtIDProof.Clear();
            txtAddress.Clear();
            dtpCheckin.ResetText();
            cboRoomType.SelectedIndex = -1;
            cboRoomBed.SelectedIndex = -1;
            cboRoomNo.Items.Clear();
            txtRoomPrice.Clear();
        }

        private void UCRegistration_Leave(object sender, EventArgs e)
        {
            clearData();
        }
    }
}
