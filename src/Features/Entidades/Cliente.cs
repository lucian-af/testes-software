﻿using System;
using Features.Core.DomainObjects;
using Features.Validations;

namespace Features.Entidades
{
	public class Cliente : Entity
	{
		public string Nome { get; private set; }
		public string Sobrenome { get; private set; }
		public DateTime DataNascimento { get; private set; }
		public DateTime DataCadastro { get; private set; }
		public string Email { get; private set; }
		public bool Ativo { get; private set; }

		protected Cliente()
		{
		}

		public Cliente(Guid id, string nome, string sobrenome, DateTime dataNascimento, string email, bool ativo,
			DateTime dataCadastro)
		{
			Id = id;
			Nome = nome;
			Sobrenome = sobrenome;
			DataNascimento = dataNascimento;
			Email = email;
			Ativo = ativo;
			DataCadastro = dataCadastro;
		}

		public string NomeCompleto()
			=> $"{Nome} {Sobrenome}";

		public bool EhEspecial() => DataCadastro < DateTime.Now.AddYears(-3) && Ativo;

		public void Inativar() => Ativo = false;

		public override bool EhValido()
		{
			ValidationResult = new ClienteValidacao().Validate(this);
			return ValidationResult.IsValid;
		}
	}
}