using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace qunLyKhachSan.Model
{
    internal class Permission
    {
        public int ID { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Position_Permissions> PositionPermissions { get; set; }
    }
}
