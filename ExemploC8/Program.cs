using System;
using System.Collections.Generic;
using System.Drawing;

namespace ExemploC8
{
    class Program
    {
        static void Main(string[] args)
        {
            MontaRanges(args);
        }

        static void MontaRanges(string[] args)
        {
            if (args == null)
            {
                throw new ArgumentNullException(nameof(args));
            }

            string[] tecnologias = new string[] { ".NET Core", "Angular", "ASP.NET Core", "Azure", "C#", "Docker" };

            ImprimirElementos(tecnologias[2..5],
                "Retornando elementos dos índices 2 a 4");

            Range range = 2..5;
            ImprimirElementos(tecnologias[range],
                "Retornando elementos dos índices 2 a 4 via struct Range");

            ImprimirElementos(tecnologias[0..5],
                "Retornando elementos dos índices 0 a 4");
            ImprimirElementos(tecnologias[..5],
                "Retornando até o elemento de posição 4 (desde a posição 0)");

            ImprimirElementos(tecnologias[1..^2],
                "Retornando elementos da posição 1 até o antepenúltimo");
            ImprimirElementos(tecnologias[1..^1],
                "Retornando elementos da posição 1 até o penúltimo");
            ImprimirElementos(tecnologias[..^1],
                "Retornando até o penúltimo elemento");

            Console.ReadKey();
        }

        private static void ImprimirElementos(string[] selecaoTecnologias,
            string mensagem)
        {
            Console.Write($"{mensagem}: [");

            foreach (string tecnologia in selecaoTecnologias)
            {
                Console.Write($"  *{tecnologia}*");
            }

            Console.Write("  ]" + Environment.NewLine);
        }

        static string GetString()
        {
            string test = "This is a test";
            test = null;
            return test;
        }

        static string GetNullableString()
        {
            string? test = "This is a test";
            test = null;
            return test;
        }

        static async IAsyncEnumerable<Person> GetAsync(IAsyncEnumerable<Person> people)
        {
            await foreach (var t in people)
            {
                yield return t;
            }
        }

        // Agora não há necessidade de ficar usando Take e Skip para selecionar uma porção específica do array
        static IEnumerable<Person> SliceArray(Person[] people)
        {
            List<Person> newList = new List<Person>();

            foreach (var person in people[1..5])
            {
                newList.Add(person);
            }

            foreach (var person in people[1..^2])
            {
                newList.Add(person);
            }

            return newList;
        }

        static string GetRecursivePatterns(Person person)
        {
            switch (person.Name, person.LastName)
            {
                case (string n, string s):
                    return $"{n} {s}";
                case (string n, null):
                    return n;
                case (null, string s):
                    return $"Sr. {s}";
                case (null, null):
                    return "Desconhecido";
            }
        }

        static string GetSwitchExpressions(Person person)
        {
            return (person.Name, person.LastName) switch
            {
                (string n, string s) => $"{n} {s}",
                (string n, null) => n,
                (null, string s) => $"Sr. {s}",
                (null, null) => "Desconhecido"
            };
        }

        //private Dictionary<string, string> dictionary = new ();

        static void GetImplicityNewExpressions()
        {
            //Point[] ps = { new (1, 4), new (3,-2), new (9, 5) };
            int[] data5 = { 1, 2, 3 };
            var a = new Func<int, bool>(a => a == 1);
            

        //Person[] pessoas = new
        //    {
        //        new ("Henrique", "Dal Bello"),
        //        new ("Bill", "Gates"),
        //        new ("Mark", "Zuckerberg")
        //    }
        }
    }

    internal class Person
    {
        public string Name { get; internal set; }
        public string LastName { get; internal set; }

        public Person(string name, string lastName)
        {
            Name = name;
            LastName = lastName;
        }
    }
}
