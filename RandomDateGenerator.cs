namespace Level_Up_Project
{
    public class RandomDateGenerator
    {
       
        private static Random random = new Random();
    
        public static string GenerateRandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        public static string GenerateRandomFirstName()
        {
            return GenerateRandomString(random.Next(5, 10));
        }

        public static string GenerateRandomLastName()
        {
            return GenerateRandomString(random.Next(5, 10));
        }

        public static string GenerateRandomEmail()
        {
            string firstName = GenerateRandomFirstName().ToLower();
            string lastName = GenerateRandomLastName().ToLower();
            string domain = "random.com"; 

            return $"{firstName}.{lastName}@{domain}";
        }

        public static string GenerateRandomPassword(int length = 8)
        {
            const string uppercaseChars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            const string lowercaseChars = "abcdefghijklmnopqrstuvwxyz";
            const string numberChars = "0123456789";
            const string symbolChars = "!@#$%^&*()-=_+[]{}|;:'\",.<>?/";

            string allChars = uppercaseChars + lowercaseChars + numberChars + symbolChars;

            Random random = new Random();

            return new string(Enumerable.Repeat(allChars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }
}
