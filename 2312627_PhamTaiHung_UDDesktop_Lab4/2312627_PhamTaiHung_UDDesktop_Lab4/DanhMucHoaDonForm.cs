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

namespace _2312627_PhamTaiHung_UDDesktop_Lab4
{
    public partial class DanhMucHoaDonForm : Form
    {
        public DanhMucHoaDonForm()
        {
            InitializeComponent();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lbNgay.SelectedItem != null)
            {
                DateTime selectedDate = DateTime.Parse(lbNgay.SelectedItem.ToString());
                LoadChiTietHoaDon(selectedDate);
            }
        }

        private void LoadChiTietHoaDon(DateTime checkoutDate)
        {
            string connectionString = "server=.; database=RestaurantManagement; Integrated Security=true;";

            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                SqlCommand sqlCommand = sqlConnection.CreateCommand();

                
                sqlCommand.CommandText = @"
        SELECT 
            A.ID AS BillID,
            A.Name AS BillName,
            C.Name AS TableName,
            A.Discount,
            A.Tax,
            D.Name AS FoodName,
            B.Quantity
        FROM Bills A
        JOIN BillDetails B ON A.ID = B.InvoiceID
        JOIN [Table] C ON A.TableID = C.ID
        JOIN Food D ON B.FoodID = D.ID
        WHERE A.CheckoutDate >= @StartOfDay AND A.CheckoutDate < @EndOfDay";

                // ✅ Gán tham số chính xác cho cả ngày
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





        private void DanhMucHoaDonForm_Load(object sender, EventArgs e)
        {
            
        }
        public void LoadDanhMuc(int tableid)
        {
            string connectionString = "server=.; database=RestaurantManagement; Integrated Security=true;";

            // Tạo đối tượng kết nối
            SqlConnection sqlConnection = new SqlConnection(connectionString);

            // Tạo đối tượng thực thi lệnh
            SqlCommand sqlCommand = sqlConnection.CreateCommand();

            // Thiết lập lệnh truy vấn cho đối tượng Command
            string query = "SELECT CheckoutDate From Bills where TableID = " + tableid ;
            sqlCommand.CommandText = query;

            // Mở kết nối tới cơ sở dữ liệu
            sqlConnection.Open();

            // Thực thi lệnh bằng phương thức ExecuteReader
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

            // Gọi hàm hiển thị dữ liệu lên màn hình
            this.DisplayBill(sqlDataReader);

            // Đóng kết nối
            sqlConnection.Close();
        }

        private void DisplayBill(SqlDataReader reader)
        {
            // Xóa tất cả các dòng hiện tại
            lbNgay.Items.Clear();

            // Đọc một dòng dữ liệu
            while (reader.Read())
            {
                // Tạo một dòng mới trong ListView
                string item = reader["CheckoutDate"].ToString();

                // Thêm dòng mới vào ListView
                lbNgay.Items.Add(item);
            }
        }

        private void lbNgay_Click(object sender, EventArgs e)
        {

        }
    }
}
