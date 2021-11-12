using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BardoRauta
{
	class Gerente : Funcionario
	{
		private int senha;
		public Gerente(string nome, int matricula, int senha) : base(nome, matricula)
		{
			this.senha = senha;
			Console.WriteLine($"Instância de Gerente criada: {this.senha}");
		}
		public float CalculaDescontoMaior(float valor)
		{
			return valor * 0.90F;
		}
	}
}
