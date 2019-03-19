using System;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace DBSource
{
    internal class Helpers
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
            Regex r = new Regex(String.Format("[{0}]", Regex.Escape(regexSearch)));
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
                MessageBox.Show(@"Incorrect Path: " + mess, @"Error", MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }

            return result;
        }

        public static string FirstCharToUpper(string input)
        {
            switch (input)
            {
                case null: throw new ArgumentNullException(nameof(input));
                case "": throw new ArgumentException($"{nameof(input)} cannot be empty", nameof(input));
                default: return input.First().ToString().ToUpper() + input.Substring(1);
            }
        }

        public static string ShowDialog(string text, string caption, string textbox = "", Control inControl = null)
        {
            var prompt = new Form()
            {
                Width = 500,
                Height = 150,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                Text = caption,
                StartPosition = FormStartPosition.CenterScreen,
                MaximizeBox = false
            };
            var textLabel = new Label() { Left = 50, Top = 20, Text = text };
            inControl = inControl ?? new TextBox();
            inControl.Left = 50;
            inControl.Top = 40;
            inControl.Width = 400;
            inControl.Text = textbox;
            var confirmation = new Button()
            {
                Text = @"OK",
                Left = 130,
                Width = 100,
                Top = 70,
                DialogResult = DialogResult.OK
            };
            confirmation.Click += (sender, e) => { prompt.Close(); };
            var cancel = new Button()
            {
                Text = @"Cancel",
                Left = 260,
                Width = 100,
                Top = 70,
                DialogResult = DialogResult.Cancel
            };
            cancel.Click += (sender, e) => { prompt.Close(); };
            prompt.Controls.Add(inControl);
            prompt.Controls.Add(confirmation);
            prompt.Controls.Add(cancel);
            prompt.Controls.Add(textLabel);
            prompt.AcceptButton = confirmation;
            prompt.AcceptButton = cancel;

            return prompt.ShowDialog() == DialogResult.OK ? inControl.Text : "";
        }
    }
}
