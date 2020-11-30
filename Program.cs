using System;
using System.Collections.Generic;

namespace Grafica
{
    class Program
    {
        static void Main(string[] args)
        {
            // string[] lines = System.IO.File.ReadAllLines(@"C:\Users\amanda.carvalho\source\repos\Grafica\DadosSo.txt");
            string[] lines = System.IO.File.ReadAllLines(@"C:\DadosSo.txt");

            Console.WriteLine("Contents of WriteLines2.txt = ");
            
            List<Pedidos> listarPedidos = new List<Pedidos>();
            int i = 0;

            foreach (string line in lines)
            {
                
                if (i == 0)
                {
                    int quantidade = Convert.ToInt32(line);
                }
                else
                {
                    String[] campos = line.Split(';');

                    listarPedidos.Add(new Pedidos(campos[0], Convert.ToInt32(campos[1]), Convert.ToInt32(campos[2]),
                           Convert.ToInt32(campos[3])));
                }

                i++;

            }

        }
    }
}
