using PSIRMobile.RestClient;
using PSIRModel;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PSIRMobile.Services
{
    public class ShopService
    {
        private string ServiceUrl = "http://192.168.0.2/api/employees/";
        private RestClient<Shop> restClient;
        public ShopService()
        {
            restClient = new RestClient<Shop>(ServiceUrl);
        }

        public async Task<List<Shop>> GetShopsAsync()
        {
            var shopList = await restClient.GetAsync();
            return shopList;
        }
        public async Task PostShopAsync(Shop shop)
        {
            var shopList = await restClient.PostAsync(shop);
        }
        public async Task PutShopAsync(int id, Shop shop)
        {
            var shopList = await restClient.PutAsync(id, shop);
        }
        public async Task DeleteShopAsync(int id, Shop shop)
        {
            var shopList = await restClient.DeleteAsync(id, shop);
        }

        public async Task<List<Shop>> GetShopsByKeyWordAsync(string keyWord)
        {
            var shopList = await restClient.GetByKeyWordAsync(keyWord);
            return shopList;
        }
    }
}
