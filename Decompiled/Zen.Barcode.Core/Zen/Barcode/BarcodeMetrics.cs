using System;

namespace Zen.Barcode;

[Serializable]
public abstract class BarcodeMetrics
{
	public int Scale { get; set; }

	protected BarcodeMetrics()
	{
		Scale = 1;
	}
}
