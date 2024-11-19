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
    public partial class frmQuanLyKhachHang : Form
    {
        DbModelContext db = new DbModelContext();

        public frmQuanLyKhachHang()
        {
            InitializeComponent();
        }

        private void btnThoat_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void frmQuanLyKhachHang_Load(object sender, EventArgs e)
        {
            var query = from c in db.Customer
                        join ct in db.CustomerTypes on c.CustomerTypeID equals ct.ID
                        join ctr in db.Countries on c.CountryID equals ctr.ID
                        select new
                        {
                            c.ID,
                            c.Name,
                            c.Address,
                            c.CCCD,
                            c.DateOfBirth,
                            CountryName = ctr.Name,
                            CustomerTypeName = ct.Name,
                            c.Gender,
                            c.Email,
                            c.PhoneNumber
                        };

            dgvCustomer.DataSource = query.ToList();

            cbbLoaiKhachHang.DataSource = db.CustomerTypes.ToList();
            cbbLoaiKhachHang.DisplayMember = "NAME";
            cbbLoaiKhachHang.ValueMember = "NAME";

            cbbQuocTich.DataSource = db.Countries.ToList();
            cbbQuocTich.DisplayMember = "NAME";
            cbbQuocTich.ValueMember = "NAME";

            cbbGioiTinh.Items.Add("Nam");
            cbbGioiTinh.Items.Add("Nữ");
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (db.Customer.Any(c => c.CCCD == txtCCCD.Text))
            {
                MessageBox.Show("CCCD này đã được đăng kí trước đó");
                return;
            }

            var countryId = db.Countries.Where(c => c.Name == cbbQuocTich.Text).Select(c => c.ID).FirstOrDefault();
            if (countryId == 0)
            {
                MessageBox.Show("Quốc tịch không hợp lệ.");
                return;
            }

            var typeId = db.CustomerTypes.Where(c => c.Name == cbbLoaiKhachHang.Text).Select(c => c.ID).FirstOrDefault();
            if (typeId == 0)
            {
                MessageBox.Show("Loại khách hàng không hợp lệ.");
                return;
            }

            // Kiểm tra các trường bắt buộc
            if (string.IsNullOrWhiteSpace(txtHoTen.Text) ||
                string.IsNullOrWhiteSpace(txtDiaChi.Text) ||
                string.IsNullOrWhiteSpace(txtCCCD.Text) ||
                string.IsNullOrWhiteSpace(txtEmail.Text) ||
                string.IsNullOrWhiteSpace(cbbGioiTinh.Text) ||
                string.IsNullOrWhiteSpace(txtPhoneNumber.Text))
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin.");
                return;
            }

            var newCustomer = new Customer
            {
                Name = txtHoTen.Text,
                Address = txtDiaChi.Text,
                CCCD = txtCCCD.Text,
                CountryID = countryId,
                CustomerTypeID = typeId,
                DateOfBirth = dtpNgaySinh.Value,
                Email = txtEmail.Text,
                Gender = cbbGioiTinh.Text,
                PhoneNumber = txtPhoneNumber.Text,
            };

            db.Customer.Add(newCustomer);
            int result = db.SaveChanges();
            if (result > 0)
            {
                MessageBox.Show("Thêm khách hàng thành công!");
            }
            else
            {
                MessageBox.Show("Không có thay đổi nào được thực hiện.");
            }
            frmQuanLyKhachHang_Load(sender, e);
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            // Lấy thông tin từ giao diện người dùng
            string cccd = txtCCCD.Text; // Giả sử bạn có một TextBox để nhập CCCD
            string name = txtHoTen.Text; // Tên khách hàng
            string address = txtDiaChi.Text; // Địa chỉ
            string email = txtEmail.Text; // Email
            string gender = cbbGioiTinh.Text; // Giới tính
            string phoneNumber = txtPhoneNumber.Text; // Số điện thoại
            DateTime dateOfBirth = dtpNgaySinh.Value; // Ngày sinh

            int typeId = db.CustomerTypes
                        .Where(t => t.Name == cbbLoaiKhachHang.Text)
                        .Select(t => t.ID).FirstOrDefault();
            int countryId = db.Countries.Where(c => c.Name == cbbQuocTich.Text)
                                        .Select(c => c.ID).FirstOrDefault();

            // Tìm khách hàng trong cơ sở dữ liệu
            var customer = db.Customer.FirstOrDefault(c => c.CCCD == cccd);

            // Kiểm tra xem khách hàng có tồn tại không
            if (customer == null)
            {
                MessageBox.Show("Khách hàng không tồn tại.");
                return;
            }

            // Lưu thay đổi vào cơ sở dữ liệu
            try
            {
                // Cập nhật thông tin khách hàng
                customer.Name = name;
                customer.Address = address;
                customer.Email = email;
                customer.Gender = gender;
                customer.PhoneNumber = phoneNumber;
                customer.DateOfBirth = dateOfBirth;
                customer.CountryID = countryId;
                customer.CustomerTypeID = typeId;

                int result = db.SaveChanges();
                if (result > 0)
                {
                    MessageBox.Show("Cập nhật thông tin khách hàng thành công!");
                }
                else
                {
                    MessageBox.Show("Không có thay đổi nào được thực hiện.");
                }
                frmQuanLyKhachHang_Load(sender, e);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi: " + ex.Message);
            }
        }

        private void dgvCustomer_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Kiểm tra xem người dùng có nhấp vào một hàng hợp lệ không
            if (e.RowIndex >= 0) // e.RowIndex < 0 có nghĩa là tiêu đề cột được nhấp vào
            {
                // Lấy thông tin từ hàng đã nhấp vào
                DataGridViewRow selectedRow = dgvCustomer.Rows[e.RowIndex];

                // Giả sử các cột trong DataGridView tương ứng với các thuộc tính của khách hàng
                txtId.Text = selectedRow.Cells["ID"].Value.ToString();
                txtCCCD.Text = selectedRow.Cells["CCCD"].Value.ToString();
                txtHoTen.Text = selectedRow.Cells["NAME"].Value.ToString();
                txtDiaChi.Text = selectedRow.Cells["ADDRESS"].Value.ToString();
                txtEmail.Text = selectedRow.Cells["EMAIL"].Value.ToString();
                cbbGioiTinh.Text = selectedRow.Cells["GENDER"].Value.ToString();
                txtPhoneNumber.Text = selectedRow.Cells["PHONENUMBER"].Value.ToString();
                dtpNgaySinh.Value = Convert.ToDateTime(selectedRow.Cells["DATEOFBIRTH"].Value);
                cbbQuocTich.Text = selectedRow.Cells["CountryName"].Value.ToString();
                cbbLoaiKhachHang.Text = selectedRow.Cells["CustomerTypeName"].Value.ToString();
            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            // Tìm kiếm khách hàng dựa trên số CCCD
            var customer = from c in db.Customer
                           join ct in db.CustomerTypes on c.CustomerTypeID equals ct.ID
                           join ctr in db.Countries on c.CountryID equals ctr.ID
                           where c.CCCD == txtTimKiem.Text
                           select new
                           {
                               c.ID,
                               c.Name,
                               c.Address,
                               c.CCCD,
                               c.DateOfBirth,
                               CountryName = ctr.Name,
                               CustomerTypeName = ct.Name,
                               c.Gender,
                               c.Email,
                               c.PhoneNumber
                           };

            // Kiểm tra nếu khách hàng tồn tại
            if (customer.Any())
            {
                // Cập nhật DataGridView với dữ liệu mới
                dgvCustomer.DataSource = customer.ToList();
            }
            else
            {
                // Hiển thị thông báo nếu không tìm thấy khách hàng
                MessageBox.Show("Không tìm thấy khách hàng với số CCCD này.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
