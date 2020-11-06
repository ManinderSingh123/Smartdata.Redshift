namespace Redmap.Redshift.DTO
{
    /// <summary>
    ///Collection of bad characters
    /// </summary>
    public static class BadChars
    {
        /// <summary>
        /// Bad character array.
        /// </summary>
        public static char[] badChars = { ';', ',', '"', '%' };
        /// <summary>
        /// Bad commands array.
        /// </summary>
        public static string[] badCommands = { "--", "xp_cmdshell", "Drop", "Update" };
    }
}
