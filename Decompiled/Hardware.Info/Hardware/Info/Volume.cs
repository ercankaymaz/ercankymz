using System;

namespace Hardware.Info;

public class Volume
{
	public string Caption { get; set; } = string.Empty;

	public bool Compressed { get; set; }

	public string Description { get; set; } = string.Empty;

	public string FileSystem { get; set; } = string.Empty;

	public ulong FreeSpace { get; set; }

	public string Name { get; set; } = string.Empty;

	public ulong Size { get; set; }

	public string VolumeName { get; set; } = string.Empty;

	public string VolumeSerialNumber { get; set; } = string.Empty;

	public override string ToString()
	{
		return "Caption: " + Caption + Environment.NewLine + "Compressed: " + Compressed + Environment.NewLine + "Description: " + Description + Environment.NewLine + "FileSystem: " + FileSystem + Environment.NewLine + "FreeSpace: " + FreeSpace + Environment.NewLine + "Name: " + Name + Environment.NewLine + "Size: " + Size + Environment.NewLine + "VolumeName: " + VolumeName + Environment.NewLine + "VolumeSerialNumber: " + VolumeSerialNumber + Environment.NewLine;
	}
}
