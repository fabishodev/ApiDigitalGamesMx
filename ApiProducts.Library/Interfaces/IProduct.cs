using System;
using System.Collections.Generic;
using System.Text;

namespace ApiProducts.Library.Interfaces
{
    public interface IProduct : IDisposable
    {
        List<Models.Producto> GetProducts();
        Models.Producto GetProduct(int id);
        int InsertProduct(string sku, string descripcion, int idPLataforma, int idGenero, int idClasificacion, string imagen, string titulo, string fechaLanzamiento);

    }
}
