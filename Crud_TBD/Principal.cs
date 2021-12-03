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
        private TextBox[] textBoxes;

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

                    // Colocar las etiquetas con su respectivo campo
                    label1.Text = "Id";
                    label2.Text = "ISBD";
                    label3.Text = "Titulo";
                    label4.Text = "Nombre";
                    label5.Text = "Primer Apellido";
                    label6.Text = "Segundo Apellido";
                    label7.Text = "Fecha";
                    label8.Text = "Editorial";
                    label9.Text = "Edicion";
                    label10.Text = "Genero";


                    // Desaparecer el label 11 y el campo de texto.
                    label11.Visible = false;
                    textBox11.Visible = false;

                    // Aparecer el label 10 junto con el campo de texto si es que quitaron.
                    label9.Visible = true;
                    label10.Visible = true;
                    textBox9.Visible = true;
                    textBox10.Visible = true;

                    // Crear el arreglo de textBoxes correspondiente al tamaño de Libros
                    textBoxes = new TextBox[10];

                    // Llenar el arreglo con su respectivo tamaño
                    llenarTextBoxes10();

                    // Colocar los valores que se deben usar para poder mostrar, insertar, actualizar y eliminar en la tabla libros.
                    seleccionConsulta = "consultaLibros";
                    seleccionGuardar = "insertarLibros";
                    seleccionActualizar = "modificarLibros";
                    seleccionarEliminar = "bajaLibros";

                    // De último mostrar la tabla en si
                    mostrarTabla();
                    break;


                case "Revistas":

                    // Colocar las etiquetas con su respectivo campo
                    label1.Text = "Id";
                    label2.Text = "ISBD";
                    label3.Text = "Nombre";
                    label4.Text = "Año";
                    label5.Text = "Editorial";
                    label6.Text = "Ciudad";
                    label7.Text = "Volumen";
                    label8.Text = "Numero";
                    label9.Text = "Autor";
                    label10.Text = "Primer apellido";
                    label11.Text = "Segundo apellido";

                    // Aparecer el label 10 y 11 junto con los campos de texto si es que quitaron.
                    label9.Visible = true;
                    label10.Visible = true;
                    label11.Visible = true;
                    textBox9.Visible = true;
                    textBox10.Visible = true;
                    textBox11.Visible = true;


                    // Crear el arreglo de textBoxes correspondiente al tamaño de Revistas
                    textBoxes = new TextBox[11];

                    llenarTextBoxes11();

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
                    // Colocar las etiquetas con su respectivo campo
                    label1.Text = "Id";
                    label2.Text = "ISBD";
                    label3.Text = "Nombre";
                    label4.Text = "Año";
                    label5.Text = "Editorial";
                    label6.Text = "Ciudad";
                    label7.Text = "Volumen";
                    label8.Text = "Numero";
                    label9.Text = "Autor";

                    // Desaparecer el label 10 y 11 junto los campos de texto.
                    label10.Visible = false;
                    label11.Visible = false;
                    textBox10.Visible = false;
                    textBox11.Visible = false;

                    // Por si se desaparece el label 9 con su respectivo campo de texto.
                    label9.Visible = true;
                    textBox9.Visible = true;

                    // Crear el arreglo de textBoxes correspondiente al tamaño de Revistas
                    textBoxes = new TextBox[9];

                    llenarTextBoxes9();

                    // Colocar los valores que se deben usar para poder mostrar, insertar, actualizar y eliminar en la tabla Investigaciones.
                    seleccionConsulta = "consultaInvestigaciones";
                    seleccionGuardar = "insertarInvestigaciones";
                    seleccionActualizar = "modificarInvestigaciones";
                    seleccionarEliminar = "bajaInvestigaciones";

                    // De último mostrar la tabla en si
                    mostrarTabla();

                    System.Console.WriteLine("Se selecciono: " + seleccionTabla);
                    break;
                case "Software":

                    // Colocar las etiquetas con su respectivo campo
                    label1.Text = "Id";
                    label2.Text = "Nombre";
                    label3.Text = "Empresa";
                    label4.Text = "Derrollador(a)";
                    label5.Text = "Lanzamiento";
                    label6.Text = "Version";
                    label7.Text = "Tipo";
                    label8.Text = "Compatibilidad";

                    // Desaparecer el label 9, 10 y 11 junto los campos de texto.
                    label9.Visible = false;
                    label10.Visible = false;
                    label11.Visible = false;
                    textBox9.Visible = false;
                    textBox10.Visible = false;
                    textBox11.Visible = false;

                    // Crear el arreglo de textBoxes correspondiente al tamaño de Revistas
                    textBoxes = new TextBox[8];

                    llenarTextBoxes8();

                    // Colocar los valores que se deben usar para poder mostrar, insertar, actualizar y eliminar en la tabla Investigaciones.
                    seleccionConsulta = "consultaSoftware";
                    seleccionGuardar = "insertarSoftware";
                    seleccionActualizar = "modificarSoftware";
                    seleccionarEliminar = "bajaSoftware";

                    // De último mostrar la tabla en si
                    mostrarTabla();

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
            comando.CommandText =  seleccionConsulta;

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

        /// <summary>
        /// Método que llenta el arreglo de text boxes cuando este tiene 9 de tamaño.
        /// </summary>
        public void llenarTextBoxes8()
        {
            // Llenar el arreglo de textBoxes cuando son 10 campos.
            textBoxes[0] = textBox1;
            textBoxes[1] = textBox2;
            textBoxes[2] = textBox3;
            textBoxes[3] = textBox4;
            textBoxes[4] = textBox5;
            textBoxes[5] = textBox6;
            textBoxes[6] = textBox7;
            textBoxes[7] = textBox8;
        }

        /// <summary>
        /// Método que llenta el arreglo de text boxes cuando este tiene 9 de tamaño.
        /// </summary>
        public void llenarTextBoxes9()
        {
            // Llenar el arreglo de textBoxes cuando son 10 campos.
            textBoxes[0] = textBox1;
            textBoxes[1] = textBox2;
            textBoxes[2] = textBox3;
            textBoxes[3] = textBox4;
            textBoxes[4] = textBox5;
            textBoxes[5] = textBox6;
            textBoxes[6] = textBox7;
            textBoxes[7] = textBox8;
            textBoxes[8] = textBox9;
        }

        /// <summary>
        /// Método que llenta el arreglo de text boxes cuando este tiene 10 de tamaño.
        /// </summary>
        public void llenarTextBoxes10()
        {
            // Llenar el arreglo de textBoxes cuando son 10 campos.
            textBoxes[0] = textBox1;
            textBoxes[1] = textBox2;
            textBoxes[2] = textBox3;
            textBoxes[3] = textBox4;
            textBoxes[4] = textBox5;
            textBoxes[5] = textBox6;
            textBoxes[6] = textBox7;
            textBoxes[7] = textBox8;
            textBoxes[8] = textBox9;
            textBoxes[9] = textBox10;
        }

        /// <summary>
        /// Método que llenta el arreglo de text boxes cuando este tiene 10 de tamaño.
        /// </summary>
        public void llenarTextBoxes11()
        {
            // Llenar el arreglo de textBoxes cuando son 10 campos.
            textBoxes[0] = textBox1;
            textBoxes[1] = textBox2;
            textBoxes[2] = textBox3;
            textBoxes[3] = textBox4;
            textBoxes[4] = textBox5;
            textBoxes[5] = textBox6;
            textBoxes[6] = textBox7;
            textBoxes[7] = textBox8;
            textBoxes[8] = textBox9;
            textBoxes[9] = textBox10;
            textBoxes[10] = textBox11;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
