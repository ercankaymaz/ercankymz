using ACadSharp.Attributes;

namespace ACadSharp.Entities;

public class GradientColor
{
	[DxfCodeValue(new int[] { 463 })]
	public double Value { get; set; }

	[DxfCodeValue(new int[] { 421 })]
	public Color Color { get; set; }

	public GradientColor Clone()
	{
		return (GradientColor)MemberwiseClone();
	}
}
