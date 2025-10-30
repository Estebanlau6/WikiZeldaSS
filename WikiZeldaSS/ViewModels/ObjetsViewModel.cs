using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using WikiZeldaSS.Database;
using WikiZeldaSS.Models;

namespace WikiZeldaSS.ViewModels;

public partial class ObjetsViewModel : ObservableObject
{

    private readonly DatabaseService _databaseService;

    [ObservableProperty]
    public ObservableCollection<Objet> _objets;

    public ObjetsViewModel(DatabaseService databaseService)
    {
        _databaseService = databaseService;
        Objets = new ObservableCollection<Objet>(_databaseService.GetObjets());
    }
    [RelayCommand]
    private async Task OpenDetailPage(Objet objet)
    {
        if (objet == null)
            return;

        await Shell.Current.GoToAsync("ObjetsDetailPage", true, new Dictionary<string, object>
        {
            { "Objet", objet }
        });
    }
}
