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
    public partial class CadastroModelo : MetroForm
    {
        private EstacionamentoContext db;

        public CadastroModelo()
        {
            InitializeComponent();
            db = new EstacionamentoContext();
            PopularGrid();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            SalvarModelo();
        }

        private void txtNome_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SalvarModelo();
            }
        }

        private void PopularGrid()
        {
            var query = from c in db.ModelosCarroes.ToList()
                        select new DataBindingModelo { Nome = c.Nome };
            var modelos = query.ToList();
            gridModelo.DataSource = modelos;
        }

        private class DataBindingModelo
        {
            public string Nome { get; set; }
        }

        private void SalvarModelo()
        {
            if(txtNome.Text != string.Empty)
            {
                if (modeloID.Text != "label2")
                {
                    var id = int.Parse(modeloID.Text);
                    var buscar = db.ModelosCarroes.Where(x => x.ID == id).SingleOrDefault();
                    if (buscar != null)
                    {
                        buscar.Nome = txtNome.Text;
                        db.Entry(buscar).State = EntityState.Modified;
                        db.SaveChanges();
                        PopularGrid();
                    }
                }
                else
                {
                    var model = new ModelosCarro() { Nome = txtNome.Text };
                    db.ModelosCarroes.Add(model);
                    db.SaveChanges();
                    PopularGrid();
                }
            }
        }

        private void gridModelo_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtNome.Text = string.Empty;
            modeloID.Text = string.Empty;
            DataGridViewRow row = new DataGridViewRow();
            row = gridModelo.CurrentRow;
            int intRow = row.Index;
            string nome = gridModelo[0, row.Index].Value.ToString();
            var result = db.ModelosCarroes.Where(x => x.Nome == nome).SingleOrDefault();
            if (result != null)
            {
                modeloID.Text = result.ID.ToString();
                txtNome.Text = result.Nome;
            }
        }

        private void btnDeletar_Click(object sender, EventArgs e)
        {
            if (modeloID.Text != string.Empty)
            {
                var id = int.Parse(modeloID.Text);
                var buscar = db.ModelosCarroes.Where(x => x.ID == id).SingleOrDefault();
                db.ModelosCarroes.Remove(buscar);
                db.SaveChanges();
                txtNome.Text = string.Empty;
                modeloID.Text = string.Empty;
                PopularGrid();
            }
            else
            {
                MessageBox.Show("Você não pode exclui um modelo não existente!");
            }
        }
    }
}
