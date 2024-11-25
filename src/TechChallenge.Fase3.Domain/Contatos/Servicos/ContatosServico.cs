﻿using System.ComponentModel.DataAnnotations;
using TechChallenge.Fase3.DataTransfer.Utils;
using TechChallenge.Fase3.Domain.Contatos.Entidades;
using TechChallenge.Fase3.Domain.Contatos.Repositorios;
using TechChallenge.Fase3.Domain.Contatos.Repositorios.Filtros;
using TechChallenge.Fase3.Domain.Contatos.Servicos.Interfaces;

namespace TechChallenge.Fase3.Domain.Contatos.Servicos
{
    public class ContatosServico(IContatosRepositorio contatosRepositorio) : IContatosServico
    {
        public async Task<PaginacaoConsulta<Contato>> ListarPaginacaoContatosAsync(ContatosPaginadosFiltro request)
        {
            PaginacaoConsulta<Contato> consultaPaginada = await contatosRepositorio.ListarPaginacaoContatosAsync(request);
            return consultaPaginada;
        }

        public async Task<List<Contato>> ListarContatosAsync(ContatoFiltro request)
            => await contatosRepositorio.ListarContatosAsync(request);


        public async Task<Contato> InserirContatoAsync(ContatoFiltro novoContato)
        {
            ValidarCampos(novoContato);

            Contato contatoInserir = new(novoContato.Nome!, novoContato.Email!, (int)novoContato.DDD!, novoContato.Telefone!);

            Contato response = await contatosRepositorio.InserirContatoAsync(contatoInserir);
            return response;
        }

        public async Task RemoverContatoAsync(int id)
        {
            Contato contato = await RecuperarContatoAsync(id);
            if (contato != null)
                await contatosRepositorio.RemoverContatoAsync((int)contato.Id!);

        }

        public async Task<Contato> RecuperarContatoAsync(int id)
        {
            return await contatosRepositorio.RecuperarContatoAsync(id);
        }

        public async Task<Contato> AtualizarContatoAsync(Contato contato)
        {
            return await contatosRepositorio.AtualizarContatoAsync(contato);
        }

        private static void ValidarCampos(ContatoFiltro contatoRequest)
        {
            if (string.IsNullOrEmpty(contatoRequest.Nome))
                throw new ArgumentException("Nome não preenchido.");

            if (!ValidarEmail(contatoRequest.Email))
                throw new ArgumentException($"Email inválido: {contatoRequest.Email}");

            if (string.IsNullOrEmpty(contatoRequest.Telefone))
                throw new ArgumentException("Telefone não preenchido.");

            if (!contatoRequest.Telefone!.All(char.IsDigit))
                throw new ArgumentException($"Telefone inválido: {contatoRequest.Telefone}");

            if (contatoRequest.DDD == null)
                throw new ArgumentException("DDD não preenchido.");

            if (contatoRequest.DDD.Value <= 0)
                throw new ArgumentException("DDD não preenchido.");
        }

        public static bool ValidarEmail(string? email)
        {
            if (string.IsNullOrWhiteSpace(email))
                return false;

            if (new EmailAddressAttribute().IsValid(email))
                return true;

            return false;
        }

    }
}
