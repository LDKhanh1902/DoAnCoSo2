using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace qunLyKhachSan.Model
{
    internal class BillDetail
    {
        public int ID { get; set; }
        public int BillID { get; set; }
        public int ServiceID { get; set; }
        public int Quantity { get; set; }

        // Navigation properties
        public virtual Bill Bill { get; set; }
        public virtual Service Service { get; set; }
    }
}
