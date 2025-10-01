using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using WikiZeldaSS.Database;

namespace WikiZeldaSS.ViewModels;

public partial class BaseViewModel : ObservableObject
{
    protected readonly DatabaseService _databaseService;

    protected BaseViewModel(DatabaseService databaseService)
    {
        _databaseService = databaseService;
    }
}
