
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace PsiControl.UserControls;

public partial class TaskItem : UserControl
{
    public TaskItem()
    {
        InitializeComponent();
    }

    #region Properties
    public string Tarefa
    {
        get { return (string)GetValue(TarefaProperty); }
        set { SetValue(TarefaProperty, value); }
    }
    public static readonly DependencyProperty TarefaProperty = DependencyProperty.Register("Tarefa", typeof(string), typeof(TaskItem));

    public string Hora
    {
        get { return (string)GetValue(HoraProperty); }
        set { SetValue(HoraProperty, value); }
    }
    public static readonly DependencyProperty HoraProperty = DependencyProperty.Register("Hora", typeof(string), typeof(TaskItem));

    public SolidColorBrush Cor
    {
        get { return (SolidColorBrush)GetValue(CorProperty); }
        set { SetValue(CorProperty, value); }
    }
    public static readonly DependencyProperty CorProperty = DependencyProperty.Register("Cor", typeof(SolidColorBrush), typeof(TaskItem));

    public FontAwesome.Sharp.IconChar Icone
    {
        get { return (FontAwesome.Sharp.IconChar)GetValue(IconeProperty); }
        set { SetValue(IconeProperty, value); }
    }

    public static readonly DependencyProperty IconeProperty = DependencyProperty.Register("Icone", typeof(FontAwesome.Sharp.IconChar), typeof(TaskItem));

    public FontAwesome.Sharp.IconChar IconeNotificacao
    {
        get { return (FontAwesome.Sharp.IconChar)GetValue(IconeNotificacaoProperty); }
        set { SetValue(IconeNotificacaoProperty, value); }
    }

    public object FontAwesome { get; internal set; }

    public static readonly DependencyProperty IconeNotificacaoProperty = DependencyProperty.Register("IconeNotificacao", typeof(FontAwesome.Sharp.IconChar), typeof(TaskItem));
    #endregion
}
