namespace MauiApHotel.Views;

public partial class ContratacaoDaHospedagem : ContentPage
{
    App PropiedadesApp;

    public ContratacaoDaHospedagem()
    {
        InitializeComponent();

        PropiedadesApp = (App)Application.Current;

        pck_quarto.ItemsSource = PropiedadesApp.lista_quartos;

        dtpxk_chekin.MinimumDate = DateTime.Now;
        dtpxk_chekin.MaximumDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month + 1, DateTime.Now.Day);

        dtpxk_chekout.MaximumDate = dtpxk_chekin.Date.AddDays(1);
        dtpxk_chekout.MaximumDate = dtpxk_chekout.Date.AddMonths(6);
    }

    private void Button_Clicked(object sender, EventArgs e)
    {
        try
        {

            Navigation.PushAsync(new HospedagemContratada());

        } catch (Exception ex)  
        {
            DisplayAlert("Ops", ex.Message, "OK");
        }
    }

    private void dtpxk_chekin_DateSelected(object sender, DateChangedEventArgs e)
    {
        DatePicker elemento = sender as DatePicker;

        DateTime data_selecionada_checkin = elemento.Date;

        dtpxk_chekout.MinimumDate = data_selecionada_checkin.AddDays(1);
        dtpxk_chekout.MaximumDate = data_selecionada_checkin.AddMonths(6);
    }
}
