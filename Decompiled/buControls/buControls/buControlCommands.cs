using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Management;
using System.Net.NetworkInformation;
using System.Reflection;
using System.Threading;
using System.Windows.Forms;
using buClass;
using buControls.Controls;
using buControls.Forms.WinControlForms.KeyPad;
using buControls.Forms.buControlForms.KeyPad;
using buCore;
using ns27;

namespace buControls;

public class buControlCommands
{
	internal static bool bool_0 = false;

	public static string sClass = "buControlCommands";

	public buControlCommands()
	{
		if (!smethod_0("buControlCommands"))
		{
			throw new RegisterException("buControlCommands");
		}
	}

	internal static bool smethod_0(string string_0)
	{
		try
		{
			if (!(string_0 == "buViewerBrooOpen"))
			{
				if (!((buVector.AskMeResult != "TesxCEguItdxXery89+dxdx+456(9004dxXXx5678X4Dfgytex &7fdxHRewxWw2") | (buVector.AskMeValue != -5861345679435.912)))
				{
					bool_0 = true;
					return true;
				}
				BinaryReader binaryReader = null;
				try
				{
					FileInfo fileInfo = new FileInfo(AppPath.Base + "\\mnbucfd.dll");
					if (fileInfo.Exists)
					{
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
							buLogVer5.addToLog("DefK", "Mode 14100", "mnb", "1", 0.0, 0.0);
							FileStream input = new FileStream(fileInfo.FullName, FileMode.Open, FileAccess.Read, FileShare.None);
							binaryReader = new BinaryReader(input);
							int num = 0;
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
							decimal num2 = default(decimal);
							int num3 = 0;
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
								num2 = binaryReader.ReadDecimal();
							}
							for (int l = 0; l < 5614; l++)
							{
								_ = (double)binaryReader.ReadInt32();
							}
							for (int m = 0; m < 4243; m++)
							{
								binaryReader.ReadSingle();
							}
							for (int n = 0; n < 9867; n++)
							{
								binaryReader.ReadDouble();
							}
							for (int num4 = 0; num4 < 3886; num4++)
							{
								num2 = binaryReader.ReadDecimal();
							}
							for (int num5 = 0; num5 < 5765; num5++)
							{
								_ = (double)binaryReader.ReadInt32();
							}
							num3 = binaryReader.ReadInt32();
							list.Clear();
							list2.Clear();
							list3.Clear();
							for (int num6 = 0; num6 <= num3 - 1; num6++)
							{
								double num7 = 0.0;
								num7 = binaryReader.ReadDouble() / 65.87;
								list.Add(num7);
								int num8 = binaryReader.ReadInt32();
								string text15 = "";
								for (int num9 = 0; num9 < num8; num9++)
								{
									byte value = Convert.ToByte(binaryReader.ReadDouble() / 46.8613);
									text15 += Convert.ToChar(value);
								}
								list2.Add(text15);
								num8 = binaryReader.ReadInt32();
								string text16 = "";
								for (int num10 = 0; num10 < num8; num10++)
								{
									byte value2 = Convert.ToByte(binaryReader.ReadDouble() / 86.3456);
									text16 += Convert.ToChar(value2);
								}
								list3.Add(text16);
							}
							num = binaryReader.ReadInt32();
							for (int num11 = 0; num11 < num; num11++)
							{
								byte value3 = Convert.ToByte(binaryReader.ReadDouble() / 54.3685);
								text += Convert.ToChar(value3);
							}
							num = binaryReader.ReadInt32();
							for (int num12 = 0; num12 < num; num12++)
							{
								byte value4 = Convert.ToByte(binaryReader.ReadDouble() / 54.3685);
								text2 += Convert.ToChar(value4);
							}
							num = binaryReader.ReadInt32();
							for (int num13 = 0; num13 < num; num13++)
							{
								byte value5 = Convert.ToByte(binaryReader.ReadDouble() / 54.3685);
								text3 += Convert.ToChar(value5);
							}
							num = binaryReader.ReadInt32();
							for (int num14 = 0; num14 < num; num14++)
							{
								byte value6 = Convert.ToByte(binaryReader.ReadDouble() / 54.3685);
								text4 += Convert.ToChar(value6);
							}
							num = binaryReader.ReadInt32();
							for (int num15 = 0; num15 < num; num15++)
							{
								byte value7 = Convert.ToByte(binaryReader.ReadDouble() / 54.3685);
								text5 += Convert.ToChar(value7);
							}
							num = binaryReader.ReadInt32();
							for (int num16 = 0; num16 < num; num16++)
							{
								byte value8 = Convert.ToByte(binaryReader.ReadDouble() / 54.3685);
								text6 += Convert.ToChar(value8);
							}
							num = binaryReader.ReadInt32();
							for (int num17 = 0; num17 < num; num17++)
							{
								byte value9 = Convert.ToByte(binaryReader.ReadDouble() / 54.3685);
								text7 += Convert.ToChar(value9);
							}
							num = binaryReader.ReadInt32();
							for (int num18 = 0; num18 < num; num18++)
							{
								byte value10 = Convert.ToByte(binaryReader.ReadDouble() / 54.3685);
								text8 += Convert.ToChar(value10);
							}
							num = binaryReader.ReadInt32();
							for (int num19 = 0; num19 < num; num19++)
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
							num = binaryReader.ReadInt32();
							for (int num20 = 0; num20 < num; num20++)
							{
								byte value12 = Convert.ToByte(binaryReader.ReadDouble() / 64.3685);
								text10 += Convert.ToChar(value12);
							}
							num = binaryReader.ReadInt32();
							for (int num21 = 0; num21 < num; num21++)
							{
								byte value13 = Convert.ToByte(binaryReader.ReadDouble() / 64.3685);
								text11 += Convert.ToChar(value13);
							}
							num = binaryReader.ReadInt32();
							for (int num22 = 0; num22 < num; num22++)
							{
								byte value14 = Convert.ToByte(binaryReader.ReadDouble() / 64.3685);
								text12 += Convert.ToChar(value14);
							}
							num = binaryReader.ReadInt32();
							for (int num23 = 0; num23 < num; num23++)
							{
								byte value15 = Convert.ToByte(binaryReader.ReadDouble() / 64.3685);
								text13 += Convert.ToChar(value15);
							}
							num = binaryReader.ReadInt32();
							for (int num24 = 0; num24 < num; num24++)
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
							buLogVer5.addToLog("DefK", "Mode 14101", "mnb", "100", 0.0, 0.0);
						}
						catch (Exception ex)
						{
							MessageBox.Show(ex.Message);
							binaryReader.Close();
							throw new RegisterException(string_0);
						}
						List<string> MacAddress = new List<string>();
						List<string> CpuAddress = new List<string>();
						string MBAddress = "";
						getMacAddress(ref MacAddress);
						buLogVer5.addToLog("DefK", "Mode 14102", "mnb", "100", 0.0, 0.0);
						getCpuID(ref CpuAddress);
						buLogVer5.addToLog("DefK", "Mode 14103", "mnb", "100", 0.0, 0.0);
						GetMotherBoardID(ref MBAddress);
						buLogVer5.addToLog("DefK", "Mode 14104", "mnb", "100", 0.0, 0.0);
						if (!flag && !flag2)
						{
							bool flag3 = Class76.smethod_817(MacAddress, MBAddress, string_0, CpuAddress, list);
							buLogVer5.addToLog("DefK", "Mode 14104", "mnb", "100", 0.0, 0.0);
							if (flag3)
							{
								bool_0 = true;
								return true;
							}
						}
						throw new RegisterException(string_0);
					}
					throw new RegisterException(string_0);
				}
				catch (Exception)
				{
					throw new RegisterException(string_0);
				}
			}
			return true;
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

	public static buButton CopyControl(buButton refControl)
	{
		buButton buButton2 = null;
		if (refControl != null)
		{
			buButton2 = refControl.DeepClone();
		}
		buButton2.Display = buControlDisplay.Copy(refControl.Display, buButton2.Display);
		buButton2.ButtonDownDisplay = new buControlDisplay(refControl.ButtonDownDisplay);
		buButton2.ButtonOverDisplay = new buControlDisplay(refControl.ButtonOverDisplay);
		return buButton2;
	}

	public static buControl CloneControlSafe(buControl source)
	{
		buControl buControl2 = (buControl)Activator.CreateInstance(source.GetType());
		foreach (PropertyDescriptor property in TypeDescriptor.GetProperties(source))
		{
			if (!property.IsReadOnly)
			{
				try
				{
					property.SetValue(buControl2, property.GetValue(source));
				}
				catch
				{
				}
			}
		}
		return buControl2;
	}

	public static buControl CloneControl(buControl source)
	{
		Dictionary<object, object> dictionary_ = new Dictionary<object, object>();
		return (buControl)Class76.smethod_260((object)source, dictionary_);
	}

	public static DataGridViewColumn DataGridViewColumbSet(int width, string headertext, string name, bool isTextbased = true, string fontname = "Arial", int fontsize = 10, bool readOnly = false, bool iscentertext = false)
	{
		DataGridViewColumn dataGridViewColumn = new DataGridViewColumn();
		dataGridViewColumn.Name = name;
		dataGridViewColumn.Width = width;
		dataGridViewColumn.HeaderText = headertext;
		dataGridViewColumn.ReadOnly = readOnly;
		dataGridViewColumn.SortMode = DataGridViewColumnSortMode.NotSortable;
		dataGridViewColumn.DefaultCellStyle.Font = new Font(fontname, fontsize, FontStyle.Bold);
		dataGridViewColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
		dataGridViewColumn.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
		dataGridViewColumn.HeaderCell.Style.BackColor = Color.Gray;
		dataGridViewColumn.HeaderCell.Style.Font = new Font(fontname, fontsize, FontStyle.Bold);
		if (iscentertext)
		{
			dataGridViewColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
			dataGridViewColumn.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
		}
		if (isTextbased)
		{
			dataGridViewColumn.CellTemplate = new DataGridViewTextBoxCell();
		}
		return dataGridViewColumn;
	}

	public static DataGridViewColumn DataGridViewColumbSetCombobox(int width, string headertext, string name, Type Enums, string fontname = "Arial", int fontsize = 10, bool readOnly = false, bool iscentertext = false)
	{
		DataGridViewColumn dataGridViewColumn = new DataGridViewComboBoxColumn();
		dataGridViewColumn.Name = name;
		dataGridViewColumn.Width = width;
		dataGridViewColumn.HeaderText = headertext;
		dataGridViewColumn.ReadOnly = readOnly;
		dataGridViewColumn.SortMode = DataGridViewColumnSortMode.NotSortable;
		dataGridViewColumn.DefaultCellStyle.Font = new Font(fontname, fontsize, FontStyle.Bold);
		dataGridViewColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
		dataGridViewColumn.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
		dataGridViewColumn.HeaderCell.Style.BackColor = Color.Gray;
		dataGridViewColumn.HeaderCell.Style.Font = new Font(fontname, fontsize, FontStyle.Bold);
		if (iscentertext)
		{
			dataGridViewColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
			dataGridViewColumn.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
		}
		List<string> list = new List<string>();
		list = buConversion.EnumToString(Enums);
		for (int i = 0; i <= list.Count - 1; i++)
		{
			((DataGridViewComboBoxColumn)dataGridViewColumn).Items.Add(list[i]);
		}
		return dataGridViewColumn;
	}

	public static void ComboboxAddItem(ArrayList Items, int SelectedIndex, ref buComboBox Combobox)
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

	public static void GetControlsInContainer(Control.ControlCollection Controls, ref List<Control> FoundControls)
	{
		for (int i = 0; i <= Controls.Count - 1; i++)
		{
			Control control = Controls[i];
			if (!(control is TextBox || control is NumericUpDown || control is buTextBox || control is buSpin))
			{
				if (!(control is Panel || control is buPanel || control is GroupBox || control is buGroup || control is TabPage))
				{
					continue;
				}
				List<Control> FoundControls2 = new List<Control>();
				GetControlsInContainer(control.Controls, ref FoundControls2);
				if (FoundControls2.Count > 0)
				{
					for (int j = 0; j <= FoundControls2.Count - 1; j++)
					{
						FoundControls.Add(FoundControls2[j]);
					}
				}
			}
			else if (control.Visible & control.Enabled)
			{
				FoundControls.Add(control);
			}
		}
	}

	public static void FindNextControlByKeyDown(Control.ControlCollection Controls, int ActualIndex, bool ShiftPressed)
	{
		List<Control> list = new List<Control>();
		for (int i = 0; i <= Controls.Count - 1; i++)
		{
			Controls[i].GetType().ToString();
			Control control = Controls[i];
			if ((Controls[i] is buPanel) | (Controls[i] is Panel) | (Controls[i] is TabPage))
			{
				List<Control> FoundControls = new List<Control>();
				GetControlsInContainer(Controls[i].Controls, ref FoundControls);
				if (FoundControls.Count > 0)
				{
					for (int j = 0; j <= FoundControls.Count - 1; j++)
					{
						list.Add(FoundControls[j]);
					}
				}
			}
			if (((control.GetType() == typeof(buSpin)) | (control.GetType() == typeof(buTextBox)) | (control.GetType() == typeof(NumericUpDown)) | (control.GetType() == typeof(TextBox))) && (control.Enabled & control.Visible))
			{
				list.Add(control);
			}
		}
		if (list.Count <= 1)
		{
			return;
		}
		int num = int.MaxValue;
		int num2 = -1;
		for (int k = 0; k <= list.Count - 1; k++)
		{
			if (list[k].Tag != null)
			{
				int result = 0;
				int.TryParse(list[k].Tag.ToString(), out result);
				int num3 = result - ActualIndex;
				if (num3 > 0 && num3 < num)
				{
					num = num3;
					num2 = k;
				}
			}
		}
		if (num2 == -1)
		{
			num = int.MaxValue;
			for (int l = 0; l <= list.Count - 1; l++)
			{
				if (list[l].Tag != null)
				{
					int result2 = 0;
					int.TryParse(list[l].Tag.ToString(), out result2);
					int num4 = result2 - ActualIndex;
					if (num4 < 0 && num4 < num)
					{
						num = num4;
						num2 = l;
					}
				}
			}
		}
		if (num2 >= 0)
		{
			if (list[num2] is buSpin)
			{
				((buSpin)list[num2]).SelectAll();
			}
			if (list[num2] is buTextBox)
			{
				((buTextBox)list[num2]).SelectAll();
			}
			if (list[num2] is NumericUpDown)
			{
				((NumericUpDown)list[num2]).Select(0, 100);
			}
			if (list[num2] is TextBox)
			{
				((TextBox)list[num2]).Select(0, 100);
			}
			list[num2].Select();
		}
	}

	public static void FindNextControlByKey(Control.ControlCollection Controls, int ActualIndex, bool ShiftPressed)
	{
		int num = int.MaxValue;
		int num2 = int.MaxValue;
		Control control = null;
		Control control2 = null;
		Control control3 = null;
		for (int i = 0; i <= Controls.Count - 1; i++)
		{
			Controls[i].GetType().ToString();
			Control control4 = Controls[i];
			if ((Controls[i].GetType() == typeof(buPanel)) | (Controls[i].GetType() == typeof(Panel)))
			{
				for (int j = 0; j <= Controls[i].Controls.Count - 1; j++)
				{
					Control control5 = Controls[i].Controls[j];
					if (!((control5.GetType() == typeof(buSpin)) | (control5.GetType() == typeof(buTextBox)) | (control5.GetType() == typeof(NumericUpDown)) | (control5.GetType() == typeof(TextBox))))
					{
						continue;
					}
					Control control6 = null;
					bool flag = false;
					bool flag2 = false;
					if (control5.GetType() == typeof(buSpin))
					{
						control6 = new buSpin();
						control6 = (buSpin)control5;
						flag = ((buSpin)control5).Visible;
						flag2 = ((buSpin)control5).Enabled;
					}
					if (control5.GetType() == typeof(buTextBox))
					{
						control6 = new buTextBox();
						control6 = (buTextBox)control5;
						flag = ((buTextBox)control5).Visible;
						flag2 = ((buTextBox)control5).Enabled;
					}
					if (control5.GetType() == typeof(NumericUpDown))
					{
						control6 = new NumericUpDown();
						control6 = (NumericUpDown)control5;
						flag = ((NumericUpDown)control5).Visible;
						flag2 = ((NumericUpDown)control5).Enabled;
					}
					if (control5.GetType() == typeof(TextBox))
					{
						control6 = new TextBox();
						control6 = (TextBox)control5;
						flag = ((TextBox)control5).Visible;
						flag2 = ((TextBox)control5).Enabled;
					}
					if (!(flag && flag2))
					{
						continue;
					}
					if (control6.Tag != null && !ShiftPressed)
					{
						int num3 = int.Parse(control6.Tag.ToString());
						if (num3 == 0)
						{
							control3 = control6;
						}
						if ((num3 > ActualIndex && num3 - ActualIndex < num) & control6.Enabled)
						{
							num = num3 - ActualIndex;
							control = control6;
						}
						if ((num3 < ActualIndex && ActualIndex - num3 < num2) & control6.Enabled)
						{
							num2 = ActualIndex - num3;
							control2 = control6;
						}
					}
					if (control6.Tag != null && ShiftPressed)
					{
						int num4 = int.Parse(control6.Tag.ToString());
						if (num4 == 0)
						{
							control3 = control6;
						}
						if ((num4 < ActualIndex && ActualIndex - num4 < num) & control6.Enabled)
						{
							num = ActualIndex - num4;
							control = control6;
						}
						if ((num4 < ActualIndex && ActualIndex - num4 < num2) & control6.Enabled)
						{
							num2 = ActualIndex - num4;
							control2 = control6;
						}
					}
				}
			}
			if (!((control4.GetType() == typeof(buSpin)) | (control4.GetType() == typeof(buTextBox)) | (control4.GetType() == typeof(NumericUpDown)) | (control4.GetType() == typeof(TextBox))))
			{
				continue;
			}
			Control control7 = null;
			bool flag3 = false;
			bool flag4 = false;
			if (control4.GetType() == typeof(buSpin))
			{
				control7 = new buSpin();
				control7 = (buSpin)control4;
				flag3 = ((buSpin)control4).Visible;
				flag4 = ((buSpin)control4).Enabled;
			}
			if (control4.GetType() == typeof(buTextBox))
			{
				control7 = new buTextBox();
				control7 = (buTextBox)control4;
				flag3 = ((buTextBox)control4).Visible;
				flag4 = ((buTextBox)control4).Enabled;
			}
			if (control4.GetType() == typeof(NumericUpDown))
			{
				control7 = new NumericUpDown();
				control7 = (NumericUpDown)control4;
				flag3 = ((NumericUpDown)control4).Visible;
				flag4 = ((NumericUpDown)control4).Enabled;
			}
			if (control4.GetType() == typeof(TextBox))
			{
				control7 = new TextBox();
				control7 = (TextBox)control4;
				flag3 = ((TextBox)control4).Visible;
				flag4 = ((TextBox)control4).Enabled;
			}
			if (!(flag3 && flag4))
			{
				continue;
			}
			if (control7.Tag != null && !ShiftPressed)
			{
				int num5 = int.Parse(control7.Tag.ToString());
				if (num5 == 0)
				{
					control3 = control7;
				}
				if ((num5 > ActualIndex && num5 - ActualIndex < num) & control7.Enabled)
				{
					num = num5 - ActualIndex;
					control = control7;
				}
				if (!((num5 < ActualIndex && ActualIndex - num5 < num) & control7.Enabled))
				{
				}
			}
			if (control7.Tag != null && ShiftPressed)
			{
				int num6 = int.Parse(control7.Tag.ToString());
				if (num6 == 0)
				{
					control3 = control7;
				}
				if ((num6 < ActualIndex && ActualIndex - num6 < num) & control7.Enabled)
				{
					num = ActualIndex - num6;
					control = control7;
				}
			}
		}
		if (control == null && control3 == null && control2 != null)
		{
			control3 = control2;
		}
		if (control != null)
		{
			if (control.GetType() == typeof(buSpin))
			{
				((buSpin)control).SelectAll();
			}
			if (control.GetType() == typeof(buTextBox))
			{
				((buTextBox)control).SelectAll();
			}
			if (control.GetType() == typeof(NumericUpDown))
			{
				((NumericUpDown)control).Select(0, 100);
			}
			if (control.GetType() == typeof(TextBox))
			{
				((TextBox)control).Select(0, 100);
			}
			control.Select();
		}
		else if (control3 != null)
		{
			if (control3.GetType() == typeof(buSpin))
			{
				((buSpin)control3).SelectAll();
			}
			if (control3.GetType() == typeof(buTextBox))
			{
				((buTextBox)control3).SelectAll();
			}
			if (control3.GetType() == typeof(NumericUpDown))
			{
				((NumericUpDown)control3).Select(0, 100);
			}
			if (control3.GetType() == typeof(TextBox))
			{
				((TextBox)control3).Select(0, 100);
			}
			control3.Select();
		}
	}

	public static void ShowKeyPad(Form Parent, Control Ctrl, int Version, string passchar = "")
	{
		if (Ctrl.GetType() == typeof(buSpin))
		{
			buControls.Forms.buControlForms.KeyPad.F_KeyPad f_KeyPad = new buControls.Forms.buControlForms.KeyPad.F_KeyPad();
			f_KeyPad.textCtrl1.PasswordChar = char.Parse(passchar);
			f_KeyPad.PasswordChar = char.Parse(passchar);
			f_KeyPad.StartPosition = FormStartPosition.CenterParent;
			f_KeyPad.ShowDialog(((buSpin)Ctrl).Value.ToString(), Parent);
			((buSpin)Ctrl).Value = double.Parse(f_KeyPad.Value);
			((buSpin)Ctrl).CursorToEnd();
		}
		if (Ctrl.GetType() == typeof(buTextBox))
		{
			buControls.Forms.buControlForms.KeyPad.F_KeyPadAlpha f_KeyPadAlpha = new buControls.Forms.buControlForms.KeyPad.F_KeyPadAlpha();
			f_KeyPadAlpha.textCtrl1.PasswordChar = char.Parse(passchar);
			f_KeyPadAlpha.PasswordChar = char.Parse(passchar);
			f_KeyPadAlpha.StartPosition = FormStartPosition.CenterParent;
			f_KeyPadAlpha.ShowDialog(((buTextBox)Ctrl).Text.ToString(), Parent);
			((buTextBox)Ctrl).Text = f_KeyPadAlpha.Value;
			((buTextBox)Ctrl).CursorToEnd();
		}
		if (Ctrl.GetType() == typeof(NumericUpDown))
		{
			buControls.Forms.buControlForms.KeyPad.F_KeyPad f_KeyPad2 = new buControls.Forms.buControlForms.KeyPad.F_KeyPad();
			f_KeyPad2.textCtrl1.PasswordChar = char.Parse(passchar);
			f_KeyPad2.PasswordChar = char.Parse(passchar);
			f_KeyPad2.StartPosition = FormStartPosition.CenterParent;
			f_KeyPad2.ShowDialog(((NumericUpDown)Ctrl).Value.ToString(), Parent);
			((NumericUpDown)Ctrl).Value = decimal.Parse(f_KeyPad2.Value);
			((NumericUpDown)Ctrl).Select(0, 100);
		}
		if (Ctrl.GetType() == typeof(TextBox))
		{
			buControls.Forms.buControlForms.KeyPad.F_KeyPadAlpha f_KeyPadAlpha2 = new buControls.Forms.buControlForms.KeyPad.F_KeyPadAlpha();
			f_KeyPadAlpha2.textCtrl1.PasswordChar = char.Parse(passchar);
			f_KeyPadAlpha2.PasswordChar = char.Parse(passchar);
			f_KeyPadAlpha2.StartPosition = FormStartPosition.CenterParent;
			f_KeyPadAlpha2.ShowDialog(((TextBox)Ctrl).Text.ToString(), Parent);
			((TextBox)Ctrl).Text = f_KeyPadAlpha2.Value;
			((TextBox)Ctrl).Select(0, 500);
		}
		if (Ctrl.GetType().BaseType == typeof(NumericUpDown))
		{
			buControls.Forms.buControlForms.KeyPad.F_KeyPad f_KeyPad3 = new buControls.Forms.buControlForms.KeyPad.F_KeyPad();
			f_KeyPad3.textCtrl1.PasswordChar = char.Parse(passchar);
			f_KeyPad3.PasswordChar = char.Parse(passchar);
			f_KeyPad3.StartPosition = FormStartPosition.CenterParent;
			f_KeyPad3.ShowDialog(((NumericUpDown)Ctrl).Value.ToString(), Parent);
			((NumericUpDown)Ctrl).Value = decimal.Parse(f_KeyPad3.Value);
			((NumericUpDown)Ctrl).Select(0, 100);
		}
		if (Ctrl.GetType().BaseType == typeof(TextBox))
		{
			buControls.Forms.buControlForms.KeyPad.F_KeyPadAlpha f_KeyPadAlpha3 = new buControls.Forms.buControlForms.KeyPad.F_KeyPadAlpha();
			f_KeyPadAlpha3.textCtrl1.PasswordChar = char.Parse(passchar);
			f_KeyPadAlpha3.PasswordChar = char.Parse(passchar);
			f_KeyPadAlpha3.StartPosition = FormStartPosition.CenterParent;
			f_KeyPadAlpha3.ShowDialog(((TextBox)Ctrl).Text.ToString(), Parent);
			((TextBox)Ctrl).Text = f_KeyPadAlpha3.Value;
			((TextBox)Ctrl).Select(0, 500);
		}
	}

	public static void ShowKeyPad(Form Parent, Control Ctrl, string passchar = "")
	{
		if (Ctrl.GetType() == typeof(buSpin))
		{
			buControls.Forms.buControlForms.KeyPad.F_KeyPad f_KeyPad = new buControls.Forms.buControlForms.KeyPad.F_KeyPad();
			if (passchar.Length > 0)
			{
				f_KeyPad.textCtrl1.PasswordChar = char.Parse(passchar);
			}
			f_KeyPad.StartPosition = FormStartPosition.CenterParent;
			f_KeyPad.ShowDialog(((buSpin)Ctrl).Value.ToString(), Parent);
			((buSpin)Ctrl).Value = double.Parse(f_KeyPad.Value);
			((buSpin)Ctrl).CursorToEnd();
		}
		if (Ctrl.GetType() == typeof(buTextBox))
		{
			buControls.Forms.buControlForms.KeyPad.F_KeyPadAlpha f_KeyPadAlpha = new buControls.Forms.buControlForms.KeyPad.F_KeyPadAlpha();
			if (passchar.Length > 0)
			{
				f_KeyPadAlpha.textCtrl1.PasswordChar = char.Parse(passchar);
			}
			f_KeyPadAlpha.StartPosition = FormStartPosition.CenterParent;
			f_KeyPadAlpha.ShowDialog(((buTextBox)Ctrl).Text.ToString(), Parent);
			((buTextBox)Ctrl).Text = f_KeyPadAlpha.Value;
			((buTextBox)Ctrl).CursorToEnd();
		}
		if (Ctrl.GetType() == typeof(NumericUpDown))
		{
			buControls.Forms.buControlForms.KeyPad.F_KeyPad f_KeyPad2 = new buControls.Forms.buControlForms.KeyPad.F_KeyPad();
			if (passchar.Length > 0)
			{
				f_KeyPad2.textCtrl1.PasswordChar = char.Parse(passchar);
			}
			f_KeyPad2.StartPosition = FormStartPosition.CenterParent;
			f_KeyPad2.ShowDialog(((NumericUpDown)Ctrl).Value.ToString(), Parent);
			((NumericUpDown)Ctrl).Value = decimal.Parse(f_KeyPad2.Value);
			((NumericUpDown)Ctrl).Select(0, 100);
		}
		if (Ctrl.GetType() == typeof(TextBox))
		{
			buControls.Forms.buControlForms.KeyPad.F_KeyPadAlpha f_KeyPadAlpha2 = new buControls.Forms.buControlForms.KeyPad.F_KeyPadAlpha();
			f_KeyPadAlpha2.StartPosition = FormStartPosition.CenterParent;
			f_KeyPadAlpha2.ShowDialog(((TextBox)Ctrl).Text.ToString(), Parent);
			((TextBox)Ctrl).Text = f_KeyPadAlpha2.Value;
			((TextBox)Ctrl).Select(0, 500);
		}
		if (Ctrl.GetType().BaseType == typeof(NumericUpDown))
		{
			buControls.Forms.buControlForms.KeyPad.F_KeyPad f_KeyPad3 = new buControls.Forms.buControlForms.KeyPad.F_KeyPad();
			f_KeyPad3.StartPosition = FormStartPosition.CenterParent;
			f_KeyPad3.ShowDialog(((NumericUpDown)Ctrl).Value.ToString(), Parent);
			((NumericUpDown)Ctrl).Value = decimal.Parse(f_KeyPad3.Value);
			((NumericUpDown)Ctrl).Select(0, 100);
		}
		if (Ctrl.GetType().BaseType == typeof(TextBox))
		{
			buControls.Forms.buControlForms.KeyPad.F_KeyPadAlpha f_KeyPadAlpha3 = new buControls.Forms.buControlForms.KeyPad.F_KeyPadAlpha();
			f_KeyPadAlpha3.StartPosition = FormStartPosition.CenterParent;
			f_KeyPadAlpha3.ShowDialog(((TextBox)Ctrl).Text.ToString(), Parent);
			((TextBox)Ctrl).Text = f_KeyPadAlpha3.Value;
			((TextBox)Ctrl).Select(0, 500);
		}
	}

	public static void ShowKeyPad(Form Parent, Control Ctrl, TouchPadType Type)
	{
		if (Ctrl.GetType() == typeof(buSpin) && Type == TouchPadType.buControlStyleBasic)
		{
			buControls.Forms.buControlForms.KeyPad.F_KeyPad f_KeyPad = new buControls.Forms.buControlForms.KeyPad.F_KeyPad();
			f_KeyPad.StartPosition = FormStartPosition.CenterParent;
			f_KeyPad.ShowDialog(((buSpin)Ctrl).Value.ToString(), Parent);
			((buSpin)Ctrl).Value = double.Parse(f_KeyPad.Value);
			((buSpin)Ctrl).CursorToEnd();
		}
		if (Ctrl.GetType() == typeof(buTextBox) && Type == TouchPadType.buControlStyleBasic)
		{
			buControls.Forms.buControlForms.KeyPad.F_KeyPadAlpha f_KeyPadAlpha = new buControls.Forms.buControlForms.KeyPad.F_KeyPadAlpha();
			f_KeyPadAlpha.StartPosition = FormStartPosition.CenterParent;
			f_KeyPadAlpha.ShowDialog(((buTextBox)Ctrl).Text.ToString(), Parent);
			((buTextBox)Ctrl).Text = f_KeyPadAlpha.Value;
			((buTextBox)Ctrl).CursorToEnd();
		}
		if ((Ctrl.GetType() == typeof(NumericUpDown)) | (Ctrl.GetType().BaseType == typeof(NumericUpDown)))
		{
			if (Type == TouchPadType.buControlStyleBasic)
			{
				buControls.Forms.buControlForms.KeyPad.F_KeyPad f_KeyPad2 = new buControls.Forms.buControlForms.KeyPad.F_KeyPad();
				f_KeyPad2.StartPosition = FormStartPosition.CenterParent;
				f_KeyPad2.ShowDialog(((NumericUpDown)Ctrl).Value.ToString(), Parent);
				f_KeyPad2.TopMost = true;
				((NumericUpDown)Ctrl).Value = decimal.Parse(f_KeyPad2.Value);
				((NumericUpDown)Ctrl).Select(0, 100);
			}
			if (Type == TouchPadType.buControlStyleEagle)
			{
				F_NumVar f_NumVar = new F_NumVar();
				f_NumVar.StartPosition = FormStartPosition.CenterParent;
				f_NumVar.ShowDialog(((NumericUpDown)Ctrl).Value.ToString(), Parent);
				((NumericUpDown)Ctrl).Value = Convert.ToDecimal(f_NumVar.Value);
				((NumericUpDown)Ctrl).Select(0, 100);
			}
		}
		if ((Ctrl.GetType() == typeof(TextBox)) | (Ctrl.GetType().BaseType == typeof(TextBox)))
		{
			if (Type == TouchPadType.buControlStyleBasic)
			{
				buControls.Forms.buControlForms.KeyPad.F_KeyPadAlpha f_KeyPadAlpha2 = new buControls.Forms.buControlForms.KeyPad.F_KeyPadAlpha();
				f_KeyPadAlpha2.StartPosition = FormStartPosition.CenterParent;
				f_KeyPadAlpha2.ShowDialog(((TextBox)Ctrl).Text.ToString(), Parent);
				((TextBox)Ctrl).Text = f_KeyPadAlpha2.Value;
				((TextBox)Ctrl).Select(0, 500);
			}
			if (Type == TouchPadType.buControlStyleEagle)
			{
				F_Keyboard f_Keyboard = new F_Keyboard();
				f_Keyboard.StartPosition = FormStartPosition.CenterParent;
				f_Keyboard.ShowDialog(((TextBox)Ctrl).Text.ToString(), Parent);
				((TextBox)Ctrl).Text = f_Keyboard.Value;
				((TextBox)Ctrl).Select(0, 500);
			}
		}
	}

	public static void ShowKeyPadWinControl(Form Parent, Control Ctrl)
	{
		if (Ctrl.GetType() == typeof(buSpin))
		{
			buControls.Forms.WinControlForms.KeyPad.F_KeyPad f_KeyPad = new buControls.Forms.WinControlForms.KeyPad.F_KeyPad();
			f_KeyPad.StartPosition = FormStartPosition.CenterParent;
			f_KeyPad.ShowDialog(((buSpin)Ctrl).Value.ToString(), Parent);
			((buSpin)Ctrl).Value = double.Parse(f_KeyPad.Value);
			((buSpin)Ctrl).CursorToEnd();
		}
		if (Ctrl.GetType() == typeof(buTextBox))
		{
			buControls.Forms.WinControlForms.KeyPad.F_KeyPadAlpha f_KeyPadAlpha = new buControls.Forms.WinControlForms.KeyPad.F_KeyPadAlpha();
			f_KeyPadAlpha.StartPosition = FormStartPosition.CenterParent;
			f_KeyPadAlpha.ShowDialog(((buTextBox)Ctrl).Text.ToString(), Parent);
			((buTextBox)Ctrl).Text = f_KeyPadAlpha.Value;
			((buTextBox)Ctrl).CursorToEnd();
		}
		if (Ctrl.GetType() == typeof(NumericUpDown))
		{
			buControls.Forms.WinControlForms.KeyPad.F_KeyPad f_KeyPad2 = new buControls.Forms.WinControlForms.KeyPad.F_KeyPad();
			f_KeyPad2.StartPosition = FormStartPosition.CenterParent;
			f_KeyPad2.ShowDialog(((NumericUpDown)Ctrl).Value.ToString(), Parent);
			((NumericUpDown)Ctrl).Value = decimal.Parse(f_KeyPad2.Value);
			((NumericUpDown)Ctrl).Select(0, 100);
		}
		if (Ctrl.GetType() == typeof(TextBox))
		{
			buControls.Forms.WinControlForms.KeyPad.F_KeyPadAlpha f_KeyPadAlpha2 = new buControls.Forms.WinControlForms.KeyPad.F_KeyPadAlpha();
			f_KeyPadAlpha2.StartPosition = FormStartPosition.CenterParent;
			f_KeyPadAlpha2.ShowDialog(((TextBox)Ctrl).Text.ToString(), Parent);
			((TextBox)Ctrl).Text = f_KeyPadAlpha2.Value;
			((TextBox)Ctrl).Select(0, 500);
		}
	}

	public static void ListboxAddFiles(List<string> Files, bool UseDirecotory, bool UseExtension, ref buListBox Listbox)
	{
		try
		{
			Listbox.Items.Clear();
			for (int i = 0; i <= Files.Count - 1; i++)
			{
				FileEventArg item = new FileEventArg(Files[i]);
				string text = Files[i];
				if (!UseDirecotory)
				{
					text = buFile.getFileName(text);
				}
				if (!UseExtension)
				{
					text = buFile.getFileNameWithoutExtension(text);
				}
				if (text.Length > 0)
				{
					Listbox.Items.Add(item);
				}
			}
		}
		catch (Exception mSException)
		{
			buLog.addLog("", "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: true, "");
		}
	}

	public static void SetButtonColor(buContainerControl Owner, buControlDisplay Display, buControlDisplay DisplayOver, buControlDisplay DisplayDown)
	{
		for (int i = 0; i <= Owner.Controls.Count - 1; i++)
		{
			if (Owner.Controls[i].GetType() == typeof(buButton))
			{
				((buButton)Owner.Controls[i]).Display = new buControlDisplay(Display);
				((buButton)Owner.Controls[i]).ButtonDownDisplay = new buControlDisplay(DisplayDown);
				((buButton)Owner.Controls[i]).ButtonOverDisplay = new buControlDisplay(DisplayOver);
			}
		}
	}

	public static buButton SetButtonColor(buButton Display, Color clr)
	{
		Display.Display.BackColor = clr;
		Display.Display.GradientType = GradientMode.Solid;
		Display.ButtonDownDisplay.BackColor = clr;
		Display.ButtonDownDisplay.GradientType = GradientMode.Solid;
		Display.ButtonOverDisplay.BackColor = clr;
		Display.ButtonOverDisplay.GradientType = GradientMode.Solid;
		return Display;
	}

	public static buButton SetButtonColorAll(buButton Display, Color clr)
	{
		Display.Display.BackColor = clr;
		Display.Display.LineerGradient.FirstColor = clr;
		Display.Display.LineerGradient.SecondColor = clr;
		Display.ButtonDownDisplay.BackColor = clr;
		Display.ButtonDownDisplay.LineerGradient.FirstColor = clr;
		Display.ButtonDownDisplay.LineerGradient.SecondColor = clr;
		Display.ButtonOverDisplay.BackColor = clr;
		Display.ButtonOverDisplay.LineerGradient.FirstColor = clr;
		Display.ButtonOverDisplay.LineerGradient.SecondColor = clr;
		return Display;
	}

	public static buButton SetButtonColor(buButton Display, GradientMode gradientMode, Color clr1, Color clr2)
	{
		Display.Display.BackColor = clr1;
		Display.Display.GradientType = gradientMode;
		Display.Display.LineerGradient.FirstColor = clr1;
		Display.Display.LineerGradient.SecondColor = clr2;
		Display.Display.LineerGradient.GradientAngle = 90f;
		Display.ButtonDownDisplay.BackColor = clr1;
		Display.ButtonDownDisplay.GradientType = gradientMode;
		Display.ButtonDownDisplay.LineerGradient.FirstColor = clr1;
		Display.ButtonDownDisplay.LineerGradient.SecondColor = clr2;
		Display.ButtonDownDisplay.LineerGradient.GradientAngle = 90f;
		Display.ButtonOverDisplay.BackColor = clr1;
		Display.ButtonOverDisplay.GradientType = gradientMode;
		Display.ButtonOverDisplay.LineerGradient.FirstColor = clr1;
		Display.ButtonOverDisplay.LineerGradient.SecondColor = clr2;
		Display.ButtonOverDisplay.LineerGradient.GradientAngle = 90f;
		return Display;
	}

	public static void SetCheckBoxColor(buContainerControl Owner, buControlDisplay Display, buControlDisplay DisplayColorMode, buControlDisplay DisplayTick)
	{
		for (int i = 0; i <= Owner.Controls.Count - 1; i++)
		{
			if (Owner.Controls[i].GetType() == typeof(buCheckBox))
			{
				((buCheckBox)Owner.Controls[i]).Display = new buControlDisplay(Display);
				((buCheckBox)Owner.Controls[i]).CheckTick.TickDisplay = new buControlDisplay(DisplayTick);
				((buCheckBox)Owner.Controls[i]).CheckTick.ColorModeDisplay = new buControlDisplay(DisplayColorMode);
			}
		}
	}

	public static void SetSpinColor(buContainerControl Owner, buControlDisplay Display, buControlDisplay DisplayCaption, buControlDisplay DisplayButton)
	{
		for (int i = 0; i <= Owner.Controls.Count - 1; i++)
		{
			if (Owner.Controls[i].GetType() == typeof(buSpin))
			{
				((buSpin)Owner.Controls[i]).Display = new buControlDisplay(Display);
				((buSpin)Owner.Controls[i]).Caption.Display = new buControlDisplay(DisplayCaption);
				((buSpin)Owner.Controls[i]).ButtonNormalDisplay = new buControlDisplay(DisplayButton);
				((buSpin)Owner.Controls[i]).ButtonDownDisplay = new buControlDisplay(DisplayButton);
				((buSpin)Owner.Controls[i]).ButtonOverDisplay = new buControlDisplay(DisplayButton);
			}
		}
	}

	public static void SetTextColor(buContainerControl Owner, buControlDisplay Display, buControlDisplay DisplayCaption)
	{
		for (int i = 0; i <= Owner.Controls.Count - 1; i++)
		{
			if (Owner.Controls[i].GetType() == typeof(buTextBox))
			{
				((buTextBox)Owner.Controls[i]).Display = new buControlDisplay(Display);
				((buTextBox)Owner.Controls[i]).Caption.Display = new buControlDisplay(DisplayCaption);
			}
		}
	}

	public static void SetLabelColor(buContainerControl Owner, buControlDisplay Display)
	{
		for (int i = 0; i <= Owner.Controls.Count - 1; i++)
		{
			if (Owner.Controls[i].GetType() == typeof(buLabel))
			{
				((buLabel)Owner.Controls[i]).Display = new buControlDisplay(Display);
			}
		}
	}

	public static void SetProgressColor(buContainerControl Owner, buControlDisplay Display, buControlDisplay DisplayDone)
	{
		for (int i = 0; i <= Owner.Controls.Count - 1; i++)
		{
			if (Owner.Controls[i].GetType() == typeof(buProgressBar))
			{
				((buProgressBar)Owner.Controls[i]).Display = new buControlDisplay(Display);
				((buProgressBar)Owner.Controls[i]).ProgressLineer.DoneDisplay = new buControlDisplay(DisplayDone);
			}
		}
	}

	public static void SetGroundColor(buGround ground, buControlDisplay Display, buControlDisplay DisplayTop, buControlDisplay DisplayBottom)
	{
		ground.Display = new buControlDisplay(Display);
		ground.DisplayTop = new buControlDisplay(DisplayTop);
		ground.DisplayBottom = new buControlDisplay(DisplayBottom);
	}

	public static void SetPanelColor(buPanel panel, buControlDisplay Display)
	{
		panel.Display = new buControlDisplay(Display);
	}

	public static void SetGroupColor(buGroup group, buControlDisplay Display, buControlDisplay DisplayTitle)
	{
		group.Display = new buControlDisplay(Display);
		group.TitleDisplay = new buControlDisplay(DisplayTitle);
	}

	public static void SetVisiblityOfPanel(ref Panel panel, bool visible, int Height, int Offset, ref int Count)
	{
		panel.Visible = visible;
		if (visible)
		{
			panel.Top = Offset + Count * Height;
			Count++;
		}
	}

	public static void SetParameterListToControlValues(List<cParameter> Parameter, ref Control.ControlCollection Ctrls)
	{
		int num = 0;
		for (int i = 0; i <= Parameter.Count - 1; i++)
		{
			for (int j = 0; j <= Ctrls.Count - 1; j++)
			{
				bool flag = false;
				bool flag2 = false;
				if (Ctrls[j].GetType() == typeof(NumericUpDown))
				{
					NumericUpDown numericUpDown = Ctrls[j] as NumericUpDown;
					if (numericUpDown.Tag != null && numericUpDown.Tag.ToString() == Parameter[i].Name)
					{
						string s = Parameter[i].Value.ToString();
						numericUpDown.Value = decimal.Parse(s);
						flag = true;
						num++;
					}
					if (!flag && numericUpDown.Name.Length > 0)
					{
						string[] array = numericUpDown.Name.Split('_');
						if (array != null && array.Length == 2 && array[1].ToString() == Parameter[i].Name)
						{
							string s2 = Parameter[i].Value.ToString();
							numericUpDown.Value = decimal.Parse(s2);
							flag2 = true;
							num++;
						}
					}
				}
				if (Ctrls[j].GetType() == typeof(CheckBox))
				{
					CheckBox checkBox = Ctrls[j] as CheckBox;
					if (checkBox.Tag != null && checkBox.Tag.ToString() == Parameter[i].Name)
					{
						checkBox.Checked = (bool)Parameter[i].Value;
						flag = true;
						num++;
					}
					if (!flag && checkBox.Name.Length > 0)
					{
						string[] array2 = checkBox.Name.Split('_');
						if (array2 != null && array2.Length == 2 && array2[1].ToString() == Parameter[i].Name)
						{
							checkBox.Checked = (bool)Parameter[i].Value;
							flag2 = true;
							num++;
						}
					}
					if (!flag && !flag2 && checkBox.Text.Length > 0 && checkBox.Text == Parameter[i].Name)
					{
						checkBox.Checked = (bool)Parameter[i].Value;
						num++;
					}
				}
				if (Ctrls[j].GetType() == typeof(buSpin))
				{
					buSpin buSpin2 = Ctrls[j] as buSpin;
					if (buSpin2.Tag != null && buSpin2.Tag.ToString() == Parameter[i].Name)
					{
						string s3 = Parameter[i].Value.ToString();
						buSpin2.Value = double.Parse(s3);
						flag = true;
						num++;
					}
					if (!flag && buSpin2.Name.Length > 0)
					{
						string[] array3 = buSpin2.Name.Split('_');
						if (array3 != null && array3.Length == 2 && array3[1].ToString() == Parameter[i].Name)
						{
							string s4 = Parameter[i].Value.ToString();
							buSpin2.Value = double.Parse(s4);
							flag2 = true;
							num++;
						}
					}
					if (!flag && !flag2 && buSpin2.Caption.Caption.Length > 0 && buSpin2.Caption.Caption == Parameter[i].Name)
					{
						string s5 = Parameter[i].Value.ToString();
						buSpin2.Value = double.Parse(s5);
						num++;
					}
				}
				if (!(Ctrls[j].GetType() == typeof(buCheckBox)))
				{
					continue;
				}
				buCheckBox buCheckBox2 = Ctrls[j] as buCheckBox;
				if (buCheckBox2.Tag != null && buCheckBox2.Tag.ToString() == Parameter[i].Name)
				{
					buCheckBox2.Check = (bool)Parameter[i].Value;
					flag = true;
					num++;
				}
				if (!flag && buCheckBox2.Name.Length > 0)
				{
					string[] array4 = buCheckBox2.Name.Split('_');
					if (array4 != null && array4.Length == 2 && array4[1].ToString() == Parameter[i].Name)
					{
						buCheckBox2.Check = (bool)Parameter[i].Value;
						flag2 = true;
						num++;
					}
				}
				if (!flag && !flag2 && buCheckBox2.Text.Length > 0 && buCheckBox2.Text == Parameter[i].Name)
				{
					buCheckBox2.Check = (bool)Parameter[i].Value;
					num++;
				}
			}
		}
	}

	public static void SetControlValuesToParameterList(Control.ControlCollection Ctrls, ref List<cParameter> Parameter)
	{
		int num = 0;
		for (int i = 0; i <= Parameter.Count - 1; i++)
		{
			bool flag = false;
			bool flag2 = false;
			for (int j = 0; j <= Ctrls.Count - 1; j++)
			{
				if (Ctrls[j].GetType() == typeof(NumericUpDown))
				{
					NumericUpDown numericUpDown = Ctrls[j] as NumericUpDown;
					if (numericUpDown.Tag != null && numericUpDown.Tag.ToString() == Parameter[i].Name)
					{
						Parameter[i].Value = (double)numericUpDown.Value;
						flag = true;
						num++;
					}
					if (!flag && numericUpDown.Name.Length > 0)
					{
						string[] array = numericUpDown.Name.Split('_');
						if (array != null && array.Length == 2 && array[1].ToString() == Parameter[i].Name)
						{
							Parameter[i].Value = (double)numericUpDown.Value;
							flag2 = true;
							num++;
						}
					}
				}
				if (Ctrls[j].GetType() == typeof(CheckBox))
				{
					CheckBox checkBox = Ctrls[j] as CheckBox;
					if (checkBox.Tag != null && checkBox.Tag.ToString() == Parameter[i].Name)
					{
						Parameter[i].Value = checkBox.Checked;
						flag = true;
						num++;
					}
					if (!flag && checkBox.Name.Length > 0)
					{
						string[] array2 = checkBox.Name.Split('_');
						if (array2 != null && array2.Length == 2 && array2[1].ToString() == Parameter[i].Name)
						{
							Parameter[i].Value = checkBox.Checked;
							flag2 = true;
							num++;
						}
					}
					if (!flag && !flag2 && checkBox.Text.Length > 0 && checkBox.Text == Parameter[i].Name)
					{
						Parameter[i].Value = checkBox.Checked;
						num++;
					}
				}
				if (Ctrls[j].GetType() == typeof(buSpin))
				{
					buSpin buSpin2 = Ctrls[j] as buSpin;
					if (buSpin2.Tag != null && buSpin2.Tag.ToString() == Parameter[i].Name)
					{
						Parameter[i].Value = buSpin2.Value;
						flag = true;
						num++;
					}
					if (!flag && buSpin2.Name.Length > 0)
					{
						string[] array3 = buSpin2.Name.Split('_');
						if (array3 != null && array3.Length == 2 && array3[1].ToString() == Parameter[i].Name)
						{
							Parameter[i].Value = buSpin2.Value;
							flag2 = true;
							num++;
						}
					}
					if (!flag && !flag2 && buSpin2.Caption.Caption.Length > 0 && buSpin2.Caption.Caption == Parameter[i].Name)
					{
						Parameter[i].Value = buSpin2.Value;
						num++;
					}
				}
				if (!(Ctrls[j].GetType() == typeof(buCheckBox)))
				{
					continue;
				}
				buCheckBox buCheckBox2 = Ctrls[j] as buCheckBox;
				if (buCheckBox2.Tag != null && buCheckBox2.Tag.ToString() == Parameter[i].Name)
				{
					Parameter[i].Value = buCheckBox2.Check;
					flag = true;
					num++;
				}
				if (!flag && buCheckBox2.Name.Length > 0)
				{
					string[] array4 = buCheckBox2.Name.Split('_');
					if (array4 != null && array4.Length == 2 && array4[1].ToString() == Parameter[i].Name)
					{
						Parameter[i].Value = buCheckBox2.Check;
						flag2 = true;
						num++;
					}
				}
				if (!flag && !flag2 && buCheckBox2.Text.Length > 0 && buCheckBox2.Text == Parameter[i].Name)
				{
					Parameter[i].Value = buCheckBox2.Check;
					num++;
				}
			}
		}
	}

	public static void CultureSettings()
	{
		try
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
			buLogVer5.addToList(sClass, "CultureSettings", "Culture", "Complated");
		}
		catch (Exception)
		{
		}
	}

	public static Control AdjustControlWithDPIScale(Control refControl, double DPIScale, bool Width = true, bool Height = true)
	{
		if (DPIScale != 1.0)
		{
			for (int i = 0; i <= refControl.Controls.Count - 1; i++)
			{
				Control control = refControl.Controls[i];
				if (Width)
				{
					control.Width = Convert.ToInt32((double)control.Width / DPIScale);
					control.Left = Convert.ToInt32((double)control.Left / DPIScale);
				}
				if (Height)
				{
					control.Height = Convert.ToInt32((double)control.Height / DPIScale);
					control.Top = Convert.ToInt32((double)control.Top / DPIScale);
				}
			}
		}
		return refControl;
	}

	public static List<NumericUpDown> GetNumericUpDownFromControl(Control.ControlCollection Controls)
	{
		List<NumericUpDown> list = null;
		return Controls.OfType<NumericUpDown>().ToList();
	}

	public static List<Button> GetButtonFromControl(Control.ControlCollection Controls)
	{
		List<Button> list = null;
		return Controls.OfType<Button>().ToList();
	}

	public static List<ComboBox> GetComboFromControl(Control.ControlCollection Controls)
	{
		List<ComboBox> list = null;
		return Controls.OfType<ComboBox>().ToList();
	}

	public static void VariablesToControls(object Parameters, ref List<NumericUpDown> SpinList, ref List<string> MissingVariables)
	{
		List<cParameter> Vars = new List<cParameter>();
		buSerilization.GetClassVariables(Parameters, ref Vars);
		for (int i = 0; i <= SpinList.Count - 1; i++)
		{
			if (SpinList[i].Tag == null)
			{
				continue;
			}
			bool flag = false;
			for (int j = 0; j <= Vars.Count - 1; j++)
			{
				if (SpinList[i].Tag.ToString() == Vars[j].Name)
				{
					decimal value = Convert.ToDecimal(Vars[j].Value.ToString());
					SpinList[i].Value = value;
					flag = true;
				}
			}
			if (!flag)
			{
				MissingVariables.Add(SpinList[i].Tag.ToString());
			}
		}
	}

	public static void ControlsToVaribles(ref object Parameters, List<NumericUpDown> SpinList)
	{
		List<cParameter> Vars = new List<cParameter>();
		buSerilization.GetClassVariables(Parameters, ref Vars);
		for (int i = 0; i <= SpinList.Count - 1; i++)
		{
			if (SpinList[i].Tag == null)
			{
				continue;
			}
			for (int j = 0; j <= Vars.Count - 1; j++)
			{
				if (SpinList[i].Tag.ToString() == Vars[j].Name)
				{
					Vars[j].Value = (double)SpinList[i].Value;
				}
			}
		}
		buSerilization.SetClassVariables(ref Parameters, Vars);
	}

	public static buControlLineerGradient ColorLinearFromEnable(bool State, Color EnableFirstColor, Color EnableSecondColor, Color DisableFirstColor, Color DisableSecondColor, double gradientAngle = 90.0)
	{
		buControlLineerGradient buControlLineerGradient2 = new buControlLineerGradient();
		if (!State)
		{
			buControlLineerGradient2.FirstColor = DisableFirstColor;
			buControlLineerGradient2.SecondColor = DisableSecondColor;
		}
		else
		{
			buControlLineerGradient2.FirstColor = EnableFirstColor;
			buControlLineerGradient2.SecondColor = EnableSecondColor;
		}
		buControlLineerGradient2.GradientAngle = (float)gradientAngle;
		return buControlLineerGradient2;
	}

	public static buButton ColorButtonLinearFromEnable(buButton refButton, bool State, LinearGradientBoolType GradientType)
	{
		refButton.Display.LineerGradient = ColorLinearFromEnable(State, GradientType);
		refButton.Display.GradientType = GradientMode.Lineer;
		refButton.ButtonOverDisplay.LineerGradient = ColorLinearFromEnable(State, GradientType, 0.9);
		refButton.ButtonOverDisplay.GradientType = GradientMode.Lineer;
		refButton.ButtonDownDisplay.LineerGradient = ColorLinearFromEnable(State, GradientType, 1.1);
		refButton.ButtonDownDisplay.GradientType = GradientMode.Lineer;
		return refButton;
	}

	public static buButton ButtonColorStateFromValue(buButton refButton, LinearGradientBoolType ColorSet, int ActVal, int CheckVal)
	{
		if (!(!refButton.ForceSelected && ActVal == CheckVal))
		{
			if (!(refButton.ForceSelected && ActVal != CheckVal))
			{
				if (!refButton.FirstSelected)
				{
					refButton.FirstSelected = true;
					bool flag = false;
					refButton = ColorButtonLinearFromEnable(refButton, refButton.ForceSelected = ((ActVal == CheckVal) ? true : false), ColorSet);
				}
			}
			else
			{
				refButton.ForceSelected = false;
				refButton = ColorButtonLinearFromEnable(refButton, State: false, ColorSet);
				refButton.FirstSelected = true;
			}
		}
		else
		{
			refButton.ForceSelected = true;
			refButton = ColorButtonLinearFromEnable(refButton, State: true, ColorSet);
			refButton.FirstSelected = true;
		}
		return refButton;
	}

	public static buButton ButtonColorStateFromValue(buButton refButton, LinearGradientBoolType ColorSet, bool ActVal)
	{
		if (!(!refButton.ForceSelected && ActVal))
		{
			if (!(refButton.ForceSelected && !ActVal))
			{
				if (!refButton.FirstSelected)
				{
					refButton.FirstSelected = true;
					refButton.ForceSelected = ActVal;
					refButton = ColorButtonLinearFromEnable(refButton, ActVal, ColorSet);
				}
			}
			else
			{
				refButton.ForceSelected = false;
				refButton = ColorButtonLinearFromEnable(refButton, State: false, ColorSet);
				refButton.FirstSelected = true;
			}
		}
		else
		{
			refButton.ForceSelected = true;
			refButton = ColorButtonLinearFromEnable(refButton, State: true, ColorSet);
			refButton.FirstSelected = true;
		}
		return refButton;
	}

	public static buLabel ColorLabelLinearFromEnable(buLabel refButton, bool State, LinearGradientBoolType GradientType)
	{
		refButton.Display.LineerGradient = ColorLinearFromEnable(State, GradientType);
		refButton.Display.GradientType = GradientMode.Lineer;
		return refButton;
	}

	public static buControlLineerGradient ColorLinearFromEnable(bool State, LinearGradientBoolType GradientType, double ColorFactor = 1.0)
	{
		buControlLineerGradient buControlLineerGradient2 = new buControlLineerGradient();
		if (!State)
		{
			buControlLineerGradient2.FirstColor = buImage.ColorToneChange(GradientType.DisableFirstColor, ColorFactor);
			buControlLineerGradient2.SecondColor = buImage.ColorToneChange(GradientType.DisableSecondColor, ColorFactor);
			buControlLineerGradient2.GradientAngle = (float)GradientType.DisableAngle;
		}
		else
		{
			buControlLineerGradient2.FirstColor = buImage.ColorToneChange(GradientType.EnableFirstColor, ColorFactor);
			buControlLineerGradient2.SecondColor = buImage.ColorToneChange(GradientType.EnableSecondColor, ColorFactor);
			buControlLineerGradient2.GradientAngle = (float)GradientType.EnableAngle;
		}
		return buControlLineerGradient2;
	}

	public static Color ColorSolidFromEnable(bool State, Color EnableColor, Color DisableColor)
	{
		Color red = Color.Red;
		if (!State)
		{
			return DisableColor;
		}
		return EnableColor;
	}

	public static string GetControlText(Control Ctrl)
	{
		string result = "";
		if (!(Ctrl is buSpin))
		{
			if (!(Ctrl is buTextBox))
			{
				if (!(Ctrl is buButton))
				{
					if (!(Ctrl is buLabel))
					{
						if (!(Ctrl is buCheckBox))
						{
							if (!(Ctrl is RadioButton))
							{
								if (!(Ctrl is Label))
								{
									if (Ctrl is Button)
									{
										result = ((Button)Ctrl).Text;
									}
								}
								else
								{
									result = ((Label)Ctrl).Text;
								}
							}
							else
							{
								result = ((RadioButton)Ctrl).Text;
							}
						}
						else
						{
							result = ((buCheckBox)Ctrl).Text;
						}
					}
					else
					{
						result = ((buLabel)Ctrl).Text;
					}
				}
				else
				{
					result = ((buButton)Ctrl).Text;
				}
			}
			else
			{
				result = ((buTextBox)Ctrl).Caption.Caption;
			}
		}
		else
		{
			result = ((buSpin)Ctrl).Caption.Caption;
		}
		return result;
	}
}
