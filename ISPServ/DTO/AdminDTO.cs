namespace ISPServ.DTO
{
    public record AdminDTO
    {
        public string? Nome { get; set; }

        public string? Email { get; set; }

        public string? Password { get; set; }

        public string? Setor { get; set; }

        public string? Cargo { get; set; }

        public DateTime DataNascimento { get; set; }

        public bool IsSuperadmin { get; set; } = false;

        public string? CPF { get; set; }
    }
}
