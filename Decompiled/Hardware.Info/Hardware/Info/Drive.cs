using System;
using System.Collections.Generic;

namespace Hardware.Info;

public class Drive
{
	public List<Partition> PartitionList { get; set; } = new List<Partition>();

	public string Caption { get; set; } = string.Empty;

	public string Description { get; set; } = string.Empty;

	public string FirmwareRevision { get; set; } = string.Empty;

	public uint Index { get; set; }

	public string Manufacturer { get; set; } = string.Empty;

	public string MediaType { get; set; } = string.Empty;

	public string Model { get; set; } = string.Empty;

	public string Name { get; set; } = string.Empty;

	public uint Partitions { get; set; }

	public string SerialNumber { get; set; } = string.Empty;

	public ulong Size { get; set; }

	public override string ToString()
	{
		return "Caption: " + Caption + Environment.NewLine + "Description: " + Description + Environment.NewLine + "FirmwareRevision: " + FirmwareRevision + Environment.NewLine + "Index: " + Index + Environment.NewLine + "Manufacturer: " + Manufacturer + Environment.NewLine + "MediaType: " + MediaType + Environment.NewLine + "Model: " + Model + Environment.NewLine + "Name: " + Name + Environment.NewLine + "Partitions: " + Partitions + Environment.NewLine + "SerialNumber: " + SerialNumber + Environment.NewLine + "Size: " + Size + Environment.NewLine;
	}
}
