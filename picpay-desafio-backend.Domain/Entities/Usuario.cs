using System;
using picpay_desafio_backend.Domain.Entities.Enums;
using picpay_desafio_backend.Domain.Exceptions;

namespace picpay_desafio_backend.Domain.Entities
{
    public sealed class Usuario : BaseEntity
    {


        public string Nome { get; private set; }
        public string CPF { get; private set; }
        public string Email { get; private set; }
        public string Senha { get; private set; }
        public TipoContaEnum TipoConta { get; private set; }
        public decimal Saldo { get; private set; }

        public Usuario()
        {
        }

        public Usuario(string nome, string cpf, string email, string senha, TipoContaEnum tipoConta, decimal saldo)
        {
            Validar(nome, cpf, email, senha, tipoConta, saldo);
            Salvar(nome, cpf, email, senha, tipoConta, saldo);
        }

        public void debitar(decimal valor)
        {
            decimal newSaldo = Saldo - valor;
            Validar(Nome, CPF, Email, Senha, TipoConta, newSaldo);
            Salvar(Nome, CPF, Email, Senha, TipoConta, newSaldo);
        }

        public void creditar(decimal valor)
        {
            decimal newSaldo = Saldo + valor;
            Validar(Nome, CPF, Email, Senha, TipoConta, newSaldo);
            Salvar(Nome, CPF, Email, Senha, TipoConta, newSaldo);
        }

        private void Validar(string nome, string cpf, string senha, string email, TipoContaEnum tipoConta, decimal saldo)
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(nome), "Nome inválido. campo obrigatório");

            DomainExceptionValidation.When(string.IsNullOrEmpty(cpf), "CPF inválido. campo obrigatório");

            DomainExceptionValidation.When(string.IsNullOrEmpty(email), "E-mail inválido. campo obrigatório");

            DomainExceptionValidation.When(string.IsNullOrEmpty(senha), "Senha inválida. campo obrigatório");

            DomainExceptionValidation.When(saldo < 0, "Saldo inválido. campo não pode ser negativo");
        }

        private void Salvar(string nome, string cpf, string senha, string email, TipoContaEnum tipoConta, decimal saldo)
        {
            Nome = nome;
            CPF = cpf;
            Email = email;
            Senha = senha;
            TipoConta = tipoConta;
            Saldo = saldo;
        }

    }
}

