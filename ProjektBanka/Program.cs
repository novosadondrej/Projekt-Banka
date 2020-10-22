using System;
using System.Threading;
using System.IO;
using System.Linq;
using System.Text;
using System.Net.Http.Headers;
using System.Collections;
using System.Collections.Generic;

namespace BankaV2
{
    class Program
    {
        static void Main(string[] args)
        {
            new Program().run();
        }

        List<Ucet> vsechnyUcty = new List<Ucet>();
        Ucet aktivni;

        void prvniVklad(Ucet ucet)
        {
            Console.Write("Zadejte jméno: ");
            ucet.name = Console.ReadLine();
            string spatnecislo = "ne";
            while (spatnecislo == "ne")
            {


                Console.Write("Zadejte výši prvního vkladu: ");
                string PrvniVklad = Console.ReadLine();
                double number;
                bool uspech = double.TryParse(PrvniVklad, out number);
                if (uspech)
                {


                    ucet.vklad(number);
                    Console.WriteLine("Úspěšně jste vložil : {0} Kč", number);
                    Console.WriteLine("Jméno účtu {0} - Zůstatek účtu : {1} Kč", ucet.jmeno(), ucet.zustatek());
                    using (StreamWriter zapis = new StreamWriter("ucty.txt", true))
                    {
                        zapis.WriteLine(ucet.toPipeOutput());
                    }
                    Console.WriteLine("Zmáčknutím ENTERu se vrátíte do Lobby");
                    Console.ReadLine();
                    spatnecislo = "ano";
                }
                else
                {
                    Console.WriteLine("Zadal jste špatné číslo");
                    Console.WriteLine("Zmáčknutím ENTERu opakujete akci");
                    Console.ReadLine();
                }
                Console.Clear();
            }
        }

        void prvniVkladNeboVyber(Ucet uverovy)
        {
            Console.Write("Zadejte jméno : ");
            uverovy.name = Console.ReadLine();
            string moznost = "ano";
            while (moznost == "ano")
            {
                Console.WriteLine("Pro výběr - v, pro vklad - d");
                string rl2 = Console.ReadLine();

                if (rl2 == "v")
                {
                    Console.WriteLine("Zůstatek účtu : {0}", uverovy.zustatek());
                    string spatnecislo = "ne";
                    while (spatnecislo == "ne")
                    {


                        Console.Write("Kolik si přejete vybrat? : ");
                        string PrvniVklad = Console.ReadLine();
                        double number;
                        bool uspech = double.TryParse(PrvniVklad, out number);
                        if (uspech)
                        {
                            uverovy.vyber(number);
                            Console.WriteLine("Úspěšně jste vybral : {0} Kč", number);
                            Console.WriteLine("Jméno účtu {0} - Zůstatek účtu : {1} Kč", uverovy.jmeno(), uverovy.zustatek());
                            using (StreamWriter zapis = new StreamWriter("ucty.txt", true))
                            {
                                zapis.WriteLine(uverovy.toPipeOutput());
                            }
                            Console.WriteLine("Zmáčknutím ENTERu se vrátíte do Lobby");
                            Console.ReadLine();
                            moznost = "ne";
                            spatnecislo = "ano";
                        }
                        else
                        {
                            Console.WriteLine("Zadal jste špatné číslo : ");
                            Console.WriteLine("Zmáčknutím ENTERu opakujete akci");
                            Console.ReadLine();
                        }
                        Console.Clear();
                    }
                }

                else if (rl2 == "d")
                {
                    string spatnecislo = "ne";
                    while (spatnecislo == "ne")
                    {


                        Console.Write("Zadejte výši prvního vkladu: ");
                        string PrvniVklad = Console.ReadLine();
                        double number;
                        bool uspech = double.TryParse(PrvniVklad, out number);
                        if (uspech)
                        {
                            uverovy.vklad(number);
                            Console.WriteLine("Úspěšně jste vložil : {0} Kč", number);
                            Console.WriteLine("Jméno účtu {0} - Zůstatek účtu : {1} Kč", uverovy.jmeno(), uverovy.zustatek());
                            using (StreamWriter zapis = new StreamWriter("ucty.txt", true))
                            {
                                zapis.WriteLine(uverovy.toPipeOutput());
                            }
                            Console.WriteLine("Zmáčknutím ENTERu se vrátíte do Lobby");
                            Console.ReadLine();
                            moznost = "ne";
                            spatnecislo = "ano";
                        }
                        else
                        {
                            Console.WriteLine("Zadal jste špatné číslo : ");
                            Console.WriteLine("Zmáčknutím ENTERu opakujete akci");
                            Console.ReadLine();
                        }
                        Console.Clear();
                    }
                }
            }
        }

        void vkladNeboVyber(Ucet ucet)
        {
            Console.WriteLine("Pro výběr - v, pro vklad - d");
            string rl2 = Console.ReadLine();

            if (rl2 == "v")
            {
                Console.WriteLine("Zůstatek účtu : {0}", ucet.zustatek());
                string spatnecislo = "ne";
                while (spatnecislo == "ne")
                {
                 
                    Console.Write("Kolik si přejete vybrat? : ");
                    string PrvniVklad = Console.ReadLine();
                    double number;
                    bool uspech = double.TryParse(PrvniVklad, out number);
                    if (uspech)
                    {
                        ucet.vyber(number);
                        Console.WriteLine("Úspěšně jste vybral : {0} Kč", number);
                        Console.WriteLine("Jméno účtu {0} - Zůstatek účtu : {1} Kč", ucet.jmeno(), ucet.zustatek());
                        ulozUcty();
                        Console.WriteLine("Zmáčknutím ENTERu se vrátíte do Lobby");
                        Console.ReadLine();
                        spatnecislo = "ano";
                    }
                    else
                    {
                        Console.WriteLine("Zadal jste špatné číslo : ");
                        Console.WriteLine("Zmáčknutím ENTERu opakujete akci");
                        Console.ReadLine();
                    }
                    Console.Clear();
                }
            }
 
            else if (rl2 == "d")
            {
                string spatnecislo = "ne";
                while (spatnecislo == "ne")
                {


                    Console.Write("Zadejte výši vkladu: ");
                    string PrvniVklad = Console.ReadLine();
                    double number;
                    bool uspech = double.TryParse(PrvniVklad, out number);
                    if (uspech)
                    {
                        ucet.vklad(number);
                        Console.WriteLine("Úspěšně jste vložil : {0} Kč", number);
                        Console.WriteLine("Jméno účtu {0} - Zůstatek účtu : {1} Kč", ucet.jmeno(), ucet.zustatek());
                        ulozUcty();
                        Console.WriteLine("Zmáčknutím ENTERu se vrátíte do Lobby");
                        Console.ReadLine();
                        spatnecislo = "ano";
                    }
                    else
                    {
                        Console.WriteLine("Zadal jste špatné číslo : ");
                        Console.WriteLine("Zmáčknutím ENTERu opakujete akci");
                        Console.ReadLine();
                    }
                    Console.Clear();
                }
            }
        }

        void ulozUcty()
        {
            using (StreamWriter zapis = new StreamWriter("ucty.txt", false))
            {
                foreach (Ucet ucet in vsechnyUcty)
                {
                    zapis.WriteLine(ucet.toPipeOutput());
                }
            }
        }

        void nactiUcty()
        {
            vsechnyUcty.Clear();
            var ucty = new List<Ucet>() { new Sporici(), new SporiciStudent(), new Uverovy() };
            using (StreamReader cti = new StreamReader("ucty.txt"))
            {
                while (!cti.EndOfStream)
                {
                    var line = cti.ReadLine();
                    Ucet ucet;
                    foreach (Ucet item in ucty)
                    {
                        if (item.tryParse(line, out ucet))
                        {
                            vsechnyUcty.Add(ucet);
                        }
                    }
                }
            }
        }

        void run()
        {
            Console.WriteLine("Vítejte v bance! :)");
            string zacatek = "ano";
            while (zacatek == "ano")
            {
                Console.WriteLine("Co chcete udělat?");
                //Lobby
                Console.WriteLine(@"q - Založit nový účet
w - vybrat nebo vložit peníze na stávající účet
e - posun v čase( měsíc )");
                string rl = Console.ReadLine();

                //zacatek Vyberu "Co chces delat?"
                if (rl == "q")
                {
                    //Založení nového účtu

                    string ucet = "ano";
                    while (ucet == "ano")
                    {
                        Console.WriteLine(@"a - Spořící
b - Spořící studentský
c - Úvěrový");
                        string rl1 = Console.ReadLine();
                        if (rl1 == "a")
                        {
                            //Zalozeni sporiciho uctu


                            Sporici sporici = new Sporici();
                            prvniVklad(sporici);
                            ucet = "ne";
                        }

                        else if (rl1 == "b")
                        {
                            //Zalozeni studentskeho sporiciho uctu

                            SporiciStudent sporiciStudent = new SporiciStudent();
                            prvniVklad(sporiciStudent);
                            ucet = "ne";
                        }

                        else if (rl1 == "c")
                        {
                            //zalozeni uveroveho uctu

                            Uverovy uverovy = new Uverovy();
                            prvniVkladNeboVyber(uverovy);

                            ucet = "ne";
                        }
                        else
                        {
                            Console.WriteLine("Zadali jste špatnou možnost");
                            Console.WriteLine("Zmáčknutím ENTERu opakujete akci");
                            Console.ReadLine();
                        }
                    }

                    //return na zacatek
                }
                else if (rl == "w")
                {
                    Console.Clear();
                    nactiUcty();

                    aktivni = null;
                    while (aktivni == null)
                    {
                        var counter = 1;
                        foreach (var item in vsechnyUcty)
                        {
                            Console.WriteLine(counter++ + ". " + item);
                        }
                        Console.WriteLine("Jaký si chcete vybrat řádek?");
                        string cisloRadku = Console.ReadLine();
                        int radek;
                        var uspech = int.TryParse(cisloRadku, out radek);
                        if (uspech && radek >= 1 && radek < counter)
                        {
                            aktivni = vsechnyUcty[radek - 1];
                            Console.WriteLine(aktivni);
                            Console.ReadLine();
                            vkladNeboVyber(aktivni);
                        }
                        else
                        {
                            Console.WriteLine("Dany ucet nebyl nacten!");
                            Console.ReadLine();
                        }
                        Console.Clear();
                    }
                }
                else if (rl == "e")
                {

                }
                else
                {
                    Console.WriteLine("Zadali jste špatnou možnost");
                    Console.WriteLine("Zmáčknutím ENTERu opakujete akci");
                    Console.ReadLine();
                }
                Console.Clear();

            }

        }
    }

    abstract class Ucet
    {
        public string name { get; set; }
        protected double balance { get; set; }
        protected string type { get; set; }

        virtual public double vklad(double vklad)
        {
            balance = balance + vklad;
            return balance;
        }

        virtual public double vyber(double vyber)
        {
            balance = balance - vyber;
            return balance;
        }
        public string jmeno()
        {
            return name;
        }

        public double zustatek()
        {
            return balance;
        }

        public virtual string toPipeOutput()
        {
            //                    0        1        2
            return string.Format("Name:{0}|Type:{1}|Balance:{2}", this.name, this.type, this.balance);
        }

        public virtual bool tryParse(string line, out Ucet ucet)
        {
            var result = false;
            ucet = null;
            if (line.Contains("|Type:" + this.type + "|"))
            {
                result = true;
                var pole = line.Split("|");
                double number;
                bool uspech = double.TryParse(pole[2].Split(":", 2)[1], out number);
                if (uspech)
                {
                    ucet = vytvorUcet();
                    ucet.name = pole[0].Split(":", 2)[1];
                    ucet.type = pole[1].Split(":", 2)[1];
                    ucet.balance = number;
                }
            }
            return result;
        }

        abstract public Ucet vytvorUcet();

        abstract public double mesicni();

    }

    class Sporici : Ucet
    {
        public Sporici()
        {
            this.type = "Sporici";
        }

        public override double mesicni()
        {
            balance += balance * 0.001f;
            return balance;
        }

        public override double vyber(double vyber)
        {
            if (vyber > balance)
            {
                Console.WriteLine("Výběr {0} Kč je větší než zůstatek {1}!", vyber, balance);
            }
            else
            {
                balance = balance - vyber;
            }
            return balance;
        }

        public override Ucet vytvorUcet()
        {
            return new Sporici();
        }

        public override string ToString()
        {
            return "Název účtu : " + name + " zůstatek : " + balance + " Spořící účet";
        }
    }

    class SporiciStudent : Ucet
    {
        private double maxvyber = 1000;

        public SporiciStudent()
        {
            this.type = "SporiciStudent";
        }

        public override Ucet vytvorUcet()
        {
            return new SporiciStudent();
        }

        public override double vyber(double vyber)
        {
            if (vyber > maxvyber)
            {
                Console.WriteLine("Maximální výběr je 1000 Kč!");
            }
            else if (vyber > balance)
            {
                Console.WriteLine("Výběr {0} Kč je větší než zůstatek {1}!", vyber, balance);
            }
            else
            {
                balance = balance - vyber;
            }
            return balance;
        }

        public override double mesicni()
        {
            balance += balance * 0.003f;
            return balance;
        }

        public override string ToString()
        {
            return Convert.ToString("Název účtu : " + name + " zůstatek : " + balance + " Studetský spořící účet");
        }

    }

    class Uverovy : Ucet
    {
        public Uverovy()
        {
            this.type = "Uverovy";
        }

        public override Ucet vytvorUcet()
        {
            return new Uverovy();
        }

        public override double mesicni()
        {
            if (balance < 0)
            {
                balance -= balance * 0.05f;
                return balance;
            }
            else
            {
                return balance;
            }
        }

        public override string ToString()
        {
            return Convert.ToString("Název účtu : " + name + " zůstatek : " + balance + " Úvěrový účet");
        }

    }

}
