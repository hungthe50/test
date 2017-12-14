using System.Collections.Generic;
using System.Threading.Tasks;
using Fifa.Models;
using Fifa.Client;
using Fifa.Mvvm;
using System;
using Fifa.Views;

namespace Fifa.ViewModels
{
    public class HomePageViewModel : ViewModelBase
    {
        private readonly FifaClient _fifaClient;
        private List<Competition> _competitions;
       

        private Competition _selectedCompetition;

        public Competition SelectedCompetition
        {
            get => _selectedCompetition;
            set
            {
                if (_selectedCompetition != value)
                {
                    _selectedCompetition = value;
                    OnPropertyChanged();
                    OncompetitionSelectedAsync(_selectedCompetition);
                }
            }
        }

        private async void OncompetitionSelectedAsync(Competition selected)
        {
            if (selected != null)
            {
                SelectedCompetition = null;
                await NavigationToPageAsync<CompetitionPage>(selected);
            }
           
        }

        public List<Competition> Competitions
        {
            get => _competitions;
            set
            {
                if (_competitions != value)
                {
                    _competitions = value;
                    OnPropertyChanged();
                }
            }
        }

        public override async void Init(object param=null)
        {
           await LoadAsync();
        }

        public HomePageViewModel()
        {
            _fifaClient = new FifaClient();
        }

        private async Task LoadAsync()
        {
            if(Competitions?.Count>0)
                return;
            
            IsBusy = true;
            var result = await _fifaClient.CurrentAsync();
            IsBusy = false;

            Competitions = result.Data.Competitions;
 
        }

      
    }

  
}
