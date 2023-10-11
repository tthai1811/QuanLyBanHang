namespace doanmonhocqlbh
{
    partial class KhachHang
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(KhachHang));
            this.ds_khachhang = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.sảnPhẩmToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.đơnHàngToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.kháchHàngToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.vậnChuyểnToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.doanhThuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label2 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.tenkhachhang = new System.Windows.Forms.TextBox();
            this.txtsdt = new System.Windows.Forms.TextBox();
            this.txtdiachi = new System.Windows.Forms.TextBox();
            this.txtemail = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.btncapnhat = new System.Windows.Forms.Button();
            this.btnxoa = new System.Windows.Forms.Button();
            this.txtMaKhachHang = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.btnlammoi = new System.Windows.Forms.Button();
            this.btnvip = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.ds_khachhang)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ds_khachhang
            // 
            this.ds_khachhang.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ds_khachhang.Location = new System.Drawing.Point(16, 340);
            this.ds_khachhang.MultiSelect = false;
            this.ds_khachhang.Name = "ds_khachhang";
            this.ds_khachhang.RowHeadersWidth = 51;
            this.ds_khachhang.RowTemplate.Height = 24;
            this.ds_khachhang.Size = new System.Drawing.Size(832, 328);
            this.ds_khachhang.TabIndex = 0;
            this.ds_khachhang.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.ds_khachhang_CellContentClick);
            this.ds_khachhang.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.ds_khachhang_RowEnter);
            this.ds_khachhang.SelectionChanged += new System.EventHandler(this.ds_khachhang_SelectionChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("UVN Bach Dang Nang", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(219, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(438, 54);
            this.label1.TabIndex = 1;
            this.label1.Text = "KHÁCH HÀNG ĐÃ ĐẶT";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(701, 104);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(121, 52);
            this.button1.TabIndex = 2;
            this.button1.Text = "Lập đơn hàng";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
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
            this.menuStrip1.Size = new System.Drawing.Size(848, 28);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // sảnPhẩmToolStripMenuItem
            // 
            this.sảnPhẩmToolStripMenuItem.Name = "sảnPhẩmToolStripMenuItem";
            this.sảnPhẩmToolStripMenuItem.Size = new System.Drawing.Size(88, 24);
            this.sảnPhẩmToolStripMenuItem.Text = "Sản Phẩm";
            this.sảnPhẩmToolStripMenuItem.Click += new System.EventHandler(this.sảnPhẩmToolStripMenuItem_Click);
            // 
            // đơnHàngToolStripMenuItem
            // 
            this.đơnHàngToolStripMenuItem.Name = "đơnHàngToolStripMenuItem";
            this.đơnHàngToolStripMenuItem.Size = new System.Drawing.Size(91, 24);
            this.đơnHàngToolStripMenuItem.Text = "Đơn Hàng";
            this.đơnHàngToolStripMenuItem.Click += new System.EventHandler(this.đơnHàngToolStripMenuItem_Click);
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
            this.doanhThuToolStripMenuItem.Click += new System.EventHandler(this.doanhThuToolStripMenuItem_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(99, 281);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(143, 16);
            this.label2.TabIndex = 4;
            this.label2.Text = "Danh sách khách hàng";
            // 
            // button2
            // 
            this.button2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button2.BackgroundImage")));
            this.button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button2.Location = new System.Drawing.Point(12, 104);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(90, 52);
            this.button2.TabIndex = 5;
            this.button2.Text = "Tìm";
            this.button2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // tenkhachhang
            // 
            this.tenkhachhang.Location = new System.Drawing.Point(364, 187);
            this.tenkhachhang.Name = "tenkhachhang";
            this.tenkhachhang.Size = new System.Drawing.Size(142, 22);
            this.tenkhachhang.TabIndex = 7;
            // 
            // txtsdt
            // 
            this.txtsdt.Location = new System.Drawing.Point(364, 232);
            this.txtsdt.Name = "txtsdt";
            this.txtsdt.Size = new System.Drawing.Size(142, 22);
            this.txtsdt.TabIndex = 8;
            // 
            // txtdiachi
            // 
            this.txtdiachi.Location = new System.Drawing.Point(613, 184);
            this.txtdiachi.Name = "txtdiachi";
            this.txtdiachi.Size = new System.Drawing.Size(171, 22);
            this.txtdiachi.TabIndex = 9;
            // 
            // txtemail
            // 
            this.txtemail.Location = new System.Drawing.Point(613, 226);
            this.txtemail.Name = "txtemail";
            this.txtemail.Size = new System.Drawing.Size(171, 22);
            this.txtemail.TabIndex = 10;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(235, 190);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(107, 16);
            this.label3.TabIndex = 11;
            this.label3.Text = "Tên Khách Hàng";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(323, 232);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 16);
            this.label4.TabIndex = 12;
            this.label4.Text = "SDT";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(525, 187);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(49, 16);
            this.label5.TabIndex = 11;
            this.label5.Text = "Địa Chỉ";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(533, 226);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 16);
            this.label6.TabIndex = 11;
            this.label6.Text = "Email";
            // 
            // btncapnhat
            // 
            this.btncapnhat.Image = ((System.Drawing.Image)(resources.GetObject("btncapnhat.Image")));
            this.btncapnhat.ImageAlign = System.Drawing.ContentAlignment.BottomRight;
            this.btncapnhat.Location = new System.Drawing.Point(178, 104);
            this.btncapnhat.Name = "btncapnhat";
            this.btncapnhat.Size = new System.Drawing.Size(103, 52);
            this.btncapnhat.TabIndex = 13;
            this.btncapnhat.Text = "Cập nhật";
            this.btncapnhat.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btncapnhat.UseVisualStyleBackColor = true;
            this.btncapnhat.Click += new System.EventHandler(this.btncapnhat_Click);
            // 
            // btnxoa
            // 
            this.btnxoa.Image = ((System.Drawing.Image)(resources.GetObject("btnxoa.Image")));
            this.btnxoa.Location = new System.Drawing.Point(380, 104);
            this.btnxoa.Name = "btnxoa";
            this.btnxoa.Size = new System.Drawing.Size(103, 52);
            this.btnxoa.TabIndex = 14;
            this.btnxoa.Text = "Xóa";
            this.btnxoa.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnxoa.UseVisualStyleBackColor = true;
            this.btnxoa.Click += new System.EventHandler(this.btnxoa_Click);
            // 
            // txtMaKhachHang
            // 
            this.txtMaKhachHang.Location = new System.Drawing.Point(129, 220);
            this.txtMaKhachHang.Name = "txtMaKhachHang";
            this.txtMaKhachHang.Size = new System.Drawing.Size(152, 22);
            this.txtMaKhachHang.TabIndex = 15;
            this.txtMaKhachHang.TextChanged += new System.EventHandler(this.txtMaKhachHang_TextChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(13, 223);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(102, 16);
            this.label7.TabIndex = 11;
            this.label7.Text = "Mã Khách Hàng";
            // 
            // btnlammoi
            // 
            this.btnlammoi.Image = ((System.Drawing.Image)(resources.GetObject("btnlammoi.Image")));
            this.btnlammoi.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnlammoi.Location = new System.Drawing.Point(536, 104);
            this.btnlammoi.Name = "btnlammoi";
            this.btnlammoi.Size = new System.Drawing.Size(103, 52);
            this.btnlammoi.TabIndex = 16;
            this.btnlammoi.Text = "Làm mới";
            this.btnlammoi.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnlammoi.UseVisualStyleBackColor = true;
            this.btnlammoi.Click += new System.EventHandler(this.btnlammoi_Click);
            // 
            // btnvip
            // 
            this.btnvip.Location = new System.Drawing.Point(670, 274);
            this.btnvip.Name = "btnvip";
            this.btnvip.Size = new System.Drawing.Size(152, 60);
            this.btnvip.TabIndex = 17;
            this.btnvip.Text = "Khách hàng chuyển vọng";
            this.btnvip.UseVisualStyleBackColor = true;
            this.btnvip.Click += new System.EventHandler(this.btnvip_Click);
            // 
            // KhachHang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(848, 680);
            this.Controls.Add(this.btnvip);
            this.Controls.Add(this.btnlammoi);
            this.Controls.Add(this.txtMaKhachHang);
            this.Controls.Add(this.btnxoa);
            this.Controls.Add(this.btncapnhat);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtemail);
            this.Controls.Add(this.txtdiachi);
            this.Controls.Add(this.txtsdt);
            this.Controls.Add(this.tenkhachhang);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ds_khachhang);
            this.Name = "KhachHang";
            this.Text = "KhachHang";
            this.Load += new System.EventHandler(this.KhachHang_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ds_khachhang)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem sảnPhẩmToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem đơnHàngToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem kháchHàngToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem vậnChuyểnToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem doanhThuToolStripMenuItem;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox tenkhachhang;
        private System.Windows.Forms.TextBox txtsdt;
        private System.Windows.Forms.TextBox txtdiachi;
        private System.Windows.Forms.TextBox txtemail;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btncapnhat;
        private System.Windows.Forms.Button btnxoa;
        private System.Windows.Forms.TextBox txtMaKhachHang;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnlammoi;
        private System.Windows.Forms.Button btnvip;
        public System.Windows.Forms.DataGridView ds_khachhang;
    }
}