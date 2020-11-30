using System;
using System.Collections.Generic;
using System.IO;

namespace Grafica
{
    class Program
    {
        static void Main(string[] args)
        {
            // string path = @"C:\Users\amanda.carvalho\source\repos\Grafica\DadosSo.txt";
            string path = @"C:\DadosSo.txt";
            string[] lines;

            if (File.Exists(path))
            {
                Console.WriteLine("Existe");
                lines = File.ReadAllLines(path);
                Console.WriteLine(lines.Length);

            }
            else
            {
                Console.WriteLine("Não Existe");
            }

            List<Pedidos> listarPedidos = new List<Pedidos>();

            // int i = 0;

            // foreach (string line in lines)
            // {

            //     if (i == 0)
            //     {
            //         int quantidade = Convert.ToInt32(line);
            //     }
            //     else
            //     {
            //         String[] campos = line.Split(';');

            //         listarPedidos.Add(new Pedidos(campos[0], Convert.ToInt32(campos[1]), Convert.ToInt32(campos[2]),
            //                Convert.ToInt32(campos[3])));
            //     }

            //     i++;

            // }

        }
    }
}
