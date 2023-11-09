using FilmesApi.Data.Dtos.Endereco;

namespace FilmesApi.Data.Dtos.Cinema;

public class ReadCinemaDto
{
    public int Id { get; set; }

    public string Nome { get; set; }
    
    public ReadEnderecoDto Endereco { get; set; }
}