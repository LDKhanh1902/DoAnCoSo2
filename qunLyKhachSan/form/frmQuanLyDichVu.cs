using qunLyKhachSan.Model;
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
    public partial class frmQuanLyDichVu : Form
    {
        DbModelContext db = new DbModelContext();

        public frmQuanLyDichVu()
        {
            InitializeComponent();
        }

        private void frmQuanLyDichVu_Load(object sender, EventArgs e)
        {
            dgvDichVu.DataSource = db.Services.Select(s=>new { s.ID, s.Name, s.Price }).ToList();
            cbbMaPhong.DataSource = db.Rooms.Where(r => r.Status == "Trống").Select(r => r.ID).ToList();
        }

        private void dgvDichVu_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Kiểm tra xem người dùng có nhấp vào một ô hợp lệ không
            if (e.RowIndex >= 0) // e.RowIndex = -1 nếu nhấp vào tiêu đề cột
            {
                // Lấy chỉ số dòng đã chọn
                int rowIndex = e.RowIndex;

                // Lấy dữ liệu từ các ô trong dòng đã chọn
                string maDichVu = dgvDichVu.Rows[rowIndex].Cells["MaDichVu"].Value.ToString();
                string tenDichVu = dgvDichVu.Rows[rowIndex].Cells["TenDichVu"].Value.ToString();
                string gia = dgvDichVu.Rows[rowIndex].Cells["Gia"].Value.ToString();

                // Cập nhật các TextBox
                txtMaDichVu.Text = maDichVu;
                cbbTenDichVu.Text = tenDichVu;
                txtGia.Text = gia;
            }
        }

        private void btnSuaDVPhong_Click(object sender, EventArgs e)
        {

        }

        private void btnTenDVPhong_Click(object sender, EventArgs e)
        {

        }

        private void btnCapNhatDVPhong_Click(object sender, EventArgs e)
        {

        }
    }
}
