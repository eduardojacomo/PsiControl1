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

namespace PsiControl.UserControls
{
    /// <summary>
    /// Interação lógica para Dashboard.xam
    /// </summary>
    public partial class Dashboard : UserControl
    {
        public Dashboard()
        {
            InitializeComponent();
            GetDia();
        }

        private void InfoCard_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void Atendimentos_Loaded(object sender, RoutedEventArgs e)
        {

        }

        public void GetDia()//pega as datas de um determinado dia da semana .. ex todas as datas da segunda feira do mês
        {
            DateTime startDate = new DateTime(2023, 07, 01);
            DateTime endDate = new DateTime(2023, 07, 31);
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
            testedias.ItemsSource = listDate;
            //foreach (string dataGravar in listDate)
            //{
            //    insert values (@codigo , @data)
            //        parameters (@data, dataGravar)
            //}
           
        }

        private void Atendimentos_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            //gridMain.Children.Clear();
            //gridMain.Children.Add(new Dashboard());
            ShowAtendimento.Children.Clear();
            ShowAtendimento.Children.Add(new ShowAtendimento());
        }
    }
}
