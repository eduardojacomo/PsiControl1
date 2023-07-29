using Microsoft.Win32;
using PsiControl.Classes;
using System;
using System.Collections.Generic;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PsiControl.UserControls
{
    /// <summary>
    /// Interação lógica para mainProfissional.xam
    /// </summary>
    public partial class mainProfissional : UserControl
    {
        public mainProfissional()
        {
            InitializeComponent();
        }
        public int Estado = 0;
        public string caminhoFoto = "";
        public byte[] byteFoto;
        //public byte[] fotoprof;

        public void LimpaCampos()
        {
            TxtCodigo.Text = "";
            TxtNome.Text = "";
            TxtRegProf.Text = "";

        }

        public void novoProfissional()
        {
            LimpaCampos();
            TxtCodigo.IsEnabled = true;
            TxtNome.IsEnabled = true;
            TxtRegProf.IsEnabled = true;
            BtnCancelar.IsEnabled = true;
            BtnSalvar.IsEnabled = true;
            BtnNovo.IsEnabled = false;
            BtnEditar.IsEnabled = false;
            //BtnSair.IsEnabled = false;
            Estado = 0;
        }
        public void editarProfissional()
        {
            TxtCodigo.IsEnabled = true;
            TxtNome.IsEnabled = true;
            TxtRegProf.IsEnabled = true;
            BtnCancelar.IsEnabled = true;
            BtnSalvar.IsEnabled = true;
            BtnNovo.IsEnabled = false;
            BtnEditar.IsEnabled = false;
            //BtnSair.IsEnabled = false;
            Estado = 1;
        }
        public void statusInicial()
        {
            TxtCodigo.IsEnabled = false;
            TxtNome.IsEnabled = false;
            TxtRegProf.IsEnabled = false;
            BtnCancelar.IsEnabled = false;
            BtnSalvar.IsEnabled = false;
            BtnNovo.IsEnabled = true;
            BtnEditar.IsEnabled = true;
            //BtnSair.IsEnabled = true;
        }


        private void BtnSair_Click(object sender, RoutedEventArgs e)
        {
        }

        private void BtnNovo_Click(object sender, RoutedEventArgs e)
        {

            novoProfissional();
        }

        private void BtnCancelar_Click(object sender, RoutedEventArgs e)
        {
            if (Estado == 0)
            {
                LimpaCampos();
            }
            statusInicial();
        }

        private void BtnEditar_Click(object sender, RoutedEventArgs e)
        {
            editarProfissional();
        }

        private void BtnSalvar_Click(object sender, RoutedEventArgs e)
        {
            FileStream fs = new FileStream(caminhoFoto, FileMode.Open, FileAccess.Read);
            byte[] data = new byte[fs.Length];
            fs.Read(data, 0, System.Convert.ToInt32(fs.Length));
            fs.Close();

            if (Estado == 0)
            {

                ProfissionalControler cadprof = new ProfissionalControler();
                Profissional cadastro = new Profissional(TxtCodigo.Text, TxtNome.Text, TxtRegProf.Text, caminhoFoto, data);

                cadprof.CadastrarProfissional(cadastro);
                MessageBox.Show(cadprof.mensagem);
                statusInicial();
                Estado = 1;
            }
            else
            {
                ProfissionalControler alteraprof = new ProfissionalControler();
                Profissional alterar = new Profissional(TxtCodigo.Text, TxtNome.Text, TxtRegProf.Text, caminhoFoto, data);
                alteraprof.AlteraProfissional(alterar);
                MessageBox.Show(alteraprof.mensagem);
                statusInicial();
                Estado = 1;
            }

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
            /*LocalizaProfissional localiza = new LocalizaProfissional();
            TxtCodigo.Text = localiza.Codigo;
            TxtNome.Text = localiza.Nome;
            TxtRegProf.Text = localiza.RegistroProfissional;
            localiza.ShowDialog();*/
            using (LocalizaProfissional form = new LocalizaProfissional())
            {
                var result = form.ShowDialog();

                TxtCodigo.Text = form.Codigo;
                TxtNome.Text = form.Nome;
                TxtRegProf.Text = form.RegistroProfissional;
                byteFoto = form.Foto;
                if (byteFoto != null)
                {
                    LoadFoto();
                }
                else
                {
                    fotoProfissional.Source = null;
                }

                Estado = 1;
            }

        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

        }
    }
}
