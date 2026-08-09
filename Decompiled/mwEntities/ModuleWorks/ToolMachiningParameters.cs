using System;
using System.Globalization;

namespace ModuleWorks;

[Serializable]
public class ToolMachiningParameters
{
	public double SpindleSpeed { get; set; }

	public ToolSpindleDirection SpindleDirection { get; set; }

	public ToolMachiningParameters()
	{
		SpindleSpeed = 2000.0;
		SpindleDirection = ToolSpindleDirection.Clockwise;
	}

	public ToolMachiningParameters(ToolMachiningParameters other)
	{
		SpindleSpeed = other.SpindleSpeed;
		SpindleDirection = other.SpindleDirection;
	}

	public override string ToString()
	{
		return string.Format(CultureInfo.InvariantCulture, "S: {0:0.##}, {1}", SpindleSpeed, SpindleDirection);
	}
}
