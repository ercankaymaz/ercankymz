using System.Security.Principal;

namespace System.IdentityModel.Policy;

internal interface IIdentityInfo
{
	IIdentity Identity { get; }
}
