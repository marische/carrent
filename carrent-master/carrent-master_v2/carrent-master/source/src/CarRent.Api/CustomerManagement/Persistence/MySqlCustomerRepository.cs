using CarRent.Api.CustomerManagement.BusinessLogic;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

namespace CarRent.Api.CustomerManagement.Persistence
{
    public class MySqlCustomerRepository : ICustomerRepository
    {
        private MySqlConnection _mySqlConnection;

        int customer_id;
        string firstname;
        string surname;
        string street;
        string zip;
        string town;
        string country;
        string phone;
        string mail;
        string birthdate;

        public MySqlCustomerRepository(string connectionString)
        {
            _mySqlConnection = new MySqlConnection(connectionString);
        }
        public IReadOnlyList<Customer> GetAll()
        {
            List<Customer> customerlist = new List<Customer>();
            _mySqlConnection.Open();
            using (_mySqlConnection.BeginTransaction())
            {
                var command = _mySqlConnection.CreateCommand();
                command.CommandText = "SELECT * FROM Customer;";
                var reader = command.ExecuteReader();
                object[] dataRow = new object[reader.FieldCount];
                while (reader.Read())
                {
                    int cols = reader.GetValues(dataRow);
                    for (int i = 0; i < cols; i++)
                    {
                        customer_id = (int)Convert.ToInt32(reader[0]);
                        firstname = reader[1].ToString();
                        surname = reader[2].ToString();
                        street = reader[3].ToString();
                        zip = reader[4].ToString();
                        town = reader[5].ToString();
                        country = reader[6].ToString();
                        phone = reader[7].ToString();
                        mail = reader[8].ToString();
                        birthdate = reader[9].ToString();
                                               
                    }
                    Customer c = new Customer(customer_id, firstname, surname, street, zip, town, country, phone, mail, birthdate); 
                    customerlist.Add(c);
                }
                reader.Close();
                IReadOnlyList<Customer> readcustomerlist = customerlist;
                return readcustomerlist;
                               
            }

        }


        public void PostCustomer(Customer customer)
        {
            _mySqlConnection.Open();

            var command = _mySqlConnection.CreateCommand();
            command.CommandText = "INSERT INTO Customer (firstname, surname, street, zip, town, country, phone, mail, birthdate) VALUES ('" + customer.Firstname + "', '" + customer.Surname + "', '" + customer.Street + "', " + customer.Zip + "', " + customer.Town + "', " + customer.Country + "', " + customer.Phone + "', " + customer.Mail + "', " + customer.Birthdate + ")";
            command.ExecuteNonQuery();
            _mySqlConnection.Close();
        }

        //todo: Allgemeiner Push für alle Attribute schreiben.
        public void UpdateCustomer(Customer customer)
        {
            _mySqlConnection.Open();

            var command = _mySqlConnection.CreateCommand();
            //command.CommandText = "UPDATE Customer SET xxxxxx WHERE customer_id = " + customer.Customer_id + ";";
            command.ExecuteNonQuery();
            _mySqlConnection.Close();
        }

        public void DeleteCustomer(int id)
        {
            _mySqlConnection.Open();

            var command = _mySqlConnection.CreateCommand();
            command.CommandText = "DELETE FROM Customer WHERE customer_id = " + id + ";";
            command.ExecuteNonQuery();
            _mySqlConnection.Close();
        }


    }
}
