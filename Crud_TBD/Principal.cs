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
        private string[] campos;

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
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            // Preparar la conexión para así tener el comando
            comando.Connection = conectador.getConnection();
            conexión = conectador.getConnection();

            // Conseguir el tipo de guardado que se selecciono
            comando.CommandText = seleccionGuardar;

            // Setear al comando como lo que se recibio, es decir un procedimiento almacenado.
            comando.CommandType = CommandType.StoredProcedure;

            // Limpiar los parametros
            comando.Parameters.Clear();

            // Meter los datos al procedimiento
            for (int i = 0; i < campos.Length; i++)
            {
                comando.Parameters.AddWithValue(campos[i], textBoxes[i].Text.ToString());
                System.Console.Write(campos[i] + " " + textBoxes[i].Text.ToString() + " ");
            }

            // Ejecutar el procedimiento y guardar si se puedo ejecutar
            int respuesta = comando.ExecuteNonQuery();

            if (respuesta > 0)
            {
                // si se ejecuto entonces es mayor a 0 y si se guardaron los datos.
                MessageBox.Show("Los datos han sido guardados");
            }
            else
                MessageBox.Show("Error no se han guardado los datos!");

            // refrescar la vista de la tabla.
            mostrarTabla();

            // Limpiar los campos
            limpiar();

        }

        /// <summary>
        /// Método que actualiza algun campo seleccioando de la tabla.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void actualizar_Click(object sender, EventArgs e)
        {
            // Preparar la conexión para así tener el comando
            comando.Connection = conectador.getConnection();
            conexión = conectador.getConnection();

            // Conseguir el tipo de consulta que se selecciono
            comando.CommandText = seleccionActualizar;

            // Setear al comando como lo que se recibio, es decir un procedimiento almacenado.
            comando.CommandType = CommandType.StoredProcedure;

            // Limpiar los parametros
            comando.Parameters.Clear();

            // Meter los datos al procedimiento
            for (int i = 0; i < campos.Length; i++)
            {
                comando.Parameters.AddWithValue(campos[i], textBoxes[i].Text.ToString() );
                System.Console.Write(campos[i] + " " +textBoxes[i].Text.ToString() + " ");
            }

            // Ejecutar el procedimiento y guardar si se puedo ejecutar
            int respuesta = comando.ExecuteNonQuery();

            if (respuesta > 0)
            {
                // si se ejecuto entonces es mayor a 0 y si se guardaron los datos.
                MessageBox.Show("Los datos han sido actualizados");
            }
            else
                MessageBox.Show("Error no se han actualizados los datos!");

            // refrescar la vista de la tabla.
            mostrarTabla();

            // Limpiar los campos
            limpiar();

            
        }

        /// <summary>
        /// Método que limpia los campos
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            // Limpiar los campos
            limpiar();
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

                    // Colocar el encabezado del registro
                    label13.Text = "Registro Libros";

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

                    // Asignarle el tamaño al arreglo de campos.
                    campos = new string[10];

                    campos[0] = "p_Id_libro";
                    campos[1] = "p_ISBD_libro";
                    campos[2] = "p_Titulo_Libro";
                    campos[3] = "p_Nombre_Autor_Libro";
                    campos[4] = "p_Pimer_Apellido_Autor_Libro";
                    campos[5] = "p_Segundo_Apellido_Autor_Libro";
                    campos[6] = "p_Fecha_Pub_Libro";
                    campos[7] = "p_Editorial_Libro";
                    campos[8] = "p_Edicion_Libro";
                    campos[9] = "p_Genero_Libro";

                    // Llenar el arreglo con su respectivo tamaño
                    llenarTextBoxes10();

                    // Colocar los valores que se deben usar para poder mostrar, insertar, actualizar y eliminar en la tabla libros.
                    seleccionConsulta = "consultaLibros";
                    seleccionGuardar = "altaLibros";
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

                    // Colocar el encabezado del registro
                    label13.Text = "Registro Revistas";

                    // Aparecer el label 10 y 11 junto con los campos de texto si es que quitaron.
                    label9.Visible = true;
                    label10.Visible = true;
                    label11.Visible = true;
                    textBox9.Visible = true;
                    textBox10.Visible = true;
                    textBox11.Visible = true;


                    // Crear el arreglo de textBoxes correspondiente al tamaño de Revistas
                    textBoxes = new TextBox[11];

                    // Asignarle el tamaño al arreglo de campos.
                    campos = new string[11];

                    campos[0] = "p_Id_Revista";
                    campos[1] = "p_ISBN_Revista";
                    campos[2] = "p_Nombre_Revista";
                    campos[3] = "p_Anio_Revista";
                    campos[4] = "p_Editorial_Revista";
                    campos[5] = "p_Ciudad_Revista";
                    campos[6] = "p_Volumen_Revista";
                    campos[7] = "p_Numero_Revista";
                    campos[8] = "p_Nombre_Autor_Revista";
                    campos[9] = "p_Primer_Apellido_Autor_Revista";
                    campos[10] = "p_Segundo_Apellido_Autor_Revista";

                    llenarTextBoxes11();

                    System.Console.WriteLine("Se selecciono: " + seleccionTabla);

                    // Colocar los valores que se deben usar para poder mostrar, insertar, actualizar y eliminar en la tabla revistas.
                    seleccionConsulta = "consultaRevistas";
                    seleccionGuardar = "altaRevistas";
                    seleccionActualizar = "modificarRevistas";
                    seleccionarEliminar = "bajaRevistas";

                    // De último mostrar la tabla en si
                    mostrarTabla();
                    break;


                case "Investigaciones":
                    // Colocar las etiquetas con su respectivo campo
                    label1.Text = "Id";
                    label2.Text = "Fecha";
                    label3.Text = "Nombre";
                    label4.Text = "Tema";
                    label5.Text = "Autor";
                    label6.Text = "Primer Apellido";
                    label7.Text = "Segundo Apellido";
                    label8.Text = "Edicion";
                    label9.Text = "Finalizacion";

                    // Colocar el encabezado del registro
                    label13.Text = "Registro Investigaciones";

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

                    // Asignarle el tamaño al arreglo de campos.
                    campos = new string[9];

                    campos[0] = "p_Id_Investigacion";
                    campos[1] = "p_Fecha_Investigacion";
                    campos[2] = "p_Nombre_Investigacion";
                    campos[3] = "p_Tema_Investigacion";
                    campos[4] = "p_Nombre_Autor_Principal";
                    campos[5] = "p_Apellido_Paterno_Autor_Principal";
                    campos[6] = "p_Apellido_Materno_Autor_Principal";
                    campos[7] = "p_Edicion_Investigacion";
                    campos[8] = "p_Fecha_Terminacion_Investigacion";

                    llenarTextBoxes9();

                    // Colocar los valores que se deben usar para poder mostrar, insertar, actualizar y eliminar en la tabla Investigaciones.
                    seleccionConsulta = "consultaInvestigaciones";
                    seleccionGuardar = "altaInvestigaciones";
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

                    // Colocar el encabezado del registro
                    label13.Text = "Registro Software";

                    // Desaparecer el label 9, 10 y 11 junto los campos de texto.
                    label9.Visible = false;
                    label10.Visible = false;
                    label11.Visible = false;
                    textBox9.Visible = false;
                    textBox10.Visible = false;
                    textBox11.Visible = false;

                    // Crear el arreglo de textBoxes correspondiente al tamaño de Revistas
                    textBoxes = new TextBox[8];

                    // Asignarle el tamaño al arreglo de campos.
                    campos = new string[8];

                    campos[0] = "p_Id_Software";
                    campos[1] = "p_Nombre_Software";
                    campos[2] = "p_Empresa_Software";
                    campos[3] = "p_Desarrollador_Principal";
                    campos[4] = "p_Fecha_Lanzamiento";
                    campos[5] = "p_Version_Software";
                    campos[6] = "p_Tipo_Software";
                    campos[7] = "p_Compatibilidad_SO";

                    llenarTextBoxes8();

                    // Colocar los valores que se deben usar para poder mostrar, insertar, actualizar y eliminar en la tabla Investigaciones.
                    seleccionConsulta = "consultaSoftware";
                    seleccionGuardar = "altaSoftware";
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
        /// Método que selecciona la fila
        /// </summary>
        public void seleccionarFila()
        {
            // conseguir la fila selecionada.
            var fila = dataGridView1.CurrentRow;


            // Siempre hacer individual el ID.
             int id = Convert.ToInt32(fila.Cells[0].Value);
            textBoxes[0].Text = id.ToString();

            string comparador;

            // fecha auxiliar
            DateTime fechaAux = new DateTime(2001,01,01);

            // Poner los datos seleccionados despues del ID.
            for (int i = 1; i < campos.Length; i ++)
            {
                comparador = campos[i].ToString().ToLower();
                if (comparador.Contains("fecha") )
                {
                    fechaAux = Convert.ToDateTime(fila.Cells[i].Value);
                    textBoxes[i].Text = fechaAux.ToString("yyyy-MM-dd");
                }
                else
                {
                    // Coloar el texto dependiendo en que tenga.
                    textBoxes[i].Text = fila.Cells[i].Value.ToString();
                    System.Console.WriteLine(fila.Cells[i].Value.ToString());
                }
                
            }
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

        /// <summary>
        /// Método que cuando se de click a la tabla, seleccione la fila.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            seleccionarFila();
        }

        /// <summary>
        /// Método para eliminar algun dato seleccionado
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            // Preparar la conexión para así tener el comando
            comando.Connection = conectador.getConnection();
            conexión = conectador.getConnection();

            // Conseguir el tipo de consulta que se selecciono
            comando.CommandText = seleccionarEliminar;

            // Setear al comando como lo que se recibio, es decir un procedimiento almacenado.
            comando.CommandType = CommandType.StoredProcedure;

            // Limpiar los parametros
            comando.Parameters.Clear();

            // Meter los datos al procedimiento
            comando.Parameters.AddWithValue(campos[0], textBoxes[0].Text.ToString());

            // Ejecutar el procedimiento y guardar si se puedo ejecutar
            int respuesta = comando.ExecuteNonQuery();

            if (respuesta > 0)
            {
                // si se ejecuto entonces es mayor a 0 y si se guardaron los datos.
                MessageBox.Show("Los datos han sido borrados");
            }
            else
                MessageBox.Show("Error no se han borrados los datos!");

            // refrescar la vista de la tabla.
            mostrarTabla();

            // Limpiar los campos
            limpiar();


        }
    }
}
