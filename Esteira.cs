using System;
using System.Collections.Generic;

namespace Grafica
{
    class Esteira
    {
		private static  int TempoDia = 32400;
		private static  int TempoMeioDia = 14400;
		private static  int TempoDepoisMeioDia = 18000;
		private static float tempoAtualAntesMeioDia = 0;
		private static float tempoAtualDepoisMeioDia = 0;

		public static void Executar(int quantidade, List<Pedidos> pedidos)
		{

			for (int index = 0; index < pedidos.size(); index++)
			{
				if (pedidos.get(index).Prazo > 0 && pedidos.get(index).Prazo * 60 <= TempoMeioDia)
				{
					pedidos.get(index).FlagMeioDia = 1;
					pedidos.get(index).CalcularTempoProducao();
				}
				else
				{
					pedidos.get(index).CalcularTempoProducao();
				}
			}

			Collections.sort(pedidos, new IComparable<Pedidos>()
			{

				public int compare(Pedidos o1, Pedidos o2)
			   {
					if (o1.GetPrazo != 0 && o2.Prazo != 0)
					{
						if (o1.Prazo < o2.Prazo)
						{
							return -1;
						}
						if (o1.Prazo > o2.Prazo)
						{
							return 1;
						}
						else return 0;
					}
					if (o1.Prazo != 0 && o2.Prazo == 0)
					{
						return -1;
					}
					if (o1.Prazo == 0 && o2.Prazo != 0)
					{
						return 1;
					}

					if (o1.Prazo == o2.Prazo)
					{
						if (o1.TempoProducao > o2.TempoProducao)
						{
							return 1;
						}
						if (o1.TempoProducao < o2.TempoProducao)
						{
							return -1;
						}
						else return 0;
					}
					return 0;
				}
		});
		 
		 int quantidadeProduzida = 0, produtosAntesMeioDia = 0;
		int foraPrazo = 0;
		int tempo = 0; 
			for(int index = 0; index<produto.size() ; index ++ ) 
			{
				tempo += produto.get(index).TempoProducao;
				if(!(tempo > TempoDia)) {
					if(tempo <= TempoMeioDia) 
					{
						produtosAntesMeioDia ++;
					}
				if(produto.get(index).Prazo > 0 && tempo > produto.get(index).Prazo* 60)
				{
					foraPrazo ++;
				}
                       quantidadeProduzida++;
				}
			}
			System.out.println("Fora do Prazo :" + foraPrazo + " Produzidos: " + quantidadeProduzida + " Antes do meio dia:" + produtosAntesMeioDia);
		}
		

	
	public static void Fifo(int quantidade, List<Produto> produto)
{
	int quantidadeProduzida = 0, produtosAntesMeioDia = 0;
	int foraPrazo = 0;
	int tempo = 0;
	for (int index = 0; index < produto.size(); index++)
	{
		produto.get(index).CalcularTempoProducao();
		tempo += produto.get(index).TempoProducao;
		if (!(tempo > TempoDia))
		{
			if (tempo <= TempoMeioDia)
			{
				produtosAntesMeioDia++;
			}
			if (produto.get(index).Prazo > 0 && tempo > produto.get(index).Prazo * 60)
			{
				foraPrazo++;
			}
			quantidadeProduzida++;
		}
	}
	System.out.println("Fora do Prazo :" + foraPrazo + " Produzidos: " + quantidadeProduzida + " Antes do meio dia:" + produtosAntesMeioDia);
}
    }
}
