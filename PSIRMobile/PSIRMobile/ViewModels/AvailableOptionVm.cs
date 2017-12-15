using PSIRMobile.Services;
using PSIRModel;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace PSIRMobile.ViewModels
{
    public class AvailableOptionVm : INotifyPropertyChanged
    {
        private AvailableOption _selectedAvailableOption = new AvailableOption();
        private List<AvailableOption> _searchedAvailableOption;
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

        public List<AvailableOption> _availableOptionList { get; set; }

        public List<AvailableOption> AvailableOptionList
        {
            get { return _availableOptionList; }
            set
            {
                _availableOptionList = value;
                OnPropertyChanged();
            }

        }

        public AvailableOption SelectedAvailableOption
        {
            get { return _selectedAvailableOption; }
            set
            {
                _selectedAvailableOption = value;
                OnPropertyChanged();
            }
        }

        public Command PostCommand
        {
            get
            {
                return new Command((async () =>
                {
                    var availbaleOptionService = new AvailbaleOptionService();
                    await availbaleOptionService.PostAvailableOptionAsync(_selectedAvailableOption);
                }));
            }
        }

        public Command RefreshCommand
        {
            get
            {
                return new Command((async () =>
                {
                    var availbaleOptionService = new AvailbaleOptionService();
                    AvailableOptionList = await availbaleOptionService.GetAvailableOptionsAsync();
                    Message = $"Total record is {AvailableOptionList.Count}";
                }));
            }
        }

        public Command PutCommand
        {
            get
            {
                return new Command((async () =>
                {
                    var availbaleOptionService = new AvailbaleOptionService();
                    await availbaleOptionService.PutAvailableOptionAsync(_selectedAvailableOption.AvailableOptionId, _selectedAvailableOption);
                }));
            }
        }

        public Command DeleteCommand
        {
            get
            {
                return new Command((async () =>
                {
                    var availbaleOptionService = new AvailbaleOptionService();
                    await availbaleOptionService.DeleteAvailableOptionAsync(_selectedAvailableOption.AvailableOptionId, _selectedAvailableOption);
                }));
            }
        }

        public Command SearchCommand
        {
            get
            {
                return new Command((async () =>
                {
                    var availbaleOptionService = new AvailbaleOptionService();
                    SearchedEmployees = await availbaleOptionService.GetAvailableOptionByKeyWordAsync(_keyWord);
                }));
            }
        }


        public List<AvailableOption> SearchedEmployees
        {
            get { return _searchedAvailableOption; }
            set
            {
                _searchedAvailableOption = value;
                OnPropertyChanged();
            }
        }

        public AvailableOptionVm()
        {

            InitializeDataAsync();
        }

        private async Task InitializeDataAsync()
        {
            var availbaleOptionService = new AvailbaleOptionService();
            AvailableOptionList = await availbaleOptionService.GetAvailableOptionsAsync();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


    }
}

