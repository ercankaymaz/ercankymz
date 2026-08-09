using System.Drawing;
using ImageProcessor.Imaging.Colors;

namespace ImageProcessor.Imaging.Quantizers.WuQuantizer;

internal struct PaletteColorHistory
{
	public ulong Alpha;

	public ulong Red;

	public ulong Green;

	public ulong Blue;

	public ulong Sum;

	public Color ToNormalizedColor()
	{
		return (Sum != 0L) ? Color.FromArgb((int)(Alpha /= Sum), (int)(Red /= Sum), (int)(Green /= Sum), (int)(Blue /= Sum)) : Color.Empty;
	}

	public void AddPixel(Color32 pixel)
	{
		Alpha += pixel.A;
		Red += pixel.R;
		Green += pixel.G;
		Blue += pixel.B;
		Sum++;
	}
}
