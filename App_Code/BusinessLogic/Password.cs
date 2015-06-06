using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

/// <summary>
/// Summary description for Password
/// </summary>
/// 

namespace BusinessLogic
{
    public static class Password
    {
        const int PASSWORD_LENGTH = 8;
        const string LOWER_CASE_CHARS = "abcdefghijklmnopqrstuvwxyz";
        const string UPPER_CASE_CHARS = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        const string NUMERIC_CHARS = "0123456789";

        public static string GeneratePassword()
        {
            string ResultPassword = string.Empty;
            Random rnd = new Random();
            string charSet = string.Empty;
            int index = 0;

            for (int i = 0; i < PASSWORD_LENGTH; i++)
            {
                int n = rnd.Next(0, 3);

                switch (n)
                {
                    case 0:
                        charSet = LOWER_CASE_CHARS;
                        break;
                    case 1:
                        charSet = UPPER_CASE_CHARS;
                        break;
                    case 2:
                        charSet = NUMERIC_CHARS;
                        break;
                    default:
                        break;
                }

                index = rnd.Next(0, charSet.Length);
                ResultPassword += charSet[index];
            }

            int lowerCaseIndex = rnd.Next(0, ResultPassword.Length);
            index = rnd.Next(0, LOWER_CASE_CHARS.Length);
            ResultPassword = ResultPassword.Remove(lowerCaseIndex, 1);
            ResultPassword = ResultPassword.Insert(lowerCaseIndex, LOWER_CASE_CHARS[index].ToString());

            int upperCaseIndex = rnd.Next(0, ResultPassword.Length);
            while (upperCaseIndex == lowerCaseIndex)
            {
                upperCaseIndex = rnd.Next(0, ResultPassword.Length);
            }

            index = rnd.Next(0, UPPER_CASE_CHARS.Length);
            ResultPassword = ResultPassword.Remove(upperCaseIndex, 1);
            ResultPassword = ResultPassword.Insert(upperCaseIndex, UPPER_CASE_CHARS[index].ToString());

            int numericIndex = rnd.Next(0, ResultPassword.Length);
            while (numericIndex == lowerCaseIndex || numericIndex == upperCaseIndex)
            {
                numericIndex = rnd.Next(0, ResultPassword.Length);
            }

            index = rnd.Next(0, NUMERIC_CHARS.Length);
            ResultPassword = ResultPassword.Remove(numericIndex, 1);
            ResultPassword = ResultPassword.Insert(numericIndex, NUMERIC_CHARS[index].ToString());

            return ResultPassword;
        }

        public static bool ValidatePassword(string password)
        {
            if (password.Length == PASSWORD_LENGTH && password.Any(char.IsLower)
                && password.Any(char.IsUpper) && password.Any(char.IsDigit))
            {
                return true;
            }
            return false;
        }

        public static string Encrypt(string plainText, string hashAlgorithm, byte[] saltBytes)
        {
            // If salt is not specified, generate it.
            if (saltBytes == null)
            {
                // Define min and max salt sizes.
                int minSaltSize = 4;
                int maxSaltSize = 8;

                // Generate a random number for the size of the salt.
                Random random = new Random();
                int saltSize = random.Next(minSaltSize, maxSaltSize);

                // Allocate a byte array, which will hold the salt.
                saltBytes = new byte[saltSize];

                // Initialize a random number generator.
                RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();

                // Fill the salt with cryptographically strong byte values.
                rng.GetNonZeroBytes(saltBytes);
            }

            // Convert plain text into a byte array.
            byte[] plainTextBytes = Encoding.UTF8.GetBytes(plainText);

            // Allocate array, which will hold plain text and salt.
            byte[] plainTextWithSaltBytes =
            new byte[plainTextBytes.Length + saltBytes.Length];

            // Copy plain text bytes into resulting array.
            for (int i = 0; i < plainTextBytes.Length; i++)
                plainTextWithSaltBytes[i] = plainTextBytes[i];

            // Append salt bytes to the resulting array.
            for (int i = 0; i < saltBytes.Length; i++)
                plainTextWithSaltBytes[plainTextBytes.Length + i] = saltBytes[i];

            HashAlgorithm hash;

            // Make sure hashing algorithm name is specified.
            if (hashAlgorithm == null)
                hashAlgorithm = "";

            // Initialize appropriate hashing algorithm class.
            switch (hashAlgorithm.ToUpper())
            {

                case "SHA384":
                    hash = new SHA384Managed();
                    break;

                case "SHA512":
                    hash = new SHA512Managed();
                    break;

                default:
                    hash = new MD5CryptoServiceProvider();
                    break;
            }

            // Compute hash value of our plain text with appended salt.
            byte[] hashBytes = hash.ComputeHash(plainTextWithSaltBytes);

            // Create array which will hold hash and original salt bytes.
            byte[] hashWithSaltBytes = new byte[hashBytes.Length +
            saltBytes.Length];

            // Copy hash bytes into resulting array.
            for (int i = 0; i < hashBytes.Length; i++)
                hashWithSaltBytes[i] = hashBytes[i];

            // Append salt bytes to the result.
            for (int i = 0; i < saltBytes.Length; i++)
                hashWithSaltBytes[hashBytes.Length + i] = saltBytes[i];

            // Convert result into a base64-encoded string.
            string hashValue = Convert.ToBase64String(hashWithSaltBytes);

            // Return the result.
            return hashValue;
        }

        public static bool Verify(string plainText, string hashAlgorithm, string hashValue)
        {

            // Convert base64-encoded hash value into a byte array.
            byte[] hashWithSaltBytes = Convert.FromBase64String(hashValue);

            // We must know size of hash (without salt).
            int hashSizeInBits, hashSizeInBytes;

            // Make sure that hashing algorithm name is specified.
            if (hashAlgorithm == null)
                hashAlgorithm = "";

            // Size of hash is based on the specified algorithm.
            switch (hashAlgorithm.ToUpper())
            {

                case "SHA384":
                    hashSizeInBits = 384;
                    break;

                case "SHA512":
                    hashSizeInBits = 512;
                    break;

                default: // Must be MD5
                    hashSizeInBits = 128;
                    break;
            }

            // Convert size of hash from bits to bytes.
            hashSizeInBytes = hashSizeInBits / 8;

            // Make sure that the specified hash value is long enough.
            if (hashWithSaltBytes.Length < hashSizeInBytes)
                return false;

            // Allocate array to hold original salt bytes retrieved from hash.
            byte[] saltBytes = new byte[hashWithSaltBytes.Length - hashSizeInBytes];

            // Copy salt from the end of the hash to the new array.
            for (int i = 0; i < saltBytes.Length; i++)
                saltBytes[i] = hashWithSaltBytes[hashSizeInBytes + i];

            // Compute a new hash string.
            string expectedHashString = Encrypt(plainText, hashAlgorithm, saltBytes);

            // If the computed hash matches the specified hash,
            // the plain text value must be correct.
            return (hashValue == expectedHashString);
        }
    }
}