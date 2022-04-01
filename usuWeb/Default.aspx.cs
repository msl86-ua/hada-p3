using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using library;

namespace usuWeb
{
    public partial class WebForm1 : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            mensajeDeSalida.Text = "";
        }

        protected void whenLeer(object sender, EventArgs e)
        {
            if (user_NIF.Text == "")
                mensajeDeSalida.Text = "No se ha introducido el NIF";
            else
            {
                ENUsuario usuario = new ENUsuario();
                usuario._nif = user_NIF.Text;

                if (usuario.readUsuario() == true)
                {
                    user_NIF.Text = usuario._nif;
                    user_NAME.Text = usuario._nombre;
                    user_AGE.Text = usuario._edad.ToString();
                    mensajeDeSalida.Text = "Usuario con NIF " + usuario._nif + "mostrado correctamente";
                }
                else
                    mensajeDeSalida.Text = "El usuario introducido no se encuentra almacenado en la base de datos";
            }
        }

        protected void whenLeerPrimero(object sender, EventArgs e)
        {
            ENUsuario usuario = new ENUsuario();
            if (usuario.readFirstUsuario() == true)
            {
                user_NIF.Text = usuario._nif;
                user_NAME.Text = usuario._nombre;
                user_AGE.Text = usuario._edad.ToString();
                mensajeDeSalida.Text = "Primer usuario " + usuario._nif + " mostrado de manera satisfactoria";
            }
            else mensajeDeSalida.Text = "Base de datos sin usuarios";
        }

        protected void whenLeerAnterior(object sender, EventArgs e)
        {

            if (user_NIF.Text != "" && user_NAME.Text != "" && user_AGE.Text != "")
            {
                ENUsuario usuario = new ENUsuario();
                usuario._nif = user_NIF.Text;
                usuario._nombre = user_NAME.Text;
                bool isNumeric = int.TryParse(user_AGE.Text, out _);
                if (isNumeric == true)
                {
                    usuario._edad = int.Parse(user_AGE.Text);
                    if (usuario.readPrevUsuario())
                    {
                        user_NIF.Text = usuario._nif;
                        user_NAME.Text = usuario._nombre;
                        user_AGE.Text = usuario._edad.ToString();
                        mensajeDeSalida.Text = "Anterior usuario registrado mostrado satisfactoriamente";
                    }
                    else mensajeDeSalida.Text = "No hay usuarios anteriores al indicado";
                }
                else
                    mensajeDeSalida.Text = "Error al introducir los datos. Edad no es un numero";
            }

            else mensajeDeSalida.Text = "Error al introducir los datos";
        }

        protected void whenLeerSiguiente(object sender, EventArgs e)
        {
            if (user_NIF.Text != "" && user_NAME.Text != "" && user_AGE.Text != "")
            {
                ENUsuario usuario = new ENUsuario();
                usuario._nif = user_NIF.Text;
                usuario._nombre = user_NAME.Text;
                bool isNumeric = int.TryParse(user_AGE.Text, out _);
                if (isNumeric == true)
                {
                    usuario._edad = int.Parse(user_AGE.Text);
                    if (usuario.readNextUsuario() == true)
                    {
                        user_NAME.Text = usuario._nombre;
                        user_NIF.Text = usuario._nif;
                        user_AGE.Text = usuario._edad.ToString();
                        mensajeDeSalida.Text = "Siguiente usuario mostrado satisfactoriamente.";
                    }
                    else
                        mensajeDeSalida.Text = "No hay más usuarios registrados en la base de datos";
                }
                else
                    mensajeDeSalida.Text = "Error al introducir los datos. Edad no es un numero";

            }
            else mensajeDeSalida.Text = "Error al introducir los datos";
        }

        protected void whenCrear(object sender, EventArgs e)
        {
            if (user_NIF.Text != "" && user_NAME.Text != "" && user_AGE.Text != "")
            {
                ENUsuario usuario = new ENUsuario
                {
                    _nif = user_NIF.Text,
                    _nombre = user_NAME.Text
                };
                bool isNumeric = int.TryParse(user_AGE.Text, out _);
                if (isNumeric == true)
                {
                    usuario._edad = int.Parse(user_AGE.Text);
                    if (usuario.createUsuario())
                        mensajeDeSalida.Text = "Usuario " + usuario._nif + " insertado en la base de datos";
                    else
                        mensajeDeSalida.Text = "No se pudo realizar la inserción";

                }

                else mensajeDeSalida.Text = "Error al introducir los datos. Edad no es un numero";

            }
            else
                mensajeDeSalida.Text = "No se pudo realizar la inserción";
        }

        protected void whenActualizar(object sender, EventArgs e)
        {
            if (user_NIF.Text != "" && user_NAME.Text != "" && user_AGE.Text != "")
            {
                ENUsuario usuario = new ENUsuario();
                usuario._nif = user_NIF.Text;
                usuario._nombre = user_NAME.Text;
                bool isNumeric = int.TryParse(user_AGE.Text, out _);
                if (isNumeric == true)
                {
                    usuario._edad = int.Parse(user_AGE.Text);
                    if (usuario.updateUsuario() == true)
                    {
                        mensajeDeSalida.Text = "El usuario " + usuario._nif + " ha sido actualizado";
                    }
                    else mensajeDeSalida.Text = "El usuario no se encuentra en la base de datos";
                }

                else
                    mensajeDeSalida.Text = "Error al introducir los datos. Edad no es un numero";
            }
            else mensajeDeSalida.Text = "Error al introducir los datos";

        }

        protected void whenBorrar(object sender, EventArgs e)
        {
            if (user_NIF.Text != "" && user_NAME.Text != "" && user_AGE.Text != "")
            {
                ENUsuario usuario = new ENUsuario();
                usuario._nif = user_NIF.Text;
                usuario._nombre = user_NAME.Text;
                bool isNumeric = int.TryParse(user_AGE.Text, out _);
                if (isNumeric == true)
                {
                    usuario._edad = int.Parse(user_AGE.Text);
                    if (usuario.deleteUsuario() == true)
                        mensajeDeSalida.Text = "El usuario con nif: " + usuario._nif + ", ha sido borrado";
                    else mensajeDeSalida.Text = "El usuario introducido no se puede borrar";

                }
                else
                    mensajeDeSalida.Text = "Error al introducir los datos. Edad no es un numero";
            }
            else mensajeDeSalida.Text = "Error al introducir los datos";

        }
    }
}