using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalMenu.Tests
{
    public class TestUtil
    {
        public static string GenerateRandomText(int length)
        {
            var random = new Random();
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            char[] randomText = new char[length];

            for (int i = 0; i < length; i++)
            {
                randomText[i] = chars[random.Next(chars.Length)];
            }

            return new string(randomText);
        }
    }
}
