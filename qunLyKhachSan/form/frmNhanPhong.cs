using qunLyKhachSan.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
            dgvDSNhanPhong.DataSource = db.Bills
                                        .Where(b => b.Status == "Đã đặt")
                                        .Select(b => new
                                        {
                                            b.ID,
                                            CustomerName = b.Customer.Name,
                                            RoomPrice = b.Room.Price, // Định dạng giá theo kiểu tiền tệ với 2 chữ số thập phân
                                            b.CheckIn,
                                            b.Status,
                                            b.CheckOut
                                        })
                                        .ToList();
        }

        private void btnNhanPhong_Click(object sender, EventArgs e)
        {
            // Lấy ID khách hàng dựa trên tên
            int id_cus = db.Customer
                           .Where(c => c.Name == txtHoTen.Text)
                           .Select(c => c.ID)
                           .FirstOrDefault();

            // Kiểm tra xem khách hàng có tồn tại không
            if (id_cus == 0) // Nếu không tìm thấy khách hàng
            {
                MessageBox.Show("Không tìm thấy khách hàng với tên: " + txtHoTen.Text);
                return; // Thoát khỏi phương thức
            }

            // Lấy hóa đơn dựa trên ID khách hàng
            var bill = db.Bills
                         .Where(b => b.CustomerID == id_cus)
                         .FirstOrDefault();

            // Kiểm tra xem hóa đơn có tồn tại không
            if (bill == null) // Nếu không tìm thấy hóa đơn
            {
                MessageBox.Show("Không tìm thấy hóa đơn cho khách hàng: " + txtHoTen.Text);
                return; // Thoát khỏi phương thức
            }

            // Cập nhật trạng thái hóa đơn
            bill.Status = "Đã nhận";

            // Lưu thay đổi vào cơ sở dữ liệu
            db.SaveChanges();

            MessageBox.Show("Hóa đơn đã được cập nhật thành công.");
        }
    }
}
