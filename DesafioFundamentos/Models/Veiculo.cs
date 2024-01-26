using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DesafioFundamentos.Models
{
    public abstract class Veiculo
    {
        public string Placa { get; set; }

        public Veiculo(string placa)
        {
            Placa = placa;
        }

        public abstract decimal CalcularPreco(int horas);
    }
}