using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DesafioFundamentos.Models
{
    public class Carro : Veiculo
    {
        public Carro(string placa) : base(placa)
        {
        }

        public override decimal CalcularPreco(int horas)
        {
            return 10 + 2 * horas;
        }
    }
}
