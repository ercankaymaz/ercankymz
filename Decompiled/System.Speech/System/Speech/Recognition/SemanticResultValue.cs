namespace System.Speech.Recognition;

public class SemanticResultValue
{
	public SemanticResultValue(object value)
	{
		throw new PlatformNotSupportedException(System.SR.PlatformNotSupported_SystemSpeech);
	}

	public SemanticResultValue(GrammarBuilder builder, object value)
	{
		throw new PlatformNotSupportedException(System.SR.PlatformNotSupported_SystemSpeech);
	}

	public SemanticResultValue(string phrase, object value)
	{
		throw new PlatformNotSupportedException(System.SR.PlatformNotSupported_SystemSpeech);
	}

	public GrammarBuilder ToGrammarBuilder()
	{
		throw new PlatformNotSupportedException(System.SR.PlatformNotSupported_SystemSpeech);
	}
}
