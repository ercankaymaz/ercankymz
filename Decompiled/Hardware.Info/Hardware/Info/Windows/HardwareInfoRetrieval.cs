using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Management;
using System.Net;
using System.Runtime.InteropServices;
using System.Security;
using System.Text;
using System.Threading;
using Microsoft.Win32;

namespace Hardware.Info.Windows;

internal class HardwareInfoRetrieval : HardwareInfoBase, IHardwareInfoRetrieval
{
	private struct OSVERSIONINFOEX
	{
		public uint dwOSVersionInfoSize;

		public uint dwMajorVersion;

		public uint dwMinorVersion;

		public uint dwBuildNumber;

		public uint dwPlatformId;

		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
		public string szCSDVersion;

		public ushort wServicePackMajor;

		public ushort wServicePackMinor;

		public ushort wSuiteMask;

		public byte wProductType;

		public byte wReserved;
	}

	private readonly MEMORYSTATUSEX _memoryStatusEx = new MEMORYSTATUSEX();

	private readonly MemoryStatus _memoryStatus = new MemoryStatus();

	private readonly OS _os = new OS();

	private readonly string _managementScope = "root\\cimv2";

	private readonly string _managementScopeWmi = "root\\wmi";

	private readonly EnumerationOptions _enumerationOptions = new EnumerationOptions
	{
		ReturnImmediately = true,
		Rewindable = false,
		Timeout = ManagementOptions.InfiniteTimeout
	};

	public HardwareInfoRetrieval(TimeSpan? enumerationOptionsTimeout = null)
	{
		if (!enumerationOptionsTimeout.HasValue)
		{
			enumerationOptionsTimeout = ManagementOptions.InfiniteTimeout;
		}
		_enumerationOptions = new EnumerationOptions
		{
			ReturnImmediately = true,
			Rewindable = false,
			Timeout = enumerationOptionsTimeout.Value
		};
		GetOs();
	}

	[DllImport("ntdll.dll", SetLastError = true)]
	private static extern int RtlGetVersion([In][Out] ref OSVERSIONINFOEX lpVersionInformation);

	public static Version? GetOsVersionByRtlGetVersion()
	{
		OSVERSIONINFOEX lpVersionInformation = default(OSVERSIONINFOEX);
		lpVersionInformation.dwOSVersionInfoSize = (uint)Marshal.SizeOf(lpVersionInformation);
		if (RtlGetVersion(ref lpVersionInformation) != 0)
		{
			return null;
		}
		return new Version((int)lpVersionInformation.dwMajorVersion, (int)lpVersionInformation.dwMinorVersion, (int)lpVersionInformation.dwBuildNumber);
	}

	public void GetOs()
	{
		string queryString = "SELECT Caption, Version FROM Win32_OperatingSystem";
		using ManagementObjectSearcher managementObjectSearcher = new ManagementObjectSearcher(_managementScope, queryString, _enumerationOptions);
		foreach (ManagementBaseObject item in managementObjectSearcher.Get())
		{
			_os.Name = GetPropertyString(item["Caption"]);
			_os.VersionString = GetPropertyString(item["Version"]);
			if (Version.TryParse(_os.VersionString, out Version result))
			{
				_os.Version = result;
			}
		}
		if (string.IsNullOrEmpty(_os.Name))
		{
			_os.Name = "Windows";
		}
		if (string.IsNullOrEmpty(_os.VersionString))
		{
			Version osVersionByRtlGetVersion = GetOsVersionByRtlGetVersion();
			if (osVersionByRtlGetVersion != null)
			{
				_os.Version = osVersionByRtlGetVersion;
				_os.VersionString = osVersionByRtlGetVersion.ToString();
			}
		}
	}

	public OS GetOperatingSystem()
	{
		return _os;
	}

	[DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
	[return: MarshalAs(UnmanagedType.Bool)]
	private static extern bool GlobalMemoryStatusEx([In][Out] MEMORYSTATUSEX lpBuffer);

	public MemoryStatus GetMemoryStatus()
	{
		if (GlobalMemoryStatusEx(_memoryStatusEx))
		{
			_memoryStatus.TotalPhysical = _memoryStatusEx.ullTotalPhys;
			_memoryStatus.AvailablePhysical = _memoryStatusEx.ullAvailPhys;
			_memoryStatus.TotalPageFile = _memoryStatusEx.ullTotalPageFile;
			_memoryStatus.AvailablePageFile = _memoryStatusEx.ullAvailPageFile;
			_memoryStatus.TotalVirtual = _memoryStatusEx.ullTotalVirtual;
			_memoryStatus.AvailableVirtual = _memoryStatusEx.ullAvailVirtual;
			_memoryStatus.AvailableExtendedVirtual = _memoryStatusEx.ullAvailExtendedVirtual;
		}
		return _memoryStatus;
	}

	public static T GetPropertyValue<T>(object obj) where T : struct
	{
		if (obj != null)
		{
			return (T)obj;
		}
		return default(T);
	}

	public static T[] GetPropertyArray<T>(object obj)
	{
		if (!(obj is T[] result))
		{
			return Array.Empty<T>();
		}
		return result;
	}

	public static string GetPropertyString(object obj)
	{
		if (!(obj is string result))
		{
			return string.Empty;
		}
		return result;
	}

	public static string GetStringFromUInt16Array(ushort[] array)
	{
		try
		{
			if (array.Length == 0)
			{
				return string.Empty;
			}
			byte[] array2 = new byte[array.Length * 2];
			Buffer.BlockCopy(array, 0, array2, 0, array2.Length);
			return Encoding.Unicode.GetString(array2).Trim(new char[1]);
		}
		catch
		{
			return string.Empty;
		}
	}

	public List<Battery> GetBatteryList()
	{
		List<Battery> list = new List<Battery>();
		string queryString = "SELECT FullChargeCapacity, DesignCapacity, BatteryStatus, EstimatedChargeRemaining, EstimatedRunTime, ExpectedLife, MaxRechargeTime, TimeOnBattery, TimeToFullCharge FROM Win32_Battery";
		using ManagementObjectSearcher managementObjectSearcher = new ManagementObjectSearcher(_managementScope, queryString, _enumerationOptions);
		foreach (ManagementBaseObject item2 in managementObjectSearcher.Get())
		{
			Battery item = new Battery
			{
				FullChargeCapacity = GetPropertyValue<uint>(item2["FullChargeCapacity"]),
				DesignCapacity = GetPropertyValue<uint>(item2["DesignCapacity"]),
				BatteryStatus = GetPropertyValue<ushort>(item2["BatteryStatus"]),
				EstimatedChargeRemaining = GetPropertyValue<ushort>(item2["EstimatedChargeRemaining"]),
				EstimatedRunTime = GetPropertyValue<uint>(item2["EstimatedRunTime"]),
				ExpectedLife = GetPropertyValue<uint>(item2["ExpectedLife"]),
				MaxRechargeTime = GetPropertyValue<uint>(item2["MaxRechargeTime"]),
				TimeOnBattery = GetPropertyValue<uint>(item2["TimeOnBattery"]),
				TimeToFullCharge = GetPropertyValue<uint>(item2["TimeToFullCharge"])
			};
			list.Add(item);
		}
		return list;
	}

	public List<BIOS> GetBiosList()
	{
		List<BIOS> list = new List<BIOS>();
		string queryString = "SELECT Caption, Description, Manufacturer, Name, ReleaseDate, SerialNumber, SoftwareElementID, Version FROM Win32_BIOS";
		using ManagementObjectSearcher managementObjectSearcher = new ManagementObjectSearcher(_managementScope, queryString, _enumerationOptions);
		foreach (ManagementBaseObject item2 in managementObjectSearcher.Get())
		{
			BIOS item = new BIOS
			{
				Caption = GetPropertyString(item2["Caption"]),
				Description = GetPropertyString(item2["Description"]),
				Manufacturer = GetPropertyString(item2["Manufacturer"]),
				Name = GetPropertyString(item2["Name"]),
				ReleaseDate = GetPropertyString(item2["ReleaseDate"]),
				SerialNumber = GetPropertyString(item2["SerialNumber"]),
				SoftwareElementID = GetPropertyString(item2["SoftwareElementID"]),
				Version = GetPropertyString(item2["Version"])
			};
			list.Add(item);
		}
		return list;
	}

	public List<ComputerSystem> GetComputerSystemList()
	{
		List<ComputerSystem> list = new List<ComputerSystem>();
		string queryString = "SELECT Caption, Description, IdentifyingNumber, Name, SKUNumber, UUID, Vendor, Version FROM Win32_ComputerSystemProduct";
		using ManagementObjectSearcher managementObjectSearcher = new ManagementObjectSearcher(_managementScope, queryString, _enumerationOptions);
		foreach (ManagementBaseObject item2 in managementObjectSearcher.Get())
		{
			ComputerSystem item = new ComputerSystem
			{
				Caption = GetPropertyString(item2["Caption"]),
				Description = GetPropertyString(item2["Description"]),
				IdentifyingNumber = GetPropertyString(item2["IdentifyingNumber"]),
				Name = GetPropertyString(item2["Name"]),
				SKUNumber = GetPropertyString(item2["SKUNumber"]),
				UUID = GetPropertyString(item2["UUID"]),
				Vendor = GetPropertyString(item2["Vendor"]),
				Version = GetPropertyString(item2["Version"])
			};
			list.Add(item);
		}
		return list;
	}

	public List<CPU> GetCpuList(bool includePercentProcessorTime = true, int millisecondsDelayBetweenTwoMeasurements = 500, bool includePerformanceCounter = true)
	{
		//IL_01f2: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f9: Expected O, but got Unknown
		List<CPU> list = new List<CPU>();
		List<CpuCore> list2 = new List<CpuCore>();
		ulong num = 0uL;
		if (includePercentProcessorTime)
		{
			string queryString = "SELECT Name, PercentProcessorTime FROM Win32_PerfFormattedData_PerfOS_Processor WHERE Name != '_Total'";
			ManagementObjectSearcher managementObjectSearcher = new ManagementObjectSearcher(_managementScope, queryString, _enumerationOptions);
			queryString = "SELECT PercentProcessorTime FROM Win32_PerfFormattedData_PerfOS_Processor WHERE Name = '_Total'";
			ManagementObjectSearcher managementObjectSearcher2 = new ManagementObjectSearcher(_managementScope, queryString, _enumerationOptions);
			try
			{
				foreach (ManagementBaseObject item2 in managementObjectSearcher.Get())
				{
					CpuCore item = new CpuCore
					{
						Name = GetPropertyString(item2["Name"]),
						PercentProcessorTime = GetPropertyValue<ulong>(item2["PercentProcessorTime"])
					};
					list2.Add(item);
				}
				foreach (ManagementBaseObject item3 in managementObjectSearcher2.Get())
				{
					num = GetPropertyValue<ulong>(item3["PercentProcessorTime"]);
				}
			}
			catch (ManagementException)
			{
			}
			finally
			{
				managementObjectSearcher.Dispose();
				managementObjectSearcher2.Dispose();
			}
			if (num == 0L)
			{
				queryString = "SELECT LoadPercentage FROM Win32_Processor";
				using ManagementObjectSearcher managementObjectSearcher3 = new ManagementObjectSearcher(_managementScope, queryString, _enumerationOptions);
				foreach (ManagementBaseObject item4 in managementObjectSearcher3.Get())
				{
					num = GetPropertyValue<ushort>(item4["LoadPercentage"]);
				}
			}
		}
		bool flag = (_os.Version.Major == 6 && _os.Version.Minor >= 2) || _os.Version.Major > 6;
		string queryString2 = (flag ? "SELECT Caption, CurrentClockSpeed, Description, L2CacheSize, L3CacheSize, Manufacturer, MaxClockSpeed, Name, NumberOfCores, NumberOfLogicalProcessors, ProcessorId, SecondLevelAddressTranslationExtensions, SocketDesignation, VirtualizationFirmwareEnabled, VMMonitorModeExtensions FROM Win32_Processor" : "SELECT Caption, CurrentClockSpeed, Description, L2CacheSize, L3CacheSize, Manufacturer, MaxClockSpeed, Name, NumberOfCores, NumberOfLogicalProcessors, ProcessorId, SocketDesignation FROM Win32_Processor");
		using ManagementObjectSearcher managementObjectSearcher4 = new ManagementObjectSearcher(_managementScope, queryString2, _enumerationOptions);
		float num2 = 100f;
		if (includePerformanceCounter)
		{
			try
			{
				PerformanceCounter val = new PerformanceCounter("Processor Information", "% Processor Performance", "_Total");
				try
				{
					num2 = val.NextValue();
					Thread.Sleep(1);
					num2 = val.NextValue();
				}
				finally
				{
					((IDisposable)val)?.Dispose();
				}
			}
			catch
			{
			}
		}
		uint num3 = 0u;
		uint num4 = 0u;
		queryString2 = "SELECT CacheType, MaxCacheSize FROM Win32_CacheMemory WHERE Level = 3";
		using ManagementObjectSearcher managementObjectSearcher5 = new ManagementObjectSearcher(_managementScope, queryString2, _enumerationOptions);
		foreach (ManagementObject item5 in managementObjectSearcher5.Get())
		{
			ushort propertyValue = GetPropertyValue<ushort>(item5["CacheType"]);
			uint num5 = 1024 * GetPropertyValue<uint>(item5["MaxCacheSize"]);
			if (num3 == 0)
			{
				num3 = num5;
			}
			if (num4 == 0)
			{
				num4 = num5;
			}
			if (propertyValue == 3)
			{
				num3 = num5;
			}
			if (propertyValue == 4)
			{
				num4 = num5;
			}
		}
		foreach (ManagementBaseObject item6 in managementObjectSearcher4.Get())
		{
			uint propertyValue2 = GetPropertyValue<uint>(item6["MaxClockSpeed"]);
			uint currentClockSpeed = (uint)((float)propertyValue2 * (num2 / 100f));
			CPU cPU = new CPU
			{
				Caption = GetPropertyString(item6["Caption"]),
				CurrentClockSpeed = currentClockSpeed,
				Description = GetPropertyString(item6["Description"]),
				L1InstructionCacheSize = num3,
				L1DataCacheSize = num4,
				L2CacheSize = 1024 * GetPropertyValue<uint>(item6["L2CacheSize"]),
				L3CacheSize = 1024 * GetPropertyValue<uint>(item6["L3CacheSize"]),
				Manufacturer = GetPropertyString(item6["Manufacturer"]),
				MaxClockSpeed = propertyValue2,
				Name = GetPropertyString(item6["Name"]),
				NumberOfCores = GetPropertyValue<uint>(item6["NumberOfCores"]),
				NumberOfLogicalProcessors = GetPropertyValue<uint>(item6["NumberOfLogicalProcessors"]),
				ProcessorId = GetPropertyString(item6["ProcessorId"]),
				SocketDesignation = GetPropertyString(item6["SocketDesignation"]),
				PercentProcessorTime = num,
				CpuCoreList = list2
			};
			if (flag)
			{
				cPU.SecondLevelAddressTranslationExtensions = GetPropertyValue<bool>(item6["SecondLevelAddressTranslationExtensions"]);
				cPU.VirtualizationFirmwareEnabled = GetPropertyValue<bool>(item6["VirtualizationFirmwareEnabled"]);
				cPU.VMMonitorModeExtensions = GetPropertyValue<bool>(item6["VMMonitorModeExtensions"]);
			}
			list.Add(cPU);
		}
		return list;
	}

	public override List<Drive> GetDriveList()
	{
		List<Drive> list = new List<Drive>();
		string queryString = "SELECT Caption, Description, DeviceID, FirmwareRevision, Index, Manufacturer, MediaType, Model, Name, Partitions, SerialNumber, Size FROM Win32_DiskDrive";
		using ManagementObjectSearcher managementObjectSearcher = new ManagementObjectSearcher(_managementScope, queryString, _enumerationOptions);
		foreach (ManagementBaseObject item2 in managementObjectSearcher.Get())
		{
			Drive drive = new Drive
			{
				Caption = GetPropertyString(item2["Caption"]),
				Description = GetPropertyString(item2["Description"]),
				FirmwareRevision = GetPropertyString(item2["FirmwareRevision"]),
				Index = GetPropertyValue<uint>(item2["Index"]),
				Manufacturer = GetPropertyString(item2["Manufacturer"]),
				MediaType = GetPropertyString(item2["MediaType"]),
				Model = GetPropertyString(item2["Model"]),
				Name = GetPropertyString(item2["Name"]),
				Partitions = GetPropertyValue<uint>(item2["Partitions"]),
				SerialNumber = GetPropertyString(item2["SerialNumber"]),
				Size = GetPropertyValue<ulong>(item2["Size"])
			};
			string queryString2 = "ASSOCIATORS OF {Win32_DiskDrive.DeviceID='" + item2["DeviceID"]?.ToString() + "'} WHERE AssocClass = Win32_DiskDriveToDiskPartition";
			using ManagementObjectSearcher managementObjectSearcher2 = new ManagementObjectSearcher(_managementScope, queryString2, _enumerationOptions);
			foreach (ManagementBaseObject item3 in managementObjectSearcher2.Get())
			{
				Partition partition = new Partition
				{
					Bootable = GetPropertyValue<bool>(item3["Bootable"]),
					BootPartition = GetPropertyValue<bool>(item3["BootPartition"]),
					Caption = GetPropertyString(item3["Caption"]),
					Description = GetPropertyString(item3["Description"]),
					DiskIndex = GetPropertyValue<uint>(item3["DiskIndex"]),
					Index = GetPropertyValue<uint>(item3["Index"]),
					Name = GetPropertyString(item3["Name"]),
					PrimaryPartition = GetPropertyValue<bool>(item3["PrimaryPartition"]),
					Size = GetPropertyValue<ulong>(item3["Size"]),
					StartingOffset = GetPropertyValue<ulong>(item3["StartingOffset"])
				};
				string queryString3 = "ASSOCIATORS OF {Win32_DiskPartition.DeviceID='" + item3["DeviceID"]?.ToString() + "'} WHERE AssocClass = Win32_LogicalDiskToPartition";
				using ManagementObjectSearcher managementObjectSearcher3 = new ManagementObjectSearcher(_managementScope, queryString3, _enumerationOptions);
				foreach (ManagementBaseObject item4 in managementObjectSearcher3.Get())
				{
					Volume item = new Volume
					{
						Caption = GetPropertyString(item4["Caption"]),
						Compressed = GetPropertyValue<bool>(item4["Compressed"]),
						Description = GetPropertyString(item4["Description"]),
						FileSystem = GetPropertyString(item4["FileSystem"]),
						FreeSpace = GetPropertyValue<ulong>(item4["FreeSpace"]),
						Name = GetPropertyString(item4["Name"]),
						Size = GetPropertyValue<ulong>(item4["Size"]),
						VolumeName = GetPropertyString(item4["VolumeName"]),
						VolumeSerialNumber = GetPropertyString(item4["VolumeSerialNumber"])
					};
					partition.VolumeList.Add(item);
				}
				drive.PartitionList.Add(partition);
			}
			list.Add(drive);
		}
		return list;
	}

	public List<Keyboard> GetKeyboardList()
	{
		List<Keyboard> list = new List<Keyboard>();
		string queryString = "SELECT Caption, Description, Name, NumberOfFunctionKeys FROM Win32_Keyboard";
		using ManagementObjectSearcher managementObjectSearcher = new ManagementObjectSearcher(_managementScope, queryString, _enumerationOptions);
		foreach (ManagementBaseObject item2 in managementObjectSearcher.Get())
		{
			Keyboard item = new Keyboard
			{
				Caption = GetPropertyString(item2["Caption"]),
				Description = GetPropertyString(item2["Description"]),
				Name = GetPropertyString(item2["Name"]),
				NumberOfFunctionKeys = GetPropertyValue<ushort>(item2["NumberOfFunctionKeys"])
			};
			list.Add(item);
		}
		return list;
	}

	public List<Memory> GetMemoryList()
	{
		List<Memory> list = new List<Memory>();
		string queryString = ((_os.Version.Major >= 10) ? "SELECT BankLabel, Capacity, FormFactor, Manufacturer, MaxVoltage, MinVoltage, PartNumber, SerialNumber, Speed FROM Win32_PhysicalMemory" : "SELECT BankLabel, Capacity, FormFactor, Manufacturer, PartNumber, SerialNumber, Speed FROM Win32_PhysicalMemory");
		using ManagementObjectSearcher managementObjectSearcher = new ManagementObjectSearcher(_managementScope, queryString, _enumerationOptions);
		foreach (ManagementBaseObject item in managementObjectSearcher.Get())
		{
			Memory memory = new Memory
			{
				BankLabel = GetPropertyString(item["BankLabel"]),
				Capacity = GetPropertyValue<ulong>(item["Capacity"]),
				FormFactor = (FormFactor)GetPropertyValue<ushort>(item["FormFactor"]),
				Manufacturer = GetPropertyString(item["Manufacturer"]),
				PartNumber = GetPropertyString(item["PartNumber"]),
				SerialNumber = GetPropertyString(item["SerialNumber"]),
				Speed = GetPropertyValue<uint>(item["Speed"])
			};
			if (_os.Version.Major >= 10)
			{
				memory.MaxVoltage = GetPropertyValue<uint>(item["MaxVoltage"]);
				memory.MinVoltage = GetPropertyValue<uint>(item["MinVoltage"]);
			}
			list.Add(memory);
		}
		return list;
	}

	public List<Monitor> GetMonitorList()
	{
		List<Monitor> list = new List<Monitor>();
		string queryString = "SELECT DeviceId FROM Win32_PnPEntity WHERE PNPClass='Monitor'";
		using ManagementObjectSearcher managementObjectSearcher = new ManagementObjectSearcher(_managementScope, queryString, _enumerationOptions);
		foreach (ManagementBaseObject item in managementObjectSearcher.Get())
		{
			try
			{
				string propertyString = GetPropertyString(item["DeviceId"]);
				string text = "SELECT Caption, Description, MonitorManufacturer, MonitorType, Name, PixelsPerXLogicalInch, PixelsPerYLogicalInch FROM Win32_DesktopMonitor WHERE PNPDeviceId='" + propertyString + "'";
				using ManagementObjectSearcher managementObjectSearcher2 = new ManagementObjectSearcher(_managementScope, text.Replace("\\", "\\\\"), _enumerationOptions);
				string text2 = "SELECT Active, ProductCodeID, SerialNumberID, ManufacturerName, UserFriendlyName, WeekOfManufacture, YearOfManufacture FROM WmiMonitorID WHERE InstanceName LIKE '" + propertyString + "%'";
				using ManagementObjectSearcher managementObjectSearcher3 = new ManagementObjectSearcher(_managementScopeWmi, text2.Replace("\\", "_"), _enumerationOptions);
				using ManagementBaseObject managementBaseObject = managementObjectSearcher2.Get().Cast<ManagementBaseObject>().FirstOrDefault();
				using ManagementBaseObject managementBaseObject2 = managementObjectSearcher3.Get().Cast<ManagementBaseObject>().FirstOrDefault();
				Monitor monitor = new Monitor();
				if (managementBaseObject != null)
				{
					monitor.Caption = GetPropertyString(managementBaseObject["Caption"]);
					monitor.Description = GetPropertyString(managementBaseObject["Description"]);
					monitor.MonitorManufacturer = GetPropertyString(managementBaseObject["MonitorManufacturer"]);
					monitor.MonitorType = GetPropertyString(managementBaseObject["MonitorType"]);
					monitor.Name = GetPropertyString(managementBaseObject["Name"]);
					monitor.PixelsPerXLogicalInch = GetPropertyValue<uint>(managementBaseObject["PixelsPerXLogicalInch"]);
					monitor.PixelsPerYLogicalInch = GetPropertyValue<uint>(managementBaseObject["PixelsPerYLogicalInch"]);
				}
				if (managementBaseObject2 != null)
				{
					monitor.Active = GetPropertyValue<bool>(managementBaseObject2["Active"]);
					monitor.ProductCodeID = GetStringFromUInt16Array(GetPropertyArray<ushort>(managementBaseObject2["ProductCodeID"]));
					monitor.UserFriendlyName = GetStringFromUInt16Array(GetPropertyArray<ushort>(managementBaseObject2["UserFriendlyName"]));
					monitor.SerialNumberID = GetStringFromUInt16Array(GetPropertyArray<ushort>(managementBaseObject2["SerialNumberID"]));
					monitor.ManufacturerName = GetStringFromUInt16Array(GetPropertyArray<ushort>(managementBaseObject2["ManufacturerName"]));
					monitor.WeekOfManufacture = GetPropertyValue<byte>(managementBaseObject2["WeekOfManufacture"]);
					monitor.YearOfManufacture = GetPropertyValue<ushort>(managementBaseObject2["YearOfManufacture"]);
				}
				list.Add(monitor);
			}
			catch (ManagementException)
			{
			}
		}
		return list;
	}

	public List<Motherboard> GetMotherboardList()
	{
		List<Motherboard> list = new List<Motherboard>();
		string queryString = "SELECT Manufacturer, Product, SerialNumber FROM Win32_BaseBoard";
		using ManagementObjectSearcher managementObjectSearcher = new ManagementObjectSearcher(_managementScope, queryString, _enumerationOptions);
		foreach (ManagementBaseObject item2 in managementObjectSearcher.Get())
		{
			Motherboard item = new Motherboard
			{
				Manufacturer = GetPropertyString(item2["Manufacturer"]),
				Product = GetPropertyString(item2["Product"]),
				SerialNumber = GetPropertyString(item2["SerialNumber"])
			};
			list.Add(item);
		}
		return list;
	}

	public List<Mouse> GetMouseList()
	{
		List<Mouse> list = new List<Mouse>();
		string queryString = "SELECT Caption, Description, Manufacturer, Name, NumberOfButtons FROM Win32_PointingDevice";
		using ManagementObjectSearcher managementObjectSearcher = new ManagementObjectSearcher(_managementScope, queryString, _enumerationOptions);
		foreach (ManagementBaseObject item2 in managementObjectSearcher.Get())
		{
			Mouse item = new Mouse
			{
				Caption = GetPropertyString(item2["Caption"]),
				Description = GetPropertyString(item2["Description"]),
				Manufacturer = GetPropertyString(item2["Manufacturer"]),
				Name = GetPropertyString(item2["Name"]),
				NumberOfButtons = GetPropertyValue<byte>(item2["NumberOfButtons"])
			};
			list.Add(item);
		}
		return list;
	}

	public override List<NetworkAdapter> GetNetworkAdapterList(bool includeBytesPersec = true, bool includeNetworkAdapterConfiguration = true, int millisecondsDelayBetweenTwoMeasurements = 1000)
	{
		List<NetworkAdapter> list = new List<NetworkAdapter>();
		string queryString = "SELECT AdapterType, Caption, Description, DeviceID, MACAddress, Manufacturer, Name, NetConnectionID, ProductName, Speed FROM Win32_NetworkAdapter WHERE PhysicalAdapter=True AND MACAddress IS NOT NULL";
		using ManagementObjectSearcher managementObjectSearcher = new ManagementObjectSearcher(_managementScope, queryString, _enumerationOptions);
		foreach (ManagementBaseObject item in managementObjectSearcher.Get())
		{
			NetworkAdapter networkAdapter = new NetworkAdapter
			{
				AdapterType = GetPropertyString(item["AdapterType"]),
				Caption = GetPropertyString(item["Caption"]),
				Description = GetPropertyString(item["Description"]),
				MACAddress = GetPropertyString(item["MACAddress"]),
				Manufacturer = GetPropertyString(item["Manufacturer"]),
				Name = GetPropertyString(item["Name"]),
				NetConnectionID = GetPropertyString(item["NetConnectionID"]),
				ProductName = GetPropertyString(item["ProductName"]),
				Speed = GetPropertyValue<ulong>(item["Speed"])
			};
			if (includeBytesPersec)
			{
				string text = networkAdapter.Name.Replace('(', '[').Replace(')', ']').Replace('#', '_')
					.Replace('\\', '_')
					.Replace('/', '_');
				string queryString2 = "SELECT BytesSentPersec, BytesReceivedPersec, CurrentBandwidth FROM Win32_PerfFormattedData_Tcpip_NetworkAdapter WHERE Name = '" + text + "'";
				using ManagementObjectSearcher managementObjectSearcher2 = new ManagementObjectSearcher(_managementScope, queryString2, _enumerationOptions);
				foreach (ManagementBaseObject item2 in managementObjectSearcher2.Get())
				{
					networkAdapter.BytesSentPersec = GetPropertyValue<ulong>(item2["BytesSentPersec"]);
					networkAdapter.BytesReceivedPersec = GetPropertyValue<ulong>(item2["BytesReceivedPersec"]);
					if (networkAdapter.Speed == 0L || networkAdapter.Speed == long.MaxValue)
					{
						networkAdapter.Speed = GetPropertyValue<ulong>(item2["CurrentBandwidth"]);
					}
				}
			}
			if (includeNetworkAdapterConfiguration && item is ManagementObject managementObject)
			{
				foreach (ManagementBaseObject item3 in managementObject.GetRelated("Win32_NetworkAdapterConfiguration"))
				{
					string[] propertyArray = GetPropertyArray<string>(item3["DefaultIPGateway"]);
					IPAddress address;
					for (int i = 0; i < propertyArray.Length; i++)
					{
						if (IPAddress.TryParse(propertyArray[i], out address))
						{
							networkAdapter.DefaultIPGatewayList.Add(address);
						}
					}
					if (IPAddress.TryParse(GetPropertyString(item3["DHCPServer"]), out address))
					{
						networkAdapter.DHCPServer = address;
					}
					propertyArray = GetPropertyArray<string>(item3["DNSServerSearchOrder"]);
					for (int i = 0; i < propertyArray.Length; i++)
					{
						if (IPAddress.TryParse(propertyArray[i], out address))
						{
							networkAdapter.DNSServerSearchOrderList.Add(address);
						}
					}
					propertyArray = GetPropertyArray<string>(item3["IPAddress"]);
					for (int i = 0; i < propertyArray.Length; i++)
					{
						if (IPAddress.TryParse(propertyArray[i], out address))
						{
							networkAdapter.IPAddressList.Add(address);
						}
					}
					propertyArray = GetPropertyArray<string>(item3["IPSubnet"]);
					for (int i = 0; i < propertyArray.Length; i++)
					{
						if (IPAddress.TryParse(propertyArray[i], out address))
						{
							networkAdapter.IPSubnetList.Add(address);
						}
					}
				}
			}
			list.Add(networkAdapter);
		}
		return list;
	}

	public List<Printer> GetPrinterList()
	{
		List<Printer> list = new List<Printer>();
		string queryString = "SELECT Caption, Default, Description, HorizontalResolution, Local, Name, Network, Shared, VerticalResolution FROM Win32_Printer";
		using ManagementObjectSearcher managementObjectSearcher = new ManagementObjectSearcher(_managementScope, queryString, _enumerationOptions);
		foreach (ManagementBaseObject item2 in managementObjectSearcher.Get())
		{
			Printer item = new Printer
			{
				Caption = GetPropertyString(item2["Caption"]),
				Default = GetPropertyValue<bool>(item2["Default"]),
				Description = GetPropertyString(item2["Description"]),
				HorizontalResolution = GetPropertyValue<uint>(item2["HorizontalResolution"]),
				Local = GetPropertyValue<bool>(item2["Local"]),
				Name = GetPropertyString(item2["Name"]),
				Network = GetPropertyValue<bool>(item2["Network"]),
				Shared = GetPropertyValue<bool>(item2["Shared"]),
				VerticalResolution = GetPropertyValue<uint>(item2["VerticalResolution"])
			};
			list.Add(item);
		}
		return list;
	}

	public List<SoundDevice> GetSoundDeviceList()
	{
		List<SoundDevice> list = new List<SoundDevice>();
		string queryString = "SELECT Caption, Description, Manufacturer, Name, ProductName FROM Win32_SoundDevice WHERE NOT Manufacturer='Microsoft'";
		using ManagementObjectSearcher managementObjectSearcher = new ManagementObjectSearcher(_managementScope, queryString, _enumerationOptions);
		foreach (ManagementBaseObject item2 in managementObjectSearcher.Get())
		{
			SoundDevice item = new SoundDevice
			{
				Caption = GetPropertyString(item2["Caption"]),
				Description = GetPropertyString(item2["Description"]),
				Manufacturer = GetPropertyString(item2["Manufacturer"]),
				Name = GetPropertyString(item2["Name"]),
				ProductName = GetPropertyString(item2["ProductName"])
			};
			list.Add(item);
		}
		return list;
	}

	public List<VideoController> GetVideoControllerList()
	{
		List<VideoController> list = new List<VideoController>();
		string queryString = "SELECT AdapterCompatibility, AdapterRAM, Caption, CurrentBitsPerPixel, CurrentHorizontalResolution, CurrentNumberOfColors, CurrentRefreshRate, CurrentVerticalResolution, Description, DriverDate, DriverVersion, MaxRefreshRate, MinRefreshRate, Name, PNPDeviceID, VideoModeDescription, VideoProcessor FROM Win32_VideoController";
		using ManagementObjectSearcher managementObjectSearcher = new ManagementObjectSearcher(_managementScope, queryString, _enumerationOptions);
		foreach (ManagementBaseObject item in managementObjectSearcher.Get())
		{
			VideoController videoController = new VideoController
			{
				Manufacturer = GetPropertyString(item["AdapterCompatibility"]),
				AdapterRAM = GetPropertyValue<uint>(item["AdapterRAM"]),
				Caption = GetPropertyString(item["Caption"]),
				CurrentBitsPerPixel = GetPropertyValue<uint>(item["CurrentBitsPerPixel"]),
				CurrentHorizontalResolution = GetPropertyValue<uint>(item["CurrentHorizontalResolution"]),
				CurrentNumberOfColors = GetPropertyValue<ulong>(item["CurrentNumberOfColors"]),
				CurrentRefreshRate = GetPropertyValue<uint>(item["CurrentRefreshRate"]),
				CurrentVerticalResolution = GetPropertyValue<uint>(item["CurrentVerticalResolution"]),
				Description = GetPropertyString(item["Description"]),
				DriverDate = GetPropertyString(item["DriverDate"]),
				DriverVersion = GetPropertyString(item["DriverVersion"]),
				MaxRefreshRate = GetPropertyValue<uint>(item["MaxRefreshRate"]),
				MinRefreshRate = GetPropertyValue<uint>(item["MinRefreshRate"]),
				Name = GetPropertyString(item["Name"]),
				VideoModeDescription = GetPropertyString(item["VideoModeDescription"]),
				VideoProcessor = GetPropertyString(item["VideoProcessor"])
			};
			try
			{
				string propertyString = GetPropertyString(item["PNPDeviceID"]);
				if (string.IsNullOrEmpty(propertyString))
				{
					continue;
				}
				if (Registry.GetValue("HKEY_LOCAL_MACHINE\\SYSTEM\\CurrentControlSet\\Enum\\" + propertyString, "Driver", (object)null) is string text && !string.IsNullOrEmpty(text) && Registry.GetValue("HKEY_LOCAL_MACHINE\\SYSTEM\\CurrentControlSet\\Control\\Class\\" + text, "HardwareInformation.qwMemorySize", (object)0L) is long num && num != 0L)
				{
					videoController.AdapterRAM = (ulong)num;
				}
				goto IL_023f;
			}
			catch (SecurityException)
			{
				goto IL_023f;
			}
			catch (UnauthorizedAccessException)
			{
				goto IL_023f;
			}
			IL_023f:
			list.Add(videoController);
		}
		return list;
	}
}
