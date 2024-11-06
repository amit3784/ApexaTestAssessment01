namespace ApexaTechAssess.Api.Features.AdvisorFeatures.Validations
{
    public static class CommonValidations
    {
        public static bool isValidPhone(string arg)
        {
            return arg.All(char.IsDigit);
        }

        public static  bool isValidSIN(string arg)
        {
            return (arg.All(char.IsDigit));
        }
    }
}
