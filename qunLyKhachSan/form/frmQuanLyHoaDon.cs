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

namespace qunLyKhachSan
{
    public partial class frmQuanLyHoaDon : Form
    {
        DbModelContext db = new DbModelContext();

        public frmQuanLyHoaDon()
        {
            InitializeComponent();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void frmQuanLyHoaDon_Load(object sender, EventArgs e)
        {
            dgvQLHD.DataSource = db.Bills.ToList();
        }

        private void btnChiTietHoaDon_Click(object sender, EventArgs e)
        {

        }
    }
}
