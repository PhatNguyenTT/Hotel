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

        private void btnCheckOut_Click(object sender, EventArgs e)
        {

        }

        private void UCEmployee_Load(object sender, EventArgs e)
        {

        }


        //
        public void getMaxID()
        {
            query = "SELECT MAX(employeeID) FROM Employee";
            DataSet dataSet = func.getDataSet(query);

            if (dataSet.Tables[0].Rows[0][0].ToString() != "")
            {
                Int64 num = Int64.Parse(dataSet.Tables[0].Rows[0][0].ToString());
                
            }

        }
    }
}
