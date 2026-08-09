using UglyToad.PdfPig.Content;
using UglyToad.PdfPig.Graphics.Colors;
using UglyToad.PdfPig.Tokens;

namespace UglyToad.PdfPig.Util;

internal static class ColorSpaceMapper
{
	public static bool TryMap(NameToken name, IResourceStore resourceStore, out ColorSpace colorSpaceResult)
	{
		if (name.TryMapToColorSpace(out colorSpaceResult))
		{
			return true;
		}
		if (!resourceStore.TryGetNamedColorSpace(name, out var namedColorSpace))
		{
			return false;
		}
		if (namedColorSpace.Name.TryMapToColorSpace(out colorSpaceResult))
		{
			return true;
		}
		return false;
	}
}
