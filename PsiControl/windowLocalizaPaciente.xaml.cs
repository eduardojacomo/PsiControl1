using PsiControl.Classes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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

namespace PsiControl;

/// <summary>
/// Lógica interna para windowLocalizaPaciente.xaml
/// </summary>
public partial class windowLocalizaPaciente : Window, IDisposable
{
    public windowLocalizaPaciente()
    {
        InitializeComponent();
        DtGridLoad();
    }
    public string Codigo { get; set; }
    public string Nome { get; set; }
    public string Cidade { get; set; }
    public string UF { get; set; }
    public string Celular { get; set; }
    public string Sexo { get; set; }
    public DateTime DataNascimento { get; set; }
    public string Endereco { get; set; }
    public string Numero { get; set; }
    public string Complemento { get; set; }
    public string Bairro { get; set; }
    public string CPF { get; set; }
    public string CEP { get; set; }
    public string Celular2 { get; set; }
    public string Email { get; set; }
    public DateTime DataCadastro { get; set; }
    public DateTime DataAlteracao { get; set; }
    public int ID { get; set; }
    public int Situacao { get; set; }
    public Decimal ValorSessao { get; set; }
    public string DiaSessao { get; set; }
    public string HoraSessao { get; set; }
    public int DiaVencimento { get; set; }
    public byte[] Foto { get; set; }
    public string convertbyte = "";
    string Busca = "";

    public windowLocalizaPaciente(string codigo, string nome, string sexo, string cpf, DateTime datanascimento, string cep, string endereco, string numero, string complemento, string bairro, string cidade, string uf,
    string celular, string celular2, string email, decimal valorsessao, string diasessao, string horasessao, int diavencimento, string caminhofoto, byte[] foto)
    {
        this.Codigo = codigo;
        this.Nome = nome;
        this.Sexo = sexo;
        this.CPF = cpf;
        this.Endereco = endereco;
        this.Numero = numero;
        this.Complemento = complemento;
        this.Bairro = bairro;
        this.Cidade = cidade;
        this.UF = uf;
        this.CEP = cep;
        this.Celular = celular;
        this.Celular2 = celular2;
        this.Email = email;
        this.ValorSessao = valorsessao;
        this.DiaSessao = diasessao;
        this.HoraSessao = horasessao;
        this.DiaVencimento = diavencimento;
        //this.Situacao = situacao;
        this.DataNascimento = datanascimento;
                   
        this.Foto = foto;
    }
    private void DtGridLoad()
    {
        ConectaBD conexao = new ConectaBD();
        SqlCommand cmd = new SqlCommand();
        Busca = TxtBuscar.Text;
        cmd.Connection = conexao.Conectar();
        if (Busca == "")
        {
            cmd.CommandText = $"select Codigo, Nome, Endereco, Numero, Complemento, Bairro, Cidade, UF, Celular, Celular2, Email, Sexo, DataNascimento, DataCadastro, DataAlteracao,Foto, ValorSessao, DiaVencimento, DiaSessao, HoraSessao, CPF, CEP From Paciente";
        }
        else
        {
            cmd.CommandText = $"select Codigo, Nome, Endereco, Numero, Complemento, Bairro, Cidade, UF, Celular, Celular2, Email, Sexo, DataNascimento, DataCadastro, DataAlteracao,Foto, ValorSessao, DiaVencimento, DiaSessao, HoraSessao, CPF, CEP From Paciente where Nome like '%" + Busca + "%'";
        }
   
        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
        DataTable tabela = new DataTable();
        adapter.Fill(tabela);
        DgvLocalizaPaciente.ItemsSource = tabela.DefaultView;
        cmd.Dispose();

    }

    private void DgvLocalizaPaciente_MouseDoubleClick(object sender, MouseButtonEventArgs e)
    {
        if (this.DgvLocalizaPaciente.SelectedCells.Count > 0)
        {
            Codigo = ((DataRowView)DgvLocalizaPaciente.SelectedItem).Row["Codigo"].ToString();
            Nome = ((DataRowView)DgvLocalizaPaciente.SelectedItem).Row["Nome"].ToString();
            Endereco = ((DataRowView)DgvLocalizaPaciente.SelectedItem).Row["Endereco"].ToString();
            Numero = ((DataRowView)DgvLocalizaPaciente.SelectedItem).Row["Numero"].ToString();
            Complemento = ((DataRowView)DgvLocalizaPaciente.SelectedItem).Row["Complemento"].ToString();
            Bairro = ((DataRowView)DgvLocalizaPaciente.SelectedItem).Row["Bairro"].ToString();
            Cidade = ((DataRowView)DgvLocalizaPaciente.SelectedItem).Row["Cidade"].ToString();
            UF = ((DataRowView)DgvLocalizaPaciente.SelectedItem).Row["UF"].ToString();
            Celular = ((DataRowView)DgvLocalizaPaciente.SelectedItem).Row["Celular"].ToString();
            Celular2 = ((DataRowView)DgvLocalizaPaciente.SelectedItem).Row["Celular2"].ToString();
            Email = ((DataRowView)DgvLocalizaPaciente.SelectedItem).Row["Email"].ToString();
            Sexo = ((DataRowView)DgvLocalizaPaciente.SelectedItem).Row["Sexo"].ToString();
            DataNascimento = Convert.ToDateTime(((DataRowView)DgvLocalizaPaciente.SelectedItem).Row["DataNascimento"].ToString());
            DataCadastro = Convert.ToDateTime(((DataRowView)DgvLocalizaPaciente.SelectedItem).Row["DataCadastro"].ToString());
            DataAlteracao = Convert.ToDateTime(((DataRowView)DgvLocalizaPaciente.SelectedItem).Row["Dataalteracao"].ToString());
            ValorSessao = decimal.Parse(((DataRowView)DgvLocalizaPaciente.SelectedItem).Row["ValorSessao"].ToString());
            DiaVencimento = Int32.Parse(((DataRowView)DgvLocalizaPaciente.SelectedItem).Row["DiaVencimento"].ToString());
            DiaSessao = ((DataRowView)DgvLocalizaPaciente.SelectedItem).Row["DiaSessao"].ToString();
            HoraSessao = ((DataRowView)DgvLocalizaPaciente.SelectedItem).Row["HoraSessao"].ToString();
            CPF = ((DataRowView)DgvLocalizaPaciente.SelectedItem).Row["CPF"].ToString();
            CEP = ((DataRowView)DgvLocalizaPaciente.SelectedItem).Row["CEP"].ToString();


            if (((DataRowView)DgvLocalizaPaciente.SelectedItem).Row["Foto"].ToString() != "")
            {
                Foto = (Byte[])((DataRowView)DgvLocalizaPaciente.SelectedItem).Row["Foto"];
            }

        }



        Close();
    }

    private void BtnBuscar_Click(object sender, RoutedEventArgs e)
    {
        DtGridLoad();
    }
     

public void Dispose()
{

    //throw new NotImplementedException();
}
}
