using WebApplication1.Models;
using System.Data.SqlClient;
using System.Data;

namespace WebApplication1.Datos
{
    public class ClienteDatos
    {
        public List<ClienteModel> Listar()
        {
            var oLista = new List<ClienteModel>();
            var cn = new Conexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL())) 
            {
                Conexion.Open();
                SqlCommand cmd = new SqlCommand("sp_Listar");
                cmd.CommandType = CommandType.StoredProcedure;
                
                using (var dr = cmd.ExecuteReader()) 
                {
                    while (dr.Read())
                    {
                        oLista.Add(new ClienteModel()
                        {
                            Id_c = Convert.ToInt32(dr["Id_c"]),
                            nom_c = dr["nom_c"].ToString(),
                            tel_c = dr["nom_c"].ToString(),
                            cor_c = dr["nom_c"].ToString()
                        });
                    }
                }
                
                    
                
            }

            return oLista;
        }
        public ClienteModel Obtener(int Id_c)
        {
            var oCliente = new ClienteModel();
            var cn = new Conexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                Conexion.Open();
                SqlCommand cmd = new SqlCommand("sp_Obtener", conexion);
                cmd.Parameters.AddWithValue("Id_c", Id_c);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        oCliente.Id_c = Convert.ToInt32(dr["Id_c"]);
                        oCliente.nom_c = dr["nom_c"].ToString();
                        oCliente.tel_c = dr["nom_c"].ToString();
                        oCliente.cor_c = dr["nom_c"].ToString();
                    }
                }



            }

            return oCliente;
        }
        public bool Guardar(ClienteModel ocontacto)
        {
            bool rpta;

            try
            {
                var cn = new Conexion();

                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("sp_Guardar", conexion);
                    cmd.Parameters.AddWithValue("nom_c", ocontacto.nom_c);
                    cmd.Parameters.AddWithValue("tel_c", ocontacto.tel_c);
                    cmd.Parameters.AddWithValue("cor_c", ocontacto.cor_c);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();
                }
                rpta = true;


            }
            catch (Exception e)
            {

                string error = e.Message;
                rpta = false;
            }



            return rpta;
        }
        public bool Editar(ClienteModel ocliente)
        {
            bool rpta;

            try
            {
                var cn = new Conexion();

                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("sp_Editar", conexion);
                    cmd.Parameters.AddWithValue("Id_c", ocliente.Id_c);
                    cmd.Parameters.AddWithValue("nom_c", ocliente.nom_c);
                    cmd.Parameters.AddWithValue("tel_c", ocliente.tel_c);
                    cmd.Parameters.AddWithValue("cor_c", ocliente.cor_c);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();
                }
                rpta = true;


            }
            catch (Exception e)
            {

                string error = e.Message;
                rpta = false;
            }
            return rpta;
        }

        public bool Eliminar(int Id_c)
        {
            bool rpta;

            try
            {
                var cn = new Conexion();

                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("sp_Eliminar", conexion);
                    cmd.Parameters.AddWithValue("Id_c", Id_c);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();
                }
                rpta = true;


            }
            catch (Exception e)
            {
                string error = e.Message;
                rpta = false;
            }
            return rpta;
        }


    }
}
