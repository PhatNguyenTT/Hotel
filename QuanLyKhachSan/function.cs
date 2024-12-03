using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;

namespace QuanLyKhachSan
{
    internal class function
    {
        protected SqlConnection sqlConnection()
        {
            SqlConnection sqlConnection = new SqlConnection();
            sqlConnection.ConnectionString = "Data Source=AAAAA;Initial Catalog=QuanLyKhachSan;Integrated Security=True;TrustServerCertificate=True";
            return sqlConnection;
        }

        public DataSet getDataSet(string query)
        {
            SqlConnection connection = sqlConnection();
            SqlCommand command = new SqlCommand();
            command.Connection = connection;
            command.CommandText = query;
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataSet dataSet = new DataSet();
            adapter.Fill(dataSet);
            return dataSet;
        }

        public void setData(string query, string message)
        {
            SqlConnection connection = sqlConnection();
            SqlCommand command = new SqlCommand();
            command.Connection = connection;
            connection.Open();
            command.CommandText = query;
            command.ExecuteNonQuery();
            connection.Close();

            MessageBox.Show(message, "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public SqlDataReader getForCombo(string query)
        {
            SqlConnection connection = sqlConnection();
            SqlCommand command = new SqlCommand();
            command.Connection = connection;
            connection.Open();
            command = new SqlCommand(query, connection);
            SqlDataReader dataReader = command.ExecuteReader();
            return dataReader;
        }
    }
}
