using System;

namespace Hardware.Info;

public class VideoController
{
	public ulong AdapterRAM { get; set; }

	public string Caption { get; set; } = string.Empty;

	public uint CurrentBitsPerPixel { get; set; }

	public uint CurrentHorizontalResolution { get; set; }

	public ulong CurrentNumberOfColors { get; set; }

	public uint CurrentRefreshRate { get; set; }

	public uint CurrentVerticalResolution { get; set; }

	public string Description { get; set; } = string.Empty;

	public string DriverDate { get; set; } = string.Empty;

	public string DriverVersion { get; set; } = string.Empty;

	public string Manufacturer { get; set; } = string.Empty;

	public uint MaxRefreshRate { get; set; }

	public uint MinRefreshRate { get; set; }

	public string Name { get; set; } = string.Empty;

	public string VideoModeDescription { get; set; } = string.Empty;

	public string VideoProcessor { get; set; } = string.Empty;

	public override string ToString()
	{
		return "AdapterRAM: " + AdapterRAM + Environment.NewLine + "Caption: " + Caption + Environment.NewLine + "CurrentBitsPerPixel: " + CurrentBitsPerPixel + Environment.NewLine + "CurrentHorizontalResolution: " + CurrentHorizontalResolution + Environment.NewLine + "CurrentNumberOfColors: " + CurrentNumberOfColors + Environment.NewLine + "CurrentRefreshRate: " + CurrentRefreshRate + Environment.NewLine + "CurrentVerticalResolution: " + CurrentVerticalResolution + Environment.NewLine + "Description: " + Description + Environment.NewLine + "DriverDate: " + DriverDate + Environment.NewLine + "DriverVersion: " + DriverVersion + Environment.NewLine + "Manufacturer: " + Manufacturer + Environment.NewLine + "MaxRefreshRate: " + MaxRefreshRate + Environment.NewLine + "MinRefreshRate: " + MinRefreshRate + Environment.NewLine + "Name: " + Name + Environment.NewLine + "VideoModeDescription: " + VideoModeDescription + Environment.NewLine + "VideoProcessor: " + VideoProcessor + Environment.NewLine;
	}
}
