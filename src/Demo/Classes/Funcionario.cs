using System;
using System.Collections.Generic;
using Demo.Classes.Enums;

namespace Demo.Classes
{
	public class Funcionario : Pessoa
	{
		public decimal Salario { get; private set; }
		public NivelProfissional NivelProfissional { get; private set; }
		public IList<string> Habilidades { get; private set; }

		public Funcionario(string nome, decimal salario)
		{
			Nome = string.IsNullOrWhiteSpace(nome) ? "Fulano" : nome;
			DefinirSalario(salario);
			DefinirHabilidades();
		}

		public void DefinirSalario(decimal salario)
		{
			if (salario < 500) throw new Exception("Salario inferior ao permitido");

			Salario = salario;
			if (salario < 2000) NivelProfissional = NivelProfissional.Junior;
			else if (salario >= 2000 && salario < 8000) NivelProfissional = NivelProfissional.Pleno;
			else if (salario >= 8000) NivelProfissional = NivelProfissional.Senior;
		}

		private void DefinirHabilidades()
		{
			var habilidadesBasicas = new List<string>()
			{

				"Lógica de Programação",
				"OOP"
			};

			Habilidades = habilidadesBasicas;

			switch (NivelProfissional)
			{
				case NivelProfissional.Pleno:
					Habilidades.Add("Testes");
					break;
				case NivelProfissional.Senior:
					Habilidades.Add("Testes");
					Habilidades.Add("Microservices");
					break;
			}
		}

		public static class FuncionarioFactory
		{
			public static Funcionario Criar(string nome, decimal salario)
				=> new(nome, salario);
		}
	}
}
