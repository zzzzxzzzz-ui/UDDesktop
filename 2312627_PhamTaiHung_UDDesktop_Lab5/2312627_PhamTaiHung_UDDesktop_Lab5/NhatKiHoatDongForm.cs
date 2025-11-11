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

namespace _2312627_PhamTaiHung_UDDesktop_Lab5
{
    public partial class NhatKiHoatDongForm : Form
    {
        public NhatKiHoatDongForm()
        {
            InitializeComponent();
        }

        public void LoadDanhMuc(string account)
        {
            string connectionString = "server=.; database=RestaurantManagement; Integrated Security=true;";

            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                SqlCommand sqlCommand = sqlConnection.CreateCommand();
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.CommandText = "Bill_GetCheckoutDateAccount";

                // Gán tham số
                sqlCommand.Parameters.Add("@account", SqlDbType.NVarChar, 100).Value = account;

                sqlConnection.Open();
                SqlDataReader reader = sqlCommand.ExecuteReader();

                DisplayBill(reader);
            }
        }

        private void DisplayBill(SqlDataReader reader)
        {
            lbNgay.Items.Clear();

            while (reader.Read())
            {
                string item = reader["CheckoutDate"].ToString();
                lbNgay.Items.Add(item);
            }
        }

        private void NhatKiHoatDongForm_Load(object sender, EventArgs e)
        {
            
        }

        private void LoadChiTietHoaDon(DateTime checkoutDate)
        {
            string connectionString = "server=.; database=RestaurantManagement; Integrated Security=true;";

            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                SqlCommand sqlCommand = sqlConnection.CreateCommand();
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.CommandText = "Bill_GetDetailByDate";

                // Truyền tham số cho thủ tục
                sqlCommand.Parameters.Add("@StartOfDay", SqlDbType.DateTime).Value = checkoutDate.Date;
                sqlCommand.Parameters.Add("@EndOfDay", SqlDbType.DateTime).Value = checkoutDate.Date.AddDays(1);

                sqlConnection.Open();
                SqlDataReader reader = sqlCommand.ExecuteReader();

                DisplayChiTietHoaDon(reader);
            }
        }

        private void DisplayChiTietHoaDon(SqlDataReader reader)
        {
            lvChiTiet.Items.Clear();

            while (reader.Read())
            {
                ListViewItem item = new ListViewItem(reader["BillID"].ToString());
                item.SubItems.Add(reader["BillName"].ToString());
                item.SubItems.Add(reader["TableName"].ToString());
                item.SubItems.Add(reader["Discount"].ToString());
                item.SubItems.Add(reader["Tax"].ToString());
                item.SubItems.Add(reader["FoodName"].ToString());
                item.SubItems.Add(reader["Quantity"].ToString());

                lvChiTiet.Items.Add(item);
            }
        }

        private void lbNgay_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lbNgay.SelectedItem != null)
            {
                DateTime selectedDate = DateTime.Parse(lbNgay.SelectedItem.ToString());
                LoadChiTietHoaDon(selectedDate);
            }
        }
    }
}
