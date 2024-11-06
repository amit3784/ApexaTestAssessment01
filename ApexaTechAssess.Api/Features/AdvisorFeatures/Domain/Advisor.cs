using System.ComponentModel.DataAnnotations;

namespace ApexaTechAssess.Api.Features.AdvisorFeatures.Domain
{
    public class Advisor
    {
        public int Id { get; set; }

        public required string FullName { get; set; }

        private string _sin;
        public required string SIN
        {   get
            {
                return MaskedValue(_sin);
            }
            set
            {
                _sin = value;
            }
        }

       

        public string Address { get; set; } = string.Empty;

        private string _phoneNumber=string.Empty;
        public string PhoneNumber
        {
            get
            {
                return MaskedValue(_phoneNumber);
            }
            set
            {
                _phoneNumber = value;
            }
        }

        private WellnessStatus _wellnessStatus;
        public WellnessStatus HealthStatus
        {
            get
            {
                return _wellnessStatus;
            }
            set
            {
                _wellnessStatus = GetRandomWellnessStatus();
            }
        }

        private string MaskedValue(string rawvalue)
        {
            //Partial masking
            //string maskedSubstr=rawvalue.Substring(0,rawvalue.Length-4);
            //string maskedandReplaceValue = rawvalue.Replace(maskedSubstr, new string('*',maskedSubstr.Length));


            //Complete masking
            string maskedandReplaceValue =new string('*',rawvalue.Length);
            return  maskedandReplaceValue;
        }

        private WellnessStatus GetRandomWellnessStatus()
        {
            double randomVal = Random.Shared.NextDouble();

            if (randomVal >= 0.0f && randomVal <= 0.6f)
            {
                return WellnessStatus.Green;
            }
            if (randomVal > 0.6f && randomVal <= 0.8f)
            {
                return WellnessStatus.Yellow;
            }
            else
            {
                return WellnessStatus.Red;
            }

        }
    }
}
