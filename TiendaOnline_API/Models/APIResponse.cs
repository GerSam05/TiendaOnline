using System.Net;

namespace TiendaOnline_API.Models
{
    public class APIResponse
    {
        public HttpStatusCode StatusCode { get; set; }
        public bool IsSuccess { get; set; } = true;
        public string? Message { get; set; }
        public Object? Result { get; set; }
        

        public string Editado() => this.Message = "Elemento editado";
        public string Eliminado() => this.Message = "Elemento eliminado";
        public string ErrorNotFound() => this.Message = "El elemento no existe en la base de datos";
        public string ErrorBadRequest() => this.Message = "Error en petición";
    }
}
