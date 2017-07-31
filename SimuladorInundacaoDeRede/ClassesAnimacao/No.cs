using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace Exercicio6
{
    /// <summary>
    /// No de uma rede
    /// </summary>
    class No
    {
        /// <summary>
        /// Nome do No
        /// </summary>
        public string Nome;

        /// <summary>
        /// Posicao X e Y do No
        /// </summary>
        public Point Localizacao;

        /// <summary>
        /// Lista de vizinhos do No
        /// </summary>
        public List<No> Vizinhos = new List<No>();

        public No()
        {
        }
    }
}
