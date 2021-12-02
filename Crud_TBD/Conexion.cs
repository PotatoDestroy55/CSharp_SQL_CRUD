using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Crud_TBD
{
    class Conexion
    {
        /// <summary>
        /// Método que realiza conexión a la base de datos en MySQL
        /// </summary>
        /// <returns>
        /// conexión
        /// </returns>
        public  MySqlConnection getConnection()
        {
            // Preparar el string para conectar con la base de datos
            string conexion = "datasource=localhost;port=3306;username=root;password=;database=biblioteca_de_itch";
            MySqlConnection connection = new MySqlConnection(conexion);
            try
            {
                // Intentar abrir la conexión
                connection.Open();
                System.Console.WriteLine("Conexión realizada con éxito");
            }
            catch(MySqlException exception)
            {
                // Si no se puede la conexión entonces remarcar que no se puedo realizar dicha conexión
                MessageBox.Show("No se puedo realizar la conexión . . . " + exception.Message);

            }
            return connection;
        }
    }
}
