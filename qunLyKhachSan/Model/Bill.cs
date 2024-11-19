using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace qunLyKhachSan.Model
{
    internal class Bill
    {
        public int ID { get; set; }
        public DateTime CheckIn { get; set; }
        public DateTime CheckOut { get; set; }
        public int RoomID { get; set; }
        public int EmployeeID { get; set; }
        public int CustomerID { get; set; }
        public string Status { get; set; }

        public virtual Room Room { get; set; }
        public virtual Employee Employee { get; set; }
        public virtual Customer Customer { get; set; }
        public virtual ICollection<BillDetail> BillDetails { get; set; }
    }
}
