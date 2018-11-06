using Microsoft.Extensions.Configuration;
using PrihApi.Interfaces;
using PrihApi.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace PrihApi.Services
{
    public class PrihDBManager : IPrihDBManager
    {
        private readonly IConfiguration _configuration;

        public PrihDBManager(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public bool InsertBar(BarData barData)
        {
            using (var connection = new SqlConnection(_configuration["dbconfig:prihconnectionstring"]))
            {
                SqlCommand cmd = connection.CreateCommand();
                connection.Open();
                cmd.Connection = connection;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "[PRIHCERVEJEIRA].[InserirBar]";

                var Nome = new SqlParameter("@Nome", SqlDbType.NVarChar);
                Nome.Value = barData.Name;
                cmd.Parameters.Add(Nome);
                var Endereco = new SqlParameter("@Endereco", SqlDbType.NVarChar);
                Endereco.Value = !((string.IsNullOrEmpty(barData.Address)) || (string.IsNullOrWhiteSpace(barData.Address))) ? barData.Address : " ";
                cmd.Parameters.Add(Endereco);
                var Cidade = new SqlParameter("@Cidade", SqlDbType.NVarChar);
                Cidade.Value = !((string.IsNullOrEmpty(barData.City)) || (string.IsNullOrWhiteSpace(barData.City))) ? barData.City : " ";
                cmd.Parameters.Add(Cidade);
                var Latitude = new SqlParameter("@Latitude", SqlDbType.Decimal);
                Latitude.Value = barData.Lat;
                cmd.Parameters.Add(Latitude);
                var Longitude = new SqlParameter("@Longitude", SqlDbType.Decimal);
                Longitude.Value = barData.Long;
                cmd.Parameters.Add(Longitude);
                var Review = new SqlParameter("@Review", SqlDbType.NVarChar);
                Review.Value = !((string.IsNullOrEmpty(barData.Description)) || (string.IsNullOrWhiteSpace(barData.Description))) ? barData.Description : " ";
                cmd.Parameters.Add(Review);
                var Chopp = new SqlParameter("@Chopp", SqlDbType.Int);
                Chopp.Value = barData.Chopp;
                cmd.Parameters.Add(Chopp);
                var Artesanal = new SqlParameter("@Artesanal", SqlDbType.Int);
                Artesanal.Value = barData.CraftBeer;
                cmd.Parameters.Add(Artesanal);
                var Gostei = new SqlParameter("@Gostei", SqlDbType.Int);
                Gostei.Value = barData.Likes;
                cmd.Parameters.Add(Gostei);
                var NaoGostei = new SqlParameter("@NaoGostei", SqlDbType.Int);
                NaoGostei.Value = barData.DontLikes;
                cmd.Parameters.Add(NaoGostei);
                var Dlist = new SqlParameter("@Dlist", SqlDbType.NVarChar);
                Dlist.Value = !((string.IsNullOrEmpty(barData.DList)) || (string.IsNullOrWhiteSpace(barData.DList))) ? barData.DList : " ";
                cmd.Parameters.Add(Dlist);
                int val = cmd.ExecuteNonQuery();

                return val > 0 ? true : false;
            }

        }




        public bool InsertComment(BarComment barComment)
        {
            using (var connection = new SqlConnection(_configuration["dbconfig:prihconnectionstring"]))
            {
                SqlCommand cmd = connection.CreateCommand();
                connection.Open();
                cmd.Connection = connection;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "[PRIHCERVEJEIRA].[InsertComment]";

                var Nome = new SqlParameter("@Nome", SqlDbType.NVarChar);
                Nome.Value = barComment.UserName;
                cmd.Parameters.Add(Nome);

                var Comentario = new SqlParameter("@Comentario", SqlDbType.NVarChar);
                Comentario.Value = !((string.IsNullOrEmpty(barComment.Comment)) || (string.IsNullOrWhiteSpace(barComment.Comment))) ? barComment.Comment : " ";
                cmd.Parameters.Add(Comentario);

                var BarId = new SqlParameter("@BarId", SqlDbType.Int);
                BarId.Value = barComment.BarId;
                cmd.Parameters.Add(BarId);


                int val = cmd.ExecuteNonQuery();

                return val > 0 ? true : false;
            }

        }


        public bool UpdateBar(BarData barData)
        {
            using (var connection = new SqlConnection(_configuration["dbconfig:prihconnectionstring"]))
            {
                SqlCommand cmd = connection.CreateCommand();
                connection.Open();
                cmd.Connection = connection;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "[PRIHCERVEJEIRA].[UpdateBarDataByID]";
                var Id = new SqlParameter("@Id", SqlDbType.Int);
                Id.Value = barData.Id;
                cmd.Parameters.Add(Id);
                var Nome = new SqlParameter("@Nome", SqlDbType.NVarChar);
                Nome.Value = barData.Name;
                cmd.Parameters.Add(Nome);
                var Endereco = new SqlParameter("@Endereco", SqlDbType.NVarChar);
                Endereco.Value = !((string.IsNullOrEmpty(barData.Address)) || (string.IsNullOrWhiteSpace(barData.Address))) ? barData.Address : " ";
                cmd.Parameters.Add(Endereco);
                var Cidade = new SqlParameter("@Cidade", SqlDbType.NVarChar);
                Cidade.Value = !((string.IsNullOrEmpty(barData.City)) || (string.IsNullOrWhiteSpace(barData.City))) ? barData.City : " ";
                cmd.Parameters.Add(Cidade);
                var Latitude = new SqlParameter("@Latitude", SqlDbType.Decimal);
                Latitude.Value = barData.Lat;
                cmd.Parameters.Add(Latitude);
                var Longitude = new SqlParameter("@Longitude", SqlDbType.Decimal);
                Longitude.Value = barData.Long;
                cmd.Parameters.Add(Longitude);
                var Review = new SqlParameter("@Review", SqlDbType.NVarChar);
                Review.Value = !((string.IsNullOrEmpty(barData.Description)) || (string.IsNullOrWhiteSpace(barData.Description))) ? barData.Description : " ";
                cmd.Parameters.Add(Review);
                var Chopp = new SqlParameter("@Chopp", SqlDbType.Int);
                Chopp.Value = barData.Chopp;
                cmd.Parameters.Add(Chopp);
                var Artesanal = new SqlParameter("@Artesanal", SqlDbType.Int);
                Artesanal.Value = barData.CraftBeer;
                cmd.Parameters.Add(Artesanal);
                var Gostei = new SqlParameter("@Gostei", SqlDbType.Int);
                Gostei.Value = barData.Likes;
                cmd.Parameters.Add(Gostei);
                var NaoGostei = new SqlParameter("@NaoGostei", SqlDbType.Int);
                NaoGostei.Value = barData.DontLikes;
                cmd.Parameters.Add(NaoGostei);
                var Dlist = new SqlParameter("@Dlist", SqlDbType.NVarChar);
                Dlist.Value = !((string.IsNullOrEmpty(barData.DList)) || (string.IsNullOrWhiteSpace(barData.DList))) ? barData.DList : " ";
                cmd.Parameters.Add(Dlist);
                int val = cmd.ExecuteNonQuery();

                return val > 0 ? true : false;
            }

        }

        public List<BarData> GetNearbyBarData(double latitude, double longitude)
        {
            var barList = new List<BarData>();
            using (var connection = new SqlConnection(_configuration["dbconfig:prihconnectionstring"]))
            {
                var cmd = new SqlCommand("[PRIHCERVEJEIRA].[GetNearbyBarList]", connection);
                cmd.CommandType = CommandType.StoredProcedure;

                connection.Open();
                using (SqlDataAdapter adapter = new SqlDataAdapter())
                {
                    adapter.SelectCommand = cmd;
                    adapter.SelectCommand.CommandType = System.Data.CommandType.StoredProcedure;

                    var Latitude = new SqlParameter("@Latitude", SqlDbType.Decimal);
                    Latitude.Value = latitude;
                    cmd.Parameters.Add(Latitude);
                    var Longitude = new SqlParameter("@Longitude", SqlDbType.Decimal);
                    Longitude.Value = longitude;
                    cmd.Parameters.Add(Longitude);
                    DataSet ds = new DataSet();
                    adapter.Fill(ds, "NearbyBars");
                    DataTable dt = ds.Tables["NearbyBars"];

                    foreach (DataRow row in dt.Rows)
                    {
                        barList.Add
                            (
                            new BarData
                            {
                                Id = Convert.ToInt32(row["ID"]),
                                Name = Convert.ToString(row["Nome"]),
                                Address = Convert.ToString(row["Endereco"]),
                                City = Convert.ToString(row["Cidade"]),
                                Description = Convert.ToString(row["Review"]),
                                DontLikes = Convert.ToInt32(row["NaoGostei"]),
                                Likes = Convert.ToInt32(row["Gostei"]),
                                Lat = Convert.ToDouble(row["Latitude"]),
                                Long = Convert.ToDouble(row["Longitude"]),
                                Chopp = Convert.ToBoolean(row["Chopp"]),
                                CraftBeer = Convert.ToBoolean(row["Artesanal"])
                            }
                            );
                    }
                }

            }
            return barList;
        }


        public BarData GetBarDetailsByID(int Id)
        {
            BarData barData = null;
            using (var connection = new SqlConnection(_configuration["dbconfig:prihconnectionstring"]))
            {
                var cmd = new SqlCommand("[PRIHCERVEJEIRA].[GetBarDetailsById]", connection);
                cmd.CommandType = CommandType.StoredProcedure;

                connection.Open();
                using (SqlDataAdapter adapter = new SqlDataAdapter())
                {
                    adapter.SelectCommand = cmd;
                    adapter.SelectCommand.CommandType = System.Data.CommandType.StoredProcedure;

                    var BarId = new SqlParameter("@BarId", SqlDbType.Int);
                    BarId.Value = Id;
                    cmd.Parameters.Add(BarId);

                    DataSet ds = new DataSet();
                    adapter.Fill(ds, "BarDetail");
                    DataTable dt = ds.Tables["BarDetail"];

                    foreach (DataRow row in dt.Rows)
                    {
                        barData =
                            new BarData
                            {
                                Id = Convert.ToInt32(row["ID"]),
                                Name = Convert.ToString(row["Nome"]),
                                Address = Convert.ToString(row["Endereco"]),
                                City = Convert.ToString(row["Cidade"]),
                                Description = Convert.ToString(row["Review"]),
                                DontLikes = Convert.ToInt32(row["NaoGostei"]),
                                Likes = Convert.ToInt32(row["Gostei"]),
                                Lat = Convert.ToDouble(row["Latitude"]),
                                Long = Convert.ToDouble(row["Longitude"]),
                                Chopp = Convert.ToBoolean(row["Chopp"]),
                                CraftBeer = Convert.ToBoolean(row["Artesanal"]),
                                DList = Convert.ToString(row["Dlist"])
                            };

                    }
                }

            }
            return barData;
        }
    }
}