namespace System.Speech.Synthesis;

public class VoiceChangeEventArgs : PromptEventArgs
{
	public VoiceInfo Voice
	{
		get
		{
			throw new PlatformNotSupportedException(System.SR.PlatformNotSupported_SystemSpeech);
		}
	}

	internal VoiceChangeEventArgs()
	{
		throw new PlatformNotSupportedException(System.SR.PlatformNotSupported_SystemSpeech);
	}
}
