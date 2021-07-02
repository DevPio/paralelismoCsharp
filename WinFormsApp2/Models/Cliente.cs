using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp2.Models
{
   public class Cliente
    {

        public string Nome { get; set; }
        public decimal Investimento { get; set; }
        public List<Movimentacao> Transactions  { get; set; }
    }
}
