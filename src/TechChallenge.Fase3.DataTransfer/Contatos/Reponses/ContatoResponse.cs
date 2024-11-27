﻿using TechChallenge.Fase3.DataTransfer.Regioes.Responses;

namespace TechChallenge.Fase3.DataTransfer.Contatos.Reponses
{
    public class ContatoResponse
    {
        public int? Id { get; set; }
        public string? Nome { get; set; }
        public string? Email { get; set; }
        public int? DDD { get; set; }
        public string? Telefone { get; set; }
        public RegiaoResponse? Regiao { get; set; }
    }
}
