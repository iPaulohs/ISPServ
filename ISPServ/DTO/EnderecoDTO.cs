using ISPServ.Domain.Enum;

namespace ISPServ.DTO
{
    public record EnderecoDTO
    {

        public string? Pais { get; set; }

        public Estado Estado { get; set; }

        public string? Cidade { get; set; }

        public string? Bairro { get; set; }

        public string? Rua { get; set; }

        public int Numero { get; set; }

        public string? Complemento { get; set; }
    }
}
