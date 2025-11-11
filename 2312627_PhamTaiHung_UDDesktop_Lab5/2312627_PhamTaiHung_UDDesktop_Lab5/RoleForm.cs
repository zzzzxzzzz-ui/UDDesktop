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
    public partial class RoleForm : Form
    {
        private string currentAccount;
        public RoleForm(string accountName)
        {
            InitializeComponent();
            currentAccount = accountName;
        }

        /*
         CREATE PROCEDURE GetRolesByAccount
              @AccountName NVARCHAR(100)
          AS
          BEGIN
              SELECT 
                  R.ID AS RoleID,
                  R.RoleName,
                  R.Path,
                  R.Notes,
                  ISNULL(RA.Actived, 0) AS Actived
              FROM Role R
              LEFT JOIN RoleAccount RA 
                  ON R.ID = RA.RoleID AND RA.AccountName = @AccountName
          END;
          GO
         */
        public void LoadDanhSachVaiTro(string accountName)
        {
            string connectionString = "server=.; database=RestaurantManagement; Integrated Security=true;";

            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                SqlCommand sqlCommand = sqlConnection.CreateCommand();

                // Dùng Stored Procedure vừa tạo
                sqlCommand.CommandText = "EXECUTE GetRolesByAccount @AccountName";
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

                // Nếu tài khoản đã được gán vai trò => check vào ô đầu tiên
                bool isActived = Convert.ToBoolean(reader["Actived"]);
                item.Checked = isActived;

                lvRoles.Items.Add(item);
            }
        }

        /*CREATE PROCEDURE InsertRole
              @ID INT OUTPUT,
              @RoleName NVARCHAR(1000),
              @Path NVARCHAR(3000) = NULL,
              @Notes NVARCHAR(3000) = NULL
          AS
          BEGIN
              INSERT INTO Role (RoleName, Path, Notes)
              VALUES (@RoleName, @Path, @Notes);

              SELECT @ID = SCOPE_IDENTITY();
          END;
          GO
        */
        private void btnAddNew_Click(object sender, EventArgs e)
        {
            try
            {
                string connectionString = "server=.; database=RestaurantManagement; Integrated Security=true;";
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = conn.CreateCommand();
                    cmd.CommandText = "EXECUTE InsertRole @ID OUTPUT, @RoleName, @Path, @Notes";

                    // Thêm tham số cho thủ tục
                    cmd.Parameters.Add("@ID", SqlDbType.Int).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("@RoleName", SqlDbType.NVarChar, 1000).Value = txtRoleName.Text.Trim();
                    cmd.Parameters.Add("@Path", SqlDbType.NVarChar, 3000).Value =
                        string.IsNullOrWhiteSpace(txtPath.Text) ? DBNull.Value : (object)txtPath.Text.Trim();
                    cmd.Parameters.Add("@Notes", SqlDbType.NVarChar, 3000).Value =
                        string.IsNullOrWhiteSpace(txtNotes.Text) ? DBNull.Value : (object)txtNotes.Text.Trim();

                    conn.Open();
                    int numRows = cmd.ExecuteNonQuery();

                    if (numRows > 0)
                    {
                        int newID = Convert.ToInt32(cmd.Parameters["@ID"].Value);
                        MessageBox.Show("Thêm vai trò thành công! Mã vai trò = " + newID, "Thông báo");

                        // Làm mới danh sách vai trò
                        LoadDanhSachVaiTro(currentAccount);

                        // Xóa text box sau khi thêm
                        txtRoleName.Clear();
                        txtPath.Clear();
                        txtNotes.Clear();
                    }
                    else
                    {
                        MessageBox.Show("Thêm vai trò thất bại!", "Lỗi");
                    }
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message, "SQL Error");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            string connectionString = "server=.; database=RestaurantManagement; Integrated Security=true;";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                SqlCommand deleteCmd = new SqlCommand("DELETE FROM RoleAccount WHERE AccountName = @AccountName", conn);
                deleteCmd.Parameters.Add("@AccountName", SqlDbType.NVarChar, 100).Value = currentAccount;
                deleteCmd.ExecuteNonQuery();

                foreach (ListViewItem item in lvRoles.Items)
                {
                    if (item.Checked)
                    {
                        SqlCommand insertCmd = new SqlCommand(
                            "INSERT INTO RoleAccount (RoleID, AccountName, Actived) VALUES (@RoleID, @AccountName, 1)", conn);
                        insertCmd.Parameters.Add("@RoleID", SqlDbType.Int).Value = int.Parse(item.Text);
                        insertCmd.Parameters.Add("@AccountName", SqlDbType.NVarChar, 100).Value = currentAccount;
                        insertCmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Cập nhật vai trò cho tài khoản thành công!");
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void lvRoles_Click(object sender, EventArgs e)
        {
            if (lvRoles.SelectedItems.Count > 0)
            {
                ListViewItem item = lvRoles.SelectedItems[0];

                // Lấy dữ liệu từ ListView và hiển thị lên TextBox
                txtRoleID.Text = item.SubItems[0].Text;    
                txtRoleName.Text = item.SubItems[1].Text;  
                txtPath.Text = item.SubItems[2].Text;      
                txtNotes.Text = item.SubItems[3].Text;     
            }
        }
    }
}
