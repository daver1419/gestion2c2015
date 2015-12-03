using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;
using System.Text.RegularExpressions;

namespace AerolineaFrba.Helpers
{
    public static class Utility
    {
        private static Logger log;
        public static Logger Log { get { if (log == null) log = new Logger(); return log; } }

        public class Logger
        {
            public const string SEPARATOR = "\n\n\n*******\n";

            public void log(Exception e)
            {
                using (StreamWriter streamWriter = new StreamWriter("../../../NORMALIZADOS.log", true, Encoding.Default))
                {
                    string line = String.Format("{0}\n\n{1}", DateTime.Now, e.ToString());
                    streamWriter.Write(line);
                    streamWriter.Write(SEPARATOR);

                }
            }
        }

        public static bool buenFormatoMatricula(Control mitextbox)
        {
            Regex regex = new Regex(@"[a-zA-Z]{3}[\-]{1}[0-9]{3}$");
            return regex.IsMatch(mitextbox.Text);
        }

        public static void ShowError(string title, string text)
        {

            MessageBox.Show(text, title, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public static void ShowError(string title, Exception e)
        {
            ShowError(title, e.Message);
            Debug.WriteLine(e.ToString());
            Log.log(e);
        }

        public static void ShowInfo(string title, string text)
        {

            MessageBox.Show(text, title, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
