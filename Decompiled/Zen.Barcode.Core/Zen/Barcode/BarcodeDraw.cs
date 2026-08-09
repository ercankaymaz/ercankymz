using System.Drawing;

namespace Zen.Barcode;

public abstract class BarcodeDraw
{
	public abstract Image Draw(string text, BarcodeMetrics metrics);

	public Image Draw(string text, int maxBarHeight)
	{
		BarcodeMetrics defaultMetrics = GetDefaultMetrics(maxBarHeight);
		return Draw(text, defaultMetrics);
	}

	public Image Draw(string text, int maxBarHeight, int scale)
	{
		BarcodeMetrics defaultMetrics = GetDefaultMetrics(maxBarHeight);
		defaultMetrics.Scale = scale;
		return Draw(text, defaultMetrics);
	}

	public abstract BarcodeMetrics GetDefaultMetrics(int maxHeight);

	public abstract BarcodeMetrics GetPrintMetrics(Size desiredBarcodeDimensions, Size printResolution, int barcodeCharLength);
}
