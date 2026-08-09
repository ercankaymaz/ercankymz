namespace System.Speech.Synthesis;

public class Prompt
{
	public bool IsCompleted
	{
		get
		{
			throw new PlatformNotSupportedException(System.SR.PlatformNotSupported_SystemSpeech);
		}
	}

	public Prompt(PromptBuilder promptBuilder)
	{
		throw new PlatformNotSupportedException(System.SR.PlatformNotSupported_SystemSpeech);
	}

	public Prompt(string textToSpeak)
	{
		throw new PlatformNotSupportedException(System.SR.PlatformNotSupported_SystemSpeech);
	}

	public Prompt(string textToSpeak, SynthesisTextFormat media)
	{
		throw new PlatformNotSupportedException(System.SR.PlatformNotSupported_SystemSpeech);
	}
}
