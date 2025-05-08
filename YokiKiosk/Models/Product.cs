using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YokiKiosk.Models
{
    public class Product
    {
        public int ID { get; set; }
        public string Title { get; set; } = string.Empty; //Title 속성의 초기값을 빈 문자열로 설정
        public decimal Price { get; set; }
        public Image? Image { get; set; }
    }

}
