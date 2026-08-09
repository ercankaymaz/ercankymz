namespace System.Speech.Recognition;

public class AudioStateChangedEventArgs : EventArgs
{
	public AudioState AudioState
	{
		get
		{
			throw new PlatformNotSupportedException(System.SR.PlatformNotSupported_SystemSpeech);
		}
	}

	internal AudioStateChangedEventArgs()
	{
		throw new PlatformNotSupportedException(System.SR.PlatformNotSupported_SystemSpeech);
	}
}
