using WikiZeldaSS.Models;
using WikiZeldaSS.ViewModels;

namespace WikiZeldaSS.Pages;

public partial class LieuxPage : ContentPage
{
    public LieuxPage(LieuxViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }

private async void OnLieuSelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if (e.CurrentSelection.FirstOrDefault() is Lieu lieu)
        {
           // await Navigation.PushAsync(new LieuDetail(lieu));

            ((CollectionView)sender).SelectedItem = null;
        }
    }
}
