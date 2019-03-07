using MySql.Data.MySqlClient;
using CarRent.Api.ContractManagement;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Threading.Tasks;
using CarRent.Api.ContractManagement.BusinessLogic;
using Contract = CarRent.Api.ContractManagement.BusinessLogic.Contract;

namespace CarRent.Api.ContractManagement.Persistence
{
    public class MySqlContractRepository : IContractRepository
    {
        private MySqlConnection _mySqlConnection;
        
        int contract_id;
        string state;
        int customer_id;
        int carclass_id;
        string startdate;
        string enddate;
        string contractdate;
        decimal totalamount;

        public MySqlContractRepository(string connectionString)
        {
            _mySqlConnection = new MySqlConnection(connectionString);
        }
        public IReadOnlyList<Contract> GetAll()
        {
            List<Contract> contractlist = new List<Contract>();
            _mySqlConnection.Open();
            using (_mySqlConnection.BeginTransaction())
            {
                var command = _mySqlConnection.CreateCommand();
                command.CommandText = "SELECT * FROM Contract;";
                var reader = command.ExecuteReader();
                object[] dataRow = new object[reader.FieldCount];
                while (reader.Read())
                {
                    int cols = reader.GetValues(dataRow);
                    for (int i = 0; i < cols; i++)
                    {
                        contract_id = (int)Convert.ToInt32(reader[0]);
                        state = reader[1].ToString();
                        customer_id = Convert.ToInt32(reader[2]);
                        carclass_id = Convert.ToInt32(reader[3]);
                        startdate = reader[4].ToString();
                        enddate = reader[5].ToString();
                        contractdate = reader[6].ToString();
                        totalamount = Convert.ToDecimal(reader[7]);
                    }
                    Contract c = new Contract(contract_id, state, customer_id, carclass_id, startdate, enddate, contractdate, totalamount); 
                    contractlist.Add(c);
                }
                reader.Close();
                IReadOnlyList<Contract> readcontractlist = contractlist;
                return readcontractlist;
            }

        }


        public void WriteContract(Contract contract)
        {
            _mySqlConnection.Open();

            var command = _mySqlConnection.CreateCommand();
            command.CommandText = "INSERT INTO Contract (state, fk_customer_id, fk_carclass_id, startdate, enddate, contractdate, totalamount) VALUES ('" + contract.State + "', '" + contract.Customer_id + "', '" + contract.Carclass_id + "', '" + contract.Startdate + "', " + contract.Enddate + " '" + contract.Contractdate + "', '" + contract.Totalamount + ")";
            command.ExecuteNonQuery();
            _mySqlConnection.Close();
        }

     
        public void UpdateContract(Contract contract)
        {
            _mySqlConnection.Open();

            var command = _mySqlConnection.CreateCommand();

            command.CommandText = "UPDATE contract SET state = '" + contract.State + "' WHERE contract_id = " + contract.Contract_id + ";";
            command.ExecuteNonQuery();
            command.CommandText = "UPDATE contract SET fk_customer_id = '" + contract.Customer_id + "' WHERE contract_id = " + contract.Contract_id + ";";
            command.ExecuteNonQuery();
            command.CommandText = "UPDATE contract SET fk_carclass_id = '" + contract.Carclass_id + "' WHERE contract_id = " + contract.Contract_id + ";";
            command.ExecuteNonQuery();
            command.CommandText = "UPDATE contract SET startdate = '" + contract.Startdate + "' WHERE contract_id = " + contract.Contract_id + ";";
            command.ExecuteNonQuery();
            command.CommandText = "UPDATE contract SET enddate = '" + contract.Enddate + "' WHERE contract_id = " + contract.Contract_id + ";";
            command.ExecuteNonQuery();
            command.CommandText = "UPDATE contract SET contractdate = '" + contract.Contractdate + "' WHERE contract_id = " + contract.Contract_id + ";";
            command.ExecuteNonQuery();
            command.CommandText = "UPDATE contract SET totalamount = '" + contract.Totalamount + "' WHERE contract_id = " + contract.Contract_id + ";";
            command.ExecuteNonQuery();

            _mySqlConnection.Close();
        }

        public void DeleteContract(int id)
        {
            _mySqlConnection.Open();

            var command = _mySqlConnection.CreateCommand();
            command.CommandText = "DELETE FROM contract WHERE contract_id = " + id + ";";
            command.ExecuteNonQuery();
            _mySqlConnection.Close();
        }


    }
}

