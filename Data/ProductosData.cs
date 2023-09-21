using ApiRestTienda.Conexion;
using ApiRestTienda.Models;
using System.Data.SqlClient;
using System.Data;

namespace ApiRestTienda.Data
{
    public class ProductosData
    {
        ConexionBD cn = new ConexionBD();
        public async Task<List<ProductoModel>> MostrarProductos()
        {
            var lista = new List<ProductoModel>();
            using (var sql = new SqlConnection(cn.ConnectionString()))
            {
                using (var cmd = new SqlCommand("mostrarProductos", sql))
                {
                    await sql.OpenAsync();
                    cmd.CommandType = CommandType.StoredProcedure;
                    using (var item = await cmd.ExecuteReaderAsync())
                    {
                        while (await item.ReadAsync())
                        {
                            var model = new ProductoModel();
                            model.id_producto = (int)item["id_producto"];
                            model.nombre = (string)item["nombre"];
                            model.descripcion = (string)item["descripcion"];
                            model.precio = (decimal)item["precio"];
                            lista.Add(model);
                        }
                    }
                }
            }
            return lista;
        }
        public async Task InsertarProductos(ProductoModel parametros)
        {
            using (var sql = new SqlConnection(cn.ConnectionString()))
            {
                using (var cmd = new SqlCommand("insertarProductos", sql))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@nombre", parametros.nombre);
                    cmd.Parameters.AddWithValue("@descripcion", parametros.descripcion);
                    cmd.Parameters.AddWithValue("@precio", parametros.precio);
                    await sql.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();

                }
            }
        }
        public async Task EditarProductos(ProductoModel parametros)
        {
            using (var sql = new SqlConnection(cn.ConnectionString()))
            {
                using (var cmd = new SqlCommand("editarProductos", sql))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@id_producto", parametros.id_producto);
                    cmd.Parameters.AddWithValue("@precio", parametros.precio);
                    await sql.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();

                }
            }
        }
        public async Task EliminarProductos(ProductoModel parametros)
        {
            using (var sql = new SqlConnection(cn.ConnectionString()))
            {
                using (var cmd = new SqlCommand("eliminarProductos", sql))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@id_producto", parametros.id_producto);
                    await sql.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();

                }
            }
        }
    }
}
