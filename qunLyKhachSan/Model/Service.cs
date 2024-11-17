using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace qunLyKhachSan.Model
{
    internal class Service
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }

        // Navigation property
        public virtual ICollection<BillDetail> BillDetails { get; set; }
    }
}
