using WikiZeldaSS.Models;
namespace WikiZeldaSS.Details;

public partial class PersonnesDetail : ContentPage
{
	public PersonnesDetail(Personnage personnage)
	{
		InitializeComponent();
		BindingContext = personnage;
    }
}