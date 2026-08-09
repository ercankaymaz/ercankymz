using System.ComponentModel;

namespace System.Speech.Synthesis.TtsEngine;

[ImmutableObject(true)]
public struct SpeechEventInfo : IEquatable<SpeechEventInfo>
{
	private object _dummy;

	private int _dummyPrimitive;

	public short EventId
	{
		get
		{
			throw new PlatformNotSupportedException(System.SR.PlatformNotSupported_SystemSpeech);
		}
	}

	public int Param1
	{
		get
		{
			throw new PlatformNotSupportedException(System.SR.PlatformNotSupported_SystemSpeech);
		}
	}

	public nint Param2
	{
		get
		{
			throw new PlatformNotSupportedException(System.SR.PlatformNotSupported_SystemSpeech);
		}
	}

	public short ParameterType
	{
		get
		{
			throw new PlatformNotSupportedException(System.SR.PlatformNotSupported_SystemSpeech);
		}
	}

	public SpeechEventInfo(short eventId, short parameterType, int param1, nint param2)
	{
		throw new PlatformNotSupportedException(System.SR.PlatformNotSupported_SystemSpeech);
	}

	public override bool Equals(object obj)
	{
		throw new PlatformNotSupportedException(System.SR.PlatformNotSupported_SystemSpeech);
	}

	public bool Equals(SpeechEventInfo other)
	{
		throw new PlatformNotSupportedException(System.SR.PlatformNotSupported_SystemSpeech);
	}

	public override int GetHashCode()
	{
		throw new PlatformNotSupportedException(System.SR.PlatformNotSupported_SystemSpeech);
	}

	public static bool operator ==(SpeechEventInfo event1, SpeechEventInfo event2)
	{
		throw new PlatformNotSupportedException(System.SR.PlatformNotSupported_SystemSpeech);
	}

	public static bool operator !=(SpeechEventInfo event1, SpeechEventInfo event2)
	{
		throw new PlatformNotSupportedException(System.SR.PlatformNotSupported_SystemSpeech);
	}
}
