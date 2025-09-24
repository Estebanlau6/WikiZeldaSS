using WikiZeldaSS.ViewModels;

namespace WikiZeldaSS
{
    public partial class MainPage : ContentPage
    {
        public MainPage(MainViewModel viewModel)
        {
            InitializeComponent();
            BindingContext = viewModel;
        }
        private async void OnPersonnagesClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("//PersonnagesPage");
        }

        private async void OnObjetsClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("//ObjetsPage");
        }

        private async void OnLieuxClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("//LieuxPage");
        }

        private async void OnQuetesClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("//QuetesPage");
        }
    }

}
