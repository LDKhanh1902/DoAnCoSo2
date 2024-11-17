using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace qunLyKhachSan.Model
{
    internal class RoomType
    {
        public int ID { get; set; }
        public string TypeName { get; set; }

        // Navigation property
        public virtual ICollection<Room> Rooms { get; set; }
    }
}
