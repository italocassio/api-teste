using System;
using System.Collections.Generic;
using System.Linq;

namespace api_auction._Base
{
    public class RuleValidator
    {

        private readonly List<string> pErrorMessages;
        public RuleValidator()
        {
            pErrorMessages = new List<string>();
        }

        public static RuleValidator New()
        {
            return new RuleValidator();
        }

        public RuleValidator When(bool hasError, string sErrorMessage)
        {
            if (hasError)
                pErrorMessages.Add(sErrorMessage);

            return this;
        }

        public void ThrowExceptionIfExists()
        {
            if (pErrorMessages.Any())
                throw new DomainException(pErrorMessages);
        }
    }

    public class DomainException : ArgumentException
    {
        public List<string> ErrorMessages;
        public DomainException(List<string> errorMessages)
        {
            ErrorMessages = errorMessages;
        }
    }
}