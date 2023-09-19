using ChatApi.Models;
using System.Data;
using System.Data.SqlClient;
namespace ChatApi.Data
{
    public class UserData
    {
        private readonly string cadenaSql;

        public UserData(string config)
        {
            cadenaSql = config;
        }

        public  List<UserModel> login(UserModel login)
        {
            List<UserModel> user = new List<UserModel>();

            try
            {
                using (var conexion = new SqlConnection(cadenaSql))
                {
                    conexion.Open();
                    var cmd = new SqlCommand("sp_search_user", conexion);
                    cmd.Parameters.AddWithValue("Name",login.name);
                    cmd.Parameters.AddWithValue("Password",login.password);
                    cmd.CommandType = CommandType.StoredProcedure;

                    using (var rd = cmd.ExecuteReader())
                    {
                        while (rd.Read())
                        {
                            user.Add(new UserModel()
                            {
                                iIdUser = Convert.ToInt32(rd["idUser"]),
                                name = rd["name"].ToString()
                            });
                        }
                    }
                }
                return user;
            }catch (Exception ex)
            {
                return new List<UserModel>();
            }
        }


        public bool creteUser(UserModel login)
        {
            try
            {
                using (var conexion = new SqlConnection(cadenaSql))
                {
                    conexion.Open();
                    var cmd = new SqlCommand("sp_create_user", conexion);
                    cmd.Parameters.AddWithValue("Name", login.name);
                    cmd.Parameters.AddWithValue("Password", login.password);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.ExecuteNonQuery();
                }
                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
        }
    }
}
