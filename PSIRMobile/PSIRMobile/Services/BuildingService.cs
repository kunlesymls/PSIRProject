using PSIRMobile.RestClient;
using PSIRModel;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PSIRMobile.Services
{
    public class BuildingService
    {
        private string ServiceUrl = "http://192.168.0.2/api/employees/";
        private RestClient<Building> restClient;
        public BuildingService()
        {
            restClient = new RestClient<Building>(ServiceUrl);
        }

        public async Task<List<Building>> GetBuildingsAsync()
        {
            var buildingList = await restClient.GetAsync();
            return buildingList;
        }
        public async Task PostBuildingAsync(Building building)
        {
            var buildingList = await restClient.PostAsync(building);
        }
        public async Task PutBuildingAsync(int id, Building building)
        {
            var buildingList = await restClient.PutAsync(id, building);
        }
        public async Task DeleteBuildingAsync(int id, Building building)
        {
            var buildingList = await restClient.DeleteAsync(id, building);
        }

        public async Task<List<Building>> GetBuildingsByKeyWordAsync(string keyWord)
        {
            var buildingList = await restClient.GetByKeyWordAsync(keyWord);
            return buildingList;
        }

    }
}
