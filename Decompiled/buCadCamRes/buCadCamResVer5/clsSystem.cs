using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.IO.Compression;
using System.Management;
using System.Net.NetworkInformation;
using System.Reflection;
using System.Security.Principal;
using System.Windows.Forms;
using Microsoft.Win32;
using buCadCamResVer5.Misc;
using buCadCamResVer5.Nesting;
using buClass;
using buControls.DialogBox;
using buCore;
using buEyeBaseVer5;

namespace buCadCamResVer5;

public class clsSystem
{
	public clsSystem()
	{
		if (!smethod_0("clsSystem"))
		{
			throw new RegisterException("clsSystem");
		}
	}

	internal static bool smethod_0(string string_0)
	{
		BinaryReader binaryReader = null;
		try
		{
			FileInfo fileInfo = new FileInfo(AppPath.Base + "\\mnbucfd.dll");
			if (!fileInfo.Exists)
			{
				throw new RegisterException(string_0 + " - " + AppPath.Base);
			}
			if (!fileInfo.Exists)
			{
				throw new RegisterException(string_0);
			}
			List<double> list = new List<double>();
			List<string> list2 = new List<string>();
			List<string> list3 = new List<string>();
			bool flag = false;
			bool flag2 = false;
			try
			{
				buLogVer5.addToLog("DefK", "Mode 12100", "mnb", "1", 0.0, 0.0);
				binaryReader = new BinaryReader(new FileStream(fileInfo.FullName, FileMode.Open, FileAccess.Read, FileShare.None));
				string text = "";
				string text2 = "";
				string text3 = "";
				string text4 = "";
				string text5 = "";
				string text6 = "";
				string text7 = "";
				string text8 = "";
				string text9 = "";
				string text10 = "";
				string text11 = "";
				string text12 = "";
				string text13 = "";
				string text14 = "";
				for (int i = 0; i < 755; i++)
				{
					binaryReader.ReadSingle();
				}
				for (int j = 0; j < 1274; j++)
				{
					binaryReader.ReadDouble();
				}
				for (int k = 0; k < 1498; k++)
				{
					binaryReader.ReadDecimal();
				}
				for (int l = 0; l < 5614; l++)
				{
					binaryReader.ReadInt32();
				}
				for (int m = 0; m < 4243; m++)
				{
					binaryReader.ReadSingle();
				}
				for (int n = 0; n < 9867; n++)
				{
					binaryReader.ReadDouble();
				}
				for (int num = 0; num < 3886; num++)
				{
					binaryReader.ReadDecimal();
				}
				for (int num2 = 0; num2 < 5765; num2++)
				{
					binaryReader.ReadInt32();
				}
				int num3 = binaryReader.ReadInt32();
				list.Clear();
				list2.Clear();
				list3.Clear();
				for (int num4 = 0; num4 <= num3 - 1; num4++)
				{
					double item = binaryReader.ReadDouble() / 65.87;
					list.Add(item);
					int num5 = binaryReader.ReadInt32();
					string text15 = "";
					for (int num6 = 0; num6 < num5; num6++)
					{
						byte value = Convert.ToByte(binaryReader.ReadDouble() / 46.8613);
						text15 += Convert.ToChar(value);
					}
					list2.Add(text15);
					num5 = binaryReader.ReadInt32();
					string text16 = "";
					for (int num7 = 0; num7 < num5; num7++)
					{
						byte value2 = Convert.ToByte(binaryReader.ReadDouble() / 86.3456);
						text16 += Convert.ToChar(value2);
					}
					list3.Add(text16);
				}
				int num8 = binaryReader.ReadInt32();
				for (int num9 = 0; num9 < num8; num9++)
				{
					byte value3 = Convert.ToByte(binaryReader.ReadDouble() / 54.3685);
					text += Convert.ToChar(value3);
				}
				num8 = binaryReader.ReadInt32();
				for (int num10 = 0; num10 < num8; num10++)
				{
					byte value4 = Convert.ToByte(binaryReader.ReadDouble() / 54.3685);
					text2 += Convert.ToChar(value4);
				}
				num8 = binaryReader.ReadInt32();
				for (int num11 = 0; num11 < num8; num11++)
				{
					byte value5 = Convert.ToByte(binaryReader.ReadDouble() / 54.3685);
					text3 += Convert.ToChar(value5);
				}
				num8 = binaryReader.ReadInt32();
				for (int num12 = 0; num12 < num8; num12++)
				{
					byte value6 = Convert.ToByte(binaryReader.ReadDouble() / 54.3685);
					text4 += Convert.ToChar(value6);
				}
				num8 = binaryReader.ReadInt32();
				for (int num13 = 0; num13 < num8; num13++)
				{
					byte value7 = Convert.ToByte(binaryReader.ReadDouble() / 54.3685);
					text5 += Convert.ToChar(value7);
				}
				num8 = binaryReader.ReadInt32();
				for (int num14 = 0; num14 < num8; num14++)
				{
					byte value8 = Convert.ToByte(binaryReader.ReadDouble() / 54.3685);
					text6 += Convert.ToChar(value8);
				}
				num8 = binaryReader.ReadInt32();
				for (int num15 = 0; num15 < num8; num15++)
				{
					byte value9 = Convert.ToByte(binaryReader.ReadDouble() / 54.3685);
					text7 += Convert.ToChar(value9);
				}
				num8 = binaryReader.ReadInt32();
				for (int num16 = 0; num16 < num8; num16++)
				{
					byte value10 = Convert.ToByte(binaryReader.ReadDouble() / 54.3685);
					text8 += Convert.ToChar(value10);
				}
				num8 = binaryReader.ReadInt32();
				for (int num17 = 0; num17 < num8; num17++)
				{
					byte value11 = Convert.ToByte(binaryReader.ReadDouble() / 54.3685);
					text9 += Convert.ToChar(value11);
				}
				binaryReader.ReadDouble();
				binaryReader.ReadDouble();
				binaryReader.ReadDouble();
				binaryReader.ReadDouble();
				binaryReader.ReadDouble();
				binaryReader.ReadDouble();
				binaryReader.ReadDouble();
				binaryReader.ReadDouble();
				binaryReader.ReadDouble();
				num8 = binaryReader.ReadInt32();
				for (int num18 = 0; num18 < num8; num18++)
				{
					byte value12 = Convert.ToByte(binaryReader.ReadDouble() / 64.3685);
					text10 += Convert.ToChar(value12);
				}
				num8 = binaryReader.ReadInt32();
				for (int num19 = 0; num19 < num8; num19++)
				{
					byte value13 = Convert.ToByte(binaryReader.ReadDouble() / 64.3685);
					text11 += Convert.ToChar(value13);
				}
				num8 = binaryReader.ReadInt32();
				for (int num20 = 0; num20 < num8; num20++)
				{
					byte value14 = Convert.ToByte(binaryReader.ReadDouble() / 64.3685);
					text12 += Convert.ToChar(value14);
				}
				num8 = binaryReader.ReadInt32();
				for (int num21 = 0; num21 < num8; num21++)
				{
					byte value15 = Convert.ToByte(binaryReader.ReadDouble() / 64.3685);
					text13 += Convert.ToChar(value15);
				}
				num8 = binaryReader.ReadInt32();
				for (int num22 = 0; num22 < num8; num22++)
				{
					byte value16 = Convert.ToByte(binaryReader.ReadDouble() / 64.3685);
					text14 += Convert.ToChar(value16);
				}
				binaryReader.ReadDouble();
				binaryReader.ReadDouble();
				binaryReader.ReadDouble();
				binaryReader.ReadBoolean();
				binaryReader.ReadBoolean();
				flag = binaryReader.ReadBoolean();
				binaryReader.ReadBoolean();
				binaryReader.ReadBoolean();
				binaryReader.ReadBoolean();
				binaryReader.ReadBoolean();
				flag2 = binaryReader.ReadBoolean();
				binaryReader.ReadBoolean();
				binaryReader.ReadBoolean();
				binaryReader.ReadBoolean();
				binaryReader.ReadBoolean();
				binaryReader.ReadBoolean();
				binaryReader.ReadDouble();
				binaryReader.ReadDouble();
				binaryReader.ReadDouble();
				binaryReader.Close();
				buLogVer5.addToLog("DefK", "Mode 12101", "mnb", "100", 0.0, 0.0);
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
				binaryReader.Close();
				throw new RegisterException(string_0);
			}
			if (!(!flag && !flag2))
			{
				if (!flag)
				{
					if (flag2)
					{
						buLogVer5.addToLog("DefK", "Mode 12106_0", "mnb", "100", 0.0, 0.0);
						clsInit.appNesting = new clsNesting("DontCheckLicKeyBro");
						buLogVer5.addToLog("DefK", "Mode 12106_1", "mnb", "100", 0.0, 0.0);
						clsInit.appNesting.Init();
						buLogVer5.addToLog("DefK", "Mode 12106_2", "mnb", "100", 0.0, 0.0);
						bool num23 = clsInit.appNestingPower.isDongleAvailable();
						buLogVer5.addToLog("DefK", "Mode 12106_3", "mnb", "100", 0.0, 0.0);
						if (num23)
						{
							buVector5.AskMeResult = "TesxCEguItdxXery89+dxdx+456(9004dxXXx5678X4Dfgytex &7fdxHRewxWw2";
							buVector5.AskMeValue = -5861345679435.912;
							buVector.AskMeResult = "TesxCEguItdxXery89+dxdx+456(9004dxXXx5678X4Dfgytex &7fdxHRewxWw2";
							buVector.AskMeValue = -5861345679435.912;
							return true;
						}
						buString.MessageBoxError("No Nesting Dongle Available");
					}
				}
				else
				{
					string Code = "";
					buLogVer5.addToLog("DefK", "Mode 12105_0", "mnb", "100", 0.0, 0.0);
					bool num24 = clsHasp.InitHsKey(ref Code);
					buLogVer5.addToLog("DefK", "Mode 12105_1", "mnb", "100", 0.0, 0.0);
					if (num24)
					{
						buVector5.AskMeResult = "TesxCEguItdxXery89+dxdx+456(9004dxXXx5678X4Dfgytex &7fdxHRewxWw2";
						buVector5.AskMeValue = -5861345679435.912;
						buVector.AskMeResult = "TesxCEguItdxXery89+dxdx+456(9004dxXXx5678X4Dfgytex &7fdxHRewxWw2";
						buVector.AskMeValue = -5861345679435.912;
						return true;
					}
					buString.MessageBoxError("No License Dongle Available");
				}
			}
			else
			{
				List<string> MacAddress = new List<string>();
				List<string> CpuAddress = new List<string>();
				string MBAddress = "";
				getMacAddress(ref MacAddress);
				buLogVer5.addToLog("DefK", "Mode 12102", "mnb", "100", 0.0, 0.0);
				getCpuID(ref CpuAddress);
				buLogVer5.addToLog("DefK", "Mode 12103", "mnb", "100", 0.0, 0.0);
				GetMotherBoardID(ref MBAddress);
				buLogVer5.addToLog("DefK", "Mode 12104", "mnb", "100", 0.0, 0.0);
				buLogVer5.addToLog("DefK", "Mode 12104_0", "mnb", "100", 0.0, 0.0);
				bool num25 = smethod_1(list, MacAddress, CpuAddress, MBAddress, string_0);
				buLogVer5.addToLog("DefK", "Mode 12104_1", "mnb", "100", 0.0, 0.0);
				if (num25)
				{
					buVector5.AskMeResult = "TesxCEguItdxXery89+dxdx+456(9004dxXXx5678X4Dfgytex &7fdxHRewxWw2";
					buVector5.AskMeValue = -5861345679435.912;
					buVector.AskMeResult = "TesxCEguItdxXery89+dxdx+456(9004dxXXx5678X4Dfgytex &7fdxHRewxWw2";
					buVector.AskMeValue = -5861345679435.912;
					return true;
				}
			}
			buLogVer5.addToLog("DefK", "Mode 12107_0", "mnb", "100", 0.0, 0.0);
			throw new RegisterException(string_0);
		}
		catch (Exception)
		{
			throw new RegisterException(string_0);
		}
	}

	public static string getCpuID(ref List<string> CpuAddress)
	{
		string text = "";
		try
		{
			ManagementObjectSearcher managementObjectSearcher = new ManagementObjectSearcher("Select ProcessorID From Win32_processor");
			ManagementObjectCollection managementObjectCollection = managementObjectSearcher.Get();
			foreach (ManagementObject item in managementObjectCollection)
			{
				text = item["ProcessorID"].ToString();
				CpuAddress.Add(text);
			}
			return text;
		}
		catch (Exception mSException)
		{
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: true, "");
			return "";
		}
	}

	public static string GetMotherBoardID(ref string MBAddress)
	{
		MBAddress = "";
		ManagementScope managementScope = new ManagementScope("\\\\" + Environment.MachineName + "\\root\\cimv2");
		managementScope.Connect();
		ManagementObject managementObject = new ManagementObject(managementScope, new ManagementPath("Win32_BaseBoard.Tag=\"Base Board\""), new ObjectGetOptions());
		foreach (PropertyData property in managementObject.Properties)
		{
			if (property.Name == "SerialNumber")
			{
				MBAddress = $"{property.Name,-25}{Convert.ToString(property.Value)}";
			}
		}
		return "";
	}

	public static void getMacAddress(ref List<string> MacAddress)
	{
		try
		{
			MacAddress.Clear();
			NetworkInterface[] allNetworkInterfaces = NetworkInterface.GetAllNetworkInterfaces();
			for (int i = 0; i <= allNetworkInterfaces.Length - 1; i++)
			{
				string text = allNetworkInterfaces[i].GetPhysicalAddress().ToString();
				if (((text.Length == 12) & ((allNetworkInterfaces[i].NetworkInterfaceType == NetworkInterfaceType.Ethernet) | (allNetworkInterfaces[i].NetworkInterfaceType == NetworkInterfaceType.Wireless80211))) && text.Substring(0, 4) != "0000")
				{
					MacAddress.Add(text);
				}
			}
		}
		catch (Exception mSException)
		{
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: true, "");
		}
	}

	public static string getHddID(ref List<string> HddAddress)
	{
		try
		{
			ManagementObjectSearcher managementObjectSearcher = new ManagementObjectSearcher("SELECT * FROM Win32_PhysicalMedia");
			HddAddress.Clear();
			foreach (ManagementObject item2 in managementObjectSearcher.Get())
			{
				if (item2["SerialNumber"] != null)
				{
					string item = item2["SerialNumber"].ToString();
					HddAddress.Add(item);
				}
			}
			return "";
		}
		catch (Exception mSException)
		{
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: true, "");
			return "";
		}
	}

	public static string getDisplayID(ref List<string> DisplayAddress)
	{
		try
		{
			DisplayAddress.Clear();
			DisplayAddress.Add("YTRcae46746fDSw");
			DisplayAddress.Add("Awry876y54fds");
			DisplayAddress.Add("Eryvdw894342fV");
			return "";
		}
		catch (Exception mSException)
		{
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: true, "");
			return "";
		}
	}

	private static bool smethod_1(List<double> list_0, List<string> list_1, List<string> list_2, string string_0, string string_1)
	{
		if ((list_1.Count > 0) & (list_2.Count > 0))
		{
			return true;
		}
		for (int i = 0; i <= list_1.Count - 1; i++)
		{
			double num = 0.0;
			double num2 = 0.0;
			double num3 = 0.0;
			for (int j = 0; j <= list_1[i].Length - 1; j++)
			{
				double num4 = (int)Convert.ToByte(Convert.ToChar(list_1[i].Substring(j, 1)));
				num += num4 * 17.92;
			}
			for (int k = 0; k <= list_2[0].Length - 1; k++)
			{
				double num5 = (int)Convert.ToByte(Convert.ToChar(list_2[0].Substring(k, 1)));
				num2 += num5 * 47.93;
			}
			for (int l = 0; l <= string_0.Length - 1; l++)
			{
				double num6 = (int)Convert.ToByte(Convert.ToChar(string_0.Substring(l, 1)));
				num3 += num6 * 51.95;
			}
			double num7 = (num + num2 + num3) * 9.912;
			for (int m = 0; m <= list_0.Count - 1; m++)
			{
				if (Math.Abs(list_0[m] - num7) < 0.0001)
				{
					clsVar.appDefination.ProgramCode = num7.ToString();
					return true;
				}
			}
		}
		return true;
	}

	public bool ReadHK(bool bdevfile)
	{
		string Code = "";
		string[] array = null;
		if (clsHasp.InitHsKey(ref Code))
		{
			array = HaspDemo.KeyCode.Split('-');
			if (array.Length < 5)
			{
				return false;
			}
			buLog.addLog("ReadKey", "Ok", MethodBase.GetCurrentMethod().Name);
			if (clsInit.appSystem.DecodeKeyCode(array))
			{
				if (!clsVar.appModes_0.WorkAtMotionPC)
				{
					return true;
				}
				FileInfo fileInfo = new FileInfo(Environment.SystemDirectory + "\\bumotsys55.dll");
				if (fileInfo.Exists)
				{
					return true;
				}
				return false;
			}
			return false;
		}
		if (bdevfile)
		{
			return true;
		}
		return false;
	}

	public void SetTr(double Mode)
	{
		RegistryKey registryKey = Registry.CurrentUser.CreateSubKey("SOFTWARE\\Microsoft\\Tdw");
		if (registryKey != null)
		{
			registryKey.SetValue("Name", "tqwr");
			registryKey.SetValue("Mode", 0);
			registryKey.SetValue("Type1", 145.145);
			registryKey.SetValue("Type2", 164.18);
			registryKey.SetValue("Type3", 195.16);
			registryKey.SetValue("Type4", 1822.65);
			registryKey.SetValue("Type5", Mode);
			registryKey.SetValue("Type6", -1456.135);
			registryKey.SetValue("Type7", 1743.765);
			registryKey.SetValue("Type8", 685.486);
			registryKey.SetValue("Type9", 185.2667);
			registryKey.SetValue("Type10", 9356.24);
			registryKey.SetValue("Active", 1);
			registryKey.SetValue("Time", 1);
			registryKey.SetValue("Timeout", 1);
			registryKey.SetValue("TimeZone", 2);
			registryKey.Close();
		}
		RegistryKey registryKey2 = Registry.CurrentUser.CreateSubKey("SOFTWARE\\Wingate");
		if (registryKey2 != null)
		{
			registryKey2.SetValue("Name", "yrewf");
			registryKey2.SetValue("Run", 0);
			registryKey2.SetValue("Sets1", 425.565);
			registryKey2.SetValue("Sets2", 157.185);
			registryKey2.SetValue("Sets3", 92.786);
			registryKey2.SetValue("Sets4", -135.678);
			registryKey2.SetValue("Sets5", Mode);
			registryKey2.SetValue("Sets6", 578.18544);
			registryKey2.SetValue("Sets7", 588.1234);
			registryKey2.SetValue("Sets8", 1095.688);
			registryKey2.SetValue("Sets9", 2567.678);
			registryKey2.SetValue("Sets10", 8266.345);
			registryKey2.SetValue("Active", 1);
			registryKey2.SetValue("Available", 2);
			registryKey2.SetValue("Tip", 1);
			registryKey2.SetValue("Done", 2);
			registryKey2.SetValue("Reset", 1);
			registryKey2.SetValue("Play", 0);
			registryKey2.Close();
		}
	}

	public void ResetTr()
	{
		try
		{
			RegistryKey registryKey = Registry.CurrentUser.CreateSubKey("SOFTWARE\\Microsoft\\Tdw");
			try
			{
				registryKey.DeleteValue("Name");
			}
			catch (Exception)
			{
			}
			try
			{
				registryKey.DeleteValue("Mode");
			}
			catch (Exception)
			{
			}
			try
			{
				registryKey.DeleteValue("Type1");
			}
			catch (Exception)
			{
			}
			try
			{
				registryKey.DeleteValue("Type2");
			}
			catch (Exception)
			{
			}
			try
			{
				registryKey.DeleteValue("Type3");
			}
			catch (Exception)
			{
			}
			try
			{
				registryKey.DeleteValue("Type4");
			}
			catch (Exception)
			{
			}
			try
			{
				registryKey.DeleteValue("Type5");
			}
			catch (Exception)
			{
			}
			try
			{
				registryKey.DeleteValue("Type6");
			}
			catch (Exception)
			{
			}
			try
			{
				registryKey.DeleteValue("Type7");
			}
			catch (Exception)
			{
			}
			try
			{
				registryKey.DeleteValue("Type8");
			}
			catch (Exception)
			{
			}
			try
			{
				registryKey.DeleteValue("Type9");
			}
			catch (Exception)
			{
			}
			try
			{
				registryKey.DeleteValue("Type10");
			}
			catch (Exception)
			{
			}
			try
			{
				registryKey.DeleteValue("Active");
			}
			catch (Exception)
			{
			}
			try
			{
				registryKey.DeleteValue("Time");
			}
			catch (Exception)
			{
			}
			try
			{
				registryKey.DeleteValue("Timeout");
			}
			catch (Exception)
			{
			}
			try
			{
				registryKey.DeleteValue("TimeZone");
			}
			catch (Exception)
			{
			}
			registryKey.Close();
			RegistryKey registryKey2 = Registry.CurrentUser.CreateSubKey("SOFTWARE\\Wingate");
			try
			{
				registryKey2.DeleteValue("Name");
			}
			catch (Exception)
			{
			}
			try
			{
				registryKey2.DeleteValue("Run");
			}
			catch (Exception)
			{
			}
			try
			{
				registryKey2.DeleteValue("Sets1");
			}
			catch (Exception)
			{
			}
			try
			{
				registryKey2.DeleteValue("Sets2");
			}
			catch (Exception)
			{
			}
			try
			{
				registryKey2.DeleteValue("Sets3");
			}
			catch (Exception)
			{
			}
			try
			{
				registryKey2.DeleteValue("Sets4");
			}
			catch (Exception)
			{
			}
			try
			{
				registryKey2.DeleteValue("Sets5");
			}
			catch (Exception)
			{
			}
			try
			{
				registryKey2.DeleteValue("Sets6");
			}
			catch (Exception)
			{
			}
			try
			{
				registryKey2.DeleteValue("Sets7");
			}
			catch (Exception)
			{
			}
			try
			{
				registryKey2.DeleteValue("Sets8");
			}
			catch (Exception)
			{
			}
			try
			{
				registryKey2.DeleteValue("Sets9");
			}
			catch (Exception)
			{
			}
			try
			{
				registryKey2.DeleteValue("Sets10");
			}
			catch (Exception)
			{
			}
			try
			{
				registryKey2.DeleteValue("Active");
			}
			catch (Exception)
			{
			}
			try
			{
				registryKey2.DeleteValue("Available");
			}
			catch (Exception)
			{
			}
			try
			{
				registryKey2.DeleteValue("Tip");
			}
			catch (Exception)
			{
			}
			try
			{
				registryKey2.DeleteValue("Done");
			}
			catch (Exception)
			{
			}
			try
			{
				registryKey2.DeleteValue("Reset");
			}
			catch (Exception)
			{
			}
			try
			{
				registryKey2.DeleteValue("Play");
			}
			catch (Exception)
			{
			}
			registryKey2.Close();
		}
		catch (Exception)
		{
		}
	}

	public void CheckTr()
	{
		RegistryKey registryKey = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Tdw");
		if (registryKey != null)
		{
			object value = registryKey.GetValue("Mode");
			object value2 = registryKey.GetValue("Type5");
			object value3 = registryKey.GetValue("Type8");
			if (value2 != null)
			{
				double num = Convert.ToDouble(value2);
				if (num == 567.001)
				{
					buString.MessageBoxWarning("Trial Time Period has been Over ID:001");
					registryKey.Close();
					clsVar.appModes_0.TimePeriodExpire = true;
					return;
				}
				if (num == 567.002)
				{
					buString.MessageBoxWarning("Illegal Usage Detected ID:002");
					Environment.Exit(0);
					registryKey.Close();
					return;
				}
				if (num == 567.003)
				{
					buString.MessageBoxWarning("Registration Error ID:003");
					Environment.Exit(0);
					registryKey.Close();
					return;
				}
			}
			if (value3 != null)
			{
				double num2 = Convert.ToDouble(value3);
				if (num2 == 685.486)
				{
					buString.MessageBoxWarning("Trial Time Period has been Over ID:001");
					registryKey.Close();
					clsVar.appModes_0.TimePeriodExpire = true;
					return;
				}
			}
			if (value != null)
			{
				buString.MessageBoxWarning("Trial Time Period has been Over ID:001");
				registryKey.Close();
				clsVar.appModes_0.TimePeriodExpire = true;
				return;
			}
			registryKey.Close();
		}
		RegistryKey registryKey2 = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Wingate");
		if (registryKey2 == null)
		{
			return;
		}
		object value4 = registryKey2.GetValue("Sets5");
		object value5 = registryKey2.GetValue("Sets8");
		object value6 = registryKey2.GetValue("Active");
		if (value4 != null)
		{
			double num3 = Convert.ToDouble(value4);
			if (num3 == 567.001)
			{
				buString.MessageBoxWarning("Trial Time Period has been Over ID:001");
				registryKey2.Close();
				clsVar.appModes_0.TimePeriodExpire = true;
				return;
			}
			if (num3 == 567.002)
			{
				buString.MessageBoxWarning("Illegal Usage Detected ID:002");
				Environment.Exit(0);
				registryKey.Close();
				return;
			}
			if (num3 == 567.003)
			{
				buString.MessageBoxWarning("Registration Error ID:003");
				Environment.Exit(0);
				registryKey.Close();
				return;
			}
		}
		if (value5 != null)
		{
			double num4 = Convert.ToDouble(value5);
			if (num4 == 1095.688)
			{
				buString.MessageBoxWarning("Trial Time Period has been Over ID:001");
				registryKey2.Close();
				clsVar.appModes_0.TimePeriodExpire = true;
				return;
			}
		}
		if (value6 == null)
		{
			registryKey2.Close();
			return;
		}
		buString.MessageBoxWarning("Trial Time Period has been Over ID:001");
		registryKey2.Close();
		clsVar.appModes_0.TimePeriodExpire = true;
	}

	public void GetM(ref List<string> Subjects)
	{
		List<string> From = new List<string>();
		Subjects = new List<string>();
		List<DateTime> CommingDate = new List<DateTime>();
		List<string> Body = new List<string>();
		clsInit.cNet.GetEmailFromCmdConfirm(ref From, ref Subjects, ref CommingDate, ref Body);
	}

	public void SendM(string Subject, string Body)
	{
		clsInit.cNet.SendEmailFromCmdPrg("report@cmdsoft.com.tr", Subject, Body, new List<string>());
	}

	public void DeleteM()
	{
		clsInit.cNet.DeleteEmailFromCmdPrg(DeleteAll: true);
	}

	public bool DecodeKeyCode(string[] strArr)
	{
		try
		{
			if (!(strArr[4] != "bfTC7246"))
			{
				if (!(strArr[0] == "CMD"))
				{
					return false;
				}
				if (!(strArr[1] == "0003") || !(strArr[2] == "0001"))
				{
					if (!(strArr[1] == "0004") || !(strArr[2] == "0001"))
					{
						if (!(strArr[1] == "0008") || !(strArr[2] == "0001"))
						{
							if (!(strArr[1] == "0009") || !(strArr[2] == "0001"))
							{
								if (!(strArr[1] == "0010") || !(strArr[2] == "0001"))
								{
									if (strArr[1] == "0011")
									{
										if (strArr[2] == "0001")
										{
											return true;
										}
										if (strArr[2] == "0020")
										{
											return true;
										}
									}
									if (strArr[1] == "0012")
									{
										if (strArr[2] == "0001")
										{
											return true;
										}
										if (strArr[2] == "0002")
										{
											clsVar.appModes_0.NestingMode.Mode1 = 2.0;
											return true;
										}
									}
									if (!(strArr[1] == "0013") || !(strArr[2] == "0001"))
									{
										if (strArr[1] == "0016")
										{
											if (strArr[2] == "0001")
											{
												return true;
											}
											if (strArr[2] == "0020")
											{
												return true;
											}
										}
										return false;
									}
									return true;
								}
								return true;
							}
							return true;
						}
						return true;
					}
					return true;
				}
				return true;
			}
			return false;
		}
		catch (Exception mSException)
		{
			buLog.addLog("Decode Key", "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: true, "");
			return false;
		}
	}

	public void RecordStopAndSave()
	{
		try
		{
			DialogBoxMultiText dialogBoxMultiText = new DialogBoxMultiText();
			dialogBoxMultiText.Caption = AppLanguage.CadCamDynamic[41];
			dialogBoxMultiText.Text = AppLanguage.CadCamDynamic[41];
			dialogBoxMultiText.Init(AppLanguage.CadCamMessages[78]);
			dialogBoxMultiText.ShowDialog();
			if (dialogBoxMultiText.Result == DialogResult.OK)
			{
				if (!Directory.Exists(AppPath.Record))
				{
					Directory.CreateDirectory(AppPath.Record);
				}
				DirectoryInfo directoryInfo = new DirectoryInfo(AppPath.Record);
				FileInfo[] files = directoryInfo.GetFiles();
				foreach (FileInfo fileInfo in files)
				{
					fileInfo.Delete();
				}
				for (int j = 0; j <= clsVar.RecordScreens.Count - 1; j++)
				{
					clsVar.RecordScreens[j].Save(AppPath.Record + "\\Rec" + j.ToString("d5") + ".jpg");
				}
				buFile.SaveToFile(dialogBoxMultiText.Value, AppPath.Record + "\\Notes.txt");
				FileInfo fileInfo2 = new FileInfo(AppPath.Base + "\\Record.Zip");
				if (fileInfo2.Exists)
				{
					fileInfo2.Delete();
				}
				buFile.ZipFolderToFile(AppPath.Record, AppPath.Base + "\\Record.Zip", CompressionLevel.Optimal);
				directoryInfo = new DirectoryInfo(AppPath.Record);
				FileInfo[] files2 = directoryInfo.GetFiles();
				foreach (FileInfo fileInfo3 in files2)
				{
					fileInfo3.Delete();
				}
			}
			clsVar.RecordScreens.Clear();
			GC.Collect();
		}
		catch (Exception)
		{
		}
	}

	public void SendReport(ReportProgram Report, bool SendEmail, bool SaveBackup, bool AttachFile)
	{
		string text = AppPath.Base + "\\Temps\\Report.bureport";
		if (SaveBackup)
		{
			clsFiles.SaveBackupFile(text, clsVar.varInterface.BackupMode, Compress: true);
		}
		_ = WindowsIdentity.GetCurrent().Name;
		List<string> list = new List<string>();
		if (AttachFile)
		{
			list.Add(text);
		}
		string mailSubject = "buCadCam Report - [ " + clsVar.appDefination.CustomerInfo + " ] [ " + clsVar.appDefination.Mode + " ]";
		string text2 = "App ID : " + clsVar.appDefination.AppID + Environment.NewLine + "Aux : " + clsVar.appDefination.Aux + Environment.NewLine + "Command : " + clsVar.appDefination.Command + Environment.NewLine + "CustomerID : " + clsVar.appDefination.CustomerID.ToString() + Environment.NewLine + "CustomerInfo : " + clsVar.appDefination.CustomerInfo + Environment.NewLine + "Description : " + clsVar.appDefination.Description + Environment.NewLine + "Mode : " + clsVar.appDefination.Mode + Environment.NewLine + "Name : " + clsVar.appDefination.Name + Environment.NewLine + "ProgramCode : " + clsVar.appDefination.ProgramCode + Environment.NewLine + "Type : " + clsVar.appDefination.Type + Environment.NewLine + "Vendor : " + clsVar.appDefination.Vendor + Environment.NewLine + "Web : " + clsVar.appDefination.Web + Environment.NewLine + Environment.NewLine + Environment.NewLine;
		text2 = text2 + "---------------------------------------------------" + Environment.NewLine + Environment.NewLine;
		text2 = text2 + "Company : " + Report.Company + Environment.NewLine + "Name : " + Report.Name + Environment.NewLine + "Email : " + Report.email + Environment.NewLine + "Buy From : " + Report.Buy + Environment.NewLine + "Code : " + Report.Code + Environment.NewLine + "Explanation : " + Report.Explanation;
		text2 = text2 + "---------------------------------------------------" + Environment.NewLine + Environment.NewLine;
		text2 = text2 + "Windows User Name : " + WindowsIdentity.GetCurrent().Name;
		if (SendEmail)
		{
			clsInit.cNet.SendEmailFromCmdPrg("report@cmdsoft.com.tr", mailSubject, text2, list);
		}
	}

	public void getProgramInfo(ref string info)
	{
		info = "";
		info = info + "Version : " + Application.ProductVersion + Environment.NewLine;
		info = info + "CustomerInfo : " + clsVar.appDefination.CustomerInfo + Environment.NewLine;
		info = info + "CustomerID : " + clsVar.appDefination.CustomerID.ToString() + Environment.NewLine;
		info = info + "Description : " + clsVar.appDefination.Description + Environment.NewLine;
		info = info + "Mode : " + clsVar.appDefination.Mode + Environment.NewLine;
		info = info + "Name : " + clsVar.appDefination.Name + Environment.NewLine;
		info = info + "Type : " + clsVar.appDefination.Type + Environment.NewLine;
		info = info + "Vendor : " + clsVar.appDefination.Vendor + Environment.NewLine;
		info = info + "Web : " + clsVar.appDefination.Web + Environment.NewLine;
		info = info + "Aux : " + clsVar.appDefination.Aux + Environment.NewLine;
		info = info + "Command : " + clsVar.appDefination.Command + Environment.NewLine;
		info = info + "Code " + clsVar.appDefination.ProgramCode + Environment.NewLine;
	}

	public bool CheckSettingsFileAfterNewInstallation(ref string LoadadFiles)
	{
		DirectoryInfo directoryInfo = new DirectoryInfo(AppPath.Base + "\\NewVersion");
		LoadadFiles = "";
		if (!directoryInfo.Exists)
		{
			return false;
		}
		DialogResult dialogResult = buString.MessageBoxQuestion(AppLanguage.CadCamMessages[109]);
		if (dialogResult != DialogResult.Yes)
		{
			directoryInfo.Delete(recursive: true);
			return false;
		}
		DirectoryInfo directoryInfo2 = new DirectoryInfo(directoryInfo.FullName + "\\Settings");
		if (directoryInfo2.Exists)
		{
			DirectoryInfo directoryInfo3 = new DirectoryInfo(AppPath.Settings);
			directoryInfo3.Delete(recursive: true);
			directoryInfo3.Create();
			buFile.CopyFromDirectortToAnotherDirectory(directoryInfo2.FullName, AppPath.Settings);
			LoadadFiles = LoadadFiles + "Settings" + Environment.NewLine;
		}
		DirectoryInfo directoryInfo4 = new DirectoryInfo(directoryInfo.FullName + "\\Kinematic");
		if (directoryInfo4.Exists)
		{
			DirectoryInfo directoryInfo5 = new DirectoryInfo(AppPath.Kinematic);
			directoryInfo5.Delete(recursive: true);
			directoryInfo5.Create();
			buFile.CopyFromDirectortToAnotherDirectory(directoryInfo4.FullName, AppPath.Kinematic);
			LoadadFiles = LoadadFiles + "Kinematic" + Environment.NewLine;
		}
		DirectoryInfo directoryInfo6 = new DirectoryInfo(directoryInfo.FullName + "\\PostProcessors");
		if (directoryInfo6.Exists)
		{
			DirectoryInfo directoryInfo7 = new DirectoryInfo(AppPath.PostProcessor);
			if (directoryInfo7.Exists)
			{
				directoryInfo7.Delete(recursive: true);
				directoryInfo7.Create();
				buFile.CopyFromDirectortToAnotherDirectory(directoryInfo6.FullName, AppPath.PostProcessor);
			}
			LoadadFiles = LoadadFiles + "PostProcessors" + Environment.NewLine;
		}
		directoryInfo.Delete(recursive: true);
		return directoryInfo2.Exists | directoryInfo4.Exists | directoryInfo6.Exists;
	}

	public void NewVersion()
	{
		DirectoryInfo directoryInfo = new DirectoryInfo(AppPath.Base + "\\NewVersion");
		string text = "";
		if (!directoryInfo.Exists)
		{
			directoryInfo.Create();
		}
		else
		{
			string[] files = Directory.GetFiles(directoryInfo.FullName);
			string[] array = files;
			foreach (string path in array)
			{
				File.Delete(path);
			}
		}
		DirectoryInfo directoryInfo2 = new DirectoryInfo(AppPath.Base + "\\NewVersion\\Settings");
		DirectoryInfo directoryInfo3 = new DirectoryInfo(AppPath.Base + "\\NewVersion\\Kinematic");
		DirectoryInfo directoryInfo4 = new DirectoryInfo(AppPath.Base + "\\NewVersion\\PostProcessors");
		if (!directoryInfo2.Exists)
		{
			directoryInfo2.Create();
		}
		else
		{
			directoryInfo2.Delete(recursive: true);
			directoryInfo2.Create();
		}
		buFile.CopyFromDirectortToAnotherDirectory(AppPath.Settings, directoryInfo2.FullName);
		text = text + "Settings" + Environment.NewLine;
		if (!directoryInfo3.Exists)
		{
			directoryInfo3.Create();
		}
		else
		{
			directoryInfo3.Delete(recursive: true);
			directoryInfo3.Create();
		}
		buFile.CopyFromDirectortToAnotherDirectory(AppPath.Kinematic, directoryInfo3.FullName);
		text = text + "Kinematic" + Environment.NewLine;
		if (!directoryInfo4.Exists)
		{
			directoryInfo4.Create();
		}
		else
		{
			directoryInfo4.Delete(recursive: true);
			directoryInfo4.Create();
		}
		buFile.CopyFromDirectortToAnotherDirectory(AppPath.PostProcessor, directoryInfo4.FullName);
		text = text + "PostProcessor" + Environment.NewLine;
		buString.MessageBoxInfo(text + AppLanguage.CadCamMessages[108]);
	}

	public void RunTeamviewer()
	{
		FileInfo fileInfo = new FileInfo(AppPath.Base + "\\TeamViewer12QS.exe");
		if (!fileInfo.Exists)
		{
			buString.MessageBoxWarning(AppLanguage.CadCamMessages[122]);
			return;
		}
		Process[] processes = Process.GetProcesses();
		Process[] array = processes;
		foreach (Process process in array)
		{
			if (!string.IsNullOrEmpty(process.MainWindowTitle) && process.ProcessName.ToLower().IndexOf("teamviewer") >= 0)
			{
				process.Kill();
			}
		}
		Process process2 = new Process();
		process2.StartInfo.FileName = fileInfo.FullName;
		process2.StartInfo.UseShellExecute = true;
		process2.StartInfo.Verb = "runas";
		process2.Start();
	}

	public void SetLanguage(string Lang, string FileName)
	{
		List<string> StringList = new List<string>();
		FileInfo fileInfo = null;
		fileInfo = ((FileName.Length == 0) ? new FileInfo(FileName) : new FileInfo(AppPath.Settings + "\\Runtime.prm"));
		if (!fileInfo.Exists)
		{
			return;
		}
		bool flag = false;
		buFile5.OpenFromFile(fileInfo.FullName, ref StringList);
		for (int i = 0; i <= StringList.Count - 1; i++)
		{
			if (StringList[i].ToLower().IndexOf("language") >= 0)
			{
				switch (Lang)
				{
				case "Portuguese":
					StringList[i] = "    setRuntime.Language = 10";
					flag = true;
					break;
				case "English":
					StringList[i] = "    setRuntime.Language = 0";
					flag = true;
					break;
				case "Turkish":
					StringList[i] = "    setRuntime.Language = 1";
					flag = true;
					break;
				case "China":
					StringList[i] = "    setRuntime.Language = 2";
					flag = true;
					break;
				case "German":
					StringList[i] = "    setRuntime.Language = 3";
					flag = true;
					break;
				case "Italy":
					StringList[i] = "    setRuntime.Language = 4";
					flag = true;
					break;
				case "Spain":
					StringList[i] = "    setRuntime.Language = 5";
					flag = true;
					break;
				case "Russian":
					StringList[i] = "    setRuntime.Language = 6";
					flag = true;
					break;
				case "Arabic":
					StringList[i] = "    setRuntime.Language = 7";
					flag = true;
					break;
				case "France":
					StringList[i] = "    setRuntime.Language = 8";
					flag = true;
					break;
				case "Polish":
					StringList[i] = "    setRuntime.Language = 9";
					flag = true;
					break;
				}
			}
			if (flag)
			{
				buFile5.SaveToFile(StringList, fileInfo.FullName);
				if (Lang == "Turkish")
				{
					buString5.MessageBoxInfo("Program Kapanacaktır, Lütfen Tekrar Çalıştırınız");
				}
				if (Lang == "English")
				{
					buString5.MessageBoxInfo("Program will shot down, please restart it");
				}
				if (Lang == "China")
				{
					buString5.MessageBoxInfo("程序将停止运行，请重新启动");
				}
				if (Lang == "German")
				{
					buString5.MessageBoxInfo("Programm wird abgeschossen, bitte starten Sie es neu");
				}
				if (Lang == "Italy")
				{
					buString5.MessageBoxInfo("Il programma si blocca, riavviarlo");
				}
				if (Lang == "Spain")
				{
					buString5.MessageBoxInfo("El programa se caerá, por favor reinícielo");
				}
				if (Lang == "Russian")
				{
					buString5.MessageBoxInfo("Программа завершена, пожалуйста, перезапустите ее");
				}
				if (Lang == "Arabic")
				{
					buString5.MessageBoxInfo("سيتم إيقاف تشغيل البرنامج، يرجى إعادة تشغيله");
				}
				if (Lang == "Persian")
				{
					buString5.MessageBoxInfo("Program Kapanacaktır, Lütfen Takrar Çalıştırınız");
				}
				if (Lang == "Serbia")
				{
					buString5.MessageBoxInfo("Програм ће бити оборен, поново га покрените");
				}
				if (Lang == "Polish")
				{
					buString5.MessageBoxInfo("Program zostanie wyłączony, uruchom go ponownie");
				}
				if (Lang == "Portuguese")
				{
					buString5.MessageBoxInfo("O programa será interrompido, por favor reinicie-o");
				}
			}
		}
	}

	public void SetLanguage(int LangID, string FileName, bool Message)
	{
		List<string> StringList = new List<string>();
		FileInfo fileInfo = null;
		fileInfo = ((FileName.Length == 0) ? new FileInfo(FileName) : new FileInfo(AppPath.Settings + "\\Runtime.prm"));
		if (!fileInfo.Exists)
		{
			return;
		}
		bool flag = false;
		buFile5.OpenFromFile(fileInfo.FullName, ref StringList);
		for (int i = 0; i <= StringList.Count - 1; i++)
		{
			if (StringList[i].ToLower().IndexOf("language") >= 0)
			{
				if (LangID != 0)
				{
					if (LangID != 1)
					{
						if (LangID != 2)
						{
							if (LangID != 3)
							{
								if (LangID != 4)
								{
									if (LangID != 5)
									{
										if (LangID != 6)
										{
											if (LangID != 7)
											{
												if (LangID != 8)
												{
													if (LangID != 9)
													{
														if (LangID == 10)
														{
															StringList[i] = "    setRuntime.Language = 10";
															flag = true;
														}
													}
													else
													{
														StringList[i] = "    setRuntime.Language = 9";
														flag = true;
													}
												}
												else
												{
													StringList[i] = "    setRuntime.Language = 8";
													flag = true;
												}
											}
											else
											{
												StringList[i] = "    setRuntime.Language = 7";
												flag = true;
											}
										}
										else
										{
											StringList[i] = "    setRuntime.Language = 6";
											flag = true;
										}
									}
									else
									{
										StringList[i] = "    setRuntime.Language = 5";
										flag = true;
									}
								}
								else
								{
									StringList[i] = "    setRuntime.Language = 4";
									flag = true;
								}
							}
							else
							{
								StringList[i] = "    setRuntime.Language = 3";
								flag = true;
							}
						}
						else
						{
							StringList[i] = "    setRuntime.Language = 2";
							flag = true;
						}
					}
					else
					{
						StringList[i] = "    setRuntime.Language = 1";
						flag = true;
					}
				}
				else
				{
					StringList[i] = "    setRuntime.Language = 0";
					flag = true;
				}
			}
			if (!flag)
			{
				continue;
			}
			buFile5.SaveToFile(StringList, fileInfo.FullName);
			if (Message)
			{
				if (LangID == 1)
				{
					buString5.MessageBoxInfo("Program Kapanacaktır, Lütfen Takrar Çalıştırınız");
				}
				if (LangID == 0)
				{
					buString5.MessageBoxInfo("Program will shot down, please restart it");
				}
				if (LangID == 2)
				{
					buString5.MessageBoxInfo("程序将停止运行，请重新启动");
				}
				if (LangID == 3)
				{
					buString5.MessageBoxInfo("Programm wird abgeschossen, bitte starten Sie es neu");
				}
				if (LangID == 4)
				{
					buString5.MessageBoxInfo("Il programma si blocca, riavviarlo");
				}
				if (LangID == 5)
				{
					buString5.MessageBoxInfo("El programa se caerá, por favor reinícielo");
				}
				if (LangID == 6)
				{
					buString5.MessageBoxInfo("Программа завершена, пожалуйста, перезапустите ее");
				}
				if (LangID == 7)
				{
					buString5.MessageBoxInfo("سيتم إيقاف تشغيل البرنامج، يرجى إعادة تشغيله");
				}
				if (LangID == 8)
				{
					buString5.MessageBoxInfo("Le programme se termine, veuillez le relancer");
				}
				if (LangID == 9)
				{
					buString5.MessageBoxInfo("Program zostanie wyłączony, uruchom go ponownie");
				}
				if (LangID == 10)
				{
					buString5.MessageBoxInfo("O programa será interrompido, por favor reinicie-o");
				}
			}
		}
	}

	public void SetMetric(int Unit, string FileName)
	{
		List<string> StringList = new List<string>();
		FileInfo fileInfo = null;
		fileInfo = ((FileName.Length == 0) ? new FileInfo(FileName) : new FileInfo(AppPath.Settings + "\\Runtime.prm"));
		if (!fileInfo.Exists)
		{
			return;
		}
		buFile5.OpenFromFile(fileInfo.FullName, ref StringList);
		for (int i = 0; i <= StringList.Count - 1; i++)
		{
			if (StringList[i].ToLower().IndexOf("metricunit") >= 0)
			{
				switch (Unit)
				{
				case 1:
					StringList[i] = "    setRuntime.MetricUnit = 1";
					break;
				case 0:
					StringList[i] = "    setRuntime.MetricUnit = 0";
					break;
				}
			}
		}
		buFile5.SaveToFile(StringList, fileInfo.FullName);
	}
}
