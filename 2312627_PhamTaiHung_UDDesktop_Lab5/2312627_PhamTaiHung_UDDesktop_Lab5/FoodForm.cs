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
    public partial class FoodForm : Form
    {
        private DataTable foodTable;
        public FoodForm()
        {
            InitializeComponent();
        }

        private void LoadCategory()
        {
            string connectionString = "server=.; database = RestaurantManagement; Integrated Security = true;";
            SqlConnection conn = new SqlConnection(connectionString);

            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT ID, Name FROM Category";

            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            // Mở kết nối
            conn.Open();

            // Lấy dữ liệu từ csdl đưa vào DataTable
            adapter.Fill(dt);

            // Đóng kết nối và giải phóng bộ nhớ
            conn.Close();
            conn.Dispose();

            // Đưa dữ liệu vào ComboBox
            cbbCategory.DataSource = dt;

            // Hiển thị tên nhóm sản phẩm
            cbbCategory.DisplayMember = "Name";

            // Nhưng khi lấy giá trị thì lấy ID của nhóm
            cbbCategory.ValueMember = "ID";
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadCategory();
        }

        private void cbbCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbbCategory.SelectedIndex == -1) return;

            string connectionString = "server=.; database = RestaurantManagement; Integrated Security = true; ";
            SqlConnection conn = new SqlConnection(connectionString);

            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT * FROM FOOD WHERE FoodCategoryID = @categoryId";

            // Truyền tham số
            cmd.Parameters.Add("@categoryId", SqlDbType.Int);

            if (cbbCategory.SelectedValue is DataRowView)
            {
                DataRowView rowView = cbbCategory.SelectedValue as DataRowView;
                cmd.Parameters["@categoryId"].Value = rowView["Id"];
            }
            else
            {
                cmd.Parameters["@categoryId"].Value = cbbCategory.SelectedValue;
            }

            // Tạo bộ điều phịu dữ liệu
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable foodTable = new DataTable();

            // Mở kết nối
            conn.Open();

            // Lấy dữ liệu từ csdl đưa vào DataTable
            adapter.Fill(foodTable);

            // Đóng kết nối và giải phóng bộ nhớ
            conn.Close();

            // Đưa dữ liệu vào data gridview
            dgvFoodList.DataSource = foodTable;

            // Hiển thị tổng số món ăn
            lblQuantity.Text = foodTable.Rows.Count.ToString();
            lblCatName.Text = cbbCategory.Text;
        }

        private void tsmCalculateQuantity_Click(object sender, EventArgs e)
        {
            string connectionString = "server=.; database = RestaurantManagement; Integrated Security = true; ";
            SqlConnection conn = new SqlConnection(connectionString);

            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT @numSaleFood = sum(Quantity) FROM BillDetails WHERE FoodID = @foodId";

            // Lấy thông tin sản phẩm được chọn
            if (dgvFoodList.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dgvFoodList.SelectedRows[0];

                DataRowView rowView = selectedRow.DataBoundItem as DataRowView;

                // Truyền tham số
                cmd.Parameters.Add("@foodId", SqlDbType.Int);
                cmd.Parameters["@foodId"].Value = rowView["Id"];

                cmd.Parameters.Add("@numSaleFood", SqlDbType.Int);
                cmd.Parameters["@numSaleFood"].Direction = ParameterDirection.Output;

                // Mở kết nối csdl
                conn.Open();

                // Thực thi truy vấn và lấy dữ liệu từ tham số
                cmd.ExecuteNonQuery();

                string result = cmd.Parameters["@numSaleFood"].Value.ToString();
                MessageBox.Show("Tổng số lượng món " + rowView["Name"] + " đã bán là: " + result + " " + rowView["Unit"]);

                // Đóng kết nối csdl
                conn.Close();
            }
            cmd.Dispose();
            conn.Dispose();
        }

        private void tsmAddFood_Click(object sender, EventArgs e)
        {
            FoodInfoForm foodForm = new FoodInfoForm();
            foodForm.FormClosed += new FormClosedEventHandler(foodForm_FormClosed);

            foodForm.Show(this);
            LoadCategory();
        }

        void foodForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            int index = cbbCategory.SelectedIndex;
            cbbCategory.SelectedIndex = -1;
            cbbCategory.SelectedIndex = index;
        }

        private void tsmUpdateFood_Click(object sender, EventArgs e)
        {
            // Lấy thông tin sản phẩm được chọn
            if (dgvFoodList.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dgvFoodList.SelectedRows[0];
                DataRowView rowView = selectedRow.DataBoundItem as DataRowView;

                FoodInfoForm foodForm = new FoodInfoForm();
                foodForm.FormClosed += new FormClosedEventHandler(foodForm_FormClosed);
                foodForm.Show(this);
                foodForm.DisplayFoodInfo(rowView);
            }
        }

        private void txtSearchByName_TextChanged(object sender, EventArgs e)
        {
            if (foodTable == null) return;

            // create filter and sort expression
            string filterExpression = "Name like '%" + txtSearchByName.Text + "%'";
            string sortExpression = "Price DESC";
            DataViewRowState rowStateFilter = DataViewRowState.OriginalRows;

            // Create a data view object to view the data in foodTable data table
            // filter by Name (contain 'ng') and sort descending by Price
            DataView foodView = new DataView(foodTable,
                filterExpression, sortExpression, rowStateFilter);

            // Assign foodTable as Data Source of data grid view
            dgvFoodList.DataSource = foodView;
        }

        private void tsmiHoaDon_Click(object sender, EventArgs e)
        {
            OrdersForm f = new OrdersForm();
            f.Show(this);
        }

        private void tsmiTaiKhoan_Click(object sender, EventArgs e)
        {
            AccountForm form = new AccountForm();
            form.Show(this);
        }
    }
}
