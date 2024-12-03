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

        private void UCRegistration_Load(object sender, EventArgs e)
        {

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
            string query = $@"SELECT roomNo FROM Rooms 
                  WHERE bed = '{cboRoomBed.Text}'
                  AND roomType = '{cboRoomType.Text}'
                  AND booked = 'NO'";
            setComboBox(query, cboRoomNo);
        }

        int roomID;
        private void cboRoomNo_SelectedIndexChanged(object sender, EventArgs e)
        {
            string query = $@"SELECT price, roomID FROM Rooms
                            WHERE roomNo = {cboRoomNo.Text}";
            DataSet dataSet = func.getDataSet(query);
            txtRoomPrice.Text = dataSet.Tables[0].Rows[0][0].ToString();
            roomID = int.Parse(dataSet.Tables[0].Rows[0][1].ToString());
        }

        private void btnAllotCustomer_Click(object sender, EventArgs e)
        {
            if (txtName.Text != "" && txtPhoneNumber.Text != "" && txtNationality.Text != "" && cboGender.Text != "" && dtpDob.Text != "" &&
                txtIDProof.Text != "" && txtAddress.Text != "" && dtpCheckin.Text != "" && txtRoomPrice.Text != "")
            {
                string name  = txtName.Text;
                Int64 phone = Int64.Parse(txtPhoneNumber.Text);
                string nationality = txtNationality.Text;
                string gender = cboGender.Text;
                string dob = dtpDob.Value.ToString("yyyy-MM-dd");
                string idproof = txtIDProof.Text;
                string address = txtAddress.Text;
                string checkin = dtpCheckin.Value.ToString("yyyy-MM-dd");

                query = $@"INSERT INTO Customer (customerName, mobile, nationality, gender, dob, idproof, address, checkin, roomID) values
                        ('{name}', '{phone}', '{nationality}', '{gender}', '{dob}', '{idproof}', '{address}', '{checkin}', '{roomID}')
                        UPDATE Rooms
                        SET booked = 'YES'
                        WHERE roomNo =  '{cboRoomNo.Text}'";
                func.setData(query, "Bạn đã đăng ký phòng " + cboRoomNo.Text + " thành công!");
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
