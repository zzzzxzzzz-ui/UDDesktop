using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Collections.Generic;

namespace _2312627_PhamTaiHung_UDDesktop_Lab5
{
    public partial class CategoryInfoForm : Form
    {
        public CategoryInfoForm()
        {
            InitializeComponent();
        }
                 /*CREATE PROCEDURE [InsertCategory]
                        @ID int output,
                        @Name nvarchar(1000),
                        @Type nvarchar(100)
                        
                    AS
                    INSERT INTO [Category]
                        ([Name], [Type])
                    VALUES
                        (@Name, @Type)
                    
                    SELECT @ID = SCOPE_IDENTITY();
                    GO
                  */
        private void btnAddNew_Click(object sender, EventArgs e)
        {
            try
            {
                string connectionString = "server=.; database=RestaurantManagement; Integrated Security=true;";
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = conn.CreateCommand())
                    {
                        // Gọi thủ tục có tham số OUTPUT
                        cmd.CommandText = "EXECUTE InsertCategory @id OUTPUT, @name, @type";

                        // Khai báo tham số
                        cmd.Parameters.Add("@id", SqlDbType.Int).Direction = ParameterDirection.Output;
                        cmd.Parameters.Add("@name", SqlDbType.NVarChar, 100).Value = txtName.Text;
                        cmd.Parameters.Add("@type", SqlDbType.NVarChar, 100).Value = txtType.Text;

                        conn.Open();
                        int numRowAffected = cmd.ExecuteNonQuery();

                        if (numRowAffected > 0)
                        {
                            string categoryID = cmd.Parameters["@id"].Value.ToString();
                            MessageBox.Show("Thêm loại món thành công! Mã loại = " + categoryID, "Thông báo");
                            this.ResetText();
                        }
                        else
                        {
                            MessageBox.Show("Thêm loại món thất bại.", "Thông báo");
                        }
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
            this.Close();
        }
    }
}
