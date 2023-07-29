using PsiControl.Classes;
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
/// Interação lógica para mainSessao.xam
/// </summary>
public partial class mainSessao : UserControl
{
    public mainSessao()
    {
        InitializeComponent();
    }

    private void Button_Click(object sender, RoutedEventArgs e)
    {
        windowSessao telasessao = new();
        telasessao.Show();
    }

    public void getPaciente() 
    {

    }

    /*private void FillGridDisponivel()
    {
        string agendadia = CbStatus.SelectedValue.ToString();
        string codprof = "1";
        string statusagenda = "Disponivel";
        GetAgenda ga = new GetAgenda();
        DgvDisponivel.ItemsSource = ga.montaagenda(agendadia, statusagenda, codprof);

    }
    
     
     
     */
    private void Button_Click_1(object sender, RoutedEventArgs e)
    {
        DateTime startDate = new DateTime(2023, 08, 01);
        DateTime endDate = new DateTime(2023, 08, 31);
        string profselect = "1";
        Agenda gerarsessoes = new Agenda();
        var sessoesagenda = AgendaControler.getagendareservada(profselect);

        foreach (var secpac in  sessoesagenda)
        {
            string codpac = secpac.CodigoPaciente;
            string diases = secpac.Dia;
            string horases = secpac.Hora;
            string dayweek = "";
            switch (diases)
            {
                case "Segunda-Feira": 
                    dayweek = "Monday";
                    break;
                case "Terça-Feira":
                    dayweek = "Tuesday";
                    break;
                case "Quarta-Feira":
                    dayweek = "Wednesday";
                    break;
                case "Quinta-Feira":
                    dayweek = "Thursday";
                    break;
                case "Sexta-Feira":
                    dayweek = "Friday";
                    break;
                case "Sabado":
                    dayweek = "Saturday";
                    break;
                case "Domingo":
                    dayweek = "Sunday";
                    break;
            }
            string[] WeekDayNames = new[] { dayweek };
            List<string> listDate = new List<string>();
            //List<DateTime> list = new List<DateTime>();
            while (startDate <= endDate)
            {
                if (WeekDayNames.Any(r => r == startDate.DayOfWeek.ToString()))
                {
                    
                    listDate.Add(startDate.ToString("dd/MM/yy"));
                }
                startDate = startDate.AddDays(1);
                //rodar o insert para adicionar as seções do mês
            }


        }
        //DgvSessoes.ItemsSource= AgendaControler.getagendareservada("1");
        
        /*string[] WeekDayNames = new[] { "Wednesday" };
        List<string> listDate = new List<string>();
        //List<DateTime> list = new List<DateTime>();
        while (startDate <= endDate)
        {
            if (WeekDayNames.Any(r => r == startDate.DayOfWeek.ToString()))
            {
                //list.Add(startDate.Date);
                listDate.Add(startDate.ToString("dd/MM/yy"));
            }
            startDate = startDate.AddDays(1);
        }*/
        //testedias.ItemsSource = listDate;
    }
}
