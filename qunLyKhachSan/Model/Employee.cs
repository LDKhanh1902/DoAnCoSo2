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
        public int ID { get; set; } // Khóa chính
        public string NAME { get; set; } // Tên
        public string ADDRESS { get; set; } // Địa chỉ
        public string CCCD { get; set; } // Số CCCD
        public DateTime DATEOFBIRTH { get; set; } // Ngày sinh
        public string GENDER { get; set; } // Giới tính
        public string EMAIL { get; set; } // Địa chỉ email
        public string PHONENUMBER { get; set; } // Số điện thoại
        public int POSITIONID { get; set; } // Khóa ngoại liên kết với bảng Positions
        public DateTime DATEOFJOINING { get; set; } = DateTime.Now;
        public string URLIMAGE { get; set; }    

        public virtual Position Position { get; set; }
    }
}
