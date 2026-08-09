using System.Collections.ObjectModel;
using System.Xml;

namespace System.Speech.Recognition.SrgsGrammar;

public class SrgsOneOf : SrgsElement
{
	public Collection<SrgsItem> Items
	{
		get
		{
			throw new PlatformNotSupportedException(System.SR.PlatformNotSupported_SystemSpeech);
		}
	}

	public SrgsOneOf()
	{
		throw new PlatformNotSupportedException(System.SR.PlatformNotSupported_SystemSpeech);
	}

	public SrgsOneOf(params SrgsItem[] items)
	{
		throw new PlatformNotSupportedException(System.SR.PlatformNotSupported_SystemSpeech);
	}

	public SrgsOneOf(params string[] items)
	{
		throw new PlatformNotSupportedException(System.SR.PlatformNotSupported_SystemSpeech);
	}

	public void Add(SrgsItem item)
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
