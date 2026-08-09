using System;
using System.Collections.Generic;

namespace Hardware.Info;

public class CPU
{
	public string Caption { get; set; } = string.Empty;

	public uint CurrentClockSpeed { get; set; }

	public string Description { get; set; } = string.Empty;

	public uint L1InstructionCacheSize { get; set; }

	public uint L1DataCacheSize { get; set; }

	public uint L2CacheSize { get; set; }

	public uint L3CacheSize { get; set; }

	public string Manufacturer { get; set; } = string.Empty;

	public uint MaxClockSpeed { get; set; }

	public string Name { get; set; } = string.Empty;

	public uint NumberOfCores { get; set; }

	public uint NumberOfLogicalProcessors { get; set; }

	public string ProcessorId { get; set; } = string.Empty;

	public bool SecondLevelAddressTranslationExtensions { get; set; }

	public string SocketDesignation { get; set; } = string.Empty;

	public bool VirtualizationFirmwareEnabled { get; set; }

	public bool VMMonitorModeExtensions { get; set; }

	public ulong PercentProcessorTime { get; set; }

	public List<CpuCore> CpuCoreList { get; set; } = new List<CpuCore>();

	public override string ToString()
	{
		return "Caption: " + Caption + Environment.NewLine + "CurrentClockSpeed: " + CurrentClockSpeed + Environment.NewLine + "Description: " + Description + Environment.NewLine + "L1InstructionCacheSize: " + L1InstructionCacheSize + Environment.NewLine + "L1DataCacheSize: " + L1DataCacheSize + Environment.NewLine + "L2CacheSize: " + L2CacheSize + Environment.NewLine + "L3CacheSize: " + L3CacheSize + Environment.NewLine + "Manufacturer: " + Manufacturer + Environment.NewLine + "MaxClockSpeed: " + MaxClockSpeed + Environment.NewLine + "Name: " + Name + Environment.NewLine + "NumberOfCores: " + NumberOfCores + Environment.NewLine + "NumberOfLogicalProcessors: " + NumberOfLogicalProcessors + Environment.NewLine + "PercentProcessorTime: " + PercentProcessorTime + Environment.NewLine + "ProcessorId: " + ProcessorId + Environment.NewLine + "SecondLevelAddressTranslationExtensions: " + SecondLevelAddressTranslationExtensions + Environment.NewLine + "SocketDesignation: " + SocketDesignation + Environment.NewLine + "VirtualizationFirmwareEnabled: " + VirtualizationFirmwareEnabled + Environment.NewLine + "VMMonitorModeExtensions: " + VMMonitorModeExtensions + Environment.NewLine;
	}
}
