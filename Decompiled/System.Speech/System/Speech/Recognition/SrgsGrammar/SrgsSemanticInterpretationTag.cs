using System.Xml;

namespace System.Speech.Recognition.SrgsGrammar;

public class SrgsSemanticInterpretationTag : SrgsElement
{
	public string Script
	{
		get
		{
			throw new PlatformNotSupportedException(System.SR.PlatformNotSupported_SystemSpeech);
		}
		set
		{
			throw new PlatformNotSupportedException(System.SR.PlatformNotSupported_SystemSpeech);
		}
	}

	public SrgsSemanticInterpretationTag()
	{
		throw new PlatformNotSupportedException(System.SR.PlatformNotSupported_SystemSpeech);
	}

	public SrgsSemanticInterpretationTag(string script)
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
