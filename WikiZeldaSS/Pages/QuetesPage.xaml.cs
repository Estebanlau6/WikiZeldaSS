using WikiZeldaSS.ViewModels;
using WikiZeldaSS.Models;
using WikiZeldaSS.Details;
namespace WikiZeldaSS.Pages;

public partial class QuetesPage : ContentPage
{
	public QuetesPage(QuetesViewModel viewModel)
	{
		InitializeComponent();
        BindingContext = viewModel;
    }
}