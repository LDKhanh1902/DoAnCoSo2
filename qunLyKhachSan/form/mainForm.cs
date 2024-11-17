using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace qunLyKhachSan
{
    public partial class mainForm : Form
    {
        public mainForm()
        {
            InitializeComponent();
        }

        private void btnThoat_frmMain_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnQuyDinh_Click(object sender, EventArgs e)
        {
        //https://www.hoteljob.vn/tin-tuc/nhung-noi-quy-nhan-vien-bo-phan-tien-sanh-khach-san-nen-biet
        }

        private void btnDatPhong_Click(object sender, EventArgs e)
        {
            frmDatPhong frmDatPhong = new frmDatPhong();
            frmDatPhong.Show();
        }

        private void btnNhanPhong_Click(object sender, EventArgs e)
        {
            frmNhanPhong frmNhanPhong=new frmNhanPhong();
            frmNhanPhong.Show();
        }

        private void btnQLNV_Click(object sender, EventArgs e)
        {
            frmQuanLyNhanVien frmQuanLyNhanVien = new frmQuanLyNhanVien();
            frmQuanLyNhanVien.Show();
        }

        private void mainForm_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            var t = new frmQuyenTruyCap();
            t.Show();
        }

        private void btnQLKhachHang_Click(object sender, EventArgs e)
        {
            new frmQuanLyKhachHang().Show();
        }

        private void btnThongTinNhanVien_Click(object sender, EventArgs e)
        {
            new frmThongTinNhanVien().Show();
        }

        private void btnQLDichVu_Click(object sender, EventArgs e)
        {
            new frmQuanLyDichVu().Show();
        }
    }
}
