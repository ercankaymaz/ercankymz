namespace System.Speech.Synthesis;

public class SpeakCompletedEventArgs : PromptEventArgs
{
	internal SpeakCompletedEventArgs()
	{
		throw new PlatformNotSupportedException(System.SR.PlatformNotSupported_SystemSpeech);
	}
}
