using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Hashing
{
    class PasswordManager
    {
        static List<User> users = new List<User>();
        
        /// <summary>
        /// Creates a user and stores it in memory
        /// </summary>
        public void Save(string username, string password)
        {
            // Creating a random number generator to generate a salt
            var rngCSP = RNGCryptoServiceProvider.Create();

            // Creates a salt
            byte[] random = new byte[256];
            rngCSP.GetNonZeroBytes(random);
            string salt = Convert.ToBase64String(random);

            // Adding the salt to the password and hashes it with the SHA512 algorithm
            HashAlgorithm hashAlgorithm = SHA512.Create();
            var passwordHash = Convert.ToBase64String(hashAlgorithm.ComputeHash(Encoding.UTF8.GetBytes(salt + password)));

            if (users.Any(u=>u.Username == username))
            {
                throw new Exception("Username already exists!");
            }
            users.Add(new User { Username = username, Salt = salt, PasswordHash = passwordHash });
        }

        /// <summary>
        /// Authenticates a user login attempt
        /// </summary>
        /// <returns>A value indicating if the user is authenticated or not</returns>
        public bool Authenticate(string username, string password)
        {
            var user = users.SingleOrDefault(u => u.Username == username);

            if (user.IsValid)
            {
                // hashes the password after adding the salt and return true, if the two values compare
                HashAlgorithm hashAlgorithm = SHA512.Create();
                var passwordHash = Convert.ToBase64String(hashAlgorithm.ComputeHash(Encoding.UTF8.GetBytes(user.Salt + password)));

                return passwordHash == user.PasswordHash;
            }

            return false;
        }
    }

    
    struct User
    {
        public string Username { get; set; }
        public string PasswordHash { get; set; }
        public string Salt { get; set; }

        /// <summary>
        /// Gets a value indicating if the user is valid or not
        /// </summary>
        public bool IsValid { get { return Username != null; } }
    }
}
