using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace PsiControl.Classes;

public class Profissional
{
    public int ID { get; set; } 
    public string Codigo { get; set; }
    public string Nome { get; set; }
    public string RegistroProfissional { get; set; }
    public string CaminhoFoto { get; set; }
    public byte[] Foto { get; set; }

    public Profissional()
    {
    }

    public Profissional(string codigo, string nome, string registroprofissional, string caminhofoto, byte[] foto)
    {
        this.Codigo = codigo;
        this.Nome = nome;
        this.RegistroProfissional = registroprofissional;
        this.CaminhoFoto = caminhofoto;
        this.Foto = foto;
    }

    public Profissional(string codprof, string nomeprof, string regprof, byte[] fotoprof)
    {
        this.Codigo = codprof;
        this.Nome = nomeprof;
        this.RegistroProfissional = regprof;
     
        this.Foto = fotoprof;
    }

}
