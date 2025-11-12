using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using WikiZeldaSS.Database;
using WikiZeldaSS.Models;
using WikiZeldaSS.Details; 

namespace WikiZeldaSS.ViewModels;

public partial class QuetesViewModel : ObservableObject
{
    private readonly DatabaseService _databaseService;

    
    [ObservableProperty]
    private ObservableCollection<Quete> quetes;

    public QuetesViewModel(DatabaseService databaseService)
    {
        _databaseService = databaseService;
        Quetes = new ObservableCollection<Quete>(_databaseService.GetQuetes());
    }

    // Commande MVVM pour ouvrir la page de détail avec animation fluide
    [RelayCommand]
    private async Task OpenDetailPage(Quete quete)
    {
        if (quete == null)
            return;

        // 🌈 Navigation Shell avec transition animée
        await Shell.Current.GoToAsync(nameof(QuetesDetail), true, new Dictionary<string, object>
        {
            { "Quete", quete }
        });
    }
}
