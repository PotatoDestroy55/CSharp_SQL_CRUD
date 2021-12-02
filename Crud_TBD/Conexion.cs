using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crud_TBD
{

    class Conexion
    {
        public static ConexionSql getConnection()
        {
            // Crear la conexión con la base de datos MySQL
            string conexion = "datasource=localhost;port3306;username=root;password=;database=biblioteca_de_itch";

            ConexionSql con = new ConexionSql();

        }


    }
}
