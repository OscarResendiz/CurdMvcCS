using crudcore.Models;
using System.Data.SqlClient;
using System.Data;
namespace crudcore.Datos
{
    public class ContactoDatos
    {
        public List<ContactoModel> Listar()
        {
            List<ContactoModel> lista=new List<ContactoModel>();
            Conexion cn=new Conexion();
            SqlConnection conexion = new SqlConnection(cn.getCadenaSQL());
            SqlCommand cmd = conexion.CreateCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "sp_Listar";
            cmd.Connection = conexion;
            cmd.Connection.Open();
            SqlDataReader dataReader = cmd.ExecuteReader();
            while (dataReader.Read())
            {
                ContactoModel model = new ContactoModel()
                {
                    Correo = dataReader["Correo"].ToString(),
                    IdContacto = int.Parse(dataReader["IdContacto"].ToString()),
                    Nombre = dataReader["Nombre"].ToString(),
                    Telefono = dataReader["Telefono"].ToString()
                };
                lista.Add(model);
            }
            dataReader.Close();
            cmd.Connection.Close();
            return lista;
        }

        public ContactoModel Obtener(int idcontacto)
        {
            ContactoModel Contacto = null;
            Conexion cn = new Conexion();
            SqlConnection conexion = new SqlConnection(cn.getCadenaSQL());
            SqlCommand cmd = conexion.CreateCommand();
            cmd.Connection = conexion;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "sp_Obtener";
            cmd.Parameters.Add("@idcontacto", SqlDbType.Int);
            cmd.Parameters["@idcontacto"].Value=idcontacto;
            cmd.Connection.Open();
            SqlDataReader dataReader = cmd.ExecuteReader();
            while (dataReader.Read())
            {
                Contacto = new ContactoModel()
                {
                    Correo = dataReader["Correo"].ToString(),
                    IdContacto = int.Parse(dataReader["IdContacto"].ToString()),
                    Nombre = dataReader["Nombre"].ToString(),
                    Telefono = dataReader["Telefono"].ToString()
                };
            }
            dataReader.Close();
            cmd.Connection.Close();
            return Contacto;
        }

        public bool Guardar(ContactoModel contacto)
        {
            try
            {
                Conexion cn = new Conexion();
                string cadena = cn.getCadenaSQL();
                SqlConnection conexion = new SqlConnection(cadena);
                SqlCommand cmd = conexion.CreateCommand();
                cmd.Connection = conexion;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "sp_Guardar";

                cmd.Parameters.Add("@nombre", SqlDbType.VarChar);
                cmd.Parameters.Add("@telefono", SqlDbType.VarChar);
                cmd.Parameters.Add("@correo", SqlDbType.VarChar);

                cmd.Parameters["@nombre"].Value = contacto.Nombre;
                cmd.Parameters["@telefono"].Value = contacto.Telefono;
                cmd.Parameters["@correo"].Value = contacto.Correo;

                cmd.Connection.Open();
                cmd.ExecuteNonQuery();
                cmd.Connection.Close();
            }
            catch (Exception ex)
            {
                return false;
            }
            return true;
        }
        public bool Actualizar(ContactoModel contacto )
        {
            try
            {
                Conexion cn = new Conexion();
                SqlConnection conexion = new SqlConnection(cn.getCadenaSQL());
                SqlCommand cmd = conexion.CreateCommand();
                cmd.Connection = conexion;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "sp_actualizar";

                cmd.Parameters.Add("@idcontacto", SqlDbType.Int);
                cmd.Parameters.Add("@nombre", SqlDbType.VarChar);
                cmd.Parameters.Add("@telefono", SqlDbType.VarChar);
                cmd.Parameters.Add("@correo", SqlDbType.VarChar);

                cmd.Parameters["@idcontacto"].Value = contacto.IdContacto;
                cmd.Parameters["@nombre"].Value = contacto.Nombre;
                cmd.Parameters["@telefono"].Value = contacto.Telefono;
                cmd.Parameters["@correo"].Value = contacto.Correo;

                cmd.Connection.Open();
                cmd.ExecuteNonQuery();
                cmd.Connection.Close();
            }
            catch   
            {
                return false; 
            }
            return true;

        }

        public bool Eliminar(int idcontacto)
        {
            try
            {
                Conexion cn = new Conexion();
                SqlConnection conexion = new SqlConnection(cn.getCadenaSQL());
                SqlCommand cmd = conexion.CreateCommand();
                cmd.Connection = conexion;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "sp_eliminar";

                cmd.Parameters.Add("@idcontacto", SqlDbType.Int);

                cmd.Parameters["@idcontacto"].Value = idcontacto;

                cmd.Connection.Open();
                cmd.ExecuteNonQuery();
                cmd.Connection.Close();
            }
            catch
            { 
                return false; 
            }
            return true;

        }



    }
}
