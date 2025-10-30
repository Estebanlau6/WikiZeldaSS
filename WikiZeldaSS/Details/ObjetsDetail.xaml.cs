using WikiZeldaSS.Models;
namespace WikiZeldaSS.Details;

public partial class ObjetsDetail : ContentPage
{
	public ObjetsDetail(Objet objet)
	{
		InitializeComponent();
		BindingContext = objet;
    }
}