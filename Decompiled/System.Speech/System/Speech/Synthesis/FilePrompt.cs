namespace System.Speech.Synthesis;

public class FilePrompt : Prompt
{
	public FilePrompt(string path, SynthesisMediaType media)
		: base((string)null)
	{
		throw new PlatformNotSupportedException(System.SR.PlatformNotSupported_SystemSpeech);
	}

	public FilePrompt(Uri promptFile, SynthesisMediaType media)
		: base((string)null)
	{
		throw new PlatformNotSupportedException(System.SR.PlatformNotSupported_SystemSpeech);
	}
}
