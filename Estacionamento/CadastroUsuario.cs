using Estacionamento.Models;
using MetroFramework.Forms;
using System;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Windows.Forms;

namespace Estacionamento
{
    public partial class CadastroUsuario : MetroForm
    {
        private EstacionamentoContext db;
        public CadastroUsuario()
        {
            InitializeComponent();
            db = new EstacionamentoContext();
            PopularGrid();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            CriarUsuario();
        }

        private void CriarUsuario()
        {
            if (txtLogin.Text != string.Empty && txtSenha.Text != string.Empty)
            {
                if (userID.Text != "label2")
                {
                    var id = int.Parse(userID.Text);
                    var existe = db.Usuarios.Where(x => x.ID == id).SingleOrDefault();
                    if (existe != null)
                    {
                        existe.Login = txtLogin.Text;
                        existe.Senha = txtSenha.Text;
                        db.Entry(existe).State = EntityState.Modified;
                        db.SaveChanges();
                    }
                }
                else
                {
                    db.Usuarios.Add(new Usuario() { Login = txtLogin.Text, Senha = txtSenha.Text });
                    db.SaveChanges();
                    txtLogin.Text = string.Empty;
                    txtSenha.Text = string.Empty;
                }
                PopularGrid();
            }
            else
            {
                MessageBox.Show("Preencha todos os campos!");
            }
        }

        private void PopularGrid()
        {
            var query = from c in db.Usuarios.ToList()
                        select new DataBindingUsuario { Login = c.Login };
            var users = query.ToList();
            gridUsuario.DataSource = users;
        }

        private class DataBindingUsuario
        {
            public string Login { get; set; }
        }

        private void txtLogin_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                CriarUsuario();
            }
        }

        private void txtSenha_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                CriarUsuario();
            }
        }

        private void btnSalvar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                CriarUsuario();
            }
        }

        private void gridUsuario_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtLogin.Text = string.Empty;
            txtSenha.Text = string.Empty;
            userID.Text = string.Empty;
            DataGridViewRow row = new DataGridViewRow();
            row = gridUsuario.CurrentRow;
            int intRow = row.Index;
            string nome = gridUsuario[0, row.Index].Value.ToString();
            var result = db.Usuarios.Where(x => x.Login == nome).SingleOrDefault();
            if(result != null)
            {
                userID.Text = result.ID.ToString();
                txtLogin.Text = result.Login;
                txtSenha.Text = result.Senha;
            }
        }

        private void btnDeletar_Click(object sender, EventArgs e)
        {
            if (userID.Text != string.Empty)
            {
                var id = int.Parse(userID.Text);
                var buscar = db.Usuarios.Where(x => x.ID == id).SingleOrDefault();
                db.Usuarios.Remove(buscar);
                db.SaveChanges();
                txtLogin.Text = string.Empty;
                txtSenha.Text = string.Empty;
                userID.Text = string.Empty;
                PopularGrid();
            }
            else
            {
                MessageBox.Show("Você não pode exclui um modelo não existente!");
            }
        }
    }
}
