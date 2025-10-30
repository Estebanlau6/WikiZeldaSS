using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using WikiZeldaSS.Database;
using WikiZeldaSS.Models;

namespace WikiZeldaSS.ViewModels;

public partial class PersonnagesViewModel : ObservableObject
{
    private readonly DatabaseService _databaseService;

    [ObservableProperty]
    public ObservableCollection<Personnage> _personnages;

    public PersonnagesViewModel(DatabaseService databaseService)
    {
        _databaseService = databaseService;
        Personnages = new ObservableCollection<Personnage>(_databaseService.GetPersonnes());
    }
    [RelayCommand]
    private async Task OpenDetailPage(Personnage personnage)
    {
        if (personnage == null)
            return;

        await Shell.Current.GoToAsync("PersonnagesDetailPage", true, new Dictionary<string, object>
        {
            { "Personnage", personnage }
        });
    }
}
