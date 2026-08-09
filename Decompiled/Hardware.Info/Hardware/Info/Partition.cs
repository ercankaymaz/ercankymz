using System;
using System.Collections.Generic;

namespace Hardware.Info;

public class Partition
{
	public List<Volume> VolumeList { get; set; } = new List<Volume>();

	public bool Bootable { get; set; }

	public bool BootPartition { get; set; }

	public string Caption { get; set; } = string.Empty;

	public string Description { get; set; } = string.Empty;

	public uint DiskIndex { get; set; }

	public uint Index { get; set; }

	public string Name { get; set; } = string.Empty;

	public bool PrimaryPartition { get; set; }

	public ulong Size { get; set; }

	public ulong StartingOffset { get; set; }

	public override string ToString()
	{
		return "Bootable: " + Bootable + Environment.NewLine + "BootPartition: " + BootPartition + Environment.NewLine + "Caption: " + Caption + Environment.NewLine + "Description: " + Description + Environment.NewLine + "DiskIndex: " + DiskIndex + Environment.NewLine + "Index: " + Index + Environment.NewLine + "Name: " + Name + Environment.NewLine + "PrimaryPartition: " + PrimaryPartition + Environment.NewLine + "Size: " + Size + Environment.NewLine + "StartingOffset: " + StartingOffset + Environment.NewLine;
	}
}
