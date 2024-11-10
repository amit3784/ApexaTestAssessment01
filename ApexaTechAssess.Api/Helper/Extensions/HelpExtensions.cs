namespace ApexaTechAssess.Api.Helper.Extensions
{
    /// <summary>
    /// This extension class is used for extension methods.
    /// </summary>
    public static class HelpExtensions
    {
        /// <summary>
        /// this extension method is used to mask the string values.
        /// </summary>
        public static string MaskedValue(this string rawvalue)
        {
            //Partial masking
            //string maskedSubstr=rawvalue.Substring(0,rawvalue.Length-4);
            //string maskedandReplaceValue = rawvalue.Replace(maskedSubstr, new string('*',maskedSubstr.Length));


            //Complete masking
            string maskedandReplaceValue = new string('*', rawvalue.Length);
            return maskedandReplaceValue;
        }
    }
}
