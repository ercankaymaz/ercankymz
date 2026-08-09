using System.Xml;

namespace System.ServiceModel.Security;

public abstract class TrustVersion
{
	internal class WSTrustVersionFeb2005 : TrustVersion
	{
		private static readonly WSTrustVersionFeb2005 s_instance = new WSTrustVersionFeb2005();

		public static TrustVersion Instance => s_instance;

		protected WSTrustVersionFeb2005()
			: base(XD.TrustFeb2005Dictionary.Namespace, XD.TrustFeb2005Dictionary.Prefix)
		{
		}
	}

	internal class WSTrustVersion13 : TrustVersion
	{
		private static readonly WSTrustVersion13 s_instance = new WSTrustVersion13();

		public static TrustVersion Instance => s_instance;

		protected WSTrustVersion13()
			: base(DXD.TrustDec2005Dictionary.Namespace, DXD.TrustDec2005Dictionary.Prefix)
		{
		}
	}

	private readonly XmlDictionaryString _prefix;

	public XmlDictionaryString Namespace { get; }

	public XmlDictionaryString Prefix => _prefix;

	public static TrustVersion Default => WSTrustFeb2005;

	public static TrustVersion WSTrustFeb2005 => WSTrustVersionFeb2005.Instance;

	public static TrustVersion WSTrust13 => WSTrustVersion13.Instance;

	internal TrustVersion(XmlDictionaryString ns, XmlDictionaryString prefix)
	{
		Namespace = ns;
		_prefix = prefix;
	}
}
