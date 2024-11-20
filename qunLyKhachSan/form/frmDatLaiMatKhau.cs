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

namespace qunLyKhachSan.form
{
    public partial class frmDatLaiMatKhau : Form
    {
        DbModelContext db = new DbModelContext();

        public frmDatLaiMatKhau()
        {
            InitializeComponent();
        }

        private void btnXacNhan_Click(object sender, EventArgs e)
        {
            // Kiểm tra xem các trường đầu vào có hợp lệ không
            if (string.IsNullOrWhiteSpace(txtMatKhauCu.Text) ||
                string.IsNullOrWhiteSpace(txtMatKhauMoi.Text) ||
                string.IsNullOrWhiteSpace(txtXacNhanMK.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin.");
                return;
            }

            var p = db.Employees
                       .Where(em => em.Username == User.UserName && em.Password == User.Password)
                       .FirstOrDefault();

            if (p != null)
            {
                // Kiểm tra mật khẩu mới và xác nhận
                if (txtMatKhauMoi.Text == txtXacNhanMK.Text)
                {
                    // Mã hóa mật khẩu mới trước khi lưu
                    p.Password = txtMatKhauMoi.Text;
                    db.SaveChanges();
                    MessageBox.Show("Mật khẩu đã được cập nhật thành công.");
                }
                else
                {
                    MessageBox.Show("Mật khẩu xác nhận không trùng khớp.");
                }
            }
            else
            {
                MessageBox.Show("Mật khẩu cũ không đúng.");
            }
        }
    }
}
