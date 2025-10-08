using WikiZeldaSS.ViewModels;

namespace WikiZeldaSS.Pages;

public partial class ObjetsPage : ContentPage
{
    public ObjetsPage()
	{
		InitializeComponent();
		BindingContext = new ObjetsViewModel(new Database.DatabaseService());
    }
}