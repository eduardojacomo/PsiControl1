using PsiControl.Classes;
using System;
using System.Windows;


namespace PsiControl;

/// <summary>
/// Lógica interna para windowSessao.xaml
/// </summary>
public partial class windowSessao : Window
{
    public windowSessao()
    {
        InitializeComponent();
    }

    private void BtnLocaliza_Click(object sender, RoutedEventArgs e)
    {
        
        
        using (LocalizaProfissional form = new LocalizaProfissional())
        {
            var result = form.ShowDialog();

            TxtCodigoProfissional.Text = form.Codigo;
            TxtNomeProfissional.Text = form.Nome;
        }
    }

    private void BtnLocalizaPaciente_Click(object sender, RoutedEventArgs e)
    {
        using (windowLocalizaPaciente form = new windowLocalizaPaciente())
        {
            var result = form.ShowDialog();

            TxtCodigoPaciente.Text = form.Codigo;
            TxtNomePaciente.Text = form.Nome;
            TxtValorSessao.Text = Convert.ToString(form.ValorSessao);
        }
    }

    private void BtnSalvar_Click(object sender, RoutedEventArgs e)
    {
        //Sessao cadastro = new Paciente(Convert.ToString(ultimoCodigo), TxtNome.Text, TxtSexo.Text, TxtCPF.Text, Convert.ToDateTime(TxtDtNasc.Text), TxtCEP.Text, TxtEnd.Text, TxtNum.Text, TxtComp.Text, TxtBairro.Text, TxtCidade.Text, CbUF.Text,
        //      TxtCel.Text, Txtwhats.Text, "Email", decimal.Parse(TxtValorSessao.Text), TxtdiaSessao.Text, TxtHoraSessao.Text, int.Parse(TxtVencimento.Text), caminhoFoto, data);

        //CodigoSessao, DataSessao, HoraInicio, HoraFinal, RegistroSessao, ValorSessao, CodigoPaciente, CodigoProfissional, IDE, Status, TipoAtendimento, RoteiroSessao

        SessaoControler sessaoControler = new();
        int ultimoCodigo = sessaoControler.GetMaxCodigo(TxtCodigoPaciente.Text,TxtCodigoProfissional.Text);
        Sessao cadastro = new Sessao();
        cadastro.CodigoSessao = ultimoCodigo;
        cadastro.DataSessao = Convert.ToDateTime(TxtDataSessao.Text);
        cadastro.HoraInicio = TxtHoraHinicio.Text;
        cadastro.HoraFinal = TxtHoraFinal.Text;
        cadastro.RegistroSessao = TxtRgistro.Text;
        cadastro.ValorSessao = Convert.ToDecimal(TxtValorSessao.Text);
        cadastro.CodigoPaciente = TxtCodigoPaciente.Text;
        cadastro.CodigoProfissional = TxtCodigoProfissional.Text;
        cadastro.Status = CbStatus.Text;
        cadastro.TipoAtendimento = "Presencial";
        //cadastro.RoteiroSessao = TxtRoteiro.Text;
        sessaoControler.CadastrarSessao(cadastro);
        MessageBox.Show(sessaoControler.mensagem);
        //MessageBoxResult messageBoxResult = MessageBox.Show(SessaoControler.CadastrarSecao.mensagem);
    }

    private void DatePicker_SelectedDateChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
    {
        TxtDataSessao.Text = Calendario.SelectedDate.ToString();
    }
}


