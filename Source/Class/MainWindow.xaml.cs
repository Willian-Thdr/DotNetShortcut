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
        }
    }
}