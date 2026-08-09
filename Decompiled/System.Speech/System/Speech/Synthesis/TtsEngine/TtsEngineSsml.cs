namespace System.Speech.Synthesis.TtsEngine;

public abstract class TtsEngineSsml
{
	protected TtsEngineSsml(string registryKey)
	{
		throw new PlatformNotSupportedException(System.SR.PlatformNotSupported_SystemSpeech);
	}

	public abstract void AddLexicon(Uri uri, string mediaType, ITtsEngineSite site);

	public abstract nint GetOutputFormat(SpeakOutputFormat speakOutputFormat, nint targetWaveFormat);

	public abstract void RemoveLexicon(Uri uri, ITtsEngineSite site);

	public abstract void Speak(TextFragment[] fragment, nint waveHeader, ITtsEngineSite site);
}
