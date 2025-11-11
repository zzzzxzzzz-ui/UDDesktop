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
    public partial class AccountForm : Form
    {
        public AccountForm()
        {
            InitializeComponent();
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
        private void AccountForm_Load(object sender, EventArgs e)
        {
            LoadForm();
        }

        private void tsmiXoa_Click(object sender, EventArgs e)
        {
            ListViewItem item =lvTaiKhoan.SelectedItems[0];
            if (lvTaiKhoan.SelectedItems.Count > 0)
            {
                // Tạo đối tượng kết nối
                string connectionString = "server=.; database=RestaurantManagement; Integrated Security=true;";
                SqlConnection sqlConnection = new SqlConnection(connectionString);

                // Tạo đối tượng thực thi lệnh
                SqlCommand sqlCommand = sqlConnection.CreateCommand();

                // Thiết lập lệnh truy vấn cho đối tượng Command
                sqlCommand.CommandText = "DELETE FROM Account WHERE AccountName = N'" + item.Text + "'";

                // Mở kết nối tới cơ sở dữ liệu
                sqlConnection.Open();

                // Thực thi lệnh bằng phương thức ExecuteNonQuery
                int numOfRowsEffected = sqlCommand.ExecuteNonQuery();

                // Đóng kết nối
                sqlConnection.Close();

                if (numOfRowsEffected == 1)
                {
                    // Cập nhật lại dữ liệu trên ListView
                   
                    lvTaiKhoan.Items.Remove(item);

                    MessageBox.Show("Xóa tài khoản thành công!");
                }
                else
                {
                    MessageBox.Show("Đã có lỗi xảy ra. Vui lòng thử lại!");
                }
            }    
        }

        private void tsmiThem_Click(object sender, EventArgs e)
        {
            AccountInfoForm f = new AccountInfoForm();
            f.ShowDialog();
            LoadForm();
        }

        private void tsmiXemVaiTro_Click(object sender, EventArgs e)
        {
            ListViewItem item = lvTaiKhoan.SelectedItems[0];
            RoleForm form = new RoleForm(item.Text);
            form.LoadDanhSachVaiTro(item.Text);
            form.ShowDialog();
        }

        private void lvTaiKhoan_DoubleClick(object sender, EventArgs e)
        {
            // Kiểm tra có dòng nào được chọn không
            if (lvTaiKhoan.SelectedItems.Count > 0)
            {
                // Lấy dòng được chọn
                ListViewItem selectedItem = lvTaiKhoan.SelectedItems[0];

                // Tạo form chi tiết tài khoản
                AccountInfoForm accountForm = new AccountInfoForm();
                accountForm.DisplayAccountInfo(selectedItem);
                // Mở form
                accountForm.Show(this);

              
                
                LoadForm();
            }
        }

        private void tsmiNhatKiHoatDong_Click(object sender, EventArgs e)
        {
            if (lvTaiKhoan.SelectedItems.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn một tài khoản để xem nhật ký hoạt động.");
                return;
            }

            // Lấy tài khoản được chọn
            ListViewItem selectedItem = lvTaiKhoan.SelectedItems[0];
            string accountName = selectedItem.Text; // accountName là tên tài khoản

            // Mở form nhật ký hoạt động với account đã chọn
            NhatKiHoatDongForm form = new NhatKiHoatDongForm();
            form.LoadDanhMuc(accountName);  // truyền tên tài khoản
            form.ShowDialog();
        }
    }
}
