using System.Collections.ObjectModel;
using WikiZeldaSS.Database;
using WikiZeldaSS.Models;


namespace WikiZeldaSS.ViewModels;

public class QuetesViewModel
{
    private readonly DatabaseService _databaseService;

    public ObservableCollection<Quete> Quetes { get; set; }

    public QuetesViewModel(DatabaseService databaseService)
    {
        _databaseService = databaseService;
        Quetes = new ObservableCollection<Quete>(_databaseService.GetQuetes());
    }
}
