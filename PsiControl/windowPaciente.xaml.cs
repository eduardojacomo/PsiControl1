using Microsoft.Win32;
using PsiControl.Classes;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace PsiControl
{
    /// <summary>
    /// Lógica interna para windowPaciente.xaml
    /// </summary>
    public partial class windowPaciente : Window
    {
        public windowPaciente()
        {
            InitializeComponent();
        }
        public string caminhoFoto = "";
        public byte[] byteFoto;
        public int Estado;

        private void BtnSair_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }


        private void BtnSalvar_Click(object sender, RoutedEventArgs e)
        {
            FileStream fs = new FileStream(caminhoFoto, FileMode.Open, FileAccess.Read);
            byte[] data = new byte[fs.Length];
            fs.Read(data, 0, System.Convert.ToInt32(fs.Length));
            fs.Close();
            string Situacao0 = "1";
            if (Estado ==0 )
            {
                
                PacienteControler cadpac = new PacienteControler();
                int ultimoCodigo = cadpac.GetMaxCodigo();

                Paciente cadastro = new Paciente(Convert.ToString(ultimoCodigo), TxtNome.Text, TxtSexo.Text, TxtCPF.Text, Convert.ToDateTime(TxtDtNasc.Text), TxtCEP.Text, TxtEnd.Text, TxtNum.Text, TxtComp.Text, TxtBairro.Text, TxtCidade.Text, CbUF.Text, 
                TxtCel.Text, Txtwhats.Text, "Email", decimal.Parse(TxtValorSessao.Text), TxtdiaSessao.Text, TxtHoraSessao.Text, int.Parse(TxtVencimento.Text), caminhoFoto, data ) ;

                cadpac.CadastrarPaciente(cadastro);
                MessageBox.Show(cadpac.mensagem);
                //statusInicial();
                Estado = 1;
            }
            else
            {
                PacienteControler alterpac = new PacienteControler();
                Paciente altera = new Paciente(TxtCodigo.Text, TxtNome.Text, TxtSexo.Text, TxtCPF.Text, Convert.ToDateTime(TxtDtNasc.Text), TxtCEP.Text, TxtEnd.Text, TxtNum.Text, TxtComp.Text, TxtBairro.Text, TxtCidade.Text, CbUF.Text,
                    TxtCel.Text, Txtwhats.Text, "Email", decimal.Parse(TxtValorSessao.Text), TxtdiaSessao.Text, TxtHoraSessao.Text, int.Parse(TxtVencimento.Text), caminhoFoto, data);
                alterpac.AlteraPaciente(altera);
                MessageBox.Show(alterpac.mensagem);
                //statusInicial();
                Estado = 1;
            }
         

        }

        private void BtnNovo_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnEditar_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnCancelar_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnLoadImage_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openDialog = new OpenFileDialog();
            openDialog.Filter = "Image Files |*.png;*.jpg";
            openDialog.FilterIndex = 1;
            if (openDialog.ShowDialog() == true)
            {
                caminhoFoto = openDialog.FileName;
                BitmapImage bitmap = new BitmapImage();
                bitmap.BeginInit();
                bitmap.UriSource = new Uri(caminhoFoto);
                bitmap.EndInit();

                fotoProfissional.Source = bitmap;
            }

        }
        private void LoadFoto()
        {

            byte[] data = byteFoto;
            MemoryStream strm = new MemoryStream();
            strm.Write(data, 0, data.Length);
            strm.Position = 0;
            System.Drawing.Image img = System.Drawing.Image.FromStream(strm);
            BitmapImage bi = new BitmapImage();
            bi.BeginInit();
            MemoryStream ms = new MemoryStream();
            img.Save(ms, System.Drawing.Imaging.ImageFormat.Bmp);
            ms.Seek(0, SeekOrigin.Begin);
            bi.StreamSource = ms;
            bi.EndInit();
            fotoProfissional.Source = bi;

        }
        private void BtnLocaliza_Click(object sender, RoutedEventArgs e)
        {
            using (windowLocalizaPaciente form = new windowLocalizaPaciente())
            {
                var result = form.ShowDialog();

                TxtCodigo.Text = form.Codigo;
                TxtNome.Text = form.Nome;
                TxtEnd.Text = form.Endereco;
                TxtNum.Text = form.Numero;
                TxtComp.Text = form.Complemento;
                TxtBairro.Text = form.Bairro;
                TxtCidade.Text = form.Cidade;
                CbUF.Text = form.UF;
                TxtCEP.Text = form.CEP;
                TxtCPF.Text = form.CPF;
                TxtCel.Text = form.Celular;
                Txtwhats.Text = form.Celular2;
                TxtDtNasc.Text = Convert.ToString(form.DataNascimento);
                TxtdiaSessao.Text = form.DiaSessao;
                TxtHoraSessao.Text = form.HoraSessao;
                TxtValorSessao.Text = Convert.ToString(form.ValorSessao);
                TxtVencimento.Text = Convert.ToString(form.DiaVencimento);


                byteFoto = form.Foto;
                if (byteFoto != null)
                {
                    LoadFoto();
                }

                Estado = 1;
            }
        }
    }
}
