using System.Security.Principal;

namespace System.ServiceModel.Security.Tokens;

internal class WindowsSidIdentity : IIdentity
{
	private string _name;

	public SecurityIdentifier SecurityIdentifier { get; }

	public string AuthenticationType { get; }

	public bool IsAuthenticated => true;

	public string Name
	{
		get
		{
			//IL_001e: Unknown result type (might be due to invalid IL or missing references)
			if (_name == null)
			{
				_name = ((IdentityReference)(NTAccount)((IdentityReference)SecurityIdentifier).Translate(typeof(NTAccount))).Value;
			}
			return _name;
		}
	}

	public WindowsSidIdentity(SecurityIdentifier sid)
	{
		SecurityIdentifier = sid ?? throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("sid");
		AuthenticationType = string.Empty;
	}

	public WindowsSidIdentity(SecurityIdentifier sid, string name, string authenticationType)
	{
		SecurityIdentifier = sid ?? throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("sid");
		_name = name ?? throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("name");
		AuthenticationType = authenticationType ?? throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("authenticationType");
	}

	public override bool Equals(object obj)
	{
		if (this == obj)
		{
			return true;
		}
		if (!(obj is WindowsSidIdentity windowsSidIdentity))
		{
			return false;
		}
		return SecurityIdentifier == windowsSidIdentity.SecurityIdentifier;
	}

	public override int GetHashCode()
	{
		return ((object)SecurityIdentifier).GetHashCode();
	}
}
