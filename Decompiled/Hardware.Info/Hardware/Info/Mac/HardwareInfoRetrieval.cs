using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
using System.Threading;

namespace Hardware.Info.Mac;

internal class HardwareInfoRetrieval : HardwareInfoBase, IHardwareInfoRetrieval
{
	private readonly MemoryStatus _memoryStatus = new MemoryStatus();

	private readonly OS _os = new OS();

	public OS GetOperatingSystem()
	{
		_os.Name = HardwareInfoBase.ReadProcessOutput("sw_vers", "-productName");
		_os.VersionString = HardwareInfoBase.ReadProcessOutput("sw_vers", "-productVersion");
		if (Version.TryParse(_os.VersionString, out Version result))
		{
			_os.Version = result;
		}
		return _os;
	}

	[DllImport("libc")]
	private static extern int sysctlbyname(string name, out IntPtr oldp, ref IntPtr oldlenp, IntPtr newp, IntPtr newlen);

	private bool StartProcess(string fileName, string arguments, Action<string> output, Action<string> error, int millisecondsTimeout = 60000)
	{
		using Process process = new Process();
		process.StartInfo.FileName = fileName;
		process.StartInfo.Arguments = arguments;
		process.StartInfo.CreateNoWindow = true;
		process.StartInfo.UseShellExecute = false;
		process.StartInfo.RedirectStandardOutput = true;
		process.StartInfo.RedirectStandardError = true;
		AutoResetEvent outputWaitHandle = new AutoResetEvent(initialState: false);
		try
		{
			AutoResetEvent errorWaitHandle = new AutoResetEvent(initialState: false);
			try
			{
				process.OutputDataReceived += delegate(object sender, DataReceivedEventArgs e)
				{
					if (e.Data == null)
					{
						outputWaitHandle.Set();
					}
					else
					{
						output(e.Data);
					}
				};
				process.ErrorDataReceived += delegate(object sender, DataReceivedEventArgs e)
				{
					if (e.Data == null)
					{
						errorWaitHandle.Set();
					}
					else
					{
						error(e.Data);
					}
				};
				process.Start();
				process.BeginOutputReadLine();
				process.BeginErrorReadLine();
				return process.WaitForExit(millisecondsTimeout) && outputWaitHandle.WaitOne(millisecondsTimeout) && errorWaitHandle.WaitOne(millisecondsTimeout);
			}
			finally
			{
				if (errorWaitHandle != null)
				{
					((IDisposable)errorWaitHandle).Dispose();
				}
			}
		}
		finally
		{
			if (outputWaitHandle != null)
			{
				((IDisposable)outputWaitHandle).Dispose();
			}
		}
	}

	public MemoryStatus GetMemoryStatus()
	{
		IntPtr oldlenp = (IntPtr)IntPtr.Size;
		if (sysctlbyname("hw.memsize", out var oldp, ref oldlenp, IntPtr.Zero, IntPtr.Zero) == 0)
		{
			_memoryStatus.TotalPhysical = (ulong)oldp.ToInt64();
		}
		return _memoryStatus;
	}

	public List<Battery> GetBatteryList()
	{
		List<Battery> list = new List<Battery>();
		Battery battery = new Battery();
		string input = HardwareInfoBase.ReadProcessOutput("pmset", "-g batt");
		Match match = new Regex("(\\d+)%").Match(input);
		if (match.Success && match.Groups.Count > 1 && ushort.TryParse(match.Groups[1].Value, out var result))
		{
			battery.EstimatedChargeRemaining = result;
		}
		match = new Regex("(\\d+:\\d+)").Match(input);
		if (match.Success && match.Groups.Count > 1)
		{
			string[] array = match.Groups[1].Value.Split(new char[1] { ':' });
			if (array.Length == 2 && uint.TryParse(array[0], out var result2) && uint.TryParse(array[1], out var result3))
			{
				battery.EstimatedRunTime = result2 * 60 + result3;
			}
		}
		list.Add(battery);
		return list;
	}

	public List<BIOS> GetBiosList()
	{
		List<BIOS> list = new List<BIOS>();
		BIOS item = new BIOS();
		list.Add(item);
		return list;
	}

	public List<ComputerSystem> GetComputerSystemList()
	{
		List<ComputerSystem> list = new List<ComputerSystem>();
		ComputerSystem computerSystem = new ComputerSystem
		{
			Vendor = "Apple"
		};
		StartProcess("system_profiler", "SPHardwareDataType", delegate(string standardOutput)
		{
			string text = standardOutput.Trim();
			if (text.StartsWith("Model Name: "))
			{
				computerSystem.Caption = text.Replace("Model Name: ", string.Empty);
				computerSystem.Name = text.Replace("Model Name: ", string.Empty);
			}
			else if (text.StartsWith("Model Identifier: "))
			{
				computerSystem.Description = text.Replace("Model Identifier: ", string.Empty);
			}
			else if (text.StartsWith("Serial Number (system): "))
			{
				computerSystem.IdentifyingNumber = text.Replace("Serial Number (system): ", string.Empty);
			}
			else if (text.StartsWith("Model Number: "))
			{
				computerSystem.SKUNumber = text.Replace("Model Number: ", string.Empty);
			}
			else if (text.StartsWith("Hardware UUID: "))
			{
				computerSystem.UUID = text.Replace("Hardware UUID: ", string.Empty);
			}
			else if (text.StartsWith("System Firmware Version: "))
			{
				computerSystem.Version = text.Replace("System Firmware Version: ", string.Empty);
			}
		}, delegate
		{
		});
		list.Add(computerSystem);
		return list;
	}

	public List<CPU> GetCpuList(bool includePercentProcessorTime = true, int millisecondsDelayBetweenTwoMeasurements = 500, bool includePerformanceCounter = true)
	{
		List<CPU> list = new List<CPU>();
		string s = HardwareInfoBase.ReadProcessOutput("sysctl", "-n hw.nperflevels");
		if (uint.TryParse(s, out var result) && result > 1)
		{
			for (int i = 0; i < result; i++)
			{
				string text = "perflevel" + i;
				CPU cPU = new CPU();
				cPU.Caption = i.ToString();
				cPU.Description = text;
				s = HardwareInfoBase.ReadProcessOutput("sysctl", "-n machdep.cpu.brand_string");
				cPU.Name = s.Split(new char[1] { '@' })[0].Trim();
				s = HardwareInfoBase.ReadProcessOutput("sysctl", "-n hw.cpufrequency_max");
				if (uint.TryParse(s, out var result2))
				{
					cPU.MaxClockSpeed = result2 / 1000000;
				}
				s = HardwareInfoBase.ReadProcessOutput("sysctl", "-n hw.cpufrequency");
				if (uint.TryParse(s, out var result3))
				{
					cPU.CurrentClockSpeed = result3 / 1000000;
				}
				s = HardwareInfoBase.ReadProcessOutput("sysctl", "-n hw." + text + ".l1icachesize");
				if (uint.TryParse(s, out var result4))
				{
					cPU.L1InstructionCacheSize = result4;
				}
				s = HardwareInfoBase.ReadProcessOutput("sysctl", "-n hw." + text + ".l1dcachesize");
				if (uint.TryParse(s, out var result5))
				{
					cPU.L1DataCacheSize = result5;
				}
				s = HardwareInfoBase.ReadProcessOutput("sysctl", "-n hw." + text + ".l2cachesize");
				if (uint.TryParse(s, out var result6))
				{
					cPU.L2CacheSize = result6;
				}
				s = HardwareInfoBase.ReadProcessOutput("sysctl", "-n hw." + text + ".l3cachesize");
				if (uint.TryParse(s, out var result7))
				{
					cPU.L3CacheSize = result7;
				}
				s = HardwareInfoBase.ReadProcessOutput("sysctl", "-n hw." + text + ".physicalcpu");
				if (uint.TryParse(s, out var result8))
				{
					cPU.NumberOfCores = result8;
				}
				s = HardwareInfoBase.ReadProcessOutput("sysctl", "-n hw." + text + ".logicalcpu");
				if (uint.TryParse(s, out var result9))
				{
					cPU.NumberOfLogicalProcessors = result9;
				}
				list.Add(cPU);
			}
		}
		else
		{
			CPU cPU2 = new CPU();
			s = HardwareInfoBase.ReadProcessOutput("sysctl", "-n machdep.cpu.brand_string");
			cPU2.Name = s.Split(new char[1] { '@' })[0].Trim();
			s = HardwareInfoBase.ReadProcessOutput("sysctl", "-n hw.cpufrequency_max");
			if (uint.TryParse(s, out var result10))
			{
				cPU2.MaxClockSpeed = result10 / 1000000;
			}
			s = HardwareInfoBase.ReadProcessOutput("sysctl", "-n hw.cpufrequency");
			if (uint.TryParse(s, out var result11))
			{
				cPU2.CurrentClockSpeed = result11 / 1000000;
			}
			s = HardwareInfoBase.ReadProcessOutput("sysctl", "-n hw.l1icachesize");
			if (uint.TryParse(s, out var result12))
			{
				cPU2.L1InstructionCacheSize = result12;
			}
			s = HardwareInfoBase.ReadProcessOutput("sysctl", "-n hw.l1dcachesize");
			if (uint.TryParse(s, out var result13))
			{
				cPU2.L1DataCacheSize = result13;
			}
			s = HardwareInfoBase.ReadProcessOutput("sysctl", "-n hw.l2cachesize");
			if (uint.TryParse(s, out var result14))
			{
				cPU2.L2CacheSize = result14;
			}
			s = HardwareInfoBase.ReadProcessOutput("sysctl", "-n hw.l3cachesize");
			if (uint.TryParse(s, out var result15))
			{
				cPU2.L3CacheSize = result15;
			}
			s = HardwareInfoBase.ReadProcessOutput("sysctl", "-n hw.physicalcpu");
			if (uint.TryParse(s, out var result16))
			{
				cPU2.NumberOfCores = result16;
			}
			s = HardwareInfoBase.ReadProcessOutput("sysctl", "-n hw.logicalcpu");
			if (uint.TryParse(s, out var result17))
			{
				cPU2.NumberOfLogicalProcessors = result17;
			}
			list.Add(cPU2);
		}
		return list;
	}

	public override List<Drive> GetDriveList()
	{
		return base.GetDriveList();
	}

	public List<Keyboard> GetKeyboardList()
	{
		List<Keyboard> list = new List<Keyboard>();
		Keyboard item = new Keyboard();
		list.Add(item);
		return list;
	}

	public List<Memory> GetMemoryList()
	{
		List<Memory> memoryList = new List<Memory>();
		Memory memory = null;
		StartProcess("system_profiler", "SPMemoryDataType", delegate(string standardOutput)
		{
			string text = standardOutput.Trim();
			string[] array = text.Split(new char[1] { ' ' });
			if (text.StartsWith("Bank"))
			{
				if (memory != null)
				{
					memoryList.Add(memory);
				}
				memory = new Memory();
			}
			if (memory != null)
			{
				if (text.StartsWith("Size:") && array.Length == 3 && ulong.TryParse(array[1], out var result))
				{
					Memory memory2 = memory;
					memory2.Capacity = array[2] switch
					{
						"TB" => result * 1024 * 1024 * 1024 * 1024, 
						"GB" => result * 1024 * 1024 * 1024, 
						"MB" => result * 1024 * 1024, 
						"KB" => result * 1024, 
						_ => result, 
					};
				}
				if (text.StartsWith("Type:") && array.Length == 2 && Enum.TryParse<FormFactor>(array[1], out var result2))
				{
					memory.FormFactor = result2;
				}
				if (text.StartsWith("Speed:") && array.Length == 3 && uint.TryParse(array[1], out var result3))
				{
					memory.Speed = result3;
				}
				if (text.StartsWith("Manufacturer: "))
				{
					memory.Manufacturer = text.Replace("Manufacturer: ", string.Empty);
				}
				if (text.StartsWith("Part Number: "))
				{
					memory.PartNumber = text.Replace("Part Number: ", string.Empty);
				}
				if (text.StartsWith("Serial Number: "))
				{
					memory.SerialNumber = text.Replace("Serial Number: ", string.Empty);
				}
			}
		}, delegate
		{
		});
		if (memory != null)
		{
			memoryList.Add(memory);
		}
		return memoryList;
	}

	public List<Monitor> GetMonitorList()
	{
		List<Monitor> monitorList = new List<Monitor>();
		Monitor monitor = null;
		StartProcess("system_profiler", "SPDisplaysDataType", delegate(string standardOutput)
		{
			int num = standardOutput.TakeWhile((char c) => c == ' ').Count();
			string text = standardOutput.Trim();
			text.Split(new char[1] { ':' });
			if (num == 8)
			{
				if (monitor != null)
				{
					monitorList.Add(monitor);
				}
				string text2 = text.TrimEnd(new char[1] { ':' });
				monitor = new Monitor
				{
					Caption = text2,
					Description = text2,
					Name = text2
				};
			}
			if (monitor != null && text.StartsWith("Display Type: "))
			{
				monitor.MonitorType = text.Replace("Display Type: ", string.Empty);
			}
		}, delegate
		{
		});
		if (monitor != null)
		{
			monitorList.Add(monitor);
		}
		return monitorList;
	}

	public List<Motherboard> GetMotherboardList()
	{
		List<Motherboard> list = new List<Motherboard>();
		Motherboard item = new Motherboard();
		list.Add(item);
		return list;
	}

	public List<Mouse> GetMouseList()
	{
		List<Mouse> list = new List<Mouse>();
		Mouse item = new Mouse();
		list.Add(item);
		return list;
	}

	public override List<NetworkAdapter> GetNetworkAdapterList(bool includeBytesPersec = true, bool includeNetworkAdapterConfiguration = true, int millisecondsDelayBetweenTwoMeasurements = 1000)
	{
		return base.GetNetworkAdapterList(includeBytesPersec, includeNetworkAdapterConfiguration);
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
		SoundDevice item = new SoundDevice();
		list.Add(item);
		return list;
	}

	public List<VideoController> GetVideoControllerList()
	{
		List<VideoController> videoControllerList = new List<VideoController>();
		VideoController videoController = null;
		StartProcess("system_profiler", "SPDisplaysDataType", delegate(string standardOutput)
		{
			int num = standardOutput.TakeWhile((char c) => c == ' ').Count();
			string text = standardOutput.Trim();
			if (num == 4)
			{
				if (videoController != null)
				{
					videoControllerList.Add(videoController);
				}
				string text2 = text.TrimEnd(new char[1] { ':' });
				videoController = new VideoController
				{
					Caption = text2,
					Description = text2,
					Name = text2
				};
			}
			if (videoController != null)
			{
				if (text.StartsWith("Chipset Model: "))
				{
					videoController.VideoProcessor = text.Replace("Chipset Model: ", string.Empty);
				}
				if (text.StartsWith("VRAM "))
				{
					string[] array = text.Split(new char[1] { ':' });
					if (array.Length == 2 && ulong.TryParse(array[1].Replace("MB", string.Empty).Trim(), out var result))
					{
						videoController.AdapterRAM = 1048576 * result;
					}
				}
				if (text.StartsWith("Vendor: "))
				{
					videoController.Manufacturer = text.Replace("Vendor: ", string.Empty);
				}
				if (text.StartsWith("Resolution: "))
				{
					string[] array2 = text.Replace("Resolution: ", string.Empty).Split(new char[1] { ' ' });
					if (array2.Length >= 3)
					{
						if (uint.TryParse(array2[0].Trim(), out var result2))
						{
							videoController.CurrentHorizontalResolution = result2;
						}
						if (uint.TryParse(array2[2].Trim(), out var result3))
						{
							videoController.CurrentVerticalResolution = result3;
						}
					}
				}
				if (text.StartsWith("UI Looks like: "))
				{
					string[] array3 = text.Split(new char[1] { '@' });
					if (array3.Length == 2 && uint.TryParse(array3[1].Replace("Hz", string.Empty).Trim(), out var result4))
					{
						videoController.CurrentRefreshRate = result4;
					}
				}
				if (text.StartsWith("Framebuffer Depth: "))
				{
					string[] array4 = text.Replace("Framebuffer Depth: ", string.Empty).Split(new char[1] { '-' });
					if (array4.Length == 2 && uint.TryParse(array4[0].Trim(), out var result5))
					{
						videoController.CurrentBitsPerPixel = result5;
					}
				}
				if (text.StartsWith("Pixel Depth: "))
				{
					string[] array5 = text.Replace("Pixel Depth: ", string.Empty).Split(new char[1] { '-' });
					if (array5.Length == 2 && uint.TryParse(array5[0].Trim(), out var result6))
					{
						videoController.CurrentBitsPerPixel = result6;
					}
				}
			}
		}, delegate
		{
		});
		if (videoController != null)
		{
			videoControllerList.Add(videoController);
		}
		return videoControllerList;
	}
}
