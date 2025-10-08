using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WikiZeldaSS.Database;
using WikiZeldaSS.Models;

namespace WikiZeldaSS.ViewModels;

public class ObjetsViewModel
{

    private readonly DatabaseService _databaseService;

    public ObservableCollection<Objet> Objets { get; set; }

    public ObjetsViewModel(DatabaseService databaseService)
    {
        _databaseService = databaseService;
        Objets = new ObservableCollection<Objet>(_databaseService.GetObjets());
    }
}
