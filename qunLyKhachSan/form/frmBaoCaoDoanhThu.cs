using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace qunLyKhachSan
{
    public partial class frmBaoCaoDoanhThu : Form
    {
        public frmBaoCaoDoanhThu()
        {
            InitializeComponent();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void frmBaoCaoDoanhThu_Load(object sender, EventArgs e)
        {
            // Xóa tất cả các series và biểu đồ hiện tại
            chart1.Series.Clear();
            chart1.Legends.Clear();

            // Tạo một series mới cho biểu đồ cột
            Series columnSeries = new Series("Column Chart");
            columnSeries.ChartType = SeriesChartType.Pie; // Đặt loại biểu đồ là cột

            // Thêm dữ liệu vào series
            columnSeries.Points.AddXY("Category 1", 30);
            columnSeries.Points.AddXY("Category 2", 25);
            columnSeries.Points.AddXY("Category 3", 20);
            columnSeries.Points.AddXY("Category 4", 15);
            columnSeries.Points.AddXY("Category 5", 10);

            // Thêm series vào biểu đồ
            chart1.Series.Add(columnSeries);

            // Tùy chỉnh biểu đồ
            chart1.Titles.Add("Biểu Đồ Cột");
            chart1.Legends.Add(new Legend("Legend"));
            chart1.Legends[0].Docking = Docking.Top; // Đặt vị trí của legend

            // Tùy chỉnh trục X để hiển thị từ trái sang phải
            chart1.ChartAreas[0].AxisX.IsReversed = false;
        }
    }
}
