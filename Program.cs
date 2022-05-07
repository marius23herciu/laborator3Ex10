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
            if (M<1)
            {
                Console.Write("Macar o clatita a facut si bunica lui Arpsod, pune un numar mai mare de 0 :).");
                return;
            }
            
            int ciocolata = NumerePrime(N, M);
            int gem = PatratSauCubPerfect(N, M);
            int inghetata = SumaDivizori(N, M);

            int totalClatite = ciocolata + gem + inghetata;
            Console.WriteLine("Arpsod a mancat " + ciocolata + " clatite cu ciocolata, ");
            Console.WriteLine(gem + " clatite cu gem ");
            Console.WriteLine("si " + inghetata + " clatite cu inghetata.");
            Console.WriteLine("In total: " + totalClatite);
        }

        static int NumerePrime(int N, int M)
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
                        break;
                    }
                    else
                    {
                        flag++;
                        ciocolata++;
                        break ;
                    }
                }
                if (flag==0)
                {
                    ciocolata++;
                }
            }

            //for (int i = N; i < M+1; i++)
            //{
            //    if (i <= 1)
            //    {
            //        continue;
            //    }
            //    if (i == 2)
            //    {
            //        ciocolata++;
            //        continue;
            //    }
            //    if (i % 2 == 0)
            //    {
            //        continue;
            //    }

            //    var boundary = (int)Math.Floor(Math.Sqrt(i));

            //    for (int j  = 3; j <= boundary; j += 2)
            //    {
            //        if (i % j == 0)
            //        {
            //            continue;
            //        }
            //        else
            //        {
            //            ciocolata++;
            //            continue;
            //        }

            //    }

            //}
            return ciocolata;
        }
        static int PatratSauCubPerfect(int N,int M)
        {
            int gem = 0;
            for (int i = N; i < M+1; i++)
            {
                double radacinaPatrata = Math.Sqrt(i);

                if (radacinaPatrata % 1 == 0)
                {
                    gem++;
                }
                double cub = Math.Round(Math.Pow(i, 1.0 / 3.0));
                if (cub * cub * cub == i)
                {
                    gem++;
                }
            }
            return gem;
        }
        static int SumaDivizori(int N,int M)
        {
            int inghetata = 0;
            for (int i = N+1; i < M+1; i++)
            {
                int sumaDivizorilor = 0;
                for (int j = 1; j < i; j++)
                {
                    if (i%j==0)
                    {
                        sumaDivizorilor += j;
                    }
                }
                if (sumaDivizorilor==i)
                {
                    inghetata++;
                }
            }
            return inghetata;
        }
    }
}
