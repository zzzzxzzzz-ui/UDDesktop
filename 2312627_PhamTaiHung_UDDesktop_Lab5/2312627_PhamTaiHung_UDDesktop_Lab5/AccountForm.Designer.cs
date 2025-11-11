namespace _2312627_PhamTaiHung_UDDesktop_Lab5
{
    partial class AccountForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.lvTaiKhoan = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmiThem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiXoa = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiXemVaiTro = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiNhatKiHoatDong = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lvTaiKhoan
            // 
            this.lvTaiKhoan.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5,
            this.columnHeader6});
            this.lvTaiKhoan.ContextMenuStrip = this.contextMenuStrip1;
            this.lvTaiKhoan.FullRowSelect = true;
            this.lvTaiKhoan.GridLines = true;
            this.lvTaiKhoan.HideSelection = false;
            this.lvTaiKhoan.Location = new System.Drawing.Point(1, 2);
            this.lvTaiKhoan.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.lvTaiKhoan.Name = "lvTaiKhoan";
            this.lvTaiKhoan.Size = new System.Drawing.Size(635, 424);
            this.lvTaiKhoan.TabIndex = 1;
            this.lvTaiKhoan.UseCompatibleStateImageBehavior = false;
            this.lvTaiKhoan.View = System.Windows.Forms.View.Details;
            this.lvTaiKhoan.DoubleClick += new System.EventHandler(this.lvTaiKhoan_DoubleClick);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Tên tài khoản";
            this.columnHeader1.Width = 119;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Mật khẩu";
            this.columnHeader2.Width = 87;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Họ và tên";
            this.columnHeader3.Width = 73;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Email";
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Tell";
            this.columnHeader5.Width = 75;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "Ngày tạo";
            this.columnHeader6.Width = 87;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiThem,
            this.tsmiXoa,
            this.tsmiXemVaiTro,
            this.tsmiNhatKiHoatDong});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(213, 92);
            // 
            // tsmiThem
            // 
            this.tsmiThem.Name = "tsmiThem";
            this.tsmiThem.Size = new System.Drawing.Size(212, 22);
            this.tsmiThem.Text = "Thêm";
            this.tsmiThem.Click += new System.EventHandler(this.tsmiThem_Click);
            // 
            // tsmiXoa
            // 
            this.tsmiXoa.Name = "tsmiXoa";
            this.tsmiXoa.Size = new System.Drawing.Size(212, 22);
            this.tsmiXoa.Text = "Xóa";
            this.tsmiXoa.Click += new System.EventHandler(this.tsmiXoa_Click);
            // 
            // tsmiXemVaiTro
            // 
            this.tsmiXemVaiTro.Name = "tsmiXemVaiTro";
            this.tsmiXemVaiTro.Size = new System.Drawing.Size(212, 22);
            this.tsmiXemVaiTro.Text = "Xem danh sách các vai trò";
            this.tsmiXemVaiTro.Click += new System.EventHandler(this.tsmiXemVaiTro_Click);
            // 
            // tsmiNhatKiHoatDong
            // 
            this.tsmiNhatKiHoatDong.Name = "tsmiNhatKiHoatDong";
            this.tsmiNhatKiHoatDong.Size = new System.Drawing.Size(212, 22);
            this.tsmiNhatKiHoatDong.Text = "Xem nhật ký hoạt động";
            this.tsmiNhatKiHoatDong.Click += new System.EventHandler(this.tsmiNhatKiHoatDong_Click);
            // 
            // AccountForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(634, 424);
            this.Controls.Add(this.lvTaiKhoan);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "AccountForm";
            this.Text = "                         ";
            this.Load += new System.EventHandler(this.AccountForm_Load);
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView lvTaiKhoan;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem tsmiThem;
        private System.Windows.Forms.ToolStripMenuItem tsmiXoa;
        private System.Windows.Forms.ToolStripMenuItem tsmiXemVaiTro;
        private System.Windows.Forms.ToolStripMenuItem tsmiNhatKiHoatDong;
    }
}