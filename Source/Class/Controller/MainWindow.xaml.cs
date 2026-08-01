using System.IO;
using System.Windows;
using Microsoft.Win32;
using Source.Services;

namespace DotNetShortcut.Source;
public partial class MainWindow : Window
{
    private string way;
    public MainWindow()
    {
        InitializeComponent();
    }

    private void ChooseFolder(object sender, EventArgs args)
    {        
        OpenFolderDialog open = new OpenFolderDialog();
        open.Title = "Selecione seu diretório";

        bool? result = open.ShowDialog();

        if (result == true)
        {
            way = open.FolderName;
            ShowDirectory.Text = way;
            CheckFolder(way);
        }
    }

    private void CheckFolder(string way)
    {

        if (Path.Exists(way))
        {
            foreach (string files in Directory.GetFiles(way))
            {
                if (files.Contains(".csproj"))
                {
                    ValueReturns("IsWpf");
                }
            }
        }
        else
        {
            ValueReturns("ERRO");
            return;
        }
    }

    private void ValueReturns(string txt)
    {
        string[] messages =
        {
            "O projeto é um WPF", // 0
            "Tipagem de projeto não indentificada" // 1
        };

        switch (txt)
        {
            case "IsWpf":
                Console.WriteLine(messages.GetValue(0));
            break;

            case "ERROR":
                Exception e = new Exception();
                MessageBox.Show($"ERROR: {e}");
            break;

            default:
                Console.WriteLine(messages.GetValue(1));
            break;
        }
    }

    private void CompileProcess(object sender, EventArgs args)
    {
        CodeCompiling.Run(way, "Compile");
    }

    private void RunProcess(object sender, EventArgs args)
    {
        CodeCompiling.Run(way, "Run");
    }
}