using Xamarin.Forms;

namespace Fifa.Mvvm
{
   public class ViewBase: ContentPage
    {
        protected object Param { get; set; }

        public ViewBase()
        {
            Param = null;
        }
        public ViewBase (object param =null)
        {
            Param = param;
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            if (BindingContext is ViewModelBase viewmodel)
            {
                viewmodel.Init(Param);
            }
        }
    }
}
