namespace Exercicio6
{
    partial class Form1
    {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">verdade se for necessário descartar os recursos gerenciados; caso contrário, falso.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte do Designer - não modifique
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.PainelBase = new System.Windows.Forms.Panel();
            this.mtxTTL = new System.Windows.Forms.MaskedTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cbListaDeNos = new System.Windows.Forms.ComboBox();
            this.rbV3 = new System.Windows.Forms.RadioButton();
            this.rbV2 = new System.Windows.Forms.RadioButton();
            this.rbV1 = new System.Windows.Forms.RadioButton();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnIniciar = new System.Windows.Forms.Button();
            this.PainelBase.SuspendLayout();
            this.SuspendLayout();
            // 
            // PainelBase
            // 
            this.PainelBase.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("PainelBase.BackgroundImage")));
            this.PainelBase.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.PainelBase.Controls.Add(this.mtxTTL);
            this.PainelBase.Controls.Add(this.label2);
            this.PainelBase.Controls.Add(this.label1);
            this.PainelBase.Controls.Add(this.cbListaDeNos);
            this.PainelBase.Controls.Add(this.rbV3);
            this.PainelBase.Controls.Add(this.rbV2);
            this.PainelBase.Controls.Add(this.rbV1);
            this.PainelBase.Controls.Add(this.btnCancelar);
            this.PainelBase.Controls.Add(this.btnIniciar);
            this.PainelBase.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PainelBase.Location = new System.Drawing.Point(0, 0);
            this.PainelBase.Name = "PainelBase";
            this.PainelBase.Size = new System.Drawing.Size(961, 409);
            this.PainelBase.TabIndex = 4;
            // 
            // mtxTTL
            // 
            this.mtxTTL.Location = new System.Drawing.Point(571, 370);
            this.mtxTTL.Mask = "00";
            this.mtxTTL.Name = "mtxTTL";
            this.mtxTTL.Size = new System.Drawing.Size(20, 20);
            this.mtxTTL.TabIndex = 14;
            this.mtxTTL.Text = "04";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(528, 375);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(27, 13);
            this.label2.TabIndex = 12;
            this.label2.Text = "TTL";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(318, 376);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 11;
            this.label1.Text = "No origem";
            // 
            // cbListaDeNos
            // 
            this.cbListaDeNos.FormattingEnabled = true;
            this.cbListaDeNos.Location = new System.Drawing.Point(379, 370);
            this.cbListaDeNos.Name = "cbListaDeNos";
            this.cbListaDeNos.Size = new System.Drawing.Size(121, 21);
            this.cbListaDeNos.TabIndex = 10;
            this.cbListaDeNos.Text = "0";
            this.cbListaDeNos.TextChanged += new System.EventHandler(this.cbListaDeNos_TextChanged);
            // 
            // rbV3
            // 
            this.rbV3.AutoSize = true;
            this.rbV3.Location = new System.Drawing.Point(205, 374);
            this.rbV3.Name = "rbV3";
            this.rbV3.Size = new System.Drawing.Size(67, 17);
            this.rbV3.TabIndex = 8;
            this.rbV3.Text = "Versão 3";
            this.rbV3.UseVisualStyleBackColor = true;
            this.rbV3.CheckedChanged += new System.EventHandler(this.rbV3_CheckedChanged);
            // 
            // rbV2
            // 
            this.rbV2.AutoSize = true;
            this.rbV2.Checked = true;
            this.rbV2.Location = new System.Drawing.Point(114, 374);
            this.rbV2.Name = "rbV2";
            this.rbV2.Size = new System.Drawing.Size(67, 17);
            this.rbV2.TabIndex = 7;
            this.rbV2.TabStop = true;
            this.rbV2.Text = "Versão 2";
            this.rbV2.UseVisualStyleBackColor = true;
            this.rbV2.CheckedChanged += new System.EventHandler(this.rbV2_CheckedChanged);
            // 
            // rbV1
            // 
            this.rbV1.AutoSize = true;
            this.rbV1.Location = new System.Drawing.Point(23, 374);
            this.rbV1.Name = "rbV1";
            this.rbV1.Size = new System.Drawing.Size(67, 17);
            this.rbV1.TabIndex = 6;
            this.rbV1.Text = "Versão 1";
            this.rbV1.UseVisualStyleBackColor = true;
            this.rbV1.CheckedChanged += new System.EventHandler(this.rbV1_CheckedChanged);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(802, 374);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 5;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnIniciar
            // 
            this.btnIniciar.Location = new System.Drawing.Point(883, 374);
            this.btnIniciar.Name = "btnIniciar";
            this.btnIniciar.Size = new System.Drawing.Size(75, 23);
            this.btnIniciar.TabIndex = 4;
            this.btnIniciar.Text = "Iniciar";
            this.btnIniciar.UseVisualStyleBackColor = true;
            this.btnIniciar.Click += new System.EventHandler(this.btnIniciar_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(961, 409);
            this.Controls.Add(this.PainelBase);
            this.Name = "Form1";
            this.Text = "Exercicio 6 - Algoritmo de inundação";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.PainelBase.ResumeLayout(false);
            this.PainelBase.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel PainelBase;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnIniciar;
        private System.Windows.Forms.RadioButton rbV3;
        private System.Windows.Forms.RadioButton rbV2;
        private System.Windows.Forms.RadioButton rbV1;
        private System.Windows.Forms.ComboBox cbListaDeNos;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.MaskedTextBox mtxTTL;
    }
}

