using WikiZeldaSS.Details;

namespace WikiZeldaSS
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute("LieuDetail", typeof(LieuxPage));
        }
    }
}
