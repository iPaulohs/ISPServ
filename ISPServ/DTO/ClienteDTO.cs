using ISPServ.Domain.Enum;

namespace ISPServ.DTO
{
    public record ClienteDTO
    {
        public string? Nome { get; set; }

        public string? CPF { get; set; }

        public string? RG { get; set; }

        public DateTime DataNascimento { get; set; }

        public EnderecoDTO? EnderecoResidencia { get; set; }

        public Sexo Sexo { get; set; }
    }
}
