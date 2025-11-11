namespace _2312627_PhamTaiHung_UDDesktop_Lab5
{
    partial class NhatKiHoatDongForm
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
            this.lvChiTiet = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lbNgay = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // lvChiTiet
            // 
            this.lvChiTiet.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5,
            this.columnHeader6,
            this.columnHeader7});
            this.lvChiTiet.Dock = System.Windows.Forms.DockStyle.Right;
            this.lvChiTiet.GridLines = true;
            this.lvChiTiet.HideSelection = false;
            this.lvChiTiet.Location = new System.Drawing.Point(247, 0);
            this.lvChiTiet.Name = "lvChiTiet";
            this.lvChiTiet.Size = new System.Drawing.Size(762, 450);
            this.lvChiTiet.TabIndex = 3;
            this.lvChiTiet.UseCompatibleStateImageBehavior = false;
            this.lvChiTiet.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Mã hóa đơn";
            this.columnHeader1.Width = 107;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Tên hóa đơn";
            this.columnHeader2.Width = 111;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Tên bàn";
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Giảm giá";
            this.columnHeader4.Width = 78;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Thuế";
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "Món ăn";
            this.columnHeader6.Width = 100;
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "Số lượng";
            this.columnHeader7.Width = 90;
            // 
            // lbNgay
            // 
            this.lbNgay.Dock = System.Windows.Forms.DockStyle.Left;
            this.lbNgay.FormattingEnabled = true;
            this.lbNgay.ItemHeight = 16;
            this.lbNgay.Location = new System.Drawing.Point(0, 0);
            this.lbNgay.Name = "lbNgay";
            this.lbNgay.Size = new System.Drawing.Size(246, 450);
            this.lbNgay.TabIndex = 2;
            this.lbNgay.SelectedIndexChanged += new System.EventHandler(this.lbNgay_SelectedIndexChanged);
            // 
            // NhatKiHoatDongForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1009, 450);
            this.Controls.Add(this.lvChiTiet);
            this.Controls.Add(this.lbNgay);
            this.Name = "NhatKiHoatDongForm";
            this.Text = "NhatKiHoatDongForm";
            this.Load += new System.EventHandler(this.NhatKiHoatDongForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView lvChiTiet;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.ListBox lbNgay;
    }
}