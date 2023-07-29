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
/// Interação lógica para EventoAgenda.xam
/// </summary>
public partial class EventoAgenda : UserControl
{
    public EventoAgenda()
    {
        InitializeComponent();
    }
    public string Paciente
    {
        get { return (string)GetValue(PacienteProperty); }
        set { SetValue(PacienteProperty, value); }
    }

    public FontAwesome.Sharp.IconChar Icone
    {
        get { return (FontAwesome.Sharp.IconChar)GetValue(IconeProperty); }
        set { SetValue(IconeProperty, value); }
    }

    public Color Background1
    {
        get { return (Color)GetValue(Background1Property); }
        set { SetValue(Background1Property, value); }
    }

    public static readonly DependencyProperty PacienteProperty = DependencyProperty.Register("Paciente", typeof(string), typeof(EventoAgenda));
    public static readonly DependencyProperty IconeProperty = DependencyProperty.Register("Icone", typeof(FontAwesome.Sharp.IconChar), typeof(EventoAgenda));
    public static readonly DependencyProperty Background1Property = DependencyProperty.Register("Background1", typeof(Color), typeof(EventoAgenda));
}
