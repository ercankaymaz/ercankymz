namespace System.ServiceModel;

public sealed class NonDualMessageSecurityOverHttp : MessageSecurityOverHttp
{
	internal const bool DefaultEstablishSecurityContext = true;

	public bool EstablishSecurityContext { get; set; }

	public NonDualMessageSecurityOverHttp()
	{
		EstablishSecurityContext = true;
	}

	protected override bool IsSecureConversationEnabled()
	{
		return EstablishSecurityContext;
	}
}
