using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Crud_TBD
{
    

    public partial class Principal : Form
    {
        // Atributos de la clase.
        private MySqlConnection conexión;
        private Conexion conectador = new Conexion();
        private string seleccionTabla;
        private readonly ComboBox seleccion = new ComboBox();
        private MySqlCommand comando = new MySqlCommand();
        MySqlDataReader leerFilas;

        // Seleccionadores de los procedimientos
        private string seleccionConsulta;
        private string seleccionGuardar;
        private string seleccionActualizar;
        private string seleccionarEliminar;

        public Principal()
        {
            InitializeComponent();
        }
        
        /// <summary>
        /// Método que actualiza algun campo seleccioando de la tabla.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void actualizar_Click(object sender, EventArgs e)
        {
            System.Console.Write("prueba");
        }

       /// <summary>
       /// Método que cuando carga la pantalla principal carga la base de datos.
       /// </summary>
       /// <param name="sender"></param>
       /// <param name="e"></param>
        private void Principal_Load(object sender, EventArgs e)
        {
            // Inicar la conexión
            conexión = conectador.getConnection();
            

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Método que cuando algo se elige de ver este mismo prepara los datos.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void comboBoxEleccion_Click(object sender, EventArgs e)
        {
            seleccionTabla = (string)comboBoxEleccion.SelectedItem;
            switch (seleccionTabla)
            {
                case "Libros":
                    System.Console.WriteLine("Se selecciono: " + seleccionTabla);

                    // Colocar los valores que se deben usar para poder mostrar, insertar, actualizar y eliminar en la tabla libros.
                    seleccionConsulta = "consultaLibros";
                    seleccionGuardar = "insertarLibros";
                    seleccionActualizar = "modificarLibros";
                    seleccionarEliminar = "bajaLibros";

                    // De último mostrar la tabla en si
                    mostrarTabla();
                    break;


                case "Revistas":
                    System.Console.WriteLine("Se selecciono: " + seleccionTabla);

                    // Colocar los valores que se deben usar para poder mostrar, insertar, actualizar y eliminar en la tabla revistas.
                    seleccionConsulta = "consultaRevistas";
                    seleccionGuardar = "insertarRevistas";
                    seleccionActualizar = "modificarRevistas";
                    seleccionarEliminar = "bajaRevistas";

                    // De último mostrar la tabla en si
                    mostrarTabla();
                    break;


                case "Investigaciones":
                    System.Console.WriteLine("Se selecciono: " + seleccionTabla);
                    break;
                case "Software":
                    System.Console.WriteLine("Se selecciono: " + seleccionTabla);
                    break;


            }
            
        }

        /// <summary>
        /// Método que muestra la tabla con el dato especificado.
        /// </summary>
        public void mostrarTabla()
        {
            // Crear la tabla modelo.
            DataTable Tabla = new DataTable();

            // Preparar la conexión para así tener el comando
            comando.Connection = conectador.getConnection();
            conexión = conectador.getConnection();

            // Conseguir el tipo de consulta que se selecciono
            comando.CommandText = seleccionConsulta;

            // Setear al comando como lo que se recibio, es decir un procedimiento almacenado.
            comando.CommandType = CommandType.StoredProcedure;

            // Agarrar la consulta que se genero por el procedimiento almacenado.
            leerFilas = comando.ExecuteReader();

            // Cargar a la tabla modelo los datos de la consulta.
            Tabla.Load(leerFilas);

            // Añadir al visualizador de datos la tabla construida por la consutla.
            dataGridView1.DataSource = Tabla;

            // Cerrar la conexión y también la lectura de filas.
            leerFilas.Close();

            conexión.Close();

        }

        /// <summary>
        /// Método que limpia los campos de texto para ingresar nuevos datos.
        /// </summary>
        public void limpiar()
        {
            // Limpiar los labels.
            textBox1.ResetText();
            textBox2.ResetText();
            textBox3.ResetText();
            textBox4.ResetText();
            textBox5.ResetText();
            textBox6.ResetText();
            textBox7.ResetText();
            textBox8.ResetText();
            textBox9.ResetText();
            textBox10.ResetText();
            textBox11.ResetText();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
