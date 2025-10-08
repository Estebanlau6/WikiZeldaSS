using WikiZeldaSS.ViewModels;

namespace WikiZeldaSS.Details;

public partial class LieuxPage : ContentPage
{
    public LieuxPage()
    {
        InitializeComponent();
        BindingContext = new LieuxDetailViewModel(new Database.DatabaseService());
    }
}
