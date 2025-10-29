using WikiZeldaSS.ViewModels;

namespace WikiZeldaSS.Pages;

public partial class PersonnagesPage : ContentPage
{
    public PersonnagesPage(PersonnagesViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }
}
