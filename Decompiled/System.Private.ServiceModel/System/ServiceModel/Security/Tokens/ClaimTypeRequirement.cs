namespace System.ServiceModel.Security.Tokens;

public class ClaimTypeRequirement
{
	internal const bool DefaultIsOptional = false;

	private bool _isOptional;

	public string ClaimType { get; }

	public bool IsOptional => _isOptional;

	public ClaimTypeRequirement(string claimType)
		: this(claimType, isOptional: false)
	{
	}

	public ClaimTypeRequirement(string claimType, bool isOptional)
	{
		if (claimType == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("claimType");
		}
		if (claimType.Length <= 0)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgument("claimType", System.SR.ClaimTypeCannotBeEmpty);
		}
		ClaimType = claimType;
		_isOptional = isOptional;
	}
}
