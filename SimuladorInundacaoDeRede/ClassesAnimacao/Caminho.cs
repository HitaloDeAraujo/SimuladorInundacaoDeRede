using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Exercicio6
{
    class Caminho
    {
        //Lista de nos
        public List<No> ListadeNos = new List<No>();

        //Lista de caminhos
        public static List<Caminho> ListaDecaminhos = new List<Caminho>();

        //Soma do percurso
        public double Soma = 0;

        public Caminho()
        {
            List<Caminho> ListaAuxiliar = new List<Caminho>();

            //Ordena a lista com base na distancia percorrida, soma
            foreach (Caminho item in ListaDecaminhos.OrderBy(p => p.Soma))
                ListaAuxiliar.Add(item);

            ListaDecaminhos.Clear();
            ListaDecaminhos.AddRange(ListaAuxiliar);
        }

        /// <summary>
        /// Melhor caminho
        /// </summary>
        public static string MelhorCaminho(int QuantNos)
        {
            List<string> Lista = new List<string>();
            bool Teste = false;
            string aux = "";


            //Procura caminho com menor distancia e que passe por todos os nos
            foreach (var caminho in Caminho.ListaDecaminhos)
            {
                Lista.Clear();

                foreach (var elemento in caminho.ListadeNos)
                    Lista.Add(elemento.Nome);

                for (int i = 0; i <= QuantNos; i++)
                {
                    Teste = false;

                    if (Lista.Contains(i.ToString()))
                        Teste = true;
                    else
                    {
                        Teste = false; 
                        
                        break;
                    }
                }

                //Fornece o melhor caminho encontrado entre os hosts
                if (Teste)
                {
                    aux = "";
                    foreach (var x in Lista)
                        aux += x + ";";

                    return aux;
                }
            }
            return "";
        }

        /// <summary>
        /// Calculo de distancia entre dois pontos
        /// </summary>
        public static double DistaciaCaminho(Point Origem, Point Destino)
        {
            //Equacao para calculo de distancia em plano cartesiano
            return Math.Sqrt(Math.Pow((Origem.X - Destino.X), 2) + Math.Pow((Origem.Y - Destino.Y), 2));
        }
    }
}
