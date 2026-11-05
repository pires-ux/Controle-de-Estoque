using Api.Models;

namespace Api.DTOs
{
    public class ResponseUsuarioDTO
    {
        public Usuario usuario { get; set; }
        public string token { get; set; }
    }
}
