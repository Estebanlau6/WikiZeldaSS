using WikiZeldaSS.Models;
namespace WikiZeldaSS.Details;

[QueryProperty(nameof(Quete), "Quete")]
public partial class QuetesDetail : ContentPage
{
    private Quete _quete;
    public Quete Quete
    {
        get => _quete;
        set
        {
            _quete = value;
            BindingContext = _quete; // pour que le XAML se mette à jour
        }
    }
    public QuetesDetail()
	{
		InitializeComponent();
    }
}