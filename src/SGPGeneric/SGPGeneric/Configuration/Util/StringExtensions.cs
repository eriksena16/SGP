using System.Linq;

namespace LuxGenerics.Utils
{
    public static class StringExtensions
    {
        public static string ToCamelCase(this string str)
        {
            if (!string.IsNullOrEmpty(str) && str.Length > 1)
            {
                return char.ToLowerInvariant(str[0]) + str[1..];
            }
            return str;
        }

        public static string SplitFullName(this string pFullName)
        {
            string[] NameSurname = new string[2];
            string[] NameSurnameTemp = pFullName.Split(' ');
            for (int i = 0; i < NameSurnameTemp.Length; i++)
            {
                if (i <= 0)
                {
                    if (!string.IsNullOrEmpty(NameSurname[0]))
                        NameSurname[0] += " " + NameSurnameTemp[i];
                    else
                        NameSurname[0] += NameSurnameTemp[i];
                }
                else
                    NameSurname[1] = NameSurnameTemp[i];
            }
            return NameSurname[0] + " " + NameSurname[1];
        }

        public static string CreateInitials(this string name)
        {
            var names = name.Trim().Split(" ");
            if (names.Any())
            {
                if (names.Length == 1)
                    return names[0].Substring(0, 1).ToUpper();
                else
                    return names[0].Substring(0, 1).ToUpper() + names[1].Substring(0, 1).ToUpper();
            }
            else
                return "";
        }
        public static long GetParentIdFromPath(int level, string path)
        {
            return long.Parse(path.Split('|')[level]);
        }
        public static string GetPath(long parentId, string parentPath)
        {
            return (parentPath ?? "|") + parentId.ToString() + "|";
        }
    }
}
