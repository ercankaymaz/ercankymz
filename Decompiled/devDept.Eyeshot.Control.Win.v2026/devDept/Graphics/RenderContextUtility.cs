using System.Drawing;

namespace devDept.Graphics;

public class RenderContextUtility
{
	public static Color ConvertColor(Color color)
	{
		return color;
	}

	public static bool AreEqual(Color color1, Color color2)
	{
		return color1.ToArgb() == color2.ToArgb();
	}

	public static Color[] ConvertColorTable(Color[] colorTable)
	{
		return colorTable;
	}

	public static Image ConvertImage(Image image)
	{
		return image;
	}

	public static Bitmap ConvertImage(Bitmap bitmapImage)
	{
		return bitmapImage;
	}
}
