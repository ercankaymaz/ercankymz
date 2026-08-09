using System.ComponentModel;

namespace System.Speech.Synthesis;

public abstract class PromptEventArgs : AsyncCompletedEventArgs
{
	public Prompt Prompt
	{
		get
		{
			throw new PlatformNotSupportedException(System.SR.PlatformNotSupported_SystemSpeech);
		}
	}

	internal PromptEventArgs()
		: base(null, cancelled: false, null)
	{
		throw new PlatformNotSupportedException(System.SR.PlatformNotSupported_SystemSpeech);
	}
}
