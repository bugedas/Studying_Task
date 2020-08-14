using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2
{
    class Program
    {


        int[] x;
        int[] y;
        HashSet<int> kaina = new HashSet<int>();

        static void Main(string[] args)
        {

            Program p = new Program();

            //------------------------------------------
            // Atkomentuoti viena ir paleisti programa!     Uncomment one and run
            //------------------------------------------




            //p.Pirma();      // 1 dalis    (1st task)

            //p.PirmaAntra(); // 1 dalis paraleliniu budu   (1st task in parallel)

            //p.AntraGera();    // 2 dalis  (2nd task)








        }

        public void AntraGera()
        {
            int[] val;
            int[] wt;

            Console.WriteLine("Irasykite skaiciu n:");
            int n = int.Parse(Console.ReadLine());

            Random r = new Random();
            wt = randomNumsAntra(n, r);
            val = randomNumsAntra(n, r);

            Console.WriteLine("Atsitiktiniai val(kainos) skaiciai:");
            for (int i = 0; i < n; i++)
            {
                Console.Write(val[i] + " | ");
            }
            Console.WriteLine();

            Console.WriteLine("Atsitiktiniai wt(svorio) skaiciai:");
            for (int i = 0; i < n; i++)
            {
                Console.Write(wt[i] + " | ");
            }
            Console.WriteLine();
            Console.WriteLine();

            Console.WriteLine("Irasykite skaiciu W:");
            int W = int.Parse(Console.ReadLine());
            Console.WriteLine();
            Console.WriteLine();

            var watch = new System.Diagnostics.Stopwatch();
            watch.Start();
            Console.WriteLine("Atsakymas: " + FSvoris(W, wt, val, n));
            watch.Stop();
            Console.WriteLine();
            Console.WriteLine($"Execution Time Second task: {watch.ElapsedMilliseconds} ms");
            Console.WriteLine();
        }
    

        public int max(int a, int b)
        {
            return (a > b) ? a : b;
        }

        
        public int FSvoris(int W, int[] wt, int[] val, int n)
        {
            int i, w;
            int[,] K = new int[n + 1, W + 1];
            
            for (i = 0; i <= n; i++)
            {
                for (w = 0; w <= W; w++)
                {
                    if (i == 0 || w == 0)
                        K[i, w] = 0;
                    else if (wt[i - 1] <= w)
                        K[i, w] = max(
                            val[i - 1]
                                + K[i - 1, w - wt[i - 1]],
                            K[i - 1, w]);
                    else
                        K[i, w] = K[i - 1, w];
                }
            }

            return K[n, W];
        }

       


        public void Antra()
        {

            Console.WriteLine("Irasykite skaiciu n:");
            int n = int.Parse(Console.ReadLine());

            Random r = new Random();
            y = randomNumsAntra(n, r);
            x = randomNumsAntra(n, r);

            Console.WriteLine("Atsitiktiniai Yn(kainos) skaiciai:");
            for (int i = 0; i < n ; i++)
            {
                Console.Write(y[i] + " | ");
            }
            Console.WriteLine();

            Console.WriteLine("Atsitiktiniai Xm(svorio) skaiciai:");
            for (int i = 0; i < n ; i++)
            {
                Console.Write(x[i] + " | ");
            }
            Console.WriteLine();
            Console.WriteLine();

            Console.WriteLine("Irasykite skaiciu W:");
            int w = int.Parse(Console.ReadLine());
            Console.WriteLine();
            Console.WriteLine();

            int[] xTemp = x;

            AF(n, xTemp, w, 0);

            Console.WriteLine("Maksimali suma: " + kaina.Max());

            for (int i =0; i < i+2; i++)
            {
                Console.WriteLine();
                Console.WriteLine("Spauskite enter jei norite baigti arba irasykite kita W skaiciu:");
                string z = Console.ReadLine();
                if (z == "")
                {
                    break;
                }
                else
                {
                    w = int.Parse(z);
                    xTemp = x;
                    kaina = new HashSet<int>();
                    AF(n, xTemp, w, 0);
                    
                    Console.WriteLine("Maksimali suma: " + kaina.Max());
                }
            }

            //foreach (int i in kaina)
            //{
            //    Console.WriteLine(i);

            //}



        }

        public void AF(int n, int[] SOld, int W, int Price)
        {

            int[] S = new int[n];
            for (int i = 0; i < n; i++)
            {
                S[i] = SOld[i];
            }

            for(int i = 0; i < n; i++)
            {

                if ( W - S[i] >= 0 && S[i] != 0)
                {
                    
                    int sTemp = S[i];
                    S[i] = 0;

                    AF(n, S, W - sTemp, Price + y[i]);
                    
                }
                else
                {
                    kaina.Add(Price);
                }
            }
        }

        public int[] randomNumsAntra(int n, Random r)
        {


            int[] ns = new int[n];

            for (int i = 0; i < n; i++)
            {
                ns[i] = r.Next(1, 300);
            }

            return ns;

        }


        public void PirmaAntra()
        {

            Console.WriteLine("Irasykite skaiciu n:");
            int n = int.Parse(Console.ReadLine());

            Console.WriteLine("Irasykite skaiciu m:");
            int m = int.Parse(Console.ReadLine());

            Random r = new Random();

            y = randomNums(n, r);
            x = randomNums(m, r);

            Console.WriteLine("Atsitiktiniai Yn skaiciai:");
            for (int i = 1; i < n + 1; i++)
            {
                Console.Write(y[i] + " | ");
            }
            Console.WriteLine();

            Console.WriteLine("Atsitiktiniai Xm skaiciai:");
            for (int i = 1; i < m + 1; i++)
            {
                Console.Write(x[i] + " | ");
            }
            Console.WriteLine();
            Console.WriteLine();

            var watch = new System.Diagnostics.Stopwatch();
            watch.Start();
            Console.WriteLine("Rezultatas su atsitiktiniais skaiciais (Dinaminiu budu): " + FDyn(m, x, n, y));
            watch.Stop();
            Console.WriteLine();
            Console.WriteLine($"Execution Time Dynamic: {watch.ElapsedMilliseconds} ms");
            Console.WriteLine();
        }

        static int FDyn(int m, int[] x, int n, int[] y)
        {
            int[,] F = new int[m + 1, n + 1];

            for (int i = 0; i <= m; i++) // IF n = 0, tai F(i,j) = m
                F[i, 0] = i;
            for (int i = 1; i <= n; i++) // IF m = 0, ir n > 0 tai F(i,j) = n
                F[0, i] = i;

            for (int i = 1; i <= m; i++) // Else
            {
                for (int j = 1; j <= n; j++)
                {
                    F[i, j] = Math.Min(1 + F[i-1,j], Math.Min(1 + F[i, j - 1], DDyn(x[i - 1], y[j - 1]) + F[i - 1, j - 1]));
                    
                }
            }

            return F[m, n];
        }

        static int DDyn(int a, int b)
        {
            if (a == b)
                return 1;
            else return 0;
        }


        public void Pirma()
        {

            Console.WriteLine("Irasykite skaiciu n:");
            int n = int.Parse(Console.ReadLine());

            Console.WriteLine("Irasykite skaiciu m:");
            int m = int.Parse(Console.ReadLine());

            Random r = new Random();

            y = randomNums(n, r);
            x = randomNums(m, r);

            Console.WriteLine("Atsitiktiniai Yn skaiciai:");
            for (int i = 1; i < n + 1; i++)
            {
                Console.Write(y[i] + " | ");
            }
            Console.WriteLine();

            Console.WriteLine("Atsitiktiniai Xm skaiciai:");
            for (int i = 1; i < m + 1; i++)
            {
                Console.Write(x[i] + " | ");
            }
            Console.WriteLine();
            Console.WriteLine();

            var watch = new System.Diagnostics.Stopwatch();
            watch.Start();
            Console.WriteLine("Rezultatas su atsitiktiniais skaiciais: " + F(m, n));
            watch.Stop();
            Console.WriteLine();
            Console.WriteLine($"Execution Time Recursive: {watch.ElapsedMilliseconds} ms");
            Console.WriteLine();
        }



        public int[] randomNums(int n, Random r)
        {

            
            int[] ns = new int[n+1];

            for (int i = 1; i < n+1; i++)
            {
                ns[i] = r.Next(1, 300);
            }

            return ns;

        }


        public int F(int m, int n)
        {
            

            if (n == 0)
            {
                return m;
            }
            else if(m == 0 && n > 0)
            {
                return n;
            }
            else
            {
                
                return Math.Min(  1 + F(m - 1, n),  Math.Min(  1 + F(m, n - 1), D(m, n) + F(m - 1, n - 1)));

            }

        }


        public int D(int i, int j)
        {

            if (x[i] == y[j])
            {
                
                return 1;
            }
            else
            {
                
                return 0;
            }

        }


        class Custom
        {
            public int data { get; set; }
        }

        public int FParallel(int m, int n)
        {
            if (n == 0)
            {
                return m;
            }
            else if (m == 0 && n > 0)
            {
                return n;
            }
            else
            {
                var tasks = new Task[3];

                tasks[0] = Task.Factory.StartNew((Object s) => { (s as Custom).data = 1 + F(m - 1, n); }, new Custom());    //a

                tasks[1] = Task.Factory.StartNew((Object s) => { (s as Custom).data = 1 + F(m, n - 1); }, new Custom());    //b
                tasks[2] = Task.Factory.StartNew((Object s) => { (s as Custom).data = D(m, n) + F(m - 1, n - 1); }, new Custom());    //c

                Task.WaitAll(tasks);


                return Math.Min((tasks[0].AsyncState as Custom).data, Math.Min((tasks[1].AsyncState as Custom).data, (tasks[2].AsyncState as Custom).data));

            }

        }



    }
}
