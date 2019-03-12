using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DBSource
{
    class Helpers
    {        
        /// <summary>
        /// Helpers Class
        /// </summary>
        public static string GetUntilOrEmpty(string text, string stopAt)
        {
            if (!String.IsNullOrWhiteSpace(text))
            {
                int charLocation = text.IndexOf(stopAt, StringComparison.Ordinal);

                if (charLocation > 0)
                {
                    return text.Substring(0, charLocation);
                }
            }

            return String.Empty;
        }

        public static string GetFromOrEmpty(string text, string startAt)
        {
            if (!String.IsNullOrWhiteSpace(text))
            {
                int charLocation = text.IndexOf(startAt, StringComparison.Ordinal);

                if (charLocation > 0)
                {
                    return text.Substring(charLocation + 1);
                }
            }

            return String.Empty;
        }

        public static string CheckForIllegalChar(string text)
        {
            string regexSearch = new string(Path.GetInvalidFileNameChars()) + new string(Path.GetInvalidPathChars());
            Regex r = new Regex(string.Format("[{0}]", Regex.Escape(regexSearch)));
            return r.Replace(text, "");
        }

        public static bool CheckPath(string path)
        {

            var result = Path.IsPathRooted(path);
            var mess = "";

            if (!result)
            {
                mess = "Path Is Not Rooted";
            }
            else
            {
                try
                {
                    Path.GetFullPath(path);
                }
                catch (Exception e)
                {
                    result = false;
                    mess = e.Message;
                }
            }

            if (!result)
            {
                MessageBox.Show("Incorrect Path: " + mess, @"Error", MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }

            return result;
        }
    }
}
