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

            List<Pedidos> listaPedidos = new List<Pedidos>();
            int quantidadePedidos = 0;

            if (File.Exists(path))
            {
                Console.WriteLine("Arquivo encontrado!");
                lines = File.ReadAllLines(path);

                Console.WriteLine($"Linhas encontradas: {lines.Length}");

                for (int i = 0; i < lines.Length; i++)
                {
                    // Elemento por linha
                    // Console.WriteLine(lines[i]);

                    string[] campos = lines[i].Split(";");

                    // Pega a quantidade de items importados, sendo que a primeira linha informa a quantidade de registros
                    if (campos.Length == 1)
                    {
                        quantidadePedidos = Int32.Parse(campos[0]);
                    }
                    else
                    {
                        // Mostra todos os elementos da lista particionando os valores
                        // Console.WriteLine($"{campos[0]}, {campos[1]}, {campos[2]}, {campos[3]}");

                        // Cria a lista de pedidos
                        listaPedidos.Add(new Pedidos(campos[0], Int32.Parse(campos[1]), Int32.Parse(campos[2]), Int32.Parse(campos[3])));
                    }

                }

                Console.WriteLine($"Tamanho da lista de pedidos: {listaPedidos.Count}");

                Console.WriteLine("Executando a esteira...");
                Esteira.Executar(quantidadePedidos, listaPedidos);

            }
            else
            {
                Console.WriteLine("Arquivo não encontrado!");
            }
        }
    }
}
