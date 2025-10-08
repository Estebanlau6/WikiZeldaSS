using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WikiZeldaSS.Database;
using WikiZeldaSS.Models;

namespace WikiZeldaSS.ViewModels;

public class LieuxViewModel
{
    private readonly DatabaseService _databaseService;

    public ObservableCollection<Lieu> Lieux { get; set; }

    public LieuxViewModel(DatabaseService databaseService)
    {
        _databaseService = databaseService;
        Lieux = new ObservableCollection<Lieu>(_databaseService.GetLieux());
    }
}
