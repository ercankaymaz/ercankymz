using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Management;
using System.Net.NetworkInformation;
using System.Reflection;
using System.Threading;
using System.Windows.Forms;
using Microsoft.Win32;
using buClass;
using buControls.Controls;
using buEyeBaseVer5.Forms.KeyPad;
using devDept.Geometry;

namespace buEyeBaseVer5;

public class buFunctions
{
	public static void CultureSettings()
	{
		int[] currencyGroupSizes = new int[3] { 3, 2, 2 };
		CultureInfo cultureInfo = new CultureInfo("en-US");
		new DateTimeFormatInfo();
		NumberFormatInfo numberFormatInfo = new NumberFormatInfo();
		numberFormatInfo.CurrencySymbol = "Rs";
		numberFormatInfo.CurrencyDecimalDigits = 3;
		numberFormatInfo.CurrencyDecimalSeparator = ".";
		numberFormatInfo.CurrencyGroupSizes = currencyGroupSizes;
		numberFormatInfo.CurrencyGroupSeparator = ",";
		numberFormatInfo.PositiveInfinitySymbol = " ";
		cultureInfo.NumberFormat = numberFormatInfo;
		Application.CurrentCulture = cultureInfo;
		Thread.CurrentThread.CurrentCulture = cultureInfo;
		Thread.CurrentThread.CurrentUICulture = cultureInfo;
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
		catch (Exception)
		{
			return text;
		}
	}

	public static string getHddID(ref List<string> HddAddress)
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

	public static void getMacAddress(ref List<string> MacAddress)
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

	public static void ExchangeDatas(ref double FirstData, ref double SecondData)
	{
		try
		{
			double num = 0.0;
			num = FirstData;
			FirstData = SecondData;
			SecondData = num;
		}
		catch (Exception mSException)
		{
			buLog.addLog("", "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: false, "");
		}
	}

	public static void ExchangeDatas(ref int FirstData, ref int SecondData)
	{
		try
		{
			int num = 0;
			num = FirstData;
			FirstData = SecondData;
			SecondData = num;
		}
		catch (Exception mSException)
		{
			buLog.addLog("", "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: false, "");
		}
	}

	public static void ExchangeDatas(ref float FirstData, ref float SecondData)
	{
		try
		{
			float num = 0f;
			num = FirstData;
			FirstData = SecondData;
			SecondData = num;
		}
		catch (Exception mSException)
		{
			buLog.addLog("", "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: false, "");
		}
	}

	public static void ExchangeDatas(ref object FirstData, ref object SecondData)
	{
		try
		{
			object obj = 0;
			obj = FirstData;
			FirstData = SecondData;
			SecondData = obj;
		}
		catch (Exception mSException)
		{
			buLog.addLog("", "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: false, "");
		}
	}

	public static void ExchangeDatas(ref Point3D FirstData, ref Point3D SecondData)
	{
		try
		{
			Point3D point3D = new Point3D(FirstData.X, FirstData.Y, FirstData.Z);
			FirstData = new Point3D(SecondData.X, SecondData.Y, SecondData.Z);
			SecondData = new Point3D(point3D.X, point3D.Y, point3D.Z);
		}
		catch (Exception mSException)
		{
			buLog.addLog("", "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: false, "");
		}
	}

	public static object EnumValueFromInt(object EnumVar, int Index)
	{
		try
		{
			return (Enum)Enum.ToObject(EnumVar.GetType(), Index);
		}
		catch (Exception mSException)
		{
			string text = "EnumVar : " + EnumVar.ToString() + " - Index: " + Index;
			buLog.addLog(text, "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: false, text);
			return null;
		}
	}

	public static object EnumValueFromString(object EnumVar, string EnumString)
	{
		try
		{
			Type type = EnumVar.GetType();
			return Enum.Parse(type, EnumString, ignoreCase: true);
		}
		catch (Exception mSException)
		{
			string text = "EnumVar : " + EnumVar.ToString() + " - EnumString: " + EnumString.ToString();
			buLog.addLog(text, "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: false, text);
			return null;
		}
	}

	public static void GetEnumTypeValues(object EnumType, ref ArrayList EnumItems)
	{
		try
		{
			Array array = null;
			if (EnumType != null && EnumType.GetType().IsEnum)
			{
				array = Enum.GetValues(EnumType.GetType());
				EnumItems.Clear();
				for (int i = 0; i <= array.Length - 1; i++)
				{
					EnumItems.Add(array.GetValue(i));
				}
			}
		}
		catch (Exception mSException)
		{
			string text = "EnumType : " + EnumType;
			buLog.addLog(text, "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: false, text);
		}
	}

	public static void GetEnumTypeValues(object EnumType, ref List<string> EnumItems)
	{
		try
		{
			Array array = null;
			if (EnumType != null && EnumType.GetType().IsEnum)
			{
				array = Enum.GetValues(EnumType.GetType());
				EnumItems.Clear();
				for (int i = 0; i <= array.Length - 1; i++)
				{
					EnumItems.Add(array.GetValue(i).ToString());
				}
			}
		}
		catch (Exception mSException)
		{
			string text = "EnumType : " + EnumType;
			buLog.addLog(text, "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: false, text);
		}
	}

	public static void ComboboxAddItem(ArrayList Items, int SelectedIndex, ref ComboBox Combobox)
	{
		if (Items.Count > 0)
		{
			Combobox.Items.Clear();
			for (int i = 0; i <= Items.Count - 1; i++)
			{
				Combobox.Items.Add(Items[i]);
			}
			if (!((SelectedIndex >= 0) & (SelectedIndex <= Items.Count - 1)))
			{
				Combobox.SelectedIndex = 0;
			}
			else
			{
				Combobox.SelectedIndex = SelectedIndex;
			}
		}
	}

	public static double GetDPIScale()
	{
		double result = 1.0;
		using (RegistryKey registryKey = Registry.LocalMachine.OpenSubKey("SOFTWARE\\Microsoft\\Windows NT\\CurrentVersion\\FontDPI"))
		{
			if (registryKey != null)
			{
				object value = registryKey.GetValue("LogPixels");
				if (value != null)
				{
					int num = (int)value;
					result = (double)num / 96.0;
				}
			}
		}
		return result;
	}

	public static void ShowKeyPad(Form Parent, Control Ctrl, string VarName = "", int Version = 1, string passchar = "")
	{
		try
		{
			bool flag = false;
			bool flag2 = false;
			bool flag3 = false;
			string text = " ";
			if (passchar.Length == 0)
			{
				text = passchar;
			}
			if (Ctrl != null)
			{
				if (Ctrl.GetType() == typeof(buTextBox))
				{
					flag2 = true;
					flag3 = true;
				}
				if (Ctrl.GetType() == typeof(TextBox))
				{
					flag2 = true;
				}
				if (Ctrl.GetType().BaseType == typeof(TextBox))
				{
					flag2 = true;
				}
				if (Ctrl.GetType() == typeof(buSpin))
				{
					flag = true;
					flag3 = true;
				}
				if (Ctrl.GetType() == typeof(NumericUpDown))
				{
					flag = true;
				}
				if (Ctrl.GetType().BaseType == typeof(NumericUpDown))
				{
					flag = true;
				}
				if (flag && Version == 1)
				{
					F_KeyPadNumV1 f_KeyPadNumV = new F_KeyPadNumV1();
					f_KeyPadNumV.Caption = VarName;
					if (text.Length > 0)
					{
						f_KeyPadNumV.textCtrl1.PasswordChar = char.Parse(text);
						f_KeyPadNumV.PasswordChar = char.Parse(text);
					}
					f_KeyPadNumV.StartPosition = FormStartPosition.CenterParent;
					f_KeyPadNumV.ShowDialog(((buSpin)Ctrl).Value.ToString(), Parent);
					if (!flag3)
					{
						((NumericUpDown)Ctrl).Value = decimal.Parse(f_KeyPadNumV.Value);
						((NumericUpDown)Ctrl).Select(0, 100);
					}
					else
					{
						((buSpin)Ctrl).Value = double.Parse(f_KeyPadNumV.Value);
						((buSpin)Ctrl).CursorToEnd();
					}
				}
				if (flag2 && Version == 1)
				{
					F_KeyPadCharV1 f_KeyPadCharV = new F_KeyPadCharV1();
					f_KeyPadCharV.Caption = VarName;
					if (text.Length > 0)
					{
						f_KeyPadCharV.textCtrl1.PasswordChar = char.Parse(text);
						f_KeyPadCharV.PasswordChar = char.Parse(text);
					}
					f_KeyPadCharV.StartPosition = FormStartPosition.CenterParent;
					f_KeyPadCharV.ShowDialog(((buTextBox)Ctrl).Text.ToString(), Parent);
					if (!flag3)
					{
						((TextBox)Ctrl).Text = f_KeyPadCharV.Value;
						((TextBox)Ctrl).Select(0, 500);
					}
					else
					{
						((buTextBox)Ctrl).Text = f_KeyPadCharV.Value;
						((buTextBox)Ctrl).CursorToEnd();
					}
				}
			}
			else
			{
				buString5.MessageBoxWarning("Null Control");
			}
		}
		catch (Exception mSException)
		{
			buLog.addLog("", "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: false, "");
		}
	}

	public static void ShowKeyPad(Form Parent, Control Ctrl, ref string Value, string VarName = "", int Version = 1, string passchar = "")
	{
		try
		{
			bool flag = false;
			bool flag2 = false;
			bool flag3 = false;
			string text = " ";
			if (passchar.Length == 0)
			{
				text = passchar;
			}
			if (Ctrl != null)
			{
				if (Ctrl.GetType() == typeof(buTextBox))
				{
					flag2 = true;
					flag3 = true;
				}
				if (Ctrl.GetType() == typeof(TextBox))
				{
					flag2 = true;
				}
				if (Ctrl.GetType().BaseType == typeof(TextBox))
				{
					flag2 = true;
				}
				if (Ctrl.GetType() == typeof(buSpin))
				{
					flag = true;
					flag3 = true;
				}
				if (Ctrl.GetType() == typeof(NumericUpDown))
				{
					flag = true;
				}
				if (Ctrl.GetType().BaseType == typeof(NumericUpDown))
				{
					flag = true;
				}
				if (flag && Version == 1)
				{
					F_KeyPadNumV1 f_KeyPadNumV = new F_KeyPadNumV1();
					f_KeyPadNumV.Caption = VarName;
					if (text.Length > 0)
					{
						f_KeyPadNumV.textCtrl1.PasswordChar = char.Parse(text);
						f_KeyPadNumV.PasswordChar = char.Parse(text);
					}
					f_KeyPadNumV.StartPosition = FormStartPosition.CenterParent;
					f_KeyPadNumV.ShowDialog(((buSpin)Ctrl).Value.ToString(), Parent);
					if (!flag3)
					{
						((NumericUpDown)Ctrl).Value = decimal.Parse(f_KeyPadNumV.Value);
						((NumericUpDown)Ctrl).Select(0, 100);
					}
					else
					{
						((buSpin)Ctrl).Value = double.Parse(f_KeyPadNumV.Value);
						((buSpin)Ctrl).CursorToEnd();
					}
				}
				if (flag2 && Version == 1)
				{
					F_KeyPadCharV1 f_KeyPadCharV = new F_KeyPadCharV1();
					f_KeyPadCharV.Caption = VarName;
					if (text.Length > 0)
					{
						f_KeyPadCharV.textCtrl1.PasswordChar = char.Parse(text);
						f_KeyPadCharV.PasswordChar = char.Parse(text);
					}
					f_KeyPadCharV.StartPosition = FormStartPosition.CenterParent;
					f_KeyPadCharV.ShowDialog(((buTextBox)Ctrl).Text.ToString(), Parent);
					if (!flag3)
					{
						((TextBox)Ctrl).Text = f_KeyPadCharV.Value;
						((TextBox)Ctrl).Select(0, 500);
					}
					else
					{
						((buTextBox)Ctrl).Text = f_KeyPadCharV.Value;
						((buTextBox)Ctrl).CursorToEnd();
					}
				}
			}
			else
			{
				F_KeyPadNumV1 f_KeyPadNumV2 = new F_KeyPadNumV1();
				f_KeyPadNumV2.Caption = VarName;
				if (text.Length > 0)
				{
					f_KeyPadNumV2.textCtrl1.PasswordChar = char.Parse(text);
					f_KeyPadNumV2.PasswordChar = char.Parse(text);
				}
				f_KeyPadNumV2.StartPosition = FormStartPosition.CenterParent;
				f_KeyPadNumV2.ShowDialog(Value, Parent);
				Value = f_KeyPadNumV2.Value;
			}
		}
		catch (Exception mSException)
		{
			buLog.addLog("", "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: false, "");
		}
	}

	public static void ShotDownPC()
	{
		if (buString5.MessageBoxQuestion(buLangTranslate.preSentences.DoYouWanttoClosePC) == DialogResult.Yes)
		{
			ProcessStartInfo processStartInfo = new ProcessStartInfo("shutdown", "/s /t 0");
			processStartInfo.CreateNoWindow = true;
			processStartInfo.UseShellExecute = false;
			Process.Start(processStartInfo);
		}
	}

	public static string GetDateAsString()
	{
		return DateTime.Now.Date.Year.ToString("D4") + DateTime.Now.Date.Month.ToString("D2") + DateTime.Now.Date.Day.ToString("D2");
	}

	public static string GetTimeAsString()
	{
		return DateTime.Now.Hour.ToString("D2") + DateTime.Now.Minute.ToString("D2") + DateTime.Now.Second.ToString("D2");
	}
}
