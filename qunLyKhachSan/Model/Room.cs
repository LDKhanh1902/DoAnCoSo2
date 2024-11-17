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
        [Column("TYPEROOMID")]
        public int TypeRoomID { get; set; }
        public string Status { get; set; } = "Trống"; // Giá trị mặc định

        // Navigation property
        public virtual RoomType RoomType { get; set; }
        public virtual ICollection<Bill> Bills { get; set; }
    }
}
