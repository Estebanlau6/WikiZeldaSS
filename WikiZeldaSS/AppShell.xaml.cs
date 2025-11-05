using WikiZeldaSS.Details;
using WikiZeldaSS.Pages;

namespace WikiZeldaSS
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute("PersonnagesDetailPage", typeof(PersonnesDetail));
            Routing.RegisterRoute("LieuxDetailPage", typeof(LieuxDetail));
            Routing.RegisterRoute("ObjetsDetailPage", typeof(ObjetsDetail));
            Routing.RegisterRoute(nameof(QuetesDetail), typeof(QuetesDetail));



        }
    }
}
