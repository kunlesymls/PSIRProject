using PSIRMobile.RestClient;
using PSIRModel;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PSIRMobile.Services
{
    public class AvailbaleOptionService
    {
        private string ServiceUrl = "http://192.168.0.2/api/employees/";
        private RestClient<AvailableOption> restClient;
        public AvailbaleOptionService()
        {
            restClient = new RestClient<AvailableOption>(ServiceUrl);
        }

        public async Task<List<AvailableOption>> GetAvailableOptionsAsync()
        {
            var availableOptionList = await restClient.GetAsync();
            return availableOptionList;
        }
        public async Task PostAvailableOptionAsync(AvailableOption availableOption)
        {
            var availableOptionList = await restClient.PostAsync(availableOption);
        }
        public async Task PutAvailableOptionAsync(int id, AvailableOption availableOption)
        {
            var availableOptionList = await restClient.PutAsync(id, availableOption);
        }
        public async Task DeleteAvailableOptionAsync(int id, AvailableOption availableOption)
        {
            var availableOptionList = await restClient.DeleteAsync(id, availableOption);
        }

        public async Task<List<AvailableOption>> GetAvailableOptionByKeyWordAsync(string keyWord)
        {
            var availableOptionList = await restClient.GetByKeyWordAsync(keyWord);
            return availableOptionList;
        }
    }
}
