using System;

namespace Hardware.Info;

public class CpuCore
{
	public string Name { get; set; } = string.Empty;

	public ulong PercentProcessorTime { get; set; }

	public override string ToString()
	{
		return "Name: " + Name + Environment.NewLine + "PercentProcessorTime: " + PercentProcessorTime + Environment.NewLine;
	}
}
