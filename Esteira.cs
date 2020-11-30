using System;
using System.Collections.Generic;
using System.Threading;

namespace Grafica
{
    class Esteira
    {
        private static int TempoDia = 32400;
        private static int TempoMeioDia = 14400;
        private static int TempoDepoisMeioDia = 18000;
        private static float tempoAtualAntesMeioDia = 0;
        private static float tempoAtualDepoisMeioDia = 0;

        public static void Executar(int quantidade, List<Pedidos> pedidos)
        {

            for (int index = 0; index < pedidos.Count; index++)
            {
                if (pedidos[index].Prazo > 0 && pedidos[index].Prazo * 60 <= TempoMeioDia)
                {
                    pedidos[index].FlagMeioDia = 1;
                    pedidos[index].CalcularTempoProducao();
                }
                else
                {
                    pedidos[index].CalcularTempoProducao();
                }
            }

            pedidos.Sort(CompararPedidos);


            int quantidadeProduzida = 0;
            int produtosAntesMeioDia = 0;
            int foraPrazo = 0;
            double tempo = 0;

            for (int index = 0; index < pedidos.Count; index++)
            {
                tempo += pedidos[index].TempoProducao;

                if (!(tempo > TempoDia))
                {
                    if (tempo <= TempoMeioDia)
                    {
                        produtosAntesMeioDia++;
                    }
                    if (pedidos[index].Prazo > 0 && pedidos[index].Prazo > tempo )
                    {
                        foraPrazo++;
                    }
                    quantidadeProduzida++;
                }
  
            }

            Console.WriteLine($"Fora do Prazo :{foraPrazo}\n Produzidos: {quantidadeProduzida}\n Antes do meio dia: {produtosAntesMeioDia}");

        }


        public static void Fifo(int quantidade, List<Pedidos> pedido)
        {
            int quantidadeProduzida = 0, produtosAntesMeioDia = 0;
            int foraPrazo = 0;
            double tempo = 0;

            for (int index = 0; index < pedido.Count; index++)
            {
                pedido[index].CalcularTempoProducao();
                tempo += pedido[index].TempoProducao;

                if (!(tempo > TempoDia))
                {
                    if (tempo <= TempoMeioDia)
                    {
                        produtosAntesMeioDia++;
                    }
                    if (pedido[index].Prazo > 0 && tempo > pedido[index].Prazo * 60)
                    {
                        foraPrazo++;
                    }
                    quantidadeProduzida++;
                }
            }

            Console.WriteLine($"Fora do Prazo: {foraPrazo} Produzidos: {quantidadeProduzida} Antes do meio dia: {produtosAntesMeioDia}");
        }


        public static void ExecutarThread(int quantidade, List<Pedidos> pedidos)
        {
            // Criando a Thread inicial, toda execucao é na Threade inicial
            Console.WriteLine("Thread principal iniciada");
            Thread.CurrentThread.Name = "Principal - ";

            // Crio duas listas particionando os pedidos em duas listas de pedidos.
            List<Pedidos> listaPedidos1 = new List<Pedidos>();
            List<Pedidos> listaPedidos2 = new List<Pedidos>();

            // Quero a lista principal inserindo na listaPedidos1 e listaPedidos2
            for (int i = 0; i < pedidos.Count; i++)
            {
                // Considero impa ou par para dividir
                if (i % 2 == 0)
                {
                    listaPedidos1.Add(pedidos[i]);
                }
                else
                {
                    listaPedidos2.Add(pedidos[i]);
                }
            }

            // Inicio uma segunda Thread, passando o metodo que ela vai executar sendo a lista 2
            Thread t1 = new Thread(() => Executar(listaPedidos2.Count, listaPedidos2));
            t1.Name = "Secundária - ";

            // Inicio a segunda thread
            t1.Start();

            // Chamo na thread principal a lista 1
            Executar(listaPedidos1.Count, listaPedidos1);
        }

        public static int CompararPedidos(Pedidos pedido1, Pedidos pedido2)
        {
            if (pedido1.Prazo != 0 && pedido2.Prazo != 0)
            {
                if (pedido1.Prazo < pedido2.Prazo)
                {
                    return -1;
                }
                if (pedido1.Prazo > pedido2.Prazo)
                {
                    return 1;
                }
                else return 0;
            }
            if (pedido1.Prazo != 0 && pedido2.Prazo == 0)
            {
                return -1;
            }
            if (pedido1.Prazo == 0 && pedido2.Prazo != 0)
            {
                return 1;
            }

            if (pedido1.Prazo == pedido2.Prazo)
            {
                if (pedido1.TempoProducao > pedido2.TempoProducao)
                {
                    return 1;
                }
                if (pedido1.TempoProducao < pedido2.TempoProducao)
                {
                    return -1;
                }
                else return 0;
            }
            return 0;
        }

    }
}