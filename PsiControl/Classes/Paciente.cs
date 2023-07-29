using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PsiControl.Classes;

public class Paciente
{
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


    public string CaminhoFoto { get; set; }
    public byte[] Foto { get; set; }

    public Paciente()
    {

    }

    public Paciente(string codigo, string nome, string sexo, string cpf, DateTime datanascimento, string cep, string endereco, string numero, string complemento, string bairro, string cidade, string uf,
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

        this.CaminhoFoto = caminhofoto;
        this.Foto = foto;
    }
}

