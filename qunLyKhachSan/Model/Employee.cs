using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace qunLyKhachSan.Model
{
    internal class Employee
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string CCCD { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Gender { get; set; }
        public string Username { get; set; }
        public string PhoneNumber { get; set; }
        public int PositionID { get; set; }
        public DateTime DateOfJoining { get; set; }
        public string Password { get; set; }
        public string UrlImage { get; set; }

        public virtual Position Position { get; set; }
        public virtual ICollection<Bill> Bills { get; set; }
    }
}
