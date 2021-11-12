using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BardoRauta
{
	class Estagiario : Funcionario
	{
		public Estagiario(string nome, int matricula) : base(nome, matricula)
		{
			Console.WriteLine("Instância de Estagiário criada!");
		}

		public float CalculaDescontoMenor(float valor)
		{
			return valor * 0.95F;
		}
	}
}