using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using WikiZeldaSS.Database;
using WikiZeldaSS.Models;


namespace WikiZeldaSS.ViewModels;

public partial class QuetesViewModel : ObservableObject
{
    private readonly DatabaseService _databaseService;

    [ObservableProperty]
    public ObservableCollection<Quete> _quetes;

    public QuetesViewModel(DatabaseService databaseService)
    {
        _databaseService = databaseService;
        Quetes = new ObservableCollection<Quete>(_databaseService.GetQuetes());
    }
    [RelayCommand]
    private async Task OpenDetailPage(Quete quete)
    {
        if (quete == null)
            return;

        await Shell.Current.GoToAsync("QueteDetailPage", true, new Dictionary<string, object>
    {
        { "Quete", quete }
    });
    }

}
