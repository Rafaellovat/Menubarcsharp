using System;
using System.Collections.Generic;
using System.Threading;

namespace BardoRauta
{
	class Loja
	{
		private List<Pedido> listaPedidos;
		private string nomeDaLoja;
		private float valorTotal = 0F;
		public Loja(string nomeDaLoja)
		{
			this.nomeDaLoja = nomeDaLoja;
			listaPedidos = new List<Pedido>();
			Console.WriteLine($"Seja bem vindo ao {nomeDaLoja}!");
		}

		public void Menu()
		{
			Console.WriteLine("---------- Bem Vindo ao bar ----------");
			Console.WriteLine("1 - Inserir Pedido");
			Console.WriteLine("2 - Buscar Pedido");
			Console.WriteLine("3 - Remover Pedido");
			Console.WriteLine("0 - Fechar o programa");
			Console.Write("Digite a opção desejada: ");
			try
			{
				char resposta = Convert.ToChar(Console.ReadLine());
				switch (resposta)
				{
					case '0':
						Console.WriteLine("");
						Console.WriteLine("Obrigado por utilizar o nosso bar!");
						Thread.Sleep(1500);
						Console.WriteLine("Volte sempre!");
						Thread.Sleep(1500);
						Environment.Exit(-10);
						break;

					case '1':
						this.InserirPedido();
						break;

					case '2':
						this.BuscarPedido();
						break;

					case '3':
						this.RemoverPedido();
						break;

					default:
						Console.WriteLine("");
						Console.WriteLine("ERRO! Escolha uma opção válida!");
						Thread.Sleep(3500);
						Console.Clear();
						this.Menu();
						break;
				}
			}
			catch (System.FormatException)
			{
				Console.WriteLine("");
				Console.WriteLine("ERRO! Escolha uma opção válida!");
				Thread.Sleep(3500);
				Console.Clear();
				this.Menu();
			}
		}
		public void InserirPedido()
		{
			Console.Clear();
			Console.WriteLine("---------- Inserir Pedido ----------");
			Console.WriteLine("");

			Console.WriteLine("1 - Red Label");
			Console.WriteLine("2 - Agua");
			Console.WriteLine("3 - Coca Cola");
			Console.WriteLine("4 - Brahma");
			Console.WriteLine("5 - Skol");
			Console.WriteLine("6 - Stella Artois");
			Console.WriteLine("");

		escolha:
			Console.Write("Qual item você quer inserir? ");
			string opcao = Console.ReadLine();

			Console.WriteLine("");
			switch (opcao)
			{
				case "1":
					Console.WriteLine("Você inseriu Red Label. Valor R$119.");
					Pedido p1 = new Pedido(119F, "Red Label");
					listaPedidos.Add(p1);
					valorTotal += 119F;
					Pedido.contador++;
					break;

				case "2":
					Console.WriteLine("Você inseriu Agua. Valor R$1,99.");
					Pedido p2 = new Pedido(1.99F, "Agua");
					listaPedidos.Add(p2);
					valorTotal += 1.99F;
					Pedido.contador++;
					break;

				case "3":
					Console.WriteLine("Você inseriu Coca Cola. Valor R$3,99.");
					Pedido p3 = new Pedido(3.99F, "Coca Cola");
					listaPedidos.Add(p3);
					valorTotal += 3.99F;
					Pedido.contador++;
					break;

				case "4":
					Console.WriteLine("Você inseriu Brahma. Valor R$5,50.");
					Pedido p4 = new Pedido(5.50F, "Brahma");
					listaPedidos.Add(p4);
					valorTotal += 5.50F;
					Pedido.contador++;
					break;

				case "5":
					Console.WriteLine("Você inseriu Skol Valor R$8,99.");
					Pedido p5 = new Pedido(8.99F, "Skol");
					listaPedidos.Add(p5);
					valorTotal += 8.99F;
					Pedido.contador++;
					break;

				case "6":
					Console.WriteLine("Você inseriu Stella Artois. Valor R$ 7,99.");
					Pedido p6 = new Pedido(7.99F, "Stella Artois");
					listaPedidos.Add(p6);
					valorTotal += 7.99F;
					Pedido.contador++;
					break;

				default:
					Console.WriteLine("ERRO! Digite um dos itens acima!");
					goto escolha;
			}

		pergunta:
			Console.WriteLine("Quer mais alguma bebida ?");
			Console.WriteLine("");
			Console.WriteLine("1 - Adicionar mais bebidas");
			Console.WriteLine("2 - Remover alguma bebida");
			Console.WriteLine("3 - Finalizar compra");
			Console.WriteLine("0 - Voltar ao bar");
			Console.WriteLine("");
			Console.Write("Opção: ");

			string resposta = Console.ReadLine();
			switch (resposta)
			{
				case "1":
					Console.Clear();
					this.InserirPedido();
					break;

				case "2":
					Console.Clear();
					this.RemoverPedido();
					break;

				case "3":
					Console.Clear();
					this.CalcularPrecoTotal();
					break;

				case "0":
					Console.Clear();
					this.Menu();
					break;

				default:
					Console.WriteLine("Erro! Opção inválida!");
					Console.WriteLine("");
					goto pergunta;
			}
		}
		public void BuscarPedido()
		{
			Console.Clear();
			Console.WriteLine("---------- Buscar Pedido ----------");
			Console.WriteLine("");

			foreach (var item in listaPedidos)
			{
				Console.WriteLine($"ID: {item.getPedidoId()}\t Data de Emissão: {item.getDataEmissao()}\tValor: R${item.getValorDoProduto()} \tDesc. Produto: {item.getDescricaoDoProduto()}");
			}
			Console.WriteLine("");
			Console.Write("Aperte qualquer tecla para voltar...");
			Console.ReadKey(true);
			Console.Clear();
			this.Menu();
		}
		public void RemoverPedido()
		{
			Console.Clear();
			Console.WriteLine("---------- Remover Item ----------");
			Console.WriteLine("");
			bool encontrou = false;
			foreach (var item in listaPedidos)
			{
				Console.WriteLine($"ID: {item.getPedidoId()}\t Data de Emissão: {item.getDataEmissao()}\tValor: R${item.getValorDoProduto()} \tDesc. Produto: {item.getDescricaoDoProduto()}");
			}
			Console.WriteLine("");

		pergunta:
			Console.Write("Qual o número do item que você deseja remover? ");
			int resposta = Int32.Parse(Console.ReadLine());
			Console.WriteLine();

			foreach (var item in listaPedidos)
			{
				if (resposta == item.getPedidoId())
				{
					listaPedidos.Remove(item);
					Console.WriteLine($"item {item.getDescricaoDoProduto()} foi removido com sucesso!");
					Console.WriteLine();
					valorTotal -= item.getValorDoProduto();
					encontrou = true;
					this.CalcularPrecoTotal();
					break;
				}
			}
			if (encontrou == false)
			{
				Console.WriteLine("ERRO! Digite um ID de item válido!");
				goto pergunta;
			}
		}

		public void CalcularPrecoTotal()
		{
			Console.WriteLine("-------- Total --------");
			Console.WriteLine("");
			foreach (var item in listaPedidos)
			{
				Console.WriteLine($"ID: {item.getPedidoId()}\t Data de Emissão: {item.getDataEmissao()}\tValor: R${item.getValorDoProduto()} \tDesc. Produto: {item.getDescricaoDoProduto()}");
			}
			Console.WriteLine("");
			Console.WriteLine($"Valor Total: R${valorTotal.ToString("N2")}");

		pergunta:
			Console.WriteLine("");
			Console.WriteLine("Escolha uma das opções abaixo: ");
			Console.WriteLine("1 - Finalizar pedido");
			Console.WriteLine("2 - Remover item");
			Console.WriteLine("3 - Inserir item");
			Console.WriteLine("");
			Console.Write("Opção: ");
			string resposta = Console.ReadLine();

			switch (resposta)
			{
				case "1":
					Console.WriteLine($"Valor Total: R${valorTotal.ToString("N2")}");
					break;

				case "2":
					Console.Clear();
					this.RemoverPedido();
					break;

				case "3":
					Console.Clear();
					this.InserirPedido();
					break;

				default:
					Console.WriteLine("ERRO! Escolha uma das opções válidas!");
					goto pergunta;
			}
		}
	}
}
