namespace UglyToad.PdfPig.Filters.Dct.JpegLibrary.Jpeg;

internal abstract class JpegBlockOutputWriter
{
	public abstract void WriteBlock(ref short blockRef, int componentIndex, int x, int y);
}
