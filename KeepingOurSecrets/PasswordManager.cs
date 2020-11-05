using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace KeepingOurSecrets
{
    class PasswordManager
    {
        public User User => new User
        {
            Username = "lars",
            PasswordHash = "tgou8mc1JHaoBjLj/UuzWU5mGC4CSdeBNov3vWFTG27vQgCcAx8VAV1e7wJawG6e8LIA8twYgKYqC4eL5qZycg==",
            Salt = "qOxbQLEUHrDSBeW/aiOLPPHsnHRWjZpnW+esJF9fBsKocmEztQMo40l9i1F3wMXwGN6q6ungezghArxYcQM38LTzIkAhu3xKG+wg1qudsnlvevouq4bZuIUVTM6AsLSFzc1aH+UJM6f5YYK19tmCVlU56VftvY0ag5gy+OL+Ijd7I1VNKv+GrmTd8h/bx3bjXYfVtJie/E5PmWBx/aLQPH7AXgqEb91NmRUdtVzM3YtStu5INt1y+oA0QbL9tV+yqYoSxfM1zq24A/K8aMh3AoQawpMf/j2nT/BwVbu9CNHEDRYL7ydJ0nUE2Zb8n0T6iDSkULzescUmFWzF0zUQYA=="
        };

        /// <summary>
        /// Authenticates a user login attempt
        /// </summary>
        /// <returns>A value indicating if the user is authenticated or not</returns>
        public bool Authenticate(string username, string password)
        {
            // hashes the password after adding the salt and return true, if the two values compare
            HashAlgorithm hashAlgorithm = SHA512.Create();
            var passwordHash = Convert.ToBase64String(hashAlgorithm.ComputeHash(Encoding.UTF8.GetBytes(User.Salt + password)));

            return passwordHash == User.PasswordHash;
        }
    }

    struct User
    {
        public string Username { get; set; }
        public string PasswordHash { get; set; }
        public string Salt { get; set; }
    }
}
