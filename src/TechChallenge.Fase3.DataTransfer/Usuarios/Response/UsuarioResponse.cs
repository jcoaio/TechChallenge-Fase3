﻿namespace TechChallenge.Fase3.DataTransfer.Usuarios.Response
{
    public class UsuarioResponse
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public DateTime DataCriacao { get; set; }
        public int Permissao { get; set; }

        public UsuarioResponse()
        {

        }
    }
}
