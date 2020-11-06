namespace Redmap.Redshift.Model
{
    /// <summary>
    /// AppSettings
    /// </summary>
    public class AppSettings
    {
        /// <summary>
        /// Server name
        /// </summary>
        public string ServerName { get; set; }
        /// <summary>
        /// Port number
        /// </summary>
        public string Port { get; set; }
        /// <summary>
        /// User Name
        /// </summary>
        public string UserName   { get; set; }
        /// <summary>
        /// Password
        /// </summary>
        public string Password { get; set; }
        /// <summary>
        /// Database
        /// </summary>
        public string Database { get; set; }

        /// <summary>
        /// Site Url
        /// </summary>
        public string SiteUrl { get; set; }
        /// <summary>
        /// Error Logging Url
        /// </summary>
        public string ErrorLoggingUrl { get; set; }

    }
}
