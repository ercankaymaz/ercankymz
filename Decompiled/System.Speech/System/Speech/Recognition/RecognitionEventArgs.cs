namespace System.Speech.Recognition;

public abstract class RecognitionEventArgs : EventArgs
{
	public RecognitionResult Result
	{
		get
		{
			throw new PlatformNotSupportedException(System.SR.PlatformNotSupported_SystemSpeech);
		}
	}

	internal RecognitionEventArgs()
	{
		throw new PlatformNotSupportedException(System.SR.PlatformNotSupported_SystemSpeech);
	}
}
