namespace doanmonhocqlbh
{
    partial class DonHang
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
            this.ds_donhang = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.btnxoa = new System.Windows.Forms.Button();
            this.btnsua = new System.Windows.Forms.Button();
            this.btnthoat = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.cbtrangthai = new System.Windows.Forms.ComboBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.sảnPhẩmToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.đơnHàngToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.kháchHàngToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.vậnChuyểnToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.doanhThuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnTim = new System.Windows.Forms.Button();
            this.txtMaKhachHang = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnlammoi = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnvanchuyen = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.ds_donhang)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // ds_donhang
            // 
            this.ds_donhang.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ds_donhang.Location = new System.Drawing.Point(12, 191);
            this.ds_donhang.Name = "ds_donhang";
            this.ds_donhang.RowHeadersWidth = 51;
            this.ds_donhang.RowTemplate.Height = 24;
            this.ds_donhang.Size = new System.Drawing.Size(1267, 314);
            this.ds_donhang.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("UVN Bai Sau Nang", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(507, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(178, 39);
            this.label1.TabIndex = 1;
            this.label1.Text = "ĐƠN HÀNG ";
            // 
            // btnxoa
            // 
            this.btnxoa.Location = new System.Drawing.Point(17, 10);
            this.btnxoa.Name = "btnxoa";
            this.btnxoa.Size = new System.Drawing.Size(102, 41);
            this.btnxoa.TabIndex = 2;
            this.btnxoa.Text = "Xóa ";
            this.btnxoa.UseVisualStyleBackColor = true;
            this.btnxoa.Click += new System.EventHandler(this.btnxoa_Click);
            // 
            // btnsua
            // 
            this.btnsua.Location = new System.Drawing.Point(41, 129);
            this.btnsua.Name = "btnsua";
            this.btnsua.Size = new System.Drawing.Size(101, 40);
            this.btnsua.TabIndex = 3;
            this.btnsua.Text = "Cập nhật ";
            this.btnsua.UseVisualStyleBackColor = true;
            this.btnsua.Click += new System.EventHandler(this.btnsua_Click);
            // 
            // btnthoat
            // 
            this.btnthoat.Location = new System.Drawing.Point(246, 8);
            this.btnthoat.Name = "btnthoat";
            this.btnthoat.Size = new System.Drawing.Size(98, 41);
            this.btnthoat.TabIndex = 4;
            this.btnthoat.Text = "Thoát";
            this.btnthoat.UseVisualStyleBackColor = true;
            this.btnthoat.Click += new System.EventHandler(this.btnthoat_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(76, 110);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(176, 16);
            this.label2.TabIndex = 5;
            this.label2.Text = "Cập nhật trạng thái đơn hàng";
            // 
            // cbtrangthai
            // 
            this.cbtrangthai.FormattingEnabled = true;
            this.cbtrangthai.Items.AddRange(new object[] {
            "Đã Giao Hàng",
            "Đang Xử Lý",
            "Chưa Giao Hàng",
            "Chưa thanh toán",
            "Đã thanh toán"});
            this.cbtrangthai.Location = new System.Drawing.Point(169, 145);
            this.cbtrangthai.Name = "cbtrangthai";
            this.cbtrangthai.Size = new System.Drawing.Size(121, 24);
            this.cbtrangthai.TabIndex = 6;
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sảnPhẩmToolStripMenuItem,
            this.đơnHàngToolStripMenuItem,
            this.kháchHàngToolStripMenuItem,
            this.vậnChuyểnToolStripMenuItem,
            this.doanhThuToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1291, 28);
            this.menuStrip1.TabIndex = 7;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // sảnPhẩmToolStripMenuItem
            // 
            this.sảnPhẩmToolStripMenuItem.Name = "sảnPhẩmToolStripMenuItem";
            this.sảnPhẩmToolStripMenuItem.Size = new System.Drawing.Size(88, 24);
            this.sảnPhẩmToolStripMenuItem.Text = "Sản Phẩm";
            // 
            // đơnHàngToolStripMenuItem
            // 
            this.đơnHàngToolStripMenuItem.Name = "đơnHàngToolStripMenuItem";
            this.đơnHàngToolStripMenuItem.Size = new System.Drawing.Size(91, 24);
            this.đơnHàngToolStripMenuItem.Text = "Đơn Hàng";
            // 
            // kháchHàngToolStripMenuItem
            // 
            this.kháchHàngToolStripMenuItem.Name = "kháchHàngToolStripMenuItem";
            this.kháchHàngToolStripMenuItem.Size = new System.Drawing.Size(103, 24);
            this.kháchHàngToolStripMenuItem.Text = "Khách Hàng";
            this.kháchHàngToolStripMenuItem.Click += new System.EventHandler(this.kháchHàngToolStripMenuItem_Click);
            // 
            // vậnChuyểnToolStripMenuItem
            // 
            this.vậnChuyểnToolStripMenuItem.Name = "vậnChuyểnToolStripMenuItem";
            this.vậnChuyểnToolStripMenuItem.Size = new System.Drawing.Size(100, 24);
            this.vậnChuyểnToolStripMenuItem.Text = "Vận Chuyển";
            // 
            // doanhThuToolStripMenuItem
            // 
            this.doanhThuToolStripMenuItem.Name = "doanhThuToolStripMenuItem";
            this.doanhThuToolStripMenuItem.Size = new System.Drawing.Size(95, 24);
            this.doanhThuToolStripMenuItem.Text = "Doanh Thu";
            // 
            // btnTim
            // 
            this.btnTim.Location = new System.Drawing.Point(313, 136);
            this.btnTim.Name = "btnTim";
            this.btnTim.Size = new System.Drawing.Size(88, 41);
            this.btnTim.TabIndex = 8;
            this.btnTim.Text = "Tìm kiếm";
            this.btnTim.UseVisualStyleBackColor = true;
            this.btnTim.Click += new System.EventHandler(this.btnTim_Click);
            // 
            // txtMaKhachHang
            // 
            this.txtMaKhachHang.Location = new System.Drawing.Point(424, 136);
            this.txtMaKhachHang.Multiline = true;
            this.txtMaKhachHang.Name = "txtMaKhachHang";
            this.txtMaKhachHang.Size = new System.Drawing.Size(289, 43);
            this.txtMaKhachHang.TabIndex = 9;
            this.txtMaKhachHang.TextChanged += new System.EventHandler(this.txtMaKhachHang_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 172);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(130, 16);
            this.label3.TabIndex = 10;
            this.label3.Text = "Danh sách đơn hàng";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // btnlammoi
            // 
            this.btnlammoi.Location = new System.Drawing.Point(125, 10);
            this.btnlammoi.Name = "btnlammoi";
            this.btnlammoi.Size = new System.Drawing.Size(112, 41);
            this.btnlammoi.TabIndex = 11;
            this.btnlammoi.Text = "Làm mới";
            this.btnlammoi.UseVisualStyleBackColor = true;
            this.btnlammoi.Click += new System.EventHandler(this.btnlammoi_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnxoa);
            this.panel2.Controls.Add(this.btnlammoi);
            this.panel2.Controls.Add(this.btnthoat);
            this.panel2.Location = new System.Drawing.Point(754, 117);
            this.panel2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(344, 60);
            this.panel2.TabIndex = 38;
            // 
            // btnvanchuyen
            // 
            this.btnvanchuyen.Location = new System.Drawing.Point(1141, 119);
            this.btnvanchuyen.Name = "btnvanchuyen";
            this.btnvanchuyen.Size = new System.Drawing.Size(118, 52);
            this.btnvanchuyen.TabIndex = 39;
            this.btnvanchuyen.Text = "Tiến hành vận chuyển";
            this.btnvanchuyen.UseVisualStyleBackColor = true;
            this.btnvanchuyen.Click += new System.EventHandler(this.btnvanchuyen_Click);
            // 
            // DonHang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1291, 517);
            this.Controls.Add(this.btnvanchuyen);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtMaKhachHang);
            this.Controls.Add(this.btnTim);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.cbtrangthai);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnsua);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ds_donhang);
            this.Name = "DonHang";
            this.Text = "DonHang";
            this.Load += new System.EventHandler(this.DonHang_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ds_donhang)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView ds_donhang;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnxoa;
        private System.Windows.Forms.Button btnsua;
        private System.Windows.Forms.Button btnthoat;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbtrangthai;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem sảnPhẩmToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem đơnHàngToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem kháchHàngToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem vậnChuyểnToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem doanhThuToolStripMenuItem;
        private System.Windows.Forms.Button btnTim;
        private System.Windows.Forms.TextBox txtMaKhachHang;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnlammoi;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnvanchuyen;
    }
}