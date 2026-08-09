namespace System.Speech.Recognition;

public class SpeechUI
{
	internal SpeechUI()
	{
		throw new PlatformNotSupportedException(System.SR.PlatformNotSupported_SystemSpeech);
	}

	public static bool SendTextFeedback(RecognitionResult result, string feedback, bool isSuccessfulAction)
	{
		throw new PlatformNotSupportedException(System.SR.PlatformNotSupported_SystemSpeech);
	}
}
