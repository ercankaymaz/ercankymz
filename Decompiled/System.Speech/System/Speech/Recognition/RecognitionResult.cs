using System.Collections.ObjectModel;
using System.Runtime.Serialization;

namespace System.Speech.Recognition;

public sealed class RecognitionResult : RecognizedPhrase, ISerializable
{
	public ReadOnlyCollection<RecognizedPhrase> Alternates
	{
		get
		{
			throw new PlatformNotSupportedException(System.SR.PlatformNotSupported_SystemSpeech);
		}
	}

	public RecognizedAudio Audio
	{
		get
		{
			throw new PlatformNotSupportedException(System.SR.PlatformNotSupported_SystemSpeech);
		}
	}

	internal RecognitionResult()
	{
		throw new PlatformNotSupportedException(System.SR.PlatformNotSupported_SystemSpeech);
	}

	public RecognizedAudio GetAudioForWordRange(RecognizedWordUnit firstWord, RecognizedWordUnit lastWord)
	{
		throw new PlatformNotSupportedException(System.SR.PlatformNotSupported_SystemSpeech);
	}

	void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
	{
		throw new PlatformNotSupportedException(System.SR.PlatformNotSupported_SystemSpeech);
	}
}
