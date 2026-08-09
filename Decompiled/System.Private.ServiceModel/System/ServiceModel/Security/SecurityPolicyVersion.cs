namespace System.ServiceModel.Security;

public abstract class SecurityPolicyVersion
{
	internal class WSSecurityPolicyVersion11 : SecurityPolicyVersion
	{
		private static readonly WSSecurityPolicyVersion11 s_instance = new WSSecurityPolicyVersion11();

		public static SecurityPolicyVersion Instance => s_instance;

		protected WSSecurityPolicyVersion11()
			: base("http://schemas.xmlsoap.org/ws/2005/07/securitypolicy", "sp")
		{
		}
	}

	internal class WSSecurityPolicyVersion12 : SecurityPolicyVersion
	{
		private static readonly WSSecurityPolicyVersion12 s_instance = new WSSecurityPolicyVersion12();

		public static SecurityPolicyVersion Instance => s_instance;

		protected WSSecurityPolicyVersion12()
			: base("http://docs.oasis-open.org/ws-sx/ws-securitypolicy/200702", "sp")
		{
		}
	}

	private readonly string _prefix;

	public string Namespace { get; }

	public string Prefix => _prefix;

	public static SecurityPolicyVersion WSSecurityPolicy11 => WSSecurityPolicyVersion11.Instance;

	public static SecurityPolicyVersion WSSecurityPolicy12 => WSSecurityPolicyVersion12.Instance;

	internal SecurityPolicyVersion(string ns, string prefix)
	{
		Namespace = ns;
		_prefix = prefix;
	}
}
