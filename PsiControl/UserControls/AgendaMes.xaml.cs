using PsiControl.Classes;
using PsiControl.UserControls;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;

using System.Windows;
using System.Windows.Controls;

using System.Windows.Input;
using System.Windows.Media;


namespace PsiControl.UserControls;
public partial class AgendaMes : UserControl
{
    public AgendaMes()
    {
        InitializeComponent();
        GetAgendaMes();
        PopulateUC();
    }

    private void Border_MouseDown(object sender, MouseButtonEventArgs e)
    {
        
    }

    static public string diasemana = "Segunda-Feira";
    static public string paciente = "2";
    static public string profissional = "1";

    private static void GetAgendaMes()
    {

            DateTime startDate = new DateTime(2023, 08, 01);
            DateTime endDate = new DateTime(2023, 08, 31);
            string[] WeekDayNames = new[] { "Wednesday" };
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
            }

    }
    public void PopulateUC()
    {
        
        TaskItem[] taskitem = new TaskItem[5];

        if (GridTasks.Children.Count > 0)
        {
            GridTasks.Children.Clear();
        }
        
        for (int i = 0; i < taskitem.Length; i++)
            {
                taskitem[i] = new TaskItem();
                taskitem[i].Tarefa = "Get a data here";
                taskitem[i].Hora = "Get a data here";
                taskitem[i].Cor = System.Windows.Media.Brushes.White;//SolidColorBrush.ColorProperty.ToString()."#ffffff";
                taskitem[i].Icone = FontAwesome.Sharp.IconChar.Check;
                taskitem[i].IconeNotificacao = FontAwesome.Sharp.IconChar.BellSlash;
            GridTasks.Children.Add(taskitem[i]);
            }
    }

    public void agendasegunda ()
    {
        List<Agenda> getsegunda = new List<Agenda>();
       // getsegunda = AgendaControler.getagenda(diasemana, profissional, paciente);


    }


}
