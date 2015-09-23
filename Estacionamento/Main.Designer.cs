namespace Estacionamento
{
    partial class Main
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.button1 = new MetroFramework.Controls.MetroButton();
            this.metroButton1 = new MetroFramework.Controls.MetroButton();
            this.metroButton4 = new MetroFramework.Controls.MetroButton();
            this.btnConfig = new MetroFramework.Controls.MetroButton();
            this.metroButton2 = new MetroFramework.Controls.MetroButton();
            this.metroButton3 = new MetroFramework.Controls.MetroButton();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button1.Location = new System.Drawing.Point(718, 63);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(98, 74);
            this.button1.TabIndex = 5;
            this.button1.Text = "Fechar";
            this.button1.UseSelectable = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // metroButton1
            // 
            this.metroButton1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.metroButton1.Location = new System.Drawing.Point(153, 63);
            this.metroButton1.Name = "metroButton1";
            this.metroButton1.Size = new System.Drawing.Size(98, 74);
            this.metroButton1.TabIndex = 8;
            this.metroButton1.Text = "Relatorio Saida";
            this.metroButton1.UseSelectable = true;
            // 
            // metroButton4
            // 
            this.metroButton4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.metroButton4.Location = new System.Drawing.Point(23, 63);
            this.metroButton4.Name = "metroButton4";
            this.metroButton4.Size = new System.Drawing.Size(98, 74);
            this.metroButton4.TabIndex = 11;
            this.metroButton4.Text = "Cadastro Usuario";
            this.metroButton4.UseSelectable = true;
            this.metroButton4.Click += new System.EventHandler(this.metroButton4_Click);
            // 
            // btnConfig
            // 
            this.btnConfig.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnConfig.Location = new System.Drawing.Point(597, 63);
            this.btnConfig.Name = "btnConfig";
            this.btnConfig.Size = new System.Drawing.Size(98, 74);
            this.btnConfig.TabIndex = 12;
            this.btnConfig.Text = "Configurações";
            this.btnConfig.UseSelectable = true;
            this.btnConfig.Click += new System.EventHandler(this.btnConfig_Click);
            // 
            // metroButton2
            // 
            this.metroButton2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.metroButton2.Location = new System.Drawing.Point(273, 63);
            this.metroButton2.Name = "metroButton2";
            this.metroButton2.Size = new System.Drawing.Size(144, 74);
            this.metroButton2.TabIndex = 13;
            this.metroButton2.Text = "Relatorio Carros Patio";
            this.metroButton2.UseSelectable = true;
            // 
            // metroButton3
            // 
            this.metroButton3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.metroButton3.Location = new System.Drawing.Point(440, 63);
            this.metroButton3.Name = "metroButton3";
            this.metroButton3.Size = new System.Drawing.Size(132, 74);
            this.metroButton3.TabIndex = 14;
            this.metroButton3.Text = "Relatorio Fechamento";
            this.metroButton3.UseSelectable = true;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1373, 722);
            this.Controls.Add(this.metroButton3);
            this.Controls.Add(this.metroButton2);
            this.Controls.Add(this.btnConfig);
            this.Controls.Add(this.metroButton4);
            this.Controls.Add(this.metroButton1);
            this.Controls.Add(this.button1);
            this.Name = "Main";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private MetroFramework.Controls.MetroButton button1;
        private MetroFramework.Controls.MetroButton metroButton1;
        private MetroFramework.Controls.MetroButton metroButton4;
        private MetroFramework.Controls.MetroButton btnConfig;
        private MetroFramework.Controls.MetroButton metroButton2;
        private MetroFramework.Controls.MetroButton metroButton3;
    }
}

