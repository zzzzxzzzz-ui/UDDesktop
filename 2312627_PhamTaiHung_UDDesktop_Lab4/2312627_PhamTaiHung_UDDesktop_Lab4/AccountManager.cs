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

namespace _2312627_PhamTaiHung_UDDesktop_Lab4
{
    public partial class AccountManager : Form
    {
        public AccountManager()
        {
            InitializeComponent();
        }

        private void AccountManager_Load(object sender, EventArgs e)
        {
            LoadForm();
        }
        private void LoadForm()
        {
            string connectionString = "server=.; database=RestaurantManagement; Integrated Security=true;";

            // Tạo đối tượng kết nối
            SqlConnection sqlConnection = new SqlConnection(connectionString);

            // Tạo đối tượng thực thi lệnh
            SqlCommand sqlCommand = sqlConnection.CreateCommand();

            // Thiết lập lệnh truy vấn cho đối tượng Command
            string query = "SELECT * FROM Account";
            sqlCommand.CommandText = query;

            // Mở kết nối tới cơ sở dữ liệu
            sqlConnection.Open();

            // Thực thi lệnh bằng phương thức ExecuteReader
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

            // Gọi hàm hiển thị dữ liệu lên màn hình
            this.DisplayAccount(sqlDataReader);

            // Đóng kết nối
            sqlConnection.Close();
        }

        private void DisplayAccount(SqlDataReader reader)
        {
            // Xóa tất cả các dòng hiện tại
            lvTaiKhoan.Items.Clear();

            // Đọc một dòng dữ liệu
            while (reader.Read())
            {
                // Tạo một dòng mới trong ListView
                ListViewItem item = new ListViewItem(reader["AccountName"].ToString());

                // Thêm dòng mới vào ListView
                lvTaiKhoan.Items.Add(item);

                // Bổ sung các thông tin khác cho ListViewItem
                
                item.SubItems.Add(reader["Password"].ToString());
                item.SubItems.Add(reader["FullName"].ToString());
                item.SubItems.Add(reader["Email"].ToString());
                item.SubItems.Add(reader["Tell"].ToString());
                item.SubItems.Add(reader["DateCreated"].ToString());
            }
        }

        void ResetText()
        {
            txtTenTK.Text= string.Empty;
            txtMK.Text= string.Empty;
            txtHoVaTen.Text= string.Empty;
            txtEmail.Text= string.Empty;
            txtNgayTao.Text= string.Empty;
            txtTell.Text= string.Empty;
        }
        private void lvTaiKhoan_Click(object sender, EventArgs e)
        {
            ListViewItem item = lvTaiKhoan.SelectedItems[0];

            // Hiển thị dữ liệu lên TextBox
           

            txtTenTK.Text = item.Text;
            txtMK.Text = item.SubItems[1].Text;
            txtHoVaTen.Text = item.SubItems[2].Text;
            txtEmail.Text = item.SubItems[3].Text;
           
            txtTell.Text = item.SubItems[4].Text;
            txtNgayTao.Text = item.SubItems[5].Text;

            // Hiển thị nút cập nhật và xóa
            btnUpdate.Enabled = true;
            btnDelete.Enabled = true;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            // Tạo đối tượng kết nối
            string connectionString = "server=.; database=RestaurantManagement; Integrated Security=true;";
            SqlConnection sqlConnection = new SqlConnection(connectionString);

            // Tạo đối tượng thực thi lệnh
            SqlCommand sqlCommand = sqlConnection.CreateCommand();

            // Thiết lập lệnh truy vấn cho đối tượng Command
            sqlCommand.CommandText = "INSERT INTO Account(AccountName, Password, FullName, Email, Tell, DateCreated) " +
                                     "VALUES (N'" + txtTenTK.Text + "', " +
                                             "N'" + txtMK.Text + "', " +
                                             "N'" + txtHoVaTen.Text + "', " +
                                             (string.IsNullOrEmpty(txtEmail.Text) ? "NULL" : "N'" + txtEmail.Text + "'") + ", " +
                                             (string.IsNullOrEmpty(txtTell.Text) ? "NULL" : "N'" + txtTell.Text + "'") + ", " +
                                             "GETDATE())";  // Tự động lấy ngày hiện tại

            // Mở kết nối tới cơ sở dữ liệu
            sqlConnection.Open();

            // Thực thi lệnh bằng phương thức ExecuteNonQuery
            int numOfRowsEffected = sqlCommand.ExecuteNonQuery();

            // Đóng kết nối
            sqlConnection.Close();

            // Kiểm tra kết quả
            if (numOfRowsEffected == 1)
            {
                MessageBox.Show("Thêm tài khoản thành công!");

                // Gọi hàm load lại dữ liệu (nếu có)
                LoadForm();

                // Xóa các ô nhập
                ResetText();
            }
            else
            {
                MessageBox.Show("Đã có lỗi xảy ra. Vui lòng thử lại!");
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            // Tạo đối tượng kết nối
            string connectionString = "server=.; database=RestaurantManagement; Integrated Security=true;";
            SqlConnection sqlConnection = new SqlConnection(connectionString);

            // Tạo đối tượng thực thi lệnh
            SqlCommand sqlCommand = sqlConnection.CreateCommand();

            // Thiết lập lệnh truy vấn cho đối tượng Command
            sqlCommand.CommandText = "UPDATE Account SET " +
                                     "Password = N'" + txtMK.Text + "', " +
                                     "FullName = N'" + txtHoVaTen.Text + "', " +
                                     "Email = " + (string.IsNullOrEmpty(txtEmail.Text) ? "NULL" : "N'" + txtEmail.Text + "'") + ", " +
                                     "Tell = " + (string.IsNullOrEmpty(txtTell.Text) ? "NULL" : "N'" + txtTell.Text + "'") + ", " +
                                     "DateCreated = " + (string.IsNullOrEmpty(txtNgayTao.Text) ? "NULL" : "N'" + txtNgayTao.Text + "'") +
                                     " WHERE AccountName = N'" + txtTenTK.Text + "'";

            // Mở kết nối tới cơ sở dữ liệu
            sqlConnection.Open();

            // Thực thi lệnh bằng phương thức ExecuteNonQuery
            int numOfRowsEffected = sqlCommand.ExecuteNonQuery();

            // Đóng kết nối
            sqlConnection.Close();

            if (numOfRowsEffected == 1)
            {
                MessageBox.Show("Cập nhật tài khoản thành công!");

                // Load lại dữ liệu (nếu có)
                LoadForm();

                // Xóa các ô nhập
                ResetText();

                // Disable các nút
                btnUpdate.Enabled = false;
                btnDelete.Enabled = false;
            }
            else
            {
                MessageBox.Show("Đã có lỗi xảy ra. Vui lòng thử lại!");
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            // Tạo đối tượng kết nối
            string connectionString = "server=.; database=RestaurantManagement; Integrated Security=true;";
            SqlConnection sqlConnection = new SqlConnection(connectionString);

            // Tạo đối tượng thực thi lệnh
            SqlCommand sqlCommand = sqlConnection.CreateCommand();

            // Thiết lập lệnh truy vấn cho đối tượng Command
            sqlCommand.CommandText = "DELETE FROM Account WHERE AccountName = N'" + txtTenTK.Text + "'";

            // Mở kết nối tới cơ sở dữ liệu
            sqlConnection.Open();

            // Thực thi lệnh bằng phương thức ExecuteNonQuery
            int numOfRowsEffected = sqlCommand.ExecuteNonQuery();

            // Đóng kết nối
            sqlConnection.Close();

            if (numOfRowsEffected == 1)
            {
                // Cập nhật lại dữ liệu trên ListView
                ListViewItem item = lvTaiKhoan.SelectedItems[0];
                lvTaiKhoan.Items.Remove(item);

                // Xóa các ô nhập
                ResetText();
                // Disable các nút xóa và cập nhật
                btnUpdate.Enabled = false;
                btnDelete.Enabled = false;

                MessageBox.Show("Xóa tài khoản thành công!");
            }
            else
            {
                MessageBox.Show("Đã có lỗi xảy ra. Vui lòng thử lại!");
            }
        }

        private void tsmiXoa_Click(object sender, EventArgs e)
        {
            if (lvTaiKhoan.SelectedItems.Count > 0)
                btnDelete.PerformClick();
        }

        private void tsmiXemVaiTro_Click(object sender, EventArgs e)
        {
            RoleForm rolef=new RoleForm();
            rolef.LoadDanhSachVaiTro(txtTenTK.Text);
            rolef.ShowDialog();
        }
    }
}
