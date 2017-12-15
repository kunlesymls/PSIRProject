using PSIRMobile.Services;
using PSIRModel;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace PSIRMobile.ViewModels
{
    class BuildingVm : INotifyPropertyChanged
    {
        private Building _selectedBuilding = new Building();
        private List<Building> _searchedBuildings;
        private string _keyWord;
        private string _message;

        public string KeyWord
        {
            get { return _keyWord; }
            set
            {
                _keyWord = value;
                OnPropertyChanged();
            }
        }

        public string Message
        {
            get { return _message; }
            set
            {
                _message = value;
                OnPropertyChanged();
            }
        }

        public List<Building> _buildingList { get; set; }

        public List<Building> BuildingList
        {
            get { return _buildingList; }
            set
            {
                _buildingList = value;
                OnPropertyChanged();
            }

        }

        public Building SelectedBuilding
        {
            get { return _selectedBuilding; }
            set
            {
                _selectedBuilding = value;
                OnPropertyChanged();
            }
        }

        public Command PostCommand
        {
            get
            {
                return new Command((async () =>
                {
                    var BuildingService = new BuildingService();
                    await BuildingService.PostBuildingAsync(_selectedBuilding);
                }));
            }
        }

        public Command RefreshCommand
        {
            get
            {
                return new Command((async () =>
                {
                    var BuildingService = new BuildingService();
                    BuildingList = await BuildingService.GetBuildingsAsync();
                    Message = $"Total record is {BuildingList.Count}";
                }));
            }
        }

        public Command PutCommand
        {
            get
            {
                return new Command((async () =>
                {
                    var buildingService = new BuildingService();
                    await buildingService.PutBuildingAsync(_selectedBuilding.BuildingId, _selectedBuilding);
                }));
            }
        }

        public Command DeleteCommand
        {
            get
            {
                return new Command((async () =>
                {
                    var buildingService = new BuildingService();
                    await buildingService.DeleteBuildingAsync(_selectedBuilding.BuildingId, _selectedBuilding);
                }));
            }
        }

        public Command SearchCommand
        {
            get
            {
                return new Command((async () =>
                {
                    var buildingService = new BuildingService();
                    SearchedBuildings = await buildingService.GetBuildingsByKeyWordAsync(_keyWord);
                }));
            }
        }


        public List<Building> SearchedBuildings
        {
            get { return _searchedBuildings; }
            set
            {
                _searchedBuildings = value;
                OnPropertyChanged();
            }
        }

        public BuildingVm()
        {

            InitializeDataAsync();
        }

        private async Task InitializeDataAsync()
        {
            var buildingService = new BuildingService();
            BuildingList = await buildingService.GetBuildingsAsync();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


    }
}


