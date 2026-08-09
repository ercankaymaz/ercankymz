namespace System.ServiceModel.Description;

public sealed class PolicyVersion
{
	private static PolicyVersion s_policyVersion12;

	public static PolicyVersion Policy12 => s_policyVersion12;

	public static PolicyVersion Policy15 { get; private set; }

	public static PolicyVersion Default => s_policyVersion12;

	public string Namespace { get; }

	static PolicyVersion()
	{
		s_policyVersion12 = new PolicyVersion("http://schemas.xmlsoap.org/ws/2004/09/policy");
		Policy15 = new PolicyVersion("http://www.w3.org/ns/ws-policy");
	}

	private PolicyVersion(string policyNamespace)
	{
		Namespace = policyNamespace;
	}

	public override string ToString()
	{
		return Namespace;
	}
}
