using WikiZeldaSS.ViewModels;
using WikiZeldaSS.Models;
using WikiZeldaSS.Details;
namespace WikiZeldaSS.Pages;

public partial class QuetesPage : ContentPage
{
	public QuetesPage()
	{
		InitializeComponent();
        BindingContext = new QuetesViewModel(new Database.DatabaseService());
    }
    //private async void OnQueteSelected(object sender, SelectionChangedEventArgs e)
    //{
    //    if (e.CurrentSelection.FirstOrDefault() is Quete selectedQuete)
    //    {
    //        await Navigation.PushAsync(new QuetesDetail(selectedQuete));

    //        // On d�s�lectionne l��l�ment apr�s le clic
    //        ((CollectionView)sender).SelectedItem = null;
    //    }
    //}
}