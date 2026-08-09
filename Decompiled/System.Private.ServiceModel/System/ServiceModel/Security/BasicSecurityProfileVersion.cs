namespace System.ServiceModel.Security;

public abstract class BasicSecurityProfileVersion
{
	internal class BasicSecurityProfile10BasicSecurityProfileVersion : BasicSecurityProfileVersion
	{
		public static BasicSecurityProfile10BasicSecurityProfileVersion Instance { get; } = new BasicSecurityProfile10BasicSecurityProfileVersion();

		public override string ToString()
		{
			return "BasicSecurityProfile10";
		}
	}

	public static BasicSecurityProfileVersion BasicSecurityProfile10 => BasicSecurityProfile10BasicSecurityProfileVersion.Instance;

	internal BasicSecurityProfileVersion()
	{
	}
}
