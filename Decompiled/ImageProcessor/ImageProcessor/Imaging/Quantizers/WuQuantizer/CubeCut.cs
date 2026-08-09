namespace ImageProcessor.Imaging.Quantizers.WuQuantizer;

internal readonly struct CubeCut(byte? cutPoint, float result)
{
	public readonly byte? Position = cutPoint;

	public readonly float Value = result;
}
