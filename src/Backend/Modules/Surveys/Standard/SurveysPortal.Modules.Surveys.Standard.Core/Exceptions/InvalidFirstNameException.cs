using SurveysPortal.Modules.Surveys.Standard.Core.ValueObjects;
using SurveysPortal.Shared.Infrastructure.Exceptions;

namespace SurveysPortal.Modules.Surveys.Standard.Core.Exceptions;

public class InvalidFirstNameException : CustomException
{
    public InvalidFirstNameException() : base(null!) {}
    public InvalidFirstNameException(Question question) : base($"First name: '{question}' is invalid.")
    {
        LastName = question;
    }

    public Question LastName { get; }
}