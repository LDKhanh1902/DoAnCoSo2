using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace qunLyKhachSan.Model
{
    internal class Position_Permissions
    {
        public int ID { get; set; }
        public int PositionID { get; set; }
        public int PermissionID { get; set; }

        public virtual Position Position { get; set; }
        public virtual Permission Permission { get; set; }
    }
}
