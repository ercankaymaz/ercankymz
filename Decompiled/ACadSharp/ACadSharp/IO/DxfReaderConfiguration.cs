namespace ACadSharp.IO;

public class DxfReaderConfiguration : CadReaderConfiguration
{
	public bool ClearCache { get; set; } = true;

	public bool CreateDefaults { get; set; }
}
