using System.Drawing;

namespace devDept;

public static class ImageComparison
{
	public static double CompareImages(Bitmap expectedImage, Bitmap actualImage, out Bitmap diffImage, double pixelTransparency = 0.3)
	{
		return CompareImages(expectedImage, actualImage, out diffImage, pixelTransparency, Color.Fuchsia, (_0023_003DzbcH_0024g15ugtfHYKqc4A_003D_003D)1);
	}

	public static double CompareImages(Bitmap expectedImage, Bitmap actualImage, out Bitmap diffImage, double pixelTransparency, Color errorPixelColor)
	{
		return CompareImages(expectedImage, actualImage, out diffImage, pixelTransparency, errorPixelColor, (_0023_003DzbcH_0024g15ugtfHYKqc4A_003D_003D)1);
	}

	internal static double CompareImages(Bitmap expectedImage, Bitmap actualImage, out Bitmap diffImage, double pixelTransparency, Color errorPixelColor, _0023_003DzbcH_0024g15ugtfHYKqc4A_003D_003D ignoreType, _0023_003DzmWQuoMLj0t5eSt42BfuJUykyP6i_0024uZ9gNg_003D_003D transformerType = (_0023_003DzmWQuoMLj0t5eSt42BfuJUykyP6i_0024uZ9gNg_003D_003D)0, bool ignoreTransparentPixels = true)
	{
		_0023_003Dz0yJgLEfz_ZPXTMHM69IqcJc_003D _0023_003Dz0yJgLEfz_ZPXTMHM69IqcJc_003D2 = new _0023_003Dz0yJgLEfz_ZPXTMHM69IqcJc_003D(expectedImage, actualImage, pixelTransparency, ignoreType, errorPixelColor, transformerType, ignoreTransparentPixels);
		_0023_003Dz0yJgLEfz_ZPXTMHM69IqcJc_003D2._0023_003DzS5KVJ48_003D();
		diffImage = _0023_003Dz0yJgLEfz_ZPXTMHM69IqcJc_003D2._0023_003DzyRUbhwA_003D();
		return _0023_003Dz0yJgLEfz_ZPXTMHM69IqcJc_003D2._0023_003DzZB9akBfD_YeCkXvbuA_003D_003D();
	}
}
