namespace ISPServ.DTO
{
    public record UsuarioTokenDTO
    {
        public bool Autenticado { get; init; }

        public DateTime Expiracao { get; init; }

        public string? Token { get; init; }

        public string? Mensagem { get; init; }

        public string? UsuarioId { get; init; }

        public string? UserName { get; init; }
    }
}
