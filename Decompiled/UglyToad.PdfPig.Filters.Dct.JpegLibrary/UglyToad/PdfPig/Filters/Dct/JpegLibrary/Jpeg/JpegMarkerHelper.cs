namespace UglyToad.PdfPig.Filters.Dct.JpegLibrary.Jpeg;

internal static class JpegMarkerHelper
{
	public static bool IsRestartMarker(this JpegMarker marker)
	{
		if (208 <= (int)marker)
		{
			return (int)marker <= 215;
		}
		return false;
	}
}
