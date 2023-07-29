using PsiControl.UserControls;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PsiControl.Classes;

public class AgendaControler
{
    static ConectaBD conexaoStatic = new ConectaBD();
    static SqlCommand cmdStatic = new SqlCommand();
    static string mensagemStatic="";

   public static List<Agenda> getagenda(string diasemana, string codprof, string codpac)
    {
        try
        {
            //Conectar com o BD
            cmdStatic.Connection = conexaoStatic.Conectar();
            List<Agenda> getagenda = new List<Agenda>();
            cmdStatic.CommandText = $"select Codigo, Dia, Hora, Status, CodigoProfissional, CodigoPaciente From AgendaProfissional where CodigoProfissional = @codprof and CodigoPaciente = @codpac and Dia=@dia";
            cmdStatic.Parameters.AddWithValue("@codprof", codprof);
            cmdStatic.Parameters.AddWithValue("@codpac", codpac);
            cmdStatic.Parameters.AddWithValue("@dia", diasemana);

            SqlDataReader reader = cmdStatic.ExecuteReader();

            while (reader.Read())
            {
                Agenda agenda = new Agenda();
                agenda.Codigo = reader.GetValue(0).ToString();
                agenda.Dia = reader.GetString(1);
                agenda.Hora = reader.GetString(2);
                agenda.Status = reader.GetString(3);
                agenda.CodigoProfissional = reader.GetString(4);
                agenda.CodigoPaciente = reader.GetString(5);
                getagenda.Add(agenda);
            }
            conexaoStatic.Desonectar();
            return getagenda;
        }
        catch (Exception e)
        {
            mensagemStatic = e.Message;
            return null;
        }
    }

    public static List<Agenda> getagendareservada(string codprof)
    {
        try
        {
            //Conectar com o BD
            cmdStatic.Connection = conexaoStatic.Conectar();
            List<Agenda> getagendareservada = new List<Agenda>();
            cmdStatic.CommandText = $"select Codigo, Dia, Hora, Status, CodigoProfissional, CodigoPaciente From AgendaProfissional where CodigoProfissional = @codprof and CodigoPaciente <> 0";
            cmdStatic.Parameters.AddWithValue("@codprof", codprof);
            
            SqlDataReader reader = cmdStatic.ExecuteReader();

            while (reader.Read())
            {
                Agenda agenda = new Agenda();
                agenda.Codigo = reader.GetValue(0).ToString();
                agenda.Dia = reader.GetString(1);
                agenda.Hora = reader.GetString(2);
                agenda.Status = reader.GetString(3);
                agenda.CodigoProfissional = reader.GetString(4);
                agenda.CodigoPaciente = reader.GetString(5);
                getagendareservada.Add(agenda);
            }
            conexaoStatic.Desonectar();
            return getagendareservada;
        }
        catch (Exception e)
        {
            mensagemStatic = e.Message;
            return null;
        }
    }

    public static implicit operator List<object>(AgendaControler v)
    {
        throw new NotImplementedException();
    }

}
