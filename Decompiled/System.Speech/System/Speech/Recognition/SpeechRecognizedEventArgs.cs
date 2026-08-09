namespace System.Speech.Recognition;

public class SpeechRecognizedEventArgs : RecognitionEventArgs
{
	internal SpeechRecognizedEventArgs()
	{
		throw new PlatformNotSupportedException(System.SR.PlatformNotSupported_SystemSpeech);
	}
}
