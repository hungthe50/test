using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Fifa.Client;
using Fifa.Models;
using Fifa.Mvvm;
using Xamarin.Forms;

namespace Fifa.ViewModels
{
    class CompetitionViewModel: ViewModelBase
    {
        private FifaClient _fifaClient;
        private CompetitionDetail _competition;

        public CompetitionViewModel()
        {
            _fifaClient=new FifaClient();
            MatchCommand = new Command(ViewMatch);
        }

        private void ViewMatch(object obj)
        {
           
        }

        public CompetitionDetail Competition
        {
            get { return _competition; }
            private set
            {
                if (_competition != value)
                {
                    _competition = value;
                    OnPropertyChanged();
                }
            }
        }

        public ICommand MatchCommand { get; }
        public override async void Init(object param = null)
        {
            
            base.Init(param);
            if (param is Competition competition)
            {
                Title = competition.CompetitionEn;
                IsBusy = true;
               var resuft = await _fifaClient.CompetitionAsync(competition.CompetitionId.ToString());
                if (resuft.Success)
                {
                    Competition = resuft.Data;
                }
                IsBusy = false;
                
            }
        }
    }
}
