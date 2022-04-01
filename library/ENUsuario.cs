using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace library
{
    public class ENUsuario
    {
        private String nif;
        private String nombre;
        private int edad;
        public String _nif {
            get { return nif; }
            set { nif = value; }
        }
        public String _nombre {
            get { return nombre; } 
            set { nombre = value; } 
        }
        public int _edad {
            get { return edad; }
            set { edad = value; }
        }
        public ENUsuario() {
            _nif = " ";
            _nombre = " ";
            _edad = 0;
        }
        public ENUsuario(String nif, String nombre, int edad)
        {
            _nif = nif;
            _nombre = nombre;
            _edad = edad;

        }
        public bool createUsuario()
        {
            CADUsuario usuario = new CADUsuario();
            bool hecho = false;
            if (!usuario.readUsuario(this))
            {
                hecho = usuario.createUsuario(this);
            }
            return hecho;
        }
        public bool readUsuario()
        {
            CADUsuario usuario = new CADUsuario();
            bool hecho = usuario.readUsuario(this);
            return hecho;
        }
        public bool readFirstUsuario()
        {
            CADUsuario usuario = new CADUsuario();
            bool hecho = usuario.readFirstUsuario(this);
            return hecho;
        }
        public bool readNextUsuario()
        {
            CADUsuario usuario = new CADUsuario();
            bool hecho = false;
            if (usuario.readUsuario(this))
                hecho = usuario.readNextUsuario(this);
            return hecho;
        }
        public bool readPrevUsuario()
        {
            bool hecho = false;
            CADUsuario usuario = new CADUsuario();
            ENUsuario usuarioAuxiliar = new ENUsuario(nif,nombre,edad);
            if (usuario.readFirstUsuario(this) && nif != usuarioAuxiliar.nif)
                hecho = usuario.readNextUsuario(this);
            return hecho;
        }
        public bool updateUsuario()
        {
            bool hecho = false;
            ENUsuario usuarioAuxiliar = new ENUsuario();
            CADUsuario usuario = new CADUsuario();
            usuarioAuxiliar.nombre = this.nombre;
            usuarioAuxiliar.nif = this.nif;
            usuarioAuxiliar.edad = this.edad;

            if (usuario.readUsuario(this))
            {
                this.nombre = usuarioAuxiliar.nombre;
                this.nif = usuarioAuxiliar.nif;
                this.edad = usuarioAuxiliar.edad;
                hecho = usuario.updateUsuario(this);
            }

            return hecho;
        }
        public bool deleteUsuario()
        {
            bool hecho = false;
            CADUsuario usuario = new CADUsuario();
            if (usuario.readUsuario(this))
            {
                hecho = usuario.deleteUsuario(this);
            }

            return hecho;
        }



    }
}
