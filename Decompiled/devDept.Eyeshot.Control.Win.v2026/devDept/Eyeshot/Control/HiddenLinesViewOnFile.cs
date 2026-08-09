namespace devDept.Eyeshot.Control;

public class HiddenLinesViewOnFile : HiddenLinesViewOnClipboard
{
	public HiddenLinesViewOnFile(HiddenLinesViewSettingsEx viewSettings, string filePath)
		: this(viewSettings, filePath, 1.0)
	{
	}

	public HiddenLinesViewOnFile(HiddenLinesViewSettingsEx viewSettings, string filePath, double scale)
		: base(viewSettings, filePath, scale)
	{
	}
}
