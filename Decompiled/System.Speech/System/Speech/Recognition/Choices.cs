namespace System.Speech.Recognition;

public class Choices
{
	public Choices()
	{
		throw new PlatformNotSupportedException(System.SR.PlatformNotSupported_SystemSpeech);
	}

	public Choices(params GrammarBuilder[] alternateChoices)
	{
		throw new PlatformNotSupportedException(System.SR.PlatformNotSupported_SystemSpeech);
	}

	public Choices(params string[] phrases)
	{
		throw new PlatformNotSupportedException(System.SR.PlatformNotSupported_SystemSpeech);
	}

	public void Add(params GrammarBuilder[] alternateChoices)
	{
		throw new PlatformNotSupportedException(System.SR.PlatformNotSupported_SystemSpeech);
	}

	public void Add(params string[] phrases)
	{
		throw new PlatformNotSupportedException(System.SR.PlatformNotSupported_SystemSpeech);
	}

	public GrammarBuilder ToGrammarBuilder()
	{
		throw new PlatformNotSupportedException(System.SR.PlatformNotSupported_SystemSpeech);
	}
}
