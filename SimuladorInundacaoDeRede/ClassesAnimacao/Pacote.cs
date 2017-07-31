using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace Exercicio6
{
    class Pacote
    {
        private Timer timer1 = new Timer();
        private float x1 = 0, x2 = 0, y1 = 0, y2 = 0;
        private float m;
        private int Incremento = 1;
        private PictureBox Imagem = new PictureBox();
        private Color Cor;
        private Pacote p;
        private No NoAtual;
        private No NoAnterior;
        private Panel Painel;
        private int Saltos = 0;
        private static bool Cancelar = false;
        private byte Versao;
        private Caminho NovoCaminho = new Caminho();

        /// <summary>
        /// Inicia inundacao da rede
        /// </summary>
        public Pacote(ref Panel Painel, No NoInicio, int Saltos, Color Cor, byte Versao)
        {
            Cancelar = false;

            //Para cada viziho do no cria uma animacao
            foreach (var Vizinho in NoInicio.Vizinhos)
            {
                //Cria novo caminho
                Caminho c = new Caminho();

                //Adiciona o no ao caminho
                c.ListadeNos.Add(NoInicio);
                
                //Cria pacote para o vizinho
                p = new Pacote(ref Painel, NoInicio, Vizinho, Saltos, Cor, Versao, c);
            }
        }

        /// <summary>
        /// Inundacao da rede a partir do segundo No
        /// </summary>
        private Pacote(ref Panel Painel, No NoOrigem, No NoDestino, int Saltos, Color Cor, byte Versao, Caminho caminho)
        {
            NoAtual = NoDestino;
            NoAnterior = NoOrigem;
            this.Painel = Painel;
            this.Cor = Cor;
            this.Saltos = Saltos;
            this.Versao = Versao;
           
            //Adiciona Nos recebidos ao caminho
            NovoCaminho.ListadeNos.AddRange(caminho.ListadeNos);

            //Adiciona o No atual ao caminho
            NovoCaminho.ListadeNos.Add(NoAtual);

            //Incrementa a soma de distancias
            NovoCaminho.Soma = caminho.Soma + Caminho.DistaciaCaminho(NoOrigem.Localizacao, NoDestino.Localizacao);

            //Adicina caminhos a lista de caminhos
            Caminho.ListaDecaminhos.Add(NovoCaminho);

            //Cria imagem para representar o pacote e adiciona essa imagem ao painel
            PictureBox Imagem = new PictureBox();
            Imagem.BackColor = Cor;
            Imagem.Location = NoOrigem.Localizacao;
            Imagem.Size = new System.Drawing.Size(10, 10);
            Painel.Controls.Add(Imagem);

            this.Imagem = Imagem;
            this.Saltos = Saltos;
            this.Saltos--;

            //y2 - y1 = m * (x2 - x1); Formula original

            //Adiciona coordenadas
            x1 = NoOrigem.Localizacao.X;
            x2 = NoDestino.Localizacao.X;
            y1 = NoOrigem.Localizacao.Y;
            y2 = NoDestino.Localizacao.Y;

            //Atribui posicao inicial no painel
            Imagem.Location = new Point((int)x1, (int)y1);

            //Calcula angulo de movimentacao
            m = (float)(y2 - y1) / (x2 - x1);

            //Verifica se a posicao X vai ser inf=crementada ou decrementada
            if (x1 > x2)
                Incremento = -1;

            //Cria timer para movimentacao
            timer1.Tick += new EventHandler(EventoTimer); //adiciona evento
            timer1.Interval = 1;   //Define intervalo
            timer1.Enabled = true;   //Habilita timer
        }

        #region FuncoesGerais
        /// <summary>
        /// Evento para movimentacao de pacote
        /// </summary>
        private void EventoTimer(object sender, EventArgs e)
        {
            //Busca vizinhos
            BuscarVizinhos();

            //Movimenta pacote na tela
            Movimentar();
        }

        private void Movimentar()
        {
            //Incrementa posicoes x e y
            x1 += Incremento;
            y1 = -m * (x2 - x1) + y2;

            //Atribui posicao atual
            Imagem.Location = new Point((int)x1, (int)y1);
        }

        private void ColorirHost()
        {
            foreach (Control ctl in Painel.Controls)
            {
                if (ctl is PictureBox)
                    if (((PictureBox)ctl).Location.X == x1 && ((PictureBox)ctl).Location.Y == y1)
                        ((PictureBox)ctl).BackColor = Cor;
            }
        }

        private void BuscarVizinhos()
        {
            if (Cancelar)
            {
                LiberarRecursos();
                return;
            }

            //Encerra caso o numero de saltos seja alcancado
            if (Saltos == 0)
            {
                timer1.Enabled = false;

                LiberarRecursos();

                return;
            }
            else if (x1 == x2)  //Encerra caso o pacote tenha chegado ao seu destino
            {
                timer1.Enabled = false;

                ColorirHost();

                //Cria pacote para cada no vizinho
                foreach (var Vizinho in NoAtual.Vizinhos)
                    if (Vizinho.Nome != NoAnterior.Nome || Versao == 1)
                        p = new Pacote(ref Painel, NoAtual, Vizinho, Saltos, Cor, Versao, NovoCaminho);

                LiberarRecursos();

                return;
            }
        }

        private void LiberarRecursos()
        {
            Imagem.Dispose();
            timer1.Dispose();
            Imagem.Dispose();
        }

        /// <summary>
        /// Evento para cancelar inundacao
        /// </summary>
        public static void CancelarInundacao()
        {
            Cancelar = true;
        }

        #endregion
    }
}
