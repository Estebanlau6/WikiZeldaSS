using WikiZeldaSS.ViewModels;

namespace WikiZeldaSS;

public partial class PersonnagesPage : ContentPage
{
	public PersonnagesPage(MainViewModel viewModel)
	{
		InitializeComponent();
        BindingContext = viewModel;
    }
}