using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public void FajlbaIr()
        {

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

            if(t.UresOszlop(1) == true)
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

            Console.ReadKey();
        }
    }
}
