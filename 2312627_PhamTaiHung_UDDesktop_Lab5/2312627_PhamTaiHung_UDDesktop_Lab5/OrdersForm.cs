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
    public partial class OrdersForm : Form
    {
        public OrdersForm()
        {
            InitializeComponent();
        }

        private void OrdersForm_Load(object sender, EventArgs e)
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

            DateTime fromDate = new DateTime(1900, 1, 1);
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
            using (SqlCommand command = new SqlCommand("GetDailyRevenue", connection))
            {
                command.CommandType = CommandType.StoredProcedure;

                // Gắn tham số
                command.Parameters.Add("@FromDate", SqlDbType.SmallDateTime).Value = fromDate;
                command.Parameters.Add("@ToDate", SqlDbType.SmallDateTime).Value = toDate;

                try
                {
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
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

                            // Cập nhật label hiển thị (format với dấu phẩy ngăn cách hàng nghìn)
                            lblTongChuaGiamGia.Text = totalBeforeDiscount.ToString("N0") + " VNĐ";
                            lblSoTienGiamGia.Text = totalDiscount.ToString("N0") + " VNĐ";
                            lblThucThuDoanhThu.Text = totalRevenue.ToString("N0") + " VNĐ";
                        }
                        else
                        {
                            lblTongChuaGiamGia.Text = "0 VNĐ";
                            lblSoTienGiamGia.Text = "0 VNĐ";
                            lblThucThuDoanhThu.Text = "0 VNĐ";
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi tính doanh thu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void lvBill_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            ListViewItem listViewItem = lvBill.SelectedItems[0];
            if (!string.IsNullOrEmpty(listViewItem.Text))
            {

                OrderDetailsForm f = new OrderDetailsForm();
                f.LoadOrderDetailForm(int.Parse(listViewItem.Text));
                f.ShowDialog();
            }
            else
            {
                MessageBox.Show("Vui lòng chọn nhóm Hóa đơn.");
            }
        }
    }
}
