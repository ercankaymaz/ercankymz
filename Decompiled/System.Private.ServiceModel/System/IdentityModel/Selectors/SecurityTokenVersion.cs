using System.Collections.ObjectModel;

namespace System.IdentityModel.Selectors;

public abstract class SecurityTokenVersion
{
	public abstract ReadOnlyCollection<string> GetSecuritySpecifications();
}
