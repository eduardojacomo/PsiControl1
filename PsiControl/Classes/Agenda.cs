using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PsiControl.Classes;

public class Agenda
{
    public string Codigo { get; set; }
    public string Dia { get; set; }
    public string Hora { get; set; }
    public string Status { get; set; }
    public string CodigoProfissional { get; set; }
    public string CodigoPaciente { get; set; }

    public Agenda()
    {
    }

}
