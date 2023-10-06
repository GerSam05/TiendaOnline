using System.Net;

namespace TiendaOnline_API.Models
{
    public class APIResponse
    {
        public HttpStatusCode StatusCode { get; set; }
        public bool IsExitoso { get; set; } = true;
        public string? ErrorMessage { get; set; }
        public List<string>? ExceptionMessages { get; set; }
        public Object? Resultado { get; set; }


        public Object Editado() => Resultado = new { message = "Editado" };
        public Object Eliminado() => Resultado = new { message = "Eliminado" };

        public string ErrorNotFound(int id) => this.ErrorMessage = $"El Id={id} no existe en la base de datos";
        public string ErrorIdCero() => this.ErrorMessage = $"El Id debe ser mayor que cero (0)";
    }
}
