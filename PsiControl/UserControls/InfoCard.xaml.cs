using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace PsiControl.UserControls;
public partial class InfoCard : UserControl
{
    public InfoCard()
    {
        InitializeComponent();
    }

    public string Titulo
    {
        get { return (string)GetValue(TitleProperty); }
        set { SetValue (TitleProperty, value); }
    }

    public string Numero
    {
        get { return (string)GetValue(NumeroProperty); }
        set { SetValue(NumeroProperty, value); }
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

    public Color Background2
    {
        get { return (Color)GetValue(Background2Property); }
        set { SetValue(Background2Property, value); }
    }

    public Color ElipseBackground1
    {
        get { return (Color)GetValue(ElipseBackground1Property); }
        set { SetValue(ElipseBackground1Property, value); }
    }

    public Color ElipseBackground2
    {
        get { return (Color)GetValue(ElipseBackground2Property); }
        set { SetValue(ElipseBackground2Property, value); }
    }

    public static readonly DependencyProperty TitleProperty = DependencyProperty.Register("Titulo", typeof(string), typeof(InfoCard));
    public static readonly DependencyProperty NumeroProperty = DependencyProperty.Register("Numero", typeof(string), typeof(InfoCard));
    public static readonly DependencyProperty IconeProperty = DependencyProperty.Register("Icone", typeof(FontAwesome.Sharp.IconChar), typeof(InfoCard));
    public static readonly DependencyProperty Background1Property = DependencyProperty.Register("Background1", typeof(Color), typeof(InfoCard));
    public static readonly DependencyProperty Background2Property = DependencyProperty.Register("Background2", typeof(Color), typeof(InfoCard));
    public static readonly DependencyProperty ElipseBackground1Property = DependencyProperty.Register("ElipseBackground1", typeof(Color), typeof(InfoCard));
    public static readonly DependencyProperty ElipseBackground2Property = DependencyProperty.Register("ElipseBackground2", typeof(Color), typeof(InfoCard));
}
