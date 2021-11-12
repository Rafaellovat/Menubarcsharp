using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BardoRauta
{
	class Pedido
	{
		private int pedidoId;
		private DateTime dataEmissao;
		private static Dictionary<string, float> itensDoPedido;
		private float valorDoProduto;
		private string descricaoDoProduto;
		public static int contador = 1;
		public Pedido(float valorDoProduto, string descricaoDoProduto)
		{
			itensDoPedido = new Dictionary<string, float>();
			dataEmissao = DateTime.Now;
			this.valorDoProduto = valorDoProduto;
			this.descricaoDoProduto = descricaoDoProduto;
			pedidoId = contador;
		}
		public int getPedidoId()
		{
			return pedidoId;
		}
		public DateTime getDataEmissao()
		{
			return dataEmissao;
		}
		public float getValorDoProduto()
		{
			return valorDoProduto;
		}
		public string getDescricaoDoProduto()
		{
			return descricaoDoProduto;
		}

	}
}
