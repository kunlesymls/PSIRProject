using PSIRMobile.RestClient;
using PSIRModel;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PSIRMobile.Services
{
    public class EnumerationService
    {
        private string ServiceUrl = "http://192.168.0.2/api/employees/";
        private RestClient<BuildingEnumeration> restClient;
        public EnumerationService()
        {
            restClient = new RestClient<BuildingEnumeration>(ServiceUrl);
        }

        public async Task<List<BuildingEnumeration>> GetBuildingEnumerationsAsync()
        {
            var buildingEnumerationList = await restClient.GetAsync();
            return buildingEnumerationList;
        }
        public async Task PostBuildingEnumerationAsync(BuildingEnumeration buildingEnumeration)
        {
            var buildingEnumerationList = await restClient.PostAsync(buildingEnumeration);
        }
        public async Task PutBuildingEnumerationAsync(int id, BuildingEnumeration buildingEnumeration)
        {
            var buildingEnumerationList = await restClient.PutAsync(id, buildingEnumeration);
        }
        public async Task DeleteBuildingEnumerationAsync(int id, BuildingEnumeration buildingEnumeration)
        {
            var buildingEnumerationList = await restClient.DeleteAsync(id, buildingEnumeration);
        }

        public async Task<List<BuildingEnumeration>> GetBuildingEnumerationByKeyWordAsync(string keyWord)
        {
            var buildingEnumerationList = await restClient.GetByKeyWordAsync(keyWord);
            return buildingEnumerationList;
        }
    }
}
