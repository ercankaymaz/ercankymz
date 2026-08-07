// Decompiled with JetBrains decompiler
// Type: buControls.Forms.WinControlForms.Tools.F_ToolDetailed
// Assembly: buControls, Version=5.1.1.4, Culture=neutral, PublicKeyToken=null
// MVID: 8B369C0A-23E7-45ED-9051-267DACDF7858
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buControls.dll

using buClass;
using buControls.DialogBox;
using buCore;
using ns7;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;

#nullable disable
namespace buControls.Forms.WinControlForms.Tools;

public class F_ToolDetailed : Form
{
  public static List<string> Captions = new List<string>();
  public FormCloseModeType FormCloseMode = FormCloseModeType.Dispose;
  public ToolBase Tool = new ToolBase();
  public bool DataTabVisible = true;
  public bool GeometryTabVisible = true;
  public bool CamTabVisible = true;
  public bool PositionTabVisible = false;
  public bool AuxTabVisible = true;
  public ToolAreaVisible ToolVarVisible = new ToolAreaVisible();
  public bool ShowHelps = true;
  public bool ShowNextButton = false;
  public bool ShowPreButton = false;
  public bool ReadOnly = false;
  public int FormHeight = 0;
  public int FormWidth = 0;
  public DialogResult Result = DialogResult.None;
  private bool bool_0 = false;
  internal IContainer icontainer_0 = (IContainer) null;
  internal TabControl tabControl_0;
  internal TabPage tabPage_0;
  internal TabPage tabPage_1;
  internal TabPage tabPage_2;
  internal TabPage tabPage_3;
  internal ImageList imageList_0;
  internal ImageList imageList_1;
  internal PictureBox pictureBox_0;
  internal ComboBox comboBox_0;
  internal TabPage tabPage_4;
  internal Label label_0;
  internal TextBox textBox_0;
  internal Panel panel_0;
  internal Label label_1;
  internal Label label_2;
  internal Panel panel_1;
  internal CheckBox checkBox_0;
  internal Label label_3;
  internal Label label_4;
  internal Panel panel_2;
  internal CheckBox checkBox_1;
  internal Label label_5;
  internal Label label_6;
  internal Panel panel_3;
  internal ComboBox comboBox_1;
  internal Label label_7;
  internal Label label_8;
  internal Panel panel_4;
  internal Label label_9;
  internal Label label_10;
  internal Panel panel_5;
  internal Label label_11;
  internal NumericUpDown numericUpDown_0;
  internal Label label_12;
  internal Panel panel_6;
  internal Label label_13;
  internal NumericUpDown numericUpDown_1;
  internal Label label_14;
  internal Panel panel_7;
  internal Label label_15;
  internal NumericUpDown numericUpDown_2;
  internal Label label_16;
  internal Panel panel_8;
  internal Label label_17;
  internal NumericUpDown numericUpDown_3;
  internal NumericUpDown numericUpDown_4;
  internal Label label_18;
  internal NumericUpDown numericUpDown_5;
  internal Panel panel_9;
  internal Label label_19;
  internal NumericUpDown numericUpDown_6;
  internal Label label_20;
  internal Panel panel_10;
  internal Label label_21;
  internal NumericUpDown numericUpDown_7;
  internal Label label_22;
  internal Panel panel_11;
  internal Label label_23;
  internal NumericUpDown numericUpDown_8;
  internal Label label_24;
  internal Panel panel_12;
  internal Label label_25;
  internal NumericUpDown numericUpDown_9;
  internal Label label_26;
  internal Panel panel_13;
  internal Label label_27;
  internal NumericUpDown numericUpDown_10;
  internal NumericUpDown numericUpDown_11;
  internal Label label_28;
  internal NumericUpDown numericUpDown_12;
  internal Panel panel_14;
  internal Label label_29;
  internal NumericUpDown numericUpDown_13;
  internal NumericUpDown numericUpDown_14;
  internal Label label_30;
  internal NumericUpDown numericUpDown_15;
  internal Panel panel_15;
  internal Label label_31;
  internal NumericUpDown numericUpDown_16;
  internal NumericUpDown numericUpDown_17;
  internal Label label_32;
  internal NumericUpDown numericUpDown_18;
  internal Panel panel_16;
  internal Label label_33;
  internal NumericUpDown numericUpDown_19;
  internal NumericUpDown numericUpDown_20;
  internal Label label_34;
  internal NumericUpDown numericUpDown_21;
  internal Panel panel_17;
  internal Label label_35;
  internal NumericUpDown numericUpDown_22;
  internal Label label_36;
  internal ImageList imageList_2;
  public Button btn_cancel;
  public Button btn_ok;
  internal TextBox textBox_1;
  public Button btn_next;
  public Button btn_pre;
  internal Panel panel_18;
  internal Label label_37;
  internal Label label_38;
  internal Label label_39;
  internal Panel panel_19;
  internal Label label_40;
  internal Label label_41;
  internal Label label_42;
  internal Panel panel_20;
  internal Label label_43;
  internal Label label_44;
  internal Label label_45;
  internal Panel panel_21;
  internal Label label_46;
  internal Panel panel_22;
  internal ComboBox comboBox_2;
  internal Label label_47;
  internal Panel panel_23;
  internal Label label_48;
  internal NumericUpDown numericUpDown_23;
  internal Panel panel_24;
  internal Label label_49;
  internal NumericUpDown numericUpDown_24;
  internal Panel panel_25;
  internal Label label_50;
  internal NumericUpDown numericUpDown_25;
  internal Panel panel_26;
  internal Label label_51;
  internal NumericUpDown numericUpDown_26;
  internal Panel panel_27;
  internal Label label_52;
  internal NumericUpDown numericUpDown_27;
  internal NumericUpDown numericUpDown_28;
  internal TextBox textBox_2;
  internal Label label_53;
  internal Label label_54;
  internal Label label_55;
  internal Label label_56;
  internal Label label_57;
  internal Label label_58;
  internal Label label_59;

  public F_ToolDetailed() => Class39.smethod_607(this);

  public void Init()
  {
    this.bool_0 = false;
    ArrayList arrayList = new ArrayList();
    if (this.FormHeight > 10)
      this.Height = this.FormHeight;
    if (this.FormWidth > 10)
      this.Width = this.FormWidth;
    this.btn_next.Visible = this.ShowNextButton;
    this.btn_pre.Visible = this.ShowPreButton;
    if (!this.AuxTabVisible && this.tabControl_0.TabPages.Count >= 5)
      this.tabControl_0.TabPages.RemoveAt(4);
    if (!this.PositionTabVisible && this.tabControl_0.TabPages.Count >= 4)
      this.tabControl_0.TabPages.RemoveAt(3);
    if (!this.CamTabVisible && this.tabControl_0.TabPages.Count >= 3)
      this.tabControl_0.TabPages.RemoveAt(2);
    if (!this.GeometryTabVisible && this.tabControl_0.TabPages.Count >= 2)
      this.tabControl_0.TabPages.RemoveAt(1);
    if (!this.DataTabVisible && this.tabControl_0.TabPages.Count >= 1)
      this.tabControl_0.TabPages.RemoveAt(0);
    int num1 = 0;
    this.panel_0.Visible = this.ToolVarVisible.Name;
    if (this.ToolVarVisible.Name)
    {
      this.panel_0.Top = 6 + num1 * 32 /*0x20*/;
      ++num1;
    }
    this.panel_7.Visible = this.ToolVarVisible.No;
    if (this.ToolVarVisible.No)
    {
      this.panel_7.Top = 6 + num1 * 32 /*0x20*/;
      ++num1;
    }
    this.panel_6.Visible = this.ToolVarVisible.Sector;
    if (this.ToolVarVisible.Sector)
    {
      this.panel_6.Top = 6 + num1 * 32 /*0x20*/;
      ++num1;
    }
    this.panel_5.Visible = this.ToolVarVisible.HeightOffsetIndex;
    if (this.ToolVarVisible.HeightOffsetIndex)
    {
      this.panel_5.Top = 6 + num1 * 32 /*0x20*/;
      ++num1;
    }
    this.panel_4.Visible = this.ToolVarVisible.Tag;
    if (this.ToolVarVisible.Name)
    {
      this.panel_4.Top = 6 + num1 * 32 /*0x20*/;
      ++num1;
    }
    this.panel_3.Visible = this.ToolVarVisible.Purpose;
    if (this.ToolVarVisible.Purpose)
    {
      this.panel_3.Top = 6 + num1 * 32 /*0x20*/;
      ++num1;
    }
    this.panel_2.Visible = this.ToolVarVisible.Clone;
    if (this.ToolVarVisible.Clone)
    {
      this.panel_2.Top = 6 + num1 * 32 /*0x20*/;
      ++num1;
    }
    this.panel_1.Visible = this.ToolVarVisible.Broken;
    if (this.ToolVarVisible.Broken)
    {
      this.panel_1.Top = 6 + num1 * 32 /*0x20*/;
      int num2 = num1 + 1;
    }
    int num3 = 0;
    this.panel_12.Visible = this.ToolVarVisible.Diameter;
    if (this.ToolVarVisible.Diameter)
    {
      this.panel_12.Top = 6 + num3 * 32 /*0x20*/;
      ++num3;
    }
    this.panel_10.Visible = this.ToolVarVisible.Length;
    if (this.ToolVarVisible.Length)
    {
      this.panel_10.Top = 6 + num3 * 32 /*0x20*/;
      ++num3;
    }
    this.panel_11.Visible = this.ToolVarVisible.Thickness;
    if (this.ToolVarVisible.Thickness)
    {
      this.panel_11.Top = 6 + num3 * 32 /*0x20*/;
      ++num3;
    }
    this.panel_9.Visible = this.ToolVarVisible.MinLength;
    if (this.ToolVarVisible.MinLength)
    {
      this.panel_9.Top = 6 + num3 * 32 /*0x20*/;
      ++num3;
    }
    this.panel_8.Visible = this.ToolVarVisible.VectorDirection;
    if (this.ToolVarVisible.VectorDirection)
    {
      this.panel_8.Top = 6 + num3 * 32 /*0x20*/;
      ++num3;
    }
    this.panel_20.Visible = this.ToolVarVisible.SolidColor;
    if (this.ToolVarVisible.SolidColor)
    {
      this.panel_20.Top = 6 + num3 * 32 /*0x20*/;
      ++num3;
    }
    this.panel_18.Visible = this.ToolVarVisible.CamColor;
    if (this.ToolVarVisible.CamColor)
    {
      this.panel_18.Top = 6 + num3 * 32 /*0x20*/;
      ++num3;
    }
    this.panel_19.Visible = this.ToolVarVisible.UpperCamColor;
    if (this.ToolVarVisible.UpperCamColor)
    {
      this.panel_19.Top = 6 + num3 * 32 /*0x20*/;
      int num4 = num3 + 1;
    }
    int num5 = 0;
    this.panel_27.Visible = this.ToolVarVisible.Stepover;
    if (this.ToolVarVisible.Stepover)
    {
      this.panel_27.Top = 6 + num5 * 32 /*0x20*/;
      ++num5;
    }
    this.panel_26.Visible = this.ToolVarVisible.OperationHeight;
    if (this.ToolVarVisible.OperationHeight)
    {
      this.panel_26.Top = 6 + num5 * 32 /*0x20*/;
      ++num5;
    }
    this.panel_25.Visible = this.ToolVarVisible.FeedSpeed;
    if (this.ToolVarVisible.FeedSpeed)
    {
      this.panel_25.Top = 6 + num5 * 32 /*0x20*/;
      ++num5;
    }
    this.panel_24.Visible = this.ToolVarVisible.PlungeSpeed;
    if (this.ToolVarVisible.PlungeSpeed)
    {
      this.panel_24.Top = 6 + num5 * 32 /*0x20*/;
      ++num5;
    }
    this.panel_23.Visible = this.ToolVarVisible.SpindleSpeed;
    if (this.ToolVarVisible.SpindleSpeed)
    {
      this.panel_23.Top = 6 + num5 * 32 /*0x20*/;
      ++num5;
    }
    this.panel_22.Visible = this.ToolVarVisible.SpindleDirection;
    if (this.ToolVarVisible.SpindleDirection)
    {
      this.panel_22.Top = 6 + num5 * 32 /*0x20*/;
      ++num5;
    }
    this.panel_21.Visible = this.ToolVarVisible.OperationHeigthForSecond;
    if (this.ToolVarVisible.OperationHeigthForSecond)
    {
      this.panel_21.Top = 6 + num5 * 32 /*0x20*/;
      int num6 = num5 + 1;
    }
    int num7 = 0;
    this.panel_17.Visible = this.ToolVarVisible.AngularPosition;
    if (this.ToolVarVisible.AngularPosition)
    {
      this.panel_17.Top = 40 + num7 * 32 /*0x20*/;
      ++num7;
    }
    this.panel_15.Visible = this.ToolVarVisible.SetPositionXYZ;
    if (this.ToolVarVisible.SetPositionXYZ)
    {
      this.panel_15.Top = 40 + num7 * 32 /*0x20*/;
      ++num7;
    }
    this.panel_16.Visible = this.ToolVarVisible.SetPositionABC;
    if (this.ToolVarVisible.SetPositionABC)
    {
      this.panel_16.Top = 40 + num7 * 32 /*0x20*/;
      ++num7;
    }
    this.panel_14.Visible = this.ToolVarVisible.OffsetXYZ;
    if (this.ToolVarVisible.OffsetXYZ)
    {
      this.panel_14.Top = 40 + num7 * 32 /*0x20*/;
      ++num7;
    }
    this.panel_13.Visible = this.ToolVarVisible.OffsetABC;
    if (this.ToolVarVisible.OffsetABC)
    {
      this.panel_13.Top = 40 + num7 * 32 /*0x20*/;
      int num8 = num7 + 1;
    }
    ArrayList EnumItems1 = new ArrayList();
    buGeneral.GetEnumTypeValues((object) this.Tool.Geometry.GeometryType, ref EnumItems1);
    buControlCommands.ComboboxAddItem(EnumItems1, Convert.ToInt32((object) this.Tool.Geometry.GeometryType), ref this.comboBox_0);
    ArrayList EnumItems2 = new ArrayList();
    buGeneral.GetEnumTypeValues((object) this.Tool.Purpose, ref EnumItems2);
    buControlCommands.ComboboxAddItem(EnumItems2, Convert.ToInt32((object) this.Tool.Purpose), ref this.comboBox_1);
    this.numericUpDown_2.Value = (Decimal) this.Tool.Data.No;
    this.numericUpDown_1.Value = (Decimal) this.Tool.Data.Sector;
    this.numericUpDown_0.Value = (Decimal) this.Tool.Data.HeightOffsetIndex;
    this.textBox_1.Text = this.Tool.Data.Name;
    this.textBox_2.Text = this.Tool.Data.Tag;
    this.checkBox_0.Checked = this.Tool.Data.Broken;
    this.checkBox_1.Checked = this.Tool.Data.Clone;
    this.numericUpDown_9.Value = (Decimal) this.Tool.Geometry.Diameter;
    this.numericUpDown_7.Value = (Decimal) this.Tool.Geometry.Length;
    this.numericUpDown_8.Value = (Decimal) this.Tool.Geometry.Thickness;
    this.numericUpDown_6.Value = (Decimal) this.Tool.Geometry.MinLength;
    this.numericUpDown_5.Value = (Decimal) this.Tool.Geometry.PlaneDirection.X;
    this.numericUpDown_4.Value = (Decimal) this.Tool.Geometry.PlaneDirection.Y;
    this.numericUpDown_3.Value = (Decimal) this.Tool.Geometry.PlaneDirection.Z;
    this.label_43.BackColor = this.Tool.Display.Solid.SkinColor;
    this.label_37.BackColor = this.Tool.Display.CamColor;
    this.label_40.BackColor = this.Tool.Display.UpperCamColor;
    ArrayList EnumItems3 = new ArrayList();
    buGeneral.GetEnumTypeValues((object) this.Tool.CamData.SpindleDirection, ref EnumItems3);
    buControlCommands.ComboboxAddItem(EnumItems3, Convert.ToInt32((object) this.Tool.CamData.SpindleDirection), ref this.comboBox_2);
    this.numericUpDown_28.Value = (Decimal) this.Tool.CamData.Stepover;
    this.numericUpDown_26.Value = (Decimal) this.Tool.CamData.OperationHeight;
    this.numericUpDown_25.Value = (Decimal) this.Tool.CamData.FeedSpeed;
    this.numericUpDown_24.Value = (Decimal) this.Tool.CamData.PlungeSpeed;
    this.numericUpDown_23.Value = (Decimal) this.Tool.CamData.SpindleSpeed;
    this.numericUpDown_27.Value = (Decimal) this.Tool.CamData.OperationHeigthForSecond;
    this.numericUpDown_22.Value = (Decimal) this.Tool.Positions.AngularPosition;
    this.numericUpDown_18.Value = (Decimal) this.Tool.Positions.Position.X;
    this.numericUpDown_17.Value = (Decimal) this.Tool.Positions.Position.Y;
    this.numericUpDown_16.Value = (Decimal) this.Tool.Positions.Position.Z;
    this.numericUpDown_21.Value = (Decimal) this.Tool.Positions.Position.A;
    this.numericUpDown_20.Value = (Decimal) this.Tool.Positions.Position.B;
    this.numericUpDown_19.Value = (Decimal) this.Tool.Positions.Position.C;
    this.numericUpDown_15.Value = (Decimal) this.Tool.Positions.Offset.X;
    this.numericUpDown_14.Value = (Decimal) this.Tool.Positions.Offset.Y;
    this.numericUpDown_13.Value = (Decimal) this.Tool.Positions.Offset.Z;
    this.numericUpDown_12.Value = (Decimal) this.Tool.Positions.Offset.A;
    this.numericUpDown_11.Value = (Decimal) this.Tool.Positions.Offset.B;
    this.numericUpDown_10.Value = (Decimal) this.Tool.Positions.Offset.C;
    this.Result = DialogResult.None;
    this.bool_0 = true;
    this.LoadLangueage();
  }

  public void LoadLangueage()
  {
    string callMethod = "ToolDetailed LoadLanguage";
    try
    {
      if (F_ToolDetailed.Captions.Count < 67)
        return;
      this.Text = F_ToolDetailed.Captions[0];
      this.tabPage_0.Text = F_ToolDetailed.Captions[1];
      this.label_1.Text = F_ToolDetailed.Captions[2];
      this.label_15.Text = F_ToolDetailed.Captions[3];
      this.label_13.Text = F_ToolDetailed.Captions[4];
      this.label_11.Text = F_ToolDetailed.Captions[5];
      this.label_9.Text = F_ToolDetailed.Captions[6];
      this.label_7.Text = F_ToolDetailed.Captions[7];
      this.label_5.Text = F_ToolDetailed.Captions[8];
      this.label_3.Text = F_ToolDetailed.Captions[9];
      this.label_2.Text = F_ToolDetailed.Captions[10];
      this.label_16.Text = F_ToolDetailed.Captions[11];
      this.label_14.Text = F_ToolDetailed.Captions[12];
      this.label_12.Text = F_ToolDetailed.Captions[13];
      this.label_10.Text = F_ToolDetailed.Captions[14];
      this.label_8.Text = F_ToolDetailed.Captions[15];
      this.label_6.Text = F_ToolDetailed.Captions[16 /*0x10*/];
      this.label_4.Text = F_ToolDetailed.Captions[17];
      this.tabPage_1.Text = F_ToolDetailed.Captions[18];
      this.label_25.Text = F_ToolDetailed.Captions[19];
      this.label_21.Text = F_ToolDetailed.Captions[20];
      this.label_23.Text = F_ToolDetailed.Captions[21];
      this.label_19.Text = F_ToolDetailed.Captions[22];
      this.label_18.Text = F_ToolDetailed.Captions[23];
      this.label_44.Text = F_ToolDetailed.Captions[24];
      this.label_38.Text = F_ToolDetailed.Captions[25];
      this.label_41.Text = F_ToolDetailed.Captions[26];
      this.label_26.Text = F_ToolDetailed.Captions[27];
      this.label_22.Text = F_ToolDetailed.Captions[28];
      this.label_24.Text = F_ToolDetailed.Captions[29];
      this.label_20.Text = F_ToolDetailed.Captions[30];
      this.label_17.Text = F_ToolDetailed.Captions[31 /*0x1F*/];
      this.label_45.Text = F_ToolDetailed.Captions[32 /*0x20*/];
      this.label_39.Text = F_ToolDetailed.Captions[33];
      this.label_42.Text = F_ToolDetailed.Captions[34];
      this.tabPage_2.Text = F_ToolDetailed.Captions[35];
      this.label_52.Text = F_ToolDetailed.Captions[36];
      this.label_51.Text = F_ToolDetailed.Captions[37];
      this.label_50.Text = F_ToolDetailed.Captions[38];
      this.label_49.Text = F_ToolDetailed.Captions[39];
      this.label_48.Text = F_ToolDetailed.Captions[40];
      this.label_47.Text = F_ToolDetailed.Captions[41];
      this.label_46.Text = F_ToolDetailed.Captions[42];
      this.label_59.Text = F_ToolDetailed.Captions[43];
      this.label_58.Text = F_ToolDetailed.Captions[44];
      this.label_57.Text = F_ToolDetailed.Captions[45];
      this.label_56.Text = F_ToolDetailed.Captions[46];
      this.label_55.Text = F_ToolDetailed.Captions[47];
      this.label_54.Text = F_ToolDetailed.Captions[48 /*0x30*/];
      this.label_53.Text = F_ToolDetailed.Captions[49];
      this.tabPage_4.Text = F_ToolDetailed.Captions[50];
      this.label_35.Text = F_ToolDetailed.Captions[51];
      this.label_32.Text = F_ToolDetailed.Captions[52];
      this.label_34.Text = F_ToolDetailed.Captions[53];
      this.label_30.Text = F_ToolDetailed.Captions[54];
      this.label_28.Text = F_ToolDetailed.Captions[55];
      this.label_36.Text = F_ToolDetailed.Captions[56];
      this.label_31.Text = F_ToolDetailed.Captions[57];
      this.label_33.Text = F_ToolDetailed.Captions[58];
      this.label_29.Text = F_ToolDetailed.Captions[59];
      this.label_27.Text = F_ToolDetailed.Captions[60];
      this.textBox_0.Text = F_ToolDetailed.Captions[61];
      this.label_0.Text = F_ToolDetailed.Captions[62];
      this.btn_ok.Text = F_ToolDetailed.Captions[63 /*0x3F*/];
      this.btn_cancel.Text = F_ToolDetailed.Captions[64 /*0x40*/];
      this.btn_pre.Text = F_ToolDetailed.Captions[65];
      this.btn_next.Text = F_ToolDetailed.Captions[66];
    }
    catch (Exception ex)
    {
      string str = "";
      buLog.addLog(str, "Not Ok", callMethod);
      buException.throwException(ex, callMethod, true, str);
    }
  }

  internal void method_0(object sender, EventArgs e)
  {
    Control control1 = new Control();
    Control control2 = (Control) sender;
    if (!this.bool_0)
      return;
    if (control2.Name == this.btn_ok.Name)
    {
      Class39.smethod_581(this);
      this.Result = DialogResult.OK;
      if (this.FormCloseMode == FormCloseModeType.Dispose)
        this.Dispose();
      if (this.FormCloseMode == FormCloseModeType.Invisible)
        this.Visible = false;
    }
    if (!(control2.Name == this.btn_cancel.Name))
      return;
    this.Result = DialogResult.Cancel;
    if (this.FormCloseMode == FormCloseModeType.Dispose)
      this.Dispose();
    if (this.FormCloseMode != FormCloseModeType.Invisible)
      return;
    this.Visible = false;
  }

  internal void method_1(object sender, KeyEventArgs e)
  {
    Control control1 = new Control();
    Control control2 = (Control) sender;
    if (!(e.KeyCode == Keys.Return | e.KeyCode == Keys.Tab))
      return;
    int result = 0;
    int.TryParse(control2.Tag.ToString(), out result);
    buControlCommands.FindNextControlByKey(this.tabControl_0.SelectedTab.Controls, result, e.Shift);
  }

  internal void method_2(object sender, EventArgs e)
  {
    try
    {
      if (!AppBool.TouchPad)
        return;
      if (sender.GetType() == typeof (TextBox))
      {
        TextBox textBox = new TextBox();
        buControlCommands.ShowKeyPad((Form) this, (Control) sender);
      }
      if (!(sender.GetType() == typeof (NumericUpDown)))
        return;
      NumericUpDown numericUpDown = new NumericUpDown();
      buControlCommands.ShowKeyPad((Form) this, (Control) sender);
    }
    catch (Exception ex)
    {
      string message = "";
      buException.throwException(new CalculationErrorEventArg(true, MethodBase.GetCurrentMethod().Name, message, "Exception", "", "", -1, ex), true);
    }
  }

  internal void method_3(object sender, EventArgs e)
  {
    this.pictureBox_0.Image = (Image) null;
    if (this.comboBox_0.SelectedIndex >= 0 & this.comboBox_0.SelectedIndex <= this.imageList_1.Images.Count - 2)
      this.pictureBox_0.Image = this.imageList_1.Images[this.comboBox_0.SelectedIndex + 1];
    else
      this.pictureBox_0.Image = this.imageList_1.Images[0];
  }

  internal void method_4(object sender, EventArgs e)
  {
    Control control1 = new Control();
    Control control2 = (Control) sender;
    if (control2.Name == this.label_43.Name)
    {
      Color backColor = this.label_43.BackColor;
      if (ColorDialogBox.ShowDialog(ref backColor) == DialogResult.OK)
        this.label_43.BackColor = backColor;
    }
    if (control2.Name == this.label_37.Name)
    {
      Color backColor = this.label_37.BackColor;
      if (ColorDialogBox.ShowDialog(ref backColor) == DialogResult.OK)
        this.label_37.BackColor = backColor;
    }
    if (!(control2.Name == this.label_40.Name))
      return;
    Color backColor1 = this.label_40.BackColor;
    if (ColorDialogBox.ShowDialog(ref backColor1) != DialogResult.OK)
      return;
    this.label_40.BackColor = backColor1;
  }

  protected override void Dispose(bool disposing)
  {
    if ((!disposing ? 0 : (this.icontainer_0 != null ? 1 : 0)) != 0)
      this.icontainer_0.Dispose();
    base.Dispose(disposing);
  }
}
