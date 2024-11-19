using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace qunLyKhachSan.Model
{
    internal class RoomType
    {
        public int ID { get; set; }
        [Column("TYPE_NAME")]
        public string TypeName { get; set; }
        [Column("MAX_OCCUPANCY")]
        public int MaxOccupancy { get; set; }

        public virtual ICollection<Room> Rooms { get; set; }
    }
}
