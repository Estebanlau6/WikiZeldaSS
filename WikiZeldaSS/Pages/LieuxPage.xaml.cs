using WikiZeldaSS.ViewModels;

namespace WikiZeldaSS.Pages;

public partial class LieuxPage : ContentPage
{
    public LieuxPage()
    {
        InitializeComponent();
        BindingContext = new LieuxViewModel(new Database.DatabaseService());
    }
}