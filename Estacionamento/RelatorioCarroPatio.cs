using Estacionamento.Models;
using MetroFramework.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Estacionamento
{
    public partial class RelatorioCarroPatio : MetroForm
    {

        private EstacionamentoContext db;

        public RelatorioCarroPatio()
        {
            InitializeComponent();
            db = new EstacionamentoContext();
            dtInicio.Value = Convert.ToDateTime(DateTime.Now.ToShortDateString() + " 00:00");
            dtFim.Value = Convert.ToDateTime(DateTime.Now.AddDays(1).ToShortDateString() + " 23:59");
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if(dtInicio.Text != string.Empty)
            {
                var result = db.Fluxoes.Where(i => i.DataEntrada >= dtInicio.Value && i.DataEntrada <= dtFim.Value && i.DataSaida == null).ToList();
                gridRelatorio.DataSource = result;
            }
        }
        

        private void RelatorioCarroPatio_Load(object sender, EventArgs e)
        {
            var result = db.Fluxoes.Where(i => i.DataEntrada >= dtInicio.Value && i.DataEntrada <= dtFim.Value && i.DataSaida == null).ToList();
            gridRelatorio.DataSource = result;
        }

        private void btnAtualizar_Click(object sender, EventArgs e)
        {
            if (txtCodigo.Text != string.Empty && txtPlaca.Text != string.Empty &&
                dtEntrada.Text != string.Empty && dtFim.Text != string.Empty && fluxoID.Text != "label3")
            {
                int id = int.Parse(fluxoID.Text);
                var result = db.Fluxoes.Find(id);
                if (result != null)
                {
                    result.Codigo = int.Parse(txtCodigo.Text);
                    result.DataEntrada = dtEntrada.Value;
                    result.DataSaida = dtSaida.Value;
                    result.Placa = txtPlaca.Text;
                    db.Entry(result).State = EntityState.Modified;
                    db.SaveChanges();
                }
            }
            else
            {
                MessageBox.Show("Preencha todos os campos!");
            }
        }

        private void gridRelatorio_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            fluxoID.Text = string.Empty;
            txtCodigo.Text = string.Empty;
            txtPlaca.Text = string.Empty;

            DataGridViewRow row = new DataGridViewRow();
            row = gridRelatorio.CurrentRow;
            int intRow = row.Index;
            fluxoID.Text = gridRelatorio[0, row.Index].Value.ToString();
            int id = int.Parse(fluxoID.Text);
            var result = db.Fluxoes.Find(id);
            if (result != null)
            {
                txtCodigo.Text = result.Codigo.ToString();
                txtPlaca.Text = result.Placa;
                dtEntrada.Value = (DateTime)result.DataEntrada;
            }
        }
    }
}
