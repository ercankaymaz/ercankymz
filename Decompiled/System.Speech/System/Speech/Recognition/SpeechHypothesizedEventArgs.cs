namespace System.Speech.Recognition;

public class SpeechHypothesizedEventArgs : RecognitionEventArgs
{
	internal SpeechHypothesizedEventArgs()
	{
		throw new PlatformNotSupportedException(System.SR.PlatformNotSupported_SystemSpeech);
	}
}
