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
    public partial class RoleForm : Form
    {
        public RoleForm()
        {
            InitializeComponent();
        }

        public void LoadDanhSachVaiTro(string accountName)
        {
            string connectionString = "server=.; database=RestaurantManagement; Integrated Security=true;";

            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                SqlCommand sqlCommand = sqlConnection.CreateCommand();

                // Dùng câu lệnh SQL trực tiếp thay vì Stored Procedure
                sqlCommand.CommandText = @"
            SELECT 
                R.ID AS RoleID,
                R.RoleName,
                R.Path,
                R.Notes,
                CASE 
                    WHEN RA.AccountName IS NOT NULL THEN 1 
                    ELSE 0 
                END AS Actived
            FROM Role R
            LEFT JOIN RoleAccount RA 
                ON R.ID = RA.RoleID AND RA.AccountName = @AccountName";

                // Gắn tham số
                sqlCommand.Parameters.Add("@AccountName", SqlDbType.NVarChar, 100).Value = accountName;

                sqlConnection.Open();
                SqlDataReader reader = sqlCommand.ExecuteReader();

                DisplayDanhSachVaiTro(reader);
            }
        }

        private void DisplayDanhSachVaiTro(SqlDataReader reader)
        {
            lvRoles.Items.Clear();

            while (reader.Read())
            {
                ListViewItem item = new ListViewItem(reader["RoleID"].ToString());  
                item.SubItems.Add(reader["RoleName"].ToString());                   
                item.SubItems.Add(reader["Path"].ToString());                       
                item.SubItems.Add(reader["Notes"].ToString());                      

                // Check nếu tài khoản có vai trò này
                bool isActived = Convert.ToInt32(reader["Actived"]) == 1;
                item.Checked = isActived;

                lvRoles.Items.Add(item);
            }
        }
    }
}
