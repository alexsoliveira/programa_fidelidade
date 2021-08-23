using System;
using System.ComponentModel.DataAnnotations;

namespace WebApi.DTOs
{
    public class ProdutoDTO
    {
        [Key]
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public decimal Preco { get; set; }
        public int Estoque { get; set; }
        public bool Disponivel { get; set; }
    }
}
