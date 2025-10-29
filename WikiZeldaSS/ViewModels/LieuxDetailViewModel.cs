using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WikiZeldaSS.Database;
using WikiZeldaSS.Models;

namespace WikiZeldaSS.ViewModels;
public partial class LieuxDetailViewModel : ObservableObject, IQueryAttributable
{
    private readonly DatabaseService _databaseService;

    [ObservableProperty]
    private ObservableCollection<LieuDetail> _detailLieux;

    [ObservableProperty]
    private Lieu _lieu;

    public void ApplyQueryAttributes(IDictionary<string, object> query)
    {
        this.Lieu = (Lieu)query["Lieu"];
    }
    public LieuxDetailViewModel(DatabaseService databaseService)
    {
        _databaseService = databaseService;
        DetailLieux = new ObservableCollection<LieuDetail>(_databaseService.GetLieuxDetails());
    }
}
