using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.IO;
using Quiz_App.Models;
namespace Quiz_App.Models
{
    public class db 
    {

        SqlConnection con;
        public db()
        {
            var configuration = GetConfiguration();
            con = new SqlConnection(configuration.GetSection("Data").GetSection("ConnectionString").Value);
            }

        public IConfigurationRoot GetConfiguration()
        {

            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
            return builder.Build();
        }

        public int LoginCheck(SuperAdmin_Login sa)
        {
            SqlCommand cmd = new SqlCommand("sp_superLogin",con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@SuperAdminPassword", sa.supAdminPassword);
            SqlParameter oblogin = new SqlParameter();
            oblogin.ParameterName = "@IsValid";
            oblogin.SqlDbType = SqlDbType.Bit;
            oblogin.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(oblogin);
            con.Open();
            cmd.ExecuteNonQuery();
            int res = Convert.ToInt32(oblogin.Value);
            con.Close();
            return res;


        }


        public DataSet normalAdminGet(normalAdmin na,out String msg)
        {
            DataSet ds = new DataSet();
            msg = string.Empty;
            try
            {
                SqlCommand cmd = new SqlCommand("sp_createAdminLogin", con);
                cmd.CommandType = CommandType.StoredProcedure;               
                cmd.Parameters.AddWithValue("@adminID", na.adminID);
                cmd.Parameters.AddWithValue("@adminUserName", na.adminUserName);
                cmd.Parameters.AddWithValue("@adminPassword", na.adminUserPassword);
                cmd.Parameters.AddWithValue("@adminDateCreated", na.adminDateCreate);
                cmd.Parameters.AddWithValue("@adminDateModified", na.adminDateModified);
                cmd.Parameters.AddWithValue("@flag", na.flag);
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                adp.Fill(ds);
                msg = "OK";
                return ds;


            }
            catch(Exception ex)
            {
                msg = ex.Message;
                return ds;
            }
        }

        public void normalAdminSaveUpdate(normalAdmin na)
        {
         String   msg = string.Empty;
           try
            {
                SqlCommand cmd = new SqlCommand("sp_saveNormalAdmin", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@adminName", na.adminName);
                cmd.Parameters.AddWithValue("@adminMobile", na.adminMobile);
                cmd.Parameters.AddWithValue("@adminUserName", na.adminUserName);
                cmd.Parameters.AddWithValue("@adminPassword", na.adminUserPassword);
                cmd.Parameters.AddWithValue("@adminDateCreated", na.adminDateCreate);
                cmd.Parameters.AddWithValue("@adminDateModified", na.adminDateModified);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();

            }
            catch (Exception ex)
            {
                if(con.State==ConnectionState.Open)
                {
                    con.Close();
                }
                msg = ex.Message;
                //return msg;
            }
        }


    }

    
   
}
