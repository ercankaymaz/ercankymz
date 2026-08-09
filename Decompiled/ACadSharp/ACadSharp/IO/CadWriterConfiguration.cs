namespace ACadSharp.IO;

public class CadWriterConfiguration
{
	public bool CloseStream { get; set; } = true;

	public bool ResetDxfClasses { get; set; }

	public bool UpdateDimensionsInBlocks { get; set; }

	public bool UpdateDimensionsInModel { get; set; }

	public bool WriteXData { get; set; } = true;

	public bool WriteXRecords { get; set; } = true;

	public bool WriteShapes { get; set; }
}
