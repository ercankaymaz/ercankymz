namespace ACadSharp.IO;

public class DwgReaderConfiguration : CadReaderConfiguration
{
	public bool CrcCheck { get; set; }

	public bool ReadSummaryInfo { get; set; } = true;
}
