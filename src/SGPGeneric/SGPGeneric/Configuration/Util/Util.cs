using System;
using System.Text;

namespace LuxGenerics.Utils
{
    public static class Util
    {
        public static string ReturnMessageException(Exception ex)
        {
            return ex.Message.ToString();
        }
        public static string RemoveDiacritics(this string texto)
        {
            if (string.IsNullOrEmpty(texto))
                return String.Empty;

            byte[] bytes = Encoding.GetEncoding("iso-8859-8").GetBytes(texto);
            return Encoding.UTF8.GetString(bytes);
        }
    }
}
