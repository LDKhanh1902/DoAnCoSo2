using qunLyKhachSan.Model;
using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace qunLyKhachSan
{
    public partial class frmThongTinNhanVien : Form
    {
        private OpenFileDialog openFileDialog;
        private string selectedImagePath;
        DbModelContext db = new DbModelContext();

        public frmThongTinNhanVien()
        {
            InitializeComponent();
            openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp;*.gif";
            openFileDialog.Title = "Chọn ảnh";
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void frmThongTinNhanVien_Load(object sender, EventArgs e)
        {
            var info = (from em in db.Employees
                                       join p in db.Positions on em.POSITIONID equals p.ID
                                       where em.EMAIL == User.UserName
                                       select new
                                       {
                                           em.ID,
                                           em.NAME,
                                           em.ADDRESS,
                                           em.CCCD,
                                           em.DATEOFBIRTH,
                                           PositionName = p.NAME,
                                           em.DATEOFJOINING,
                                           em.URLIMAGE,
                                           em.GENDER,
                                           em.EMAIL,
                                           em.PHONENUMBER
                                       }).FirstOrDefault();

            if (info != null)
            {
                txtSDT.Text = info.PHONENUMBER;
                txtCCCD.Text = info.CCCD;
                dtpNgaySinh.Value = info.DATEOFBIRTH;
                dtpNgayVaoLam.Value = info.DATEOFJOINING;
                txttenDangNhap.Text = info.EMAIL;
                txtTenHienthi.Text = info.NAME;
                labTenHienThi.Text = info.NAME;
                txtLoaiTaiKhoan.Text = info.PositionName;
                txttenDangNhap.Text += info.EMAIL;
                cbbGioiTinh.Text = info.GENDER;
                txtDiaChi.Text = info.ADDRESS;

                // Hiển thị ảnh hiện tại của nhân sb
                if (!string.IsNullOrEmpty(info.URLIMAGE) && File.Exists(info.URLIMAGE))
                {
                    ptbAnhNhanVien.Image = Image.FromFile(info.URLIMAGE);
                }
            }
        }

        private void btnLuuThayDoi_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(selectedImagePath))
            {
                string destinationFolderPath = @"D:\DoAn2\qunLyKhachSan\qunLyKhachSan\anh_nv";
                string fileName = Path.GetFileName(selectedImagePath);
                string destinationFilePath = Path.Combine(destinationFolderPath, fileName);

                try
                {
                    File.Copy(selectedImagePath, destinationFilePath, true);
                    ptbAnhNhanVien.Image = Image.FromFile(destinationFilePath);

                    int employeeId = db.Employees.Where(em => em.EMAIL == User.UserName).Select(em => em.ID).FirstOrDefault();
                    var employee = db.Employees.FirstOrDefault(em => em.ID == employeeId);
                    if (employee != null)
                    {
                        employee.URLIMAGE = destinationFilePath;
                        db.SaveChanges();
                        MessageBox.Show("Ảnh đã được lưu và thông tin nhân viên đã được cập nhật thành công!");
                    }
                    else
                    {
                        MessageBox.Show("Không tìm thấy nhân viên với ID này.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Đã xảy ra lỗi khi lưu ảnh: " + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn ảnh trước khi lưu.");
            }
        }

        private void ptbAnhNhanVien_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                selectedImagePath = openFileDialog.FileName;
                ptbAnhNhanVien.Image = Image.FromFile(selectedImagePath);
            }
        }
    }
}
