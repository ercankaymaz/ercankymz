using System;

namespace Hardware.Info;

public class ComputerSystem
{
	public string Caption { get; set; } = string.Empty;

	public string Description { get; set; } = string.Empty;

	public string IdentifyingNumber { get; set; } = string.Empty;

	public string Name { get; set; } = string.Empty;

	public string SKUNumber { get; set; } = string.Empty;

	public string UUID { get; set; } = string.Empty;

	public string Vendor { get; set; } = string.Empty;

	public string Version { get; set; } = string.Empty;

	public override string ToString()
	{
		return "Caption: " + Caption + Environment.NewLine + "Description: " + Description + Environment.NewLine + "IdentifyingNumber: " + IdentifyingNumber + Environment.NewLine + "Name: " + Name + Environment.NewLine + "SKUNumber: " + SKUNumber + Environment.NewLine + "UUID: " + UUID + Environment.NewLine + "Vendor: " + Vendor + Environment.NewLine + "Version: " + Version + Environment.NewLine;
	}
}
