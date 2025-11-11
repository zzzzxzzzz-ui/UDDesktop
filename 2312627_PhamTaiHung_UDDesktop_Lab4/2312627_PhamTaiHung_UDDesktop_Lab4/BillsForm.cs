using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace _2312627_PhamTaiHung_UDDesktop_Lab4
{
    public partial class BillsForm : Form
    {
        public BillsForm()
        {
            InitializeComponent();
        }

        private void BillsForm_Load(object sender, EventArgs e)
        {
            string connectionString = "server=.; database=RestaurantManagement; Integrated Security=true;";

            // Tạo đối tượng kết nối
            SqlConnection sqlConnection = new SqlConnection(connectionString);

            // Tạo đối tượng thực thi lệnh
            SqlCommand sqlCommand = sqlConnection.CreateCommand();

            // Thiết lập lệnh truy vấn cho đối tượng Command
            string query = "SELECT * From Bills";
            sqlCommand.CommandText = query;

            // Mở kết nối tới cơ sở dữ liệu
            sqlConnection.Open();

            // Thực thi lệnh bằng phương thức ExecuteReader
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

            // Gọi hàm hiển thị dữ liệu lên màn hình
            this.DisplayBill(sqlDataReader);

            DateTime fromDate = new DateTime(1753, 1, 1);
            DateTime toDate = DateTime.Now;
            DisplaySummaryByProcedure(fromDate, toDate);

            // Đóng kết nối
            sqlConnection.Close();
        }

        private void DisplayBill(SqlDataReader reader)
        {
            // Xóa tất cả các dòng hiện tại
            lvBill.Items.Clear();

            // Đọc một dòng dữ liệu
            while (reader.Read())
            {
                // Tạo một dòng mới trong ListView
                ListViewItem item = new ListViewItem(reader["ID"].ToString());

                // Thêm dòng mới vào ListView
                lvBill.Items.Add(item);

                // Bổ sung các thông tin khác cho ListViewItem
                item.SubItems.Add(reader["Name"].ToString());
                item.SubItems.Add(reader["TableID"].ToString());
                item.SubItems.Add(reader["Amount"].ToString());
                item.SubItems.Add(reader["Discount"].ToString());
                item.SubItems.Add(reader["Tax"].ToString());
                item.SubItems.Add(reader["Status"].ToString());
                item.SubItems.Add(reader["CheckoutDate"].ToString());
                item.SubItems.Add(reader["Account"].ToString());

            }
        }

        private void LoadBillsByDateRange(DateTime fromDate, DateTime toDate)
        {
            string connectionString = "server=.; database=RestaurantManagement; Integrated Security=true;";
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            SqlCommand sqlCommand = sqlConnection.CreateCommand();

            string query = @"SELECT ID, Name, TableID, Amount, Discount, Tax, Status, CheckoutDate, Account
                     FROM Bills
                     WHERE CheckoutDate BETWEEN @fromDate AND @toDate";

            sqlCommand.CommandText = query;
            sqlCommand.Parameters.AddWithValue("@fromDate", fromDate);
            sqlCommand.Parameters.AddWithValue("@toDate", toDate);

            sqlConnection.Open();
            SqlDataReader reader = sqlCommand.ExecuteReader();
            this.DisplayBill(reader);
            sqlConnection.Close();
        }

        private void btnFilter_Click(object sender, EventArgs e)
        {
            DateTime fromDate = dtpFrom.Value.Date;
            DateTime toDate = dtpTo.Value.Date.AddDays(1).AddTicks(-1);

            LoadBillsByDateRange(fromDate, toDate);
            DisplaySummaryByProcedure(fromDate, toDate);
        }

        private void DisplaySummaryByProcedure(DateTime fromDate, DateTime toDate)
        {
            string connectionString = "server=.; database=RestaurantManagement; Integrated Security=true;";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                // 🔹 Tính tổng tiền thật từ BillDetails × Food
                string query = @"
            SELECT 
                SUM(bd.Quantity * f.Price) AS TotalBeforeDiscount,
                SUM((bd.Quantity * f.Price) * ISNULL(b.Discount, 0) / 100) AS TotalDiscount,
                SUM((bd.Quantity * f.Price) - ((bd.Quantity * f.Price) * ISNULL(b.Discount, 0) / 100)
                    + ((bd.Quantity * f.Price) * ISNULL(b.Tax, 0) / 100)) AS TotalRevenue
            FROM Bills b
            JOIN BillDetails bd ON b.ID = bd.InvoiceID
            JOIN Food f ON bd.FoodID = f.ID
            WHERE b.CheckoutDate BETWEEN @FromDate AND @ToDate;
        ";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@FromDate", fromDate);
                command.Parameters.AddWithValue("@ToDate", toDate);

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    decimal totalBeforeDiscount = reader["TotalBeforeDiscount"] != DBNull.Value
                        ? Convert.ToDecimal(reader["TotalBeforeDiscount"])
                        : 0;

                    decimal totalDiscount = reader["TotalDiscount"] != DBNull.Value
                        ? Convert.ToDecimal(reader["TotalDiscount"])
                        : 0;

                    decimal totalRevenue = reader["TotalRevenue"] != DBNull.Value
                        ? Convert.ToDecimal(reader["TotalRevenue"])
                        : 0;

                    // 🔹 Hiển thị kết quả ra giao diện
                    lblTongChuaGiamGia.Text = totalBeforeDiscount.ToString("N0") + " VNĐ";
                    lblSoTienGiamGia.Text = totalDiscount.ToString("N0") + " VNĐ";
                    lblThucThuDoanhThu.Text = totalRevenue.ToString("N0") + " VNĐ";
                }

                reader.Close();
            }
        }



        private void lvBill_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            ListViewItem listViewItem = lvBill.SelectedItems[0];
            if (!string.IsNullOrEmpty(listViewItem.Text))
            {
                

                BillDetailsForm BillDTForm = new BillDetailsForm();
                BillDTForm.LoadBillDeTails(int.Parse(listViewItem.Text));  
                BillDTForm.ShowDialog();
            }
            else
            {
                MessageBox.Show("Vui lòng chọn nhóm Hóa đơn.");
            }
        }

        private void lvBill_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void lvBill_Click(object sender, EventArgs e)
        {
            

            
        }
    }
}
