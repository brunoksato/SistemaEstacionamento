using Estacionamento.Models;
using MetroFramework.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Estacionamento
{
    public partial class RelatorioFechamento : MetroForm
    {
        private EstacionamentoContext db;

        public RelatorioFechamento()
        {
            InitializeComponent();
            db = new EstacionamentoContext();
            dtInicio.Value = Convert.ToDateTime(DateTime.Now.ToShortDateString() + " 00:00");
            dtFim.Value = Convert.ToDateTime(DateTime.Now.AddDays(30).ToShortDateString() + " 23:59");
        }

        private void Relatorio2_Load(object sender, EventArgs e)
        {

        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (dtInicio.Text != string.Empty && dtFim.Text != string.Empty)
            {
                var result = db.Fluxoes.Where(i => i.DataEntrada >= dtInicio.Value && i.DataSaida <= dtFim.Value).ToList();
                double total = 0;
                foreach (var item in result)
                {
                    total += (double)item.Valor;
                }
                gridRelatorio.DataSource = result;
                lblValorTotal.Text = total.ToString("c2");
            }
        }
    }
}
