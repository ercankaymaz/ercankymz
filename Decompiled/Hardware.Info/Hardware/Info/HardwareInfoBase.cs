using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Runtime.InteropServices;

namespace Hardware.Info;

internal class HardwareInfoBase
{
	internal static Process StartProcess(string cmd, string args)
	{
		return Process.Start(new ProcessStartInfo(cmd, args)
		{
			CreateNoWindow = true,
			UseShellExecute = false,
			RedirectStandardError = true,
			RedirectStandardInput = true,
			RedirectStandardOutput = true
		});
	}

	internal static string ReadProcessOutput(string cmd, string args)
	{
		try
		{
			using Process process = StartProcess(cmd, args);
			using StreamReader streamReader = process.StandardOutput;
			process.WaitForExit();
			return streamReader.ReadToEnd().Trim();
		}
		catch
		{
			return string.Empty;
		}
	}

	internal static string TryReadTextFromFile(string path)
	{
		try
		{
			return File.ReadAllText(path).Trim();
		}
		catch
		{
			return string.Empty;
		}
	}

	internal static uint TryReadIntegerFromFile(params string[] possiblePaths)
	{
		for (int i = 0; i < possiblePaths.Length; i++)
		{
			if (uint.TryParse(TryReadTextFromFile(possiblePaths[i]), out var result))
			{
				return result;
			}
		}
		return 0u;
	}

	internal static string[] TryReadLinesFromFile(string path)
	{
		try
		{
			return File.ReadAllLines(path);
		}
		catch
		{
			return Array.Empty<string>();
		}
	}

	public virtual List<Drive> GetDriveList()
	{
		List<Drive> list = new List<Drive>();
		Drive drive = new Drive();
		Partition partition = new Partition();
		DriveInfo[] drives = DriveInfo.GetDrives();
		foreach (DriveInfo driveInfo in drives)
		{
			try
			{
				Volume item = new Volume
				{
					FileSystem = driveInfo.DriveFormat,
					Description = driveInfo.DriveType.ToString(),
					Name = driveInfo.Name,
					Caption = driveInfo.RootDirectory.FullName,
					FreeSpace = (ulong)driveInfo.TotalFreeSpace,
					Size = (ulong)driveInfo.TotalSize,
					VolumeName = driveInfo.VolumeLabel
				};
				partition.VolumeList.Add(item);
			}
			catch (UnauthorizedAccessException)
			{
			}
		}
		drive.PartitionList.Add(partition);
		list.Add(drive);
		return list;
	}

	public virtual List<NetworkAdapter> GetNetworkAdapterList(bool includeBytesPersec = true, bool includeNetworkAdapterConfiguration = true, int millisecondsDelayBetweenTwoMeasurements = 1000)
	{
		List<NetworkAdapter> list = new List<NetworkAdapter>();
		NetworkInterface[] allNetworkInterfaces = NetworkInterface.GetAllNetworkInterfaces();
		foreach (NetworkInterface networkInterface in allNetworkInterfaces)
		{
			NetworkAdapter networkAdapter = new NetworkAdapter
			{
				MACAddress = networkInterface.GetPhysicalAddress().ToString().Trim(),
				Description = networkInterface.Description.Trim(),
				Name = networkInterface.Name.Trim()
			};
			if (!RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
			{
				networkAdapter.Speed = (ulong)networkInterface.Speed;
			}
			if (includeNetworkAdapterConfiguration)
			{
				foreach (UnicastIPAddressInformation unicastAddress in networkInterface.GetIPProperties().UnicastAddresses)
				{
					if (unicastAddress.Address.AddressFamily == AddressFamily.InterNetwork)
					{
						networkAdapter.IPAddressList.Add(unicastAddress.Address);
					}
				}
			}
			list.Add(networkAdapter);
		}
		return list;
	}
}
