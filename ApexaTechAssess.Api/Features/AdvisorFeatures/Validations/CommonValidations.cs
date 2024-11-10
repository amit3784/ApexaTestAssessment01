namespace ApexaTechAssess.Api.Features.AdvisorFeatures.Validations
{
    /// <summary>
    /// this class is used to handle common validations for the input fields.
    /// </summary>
    public static class CommonValidations
    {
        /// <summary>
        /// this method is used to validate if the phone number is valid and contains only digits.
        /// </summary>
        /// <param name="arg"></param>
        /// <returns>true/false</returns>
        public static bool isValidPhone(string arg)
        {
            return arg.All(char.IsDigit);
        }

        /// <summary>
        /// this method is used to validate if the sin number is valid and contains only digits.
        /// </summary>
        /// <param name="arg"></param>
        /// <returns>true/false</returns>
        public static  bool isValidSIN(string arg)
        {
            return (arg.All(char.IsDigit));
        }
    }
}
