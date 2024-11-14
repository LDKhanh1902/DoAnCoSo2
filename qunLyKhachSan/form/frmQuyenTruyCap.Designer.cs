namespace qunLyKhachSan
{
    partial class frmQuyenTruyCap
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmQuyenTruyCap));
            this.btnThoat = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnXoaHet = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnThem = new System.Windows.Forms.Button();
            this.btnThemHet = new System.Windows.Forms.Button();
            this.gbPermission = new System.Windows.Forms.GroupBox();
            this.lsbPermission = new System.Windows.Forms.ListBox();
            this.gbPermissionCurrent = new System.Windows.Forms.GroupBox();
            this.lsbPermissionCurrent = new System.Windows.Forms.ListBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnDong = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            this.btnthemMoi = new System.Windows.Forms.Button();
            this.btnSuaTen = new System.Windows.Forms.Button();
            this.cbbLoaiNhanVien = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.gbPermission.SuspendLayout();
            this.gbPermissionCurrent.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnThoat
            // 
            this.btnThoat.FlatAppearance.BorderSize = 0;
            this.btnThoat.Image = ((System.Drawing.Image)(resources.GetObject("btnThoat.Image")));
            this.btnThoat.Location = new System.Drawing.Point(791, 0);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(50, 50);
            this.btnThoat.TabIndex = 7;
            this.btnThoat.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnThoat.UseVisualStyleBackColor = false;
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(254)));
            this.label1.ForeColor = System.Drawing.Color.Teal;
            this.label1.Location = new System.Drawing.Point(5, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(275, 39);
            this.label1.TabIndex = 8;
            this.label1.Text = "Quyền Truy Cập:";
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.btnXoaHet);
            this.panel1.Controls.Add(this.btnXoa);
            this.panel1.Controls.Add(this.btnThem);
            this.panel1.Controls.Add(this.btnThemHet);
            this.panel1.Controls.Add(this.gbPermission);
            this.panel1.Controls.Add(this.gbPermissionCurrent);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Location = new System.Drawing.Point(14, 46);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(826, 542);
            this.panel1.TabIndex = 9;
            // 
            // btnXoaHet
            // 
            this.btnXoaHet.Location = new System.Drawing.Point(373, 431);
            this.btnXoaHet.Name = "btnXoaHet";
            this.btnXoaHet.Size = new System.Drawing.Size(75, 23);
            this.btnXoaHet.TabIndex = 2;
            this.btnXoaHet.Text = "<<";
            this.btnXoaHet.UseVisualStyleBackColor = true;
            this.btnXoaHet.Click += new System.EventHandler(this.btnXoaHet_Click);
            // 
            // btnXoa
            // 
            this.btnXoa.Location = new System.Drawing.Point(374, 402);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(75, 23);
            this.btnXoa.TabIndex = 2;
            this.btnXoa.Text = "<";
            this.btnXoa.UseVisualStyleBackColor = true;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // btnThem
            // 
            this.btnThem.Location = new System.Drawing.Point(373, 314);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(75, 23);
            this.btnThem.TabIndex = 2;
            this.btnThem.Text = ">";
            this.btnThem.UseVisualStyleBackColor = true;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // btnThemHet
            // 
            this.btnThemHet.Location = new System.Drawing.Point(374, 285);
            this.btnThemHet.Name = "btnThemHet";
            this.btnThemHet.Size = new System.Drawing.Size(75, 23);
            this.btnThemHet.TabIndex = 2;
            this.btnThemHet.Text = ">>";
            this.btnThemHet.UseVisualStyleBackColor = true;
            this.btnThemHet.Click += new System.EventHandler(this.btnThemHet_Click);
            // 
            // gbPermission
            // 
            this.gbPermission.Controls.Add(this.lsbPermission);
            this.gbPermission.Location = new System.Drawing.Point(14, 172);
            this.gbPermission.Name = "gbPermission";
            this.gbPermission.Size = new System.Drawing.Size(358, 368);
            this.gbPermission.TabIndex = 1;
            this.gbPermission.TabStop = false;
            this.gbPermission.Text = "Quyền còn lại";
            // 
            // lsbPermission
            // 
            this.lsbPermission.FormattingEnabled = true;
            this.lsbPermission.ItemHeight = 16;
            this.lsbPermission.Location = new System.Drawing.Point(6, 21);
            this.lsbPermission.Name = "lsbPermission";
            this.lsbPermission.Size = new System.Drawing.Size(346, 340);
            this.lsbPermission.TabIndex = 0;
            // 
            // gbPermissionCurrent
            // 
            this.gbPermissionCurrent.Controls.Add(this.lsbPermissionCurrent);
            this.gbPermissionCurrent.Location = new System.Drawing.Point(463, 172);
            this.gbPermissionCurrent.Name = "gbPermissionCurrent";
            this.gbPermissionCurrent.Size = new System.Drawing.Size(350, 368);
            this.gbPermissionCurrent.TabIndex = 1;
            this.gbPermissionCurrent.TabStop = false;
            this.gbPermissionCurrent.Text = "Quyền hiện Tại";
            // 
            // lsbPermissionCurrent
            // 
            this.lsbPermissionCurrent.FormattingEnabled = true;
            this.lsbPermissionCurrent.ItemHeight = 16;
            this.lsbPermissionCurrent.Location = new System.Drawing.Point(6, 22);
            this.lsbPermissionCurrent.Name = "lsbPermissionCurrent";
            this.lsbPermissionCurrent.Size = new System.Drawing.Size(338, 340);
            this.lsbPermissionCurrent.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnDong);
            this.groupBox1.Controls.Add(this.btnSua);
            this.groupBox1.Controls.Add(this.btnthemMoi);
            this.groupBox1.Controls.Add(this.btnSuaTen);
            this.groupBox1.Controls.Add(this.cbbLoaiNhanVien);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(254)));
            this.groupBox1.Location = new System.Drawing.Point(14, 15);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(799, 146);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Loại nhân viên";
            // 
            // btnDong
            // 
            this.btnDong.Location = new System.Drawing.Point(454, 75);
            this.btnDong.Name = "btnDong";
            this.btnDong.Size = new System.Drawing.Size(187, 53);
            this.btnDong.TabIndex = 2;
            this.btnDong.Text = "Đóng";
            this.btnDong.UseVisualStyleBackColor = true;
            // 
            // btnSua
            // 
            this.btnSua.Location = new System.Drawing.Point(248, 75);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(187, 53);
            this.btnSua.TabIndex = 2;
            this.btnSua.Text = "Sửa";
            this.btnSua.UseVisualStyleBackColor = true;
            // 
            // btnthemMoi
            // 
            this.btnthemMoi.Location = new System.Drawing.Point(454, 16);
            this.btnthemMoi.Name = "btnthemMoi";
            this.btnthemMoi.Size = new System.Drawing.Size(187, 53);
            this.btnthemMoi.TabIndex = 2;
            this.btnthemMoi.Text = "Thêm mới";
            this.btnthemMoi.UseVisualStyleBackColor = true;
            // 
            // btnSuaTen
            // 
            this.btnSuaTen.Location = new System.Drawing.Point(248, 16);
            this.btnSuaTen.Name = "btnSuaTen";
            this.btnSuaTen.Size = new System.Drawing.Size(187, 53);
            this.btnSuaTen.TabIndex = 2;
            this.btnSuaTen.Text = "Sửa tên";
            this.btnSuaTen.UseVisualStyleBackColor = true;
            // 
            // cbbLoaiNhanVien
            // 
            this.cbbLoaiNhanVien.FormattingEnabled = true;
            this.cbbLoaiNhanVien.Location = new System.Drawing.Point(6, 55);
            this.cbbLoaiNhanVien.Name = "cbbLoaiNhanVien";
            this.cbbLoaiNhanVien.Size = new System.Drawing.Size(197, 28);
            this.cbbLoaiNhanVien.TabIndex = 1;
            this.cbbLoaiNhanVien.Text = "Quản lý";
            this.cbbLoaiNhanVien.SelectedIndexChanged += new System.EventHandler(this.cbbLoaiNhanVien_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(254)));
            this.label2.Location = new System.Drawing.Point(6, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(149, 20);
            this.label2.TabIndex = 0;
            this.label2.Text = "Tên loại nhân viên:";
            // 
            // frmQuyenTruyCap
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(841, 600);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnThoat);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmQuyenTruyCap";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmQuyenTruyCap";
            this.Load += new System.EventHandler(this.frmQuyenTruyCap_Load);
            this.panel1.ResumeLayout(false);
            this.gbPermission.ResumeLayout(false);
            this.gbPermissionCurrent.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnThoat;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cbbLoaiNhanVien;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnXoaHet;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Button btnThemHet;
        private System.Windows.Forms.GroupBox gbPermission;
        private System.Windows.Forms.GroupBox gbPermissionCurrent;
        private System.Windows.Forms.Button btnDong;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button btnthemMoi;
        private System.Windows.Forms.Button btnSuaTen;
        private System.Windows.Forms.ListBox lsbPermission;
        private System.Windows.Forms.ListBox lsbPermissionCurrent;
    }
}