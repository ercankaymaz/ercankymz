using System.Drawing;
using devDept.Eyeshot.Entities;

namespace devDept.Eyeshot.Control;

public class DimensionPreviewDrawParams
{
	public double TextHeight;

	public double TextGap;

	public float LineSize;

	public Color Color;

	public double DistancesScaleFactor = 1.0;

	public linearDimensionUnitsType LinearDimensionUnits = linearDimensionUnitsType.Decimal;

	public int Precision = 3;

	public string TextOverride;

	public string TextSuffix;

	public string TextPrefix;

	public bool SuppressLeadingZeros;

	public bool SuppressTrailingZeros;

	public double WidthFactor = 1.0;

	public toleranceType ToleranceMode;

	public bool ToleranceSuppressLeadingZeros;

	public bool ToleranceSuppressTrailingZeros;

	public int TolerancePrecision = 3;

	public DimensionPreviewDrawParams(Color color)
	{
		TextHeight = 1.0;
		TextGap = TextHeight * 0.25;
		LineSize = 1f;
		Color = color;
	}

	public DimensionPreviewDrawParams(double textHeight, Color color)
	{
		TextHeight = textHeight;
		TextGap = textHeight * 0.25;
		LineSize = 1f;
		Color = color;
	}

	public DimensionPreviewDrawParams(double textHeight, Color color, float lineSize)
	{
		TextHeight = textHeight;
		TextGap = textHeight * 0.25;
		LineSize = lineSize;
		Color = color;
	}

	public DimensionPreviewDrawParams(double textHeight, Color color, float lineSize, linearDimensionUnitsType linearDimensionUnits, int precision, string textOverride, string textSuffix, string textPrefix, bool suppressLeadingZeros, bool suppressTrailingZeros)
	{
		TextHeight = textHeight;
		TextGap = textHeight * 0.25;
		LineSize = lineSize;
		Color = color;
		LinearDimensionUnits = linearDimensionUnits;
		Precision = precision;
		TextOverride = textOverride;
		TextSuffix = textSuffix;
		TextPrefix = textPrefix;
		SuppressLeadingZeros = suppressLeadingZeros;
		SuppressTrailingZeros = suppressTrailingZeros;
	}

	public DimensionPreviewDrawParams(double textHeight, Color color, float lineSize, linearDimensionUnitsType linearDimensionUnits, int precision, string textOverride, string textSuffix, string textPrefix, bool suppressLeadingZeros, bool suppressTrailingZeros, toleranceType toleranceMode, bool toleranceSuppressLeadingZeros, bool toleranceSuppressTrailingZeros, int tolerancePrecision)
	{
		TextHeight = textHeight;
		TextGap = textHeight * 0.25;
		LineSize = lineSize;
		Color = color;
		LinearDimensionUnits = linearDimensionUnits;
		Precision = precision;
		TextOverride = textOverride;
		TextSuffix = textSuffix;
		TextPrefix = textPrefix;
		SuppressLeadingZeros = suppressLeadingZeros;
		SuppressTrailingZeros = suppressTrailingZeros;
		ToleranceMode = toleranceMode;
		TolerancePrecision = tolerancePrecision;
		ToleranceSuppressLeadingZeros = toleranceSuppressLeadingZeros;
		ToleranceSuppressTrailingZeros = toleranceSuppressTrailingZeros;
	}
}
