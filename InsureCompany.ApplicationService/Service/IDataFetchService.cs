using InsureCompany.DomainModel.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsureCompany.ApplicationService.Service
{
    public interface IDataFetchService
    {
        Task<IEnumerable<Client>> FetchClientsFromApiAsync();
        Task<IEnumerable<Policy>> FetchPoliciesFromApiAsync();
    }
}
