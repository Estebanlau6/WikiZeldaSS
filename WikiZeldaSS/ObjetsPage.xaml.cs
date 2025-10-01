using WikiZeldaSS.ViewModels;

namespace WikiZeldaSS;

public partial class ObjetsPage : ContentPage
{
    public ObjetsPage(ObjetsViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
    }
}