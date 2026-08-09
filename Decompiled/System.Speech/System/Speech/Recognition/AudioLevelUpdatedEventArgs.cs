namespace System.Speech.Recognition;

public class AudioLevelUpdatedEventArgs : EventArgs
{
	public int AudioLevel
	{
		get
		{
			throw new PlatformNotSupportedException(System.SR.PlatformNotSupported_SystemSpeech);
		}
	}

	internal AudioLevelUpdatedEventArgs()
	{
		throw new PlatformNotSupportedException(System.SR.PlatformNotSupported_SystemSpeech);
	}
}
