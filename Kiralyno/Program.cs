using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Kiralyno
{
    class Tabla
    {
        private char[,] T;//Deklarálás -> megmondjuk, hogy lesz valami, de nem adunk neki értéket.
        private char UresCella;
        private int UresOszlopokSzama;
        private int UresSorokSzama;

        public Tabla(char ch)//Konstruktor.
        {
            T = new char[8, 8];//Inicializálás -> megadjuk a méretet.
            UresCella = ch;
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    T[i, j] = UresCella;
                }
            }
        }

        public void Elhelyez(int N)
        {
            //1. Véletlen helyérték létrehozása.
            //      - Random osztály értékek halmaza: [0, 7]
            //      - Kell egy véletlen sor és egy véletlen oszlop.
            //      - Elhelyezzük a "K"-t, ha üres.
            Random veletlen = new Random();
            for (int i = 0; i < N; i++)
            {
                int sor = veletlen.Next(0, 8);
                int oszlop = veletlen.Next(0, 8);
                while (T[sor,oszlop]=='K')
                {
                    sor = veletlen.Next(0, 8);
                    oszlop = veletlen.Next(0, 8);
                }
                T[sor, oszlop] = 'K';
            }
        }

        public void FajlbaIr(StreamWriter fajl)
        {
            //fajl.WriteLine("Ez egy szöveg.");
            for (int i = 0; i < 8; i++)
            {
                string sor = "";
                for (int j = 0; j < 8; j++)
                {
                    sor += T[i, j];
                }
                fajl.WriteLine(sor);
            }
        }

        public void Megjelenit()
        {
            for (int i = 0; i < 8; i++)
            {
                Console.WriteLine();
                for (int j = 0; j < 8; j++)
                {
                    Console.Write(T[i, j]);
                }
            }
        }

        public bool UresOszlop(int oszlop)
        {
            bool van = true;
            for (int i = 0; i < 8; i++)
            {
                if (T[i, oszlop] == 'K')
                {
                    van = false;
                    break;
                }
            }
            return van;

            //int i = 0;
            //while (i < 8  && T[i, oszlop] !='K')
            //{
            //    i++;
            //}

            //if (i < 8)
            //{
            //    return false;
            //}
            //else
            //{
            //    return true;
            //}
        }

        public bool UresSor(int sor)
        {
            bool van = true;
            for (int i = 0; i < 8; i++)
            {
                if (T[sor, i] == 'K')
                {
                    van = false;
                    break;
                }
            }
            return van;

            //int i = 0;
            //while (i < 8 && T[sor, i] != 'K')
            //{
            //    i++;
            //}

            //if (i < 8)
            //{
            //    return false;
            //}
            //else
            //{
            //    return true;
            //}
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Tabla t = new Tabla('#');

            Console.WriteLine("Üres tábla: ");
            t.Megjelenit();
            t.Elhelyez(8);
            Console.WriteLine();
            t.Megjelenit();
            Console.WriteLine();

            if (t.UresOszlop(1) == true)
            {
                Console.WriteLine("A megadott oszlop üres.");
            }
            else
            {
                Console.WriteLine("A megadott oszlop nem üres.");
                
            }


            if (t.UresSor(1) == true)
            {
                Console.WriteLine("A megadott sor üres.");
            }
            else
            {
                Console.WriteLine("A megadott sor nem üres.");
            }

            //Console.Write("Melyik sor? ");
            //int sor = int.Parse(Console.ReadLine());
            //if (t.UresSor(sor))
            //{
            //    Console.WriteLine("A megadott sor üres.");
            //}
            //else
            //{
            //    Console.WriteLine("A megadott sor nem üres.");
            //}

            Console.WriteLine("Az üres oszlopok és sorok száma:");

            int UresSor = 0;
            int UresOszlop = 0;
            for (int i = 0; i < 8; i++)
            {
                if (t.UresSor(i) == true)
                {
                    UresSor++;
                }
                else if (t.UresOszlop(i) == true)
                {
                    UresOszlop++;
                }
            }
            Console.WriteLine("{0}, {1}", UresSor, UresOszlop);


            Tabla tab = new Tabla('#');
            Tabla[] tablak = new Tabla[64];

            StreamWriter ki = new StreamWriter("adatok.txt");
            for (int i = 0; i < 64; i++)
            {
                tablak[i] = new Tabla('*');
            }

            for (int i = 0; i < 64; i++)
            {
                tablak[i].Elhelyez(i + 1);
                tablak[i].FajlbaIr(ki);
                ki.WriteLine();
            }

            ki.Close();

            Console.ReadKey();
        }
    }
}
