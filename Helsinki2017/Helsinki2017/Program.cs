using System;
using System.IO;

namespace Helsinki2017
{
    class Pasz
    {

        public struct adat
        {
            public string nev;
            public string okod;
            public double tecpon;
            public double kompon;
            public int hibap;
        }

        public void ÖsszPontszám(string nev, ref double sz)
        {
            string[] soroka = File.ReadAllLines("rovidprogram.csv");
            string[] sorokb = File.ReadAllLines("donto.csv");
            adat[] rp = new adat[soroka.Length - 1];
            adat[] donto = new adat[soroka.Length - 1];

            for (int i = 0; i < soroka.Length - 1; i++)
            {
                string[] sor = soroka[i + 1].Split(';');
                rp[i].nev = sor[0];
                rp[i].okod = sor[1];
                sor[2] = sor[2].Replace('.', ',');
                rp[i].tecpon = Convert.ToDouble(sor[2]);
                sor[3] = sor[3].Replace('.', ',');
                rp[i].kompon = Convert.ToDouble(sor[3]);
                rp[i].hibap = Convert.ToInt32(sor[4]);
            }

            for (int i = 0; i < sorokb.Length - 1; i++)
            {
                string[] sor = sorokb[i + 1].Split(';');
                donto[i].nev = sor[0];
                donto[i].okod = sor[1];
                sor[2] = sor[2].Replace('.', ',');
                donto[i].tecpon = Convert.ToDouble(sor[2]);
                sor[3] = sor[3].Replace('.', ',');
                donto[i].kompon = Convert.ToDouble(sor[3]);
                donto[i].hibap = Convert.ToInt32(sor[4]);
            }

            int index = -1;
            for (int i = 0; i < soroka.Length - 1; i++)
            {
                if (nev == rp[i].nev)
                {
                    index = i;
                }
            }

            sz = rp[index].tecpon + rp[index].kompon - rp[index].hibap;
            //Console.WriteLine(rp[index].tecpon+ ";"  + rp[index].kompon + ";" + rp[index].hibap + ";" + sz);
            int x = 0;
            bool van = true;
            while (van && x < (sorokb.Length - 1))
            {
                if (nev == donto[x].nev)
                {
                    van = false;
                    index = x;
                }
                x = x + 1;
            }
            //Console.WriteLine(van);
            if (!van)
            {
                sz = sz + donto[index].tecpon + donto[index].kompon - donto[index].hibap; 
            }
            //Console.WriteLine(sz);

        }

    }

    class Program
    {
        public struct adat
        {
            public string nev;
            public string okod;
            public double tecpon;
            public double kompon;
            public int hibap;
            public double psz;
        }

        static void Main(string[] args)
        {
            string[] soroka = File.ReadAllLines("rovidprogram.csv");
            string[] sorokb = File.ReadAllLines("donto.csv");
            adat[] rp = new adat[soroka.Length - 1];
            adat[] donto = new adat[soroka.Length - 1];

            for (int i = 0; i < soroka.Length - 1; i++)
            {
                string[] sor = soroka[i + 1].Split(';');
                //Console.WriteLine(soroka[i+1]);
                rp[i].nev = sor[0];
                rp[i].okod = sor[1];
                sor[2] = sor[2].Replace('.', ',');
                rp[i].tecpon = Convert.ToDouble(sor[2]);
                sor[3] = sor[3].Replace('.', ',');
                rp[i].kompon = Convert.ToDouble(sor[3]);
                rp[i].hibap = Convert.ToInt32(sor[4]);
            }

            for (int i = 0; i < sorokb.Length - 1; i++)
            {
                string[] sor = sorokb[i + 1].Split(';');
                donto[i].nev = sor[0];
                donto[i].okod = sor[1];
                sor[2] = sor[2].Replace('.', ',');
                donto[i].tecpon = Convert.ToDouble(sor[2]);
                sor[3] = sor[3].Replace('.', ',');
                donto[i].kompon = Convert.ToDouble(sor[3]);
                donto[i].hibap = Convert.ToInt32(sor[4]);
            }

            Console.WriteLine("2. feladat:");
            Console.WriteLine("\tA rövidprogramban " + (soroka.Length - 1) + " induló volt");

            Console.WriteLine("3. feladat:");
            bool van = false;
            for (int i = 0; i < soroka.Length-1; i++)
            {
                if (donto[i].okod == "HUN")
                {
                    van = true;
                }
            }
            if (van)
            {
                Console.WriteLine("\tA magyar versenyző bejutott a kűrbe");
            }
            else
            {
                Console.WriteLine("\tA magyar versenyző nem jutott be a kűrbe");
            }

            /*Console.WriteLine("4. feladat:");
            Pasz x = new Pasz();
            string nev = "Evgenia MEDVEDEVA";
            double sz = 0;
            x.ÖsszPontszám(nev, ref sz);
            Console.WriteLine(sz);*/


            Console.WriteLine("5. feladat:");
            Console.Write("\tKérem a versenyző nevét: ");
            string knev = Console.ReadLine();
            van = false;
            for (int i=0; i<soroka.Length-1;i++)
            {
                if (knev==rp[i].nev)
                {
                    van = true;
                }
            }

            if (!van)
            {
                Console.WriteLine("\tIlyen nevű induló nem volt");
            }
            else
            {
                Console.WriteLine("6. feladat:");
                Pasz x = new Pasz();
                double sz = 0;
                x.ÖsszPontszám(knev, ref sz);
                Console.WriteLine("\tA versenyző összpontszáma: " + sz);
            }

            Console.WriteLine("7. feladat:");
            string[] orszag = new string[sorokb.Length-1];
            int v = 0;
            int[] szam = new int[sorokb.Length - 1];
            for (int i=0; i<sorokb.Length-1;i++)
            {
                if (v==0)
                {
                    orszag[v] = donto[i].okod;
                    v++;
                }
                else
                {
                    int j = 0;
                    van = true;
                    while (van && j<v)
                    {
                        if (orszag[j]==donto[i].okod)
                        {
                            van = false;
                        }
                        j++;
                    }
                    if (van)
                    {
                        orszag[v] = donto[i].okod;
                        v++;
                    }
                }
            }


            for (int i = 0; i < v; i++)
            {
                for (int b=0;b<sorokb.Length-1;b++)
                {
                    if (orszag[i]==donto[b].okod)
                    {
                        szam[i]++;
                    }
                }
            }

            for (int i = 0; i < v; i++)
            {
                if (szam[i]>1)
                Console.WriteLine("\t"+orszag[i]+": "+ szam[i]+ " versenyző");
            }
            Pasz po = new Pasz();
            double d = 0;
            double[] p = new double[sorokb.Length - 1];
            string pop ="";
            for (int i=0;i<sorokb.Length-1;i++)
            {
                pop = donto[i].nev;
                d = 0;
                po.ÖsszPontszám(pop, ref d);
                donto[i].psz = d;
                p[i] = d;
            }

            int g = 0;
            string[] ki =new string[sorokb.Length - 1];
            Array.Sort(p);
            for (int i=sorokb.Length-2;i>=0;i--)
            {
                for (int h=0;h<sorokb.Length;h++)
                {
                    if (p[i]==donto[h].psz)
                    {

                        ki[g] = (g+1) + ";" + donto[h].nev + ";" + donto[h].okod + ";" + Math.Round(p[i],2); 
                        g++;
                    }
                }
            }
            File.WriteAllLines("vegeredmeny.csv",ki);
            
            
            


            Console.ReadLine();
        }
    }
}
