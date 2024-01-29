using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;

namespace LockBox
{
    [Serializable]
    public class Account
    {
        public string Email { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
    }
    internal class accounts
    {
        private List<List<Account>> _accounts;

        public accounts()
        {
            _accounts = new List<List<Account>>();
        }

        public void AddAccount(Account account)
        {
            _accounts.Add(new List<Account> { account });
        }

        public List<Account> GetAccounts()
        {
            return _accounts.SelectMany(row => row).ToList();
        }

        public void SaveAccounts(string filePath)
        {
            try
            {
                // Serialize the 2D accounts list and save it to a file
                using (FileStream fs = new FileStream(filePath, FileMode.Create))
                {
                    IFormatter formatter = new BinaryFormatter();
                    formatter.Serialize(fs, _accounts);
                }
            }
            catch (Exception ex)
            {
                // Handle exceptions appropriately (e.g., log, display an error message)
                Console.WriteLine($"Error saving accounts: {ex.Message}");
            }
        }

        public void LoadAccounts(string filePath)
        {
            try
            {
                // Deserialize the 2D accounts list from the file
                using (FileStream fs = new FileStream(filePath, FileMode.Open))
                {
                    IFormatter formatter = new BinaryFormatter();
                    _accounts = (List<List<Account>>)formatter.Deserialize(fs);
                }
            }
            catch (Exception ex)
            {
                // Handle exceptions appropriately (e.g., log, display an error message)
                Console.WriteLine($"Error loading accounts: {ex.Message}");
            }
        }
    }

}
