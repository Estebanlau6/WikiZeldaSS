using WikiZeldaSS.Models;
using WikiZeldaSS.ViewModels;
using WikiZeldaSS.Details;

namespace WikiZeldaSS.Pages;

public partial class LieuxPage : ContentPage
{
    public LieuxPage(LieuxViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }

}
