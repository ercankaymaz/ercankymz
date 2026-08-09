namespace System.Speech.Recognition;

public class SemanticResultKey
{
	public SemanticResultKey(string semanticResultKey, params GrammarBuilder[] builders)
	{
		throw new PlatformNotSupportedException(System.SR.PlatformNotSupported_SystemSpeech);
	}

	public SemanticResultKey(string semanticResultKey, params string[] phrases)
	{
		throw new PlatformNotSupportedException(System.SR.PlatformNotSupported_SystemSpeech);
	}

	public GrammarBuilder ToGrammarBuilder()
	{
		throw new PlatformNotSupportedException(System.SR.PlatformNotSupported_SystemSpeech);
	}
}
