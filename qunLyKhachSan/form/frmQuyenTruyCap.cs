using qunLyKhachSan.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace qunLyKhachSan
{
    public partial class frmQuyenTruyCap : Form
    {
        DbModelContext db = new DbModelContext();

        public frmQuyenTruyCap()
        {
            InitializeComponent();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnXoaHet_Click(object sender, EventArgs e)
        {
            if (lsbPermissionCurrent.Items.Count > 0) // Kiểm tra xem có mục nào không
            {
                var id_pos = db.Positions
                        .Where(p => p.NAME == cbbLoaiNhanVien.Text)
                        .Select(p => p.ID)
                        .FirstOrDefault();

                if (id_pos == 0)
                {
                    MessageBox.Show("Position not found.");
                    return;
                }

                // Danh sách để lưu các Permission ID
                var permissionIds = new List<int>();

                foreach (var item in lsbPermissionCurrent.Items.Cast<object>().ToList())
                {
                    // Lấy ID của Permission tương ứng với mục đã chọn
                    var id_per = db.Permissions
                            .Where(p => p.NAME == item.ToString())
                            .Select(p => p.ID)
                            .FirstOrDefault();

                    if (id_per == 0)
                    {
                        MessageBox.Show($"Permission '{item}' not found.");
                        continue; // Bỏ qua mục này và tiếp tục với mục tiếp theo
                    }

                    // Tìm đối tượng Position_Permissions để xóa
                    var positionPermission = db.Position_Permissions
                            .FirstOrDefault(pp => pp.PERMISSION_ID == id_per && pp.POSITION_ID == id_pos);

                    if (positionPermission != null)
                    {
                        db.Position_Permissions.Remove(positionPermission);
                        permissionIds.Add(id_per); // Lưu ID để thêm vào lsbPermission
                    }
                }

                // Lưu thay đổi một lần
                db.SaveChanges();

                // Di chuyển các mục từ lsbPermissionCurrent sang lsbPermission
                foreach (var item in lsbPermissionCurrent.Items.Cast<object>().ToList())
                {
                    lsbPermission.Items.Add((string)item);
                }

                // Xóa tất cả các mục khỏi lsbPermissionCurrent
                lsbPermissionCurrent.Items.Clear();
            }
            else
            {
                MessageBox.Show("No permissions to remove.");
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (lsbPermission.SelectedIndex != -1)
            {
                
                var id_pos = db.Positions
                        .Where(p => p.NAME == cbbLoaiNhanVien.Text)
                        .Select(p => p.ID)
                        .FirstOrDefault();
                var id_per = db.Permissions
                        .Where(p => p.NAME == lsbPermission.SelectedItem.ToString())
                        .Select(p => p.ID)
                        .FirstOrDefault();

                if (id_pos == 0 || id_per == 0)
                {
                    MessageBox.Show("Position or Permission not found.");
                    return;
                }
                var item = new Position_Permissions()
                {
                    POSITION_ID = id_pos,
                    PERMISSION_ID = id_per
                };

                db.Position_Permissions.Add(item);
                db.SaveChanges();

                // Proceed to remove the item
                var selectedItem = lsbPermission.SelectedItem;
                lsbPermissionCurrent.Items.Add(selectedItem);
                lsbPermission.Items.Remove(selectedItem);
                
                
            }
            else
            {
                // Handle the case where no item is selected
                MessageBox.Show("Please select an item to remove.");
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (lsbPermissionCurrent.SelectedIndex != -1)
            {
                // Lấy mục đã chọn
                var selectedItem = lsbPermissionCurrent.SelectedItem;

                // Lấy ID của Permission tương ứng với mục đã chọn
                var id_per = db.Permissions
                        .Where(p => p.NAME == selectedItem.ToString())
                        .Select(p => p.ID)
                        .FirstOrDefault();

                var id_pos = db.Positions
                        .Where(p => p.NAME == cbbLoaiNhanVien.Text)
                        .Select(p => p.ID)
                        .FirstOrDefault();

                // Kiểm tra xem ID có hợp lệ không
                if (id_per == 0 || id_pos == 0)
                {
                    MessageBox.Show("Permission not found.");
                    return;
                }

                // Tìm đối tượng Position_Permissions để xóa
                var positionPermission = db.Position_Permissions
                        .FirstOrDefault(pp => pp.PERMISSION_ID == id_per && pp.POSITION_ID == id_pos); // id_pos cần được xác định trước

                db.Position_Permissions.Remove(positionPermission);
                db.SaveChanges();

                // Xóa mục khỏi lsbPermissionCurrent
                lsbPermissionCurrent.Items.Remove(selectedItem);

                lsbPermission.Items.Add(selectedItem);
                lsbPermissionCurrent.Items.Remove(selectedItem);
            }
            else
            {
                // Handle the case where no item is selected
                MessageBox.Show("Please select an item to remove.");
            }
        }

        private void btnThemHet_Click(object sender, EventArgs e)
        {
            if(lsbPermission != null)
            {
                var id_pos = db.Positions
                        .Where(p => p.NAME == cbbLoaiNhanVien.Text)
                        .Select(p => p.ID)
                        .FirstOrDefault();

                foreach (var item in lsbPermission.Items.Cast<object>().ToList())
                {
                    // Lấy ID của Permission tương ứng với mục đã chọn
                    var id_per = db.Permissions
                            .Where(p => p.NAME == item.ToString())
                            .Select(p => p.ID)
                            .FirstOrDefault();

                    if (id_pos == 0 || id_per == 0)
                    {
                        MessageBox.Show("Position or Permission not found.");
                        return;
                    }
                    var new_pp = new Position_Permissions()
                    {
                        POSITION_ID = id_pos,
                        PERMISSION_ID = id_per
                    };

                    db.Position_Permissions.Add(new_pp);
                    db.SaveChanges();
                }

                foreach (var item in lsbPermission.Items.Cast<object>().ToList())
                {
                    lsbPermissionCurrent.Items.Add((string)item);
                }

                lsbPermission.Items.Clear();
            }
        }

        private void Data_Load(int? id)
        {
            var lstPermission = db.Permissions.ToList();
            var lstPermissionCurrent = db.Position_Permissions.Where(p => p.POSITION_ID == id).ToList();

            var currentPermissionIds = lstPermissionCurrent.Select(p => p.PERMISSION_ID).ToHashSet();

            foreach (var permission in lstPermission)
            {
                if (currentPermissionIds.Contains(permission.ID))
                {
                    lsbPermissionCurrent.Items.Add(permission.NAME);
                }
                else
                {
                    lsbPermission.Items.Add(permission.NAME);
                }
            }
        }

        private void frmQuyenTruyCap_Load(object sender, EventArgs e)
        {
            var lstPosition = db.Positions.ToList();
            cbbLoaiNhanVien.DataSource = lstPosition;
            cbbLoaiNhanVien.DisplayMember = "NAME";
            cbbLoaiNhanVien.ValueMember = "NAME";
        }

        private void cbbLoaiNhanVien_SelectedIndexChanged(object sender, EventArgs e)
        {
            var id = db.Positions
            .Where(p => p.NAME == cbbLoaiNhanVien.Text)
            .Select(p => p.ID)
            .FirstOrDefault();
            try
            {
                lsbPermission.Items.Clear();
                lsbPermissionCurrent.Items.Clear();
                Data_Load(id);
            }
            catch { 
            
            }         
        }
    }
}