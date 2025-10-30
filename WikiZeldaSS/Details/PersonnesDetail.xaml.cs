using WikiZeldaSS.Models;
namespace WikiZeldaSS.Details;

[QueryProperty(nameof(Personnage), "Personnage")]

public partial class PersonnesDetail : ContentPage
{
    private Personnage _personnage;
    public Personnage Personnage
    {
        get => _personnage;
        set
        {
            _personnage = value;
            BindingContext = _personnage; // met � jour le XAML
        }
    }
    public PersonnesDetail()
	{
		InitializeComponent();
    }
}