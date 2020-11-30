using System;
using System.Collections.Generic;

namespace Grafica
{
    class Pedidos
    {
        public int TempoPorPacote = 1;
        public string Cliente;
        public int FlagMeioDia = 0;
        public float Total, Preco;
        public int Prazo;

        public double TempoProducao;
        public Pedidos(String cliente, int totalDePaginas, float precoPagina, int prazo)
        {
            Cliente = cliente;
            Total = totalDePaginas;
            Preco = precoPagina;
            Prazo = prazo;
        }

        public void SetNome(String cliente1)
        {
            this.Cliente = cliente1;
        }
        public void SetTotal(int total)
        {
            this.Total = total;
        }
        public void Setpreco(float preco)
        {
            this.Preco = preco;
        }
        public void SetPrazo(int prazo)
        {
            this.Prazo = prazo;
        }

        public void CalcularTempoProducao()
        {
            double tempoDecorrido = 0.15;
            float totalPedido = Total;
            float volumeTotal = this.Total * this.Preco;
            float produtosPacote = 80 / this.Total;

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
