using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PsiControl.Classes;

public class GetAgenda
{
    public string Codigo { get; set; }
    public string Dia { get; set; }
    public string Hora { get; set; }
    public string Status { get; set; }
    public string CodigoProfissional { get; set; }
    public string CodigoPaciente { get; set; }

    ConectaBD conexao = new ConectaBD();
    SqlCommand cmd = new SqlCommand();
    string mensagem = "";
    public string diasemana;
    
    public List<GetAgenda> montaagenda(string diasemana, string statusagenda, string codprof)
    {
        ;
        try
        {
            
            
            //Conectar com o BD
            cmd.Connection = conexao.Conectar();
            List<GetAgenda> agendaa = new List<GetAgenda>();
            cmd.CommandText = $"select Codigo, Dia, Hora, Status, CodigoProfissional, CodigoPaciente From AgendaProfissional where CodigoProfissional = @codprof and Status = @Status and Dia=@Dia";
            cmd.Parameters.AddWithValue("@codprof", codprof);
            cmd.Parameters.AddWithValue("@Status", statusagenda);
            cmd.Parameters.AddWithValue("@Dia", diasemana);


            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {

                GetAgenda agenda = new GetAgenda();
                agenda.Codigo = reader.GetValue(0).ToString();
                agenda.Dia = reader.GetString(1);
                agenda.Hora = reader.GetString(2);
                agenda.Status = reader.GetString(3);
                agenda.CodigoProfissional = reader.GetString(4);
                agenda.CodigoPaciente = reader.GetString(5);
                agendaa.Add(agenda);
            }
            conexao.Desonectar();
            return agendaa;
        }
        catch (Exception e)
        {
            mensagem = e.Message;
            return null;
        }
    }

    public static implicit operator List<object>(GetAgenda v)
    {
        throw new NotImplementedException();
    }
}
