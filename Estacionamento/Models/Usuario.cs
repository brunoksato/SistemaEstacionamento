using System;
using System.Collections.Generic;

namespace Estacionamento.Models
{
    public partial class Usuario
    {
        public int ID { get; set; }
        public string Login { get; set; }
        public string Senha { get; set; }
        public bool? Admin { get; set; }
    }
}
