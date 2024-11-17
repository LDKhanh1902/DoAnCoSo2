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

        }
    }
}
