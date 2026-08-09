using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Hardware.Info.Linux;

internal class HardwareInfoRetrieval : HardwareInfoBase, IHardwareInfoRetrieval
{
	private class Processor
	{
		public string ProcessorId = string.Empty;

		public string VendorId = string.Empty;

		public string ModelName = string.Empty;

		public uint CpuMhz;

		public uint CacheSize;

		public uint PhysicalId;

		public uint Siblings;

		public uint CoreId;

		public uint CpuCores;

		public uint L1DataCacheSize;

		public uint L1InstructionCacheSize;

		public uint L2CacheSize;

		public uint L3CacheSize;

		public ulong PercentProcessorTime;
	}

	private readonly MemoryStatus _memoryStatus = new MemoryStatus();

	private readonly OS _os = new OS();

	public OS GetOperatingSystem()
	{
		string[] array = HardwareInfoBase.TryReadLinesFromFile("/etc/os-release");
		foreach (string text in array)
		{
			if (text.StartsWith("NAME="))
			{
				_os.Name = text.Replace("NAME=", string.Empty).Trim(new char[1] { '"' });
			}
			if (text.StartsWith("VERSION_ID="))
			{
				_os.VersionString = text.Replace("VERSION_ID=", string.Empty).Trim(new char[1] { '"' });
				if (Version.TryParse(_os.VersionString, out Version result))
				{
					_os.Version = result;
				}
			}
		}
		return _os;
	}

	public MemoryStatus GetMemoryStatus()
	{
		string[] meminfo = HardwareInfoBase.TryReadLinesFromFile("/proc/meminfo");
		_memoryStatus.TotalPhysical = GetBytesFromLine(meminfo, "MemTotal:");
		_memoryStatus.AvailablePhysical = GetBytesFromLine(meminfo, "MemAvailable:");
		_memoryStatus.TotalVirtual = GetBytesFromLine(meminfo, "SwapTotal:");
		_memoryStatus.AvailableVirtual = GetBytesFromLine(meminfo, "SwapFree:");
		return _memoryStatus;
	}

	private ulong GetBytesFromLine(string[] meminfo, string token)
	{
		string text = meminfo.FirstOrDefault((string line) => line.StartsWith(token) && line.EndsWith("kB"));
		if (text != null && ulong.TryParse(text.Replace(token, string.Empty).Replace("kB", string.Empty).Trim(), out var result))
		{
			return result * 1024;
		}
		return 0uL;
	}

	public List<Battery> GetBatteryList()
	{
		List<Battery> list = new List<Battery>();
		for (int i = 0; i < 10; i++)
		{
			if (Directory.Exists($"/sys/class/power_supply/BAT{i}"))
			{
				uint num = HardwareInfoBase.TryReadIntegerFromFile($"/sys/class/power_supply/BAT{i}/power_now", $"/sys/class/power_supply/BAT{i}/voltage_now");
				uint designCapacity = HardwareInfoBase.TryReadIntegerFromFile($"/sys/class/power_supply/BAT{i}/energy_full_design", $"/sys/class/power_supply/BAT{i}/charge_full_design");
				uint num2 = HardwareInfoBase.TryReadIntegerFromFile($"/sys/class/power_supply/BAT{i}/energy_full", $"/sys/class/power_supply/BAT{i}/charge_full");
				uint num3 = HardwareInfoBase.TryReadIntegerFromFile($"/sys/class/power_supply/BAT{i}/energy_now", $"/sys/class/power_supply/BAT{i}/charge_now");
				if (num == 0)
				{
					num = 1u;
				}
				if (num2 == 0)
				{
					num2 = 1u;
				}
				Battery item = new Battery
				{
					DesignCapacity = designCapacity,
					FullChargeCapacity = num2,
					BatteryStatusDescription = HardwareInfoBase.TryReadTextFromFile($"/sys/class/power_supply/BAT{i}/status"),
					EstimatedChargeRemaining = (ushort)(num3 * 100 / num2),
					EstimatedRunTime = num3 / num,
					ExpectedLife = num2 / num,
					MaxRechargeTime = num2 / num,
					TimeToFullCharge = (num2 - num3) / num
				};
				list.Add(item);
			}
		}
		return list;
	}

	public List<BIOS> GetBiosList()
	{
		List<BIOS> list = new List<BIOS>();
		BIOS item = new BIOS
		{
			ReleaseDate = HardwareInfoBase.TryReadTextFromFile("/sys/class/dmi/id/bios_date"),
			Version = HardwareInfoBase.TryReadTextFromFile("/sys/class/dmi/id/bios_version"),
			Manufacturer = HardwareInfoBase.TryReadTextFromFile("/sys/class/dmi/id/bios_vendor")
		};
		list.Add(item);
		return list;
	}

	public List<ComputerSystem> GetComputerSystemList()
	{
		List<ComputerSystem> list = new List<ComputerSystem>();
		ComputerSystem item = new ComputerSystem
		{
			Caption = HardwareInfoBase.TryReadTextFromFile("/sys/class/dmi/id/product_name"),
			Description = HardwareInfoBase.TryReadTextFromFile("/sys/class/dmi/id/product_family"),
			IdentifyingNumber = HardwareInfoBase.TryReadTextFromFile("/sys/class/dmi/id/product_serial"),
			Name = HardwareInfoBase.TryReadTextFromFile("/sys/class/dmi/id/product_name"),
			SKUNumber = HardwareInfoBase.TryReadTextFromFile("/sys/class/dmi/id/product_sku"),
			UUID = HardwareInfoBase.TryReadTextFromFile("/sys/class/dmi/id/product_uuid"),
			Vendor = HardwareInfoBase.TryReadTextFromFile("/sys/class/dmi/id/sys_vendor"),
			Version = HardwareInfoBase.TryReadTextFromFile("/sys/class/dmi/id/product_version")
		};
		list.Add(item);
		return list;
	}

	public List<CPU> GetCpuList(bool includePercentProcessorTime = true, int millisecondsDelayBetweenTwoMeasurements = 500, bool includePerformanceCounter = true)
	{
		string[] array = HardwareInfoBase.TryReadLinesFromFile("/proc/cpuinfo");
		Regex regex = new Regex("^processor\\s+:\\s+(\\d+)");
		Regex regex2 = new Regex("^vendor_id\\s+:\\s+(.+)");
		Regex regex3 = new Regex("^model name\\s+:\\s+(.+)");
		Regex regex4 = new Regex("^cpu MHz\\s+:\\s+(.+)");
		Regex regex5 = new Regex("^cache size\\s+:\\s+(.+)\\s+KB");
		Regex regex6 = new Regex("^physical id\\s+:\\s+(\\d+)");
		Regex regex7 = new Regex("^siblings\\s+:\\s+(.+)");
		Regex regex8 = new Regex("^core id\\s+:\\s+(.+)");
		Regex regex9 = new Regex("^cpu cores\\s+:\\s+(.+)");
		List<Processor> list = new List<Processor>();
		Processor processor = null;
		string[] array2 = array;
		foreach (string input in array2)
		{
			Match match = regex.Match(input);
			if (match.Success && match.Groups.Count > 1)
			{
				processor = new Processor();
				if (uint.TryParse(match.Groups[1].Value, out var result))
				{
					processor.ProcessorId = $"cpu{result}";
					GetCpuCacheSize(processor);
					list.Add(processor);
				}
			}
			else
			{
				if (processor == null)
				{
					continue;
				}
				match = regex2.Match(input);
				if (match.Success && match.Groups.Count > 1)
				{
					processor.VendorId = match.Groups[1].Value.Trim();
					continue;
				}
				match = regex3.Match(input);
				if (match.Success && match.Groups.Count > 1)
				{
					processor.ModelName = match.Groups[1].Value.Trim();
					continue;
				}
				match = regex4.Match(input);
				if (match.Success && match.Groups.Count > 1)
				{
					if (double.TryParse(match.Groups[1].Value, out var result2))
					{
						processor.CpuMhz = (uint)result2;
					}
					continue;
				}
				match = regex5.Match(input);
				if (match.Success && match.Groups.Count > 1)
				{
					if (uint.TryParse(match.Groups[1].Value, out var result3))
					{
						processor.CacheSize = 1024 * result3;
					}
					continue;
				}
				match = regex6.Match(input);
				if (match.Success && match.Groups.Count > 1)
				{
					if (uint.TryParse(match.Groups[1].Value, out var result4))
					{
						processor.PhysicalId = result4;
					}
					continue;
				}
				match = regex7.Match(input);
				if (match.Success && match.Groups.Count > 1)
				{
					if (uint.TryParse(match.Groups[1].Value, out var result5))
					{
						processor.Siblings = result5;
					}
					continue;
				}
				match = regex8.Match(input);
				if (match.Success && match.Groups.Count > 1)
				{
					if (uint.TryParse(match.Groups[1].Value, out var result6))
					{
						processor.CoreId = result6;
					}
					continue;
				}
				match = regex9.Match(input);
				if (match.Success && match.Groups.Count > 1 && uint.TryParse(match.Groups[1].Value, out var result7))
				{
					processor.CpuCores = result7;
				}
			}
		}
		ulong percentProcessorTime = 0uL;
		if (includePercentProcessorTime)
		{
			percentProcessorTime = GetCpuUsage(list, millisecondsDelayBetweenTwoMeasurements);
		}
		List<CPU> list2 = new List<CPU>();
		foreach (IGrouping<uint, Processor> item2 in from processor3 in list
			group processor3 by processor3.PhysicalId)
		{
			Processor processor2 = item2.First();
			CPU cPU = new CPU
			{
				PercentProcessorTime = percentProcessorTime,
				ProcessorId = item2.Key.ToString(),
				Manufacturer = processor2.VendorId,
				Name = processor2.ModelName,
				CurrentClockSpeed = processor2.CpuMhz,
				NumberOfLogicalProcessors = processor2.Siblings,
				NumberOfCores = processor2.CpuCores,
				L1DataCacheSize = processor2.L1DataCacheSize,
				L1InstructionCacheSize = processor2.L1InstructionCacheSize,
				L2CacheSize = processor2.L2CacheSize,
				L3CacheSize = processor2.L3CacheSize
			};
			if (cPU.L2CacheSize == 0)
			{
				cPU.L2CacheSize = processor2.CacheSize;
			}
			foreach (Processor item3 in item2)
			{
				CpuCore item = new CpuCore
				{
					Name = item3.ProcessorId,
					PercentProcessorTime = item3.PercentProcessorTime
				};
				cPU.CpuCoreList.Add(item);
			}
			list2.Add(cPU);
		}
		return list2;
	}

	private static void GetCpuCacheSize(Processor processor)
	{
		for (int i = 0; i <= 3; i++)
		{
			string text = HardwareInfoBase.TryReadTextFromFile($"/sys/devices/system/cpu/{processor.ProcessorId}/cache/index{i}/level");
			string text2 = HardwareInfoBase.TryReadTextFromFile($"/sys/devices/system/cpu/{processor.ProcessorId}/cache/index{i}/type");
			if (!uint.TryParse(HardwareInfoBase.TryReadTextFromFile($"/sys/devices/system/cpu/{processor.ProcessorId}/cache/index{i}/size").TrimEnd(new char[1] { 'K' }), out var result))
			{
				continue;
			}
			result *= 1024;
			if (text == "1")
			{
				if (text2 == "Data")
				{
					processor.L1DataCacheSize = result;
				}
				if (text2 == "Instruction")
				{
					processor.L1InstructionCacheSize = result;
				}
			}
			if (text == "2")
			{
				processor.L2CacheSize = result;
			}
			if (text == "3")
			{
				processor.L3CacheSize = result;
			}
		}
	}

	private static ulong GetCpuUsage(List<Processor> processorList, int millisecondsDelayBetweenTwoMeasurements)
	{
		string[] array = HardwareInfoBase.TryReadLinesFromFile("/proc/stat");
		Task.Delay(millisecondsDelayBetweenTwoMeasurements).Wait();
		string[] array2 = HardwareInfoBase.TryReadLinesFromFile("/proc/stat");
		ulong result = 0uL;
		if (array.Length != 0 && array2.Length != 0)
		{
			result = GetCpuPercentage(array[0], array2[0]);
			foreach (Processor processor in processorList)
			{
				string text = array.FirstOrDefault((string s) => s.StartsWith(processor.ProcessorId));
				string text2 = array2.FirstOrDefault((string s) => s.StartsWith(processor.ProcessorId));
				if (!string.IsNullOrEmpty(text) && !string.IsNullOrEmpty(text2))
				{
					processor.PercentProcessorTime = GetCpuPercentage(text, text2);
				}
			}
		}
		return result;
	}

	private static ulong GetCpuPercentage(string cpuStatLast, string cpuStatNow)
	{
		char[] separator = new char[1] { ' ' };
		List<string> list = cpuStatNow.Split(separator, StringSplitOptions.RemoveEmptyEntries).ToList();
		list.RemoveAt(0);
		List<string> list2 = cpuStatLast.Split(separator, StringSplitOptions.RemoveEmptyEntries).ToList();
		list2.RemoveAt(0);
		ulong num = 0uL;
		foreach (string item in list)
		{
			if (ulong.TryParse(item, out var result))
			{
				num += result;
			}
		}
		ulong num2 = 0uL;
		foreach (string item2 in list2)
		{
			if (ulong.TryParse(item2, out var result2))
			{
				num2 += result2;
			}
		}
		ulong num3 = num - num2;
		if (num3 == 0L)
		{
			return 0uL;
		}
		ulong num4 = 0uL;
		if (list.Count > 3 && list2.Count > 3 && ulong.TryParse(list[3], out var result3) && ulong.TryParse(list2[3], out var result4))
		{
			num4 = result3 - result4;
		}
		ulong num5 = num3 - num4;
		return 100 * num5 / num3;
	}

	public override List<Drive> GetDriveList()
	{
		List<Drive> driveList = base.GetDriveList();
		string[] array = HardwareInfoBase.ReadProcessOutput("lshw", "-class disk").Split(new string[1] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
		Drive drive = null;
		string[] array2 = array;
		for (int i = 0; i < array2.Length; i++)
		{
			string text = array2[i].Trim();
			if (text.StartsWith("*-cdrom") || text.StartsWith("*-disk"))
			{
				if (driveList.Count > 0 && drive == null && text.StartsWith("*-disk"))
				{
					drive = driveList.First();
					continue;
				}
				drive = new Drive();
				driveList.Add(drive);
			}
			else if (drive != null)
			{
				if (text.StartsWith("product:"))
				{
					Drive drive2 = drive;
					string model = (drive.Caption = text.Replace("product:", string.Empty).Trim());
					drive2.Model = model;
				}
				else if (text.StartsWith("vendor:"))
				{
					drive.Manufacturer = text.Replace("vendor:", string.Empty).Trim();
				}
				else if (text.StartsWith("description:"))
				{
					drive.Description = text.Replace("description:", string.Empty).Trim();
				}
				else if (text.StartsWith("version:"))
				{
					drive.FirmwareRevision = text.Replace("version:", string.Empty).Trim();
				}
				else if (text.StartsWith("logical name:"))
				{
					drive.Name = text.Replace("logical name:", string.Empty).Trim();
				}
				else if (text.StartsWith("serial:"))
				{
					drive.SerialNumber = text.Replace("serial:", string.Empty).Trim();
				}
				else if (text.StartsWith("size:"))
				{
					string input = text.Replace("size:", string.Empty).Trim();
					drive.Size = ExtractSizeInBytes(input);
				}
			}
		}
		return driveList;
		static ulong ExtractSizeInBytes(string input2)
		{
			Match match = new Regex("(\\d+)\\s*(KB|MB|GB|TB)").Match(input2);
			if (match.Success && ulong.TryParse(match.Groups[1].Value, out var result))
			{
				return match.Groups[2].Value switch
				{
					"KB" => result * 1024, 
					"MB" => result * 1024 * 1024, 
					"GB" => result * 1024 * 1024 * 1024, 
					"TB" => result * 1024 * 1024 * 1024 * 1024, 
					_ => result, 
				};
			}
			return 0uL;
		}
	}

	public List<Keyboard> GetKeyboardList()
	{
		List<Keyboard> list = new List<Keyboard>();
		string[] array = HardwareInfoBase.TryReadLinesFromFile("/proc/bus/input/devices");
		foreach (string text in array)
		{
			if (text.StartsWith("N: Name=") && text.IndexOf("keyboard", StringComparison.OrdinalIgnoreCase) >= 0)
			{
				string[] array2 = text.Split(new char[1] { '"' });
				if (array2.Length > 1)
				{
					Keyboard item = new Keyboard
					{
						Caption = array2[1],
						Description = array2[1],
						Name = array2[1]
					};
					list.Add(item);
				}
			}
		}
		return list;
	}

	public List<Memory> GetMemoryList()
	{
		List<Memory> list = new List<Memory>();
		string[] array = HardwareInfoBase.ReadProcessOutput("lshw", "-short -C memory").Split(new string[1] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
		string[] names = Enum.GetNames(typeof(FormFactor));
		string[] array2 = array;
		for (int i = 0; i < array2.Length; i++)
		{
			string[] array3 = array2[i].Split(new string[1] { "memory" }, StringSplitOptions.RemoveEmptyEntries);
			if (array3.Length <= 1)
			{
				continue;
			}
			string text = array3[1].Trim();
			if (!text.Contains("DDR") && !text.Contains("DIMM") && !text.Contains("System"))
			{
				continue;
			}
			Memory memory = new Memory();
			string[] array4 = text.Split(new char[1] { ' ' });
			foreach (string part in array4)
			{
				Regex regex = new Regex("^([0-9]+)(K|M|G|T)iB");
				if (names.Any((string name) => name == part))
				{
					if (Enum.TryParse<FormFactor>(part, out var result))
					{
						memory.FormFactor = result;
					}
				}
				else if (new Regex("^[0-9]+$").IsMatch(part))
				{
					if (uint.TryParse(part, out var result2))
					{
						memory.Speed = result2;
					}
				}
				else if (regex.IsMatch(part))
				{
					Match match = regex.Match(part);
					if (match.Groups.Count > 2 && ulong.TryParse(match.Groups[1].Value, out var result3))
					{
						string value = match.Groups[2].Value;
						Memory memory2 = memory;
						memory2.Capacity = value switch
						{
							"T" => result3 * 1024 * 1024 * 1024 * 1024, 
							"G" => result3 * 1024 * 1024 * 1024, 
							"M" => result3 * 1024 * 1024, 
							"K" => result3 * 1024, 
							_ => result3, 
						};
					}
				}
			}
			list.Add(memory);
		}
		return list;
	}

	public List<Monitor> GetMonitorList()
	{
		List<Monitor> list = new List<Monitor>();
		Monitor item = new Monitor();
		list.Add(item);
		return list;
	}

	public List<Motherboard> GetMotherboardList()
	{
		List<Motherboard> list = new List<Motherboard>();
		Motherboard item = new Motherboard
		{
			Product = HardwareInfoBase.TryReadTextFromFile("/sys/class/dmi/id/board_name"),
			Manufacturer = HardwareInfoBase.TryReadTextFromFile("/sys/class/dmi/id/board_vendor"),
			SerialNumber = HardwareInfoBase.TryReadTextFromFile("/sys/class/dmi/id/board_serial")
		};
		list.Add(item);
		return list;
	}

	public List<Mouse> GetMouseList()
	{
		List<Mouse> list = new List<Mouse>();
		string[] array = HardwareInfoBase.TryReadLinesFromFile("/proc/bus/input/devices");
		foreach (string text in array)
		{
			if (text.StartsWith("N: Name=") && text.IndexOf("mouse", StringComparison.OrdinalIgnoreCase) >= 0)
			{
				string[] array2 = text.Split(new char[1] { '"' });
				if (array2.Length > 1)
				{
					Mouse item = new Mouse
					{
						Caption = array2[1],
						Description = array2[1],
						Name = array2[1]
					};
					list.Add(item);
				}
			}
		}
		return list;
	}

	private List<NetworkAdapter> GetNetworkAdapters()
	{
		List<NetworkAdapter> list = new List<NetworkAdapter>();
		string[] array = HardwareInfoBase.TryReadLinesFromFile("/proc/net/route");
		string[] fibTrieLines = HardwareInfoBase.TryReadLinesFromFile("/proc/net/fib_trie");
		foreach (string item2 in Directory.EnumerateDirectories("/sys/class/net"))
		{
			string fileName = Path.GetFileName(item2);
			string text = HardwareInfoBase.TryReadTextFromFile("/sys/class/net/" + fileName + "/address");
			NetworkAdapter networkAdapter = new NetworkAdapter
			{
				Caption = fileName,
				Description = fileName,
				Name = fileName,
				MACAddress = text.Replace(":", "").ToUpper(),
				NetConnectionID = fileName,
				ProductName = fileName
			};
			if (ulong.TryParse(HardwareInfoBase.TryReadTextFromFile("/sys/class/net/" + fileName + "/speed"), out var result))
			{
				networkAdapter.Speed = result;
			}
			string[] array2 = array;
			for (int i = 0; i < array2.Length; i++)
			{
				string[] array3 = array2[i].Split(new char[1] { '\t' });
				if (array3.Length < 8 || !(array3[0] == fileName))
				{
					continue;
				}
				if (array3[1] == "00000000" && array3[7] == "00000000")
				{
					byte[] bytes = BitConverter.GetBytes(Convert.ToInt32(array3[2], 16));
					Array.Reverse((Array)bytes);
					IPAddress item = new IPAddress(bytes);
					networkAdapter.DefaultIPGatewayList.Add(item);
				}
				if (array3[2] == "00000000" && array3[7] != "FFFFFFFF")
				{
					string network = HexToDecimalIP(array3[1]);
					string ipString = HexToDecimalIP(array3[7]);
					if (TryGetInterfaceIp(fibTrieLines, network, out string ip))
					{
						networkAdapter.IPAddressList.Add(IPAddress.Parse(ip));
						networkAdapter.IPSubnetList.Add(IPAddress.Parse(ipString));
					}
				}
			}
			list.Add(networkAdapter);
		}
		return list;
	}

	private string HexToDecimalIP(string hex)
	{
		return int.Parse(hex.Substring(6, 2), NumberStyles.HexNumber) + "." + int.Parse(hex.Substring(4, 2), NumberStyles.HexNumber) + "." + int.Parse(hex.Substring(2, 2), NumberStyles.HexNumber) + "." + int.Parse(hex.Substring(0, 2), NumberStyles.HexNumber);
	}

	private bool TryGetInterfaceIp(string[] fibTrieLines, string network, out string ip)
	{
		ip = string.Empty;
		bool flag = false;
		bool flag2 = false;
		bool result = false;
		foreach (string text in fibTrieLines)
		{
			if (text.StartsWith("Local"))
			{
				flag = true;
			}
			else
			{
				if (!flag)
				{
					continue;
				}
				if (text.Contains(network))
				{
					flag2 = true;
				}
				else if (flag2)
				{
					if (text.Contains("32 host"))
					{
						result = true;
						break;
					}
					string[] array = text.Split(new char[1] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
					ip = array[1];
				}
			}
		}
		return result;
	}

	public override List<NetworkAdapter> GetNetworkAdapterList(bool includeBytesPersec = true, bool includeNetworkAdapterConfiguration = true, int millisecondsDelayBetweenTwoMeasurements = 1000)
	{
		List<NetworkAdapter> networkAdapters = GetNetworkAdapters();
		if (includeBytesPersec)
		{
			char[] separator = new char[1] { ' ' };
			string[] source = HardwareInfoBase.TryReadLinesFromFile("/proc/net/dev");
			Task.Delay(millisecondsDelayBetweenTwoMeasurements).Wait();
			string[] source2 = HardwareInfoBase.TryReadLinesFromFile("/proc/net/dev");
			foreach (NetworkAdapter networkAdapter in networkAdapters)
			{
				List<string> list = source.FirstOrDefault((string l) => l.Trim().StartsWith(networkAdapter.Name))?.Trim().Split(separator, StringSplitOptions.RemoveEmptyEntries).ToList();
				List<string> list2 = source2.FirstOrDefault((string l) => l.Trim().StartsWith(networkAdapter.Name))?.Trim().Split(separator, StringSplitOptions.RemoveEmptyEntries).ToList();
				if (list != null && list2 != null)
				{
					if (list.Count > 1 && list2.Count > 1 && ulong.TryParse(list2[1], out var result) && ulong.TryParse(list[1], out var result2))
					{
						networkAdapter.BytesReceivedPersec = result - result2;
					}
					if (list.Count > 9 && list2.Count > 9 && ulong.TryParse(list2[9], out var result3) && ulong.TryParse(list[9], out var result4))
					{
						networkAdapter.BytesSentPersec = result3 - result4;
					}
				}
			}
		}
		return networkAdapters;
	}

	public List<Printer> GetPrinterList()
	{
		List<Printer> list = new List<Printer>();
		Printer item = new Printer();
		list.Add(item);
		return list;
	}

	public List<SoundDevice> GetSoundDeviceList()
	{
		List<SoundDevice> list = new List<SoundDevice>();
		string[] array = HardwareInfoBase.ReadProcessOutput("lspci", string.Empty).Split(new string[1] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
		foreach (string text in array)
		{
			if (text.Contains("Audio device") || text.Contains("Multimedia audio controller"))
			{
				string[] array2 = text.Split(new string[2] { "Audio device: ", "Multimedia audio controller: " }, StringSplitOptions.RemoveEmptyEntries);
				if (array2.Length > 1)
				{
					SoundDevice item = new SoundDevice
					{
						Caption = array2[1],
						Description = array2[1],
						Name = array2[1]
					};
					list.Add(item);
				}
			}
		}
		if (list.Count > 0)
		{
			return list;
		}
		array = HardwareInfoBase.TryReadLinesFromFile("/proc/asound/cards");
		foreach (string text2 in array)
		{
			if (text2.Contains(" at "))
			{
				string[] array3 = text2.Split(new string[1] { " at " }, StringSplitOptions.RemoveEmptyEntries);
				if (array3.Length != 0)
				{
					string text3 = array3[0].Trim();
					SoundDevice item2 = new SoundDevice
					{
						Caption = text3,
						Description = text3,
						Name = text3
					};
					list.Add(item2);
				}
			}
		}
		if (list.Count > 0)
		{
			return list;
		}
		array = HardwareInfoBase.ReadProcessOutput("aplay", "-l").Split(new string[1] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
		foreach (string text4 in array)
		{
			if (text4.StartsWith("card "))
			{
				string[] array4 = text4.Split(new char[1] { ':' });
				if (array4.Length != 0)
				{
					string text5 = array4[^1].Trim();
					SoundDevice item3 = new SoundDevice
					{
						Caption = text5,
						Description = text5,
						Name = text5
					};
					list.Add(item3);
				}
			}
		}
		return list;
	}

	public List<VideoController> GetVideoControllerList()
	{
		List<VideoController> list = new List<VideoController>();
		uint currentHorizontalResolution = 0u;
		uint currentVerticalResolution = 0u;
		uint currentRefreshRate = 0u;
		string[] array = HardwareInfoBase.ReadProcessOutput("xrandr", "-q").Split(new string[1] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
		foreach (string text in array)
		{
			if (!Enumerable.Contains(text, '*') || !Enumerable.Contains(text, 'x'))
			{
				continue;
			}
			string[] array2 = text.Split(new string[1] { " " }, StringSplitOptions.RemoveEmptyEntries);
			if (array2.Length <= 1)
			{
				continue;
			}
			string text2 = array2[0];
			if (Enumerable.Contains(text2, 'x'))
			{
				string[] array3 = text2.Split(new char[1] { 'x' });
				if (array3.Length > 1)
				{
					if (uint.TryParse(array3[0], out var result))
					{
						currentHorizontalResolution = result;
					}
					if (uint.TryParse(array3[1], out var result2))
					{
						currentVerticalResolution = result2;
					}
				}
			}
			if (double.TryParse(array2[1].Trim('*', '+'), out var result3))
			{
				currentRefreshRate = (uint)Math.Round(result3);
			}
		}
		foreach (string item2 in from l in HardwareInfoBase.ReadProcessOutput("lspci", string.Empty).Split(new string[1] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries)
			where l.Contains("VGA compatible controller") || l.Contains("3D controller") || l.Contains("Display controller")
			select l)
		{
			string[] array4 = item2.Split(new char[1] { ':' });
			if (array4.Length <= 2)
			{
				continue;
			}
			string text3 = array4[2].Trim();
			if (!string.IsNullOrWhiteSpace(text3))
			{
				string text4 = string.Empty;
				if (text3.Contains("Intel"))
				{
					text4 = "Intel Corporation";
				}
				else if (text3.Contains("AMD") || text3.Contains("Advanced Micro Devices") || text3.Contains("ATI"))
				{
					text4 = "Advanced Micro Devices, Inc.";
				}
				else if (text3.ToUpperInvariant().Contains("NVIDIA"))
				{
					text4 = "NVIDIA Corporation";
				}
				string text5 = text3.Replace("[AMD/ATI]", string.Empty);
				if (!string.IsNullOrEmpty(text4))
				{
					text5 = text5.Replace(text4, string.Empty);
				}
				VideoController item = new VideoController
				{
					Description = text3,
					Manufacturer = text4,
					Name = text5,
					CurrentHorizontalResolution = currentHorizontalResolution,
					CurrentVerticalResolution = currentVerticalResolution,
					CurrentRefreshRate = currentRefreshRate
				};
				list.Add(item);
			}
		}
		return list;
	}
}
