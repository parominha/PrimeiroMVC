using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PrimeiroMVC.EF
{
    public class Paloma
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public DateTime DataNascimento { get; set; }
        public bool Ativo { get; set; }
        public string Sexo { get; set; }
        public DateTime DataCadastro { get; set; }
    }
}
