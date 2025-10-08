using System.Collections.ObjectModel;
using WikiZeldaSS.Database;
using WikiZeldaSS.Models;

namespace WikiZeldaSS.ViewModels;

public class PersonnagesViewModel
{
    private readonly DatabaseService _databaseService;

    public ObservableCollection<Personnage> Personnages { get; set; }

    public PersonnagesViewModel(DatabaseService databaseService)
    {
        _databaseService = databaseService;
        Personnages = new ObservableCollection<Personnage>(_databaseService.GetPersonnes());
    }

    public List<Personnage> GetPagePersonne()
    {
        return _databaseService.GetPersonnes();
    }
}