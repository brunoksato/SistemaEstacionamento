using Estacionamento.Models;
using MetroFramework.Forms;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace Estacionamento
{
    public partial class Login : MetroForm
    {
        private EstacionamentoContext db;

        public Login()
        {
            InitializeComponent();
            db = new EstacionamentoContext();
        }

        private void btnEntrar_Click(object sender, EventArgs e)
        {
            Logar();
        }

        public void Logar()
        {
            var result = db.Usuarios.Where(x => x.Login == txtLogin.Text && x.Senha == txtSenha.Text).SingleOrDefault();
            if (result != null)
            {
                this.Hide();
                var form = new Main();
                form.Closed += (s, args) => this.Close();
                form.Show();
            }
            else
            {
                MessageBox.Show("Usuario ou senha incorreta!");
            }
        }

        private void txtLogin_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Logar();
            }
        }

        private void txtSenha_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Logar();
            }
        }

        private void btnEntrar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Logar();
            }
        }
    }
}
