using System;
using System.Collections.Generic;

namespace Estacionamento.Models
{
    public partial class Fluxo
    {
        public int ID { get; set; }
        public int Codigo { get; set; }
        public string Placa { get; set; }
        public string Modelo { get; set; }
        public string Nome { get; set; }
        public Nullable<System.DateTime> DataEntrada { get; set; }
        public Nullable<System.DateTime> DataSaida { get; set; }
        public string Type { get; set; }
        public Nullable<double> Valor { get; set; }
    }
}
