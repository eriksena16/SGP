using System;
using System.Globalization;
using System.Linq;

namespace SGP.Patrimony.Util.PatrimonyUtil
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
            names = names.Where(c => !string.IsNullOrEmpty(c)).ToArray();
            if (names.Any())
            {
                if (names.Length == 1)
                    return names[0][..1].ToUpper();
                else
                    return names[0][..1].ToUpper() + names[1][..1].ToUpper();
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

        public static string RemoveNonNumericChars(string texto)
        {
            if (texto == null)
                return "";

            String ret = "";
            foreach (char c in texto)
            {
                if (char.IsNumber(c))
                    ret += c;
            }

            return ret;
        }

        public static string RemoveSpecialChars(string str)
        {
            var htSpecialChars = new System.Collections.Hashtable();

            htSpecialChars["a"] = new string[] { "áàâãä", "a" };
            htSpecialChars["e"] = new string[] { "éèêë", "e" };
            htSpecialChars["i"] = new string[] { "íìîï", "i" };
            htSpecialChars["o"] = new string[] { "óòôõö", "o" };
            htSpecialChars["u"] = new string[] { "úùûü", "u" };
            htSpecialChars["ç"] = new string[] { "ç", "c" };

            htSpecialChars["A"] = new string[] { "ÁÀÂÃÄ", "A" };
            htSpecialChars["E"] = new string[] { "ÉÈÊË&", "E" };
            htSpecialChars["I"] = new string[] { "ÌÍÎÏ", "I" };
            htSpecialChars["O"] = new string[] { "ÒÓÔÕÖ", "O" };
            htSpecialChars["U"] = new string[] { "ÙÚÛÜ", "U" };
            htSpecialChars["Ç"] = new string[] { "Ç", "C" };

            //Johnson
            htSpecialChars["°"] = new string[] { "°", " " };
            htSpecialChars["ª"] = new string[] { "ª", " " };
            htSpecialChars["º"] = new string[] { "º", " " };
            htSpecialChars["/"] = new string[] { "/", " " };
            htSpecialChars["|"] = new string[] { "|", " " };
            htSpecialChars["_"] = new string[] { "_", " " };
            htSpecialChars["_"] = new string[] { "_", " " };
            htSpecialChars["-"] = new string[] { "-", " " };
            htSpecialChars["–"] = new string[] { "–", " " };
            htSpecialChars["("] = new string[] { "(", " " };
            htSpecialChars[")"] = new string[] { ")", " " };
            htSpecialChars["*"] = new string[] { "*", " " };
            htSpecialChars["."] = new string[] { ".", " " };
            htSpecialChars["!"] = new string[] { "!", " " };
            htSpecialChars["?"] = new string[] { "?", " " };
            htSpecialChars["{"] = new string[] { "{", " " };
            htSpecialChars["}"] = new string[] { "}", " " };
            htSpecialChars["%"] = new string[] { "%", " " };
            htSpecialChars["@"] = new string[] { "@", " " };
            htSpecialChars["#"] = new string[] { "#", " " };
            htSpecialChars[","] = new string[] { ",", " " };
            htSpecialChars[";"] = new string[] { ";", " " };
            htSpecialChars[":"] = new string[] { ":", " " };
            htSpecialChars["'"] = new string[] { "'", " " };
            htSpecialChars["$"] = new string[] { "$", " " };
            htSpecialChars["`"] = new string[] { "`", " " };
            htSpecialChars["´"] = new string[] { "´", " " };
            htSpecialChars["\""] = new string[] { "\"", " " };
            htSpecialChars["Ã"] = new string[] { "Ã", "A" };
            htSpecialChars["Ç"] = new string[] { "Ç", "C" };
            htSpecialChars["<"] = new string[] { "<", " " };
            htSpecialChars[">"] = new string[] { ">", " " };
            htSpecialChars["±"] = new string[] { "±", " " };
            htSpecialChars["²"] = new string[] { "²", " " };
            htSpecialChars["”"] = new string[] { "”", " " };
            htSpecialChars["§"] = new string[] { "§", " " };
            htSpecialChars["+"] = new string[] { "+", " " };
            htSpecialChars["\t"] = new String[] { "\t", " " };
            htSpecialChars["\r"] = new String[] { "\r", " " };
            htSpecialChars["\n"] = new String[] { "\n", " " };

            //
            //
            foreach (object obj in htSpecialChars.Keys)
                foreach (char c in ((string[])htSpecialChars[obj])[0])
                    str = str.Replace(c.ToString(), ((string[])htSpecialChars[obj])[1]);

            return str;
        }

        public static string FormatCNPJ(this string CNPJ)
        {
            return Convert.ToUInt64(CNPJ).ToString(@"00\.000\.000\/0000\-00");
        }

        public static string FormatCPF(this string CPF)
        {
            return Convert.ToUInt64(CPF).ToString(@"000\.000\.000\-00");
        }
        public static string FormatChaveAcesso(this string chave)
        {
            chave = chave.Remove(0, 3);
            string newChave = chave.Insert(4, " ").Insert(9, " ").Insert(14, " ").Insert(19, " ").Insert(24, " ").Insert(29, " ").Insert(34, " ").Insert(39, " ").Insert(44, " ").Insert(49, " ");

            return newChave;
        }
        public static string FormatNumeroNota(this long numero)
        {
            var qtZeros = 9 - numero.ToString().Length;

            var decimalLength = numero.ToString("D").Length + qtZeros;

            string nNota = numero.ToString("D" + decimalLength.ToString());

            return nNota;
        }
        public static string FormatNumeroSerie(this int numero)
        {
            var qtZeros = 3 - numero.ToString().Length;

            var decimalLength = numero.ToString("D").Length + qtZeros;

            string serie = numero.ToString("D" + decimalLength.ToString());

            return serie;
        }
        public static string FormatCep(this string cep)
        {

            return Convert.ToUInt64(cep).ToString(@"00000\-000");
        }
        public static string FormatObject(this object sender, string str)
        {
            try
            {
                var value = Convert.ToDecimal(sender.GetType().GetProperty(str).GetValue(sender, null).ToString());

                var newValue = value.ToString(CultureInfo.CreateSpecificCulture("pt-BR"));

                return newValue;
            }
            catch (Exception)
            {
                return "";
            }

        }
        public static string FormatCST(this object sender, string str)
        {
            try
            {
                return sender.GetType().GetProperty(str).GetValue(sender, null).ToString();
            }
            catch (Exception)
            {
                return "";
            }
        }
        public static string ConvertImageFromBase64(this byte[] imageArray)
        {
            return Convert.ToBase64String(imageArray);
        }
        public static string FormatString(string text, int length)
        {
            return FormatString(text, "0", length, true);
        }
        public static string FormatString(string text, string with, int length, bool left)
        {
            length -= text.Length;
            if (left)
            {
                for (int i = 0; i < length; ++i)
                {
                    text = with + text;
                }
            }
            else
            {
                for (int i = 0; i < length; ++i)
                {
                    text += with;
                }
            }
            return text;
        }
    }
}
