using WikiZeldaSS.ViewModels;

namespace WikiZeldaSS.Pages;

public partial class QuetesPage : ContentPage
{
	public QuetesPage(QuetesViewModel viewModel)
	{
		InitializeComponent();
        BindingContext = viewModel;
    }
}