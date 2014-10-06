using System;
using System.Text;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Security.Cryptography;


namespace BoardHunt.classes
{
    public class hasher
    {

        byte[] hashedBytes;

        //constructor
        public hasher()
        {
            
        }
/*        
*/
        public byte[] getHash(string salt, string pwd)
        {
            string tmpString;
            //byte[] tmpByte1;

            tmpString = salt + pwd;

            UTF8Encoding textConverter = new UTF8Encoding();

            MD5CryptoServiceProvider md5Hasher = new MD5CryptoServiceProvider();
            hashedBytes = md5Hasher.ComputeHash(textConverter.GetBytes(tmpString));

            return hashedBytes;

        }

        // Generate a six-byte salt
        public byte[] GenerateSALT()
        //public string GenerateSALT()
        {
            byte[] data = new byte[6];
            new System.Security.Cryptography.RNGCryptoServiceProvider().GetBytes(data);
            return data;

            //return GenerateRandomString(8).ToLower();
        }

        // Just compare to two arrays for equality
        // You can add a length comparison, but normally
        // all hashes are the same size.
        private bool PasswordsMatch(byte[] psswd1, byte[] psswd2)
        {
            try
            {
                for (int i = 0; i < psswd1.Length; i++)
                {
                    if (psswd1[i] != psswd2[i])
                        return false;
                }
                return true;
            }
            catch (IndexOutOfRangeException)
            {
                return false;
            }
        }

/*
*/
        
        private static string GenerateRandomString(int intLenghtOfString)
        {
            //Create a new StrinBuilder that would hold the random string.
            StringBuilder randomString = new StringBuilder();
            //Create a new instance of the class Random
            Random randomNumber = new Random();
            //Create a variable to hold the generated charater.
            Char appendedChar;
            //Create a loop that would iterate from 0 to the specified value of intLenghtOfString
            for (int i = 0; i <= intLenghtOfString; ++i)
            {
                //Generate the char and assign it to appendedChar
                appendedChar = Convert.ToChar(Convert.ToInt32(26 * randomNumber.NextDouble()) + 65);
                //Append appendedChar to randomString
                randomString.Append(appendedChar);
            }
            //Convert randomString to String and return the result.
            return randomString.ToString();
        }     
    }
}
