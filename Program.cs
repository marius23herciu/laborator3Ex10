using System;

namespace laborator3Ex10
{
    class Program
    {
        static void Main(string[] args)
        {
            //Ex10 Arpsod adoră două lucruri: matematica și clătitele bunicii sale. Într-o zi,
            //aceasta s-a apucat să prepare clătite. Arpsod mănâncă toate clătitele începând de
            //la a N - a clătită preparată, până la a M - a clătită preparată(inclusiv N și M).
            //Pentru că el vrea să mănânce clătite cu diferite umpluturi și - a făcut următoarea
            //regulă:
            // “Dacă numărul de ordine al clătitei este prim atunci aceasta va fi cu ciocolată. Dacă
            //numărul de ordine este pătrat perfect sau cub perfect aceasta va fi cu gem.Dacă suma
            //divizorilor numărului este egală cu însuși numărul de ordine atunci aceasta va fi cu
            //înghețată. (se iau în considerare toți divizorii în afară de numărul în sine, inclusiv 1).
            // Dacă niciuna dintre condițiile de mai sus nu este îndeplinită, pentru cele cu numărul de
            //ordine par, clătita va fi cu zahar, iar pentru numărul de ordine impar, clătita va fi
            //simplă.”
            //• Cerința
            // Cunoscându - se N și M, numere naturale, să se determine câte clătite a mâncat Arpsod în
            //total și numărul de clătite din fiecare tip. A
            //• Indicii
            // 1.iteratorul unui for nu incepe neaparat de la 1 ☺
            // 2, folositi functii: extrageti operatiile matematice complicate asupra intregilor in funciti.
            //Veti simplifica astfel partea de logica.

            int N = 1;
            Console.WriteLine("Introduceti numarul de glatite facute de bunica lui Arpsod(nu stiu de unde ati luat numele asta ☺)");
            int M = int.Parse(Console.ReadLine());
            if (M < 1)
            {
                Console.Write("Macar o clatita a facut si bunica lui Arpsod, pune un numar mai mare de 0 :).");
                return;
            }

            int[] clatiteMancate = new int[M];

            int ciocolata = NumerePrime(N, M, clatiteMancate);
            int gem = PatratSauCubPerfect(N, M, clatiteMancate);
            int inghetata = SumaDivizori(N, M, clatiteMancate);
            int zahar = ClatiteZahar(clatiteMancate);
            int simplu = ClatiteSimple(clatiteMancate);

            int totalClatite = ciocolata + gem + inghetata + zahar + simplu;

            Console.WriteLine("Arpsod a mancat " + ciocolata + " clatite cu ciocolata, ");
            Console.WriteLine(gem + " clatite cu gem ");
            Console.WriteLine(inghetata + " clatite cu inghetata ");
            Console.WriteLine(zahar + " clatite cu zahar ");
            Console.WriteLine("si " + simplu + " clatite simple.");
            Console.WriteLine("In total: " + totalClatite);
        }

        static int NumerePrime(int N, int M, int[] clatiteMancate)
        {
            int ciocolata = 0;
            for (int i = N; i < M + 1; i++)
            {
                var radacinaPatrata = (int)Math.Floor(Math.Sqrt(i));
                if (i <= 1)
                {
                    continue;
                }
                if (i == 2)
                {
                    ciocolata++;
                    clatiteMancate[i - 1] = i;
                    continue;
                }
                if (i % 2 == 0)
                {
                    continue;
                }
                int flag = 0;
                for (int j = 3; j <= radacinaPatrata; j += 2)
                {
                    if (i % j == 0)
                    {
                        flag++;
                    }
                    else
                    {
                        if (j + 2 > radacinaPatrata && flag == 0)
                        {
                            ciocolata++;
                            clatiteMancate[i - 1] = i;
                            flag++;
                        }
                    }
                }
                if (flag == 0)
                {
                    ciocolata++;
                    clatiteMancate[i - 1] = i;
                }
            }

            return ciocolata;
        }
        static int PatratSauCubPerfect(int N, int M, int[] clatiteMancate)
        {
            int gem = 0;
            for (int i = N; i < M + 1; i++)
            {
                double radacinaPatrata = Math.Sqrt(i);
                int flag = 0;
                if (radacinaPatrata % 1 == 0)
                {
                    gem++;
                    clatiteMancate[i - 1] = i;
                    flag++;
                }
                double cub = Math.Round(Math.Pow(i, 1.0 / 3.0));
                if (cub * cub * cub == i)
                {
                    if (flag == 0)
                    {
                        gem++;
                        clatiteMancate[i - 1] = i;
                    }
                }
            }

            return gem;
        }
        static int SumaDivizori(int N, int M, int[] clatiteMancate)
        {
            int inghetata = 0;
            for (int i = N + 1; i < M + 1; i++)
            {
                int sumaDivizorilor = 0;
                for (int j = 1; j < i; j++)
                {
                    if (i % j == 0)
                    {
                        sumaDivizorilor += j;
                    }
                }
                if (sumaDivizorilor == i)
                {
                    inghetata++;
                    clatiteMancate[i - 1] = i;
                }
            }
            return inghetata;
        }
        static int ClatiteZahar(int[] clatiteMancate)
        {
            int zahar = 0;
            for (int i = 0; i < clatiteMancate.Length; i++)
            {
                if (clatiteMancate[i] == 0)
                {
                    if ((i + 1) % 2 == 0)
                    {
                        zahar++;
                        clatiteMancate[i] = (i + 1);
                    }
                }
            }
            return zahar;
        }
        static int ClatiteSimple(int[] clatiteMancate)
        {
            int simple = 0;
            for (int i = 0; i < clatiteMancate.Length; i++)
            {
                if (clatiteMancate[i] == 0)
                {
                    if ((i + 1) % 2 != 0)
                    {
                        simple++;
                        clatiteMancate[i] = (i + 1);
                    }
                }
            }
            return simple;
        }
    }
}
