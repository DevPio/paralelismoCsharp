using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp2.Models
{
    public enum TipoMovimentacao
    {
        Saque,
        Deposito,
        Transferencia,
        RecargaCelular,
        PagamentoDeposito
    }
    public class Movimentacao
    {
        public decimal Valor { get; set; }
        public DateTime Data { get; set; }
        public TipoMovimentacao Tipo { get; set; }
    }
}
