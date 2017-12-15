using PSIRMobile.Services;
using PSIRModel;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace PSIRMobile.ViewModels
{
    public class ShopVm : INotifyPropertyChanged
    {
        private Shop _selectedShop = new Shop();
        private List<Shop> _searchedShops;
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

        public List<Shop> _shopsList { get; set; }

        public List<Shop> ShopsList
        {
            get { return _shopsList; }
            set
            {
                _shopsList = value;
                OnPropertyChanged();
            }

        }

        public Shop SelectedEmployee
        {
            get { return _selectedShop; }
            set
            {
                _selectedShop = value;
                OnPropertyChanged();
            }
        }

        public Command PostCommand
        {
            get
            {
                return new Command((async () =>
                {
                    var shopsService = new ShopService();
                    await shopsService.PostShopAsync(_selectedShop);
                }));
            }
        }

        public Command RefreshCommand
        {
            get
            {
                return new Command((async () =>
                {
                    var shopsService = new ShopService();
                    ShopsList = await shopsService.GetShopsAsync();
                    Message = $"Total record is {ShopsList.Count}";
                }));
            }
        }

        public Command PutCommand
        {
            get
            {
                return new Command((async () =>
                {
                    var shopsService = new ShopService();
                    await shopsService.PutShopAsync(_selectedShop.ShopId, _selectedShop);
                }));
            }
        }

        public Command DeleteCommand
        {
            get
            {
                return new Command((async () =>
                {
                    var shopsService = new ShopService();
                    await shopsService.DeleteShopAsync(_selectedShop.ShopId, _selectedShop);
                }));
            }
        }

        public Command SearchCommand
        {
            get
            {
                return new Command((async () =>
                {
                    var shopsService = new ShopService();
                    SearchedEmployees = await shopsService.GetShopsByKeyWordAsync(_keyWord);
                }));
            }
        }


        public List<Shop> SearchedEmployees
        {
            get { return _searchedShops; }
            set
            {
                _searchedShops = value;
                OnPropertyChanged();
            }
        }

        public ShopVm()
        {

            InitializeDataAsync();
        }

        private async Task InitializeDataAsync()
        {
            var shopsService = new ShopService();
            ShopsList = await shopsService.GetShopsAsync();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


    }
}

