using WikiZeldaSS.ViewModels;

namespace WikiZeldaSS.Pages;

public partial class PersonnagesPage : ContentPage
{
    public PersonnagesPage()
    {
        InitializeComponent();
        BindingContext = new PersonnagesViewModel(new Database.DatabaseService());
    }
}
