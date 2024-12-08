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
    public partial class UCCustomerDetails : UserControl
    {
        string connectionString = "Data Source=AAAAA;Initial Catalog=QuanLyKhachSan;Integrated Security=True;Encrypt=True;TrustServerCertificate=True";
        function func = new function();
        string query;
        public UCCustomerDetails()
        {
            InitializeComponent();
        }

        private void cboCustomerType_SelectedIndexChanged(object sender, EventArgs e)
        {
            string baseQuery = @"SELECT Customer.customerID, Customer.customerName, Customer.mobile, Customer.nationality, Customer.gender, Customer.dob, Customer.idProof, customer.address,
                         customer.checkin, Rooms.roomNo, Rooms.roomType, Rooms.bed, Rooms.price
                         FROM Customer INNER JOIN Rooms
                         ON Customer.roomID = Rooms.roomID";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;

                    if (cboCustomerType.SelectedIndex == 0)
                    {
                        cmd.CommandText = baseQuery;
                    }
                    else if (cboCustomerType.SelectedIndex == 1)
                    {
                        cmd.CommandText = baseQuery + " WHERE checkout IS NULL";
                    }
                    else if (cboCustomerType.SelectedIndex == 2)
                    {
                        cmd.CommandText = baseQuery + " WHERE checkout IS NOT NULL";
                    }

                    conn.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataSet dataSet = new DataSet();
                    adapter.Fill(dataSet);

                    dtgvCustomerDetails.DataSource = dataSet.Tables[0];
                }
            }
        }


        private void getRecord(string query)
        {
            DataSet dataSet = func.getDataSet(query);
            dtgvCustomerDetails.DataSource = dataSet.Tables[0];
        }
    }
}
