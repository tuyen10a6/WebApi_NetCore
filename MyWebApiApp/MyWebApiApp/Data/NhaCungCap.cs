using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyWebApiApp.Data
{
    [Table ("NhaCungCap")]
    public class NhaCungCap
    {
        [Key]
        public Guid NCC_Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string NCC_Name { get; set;}
        public string? Adress_NCC { get; set; }
        public string? Sdt { get; set; }
    }
}
