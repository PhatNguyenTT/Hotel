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
    public partial class UCCustomerDetails : UserControl
    {
        function func = new function();
        string query;
        public UCCustomerDetails()
        {
            InitializeComponent();
        }

        private void cboCustomerType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cboCustomerType.SelectedIndex == 0)
            {
                query = $@"SELECT Customer.customerID, Customer.customerName, Customer.mobile, Customer.nationality, Customer.gender, Customer.dob, Customer.idProof, customer.address,
                        customer.checkin, Rooms.roomNo, Rooms.roomType, Rooms.bed, Rooms.price
                        FROM Customer INNER JOIN Rooms
                        ON Customer.roomID = Rooms.roomID";
                getRecord(query);
            }
            else if(cboCustomerType.SelectedIndex == 1)
            {
                query = $@"SELECT Customer.customerID, Customer.customerName, Customer.mobile, Customer.nationality, Customer.gender, Customer.dob, Customer.idProof, customer.address,
                        customer.checkin, Rooms.roomNo, Rooms.roomType, Rooms.bed, Rooms.price
                        FROM Customer INNER JOIN Rooms
                        ON Customer.roomID = Rooms.roomID
                        WHERE checkout is NULL";
                getRecord(query);
            }
            else if(cboCustomerType.SelectedIndex == 2)
            {
                query = $@"SELECT Customer.customerID, Customer.customerName, Customer.mobile, Customer.nationality, Customer.gender, Customer.dob, Customer.idProof, customer.address,
                        customer.checkin, Rooms.roomNo, Rooms.roomType, Rooms.bed, Rooms.price
                        FROM Customer INNER JOIN Rooms
                        ON Customer.roomID = Rooms.roomID
                        WHERE checkout is NOT NULL";
                getRecord(query);
            }
        }

        private void getRecord(string query)
        {
            DataSet dataSet = func.getDataSet(query);
            dtgvCustomerDetails.DataSource = dataSet.Tables[0];
        }
    }
}
