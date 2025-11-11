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
    public partial class NhatKiMuaHang : Form
    {
        public NhatKiMuaHang()
        {
            InitializeComponent();
        }

        public void LoadDanhMuc(int tableid)
        {
            string connectionString = "server=.; database=RestaurantManagement; Integrated Security=true;";

            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                string query = @"
            SELECT 
                b.ID,
                b.Name AS BillName,
                t.Name AS TableName,
                b.Amount,
                b.Discount,
                b.Tax,
                b.Status,
                b.CheckoutDate,
                b.Account
            FROM Bills b
            JOIN [Table] t ON b.TableID = t.ID
            WHERE b.TableID = @TableID";

                SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
                sqlCommand.Parameters.AddWithValue("@TableID", tableid);

                sqlConnection.Open();
                SqlDataReader reader = sqlCommand.ExecuteReader();

                DisplayBill(reader);
                sqlConnection.Close();
            }

            TinhTong(tableid);
        }

        private void DisplayBill(SqlDataReader reader)
        {
            lvBill.Items.Clear();

            while (reader.Read())
            {
                ListViewItem item = new ListViewItem(reader["BillName"].ToString()); // Tên hóa đơn
                lvBill.Items.Add(item);

                item.SubItems.Add(reader["TableName"].ToString());   // Tên bàn
                item.SubItems.Add(reader["Amount"].ToString());      // Số tiền
                item.SubItems.Add(reader["Discount"].ToString());    // Giảm giá
                item.SubItems.Add(reader["Tax"].ToString());         // Thuế
                item.SubItems.Add(Convert.ToBoolean(reader["Status"]) ? "Đã thanh toán" : "Chưa thanh toán");
                item.SubItems.Add(reader["CheckoutDate"].ToString()); // Ngày thanh toán
                item.SubItems.Add(reader["Account"].ToString());     // Tài khoản
            }
        }

        private void TinhTong(int tableid)
        {
            string connectionString = "server=.; database=RestaurantManagement; Integrated Security=true;";

            decimal tongTien = 0;
            decimal tongThue = 0;
            decimal tongGiamGia = 0;
            int tongHoaDon = 0;

            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                string query = @"
            SELECT 
                COUNT(DISTINCT b.ID) AS TongHoaDon,
                SUM(bd.Quantity * f.Price) AS TongTien,
                SUM(ISNULL(b.Tax, 0)) AS TongThue,
                SUM(ISNULL(b.Discount, 0)) AS TongGiamGia
            FROM Bills b
            JOIN BillDetails bd ON b.ID = bd.InvoiceID
            JOIN Food f ON bd.FoodID = f.ID
            WHERE b.TableID = @TableID";

                SqlCommand command = new SqlCommand(query, sqlConnection);
                command.Parameters.AddWithValue("@TableID", tableid);

                sqlConnection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    tongHoaDon = reader["TongHoaDon"] != DBNull.Value ? Convert.ToInt32(reader["TongHoaDon"]) : 0;
                    tongTien = reader["TongTien"] != DBNull.Value ? Convert.ToDecimal(reader["TongTien"]) : 0;
                    tongThue = reader["TongThue"] != DBNull.Value ? Convert.ToDecimal(reader["TongThue"]) : 0;
                    tongGiamGia = reader["TongGiamGia"] != DBNull.Value ? Convert.ToDecimal(reader["TongGiamGia"]) : 0;
                }

                sqlConnection.Close();
            }

            // Gợi ý: hiển thị lên Label hoặc TextBox trên Form
            lblTongHoaDon.Text = tongHoaDon.ToString();
            lblTongTien.Text = tongTien.ToString("N0") + " VNĐ";
            lblTongThue.Text = tongThue.ToString("N0") + " VNĐ";
            lblTongGiamGia.Text = tongGiamGia.ToString("N0") + " VNĐ";
        }

        private void NhatKiMuaHang_Load(object sender, EventArgs e)
        {
            
        }
    }
}
