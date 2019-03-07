using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarRent.Api.ContractManagement.BusinessLogic
{
    public interface IContractService
    {
        IReadOnlyList<Contract> GetAll();
        void WriteContract(Contract contract);
        void UpdateContract(Contract contract);
        void DeleteContract(int id);
    }
}
