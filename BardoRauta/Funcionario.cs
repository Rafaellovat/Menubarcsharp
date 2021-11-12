using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BardoRauta
{
	class Funcionario
	{
		private string nome;
		private int matricula;
		public Funcionario(string nome, int matricula)
		{
			this.nome = nome;
			this.matricula = matricula;
			Console.WriteLine($"Construtor de Funcionário: {this.nome}, {this.matricula}");
		}
	}
}
