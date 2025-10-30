using WikiZeldaSS.Models;
namespace WikiZeldaSS.Details;

[QueryProperty(nameof(Objet), "Objet")]
public partial class ObjetsDetail : ContentPage
{
    private Objet _objet;
    public Objet Objet
    {
        get => _objet;
        set
        {
            _objet = value;
            BindingContext = _objet; 
        }
    }
    public ObjetsDetail()
	{
		InitializeComponent();
    }
}