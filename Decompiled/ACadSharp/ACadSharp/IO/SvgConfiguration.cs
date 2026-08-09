using System;
using ACadSharp.Extensions;
using ACadSharp.Types.Units;

namespace ACadSharp.IO;

public class SvgConfiguration : CadWriterConfiguration
{
	public double LineWeightRatio { get; set; } = 100.0;

	public double DefaultLineWeight { get; set; } = 0.01;

	public double PointRadius { get; set; } = 0.1;

	public int ArcPoints { get; set; } = 256;

	public double GetLineWeightValue(LineWeightType lineWeight, UnitsType units)
	{
		double num = Math.Abs((double)lineWeight);
		if (units == UnitsType.Unitless)
		{
			return num / LineWeightRatio;
		}
		return lineWeight switch
		{
			LineWeightType.Default => DefaultLineWeight, 
			LineWeightType.W0 => 0.001, 
			_ => lineWeight.GetLineWeightValue(), 
		};
	}
}
