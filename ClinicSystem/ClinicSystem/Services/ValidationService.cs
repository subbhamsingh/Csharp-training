

namespace ClinicSystem.Services
{
 
        public static class ValidationService
    {
            public static bool IsValidText(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
                return false;
            input = input.Trim();
            foreach (char c in input)
            {
                if (!char.IsLetter(c) && c != ' ')
                    return false;

            }
            return true;
        }

            public static bool IsValidChoice(string input)
            {
                if (string.IsNullOrWhiteSpace(input))
                    return false;

                if (input == "1" || input == "2" || input == "3" || input == "4" 
                || input == "5"||input=="6" || input=="7")
                    return true;

                return false;
            }

        public static bool IsValidAge(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
                return false;

            input = input.Trim();

            foreach (char c in input)
            {
                if (!char.IsDigit(c))
                    return false;
            }

            return true;
        }

        public static bool IsValidDate(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
                return false;

            if (DateTime.TryParse(input, out DateTime date))
                return true;

            return false;
        }

    }
    
}
