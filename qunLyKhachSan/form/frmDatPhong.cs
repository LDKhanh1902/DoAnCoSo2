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
    public partial class frmDatPhong : Form
    {
        DbModelContext db = new DbModelContext();

        public frmDatPhong()
        {
            InitializeComponent();
        }

        private void btnThoat_frmMain_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            frmChiTietDatPhong chiTietDatPhong = new frmChiTietDatPhong();
            chiTietDatPhong.Show();
        }

        private void frmDatPhong_Load(object sender, EventArgs e)
        {
            dgvDSDatPhong.DataSource = db.Bills.Where(r=>r.Status == "Đã đặt").ToList();

            cbbTenLoai.DataSource = db.RoomTypes.Select(rt => rt.TypeName).ToList();
        }

        private void btnDatPhong_Click(object sender, EventArgs e)
        {
            // Lấy ID nhân viên dựa trên email người dùng
            int id_em = db.Employees
                .Where(em => em.Email == User.UserName)
                .Select(em => em.ID)
                .FirstOrDefault();

            // Kiểm tra xem ID nhân viên có hợp lệ không
            if (id_em == 0)
            {
                MessageBox.Show("Không tìm thấy nhân viên với email này.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Lấy ID khách hàng dựa trên tên khách hàng
            int id_cus = db.Customer
                .Where(cus => cus.Name == txtHovaTen.Text)
                .Select(cus => cus.ID)
                .FirstOrDefault();

            // Kiểm tra xem ID khách hàng có hợp lệ không
            if (id_cus == 0)
            {
                MessageBox.Show("Không tìm thấy khách hàng với tên này.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Tạo một đối tượng Bill mới
            var newBill = new Bill()
            {
                EmployeeID = id_em,
                CustomerID = id_cus,
                CheckIn = timeNhanPhong.Value,
                CheckOut = TimeTraPhong.Value,
                RoomID = int.Parse(cbbMaPhong.Text), // Hàm này cần được định nghĩa để lấy ID phòng đã chọn
                Status = "Đã đặt"
            };

            // Thêm đối tượng Bill vào DbSet
            db.Bills.Add(newBill);

            // Lưu thay đổi vào cơ sở dữ liệu
            try
            {
                db.SaveChanges();
                MessageBox.Show("Đặt phòng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi xảy ra khi đặt phòng: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cbbMaPhong_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Lấy danh sách phòng trống
            cbbMaPhong.DataSource = db.Rooms.Where(r => r.Status == "Trống").Select(r => r.ID).ToList();

            // Kiểm tra xem có phòng nào được chọn không
            if (cbbMaPhong.SelectedItem != null)
            {
                int selectedRoomId = (int)cbbMaPhong.SelectedItem;

                // Lấy giá phòng theo loại phòng
                var room = db.Rooms.FirstOrDefault(r => r.ID == selectedRoomId);
                if (room != null)
                {
                    txtGia.Text = room.Price.ToString();
                }
                else
                {
                    txtGia.Text = "0"; // Hoặc một giá trị mặc định khác
                }

                // Lấy số người tối đa theo loại phòng
                var roomType = db.RoomTypes.FirstOrDefault(rt => rt.ID == room.TypeRoomID);
                if (roomType != null)
                {
                    txtSoNguoiToiDa.Text = roomType.MaxOccupancy.ToString();
                }
                else
                {
                    txtSoNguoiToiDa.Text = "0"; // Hoặc một giá trị mặc định khác
                }
            }
        }

        private void cbbTenLoai_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Cập nhật danh sách phòng theo loại phòng đã chọn
            cbbMaPhong.DataSource = db.Rooms.Where(r => r.RoomType.TypeName == cbbTenLoai.Text).Select(r => r.ID).ToList();
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            // Validate input
            if (string.IsNullOrWhiteSpace(txtTimKiem.Text))
            {
                MessageBox.Show("Please enter a valid CCCD.");
                return;
            }

            // Search for the customer using the correct DbSet
            var customer = (from c in db.Customer
                            join ct in db.CustomerTypes on c.CountryID equals ct.ID // Corrected syntax
                            where c.CCCD == txtTimKiem.Text // Condition to search by CCCD
                            select c).FirstOrDefault();

            if (customer != null)
            {
                // Populate fields with customer information
                txtHovaTen.Text = customer.Name; // Assuming you want the customer's name
                txtDiaChi.Text = customer.Address;
                txtSDT.Text = customer.PhoneNumber;
                cbbGioiTinh.Text = customer.Gender;

                // Check if Country is not null before accessing its NAME
                cbbQuocTich.Text = customer.Country != null ? customer.Country.Name : "Unknown";

                // Set the date directly
                dtpNgaySinh.Value = customer.DateOfBirth; // Use Value for DateTimePicker

                txtCCCD.Text = customer.CCCD;

                // Assuming you want to set the customer type name instead of ID
                cbbLoaiKhachHang.Text = db.CustomerTypes.Where(ct=>ct.ID == customer.CustomerTypeID).FirstOrDefault().Name;
            }
            else
            {
                MessageBox.Show("No customer found with the provided CCCD.");
            }
        }

        private void dgvDSDatPhong_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
