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
    public partial class frmThemDichVu : Form
    {
        DbModelContext db = new DbModelContext();

        public frmThemDichVu()
        {
            InitializeComponent();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void frmThemDichVu_Load(object sender, EventArgs e)
        {
        }

        private void btnThemDichVu_Click(object sender, EventArgs e)
        {
            // Kiểm tra xem tên dịch vụ và giá có hợp lệ không
            if (string.IsNullOrWhiteSpace(txtTenDichVu.Text) || !decimal.TryParse(txtGia.Text, out decimal price))
            {
                MessageBox.Show("Vui lòng nhập tên dịch vụ hợp lệ và giá dịch vụ hợp lệ.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Tạo đối tượng dịch vụ mới
            var newSv = new Service()
            {
                Name = txtTenDichVu.Text,
                Price = price
            };

            try
            {
                // Thêm dịch vụ mới vào cơ sở dữ liệu
                db.Services.Add(newSv);
                db.SaveChanges();

                MessageBox.Show("Dịch vụ đã được thêm thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Xóa nội dung trong các ô nhập liệu sau khi thêm thành công (tuỳ chọn)
                txtTenDichVu.Clear();
                txtGia.Clear();
            }
            catch (Exception ex)
            {
                // Xử lý lỗi nếu có
                MessageBox.Show($"Có lỗi xảy ra khi thêm dịch vụ: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            // Tìm ID dịch vụ dựa trên tên dịch vụ
            int? id_sv = db.Services
                .Where(s => s.Name == txtTenDichVu.Text)
                .Select(s => s.ID)
                .FirstOrDefault();

            if (id_sv.HasValue) // Kiểm tra xem id_sv có giá trị hay không
            {
                // Tìm đối tượng dịch vụ cần xóa
                var serviceToRemove = db.Services.Find(id_sv.Value);

                if (serviceToRemove != null) // Kiểm tra xem dịch vụ có tồn tại không
                {
                    db.Services.Remove(serviceToRemove); // Xóa dịch vụ
                    db.SaveChanges(); // Lưu thay đổi
                }
                else
                {
                    // Xử lý trường hợp không tìm thấy dịch vụ
                    Console.WriteLine("Dịch vụ không tồn tại.");
                }
            }
            else
            {
                // Xử lý trường hợp không tìm thấy ID dịch vụ
                Console.WriteLine("Không tìm thấy dịch vụ với tên đã cho.");
            }
        }
    }
}
