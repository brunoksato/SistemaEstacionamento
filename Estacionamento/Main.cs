﻿using Epson;
using Estacionamento.Models;
using MetroFramework;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace Estacionamento
{
    public partial class Main : Form
    {
        private EstacionamentoContext db;
        private int iRetorno;

        public Main()
        {
            InitializeComponent();
            db = new EstacionamentoContext();
            PopularTela();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MetroMessageBox.Show(this, "Do you like this metro message box?", "Metro Title", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Asterisk);
        }

        private void btnConfig_Click(object sender, EventArgs e)
        {
            new Configuracao().Show();
        }

        private void metroButton4_Click(object sender, EventArgs e)
        {
            new CadastroUsuario().Show();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Close();
        }

        private void metroButton5_Click(object sender, EventArgs e)
        {
            new CadastroModelo().Show();
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            new RelatorioSaida().Show();
        }

        private void metroButton2_Click(object sender, EventArgs e)
        {
            new RelatorioCarroPatio().Show();
        }

        private void metroButton3_Click(object sender, EventArgs e)
        {
            new RelatorioFechamento().Show();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {

            if (txtCodigo.Text != string.Empty && txtDescricao.Text != string.Empty && txtPlaca.Text != string.Empty &&
                cbModelo.Text != string.Empty && cbTipoValor.Text != string.Empty)
            {
                string dataEntrada = string.Empty;
                string dataSaida = string.Empty;

                string testDate = dtEntrada.Text.Split(':')[0];
                if (testDate == "00" || testDate == "01" || testDate == "02" || testDate == "03" || testDate == "04" || testDate == "05")
                {
                    string timeNow = DateTime.Now.ToShortTimeString().Split(':')[0];
                    if (timeNow != "00" && timeNow != "01" && timeNow != "02" && timeNow != "03" && timeNow != "04" && timeNow != "05")
                    {
                        dataEntrada = DateTime.Now.AddDays(1).ToShortDateString() + " " + dtEntrada.Value.ToShortTimeString();
                    }
                    else
                    {
                        dataEntrada = DateTime.Now.ToShortDateString() + " " + dtEntrada.Value.ToShortTimeString();
                    }
                }
                else
                {
                    dataEntrada = DateTime.Now.ToShortDateString() + " " + dtEntrada.Value.ToShortTimeString();
                }

                string testDate1 = dtSaida.Text.Split(':')[0];
                if (testDate1 == "00" || testDate1 == "01" || testDate1 == "02" || testDate1 == "03" || testDate1 == "04" || testDate1 == "05")
                {
                    string timeNow = DateTime.Now.ToShortTimeString().Split(':')[0];
                    if (timeNow != "00" && timeNow != "01" && timeNow != "02" && timeNow != "03" && timeNow != "04" && timeNow != "05")
                    {
                        dataSaida = DateTime.Now.AddDays(1).ToShortDateString() + " " + dtSaida.Value.ToShortTimeString();
                    }
                    else
                    {
                        dataSaida = DateTime.Now.ToShortDateString() + " " + dtSaida.Value.ToShortTimeString();
                    }
                }
                else
                {
                    dataSaida = DateTime.Now.ToShortDateString() + " " + dtSaida.Value.ToShortTimeString();
                }

                Fluxo modelo;

                if (checkSaida.Checked)
                {
                    modelo = new Fluxo()
                    {
                        Codigo = int.Parse(txtCodigo.Text),
                        Nome = txtDescricao.Text,
                        DataEntrada = Convert.ToDateTime(dataEntrada),
                        DataSaida = Convert.ToDateTime(dataSaida),
                        Placa = txtPlaca.Text,
                        Modelo = cbModelo.SelectedValue.ToString(),
                        Type = cbTipoValor.SelectedValue.ToString(),
                        Valor = (double)txtValorTotal.Value
                    };
                }
                else
                {
                    modelo = new Fluxo()
                    {
                        Codigo = int.Parse(txtCodigo.Text),
                        Nome = txtDescricao.Text,
                        DataEntrada = Convert.ToDateTime(dataEntrada),
                        DataSaida = null,
                        Placa = txtPlaca.Text,
                        Modelo = cbModelo.SelectedValue.ToString(),
                        Type = cbTipoValor.SelectedValue.ToString(),
                        Valor = (double)txtValorTotal.Value
                    };
                }

                db.Fluxoes.Add(modelo);
                db.SaveChanges();

                iRetorno = InterfaceEpsonNF.ConfiguraTaxaSerial(115200);
                iRetorno = InterfaceEpsonNF.IniciaPorta("USB");
                iRetorno = InterfaceEpsonNF.FormataTX("----------------------Estacionamento-----------------------\n", 1, 0, 0, 0, 0);
                iRetorno = InterfaceEpsonNF.FormataTX("Empresa Teste\n", 1, 0, 0, 0, 0);
                iRetorno = InterfaceEpsonNF.FormataTX("CNPJ: xxxxxxxxxxxxxx      Inscrição Estadual: yyyyyyyyyy\n", 1, 0, 0, 0, 0);
                iRetorno = InterfaceEpsonNF.FormataTX("Rua: aaaaaaaaaaaa, Número: 999   Bairro: bbbbbbb\n", 1, 0, 0, 0, 0);
                iRetorno = InterfaceEpsonNF.FormataTX("Cidade: zzzzzzzzzzzz nn\n", 1, 0, 0, 0, 0);
                iRetorno = InterfaceEpsonNF.FormataTX("--------------------------------------------------------\n", 1, 0, 0, 0, 0);
                iRetorno = InterfaceEpsonNF.FormataTX("TICKET: " + modelo.ID.ToString() + "\n", 1, 0, 0, 1, 0);
                iRetorno = InterfaceEpsonNF.FormataTX("--------------------------------------------------------\n", 1, 0, 0, 0, 0);
                iRetorno = InterfaceEpsonNF.FormataTX("PLACA: " + txtPlaca.Text + "\n", 1, 0, 0, 1, 0);
                iRetorno = InterfaceEpsonNF.FormataTX("ENTRADA: " + dtEntrada.Value.ToString() + "\n", 1, 0, 0, 1, 0);
                //iRetorno = InterfaceEpsonNF.FormataTX("SAÍDA: " + dtSaida.Text + "\n", 1, 0, 0, 1, 0);
                //iRetorno = InterfaceEpsonNF.FormataTX("PERMANENCIA: " + dtSaida.Value.Subtract((DateTime)result.DataEntrada) + "\n", 1, 0, 0, 1, 0);
                iRetorno = InterfaceEpsonNF.FormataTX("TIPO: " + cbTipoValor.SelectedValue.ToString() + "\n", 1, 0, 0, 1, 0);
                iRetorno = InterfaceEpsonNF.FormataTX("--------------------------------------------------------\n", 1, 0, 0, 0, 0);
                iRetorno = InterfaceEpsonNF.FormataTX("--------------------------------------------------------\n", 1, 0, 0, 0, 0);
                if(cbTipoValor.SelectedValue.ToString() != "Por Hora")
                    iRetorno = InterfaceEpsonNF.FormataTX("TOTAL: " + txtValorTotal.Value.ToString("c2") + "\n", 1, 0, 0, 1, 0);
                iRetorno = InterfaceEpsonNF.FormataTX("--------------------------------------------------------\n", 1, 0, 0, 0, 0);
                iRetorno = InterfaceEpsonNF.FormataTX("--------------------------------------------------------\n\n", 1, 0, 0, 0, 0);
                iRetorno = InterfaceEpsonNF.FormataTX("---OBRIGADO E VOLTE SEMPRE---\n\n\n\n\n\n\n\n\n", 1, 0, 0, 1, 1);

                LimparCampos();
            }
            else
            {
                MessageBox.Show("Preencha todos os campos!");
            }
        }

        private void PopularTela()
        {
            var query = from c in db.ModelosCarroes.ToList()
                        select new DataBindingModelo { Nome = c.Nome };
            var modelos = query.ToList();
            cbModelo.DataSource = modelos;
            cbModelo.DisplayMember = "Nome";
            cbModelo.ValueMember = "Nome";

            var query1 = from c in db.Horarios.Where(x => x.Type != "Demais horas").ToList()
                         select new DataBindingTipoValor { Type = c.Type };
            var horarios = query1.ToList();
            cbTipoValor.DataSource = horarios;
            cbTipoValor.DisplayMember = "Type";
            cbTipoValor.ValueMember = "Type";

        }

        private class DataBindingModelo
        {
            public string Nome { get; set; }
        }

        private class DataBindingTipoValor
        {
            public string Type { get; set; }
        }

        private void LimparCampos()
        {
            txtCodigo.Text = string.Empty;
            txtDescricao.Text = string.Empty;
            txtPlaca.Text = string.Empty;
            txtValorTotal.Value = 0;
        }

        private void txtPlaca_KeyDown(object sender, KeyEventArgs e)
        {
            var buscarPlaca = db.Fluxoes.Where(x => x.Placa.ToLower() == txtPlaca.Text.ToLower()).FirstOrDefault();
            if(buscarPlaca != null)
            {

            }
        }

        private void cbTipoValor_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbTipoValor.SelectedValue.ToString() == "Estacionamento.Main+DataBindingTipoValor")
            {
                var value = ((DataBindingTipoValor)cbTipoValor.SelectedValue).Type;
                if (value == "Por Hora")
                {
                    txtValorTotal.Value = 0;
                    return;
                }

                var calculeValor = db.Horarios.Where(x => x.Type == value).FirstOrDefault();
                if (calculeValor != null)
                {
                    txtValorTotal.Value = (decimal)calculeValor.Valor;
                }
            }
            else
            {
                if (cbTipoValor.SelectedValue.ToString() == "Por Hora")
                {
                    txtValorTotal.Value = 0;
                    return;
                }
                var calculeValor = db.Horarios.Where(x => x.Type == cbTipoValor.SelectedValue.ToString()).FirstOrDefault();
                if (calculeValor != null)
                {
                    txtValorTotal.Value = (decimal)calculeValor.Valor;
                }
            }
            
            
        }

        private void btnSalvarPrint_Click(object sender, EventArgs e)
        {

        }

        private void btnTicket_Click(object sender, EventArgs e)
        {
            new Ticket().Show();
        }
    }
}
