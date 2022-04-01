using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using library;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Data.SqlTypes;



namespace library
{
    public class CADUsuario
    {

        private String constring;
        public CADUsuario()
        {
            constring = ConfigurationManager.ConnectionStrings["miconexion"].ToString();
        }
        public bool createUsuario(ENUsuario en)
        {
            SqlConnection conectar = null;
            bool success=false;
            try
            {
                conectar = new SqlConnection(constring);
                conectar.Open();
                String cadena = "Insert INTO [dbo].[Usuarios] (nombre, nif, edad) VALUES ('" + en._nombre + "', '" + en._nif + "', " + en._edad + ")";
                SqlCommand com = new SqlCommand(cadena, conectar);
                com.ExecuteNonQuery();
                success = true;
            }
            catch (SqlException ex)
            {
                Console.WriteLine("User operation has failed.Error: {0}", ex.Message);
                success = false;
            }
            catch (Exception ex)
            {
                Console.WriteLine("User operation has failed.Error: {0}", ex.Message);
                success = false;
            }
            finally
            {
                if (conectar != null)
                    conectar.Close();
            }
            return success;
        }
        public bool readUsuario(ENUsuario en)
        {
            SqlConnection conectar= null;
            bool success;
            success = true;
            try
            {
                conectar = new SqlConnection(constring);
                conectar.Open();
                SqlCommand com = new SqlCommand("Select * from [dbo].[Usuarios] Where nif = '" + en._nif + "' ", conectar);
                SqlDataReader buscar = com.ExecuteReader();
                buscar.Read();

                if (buscar["nif"].ToString() == en._nif)
                {
                    en._nombre = buscar["nombre"].ToString();
                    en._nif = buscar["nif"].ToString();
                    en._edad = int.Parse(buscar["edad"].ToString());
                }
                else success = false;
                buscar.Close();
            }
            catch (SqlException e)
            {
                success = false;
                Console.WriteLine("User operation has failed.Error: {0}", e.Message);
            }
            catch (Exception e)
            {
                success = false;
                Console.WriteLine("User operation has failed.Error: {0}", e.Message);
            }
            finally
            {
                if(conectar != null)
                    conectar.Close();
            }
            return success;
        }

        public bool readFirstUsuario(ENUsuario en)
        {
            bool success = false;
            SqlConnection conectar=null;
            try
            {
                conectar = new SqlConnection(constring);
                conectar.Open();
                SqlCommand com = new SqlCommand("Select * from [dbo].[Usuarios]", conectar);
                SqlDataReader buscar = com.ExecuteReader();

                buscar.Read();
                en._nombre = buscar["nombre"].ToString();
                en._nif = buscar["nif"].ToString();
                en._edad = int.Parse(buscar["edad"].ToString());
                success = true;
                buscar.Close();

            }
            catch (SqlException e)
            {
                success = false;
                Console.WriteLine("User operation has failed.Error: {0}", e.Message);
            }
            catch (Exception e)
            {
                success = false;
                Console.WriteLine("User operation has failed.Error: {0}", e.Message);
            }

            finally
            {
                if (conectar != null)
                    conectar.Close();
            }

            return success;

        }
        public bool readNextUsuario(ENUsuario en)
        {
            bool success;
            bool encuentra = false;
            SqlConnection conectar = null;
            try
            {
                conectar = new SqlConnection(constring);
                conectar.Open();
                SqlCommand com = new SqlCommand("Select * from [dbo].[Usuarios]", conectar);
                SqlDataReader buscar = com.ExecuteReader();

                while (buscar.Read())
                {
                    if (en._nif.ToString() == buscar["nif"].ToString())
                        encuentra = true;

                    else if (encuentra == true)
                    {
                        en._nombre = buscar["nombre"].ToString();
                        en._nif = buscar["nif"].ToString();
                        en._edad = int.Parse(buscar["edad"].ToString());
                        break;
                    }

                };

                success = true;
                buscar.Close();

            }
            catch (SqlException e)
            {
                success = false;
                Console.WriteLine("User operation has failed.Error: {0}", e.Message);
            }
            catch (Exception e)
            {
                success = false;
                Console.WriteLine("User operation has failed.Error: {0}", e.Message);
            }
            finally
            {
                if (conectar != null)
                    conectar.Close();
            }

            return success;
        }

        public bool readPrevUsuario(ENUsuario en)
        {
            bool success = false;
            SqlConnection conectar=null;
            try
            {
                conectar = new SqlConnection(constring);
                conectar.Open();
                SqlCommand com = new SqlCommand("Select * from [dbo].[Usuarios]", conectar);
                SqlDataReader search = com.ExecuteReader();

                search.Read();
                ENUsuario usuarioAuxiliar = new ENUsuario();


                while (search.Read() && success == false)
                {
                    usuarioAuxiliar._nombre = search["nombre"].ToString();
                    usuarioAuxiliar._nif = search["nif"].ToString();
                    usuarioAuxiliar._edad = int.Parse(search["edad"].ToString());
                    if (search["nif"].ToString() == en._nif)
                    {
                        success = true;
                    }
                }

                en._nombre = usuarioAuxiliar._nombre;
                en._nif = usuarioAuxiliar._nif;
                en._edad = usuarioAuxiliar._edad;

                search.Close();

            }
            catch (SqlException e)
            {
                success = false;
                Console.WriteLine("User operation has failed.Error: {0}", e.Message);
            }
            catch (Exception e)
            {
                success = false;
                Console.WriteLine("User operation has failed.Error: {0}", e.Message);
            }
            finally
            {
                if (conectar != null)
                    conectar.Close();
            }
            return success;
        }

        public bool updateUsuario(ENUsuario en)
        {
            bool success = true;
            SqlConnection conectar=null;
            try
            {
                conectar = new SqlConnection(constring);
                conectar.Open();
                SqlCommand com = new SqlCommand("UPDATE [dbo].[Usuarios] set nombre= '" + en._nombre + "' ,edad=" + en._edad + "WHERE nif = '" + en._nif + "'", conectar);
                com.ExecuteNonQuery();
            }
            catch (SqlException e)
            {
                success = false;
                Console.WriteLine("User operation has failed.Error: {0}", e.Message);
            }
            catch (Exception e)
            {
                success = false;
                Console.WriteLine("User operation has failed.Error: {0}", e.Message);
            }
            finally
            {
                if (conectar != null)
                    conectar.Close();
            }
            return success;
        }

        public bool deleteUsuario(ENUsuario en)
        {

            bool success = true;
            SqlConnection conectar=null;
            try
            {
                conectar = new SqlConnection(constring);
                conectar.Open();
                SqlCommand com = new SqlCommand("DELETE FROM [dbo].[Usuarios] WHERE nif = '"+en._nif+"'", conectar);
                com.ExecuteNonQuery();
            }
            catch (SqlException e)
            {
                success = false;
                Console.WriteLine("User operation has failed.Error: {0}", e.Message);
            }
            catch (Exception e)
            {
                success = false;
                Console.WriteLine("User operation has failed.Error: {0}", e.Message);
            }
            finally
            {
                if (conectar != null)
                    conectar.Close();
            }
            return success;
        }
    }
}

    

