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
            string path = @"C:\DadosSo2.txt";
            string[] lines;

            List<Pedidos> listaPedidos = new List<Pedidos>();
            int quantidadePedidos = 0;

            // Verifica se existe o arquivo com o caminho passado.
            if (File.Exists(path))
            {
                Console.WriteLine("\nArquivo encontrado!");

                // Procura o arquivo pelo caminho path e devolve em um array de string
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
                        listaPedidos.Add(new Pedidos(campos[0], Int32.Parse(campos[1]), float.Parse(campos[2]), Int32.Parse(campos[3]), Int32.Parse(campos[4])));
                    }

                }


                // Exibir a quantidade de itens da lista de pedidos já no padrão.
                Console.WriteLine($"\nTamanho da lista de pedidos: {listaPedidos.Count}");

                Console.WriteLine("\nExecutando a esteira...");
                // Executa a esteira padrao passando a lista de pedidos e a quantidade
                Esteira.Executar(quantidadePedidos, listaPedidos, true);

                Console.WriteLine("\nExecutando a esteira FIFO...");
                // Executa a esteira no modo fifo passando a lista de pedidos e a quantidade
                Esteira.Fifo(quantidadePedidos, listaPedidos);

                Console.WriteLine("\nExecutando a esteira com THREADS...");
                // Executa a esteira com threads passando a lista de pedidos e a quantidade
                Esteira.ExecutarThread(quantidadePedidos, listaPedidos);

                Console.WriteLine("\nFim da execução");

            }
            else
            {
                Console.WriteLine("Arquivo não encontrado!");
            }
        }
    }
}
