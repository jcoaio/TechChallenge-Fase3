﻿using AutoMapper;
using TechChallenge.Fase3.Domain.Contatos.Comandos;
using TechChallenge.Fase3.Domain.Contatos.Entidades;

namespace ContatoWorker.Profiles
{
    public class ContatoProfile : Profile
    {
        public ContatoProfile()
        {
            CreateMap<Contato, ContatoComando>().ReverseMap();
        }
    }
}
