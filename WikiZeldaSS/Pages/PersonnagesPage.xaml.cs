using WikiZeldaSS.ViewModels;

namespace WikiZeldaSS.Pages;

public partial class PersonnagesPage : ContentPage
{
	public PersonnagesPage(MainViewModel viewModel)
	{
		InitializeComponent();
        BindingContext = viewModel;
    }
}