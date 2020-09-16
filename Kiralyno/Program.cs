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
            int sor = veletlen.Next(0, 8);
            int oszlop = veletlen.Next(0, 8);
            if (T[sor,oszlop]=='#')
            {
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

        public int UresOszlop()
        {
            return 0;
        }

        public int UresSor()
        {
            return 0;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Tabla t = new Tabla('#');

            Console.WriteLine("Üres tábla: ");
            t.Megjelenit();
            t.Elhelyez(1);
            Console.WriteLine();
            t.Megjelenit();

            Console.ReadKey();
        }
    }
}
