using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarRent.Api.ContractManagement.BusinessLogic
{
    internal class ContractService : IContractService
    {
        private readonly IContractRepository contractRepository;

        public ContractService(IContractRepository contractRepository)
        {
            this.contractRepository = contractRepository;
        }

        public IReadOnlyList<Contract> GetAll()
        {
            return contractRepository.GetAll();
        }

        public void WriteContract(Contract contract)
        {
            contractRepository.WriteContract(contract);
        }

        public void UpdateContract(Contract contract)
        {
            contractRepository.UpdateContract(contract);
        }

        public void DeleteContract(int id)
        {
            contractRepository.DeleteContract(id);
        }
    }
}
