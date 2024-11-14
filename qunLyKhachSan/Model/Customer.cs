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
        public int ID { get; set; } // ID
        public string NAME { get; set; } // Tên khách hàng
        public string ADDRESS { get; set; } // Địa chỉ
        public string CCCD { get; set; } // Số căn cước công dân
        public DateTime DATEOFBIRTH { get; set; } // Ngày sinh
        public int COUNTRYID { get; set; }
        public int CUSTOMERTYPEID { get; set; }
        public string GENDER { get; set; } // Giới tính
        public string EMAIL { get; set; } // Địa chỉ email
        public string PHONENUMBER { get; set; } // Số điện thoại

        public CustomerType CustomerType { get; set; }
        public Country Country { get; set; }
    }
}
