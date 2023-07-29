using PsiControl.Classes;
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

namespace PsiControl
{
    /// <summary>
    /// Lógica interna para Main.xaml
    /// </summary>
    public partial class Main : Window
    {
        public Main()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            gridMain.Children.Clear();
            gridMain.Children.Add(new Dashboard());
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            gridMain.Children.Clear();
            gridMain.Children.Add(new Configuracoes());
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            windowPaciente telapaciente = new();
            telapaciente.Show();
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            windowAgenda telaagenda = new();
            telaagenda.Show();
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            gridMain.Children.Clear();
            gridMain.Children.Add(new mainSessao());
        }

        private void Button_Click_6(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Button_Click_7(object sender, RoutedEventArgs e)
        {
            if (WindowState == WindowState.Normal)
            {
                WindowState = WindowState.Maximized;
            }
            else
            {
                WindowState = WindowState.Normal;
            }
        }

        private void Button_Click_8(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }
    }
}
