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
    public partial class Configuracao : MetroForm
    {
        private EstacionamentoContext db;

        public Configuracao()
        {
            InitializeComponent();
            db = new EstacionamentoContext();
        }
        
        private void btnSalvar_Click(object sender, EventArgs e)
        {
            //por hora
            var buscarHora = db.Horarios.Where(x => x.Type == "Por Hora").SingleOrDefault();
            if (buscarHora != null)
            {
                buscarHora.Dia = "Por Hora";
                buscarHora.DataInicio = DateTime.Now.TimeOfDay;
                buscarHora.DataFim = DateTime.Now.TimeOfDay;
                buscarHora.Valor = (double)valorPrimeiraHora.Value;
                buscarHora.Type = "Por Hora";
                db.Entry(buscarHora).State = EntityState.Modified;
                db.SaveChanges();
            }
            else
            {
                var model = new Horario();
                model.Dia = "Por Hora";
                model.DataInicio = DateTime.Now.TimeOfDay;
                model.DataFim = DateTime.Now.TimeOfDay;
                model.Valor = (double)valorPrimeiraHora.Value;
                model.Type = "Por Hora";
                db.Horarios.Add(model);
                db.SaveChanges();
            }

            //Demais horas
            var buscarDemaisHoras = db.Horarios.Where(x => x.Type == "Demais horas").SingleOrDefault();
            if (buscarHora != null)
            {
                buscarHora.Dia = "Demais horas";
                buscarHora.DataInicio = DateTime.Now.TimeOfDay;
                buscarHora.DataFim = DateTime.Now.TimeOfDay;
                buscarHora.Valor = (double)valorSegundaHora.Value;
                buscarHora.Type = "Demais horas";
                db.Entry(buscarHora).State = EntityState.Modified;
                db.SaveChanges();
            }
            else
            {
                var model = new Horario();
                model.Dia = "Demais horas";
                model.DataInicio = DateTime.Now.TimeOfDay;
                model.DataFim = DateTime.Now.TimeOfDay;
                model.Valor = (double)valorSegundaHora.Value;
                model.Type = "Demais horas";
                db.Horarios.Add(model);
                db.SaveChanges();
            }

            //terca / quarta
            if (dtTercaInit.Text != string.Empty && dtTercaEnd.Text != string.Empty)
            {
                var buscarTerca = db.Horarios.Where(x => x.Type == lblNormal1.Text).SingleOrDefault();
                if(buscarTerca != null)
                {
                    buscarTerca.Dia = "Terça";
                    buscarTerca.DataInicio = dtTercaInit.Value.TimeOfDay;
                    buscarTerca.DataFim = dtTercaEnd.Value.TimeOfDay;
                    buscarTerca.Valor = (double)valorTerca.Value;
                    buscarTerca.Type = lblNormal1.Text;
                    db.Entry(buscarTerca).State = EntityState.Modified;
                    db.SaveChanges();
                }
                else
                {
                    var model = new Horario();
                    model.Dia = "Terça";
                    model.DataInicio = dtTercaInit.Value.TimeOfDay;
                    model.DataFim = dtTercaEnd.Value.TimeOfDay;
                    model.Valor = (double)valorTerca.Value;
                    model.Type = lblNormal1.Text;
                    db.Horarios.Add(model);
                    db.SaveChanges();
                }
            }

            //sexta
            if (dtSextaInit.Text != string.Empty && dtSextaEnd.Text != string.Empty)
            {
                var buscarSexta = db.Horarios.Where(x => x.Type == lblNormal2.Text).SingleOrDefault();
                if (buscarSexta != null)
                {
                    buscarSexta.Dia = "Sexta";
                    buscarSexta.DataInicio = dtSextaInit.Value.TimeOfDay;
                    buscarSexta.DataFim = dtSextaEnd.Value.TimeOfDay;
                    buscarSexta.Valor = (double)valorSexta.Value;
                    buscarSexta.Type = lblNormal2.Text;
                    db.Entry(buscarSexta).State = EntityState.Modified;
                    db.SaveChanges();
                }
                else
                {
                    var model = new Horario();
                    model.Dia = "Sexta";
                    model.DataInicio = dtSextaInit.Value.TimeOfDay;
                    model.DataFim = dtSextaEnd.Value.TimeOfDay;
                    model.Valor = (double)valorSexta.Value;
                    model.Type = lblNormal2.Text;
                    db.Horarios.Add(model);
                    db.SaveChanges();
                }
            }

            //quinta
            if (dtQuintaInit1.Text != string.Empty && dtQuintaEnd1.Text != string.Empty && 
                dtQuintaInit2.Text != string.Empty && dtQuintaEnd2.Text != string.Empty)
            {
                //quinta 1
                var buscarQuinta1 = db.Horarios.Where(x => x.Type == lblQuinta1.Text).SingleOrDefault();
                if (buscarQuinta1 != null)
                {
                    buscarQuinta1.Dia = "Quinta";
                    buscarQuinta1.DataInicio = dtQuintaInit1.Value.TimeOfDay;
                    buscarQuinta1.DataFim = dtQuintaEnd1.Value.TimeOfDay;
                    buscarQuinta1.Valor = (double)valorQuinta1.Value;
                    buscarQuinta1.Type = lblQuinta1.Text;
                    db.Entry(buscarQuinta1).State = EntityState.Modified;
                    db.SaveChanges();
                }
                else
                {
                    var model = new Horario();
                    model.Dia = "Quinta";
                    model.DataInicio = dtQuintaInit1.Value.TimeOfDay;
                    model.DataFim = dtQuintaEnd1.Value.TimeOfDay;
                    model.Valor = (double)valorQuinta1.Value;
                    model.Type = lblQuinta1.Text;
                    db.Horarios.Add(model);
                    db.SaveChanges();
                }

                //quinta 2
                var buscarQuinta2 = db.Horarios.Where(x => x.Type == lblQuinta2.Text).SingleOrDefault();
                if (buscarQuinta2 != null)
                {
                    buscarQuinta2.Dia = "Quinta";
                    buscarQuinta2.DataInicio = dtQuintaInit2.Value.TimeOfDay;
                    buscarQuinta2.DataFim = dtQuintaEnd2.Value.TimeOfDay;
                    buscarQuinta2.Valor = (double)valorQuinta2.Value;
                    buscarQuinta2.Type = lblQuinta2.Text;
                    db.Entry(buscarQuinta2).State = EntityState.Modified;
                    db.SaveChanges();
                }
                else
                {
                    var model = new Horario();
                    model.Dia = "Quinta";
                    model.DataInicio = dtQuintaInit2.Value.TimeOfDay;
                    model.DataFim = dtQuintaEnd2.Value.TimeOfDay;
                    model.Valor = (double)valorQuinta2.Value;
                    model.Type = lblQuinta2.Text;
                    db.Horarios.Add(model);
                    db.SaveChanges();
                }
            }

            //sabado
            if (dtSabadoInit1.Text != string.Empty && dtSabadoEnd1.Text != string.Empty &&
                dtSabadoInit2.Text != string.Empty && dtSabadoEnd2.Text != string.Empty &&
                dtSabadoInit3.Text != string.Empty && dtSabadoEnd3.Text != string.Empty)
            {
                //sabado 1
                var buscarSabado1 = db.Horarios.Where(x => x.Type == lblSabado1.Text).SingleOrDefault();
                if (buscarSabado1 != null)
                {
                    buscarSabado1.Dia = "Sabado";
                    buscarSabado1.DataInicio = dtSabadoInit1.Value.TimeOfDay;
                    buscarSabado1.DataFim = dtSabadoEnd1.Value.TimeOfDay;
                    buscarSabado1.Valor = (double)valorSabado1.Value;
                    buscarSabado1.Type = lblSabado1.Text;
                    db.Entry(buscarSabado1).State = EntityState.Modified;
                    db.SaveChanges();
                }
                else
                {
                    var model = new Horario();
                    model.Dia = "Sabado";
                    model.DataInicio = dtSabadoInit1.Value.TimeOfDay;
                    model.DataFim = dtSabadoEnd1.Value.TimeOfDay;
                    model.Valor = (double)valorSabado1.Value;
                    model.Type = lblSabado1.Text;
                    db.Horarios.Add(model);
                    db.SaveChanges();
                }

                //sabado 2
                var buscarSabado2 = db.Horarios.Where(x => x.Type == lblSabado2.Text).SingleOrDefault();
                if (buscarSabado2 != null)
                {
                    buscarSabado2.Dia = "Sabado";
                    buscarSabado2.DataInicio = dtSabadoInit2.Value.TimeOfDay;
                    buscarSabado2.DataFim = dtSabadoEnd2.Value.TimeOfDay;
                    buscarSabado2.Valor = (double)valorSabado2.Value;
                    buscarSabado2.Type = lblSabado2.Text;
                    db.Entry(buscarSabado1).State = EntityState.Modified;
                    db.SaveChanges();
                }
                else
                {
                    var model = new Horario();
                    model.Dia = "Sabado";
                    model.DataInicio = dtSabadoInit2.Value.TimeOfDay;
                    model.DataFim = dtSabadoEnd2.Value.TimeOfDay;
                    model.Valor = (double)valorSabado2.Value;
                    model.Type = lblSabado2.Text;
                    db.Horarios.Add(model);
                    db.SaveChanges();
                }

                //sabado 3
                var buscarSabado3 = db.Horarios.Where(x => x.Type == lblSabado3.Text).SingleOrDefault();
                if (buscarSabado3 != null)
                {
                    buscarSabado3.Dia = "Sabado";
                    buscarSabado3.DataInicio = dtSabadoInit3.Value.TimeOfDay;
                    buscarSabado3.DataFim = dtSabadoEnd3.Value.TimeOfDay;
                    buscarSabado3.Valor = (double)valorSabado3.Value;
                    buscarSabado3.Type = lblSabado3.Text;
                    db.Entry(buscarSabado3).State = EntityState.Modified;
                    db.SaveChanges();
                }
                else
                {
                    var model = new Horario();
                    model.Dia = "Sabado";
                    model.DataInicio = dtSabadoInit3.Value.TimeOfDay;
                    model.DataFim = dtSabadoEnd3.Value.TimeOfDay;
                    model.Valor = (double)valorSabado3.Value;
                    model.Type = lblSabado3.Text;
                    db.Horarios.Add(model);
                    db.SaveChanges();
                }
            }
        }

        private void CarregarCampos()
        {
            var buscarPorHora = db.Horarios.Where(x => x.Type == "Por Hora").SingleOrDefault();
            if (buscarPorHora != null)
            {
                valorPrimeiraHora.Value = (decimal)buscarPorHora.Valor;
            }

            var buscarDemaisHora = db.Horarios.Where(x => x.Type == "Demais horas").SingleOrDefault();
            if (buscarDemaisHora != null)
            {
                valorSegundaHora.Value = (decimal)buscarDemaisHora.Valor;
            }

            var buscarTerca = db.Horarios.Where(x => x.Type == lblNormal1.Text).SingleOrDefault();
            if(buscarTerca != null)
            {
                dtTercaInit.Value = Convert.ToDateTime(buscarTerca.DataInicio.ToString());
                dtTercaEnd.Value = Convert.ToDateTime(buscarTerca.DataFim.ToString());
                valorTerca.Value = (decimal)buscarTerca.Valor;
            }

            var buscarSexta = db.Horarios.Where(x => x.Type == lblNormal2.Text).SingleOrDefault();
            if (buscarSexta != null)
            {
                dtSextaInit.Value = Convert.ToDateTime(buscarSexta.DataInicio.ToString());
                dtSextaEnd.Value = Convert.ToDateTime(buscarSexta.DataFim.ToString());
                valorSexta.Value = (decimal)buscarSexta.Valor;
            }

            var buscarQuinta1 = db.Horarios.Where(x => x.Type == lblQuinta1.Text).SingleOrDefault();
            if (buscarQuinta1 != null)
            {
                dtQuintaInit1.Value = Convert.ToDateTime(buscarQuinta1.DataInicio.ToString());
                dtQuintaEnd1.Value = Convert.ToDateTime(buscarQuinta1.DataFim.ToString());
                valorQuinta1.Value = (decimal)buscarQuinta1.Valor;
            }

            var buscarQuinta2 = db.Horarios.Where(x => x.Type == lblQuinta2.Text).SingleOrDefault();
            if (buscarQuinta2 != null)
            {
                dtQuintaInit2.Value = Convert.ToDateTime(buscarQuinta2.DataInicio.ToString());
                dtQuintaEnd2.Value = Convert.ToDateTime(buscarQuinta2.DataFim.ToString());
                valorQuinta2.Value = (decimal)buscarQuinta2.Valor;
            }

            var buscarSabado1 = db.Horarios.Where(x => x.Type == lblSabado1.Text).SingleOrDefault();
            if (buscarSabado1 != null)
            {
                dtSabadoInit1.Value = Convert.ToDateTime(buscarSabado1.DataInicio.ToString());
                dtSabadoEnd1.Value = Convert.ToDateTime(buscarSabado1.DataFim.ToString());
                valorSabado1.Value = (decimal)buscarSabado1.Valor;
            }

            var buscarSabado2 = db.Horarios.Where(x => x.Type == lblSabado2.Text).SingleOrDefault();
            if (buscarSabado2 != null)
            {
                dtSabadoInit2.Value = Convert.ToDateTime(buscarSabado2.DataInicio.ToString());
                dtSabadoEnd2.Value = Convert.ToDateTime(buscarSabado2.DataFim.ToString());
                valorSabado2.Value = (decimal)buscarSabado2.Valor;
            }

            var buscarSabado3 = db.Horarios.Where(x => x.Type == lblSabado3.Text).SingleOrDefault();
            if (buscarSabado3 != null)
            {
                dtSabadoInit3.Value = Convert.ToDateTime(buscarSabado3.DataInicio.ToString());
                dtSabadoEnd3.Value = Convert.ToDateTime(buscarSabado3.DataFim.ToString());
                valorSabado3.Value = (decimal)buscarSabado3.Valor;
            }
        }

        private void Configuracao_Load(object sender, EventArgs e)
        {
            CarregarCampos();
        }
    }
}
