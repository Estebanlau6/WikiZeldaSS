using WikiZeldaSS.ViewModels;

namespace WikiZeldaSS;

public partial class LieuxPage : ContentPage
{
	public LieuxPage(LieuxViewModel viewModel)
	{
		InitializeComponent();
        BindingContext = viewModel;
    }
}