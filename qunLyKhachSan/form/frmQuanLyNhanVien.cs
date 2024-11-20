using qunLyKhachSan.form;
using qunLyKhachSan.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Infrastructure;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace qunLyKhachSan
{
    public partial class frmQuanLyNhanVien : Form
    {
        DbModelContext db = new DbModelContext();

        public frmQuanLyNhanVien()
        {
            InitializeComponent();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Application.Exit();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            frmQuyenTruyCap frmQuyenTruyCap = new frmQuyenTruyCap();
            frmQuyenTruyCap.Show();
        }

        private void frmQuanLyNhanVien_Load(object sender, EventArgs e)
        {
            var employees = from em in db.Employees
                            join p in db.Positions on em.PositionID equals p.ID 
                            select new { 
                                em.ID, 
                                em.Name, 
                                em.Address, 
                                em.CCCD, 
                                em.DateOfBirth,
                                PositionName = p.Name, 
                                em.Gender, 
                                em.Username, 
                                em.PhoneNumber };
            dgvEmployee.DataSource = employees.ToList();
        }

        private void dgvEmployee_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Kiểm tra xem người dùng có nhấp vào một hàng hợp lệ không
            if (e.RowIndex >= 0) // e.RowIndex < 0 có nghĩa là tiêu đề cột được nhấp vào
            {
                // Lấy thông tin từ hàng đã nhấp vào
                DataGridViewRow selectedRow = dgvEmployee.Rows[e.RowIndex];

                txtName.Text = selectedRow.Cells["NAME"].Value.ToString();
                txtDiaChi.Text = selectedRow.Cells["ADDRESS"].Value.ToString();
                txtCCCD.Text = selectedRow.Cells["CCCD"].Value.ToString();
                dtpNgaySinh.Value = Convert.ToDateTime(selectedRow.Cells["DATEOFBIRTH"].Value);
                cbbLoaiNhanVien.Text = selectedRow.Cells["PositionName"].Value.ToString();
                cbbGioiTinh.Text = selectedRow.Cells["GENDER"].Value.ToString();
                txtEmail.Text = selectedRow.Cells["Username"].Value.ToString();
                txtSDT.Text = selectedRow.Cells["PHONENUMBER"].Value.ToString();
            }
        }

        private void btnDatLaiMatKhau_Click(object sender, EventArgs e)
        {
            new frmDatLaiMatKhau().Show();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            // Kiểm tra xem các trường thông tin có hợp lệ không
            if (string.IsNullOrWhiteSpace(txtName.Text) ||
                string.IsNullOrWhiteSpace(txtDiaChi.Text) ||
                string.IsNullOrWhiteSpace(txtCCCD.Text) ||
                string.IsNullOrWhiteSpace(txtEmail.Text) ||
                string.IsNullOrWhiteSpace(txtSDT.Text) ||
                cbbLoaiNhanVien.SelectedIndex < 0 ||
                cbbGioiTinh.SelectedIndex < 0)
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Lấy ID của vị trí từ cơ sở dữ liệu
            var id_pos = db.Positions
                        .Where(p => p.Name == cbbLoaiNhanVien.Text)
                        .Select(p => p.ID)
                        .FirstOrDefault();

            // Tạo một đối tượng nhân viên mới
            var newEmployee = new Employee
            {
                Name = txtName.Text,
                Address = txtDiaChi.Text,
                CCCD = txtCCCD.Text,
                DateOfBirth = dtpNgaySinh.Value,
                PositionID = id_pos,
                Gender = cbbGioiTinh.Text,
                Username = txtEmail.Text,
                PhoneNumber = txtSDT.Text
            };

            try
            {
                // Thêm nhân viên vào cơ sở dữ liệu
                db.Employees.Add(newEmployee);
                db.SaveChanges(); // Lưu thay đổi vào cơ sở dữ liệu

                MessageBox.Show("Thêm nhân viên thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                frmQuanLyNhanVien_Load(sender,e);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Thêm không thành công: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {


            // Kiểm tra xem các trường thông tin có hợp lệ không
            if (string.IsNullOrWhiteSpace(txtName.Text) ||
                string.IsNullOrWhiteSpace(txtDiaChi.Text) ||
                string.IsNullOrWhiteSpace(txtCCCD.Text) ||
                string.IsNullOrWhiteSpace(txtEmail.Text) ||
                string.IsNullOrWhiteSpace(txtSDT.Text) ||
                cbbLoaiNhanVien.SelectedIndex < 0 ||
                cbbGioiTinh.SelectedIndex < 0)
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Lấy thông tin nhân viên đã chọn
            DataGridViewRow selectedRow = dgvEmployee.SelectedRows[0];
            int employeeId = Convert.ToInt32(selectedRow.Cells["ID"].Value); // Giả sử có cột EmployeeId
            // Lấy ID của vị trí từ cơ sở dữ liệu
            var id_pos = db.Positions
                        .Where(p => p.Name == cbbLoaiNhanVien.Text)
                        .Select(p => p.ID)
                        .FirstOrDefault();

            // Cập nhật thông tin nhân viên
            var updatedEmployee = new Employee
            {
                ID = employeeId,
                Name = txtName.Text,
                Address = txtDiaChi.Text,
                CCCD = txtCCCD.Text,
                DateOfBirth = dtpNgaySinh.Value,
                PositionID = id_pos,
                Gender = cbbGioiTinh.Text,
                Username = txtEmail.Text,
                PhoneNumber = txtSDT.Text
            };

            frmQuanLyNhanVien_Load(sender,e);

            // Thông báo thành công
            MessageBox.Show("Cập nhật nhân viên thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
