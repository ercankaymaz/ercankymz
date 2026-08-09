namespace UglyToad.PdfPig.Images.Png;

internal class PngOpenerSettings
{
	public IChunkVisitor? ChunkVisitor { get; set; }

	public bool DisallowTrailingData { get; set; }
}
