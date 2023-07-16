using InsureCompany.DomainModel.Entities;
using Microsoft.Identity.Client;
using Newtonsoft.Json;
using Serilog;


namespace InsureCompany.ApplicationService.Service
{
    public class DataFetchService : IDataFetchService
    {
        private static readonly HttpClient HttpClient = new HttpClient();
        private const string ClientsApiUrl = "http://www.mocky.io/v2/5808862710000087232b75ac";
        private const string PoliciesApiUrl = "http://www.mocky.io/v2/580891a4100000e8242b75c5";

        public async Task<IEnumerable<Client>> FetchClientsFromApiAsync()
        {
            try
            {
                var response = await HttpClient.GetStringAsync(ClientsApiUrl);
                var clientData = JsonConvert.DeserializeObject<ClientData>(response);
                return clientData.Clients;
            }
            catch (Exception ex)
            {
                Log.Error($"An error occurred while fetching clients: {ex.Message}");
                return Enumerable.Empty<Client>();
            }
        }

        public async Task<IEnumerable<Policy>> FetchPoliciesFromApiAsync()
        {
            try
            {
                var response = await HttpClient.GetStringAsync(PoliciesApiUrl);
                var policyData = JsonConvert.DeserializeObject<PolicyData>(response);
                return policyData.Policies;
            }
            catch (Exception ex)
            {
                Log.Error($"An error occurred while fetching policies: {ex.Message}");
                return Enumerable.Empty<Policy>();
            }
        }
    }

    public class ClientData
    {
        public List<Client> Clients { get; set; }
    }

    public class PolicyData
    {
        public List<Policy> Policies { get; set; }
    }
}
