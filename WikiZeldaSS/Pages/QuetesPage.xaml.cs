using WikiZeldaSS.ViewModels;

namespace WikiZeldaSS;

public partial class QuetesPage : ContentPage
{
	public QuetesPage(QuetesViewModel viewModel)
	{
		InitializeComponent();
        BindingContext = viewModel;
    }
}