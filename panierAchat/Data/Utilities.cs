using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace panierAchat.Data
{
    public class Utilities
    {
        public static bool IsPwdValid(string storedPwd, string pwd)// throws IOException
        {

            bool isValue = false;

           // string storedPwd = CredentialsDAO.getPasswordByUsername(user);

            string unscrambledPwd = UnscramblePwd(storedPwd);

            if (unscrambledPwd.Equals(pwd))
            {
                isValue = true;
            }

            return isValue;
        }

        public static string ScramblePwd(string pwd)
        {

            StringBuilder newPwd = new StringBuilder();
            char str;
            int ascii, count = 1;

            foreach(char character in pwd)
            {
                ascii = Convert.ToByte(character) + count;
                str = (char)ascii;
                newPwd.Append(str.ToString());
                count++;
            }

            return newPwd.ToString();
        }

        public static string UnscramblePwd(string pwd)
        {

            StringBuilder newPwd = new StringBuilder();
            char str;
            int ascii, count = 1;

            foreach (char character in pwd)
            {
                ascii = Convert.ToByte(character) - count;
                str = (char)ascii;
                newPwd.Append(str.ToString());
                count--;
            }

            return newPwd.ToString();
        }

        public static bool ValidateCreditCardNumber(string str)
        {
            //// check whether input string is null or empty
            if (string.IsNullOrEmpty(str))
            {
                return false;
            }

            //// 1.	Starting with the check digit double the value of every other digit 
            //// 2.	If doubling of a number results in a two digits number, add up
            ///   the digits to get a single digit number. This will results in eight single digit numbers                    
            //// 3. Get the sum of the digits
            int sumOfDigits = str.Where((e) => e >= '0' && e <= '9')
                            .Reverse()
                            .Select((e, i) => ((int)e - 48) * (i % 2 == 0 ? 1 : 2))
                            .Sum((e) => e / 10 + e % 10);


            //// If the final sum is divisible by 10, then the credit card number
            //   is valid. If it is not divisible by 10, the number is invalid.            
            return sumOfDigits % 10 == 0;

        }
    }
}
