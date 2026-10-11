using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace SSI_Grupowanie
{
    internal class Algorytm
    {
        public void PrzygotowanieDanych()
        {
            string[] dane = File.ReadAllLines("spiralka.csv");
            MessageBox.Show(string.Join("\n", dane));
        }
    }
}
