using System;

namespace Laboratorio9
{
    class Program
    {
        static void Main(string[] args)
        {
            TermometroLimite term = new TermometroLimite(5);
            Console.WriteLine(term.ToString());

            term.LimiteSuperiorEvent += new TermometroLimite.MeuDelegate(TrataLimiteSuperior);
            term.TempVoltouNormal += new TermometroLimite.MeuDelegate(TrataTempNormal);

            term.Aumentar(6);
            Console.WriteLine(term.ToString());
            term.Diminuir(2);
            Console.WriteLine(term.ToString());
            term.Diminuir(3);
            Console.WriteLine(term.ToString());
            term.Aumentar(7);
            Console.WriteLine(term.ToString());
            term.Diminuir(4);
            Console.WriteLine(term.ToString());
        }

        public static void TrataLimiteSuperior(string msg)
        {
            Console.WriteLine(msg);
        }

        public static void TrataTempNormal(string msg)
        {
            Console.WriteLine(msg);
        }
    }
}
