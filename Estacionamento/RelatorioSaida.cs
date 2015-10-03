using Epson;
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
    public partial class RelatorioSaida : MetroForm
    {
        private EstacionamentoContext db;
        private int iRetorno;

        public RelatorioSaida()
        {
            InitializeComponent();
            db = new EstacionamentoContext();
            dtInicio.Value = Convert.ToDateTime(DateTime.Now.ToShortDateString() + " 00:00");
            dtFim.Value = Convert.ToDateTime(DateTime.Now.AddDays(1).ToShortDateString() + " 23:59");
        }

        private void Relatorio1_Load(object sender, EventArgs e)
        {

        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (dtInicio.Text != string.Empty && dtFim.Text != string.Empty)
            {
                var result = db.Fluxoes.Where(i => i.DataEntrada >= dtInicio.Value && i.DataSaida <= dtFim.Value).ToList();
                gridRelatorio.DataSource = result;
            }
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            var result = db.Fluxoes.Where(i => i.DataEntrada >= dtInicio.Value && i.DataSaida <= dtFim.Value).ToList();
            double soma = 0;
            iRetorno = InterfaceEpsonNF.ConfiguraTaxaSerial(115200);
            iRetorno = InterfaceEpsonNF.IniciaPorta("USB");
            iRetorno = InterfaceEpsonNF.FormataTX("Data Inicio: " + dtInicio.Value + "\n", 1, 0, 0, 0, 0);
            iRetorno = InterfaceEpsonNF.FormataTX("Data Final: " + dtFim.Value + "\n", 1, 0, 0, 0, 0);
            iRetorno = InterfaceEpsonNF.FormataTX("--------------------------------------------------------\n", 1, 0, 0, 0, 0);
            foreach (var item in result)
            {
                var val = (double)item.Valor;
                iRetorno = InterfaceEpsonNF.FormataTX("Ticket: " + item.ID + " - Valor: " + val.ToString("c2") + "\n", 1, 0, 0, 0, 0);
                soma += (double)item.Valor;
            }
            iRetorno = InterfaceEpsonNF.FormataTX("--------------------------------------------------------\n", 1, 0, 0, 0, 0);
            iRetorno = InterfaceEpsonNF.FormataTX("Valor Total do dia: "+ soma.ToString("c2") + "\n\n\n\n\n\n\n\n\n\n\n\n", 1, 0, 0, 1, 0);

        }
    }
}
