namespace Estacionamento
{
    partial class RelatorioCarroPatio
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
            this.gridRelatorio = new System.Windows.Forms.DataGridView();
            this.dtInicio = new System.Windows.Forms.DateTimePicker();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.dtFim = new System.Windows.Forms.DateTimePicker();
            this.txtCodigo = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtPlaca = new System.Windows.Forms.TextBox();
            this.dtSaida = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.dtEntrada = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.fluxoID = new System.Windows.Forms.Label();
            this.btnAtualizar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.gridRelatorio)).BeginInit();
            this.SuspendLayout();
            // 
            // gridRelatorio
            // 
            this.gridRelatorio.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridRelatorio.Location = new System.Drawing.Point(23, 247);
            this.gridRelatorio.Name = "gridRelatorio";
            this.gridRelatorio.Size = new System.Drawing.Size(1103, 487);
            this.gridRelatorio.TabIndex = 0;
            this.gridRelatorio.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridRelatorio_CellClick);
            // 
            // dtInicio
            // 
            this.dtInicio.CustomFormat = "dd/MM/yyyy HH:mm";
            this.dtInicio.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtInicio.Location = new System.Drawing.Point(23, 87);
            this.dtInicio.Name = "dtInicio";
            this.dtInicio.Size = new System.Drawing.Size(200, 20);
            this.dtInicio.TabIndex = 1;
            // 
            // btnBuscar
            // 
            this.btnBuscar.Location = new System.Drawing.Point(502, 84);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(75, 23);
            this.btnBuscar.TabIndex = 2;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // dtFim
            // 
            this.dtFim.CustomFormat = "dd/MM/yyyy HH:mm";
            this.dtFim.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtFim.Location = new System.Drawing.Point(256, 87);
            this.dtFim.Name = "dtFim";
            this.dtFim.Size = new System.Drawing.Size(200, 20);
            this.dtFim.TabIndex = 3;
            // 
            // txtCodigo
            // 
            this.txtCodigo.Location = new System.Drawing.Point(407, 150);
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.Size = new System.Drawing.Size(156, 20);
            this.txtCodigo.TabIndex = 20;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(314, 153);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 13);
            this.label1.TabIndex = 19;
            this.label1.Text = "Codigo";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(27, 153);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 13);
            this.label2.TabIndex = 21;
            this.label2.Text = "Placa do Carro";
            // 
            // txtPlaca
            // 
            this.txtPlaca.Location = new System.Drawing.Point(120, 150);
            this.txtPlaca.Name = "txtPlaca";
            this.txtPlaca.Size = new System.Drawing.Size(156, 20);
            this.txtPlaca.TabIndex = 22;
            // 
            // dtSaida
            // 
            this.dtSaida.CustomFormat = "dd/MM/yyyy HH:mm:ss";
            this.dtSaida.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtSaida.Location = new System.Drawing.Point(407, 189);
            this.dtSaida.Name = "dtSaida";
            this.dtSaida.ShowUpDown = true;
            this.dtSaida.Size = new System.Drawing.Size(156, 20);
            this.dtSaida.TabIndex = 30;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(314, 195);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(62, 13);
            this.label6.TabIndex = 29;
            this.label6.Text = "Data Saída";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dtEntrada
            // 
            this.dtEntrada.Cursor = System.Windows.Forms.Cursors.Default;
            this.dtEntrada.CustomFormat = "hh:mm:ss";
            this.dtEntrada.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtEntrada.Location = new System.Drawing.Point(120, 189);
            this.dtEntrada.Name = "dtEntrada";
            this.dtEntrada.ShowUpDown = true;
            this.dtEntrada.Size = new System.Drawing.Size(156, 20);
            this.dtEntrada.TabIndex = 28;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(27, 195);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(70, 13);
            this.label5.TabIndex = 27;
            this.label5.Text = "Data Entrada";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // fluxoID
            // 
            this.fluxoID.AutoSize = true;
            this.fluxoID.Location = new System.Drawing.Point(777, 20);
            this.fluxoID.Name = "fluxoID";
            this.fluxoID.Size = new System.Drawing.Size(35, 13);
            this.fluxoID.TabIndex = 31;
            this.fluxoID.Text = "label3";
            this.fluxoID.Visible = false;
            // 
            // btnAtualizar
            // 
            this.btnAtualizar.Location = new System.Drawing.Point(605, 185);
            this.btnAtualizar.Name = "btnAtualizar";
            this.btnAtualizar.Size = new System.Drawing.Size(75, 23);
            this.btnAtualizar.TabIndex = 32;
            this.btnAtualizar.Text = "Atualizar";
            this.btnAtualizar.UseVisualStyleBackColor = true;
            this.btnAtualizar.Click += new System.EventHandler(this.btnAtualizar_Click);
            // 
            // RelatorioCarroPatio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1174, 757);
            this.Controls.Add(this.btnAtualizar);
            this.Controls.Add(this.fluxoID);
            this.Controls.Add(this.dtSaida);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.dtEntrada);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtCodigo);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtPlaca);
            this.Controls.Add(this.dtFim);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.dtInicio);
            this.Controls.Add(this.gridRelatorio);
            this.Name = "RelatorioCarroPatio";
            this.Text = "Relatorio";
            this.Load += new System.EventHandler(this.RelatorioCarroPatio_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridRelatorio)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView gridRelatorio;
        private System.Windows.Forms.DateTimePicker dtInicio;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.DateTimePicker dtFim;
        private System.Windows.Forms.TextBox txtCodigo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtPlaca;
        private System.Windows.Forms.DateTimePicker dtSaida;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DateTimePicker dtEntrada;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label fluxoID;
        private System.Windows.Forms.Button btnAtualizar;
    }
}