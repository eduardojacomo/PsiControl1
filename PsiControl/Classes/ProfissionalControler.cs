using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace PsiControl.Classes;

public class ProfissionalControler
{
    public string mensagem = "";
    public string codigo;
    public string nome;

    ConectaBD conexao = new ConectaBD();
    SqlCommand cmd = new SqlCommand();

    static ConectaBD conexaoStatic = new ConectaBD();
    static SqlCommand cmdStatic = new SqlCommand();
    static string mensagemStatic = "";


    public void CadastrarProfissional(Profissional profissional)
    {


        cmd.CommandText = "INSERT INTO PROFISSIONAL (Codigo, Nome, RegistroProfissional, Foto) VALUES (@Codigo,@Nome, @RegistroProfissional, @foto)";
        cmd.Parameters.AddWithValue("@Codigo", profissional.Codigo);
        cmd.Parameters.AddWithValue("@Nome", profissional.Nome);
        cmd.Parameters.AddWithValue("@RegistroProfissional", profissional.RegistroProfissional);
        cmd.Parameters.AddWithValue("@Foto", profissional.Foto);

        try
        {
            //Conectar com o BD
            cmd.Connection = conexao.Conectar();
            //Executar Comando
            cmd.ExecuteNonQuery();
            //mensagem
            this.mensagem = "Cadastrado com Sucesso";
        }
        catch (SqlException e)
        {
            //this.mensagem = "Erro ao tentar se conectar ao BD";
            mensagem = e.Message;
        }
        finally
        {
            conexao.Desonectar();
        }
    }

    public void AlteraProfissional(Profissional profissional)
    {
        cmd.CommandText = "Update Profissional set Codigo=@Codigo, Nome=@Nome, RegistroProfissional=@RegistroProfissional, Foto=@Foto where Codigo=@Codigo";
        //Parametros
        cmd.Parameters.AddWithValue("@Codigo", profissional.Codigo) ;
        cmd.Parameters.AddWithValue("@Nome", profissional.Nome);
        cmd.Parameters.AddWithValue("@RegistroProfissional", profissional.RegistroProfissional);
        cmd.Parameters.AddWithValue("@Foto", profissional.Foto);

        try
        {        
            //Conectar com o BD
            cmd.Connection = conexao.Conectar();
            //Executar Comando
            cmd.ExecuteNonQuery();
            //mensagem
            this.mensagem = "Alterado com Sucesso";
        }
        catch (SqlException e)
        {
            //this.mensagem = "Erro ao tentar se conectar ao BD";
            mensagem = e.Message;
        }
        finally
        {
            conexao.Desonectar();
        }
    }

    public void LocalizaProfissional()
    {
    }
    public static List<Profissional> getprofissional(string codprof)
    {
        
        try
        {
            //Conectar com o BD
            cmdStatic.Connection = conexaoStatic.Conectar();
            List<Profissional> getprof = new List<Profissional>();
            cmdStatic.CommandText = $"select Codigo, Nome, RegistroProfissional, Foto From Profissional where Codigo=@CodProf";
            cmdStatic.Parameters.AddWithValue("@CodProf", codprof);
            

            SqlDataReader reader = cmdStatic.ExecuteReader();

            while (reader.Read())
            {
                Profissional profissional = new Profissional();
                profissional.Codigo = reader.GetString(0);
                profissional.Nome = reader.GetString(1);
                profissional.RegistroProfissional = reader.GetString(2);
                profissional.Foto = (byte[])reader[3];
                //codigo = reader.GetString(0);
                //nome = reader.GetString(1);
                getprof.Add(profissional);
            }
            conexaoStatic.Desonectar();
            return getprof ;
        }
        catch (Exception e)
        {
            mensagemStatic = e.Message;
            return null;
        }
    }
}
