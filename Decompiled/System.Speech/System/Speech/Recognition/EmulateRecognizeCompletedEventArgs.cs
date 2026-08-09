using System.ComponentModel;

namespace System.Speech.Recognition;

public class EmulateRecognizeCompletedEventArgs : AsyncCompletedEventArgs
{
	public RecognitionResult Result
	{
		get
		{
			throw new PlatformNotSupportedException(System.SR.PlatformNotSupported_SystemSpeech);
		}
	}

	internal EmulateRecognizeCompletedEventArgs()
		: base(null, cancelled: false, null)
	{
		throw new PlatformNotSupportedException(System.SR.PlatformNotSupported_SystemSpeech);
	}
}
