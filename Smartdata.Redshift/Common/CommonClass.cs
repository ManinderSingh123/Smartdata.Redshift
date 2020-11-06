using Redmap.Redshift.DTO;
using System;

namespace Redmap.Events.Common
{
    /// <summary>
    /// Class with common functions.
    /// </summary>
    public static class CommonClass
    {        

        /// <summary>
        /// Change Date Format
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static string ChangeDateFormat(string text)
        {
            string returnDate = "";
            if (!string.IsNullOrEmpty(text))
            {
                var splitdate = text.Split('/');
                returnDate = splitdate[1] + "/" + splitdate[0] + "/" + splitdate[2];
            }

            return returnDate;
        }

        /// <summary>
        /// Get connection string
        /// </summary>
        /// <returns></returns>
        public static string GetConnectionString(string server, string port, string masterUsername, string masterUserPassword, string DBName)
        {

            string connString = String.Format("Server={0};Database={1};" + "UID={2};PWD={3};Port={4};", server, DBName, masterUsername, masterUserPassword, port);

            return connString;
        }

        /// <summary>
        /// Verify sql injection
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        public static bool VerifyQuery(string query)
        {
            bool status = false;

            // Check for database special commands
            foreach (var item in BadChars.badCommands)
            {
                if (query.ToUpper().Contains(item.ToUpper()))
                {                   
                    status = true;
                }
            }

            return status;
        }

    }
}
