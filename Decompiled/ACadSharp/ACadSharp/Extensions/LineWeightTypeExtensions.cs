using System;

namespace ACadSharp.Extensions;

public static class LineWeightTypeExtensions
{
	public static double GetLineWeightValue(this LineWeightType lineWeight)
	{
		double num = Math.Abs((double)lineWeight);
		if (lineWeight == LineWeightType.W0)
		{
			return 0.001;
		}
		return num / 100.0;
	}
}
