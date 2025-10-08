using WikiZeldaSS.ViewModels;

namespace WikiZeldaSS.Pages;

public partial class LieuxPage : ContentPage
{
    public LieuxPage()
    {
        InitializeComponent();
        BindingContext = new LieuxViewModel(new Database.DatabaseService());
    }

private async void OnLieuSelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if (e.CurrentSelection.FirstOrDefault() is Lieux lieu)
        {
            await Navigation.PushAsync(new LieuDetail(lieu));

            ((CollectionView)sender).SelectedItem = null;
        }
    }
}
