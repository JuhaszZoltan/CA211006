using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA211006
{
    interface IVersenyenLevoCucc
    {
        string GetInfo();
    }


    class Hal : IVersenyenLevoCucc
    {
        public string Fajta { get; set; }
        public float Suly { get; set; }
        public (int Felso, int Also) UszasiMelyseg { get; set; }

        public string GetInfo()
        {
            return $"{Fajta} {Suly} Kg [{UszasiMelyseg.Also}-{UszasiMelyseg.Felso}] m\n";
        }
    }

    class Horgasz : IVersenyenLevoCucc
    {
        public string Nev { get; set; }
        public List<Hal> KifogottHalak { get; set; } = new List<Hal>();
        public DateTime SzuletesiIdo { get; set; }
        public string SzuletesiHely { get; set; }

        public string GetInfo()
        {
            string info = $"{Nev} ({DateTime.Now.Year - SzuletesiIdo.Year} éves)\n";
            foreach (var h in KifogottHalak)
                info += $"\t{h.GetInfo()}";
            return info;
        }
    }

    class Program
    {

        static List<Hal> To = new List<Hal>()
        {
            new Hal() { Fajta = "sügér", Suly = 20.5F, UszasiMelyseg = (20, 100), },
            new Hal() { Fajta = "harcsa", Suly = 8F, UszasiMelyseg = (0, 40), },
            new Hal() { Fajta = "ponty", Suly = 11F, UszasiMelyseg = (10, 60), },
            new Hal() { Fajta = "ponty", Suly = 12F, UszasiMelyseg = (10, 70), },
            new Hal() { Fajta = "pisztráng", Suly = 31F, UszasiMelyseg = (50, 60), },
        };

        static List<Horgasz> Versenyzok = new List<Horgasz>()
        {
            new Horgasz() { Nev = "Laci", SzuletesiHely = "Bivalytasznádi", SzuletesiIdo = new DateTime(1972, 10, 06) },
            new Horgasz() { Nev = "Józsi", SzuletesiHely = "Iklad", SzuletesiIdo = new DateTime(1968, 03, 22) },
            new Horgasz() { Nev = "Bagyi", SzuletesiHely = "Szarvas", SzuletesiIdo = new DateTime(2003, 01, 01) },
        };
        static void Main(string[] args)
        {
            Versenyzok[0].KifogottHalak.Add(To[0]);
            To.Remove(Versenyzok[0].KifogottHalak[0]);

            Versenyzok[0].KifogottHalak.Add(To[0]);
            To.Remove(Versenyzok[0].KifogottHalak[1]);

            Versenyzok[1].KifogottHalak.Add(To[1]);
            To.Remove(Versenyzok[1].KifogottHalak[0]);

            //Console.Write(Versenyzok[0].GetInfo());

            //Console.Write(To[0].GetInfo());

            var cuccok = new List<IVersenyenLevoCucc>();

            cuccok.AddRange(To);
            cuccok.AddRange(Versenyzok);

            foreach (var cucc in cuccok)
            {
                if (cucc is Hal) Console.Write("Hal: ");
                else if (cucc is Horgasz) Console.Write("Horgász: ");
                Console.Write(cucc.GetInfo());
            }

            Console.ReadKey();
        }
    }
}
