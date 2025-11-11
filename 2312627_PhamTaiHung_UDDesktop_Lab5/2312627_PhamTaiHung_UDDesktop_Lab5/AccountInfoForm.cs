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
    public partial class AccountInfoForm : Form
    {
        public AccountInfoForm()
        {
            InitializeComponent();
        }

        void ResetText()
        {
            txtAccountName.Text = string.Empty;
            txtPassword.Text = string.Empty;
            txtFullName.Text = string.Empty;
            txtEmail.Text = string.Empty;
            dtpDateCreated.Text = string.Empty;
            txtTell.Text = string.Empty;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                string connectionString = "server=.; database=RestaurantManagement; Integrated Security=true;";
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("InsertAccount", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    // Thêm tham số
                    cmd.Parameters.Add("@AccountName", SqlDbType.NVarChar, 100).Value = txtAccountName.Text.Trim();
                    cmd.Parameters.Add("@Password", SqlDbType.NVarChar, 200).Value = txtPassword.Text.Trim();
                    cmd.Parameters.Add("@FullName", SqlDbType.NVarChar, 1000).Value = txtFullName.Text.Trim();
                    cmd.Parameters.Add("@Email", SqlDbType.NVarChar, 1000).Value = txtEmail.Text.Trim();
                    cmd.Parameters.Add("@Tell", SqlDbType.NVarChar, 200).Value = txtTell.Text.Trim();

                    conn.Open();
                    int rows = cmd.ExecuteNonQuery();

                    if (rows > 0)
                    {
                        MessageBox.Show("Thêm tài khoản thành công!", "Thông báo");
                        this.ResetText();
                    }
                    else
                    {
                        MessageBox.Show("Thêm tài khoản thất bại!", "Lỗi");
                    }
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Lỗi SQL: " + ex.Message, "SQL Error");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Error");
            }
        }

        public void DisplayAccountInfo(ListViewItem item)
        {
            try
            {
                // Cột đầu tiên (Text)
                txtAccountName.Text = item.SubItems[0].Text;
                // Các cột tiếp theo
                txtPassword.Text = item.SubItems[1].Text;
                txtFullName.Text = item.SubItems[2].Text;
                txtEmail.Text = item.SubItems[3].Text;
                txtTell.Text = item.SubItems[4].Text;
                dtpDateCreated.Text = item.SubItems[5].Text;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
                this.Close();
            }
            btnUpdate.Enabled = true;
            btnAdd.Enabled = false;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                string connectionString = "server=.; database=RestaurantManagement; Integrated Security=true;";
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = conn.CreateCommand();
                    cmd.CommandText = "EXECUTE UpdateAccount @accountName, @password, @fullName, @email, @tell";

                    // Thêm tham số đầu vào cho thủ tục
                    cmd.Parameters.Add("@accountName", SqlDbType.NVarChar, 100);
                    cmd.Parameters.Add("@password", SqlDbType.NVarChar, 100);
                    cmd.Parameters.Add("@fullName", SqlDbType.NVarChar, 100);
                    cmd.Parameters.Add("@email", SqlDbType.NVarChar, 100);
                    cmd.Parameters.Add("@tell", SqlDbType.NVarChar, 20);

                    // Gán giá trị từ các textbox
                    cmd.Parameters["@accountName"].Value = txtAccountName.Text;
                    cmd.Parameters["@password"].Value = txtPassword.Text;
                    cmd.Parameters["@fullName"].Value = txtFullName.Text;
                    cmd.Parameters["@email"].Value = txtEmail.Text;
                    cmd.Parameters["@tell"].Value = txtTell.Text;

                    conn.Open();

                    int numRowsAffected = cmd.ExecuteNonQuery();

                    if (numRowsAffected > 0)
                    {
                        MessageBox.Show("Cập nhật tài khoản thành công!", "Thông báo");
                        this.ResetText();
                    }
                    else
                    {
                        MessageBox.Show("Cập nhật thất bại. Vui lòng kiểm tra lại!", "Lỗi");
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

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
