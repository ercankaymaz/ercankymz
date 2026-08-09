using System;

namespace Hardware.Info;

public class Memory
{
	public string BankLabel { get; set; } = string.Empty;

	public ulong Capacity { get; set; }

	public FormFactor FormFactor { get; set; }

	public string Manufacturer { get; set; } = string.Empty;

	public uint MaxVoltage { get; set; }

	public uint MinVoltage { get; set; }

	public string PartNumber { get; set; } = string.Empty;

	public string SerialNumber { get; set; } = string.Empty;

	public uint Speed { get; set; }

	public override string ToString()
	{
		return "BankLabel: " + BankLabel + Environment.NewLine + "Capacity: " + Capacity + Environment.NewLine + "FormFactor: " + FormFactor.ToString() + Environment.NewLine + "Manufacturer: " + Manufacturer + Environment.NewLine + "MaxVoltage: " + MaxVoltage + Environment.NewLine + "MinVoltage: " + MinVoltage + Environment.NewLine + "PartNumber: " + PartNumber + Environment.NewLine + "SerialNumber: " + SerialNumber + Environment.NewLine + "Speed: " + Speed + Environment.NewLine;
	}
}
