using System;

namespace Business.Models
{
    public class Produto : Entity
    {        
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public decimal Preco { get; set; }
        public int Estoque { get; set; }
        public bool Disponivel { get; set; }
    }
}
