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
    public partial class BillDetailsForm : Form
    {
        public BillDetailsForm()
        {
            InitializeComponent();
        }

        private void dgvBillDetails_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        public void LoadBillDeTails(int BillID)
        {
           

            // Tiếp tục xử lý như cũ
            string connectionString = "server=.; database=RestaurantManagement; Integrated Security=true;";
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                SqlCommand sqlCommand = sqlConnection.CreateCommand();
                sqlCommand.CommandText = "SELECT Name FROM Bills WHERE ID = " + BillID;
                sqlConnection.Open();

                string catName = sqlCommand.ExecuteScalar()?.ToString() ?? "Không rõ";
                this.Text = "Chi tiết hóa đơn: " + catName;

                sqlCommand.CommandText = "SELECT A.Name,B.Quantity FROM Food A, BillDetails B WHERE A.ID = B.FoodID and B.InvoiceID = " + BillID;
                SqlDataAdapter da = new SqlDataAdapter(sqlCommand);
                DataTable dt = new DataTable("BillDetails");
                da.Fill(dt);

                dgvBillDetails.DataSource = dt;
            }
        }
    }
}
