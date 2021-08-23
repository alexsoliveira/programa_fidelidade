using System;
using System.ComponentModel.DataAnnotations;

namespace WebApi.DTOs
{
    public class ContaDTO
    {
        [Key]
        public Guid Id { get; set; }
        public string Email { get; set; }
        public decimal Saldo { get; set; }
    }
}
