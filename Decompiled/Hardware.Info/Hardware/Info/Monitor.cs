using System;

namespace Hardware.Info;

public class Monitor
{
	public string Caption { get; set; } = string.Empty;

	public string Description { get; set; } = string.Empty;

	public string MonitorManufacturer { get; set; } = string.Empty;

	public string MonitorType { get; set; } = string.Empty;

	public string Name { get; set; } = string.Empty;

	public uint PixelsPerXLogicalInch { get; set; }

	public uint PixelsPerYLogicalInch { get; set; }

	public bool Active { get; set; }

	public string ManufacturerName { get; set; } = string.Empty;

	public string ProductCodeID { get; set; } = string.Empty;

	public string SerialNumberID { get; set; } = string.Empty;

	public string UserFriendlyName { get; set; } = string.Empty;

	public ushort WeekOfManufacture { get; set; }

	public ushort YearOfManufacture { get; set; }

	public override string ToString()
	{
		return "Caption: " + Caption + Environment.NewLine + "Description: " + Description + Environment.NewLine + "MonitorManufacturer: " + MonitorManufacturer + Environment.NewLine + "MonitorType: " + MonitorType + Environment.NewLine + "Name: " + Name + Environment.NewLine + "PixelsPerXLogicalInch: " + PixelsPerXLogicalInch + Environment.NewLine + "PixelsPerYLogicalInch: " + PixelsPerYLogicalInch + Environment.NewLine + "Active: " + Active + Environment.NewLine + "ManufacturerName: " + ManufacturerName + Environment.NewLine + "ProductCodeID: " + ProductCodeID + Environment.NewLine + "SerialNumberID: " + SerialNumberID + Environment.NewLine + "UserFriendlyName: " + UserFriendlyName + Environment.NewLine + "WeekOfManufacture: " + WeekOfManufacture + Environment.NewLine + "YearOfManufacture: " + YearOfManufacture + Environment.NewLine;
	}
}
