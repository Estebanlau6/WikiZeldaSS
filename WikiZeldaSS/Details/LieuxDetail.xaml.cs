// Dans LieuxDetail.xaml.cs
using WikiZeldaSS.Models; // Assure-toi que ce namespace est correct

namespace WikiZeldaSS.Pages
{
    [QueryProperty(nameof(SelectedLieu), "SelectedLieu")]
    public partial class LieuxDetail : ContentPage
    {
        private Lieu _selectedLieu;
        public Lieu SelectedLieu
        {
            get => _selectedLieu;
            set
            {
                _selectedLieu = value;
                // Quand l'objet arrive, on met à jour la page
                UpdatePageData(); 
            }
        }

        public LieuxDetail()
        {
            InitializeComponent();
            BindingContext = this; 
        }

        private void InitializeComponent()
        {
            throw new NotImplementedException();
        }

        private void UpdatePageData()
        {
            if (SelectedLieu != null)
            {
                // Par exemple, si tu as un Label nommé 'TitreLabel' en XAML
                // TitreLabel.Text = SelectedLieu.Nom;
                
                // Ou mieux, si ton XAML binde sur SelectedLieu
                // (ex: <Label Text="{Binding SelectedLieu.Nom}" />)
                // alors tu n'as presque rien à faire ici.
                OnPropertyChanged(nameof(SelectedLieu));
            }
        }
    }
}