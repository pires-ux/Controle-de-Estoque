using Api.Migrations;
using Api.Models;

namespace Api.DTOs.Usuario
{
    public class ResponseUsuarioDTO
    {
        public Models.Usuario usuario { get; set; }
        public string token { get; set; }


    }
}
