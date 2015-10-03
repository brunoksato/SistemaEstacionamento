using Estacionamento.Models;
using MetroFramework.Forms;
using System;
using System.Data.Entity;
using System.Windows.Forms;
using Epson;
using System.Data;
using System.Linq;

namespace Estacionamento
{
    public partial class Ticket : MetroForm
    {
        private EstacionamentoContext db;
        private int iRetorno;

        public Ticket()
        {
            InitializeComponent();
            db = new EstacionamentoContext();
            dtSaida.Value = Convert.ToDateTime(DateTime.Now);
        }

        private void btnAtualizar_Click(object sender, EventArgs e)
        {
            if ((MessageBox.Show("Voce colocou data saida?", "Data Saida",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                    MessageBoxDefaultButton.Button1) == System.Windows.Forms.DialogResult.Yes))
            {
                if(txtTicket.Text != string.Empty)
                {
                    var id = int.Parse(txtTicket.Text);
                    var result = db.Fluxoes.Find(id);
                    if (result != null)
                    {
                        result.Codigo = int.Parse(txtCodigo.Text);
                        result.DataSaida = dtSaida.Value;
                        result.Modelo = txtModelo.Text;
                        result.Nome = txtDescricao.Text;
                        result.Placa = txtPlaca.Text;
                        result.Valor = (double)txtValorTotal.Value;
                        db.Entry(result).State = EntityState.Modified;
                        db.SaveChanges();

                        iRetorno = InterfaceEpsonNF.ConfiguraTaxaSerial(115200);
                        iRetorno = InterfaceEpsonNF.IniciaPorta("USB");
                        iRetorno = InterfaceEpsonNF.FormataTX("----------------------Estacionamento-----------------------\n", 1, 0, 0, 0, 0);
                        iRetorno = InterfaceEpsonNF.FormataTX("Empresa Teste\n", 1, 0, 0, 0, 0);
                        iRetorno = InterfaceEpsonNF.FormataTX("CNPJ: xxxxxxxxxxxxxx      Inscrição Estadual: yyyyyyyyyy\n", 1, 0, 0, 0, 0);
                        iRetorno = InterfaceEpsonNF.FormataTX("Rua: aaaaaaaaaaaa, Número: 999   Bairro: bbbbbbb\n", 1, 0, 0, 0, 0);
                        iRetorno = InterfaceEpsonNF.FormataTX("Cidade: zzzzzzzzzzzz nn\n", 1, 0, 0, 0, 0);
                        iRetorno = InterfaceEpsonNF.FormataTX("--------------------------------------------------------\n", 1, 0, 0, 0, 0);
                        iRetorno = InterfaceEpsonNF.FormataTX("TICKET: " + txtTicket.Text + "\n", 1, 0, 0, 1, 0);
                        iRetorno = InterfaceEpsonNF.FormataTX("--------------------------------------------------------\n", 1, 0, 0, 0, 0);
                        iRetorno = InterfaceEpsonNF.FormataTX("PLACA: " + txtPlaca.Text + "\n", 1, 0, 0, 1, 0);
                        iRetorno = InterfaceEpsonNF.FormataTX("ENTRADA: " + result.DataEntrada.ToString() + "\n", 1, 0, 0, 1, 0);
                        iRetorno = InterfaceEpsonNF.FormataTX("SAÍDA: " + dtSaida.Text + "\n", 1, 0, 0, 1, 0);
                        iRetorno = InterfaceEpsonNF.FormataTX("PERMANENCIA: " + dtSaida.Value.Subtract((DateTime)result.DataEntrada).ToString().Split('.')[0] + "\n", 1, 0, 0, 1, 0);
                        iRetorno = InterfaceEpsonNF.FormataTX("TIPO: " + txtTipoValor.Text + "\n", 1, 0, 0, 1, 0);
                        iRetorno = InterfaceEpsonNF.FormataTX("--------------------------------------------------------\n", 1, 0, 0, 0, 0);
                        iRetorno = InterfaceEpsonNF.FormataTX("--------------------------------------------------------\n", 1, 0, 0, 0, 0);
                        iRetorno = InterfaceEpsonNF.FormataTX("TOTAL: " + txtValorTotal.Value.ToString("c2") + "\n", 1, 0, 0, 1, 0);
                        iRetorno = InterfaceEpsonNF.FormataTX("--------------------------------------------------------\n", 1, 0, 0, 0, 0);
                        iRetorno = InterfaceEpsonNF.FormataTX("--------------------------------------------------------\n\n", 1, 0, 0, 0, 0);
                        iRetorno = InterfaceEpsonNF.FormataTX("---OBRIGADO E VOLTE SEMPRE---\n\n\n\n\n\n\n\n\n", 1, 0, 0, 1, 1);
                    }
                    else
                    {
                        MessageBox.Show("Ticket invalido!");
                    }
                }
                else
                {
                    MessageBox.Show("Não foi localizado o ticket!");
                }
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (txtTicket.Text != string.Empty)
            {
                var id = int.Parse(txtTicket.Text);
                var result = db.Fluxoes.Find(id);
                if (result != null)
                {
                    txtCodigo.Text = result.Codigo.ToString();
                    txtDescricao.Text = result.Nome;
                    txtModelo.Text = result.Modelo;
                    txtPlaca.Text = result.Placa;
                    txtTipoValor.Text = result.Type;
                    if(result.Type == "Por Hora")
                    {
                        double total = 0;
                        var data = DateTime.Now;
                        var time = data.Subtract((DateTime)result.DataEntrada);
                        int totalHoras = (int)time.TotalHours;
                        var valorHora = db.Horarios.Where(x => x.Type == "Por Hora").Select(x => x.Valor).FirstOrDefault();
                        var valorDemaisHora = db.Horarios.Where(x => x.Type == "Demais horas").Select(x => x.Valor).FirstOrDefault();
                        for (int i = 0; i < totalHoras; i++)
                        {
                            if(i == 0)
                            {
                                total += valorHora;
                            }
                            else
                            {
                                total += valorDemaisHora;
                            }
                        }
                        txtValorTotal.Value = (decimal)total;
                    }
                    else
                    {
                        txtValorTotal.Value = (decimal)result.Valor;
                    }
                    
                    dtEntrada.Value = (DateTime)result.DataEntrada;
                    if(result.DataSaida != null)
                    {
                        dtSaida.Value = (DateTime)result.DataSaida;
                    }
                }
                else
                {
                    MessageBox.Show("Ticket invalido!");
                }
            }
            else
            {
                MessageBox.Show("Preencha o ticket!");
            }
        }
    }
}
