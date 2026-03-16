namespace RuleBasedAccess.Services
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

            if (input == "1" || input == "2" || input == "3")
                return true;

            return false;
        }

        public static bool IsValidChoiceResource(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
                return false;

            if (input == "1" || input == "2" || input == "3" || input=="4")
                return true;

            return false;
        }
    }
}