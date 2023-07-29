using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PsiControl.Classes;

public class Sessao
{
    public int CodigoSessao { get; set; }
    public string CodigoPaciente { get; set; }
    public string CodigoProfissional { get; set; }
    public DateTime DataSessao { get; set; }
    public string HoraInicio { get; set; }
    public string HoraFinal { get; set; }
    public string RegistroSessao { get; set; }
    public decimal ValorSessao { get; set; }
    public Guid IDE { get; set; }
    public string Status { get; set; }
    public string TipoAtendimento { get; set; }
    public string RoteiroSessao { get; set; }

    public Sessao()
    {

    }
}
