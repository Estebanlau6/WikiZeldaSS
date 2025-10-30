using WikiZeldaSS.Details;
using WikiZeldaSS.Pages;

namespace WikiZeldaSS
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute("LieuDetail", typeof(LieuxPage));
            Routing.RegisterRoute("LieuxDetailPage", typeof(LieuxDetail));
            Routing.RegisterRoute("ObjetsDetailPage", typeof(ObjetsDetail));
            Routing.RegisterRoute("QueteDetailPage", typeof(QuetesDetail));


        }
    }
}
