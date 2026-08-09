using System.ComponentModel;

namespace System.Speech.Recognition;

public class RecognizeCompletedEventArgs : AsyncCompletedEventArgs
{
	public TimeSpan AudioPosition
	{
		get
		{
			throw new PlatformNotSupportedException(System.SR.PlatformNotSupported_SystemSpeech);
		}
	}

	public bool BabbleTimeout
	{
		get
		{
			throw new PlatformNotSupportedException(System.SR.PlatformNotSupported_SystemSpeech);
		}
	}

	public bool InitialSilenceTimeout
	{
		get
		{
			throw new PlatformNotSupportedException(System.SR.PlatformNotSupported_SystemSpeech);
		}
	}

	public bool InputStreamEnded
	{
		get
		{
			throw new PlatformNotSupportedException(System.SR.PlatformNotSupported_SystemSpeech);
		}
	}

	public RecognitionResult Result
	{
		get
		{
			throw new PlatformNotSupportedException(System.SR.PlatformNotSupported_SystemSpeech);
		}
	}

	internal RecognizeCompletedEventArgs()
		: base(null, cancelled: false, null)
	{
		throw new PlatformNotSupportedException(System.SR.PlatformNotSupported_SystemSpeech);
	}
}
