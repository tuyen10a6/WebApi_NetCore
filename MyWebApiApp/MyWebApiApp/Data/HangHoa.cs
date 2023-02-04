﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace MyWebApiApp.Data
{
    [Table("HangHoa")]
    public class HangHoa
    {
        [Key]
        public Guid MaHH { get; set; }
        [Required]
        [MaxLength(100)]
        public string TenHH { get; set; }

        public string MoTa { get; set; }

        [Range(0,double.MaxValue)]
        public double DonGia { get; set; }
        public byte GiamGia { get; set; }
        // Thêm dấu hỏi có nghĩa có thể có hoặc có thể không
        public int? MaLoai { get; set; }
        [ForeignKey("MaLoai")]
        public Loai Loai { get; set; }

        public ICollection<DonHangChiTiet> DonHangChiTiets { get; set; }
        public HangHoa()
        {
            DonHangChiTiets = new HashSet<DonHangChiTiet>();
        }

    }
}
