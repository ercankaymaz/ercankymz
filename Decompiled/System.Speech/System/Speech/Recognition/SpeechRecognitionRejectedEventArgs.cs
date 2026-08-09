namespace System.Speech.Recognition;

public class SpeechRecognitionRejectedEventArgs : RecognitionEventArgs
{
	internal SpeechRecognitionRejectedEventArgs()
	{
		throw new PlatformNotSupportedException(System.SR.PlatformNotSupported_SystemSpeech);
	}
}
