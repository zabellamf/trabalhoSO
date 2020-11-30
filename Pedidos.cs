using System;
using System.Collections.Generic;

namespace Grafica
{
    class Pedidos
    {
        private int TempoPorPacote = 1;
        string cliente1;
        int FlagMeioDia = 0;
        float total, preco;
        int prazo1;
        public double TempoProducao;
        public Pedidos(String cliente, int totalDePaginas, float precoPagina, int prazo)
        {
            cliente1 = cliente;
            total = totalDePaginas;
            preco = precoPagina;
            prazo1 = prazo;
        }

        public String Getcliente()
        {
            return this.cliente1;
        }

        public float GetTotal()
        {
            return this.total;
        }

        public int GetPrazo()
        {
            return this.prazo1;
        }

        public float GetPreco()
        {
            return this.preco;
        }
        public void SetNome(String cliente1)
        {
            this.cliente1 = cliente1;
        }
        public void SetTotal(int total)
        {
            this.total = total;
        }
        public void Setpreco(float preco)
        {
            this.preco = preco;
        }
        public void SetPrazo(int prazo1)
        {
            this.prazo1 = prazo1;
        }

        public void CalcularTempo()
        {
            double tempoDecorrido = 0.15;
            float totalPedido = total;
            float volumeTotal = this.GetTotal() * this.GetPreco();
            float produtosPacote = 80 / this.GetTotal();

            if (volumeTotal <= 80)
            {
                tempoDecorrido = 0.5;
            }

            while (totalPedido != 0)
            {
                if (totalPedido < produtosPacote)
                {
                    totalPedido = 0;
                    tempoDecorrido += 5.5;
                }
                else
                {
                    totalPedido -= produtosPacote;
                    tempoDecorrido = +5.5;
                }
            }
            
            this.TempoProducao = tempoDecorrido;

            //  int volumeTotal = this.GetVolume() * this.GetNumeroProdutos();
        }
        internal static List<Pedidos> List()
        {
            throw new NotImplementedException();
        }
    }
}
