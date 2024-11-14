using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace qunLyKhachSan.Model
{
    internal class Account
    {
        [Key]
        public string EMAIL {  get; set; }  
        public string PASSWORD { get; set; }
    }
}
