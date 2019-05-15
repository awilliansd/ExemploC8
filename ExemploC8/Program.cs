using System;
using System.Collections.Generic;

namespace ExemploC8
{
    class Program
    {
        static void Main(string[] args)
        {
            MontaRanges(args);

            Person bassam = new Person("Alessandro", "Dias");

            if (bassam is Person { Name: "Bassam Alugili", LastName: "Mohamed" })
            {
                Console.WriteLine($"The employee: {bassam.Name} , LastName {bassam.LastName}");
            }

            var employee = new Employee();
            var firstEmployee = new Employee();


            if (firstEmployee.GetType() == typeof(Employee))
			{
				employee = (Employee)firstEmployee;

				if (employee.Name == "Bassam Alugili" && employee.Age == 42) 
				{
					Console.WriteLine($"The employee: {employee.Name} , Age {employee.Age}");
				}
			}

            // Or we can do it like this:

            employee = firstEmployee as Employee;

            if (employee != null) 
			{
				if (employee.Name == "Bassam Alugili" && employee.Age == 42) 
				{
				    Console.WriteLine($"The employee: {employee.Name} , Age {employee.Age}");
				}
			}
        }

        static void MontaRanges(string[] args)
        {
            if (args == null)
                throw new ArgumentNullException(nameof(args));

            string[] tecnologias = new string[] { ".NET Core", "Angular", "ASP.NET Core", "Azure", "C#", "Docker" };

            // Range ilimitado
            //array[start..]  // Get items start-1 with the rest of the array
            //array[..end]    // Get items from the beginning until end-1
            //array[..]       // A Get the whole array

			// Range positivos
			var fiveToEnd = 5..;      // Equivalent to Range.From(5) i.e. missing upper bound
			var startToTen = ..1;     // Equivalent to Range.ToEnd(1). Missing lower bound. Result: 0, 1
			var everything1 = ..;      // Equivalent to Range.All. Missing upper and lower bound. Result: 0..Int.Max
			var everything2 = 5..11; // Equivalent to Range.Create(5, 11)

			var collection1 = new [] { 'a', 'b', 'c' };
			// collection[2..];  // Result chars: c
			// collection[..2];  // Result chars: a, b
			// collection[..];   // Result chars: a, b, c 

			// Range negativos
			var collection2 = new [] { 'a', 'b', 'c' };
			// collection[-2..2];  // Result chars: b, c
			// collection[-1..];   // Result chars: c
			// collection[-3..-1]; // Result chars: a, b

            ImprimirElementos(tecnologias[2..5], "Retornando elementos dos índices 2 a 4");

            Range range = 2..5;

            ImprimirElementos(tecnologias[range], "Retornando elementos dos índices 2 a 4 via struct Range");
            ImprimirElementos(tecnologias[0..5], "Retornando elementos dos índices 0 a 4");
            ImprimirElementos(tecnologias[..5], "Retornando até o elemento de posição 4 (desde a posição 0)");
            ImprimirElementos(tecnologias[1..^2], "Retornando elementos da posição 1 até o antepenúltimo");
            ImprimirElementos(tecnologias[1..^1], "Retornando elementos da posição 1 até o penúltimo");
            ImprimirElementos(tecnologias[..^1], "Retornando até o penúltimo elemento");

            Console.ReadKey();
        }

        private static void ImprimirElementos(string[] selecaoTecnologias, string mensagem)
        {
            Console.Write($"{mensagem}: [");

            foreach (string tecnologia in selecaoTecnologias)
                Console.Write($"  *{tecnologia}*");

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

        static string GetNotNullableString(Person person)
        {
            var teste = person!.Name;
            return teste;
        }

        // Antes usava-se Task<IEnumerable<T>>
        static async IAsyncEnumerable<Person> GetAsync(IAsyncEnumerable<Person> people)
        {
            await foreach (var t in people)
            {
                yield return t;
            }
        }

        public static IEnumerable<int> Potencia(int numero, int exponente)
        {
            int resultado = 1;

            for (int i = 0; i < exponente; i++)
            {
                resultado *= numero;
                yield return resultado;
            }
        }

        // Agora não há necessidade de ficar usando Take e Skip para selecionar uma porção específica do array
        static IEnumerable<Person> SliceArray(Person[] people)
        {
            List<Person> newList = new List<Person>();

            foreach (var person in people[1..5])
                newList.Add(person);

            foreach (var person in people[1..^2])
                newList.Add(person);

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

        //static string GetRecursivePatterns2(Person person)
        //{
        //    string test;
        //    switch (person)
        //    {
        //        case Person(_, "Dias") personTmp when (person.Name == "Alessandro"):
        //            {
        //                test = $"{person.Name} {person.LastName}";
        //            }
        //            break;
        //        default:
        //            test = "";
        //            break;
        //    }

        //    return test;
        //}

        public static string RockPaperScissors(string first, string second) => (first, second) switch
        {
            ("rock", "paper") => "rock is covered by paper. Paper wins.",
            ("rock", "scissors") => "rock breaks scissors. Rock wins.",
            ("paper", "rock") => "paper covers rock. Paper wins.",
            ("paper", "scissors") => "paper is cut by scissors. Scissors wins.",
            ("scissors", "rock") => "scissors is broken by rock. Rock wins.",
            ("scissors", "paper") => "scissors cuts paper. Scissors wins.",
            (_, _) => "tie"
        };

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

        static Quadrant GetQuadrant(Point point) => point switch
        {
            (0, 0) => Quadrant.Origin,
            var (x, y) when x > 0 && y > 0 => Quadrant.One,
            var (x, y) when x < 0 && y > 0 => Quadrant.Two,
            var (x, y) when x < 0 && y < 0 => Quadrant.Three,
            var (x, y) when x > 0 && y < 0 => Quadrant.Four,
            var (_, _) => Quadrant.OnBorder,
            _ => Quadrant.Unknown
        };
    }
}

//public interface ILogger
//{
//    void Log(string mensagem);
//    void Log(Exception ex) => Log(ex.Message); //Default

//}

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

public class Point
{
    public int X { get; }
    public int Y { get; }

    public Point(int x, int y) => (X, Y) = (x, y);

    public void Deconstruct(out int x, out int y) => (x, y) = (X, Y);
}

public class testeString
{
    static string Quadrant(Point p) => p switch
    {
        (0, 0) => "origin",
        (var x, var y) when x > 0 && y > 0 => "Quadrant 1",
        (var x, var y) when x < 0 && y > 0 => "Quadrant 2",
        (var x, var y) when x < 0 && y < 0 => "Quadrant 3",
        (var x, var y) when x > 0 && y < 0 => "Quadrant 4",
        (var x, var y) => "on a border",
        _ => "unknown"
    };
}

public class Teste2
{
    static void WriteLinesToFile(IEnumerable<string> lines)
    {
        using var file = new System.IO.StreamWriter("WriteLines2.txt");
        foreach (string line in lines)
        {
            // If the line doesn't contain the word 'Second', write the line to the file.
            if (!line.Contains("Second"))
            {
                file.WriteLine(line);
            }
        }
        // file is disposed here
    }

    static void WriteLinesToFile2(IEnumerable<string> lines)
    {
        using (var file = new System.IO.StreamWriter("WriteLines2.txt"))
        {
            foreach (string line in lines)
            {
                // If the line doesn't contain the word 'Second', write the line to the file.
                if (!line.Contains("Second"))
                {
                    file.WriteLine(line);
                }
            }
        } // file is disposed here
    }

    static void Teste()
    {
        int M()
        {
            int y;
            LocalFunction();
            return y;

            void LocalFunction() => y = 0;
        }
    }

    void LocalFunction()
    {
        throw new NotImplementedException();
    }
}

public enum Quadrant
{
    Unknown,
    Origin,
    One,
    Two,
    Three,
    Four,
    OnBorder
}

public class Employee
{
    public string Name;
    public int Age;
}