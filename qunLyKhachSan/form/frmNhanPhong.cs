using qunLyKhachSan.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace qunLyKhachSan
{
    public partial class frmNhanPhong : Form
    {
        DbModelContext db = new DbModelContext();   

        public frmNhanPhong()
        {
            InitializeComponent();
        }

        private void btnThoat_frmMain_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnThemKhachHang_Click(object sender, EventArgs e)
        {

        }

        private void frmNhanPhong_Load(object sender, EventArgs e)
        {
            // Giả sử bạn đã có DataGridView dgvDSNhanPhong và DbContext db
            var today = DateTime.Now.Date; // Ngày hôm nay không có phần thời gian
            var tomorrow = today.AddDays(1); // Ngày mai

            dgvDSNhanPhong.DataSource = db.Bills
                .Where(b => b.Status == "Đã đặt" &&
                            b.CheckIn >= today &&
                            b.CheckIn < tomorrow) // So sánh với khoảng thời gian của ngày hôm nay
                .Select(b => new
                {
                    b.ID,
                    CustomerName = b.Customer.Name,
                    CCCD = b.Customer.CCCD,
                    RoomType = b.Room.RoomType.TypeName,
                    RoomPrice = b.Room.Price, // Để lại giá nguyên thủy
                    b.CheckIn,
                    b.Status,
                    b.CheckOut
                })
                .ToList();
        }

        private void btnNhanPhong_Click(object sender, EventArgs e)
        {
            // Lấy ID khách hàng dựa trên tên
            var customer = db.Customer
                             .FirstOrDefault(c => c.Name == txtHoTen.Text);

            // Kiểm tra xem khách hàng có tồn tại không
            if (customer == null) // Nếu không tìm thấy khách hàng
            {
                MessageBox.Show("Không tìm thấy khách hàng với tên: " + txtHoTen.Text);
                return; // Thoát khỏi phương thức
            }

            // Lấy hóa đơn dựa trên ID khách hàng
            var bill = db.Bills
                         .Include(b => b.Room) // Tải thông tin phòng cùng với hóa đơn
                         .FirstOrDefault(b => b.CustomerID == customer.ID);

            // Kiểm tra xem hóa đơn có tồn tại không
            if (bill == null) // Nếu không tìm thấy hóa đơn
            {
                MessageBox.Show("Không tìm thấy hóa đơn cho khách hàng: " + txtHoTen.Text);
                return; // Thoát khỏi phương thức
            }

            // Kiểm tra xem phòng có tồn tại không
            if (bill.Room == null) // Nếu không tìm thấy phòng liên quan
            {
                MessageBox.Show("Không tìm thấy phòng cho hóa đơn này.");
                return; // Thoát khỏi phương thức
            }

            // Cập nhật trạng thái hóa đơn và phòng
            bill.Status = "Đã nhận";
            bill.Room.Status = "Có người";

            // Lưu thay đổi vào cơ sở dữ liệu
            db.SaveChanges();

            MessageBox.Show("Hóa đơn đã được cập nhật thành công.");
            frmNhanPhong_Load(sender, e);
        }

        private void dgvDSNhanPhong_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Kiểm tra xem người dùng có nhấp vào một ô hợp lệ không
            if (e.RowIndex >= 0) // e.RowIndex sẽ là -1 nếu nhấp vào header
            {
                // Lấy hàng được chọn
                DataGridViewRow selectedRow = dgvDSNhanPhong.Rows[e.RowIndex];

                // Lấy thông tin từ các ô trong hàng được chọn
                txtHoTen.Text = selectedRow.Cells["CustomerName"].Value.ToString();
                txtGia.Text = selectedRow.Cells["RoomPrice"].Value.ToString();
                dtpNgayNhan.Value = (DateTime)selectedRow.Cells["CheckIn"].Value;
                dtpNgayTra.Value = (DateTime)selectedRow.Cells["CheckOut"].Value;
                txtCCCD.Text = selectedRow.Cells["CCCD"].ToString();
                txtTenPhong.Text = selectedRow.Cells["ID"].Value.ToString();
                txtTenLoaiPhong.Text = selectedRow.Cells["RoomType"].Value.ToString();
            }
        }
    }
}
