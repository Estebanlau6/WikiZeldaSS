using WikiZeldaSS.Models; 
namespace WikiZeldaSS.Details
{
    [QueryProperty(nameof(Lieu), "Lieu")]
    public partial class LieuxDetail : ContentPage
    {
        private Lieu _lieu;
        public Lieu Lieu
        {
            get => _lieu;
            set
            {
                _lieu = value;
                BindingContext = _lieu; 
            }
        }
        public LieuxDetail()
        {
            InitializeComponent();
        }
    }
}