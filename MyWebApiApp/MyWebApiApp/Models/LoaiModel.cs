using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace MyWebApiApp.Models
{
    
    public class LoaiModel
    {
        [Required]
        [MaxLength(100)]
        public string TenLoai { get; set; }
    }
}
