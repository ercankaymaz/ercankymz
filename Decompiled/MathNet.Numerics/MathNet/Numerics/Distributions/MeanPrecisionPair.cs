namespace MathNet.Numerics.Distributions;

public struct MeanPrecisionPair(double m, double p)
{
	public double Mean { get; set; } = m;

	public double Precision { get; set; } = p;
}
