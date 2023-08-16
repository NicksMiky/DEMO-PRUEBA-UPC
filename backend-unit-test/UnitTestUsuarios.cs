

using backend.connection;
using backend.entidades;
using backend.servicios;

namespace backend_unit_test
{
    public class UnitTestUsuarios
    {
        public UnitTestUsuarios()
        {
            BDManager.GetInstance.ConnectionString = "workstation id=upc-database.mssql.somee.com;packet size=4096;user id=escalante_77_SQLLogin_4;pwd=l6yh7t1jfv;data source=upc-database.mssql.somee.com;persist security info=False;initial catalog=upc-database";
        }

        [Fact]
        public void Usuarios_Get_Verificar_NotNull()
        {
            var result = UsuariosServicios.ObtenerTodo<Usuarios>();
            Assert.NotNull(result);
        }
        [Fact]
        public void Usuarios_GetById_VerificarItem()
        {
            var result = UsuariosServicios.ObtenerById<Usuarios>(1);
            Assert.Equal(1, result.Id);
        }

        [Fact]
        public void Usuarios_Insertar()
        {
            Usuarios usuarioTemp = new()
            {
                NombreCompleto = "Nombre Test",
                UserName = "UserName Test",
                Password = "Password Test"
            };

            var result = UsuariosServicios.InsertUsuario(usuarioTemp);
            Assert.Equal(1, result);
        }

        [Fact]
        public void Usuarios_editar()
        {
            Usuarios usuarioTemp = new()
            {   
                Id = 1,
                NombreCompleto = "Nombre Test",
                UserName = "UserName Test",
                Password = "Password Test"
            };
            var result = UsuariosServicios.UpdateUsuario(usuarioTemp);
            Assert.Equal(1, result);
        }

        /*[Fact]
        public void Usuarios_eliminar()
        {
            int Id = 2;
            var result = UsuariosServicios.DeleteUsuario(Id);
            Assert.Equal(1, result);
        }*/

    }
}