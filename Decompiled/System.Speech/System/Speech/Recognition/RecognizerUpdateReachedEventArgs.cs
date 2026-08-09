namespace System.Speech.Recognition;

public class RecognizerUpdateReachedEventArgs : EventArgs
{
	public TimeSpan AudioPosition
	{
		get
		{
			throw new PlatformNotSupportedException(System.SR.PlatformNotSupported_SystemSpeech);
		}
	}

	public object UserToken
	{
		get
		{
			throw new PlatformNotSupportedException(System.SR.PlatformNotSupported_SystemSpeech);
		}
	}

	internal RecognizerUpdateReachedEventArgs()
	{
		throw new PlatformNotSupportedException(System.SR.PlatformNotSupported_SystemSpeech);
	}
}
