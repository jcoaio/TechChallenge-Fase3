﻿namespace TechChallenge.Fase3.Consumer.Configurations
{
    public class BusConfiguration
    {
        public required string Servidor { get; set; }
        public required string Usuario { get; set; }
        public required string Senha { get; set; }
        public required string NomeFilaInsercao { get; set; }
        public required string NomeFilaEdicao { get; set; }
        public required string NomeFilaRemover { get; set; }
    }
}