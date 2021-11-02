using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;
using Prueba.Controllers;

namespace Prueba.Views
{
    public partial class mantenimientoCandidato : System.Web.UI.Page
    {
        conexionGeneral st = new conexionGeneral();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                limpiartxt();
                lblerror.Visible = false;
            }
        }
        public void limpiartxt()
        {
            dpi.Value = "";
            nombres.Value = "";
            apellidos.Value = "";
            direccion.Value = "";
            telefono.Value = "";
            escolaridad.Value = "";
            plaza.Value = "";
            dpi.Focus();
            lblerror.Visible = false;
        }

        public bool validarBlancos()
        {
            if (dpi.Value == "" || nombres.Value == "" || apellidos.Value == "" || direccion.Value == "" || telefono.Value == "" || escolaridad.Value == "" || plaza.Value == "")
            {
                lblerror.Visible = true;
                lblerror.Text = "";
                lblerror.Text = "Error: Uno de los campos se encuentra vacio";
                return false;
            }
            else
            {
                lblerror.Visible = false;
                return true;
            }
        }

        public void leerRegistro()
        {
            if(dpi.Value != "")
            {
                lblerror.Visible = false;
                string query = "SELECT * FROM tbl_candidato WHERE pk_CUI = " + dpi.Value + ";";
                MySqlConnection databaseConnection = new MySqlConnection(st.conexion());
                MySqlCommand commandDatabase = new MySqlCommand(query, databaseConnection);
                commandDatabase.CommandTimeout = 60;
                MySqlDataReader reader;
                try
                {
                    databaseConnection.Open();
                    reader = commandDatabase.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            string[] row = { reader.GetString(0), reader.GetString(1), reader.GetString(2), reader.GetString(3), reader.GetString(4), reader.GetString(5), reader.GetString(6), reader.GetString(7) };
                        }
                        dpi.Value = reader.GetString(0);
                        nombres.Value = reader.GetString(1);
                        apellidos.Value = reader.GetString(2);
                        direccion.Value = reader.GetString(3);
                        telefono.Value = reader.GetString(4);
                        escolaridad.Value = reader.GetString(5);
                        plaza.Value = reader.GetString(6);
                        if (reader.GetString(7) == "0")
                        {
                            lblerror.Visible = true;
                            lblerror.Text = "";
                            lblerror.Text = "El registro se encuentra eliminado, si lo modifica se activara.";
                        }
                        dpi.Focus();
                    }
                    else
                    {
                        lblerror.Visible = true;
                        lblerror.Text = "";
                        lblerror.Text = "No se encontro el registro";
                    }

                    // Cerrar la conexión
                    databaseConnection.Close();
                }
                catch (Exception ex)
                {
                    // Mostrar cualquier excepción
                    lblerror.Visible = true;
                    lblerror.Text = "";
                    lblerror.Text = "Error: " + ex.Message;
                }
            }
            else
            {
                // Mostrar cualquier excepción
                lblerror.Visible = true;
                lblerror.Text = "";
                lblerror.Text = "Coloque un numero de DPI";
            }
        }

        public void ingresarRegistro()
        {
            string query = "INSERT INTO tbl_candidato VALUES ('" + dpi.Value + "','" + nombres.Value + "','" + apellidos.Value + "','" + direccion.Value + "','" + telefono.Value + "','" + escolaridad.Value + "','" + plaza.Value + "','1');";
            lblerror.Visible = true;
            lblerror.Text = query;
            MySqlConnection databaseConnection = new MySqlConnection(st.conexion());
            MySqlCommand commandDatabase = new MySqlCommand(query, databaseConnection);
            commandDatabase.CommandTimeout = 60;

            try
            {
                databaseConnection.Open();
                MySqlDataReader myReader = commandDatabase.ExecuteReader();
                lblerror.Visible = true;
                databaseConnection.Close();
                limpiartxt();
                lblerror.Text = "";
                lblerror.Text = "Registro ingresado de manera exitosa";

            }
            catch (Exception ex)
            {
                // Mostrar cualquier error
                lblerror.Visible = true;
                lblerror.Text = "";
                lblerror.Text = "Error: " + ex.Message;
            }
        }
        
        public bool consultarRegistro()
        {
            if (dpi.Value != "")
            {
                lblerror.Visible = false;
                string query = "SELECT pk_CUI FROM tbl_candidato WHERE pk_CUI = " + dpi.Value + ";";
                MySqlConnection databaseConnection = new MySqlConnection(st.conexion());
                MySqlCommand commandDatabase = new MySqlCommand(query, databaseConnection);
                commandDatabase.CommandTimeout = 60;
                MySqlDataReader reader;
                try
                {
                    databaseConnection.Open();
                    reader = commandDatabase.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            string[] row = { reader.GetString(0) };
                        }
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                    // Cerrar la conexión
                    databaseConnection.Close();
                }
                catch (Exception ex)
                {
                    // Mostrar cualquier excepción
                    lblerror.Visible = true;
                    lblerror.Text = "";
                    lblerror.Text = "Error: " + ex.Message;
                    return true;
                }
            }
            else
            {
                // Mostrar cualquier excepción
                lblerror.Visible = true;
                lblerror.Text = "";
                lblerror.Text = "Coloque un numero de DPI";
                return true;
            }
        }

        public void eliminarRegistro()
        {
            if (dpi.Value != "")
            {
                string query = "UPDATE tbl_candidato SET estado='0' WHERE pk_CUI = '" + dpi.Value + "';";
                MySqlConnection databaseConnection = new MySqlConnection(st.conexion());
                MySqlCommand commandDatabase = new MySqlCommand(query, databaseConnection);
                commandDatabase.CommandTimeout = 60;
                MySqlDataReader reader;

                try
                {
                    databaseConnection.Open();
                    reader = commandDatabase.ExecuteReader();

                    // Actualizado satisfactoriamente

                    databaseConnection.Close();
                    limpiartxt();
                    lblerror.Visible = true;
                    lblerror.Text = "";
                    lblerror.Text = "Registro eliminado de forma correcta";
                }
                catch (Exception ex)
                {
                    // Mostrar cualquier excepción
                    lblerror.Visible = true;
                    lblerror.Text = "";
                    lblerror.Text = "Numero de DPI no registrado";
                }
            }else
            {
                // Mostrar cualquier excepción
                lblerror.Visible = true;
                lblerror.Text = "";
                lblerror.Text = "Coloque un numero de DPI";
            }
        }

        public void modificarRegistro()
        {
            if (dpi.Value != "")
            {
                string query = "UPDATE tbl_candidato SET pk_CUI = '" + dpi.Value + "', nombres = '" + nombres.Value + "', apellidos = '" + apellidos.Value + "', direccion = '" + direccion.Value + "', telefono = '"+ telefono.Value + "', escolaridad ='" + escolaridad.Value + "', plaza = '" + plaza.Value + "', estado='1' WHERE pk_CUI = '" + dpi.Value + "';";
                MySqlConnection databaseConnection = new MySqlConnection(st.conexion());
                MySqlCommand commandDatabase = new MySqlCommand(query, databaseConnection);
                commandDatabase.CommandTimeout = 60;
                MySqlDataReader reader;

                try
                {
                    databaseConnection.Open();
                    reader = commandDatabase.ExecuteReader();

                    // Actualizado satisfactoriamente

                    databaseConnection.Close();
                    limpiartxt();
                    lblerror.Visible = true;
                    lblerror.Text = "";
                    lblerror.Text = "Registro modificado de manera exitosa";
                }
                catch (Exception ex)
                {
                    // Mostrar cualquier excepción
                    lblerror.Visible = true;
                    lblerror.Text = "";
                    lblerror.Text = "Numero de DPI no registrado";
                }
            }
            else
            {
                // Mostrar cualquier excepción
                lblerror.Visible = true;
                lblerror.Text = "";
                lblerror.Text = "Coloque un numero de DPI";
            }
        }
        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            if(validarBlancos() == true)
              if(consultarRegistro() == false)
                 ingresarRegistro();
                else
                {
                    lblerror.Visible = true;
                    lblerror.Text = "";
                    lblerror.Text = "Registro duplicado";
                }
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            leerRegistro();
        }

        protected void btnLimpiar_Click(object sender, EventArgs e)
        {
            limpiartxt();
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            if (consultarRegistro() == true)
               eliminarRegistro();
            else
            {
               lblerror.Visible = true;
               lblerror.Text = "";
               lblerror.Text = "Registro duplicado";
            }
        }

        protected void btnModificar_Click(object sender, EventArgs e)
        {
            if (validarBlancos() == true)
               modificarRegistro();
            else
            {
               lblerror.Visible = true;
               lblerror.Text = "";
               lblerror.Text = "Ingrese un numero de DPI";
            }
        }

        protected void regresar_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Menu.aspx");
        }

        protected void regresar_Click1(object sender, EventArgs e)
        {
            Response.Redirect("/views/Menu.aspx");
        }
    }
}