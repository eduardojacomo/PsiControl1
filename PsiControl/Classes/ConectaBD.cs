using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PsiControl.Classes;

public class ConectaBD
{
    SqlConnection con = new SqlConnection();


    //Construtor
    public ConectaBD()
    {
        con.ConnectionString = @"Data Source=localhost\SQL2014;Initial Catalog=Clinica;Integrated Security=True; TrustServerCertificate=True;";
    }

    //Metodo Conectar
    public SqlConnection Conectar()
    {
        if (con.State == ConnectionState.Closed)
        {
            con.Open();
        }
        return con;
    }
    //Metodo Desconectar
    public void Desonectar()
    {
        if (con.State == ConnectionState.Open)
        {
            con.Close();
        }
    }
}
