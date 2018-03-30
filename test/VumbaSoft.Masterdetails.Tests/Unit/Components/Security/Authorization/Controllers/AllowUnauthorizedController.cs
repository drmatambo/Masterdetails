using VumbaSoft.Masterdetails.Components.Security;
using System.Diagnostics.CodeAnalysis;

namespace VumbaSoft.Masterdetails.Tests.Unit.Components.Security
{
    [AllowUnauthorized]
    [ExcludeFromCodeCoverage]
    public class AllowUnauthorizedController : AuthorizedController
    {
    }
}
