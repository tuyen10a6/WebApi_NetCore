using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyWebApiApp.Data
{
    [Table ("KhachHang")]
    public class KhachHang
    {
        [Key]
        public int MaKH { get; set; }
        [Required]
        [MaxLength(100)]
        public string TenKH { get; set; }
        [Required]
        [MaxLength(10)]
        public string Sdt { get; set; }
        [Required]
        [MaxLength(200)]
        public string DiaChi { get; set; }
        public string? Email { get; set; }
    }
}
