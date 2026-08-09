using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using Hardware.Info.Linux;
using Hardware.Info.Mac;
using Hardware.Info.Windows;

namespace Hardware.Info;

public class HardwareInfo : IHardwareInfo
{
	private readonly IHardwareInfoRetrieval _hardwareInfoRetrieval;

	private static bool _pingInProgress;

	private static Action<bool>? _onPingComplete;

	public OS OperatingSystem { get; private set; } = new OS();

	public MemoryStatus MemoryStatus { get; private set; } = new MemoryStatus();

	public List<Battery> BatteryList { get; private set; } = new List<Battery>();

	public List<BIOS> BiosList { get; private set; } = new List<BIOS>();

	public List<ComputerSystem> ComputerSystemList { get; private set; } = new List<ComputerSystem>();

	public List<CPU> CpuList { get; private set; } = new List<CPU>();

	public List<Drive> DriveList { get; private set; } = new List<Drive>();

	public List<Keyboard> KeyboardList { get; private set; } = new List<Keyboard>();

	public List<Memory> MemoryList { get; private set; } = new List<Memory>();

	public List<Monitor> MonitorList { get; private set; } = new List<Monitor>();

	public List<Motherboard> MotherboardList { get; private set; } = new List<Motherboard>();

	public List<Mouse> MouseList { get; private set; } = new List<Mouse>();

	public List<NetworkAdapter> NetworkAdapterList { get; private set; } = new List<NetworkAdapter>();

	public List<Printer> PrinterList { get; private set; } = new List<Printer>();

	public List<SoundDevice> SoundDeviceList { get; private set; } = new List<SoundDevice>();

	public List<VideoController> VideoControllerList { get; private set; } = new List<VideoController>();

	public HardwareInfo(TimeSpan? timeoutInWMI = null)
	{
		if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
		{
			_hardwareInfoRetrieval = new Hardware.Info.Windows.HardwareInfoRetrieval(timeoutInWMI);
		}
		if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
		{
			_hardwareInfoRetrieval = new Hardware.Info.Mac.HardwareInfoRetrieval();
		}
		if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
		{
			_hardwareInfoRetrieval = new Hardware.Info.Linux.HardwareInfoRetrieval();
		}
	}

	public void RefreshAll()
	{
		RefreshOperatingSystem();
		RefreshMemoryStatus();
		RefreshBatteryList();
		RefreshBIOSList();
		RefreshComputerSystemList();
		RefreshCPUList();
		RefreshDriveList();
		RefreshKeyboardList();
		RefreshMemoryList();
		RefreshMonitorList();
		RefreshMotherboardList();
		RefreshMouseList();
		RefreshNetworkAdapterList();
		RefreshPrinterList();
		RefreshSoundDeviceList();
		RefreshVideoControllerList();
	}

	public void RefreshOperatingSystem()
	{
		OperatingSystem = _hardwareInfoRetrieval.GetOperatingSystem();
	}

	public void RefreshMemoryStatus()
	{
		MemoryStatus = _hardwareInfoRetrieval.GetMemoryStatus();
	}

	public void RefreshBatteryList()
	{
		BatteryList = _hardwareInfoRetrieval.GetBatteryList();
	}

	public void RefreshBIOSList()
	{
		BiosList = _hardwareInfoRetrieval.GetBiosList();
	}

	public void RefreshComputerSystemList()
	{
		ComputerSystemList = _hardwareInfoRetrieval.GetComputerSystemList();
	}

	public void RefreshCPUList(bool includePercentProcessorTime = true, int millisecondsDelayBetweenTwoMeasurements = 500, bool includePerformanceCounter = true)
	{
		CpuList = _hardwareInfoRetrieval.GetCpuList(includePercentProcessorTime, millisecondsDelayBetweenTwoMeasurements, includePerformanceCounter);
	}

	public void RefreshDriveList()
	{
		DriveList = _hardwareInfoRetrieval.GetDriveList();
	}

	public void RefreshKeyboardList()
	{
		KeyboardList = _hardwareInfoRetrieval.GetKeyboardList();
	}

	public void RefreshMemoryList()
	{
		MemoryList = _hardwareInfoRetrieval.GetMemoryList();
	}

	public void RefreshMonitorList()
	{
		MonitorList = _hardwareInfoRetrieval.GetMonitorList();
	}

	public void RefreshMotherboardList()
	{
		MotherboardList = _hardwareInfoRetrieval.GetMotherboardList();
	}

	public void RefreshMouseList()
	{
		MouseList = _hardwareInfoRetrieval.GetMouseList();
	}

	public void RefreshNetworkAdapterList(bool includeBytesPerSec = true, bool includeNetworkAdapterConfiguration = true, int millisecondsDelayBetweenTwoMeasurements = 1000)
	{
		NetworkAdapterList = _hardwareInfoRetrieval.GetNetworkAdapterList(includeBytesPerSec, includeNetworkAdapterConfiguration, millisecondsDelayBetweenTwoMeasurements);
	}

	public void RefreshPrinterList()
	{
		PrinterList = _hardwareInfoRetrieval.GetPrinterList();
	}

	public void RefreshSoundDeviceList()
	{
		SoundDeviceList = _hardwareInfoRetrieval.GetSoundDeviceList();
	}

	public void RefreshVideoControllerList()
	{
		VideoControllerList = _hardwareInfoRetrieval.GetVideoControllerList();
	}

	public static void Ping(string hostNameOrAddress, Action<bool> onPingComplete)
	{
		if (_pingInProgress)
		{
			return;
		}
		_pingInProgress = true;
		_onPingComplete = onPingComplete;
		using Ping ping = new Ping();
		ping.PingCompleted += PingCompleted;
		byte[] buffer = Enumerable.Repeat((byte)97, 32).ToArray();
		int timeout = 12000;
		PingOptions options = new PingOptions(64, dontFragment: true);
		ping.SendAsync(hostNameOrAddress, timeout, buffer, options, null);
	}

	private static void PingCompleted(object sender, PingCompletedEventArgs e)
	{
		_pingInProgress = false;
		bool obj = true;
		if (e.Cancelled)
		{
			obj = false;
		}
		if (e.Error != null)
		{
			obj = false;
		}
		PingReply reply = e.Reply;
		if (reply == null)
		{
			obj = false;
		}
		else if (reply.Status != IPStatus.Success)
		{
			obj = false;
		}
		_onPingComplete?.Invoke(obj);
	}

	public static IEnumerable<IPAddress> GetLocalIPv4Addresses()
	{
		if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
		{
			return from addressInformation in NetworkInterface.GetAllNetworkInterfaces().SelectMany((NetworkInterface networkInterface) => networkInterface.GetIPProperties().UnicastAddresses)
				where addressInformation.Address.AddressFamily == AddressFamily.InterNetwork
				select addressInformation.Address;
		}
		return Dns.GetHostEntry(Dns.GetHostName()).AddressList.Where((IPAddress ip) => ip.AddressFamily == AddressFamily.InterNetwork);
	}

	public static IEnumerable<IPAddress> GetLocalIPv4Addresses(NetworkInterfaceType networkInterfaceType)
	{
		return from addressInformation in (from networkInterface in NetworkInterface.GetAllNetworkInterfaces()
				where networkInterface.NetworkInterfaceType == networkInterfaceType
				select networkInterface).SelectMany((NetworkInterface networkInterface) => networkInterface.GetIPProperties().UnicastAddresses)
			where addressInformation.Address.AddressFamily == AddressFamily.InterNetwork
			select addressInformation.Address;
	}

	public static IEnumerable<IPAddress> GetLocalIPv4Addresses(OperationalStatus operationalStatus)
	{
		return from addressInformation in (from networkInterface in NetworkInterface.GetAllNetworkInterfaces()
				where networkInterface.OperationalStatus == operationalStatus
				select networkInterface).SelectMany((NetworkInterface networkInterface) => networkInterface.GetIPProperties().UnicastAddresses)
			where addressInformation.Address.AddressFamily == AddressFamily.InterNetwork
			select addressInformation.Address;
	}

	public static IEnumerable<IPAddress> GetLocalIPv4Addresses(NetworkInterfaceType networkInterfaceType, OperationalStatus operationalStatus)
	{
		return from addressInformation in (from networkInterface in NetworkInterface.GetAllNetworkInterfaces()
				where networkInterface.NetworkInterfaceType == networkInterfaceType && networkInterface.OperationalStatus == operationalStatus
				select networkInterface).SelectMany((NetworkInterface networkInterface) => networkInterface.GetIPProperties().UnicastAddresses)
			where addressInformation.Address.AddressFamily == AddressFamily.InterNetwork
			select addressInformation.Address;
	}
}
