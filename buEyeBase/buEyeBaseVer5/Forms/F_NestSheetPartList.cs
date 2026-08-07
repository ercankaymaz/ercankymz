// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Forms.F_NestSheetPartList
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using buClass.Apps;
using buControls.DialogBox;
using buCore;
using buEyeBaseVer5.Apps;
using buEyeBaseVer5.buEntities;
using devDept.Eyeshot.Control;
using devDept.Eyeshot.Entities;
using devDept.Geometry;
using dummy_ptr;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;

#nullable disable
namespace buEyeBaseVer5.Forms;

public class F_NestSheetPartList : Form
{
  internal Label \u0001;
  internal Panel \u0001;
  internal Label \u0002;
  internal Button \u0001;
  internal ImageList \u0001;
  internal Button \u0002;
  internal Label \u0003;
  internal Label \u0004;
  internal Panel \u0002;
  internal Label \u0005;
  internal Label \u0006;
  internal NumericUpDown \u0001;
  internal Panel \u0003;
  public TextBox txt_name;
  internal Label \u0007;
  public TextBox txt_explanation;
  public static byte f000EDD;
  public static List<string> Captions;
  public FormProperties PropertiesForm;
  public buNestingSheet Sheet;
  public buNestingVar Settings;
  private Design \u0001;
  private Timer \u0001;
  internal IContainer \u0001;
  internal Label \u0001;
  internal Panel \u0001;
  internal Label \u0002;
  internal Button \u0001;
  internal ImageList \u0001;
  internal Button \u0002;
  internal Label \u0003;
  internal Label \u0004;
  internal NumericUpDown \u0001;
  internal Panel \u0002;
  internal Label \u0005;
  internal Label \u0006;
  internal NumericUpDown \u0002;
  internal Panel \u0003;
  internal Label \u0007;
  internal Panel \u0004;
  internal CheckBox \u0001;
  internal CheckBox \u0002;
  public TextBox txt_name;
  public static byte f000EF8;
  public static List<string> Captions;
  public FormProperties PropertiesForm;
  public buNestingPart Part;
  public buNestingVar Settings;
  private Design \u0001;
  private Timer \u0001;
  internal IContainer \u0001;
  internal Panel \u0001;
  internal Label \u0001;
  internal Button \u0001;
  internal ImageList \u0001;
  internal Panel \u0002;
  internal Label \u0002;
  internal NumericUpDown \u0001;
  internal Button \u0002;
  internal Panel \u0003;
  internal ComboBox \u0001;
  internal Label \u0003;
  internal Label \u0004;
  internal NumericUpDown \u0002;
  internal Panel \u0004;
  internal Label \u0005;
  internal NumericUpDown \u0003;
  internal Panel \u0005;
  internal Label \u0006;
  internal Panel \u0006;
  internal CheckBox \u0001;
  internal CheckBox \u0002;
  public TextBox txt_name;
  internal Label \u0007;
  internal Panel \u0007;
  internal Label \u0008;
  internal Label \u000E;
  internal RadioButton \u0001;
  internal RadioButton \u0002;
  internal NumericUpDown \u0004;
  internal Label \u000F;
  internal Panel \u0008;
  internal Label \u0010;
  internal Label \u0011;
  internal NumericUpDown \u0005;
  internal CheckBox \u0003;
  internal Label \u0012;
  internal NumericUpDown \u0006;
  internal Label \u0013;
  public static byte f000F26;
  public static List<string> Captions;
  public DialogResult Result;
  public FormCloseModeType FormCloseMode;
  public buNestingPart Part;
  public buNestingVar Settings;
  public bool ShowItemNo;
  internal IContainer \u0001;
  internal Label \u0001;
  internal TextBox \u0001;
  internal Panel \u0001;
  internal Label \u0002;
  internal Label \u0003;
  internal Label \u0004;

  internal void \u0001([In] object obj0, [In] TreeViewEventArgs obj1)
  {
    if (((F_BendingRotaryDisk) this).treeView1.SelectedNode == null || ((F_BendingRotaryDisk) this).treeView1.SelectedNode.Tag == null)
      return;
    ((F_BendingRotaryDisk) this).\u0001 = ((F_BendingRotaryDisk) this).treeView1.SelectedNode.Tag.ToString();
  }

  internal void \u0004([In] object obj0, [In] EventArgs obj1)
  {
    // ISSUE: reference to a compiler-generated field
    if (((F_PanelCutNestSheetPartList) this).\u0001 == null)
      return;
    // ISSUE: reference to a compiler-generated field
    ((F_PanelCutNestSheetPartList) this).\u0001((object) ((F_BendingRotaryDisk) this).\u0001);
  }

  internal void \u0005([In] object obj0, [In] EventArgs obj1)
  {
    if (!((F_BendingRotaryDisk) this).\u0002.Visible)
      ((F_BendingRotaryDisk) this).\u0002.Visible = true;
    else
      ((F_BendingRotaryDisk) this).\u0002.Visible = false;
  }

  internal void \u0006([In] object obj0, [In] EventArgs obj1)
  {
    ((F_BendingRotaryDisk) this).\u0002.Visible = false;
  }

  internal void \u0007([In] object obj0, [In] EventArgs obj1)
  {
    // ISSUE: reference to a compiler-generated field
    if (!((F_PanelCutNestSheetPartList) this).PropertiesForm.Inited || ((F_BendingRotaryDisk) this).\u0003 == null)
      return;
    ((buEyeBaseVer5.Apps.ProfileClamperSettings) ((ProfileSupportBlock) ((F_BendingRotaryDisk) this).SettingsPar).Settings).ShowResultPreviewAfterFinish = ((F_BendingRotaryDisk) this).\u0001.Checked;
    // ISSUE: reference to a compiler-generated field
    ((F_BendingRotaryDisk) this).\u0003((object) ((F_BendingRotaryDisk) this).SettingsPar);
  }

  protected override void Dispose(bool disposing)
  {
    if ((!disposing ? 0 : (((F_BendingRotaryDisk) this).\u0001 != null ? 1 : 0)) != 0)
      ((F_BendingRotaryDisk) this).\u0001.Dispose();
    base.Dispose(disposing);
  }

  static F_NestSheetPartList() => F_PanelCutNestSheetPartList.Captions = new List<string>();

  public F_NestSheetPartList()
  {
    ((F_BendingRotaryDisk) this).PropertiesForm = new FormProperties();
    ((F_BendingRotaryDisk) this).Part = (buNestingPart) new buEyeBaseVer5.Apps.ProfileOperationBarrel();
    ((F_BendingRotaryDisk) this).Settings = (buNestingVar) new buEyeBaseVer5.Apps.ProfileOperationDataBarel();
    ((F_BendingRotaryDisk) this).\u0001 = (Design) null;
    ((F_BendingRotaryDisk) this).\u0001 = new Timer();
    ((F_BendingLRAList) this).\u0001 = (IContainer) null;
    // ISSUE: explicit constructor call
    base.\u002Ector();
    buCompare5.CultureSettings();
    \u0007.\u0001.\u0001((F_NestPartAddV2) this);
    ((F_BendingRotaryDisk) this).\u0001.Tick += new EventHandler(this.\u0002);
  }

  internal void \u0001([In] object obj0, [In] EventArgs obj1)
  {
  }

  public void Init()
  {
    ((F_BendingRotaryDisk) this).PropertiesForm.Inited = false;
    if (((F_BendingRotaryDisk) this).PropertiesForm.Height > 10)
      this.Height = ((F_BendingRotaryDisk) this).PropertiesForm.Height;
    if (((F_BendingRotaryDisk) this).PropertiesForm.Width > 10)
      this.Width = ((F_BendingRotaryDisk) this).PropertiesForm.Width;
    this.TopMost = ((F_BendingRotaryDisk) this).PropertiesForm.TopMost;
    this.StartPosition = ((F_BendingRotaryDisk) this).PropertiesForm.FormPosition;
    ((F_BendingLRAList) this).\u0001.Value = (Decimal) ((buEyeBaseVer5.Apps.ProfileOperationNotch) ((ProfileSupportBlock) ((F_BendingRotaryDisk) this).Settings).AddPart).Priority;
    ((F_BendingLRAList) this).\u0002.Value = (Decimal) ((ProfileOperationNotchOld) ((ProfileSupportBlock) ((F_BendingRotaryDisk) this).Settings).AddPart).Quantity;
    ((F_BendingLRAList) this).\u0003.Value = (Decimal) ((ProfileOperationNotchOld) ((ProfileSupportBlock) ((F_BendingRotaryDisk) this).Settings).AddPart).Thickness;
    ((F_BendingLRAList) this).\u0004.Value = (Decimal) ((ProfileOperationNotchOld) ((ProfileSupportBlock) ((F_BendingRotaryDisk) this).Settings).AddPart).PartDistance;
    ((F_BendingLRAList) this).txt_name.Text = ((ProfileOperationNotchOld) ((ProfileSupportBlock) ((F_BendingRotaryDisk) this).Settings).AddPart).Name;
    ((F_BendingLRAList) this).\u0004.Checked = ((buEyeBaseVer5.Apps.ProfileOperationText) ((ProfileSupportBlock) ((F_BendingRotaryDisk) this).Settings).AddPart).MirrorEnable;
    ((F_BendingLRAList) this).\u0001.Checked = ((buEyeBaseVer5.Apps.ProfileOperationNotch) ((ProfileSupportBlock) ((F_BendingRotaryDisk) this).Settings).AddPart).AddAuxEntities;
    ((F_BendingLRAList) this).\u0002.Checked = ((buEyeBaseVer5.Apps.ProfileOperationNotch) ((ProfileSupportBlock) ((F_BendingRotaryDisk) this).Settings).AddPart).DeleteSelectedEntities;
    ((F_BendingLRAList) this).\u0003.Checked = ((buEyeBaseVer5.Apps.ProfileOperationNotch) ((ProfileSupportBlock) ((F_BendingRotaryDisk) this).Settings).AddPart).DeleteSelectedAuxEntities;
    ArrayList EnumItems = new ArrayList();
    buCompare5.GetEnumTypeValues((object) ((buEyeBaseVer5.Apps.ProfileOperationFreeDraw) ((ProfileSupportBlock) ((F_BendingRotaryDisk) this).Settings).AddPart).Rotation, ref EnumItems);
    buCompare5.ComboboxAddItem(EnumItems, Convert.ToInt32((object) ((buEyeBaseVer5.Apps.ProfileOperationFreeDraw) ((ProfileSupportBlock) ((F_BendingRotaryDisk) this).Settings).AddPart).Rotation), ref ((F_BendingLRAList) this).\u0001);
    this.LoadLanguage();
    if (((F_BendingRotaryDisk) this).\u0001 == null)
    {
      EyeCreateProps Properties = (EyeCreateProps) new ShapeEdit();
      ((DiameterDepthPoint) Properties).ShowToolBar = false;
      ((DiameterDepthPoint) Properties).ShowViewCube = false;
      ((MaterialBase5) Properties).ShowCoordinateArrow = false;
      buConversion5.CreateControlsTool(true, Properties, ref ((F_BendingRotaryDisk) this).\u0001);
      ((F_BendingRotaryDisk) this).\u0001.Dock = DockStyle.Fill;
      if (((F_BendingLRAList) this).\u0006.Controls.Count == 0)
        ((F_BendingLRAList) this).\u0006.Controls.Add((System.Windows.Forms.Control) ((F_BendingRotaryDisk) this).\u0001);
    }
    ((F_BendingRotaryDisk) this).\u0001.Interval = 50;
    ((F_BendingRotaryDisk) this).\u0001.Enabled = true;
    ((F_BendingRotaryDisk) this).PropertiesForm.Result = DialogResult.None;
    ((F_BendingRotaryDisk) this).PropertiesForm.Inited = true;
  }

  private void \u0002([In] object obj0, [In] EventArgs obj1)
  {
    ((F_BendingRotaryDisk) this).\u0001.Enabled = false;
    buNestingVar Settings = (buNestingVar) new buEyeBaseVer5.Apps.ProfileOperationDataBarel(((F_BendingRotaryDisk) this).Settings);
    ((ProfileOperationCamData) ((ProfileMultiply) Settings).Draw).PartInnerShow = ((buEyeBaseVer5.Apps.ProfileOperationNotch) ((ProfileSupportBlock) ((F_BendingRotaryDisk) this).Settings).AddPart).AddAuxEntities;
    buCall.\u0001.DrawPart(((F_BendingRotaryDisk) this).Part, Settings, ref ((F_BendingRotaryDisk) this).\u0001);
  }

  public void LoadLanguage()
  {
    string callMethod = "NestPartAdd LoadLanguage";
    try
    {
      if (F_BendingRotaryDisk.Captions.Count < 9)
        return;
      this.Text = F_BendingRotaryDisk.Captions[0];
      ((F_BendingLRAList) this).\u0001.Text = F_BendingRotaryDisk.Captions[1];
      ((F_BendingLRAList) this).\u0005.Text = F_BendingRotaryDisk.Captions[2];
      ((F_BendingLRAList) this).\u0004.Text = F_BendingRotaryDisk.Captions[3];
      ((F_BendingLRAList) this).\u0002.Text = F_BendingRotaryDisk.Captions[4];
      ((F_BendingLRAList) this).\u0003.Text = F_BendingRotaryDisk.Captions[5];
      ((F_BendingLRAList) this).\u0001.Text = F_BendingRotaryDisk.Captions[6];
      ((F_BendingLRAList) this).\u0002.Text = F_BendingRotaryDisk.Captions[7];
      ((F_BendingLRAList) this).\u0001.Text = F_BendingRotaryDisk.Captions[8];
      ((F_BendingLRAList) this).\u0002.Text = F_BendingRotaryDisk.Captions[9];
      ((F_BendingLRAList) this).\u0008.Text = buLangTranslate.preDef.Mirror;
      ((F_BendingLRAList) this).\u0003.Text = F_BendingRotaryDisk.Captions[14];
      ((F_BendingLRAList) this).\u0007.Text = F_BendingRotaryDisk.Captions[15];
    }
    catch (Exception ex)
    {
      string str = "";
      buLog.addLog(str, "Not Ok", callMethod);
      buException.throwException(ex, callMethod, true, str);
    }
  }

  internal void \u0003([In] object obj0, [In] EventArgs obj1)
  {
    System.Windows.Forms.Control control1 = new System.Windows.Forms.Control();
    System.Windows.Forms.Control control2 = (System.Windows.Forms.Control) obj0;
    if (control2.Name == ((F_BendingLRAList) this).\u0001.Name)
    {
      ((buEyeBaseVer5.Apps.ProfileOperationNotch) ((ProfileSupportBlock) ((F_BendingRotaryDisk) this).Settings).AddPart).Priority = (int) ((F_BendingLRAList) this).\u0001.Value;
      ((ProfileOperationNotchOld) ((ProfileSupportBlock) ((F_BendingRotaryDisk) this).Settings).AddPart).Quantity = (int) ((F_BendingLRAList) this).\u0002.Value;
      ((ProfileOperationNotchOld) ((ProfileSupportBlock) ((F_BendingRotaryDisk) this).Settings).AddPart).Thickness = (double) ((F_BendingLRAList) this).\u0003.Value;
      ((buEyeBaseVer5.Apps.ProfileOperationNotch) ((ProfileSupportBlock) ((F_BendingRotaryDisk) this).Settings).AddPart).AddAuxEntities = ((F_BendingLRAList) this).\u0001.Checked;
      ((buEyeBaseVer5.Apps.ProfileOperationNotch) ((ProfileSupportBlock) ((F_BendingRotaryDisk) this).Settings).AddPart).DeleteSelectedEntities = ((F_BendingLRAList) this).\u0002.Checked;
      ((buEyeBaseVer5.Apps.ProfileOperationNotch) ((ProfileSupportBlock) ((F_BendingRotaryDisk) this).Settings).AddPart).DeleteSelectedAuxEntities = ((F_BendingLRAList) this).\u0003.Checked;
      ((buEyeBaseVer5.Apps.ProfileOperationFreeDraw) ((ProfileSupportBlock) ((F_BendingRotaryDisk) this).Settings).AddPart).Rotation = (nestPartRotateType) buGeneral.EnumValueFromInt((object) ((buEyeBaseVer5.Apps.ProfileOperationFreeDraw) ((ProfileSupportBlock) ((F_BendingRotaryDisk) this).Settings).AddPart).Rotation, ((F_BendingLRAList) this).\u0001.SelectedIndex);
      ((buEyeBaseVer5.Apps.ProfileOperationText) ((ProfileSupportBlock) ((F_BendingRotaryDisk) this).Settings).AddPart).MirrorEnable = ((F_BendingLRAList) this).\u0004.Checked;
      ((ProfileOperationNotchOld) ((ProfileSupportBlock) ((F_BendingRotaryDisk) this).Settings).AddPart).PartDistance = (double) ((F_BendingLRAList) this).\u0004.Value;
      ((buEyeBaseVer5.Apps.ProfileOperation) ((buEyeBaseVer5.Apps.ProfileOperation) ((F_BendingRotaryDisk) this).Part).PartData).Thickness = (double) ((F_BendingLRAList) this).\u0003.Value;
      ((buEyeBaseVer5.Apps.ProfileOperation) ((buEyeBaseVer5.Apps.ProfileOperation) ((F_BendingRotaryDisk) this).Part).PartData).Quantity = (int) ((F_BendingLRAList) this).\u0002.Value;
      ((buEyeBaseVer5.Apps.ProfileOperation) ((buEyeBaseVer5.Apps.ProfileOperation) ((F_BendingRotaryDisk) this).Part).PartData).Priority = (int) ((F_BendingLRAList) this).\u0001.Value;
      ((buEyeBaseVer5.Apps.ProfileOperation) ((F_BendingRotaryDisk) this).Part).PartDistance = (double) (int) ((F_BendingLRAList) this).\u0004.Value;
      ((buEyeBaseVer5.Apps.ProfileOperation) ((buEyeBaseVer5.Apps.ProfileOperation) ((F_BendingRotaryDisk) this).Part).PartData).Name = ((F_BendingLRAList) this).txt_name.Text;
      ((buEyeBaseVer5.Apps.ProfileOperation) ((buEyeBaseVer5.Apps.ProfileOperation) ((F_BendingRotaryDisk) this).Part).PartData).Rotation = (nestPartRotateType) buCompare5.EnumValueFromInt((object) ((buEyeBaseVer5.Apps.ProfileOperation) ((buEyeBaseVer5.Apps.ProfileOperation) ((F_BendingRotaryDisk) this).Part).PartData).Rotation, ((F_BendingLRAList) this).\u0001.SelectedIndex);
      if (((buEyeBaseVer5.Apps.ProfileOperation) ((buEyeBaseVer5.Apps.ProfileOperation) ((F_BendingRotaryDisk) this).Part).PartData).Quantity <= 0)
      {
        buNumeric5.MessageBoxWarning(AppLanguage.CadCamMessages[37]);
        return;
      }
      if (((buEyeBaseVer5.Apps.ProfileOperation) ((buEyeBaseVer5.Apps.ProfileOperation) ((F_BendingRotaryDisk) this).Part).PartData).Width <= 0.0)
      {
        buNumeric5.MessageBoxWarning(AppLanguage.CadCamMessages[38]);
        return;
      }
      if (((buEyeBaseVer5.Apps.ProfileOperation) ((buEyeBaseVer5.Apps.ProfileOperation) ((F_BendingRotaryDisk) this).Part).PartData).Height <= 0.0)
      {
        buNumeric5.MessageBoxWarning(AppLanguage.CadCamMessages[39]);
        return;
      }
      if (((buEyeBaseVer5.Apps.ProfileOperation) ((buEyeBaseVer5.Apps.ProfileOperation) ((F_BendingRotaryDisk) this).Part).PartData).Thickness <= 0.0 & ((F_BendingLRAList) this).\u0005.Visible)
      {
        buNumeric5.MessageBoxWarning(AppLanguage.CadCamMessages[40]);
        return;
      }
      ((F_BendingRotaryDisk) this).PropertiesForm.Result = DialogResult.OK;
      if (((F_BendingRotaryDisk) this).PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
        this.Dispose();
      if (((F_BendingRotaryDisk) this).PropertiesForm.FormCloseMode == FormCloseModeType.Invisible)
        this.Visible = false;
    }
    if (!(control2.Name == ((F_BendingLRAList) this).\u0002.Name))
      return;
    ((F_BendingRotaryDisk) this).PropertiesForm.Result = DialogResult.Cancel;
    if (((F_BendingRotaryDisk) this).PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
      this.Dispose();
    if (((F_BendingRotaryDisk) this).PropertiesForm.FormCloseMode != FormCloseModeType.Invisible)
      return;
    this.Visible = false;
  }

  internal void \u0001([In] object obj0, [In] FormClosingEventArgs obj1)
  {
    if (((F_BendingRotaryDisk) this).PropertiesForm.Result == DialogResult.OK)
      return;
    obj1.Cancel = true;
    ((F_BendingRotaryDisk) this).PropertiesForm.Result = DialogResult.Cancel;
    if (((F_BendingRotaryDisk) this).PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
      this.Dispose();
    if (((F_BendingRotaryDisk) this).PropertiesForm.FormCloseMode != FormCloseModeType.Invisible)
      return;
    this.Visible = false;
  }

  internal void \u0004([In] object obj0, [In] EventArgs obj1)
  {
    if (!((F_BendingRotaryDisk) this).PropertiesForm.Inited)
      return;
    buNestingVar Settings = (buNestingVar) new buEyeBaseVer5.Apps.ProfileOperationDataBarel(((F_BendingRotaryDisk) this).Settings);
    ((ProfileOperationCamData) ((ProfileMultiply) Settings).Draw).PartInnerShow = ((F_BendingLRAList) this).\u0001.Checked;
    buCall.\u0001.DrawPart(((F_BendingRotaryDisk) this).Part, Settings, ref ((F_BendingRotaryDisk) this).\u0001);
  }

  protected override void Dispose(bool disposing)
  {
    if ((!disposing ? 0 : (((F_BendingLRAList) this).\u0001 != null ? 1 : 0)) != 0)
      ((F_BendingLRAList) this).\u0001.Dispose();
    base.Dispose(disposing);
  }

  static F_NestSheetPartList() => F_BendingRotaryDisk.Captions = new List<string>();

  public F_NestSheetPartList()
  {
    ((F_BendingLRAList) this).PropertiesForm = new FormProperties();
    ((F_BendingLRAList) this).\u0001 = new Timer();
    ((F_BendingLRAList) this).\u0001 = -1;
    ((F_LaserStartOrder) this).\u0002 = -1;
    ((F_LaserStartOrder) this).\u0001 = (Design) null;
    ((F_LaserStartOrder) this).Settings = (buNestingVar) new buEyeBaseVer5.Apps.ProfileOperationDataBarel();
    ((F_LaserStartOrder) this).AddPartFromFileExtender = "buCad Cad/Cam Files (*.bucadv5)|*.bucadv5|Autocad Dxf Files (*.dxf)|*.dxf";
    ((F_LaserStartOrder) this).AddSheetFromFileExtender = "buCad Cad/Cam Files (*.bucadv5)|*.bucadv5|Autocad Dxf Files (*.dxf)|*.dxf";
    ((F_LaserStartOrder) this).SaveFileExtender = "Autocad Dxf Files (*.dxf)|*.dxf";
    ((F_LaserStartOrder) this).AddPartFromFileExtenderAsCsvType = false;
    ((F_LaserStartOrder) this).SendToCad = false;
    ((F_LaserStartOrder) this).AddPartFromFileExtensionIndex = 1;
    ((F_LaserStartOrder) this).AddSheetFromFileExtensionIndex = 1;
    ((F_LaserStartOrder) this).SaveFileExtensionIndex = 1;
    ((F_LaserStartOrder) this).AddPartFromFileFolder = Application.StartupPath;
    ((F_LaserStartOrder) this).AddSheetFromFileFolder = Application.StartupPath;
    ((F_LaserStartOrder) this).SaveFileFolder = Application.StartupPath;
    ((F_LaserStartOrder) this).CsvOpenTypeForAddNestingFromFile = nestCsvPartImportType.Mode2_NameWidthHeightCount;
    ((F_LaserStartOrder) this).PartRotationDefault = nestPartRotateType.Increment90;
    ((F_LaserStartOrder) this).Sheets = new List<buNestingSheet>();
    ((F_LaserMaterial) this).Parts = new List<buNestingPart>();
    ((F_LaserMaterial) this).SendToCadEntities = new List<Entity>();
    ((F_LaserMaterial) this).\u0001 = (IContainer) null;
    // ISSUE: explicit constructor call
    base.\u002Ector();
    buCompare5.CultureSettings();
    \u0007.\u0001.\u0001((F_PanelCutNestSheetPartList) this);
  }

  public void Init(int SelectedTab)
  {
    ((F_BendingLRAList) this).PropertiesForm.Inited = false;
    ((F_LaserStartOrder) this).SendToCad = false;
    if (((F_LaserStartOrder) this).\u0001 == null)
    {
      EyeCreateProps Properties = (EyeCreateProps) new ShapeEdit();
      ((DiameterDepthPoint) Properties).ShowToolBar = false;
      ((DiameterDepthPoint) Properties).ShowViewCube = false;
      ((MaterialBase5) Properties).ShowCoordinateArrow = false;
      buConversion5.CreateControlsTool(true, Properties, ref ((F_LaserStartOrder) this).\u0001);
      ((F_LaserStartOrder) this).\u0001.Dock = DockStyle.Fill;
      ((F_LaserMaterial) this).\u0004.Controls.Add((System.Windows.Forms.Control) ((F_LaserStartOrder) this).\u0001);
    }
    if (((GProfileOperation) ((ProfileSupportBlock) ((F_LaserStartOrder) this).Settings).MaterailSettings).UseSmallAreaFirst)
      ((GProfileOperationGroup) buCall.\u0001).SortNestingMaterialFromSmallToBig(true, ref ((F_LaserStartOrder) this).Sheets);
    ((F_LaserStartOrder) this).AddPartFromFileExtender = "buCad Cad/Cam Files (*.bucadv5)|*.bucadv5|Autocad Dxf Files (*.dxf)|*.dxf";
    if (((F_LaserStartOrder) this).AddPartFromFileExtenderAsCsvType)
      ((F_LaserStartOrder) this).AddPartFromFileExtender = ((F_LaserStartOrder) this).AddPartFromFileExtender + "|Csv Files (*.csv)|*.csv";
    ((F_LaserStartOrder) this).AddSheetFromFileExtender = "buCad Cad/Cam Files (*.bucadv5)|*.bucadv5|Autocad Dxf Files (*.dxf)|*.dxf";
    string str1 = "No";
    string str2 = "Sel";
    string str3 = "Name";
    string str4 = "Preview";
    string str5 = "Width";
    string str6 = "Height";
    string str7 = "Count";
    string str8 = "Used";
    string str9 = "Remain";
    string str10 = "Filename";
    string str11 = "Thickness";
    string str12 = "ItemNo";
    string str13 = "Other";
    string str14 = "Aux";
    string str15 = "Nested";
    string str16 = "Rotation";
    string str17 = "Priority";
    if (F_LaserMaterial.Captions.Count > 46)
    {
      str1 = F_LaserMaterial.Captions[35];
      str2 = F_LaserMaterial.Captions[36];
      str3 = F_LaserMaterial.Captions[37];
      str4 = F_LaserMaterial.Captions[38];
      str5 = F_LaserMaterial.Captions[39];
      str6 = F_LaserMaterial.Captions[40];
      str7 = F_LaserMaterial.Captions[41];
      str8 = F_LaserMaterial.Captions[46];
      str9 = F_LaserMaterial.Captions[43];
      str10 = F_LaserMaterial.Captions[47];
      str11 = F_LaserMaterial.Captions[48 /*0x30*/];
      str12 = F_LaserMaterial.Captions[51];
      str13 = F_LaserMaterial.Captions[50];
      str14 = F_LaserMaterial.Captions[49];
      str15 = F_LaserMaterial.Captions[42];
      str16 = F_LaserMaterial.Captions[45];
      str17 = F_LaserMaterial.Captions[44];
    }
    if (((F_LaserMaterial) this).\u0001.Columns.Count == 0)
    {
      DataGridViewColumn dataGridViewColumn1 = new DataGridViewColumn();
      dataGridViewColumn1.SortMode = DataGridViewColumnSortMode.NotSortable;
      dataGridViewColumn1.Width = 40;
      dataGridViewColumn1.HeaderText = str1;
      dataGridViewColumn1.Name = "No";
      dataGridViewColumn1.ReadOnly = true;
      dataGridViewColumn1.DefaultCellStyle.Font = new Font("Arial", 10f, FontStyle.Bold);
      dataGridViewColumn1.CellTemplate = (DataGridViewCell) new DataGridViewTextBoxCell();
      ((F_LaserMaterial) this).\u0001.Columns.Add(dataGridViewColumn1);
      DataGridViewColumn dataGridViewColumn2 = new DataGridViewColumn();
      dataGridViewColumn2.SortMode = DataGridViewColumnSortMode.NotSortable;
      dataGridViewColumn2.Width = 50;
      dataGridViewColumn2.HeaderText = str2;
      dataGridViewColumn2.Name = "Sel";
      dataGridViewColumn2.ReadOnly = false;
      dataGridViewColumn2.DefaultCellStyle.Font = new Font("Arial", 10f, FontStyle.Bold);
      dataGridViewColumn2.CellTemplate = (DataGridViewCell) new DataGridViewCheckBoxCell();
      ((F_LaserMaterial) this).\u0001.Columns.Add(dataGridViewColumn2);
      DataGridViewColumn dataGridViewColumn3 = new DataGridViewColumn();
      dataGridViewColumn3.SortMode = DataGridViewColumnSortMode.NotSortable;
      dataGridViewColumn3.Width = 200;
      dataGridViewColumn3.HeaderText = str3;
      dataGridViewColumn3.Name = "Name";
      dataGridViewColumn3.ReadOnly = false;
      dataGridViewColumn3.DefaultCellStyle.Font = new Font("Arial", 10f, FontStyle.Bold);
      dataGridViewColumn3.CellTemplate = (DataGridViewCell) new DataGridViewTextBoxCell();
      ((F_LaserMaterial) this).\u0001.Columns.Add(dataGridViewColumn3);
      DataGridViewColumn dataGridViewColumn4 = new DataGridViewColumn();
      dataGridViewColumn4.SortMode = DataGridViewColumnSortMode.NotSortable;
      dataGridViewColumn4.Width = ((buEyeBaseVer5.Apps.ProfileClamper) ((ProfileMultiply) ((F_LaserStartOrder) this).Settings).Draw).GridPartSheetPreviewWidth;
      dataGridViewColumn4.HeaderText = str4;
      dataGridViewColumn4.Name = "Image";
      dataGridViewColumn4.ReadOnly = true;
      dataGridViewColumn4.DefaultCellStyle.Font = new Font("Arial", 10f, FontStyle.Bold);
      dataGridViewColumn4.CellTemplate = (DataGridViewCell) new DataGridViewImageCell();
      ((F_LaserMaterial) this).\u0001.Columns.Add(dataGridViewColumn4);
      DataGridViewColumn dataGridViewColumn5 = new DataGridViewColumn();
      dataGridViewColumn5.SortMode = DataGridViewColumnSortMode.NotSortable;
      dataGridViewColumn5.Width = 100;
      dataGridViewColumn5.HeaderText = str5;
      dataGridViewColumn5.Name = "Width";
      dataGridViewColumn5.ReadOnly = false;
      dataGridViewColumn5.DefaultCellStyle.Font = new Font("Arial", 10f, FontStyle.Bold);
      dataGridViewColumn5.CellTemplate = (DataGridViewCell) new DataGridViewTextBoxCell();
      ((F_LaserMaterial) this).\u0001.Columns.Add(dataGridViewColumn5);
      DataGridViewColumn dataGridViewColumn6 = new DataGridViewColumn();
      dataGridViewColumn6.SortMode = DataGridViewColumnSortMode.NotSortable;
      dataGridViewColumn6.Width = 100;
      dataGridViewColumn6.HeaderText = str6;
      dataGridViewColumn6.Name = "Height";
      dataGridViewColumn6.ReadOnly = false;
      dataGridViewColumn6.DefaultCellStyle.Font = new Font("Arial", 10f, FontStyle.Bold);
      dataGridViewColumn6.CellTemplate = (DataGridViewCell) new DataGridViewTextBoxCell();
      ((F_LaserMaterial) this).\u0001.Columns.Add(dataGridViewColumn6);
      DataGridViewColumn dataGridViewColumn7 = new DataGridViewColumn();
      dataGridViewColumn7.SortMode = DataGridViewColumnSortMode.NotSortable;
      dataGridViewColumn7.Width = 80 /*0x50*/;
      dataGridViewColumn7.HeaderText = str7;
      dataGridViewColumn7.Name = "Count";
      dataGridViewColumn7.ReadOnly = false;
      dataGridViewColumn7.DefaultCellStyle.Font = new Font("Arial", 10f, FontStyle.Bold);
      dataGridViewColumn7.CellTemplate = (DataGridViewCell) new DataGridViewTextBoxCell();
      ((F_LaserMaterial) this).\u0001.Columns.Add(dataGridViewColumn7);
      DataGridViewColumn dataGridViewColumn8 = new DataGridViewColumn();
      dataGridViewColumn8.SortMode = DataGridViewColumnSortMode.NotSortable;
      dataGridViewColumn8.Width = 100;
      dataGridViewColumn8.HeaderText = str8;
      dataGridViewColumn8.Name = "Used";
      dataGridViewColumn8.ReadOnly = true;
      dataGridViewColumn8.DefaultCellStyle.Font = new Font("Arial", 10f, FontStyle.Bold);
      dataGridViewColumn8.CellTemplate = (DataGridViewCell) new DataGridViewTextBoxCell();
      ((F_LaserMaterial) this).\u0001.Columns.Add(dataGridViewColumn8);
      DataGridViewColumn dataGridViewColumn9 = new DataGridViewColumn();
      dataGridViewColumn9.SortMode = DataGridViewColumnSortMode.NotSortable;
      dataGridViewColumn9.Width = 100;
      dataGridViewColumn9.HeaderText = str9;
      dataGridViewColumn9.Name = "Remain";
      dataGridViewColumn9.ReadOnly = true;
      dataGridViewColumn9.DefaultCellStyle.Font = new Font("Arial", 10f, FontStyle.Bold);
      dataGridViewColumn9.CellTemplate = (DataGridViewCell) new DataGridViewTextBoxCell();
      ((F_LaserMaterial) this).\u0001.Columns.Add(dataGridViewColumn9);
      DataGridViewColumn dataGridViewColumn10 = new DataGridViewColumn();
      dataGridViewColumn10.SortMode = DataGridViewColumnSortMode.NotSortable;
      dataGridViewColumn10.Width = 200;
      dataGridViewColumn10.HeaderText = str10;
      dataGridViewColumn10.Name = "FileName";
      dataGridViewColumn10.ReadOnly = true;
      dataGridViewColumn10.Visible = ((buEyeBaseVer5.Apps.ProfileClamper) ((ProfileMultiply) ((F_LaserStartOrder) this).Settings).Draw).ShowSheetFileNameColumb;
      dataGridViewColumn10.DefaultCellStyle.Font = new Font("Arial", 10f, FontStyle.Bold);
      dataGridViewColumn10.CellTemplate = (DataGridViewCell) new DataGridViewTextBoxCell();
      ((F_LaserMaterial) this).\u0001.Columns.Add(dataGridViewColumn10);
      DataGridViewColumn dataGridViewColumn11 = new DataGridViewColumn();
      dataGridViewColumn11.SortMode = DataGridViewColumnSortMode.NotSortable;
      dataGridViewColumn11.Width = 100;
      dataGridViewColumn11.HeaderText = str11;
      dataGridViewColumn11.Name = "Thickness";
      dataGridViewColumn11.ReadOnly = false;
      dataGridViewColumn11.Visible = ((buEyeBaseVer5.Apps.ProfileClamper) ((ProfileMultiply) ((F_LaserStartOrder) this).Settings).Draw).ShowSheetThicknessColumb;
      dataGridViewColumn11.DefaultCellStyle.Font = new Font("Arial", 10f, FontStyle.Bold);
      dataGridViewColumn11.CellTemplate = (DataGridViewCell) new DataGridViewTextBoxCell();
      ((F_LaserMaterial) this).\u0001.Columns.Add(dataGridViewColumn11);
      DataGridViewColumn dataGridViewColumn12 = new DataGridViewColumn();
      dataGridViewColumn12.SortMode = DataGridViewColumnSortMode.NotSortable;
      dataGridViewColumn12.Width = 80 /*0x50*/;
      dataGridViewColumn12.HeaderText = str12;
      dataGridViewColumn12.Name = "ItemNo";
      dataGridViewColumn12.ReadOnly = false;
      dataGridViewColumn12.Visible = ((buEyeBaseVer5.Apps.ProfileClamper) ((ProfileMultiply) ((F_LaserStartOrder) this).Settings).Draw).ShowSheetItemNoColumb;
      dataGridViewColumn12.DefaultCellStyle.Font = new Font("Arial", 10f, FontStyle.Bold);
      dataGridViewColumn12.CellTemplate = (DataGridViewCell) new DataGridViewTextBoxCell();
      ((F_LaserMaterial) this).\u0001.Columns.Add(dataGridViewColumn12);
      DataGridViewColumn dataGridViewColumn13 = new DataGridViewColumn();
      dataGridViewColumn13.SortMode = DataGridViewColumnSortMode.NotSortable;
      dataGridViewColumn13.Width = 80 /*0x50*/;
      dataGridViewColumn13.HeaderText = str13;
      dataGridViewColumn13.Name = "Other";
      dataGridViewColumn13.ReadOnly = false;
      dataGridViewColumn13.Visible = ((buEyeBaseVer5.Apps.ProfileClamper) ((ProfileMultiply) ((F_LaserStartOrder) this).Settings).Draw).ShowSheetOtherColumb;
      dataGridViewColumn13.DefaultCellStyle.Font = new Font("Arial", 10f, FontStyle.Bold);
      dataGridViewColumn13.CellTemplate = (DataGridViewCell) new DataGridViewTextBoxCell();
      ((F_LaserMaterial) this).\u0001.Columns.Add(dataGridViewColumn13);
      DataGridViewColumn dataGridViewColumn14 = new DataGridViewColumn();
      dataGridViewColumn14.SortMode = DataGridViewColumnSortMode.NotSortable;
      dataGridViewColumn14.Width = 80 /*0x50*/;
      dataGridViewColumn14.HeaderText = str14;
      dataGridViewColumn14.Name = "Aux";
      dataGridViewColumn14.ReadOnly = false;
      dataGridViewColumn14.Visible = ((buEyeBaseVer5.Apps.ProfileClamper) ((ProfileMultiply) ((F_LaserStartOrder) this).Settings).Draw).ShowSheetAuxColumb;
      dataGridViewColumn14.DefaultCellStyle.Font = new Font("Arial", 10f, FontStyle.Bold);
      dataGridViewColumn14.CellTemplate = (DataGridViewCell) new DataGridViewTextBoxCell();
      ((F_LaserMaterial) this).\u0001.Columns.Add(dataGridViewColumn14);
    }
    ((F_LaserMaterial) this).\u0001.RowHeadersVisible = false;
    ((F_LaserMaterial) this).\u0001.AllowUserToAddRows = false;
    ((F_LaserMaterial) this).\u0001.AllowUserToResizeColumns = false;
    if (((F_LaserMaterial) this).\u0002.Columns.Count == 0)
    {
      DataGridViewColumn dataGridViewColumn15 = new DataGridViewColumn();
      dataGridViewColumn15.SortMode = DataGridViewColumnSortMode.NotSortable;
      dataGridViewColumn15.Width = 40;
      dataGridViewColumn15.HeaderText = str1;
      dataGridViewColumn15.Name = "No";
      dataGridViewColumn15.ReadOnly = true;
      dataGridViewColumn15.DefaultCellStyle.Font = new Font("Arial", 10f, FontStyle.Bold);
      dataGridViewColumn15.CellTemplate = (DataGridViewCell) new DataGridViewTextBoxCell();
      ((F_LaserMaterial) this).\u0002.Columns.Add(dataGridViewColumn15);
      DataGridViewColumn dataGridViewColumn16 = new DataGridViewColumn();
      dataGridViewColumn16.SortMode = DataGridViewColumnSortMode.NotSortable;
      dataGridViewColumn16.Width = 50;
      dataGridViewColumn16.HeaderText = str2;
      dataGridViewColumn16.Name = "Sel";
      dataGridViewColumn16.ReadOnly = false;
      dataGridViewColumn16.DefaultCellStyle.Font = new Font("Arial", 10f, FontStyle.Bold);
      dataGridViewColumn16.CellTemplate = (DataGridViewCell) new DataGridViewCheckBoxCell();
      ((F_LaserMaterial) this).\u0002.Columns.Add(dataGridViewColumn16);
      DataGridViewColumn dataGridViewColumn17 = new DataGridViewColumn();
      dataGridViewColumn17.SortMode = DataGridViewColumnSortMode.NotSortable;
      dataGridViewColumn17.Width = 200;
      dataGridViewColumn17.HeaderText = str3;
      dataGridViewColumn17.Name = "Name";
      dataGridViewColumn17.ReadOnly = false;
      dataGridViewColumn17.DefaultCellStyle.Font = new Font("Arial", 10f, FontStyle.Bold);
      dataGridViewColumn17.CellTemplate = (DataGridViewCell) new DataGridViewTextBoxCell();
      ((F_LaserMaterial) this).\u0002.Columns.Add(dataGridViewColumn17);
      DataGridViewColumn dataGridViewColumn18 = new DataGridViewColumn();
      dataGridViewColumn18.SortMode = DataGridViewColumnSortMode.NotSortable;
      dataGridViewColumn18.Width = ((buEyeBaseVer5.Apps.ProfileClamper) ((ProfileMultiply) ((F_LaserStartOrder) this).Settings).Draw).GridPartSheetPreviewWidth;
      dataGridViewColumn18.HeaderText = str4;
      dataGridViewColumn18.Name = "Image";
      dataGridViewColumn18.ReadOnly = true;
      dataGridViewColumn18.DefaultCellStyle.Font = new Font("Arial", 10f, FontStyle.Bold);
      dataGridViewColumn18.CellTemplate = (DataGridViewCell) new DataGridViewImageCell();
      ((F_LaserMaterial) this).\u0002.Columns.Add(dataGridViewColumn18);
      DataGridViewColumn dataGridViewColumn19 = new DataGridViewColumn();
      dataGridViewColumn19.SortMode = DataGridViewColumnSortMode.NotSortable;
      dataGridViewColumn19.Width = 100;
      dataGridViewColumn19.HeaderText = str5;
      dataGridViewColumn19.Name = "Width";
      dataGridViewColumn19.ReadOnly = false;
      dataGridViewColumn19.DefaultCellStyle.Font = new Font("Arial", 10f, FontStyle.Bold);
      dataGridViewColumn19.CellTemplate = (DataGridViewCell) new DataGridViewTextBoxCell();
      ((F_LaserMaterial) this).\u0002.Columns.Add(dataGridViewColumn19);
      DataGridViewColumn dataGridViewColumn20 = new DataGridViewColumn();
      dataGridViewColumn20.SortMode = DataGridViewColumnSortMode.NotSortable;
      dataGridViewColumn20.Width = 100;
      dataGridViewColumn20.HeaderText = str6;
      dataGridViewColumn20.Name = "Height";
      dataGridViewColumn20.ReadOnly = false;
      dataGridViewColumn20.DefaultCellStyle.Font = new Font("Arial", 10f, FontStyle.Bold);
      dataGridViewColumn20.CellTemplate = (DataGridViewCell) new DataGridViewTextBoxCell();
      ((F_LaserMaterial) this).\u0002.Columns.Add(dataGridViewColumn20);
      DataGridViewColumn dataGridViewColumn21 = new DataGridViewColumn();
      dataGridViewColumn21.SortMode = DataGridViewColumnSortMode.NotSortable;
      dataGridViewColumn21.Width = 80 /*0x50*/;
      dataGridViewColumn21.HeaderText = str7;
      dataGridViewColumn21.Name = "Count";
      dataGridViewColumn21.ReadOnly = false;
      dataGridViewColumn21.DefaultCellStyle.Font = new Font("Arial", 10f, FontStyle.Bold);
      dataGridViewColumn21.CellTemplate = (DataGridViewCell) new DataGridViewTextBoxCell();
      ((F_LaserMaterial) this).\u0002.Columns.Add(dataGridViewColumn21);
      DataGridViewColumn dataGridViewColumn22 = new DataGridViewColumn();
      dataGridViewColumn22.SortMode = DataGridViewColumnSortMode.NotSortable;
      dataGridViewColumn22.Width = 100;
      dataGridViewColumn22.HeaderText = str15;
      dataGridViewColumn22.Name = "Nested";
      dataGridViewColumn22.ReadOnly = true;
      dataGridViewColumn22.DefaultCellStyle.Font = new Font("Arial", 10f, FontStyle.Bold);
      dataGridViewColumn22.CellTemplate = (DataGridViewCell) new DataGridViewTextBoxCell();
      ((F_LaserMaterial) this).\u0002.Columns.Add(dataGridViewColumn22);
      DataGridViewColumn dataGridViewColumn23 = new DataGridViewColumn();
      dataGridViewColumn23.SortMode = DataGridViewColumnSortMode.NotSortable;
      dataGridViewColumn23.Width = 100;
      dataGridViewColumn23.HeaderText = str9;
      dataGridViewColumn23.Name = "Remain";
      dataGridViewColumn23.ReadOnly = true;
      dataGridViewColumn23.DefaultCellStyle.Font = new Font("Arial", 10f, FontStyle.Bold);
      dataGridViewColumn23.CellTemplate = (DataGridViewCell) new DataGridViewTextBoxCell();
      ((F_LaserMaterial) this).\u0002.Columns.Add(dataGridViewColumn23);
      DataGridViewColumn dataGridViewColumn24 = new DataGridViewColumn();
      dataGridViewColumn24.SortMode = DataGridViewColumnSortMode.NotSortable;
      dataGridViewColumn24.Width = 100;
      dataGridViewColumn24.HeaderText = str17;
      dataGridViewColumn24.Name = "Priority";
      dataGridViewColumn24.ReadOnly = true;
      dataGridViewColumn24.DefaultCellStyle.Font = new Font("Arial", 10f, FontStyle.Bold);
      dataGridViewColumn24.CellTemplate = (DataGridViewCell) new DataGridViewTextBoxCell();
      ((F_LaserMaterial) this).\u0002.Columns.Add(dataGridViewColumn24);
      DataGridViewColumn dataGridViewColumn25 = new DataGridViewColumn();
      dataGridViewColumn25.SortMode = DataGridViewColumnSortMode.NotSortable;
      dataGridViewColumn25.Width = 140;
      dataGridViewColumn25.HeaderText = str16;
      dataGridViewColumn25.Name = "Rotation";
      dataGridViewColumn25.ReadOnly = true;
      dataGridViewColumn25.DefaultCellStyle.Font = new Font("Arial", 10f, FontStyle.Bold);
      dataGridViewColumn25.CellTemplate = (DataGridViewCell) new DataGridViewTextBoxCell();
      ((F_LaserMaterial) this).\u0002.Columns.Add(dataGridViewColumn25);
      DataGridViewColumn dataGridViewColumn26 = new DataGridViewColumn();
      dataGridViewColumn26.SortMode = DataGridViewColumnSortMode.NotSortable;
      dataGridViewColumn26.Width = 200;
      dataGridViewColumn26.HeaderText = str10;
      dataGridViewColumn26.Name = "FileName";
      dataGridViewColumn26.ReadOnly = true;
      dataGridViewColumn26.Visible = ((buEyeBaseVer5.Apps.ProfileClamper) ((ProfileMultiply) ((F_LaserStartOrder) this).Settings).Draw).ShowPartFileNameColumb;
      dataGridViewColumn26.DefaultCellStyle.Font = new Font("Arial", 10f, FontStyle.Bold);
      dataGridViewColumn26.CellTemplate = (DataGridViewCell) new DataGridViewTextBoxCell();
      ((F_LaserMaterial) this).\u0002.Columns.Add(dataGridViewColumn26);
      DataGridViewColumn dataGridViewColumn27 = new DataGridViewColumn();
      dataGridViewColumn27.SortMode = DataGridViewColumnSortMode.NotSortable;
      dataGridViewColumn27.Width = 100;
      dataGridViewColumn27.HeaderText = str11;
      dataGridViewColumn27.Name = "Thickness";
      dataGridViewColumn27.ReadOnly = false;
      dataGridViewColumn27.Visible = ((buEyeBaseVer5.Apps.ProfileClamperSettings) ((ProfileMultiply) ((F_LaserStartOrder) this).Settings).Draw).ShowPartThicknessColumb;
      dataGridViewColumn27.DefaultCellStyle.Font = new Font("Arial", 10f, FontStyle.Bold);
      dataGridViewColumn27.CellTemplate = (DataGridViewCell) new DataGridViewTextBoxCell();
      ((F_LaserMaterial) this).\u0002.Columns.Add(dataGridViewColumn27);
      DataGridViewColumn dataGridViewColumn28 = new DataGridViewColumn();
      dataGridViewColumn28.SortMode = DataGridViewColumnSortMode.NotSortable;
      dataGridViewColumn28.Width = 80 /*0x50*/;
      dataGridViewColumn28.HeaderText = str12;
      dataGridViewColumn28.Name = "ItemNo";
      dataGridViewColumn28.ReadOnly = false;
      dataGridViewColumn28.Visible = ((buEyeBaseVer5.Apps.ProfileClamper) ((ProfileMultiply) ((F_LaserStartOrder) this).Settings).Draw).ShowPartItemNoColumb;
      dataGridViewColumn28.DefaultCellStyle.Font = new Font("Arial", 10f, FontStyle.Bold);
      dataGridViewColumn28.CellTemplate = (DataGridViewCell) new DataGridViewTextBoxCell();
      ((F_LaserMaterial) this).\u0002.Columns.Add(dataGridViewColumn28);
      DataGridViewColumn dataGridViewColumn29 = new DataGridViewColumn();
      dataGridViewColumn29.SortMode = DataGridViewColumnSortMode.NotSortable;
      dataGridViewColumn29.Width = 80 /*0x50*/;
      dataGridViewColumn29.HeaderText = str13;
      dataGridViewColumn29.Name = "Other";
      dataGridViewColumn29.ReadOnly = false;
      dataGridViewColumn29.Visible = ((buEyeBaseVer5.Apps.ProfileClamperSettings) ((ProfileMultiply) ((F_LaserStartOrder) this).Settings).Draw).ShowPartOtherColumb;
      dataGridViewColumn29.DefaultCellStyle.Font = new Font("Arial", 10f, FontStyle.Bold);
      dataGridViewColumn29.CellTemplate = (DataGridViewCell) new DataGridViewTextBoxCell();
      ((F_LaserMaterial) this).\u0002.Columns.Add(dataGridViewColumn29);
      DataGridViewColumn dataGridViewColumn30 = new DataGridViewColumn();
      dataGridViewColumn30.SortMode = DataGridViewColumnSortMode.NotSortable;
      dataGridViewColumn30.Width = 80 /*0x50*/;
      dataGridViewColumn30.HeaderText = str14;
      dataGridViewColumn30.Name = "Aux";
      dataGridViewColumn30.ReadOnly = false;
      dataGridViewColumn30.Visible = ((buEyeBaseVer5.Apps.ProfileClamperSettings) ((ProfileMultiply) ((F_LaserStartOrder) this).Settings).Draw).ShowPartAuxColumb;
      dataGridViewColumn30.DefaultCellStyle.Font = new Font("Arial", 10f, FontStyle.Bold);
      dataGridViewColumn30.CellTemplate = (DataGridViewCell) new DataGridViewTextBoxCell();
      ((F_LaserMaterial) this).\u0002.Columns.Add(dataGridViewColumn30);
    }
    ((F_LaserMaterial) this).\u0002.RowHeadersVisible = false;
    ((F_LaserMaterial) this).\u0002.AllowUserToAddRows = false;
    ((F_LaserMaterial) this).\u0002.AllowUserToResizeColumns = false;
    ((F_LaserMaterial) this).\u0001.Value = (Decimal) ((buEyeBaseVer5.Apps.ProfileOperationSlot) ((ProfileSupportBlock) ((F_LaserStartOrder) this).Settings).PartSettings).Multiply;
    ((F_LaserMaterial) this).SendToCadEntities.Clear();
    ((F_LaserMaterial) this).SendToCadEntities = new List<Entity>();
    ((F_BendingLRAList) this).\u0001 = new Timer();
    \u007B0e48b843\u002Dfb72\u002D498c\u002D834d\u002Dfc743ba0facc\u007D.\u0001((F_PanelCutNestSheetPartList) this);
    if (SelectedTab == 0)
      ((F_LaserMaterial) this).\u0001.SelectedIndex = 0;
    if (SelectedTab == 1)
      ((F_LaserMaterial) this).\u0001.SelectedIndex = 1;
    if (!((F_LaserMaterial) this).\u0006.Checked & !((F_LaserMaterial) this).\u0004.Checked & !((F_LaserMaterial) this).\u0005.Checked)
      ((F_LaserMaterial) this).\u0005.Checked = true;
    if (!((F_LaserMaterial) this).\u0003.Checked & !((F_LaserMaterial) this).\u0001.Checked & !((F_LaserMaterial) this).\u0002.Checked)
      ((F_LaserMaterial) this).\u0002.Checked = true;
    this.LoadLanguage();
    ((F_BendingLRAList) this).PropertiesForm.Result = DialogResult.None;
    ((F_BendingLRAList) this).PropertiesForm.Inited = false;
  }

  internal void \u0001([In] object obj0, [In] FormClosingEventArgs obj1)
  {
    if (((F_BendingLRAList) this).PropertiesForm.Result == DialogResult.OK)
      return;
    obj1.Cancel = true;
    ((F_BendingLRAList) this).PropertiesForm.Result = DialogResult.Cancel;
    this.Visible = false;
  }

  public void LoadLanguage()
  {
    string callMethod = "NestSheetPart LoadLanguage";
    try
    {
      if (F_LaserMaterial.Captions.Count < 33)
        return;
      this.Text = F_LaserMaterial.Captions[0];
      ((F_LaserMaterial) this).\u0001.Text = F_LaserMaterial.Captions[1];
      ((F_LaserMaterial) this).\u0005.Text = F_LaserMaterial.Captions[1];
      ((F_LaserMaterial) this).\u0002.Text = F_LaserMaterial.Captions[2];
      ((F_LaserMaterial) this).\u0006.Text = F_LaserMaterial.Captions[2];
      ((F_LaserMaterial) this).\u0001.Text = F_LaserMaterial.Captions[3];
      ((F_LaserMaterial) this).\u0005.Text = F_LaserMaterial.Captions[4];
      ((F_LaserMaterial) this).\u0004.Text = F_LaserMaterial.Captions[5];
      ((F_LaserMaterial) this).\u0006.Text = F_LaserMaterial.Captions[6];
      ((F_LaserMaterial) this).\u000F.Text = F_LaserMaterial.Captions[7];
      ((F_LaserMaterial) this).\u000E.Text = F_LaserMaterial.Captions[8];
      ((F_LaserMaterial) this).\u0007.Text = F_LaserMaterial.Captions[9];
      ((F_LaserMaterial) this).\u0003.Text = F_LaserMaterial.Captions[10];
      ((F_LaserMaterial) this).\u0002.Text = F_LaserMaterial.Captions[11];
      ((F_LaserMaterial) this).\u0008.Text = F_LaserMaterial.Captions[10];
      ((F_LaserMaterial) this).\u0007.Text = F_LaserMaterial.Captions[11];
      ((F_LaserMaterial) this).\u0003.Text = F_LaserMaterial.Captions[12];
      ((F_LaserMaterial) this).\u0002.Text = F_LaserMaterial.Captions[13];
      ((F_LaserMaterial) this).\u0001.Text = F_LaserMaterial.Captions[14];
      ((F_LaserMaterial) this).\u0006.Text = F_LaserMaterial.Captions[12];
      ((F_LaserMaterial) this).\u0005.Text = F_LaserMaterial.Captions[13];
      ((F_LaserMaterial) this).\u0004.Text = F_LaserMaterial.Captions[14];
      ((F_LaserMaterial) this).\u0002.Text = F_LaserMaterial.Captions[15];
      ((F_LaserMaterial) this).\u0001.Text = F_LaserMaterial.Captions[16 /*0x10*/];
      ((F_LaserMaterial) this).\u0004.Text = F_LaserMaterial.Captions[15];
      ((F_LaserMaterial) this).\u0003.Text = F_LaserMaterial.Captions[16 /*0x10*/];
      ((F_LaserMaterial) this).chk_preview.Text = F_LaserMaterial.Captions[17];
      ((F_LaserMaterial) this).\u0011.Text = F_LaserMaterial.Captions[18];
      ((F_LaserMaterial) this).\u0010.Text = F_LaserMaterial.Captions[19];
      ((F_LaserMaterial) this).\u0013.Text = F_LaserMaterial.Captions[20];
      ((F_LaserMaterial) this).\u0012.Text = F_LaserMaterial.Captions[21];
      ((F_LaserMaterial) this).\u0004.Text = F_LaserMaterial.Captions[22];
      ((F_LaserMaterial) this).\u0005.Text = F_LaserMaterial.Captions[23];
      ((F_LaserMaterial) this).\u0006.Text = F_LaserMaterial.Captions[24];
      ((F_LaserMaterial) this).\u0007.Text = F_LaserMaterial.Captions[25];
      ((F_LaserMaterial) this).\u0008.Text = F_LaserMaterial.Captions[26];
      ((F_LaserMaterial) this).\u000E.Text = F_LaserMaterial.Captions[27];
      ((F_LaserMaterial) this).\u000F.Text = F_LaserMaterial.Captions[28];
      ((F_LaserMaterial) this).\u0010.Text = F_LaserMaterial.Captions[29];
      ((F_LaserMaterial) this).\u0011.Text = F_LaserMaterial.Captions[30];
      ((F_LaserMaterial) this).\u0012.Text = F_LaserMaterial.Captions[31 /*0x1F*/];
      ((F_LaserMaterial) this).\u0001.Text = F_LaserMaterial.Captions[32 /*0x20*/];
      ((F_LaserMaterial) this).\u0002.Text = F_LaserMaterial.Captions[52];
      ((F_LaserMaterial) this).\u0003.Text = F_LaserMaterial.Captions[28];
      ((F_LaserMaterial) this).\u0013.Text = F_LaserMaterial.Captions[29];
      ((F_LaserMaterial) this).\u0014.Text = F_LaserMaterial.Captions[33];
      ((F_LaserMaterial) this).\u0015.Text = F_LaserMaterial.Captions[34];
      ((F_LaserMaterial) this).\u0016.Text = F_LaserMaterial.Captions[53];
    }
    catch (Exception ex)
    {
      string str = "";
      buLog.addLog(str, "Not Ok", callMethod);
      buException.throwException(ex, callMethod, true, str);
    }
  }

  internal void \u0001([In] object obj0, [In] EventArgs obj1)
  {
    System.Windows.Forms.Control control = new System.Windows.Forms.Control();
    string str1 = "";
    if (obj0.GetType() == typeof (System.Windows.Forms.Control) | obj0.GetType() == typeof (Button))
      str1 = ((System.Windows.Forms.Control) obj0).Name;
    if (obj0.GetType() == typeof (ToolStripMenuItem))
      str1 = ((ToolStripItem) obj0).Name;
    if (str1 == ((F_LaserMaterial) this).\u0005.Name)
    {
      F_NestSheetAdd fNestSheetAdd = (F_NestSheetAdd) new F_SortingSettings();
      ((F_Layer) fNestSheetAdd).ShowItemNo = ((buEyeBaseVer5.Apps.ProfileClamper) ((ProfileMultiply) ((F_LaserStartOrder) this).Settings).Draw).ShowSheetItemNoColumb;
      ((F_Layer) fNestSheetAdd).FormCloseMode = FormCloseModeType.Dispose;
      ((F_SortingSettings) fNestSheetAdd).Init();
      fNestSheetAdd.StartPosition = FormStartPosition.CenterParent;
      int num = (int) fNestSheetAdd.ShowDialog();
      if (((F_Layer) fNestSheetAdd).Result == DialogResult.OK)
      {
        buNestingSheet buNestingSheet = (buNestingSheet) new buEyeBaseVer5.Apps.ProfileOperation(((F_Layer) fNestSheetAdd).Sheet);
        buCall.\u0001.SetColorEntity(((ProfileOperationSortItem) ((ProfileMultiply) ((F_LaserStartOrder) this).Settings).Draw).SheetEntityColor, ref ((\u0084.\u0001) ((ProfileItemCalc) buNestingSheet).EntitiesGroup.Outside).Entities);
        ((buEyeBaseVer5.Apps.ProfileCalculatedJob) buCall.\u0001).GetAvailableNestingSheetID(((F_LaserStartOrder) this).Sheets, ref ((ProfileItemCalc) buNestingSheet).ID);
        ((F_LaserStartOrder) this).Sheets.Add(buNestingSheet);
        Image Img = (Image) null;
        ((F_Preview) this).SheetPointsToImage(((F_Layer) fNestSheetAdd).Sheet, ((buEyeBaseVer5.Apps.ProfileClamper) ((ProfileMultiply) ((F_LaserStartOrder) this).Settings).Draw).GridPartSheetPreviewWidth, ((buEyeBaseVer5.Apps.ProfileClamper) ((ProfileMultiply) ((F_LaserStartOrder) this).Settings).Draw).GridPartSheetHeight, ref Img);
        DataGridViewRowCollection rows = ((F_LaserMaterial) this).\u0001.Rows;
        int count = ((F_LaserStartOrder) this).Sheets.Count;
        bool enable = ((ProfileItemCalc) ((F_Layer) fNestSheetAdd).Sheet).Enable;
        string name = ((buEyeBaseVer5.Apps.ProfileItem) ((ProfileItemCalc) ((F_Layer) fNestSheetAdd).Sheet).MaterialData).Name;
        double width = ((buEyeBaseVer5.Apps.ProfileItem) ((ProfileItemCalc) ((F_Layer) fNestSheetAdd).Sheet).MaterialData).Width;
        double height = ((buEyeBaseVer5.Apps.ProfileItem) ((ProfileItemCalc) ((F_Layer) fNestSheetAdd).Sheet).MaterialData).Height;
        int quantity = ((buEyeBaseVer5.Apps.ProfileItem) ((ProfileItemCalc) ((F_Layer) fNestSheetAdd).Sheet).MaterialData).Quantity;
        int used = ((ProfileItemCalc) ((F_Layer) fNestSheetAdd).Sheet).Used;
        int remain = ((ProfileItemCalc) ((F_Layer) fNestSheetAdd).Sheet).Remain;
        string fileName = ((ProfileItemCalc) ((F_Layer) fNestSheetAdd).Sheet).FileName;
        double thickness = ((buEyeBaseVer5.Apps.ProfileItem) ((ProfileItemCalc) ((F_Layer) fNestSheetAdd).Sheet).MaterialData).Thickness;
        string itemNo = ((buEyeBaseVer5.Apps.ProfileItem) ((ProfileItemCalc) ((F_Layer) fNestSheetAdd).Sheet).MaterialData).ItemNo;
        string other = ((buEyeBaseVer5.Apps.ProfileItem) ((ProfileItemCalc) ((F_Layer) fNestSheetAdd).Sheet).MaterialData).Other;
        string aux = ((buEyeBaseVer5.Apps.ProfileItem) ((ProfileItemCalc) ((F_Layer) fNestSheetAdd).Sheet).MaterialData).Aux;
        object[] objArray = \u007B0e48b843\u002Dfb72\u002D498c\u002D834d\u002Dfc743ba0facc\u007D.\u0001(width, quantity, itemNo, aux, name, remain, count, height, Img, thickness, other, (F_PanelCutNestSheetPartList) this, fileName, used, enable);
        rows.Add(objArray);
        ((F_LaserMaterial) this).\u0001.Rows[((F_LaserMaterial) this).\u0001.Rows.Count - 1].DefaultCellStyle.ForeColor = Color.Black;
        ((F_LaserMaterial) this).\u0001.Rows[((F_LaserMaterial) this).\u0001.Rows.Count - 1].Height = ((buEyeBaseVer5.Apps.ProfileClamper) ((ProfileMultiply) ((F_LaserStartOrder) this).Settings).Draw).GridPartSheetHeight;
      }
    }
    if (str1 == ((F_LaserMaterial) this).\u0004.Name)
    {
      if (((F_LaserMaterial) this).\u0003.Checked && buNumeric5.MessageBoxQuestion(buNesting.LangNestingMessage[7] + AppLanguage.CadCamDynamic[33]) == DialogResult.Yes)
      {
        ((F_LaserStartOrder) this).Sheets.Clear();
        ((F_LaserMaterial) this).\u0001.Rows.Clear();
      }
      if (((F_LaserMaterial) this).\u0002.Checked && buNumeric5.MessageBoxQuestion(buNesting.LangNestingMessage[7] + AppLanguage.CadCamDynamic[33]) == DialogResult.Yes)
      {
        ((F_LaserMaterial) this).\u0001.Rows.RemoveAt(((F_BendingLRAList) this).\u0001);
        ((F_LaserStartOrder) this).Sheets.RemoveAt(((F_BendingLRAList) this).\u0001);
      }
      if (!((F_LaserMaterial) this).\u0001.Checked || buNumeric5.MessageBoxQuestion(buNesting.LangNestingMessage[7] + AppLanguage.CadCamDynamic[33]) != DialogResult.Yes)
        return;
      for (int index = ((F_LaserMaterial) this).\u0001.Rows.Count - 1; index >= 0; --index)
      {
        if (Convert.ToBoolean(((F_LaserMaterial) this).\u0001.Rows[index].Cells[1].Value))
        {
          ((F_LaserMaterial) this).\u0001.Rows.RemoveAt(index);
          ((F_LaserStartOrder) this).Sheets.RemoveAt(index);
        }
      }
    }
    else
    {
      if (str1 == ((F_LaserMaterial) this).\u0003.Name && ((F_BendingLRAList) this).\u0001 >= 0 & ((F_BendingLRAList) this).\u0001 <= ((F_LaserMaterial) this).Parts.Count - 1)
      {
        ((F_LaserMaterial) this).\u0001.Rows[((F_BendingLRAList) this).\u0001].Cells[7].Value = (object) 0;
        ((F_LaserMaterial) this).\u0001.Rows[((F_BendingLRAList) this).\u0001].Cells[8].Value = (object) ((buEyeBaseVer5.Apps.ProfileItem) ((ProfileItemCalc) ((F_LaserStartOrder) this).Sheets[((F_BendingLRAList) this).\u0001]).MaterialData).Quantity;
        ((ProfileItemCalc) ((F_LaserStartOrder) this).Sheets[((F_BendingLRAList) this).\u0001]).Used = 0;
        ((ProfileItemCalc) ((F_LaserStartOrder) this).Sheets[((F_BendingLRAList) this).\u0001]).Remain = ((buEyeBaseVer5.Apps.ProfileItem) ((ProfileItemCalc) ((F_LaserStartOrder) this).Sheets[((F_BendingLRAList) this).\u0001]).MaterialData).Quantity;
        ((F_LaserMaterial) this).\u0001.Rows[((F_BendingLRAList) this).\u0001].DefaultCellStyle.ForeColor = Color.Black;
      }
      if (str1 == ((F_LaserMaterial) this).\u0002.Name)
      {
        for (int index = 0; index <= ((F_LaserStartOrder) this).Sheets.Count - 1; ++index)
        {
          ((ProfileItemCalc) ((F_LaserStartOrder) this).Sheets[index]).Used = 0;
          ((ProfileItemCalc) ((F_LaserStartOrder) this).Sheets[index]).Remain = ((buEyeBaseVer5.Apps.ProfileItem) ((ProfileItemCalc) ((F_LaserStartOrder) this).Sheets[index]).MaterialData).Quantity;
          ((F_LaserMaterial) this).\u0001.Rows[index].Cells[7].Value = (object) 0;
          ((F_LaserMaterial) this).\u0001.Rows[index].Cells[8].Value = (object) ((buEyeBaseVer5.Apps.ProfileItem) ((ProfileItemCalc) ((F_LaserStartOrder) this).Sheets[index]).MaterialData).Quantity;
          ((F_LaserMaterial) this).\u0001.Rows[index].DefaultCellStyle.ForeColor = Color.Black;
        }
      }
      if (str1 == ((F_LaserMaterial) this).\u0001.Name)
      {
        for (int index = ((F_LaserMaterial) this).\u0001.Rows.Count - 1; index >= 0; --index)
        {
          ((F_LaserMaterial) this).\u0001.Rows[index].Cells[1].Value = (object) true;
          ((ProfileItemCalc) ((F_LaserStartOrder) this).Sheets[index]).Enable = true;
        }
      }
      if (str1 == ((F_LaserMaterial) this).\u0002.Name)
      {
        for (int index = ((F_LaserMaterial) this).\u0001.Rows.Count - 1; index >= 0; --index)
        {
          ((F_LaserMaterial) this).\u0001.Rows[index].Cells[1].Value = (object) false;
          ((ProfileItemCalc) ((F_LaserStartOrder) this).Sheets[index]).Enable = false;
        }
      }
      if (str1 == ((F_LaserMaterial) this).\u0003.Name)
      {
        DialogBoxInput dialogBoxInput = new DialogBoxInput();
        dialogBoxInput.ValueCaption = "Count";
        dialogBoxInput.FormCaption = "Set Sheet Count";
        dialogBoxInput.Value = 1.0;
        int num = (int) dialogBoxInput.ShowDialog();
        if (dialogBoxInput.Result == DialogResult.OK)
        {
          for (int index = ((F_LaserMaterial) this).\u0001.Rows.Count - 1; index >= 0; --index)
          {
            ((F_LaserMaterial) this).\u0001.Rows[index].Cells[6].Value = (object) Convert.ToInt32(dialogBoxInput.Value);
            ((buEyeBaseVer5.Apps.ProfileItem) ((ProfileItemCalc) ((F_LaserStartOrder) this).Sheets[index]).MaterialData).Quantity = Convert.ToInt32(dialogBoxInput.Value);
          }
        }
      }
      int num1;
      if (str1 == ((F_LaserMaterial) this).\u0013.Name && ((F_LaserMaterial) this).Parts.Count > 0)
      {
        SaveFileDialog saveFileDialog = new SaveFileDialog();
        saveFileDialog.InitialDirectory = ((F_LaserStartOrder) this).SaveFileFolder;
        saveFileDialog.Filter = ((F_LaserStartOrder) this).SaveFileExtender;
        saveFileDialog.FilterIndex = ((F_LaserStartOrder) this).SaveFileExtensionIndex;
        if (saveFileDialog.ShowDialog() == DialogResult.OK)
        {
          FileInfo fileInfo = new FileInfo(saveFileDialog.FileName);
          ((F_LaserStartOrder) this).SaveFileFolder = buFile5.bunesting.GetPath(saveFileDialog.FileName);
          if (fileInfo.Extension == ".dxf")
          {
            for (int index1 = 0; index1 <= ((F_LaserStartOrder) this).Sheets.Count - 1; ++index1)
            {
              if (((ProfileItemCalc) ((F_LaserStartOrder) this).Sheets[index1]).Enable)
              {
                string str2 = ((buEyeBaseVer5.Apps.ProfileItem) ((ProfileItemCalc) ((F_LaserStartOrder) this).Sheets[index1]).MaterialData).Name.Trim();
                if (str2.Length == 0)
                {
                  num1 = index1 + 1;
                  str2 = "Mat" + num1.ToString();
                }
                string[] strArray = new string[10];
                strArray[0] = buFile5.bunesting.GetPath(saveFileDialog.FileName);
                strArray[1] = "\\";
                strArray[2] = buFile5.bunesting.getFileNameWithoutExtension(saveFileDialog.FileName);
                strArray[3] = "_";
                num1 = index1 + 1;
                strArray[4] = num1.ToString();
                strArray[5] = "_";
                strArray[6] = str2;
                strArray[7] = "_";
                strArray[8] = ((buEyeBaseVer5.Apps.ProfileItem) ((ProfileItemCalc) ((F_LaserStartOrder) this).Sheets[index1]).MaterialData).Quantity.ToString();
                strArray[9] = fileInfo.Extension;
                string FileName = string.Concat(strArray);
                List<Entity> copiedEntities = new List<Entity>();
                buDiametricDim.Copy(((\u0084.\u0001) ((ProfileItemCalc) ((F_LaserStartOrder) this).Sheets[index1]).EntitiesGroup.Outside).Entities, ref copiedEntities);
                if (((ProfileItemCalc) ((F_LaserStartOrder) this).Sheets[index1]).EntitiesGroup.Inside != null)
                {
                  for (int index2 = 0; index2 <= ((ProfileItemCalc) ((F_LaserStartOrder) this).Sheets[index1]).EntitiesGroup.Inside.Count - 1; ++index2)
                  {
                    for (int index3 = 0; index3 <= ((\u0084.\u0001) ((ProfileItemCalc) ((F_LaserStartOrder) this).Sheets[index1]).EntitiesGroup.Inside[index2]).Entities.Count - 1; ++index3)
                    {
                      Entity copiedEntity = (Entity) null;
                      buAngularDim.Copy(((\u0084.\u0001) ((ProfileItemCalc) ((F_LaserStartOrder) this).Sheets[index1]).EntitiesGroup.Inside[index2]).Entities[index3], ref copiedEntity);
                      copiedEntities.Add(copiedEntity);
                    }
                  }
                }
                if (((ProfileItemCalc) ((F_LaserStartOrder) this).Sheets[index1]).EntitiesGroup.OpenEntities != null)
                {
                  for (int index4 = 0; index4 <= ((ProfileItemCalc) ((F_LaserStartOrder) this).Sheets[index1]).EntitiesGroup.OpenEntities.Count - 1; ++index4)
                  {
                    for (int index5 = 0; index5 <= ((\u0084.\u0001) ((ProfileItemCalc) ((F_LaserStartOrder) this).Sheets[index1]).EntitiesGroup.OpenEntities[index4]).Entities.Count - 1; ++index5)
                    {
                      Entity copiedEntity = (Entity) null;
                      buAngularDim.Copy(((\u0084.\u0001) ((ProfileItemCalc) ((F_LaserStartOrder) this).Sheets[index1]).EntitiesGroup.OpenEntities[index4]).Entities[index5], ref copiedEntity);
                      copiedEntities.Add(copiedEntity);
                    }
                  }
                }
                if (((DimensionGroup) ((ProfileItemCalc) ((F_LaserStartOrder) this).Sheets[index1]).EntitiesGroup).Text != null)
                {
                  for (int index6 = 0; index6 <= ((\u0084.\u0001) ((DimensionGroup) ((ProfileItemCalc) ((F_LaserStartOrder) this).Sheets[index1]).EntitiesGroup).Text).Entities.Count - 1; ++index6)
                  {
                    Entity copiedEntity = (Entity) null;
                    buAngularDim.Copy(((\u0084.\u0001) ((DimensionGroup) ((ProfileItemCalc) ((F_LaserStartOrder) this).Sheets[index1]).EntitiesGroup).Text).Entities[index6], ref copiedEntity);
                    copiedEntities.Add(copiedEntity);
                  }
                }
                cParameter5.SaveDxfDwg(copiedEntities, FileName);
              }
            }
          }
        }
      }
      if (str1 == ((F_LaserMaterial) this).\u000F.Name)
      {
        F_NestRectPartAdd fNestRectPartAdd = (F_NestRectPartAdd) new F_SortingSettings();
        ((F_NestSheetPartList) fNestRectPartAdd).ShowItemNo = ((buEyeBaseVer5.Apps.ProfileClamper) ((ProfileMultiply) ((F_LaserStartOrder) this).Settings).Draw).ShowPartItemNoColumb;
        ((F_NestSheetPartList) fNestRectPartAdd).FormCloseMode = FormCloseModeType.Dispose;
        ((F_SortingSettings) fNestRectPartAdd).Init();
        fNestRectPartAdd.StartPosition = FormStartPosition.CenterParent;
        int num2 = (int) fNestRectPartAdd.ShowDialog();
        if (((F_NestSheetPartList) fNestRectPartAdd).Result == DialogResult.OK)
        {
          buNestingPart buNestingPart = (buNestingPart) new buEyeBaseVer5.Apps.ProfileOperationBarrel(((F_NestSheetPartList) fNestRectPartAdd).Part);
          ((buEyeBaseVer5.Apps.ProfileCalculatedJob) buCall.\u0001).GetAvailableNestingPartID(((F_LaserMaterial) this).Parts, ref ((buEyeBaseVer5.Apps.ProfileOperation) buNestingPart).ID);
          ((F_LaserMaterial) this).Parts.Add(buNestingPart);
          Image Img = (Image) null;
          ((F_Preview) this).PartPointsToImage(((F_NestSheetPartList) fNestRectPartAdd).Part, ((buEyeBaseVer5.Apps.ProfileClamper) ((ProfileMultiply) ((F_LaserStartOrder) this).Settings).Draw).GridPartSheetPreviewWidth, ((buEyeBaseVer5.Apps.ProfileClamper) ((ProfileMultiply) ((F_LaserStartOrder) this).Settings).Draw).GridPartSheetHeight, ref Img);
          DataGridViewRowCollection rows = ((F_LaserMaterial) this).\u0002.Rows;
          int count = ((F_LaserMaterial) this).Parts.Count;
          bool enable = ((buEyeBaseVer5.Apps.ProfileOperation) ((F_NestSheetPartList) fNestRectPartAdd).Part).Enable;
          string name = ((buEyeBaseVer5.Apps.ProfileOperation) ((buEyeBaseVer5.Apps.ProfileOperation) ((F_NestSheetPartList) fNestRectPartAdd).Part).PartData).Name;
          double width = ((buEyeBaseVer5.Apps.ProfileOperation) ((buEyeBaseVer5.Apps.ProfileOperation) ((F_NestSheetPartList) fNestRectPartAdd).Part).PartData).Width;
          double height = ((buEyeBaseVer5.Apps.ProfileOperation) ((buEyeBaseVer5.Apps.ProfileOperation) ((F_NestSheetPartList) fNestRectPartAdd).Part).PartData).Height;
          int quantity = ((buEyeBaseVer5.Apps.ProfileOperation) ((buEyeBaseVer5.Apps.ProfileOperation) ((F_NestSheetPartList) fNestRectPartAdd).Part).PartData).Quantity;
          int nested = ((buEyeBaseVer5.Apps.ProfileOperation) ((F_NestSheetPartList) fNestRectPartAdd).Part).Nested;
          int remain = ((buEyeBaseVer5.Apps.ProfileOperation) ((F_NestSheetPartList) fNestRectPartAdd).Part).Remain;
          int priority = ((buEyeBaseVer5.Apps.ProfileOperation) ((buEyeBaseVer5.Apps.ProfileOperation) ((F_NestSheetPartList) fNestRectPartAdd).Part).PartData).Priority;
          Enum rotation = (Enum) ((buEyeBaseVer5.Apps.ProfileOperation) ((buEyeBaseVer5.Apps.ProfileOperation) ((F_NestSheetPartList) fNestRectPartAdd).Part).PartData).Rotation;
          string fileName = ((buEyeBaseVer5.Apps.ProfileOperation) ((F_NestSheetPartList) fNestRectPartAdd).Part).FileName;
          string itemNo = ((buEyeBaseVer5.Apps.ProfileOperation) ((buEyeBaseVer5.Apps.ProfileOperation) ((F_NestSheetPartList) fNestRectPartAdd).Part).PartData).ItemNo;
          string other = ((buEyeBaseVer5.Apps.ProfileOperation) ((buEyeBaseVer5.Apps.ProfileOperation) ((F_NestSheetPartList) fNestRectPartAdd).Part).PartData).Other;
          string aux = ((buEyeBaseVer5.Apps.ProfileOperation) ((buEyeBaseVer5.Apps.ProfileOperation) ((F_NestSheetPartList) fNestRectPartAdd).Part).PartData).Aux;
          object[] objArray = \u0007.\u0001.\u0001(rotation, itemNo, other, (F_PanelCutNestSheetPartList) this, enable, quantity, name, height, fileName, count, aux, priority, nested, remain, width, Img);
          rows.Add(objArray);
          ((F_LaserMaterial) this).\u0002.Rows[((F_LaserMaterial) this).\u0002.Rows.Count - 1].DefaultCellStyle.ForeColor = Color.Black;
          ((F_LaserMaterial) this).\u0002.Rows[((F_LaserMaterial) this).\u0002.Rows.Count - 1].Height = ((buEyeBaseVer5.Apps.ProfileClamper) ((ProfileMultiply) ((F_LaserStartOrder) this).Settings).Draw).GridPartSheetHeight;
        }
      }
      if (str1 == ((F_LaserMaterial) this).\u0006.Name)
      {
        OpenFileDialog openFileDialog = new OpenFileDialog();
        openFileDialog.InitialDirectory = ((F_LaserStartOrder) this).AddPartFromFileFolder;
        openFileDialog.Filter = ((F_LaserStartOrder) this).AddPartFromFileExtender;
        openFileDialog.FilterIndex = ((F_LaserStartOrder) this).AddPartFromFileExtensionIndex;
        openFileDialog.Multiselect = true;
        openFileDialog.FileName = "";
        if (openFileDialog.ShowDialog() == DialogResult.OK)
        {
          ((F_LaserStartOrder) this).AddPartFromFileFolder = buFile5.bunesting.GetPath(openFileDialog.FileName);
          ((F_LaserStartOrder) this).AddPartFromFileExtensionIndex = openFileDialog.FilterIndex;
          if (openFileDialog.FileNames.Length != 0)
          {
            for (int index = 0; index <= openFileDialog.FileNames.Length - 1; ++index)
            {
              FileInfo fileInfo = new FileInfo(openFileDialog.FileNames[index]);
              if (fileInfo.Extension == ".bucadv5")
              {
                List<eEntities> Entities = new List<eEntities>();
                buGCodeCreate.OpenBuCadCam(fileInfo.FullName, new buCadFileOpenOptions(), ref Entities);
                ((F_PostProcessorSelect) this).AddPartFromEntities(Entities);
              }
              if (fileInfo.Extension == ".dxf")
              {
                List<eEntities> Entities = new List<eEntities>();
                List<LayerBase> layerBaseList = new List<LayerBase>();
                ((F_PostProcessorSelect) this).AddPartFromEntities(Entities);
              }
              if (fileInfo.Extension == ".csv")
                ((F_PostProcessorSelect) this).AddPartFromCsvFile(((F_LaserStartOrder) this).CsvOpenTypeForAddNestingFromFile, openFileDialog.FileName);
            }
          }
        }
      }
      if (str1 == ((F_LaserMaterial) this).\u000E.Name)
      {
        if (((F_LaserMaterial) this).\u0006.Checked && buNumeric5.MessageBoxQuestion(buNesting.LangNestingMessage[7] + AppLanguage.CadCamDynamic[34]) == DialogResult.Yes)
        {
          ((F_LaserMaterial) this).Parts.Clear();
          ((F_LaserMaterial) this).\u0002.Rows.Clear();
        }
        if (((F_LaserMaterial) this).\u0004.Checked && buNumeric5.MessageBoxQuestion(buNesting.LangNestingMessage[7] + AppLanguage.CadCamDynamic[34]) == DialogResult.Yes)
        {
          for (int index = ((F_LaserMaterial) this).\u0002.Rows.Count - 1; index >= 0; --index)
          {
            if (Convert.ToBoolean(((F_LaserMaterial) this).\u0002.Rows[index].Cells[1].Value))
            {
              ((F_LaserMaterial) this).\u0002.Rows.RemoveAt(index);
              ((F_LaserMaterial) this).Parts.RemoveAt(index);
            }
          }
        }
        if (!((F_LaserMaterial) this).\u0005.Checked || buNumeric5.MessageBoxQuestion(buNesting.LangNestingMessage[7] + AppLanguage.CadCamDynamic[34]) != DialogResult.Yes || !(((F_LaserStartOrder) this).\u0002 >= 0 & ((F_LaserStartOrder) this).\u0002 <= ((F_LaserMaterial) this).Parts.Count - 1))
          return;
        ((F_LaserMaterial) this).\u0002.Rows.RemoveAt(((F_LaserStartOrder) this).\u0002);
        ((F_LaserMaterial) this).Parts.RemoveAt(((F_LaserStartOrder) this).\u0002);
      }
      else
      {
        if (str1 == ((F_LaserMaterial) this).\u0008.Name && ((F_LaserStartOrder) this).\u0002 >= 0 & ((F_LaserStartOrder) this).\u0002 <= ((F_LaserMaterial) this).Parts.Count - 1)
        {
          ((F_LaserMaterial) this).\u0002.Rows[((F_LaserStartOrder) this).\u0002].Cells[7].Value = (object) 0;
          ((F_LaserMaterial) this).\u0002.Rows[((F_LaserStartOrder) this).\u0002].Cells[8].Value = (object) ((buEyeBaseVer5.Apps.ProfileOperation) ((buEyeBaseVer5.Apps.ProfileOperation) ((F_LaserMaterial) this).Parts[((F_LaserStartOrder) this).\u0002]).PartData).Quantity;
          ((buEyeBaseVer5.Apps.ProfileOperation) ((F_LaserMaterial) this).Parts[((F_LaserStartOrder) this).\u0002]).Nested = 0;
          ((buEyeBaseVer5.Apps.ProfileOperation) ((F_LaserMaterial) this).Parts[((F_LaserStartOrder) this).\u0002]).Remain = ((buEyeBaseVer5.Apps.ProfileOperation) ((buEyeBaseVer5.Apps.ProfileOperation) ((F_LaserMaterial) this).Parts[((F_LaserStartOrder) this).\u0002]).PartData).Quantity;
          ((F_LaserMaterial) this).\u0002.Rows[((F_LaserStartOrder) this).\u0002].DefaultCellStyle.ForeColor = Color.Black;
        }
        if (str1 == ((F_LaserMaterial) this).\u0007.Name)
        {
          for (int index = 0; index <= ((F_LaserMaterial) this).Parts.Count - 1; ++index)
          {
            ((F_LaserMaterial) this).\u0002.Rows[index].Cells[7].Value = (object) 0;
            ((F_LaserMaterial) this).\u0002.Rows[index].Cells[8].Value = (object) ((buEyeBaseVer5.Apps.ProfileOperation) ((buEyeBaseVer5.Apps.ProfileOperation) ((F_LaserMaterial) this).Parts[index]).PartData).Quantity;
            ((buEyeBaseVer5.Apps.ProfileOperation) ((F_LaserMaterial) this).Parts[index]).Nested = 0;
            ((buEyeBaseVer5.Apps.ProfileOperation) ((F_LaserMaterial) this).Parts[index]).Remain = ((buEyeBaseVer5.Apps.ProfileOperation) ((buEyeBaseVer5.Apps.ProfileOperation) ((F_LaserMaterial) this).Parts[index]).PartData).Quantity;
            ((F_LaserMaterial) this).\u0002.Rows[index].DefaultCellStyle.ForeColor = Color.Black;
          }
        }
        if (str1 == ((F_LaserMaterial) this).\u0014.Name && ((F_LaserStartOrder) this).\u0002 >= 0)
        {
          buNestingPart Part = (buNestingPart) new buEyeBaseVer5.Apps.ProfileOperationBarrel(((F_LaserMaterial) this).Parts[((F_LaserStartOrder) this).\u0002]);
          ((buEyeBaseVer5.Apps.ProfileOperation) ((buEyeBaseVer5.Apps.ProfileOperation) Part).PartData).Name = ((buEyeBaseVer5.Apps.ProfileOperation) ((buEyeBaseVer5.Apps.ProfileOperation) Part).PartData).Name + "- [Mirror]";
          Point3D MirrorPoint = new Point3D(1.0, 0.0, 0.0);
          buCall.\u0001.Mirror(new Point3D(), MirrorPoint, Plane.XY, ref ((buEyeBaseVer5.Apps.ProfileOperationRectangle) Part).EntitiesGroup);
          ((buEyeBaseVer5.Apps.ProfileCalculatedJob) buCall.\u0001).GetAvailableNestingPartID(((F_LaserMaterial) this).Parts, ref ((buEyeBaseVer5.Apps.ProfileOperation) Part).ID);
          ((F_LaserMaterial) this).Parts.Add(Part);
          Image Img = (Image) null;
          ((F_Preview) this).PartPointsToImage(Part, ((buEyeBaseVer5.Apps.ProfileClamper) ((ProfileMultiply) ((F_LaserStartOrder) this).Settings).Draw).GridPartSheetPreviewWidth, ((buEyeBaseVer5.Apps.ProfileClamper) ((ProfileMultiply) ((F_LaserStartOrder) this).Settings).Draw).GridPartSheetHeight, ref Img);
          DataGridViewRowCollection rows = ((F_LaserMaterial) this).\u0002.Rows;
          int count = ((F_LaserMaterial) this).Parts.Count;
          bool enable = ((buEyeBaseVer5.Apps.ProfileOperation) Part).Enable;
          string name = ((buEyeBaseVer5.Apps.ProfileOperation) ((buEyeBaseVer5.Apps.ProfileOperation) Part).PartData).Name;
          double width = ((buEyeBaseVer5.Apps.ProfileOperation) ((buEyeBaseVer5.Apps.ProfileOperation) Part).PartData).Width;
          double height = ((buEyeBaseVer5.Apps.ProfileOperation) ((buEyeBaseVer5.Apps.ProfileOperation) Part).PartData).Height;
          int quantity = ((buEyeBaseVer5.Apps.ProfileOperation) ((buEyeBaseVer5.Apps.ProfileOperation) Part).PartData).Quantity;
          int nested = ((buEyeBaseVer5.Apps.ProfileOperation) Part).Nested;
          int remain = ((buEyeBaseVer5.Apps.ProfileOperation) Part).Remain;
          int priority = ((buEyeBaseVer5.Apps.ProfileOperation) ((buEyeBaseVer5.Apps.ProfileOperation) Part).PartData).Priority;
          Enum rotation = (Enum) ((buEyeBaseVer5.Apps.ProfileOperation) ((buEyeBaseVer5.Apps.ProfileOperation) Part).PartData).Rotation;
          string fileName = ((buEyeBaseVer5.Apps.ProfileOperation) Part).FileName;
          string itemNo = ((buEyeBaseVer5.Apps.ProfileOperation) ((buEyeBaseVer5.Apps.ProfileOperation) Part).PartData).ItemNo;
          string other = ((buEyeBaseVer5.Apps.ProfileOperation) ((buEyeBaseVer5.Apps.ProfileOperation) Part).PartData).Other;
          string aux = ((buEyeBaseVer5.Apps.ProfileOperation) ((buEyeBaseVer5.Apps.ProfileOperation) Part).PartData).Aux;
          object[] objArray = \u0007.\u0001.\u0001(rotation, itemNo, other, (F_PanelCutNestSheetPartList) this, enable, quantity, name, height, fileName, count, aux, priority, nested, remain, width, Img);
          rows.Add(objArray);
          ((F_LaserMaterial) this).\u0002.Rows[((F_LaserMaterial) this).\u0002.Rows.Count - 1].DefaultCellStyle.ForeColor = Color.Black;
          ((F_LaserMaterial) this).\u0002.Rows[((F_LaserMaterial) this).\u0002.Rows.Count - 1].Height = ((buEyeBaseVer5.Apps.ProfileClamper) ((ProfileMultiply) ((F_LaserStartOrder) this).Settings).Draw).GridPartSheetHeight;
        }
        if (str1 == ((F_LaserMaterial) this).\u0015.Name && ((F_LaserStartOrder) this).\u0002 >= 0)
        {
          buNestingPart Part = (buNestingPart) new buEyeBaseVer5.Apps.ProfileOperationBarrel(((F_LaserMaterial) this).Parts[((F_LaserStartOrder) this).\u0002]);
          ((buEyeBaseVer5.Apps.ProfileOperation) ((buEyeBaseVer5.Apps.ProfileOperation) Part).PartData).Name = ((buEyeBaseVer5.Apps.ProfileOperation) ((buEyeBaseVer5.Apps.ProfileOperation) Part).PartData).Name + "- [Mirror]";
          Point3D MirrorPoint = new Point3D(0.0, 1.0, 0.0);
          buCall.\u0001.Mirror(new Point3D(), MirrorPoint, Plane.XY, ref ((buEyeBaseVer5.Apps.ProfileOperationRectangle) Part).EntitiesGroup);
          ((buEyeBaseVer5.Apps.ProfileCalculatedJob) buCall.\u0001).GetAvailableNestingPartID(((F_LaserMaterial) this).Parts, ref ((buEyeBaseVer5.Apps.ProfileOperation) Part).ID);
          ((F_LaserMaterial) this).Parts.Add(Part);
          Image Img = (Image) null;
          ((F_Preview) this).PartPointsToImage(Part, ((buEyeBaseVer5.Apps.ProfileClamper) ((ProfileMultiply) ((F_LaserStartOrder) this).Settings).Draw).GridPartSheetPreviewWidth, ((buEyeBaseVer5.Apps.ProfileClamper) ((ProfileMultiply) ((F_LaserStartOrder) this).Settings).Draw).GridPartSheetHeight, ref Img);
          DataGridViewRowCollection rows = ((F_LaserMaterial) this).\u0002.Rows;
          int count = ((F_LaserMaterial) this).Parts.Count;
          bool enable = ((buEyeBaseVer5.Apps.ProfileOperation) Part).Enable;
          string name = ((buEyeBaseVer5.Apps.ProfileOperation) ((buEyeBaseVer5.Apps.ProfileOperation) Part).PartData).Name;
          double width = ((buEyeBaseVer5.Apps.ProfileOperation) ((buEyeBaseVer5.Apps.ProfileOperation) Part).PartData).Width;
          double height = ((buEyeBaseVer5.Apps.ProfileOperation) ((buEyeBaseVer5.Apps.ProfileOperation) Part).PartData).Height;
          int quantity = ((buEyeBaseVer5.Apps.ProfileOperation) ((buEyeBaseVer5.Apps.ProfileOperation) Part).PartData).Quantity;
          int nested = ((buEyeBaseVer5.Apps.ProfileOperation) Part).Nested;
          int remain = ((buEyeBaseVer5.Apps.ProfileOperation) Part).Remain;
          int priority = ((buEyeBaseVer5.Apps.ProfileOperation) ((buEyeBaseVer5.Apps.ProfileOperation) Part).PartData).Priority;
          Enum rotation = (Enum) ((buEyeBaseVer5.Apps.ProfileOperation) ((buEyeBaseVer5.Apps.ProfileOperation) Part).PartData).Rotation;
          string fileName = ((buEyeBaseVer5.Apps.ProfileOperation) Part).FileName;
          string itemNo = ((buEyeBaseVer5.Apps.ProfileOperation) ((buEyeBaseVer5.Apps.ProfileOperation) Part).PartData).ItemNo;
          string other = ((buEyeBaseVer5.Apps.ProfileOperation) ((buEyeBaseVer5.Apps.ProfileOperation) Part).PartData).Other;
          string aux = ((buEyeBaseVer5.Apps.ProfileOperation) ((buEyeBaseVer5.Apps.ProfileOperation) Part).PartData).Aux;
          object[] objArray = \u0007.\u0001.\u0001(rotation, itemNo, other, (F_PanelCutNestSheetPartList) this, enable, quantity, name, height, fileName, count, aux, priority, nested, remain, width, Img);
          rows.Add(objArray);
          ((F_LaserMaterial) this).\u0002.Rows[((F_LaserMaterial) this).\u0002.Rows.Count - 1].DefaultCellStyle.ForeColor = Color.Black;
          ((F_LaserMaterial) this).\u0002.Rows[((F_LaserMaterial) this).\u0002.Rows.Count - 1].Height = ((buEyeBaseVer5.Apps.ProfileClamper) ((ProfileMultiply) ((F_LaserStartOrder) this).Settings).Draw).GridPartSheetHeight;
        }
        if (str1 == ((F_LaserMaterial) this).\u0012.Name)
        {
          ((F_LaserMaterial) this).SendToCadEntities.Clear();
          double dy = 0.0;
          double dx = 0.0;
          double num3 = double.MinValue;
          int num4 = 0;
          int num5 = 0;
          for (int index = 0; index <= ((F_LaserMaterial) this).Parts.Count - 1; ++index)
          {
            if (((buEyeBaseVer5.Apps.ProfileOperation) ((F_LaserMaterial) this).Parts[index]).Enable && ((buEyeBaseVer5.Apps.ProfileOperation) ((buEyeBaseVer5.Apps.ProfileOperation) ((F_LaserMaterial) this).Parts[index]).PartData).Width > num3)
              num3 = ((buEyeBaseVer5.Apps.ProfileOperation) ((buEyeBaseVer5.Apps.ProfileOperation) ((F_LaserMaterial) this).Parts[index]).PartData).Width;
          }
          for (int index7 = 0; index7 <= ((F_LaserMaterial) this).Parts.Count - 1; ++index7)
          {
            if (((buEyeBaseVer5.Apps.ProfileOperation) ((F_LaserMaterial) this).Parts[index7]).Enable)
            {
              List<Entity> copiedEntity = new List<Entity>();
              buDiametricDim.Copy(((buEyeBaseVer5.Apps.ProfileOperationRectangle) ((F_LaserMaterial) this).Parts[index7]).EntitiesGroup, ref copiedEntity);
              for (int index8 = 0; index8 <= copiedEntity.Count - 1; ++index8)
              {
                copiedEntity[index8].Translate(dx, dy);
                ((F_LaserMaterial) this).SendToCadEntities.Add(copiedEntity[index8]);
              }
              dy = dy + ((buEyeBaseVer5.Apps.ProfileOperation) ((buEyeBaseVer5.Apps.ProfileOperation) ((F_LaserMaterial) this).Parts[index7]).PartData).Height + 20.0;
              ++num4;
              if (num4 >= 10)
              {
                num4 = 0;
                ++num5;
                dy = 0.0;
                dx = num3 * (double) num5;
              }
            }
          }
          if (((F_LaserMaterial) this).SendToCadEntities.Count > 0)
          {
            ((F_LaserStartOrder) this).SendToCad = true;
            this.Visible = false;
            ((F_BendingLRAList) this).PropertiesForm.Result = DialogResult.OK;
          }
        }
        if (str1 == ((F_LaserMaterial) this).\u000F.Name)
        {
          DialogBoxInput dialogBoxInput = new DialogBoxInput();
          dialogBoxInput.ValueCaption = "Count";
          dialogBoxInput.FormCaption = "Set Part Count";
          int num6 = (int) dialogBoxInput.ShowDialog();
          if (dialogBoxInput.Result == DialogResult.OK)
          {
            for (int index = ((F_LaserMaterial) this).\u0002.Rows.Count - 1; index >= 0; --index)
            {
              ((F_LaserMaterial) this).\u0002.Rows[index].Cells[6].Value = (object) Convert.ToInt32(dialogBoxInput.Value);
              ((buEyeBaseVer5.Apps.ProfileOperation) ((buEyeBaseVer5.Apps.ProfileOperation) ((F_LaserMaterial) this).Parts[index]).PartData).Quantity = Convert.ToInt32(dialogBoxInput.Value);
            }
          }
        }
        if (str1 == ((F_LaserMaterial) this).\u0016.Name)
        {
          DialogBoxInput dialogBoxInput = new DialogBoxInput();
          dialogBoxInput.ValueCaption = "Addtional Rotation";
          dialogBoxInput.FormCaption = "Degree";
          int num7 = (int) dialogBoxInput.ShowDialog();
          if (dialogBoxInput.Result == DialogResult.OK)
          {
            for (int index = ((F_LaserMaterial) this).\u0002.Rows.Count - 1; index >= 0; --index)
              ((buEyeBaseVer5.Apps.ProfileOperation) ((buEyeBaseVer5.Apps.ProfileOperation) ((F_LaserMaterial) this).Parts[index]).PartData).AdditionalRotation = Convert.ToDouble(dialogBoxInput.Value);
          }
        }
        if (str1 == ((F_LaserMaterial) this).\u0004.Name)
        {
          for (int index = ((F_LaserMaterial) this).\u0002.Rows.Count - 1; index >= 0; --index)
          {
            ((F_LaserMaterial) this).\u0002.Rows[index].Cells[1].Value = (object) true;
            ((buEyeBaseVer5.Apps.ProfileOperation) ((F_LaserMaterial) this).Parts[index]).Enable = true;
          }
        }
        if (str1 == ((F_LaserMaterial) this).\u0005.Name)
        {
          for (int index = ((F_LaserMaterial) this).\u0002.Rows.Count - 1; index >= 0; --index)
          {
            ((F_LaserMaterial) this).\u0002.Rows[index].Cells[1].Value = (object) false;
            ((buEyeBaseVer5.Apps.ProfileOperation) ((F_LaserMaterial) this).Parts[index]).Enable = false;
          }
        }
        if (str1 == ((F_LaserMaterial) this).\u0007.Name)
        {
          for (int index = 0; index <= ((F_LaserMaterial) this).\u0002.Rows.Count - 1; ++index)
          {
            if (Convert.ToBoolean(((F_LaserMaterial) this).\u0002.Rows[index].Cells[1].Value))
            {
              ((buEyeBaseVer5.Apps.ProfileOperation) ((buEyeBaseVer5.Apps.ProfileOperation) ((F_LaserMaterial) this).Parts[index]).PartData).Rotation = nestPartRotateType.Fixed0;
              ((F_LaserMaterial) this).\u0002.Rows[index].Cells[10].Value = (object) nestPartRotateType.Fixed0;
            }
          }
        }
        if (str1 == ((F_LaserMaterial) this).\u0006.Name)
        {
          for (int index = 0; index <= ((F_LaserMaterial) this).\u0002.Rows.Count - 1; ++index)
          {
            if (Convert.ToBoolean(((F_LaserMaterial) this).\u0002.Rows[index].Cells[0].Value))
            {
              ((buEyeBaseVer5.Apps.ProfileOperation) ((buEyeBaseVer5.Apps.ProfileOperation) ((F_LaserMaterial) this).Parts[index]).PartData).Rotation = nestPartRotateType.FreeRotate;
              ((F_LaserMaterial) this).\u0002.Rows[index].Cells[10].Value = (object) nestPartRotateType.FreeRotate;
            }
          }
        }
        if (str1 == ((F_LaserMaterial) this).\u0008.Name)
        {
          for (int index = 0; index <= ((F_LaserMaterial) this).\u0002.Rows.Count - 1; ++index)
          {
            if (Convert.ToBoolean(((F_LaserMaterial) this).\u0002.Rows[index].Cells[1].Value))
            {
              ((buEyeBaseVer5.Apps.ProfileOperation) ((buEyeBaseVer5.Apps.ProfileOperation) ((F_LaserMaterial) this).Parts[index]).PartData).Rotation = nestPartRotateType.Increment90;
              ((F_LaserMaterial) this).\u0002.Rows[index].Cells[10].Value = (object) nestPartRotateType.Increment90;
            }
          }
        }
        if (str1 == ((F_LaserMaterial) this).\u000E.Name)
        {
          for (int index = 0; index <= ((F_LaserMaterial) this).\u0002.Rows.Count - 1; ++index)
          {
            if (Convert.ToBoolean(((F_LaserMaterial) this).\u0002.Rows[index].Cells[1].Value))
            {
              ((buEyeBaseVer5.Apps.ProfileOperation) ((buEyeBaseVer5.Apps.ProfileOperation) ((F_LaserMaterial) this).Parts[index]).PartData).Rotation = nestPartRotateType.Increment180;
              ((F_LaserMaterial) this).\u0002.Rows[index].Cells[10].Value = (object) nestPartRotateType.Increment180;
            }
          }
        }
        if (str1 == ((F_LaserMaterial) this).\u0011.Name)
        {
          List<buNestingPart> buNestingPartList = new List<buNestingPart>();
          for (int index = 0; index <= ((F_LaserMaterial) this).Parts.Count - 1; ++index)
          {
            buNestingPart data1 = (buNestingPart) new buEyeBaseVer5.Apps.ProfileOperationBarrel();
            Point3D MinPoint = new Point3D();
            Point3D MaxPoint = new Point3D();
            buCall.\u0001.BoxSizeCalculate(((buEyeBaseVer5.Apps.ProfileOperationRectangle) ((F_LaserMaterial) this).Parts[index]).EntitiesGroup, ref MinPoint, ref MaxPoint);
            double newWidth = MaxPoint.X - MinPoint.X;
            double newHeight = MaxPoint.Y - MinPoint.Y;
            if (newWidth > 0.0 & newHeight > 0.0)
            {
              ((F_Preview) this).CreatPartAsRectanlge(newWidth, newHeight, ((F_LaserMaterial) this).Parts[index], ref data1);
              ((GProfileOperation) buCall.\u0001).PartRectangle(((buEyeBaseVer5.Apps.ProfileOperation) ((buEyeBaseVer5.Apps.ProfileOperation) data1).PartData).Width, ((buEyeBaseVer5.Apps.ProfileOperation) ((buEyeBaseVer5.Apps.ProfileOperation) data1).PartData).Height, ref data1);
              buNestingPart data2 = (buNestingPart) new buEyeBaseVer5.Apps.ProfileOperationBarrel(data1);
              ((buEyeBaseVer5.Apps.ProfileCalculatedJob) buCall.\u0001).GetAvailableNestingPartID(((F_LaserMaterial) this).Parts, ref ((buEyeBaseVer5.Apps.ProfileOperation) data2).ID);
              ((F_LaserMaterial) this).Parts[index] = (buNestingPart) new buEyeBaseVer5.Apps.ProfileOperationBarrel(data2);
              buNestingPartList.Add(data2);
            }
          }
          this.Init(1);
        }
        if (str1 == ((F_LaserMaterial) this).\u0010.Name && ((F_LaserMaterial) this).Parts.Count > 0)
        {
          SaveFileDialog saveFileDialog = new SaveFileDialog();
          saveFileDialog.InitialDirectory = ((F_LaserStartOrder) this).SaveFileFolder;
          saveFileDialog.Filter = ((F_LaserStartOrder) this).SaveFileExtender;
          saveFileDialog.FilterIndex = ((F_LaserStartOrder) this).SaveFileExtensionIndex;
          if (saveFileDialog.ShowDialog() == DialogResult.OK)
          {
            FileInfo fileInfo = new FileInfo(saveFileDialog.FileName);
            ((F_LaserStartOrder) this).SaveFileFolder = buFile5.bunesting.GetPath(saveFileDialog.FileName);
            if (fileInfo.Extension == ".dxf")
            {
              for (int index = 0; index <= ((F_LaserMaterial) this).Parts.Count - 1; ++index)
              {
                if (((buEyeBaseVer5.Apps.ProfileOperation) ((F_LaserMaterial) this).Parts[index]).Enable)
                {
                  string str3 = ((buEyeBaseVer5.Apps.ProfileOperation) ((buEyeBaseVer5.Apps.ProfileOperation) ((F_LaserMaterial) this).Parts[index]).PartData).Name.Trim();
                  if (str3.Length == 0)
                  {
                    num1 = index + 1;
                    str3 = "Part" + num1.ToString();
                  }
                  string[] strArray = new string[10];
                  strArray[0] = buFile5.bunesting.GetPath(saveFileDialog.FileName);
                  strArray[1] = "\\";
                  strArray[2] = buFile5.bunesting.getFileNameWithoutExtension(saveFileDialog.FileName);
                  strArray[3] = "_";
                  num1 = index + 1;
                  strArray[4] = num1.ToString();
                  strArray[5] = "_";
                  strArray[6] = str3;
                  strArray[7] = "_";
                  strArray[8] = ((buEyeBaseVer5.Apps.ProfileOperation) ((buEyeBaseVer5.Apps.ProfileOperation) ((F_LaserMaterial) this).Parts[index]).PartData).Quantity.ToString();
                  strArray[9] = fileInfo.Extension;
                  string FileName = string.Concat(strArray);
                  List<Entity> copiedEntity = new List<Entity>();
                  buDiametricDim.Copy(((buEyeBaseVer5.Apps.ProfileOperationRectangle) ((F_LaserMaterial) this).Parts[index]).EntitiesGroup, ref copiedEntity);
                  cParameter5.SaveDxfDwg(copiedEntity, FileName);
                }
              }
            }
          }
        }
        if (str1 == ((F_LaserMaterial) this).\u0010.Name)
        {
          SaveFileDialog saveFileDialog = new SaveFileDialog();
          saveFileDialog.InitialDirectory = ((F_LaserStartOrder) this).SaveFileFolder;
          saveFileDialog.Filter = "buCad/Cam Nesting Files (*.bunesting)|*.bunesting";
          saveFileDialog.FilterIndex = 1;
          if (saveFileDialog.ShowDialog() == DialogResult.OK)
          {
            ((F_LaserStartOrder) this).SaveFileFolder = buFile5.bunesting.GetPath(saveFileDialog.FileName);
            new buVector5().SaveNesting(saveFileDialog.FileName, ((F_LaserMaterial) this).Parts, ((F_LaserStartOrder) this).Sheets, ((F_LaserStartOrder) this).Settings);
          }
        }
        if (str1 == ((F_LaserMaterial) this).\u0011.Name)
        {
          OpenFileDialog openFileDialog = new OpenFileDialog();
          openFileDialog.InitialDirectory = ((F_LaserStartOrder) this).SaveFileFolder;
          openFileDialog.Filter = "buCad/Cam Nesting Files (*.bunesting)|*.bunesting";
          openFileDialog.FilterIndex = 1;
          if (openFileDialog.ShowDialog() == DialogResult.OK)
          {
            ((F_LaserStartOrder) this).SaveFileFolder = buFile5.bunesting.GetPath(openFileDialog.FileName);
            new buVector5().OpenNesting(openFileDialog.FileName, ref ((F_LaserMaterial) this).Parts, ref ((F_LaserStartOrder) this).Sheets);
            this.Init(((F_LaserMaterial) this).\u0001.SelectedIndex);
          }
        }
        if (str1 == ((F_LaserMaterial) this).\u0012.Name)
        {
          this.Visible = false;
          ((F_BendingLRAList) this).PropertiesForm.Result = DialogResult.Cancel;
        }
        if (!(str1 == ((F_LaserMaterial) this).\u0013.Name))
          return;
        ((buEyeBaseVer5.Apps.ProfileOperationSlot) ((ProfileSupportBlock) ((F_LaserStartOrder) this).Settings).PartSettings).Multiply = (int) ((F_LaserMaterial) this).\u0001.Value;
        this.Visible = false;
        ((F_BendingLRAList) this).PropertiesForm.Result = DialogResult.OK;
      }
    }
  }
}
