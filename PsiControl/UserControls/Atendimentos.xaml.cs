using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace PsiControl.UserControls;

/// <summary>
/// Interação lógica para Atendimentos.xam
/// </summary>
public partial class Atendimentos : UserControl
{
    public Atendimentos()
    {
        InitializeComponent();
    }

    public string Paciente
    {
        get { return (string)GetValue(PacienteProperty); }
        set { SetValue(PacienteProperty, value); }
    }

    public string Horario
    {
        get { return (string)GetValue(HorarioProperty); }
        set { SetValue(HorarioProperty, value); }
    }
    public static readonly DependencyProperty PacienteProperty = DependencyProperty.Register("Paciente", typeof(string), typeof(Atendimentos));
    public static readonly DependencyProperty HorarioProperty = DependencyProperty.Register("Horario", typeof(string), typeof(Atendimentos) );
}
