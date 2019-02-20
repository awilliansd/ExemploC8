using System;

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
    }
}
