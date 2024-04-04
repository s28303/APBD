using System;

namespace LegacyApp
{
    public class UserService
    {
        private readonly ClientRepository _clientRepository = new();
        private readonly UserCreditService _creditLimitService = new();

        public bool AddUser(string firstName, string lastName, string email, DateTime dateOfBirth, int clientId)
        {
            if (!IsValidInput(firstName, lastName, email, dateOfBirth)) 
                return false;

            var client = _clientRepository.GetById(clientId);
            var user = CreateUser(firstName, lastName, email, dateOfBirth, client);

            
            if (!IsUserEligible(user)) 
                return false;

            
            UserDataAccess.AddUser(user); 
            
            return true;
        }

        
        private bool IsValidInput(string firstName, string lastName, string email, DateTime dateOfBirth)
        {
            if (string.IsNullOrEmpty(firstName) || string.IsNullOrEmpty(lastName))
                return false;

            if (!email.Contains('@') && !email.Contains('.')) 
                return false;
            
            
            var now = DateTime.Now;
            int age = now.Year - dateOfBirth.Year;
            if (now.Month < dateOfBirth.Month || (now.Month == dateOfBirth.Month && now.Day < dateOfBirth.Day)) age--;

            return age >= 21;
        }

        
        private User CreateUser(string firstName, string lastName, string email, DateTime dateOfBirth, Client client)
        {
            var user = new User
            {
                Client = client,
                DateOfBirth = dateOfBirth,
                EmailAddress = email,
                FirstName = firstName,
                LastName = lastName
            };

            
            SetCreditLimit(user, client);
            
            return user;
        }

        private void SetCreditLimit(User user, Client client)
        {
            if (client.Type == "VeryImportantClient")
            {
                user.HasCreditLimit = false;
            }
            else if (client.Type == "ImportantClient") {
                int creditLimit = _creditLimitService.GetCreditLimit(user.LastName);
                creditLimit *= 2;
                user.CreditLimit = creditLimit;
            }
            else
            {
                user.HasCreditLimit = true;
                int creditLimit = _creditLimitService.GetCreditLimit(user.LastName);
                user.CreditLimit = creditLimit;
            }
        }

        private bool IsUserEligible(User user)
        {
            return !user.HasCreditLimit || user.CreditLimit >= 500;
        }
    }
}
