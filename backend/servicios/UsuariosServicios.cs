using System.Data;
using backend.connection;
using backend.entidades;
using Dapper;

namespace backend.servicios
{
    public static class UsuariosServicios
    {
        public static IEnumerable<T> ObtenerTodo<T>()
        {
            const string sql = "select * from usuarios";
            return BDManager.GetInstance.GetData<T>(sql); //Dapper
        }

        public static T ObtenerById<T>(int id)
        {
        const string sql = "select * from usuarios where ID = @Id and estado_registro =1";
        var parameters = new DynamicParameters();
        parameters.Add("id", id, DbType.Int64);
        var result = BDManager.GetInstance.GetDataWithParameters<T>(sql,parameters);
        return result.FirstOrDefault();
        }

         public static int InsertUsuario(Usuarios usuarios)
        {
            const string sql = "INSERT INTO [dbo].[USUARIOS] ([USER_NAME], [NOMBRE_COMPLETO], [PASSWORD]) VALUES(@user_name,  @nombre_completo, @password)";
            var parameters = new DynamicParameters();
            parameters.Add("user_name", usuarios.UserName, DbType.String);
            parameters.Add("nombre_completo", usuarios.NombreCompleto, DbType.String);
            parameters.Add("password", usuarios.Password, DbType.String);

            var result = BDManager.GetInstance.SetData(sql, parameters);
            return result;
        }

        public static int UpdateUsuario(Usuarios usuarios)
        {
                const string sql = "UPDATE [dbo].[USUARIOS] SET NOMBRE_COMPLETO = @nombre_completo, USER_NAME = @user_name, PASSWORD = @password where ID = @Id";
                var parameters = new DynamicParameters();
                parameters.Add("id", usuarios.Id, DbType.Int64);
                parameters.Add("user_name", usuarios.UserName, DbType.String);
                parameters.Add("nombre_completo", usuarios.NombreCompleto, DbType.String);
                parameters.Add("password", usuarios.Password, DbType.String);

                var result = BDManager.GetInstance.SetData(sql, parameters);
                return result;
        }

        public static int DeleteUsuario(int id)
        {
             const string sql = "DELETE FROM [dbo].[USUARIOS] WHERE ID = @Id";
             var parameters = new DynamicParameters();
             parameters.Add("id" , id, DbType.Int64);

             var result = BDManager.GetInstance.SetData(sql,parameters);
             return result; 
        }
    }

}

    