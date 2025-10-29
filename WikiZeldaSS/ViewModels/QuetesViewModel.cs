using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;
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
}
