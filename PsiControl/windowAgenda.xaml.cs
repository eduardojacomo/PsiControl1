using PsiControl.UserControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace PsiControl;

/// <summary>
/// Lógica interna para windowAgenda.xaml
/// </summary>
public partial class windowAgenda : Window
{
    public windowAgenda()
    {
        InitializeComponent();
    }

    private void Button_Click(object sender, RoutedEventArgs e)
    {
        getAgenda.Children.Clear();
        getAgenda.Children.Add(new AgendaMes());
    }

    private void Button_Click_1(object sender, RoutedEventArgs e)
    {
        getAgenda.Children.Clear();
        getAgenda.Children.Add(new Agenda());
    }
}
