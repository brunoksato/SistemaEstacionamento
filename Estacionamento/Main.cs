using MetroFramework;
using MetroFramework.Forms;
using System;
using System.Windows.Forms;

namespace Estacionamento
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MetroMessageBox.Show(this, "Do you like this metro message box?", "Metro Title", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Asterisk);
        }

        private void relatorio1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var relatorio = new RelatorioSaida();
            relatorio.Show();
        }

        private void relatorio2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var relatorio = new RelatorioFechamento();
            relatorio.Show();
        }

        private void sairToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
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
            this.Close();
        }
    }
}
