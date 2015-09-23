using System;
using System.Collections.Generic;

namespace Estacionamento.Models
{
    public partial class Horario
    {
        public int ID { get; set; }
        public string Dia { get; set; }
        public System.TimeSpan DataInicio { get; set; }
        public System.TimeSpan DataFim { get; set; }
        public double Valor { get; set; }
        public string Type { get; set; }
    }
}
