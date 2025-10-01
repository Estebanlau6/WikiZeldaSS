using WikiZeldaSS.ViewModels;

namespace WikiZeldaSS.Pages;

public partial class LieuxPage : ContentPage
{
	public LieuxPage(LieuxViewModel viewModel)
	{
		InitializeComponent();
        BindingContext = viewModel;
    }
}