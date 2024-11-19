using qunLyKhachSan.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace qunLyKhachSan
{
    public partial class frmDangNhap : Form
    {
        DbModelContext db = new DbModelContext();
        public frmDangNhap()
        {
            InitializeComponent();
        }

        private void btnAnHienMk_Click(object sender, EventArgs e)
        {
            if (txtMatKhau.PasswordChar.ToString() == "*")
            {
                txtMatKhau.PasswordChar = '\0';
                btnAnHienMk.Image = qunLyKhachSan.Properties.Resources.anMK;
            }
            else
            {
                txtMatKhau.PasswordChar = '*';
                btnAnHienMk.Image = qunLyKhachSan.Properties.Resources.hienMK;
            }
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            //// Hash the password entered by the user
            //string hashedPassword = HashPassword(txtMatKhau.Text);

            // Check if the user exists with the given email and hashed password
            var login = db.Employees.FirstOrDefault(a => a.PhoneNumber == txtTenDangNhap.Text && a.Password == txtMatKhau.Text);

            if (login != null) // Kiểm tra xem có bản ghi nào được tìm thấy không
            {
                // Ẩn form đăng nhập và hiển thị form chính
                this.Hide(); // Ẩn form đăng nhập hiện tại
                new mainForm().Show(); // Hiển thị form chính

                // Lưu thông tin người dùng
                User.UserName = login.Email; // Lưu tên đăng nhập
                User.Password = login.Password; // Lưu mật khẩu (nên cân nhắc không lưu mật khẩu)
            }
            else
            {
                MessageBox.Show("Tên đăng nhập hoặc mật khẩu không đúng."); // Thông báo lỗi nếu không tìm thấy tài khoản
            }
        }

        //// Example of a password hashing method
        //public static string HashPassword(string password)
        //{
        //    using (var sha256 = SHA256.Create())
        //    {
        //        var bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
        //        return Convert.ToBase64String(bytes);
        //    }
        //}

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void frmDangNhap_Load(object sender, EventArgs e)
        {

        }
    }
}
