using FontAwesome.Sharp;
using MahApps.Metro.Controls;
using MahApps.Metro.IconPacks;
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
using System.Windows.Navigation;
using System.Windows.Shapes;


namespace PsiControl.UserControls;

/// <summary>
/// Interação lógica para TasksEvent.xam
/// </summary>
public partial class TasksEvent : UserControl
{
    public TasksEvent()
    {
        InitializeComponent();
    }

    public string Titulo
    {
        get { return (string)GetValue(TituloProperty); }
        set { SetValue(TituloProperty, value); }
    }
    public static readonly DependencyProperty TituloProperty = DependencyProperty.Register("Titulo", typeof(string), typeof(TasksEvent));

    public FontAwesome.Sharp.IconChar Icone
    {
        get { return (FontAwesome.Sharp.IconChar)GetValue(IconeProperty); }
        set { SetValue(IconeProperty, value); }
    }

    public static readonly DependencyProperty IconeProperty = DependencyProperty.Register("Icone", typeof(FontAwesome.Sharp.IconChar), typeof(TasksEvent));

}
