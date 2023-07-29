using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls.Primitives;
using System.Windows.Navigation;

namespace PsiControl.Classes
{
    class PacienteControler
    {
        ConectaBD conexao = new ConectaBD();
        SqlCommand cmd = new SqlCommand();
        public String mensagem = "";

        public void CadastrarPaciente(Paciente paciente)
        {
            //Paciente(string codigo, string nome, string sexo, string cpf, DateTime datanascimento, string cep, string endereco, string numero, string complemento, string bairro, string cidade, string uf,
            //string celular, string celular2, string email,string situacao, string valorsessao, string diasessao, string horasessao, string diavencimento, DateTime datacadastro, DateTime dataalteracao,string caminhofoto, byte[] foto)
    
            //Comando SQL
            cmd.CommandText = "INSERT INTO PACIENTE (Codigo, Nome, Endereco, Numero, Complemento, Bairro, Cidade, UF, Celular, Celular2, Email, Sexo, DataNascimento, DataCadastro, DataAlteracao,Foto, ValorSessao, DiaVencimento, DiaSessao, HoraSessao, CPF, CEP) " +
                "VALUES (@Cod,@Nome, @Endereco, @Num, @Comp, @Bairro, @Cidade, @UF, @Celular, @Celular2, @Email, @Sexo, @DtNasc, @DtCad, @DtAlt, @Foto, @ValorSessao, @DiaVencimento, @DiaSessao, @HoraSessao, @CPF, @CEP)";
            //Parametros
            cmd.Parameters.AddWithValue("@Cod", paciente.Codigo);
            cmd.Parameters.AddWithValue("@Nome", paciente.Nome);
            cmd.Parameters.AddWithValue("@Endereco", paciente.Endereco);
            cmd.Parameters.AddWithValue("@Num", paciente.Numero);
            cmd.Parameters.AddWithValue("@Comp", paciente.Complemento);
            cmd.Parameters.AddWithValue("@Bairro", paciente.Bairro);
            cmd.Parameters.AddWithValue("@Cidade", paciente.Cidade);
            cmd.Parameters.AddWithValue("@UF", paciente.UF);
            cmd.Parameters.AddWithValue("@Celular", paciente.Celular);
            cmd.Parameters.AddWithValue("@Celular2", paciente.Celular2);
            cmd.Parameters.AddWithValue("@Email", paciente.Email);
            cmd.Parameters.AddWithValue("@Sexo", paciente.Sexo);
            cmd.Parameters.AddWithValue("@DtNasc", paciente.DataNascimento);
            cmd.Parameters.AddWithValue("@DtCad", DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss"));
            cmd.Parameters.AddWithValue("@DtAlt", DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss"));
            
            cmd.Parameters.AddWithValue("@CPF", paciente.CPF);
            cmd.Parameters.AddWithValue("@CEP", paciente.CEP);
            cmd.Parameters.AddWithValue("@ValorSessao", paciente.ValorSessao);
            cmd.Parameters.AddWithValue("@DiaVencimento", paciente.DiaVencimento);
            cmd.Parameters.AddWithValue("@DiaSessao", paciente.DiaSessao);
            cmd.Parameters.AddWithValue("@HoraSessao", paciente.HoraSessao);
            cmd.Parameters.AddWithValue("@Foto", paciente.Foto);
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

        public void AlteraPaciente(Paciente paciente)
        {
            //Paciente(string codigo, string nome, string sexo, string cpf, DateTime datanascimento, string cep, string endereco, string numero, string complemento, string bairro, string cidade, string uf,
            //string celular, string celular2, string email,string situacao, string valorsessao, string diasessao, string horasessao, string diavencimento, DateTime datacadastro, DateTime dataalteracao,string caminhofoto, byte[] foto)

            //Comando SQL
            cmd.CommandText = "Update PACIENTE set Codigo=@Cod, Nome=@Nome, Endereco=@Endereco, Numero=@Num, Complemento=@Comp, Bairro=@Bairro, Cidade=@cidade, UF=@UF, Celular=@Celular, Celular2=@Celular2" +
                ", Email=@Email, Sexo=@Sexo, DataNascimento=@DtNasc, DataCadastro=@DtCad, DataAlteracao=@DtAlt,Foto=@Foto, ValorSessao=@ValorSessao, DiaVencimento=@DiaVencimento, DiaSessao=@DiaSessao, HoraSessao=@HoraSessao, CPF=@CPF, CEP=@CEP Where Codigo=@Cod ";
            //Parametros
            cmd.Parameters.AddWithValue("@Cod", paciente.Codigo);
            cmd.Parameters.AddWithValue("@Nome", paciente.Nome);
            cmd.Parameters.AddWithValue("@Endereco", paciente.Endereco);
            cmd.Parameters.AddWithValue("@Num", paciente.Numero);
            cmd.Parameters.AddWithValue("@Comp", paciente.Complemento);
            cmd.Parameters.AddWithValue("@Bairro", paciente.Bairro);
            cmd.Parameters.AddWithValue("@Cidade", paciente.Cidade);
            cmd.Parameters.AddWithValue("@UF", paciente.UF);
            cmd.Parameters.AddWithValue("@Celular", paciente.Celular);
            cmd.Parameters.AddWithValue("@Celular2", paciente.Celular2);
            cmd.Parameters.AddWithValue("@Email", paciente.Email);
            cmd.Parameters.AddWithValue("@Sexo", paciente.Sexo);
            cmd.Parameters.AddWithValue("@DtNasc", paciente.DataNascimento);
            cmd.Parameters.AddWithValue("@DtCad", DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss"));
            cmd.Parameters.AddWithValue("@DtAlt", DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss"));

            cmd.Parameters.AddWithValue("@CPF", paciente.CPF);
            cmd.Parameters.AddWithValue("@CEP", paciente.CEP);
            cmd.Parameters.AddWithValue("@ValorSessao", paciente.ValorSessao);
            cmd.Parameters.AddWithValue("@DiaVencimento", paciente.DiaVencimento);
            cmd.Parameters.AddWithValue("@DiaSessao", paciente.DiaSessao);
            cmd.Parameters.AddWithValue("@HoraSessao", paciente.HoraSessao);
            cmd.Parameters.AddWithValue("@Foto", paciente.Foto);
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

        public int GetMaxCodigo()
        {
            cmd.Connection = conexao.Conectar();
            //cmd.CommandText = $"SELECT Codigo FROM Paciente";
            cmd.CommandText = $"SELECT MAX(CAST(Codigo AS INTEGER)) FROM Paciente";
            
            int maxcodigo = (int)cmd.ExecuteScalar();
            return maxcodigo + 1;
        }
       
    }
}
