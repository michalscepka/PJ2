using cv6.Comparers;
using System;
using System.Collections.Generic;

namespace cv6
{
    class Program
    {
        static void Main(string[] args)
        {
            ZasobnikSCustomEnumeratorem();
            ZasobnikYield();

            Comparers();
        }

        private static void ZasobnikSCustomEnumeratorem()
        {
            MujZasobnik stack = new MujZasobnik(20);
            stack.Push(5);
            stack.Push(-25);
            stack.Push(10);
            stack.Push(1);
            stack.Push(40);

            // toto funguje díky tomu, že MyStack implementuje rozhraní IEnumerable
            foreach (int item in stack)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();

            // foreach se kompiluje na tento kód (co myslíte, že bude rychlejší na procházení obyčejným polem? "for", nebo "foreach"? proč je for rychlejší)
            IEnumerator<int> stackEnumerator = stack.GetEnumerator();
            while (stackEnumerator.MoveNext())
            {
                Console.WriteLine(stackEnumerator.Current);
            }
            Console.WriteLine();
        }

        private static void ZasobnikYield()
        {
            // druhá možnost jak implementovat Ienumerable jepomocí slovíčka yield. Kompilátor nám následně sám vygeneruje enumerátor
            MujZasobnikYield stack = new MujZasobnikYield(20);
            stack.Push(5);
            stack.Push(-25);
            stack.Push(10);
            stack.Push(1);
            stack.Push(40);

            foreach (int item in stack)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();

            IEnumerator<int> stackEnumerator = stack.GetEnumerator();
            while (stackEnumerator.MoveNext())
            {
                Console.WriteLine(stackEnumerator.Current);
            }
            Console.WriteLine();
        }

        private static void Comparers()
        {
            int[] numbers = new int[] { 5, 2, -60, 30, 44, 21, 15, 4, 9, 3, 5, 80, 44 };

            Array.Sort(numbers, new SudaLichaComparer());
            Console.WriteLine("Suda a pak licha:");
            Console.WriteLine(string.Join(", ", numbers));

            Console.WriteLine();

            Array.Sort(numbers, new LichaSudaComparer());
            Console.WriteLine("Licha a pak suda:");
            Console.WriteLine(string.Join(", ", numbers));

            Console.WriteLine();

            Array.Sort(numbers, new DesitkovaCifraComparer());
            Console.WriteLine("Dle jednotkové dekadické cifry a v rámci skupin dle velikosti:");
            Console.WriteLine(string.Join(", ", numbers));

            Console.WriteLine();
        }
    }
}
