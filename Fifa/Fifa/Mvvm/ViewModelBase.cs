using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Fifa.Annotations;
using Xamarin.Forms;

namespace Fifa.Mvvm
{
   public class ViewModelBase: INotifyPropertyChanged
    {
        private bool _isBusy;
        private string _title;
        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public virtual void Init(object param = null)
        {
           
        }

        public bool IsBusy
        {
            get => _isBusy;
            set
            {
                if (_isBusy != value)
                {
                    _isBusy = value;
                    OnPropertyChanged();
                    OnPropertyChanged(nameof(IsNotBusy));
                }
            }
        }

        public bool IsNotBusy => !IsBusy;

        public string Title
        {
            get => _title;
            set {
                if (_title != value)
                {
                    _title = value;
                    OnPropertyChanged();
                }
                
            }
        }

        protected Task NavigationToPageAsync<T>(object param) where T : ViewBase
        {
            if (Application.Current.MainPage is NavigationPage navigationPage)
            {
                return navigationPage.Navigation.PushAsync(
                    (ViewBase)Activator.CreateInstance(typeof(T),param));
            }
            return Task.FromResult((object)null);
        }
        protected Task NavigationToPageAsync<T>() where T : Page
        {
            if (App.Current.MainPage is NavigationPage navigationPage)
            {
              return  navigationPage.Navigation.PushAsync(Activator.CreateInstance<T>());
            }
            return Task.FromResult((object) null);
        }
    }
}
