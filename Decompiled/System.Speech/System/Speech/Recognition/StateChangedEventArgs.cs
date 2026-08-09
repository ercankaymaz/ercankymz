namespace System.Speech.Recognition;

public class StateChangedEventArgs : EventArgs
{
	public RecognizerState RecognizerState
	{
		get
		{
			throw new PlatformNotSupportedException(System.SR.PlatformNotSupported_SystemSpeech);
		}
	}

	internal StateChangedEventArgs()
	{
		throw new PlatformNotSupportedException(System.SR.PlatformNotSupported_SystemSpeech);
	}
}
