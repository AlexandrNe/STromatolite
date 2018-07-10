using Stromatolite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace Stromatolite.DAL
{
    public class DataAccessLayer
    {
        public UnitOfWork uof = new UnitOfWork();

        public string ClearSpecChars(string _str)
        {
            if (string.IsNullOrEmpty(_str))
            {
                return string.Empty;
            }
            char[] bl = {'"'};
            string Bl = new string(bl);

            string str = _str.Replace("%", "")
                .Replace("|", "")
                .Replace("&", "")
                .Replace(" ", "-")
                .Replace("!", "%21")
                .Replace(Bl, "%22")
                .Replace("#", "%23")
                .Replace("$", "%24")
                .Replace("'", "%27")
                .Replace("*", "x")
                .Replace(",", "%2c")
                .Replace("+", "")
                .Replace("/", "")
                .Replace("?", "_7_")
                .Replace("@", "-")
                .Replace("\\", "-");
            return str;
        }

        public string tagStop(string _str)
        {
            if (string.IsNullOrEmpty(_str))
            {
                return string.Empty;
            }
            string str = _str.Replace("<", "&lt;").Replace(">", "&gt;")
                        .Replace("&lt;p&gt;", "<p>").Replace("&lt;/p&gt;","</p>")
                        .Replace("&lt;b&gt;", "<b>").Replace("&lt;/b&gt;", "</b>")
                        .Replace("&lt;h1&gt;", "<h1>").Replace("&lt;/h1&gt;", "</h1>")
                        .Replace("&lt;h2&gt;", "<h2>").Replace("&lt;/h2&gt;", "</h2>")
                        .Replace("&lt;h3&gt;", "<h3>").Replace("&lt;/h3&gt;", "</h3>")
                        .Replace("&lt;h4&gt;", "<h4>").Replace("&lt;/h4&gt;", "</h4>")
                        .Replace("&lt;h5&gt;", "<h5>").Replace("&lt;/h5&gt;", "</h5>")
                        .Replace("&lt;h6&gt;", "<h6>").Replace("&lt;/h6&gt;", "</h6>")
                        .Replace("&lt;strong&gt;", "<strong>").Replace("&lt;/strong&gt;", "</strong>")
                        .Replace("&lt;blockquote&gt;", "<blockquote>").Replace("&lt;/blockquote&gt;", "</blockquote>")
                        .Replace("&lt;em&gt;", "<em>").Replace("&lt;/em&gt;", "</em>")
                        .Replace("&lt;mark&gt;", "<mark>").Replace("&lt;/mark&gt;", "</mark>")
                        .Replace("&lt;q&gt;", "<q>").Replace("&lt;/q&gt;", "</q>")
                        .Replace("://", " : / / ")
                        ;
            str = str
                        .Replace("&lt;P&gt;", "<p>").Replace("&lt;/P&gt;", "</p>")
                        .Replace("&lt;B&gt;", "<b>").Replace("&lt;/B&gt;", "</b>")
                        .Replace("&lt;H1&gt;", "<h1>").Replace("&lt;/H1&gt;", "</h1>")
                        .Replace("&lt;H2&gt;", "<h2>").Replace("&lt;/H2&gt;", "</h2>")
                        .Replace("&lt;H3&gt;", "<h3>").Replace("&lt;/H3&gt;", "</h3>")
                        .Replace("&lt;H4&gt;", "<h4>").Replace("&lt;/H4&gt;", "</h4>")
                        .Replace("&lt;H5&gt;", "<h5>").Replace("&lt;/H5&gt;", "</h5>")
                        .Replace("&lt;H6&gt;", "<h6>").Replace("&lt;/H6&gt;", "</h6>")
                        .Replace("&lt;STRONG&gt;", "<strong>").Replace("&lt;/STRONG&gt;", "</strong>")
                        .Replace("&lt;BLOCKQUOTE&gt;", "<blockquote>").Replace("&lt;/BLOCKQUOTE&gt;", "</blockquote>")
                        .Replace("&lt;EM&gt;", "<em>").Replace("&lt;/EM&gt;", "</em>")
                        .Replace("&lt;MARK&gt;", "<mark>").Replace("&lt;/MARK&gt;", "</mark>")
                        .Replace("&lt;Q&gt;", "<q>").Replace("&lt;/Q&gt;", "</q>")
                        ;

            return str;

        }
   
    }

    /************************************************************************/
    public static class MyString
    {
        public static string Translit(string str, bool direct = true)
        {
            List<string> lat = new List<string> { "a", "b", "v", "g", "d", "e", "jo", "zh", "z", "i", "j", "k", "l", "m", "n", "o", "p", "r", "s", "t", "u", "f", "h", "c", "ch", "sh", "shh", "", "y", "", "je", "ju", "ja" };
            List<string> rus = new List<string> { "а", "б", "в", "г", "д", "е", "ё", "ж", "з", "и", "й", "к", "л", "м", "н", "о", "п", "р", "с", "т", "у", "ф", "х", "ц", "ч", "ш", "щ", "ъ", "ы", "ь", "э", "ю", "я" };
            for (int i = 0; i < 33; i++)
            {
                if (direct)
                {
                    str = str.Replace(rus[i], lat[i]).Replace(rus[i].ToUpper(), lat[i].ToUpper());
                }
                else
                {
                    str = str.Replace(lat[i], rus[i]).Replace(lat[i].ToUpper(), rus[i].ToUpper());
                }

            }
            return str;
        }

        public static string AllTrim(string str)
        {
            return str.Replace(" ", "");
        }

        public static string HyphenTrim(string str)
        {
            return str.Replace(" ", "-");
        }

        public static string DeleteSpecChars(string _str)
        {
            if (string.IsNullOrEmpty(_str))
            {
                return string.Empty;
            }
            char[] bl = { '"' };
            string Bl = new string(bl);

            string str = _str.Replace("%", "")
                .Replace("&", "")
                .Replace("|", "")
                .Replace("!", "")
                .Replace(Bl, "")
                .Replace("#", "")
                .Replace("$", "")
                .Replace("'", "")
                .Replace("*", "")
                .Replace(",", "")
                .Replace("+", "")
                .Replace("/", "")
                .Replace("?", "_7_")
                .Replace("@", "")
                .Replace("\\", "");
            str =str.Trim();
            return str;
        }

    }
}