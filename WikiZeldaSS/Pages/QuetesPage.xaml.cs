using WikiZeldaSS.ViewModels;

namespace WikiZeldaSS.Pages;

public partial class QuetesPage : ContentPage
{
	public QuetesPage()
	{
		InitializeComponent();
        BindingContext = new QuetesViewModel(new Database.DatabaseService());
    }
}