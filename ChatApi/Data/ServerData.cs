using ChatApi.Models;
using System.Data.SqlClient;
using System.Data;
using System.Xml.Linq;
using Microsoft.AspNetCore.Hosting.Server;

namespace ChatApi.Data
{
    public class ServerData
    {
        private readonly string cadenaSql;


        public ServerData(string conexion)
        {
            cadenaSql = conexion;
        }

        public List<ServerModel> listServers(ServerModel oserver)
        {
            List<ServerModel> serves = new List<ServerModel>();
            try
            {
                using(var conexion = new SqlConnection(cadenaSql))
                {
                    conexion.Open();
                    var cmd = new SqlCommand("sp_list_server", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    using (var rd = cmd.ExecuteReader() ) {

                        while(rd.Read())
                        {
                            serves.Add(new ServerModel
                            {
                                idServer = Convert.ToInt32(rd["idServer"]),
                                name = rd["name"].ToString(),
                                photo = rd["photo"].ToString()
                            }); 
                        }
                    }
                }
                return serves;
            }catch (Exception ex)
            {
                return new List<ServerModel>();
            }
        }

        public List<ServerModel> server(int id) {
            List<ServerModel> server = new List<ServerModel>();
            try
            {
                using (var conexion = new SqlConnection(cadenaSql))
                {
                    conexion.Open();
                    var cmd = new SqlCommand("sp_list_chat", conexion);
                    cmd.Parameters.AddWithValue("IdServer", id);
                    cmd.CommandType = CommandType.StoredProcedure;
                    using (var rd = cmd.ExecuteReader())
                    {
                        while (rd.Read())
                        {
                            server.Add(new ServerModel
                            {
                                idServer = Convert.ToInt32(rd["idServer"]),
                                name = rd["name"].ToString(),
                                photo = rd["photo"].ToString()
                            });
                        }
                    }
                }
                return server;
            }catch(Exception ex)
            {
                return new List<ServerModel>();
            }
        
        }
    }
}
