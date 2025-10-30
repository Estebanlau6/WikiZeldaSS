using WikiZeldaSS.Details;

namespace WikiZeldaSS
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute("LieuDetail", typeof(LieuxPage));
            Routing.RegisterRoute("LieuxDetailPage", typeof(Details.LieuxDetail));
            Routing.RegisterRoute("ObjetsDetailPage", typeof(Details.ObjetsDetail));


        }
    }
}
