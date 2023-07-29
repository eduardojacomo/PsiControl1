using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Globalization;
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

namespace PsiControl.UserControls
{
    /// <summary>
    /// Interação lógica para Agenda.xam
    /// </summary>
    public partial class Agenda : UserControl
    {
        public Agenda()
        {
            InitializeComponent();
        }

        private void EventoAgenda_Loaded(object sender, RoutedEventArgs e)
        {

        }

        public void SemanaAtual()
        {
            List<DayOfWeek> workDays = new List<DayOfWeek>();
            workDays.Add(DayOfWeek.Monday);
            workDays.Add(DayOfWeek.Wednesday);

            // Loop over list of days.
            foreach (var day in workDays)
            {
                Console.WriteLine($"WORK DAY: {day}");
            }
        }
    }
}
