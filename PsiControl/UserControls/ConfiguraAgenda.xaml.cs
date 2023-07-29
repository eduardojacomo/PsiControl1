using PsiControl.Classes;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
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

namespace PsiControl;

/// <summary>
/// Interação lógica para ConfiguraAgenda.xam
/// </summary>
public partial class ConfiguraAgenda : UserControl
{
    public ConfiguraAgenda()
    {
        InitializeComponent();
        GetProfissional();
    }

    public string codprof { get; set; }
    public string mensagem = "";
    
    private void FillGridIndisponivel()
    {
        string agendadia = CbStatus.SelectedValue.ToString();
        string codprof = "1";
        string statusagenda = "Indisponivel";
        GetAgenda ga = new GetAgenda();
        DgvIndisponivel.ItemsSource = ga.montaagenda(agendadia, statusagenda, codprof);

    }

    private void FillGridDisponivel()
    {
        string agendadia = CbStatus.SelectedValue.ToString();
        string codprof = "1";
        string statusagenda = "Disponivel";
        GetAgenda ga = new GetAgenda();
        DgvDisponivel.ItemsSource = ga.montaagenda(agendadia, statusagenda, codprof);

    }

   /* private void GetAgendaDisponivel()
    {
        ConectaBD conexao = new ConectaBD();
        SqlCommand cmd = new SqlCommand();
        codprof = "1";
        string statusagenda = "Disponivel";
        string agendadia = CbStatus.SelectedValue.ToString();

        cmd.Connection = conexao.Conectar();

        cmd.CommandText = $"select Codigo, Dia, Hora, Status, CodigoProfissional, CodigoPaciente From AgendaProfissional where CodigoProfissional = @codprof and Status = @Status and Dia=@Dia";
        cmd.Parameters.AddWithValue("@codprof", codprof);
        cmd.Parameters.AddWithValue("@Status", statusagenda);
        cmd.Parameters.AddWithValue("@Dia", agendadia);
        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
        DataTable tabela = new DataTable();
        adapter.Fill(tabela);
        DgvDisponivel.ItemsSource = tabela.DefaultView;
        cmd.Dispose();
    }
   */
    private void BtnNovo_Click(object sender, RoutedEventArgs e)
    {
        windowProfissional telaprofissional = new();
        telaprofissional.Show();
    }

    private void BtnLocaliza_Click(object sender, RoutedEventArgs e)
    {

    }

    private void GetProfissional()
    {
        List<Profissional> getprof = new();
        getprof = ProfissionalControler.getprofissional("1");
        if (getprof != null && getprof.Count == 1)
        {
            TxtCodigoProfissional.Text = Convert.ToString(getprof[0].Codigo);
            TxtNomeProfissional.Text = getprof[0].Nome;
        }

    }

    private void CbStatus_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
      
        FillGridIndisponivel();
        FillGridDisponivel();
        
    }

    private void CbStatus_Loaded(object sender, RoutedEventArgs e)
    {
        CbStatus.ItemsSource = new List<string> { "Segunda-Feira", "Terça-Feira", "Quarta-Feira", "Quinta-Feira", "Sexta-Feira", "Sábado", "Domingo" };
    }

    private void Button_Click(object sender, RoutedEventArgs e)
    {
        ConectaBD conexao = new ConectaBD();
        SqlCommand cmd = new SqlCommand();

        foreach (var row in DgvIndisponivel.SelectedItems)
        {
            //List<ConfiguraAgenda> listAgendas = DgvIndisponivel.SelectedItems.OfType<ConfiguraAgenda>().ToList();
            //Products product = row as Products;
            List<ConfiguraAgenda> listAgendas = row as List<ConfiguraAgenda>;
            string codigochange = ((PsiControl.Classes.GetAgenda)row).Codigo;
            string statusagenda = "Disponivel";
            cmd.CommandText = "Update AgendaProfissional set Status=@StatusAgenda where Codigo=@Codigo";
            //Parametros
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@Codigo", codigochange);
            cmd.Parameters.AddWithValue("@StatusAgenda", statusagenda);
            cmd.Connection = conexao.Conectar();
            //Executar Comando acertar de poder preencher mais de um codigo
            cmd.ExecuteNonQuery();
        }
        FillGridIndisponivel();
        FillGridDisponivel();

    }

    private void Button_Click_1(object sender, RoutedEventArgs e)
    {
        ConectaBD conexao = new ConectaBD();
        SqlCommand cmd = new SqlCommand();

        foreach (var row in DgvDisponivel.SelectedItems)
        {
            //List<ConfiguraAgenda> listAgendas = DgvIndisponivel.SelectedItems.OfType<ConfiguraAgenda>().ToList();
            //Products product = row as Products;
            List<ConfiguraAgenda> listAgendas = row as List<ConfiguraAgenda>;
            string codigochange = ((PsiControl.Classes.GetAgenda)row).Codigo;
            string statusagenda = "Indisponivel";
            cmd.CommandText = "Update AgendaProfissional set Status=@StatusAgenda where Codigo=@Codigo";
            //Parametros
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@Codigo", codigochange);
            cmd.Parameters.AddWithValue("@StatusAgenda", statusagenda);
            cmd.Connection = conexao.Conectar();
            //Executar Comando acertar de poder preencher mais de um codigo
            cmd.ExecuteNonQuery();
        }
        FillGridIndisponivel();
        FillGridDisponivel();
    }
}
