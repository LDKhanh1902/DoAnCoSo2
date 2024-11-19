using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace qunLyKhachSan.Model
{
    internal class Room
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public int TypeRoomID { get; set; }
        public string Status { get; set; }

        public virtual RoomType RoomType { get; set; }
        public virtual ICollection<Bill> Bills { get; set; }
    }
}
