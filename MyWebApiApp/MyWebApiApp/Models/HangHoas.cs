using MyWebApiApp.Data;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Transactions;

namespace MyWebApiApp.Models
{
    public class HangHoaVM
    {
        public Guid MaHangHoa { get; set; }
        public string TenHH { get; set; }

        public string MoTa { get; set; }
        public double DonGia { get; set; }
        public byte GiamGia { get; set; }
        // Thêm dấu hỏi có nghĩa có thể có hoặc có thể không
        public int? MaLoai { get; set; }
    }
    public class HangHoas:HangHoaVM
    {
        public Guid MaHangHoa { get; set; }
        public string TenHH { get; set; }

        public string MoTa { get; set; }
        public double DonGia { get; set; }
        public byte GiamGia { get; set; }
        // Thêm dấu hỏi có nghĩa có thể có hoặc có thể không
        public int? MaLoai { get; set; }
       
     

    }
    public class HangHoaModel
    {
      
        public Guid MaHH { get; set; }
      
        public string TenHH { get; set; }

        public string MoTa { get; set; }

       
        public double DonGia { get; set; }
        public byte GiamGia { get; set; }
        // Thêm dấu hỏi có nghĩa có thể có hoặc có thể không
        public int? MaLoai { get; set; }
      
        public Loai Loai { get; set; }
        public string? TenLoai { get; set; }
        //public ICollection<DonHangChiTiet> DonHangChiTiets { get; set; }
    }
}
