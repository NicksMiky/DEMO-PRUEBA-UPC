

using backend.connection;
using backend.entidades;
using backend.servicios;

namespace backend_unit_test
{
    public class UnitTestProductos
    {
        public UnitTestProductos()
        {
            BDManager.GetInstance.ConnectionString = "workstation id=upc-database.mssql.somee.com;packet size=4096;user id=escalante_77_SQLLogin_4;pwd=l6yh7t1jfv;data source=upc-database.mssql.somee.com;persist security info=False;initial catalog=upc-database";
        }

        [Fact]
        public void Productos_Get_Verificar_NotNull()
        {
            var result = ProductoServicios.ObtenerTodo<Producto>();
            Assert.NotNull(result);
        }
        [Fact]
        public void Productos_GetById_VerificarItem()
        {
            var result = ProductoServicios.ObtenerById<Producto>(1);
            Assert.Equal(1, result.Id);
        }

        [Fact]
        public void Producto_Insertar()
        {
            Producto productoTemp = new()
            {
                Nombre = "Nombre Test",
                IdCategoria = 1
            };

            var result = ProductoServicios.InsertProducto(productoTemp);
            Assert.Equal(1, result);
        }

        [Fact]
        public void Productos_editar()
        {
             Producto productoTemp = new()
            {   
                Id = 1,
                Nombre = "Nombre Test",
                IdCategoria = 1
            };
            var result = ProductoServicios.UpdateProducto(productoTemp);
            Assert.Equal(1, result);
        }

        /*[Fact]
        public void Productos_eliminar()
        {
            int Id = 1;
            var result = ProductoServicios.DeleteProducto(Id);
            Assert.Equal(1, result);
        }*/

    }
}