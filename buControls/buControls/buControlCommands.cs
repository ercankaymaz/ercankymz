// Decompiled with JetBrains decompiler
// Type: buControls.buControlCommands
// Assembly: buControls, Version=5.1.1.4, Culture=neutral, PublicKeyToken=null
// MVID: 8B369C0A-23E7-45ED-9051-267DACDF7858
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buControls.dll

using buClass;
using buControls.Controls;
using buControls.Forms.buControlForms.KeyPad;
using buCore;
using ns7;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Management;
using System.Net.NetworkInformation;
using System.Reflection;
using System.Threading;
using System.Windows.Forms;

#nullable disable
namespace buControls;

public class buControlCommands
{
  internal static bool bool_0 = false;
  public static string sClass = nameof (buControlCommands);

  public buControlCommands()
  {
    if (!buControlCommands.smethod_0(nameof (buControlCommands)))
      throw new RegisterException(nameof (buControlCommands));
  }

  internal static bool smethod_0(string string_0)
  {
    buControlCommands.bool_0 = true;
    return true;
  }

  public static string getCpuID(ref List<string> CpuAddress)
  {
    string cpuId = "";
    try
    {
      foreach (ManagementBaseObject managementBaseObject in new ManagementObjectSearcher("Select ProcessorID From Win32_processor").Get())
      {
        cpuId = managementBaseObject["ProcessorID"].ToString();
        CpuAddress.Add(cpuId);
      }
      return cpuId;
    }
    catch (Exception ex)
    {
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, true, "");
      return "";
    }
  }

  public static string GetMotherBoardID(ref string MBAddress)
  {
    MBAddress = "";
    ManagementScope scope = new ManagementScope($"\\\\{Environment.MachineName}\\root\\cimv2");
    scope.Connect();
    foreach (PropertyData property in new ManagementObject(scope, new ManagementPath("Win32_BaseBoard.Tag=\"Base Board\""), new ObjectGetOptions()).Properties)
    {
      if (property.Name == "SerialNumber")
        MBAddress = $"{property.Name,-25}{Convert.ToString(property.Value)}";
    }
    return "";
  }

  public static void getMacAddress(ref List<string> MacAddress)
  {
    try
    {
      MacAddress.Clear();
      NetworkInterface[] networkInterfaces = NetworkInterface.GetAllNetworkInterfaces();
      for (int index = 0; index <= networkInterfaces.Length - 1; ++index)
      {
        string str = networkInterfaces[index].GetPhysicalAddress().ToString();
        if (str.Length == 12 & (networkInterfaces[index].NetworkInterfaceType == NetworkInterfaceType.Ethernet | networkInterfaces[index].NetworkInterfaceType == NetworkInterfaceType.Wireless80211) && str.Substring(0, 4) != "0000")
          MacAddress.Add(str);
      }
    }
    catch (Exception ex)
    {
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, true, "");
    }
  }

  public static string getHddID(ref List<string> HddAddress)
  {
    try
    {
      ManagementObjectSearcher managementObjectSearcher = new ManagementObjectSearcher("SELECT * FROM Win32_PhysicalMedia");
      HddAddress.Clear();
      foreach (ManagementObject managementObject in managementObjectSearcher.Get())
      {
        if (managementObject["SerialNumber"] != null)
        {
          string str = managementObject["SerialNumber"].ToString();
          HddAddress.Add(str);
        }
      }
      return "";
    }
    catch (Exception ex)
    {
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, true, "");
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
    catch (Exception ex)
    {
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, true, "");
      return "";
    }
  }

  public static buButton CopyControl(buButton refControl)
  {
    buButton buButton = (buButton) null;
    if (refControl != null)
      buButton = refControl.DeepClone<buButton>();
    buButton.Display = buControlDisplay.Copy(refControl.Display, buButton.Display);
    buButton.ButtonDownDisplay = new buControlDisplay(refControl.ButtonDownDisplay);
    buButton.ButtonOverDisplay = new buControlDisplay(refControl.ButtonOverDisplay);
    return buButton;
  }

  public static buControl CloneControlSafe(buControl source)
  {
    buControl instance = (buControl) Activator.CreateInstance(source.GetType());
    foreach (PropertyDescriptor property in TypeDescriptor.GetProperties((object) source))
    {
      if (!property.IsReadOnly)
      {
        try
        {
          property.SetValue((object) instance, property.GetValue((object) source));
        }
        catch
        {
        }
      }
    }
    return instance;
  }

  public static buControl CloneControl(buControl source)
  {
    Dictionary<object, object> dictionary_0 = new Dictionary<object, object>();
    return (buControl) Class39.smethod_260((object) source, dictionary_0);
  }

  public static DataGridViewColumn DataGridViewColumbSet(
    int width,
    string headertext,
    string name,
    bool isTextbased = true,
    string fontname = "Arial",
    int fontsize = 10,
    bool readOnly = false,
    bool iscentertext = false)
  {
    DataGridViewColumn dataGridViewColumn = new DataGridViewColumn();
    dataGridViewColumn.Name = name;
    dataGridViewColumn.Width = width;
    dataGridViewColumn.HeaderText = headertext;
    dataGridViewColumn.ReadOnly = readOnly;
    dataGridViewColumn.SortMode = DataGridViewColumnSortMode.NotSortable;
    dataGridViewColumn.DefaultCellStyle.Font = new Font(fontname, (float) fontsize, FontStyle.Bold);
    dataGridViewColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
    dataGridViewColumn.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
    dataGridViewColumn.HeaderCell.Style.BackColor = Color.Gray;
    dataGridViewColumn.HeaderCell.Style.Font = new Font(fontname, (float) fontsize, FontStyle.Bold);
    if (iscentertext)
    {
      dataGridViewColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
      dataGridViewColumn.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
    }
    if (isTextbased)
      dataGridViewColumn.CellTemplate = (DataGridViewCell) new DataGridViewTextBoxCell();
    return dataGridViewColumn;
  }

  public static DataGridViewColumn DataGridViewColumbSetCombobox(
    int width,
    string headertext,
    string name,
    System.Type Enums,
    string fontname = "Arial",
    int fontsize = 10,
    bool readOnly = false,
    bool iscentertext = false)
  {
    DataGridViewColumn dataGridViewColumn = (DataGridViewColumn) new DataGridViewComboBoxColumn();
    dataGridViewColumn.Name = name;
    dataGridViewColumn.Width = width;
    dataGridViewColumn.HeaderText = headertext;
    dataGridViewColumn.ReadOnly = readOnly;
    dataGridViewColumn.SortMode = DataGridViewColumnSortMode.NotSortable;
    dataGridViewColumn.DefaultCellStyle.Font = new Font(fontname, (float) fontsize, FontStyle.Bold);
    dataGridViewColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
    dataGridViewColumn.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
    dataGridViewColumn.HeaderCell.Style.BackColor = Color.Gray;
    dataGridViewColumn.HeaderCell.Style.Font = new Font(fontname, (float) fontsize, FontStyle.Bold);
    if (iscentertext)
    {
      dataGridViewColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
      dataGridViewColumn.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
    }
    List<string> stringList1 = new List<string>();
    List<string> stringList2 = buConversion.EnumToString(Enums);
    for (int index = 0; index <= stringList2.Count - 1; ++index)
      ((DataGridViewComboBoxColumn) dataGridViewColumn).Items.Add((object) stringList2[index]);
    return dataGridViewColumn;
  }

  public static void ComboboxAddItem(ArrayList Items, int SelectedIndex, ref buComboBox Combobox)
  {
    if (Items.Count <= 0)
      return;
    Combobox.Items.Clear();
    for (int index = 0; index <= Items.Count - 1; ++index)
      Combobox.Items.Add(Items[index]);
    if (SelectedIndex >= 0 & SelectedIndex <= Items.Count - 1)
      Combobox.SelectedIndex = SelectedIndex;
    else
      Combobox.SelectedIndex = 0;
  }

  public static void ComboboxAddItem(ArrayList Items, int SelectedIndex, ref ComboBox Combobox)
  {
    if (Items.Count <= 0)
      return;
    Combobox.Items.Clear();
    for (int index = 0; index <= Items.Count - 1; ++index)
      Combobox.Items.Add(Items[index]);
    if (SelectedIndex >= 0 & SelectedIndex <= Items.Count - 1)
      Combobox.SelectedIndex = SelectedIndex;
    else
      Combobox.SelectedIndex = 0;
  }

  public static void GetControlsInContainer(
    Control.ControlCollection Controls,
    ref List<Control> FoundControls)
  {
    for (int index1 = 0; index1 <= Controls.Count - 1; ++index1)
    {
      Control control = Controls[index1];
      if (control is TextBox | control is NumericUpDown | control is buTextBox | control is buSpin)
      {
        if (control.Visible & control.Enabled)
          FoundControls.Add(control);
      }
      else if (control is Panel | control is buPanel | control is GroupBox | control is buGroup | control is TabPage)
      {
        List<Control> FoundControls1 = new List<Control>();
        buControlCommands.GetControlsInContainer(control.Controls, ref FoundControls1);
        if (FoundControls1.Count > 0)
        {
          for (int index2 = 0; index2 <= FoundControls1.Count - 1; ++index2)
            FoundControls.Add(FoundControls1[index2]);
        }
      }
    }
  }

  public static void FindNextControlByKeyDown(
    Control.ControlCollection Controls,
    int ActualIndex,
    bool ShiftPressed)
  {
    List<Control> controlList = new List<Control>();
    for (int index1 = 0; index1 <= Controls.Count - 1; ++index1)
    {
      Controls[index1].GetType().ToString();
      Control control = Controls[index1];
      if (Controls[index1] is buPanel | Controls[index1] is Panel | Controls[index1] is TabPage)
      {
        List<Control> FoundControls = new List<Control>();
        buControlCommands.GetControlsInContainer(Controls[index1].Controls, ref FoundControls);
        if (FoundControls.Count > 0)
        {
          for (int index2 = 0; index2 <= FoundControls.Count - 1; ++index2)
            controlList.Add(FoundControls[index2]);
        }
      }
      if (control.GetType() == typeof (buSpin) | control.GetType() == typeof (buTextBox) | control.GetType() == typeof (NumericUpDown) | control.GetType() == typeof (TextBox) && control.Enabled & control.Visible)
        controlList.Add(control);
    }
    if (controlList.Count <= 1)
      return;
    int num1 = int.MaxValue;
    int index3 = -1;
    for (int index4 = 0; index4 <= controlList.Count - 1; ++index4)
    {
      if (controlList[index4].Tag != null)
      {
        int result = 0;
        int.TryParse(controlList[index4].Tag.ToString(), out result);
        int num2 = result - ActualIndex;
        if (num2 > 0 & num2 < num1)
        {
          num1 = num2;
          index3 = index4;
        }
      }
    }
    if (index3 == -1)
    {
      int num3 = int.MaxValue;
      for (int index5 = 0; index5 <= controlList.Count - 1; ++index5)
      {
        if (controlList[index5].Tag != null)
        {
          int result = 0;
          int.TryParse(controlList[index5].Tag.ToString(), out result);
          int num4 = result - ActualIndex;
          if (num4 < 0 & num4 < num3)
          {
            num3 = num4;
            index3 = index5;
          }
        }
      }
    }
    if (index3 < 0)
      return;
    if (controlList[index3] is buSpin)
      ((buSpin) controlList[index3]).SelectAll();
    if (controlList[index3] is buTextBox)
      ((buTextBox) controlList[index3]).SelectAll();
    if (controlList[index3] is NumericUpDown)
      ((UpDownBase) controlList[index3]).Select(0, 100);
    if (controlList[index3] is TextBox)
      ((TextBoxBase) controlList[index3]).Select(0, 100);
    controlList[index3].Select();
  }

  public static void FindNextControlByKey(
    Control.ControlCollection Controls,
    int ActualIndex,
    bool ShiftPressed)
  {
    int num1 = int.MaxValue;
    int num2 = int.MaxValue;
    Control control1 = (Control) null;
    Control control2 = (Control) null;
    Control control3 = (Control) null;
    for (int index1 = 0; index1 <= Controls.Count - 1; ++index1)
    {
      Controls[index1].GetType().ToString();
      Control control4 = Controls[index1];
      if (Controls[index1].GetType() == typeof (buPanel) | Controls[index1].GetType() == typeof (Panel))
      {
        for (int index2 = 0; index2 <= Controls[index1].Controls.Count - 1; ++index2)
        {
          Control control5 = Controls[index1].Controls[index2];
          if (control5.GetType() == typeof (buSpin) | control5.GetType() == typeof (buTextBox) | control5.GetType() == typeof (NumericUpDown) | control5.GetType() == typeof (TextBox))
          {
            Control control6 = (Control) null;
            bool flag1 = false;
            bool flag2 = false;
            Control control7;
            if (control5.GetType() == typeof (buSpin))
            {
              control7 = (Control) new buSpin();
              control6 = control5;
              flag1 = control5.Visible;
              flag2 = control5.Enabled;
            }
            if (control5.GetType() == typeof (buTextBox))
            {
              control7 = (Control) new buTextBox();
              control6 = control5;
              flag1 = control5.Visible;
              flag2 = control5.Enabled;
            }
            if (control5.GetType() == typeof (NumericUpDown))
            {
              control7 = (Control) new NumericUpDown();
              control6 = control5;
              flag1 = control5.Visible;
              flag2 = control5.Enabled;
            }
            if (control5.GetType() == typeof (TextBox))
            {
              control7 = (Control) new TextBox();
              control6 = control5;
              flag1 = control5.Visible;
              flag2 = control5.Enabled;
            }
            if (flag1 & flag2)
            {
              if (control6.Tag != null & !ShiftPressed)
              {
                int num3 = int.Parse(control6.Tag.ToString());
                if (num3 == 0)
                  control3 = control6;
                if (num3 > ActualIndex & num3 - ActualIndex < num1 & control6.Enabled)
                {
                  num1 = num3 - ActualIndex;
                  control1 = control6;
                }
                if (num3 < ActualIndex & ActualIndex - num3 < num2 & control6.Enabled)
                {
                  num2 = ActualIndex - num3;
                  control2 = control6;
                }
              }
              if (control6.Tag != null & ShiftPressed)
              {
                int num4 = int.Parse(control6.Tag.ToString());
                if (num4 == 0)
                  control3 = control6;
                if (num4 < ActualIndex & ActualIndex - num4 < num1 & control6.Enabled)
                {
                  num1 = ActualIndex - num4;
                  control1 = control6;
                }
                if (num4 < ActualIndex & ActualIndex - num4 < num2 & control6.Enabled)
                {
                  num2 = ActualIndex - num4;
                  control2 = control6;
                }
              }
            }
          }
        }
      }
      if (control4.GetType() == typeof (buSpin) | control4.GetType() == typeof (buTextBox) | control4.GetType() == typeof (NumericUpDown) | control4.GetType() == typeof (TextBox))
      {
        Control control8 = (Control) null;
        bool flag3 = false;
        bool flag4 = false;
        Control control9;
        if (control4.GetType() == typeof (buSpin))
        {
          control9 = (Control) new buSpin();
          control8 = control4;
          flag3 = control4.Visible;
          flag4 = control4.Enabled;
        }
        if (control4.GetType() == typeof (buTextBox))
        {
          control9 = (Control) new buTextBox();
          control8 = control4;
          flag3 = control4.Visible;
          flag4 = control4.Enabled;
        }
        if (control4.GetType() == typeof (NumericUpDown))
        {
          control9 = (Control) new NumericUpDown();
          control8 = control4;
          flag3 = control4.Visible;
          flag4 = control4.Enabled;
        }
        if (control4.GetType() == typeof (TextBox))
        {
          control9 = (Control) new TextBox();
          control8 = control4;
          flag3 = control4.Visible;
          flag4 = control4.Enabled;
        }
        if (flag3 & flag4)
        {
          if (control8.Tag != null & !ShiftPressed)
          {
            int num5 = int.Parse(control8.Tag.ToString());
            if (num5 == 0)
              control3 = control8;
            if (num5 > ActualIndex & num5 - ActualIndex < num1 & control8.Enabled)
            {
              num1 = num5 - ActualIndex;
              control1 = control8;
            }
            if (num5 < ActualIndex & ActualIndex - num5 < num1 & control8.Enabled)
              ;
          }
          if (control8.Tag != null & ShiftPressed)
          {
            int num6 = int.Parse(control8.Tag.ToString());
            if (num6 == 0)
              control3 = control8;
            if (num6 < ActualIndex & ActualIndex - num6 < num1 & control8.Enabled)
            {
              num1 = ActualIndex - num6;
              control1 = control8;
            }
          }
        }
      }
    }
    if (control1 == null & control3 == null && control2 != null)
      control3 = control2;
    if (control1 == null)
    {
      if (control3 == null)
        return;
      if (control3.GetType() == typeof (buSpin))
        ((buSpin) control3).SelectAll();
      if (control3.GetType() == typeof (buTextBox))
        ((buTextBox) control3).SelectAll();
      if (control3.GetType() == typeof (NumericUpDown))
        ((UpDownBase) control3).Select(0, 100);
      if (control3.GetType() == typeof (TextBox))
        ((TextBoxBase) control3).Select(0, 100);
      control3.Select();
    }
    else
    {
      if (control1.GetType() == typeof (buSpin))
        ((buSpin) control1).SelectAll();
      if (control1.GetType() == typeof (buTextBox))
        ((buTextBox) control1).SelectAll();
      if (control1.GetType() == typeof (NumericUpDown))
        ((UpDownBase) control1).Select(0, 100);
      if (control1.GetType() == typeof (TextBox))
        ((TextBoxBase) control1).Select(0, 100);
      control1.Select();
    }
  }

  public static void ShowKeyPad(Form Parent, Control Ctrl, int Version, string passchar = "")
  {
    if (Ctrl.GetType() == typeof (buSpin))
    {
      buControls.Forms.buControlForms.KeyPad.F_KeyPad fKeyPad = new buControls.Forms.buControlForms.KeyPad.F_KeyPad();
      fKeyPad.textCtrl1.PasswordChar = char.Parse(passchar);
      fKeyPad.PasswordChar = char.Parse(passchar);
      fKeyPad.StartPosition = FormStartPosition.CenterParent;
      fKeyPad.ShowDialog(((buSpin) Ctrl).Value.ToString(), (IWin32Window) Parent);
      ((buSpin) Ctrl).Value = double.Parse(fKeyPad.Value);
      ((buSpin) Ctrl).CursorToEnd();
    }
    if (Ctrl.GetType() == typeof (buTextBox))
    {
      buControls.Forms.buControlForms.KeyPad.F_KeyPadAlpha fKeyPadAlpha = new buControls.Forms.buControlForms.KeyPad.F_KeyPadAlpha();
      fKeyPadAlpha.textCtrl1.PasswordChar = char.Parse(passchar);
      fKeyPadAlpha.PasswordChar = char.Parse(passchar);
      fKeyPadAlpha.StartPosition = FormStartPosition.CenterParent;
      fKeyPadAlpha.ShowDialog(Ctrl.Text.ToString(), (IWin32Window) Parent);
      Ctrl.Text = fKeyPadAlpha.Value;
      ((buTextBox) Ctrl).CursorToEnd();
    }
    Decimal num;
    if (Ctrl.GetType() == typeof (NumericUpDown))
    {
      buControls.Forms.buControlForms.KeyPad.F_KeyPad fKeyPad1 = new buControls.Forms.buControlForms.KeyPad.F_KeyPad();
      fKeyPad1.textCtrl1.PasswordChar = char.Parse(passchar);
      fKeyPad1.PasswordChar = char.Parse(passchar);
      fKeyPad1.StartPosition = FormStartPosition.CenterParent;
      buControls.Forms.buControlForms.KeyPad.F_KeyPad fKeyPad2 = fKeyPad1;
      num = ((NumericUpDown) Ctrl).Value;
      string str = num.ToString();
      Form owner = Parent;
      fKeyPad2.ShowDialog(str, (IWin32Window) owner);
      ((NumericUpDown) Ctrl).Value = Decimal.Parse(fKeyPad1.Value);
      ((UpDownBase) Ctrl).Select(0, 100);
    }
    if (Ctrl.GetType() == typeof (TextBox))
    {
      buControls.Forms.buControlForms.KeyPad.F_KeyPadAlpha fKeyPadAlpha = new buControls.Forms.buControlForms.KeyPad.F_KeyPadAlpha();
      fKeyPadAlpha.textCtrl1.PasswordChar = char.Parse(passchar);
      fKeyPadAlpha.PasswordChar = char.Parse(passchar);
      fKeyPadAlpha.StartPosition = FormStartPosition.CenterParent;
      fKeyPadAlpha.ShowDialog(Ctrl.Text.ToString(), (IWin32Window) Parent);
      Ctrl.Text = fKeyPadAlpha.Value;
      ((TextBoxBase) Ctrl).Select(0, 500);
    }
    if (Ctrl.GetType().BaseType == typeof (NumericUpDown))
    {
      buControls.Forms.buControlForms.KeyPad.F_KeyPad fKeyPad3 = new buControls.Forms.buControlForms.KeyPad.F_KeyPad();
      fKeyPad3.textCtrl1.PasswordChar = char.Parse(passchar);
      fKeyPad3.PasswordChar = char.Parse(passchar);
      fKeyPad3.StartPosition = FormStartPosition.CenterParent;
      buControls.Forms.buControlForms.KeyPad.F_KeyPad fKeyPad4 = fKeyPad3;
      num = ((NumericUpDown) Ctrl).Value;
      string str = num.ToString();
      Form owner = Parent;
      fKeyPad4.ShowDialog(str, (IWin32Window) owner);
      ((NumericUpDown) Ctrl).Value = Decimal.Parse(fKeyPad3.Value);
      ((UpDownBase) Ctrl).Select(0, 100);
    }
    if (!(Ctrl.GetType().BaseType == typeof (TextBox)))
      return;
    buControls.Forms.buControlForms.KeyPad.F_KeyPadAlpha fKeyPadAlpha1 = new buControls.Forms.buControlForms.KeyPad.F_KeyPadAlpha();
    fKeyPadAlpha1.textCtrl1.PasswordChar = char.Parse(passchar);
    fKeyPadAlpha1.PasswordChar = char.Parse(passchar);
    fKeyPadAlpha1.StartPosition = FormStartPosition.CenterParent;
    fKeyPadAlpha1.ShowDialog(Ctrl.Text.ToString(), (IWin32Window) Parent);
    Ctrl.Text = fKeyPadAlpha1.Value;
    ((TextBoxBase) Ctrl).Select(0, 500);
  }

  public static void ShowKeyPad(Form Parent, Control Ctrl, string passchar = "")
  {
    if (Ctrl.GetType() == typeof (buSpin))
    {
      buControls.Forms.buControlForms.KeyPad.F_KeyPad fKeyPad = new buControls.Forms.buControlForms.KeyPad.F_KeyPad();
      if (passchar.Length > 0)
        fKeyPad.textCtrl1.PasswordChar = char.Parse(passchar);
      fKeyPad.StartPosition = FormStartPosition.CenterParent;
      fKeyPad.ShowDialog(((buSpin) Ctrl).Value.ToString(), (IWin32Window) Parent);
      ((buSpin) Ctrl).Value = double.Parse(fKeyPad.Value);
      ((buSpin) Ctrl).CursorToEnd();
    }
    if (Ctrl.GetType() == typeof (buTextBox))
    {
      buControls.Forms.buControlForms.KeyPad.F_KeyPadAlpha fKeyPadAlpha = new buControls.Forms.buControlForms.KeyPad.F_KeyPadAlpha();
      if (passchar.Length > 0)
        fKeyPadAlpha.textCtrl1.PasswordChar = char.Parse(passchar);
      fKeyPadAlpha.StartPosition = FormStartPosition.CenterParent;
      fKeyPadAlpha.ShowDialog(Ctrl.Text.ToString(), (IWin32Window) Parent);
      Ctrl.Text = fKeyPadAlpha.Value;
      ((buTextBox) Ctrl).CursorToEnd();
    }
    if (Ctrl.GetType() == typeof (NumericUpDown))
    {
      buControls.Forms.buControlForms.KeyPad.F_KeyPad fKeyPad = new buControls.Forms.buControlForms.KeyPad.F_KeyPad();
      if (passchar.Length > 0)
        fKeyPad.textCtrl1.PasswordChar = char.Parse(passchar);
      fKeyPad.StartPosition = FormStartPosition.CenterParent;
      fKeyPad.ShowDialog(((NumericUpDown) Ctrl).Value.ToString(), (IWin32Window) Parent);
      ((NumericUpDown) Ctrl).Value = Decimal.Parse(fKeyPad.Value);
      ((UpDownBase) Ctrl).Select(0, 100);
    }
    if (Ctrl.GetType() == typeof (TextBox))
    {
      buControls.Forms.buControlForms.KeyPad.F_KeyPadAlpha fKeyPadAlpha = new buControls.Forms.buControlForms.KeyPad.F_KeyPadAlpha();
      fKeyPadAlpha.StartPosition = FormStartPosition.CenterParent;
      fKeyPadAlpha.ShowDialog(Ctrl.Text.ToString(), (IWin32Window) Parent);
      Ctrl.Text = fKeyPadAlpha.Value;
      ((TextBoxBase) Ctrl).Select(0, 500);
    }
    if (Ctrl.GetType().BaseType == typeof (NumericUpDown))
    {
      buControls.Forms.buControlForms.KeyPad.F_KeyPad fKeyPad = new buControls.Forms.buControlForms.KeyPad.F_KeyPad();
      fKeyPad.StartPosition = FormStartPosition.CenterParent;
      fKeyPad.ShowDialog(((NumericUpDown) Ctrl).Value.ToString(), (IWin32Window) Parent);
      ((NumericUpDown) Ctrl).Value = Decimal.Parse(fKeyPad.Value);
      ((UpDownBase) Ctrl).Select(0, 100);
    }
    if (!(Ctrl.GetType().BaseType == typeof (TextBox)))
      return;
    buControls.Forms.buControlForms.KeyPad.F_KeyPadAlpha fKeyPadAlpha1 = new buControls.Forms.buControlForms.KeyPad.F_KeyPadAlpha();
    fKeyPadAlpha1.StartPosition = FormStartPosition.CenterParent;
    fKeyPadAlpha1.ShowDialog(Ctrl.Text.ToString(), (IWin32Window) Parent);
    Ctrl.Text = fKeyPadAlpha1.Value;
    ((TextBoxBase) Ctrl).Select(0, 500);
  }

  public static void ShowKeyPad(Form Parent, Control Ctrl, TouchPadType Type)
  {
    if (Ctrl.GetType() == typeof (buSpin) && Type == TouchPadType.buControlStyleBasic)
    {
      buControls.Forms.buControlForms.KeyPad.F_KeyPad fKeyPad = new buControls.Forms.buControlForms.KeyPad.F_KeyPad();
      fKeyPad.StartPosition = FormStartPosition.CenterParent;
      fKeyPad.ShowDialog(((buSpin) Ctrl).Value.ToString(), (IWin32Window) Parent);
      ((buSpin) Ctrl).Value = double.Parse(fKeyPad.Value);
      ((buSpin) Ctrl).CursorToEnd();
    }
    if (Ctrl.GetType() == typeof (buTextBox) && Type == TouchPadType.buControlStyleBasic)
    {
      buControls.Forms.buControlForms.KeyPad.F_KeyPadAlpha fKeyPadAlpha = new buControls.Forms.buControlForms.KeyPad.F_KeyPadAlpha();
      fKeyPadAlpha.StartPosition = FormStartPosition.CenterParent;
      fKeyPadAlpha.ShowDialog(Ctrl.Text.ToString(), (IWin32Window) Parent);
      Ctrl.Text = fKeyPadAlpha.Value;
      ((buTextBox) Ctrl).CursorToEnd();
    }
    if (Ctrl.GetType() == typeof (NumericUpDown) | Ctrl.GetType().BaseType == typeof (NumericUpDown))
    {
      if (Type == TouchPadType.buControlStyleBasic)
      {
        buControls.Forms.buControlForms.KeyPad.F_KeyPad fKeyPad = new buControls.Forms.buControlForms.KeyPad.F_KeyPad();
        fKeyPad.StartPosition = FormStartPosition.CenterParent;
        fKeyPad.ShowDialog(((NumericUpDown) Ctrl).Value.ToString(), (IWin32Window) Parent);
        fKeyPad.TopMost = true;
        ((NumericUpDown) Ctrl).Value = Decimal.Parse(fKeyPad.Value);
        ((UpDownBase) Ctrl).Select(0, 100);
      }
      if (Type == TouchPadType.buControlStyleEagle)
      {
        F_NumVar fNumVar = new F_NumVar();
        fNumVar.StartPosition = FormStartPosition.CenterParent;
        fNumVar.ShowDialog(((NumericUpDown) Ctrl).Value.ToString(), (IWin32Window) Parent);
        ((NumericUpDown) Ctrl).Value = Convert.ToDecimal(fNumVar.Value);
        ((UpDownBase) Ctrl).Select(0, 100);
      }
    }
    if (!(Ctrl.GetType() == typeof (TextBox) | Ctrl.GetType().BaseType == typeof (TextBox)))
      return;
    if (Type == TouchPadType.buControlStyleBasic)
    {
      buControls.Forms.buControlForms.KeyPad.F_KeyPadAlpha fKeyPadAlpha = new buControls.Forms.buControlForms.KeyPad.F_KeyPadAlpha();
      fKeyPadAlpha.StartPosition = FormStartPosition.CenterParent;
      fKeyPadAlpha.ShowDialog(Ctrl.Text.ToString(), (IWin32Window) Parent);
      Ctrl.Text = fKeyPadAlpha.Value;
      ((TextBoxBase) Ctrl).Select(0, 500);
    }
    if (Type != TouchPadType.buControlStyleEagle)
      return;
    F_Keyboard fKeyboard = new F_Keyboard();
    fKeyboard.StartPosition = FormStartPosition.CenterParent;
    fKeyboard.ShowDialog(Ctrl.Text.ToString(), (IWin32Window) Parent);
    Ctrl.Text = fKeyboard.Value;
    ((TextBoxBase) Ctrl).Select(0, 500);
  }

  public static void ShowKeyPadWinControl(Form Parent, Control Ctrl)
  {
    if (Ctrl.GetType() == typeof (buSpin))
    {
      buControls.Forms.WinControlForms.KeyPad.F_KeyPad fKeyPad = new buControls.Forms.WinControlForms.KeyPad.F_KeyPad();
      fKeyPad.StartPosition = FormStartPosition.CenterParent;
      fKeyPad.ShowDialog(((buSpin) Ctrl).Value.ToString(), (IWin32Window) Parent);
      ((buSpin) Ctrl).Value = double.Parse(fKeyPad.Value);
      ((buSpin) Ctrl).CursorToEnd();
    }
    if (Ctrl.GetType() == typeof (buTextBox))
    {
      buControls.Forms.WinControlForms.KeyPad.F_KeyPadAlpha fKeyPadAlpha = new buControls.Forms.WinControlForms.KeyPad.F_KeyPadAlpha();
      fKeyPadAlpha.StartPosition = FormStartPosition.CenterParent;
      fKeyPadAlpha.ShowDialog(Ctrl.Text.ToString(), (IWin32Window) Parent);
      Ctrl.Text = fKeyPadAlpha.Value;
      ((buTextBox) Ctrl).CursorToEnd();
    }
    if (Ctrl.GetType() == typeof (NumericUpDown))
    {
      buControls.Forms.WinControlForms.KeyPad.F_KeyPad fKeyPad = new buControls.Forms.WinControlForms.KeyPad.F_KeyPad();
      fKeyPad.StartPosition = FormStartPosition.CenterParent;
      fKeyPad.ShowDialog(((NumericUpDown) Ctrl).Value.ToString(), (IWin32Window) Parent);
      ((NumericUpDown) Ctrl).Value = Decimal.Parse(fKeyPad.Value);
      ((UpDownBase) Ctrl).Select(0, 100);
    }
    if (!(Ctrl.GetType() == typeof (TextBox)))
      return;
    buControls.Forms.WinControlForms.KeyPad.F_KeyPadAlpha fKeyPadAlpha1 = new buControls.Forms.WinControlForms.KeyPad.F_KeyPadAlpha();
    fKeyPadAlpha1.StartPosition = FormStartPosition.CenterParent;
    fKeyPadAlpha1.ShowDialog(Ctrl.Text.ToString(), (IWin32Window) Parent);
    Ctrl.Text = fKeyPadAlpha1.Value;
    ((TextBoxBase) Ctrl).Select(0, 500);
  }

  public static void ListboxAddFiles(
    List<string> Files,
    bool UseDirecotory,
    bool UseExtension,
    ref buListBox Listbox)
  {
    try
    {
      Listbox.Items.Clear();
      for (int index = 0; index <= Files.Count - 1; ++index)
      {
        FileEventArg fileEventArg = new FileEventArg(Files[index]);
        string FullPath = Files[index];
        if (!UseDirecotory)
          FullPath = buFile.getFileName(FullPath);
        if (!UseExtension)
          FullPath = buFile.getFileNameWithoutExtension(FullPath);
        if (FullPath.Length > 0)
          Listbox.Items.Add((object) fileEventArg);
      }
    }
    catch (Exception ex)
    {
      buLog.addLog("", "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, true, "");
    }
  }

  public static void SetButtonColor(
    buContainerControl Owner,
    buControlDisplay Display,
    buControlDisplay DisplayOver,
    buControlDisplay DisplayDown)
  {
    for (int index = 0; index <= Owner.Controls.Count - 1; ++index)
    {
      if (Owner.Controls[index].GetType() == typeof (buButton))
      {
        ((buControl) Owner.Controls[index]).Display = new buControlDisplay(Display);
        ((buButtonBase) Owner.Controls[index]).ButtonDownDisplay = new buControlDisplay(DisplayDown);
        ((buButtonBase) Owner.Controls[index]).ButtonOverDisplay = new buControlDisplay(DisplayOver);
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

  public static buButton SetButtonColor(
    buButton Display,
    GradientMode gradientMode,
    Color clr1,
    Color clr2)
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

  public static void SetCheckBoxColor(
    buContainerControl Owner,
    buControlDisplay Display,
    buControlDisplay DisplayColorMode,
    buControlDisplay DisplayTick)
  {
    for (int index = 0; index <= Owner.Controls.Count - 1; ++index)
    {
      if (Owner.Controls[index].GetType() == typeof (buCheckBox))
      {
        ((buControl) Owner.Controls[index]).Display = new buControlDisplay(Display);
        ((buCheckBox) Owner.Controls[index]).CheckTick.TickDisplay = new buControlDisplay(DisplayTick);
        ((buCheckBox) Owner.Controls[index]).CheckTick.ColorModeDisplay = new buControlDisplay(DisplayColorMode);
      }
    }
  }

  public static void SetSpinColor(
    buContainerControl Owner,
    buControlDisplay Display,
    buControlDisplay DisplayCaption,
    buControlDisplay DisplayButton)
  {
    for (int index = 0; index <= Owner.Controls.Count - 1; ++index)
    {
      if (Owner.Controls[index].GetType() == typeof (buSpin))
      {
        ((buControl) Owner.Controls[index]).Display = new buControlDisplay(Display);
        ((buCaptionBaseControl) Owner.Controls[index]).Caption.Display = new buControlDisplay(DisplayCaption);
        ((buSpin) Owner.Controls[index]).ButtonNormalDisplay = new buControlDisplay(DisplayButton);
        ((buSpin) Owner.Controls[index]).ButtonDownDisplay = new buControlDisplay(DisplayButton);
        ((buSpin) Owner.Controls[index]).ButtonOverDisplay = new buControlDisplay(DisplayButton);
      }
    }
  }

  public static void SetTextColor(
    buContainerControl Owner,
    buControlDisplay Display,
    buControlDisplay DisplayCaption)
  {
    for (int index = 0; index <= Owner.Controls.Count - 1; ++index)
    {
      if (Owner.Controls[index].GetType() == typeof (buTextBox))
      {
        ((buControl) Owner.Controls[index]).Display = new buControlDisplay(Display);
        ((buCaptionBaseControl) Owner.Controls[index]).Caption.Display = new buControlDisplay(DisplayCaption);
      }
    }
  }

  public static void SetLabelColor(buContainerControl Owner, buControlDisplay Display)
  {
    for (int index = 0; index <= Owner.Controls.Count - 1; ++index)
    {
      if (Owner.Controls[index].GetType() == typeof (buLabel))
        ((buControl) Owner.Controls[index]).Display = new buControlDisplay(Display);
    }
  }

  public static void SetProgressColor(
    buContainerControl Owner,
    buControlDisplay Display,
    buControlDisplay DisplayDone)
  {
    for (int index = 0; index <= Owner.Controls.Count - 1; ++index)
    {
      if (Owner.Controls[index].GetType() == typeof (buProgressBar))
      {
        ((buControl) Owner.Controls[index]).Display = new buControlDisplay(Display);
        ((buProgressBar) Owner.Controls[index]).ProgressLineer.DoneDisplay = new buControlDisplay(DisplayDone);
      }
    }
  }

  public static void SetGroundColor(
    buGround ground,
    buControlDisplay Display,
    buControlDisplay DisplayTop,
    buControlDisplay DisplayBottom)
  {
    ground.Display = new buControlDisplay(Display);
    ground.DisplayTop = new buControlDisplay(DisplayTop);
    ground.DisplayBottom = new buControlDisplay(DisplayBottom);
  }

  public static void SetPanelColor(buPanel panel, buControlDisplay Display)
  {
    panel.Display = new buControlDisplay(Display);
  }

  public static void SetGroupColor(
    buGroup group,
    buControlDisplay Display,
    buControlDisplay DisplayTitle)
  {
    group.Display = new buControlDisplay(Display);
    group.TitleDisplay = new buControlDisplay(DisplayTitle);
  }

  public static void SetVisiblityOfPanel(
    ref Panel panel,
    bool visible,
    int Height,
    int Offset,
    ref int Count)
  {
    panel.Visible = visible;
    if (!visible)
      return;
    panel.Top = Offset + Count * Height;
    ++Count;
  }

  public static void SetParameterListToControlValues(
    List<cParameter> Parameter,
    ref Control.ControlCollection Ctrls)
  {
    int num = 0;
    for (int index1 = 0; index1 <= Parameter.Count - 1; ++index1)
    {
      for (int index2 = 0; index2 <= Ctrls.Count - 1; ++index2)
      {
        bool flag1 = false;
        bool flag2 = false;
        if (Ctrls[index2].GetType() == typeof (NumericUpDown))
        {
          NumericUpDown numericUpDown = Ctrls[index2] as NumericUpDown;
          if (numericUpDown.Tag != null && numericUpDown.Tag.ToString() == Parameter[index1].Name)
          {
            string s = Parameter[index1].Value.ToString();
            numericUpDown.Value = Decimal.Parse(s);
            flag1 = true;
            ++num;
          }
          if (!flag1 && numericUpDown.Name.Length > 0)
          {
            string[] strArray = numericUpDown.Name.Split('_');
            if (strArray != null && strArray.Length == 2 && strArray[1].ToString() == Parameter[index1].Name)
            {
              string s = Parameter[index1].Value.ToString();
              numericUpDown.Value = Decimal.Parse(s);
              flag2 = true;
              ++num;
            }
          }
        }
        if (Ctrls[index2].GetType() == typeof (CheckBox))
        {
          CheckBox checkBox = Ctrls[index2] as CheckBox;
          if (checkBox.Tag != null && checkBox.Tag.ToString() == Parameter[index1].Name)
          {
            checkBox.Checked = (bool) Parameter[index1].Value;
            flag1 = true;
            ++num;
          }
          if (!flag1 && checkBox.Name.Length > 0)
          {
            string[] strArray = checkBox.Name.Split('_');
            if (strArray != null && strArray.Length == 2 && strArray[1].ToString() == Parameter[index1].Name)
            {
              checkBox.Checked = (bool) Parameter[index1].Value;
              flag2 = true;
              ++num;
            }
          }
          if (!flag1 & !flag2 && checkBox.Text.Length > 0 && checkBox.Text == Parameter[index1].Name)
          {
            checkBox.Checked = (bool) Parameter[index1].Value;
            ++num;
          }
        }
        if (Ctrls[index2].GetType() == typeof (buSpin))
        {
          buSpin buSpin = Ctrls[index2] as buSpin;
          if (buSpin.Tag != null && buSpin.Tag.ToString() == Parameter[index1].Name)
          {
            string s = Parameter[index1].Value.ToString();
            buSpin.Value = double.Parse(s);
            flag1 = true;
            ++num;
          }
          if (!flag1 && buSpin.Name.Length > 0)
          {
            string[] strArray = buSpin.Name.Split('_');
            if (strArray != null && strArray.Length == 2 && strArray[1].ToString() == Parameter[index1].Name)
            {
              string s = Parameter[index1].Value.ToString();
              buSpin.Value = double.Parse(s);
              flag2 = true;
              ++num;
            }
          }
          if (!flag1 & !flag2 && buSpin.Caption.Caption.Length > 0 && buSpin.Caption.Caption == Parameter[index1].Name)
          {
            string s = Parameter[index1].Value.ToString();
            buSpin.Value = double.Parse(s);
            ++num;
          }
        }
        if (Ctrls[index2].GetType() == typeof (buCheckBox))
        {
          buCheckBox buCheckBox = Ctrls[index2] as buCheckBox;
          if (buCheckBox.Tag != null && buCheckBox.Tag.ToString() == Parameter[index1].Name)
          {
            buCheckBox.Check = (bool) Parameter[index1].Value;
            flag1 = true;
            ++num;
          }
          if (!flag1 && buCheckBox.Name.Length > 0)
          {
            string[] strArray = buCheckBox.Name.Split('_');
            if (strArray != null && strArray.Length == 2 && strArray[1].ToString() == Parameter[index1].Name)
            {
              buCheckBox.Check = (bool) Parameter[index1].Value;
              flag2 = true;
              ++num;
            }
          }
          if (!flag1 & !flag2 && buCheckBox.Text.Length > 0 && buCheckBox.Text == Parameter[index1].Name)
          {
            buCheckBox.Check = (bool) Parameter[index1].Value;
            ++num;
          }
        }
      }
    }
  }

  public static void SetControlValuesToParameterList(
    Control.ControlCollection Ctrls,
    ref List<cParameter> Parameter)
  {
    int num = 0;
    for (int index1 = 0; index1 <= Parameter.Count - 1; ++index1)
    {
      bool flag1 = false;
      bool flag2 = false;
      for (int index2 = 0; index2 <= Ctrls.Count - 1; ++index2)
      {
        if (Ctrls[index2].GetType() == typeof (NumericUpDown))
        {
          NumericUpDown ctrl = Ctrls[index2] as NumericUpDown;
          if (ctrl.Tag != null && ctrl.Tag.ToString() == Parameter[index1].Name)
          {
            Parameter[index1].Value = (object) (double) ctrl.Value;
            flag1 = true;
            ++num;
          }
          if (!flag1 && ctrl.Name.Length > 0)
          {
            string[] strArray = ctrl.Name.Split('_');
            if (strArray != null && strArray.Length == 2 && strArray[1].ToString() == Parameter[index1].Name)
            {
              Parameter[index1].Value = (object) (double) ctrl.Value;
              flag2 = true;
              ++num;
            }
          }
        }
        if (Ctrls[index2].GetType() == typeof (CheckBox))
        {
          CheckBox ctrl = Ctrls[index2] as CheckBox;
          if (ctrl.Tag != null && ctrl.Tag.ToString() == Parameter[index1].Name)
          {
            Parameter[index1].Value = (object) ctrl.Checked;
            flag1 = true;
            ++num;
          }
          if (!flag1 && ctrl.Name.Length > 0)
          {
            string[] strArray = ctrl.Name.Split('_');
            if (strArray != null && strArray.Length == 2 && strArray[1].ToString() == Parameter[index1].Name)
            {
              Parameter[index1].Value = (object) ctrl.Checked;
              flag2 = true;
              ++num;
            }
          }
          if (!flag1 & !flag2 && ctrl.Text.Length > 0 && ctrl.Text == Parameter[index1].Name)
          {
            Parameter[index1].Value = (object) ctrl.Checked;
            ++num;
          }
        }
        if (Ctrls[index2].GetType() == typeof (buSpin))
        {
          buSpin ctrl = Ctrls[index2] as buSpin;
          if (ctrl.Tag != null && ctrl.Tag.ToString() == Parameter[index1].Name)
          {
            Parameter[index1].Value = (object) ctrl.Value;
            flag1 = true;
            ++num;
          }
          if (!flag1 && ctrl.Name.Length > 0)
          {
            string[] strArray = ctrl.Name.Split('_');
            if (strArray != null && strArray.Length == 2 && strArray[1].ToString() == Parameter[index1].Name)
            {
              Parameter[index1].Value = (object) ctrl.Value;
              flag2 = true;
              ++num;
            }
          }
          if (!flag1 & !flag2 && ctrl.Caption.Caption.Length > 0 && ctrl.Caption.Caption == Parameter[index1].Name)
          {
            Parameter[index1].Value = (object) ctrl.Value;
            ++num;
          }
        }
        if (Ctrls[index2].GetType() == typeof (buCheckBox))
        {
          buCheckBox ctrl = Ctrls[index2] as buCheckBox;
          if (ctrl.Tag != null && ctrl.Tag.ToString() == Parameter[index1].Name)
          {
            Parameter[index1].Value = (object) ctrl.Check;
            flag1 = true;
            ++num;
          }
          if (!flag1 && ctrl.Name.Length > 0)
          {
            string[] strArray = ctrl.Name.Split('_');
            if (strArray != null && strArray.Length == 2 && strArray[1].ToString() == Parameter[index1].Name)
            {
              Parameter[index1].Value = (object) ctrl.Check;
              flag2 = true;
              ++num;
            }
          }
          if (!flag1 & !flag2 && ctrl.Text.Length > 0 && ctrl.Text == Parameter[index1].Name)
          {
            Parameter[index1].Value = (object) ctrl.Check;
            ++num;
          }
        }
      }
    }
  }

  public static void CultureSettings()
  {
    try
    {
      CultureInfo cultureInfo = new CultureInfo("tr-TR");
      Application.CurrentCulture = cultureInfo;
      Thread.CurrentThread.CurrentCulture = cultureInfo;
      Thread.CurrentThread.CurrentUICulture = cultureInfo;
      buLogVer5.addToList(buControlCommands.sClass, nameof (CultureSettings), "Culture", "Complated");
    }
    catch (Exception ex)
    {
    }
  }

  public static Control AdjustControlWithDPIScale(
    Control refControl,
    double DPIScale,
    bool Width = true,
    bool Height = true)
  {
    if (DPIScale != 1.0)
    {
      for (int index = 0; index <= refControl.Controls.Count - 1; ++index)
      {
        Control control = refControl.Controls[index];
        if (Width)
        {
          control.Width = Convert.ToInt32((double) control.Width / DPIScale);
          control.Left = Convert.ToInt32((double) control.Left / DPIScale);
        }
        if (Height)
        {
          control.Height = Convert.ToInt32((double) control.Height / DPIScale);
          control.Top = Convert.ToInt32((double) control.Top / DPIScale);
        }
      }
    }
    return refControl;
  }

  public static List<NumericUpDown> GetNumericUpDownFromControl(Control.ControlCollection Controls)
  {
    return Controls.OfType<NumericUpDown>().ToList<NumericUpDown>();
  }

  public static List<Button> GetButtonFromControl(Control.ControlCollection Controls)
  {
    return Controls.OfType<Button>().ToList<Button>();
  }

  public static List<ComboBox> GetComboFromControl(Control.ControlCollection Controls)
  {
    return Controls.OfType<ComboBox>().ToList<ComboBox>();
  }

  public static void VariablesToControls(
    object Parameters,
    ref List<NumericUpDown> SpinList,
    ref List<string> MissingVariables)
  {
    List<cParameter> Vars = new List<cParameter>();
    buSerilization.GetClassVariables(Parameters, ref Vars);
    for (int index1 = 0; index1 <= SpinList.Count - 1; ++index1)
    {
      if (SpinList[index1].Tag != null)
      {
        bool flag = false;
        for (int index2 = 0; index2 <= Vars.Count - 1; ++index2)
        {
          if (SpinList[index1].Tag.ToString() == Vars[index2].Name)
          {
            Decimal num = Convert.ToDecimal(Vars[index2].Value.ToString());
            SpinList[index1].Value = num;
            flag = true;
          }
        }
        if (!flag)
          MissingVariables.Add(SpinList[index1].Tag.ToString());
      }
    }
  }

  public static void ControlsToVaribles(ref object Parameters, List<NumericUpDown> SpinList)
  {
    List<cParameter> Vars = new List<cParameter>();
    buSerilization.GetClassVariables(Parameters, ref Vars);
    for (int index1 = 0; index1 <= SpinList.Count - 1; ++index1)
    {
      if (SpinList[index1].Tag != null)
      {
        for (int index2 = 0; index2 <= Vars.Count - 1; ++index2)
        {
          if (SpinList[index1].Tag.ToString() == Vars[index2].Name)
            Vars[index2].Value = (object) (double) SpinList[index1].Value;
        }
      }
    }
    buSerilization.SetClassVariables(ref Parameters, Vars);
  }

  public static buControlLineerGradient ColorLinearFromEnable(
    bool State,
    Color EnableFirstColor,
    Color EnableSecondColor,
    Color DisableFirstColor,
    Color DisableSecondColor,
    double gradientAngle = 90.0)
  {
    buControlLineerGradient controlLineerGradient = new buControlLineerGradient();
    if (State)
    {
      controlLineerGradient.FirstColor = EnableFirstColor;
      controlLineerGradient.SecondColor = EnableSecondColor;
    }
    else
    {
      controlLineerGradient.FirstColor = DisableFirstColor;
      controlLineerGradient.SecondColor = DisableSecondColor;
    }
    controlLineerGradient.GradientAngle = (float) gradientAngle;
    return controlLineerGradient;
  }

  public static buButton ColorButtonLinearFromEnable(
    buButton refButton,
    bool State,
    LinearGradientBoolType GradientType)
  {
    refButton.Display.LineerGradient = buControlCommands.ColorLinearFromEnable(State, GradientType);
    refButton.Display.GradientType = GradientMode.Lineer;
    refButton.ButtonOverDisplay.LineerGradient = buControlCommands.ColorLinearFromEnable(State, GradientType, 0.9);
    refButton.ButtonOverDisplay.GradientType = GradientMode.Lineer;
    refButton.ButtonDownDisplay.LineerGradient = buControlCommands.ColorLinearFromEnable(State, GradientType, 1.1);
    refButton.ButtonDownDisplay.GradientType = GradientMode.Lineer;
    return refButton;
  }

  public static buButton ButtonColorStateFromValue(
    buButton refButton,
    LinearGradientBoolType ColorSet,
    int ActVal,
    int CheckVal)
  {
    if (!refButton.ForceSelected & ActVal == CheckVal)
    {
      refButton.ForceSelected = true;
      refButton = buControlCommands.ColorButtonLinearFromEnable(refButton, true, ColorSet);
      refButton.FirstSelected = true;
    }
    else if (refButton.ForceSelected & ActVal != CheckVal)
    {
      refButton.ForceSelected = false;
      refButton = buControlCommands.ColorButtonLinearFromEnable(refButton, false, ColorSet);
      refButton.FirstSelected = true;
    }
    else if (!refButton.FirstSelected)
    {
      refButton.FirstSelected = true;
      bool State = ActVal == CheckVal;
      refButton.ForceSelected = State;
      refButton = buControlCommands.ColorButtonLinearFromEnable(refButton, State, ColorSet);
    }
    return refButton;
  }

  public static buButton ButtonColorStateFromValue(
    buButton refButton,
    LinearGradientBoolType ColorSet,
    bool ActVal)
  {
    if (!refButton.ForceSelected & ActVal)
    {
      refButton.ForceSelected = true;
      refButton = buControlCommands.ColorButtonLinearFromEnable(refButton, true, ColorSet);
      refButton.FirstSelected = true;
    }
    else if (refButton.ForceSelected & !ActVal)
    {
      refButton.ForceSelected = false;
      refButton = buControlCommands.ColorButtonLinearFromEnable(refButton, false, ColorSet);
      refButton.FirstSelected = true;
    }
    else if (!refButton.FirstSelected)
    {
      refButton.FirstSelected = true;
      refButton.ForceSelected = ActVal;
      refButton = buControlCommands.ColorButtonLinearFromEnable(refButton, ActVal, ColorSet);
    }
    return refButton;
  }

  public static buLabel ColorLabelLinearFromEnable(
    buLabel refButton,
    bool State,
    LinearGradientBoolType GradientType)
  {
    refButton.Display.LineerGradient = buControlCommands.ColorLinearFromEnable(State, GradientType);
    refButton.Display.GradientType = GradientMode.Lineer;
    return refButton;
  }

  public static buControlLineerGradient ColorLinearFromEnable(
    bool State,
    LinearGradientBoolType GradientType,
    double ColorFactor = 1.0)
  {
    buControlLineerGradient controlLineerGradient = new buControlLineerGradient();
    if (State)
    {
      controlLineerGradient.FirstColor = buImage.ColorToneChange(GradientType.EnableFirstColor, ColorFactor);
      controlLineerGradient.SecondColor = buImage.ColorToneChange(GradientType.EnableSecondColor, ColorFactor);
      controlLineerGradient.GradientAngle = (float) GradientType.EnableAngle;
    }
    else
    {
      controlLineerGradient.FirstColor = buImage.ColorToneChange(GradientType.DisableFirstColor, ColorFactor);
      controlLineerGradient.SecondColor = buImage.ColorToneChange(GradientType.DisableSecondColor, ColorFactor);
      controlLineerGradient.GradientAngle = (float) GradientType.DisableAngle;
    }
    return controlLineerGradient;
  }

  public static Color ColorSolidFromEnable(bool State, Color EnableColor, Color DisableColor)
  {
    Color red = Color.Red;
    return !State ? DisableColor : EnableColor;
  }

  public static string GetControlText(Control Ctrl)
  {
    string controlText = "";
    switch (Ctrl)
    {
      case buSpin _:
        controlText = ((buCaptionBaseControl) Ctrl).Caption.Caption;
        break;
      case buTextBox _:
        controlText = ((buCaptionBaseControl) Ctrl).Caption.Caption;
        break;
      case buButton _:
        controlText = Ctrl.Text;
        break;
      case buLabel _:
        controlText = Ctrl.Text;
        break;
      case buCheckBox _:
        controlText = Ctrl.Text;
        break;
      case RadioButton _:
        controlText = Ctrl.Text;
        break;
      case Label _:
        controlText = Ctrl.Text;
        break;
      case Button _:
        controlText = Ctrl.Text;
        break;
    }
    return controlText;
  }
}
