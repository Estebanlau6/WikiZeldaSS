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

    //        // On désélectionne l’élément après le clic
    //        ((CollectionView)sender).SelectedItem = null;
    //    }
    //}
}