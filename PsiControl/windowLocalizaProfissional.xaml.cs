using System;
using System.Data.SqlClient;
using System.Data;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using PsiControl.Classes;
using System.Windows.Documents;
using System.Collections;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace PsiControl;

public partial class LocalizaProfissional : Window, IDisposable
{
    public LocalizaProfissional()
    {
        InitializeComponent();
        DtGridLoad();
    }
    string Busca = "";
    public int ID { get; set; }
    public string Codigo { get; set; }
    public string Nome { get; set; }
    public string RegistroProfissional { get; set; }
    
    public byte[] Foto { get; set; }
    public string convertbyte = "";

    public LocalizaProfissional(int id, string codigo, string nome, string regprof, byte[] foto)
        {
        this.Codigo = codigo;
        this.Nome = nome;
        this.RegistroProfissional = regprof;
        this.ID = id;
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
            cmd.CommandText = $"select ID, Codigo, Nome, RegistroProfissional, Foto From Profissional";
        }
        else
        {
            cmd.CommandText = $"select ID, Codigo, Nome, RegistroProfissional, Foto From Profissional where Nome like '%" + Busca + "%'";
        }
        //cmd.Parameters.AddWithValue(Busca, Name);
        //SqlDataReader reader = cmd.ExecuteReader();
        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
        DataTable tabela = new DataTable();
        adapter.Fill(tabela);
        DgvLocalizaProfissional.ItemsSource = tabela.DefaultView;
        cmd.Dispose();

    }

    private void BtnBuscar_Click(object sender, RoutedEventArgs e)
    {
        DtGridLoad();
    }

    private void DgvLocalizaProfissional_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
    {

        if (this.DgvLocalizaProfissional.SelectedCells.Count > 0)
        {
            ID = Convert.ToInt32(((DataRowView)DgvLocalizaProfissional.SelectedItem).Row["Id"].ToString());
            Codigo = ((DataRowView)DgvLocalizaProfissional.SelectedItem).Row["Codigo"].ToString();
            Nome = ((DataRowView)DgvLocalizaProfissional.SelectedItem).Row["Nome"].ToString();
            RegistroProfissional = ((DataRowView)DgvLocalizaProfissional.SelectedItem).Row["RegistroProfissional"].ToString();
            
            if (((DataRowView)DgvLocalizaProfissional.SelectedItem).Row["Foto"].ToString() != "")
            {
                Foto = (Byte[])((DataRowView)DgvLocalizaProfissional.SelectedItem).Row["Foto"];
            }

        }          



        Close();
    }

    public void Dispose()
    {
        
        //throw new NotImplementedException();
    }

  


}
