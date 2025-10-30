using WikiZeldaSS.Models; 
namespace WikiZeldaSS.Details
{
    public partial class LieuxDetail : ContentPage
    {
        public LieuxDetail(Lieu lieu)
        {
            InitializeComponent();
            BindingContext = lieu; 
        }
    }
}