using PsiControl.Classes;
using System;

using System.Windows;
using System.Windows.Controls;
using PsiControl.UserControls;

namespace PsiControl.UserControls;

/// <summary>
/// Interação lógica para Configuracoes.xam
/// </summary>
public partial class Configuracoes : UserControl
{
    public Configuracoes()
    {
        InitializeComponent();
    }

    private void SearchConfig_TextChanged(object sender, TextChangedEventArgs e)
    {

    }

    private void Button_Click(object sender, RoutedEventArgs e)
    {
        ConfiguraGrid.Children.Clear();
        ConfiguraGrid.Children.Add(new ConfiguraAgenda());
    }

    private void Button_Click_1(object sender, RoutedEventArgs e)
    {
        ConfiguraGrid.Children.Clear();
        ConfiguraGrid.Children.Add(new mainProfissional());
    }
}
