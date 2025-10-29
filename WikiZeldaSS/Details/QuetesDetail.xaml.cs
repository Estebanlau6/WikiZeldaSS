using WikiZeldaSS.Models;
namespace WikiZeldaSS.Details;

public partial class QuetesDetail : ContentPage
{
	public QuetesDetail(Quete quete)
	{
		InitializeComponent();
		BindingContext = quete;
    }
}