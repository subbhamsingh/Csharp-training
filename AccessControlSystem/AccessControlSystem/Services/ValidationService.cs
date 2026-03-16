namespace AccessControlSystem.Services
{
    public static class ValidationService
    {
       
        //public static bool IsValidText(string input)
        //{
        //    if (string.IsNullOrWhiteSpace(input))
        //        return false;

        //    input = input.Trim();

        //    foreach (char c in input)
        //    {
        //        if (!char.IsLetter(c) && c != ' ')
        //            return false;
            

        //    return true;
        //}

        public static bool IsValidText(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
                return false;
            input = input.Trim();
            foreach(char c in input)
            {
                if (!char.IsLetter(c) && c != ' ')
                    return false;

            }
            return true;
        }

      

        //public static bool IsValidChoice(string input, int maxOption)
        //{
        //    if (string.IsNullOrWhiteSpace(input))
        //        return false;

        //    if (!int.TryParse(input, out int value))
        //        return false;

        //    if (value < 1 || value > maxOption)
        //        return false;

        //    return true;
        //}

        public static bool IsValidChoice(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
                return false;

            if (input == "1" || input == "2" || input == "3")
                return true;

            return true;
        }
    }
}