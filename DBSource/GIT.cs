using System;
using System.Collections.ObjectModel;

namespace DBSource
{
    public class GIT
    {
        public static void GITCommit(string directory, bool isPush = true, string message = null)
        {
            /*message = message ?? @"git commit from DBSource " + DateTime.Now.ToString("MM-dd-yyyy HH:mm");
            using (PowerShell powershell = PowerShell.Create())
            {
                // this changes from the user folder that PowerShell starts up with to your git repository
                powershell.AddScript(String.Format(@"cd {0}", directory));

                powershell.AddScript(@"git init");
                powershell.AddScript(@"git add *");
                powershell.AddScript(@"git commit -m '$message$'".Replace("$message$", message));
                if (isPush)
                    powershell.AddScript(@"git push");

                Collection<PSObject> results = powershell.Invoke();
            }
            */
        }
    }
}