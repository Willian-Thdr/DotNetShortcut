using System.IO;
using System.Windows;
using Microsoft.Win32;

namespace DotNetShortcut.Source;
public partial class MainWindow : Window
{
    private string way;
    public MainWindow()
    {
        InitializeComponent();
    }

    private static void CalculadoraInterna(int[] x, double[] x2)
    {
        
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
        string condition = "WaitValue";
        string[] messages =
        {
            "O projeto é um WPF", // 0
            "Tipagem de projeto não indentificada" // 1
        };

        foreach (string files in Directory.GetFiles(way))
        {
            if (files.Contains(".csproj"))
            {
                condition = "IsWpf";
            }
        }

        switch (condition)
        {
            case "IsWpf":
                Console.WriteLine(messages.GetValue(0));
            break;

            default:
                Console.WriteLine(messages.GetValue(1));
            break;
        }
    }
}