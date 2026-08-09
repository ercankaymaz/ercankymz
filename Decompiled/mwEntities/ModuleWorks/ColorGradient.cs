using System;
using System.Drawing;

namespace ModuleWorks;

[Serializable]
public struct ColorGradient
{
	public ColorGradientType GradientType { get; set; }

	public Color StartColor { get; set; }

	public Color EndColor { get; set; }

	public ColorGradient(ColorGradientType type, Color startColor, Color endColor)
	{
		this = default(ColorGradient);
		GradientType = type;
		StartColor = startColor;
		EndColor = endColor;
	}
}
