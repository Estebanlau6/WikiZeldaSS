using WikiZeldaSS.ViewModels;

namespace WikiZeldaSS.Pages;

public partial class ObjetsPage : ContentPage
{
    public ObjetsPage(ObjetsViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
    }
}