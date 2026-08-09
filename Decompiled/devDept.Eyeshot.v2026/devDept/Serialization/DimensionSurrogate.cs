using System.Drawing;
using devDept.Eyeshot.Entities;
using devDept.Geometry;

namespace devDept.Serialization;

public abstract class DimensionSurrogate : TextSurrogate
{
	public double ArrowheadSize;

	public byte ArrowsLocation;

	public Point3D DimLinePosition;

	public int Precision;

	public bool SuppressLeadingZeros;

	public bool SuppressTrailingZeros;

	public double TextGap;

	public byte TextLocation;

	public string TextPrefix;

	public string TextOverride;

	public string TextSuffix;

	public double LinearScale;

	public double ScaleOverall;

	public byte LinearDimensionUnits;

	public string DimStyle;

	public double Distance;

	public byte ToleranceMode;

	public bool ToleranceAlignment;

	public double UpperValue;

	public double LowerValue;

	public double ScalingForHeight;

	public bool ToleranceSuppressLeadingZeros;

	public bool ToleranceSuppressTralingZeros;

	public int TolerancePrecision;

	public byte TextColorMethod;

	public Color TextColor;

	public Dimension.horizontalAlignmentType TextHorizontalPosition;

	public Dimension.verticalAlignmentType TextVerticalPosition;

	public bool UseDefaultTextPosition;

	public DimensionSurrogate(Dimension dimension)
		: base(dimension)
	{
	}

	protected abstract override Entity ConvertToObject();

	protected override void CopyDataToObject(Entity entity)
	{
		Dimension dimension = (Dimension)entity;
		dimension.ArrowheadSize = ArrowheadSize;
		dimension.ArrowsLocation = (elementPositionType)ArrowsLocation;
		dimension.DimLinePosition = DimLinePosition;
		dimension.Precision = Precision;
		dimension.SuppressLeadingZeros = SuppressLeadingZeros;
		dimension.SuppressTrailingZeros = SuppressTrailingZeros;
		dimension.TextGap = TextGap;
		dimension.TextLocation = (elementPositionType)TextLocation;
		dimension.TextPrefix = TextPrefix;
		dimension.TextOverride = TextOverride;
		dimension.TextSuffix = TextSuffix;
		dimension.LinearScale = LinearScale;
		dimension.ScaleOverall = ScaleOverall;
		dimension.LinearDimensionUnits = (linearDimensionUnitsType)LinearDimensionUnits;
		dimension.DimStyle = DimStyle;
		dimension.Distance = Distance;
		dimension.ToleranceMode = (toleranceType)ToleranceMode;
		dimension.ToleranceAlignment = ToleranceAlignment;
		dimension.UpperValue = UpperValue;
		dimension.LowerValue = LowerValue;
		dimension.ScalingForHeight = ScalingForHeight;
		dimension.ToleranceSuppressLeadingZeros = ToleranceSuppressLeadingZeros;
		dimension.ToleranceSuppressTralingZeros = ToleranceSuppressTralingZeros;
		dimension.TolerancePrecision = TolerancePrecision;
		if (base.Version >= 7)
		{
			dimension.TextColorMethod = (colorMethodType)TextColorMethod;
			dimension.TextColor = TextColor;
		}
		if (base.Version >= 21)
		{
			dimension.TextHorizontalPosition = TextHorizontalPosition;
			dimension.TextVerticalPosition = TextVerticalPosition;
			dimension.UseDefaultTextPosition = UseDefaultTextPosition;
		}
		base.CopyDataToObject(entity);
	}

	protected override void CopyDataFromObject(Entity entity)
	{
		Dimension dimension = (Dimension)entity;
		ArrowheadSize = dimension.ArrowheadSize;
		ArrowsLocation = (byte)dimension.ArrowsLocation;
		DimLinePosition = dimension.DimLinePosition;
		Precision = dimension.Precision;
		SuppressLeadingZeros = dimension.SuppressLeadingZeros;
		SuppressTrailingZeros = dimension.SuppressTrailingZeros;
		TextGap = dimension.TextGap;
		TextLocation = (byte)dimension.TextLocation;
		TextPrefix = dimension.TextPrefix;
		TextOverride = dimension.TextOverride;
		TextSuffix = dimension.TextSuffix;
		LinearScale = dimension.LinearScale;
		ScaleOverall = dimension.ScaleOverall;
		LinearDimensionUnits = (byte)dimension.LinearDimensionUnits;
		DimStyle = dimension.DimStyle;
		Distance = dimension.Distance;
		ToleranceMode = (byte)dimension.ToleranceMode;
		ToleranceAlignment = dimension.ToleranceAlignment;
		UpperValue = dimension.UpperValue;
		LowerValue = dimension.LowerValue;
		ScalingForHeight = dimension.ScalingForHeight;
		ToleranceSuppressLeadingZeros = dimension.ToleranceSuppressLeadingZeros;
		ToleranceSuppressTralingZeros = dimension.ToleranceSuppressTralingZeros;
		TolerancePrecision = dimension.TolerancePrecision;
		TextColorMethod = (byte)dimension.TextColorMethod;
		TextColor = dimension.TextColor;
		TextHorizontalPosition = dimension.TextHorizontalPosition;
		TextVerticalPosition = dimension.TextVerticalPosition;
		UseDefaultTextPosition = dimension.UseDefaultTextPosition;
		base.CopyDataFromObject(entity);
	}
}
