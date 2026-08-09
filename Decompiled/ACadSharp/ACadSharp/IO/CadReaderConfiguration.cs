namespace ACadSharp.IO;

public abstract class CadReaderConfiguration
{
	public bool Failsafe { get; set; } = true;

	public bool KeepUnknownEntities { get; set; }

	public bool KeepUnknownNonGraphicalObjects { get; set; }
}
