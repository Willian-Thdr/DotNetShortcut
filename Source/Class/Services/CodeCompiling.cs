using System.Diagnostics;
using System.Dynamic;
using System.IO;

namespace Source.Services;
public class CodeCompiling
{
    private static ProcessStartInfo info = new ProcessStartInfo();
    public static void Run(string way, string txt)
    {
        if (way == null)
            return;

        switch (txt)
        {
            case "Compile":

                info.FileName = @$"{Directory.GetCurrentDirectory()}\Source\Comands\compile.bat";
                info.Arguments = way;
                info.UseShellExecute = true;
                
                Process.Start(info); 
            break;

            case "Run":
                info.FileName = @$"{Directory.GetCurrentDirectory()}\Source\Comands\run.bat";
                info.Arguments = way;
                info.UseShellExecute = true;
                
                Process.Start(info); 
            break;
        }
    }
}