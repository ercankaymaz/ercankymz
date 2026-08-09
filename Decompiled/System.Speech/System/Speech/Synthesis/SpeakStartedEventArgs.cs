namespace System.Speech.Synthesis;

public class SpeakStartedEventArgs : PromptEventArgs
{
	internal SpeakStartedEventArgs()
	{
		throw new PlatformNotSupportedException(System.SR.PlatformNotSupported_SystemSpeech);
	}
}
