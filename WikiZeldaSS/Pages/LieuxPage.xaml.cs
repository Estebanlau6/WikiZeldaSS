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
    protected override void OnAppearing()
    {
        base.OnAppearing();


        LieuxCollectionView.SelectedItem = null;
    }

}
