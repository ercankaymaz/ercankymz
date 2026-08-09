using System;

namespace Hardware.Info;

public class OS
{
	public string Name { get; set; } = string.Empty;

	public string VersionString { get; set; } = string.Empty;

	public Version Version { get; set; } = new Version();

	public override string ToString()
	{
		return "Name: " + Name + Environment.NewLine + "Version: " + VersionString + Environment.NewLine;
	}
}
