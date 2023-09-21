using ApiRestTienda.Data;
using ApiRestTienda.Models;
using Microsoft.AspNetCore.Mvc;

namespace ApiRestTienda.Controllers
{
    [ApiController]
    [Route("api/productos")]
    public class ProductoController:ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<List<ProductoModel>>> GetProductos()
        {
            var funcion = new ProductosData();
            var lista = await funcion.MostrarProductos();
            return lista;
        }
        [HttpPost]
        public async Task InsertarProductos([FromBody] ProductoModel parametros)
        {
            var funcion = new ProductosData();
            await funcion.InsertarProductos(parametros);
        }
        [HttpPut("{id}")]
        public async Task<ActionResult> EditarProductos(int id, [FromBody] ProductoModel parametros)
        {
            var funcion = new ProductosData();
            parametros.id_producto = id;
            await funcion.EditarProductos(parametros);
            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> EliminarProductos(int id)
        {
            var funcion = new ProductosData();
            var parametros = new ProductoModel();
            parametros.id_producto = id;
            await funcion.EliminarProductos(parametros);
            return NoContent();
        }
    }
}
