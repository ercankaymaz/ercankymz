// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Forms.F_SettingTreeView
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using buEyeBaseVer5.Apps;
using devDept.Eyeshot.Control;
using dummy_ptr;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Windows.Forms;

#nullable disable
namespace buEyeBaseVer5.Forms;

public class F_SettingTreeView : Form
{
  internal Label \u0001;
  internal TextBox \u0001;
  internal Label \u0002;
  internal TextBox \u0002;
  internal Button \u0001;
  internal ImageList \u0001;
  internal Button \u0002;
  internal Button \u0003;
  internal Button \u0004;
  internal Button \u0005;
  internal ContextMenuStrip \u0001;
  internal ToolStripMenuItem \u0001;
  internal ToolStripMenuItem \u0002;
  internal ToolStripSeparator \u0001;
  internal ToolStripMenuItem \u0003;
  internal TabPage \u0002;
  internal Label \u0003;
  internal TextBox \u0003;
  internal Label \u0004;
  internal TextBox \u0004;
  internal Button \u0006;
  internal Button \u0007;
  internal Button \u0008;
  internal Button \u000E;
  internal Button \u000F;
  internal DataGridView \u0002;
  internal ContextMenuStrip \u0002;
  internal ToolStripMenuItem \u0004;

  static F_SettingTreeView() => F_NestPartAdd.Captions = new List<string>();

  public F_SettingTreeView()
  {
    ((F_NestSheetAdd) this).PropertiesForm = new FormProperties();
    ((F_NestSheetAdd) this).Settings = (buNestingSettings) new ProfileOperationDataRectangleRound();
    ((F_NestSheetAdd) this).RunTimeSettings = (buNestingRuntime) new ProfileOperationDataBarel();
    ((F_NestSheetAdd) this).\u0001 = (IContainer) null;
    // ISSUE: explicit constructor call
    base.\u002Ector();
    buCompare5.CultureSettings();
    \u0007.\u0001.\u0001((F_NestExecute) this);
  }

  internal void \u0001([In] object obj0, [In] EventArgs obj1)
  {
  }

  public void Init()
  {
    ((F_NestSheetAdd) this).PropertiesForm.Inited = false;
    if (((F_NestSheetAdd) this).PropertiesForm.Height > 10)
      this.Height = ((F_NestSheetAdd) this).PropertiesForm.Height;
    if (((F_NestSheetAdd) this).PropertiesForm.Width > 10)
      this.Width = ((F_NestSheetAdd) this).PropertiesForm.Width;
    this.TopMost = ((F_NestSheetAdd) this).PropertiesForm.TopMost;
    this.StartPosition = ((F_NestSheetAdd) this).PropertiesForm.FormPosition;
    if (((ProfileTempVars) ((F_NestSheetAdd) this).RunTimeSettings).MaxNestingTimeSec < 1)
      ((ProfileTempVars) ((F_NestSheetAdd) this).RunTimeSettings).MaxNestingTimeSec = 1;
    if (((ProfileTempVars) ((F_NestSheetAdd) this).RunTimeSettings).MaxNestingTimeSec > 10000)
      ((ProfileTempVars) ((F_NestSheetAdd) this).RunTimeSettings).MaxNestingTimeSec = 10000;
    ((F_NestSheetPartList) this).txt_name.Text = ((ProfileTempVars) ((F_NestSheetAdd) this).RunTimeSettings).NestingJobName;
    ((F_NestSheetPartList) this).txt_explanation.Text = ((ProfileTempVars) ((F_NestSheetAdd) this).RunTimeSettings).NestingJobExplanation;
    ((F_NestSheetPartList) this).\u0001.Value = (Decimal) ((ProfileTempVars) ((F_NestSheetAdd) this).RunTimeSettings).MaxNestingTimeSec;
    this.LoadLanguage();
    ((F_NestSheetAdd) this).PropertiesForm.Result = DialogResult.None;
    ((F_NestSheetAdd) this).PropertiesForm.Inited = true;
  }

  public void LoadLanguage()
  {
    string callMethod = "NestPartAdd LoadLanguage";
    try
    {
      if (F_NestSheetAdd.Captions.Count < 6)
        return;
      this.Text = F_NestSheetAdd.Captions[0];
      ((F_NestSheetPartList) this).\u0002.Text = F_NestSheetAdd.Captions[1];
      ((F_NestSheetPartList) this).\u0006.Text = F_NestSheetAdd.Captions[2];
      ((F_NestSheetPartList) this).\u0007.Text = F_NestSheetAdd.Captions[3];
      ((F_NestSheetPartList) this).\u0004.Text = F_NestSheetAdd.Captions[4];
      ((F_NestSheetPartList) this).\u0001.Text = F_NestSheetAdd.Captions[5];
      ((F_NestSheetPartList) this).\u0002.Text = F_NestSheetAdd.Captions[6];
    }
    catch (Exception ex)
    {
      string str = "";
      buLog.addLog(str, "Not Ok", callMethod);
      buException.throwException(ex, callMethod, true, str);
    }
  }

  internal void \u0002([In] object obj0, [In] EventArgs obj1)
  {
    System.Windows.Forms.Control control1 = new System.Windows.Forms.Control();
    System.Windows.Forms.Control control2 = (System.Windows.Forms.Control) obj0;
    if (control2.Name == ((F_NestSheetPartList) this).\u0001.Name)
    {
      this.Apply();
      ((F_NestSheetAdd) this).PropertiesForm.Result = DialogResult.OK;
      if (((F_NestSheetAdd) this).PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
        this.Dispose();
      if (((F_NestSheetAdd) this).PropertiesForm.FormCloseMode == FormCloseModeType.Invisible)
        this.Visible = false;
    }
    if (!(control2.Name == ((F_NestSheetPartList) this).\u0002.Name))
      return;
    ((F_NestSheetAdd) this).PropertiesForm.Result = DialogResult.Cancel;
    if (((F_NestSheetAdd) this).PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
      this.Dispose();
    if (((F_NestSheetAdd) this).PropertiesForm.FormCloseMode != FormCloseModeType.Invisible)
      return;
    this.Visible = false;
  }

  public void Apply()
  {
    ((ProfileTempVars) ((F_NestSheetAdd) this).RunTimeSettings).MaxNestingTimeSec = (int) ((F_NestSheetPartList) this).\u0001.Value;
    ((ProfileTempVars) ((F_NestSheetAdd) this).RunTimeSettings).NestingJobName = ((F_NestSheetPartList) this).txt_name.Text;
    ((ProfileTempVars) ((F_NestSheetAdd) this).RunTimeSettings).NestingJobExplanation = ((F_NestSheetPartList) this).txt_explanation.Text;
  }

  internal void \u0001([In] object obj0, [In] FormClosingEventArgs obj1)
  {
    if (((F_NestSheetAdd) this).PropertiesForm.Result == DialogResult.OK)
      return;
    obj1.Cancel = true;
    ((F_NestSheetAdd) this).PropertiesForm.Result = DialogResult.Cancel;
    if (((F_NestSheetAdd) this).PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
      this.Dispose();
    if (((F_NestSheetAdd) this).PropertiesForm.FormCloseMode != FormCloseModeType.Invisible)
      return;
    this.Visible = false;
  }

  protected override void Dispose(bool disposing)
  {
    if ((!disposing ? 0 : (((F_NestSheetAdd) this).\u0001 != null ? 1 : 0)) != 0)
      ((F_NestSheetAdd) this).\u0001.Dispose();
    base.Dispose(disposing);
  }

  static F_SettingTreeView() => F_NestSheetAdd.Captions = new List<string>();

  public F_SettingTreeView()
  {
    ((F_NestSheetPartList) this).PropertiesForm = new FormProperties();
    ((F_NestSheetPartList) this).Sheet = (buNestingSheet) new ProfileOperation();
    ((F_NestSheetPartList) this).Settings = (buNestingVar) new ProfileOperationDataBarel();
    ((F_NestSheetPartList) this).\u0001 = (Design) null;
    ((F_NestSheetPartList) this).\u0001 = new Timer();
    ((F_NestSheetPartList) this).\u0001 = (IContainer) null;
    // ISSUE: explicit constructor call
    base.\u002Ector();
    buCompare5.CultureSettings();
    \u007B0e48b843\u002Dfb72\u002D498c\u002D834d\u002Dfc743ba0facc\u007D.\u0001((F_NestSheetShapeAdd) this);
    ((F_NestSheetPartList) this).\u0001.Tick += new EventHandler(this.\u0002);
  }

  internal void \u0001([In] object obj0, [In] EventArgs obj1)
  {
  }

  public void Init()
  {
    ((F_NestSheetPartList) this).PropertiesForm.Inited = false;
    if (((F_NestSheetPartList) this).PropertiesForm.Height > 10)
      this.Height = ((F_NestSheetPartList) this).PropertiesForm.Height;
    if (((F_NestSheetPartList) this).PropertiesForm.Width > 10)
      this.Width = ((F_NestSheetPartList) this).PropertiesForm.Width;
    this.TopMost = ((F_NestSheetPartList) this).PropertiesForm.TopMost;
    this.StartPosition = ((F_NestSheetPartList) this).PropertiesForm.FormPosition;
    ((F_NestSheetPartList) this).\u0001.Value = (Decimal) ((GProfileOperation) ((ProfileSupportBlock) ((F_NestSheetPartList) this).Settings).AddMaterial).Quantity;
    ((F_NestSheetPartList) this).\u0002.Value = (Decimal) ((GProfileOperation) ((ProfileSupportBlock) ((F_NestSheetPartList) this).Settings).AddMaterial).Thickness;
    ((F_NestSheetPartList) this).txt_name.Text = ((GProfileOperation) ((ProfileSupportBlock) ((F_NestSheetPartList) this).Settings).AddMaterial).Name;
    ((F_NestSheetPartList) this).\u0001.Checked = ((GProfileOperation) ((ProfileSupportBlock) ((F_NestSheetPartList) this).Settings).AddMaterial).AddUselessEntities;
    ((F_NestSheetPartList) this).\u0002.Checked = ((GProfileOperation) ((ProfileSupportBlock) ((F_NestSheetPartList) this).Settings).AddMaterial).DeleteSelectedEntities;
    this.LoadLanguage();
    if (((F_NestSheetPartList) this).\u0001 == null)
    {
      EyeCreateProps Properties = (EyeCreateProps) new ShapeEdit();
      ((DiameterDepthPoint) Properties).ShowToolBar = false;
      ((DiameterDepthPoint) Properties).ShowViewCube = false;
      ((MaterialBase5) Properties).ShowCoordinateArrow = false;
      buConversion5.CreateControlsTool(true, Properties, ref ((F_NestSheetPartList) this).\u0001);
      ((F_NestSheetPartList) this).\u0001.Dock = DockStyle.Fill;
      if (((F_NestSheetPartList) this).\u0004.Controls.Count == 0)
        ((F_NestSheetPartList) this).\u0004.Controls.Add((System.Windows.Forms.Control) ((F_NestSheetPartList) this).\u0001);
    }
    ((F_NestSheetPartList) this).\u0001.Interval = 50;
    ((F_NestSheetPartList) this).\u0001.Enabled = true;
    ((F_NestSheetPartList) this).PropertiesForm.Result = DialogResult.None;
    ((F_NestSheetPartList) this).PropertiesForm.Inited = true;
  }

  private void \u0002([In] object obj0, [In] EventArgs obj1)
  {
    ((F_NestSheetPartList) this).\u0001.Enabled = false;
    buCall.\u0001.DrawSheet(((F_NestSheetPartList) this).Sheet, ((F_NestSheetPartList) this).Settings, ref ((F_NestSheetPartList) this).\u0001);
  }

  public void LoadLanguage()
  {
    string callMethod = "NestSheetAdd LoadLanguage";
    try
    {
      if (F_NestSheetPartList.Captions.Count < 7)
        return;
      this.Text = F_NestSheetPartList.Captions[0];
      ((F_NestSheetPartList) this).\u0002.Text = F_NestSheetPartList.Captions[1];
      ((F_NestSheetPartList) this).\u0006.Text = F_NestSheetPartList.Captions[2];
      ((F_NestSheetPartList) this).\u0004.Text = F_NestSheetPartList.Captions[3];
      ((F_NestSheetPartList) this).\u0001.Text = F_NestSheetPartList.Captions[4];
      ((F_NestSheetPartList) this).\u0002.Text = F_NestSheetPartList.Captions[5];
      ((F_NestSheetPartList) this).\u0001.Text = F_NestSheetPartList.Captions[6];
      ((F_NestSheetPartList) this).\u0002.Text = F_NestSheetPartList.Captions[7];
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
    if (control2.Name == ((F_NestSheetPartList) this).\u0001.Name)
    {
      ((GProfileOperation) ((ProfileSupportBlock) ((F_NestSheetPartList) this).Settings).AddMaterial).Quantity = (int) ((F_NestSheetPartList) this).\u0001.Value;
      ((GProfileOperation) ((ProfileSupportBlock) ((F_NestSheetPartList) this).Settings).AddMaterial).Thickness = (double) ((F_NestSheetPartList) this).\u0002.Value;
      ((GProfileOperation) ((ProfileSupportBlock) ((F_NestSheetPartList) this).Settings).AddMaterial).AddUselessEntities = ((F_NestSheetPartList) this).\u0001.Checked;
      ((GProfileOperation) ((ProfileSupportBlock) ((F_NestSheetPartList) this).Settings).AddMaterial).DeleteSelectedEntities = ((F_NestSheetPartList) this).\u0002.Checked;
      ((ProfileItem) ((ProfileItemCalc) ((F_NestSheetPartList) this).Sheet).MaterialData).Thickness = (double) ((F_NestSheetPartList) this).\u0002.Value;
      ((ProfileItem) ((ProfileItemCalc) ((F_NestSheetPartList) this).Sheet).MaterialData).Quantity = (int) ((F_NestSheetPartList) this).\u0001.Value;
      ((ProfileItem) ((ProfileItemCalc) ((F_NestSheetPartList) this).Sheet).MaterialData).Name = ((F_NestSheetPartList) this).txt_name.Text;
      if (((ProfileItem) ((ProfileItemCalc) ((F_NestSheetPartList) this).Sheet).MaterialData).Quantity <= 0)
      {
        buNumeric5.MessageBoxWarning(AppLanguage.CadCamMessages[37]);
        return;
      }
      if (((ProfileItem) ((ProfileItemCalc) ((F_NestSheetPartList) this).Sheet).MaterialData).Width <= 0.0)
      {
        buNumeric5.MessageBoxWarning(AppLanguage.CadCamMessages[38]);
        return;
      }
      if (((ProfileItem) ((ProfileItemCalc) ((F_NestSheetPartList) this).Sheet).MaterialData).Height <= 0.0)
      {
        buNumeric5.MessageBoxWarning(AppLanguage.CadCamMessages[39]);
        return;
      }
      if (((ProfileItem) ((ProfileItemCalc) ((F_NestSheetPartList) this).Sheet).MaterialData).Thickness <= 0.0 & ((F_NestSheetPartList) this).\u0003.Visible)
      {
        buNumeric5.MessageBoxWarning(AppLanguage.CadCamMessages[40]);
        return;
      }
      ((F_NestSheetPartList) this).PropertiesForm.Result = DialogResult.OK;
      if (((F_NestSheetPartList) this).PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
        this.Dispose();
      if (((F_NestSheetPartList) this).PropertiesForm.FormCloseMode == FormCloseModeType.Invisible)
        this.Visible = false;
    }
    if (!(control2.Name == ((F_NestSheetPartList) this).\u0002.Name))
      return;
    ((F_NestSheetPartList) this).PropertiesForm.Result = DialogResult.Cancel;
    if (((F_NestSheetPartList) this).PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
      this.Dispose();
    if (((F_NestSheetPartList) this).PropertiesForm.FormCloseMode != FormCloseModeType.Invisible)
      return;
    this.Visible = false;
  }

  internal void \u0001([In] object obj0, [In] FormClosingEventArgs obj1)
  {
    if (((F_NestSheetPartList) this).PropertiesForm.Result == DialogResult.OK)
      return;
    obj1.Cancel = true;
    ((F_NestSheetPartList) this).PropertiesForm.Result = DialogResult.Cancel;
    if (((F_NestSheetPartList) this).PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
      this.Dispose();
    if (((F_NestSheetPartList) this).PropertiesForm.FormCloseMode != FormCloseModeType.Invisible)
      return;
    this.Visible = false;
  }

  internal void \u0004([In] object obj0, [In] EventArgs obj1)
  {
    if (!((F_NestSheetPartList) this).PropertiesForm.Inited)
      return;
    buNestingVar Settings = (buNestingVar) new ProfileOperationDataBarel(((F_NestSheetPartList) this).Settings);
    ((ProfileOperationCamData) ((ProfileMultiply) Settings).Draw).SheetUselessShow = ((F_NestSheetPartList) this).\u0001.Checked;
    buCall.\u0001.DrawSheet(((F_NestSheetPartList) this).Sheet, Settings, ref ((F_NestSheetPartList) this).\u0001);
  }

  protected override void Dispose(bool disposing)
  {
    if ((!disposing ? 0 : (((F_NestSheetPartList) this).\u0001 != null ? 1 : 0)) != 0)
      ((F_NestSheetPartList) this).\u0001.Dispose();
    base.Dispose(disposing);
  }

  public event F_SettingTreeView.ApplyClickEvent ApplyClick;

  public event F_SettingTreeView.DefaultClickEvent DefaultClick;

  public delegate void ApplyClickEvent();

  public delegate void DefaultClickEvent();
}
