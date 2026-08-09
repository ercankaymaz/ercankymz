using System.Collections.ObjectModel;

namespace System.Speech.Recognition.SrgsGrammar;

public sealed class SrgsRulesCollection : KeyedCollection<string, SrgsRule>
{
	public SrgsRulesCollection()
	{
		throw new PlatformNotSupportedException(System.SR.PlatformNotSupported_SystemSpeech);
	}

	public void Add(params SrgsRule[] rules)
	{
		throw new PlatformNotSupportedException(System.SR.PlatformNotSupported_SystemSpeech);
	}

	protected override string GetKeyForItem(SrgsRule rule)
	{
		throw new PlatformNotSupportedException(System.SR.PlatformNotSupported_SystemSpeech);
	}
}
