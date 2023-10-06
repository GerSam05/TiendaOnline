using Bodega_API.Conexion;
using Microsoft.Data.SqlClient;
using TiendaOnline_API.Models;
using System.Data;
using System.Reflection.PortableExecutable;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace TiendaOnline_API.Data
{
    public class DataArticulo
    {
        private readonly ConexionBd cn = new();
        protected APIResponse _response;
        public DataArticulo()
        {
            _response = new();
        }

        public async Task<APIResponse> MostrarArticulos()
        {
            List<Articulo> lista = new();
            try
            {
                using (var sql = new SqlConnection(cn.CadenaSQL()))
                {
                    var cmd = new SqlCommand("sp_ListarArticulos", sql);
                    cmd.CommandType = CommandType.StoredProcedure;
                    sql.Open();

                    using (var rd = cmd.ExecuteReader())
                    {
                        while (await rd.ReadAsync())
                        {
                            var articulo = new Articulo
                            {
                                Id = (int)rd["Id"],
                                Codigo = (string)rd["Codigo"],
                                Nombre = (string)rd["Nombre"],
                                Marca = (string)rd["Marca"],
                                Categoria = (string)rd["Categoria"],
                                Precio = (decimal)rd["Precio"]
                            };

                            lista.Add(articulo);
                        }
                    }
                }
                _response.Resultado = lista;
                _response.StatusCode = HttpStatusCode.OK;
                return _response;
            }
            catch (Exception ex)
            {
                _response.IsExitoso = false;
                _response.StatusCode = HttpStatusCode.InternalServerError;
                _response.ExceptionMessages = new List<string> { ex.ToString() };
            }
            return _response;
        }

        public async Task<APIResponse> ObtenerArticulo(int id)
        {
            List<Articulo> lista = new();
            Articulo articuloId = new();
            try
            {
                using (var sql = new SqlConnection(cn.CadenaSQL()))
                {
                    var cmd = new SqlCommand("sp_ListarArticulos", sql);
                    cmd.CommandType = CommandType.StoredProcedure;
                    sql.Open();

                    using (var rd = cmd.ExecuteReader())
                    {
                        while (await rd.ReadAsync())
                        {
                            var articulo = new Articulo
                            {
                                Id = (int)rd["Id"],
                                Codigo = (string)rd["Codigo"],
                                Nombre = (string)rd["Nombre"],
                                Marca = (string)rd["Marca"],
                                Categoria = (string)rd["Categoria"],
                                Precio = (decimal)rd["Precio"]
                            };

                            lista.Add(articulo);
                        }
                    }
                }
                articuloId = lista.Where(i => i.Id == id).FirstOrDefault();

                if (articuloId == null)
                {
                    _response.StatusCode = HttpStatusCode.NotFound;
                    _response.ErrorNotFound(id);
                    return _response;
                }
                _response.Resultado = articuloId;
                _response.StatusCode = HttpStatusCode.OK;
                return _response;
            }
            catch (Exception ex)
            {
                _response.IsExitoso = false;
                _response.ExceptionMessages = new List<string> { ex.ToString() };
            }
            return _response;
        }

        public async Task<APIResponse> ObtenerArticuloId(int id)
        {
            List<Articulo> lista = new();
            Articulo articuloId = new();
            try
            {
                using (var sql = new SqlConnection(cn.CadenaSQL()))
                {
                    var cmd = new SqlCommand("sp_ListarArticulos", sql);
                    cmd.CommandType = CommandType.StoredProcedure;
                    sql.Open();

                    using (var rd = cmd.ExecuteReader())
                    {
                        while (await rd.ReadAsync())
                        {
                            var articulo = new Articulo
                            {
                                Id = (int)rd["Id"],
                                Codigo = (string)rd["Codigo"],
                                Nombre = (string)rd["Nombre"],
                                Marca = (string)rd["Marca"],
                                Categoria = (string)rd["Categoria"],
                                Precio = (decimal)rd["Precio"]
                            };

                            lista.Add(articulo);
                        }
                    }
                }
                articuloId = lista.Where(i => i.Id == id).FirstOrDefault();

                if (articuloId == null)
                {
                    _response.ErrorNotFound(id);
                    return _response;
                }
                _response.Resultado = articuloId;
                return _response;
            }
        }

        public async Task<APIResponse> GuardarArticulo([FromBody]Articulo newArticulo)
        {
            try
            {
                using (var sql = new SqlConnection(cn.CadenaSQL()))
                {
                    var cmd = new SqlCommand("sp_GuardarArticulo", sql);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@codigo", newArticulo.Codigo);
                    cmd.Parameters.AddWithValue("@nombre", newArticulo.Nombre);
                    cmd.Parameters.AddWithValue("@marca", newArticulo.Marca);
                    cmd.Parameters.AddWithValue("@categoria", newArticulo.Categoria);
                    cmd.Parameters.AddWithValue("@precio", newArticulo.Precio);

                    await sql.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();
                }
                _response.Resultado = newArticulo;
                _response.StatusCode = HttpStatusCode.Created;
                return _response;
            }
            catch (Exception ex)
            {
                _response.IsExitoso = false;
                _response.StatusCode = HttpStatusCode.InternalServerError;
                _response.ExceptionMessages = new List<string> { ex.ToString() };
            }
            return _response;
        }

        public async Task<APIResponse> EditarArticulo([FromBody] Articulo newArticulo)
        {
            try
            {
                using (var sql = new SqlConnection(cn.CadenaSQL()))
                {
                    var cmd = new SqlCommand("sp_EditarArticulo", sql);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Id", newArticulo.Id == 0 ? DBNull.Value : newArticulo.Id);
                    cmd.Parameters.AddWithValue("@codigo", newArticulo.Codigo is null ? DBNull.Value : newArticulo.Codigo);
                    cmd.Parameters.AddWithValue("@nombre", newArticulo.Nombre is null ? DBNull.Value : newArticulo.Nombre);
                    cmd.Parameters.AddWithValue("@marca", newArticulo.Marca is null ? DBNull.Value : newArticulo.Marca);
                    cmd.Parameters.AddWithValue("@categoria", newArticulo.Categoria is null ? DBNull.Value : newArticulo.Categoria);
                    cmd.Parameters.AddWithValue("@precio", newArticulo.Precio == 0 ? DBNull.Value : newArticulo.Precio);

                    await sql.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();
                }
                _response.Editado();
                _response.StatusCode = HttpStatusCode.OK;
                return _response;
            }
            catch (Exception ex)
            {
                _response.IsExitoso = false;
                _response.StatusCode = HttpStatusCode.InternalServerError;
                _response.ExceptionMessages = new List<string> { ex.ToString() };
            }
            return _response;
        }



    }
}
