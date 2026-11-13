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
        public double[,] dane;
        public double[,] srodki = new double[3, 2];
        public int[] tablicaGrup;

        public void GlownyProgram()
        {
            PrzygotowanieDanych();
            WygenerujSrodki();

            for (int i = 0; i < 10; i++)
            {
                PrzypisanieDoGrupy();
                AktulizacjaSrodkow();
            }

            PrzypisanieDoGrupy();
        }
        public void PrzygotowanieDanych()
        {
            string[] spiralka = File.ReadAllLines("spiralka.csv");
            dane = new double[spiralka.Length, 2];

            for (int i = 0; i < spiralka.Length; i++)
            {
                string[] d = spiralka[i].Split(',');

                dane[i, 0] = double.Parse(d[0].Replace('.', ','));
                dane[i, 1] = double.Parse(d[1].Replace('.', ','));
            }
            MessageBox.Show("probki:" + spiralka.Length);
        }

        public void WygenerujSrodki()
        {
            Random rand = new Random();

            for (int i = 0; i < 3; i++)
            {
                int losowyIndex = rand.Next(0, dane.GetLength(0));

                srodki[i, 0] = dane[losowyIndex, 0];
                srodki[i, 1] = dane[losowyIndex, 1];

            }
        }

        public void PrzypisanieDoGrupy()
        {
            tablicaGrup = new int[dane.GetLength(0)];

            for (int i = 0; i < dane.GetLength(0); i++)
            {
                double min = double.MaxValue;

                for (int j = 0; j < 3; j++)
                {
                    double x = dane[i, 0] - srodki[j, 0];
                    double y = dane[i, 1] - srodki[j, 1];

                    double odleglosc = Math.Sqrt(x * x + y * y);

                    if (odleglosc < min)
                    {
                        min = odleglosc;
                        tablicaGrup[i] = j;
                    }
                }
            }
        }

        public void AktulizacjaSrodkow()
        {
            for (int i = 0; i < 3; i++)
            {
                double sumaX = 0;
                double sumaY = 0;

                int licznik = 0;

                for (int j = 0; j < dane.GetLength(0); j++)
                {
                    if (tablicaGrup[j] == i)
                    {
                        sumaX += dane[j, 0];
                        sumaY += dane[j, 1];
                        licznik++;
                    }
                }

                if(licznik > 0)
                {
                    srodki[i, 0] = sumaX / licznik;
                    srodki[i, 1] = sumaY / licznik;
                }
            }
        }

    }
}
