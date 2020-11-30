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
            int quantidadePedidos = 0;

            if (File.Exists(path))
            {
                Console.WriteLine("Arquivo encontrado!");
                lines = File.ReadAllLines(path);

                for (int i = 0; i < lines.Length; i++)
                {
                    Console.WriteLine(lines[i]);

                    string[] campos = lines[i].Split(";");

                    // Pega a quantidade de items importados
                    if (campos.Length == 1)
                    {
                        quantidadePedidos = Int32.Parse(campos[0]);
                    }
                    else
                    {
                        // Mostra todos os elementos da lista particionando os valores
                        Console.WriteLine($"{campos[0]}, {campos[1]}, {campos[2]}, {campos[3]}");
                    }

                }

            }
            else
            {
                Console.WriteLine("Arquivo não encontrado!");
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
