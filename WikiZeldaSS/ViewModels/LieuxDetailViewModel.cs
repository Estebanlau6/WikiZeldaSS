using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WikiZeldaSS.Database;
using WikiZeldaSS.Models;

namespace WikiZeldaSS.ViewModels
{
    internal class LieuxDetailViewModel
    {
        private readonly DatabaseService _databaseService;

        public ObservableCollection<LieuDetail> DetailLieux { get; set; }

        public LieuxViewModel(DatabaseService databaseService)
        {
            _databaseService = databaseService;
            DetailLieux = new ObservableCollection<LieuDetail>(_databaseService.GetDetailLieux());
        }
    }
}
