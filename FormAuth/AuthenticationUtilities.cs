using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace FormAuth
{
    internal sealed class AuthenticationUtilities
    {
        private static string DB_HOST = "PC1\\mssql2016";
        private static string DB_NAME = "SSRSConfig";
        
        /// <summary>
        /// checks weather the give username exists
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        internal static bool VerifyUser(string userName)
        {
            bool isValid = false;
            using (SqlConnection conn = new SqlConnection(
                "Server=" + DB_HOST + ";" +
                "Integrated Security=SSPI;" +
                "database=" + DB_NAME))
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM SSRSUser WHERE UserName = @userName", conn);


                SqlParameter sqlParam = cmd.Parameters.Add("@userName", SqlDbType.VarChar, 255);
                sqlParam.Value = userName;
                try
                {
                    conn.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {

                        //if record exists, then username exists
                        if (reader.Read())
                        {
                            isValid = true;
                        }

                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Couldn`t Verify the user " + ex.Message);
                }

                return isValid;
            }

        }


        // Method that indicates whether 
        // the supplied username and password are valid
        internal static bool VerifyPassword(string userName, string password)
        {

            bool passwordMatch = false;

            using (SqlConnection conn = new SqlConnection(
                "Server=" + DB_HOST + ";" +
                "Integrated Security=SSPI;" +
                "database=" + DB_NAME))
            {
                SqlCommand cmd = new SqlCommand("SELECT Password FROM SSRSUser WHERE UserName = @userName", conn);


                SqlParameter sqlParam = cmd.Parameters.Add("@userName", SqlDbType.VarChar, 255);
                sqlParam.Value = userName;
                try
                {
                    conn.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        reader.Read(); // Advance to the one and only row

                        string dbPasswordHash = reader.GetString(0).ToUpper();

                        string hashedPassword = CalculateSHA1HashString(password).ToUpper();

                        // Now verify them. Returns true if they are equal
                        passwordMatch = dbPasswordHash.Equals(hashedPassword);
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Couldn`t verify the password " + ex.Message);
                }
            }
            return passwordMatch;

        }


        private static string CalculateSHA1HashString(string password){

            using (SHA1Managed sha1 = new SHA1Managed())
            {
                byte[] hashBytes = sha1.ComputeHash(Encoding.UTF8.GetBytes(password));

                string hashStr = "";
                foreach (byte hashByte in hashBytes)
                {
                    hashStr += hashByte.ToString("x2");
                }

                return hashStr;
            }
        }
       
    }
}
