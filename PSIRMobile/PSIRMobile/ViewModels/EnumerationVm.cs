using PSIRMobile.Services;
using PSIRModel;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace PSIRMobile.ViewModels
{
    public class EnumerationVm : INotifyPropertyChanged
    {
        private BuildingEnumeration _selectedBuildingEnumeration = new BuildingEnumeration();
        private List<BuildingEnumeration> _searchedBuildingEnumeration;
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

        public List<BuildingEnumeration> _buildingEnumerationList { get; set; }

        public List<BuildingEnumeration> BuildingEnumerationList
        {
            get { return _buildingEnumerationList; }
            set
            {
                _buildingEnumerationList = value;
                OnPropertyChanged();
            }

        }

        public BuildingEnumeration SelectedEmployee
        {
            get { return _selectedBuildingEnumeration; }
            set
            {
                _selectedBuildingEnumeration = value;
                OnPropertyChanged();
            }
        }

        public Command PostCommand
        {
            get
            {
                return new Command((async () =>
                {
                    var enumerationService = new EnumerationService();
                    await enumerationService.PostBuildingEnumerationAsync(_selectedBuildingEnumeration);
                }));
            }
        }

        public Command RefreshCommand
        {
            get
            {
                return new Command((async () =>
                {
                    var enumerationService = new EnumerationService();
                    BuildingEnumerationList = await enumerationService.GetBuildingEnumerationsAsync();
                    Message = $"Total record is {BuildingEnumerationList.Count}";
                }));
            }
        }

        public Command PutCommand
        {
            get
            {
                return new Command((async () =>
                {
                    var enumerationService = new EnumerationService();
                    await enumerationService.PutBuildingEnumerationAsync(_selectedBuildingEnumeration.BuildingEnumerationId, _selectedBuildingEnumeration);
                }));
            }
        }

        public Command DeleteCommand
        {
            get
            {
                return new Command((async () =>
                {
                    var enumerationService = new EnumerationService();
                    await enumerationService.DeleteBuildingEnumerationAsync(_selectedBuildingEnumeration.BuildingEnumerationId, _selectedBuildingEnumeration);
                }));
            }
        }

        public Command SearchCommand
        {
            get
            {
                return new Command((async () =>
                {
                    var enumerationService = new EnumerationService();
                    SearchedEmployees = await enumerationService.GetBuildingEnumerationByKeyWordAsync(_keyWord);
                }));
            }
        }


        public List<BuildingEnumeration> SearchedEmployees
        {
            get { return _searchedBuildingEnumeration; }
            set
            {
                _searchedBuildingEnumeration = value;
                OnPropertyChanged();
            }
        }

        public EnumerationVm()
        {

            InitializeDataAsync();
        }

        private async Task InitializeDataAsync()
        {
            var enumerationService = new EnumerationService();
            BuildingEnumerationList = await enumerationService.GetBuildingEnumerationsAsync();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


    }
}


