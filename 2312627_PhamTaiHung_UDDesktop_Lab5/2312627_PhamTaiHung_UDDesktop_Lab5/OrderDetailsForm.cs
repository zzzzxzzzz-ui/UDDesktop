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
    public partial class OrderDetailsForm : Form
    {
        public OrderDetailsForm()
        {
            InitializeComponent();
        }

        public void LoadOrderDetailForm(int BillID)
        {
            string connectionString = "server=.; database=RestaurantManagement; Integrated Security=true;";

            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            using (SqlCommand sqlCommand = sqlConnection.CreateCommand())
            {
                // Dùng thủ tục thay vì query trực tiếp
                sqlCommand.CommandText = "Bill_GetDetailsByID";
                sqlCommand.CommandType = CommandType.StoredProcedure;

                // Truyền tham số @BillID vào thủ tục
                sqlCommand.Parameters.Add("@BillID", SqlDbType.Int).Value = BillID;

                sqlConnection.Open();

                // Lấy tên hóa đơn để hiển thị tiêu đề
                using (SqlCommand cmdName = new SqlCommand("SELECT Name FROM Bills WHERE ID = @BillID", sqlConnection))
                {
                    cmdName.Parameters.Add("@BillID", SqlDbType.Int).Value = BillID;
                    string catName = cmdName.ExecuteScalar()?.ToString() ?? "Không rõ";
                    this.Text = "Chi tiết hóa đơn: " + catName;
                }

                // Dùng DataAdapter để đổ dữ liệu ra DataGridView
                SqlDataAdapter da = new SqlDataAdapter(sqlCommand);
                DataTable dt = new DataTable("BillDetails");
                da.Fill(dt);

                dgvBillDetails.DataSource = dt;
            }
        }
    }
}
