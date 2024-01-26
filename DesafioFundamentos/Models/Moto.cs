using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DesafioFundamentos.Models
{
    public class Moto : Veiculo
    {
        public Moto(string placa) : base(placa)
        {
        }

        public override decimal CalcularPreco(int horas)
        {
            return 5 + 2 * horas;
        }
    }
}