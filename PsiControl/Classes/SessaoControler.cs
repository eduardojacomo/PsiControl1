using PsiControl.UserControls;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace PsiControl.Classes;

class SessaoControler

{
    

    ConectaBD conexao = new ConectaBD();
    SqlCommand cmd = new SqlCommand();
    public string mensagem = "";

    public void CadastrarSessao( Sessao sessao)
    {
        //Guid Ide;
        cmd.CommandText = "INSERT INTO SESSAO (CodigoSessao, DataSessao, HoraInicio, HoraFinal, RegistroSessao, ValorSessao, CodigoPaciente, CodigoProfissional, IDE, Status, TipoAtendimento) " +
                "VALUES (@CodigoSessao,@DataSessao,@HoraInicio, @HoraFinal, @RegistroSessao, @ValorSessao, @CodigoPaciente, @CodigoProfissional, @IDE, @Status, @TipoAtendimento)";
        cmd.Parameters.AddWithValue("@CodigoSessao", sessao.CodigoSessao);
        cmd.Parameters.AddWithValue("DataSessao", Convert.ToDateTime(sessao.DataSessao));
        cmd.Parameters.AddWithValue("@HoraInicio", sessao.HoraInicio);
        cmd.Parameters.AddWithValue("@HoraFinal", sessao.HoraFinal);
        cmd.Parameters.AddWithValue("@RegistroSessao", sessao.RegistroSessao);
        cmd.Parameters.AddWithValue("@ValorSessao", Convert.ToDecimal(sessao.ValorSessao));
        cmd.Parameters.AddWithValue("@CodigoPaciente", sessao.CodigoPaciente);
        cmd.Parameters.AddWithValue("@CodigoProfissional", sessao.CodigoProfissional);
        cmd.Parameters.AddWithValue("@IDE", Guid.NewGuid());
        cmd.Parameters.AddWithValue("@Status", sessao.Status);
        cmd.Parameters.AddWithValue("@TipoAtendimento", sessao.TipoAtendimento);
        //cmd.Parameters.AddWithValue("@RoteiroSecao", sessao.RoteiroSessao);
        

        try
        {
            //Conectar com o BD
            cmd.Connection = conexao.Conectar();
            //Executar Comando
            cmd.ExecuteNonQuery();
            //mensagem
            mensagem = "Cadastrado com Sucesso";
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

    public void AlterarSessao(Sessao sessao)
    {
        //Guid Ide;
        cmd.CommandText = "UPDATE SESSAO SET CodigoSessao = @CodigoSessao, DataSessao=@DataSessao, HoraInicio=@HoraInicio, HoraFinal=@HoraFinal, RegistroSessao=@RegistroSessao, ValorSessao=@ValorSessao, CodigoPaciente=@CodigoPaciente, CodigoProfissional=@CodigoProfissional, Status=@Status, TipoAtendimento=@TipoAtendimento, RoteiroSessao=@RoteiroSessao " +
                "WHERE IDE=@IDE";
        cmd.Parameters.AddWithValue("@CodigoSessao", sessao.CodigoSessao);
        cmd.Parameters.AddWithValue("DataSessao", sessao.DataSessao);
        cmd.Parameters.AddWithValue("@HoraInicio", sessao.HoraInicio);
        cmd.Parameters.AddWithValue("@HoraFinal", sessao.HoraFinal);
        cmd.Parameters.AddWithValue("@RegistroSessao", sessao.RegistroSessao);
        cmd.Parameters.AddWithValue("@ValorSessao", Convert.ToDecimal(sessao.ValorSessao));
        cmd.Parameters.AddWithValue("@CodigoPaciente", sessao.CodigoPaciente);
        cmd.Parameters.AddWithValue("@CodigoProfissional", sessao.CodigoProfissional);
        cmd.Parameters.AddWithValue("@IDE", sessao.IDE);
        cmd.Parameters.AddWithValue("@Status", sessao.Status);
        cmd.Parameters.AddWithValue("@TipoAtendimento", sessao.TipoAtendimento);
        cmd.Parameters.AddWithValue("@RoteiroSecao", sessao.RoteiroSessao);


        try
        {
            //Conectar com o BD
            cmd.Connection = conexao.Conectar();
            //Executar Comando
            cmd.ExecuteNonQuery();
            //mensagem
            mensagem = "Alterado com Sucesso";
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

    public void ExcluirSessao(Sessao sessao)
    {
        //Guid Ide;
        cmd.CommandText = "Delete from Sessao WHERE IDE=@IDE";
            
        cmd.Parameters.AddWithValue("@IDE", sessao.IDE);
            
        try
        {
            //Conectar com o BD
            cmd.Connection = conexao.Conectar();
            //Executar Comando
            cmd.ExecuteNonQuery();
            //mensagem
            mensagem = "Alterado com Sucesso";
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

    public int GetMaxCodigo(string codpac, string codprof)
    {
        cmd.Connection = conexao.Conectar();
        //cmd.CommandText = $"SELECT Codigo FROM Paciente";
        cmd.CommandText = $"SELECT MAX(CAST(CodigoSessao AS INTEGER)) FROM Sessao where CodigoProfissional=@CodigoProf and CodigoPaciente=@CodigoPac";
        cmd.Parameters.AddWithValue("@CodigoPac", codpac);
        cmd.Parameters.AddWithValue("@CodigoProf", codprof);
        int maxcodigo = (int)cmd.ExecuteScalar();
        return maxcodigo + 1;
    }

    
    /*public List<Sessao> Getlistsessao()
    {
        List<Sessao> listsessao = new List<Sessao>();
        cmd.CommandText = "Select CodigoSessao, DataSessao, HoraInicio, HoraFinal, RegistroSessao, ValorSessao, CodigoPaciente, CodigoProfissional, IDE, Status, TipoAtendimento, RoteiroSessao " +
                "from sessao where IDE= @IDE";
        cmd.Parameters.AddWithValue("@CodigoSessao", Sessao.CodigoSessao);
        cmd.Parameters.AddWithValue("DataSessao", sessao.DataSessao);
        cmd.Parameters.AddWithValue("@HoraInicio", sessao.HoraInicio);
        cmd.Parameters.AddWithValue("@HoraFinal", sessao.HoraFinal);
        cmd.Parameters.AddWithValue("@RegistroSessao", sessao.RegistroSessao);
        cmd.Parameters.AddWithValue("@ValorSessao", Convert.ToDecimal(sessao.ValorSessao));
        cmd.Parameters.AddWithValue("@CodigoPaciente", sessao.CodigoPaciente);
        cmd.Parameters.AddWithValue("@CodigoProfissional", sessao.CodigoProfissional);
        cmd.Parameters.AddWithValue("@IDE", sessao.IDE);
        cmd.Parameters.AddWithValue("@Status", sessao.Status);
        cmd.Parameters.AddWithValue("@TipoAtendimento", sessao.TipoAtendimento);
        cmd.Parameters.AddWithValue("@RoteiroSecao", sessao.RoteiroSessao);


        try
        {
            //Conectar com o BD
            cmd.Connection = conexao.Conectar();

            SqlDataReader reader = cmd.ExecuteReader();
            //Executar Comando
            while (reader.Read())
            {

                Sessao sessao1 = new Sessao();
                sessao1.CodigoSessao = reader.GetInt32(0);
                sessao1.DataSessao = reader.GetDateTime(1);
                sessao1.HoraInicio = reader.GetString(2);
                sessao1.HoraFinal = reader.GetString(3);
                sessao1.RegistroSessao = reader.GetString(4);
                sessao1.ValorSessao = reader.GetDecimal(5);
                sessao1.CodigoPaciente = reader.GetString(6);
                sessao1.CodigoProfissional = reader.GetString(7);
                sessao1.IDE = reader.GetGuid(8);
                sessao1.Status = reader.GetString(9);
                sessao1.TipoAtendimento = reader.GetString(10);
                sessao1.RoteiroSessao = reader.GetString(11);

                listsessao.Add(sessao1);
            }
            conexao.Desonectar();
            return listsessao;
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

    }*/


}
