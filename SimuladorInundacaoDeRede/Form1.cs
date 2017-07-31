using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Exercicio6
{
    public partial class Form1 : Form
    {
        //Lista de nos lida do arquivo .txt
        private List<No> ListaDeNos;
        private No NoInicial = new No();
        private byte Versao = 2;

        public Form1()
        {
            InitializeComponent();

            CarregarNos();

            CarregarVizinhos();

            Desenhar();
            mtxTTL.Text = ListaDeNos.Count().ToString();
        }

        /// <summary>
        /// Inicia execucao
        /// </summary>
        void Iniciar(No NoInicial)
        {
            Pacote p = new Pacote(ref PainelBase, NoInicial, int.Parse(mtxTTL.Text), Cor.CorAleatoria(), Versao);
        }

        #region Carregar e desenhar elementos

        /// <summary>
        /// Cria elementos com base nas informacoes armazenadas nos arquivos .txt
        /// </summary>
        private void CarregarNos()
        {
            try
            {
                using (StreamReader srNos = new StreamReader("Nos.txt"))    //Variaveis para leitura doa arquivos
                {
                    cbListaDeNos.Items.Clear();
                    No NovoNo;
                    ListaDeNos = new List<No>();

                    //Enquanto o arquivo nao chegar ao fim
                    while (!srNos.EndOfStream)
                    {
                        //Divide a linha como base no caractere ';'
                        string[] Linha = srNos.ReadLine().Split(';');

                        NovoNo = new No();
                        NovoNo.Nome = Linha[0];
                        NovoNo.Localizacao = new Point(int.Parse(Linha[1]), int.Parse(Linha[2]));

                        //Adiciona novo no a lista de nos
                        ListaDeNos.Add(NovoNo);

                        cbListaDeNos.Items.Add(NovoNo.Nome);
                    }

                    //Fecha arquivo
                    srNos.Close();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Um erro relacionado ao arquivo \"Nos.txt\" ocorreu, considere alterar o arquivo");
            }
        }

        private void CarregarVizinhos()
        {
            try
            {
                using (StreamReader srVizinhos = new StreamReader("Vizinhos.txt"))
                {
                    NoInicial = ListaDeNos[int.Parse(cbListaDeNos.Text)];

                    foreach (No No in ListaDeNos)
                        No.Vizinhos.Clear();        //Limpa todos os vizinhos do no

                    //Enquanto o arquivo nao chegar ao fim
                    while (!srVizinhos.EndOfStream)
                    {
                        //Divide a linha como base no caractere ';'
                        string[] Linha = srVizinhos.ReadLine().Split(';');

                        //if (Linha[1] != NoInicial.Nome || Versao != "versao 2")
                        ListaDeNos[int.Parse(Linha[0])].Vizinhos.Add(ListaDeNos[int.Parse(Linha[1])]);  //Adiciona vizinhos aos nos
                    }

                    NoInicial = ListaDeNos[int.Parse(cbListaDeNos.Text)];

                    //Fecha arquivo
                    srVizinhos.Close();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Um erro relacionado ao arquivo \"Vizinhos.txt\" ocorreu, considere alterar o arquivo");
            }
        }

        private void CarregarVizinhos(string Texto)
        {
            NoInicial = ListaDeNos[int.Parse(cbListaDeNos.Text)];

            foreach (No No in ListaDeNos)
                No.Vizinhos.Clear();        //Limpa todos os vizinhos do no


            string[] Linha = Texto.Split(';');

            for (int i = 0; i < Linha.Count() - 2; i++)
            {
                ListaDeNos[int.Parse(Linha[i])].Vizinhos.Add(ListaDeNos[int.Parse(Linha[i + 1])]);  //Adiciona vizinhos aos nos
            }


            NoInicial = ListaDeNos[int.Parse(cbListaDeNos.Text)];
        }

        private void Desenhar()
        {
            Graphics graphics = Graphics.FromImage(this.PainelBase.BackgroundImage);
            graphics.Clear(Color.White);

            //Para cada no da lista de nos
            foreach (var NoAtual in ListaDeNos)
            {
                PictureBox Imagem = new PictureBox();
                Label lblNome = new System.Windows.Forms.Label();

                //Cria label para nome do host
                lblNome.AutoSize = true;
                lblNome.Location = new System.Drawing.Point(NoAtual.Localizacao.X + 8, NoAtual.Localizacao.Y + 8);
                lblNome.Name = "lblNome";
                lblNome.BackColor = System.Drawing.SystemColors.ControlDark;
                lblNome.ForeColor = Color.White;
                lblNome.TabIndex = 5;
                lblNome.Text = NoAtual.Nome;

                //Cria imagem para representar o host
                Imagem.BackColor = System.Drawing.SystemColors.ControlDark;
                Imagem.Size = new System.Drawing.Size(30, 30);
                Imagem.Location = NoAtual.Localizacao;

                //Adiciona controles a PainelBase
                PainelBase.Controls.Add(lblNome);
                PainelBase.Controls.Add(Imagem);

                //Cria uma linha para cada vizinho do no
                foreach (var NoVizinho in NoAtual.Vizinhos)
                {
                    Pen pen = new Pen(Color.Black, 1f);

                    graphics.DrawLine(pen, NoAtual.Localizacao.X + 15, NoAtual.Localizacao.Y + 15, NoVizinho.Localizacao.X + 15, NoVizinho.Localizacao.Y + 15);
                }
            }
        }

        private bool ProcessoEmExecucao()
        {
            foreach (Control ctl in PainelBase.Controls)
                if (ctl is PictureBox)
                    if (((PictureBox)ctl).Size.Width == 10)
                        return true;

            return false;
        }

        #endregion

        #region Elementos de interacao usuario

        private void btnIniciar_Click(object sender, EventArgs e)
        {
            //Inicia execucao com o primeiro no da lista como no de origem
            if (Versao == 3)
            {
                if (!ProcessoEmExecucao())
                {
                    CarregarVizinhos(Caminho.MelhorCaminho(ListaDeNos.Count() - 1));
                    Iniciar(NoInicial);
                }
                else
                    MessageBox.Show("O algoritmo 3 ainda esta inundando a rede");
            }
            else
            {
                CarregarVizinhos();

                Iniciar(NoInicial);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            if (Versao == 3 && ProcessoEmExecucao())
                MessageBox.Show("Não é possivel encerrar nesse momento, o algoritmo 3 esta inundando a rede");
            else
                Pacote.CancelarInundacao();
        }

        private void rbV1_CheckedChanged(object sender, EventArgs e)
        {
            if (rbV1.Checked)
                Versao = 1;
        }

        private void rbV2_CheckedChanged(object sender, EventArgs e)
        {
            if (rbV2.Checked)
                Versao = 2;
        }

        private void rbV3_CheckedChanged(object sender, EventArgs e)
        {
            if (rbV3.Checked)
            {
                Versao = 3;

                Caminho.ListaDecaminhos.Clear();

                MessageBox.Show("A rede sera inundada para calculos de distancia, apos a inundação aperte Iniciar");

                Iniciar(NoInicial);
            }
        }

        private void cbListaDeNos_TextChanged(object sender, EventArgs e)
        {
            CarregarVizinhos();
        }

        #endregion

        private void Form1_Load(object sender, EventArgs e)
        {
            //Mensagem de desempenho
            MessageBox.Show("Apesar da capacidade elevada de processamento desde computador, um numero alto de pacotes na rede pode deixar o programa lento pela não implementação eficiente de threads, por favor ao alterar o arquivo Nos.txt leve em consideração isto", "Observação: hard way - hardware way");
        }

        //private void button1_Click(object sender, EventArgs e)
        //{
        //    string a = "";
        //    StreamWriter sw = new StreamWriter("Rotas.txt");
        //    foreach (var item in Caminho.ListaDecaminhos)
        //    {
        //        foreach (var elemento in item.ListadeNos)
        //        {
        //            a += elemento.Nome + ";";
        //        }
        //        sw.WriteLine(a + item.Soma);
        //        a = "";
        //    }

        //    sw.Close();

        //    MessageBox.Show(Caminho.MelhorCaminho(ListaDeNos.Count() - 1));
        //    CarregarVizinhos(Caminho.MelhorCaminho(ListaDeNos.Count() - 1));
        //}
    }
}