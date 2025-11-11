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
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void tsmiDSMonAn_Click(object sender, EventArgs e)
        {
            CategoryForm categoryForm = new CategoryForm();
            categoryForm.ShowDialog();
        }

        private void tsmiHoaDon_Click(object sender, EventArgs e)
        {
            BillsForm billsForm = new BillsForm();
            billsForm.ShowDialog();
        }

        private void lvBan_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            LoadDanhMuc();

        }
        public void LoadDanhMuc()
        {
            string connectionString = "server=.; database=RestaurantManagement; Integrated Security=true;";

            // Tạo đối tượng kết nối
            SqlConnection sqlConnection = new SqlConnection(connectionString);

            // Tạo đối tượng thực thi lệnh
            SqlCommand sqlCommand = sqlConnection.CreateCommand();

            // Thiết lập lệnh truy vấn cho đối tượng Command
            string query = "SELECT ID, Name, Status, Capacity FROM [Table]";
            sqlCommand.CommandText = query;

            // Mở kết nối tới cơ sở dữ liệu
            sqlConnection.Open();

            // Thực thi lệnh bằng phương thức ExecuteReader
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

            // Gọi hàm hiển thị dữ liệu lên màn hình
            this.DisplayBan(sqlDataReader);

            // Đóng kết nối
            sqlConnection.Close();
        }

        private void DisplayBan(SqlDataReader reader)
        {
            // Xóa tất cả các dòng hiện tại
            lvBan.Items.Clear();

            while (reader.Read())
            {
                ListViewItem item = new ListViewItem(reader["ID"].ToString());

                // Thêm các thông tin khác
                item.SubItems.Add(reader["Name"].ToString());

                // Chuyển Status từ số sang chữ
                string statusText = "";
                int status = Convert.ToInt32(reader["Status"]);
                switch (status)
                {
                    case 0:
                        statusText = "Chưa đặt";
                        break;
                    case 1:
                        statusText = "Đã đặt";
                        break;
                    case 2:
                        statusText = "Có khách";
                        break;
                    default:
                        statusText = "Không xác định";
                        break;
                }
                item.SubItems.Add(statusText);

                item.SubItems.Add(reader["Capacity"].ToString());

                lvBan.Items.Add(item);
            }
        }


        private void tsmiXoa_Click(object sender, EventArgs e)
        {
            ListViewItem item = lvBan.SelectedItems[0];
            string id = item.SubItems[0].Text; // cột đầu tiên chứa ID

            string connectionString = "server=.; database=RestaurantManagement; Integrated Security=true;";
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                SqlCommand sqlCommand = sqlConnection.CreateCommand();

                // Cách 1: Dùng parameter để an toàn và tránh lỗi
                sqlCommand.CommandText = "DELETE FROM [Table] WHERE ID = @id";
                sqlCommand.Parameters.AddWithValue("@id", id);

                sqlConnection.Open();
                int numOfRowsEffected = sqlCommand.ExecuteNonQuery();

                if (numOfRowsEffected == 1)
                {
                    lvBan.Items.Remove(item);
                    MessageBox.Show("Xóa bàn thành công");
                }
                else
                {
                    MessageBox.Show("Đã có lỗi xảy ra. Vui lòng thử lại");
                }
            }
        }

        private void tsmiDanhMucHoaDon_Click(object sender, EventArgs e)
        {
            ListViewItem item = lvBan.SelectedItems[0];
            int id = int.Parse(item.Text);
            DanhMucHoaDonForm form= new DanhMucHoaDonForm();
            form.LoadDanhMuc(id);
            form.ShowDialog();
        }

        private void tsmiXemNhatKiHoaDon_Click(object sender, EventArgs e)
        {
            ListViewItem item = lvBan.SelectedItems[0];
            int id = int.Parse(item.Text);
            NhatKiMuaHang form = new NhatKiMuaHang();
            form.LoadDanhMuc(id);
            form.ShowDialog();
        }

        

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
           
        }

        private void btnThem_Click_1(object sender, EventArgs e)
        {
            string connectionString = "server=.; database=RestaurantManagement; Integrated Security=true;";
            SqlConnection sqlConnection = new SqlConnection(connectionString);

            // Tạo đối tượng thực thi lệnh
            SqlCommand sqlCommand = sqlConnection.CreateCommand();

            // Lệnh INSERT (bảng Ban có cột: Name, Status, Capacity)
            // Status mặc định = 0 (Trống)
            sqlCommand.CommandText =
                "INSERT INTO [Table](Name, Status, Capacity) " +
                "VALUES (N'" + txtTenBan.Text + "', 0, " + txtSucChua.Text + ")";

            // Mở kết nối
            sqlConnection.Open();

            // Thực thi lệnh
            int numOfRowsEffected = sqlCommand.ExecuteNonQuery();

            // Đóng kết nối
            sqlConnection.Close();

            // Kiểm tra kết quả
            if (numOfRowsEffected == 1)
            {
                MessageBox.Show("Thêm bàn mới thành công!");

                
                txtTenBan.Text = "";
                txtSucChua.Text = "";
                txtMaBan.Text = "";
                txtTrangThai.Text = "";

                LoadDanhMuc();

            }
            else
            {
                MessageBox.Show("Đã có lỗi xảy ra. Vui lòng thử lại!");
            }
        }

        private void btnCapNhap_Click(object sender, EventArgs e)
        {
            // Tạo đối tượng kết nối
            string connectionString = "server=.; database=RestaurantManagement; Integrated Security=true;";
            SqlConnection sqlConnection = new SqlConnection(connectionString);

            // Tạo đối tượng thực thi lệnh
            SqlCommand sqlCommand = sqlConnection.CreateCommand();

            // Thiết lập lệnh truy vấn cho đối tượng Command
            sqlCommand.CommandText =
                "UPDATE [Table] SET Name = N'" + txtTenBan.Text +
                "', Capacity = " + txtSucChua.Text +
                
                " WHERE ID = " + txtMaBan.Text;

            // Mở kết nối tới cơ sở dữ liệu
            sqlConnection.Open();

            // Thực thi lệnh bằng phương thức ExecuteNonQuery
            int numOfRowsEffected = sqlCommand.ExecuteNonQuery();

            // Đóng kết nối
            sqlConnection.Close();

            if (numOfRowsEffected == 1)
            {
                // Cập nhật lại dữ liệu hiển thị trên ListView (nếu có)
                if (lvBan.SelectedItems.Count > 0)
                {
                    ListViewItem item = lvBan.SelectedItems[0];
                    item.SubItems[1].Text = txtTenBan.Text;
                   
                    item.SubItems[3].Text = txtSucChua.Text;
                }

                // Xóa các ô nhập
                txtMaBan.Text = "";
                txtTenBan.Text = "";
                txtSucChua.Text = "";
                txtTrangThai.Text = "";
               

                // Disable các nút
                btnCapNhap.Enabled = false;
                btnXoa.Enabled = false;

                MessageBox.Show("Cập nhật bàn thành công!");
            }
            else
            {
                MessageBox.Show("Đã có lỗi xảy ra. Vui lòng thử lại!");
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string connectionString = "server=.; database=RestaurantManagement; Integrated Security=true;";
            SqlConnection sqlConnection = new SqlConnection(connectionString);

            // Tạo đối tượng thực thi lệnh
            SqlCommand sqlCommand = sqlConnection.CreateCommand();

            // Thiết lập lệnh truy vấn cho đối tượng Command
            sqlCommand.CommandText = "DELETE FROM [Table] WHERE ID = " + txtMaBan.Text;

            // Mở kết nối tới cơ sở dữ liệu
            sqlConnection.Open();

            // Thực thi lệnh bằng phương thức ExecuteNonQuery
            int numOfRowsEffected = sqlCommand.ExecuteNonQuery();

            // Đóng kết nối
            sqlConnection.Close();

            if (numOfRowsEffected == 1)
            {
                // Cập nhật lại dữ liệu trên ListView
                if (lvBan.SelectedItems.Count > 0)
                {
                    ListViewItem item = lvBan.SelectedItems[0];
                    lvBan.Items.Remove(item);
                }

                // Xóa các ô nhập
                txtMaBan.Text = "";
                txtTenBan.Text = "";
                txtSucChua.Text = "";
                txtTrangThai.Text = "";
                

                // Disable các nút xóa và cập nhật
                btnCapNhap.Enabled = false;
                btnXoa.Enabled = false;

                MessageBox.Show("Xóa bàn thành công!");
            }
            else
            {
                MessageBox.Show("Đã có lỗi xảy ra. Vui lòng thử lại!");
            }
        }

        private void lvBan_Click(object sender, EventArgs e)
        {
            if (lvBan.SelectedItems.Count == 0)
                return;

            ListViewItem item = lvBan.SelectedItems[0];

            // 🪑 Hiển thị thông tin bàn lên TextBox
            txtMaBan.Text = item.Text;
            txtTenBan.Text = item.SubItems[1].Text;
            txtTrangThai.Text = item.SubItems[2].Text;
            txtSucChua.Text = item.SubItems[3].Text;

            // Bật nút cập nhật và xóa
            btnCapNhap.Enabled = true;
            btnXoa.Enabled = true;

            // 🔹 Hiển thị hóa đơn của bàn này
            try
            {
                int tableID = int.Parse(txtMaBan.Text);
                DataTable dt = GetBillByTableID(tableID);
                DisplayBill(dt);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải hóa đơn: " + ex.Message);
            }
        }

        private void tsmiTaiKhoan_Click(object sender, EventArgs e)
        {
            AccountManager f = new AccountManager();
            f.ShowDialog();
        }

        private DataTable GetBillByTableID(int tableID)
        {
            string connectionString = "server=.; database=RestaurantManagement; Integrated Security=true;";
            DataTable dt = new DataTable();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = @"
            SELECT 
                b.Name AS BillName,          -- Tên hóa đơn
                b.Amount AS NumOfPeople,     -- Số người
                b.Discount,                  -- Giảm giá
                b.Tax,                       -- Thuế
                f.Name AS FoodName,          -- Tên món ăn
                bd.Quantity,                 -- Số lượng
                f.Price AS UnitPrice,        -- Đơn giá
                (bd.Quantity * f.Price) AS TotalPrice  -- Thành tiền
            FROM Bills b
            INNER JOIN BillDetails bd ON b.ID = bd.InvoiceID
            INNER JOIN Food f ON bd.FoodID = f.ID
            WHERE b.TableID = @TableID AND b.Status = 0";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.Add("@TableID", SqlDbType.Int).Value = tableID;

                SqlDataAdapter adapter = new SqlDataAdapter(command);
                adapter.Fill(dt);
            }

            return dt;
        }

        private void DisplayBill(DataTable dt)
        {
            lvFoodBill.Items.Clear();

            if (dt.Rows.Count == 0)
            {
                txtTenHoaDon.Text = "";
                nudSoNguoi.Value = 0;
                txtThanhTien.Text = "0";
                txtGiamGia.Text = "0";
                txtThue.Text = "0";
                return;
            }

            // 🧾 Lấy thông tin hóa đơn
            DataRow first = dt.Rows[0];
            txtTenHoaDon.Text = first["BillName"].ToString();
            nudSoNguoi.Value = Convert.ToDecimal(first["NumOfPeople"]);
            txtGiamGia.Text = first["Discount"].ToString();
            txtThue.Text = first["Tax"].ToString();

            double tongTien = 0;

            // 🍽️ Lấy danh sách món ăn
            foreach (DataRow row in dt.Rows)
            {
                string foodName = row["FoodName"].ToString();
                int quantity = Convert.ToInt32(row["Quantity"]);
                double price = Convert.ToDouble(row["UnitPrice"]);
                double total = Convert.ToDouble(row["TotalPrice"]);

                tongTien += total;

                ListViewItem item = new ListViewItem(foodName);
                item.SubItems.Add(quantity.ToString());
                item.SubItems.Add(price.ToString("N0"));
                item.SubItems.Add(total.ToString("N0"));
                lvFoodBill.Items.Add(item);
            }

            
            txtThanhTien.Text = tongTien.ToString("N0");
        }

    }

}
