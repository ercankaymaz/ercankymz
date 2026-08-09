using System.Collections.Generic;
using ACadSharp.Attributes;

namespace ACadSharp.Entities;

public class HatchGradientPattern
{
	[DxfCodeValue(new int[] { 450 })]
	public bool Enabled { get; set; }

	[DxfCodeValue(new int[] { 451 })]
	internal int Reserved { get; set; }

	[DxfCodeValue(new int[] { 460 })]
	public double Angle { get; set; }

	[DxfCodeValue(new int[] { 461 })]
	public double Shift { get; set; }

	[DxfCodeValue(new int[] { 452 })]
	public bool IsSingleColorGradient { get; set; }

	[DxfCodeValue(new int[] { 462 })]
	public double ColorTint { get; set; }

	[DxfCodeValue(new int[] { 453 })]
	public List<GradientColor> Colors { get; set; } = new List<GradientColor>();

	[DxfCodeValue(new int[] { 470 })]
	public string Name { get; set; }

	public HatchGradientPattern()
	{
	}

	public HatchGradientPattern(string name)
	{
		Name = name;
	}

	public HatchGradientPattern Clone()
	{
		HatchGradientPattern hatchGradientPattern = (HatchGradientPattern)MemberwiseClone();
		hatchGradientPattern.Colors.Clear();
		foreach (GradientColor color in Colors)
		{
			hatchGradientPattern.Colors.Add(color.Clone());
		}
		return hatchGradientPattern;
	}
}
