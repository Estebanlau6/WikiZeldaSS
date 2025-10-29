using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WikiZeldaSS.Database;
using WikiZeldaSS.Models;

namespace WikiZeldaSS.ViewModels;

public partial class LieuxViewModel : ObservableObject
{
    private readonly DatabaseService _databaseService;

    [ObservableProperty]
    private ObservableCollection<Lieu> _lieux;

    public LieuxViewModel(DatabaseService databaseService)
    {
        _databaseService = databaseService;
        Lieux = new ObservableCollection<Lieu>(_databaseService.GetLieux());
    }

    [RelayCommand]
    private void OpenDetailPage(Lieu lieu)
    {
        Shell.Current.GoToAsync("LieuDetail", true, new Dictionary<string, object>
        {
            { "Lieu", lieu }
        });
    }
}
