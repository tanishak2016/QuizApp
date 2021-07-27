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
        //string connectionstring = "Data Source=DESKTOP-TAU5C2E;Initial Catalog=QuizApp;Integrated Security=True;Pooling=False";

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

        public String apiUserRegistrationSave(apiUserRegistrationModel userregistration)
        {
            string msg = String.Empty;
            try
            {
                SqlCommand cmd = new SqlCommand("sp_apiUserRegistration", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@userfullname", userregistration.userFullName);
                cmd.Parameters.AddWithValue("@usermobile", userregistration.userMobile);
                cmd.Parameters.AddWithValue("@useremailid", userregistration.userEmailID);
                cmd.Parameters.AddWithValue("@userusername", userregistration.userUserName);
                cmd.Parameters.AddWithValue("@userpassword", userregistration.userPassword);
                cmd.Parameters.AddWithValue("@userdatecreated", DateTime.Now);
                con.Open();
                string result = cmd.ExecuteScalar().ToString();
                con.Close();
                return result;
            }
            catch (Exception ex)
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                return (ex.Message.ToString());
            }
        }

        public List<apiUserRegistrationModel> apiUserRegistrationDisplay()
        {
            List<apiUserRegistrationModel> apiuserregist = new List<apiUserRegistrationModel>();
            SqlCommand cmd = new SqlCommand("sp_dispAPIUserRegistration", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows != null && dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    apiUserRegistrationModel obj = new apiUserRegistrationModel();
                    obj.userFullName = dt.Rows[i]["userFullName"].ToString();
                    obj.userMobile = dt.Rows[i]["userMobile"].ToString();
                    obj.userEmailID = dt.Rows[i]["userEmailID"].ToString();
                    obj.userUserName = dt.Rows[i]["userUserName"].ToString();
                    obj.userPassword = dt.Rows[i]["userPassword"].ToString();
                    obj.userDateCreated = dt.Rows[i]["userDateCreated"].ToString();
                    obj.userDateModified = dt.Rows[i]["userDateModified"].ToString();
                    apiuserregist.Add(obj);
                }
            }
            return apiuserregist;
        }

        

    }
}
