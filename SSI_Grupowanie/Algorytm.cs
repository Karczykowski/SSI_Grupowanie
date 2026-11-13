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
        public double[,] srodki;
        public int[] tablicaGrup;

        public void GlownyProgram(int k, int iteracje)
        {
            srodki = new double[k, 2];
            PrzygotowanieDanych();
            WygenerujSrodki(k);

            for (int i = 0; i < iteracje; i++)
            {
                PrzypisanieDoGrupy(k);
                AktulizacjaSrodkow(k);
            }

            PrzypisanieDoGrupy(k);
            WyswietlWynik(k);
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
            MessageBox.Show("Liczba Probek:" + spiralka.Length);
        }

        public void WygenerujSrodki(int k)
        {
            Random rand = new Random();

            for (int i = 0; i < k; i++)
            {
                int losowyIndex = rand.Next(0, dane.GetLength(0));

                srodki[i, 0] = dane[losowyIndex, 0];
                srodki[i, 1] = dane[losowyIndex, 1];

            }
        }

        public void PrzypisanieDoGrupy(int k)
        {
            tablicaGrup = new int[dane.GetLength(0)];

            for (int i = 0; i < dane.GetLength(0); i++)
            {
                double min = double.MaxValue;

                for (int j = 0; j < k; j++)
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

        public void AktulizacjaSrodkow(int k)
        {
            for (int i = 0; i < k; i++)
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

        public void WyswietlWynik(int k)
        {
            string wynik = "";

            for (int i = 0; i < k; i++)
            {
                int licznik = 0;

                for (int j = 0; j < dane.GetLength(0); j++)
                {
                    if (tablicaGrup[j] == i)
                    {
                        licznik++;
                    }
                }

                wynik += "Grupa " + (i + 1) + "\n";
                wynik += "Środek: " + Math.Round(srodki[i, 0], 2)
                       + ", " + Math.Round(srodki[i, 1], 2) + "\n";
                wynik += "Liczba punktów: " + licznik + "\n\n";
            }

            MessageBox.Show(wynik);
        }

    }
}
