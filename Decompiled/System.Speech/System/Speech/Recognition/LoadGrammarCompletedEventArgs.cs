using System.ComponentModel;

namespace System.Speech.Recognition;

public class LoadGrammarCompletedEventArgs : AsyncCompletedEventArgs
{
	public Grammar Grammar
	{
		get
		{
			throw new PlatformNotSupportedException(System.SR.PlatformNotSupported_SystemSpeech);
		}
	}

	internal LoadGrammarCompletedEventArgs()
		: base(null, cancelled: false, null)
	{
		throw new PlatformNotSupportedException(System.SR.PlatformNotSupported_SystemSpeech);
	}
}
