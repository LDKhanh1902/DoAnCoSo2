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
            cbbMaPhong.DataSource = db.Rooms.Where(r => r.Status != "Có người").Select(r => r.ID).ToList();
        }

        private void dgvDichVu_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Kiểm tra xem người dùng có nhấp vào một ô hợp lệ không
            if (e.RowIndex >= 0) // e.RowIndex = -1 nếu nhấp vào tiêu đề cột
            {
                // Lấy chỉ số dòng đã chọn
                int rowIndex = e.RowIndex;

                // Lấy dữ liệu từ các ô trong dòng đã chọn
                txtMaDichVu.Text = dgvDichVu.Rows[rowIndex].Cells["ID"].Value.ToString();
                cbbTenDichVu.Text = dgvDichVu.Rows[rowIndex].Cells["Name"].Value.ToString();
                txtGia.Text = dgvDichVu.Rows[rowIndex].Cells["Price"].Value.ToString();
            }
        }

        private void btnSuaDVPhong_Click(object sender, EventArgs e)
        {

        }

        private void btnCapNhatDVPhong_Click(object sender, EventArgs e)
        {

        }

        private void btnThemDVPhong_Click(object sender, EventArgs e)
        {
            // Lấy ID của hóa đơn dựa trên mã phòng đã chọn
            int id_bill = db.Bills
                .Where(b => b.RoomID == int.Parse(cbbMaPhong.Text))
                .Select(b => b.ID)
                .FirstOrDefault();

            // Kiểm tra xem có hóa đơn nào tương ứng không
            if (id_bill == 0)
            {
                MessageBox.Show("Không tìm thấy hóa đơn cho phòng này.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Tạo một đối tượng BillDetail mới
            var item = new BillDetail()
            {
                ServiceID = int.Parse(txtMaDichVu.Text),
                BillID = id_bill,
                Quantity = 1 // Hoặc có thể lấy từ một TextBox khác nếu cần
            };

            // Thêm đối tượng BillDetail vào DbSet
            db.BillDetails.Add(item);

            // Lưu thay đổi vào cơ sở dữ liệu
            try
            {
                db.SaveChanges();
                MessageBox.Show("Thêm dịch vụ thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi xảy ra: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
