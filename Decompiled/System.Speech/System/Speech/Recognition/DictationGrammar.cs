namespace System.Speech.Recognition;

public class DictationGrammar : Grammar
{
	public DictationGrammar()
	{
		throw new PlatformNotSupportedException(System.SR.PlatformNotSupported_SystemSpeech);
	}

	public DictationGrammar(string topic)
	{
		throw new PlatformNotSupportedException(System.SR.PlatformNotSupported_SystemSpeech);
	}

	public void SetDictationContext(string precedingText, string subsequentText)
	{
		throw new PlatformNotSupportedException(System.SR.PlatformNotSupported_SystemSpeech);
	}
}
