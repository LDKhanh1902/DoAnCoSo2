using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace qunLyKhachSan.Model
{
    internal class Customer
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string CCCD { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int CountryID { get; set; }
        public int CustomerTypeID { get; set; }
        public string Gender { get; set; }
        public string PhoneNumber { get; set; }

        public virtual Country Country { get; set; }
        public virtual CustomerType CustomerType { get; set; }
        public virtual ICollection<Bill> Bills { get; set; }
    }
}
