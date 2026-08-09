using System.Runtime.CompilerServices;

namespace System.Diagnostics.Metrics;

[System_002EDiagnostics_002EDiagnosticSource_002EIsReadOnly]
internal struct QuantileValue(double quantile, double value)
{
	public double Quantile { get; } = quantile;

	public double Value { get; } = value;
}
