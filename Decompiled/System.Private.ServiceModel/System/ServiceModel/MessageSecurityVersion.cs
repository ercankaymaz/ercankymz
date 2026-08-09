using System.IdentityModel.Selectors;
using System.ServiceModel.Security;

namespace System.ServiceModel;

public abstract class MessageSecurityVersion
{
	internal class WSSecurity11WSTrustFebruary2005WSSecureConversationFebruary2005WSSecurityPolicy11MessageSecurityVersion : MessageSecurityVersion
	{
		public static MessageSecurityVersion Instance { get; } = new WSSecurity11WSTrustFebruary2005WSSecureConversationFebruary2005WSSecurityPolicy11MessageSecurityVersion();

		public override BasicSecurityProfileVersion BasicSecurityProfileVersion => null;

		internal override MessageSecurityTokenVersion MessageSecurityTokenVersion => MessageSecurityTokenVersion.WSSecurity11WSTrustFebruary2005WSSecureConversationFebruary2005;

		public override SecurityPolicyVersion SecurityPolicyVersion => SecurityPolicyVersion.WSSecurityPolicy11;

		public override string ToString()
		{
			return "WSSecurity11WSTrustFebruary2005WSSecureConversationFebruary2005WSSecurityPolicy11";
		}
	}

	internal class WSSecurity10WSTrustFebruary2005WSSecureConversationFebruary2005WSSecurityPolicy11BasicSecurityProfile10MessageSecurityVersion : MessageSecurityVersion
	{
		public static MessageSecurityVersion Instance { get; } = new WSSecurity10WSTrustFebruary2005WSSecureConversationFebruary2005WSSecurityPolicy11BasicSecurityProfile10MessageSecurityVersion();

		public override BasicSecurityProfileVersion BasicSecurityProfileVersion => BasicSecurityProfileVersion.BasicSecurityProfile10;

		internal override MessageSecurityTokenVersion MessageSecurityTokenVersion => MessageSecurityTokenVersion.WSSecurity10WSTrustFebruary2005WSSecureConversationFebruary2005BasicSecurityProfile10;

		public override SecurityPolicyVersion SecurityPolicyVersion => SecurityPolicyVersion.WSSecurityPolicy11;

		public override string ToString()
		{
			return "WSSecurity10WSTrustFebruary2005WSSecureConversationFebruary2005WSSecurityPolicy11BasicSecurityProfile10";
		}
	}

	internal class WSSecurity11WSTrustFebruary2005WSSecureConversationFebruary2005WSSecurityPolicy11BasicSecurityProfile10MessageSecurityVersion : MessageSecurityVersion
	{
		public static MessageSecurityVersion Instance { get; } = new WSSecurity11WSTrustFebruary2005WSSecureConversationFebruary2005WSSecurityPolicy11BasicSecurityProfile10MessageSecurityVersion();

		public override SecurityPolicyVersion SecurityPolicyVersion => SecurityPolicyVersion.WSSecurityPolicy11;

		public override BasicSecurityProfileVersion BasicSecurityProfileVersion => BasicSecurityProfileVersion.BasicSecurityProfile10;

		internal override MessageSecurityTokenVersion MessageSecurityTokenVersion => MessageSecurityTokenVersion.WSSecurity11WSTrustFebruary2005WSSecureConversationFebruary2005BasicSecurityProfile10;

		public override string ToString()
		{
			return "WSSecurity11WSTrustFebruary2005WSSecureConversationFebruary2005WSSecurityPolicy11BasicSecurityProfile10";
		}
	}

	internal class WSSecurity10WSTrust13WSSecureConversation13WSSecurityPolicy12BasicSecurityProfile10MessageSecurityVersion : MessageSecurityVersion
	{
		public static MessageSecurityVersion Instance { get; } = new WSSecurity10WSTrust13WSSecureConversation13WSSecurityPolicy12BasicSecurityProfile10MessageSecurityVersion();

		public override SecurityPolicyVersion SecurityPolicyVersion => SecurityPolicyVersion.WSSecurityPolicy12;

		public override BasicSecurityProfileVersion BasicSecurityProfileVersion => null;

		internal override MessageSecurityTokenVersion MessageSecurityTokenVersion => MessageSecurityTokenVersion.WSSecurity10WSTrust13WSSecureConversation13BasicSecurityProfile10;

		public override string ToString()
		{
			return "WSSecurity10WSTrust13WSSecureConversation13WSSecurityPolicy12BasicSecurityProfile10";
		}
	}

	internal class WSSecurity11WSTrust13WSSecureConversation13WSSecurityPolicy12MessageSecurityVersion : MessageSecurityVersion
	{
		public static MessageSecurityVersion Instance { get; } = new WSSecurity11WSTrust13WSSecureConversation13WSSecurityPolicy12MessageSecurityVersion();

		public override SecurityPolicyVersion SecurityPolicyVersion => SecurityPolicyVersion.WSSecurityPolicy12;

		public override BasicSecurityProfileVersion BasicSecurityProfileVersion => null;

		internal override MessageSecurityTokenVersion MessageSecurityTokenVersion => MessageSecurityTokenVersion.WSSecurity11WSTrust13WSSecureConversation13;

		public override string ToString()
		{
			return "WSSecurity11WSTrust13WSSecureConversation13WSSecurityPolicy12";
		}
	}

	internal class WSSecurity11WSTrust13WSSecureConversation13WSSecurityPolicy12BasicSecurityProfile10MessageSecurityVersion : MessageSecurityVersion
	{
		public static MessageSecurityVersion Instance { get; } = new WSSecurity11WSTrust13WSSecureConversation13WSSecurityPolicy12BasicSecurityProfile10MessageSecurityVersion();

		public override SecurityPolicyVersion SecurityPolicyVersion => SecurityPolicyVersion.WSSecurityPolicy12;

		public override BasicSecurityProfileVersion BasicSecurityProfileVersion => null;

		internal override MessageSecurityTokenVersion MessageSecurityTokenVersion => MessageSecurityTokenVersion.WSSecurity11WSTrust13WSSecureConversation13BasicSecurityProfile10;

		public override string ToString()
		{
			return "WSSecurity11WSTrust13WSSecureConversation13WSSecurityPolicy12BasicSecurityProfile10";
		}
	}

	public static MessageSecurityVersion WSSecurity11WSTrustFebruary2005WSSecureConversationFebruary2005WSSecurityPolicy11 => WSSecurity11WSTrustFebruary2005WSSecureConversationFebruary2005WSSecurityPolicy11MessageSecurityVersion.Instance;

	public static MessageSecurityVersion WSSecurity10WSTrustFebruary2005WSSecureConversationFebruary2005WSSecurityPolicy11BasicSecurityProfile10 => WSSecurity10WSTrustFebruary2005WSSecureConversationFebruary2005WSSecurityPolicy11BasicSecurityProfile10MessageSecurityVersion.Instance;

	public static MessageSecurityVersion WSSecurity11WSTrustFebruary2005WSSecureConversationFebruary2005WSSecurityPolicy11BasicSecurityProfile10 => WSSecurity11WSTrustFebruary2005WSSecureConversationFebruary2005WSSecurityPolicy11BasicSecurityProfile10MessageSecurityVersion.Instance;

	public static MessageSecurityVersion WSSecurity11WSTrust13WSSecureConversation13WSSecurityPolicy12 => WSSecurity11WSTrust13WSSecureConversation13WSSecurityPolicy12MessageSecurityVersion.Instance;

	public static MessageSecurityVersion WSSecurity10WSTrust13WSSecureConversation13WSSecurityPolicy12BasicSecurityProfile10 => WSSecurity10WSTrust13WSSecureConversation13WSSecurityPolicy12BasicSecurityProfile10MessageSecurityVersion.Instance;

	public static MessageSecurityVersion WSSecurity11WSTrust13WSSecureConversation13WSSecurityPolicy12BasicSecurityProfile10 => WSSecurity11WSTrust13WSSecureConversation13WSSecurityPolicy12BasicSecurityProfile10MessageSecurityVersion.Instance;

	public static MessageSecurityVersion Default => WSSecurity11WSTrustFebruary2005WSSecureConversationFebruary2005WSSecurityPolicy11MessageSecurityVersion.Instance;

	internal static MessageSecurityVersion WSSXDefault => WSSecurity11WSTrust13WSSecureConversation13WSSecurityPolicy12MessageSecurityVersion.Instance;

	public SecurityVersion SecurityVersion => MessageSecurityTokenVersion.SecurityVersion;

	public TrustVersion TrustVersion => MessageSecurityTokenVersion.TrustVersion;

	public SecureConversationVersion SecureConversationVersion => MessageSecurityTokenVersion.SecureConversationVersion;

	public SecurityTokenVersion SecurityTokenVersion => MessageSecurityTokenVersion;

	public abstract SecurityPolicyVersion SecurityPolicyVersion { get; }

	public abstract BasicSecurityProfileVersion BasicSecurityProfileVersion { get; }

	internal abstract MessageSecurityTokenVersion MessageSecurityTokenVersion { get; }

	internal MessageSecurityVersion()
	{
	}
}
