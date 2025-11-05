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
            BindingContext = _quete;
        }
    }

    public QuetesDetail()
    {
        InitializeComponent();

        // 🎬 Préparation de l’animation : tout le contenu est invisible au départ
        this.Opacity = 0;
        this.Scale = 0.85;
        this.TranslationY = 50;
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();

        // ✨ Animation combinée (fade + zoom + slide vers le haut)
        await Task.WhenAll(
            this.FadeTo(1, 600, Easing.CubicInOut),
            this.ScaleTo(1, 600, Easing.CubicOut),
            this.TranslateTo(0, 0, 600, Easing.CubicOut)
        );
    }
}
