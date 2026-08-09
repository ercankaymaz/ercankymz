using System.ComponentModel;
using System.Xml;

namespace System.Speech.Recognition.SrgsGrammar;

[ImmutableObject(true)]
public class SrgsRuleRef : SrgsElement
{
	public static readonly SrgsRuleRef Dictation;

	public static readonly SrgsRuleRef Garbage;

	public static readonly SrgsRuleRef MnemonicSpelling;

	public static readonly SrgsRuleRef Null;

	public static readonly SrgsRuleRef Void;

	public string Params
	{
		get
		{
			throw new PlatformNotSupportedException(System.SR.PlatformNotSupported_SystemSpeech);
		}
	}

	public string SemanticKey
	{
		get
		{
			throw new PlatformNotSupportedException(System.SR.PlatformNotSupported_SystemSpeech);
		}
	}

	public Uri Uri
	{
		get
		{
			throw new PlatformNotSupportedException(System.SR.PlatformNotSupported_SystemSpeech);
		}
	}

	public SrgsRuleRef(SrgsRule rule)
	{
		throw new PlatformNotSupportedException(System.SR.PlatformNotSupported_SystemSpeech);
	}

	public SrgsRuleRef(SrgsRule rule, string semanticKey)
	{
		throw new PlatformNotSupportedException(System.SR.PlatformNotSupported_SystemSpeech);
	}

	public SrgsRuleRef(SrgsRule rule, string semanticKey, string parameters)
	{
		throw new PlatformNotSupportedException(System.SR.PlatformNotSupported_SystemSpeech);
	}

	public SrgsRuleRef(Uri uri)
	{
		throw new PlatformNotSupportedException(System.SR.PlatformNotSupported_SystemSpeech);
	}

	public SrgsRuleRef(Uri uri, string rule)
	{
		throw new PlatformNotSupportedException(System.SR.PlatformNotSupported_SystemSpeech);
	}

	public SrgsRuleRef(Uri uri, string rule, string semanticKey)
	{
		throw new PlatformNotSupportedException(System.SR.PlatformNotSupported_SystemSpeech);
	}

	public SrgsRuleRef(Uri uri, string rule, string semanticKey, string parameters)
	{
		throw new PlatformNotSupportedException(System.SR.PlatformNotSupported_SystemSpeech);
	}

	internal override string DebuggerDisplayString()
	{
		throw new PlatformNotSupportedException(System.SR.PlatformNotSupported_SystemSpeech);
	}

	internal override void WriteSrgs(XmlWriter writer)
	{
		throw new PlatformNotSupportedException(System.SR.PlatformNotSupported_SystemSpeech);
	}
}
