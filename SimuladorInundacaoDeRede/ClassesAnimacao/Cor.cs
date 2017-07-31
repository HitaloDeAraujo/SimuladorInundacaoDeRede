using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercicio6
{
    class Cor
    {
        //Lista de cores
        private static List<Color> ListaDeCores;

        //Variavel para numeros aleatorios
        private static Random r = new Random();

        /// <summary>
        /// Retorna uma cor aleatoria
        /// </summary>
        public static Color CorAleatoria()
        {
            if (ListaDeCores ==  null || ListaDeCores.Count == 0)
                ListaDeCores = new List<Color>() { Color.Yellow, Color.Green, Color.Red, Color.SkyBlue };

            int aux = r.Next(ListaDeCores.Count());
            Color Cor = ListaDeCores[aux];
            ListaDeCores.RemoveAt(aux);

            return Cor;
        }
    }
}
