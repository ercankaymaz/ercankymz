namespace Zen.Barcode;

public class BarcodeMetricsQr : BarcodeMetrics2d
{
	public int Version { get; set; }

	public QrEncodeMode EncodeMode { get; set; }

	public QrErrorCorrection ErrorCorrection { get; set; }
}
