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
using System.Xml.Linq;

namespace _2312627_PhamTaiHung_UDDesktop_Lab4
{
    public partial class FoodForm : Form
    {
        public FoodForm()
        {
            InitializeComponent();
        }

        private void ResetText()
        {
            txtTenMon.Text=string.Empty;
            txtDonViTinh.Text = string.Empty;
            txtGhiChu.Text = string.Empty;
            txtDonViTinh.Text =string.Empty;
           
            txtDonGia.Text = string.Empty;
        }

        
        public void LoadFood(int categoryID)
        {
          
            // Tạo đối tượng kết nối
            string connectionString = "server=.; database=RestaurantManagement; Integrated Security = true;";
            SqlConnection sqlConnection = new SqlConnection(connectionString);

            // Tạo đối tượng thực thi lệnh
            SqlCommand sqlCommand = sqlConnection.CreateCommand();

            // Thiết lập lệnh truy vấn cho đối tượng Command
            sqlCommand.CommandText = "SELECT Name FROM Category where ID = " + categoryID;

            // Mở kết nối tới cơ sở dữ liệu
            sqlConnection.Open();

            // Gán tên nhóm sản phẩm cho tiêu đề
            string catName = sqlCommand.ExecuteScalar().ToString();
            this.Text = "Danh sách các món ăn thuộc nhóm: " + catName;

            sqlCommand.CommandText = "SELECT * FROM Food WHERE FoodCategoryID = " + categoryID;

            // Tạo đối tượng DataAdapter
            SqlDataAdapter da = new SqlDataAdapter(sqlCommand);

            // Tạo DataTable để chứa dữ liệu
            DataTable dt = new DataTable("Food");
            da.Fill(dt);

            // Hiển thị danh sách món ăn lên Form
            dgvFood.DataSource = dt;
            txtMaNhom.Text = categoryID.ToString();

            // Đóng kết nối và giải phóng bộ nhớ
            sqlConnection.Close();
            sqlConnection.Dispose();
            da.Dispose();
        }

        


        private void dgvFood_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            // Tạo đối tượng kết nối
            string connectionString = "server=.; database=RestaurantManagement; Integrated Security=true;";
            SqlConnection sqlConnection = new SqlConnection(connectionString);

            // Tạo đối tượng thực thi lệnh
            SqlCommand sqlCommand = sqlConnection.CreateCommand();

            // Thiết lập lệnh truy vấn cho đối tượng Command
            sqlCommand.CommandText = "DELETE FROM Food WHERE ID = " + txtMaMon.Text;

            // Mở kết nối tới cơ sở dữ liệu
            sqlConnection.Open();

            // Thực thi lệnh bằng phương thức ExecuteNonQuery
            int numOfRowsEffected = sqlCommand.ExecuteNonQuery();

            // Đóng kết nối
            sqlConnection.Close();

            if (numOfRowsEffected == 1)
            {
                // Cập nhật lại dữ liệu trên ListView
                DataGridViewRow row = dgvFood.SelectedRows[0];
                dgvFood.Rows.Remove(row);

                // Xóa các ô nhập
                ResetText();

                // Disable các nút xóa và cập nhật
                btnUpdate.Enabled = false;
                btnDelete.Enabled = false;

                MessageBox.Show("Xóa nhóm món ăn thành công");
            }
            else
            {
                MessageBox.Show("Đã có lỗi xảy ra. Vui lòng thử lại");
            }
            
        }

       
        private void dgvFood_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvFood.CurrentRow != null)
            {
                DataGridViewRow row = dgvFood.CurrentRow;

                txtMaMon.Text = row.Cells[0].Value?.ToString();
                txtTenMon.Text = row.Cells[1].Value?.ToString();
                txtDonViTinh.Text = row.Cells[2].Value?.ToString();
                txtMaNhom.Text = row.Cells[3].Value?.ToString();
                txtDonGia.Text = row.Cells[4].Value?.ToString();
                txtGhiChu.Text = row.Cells[5].Value?.ToString();

                btnUpdate.Enabled = true;
                btnDelete.Enabled = true;
            }
        }

        

        private void txtDonGia_TextChanged(object sender, EventArgs e)
        {

        }

        private void tsmiXoa_Click(object sender, EventArgs e)
        {
            if (dgvFood.SelectedRows.Count > 0)
                btnDelete.PerformClick();
        }

       
        private void btnAdd_Click(object sender, EventArgs e)
        {
            string connectionString = "server=.; database=RestaurantManagement; Integrated Security=true;";
            SqlConnection sqlConnection = new SqlConnection(connectionString);

            // Tạo đối tượng thực thi lệnh
            SqlCommand sqlCommand = sqlConnection.CreateCommand();

            // Thiết lập lệnh truy vấn cho đối tượng Command
            sqlCommand.CommandText = "INSERT INTO Food(Name, Unit, FoodCategoryID, Price, Notes)" +
                                     " VALUES (N'" + txtTenMon.Text + "', N'" + txtDonViTinh.Text + "', " +
                                     txtMaNhom.Text + ", " + txtDonGia.Text + ", N'" + txtGhiChu.Text + "')";

            // Mở kết nối tới cơ sở dữ liệu
            sqlConnection.Open();

            // Thực thi lệnh bằng phương thức ExecuteNonQuery
            int numOfRowsEffected = sqlCommand.ExecuteNonQuery();

            // Đóng kết nối
            sqlConnection.Close();

            if (numOfRowsEffected == 1)
            {

                ResetText();
                btnUpdate.Enabled = false;
                btnDelete.Enabled = false;
                MessageBox.Show("Thêm món ăn thành công");
                LoadFood(int.Parse(txtMaNhom.Text));

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
            sqlCommand.CommandText = "UPDATE Food SET Name = N'" + txtTenMon.Text +
                                     "', Unit = N'" + txtDonViTinh.Text +
                                     "', FoodCategoryID = " + txtMaNhom.Text +
                                     ", Price = " + txtDonGia.Text +
                                     ", Notes = N'" + txtGhiChu.Text +
                                     "' WHERE ID = " + txtMaMon.Text;

            // Mở kết nối tới cơ sở dữ liệu
            sqlConnection.Open();

            // Thực thi lệnh bằng phương thức ExecuteNonQuery
            int numOfRowsEffected = sqlCommand.ExecuteNonQuery();

            // Đóng kết nối
            sqlConnection.Close();

            if (numOfRowsEffected == 1)
            {
                // Cập nhật lại dữ liệu trên ListView hoặc DataGridView nếu có
                MessageBox.Show("Cập nhật món ăn thành công");

                // Tải lại dữ liệu
                

                // Xóa các ô nhập
                ResetText() ;

                // Disable các nút xóa và cập nhật
                btnUpdate.Enabled = false;
                btnDelete.Enabled = false;
                int MaNhom = int.Parse(txtMaNhom.Text);

                LoadFood(MaNhom);
            }
            else
            {
                MessageBox.Show("Đã có lỗi xảy ra. Vui lòng thử lại");
            }
        }
    }
}
