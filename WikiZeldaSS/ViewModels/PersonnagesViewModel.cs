using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;
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
}
