using WikiZeldaSS.ViewModels;
using WikiZeldaSS.Database;
namespace WikiZeldaSS.Pages;

public partial class ObjetsPage : ContentPage
{
    public ObjetsPage(ObjetsViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
    }
}