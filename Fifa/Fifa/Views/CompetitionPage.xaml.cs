using Xamarin.Forms.Xaml;

namespace Fifa.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CompetitionPage
    {
        public CompetitionPage(object param):base(param)
        {
            InitializeComponent();
        }
    }
}