// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Forms.F_PanelCutNestSheetPartList
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using buEyeBaseVer5.Apps;
using dummy_ptr;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Windows.Forms;

#nullable disable
namespace buEyeBaseVer5.Forms;

public class F_PanelCutNestSheetPartList : Form
{
  private int \u0001;
  internal int \u0002;
  private string \u0001;
  private bool \u0001;
  private buNestedResult \u0001;
  private buNestedSheet \u0001;
  private TreeNode \u0001;
  internal IContainer \u0001;
  public TreeView tree_nest;
  internal ContextMenuStrip \u0001;
  internal ToolStripMenuItem \u0001;
  internal ToolStripMenuItem \u0002;
  internal ToolStripSeparator \u0001;
  internal ToolStripMenuItem \u0003;
  internal ToolStripMenuItem \u0004;
  internal ToolStripSeparator \u0002;
  internal ToolStripMenuItem \u0005;
  internal ToolStripMenuItem \u0006;
  internal ToolStripSeparator \u0003;
  internal ToolStripMenuItem \u0007;
  internal ToolStripMenuItem \u0008;
  internal Button \u0001;
  internal Panel \u0001;
  internal Label \u0001;
  internal Button \u0002;
  internal Button \u0003;
  internal ImageList \u0001;
  internal Panel \u0002;
  public CheckBox chk_docam;
  internal ToolStripMenuItem \u000E;
  internal Panel \u0003;
  internal TextBox \u0001;
  internal Label \u0002;
  internal Button \u0004;
  internal Button \u0005;
  internal Button \u0006;
  internal Button \u0007;
  internal Button \u0008;
  public CheckBox chk_pdf;
  internal ToolStripSeparator \u0004;
  internal RadioButton \u0001;
  internal ComboBox \u0001;
  internal RadioButton \u0002;
  internal Label \u0003;
  public CheckBox chk_csv;
  internal Panel \u0004;
  public CheckBox chk_addentitiestoend;
  public CheckBox chk_clearalldrawing;
  internal Label \u0004;
  internal Panel \u0005;
  internal Label \u0005;
  internal Button \u000E;
  internal Label \u0006;
  internal NumericUpDown \u0001;
  internal Button \u000F;
  internal ToolStripSeparator \u0005;
  internal ToolStripMenuItem \u000F;
  public static byte f000D40;
  public FormProperties PropertiesForm;
  public static List<string> Captions;
  public List<string> NestedResultList;
  public string selectedItem;
  public string JobFolder;
  public string FileExtension;
  public buNestingVar Settings;
  internal IContainer \u0001;
  internal ImageList \u0001;
  public Button btn_close;
  public Button btn_select;
  internal ListBox \u0001;
  internal TextBox \u0001;
  internal Label \u0001;
  internal CheckBox \u0001;
  internal CheckBox \u0002;
  internal CheckBox \u0003;
  internal RadioButton \u0001;
  internal Panel \u0001;
  internal Label \u0002;
  internal Panel \u0002;
  internal RadioButton \u0002;
  internal Label \u0003;
  internal Label \u0004;
  internal Label \u0005;
  internal Label \u0006;
  internal PictureBox \u0001;
  internal PictureBox \u0002;
  internal CheckBox \u0004;
  internal CheckBox \u0005;
  public Button btn_preview;
  public static byte f000D61;
  public FormProperties PropertiesForm;
  public static List<string> Captions;

  public F_PanelCutNestSheetPartList()
  {
    ((F_LayerTufting) this).PropertiesForm = new FormProperties();
    ((F_LayerTufting) this).Vertical = false;
    ((F_LayerTufting) this).Horizontal = false;
    ((F_LayerTufting) this).Angle = false;
    ((F_LayerTufting) this).strRemoveCaption = "Do You Want to Remove Item";
    ((F_LayerTufting) this).\u0001 = (IContainer) null;
    // ISSUE: explicit constructor call
    base.\u002Ector();
    \u0007.\u0001.\u0001((F_PerpendicularSelection) this);
  }

  public void Init()
  {
    ((F_LayerTufting) this).PropertiesForm.Inited = false;
    if (((F_LayerTufting) this).PropertiesForm.Height > 10)
      this.Height = ((F_LayerTufting) this).PropertiesForm.Height;
    if (((F_LayerTufting) this).PropertiesForm.Width > 10)
      this.Width = ((F_LayerTufting) this).PropertiesForm.Width;
    this.TopMost = ((F_LayerTufting) this).PropertiesForm.TopMost;
    this.StartPosition = ((F_LayerTufting) this).PropertiesForm.FormPosition;
    ((F_LayerTufting) this).PropertiesForm.Result = DialogResult.None;
    \u0007.\u0001.\u0001((F_PerpendicularSelection) this);
    ((F_Material) this).\u0001.Checked = ((F_LayerTufting) this).Horizontal;
    ((F_Material) this).\u0002.Checked = ((F_LayerTufting) this).Vertical;
    ((F_Material) this).\u0003.Checked = ((F_LayerTufting) this).Angle;
    ((F_LayerTufting) this).PropertiesForm.Inited = true;
  }

  internal void \u0001([In] object obj0, [In] EventArgs obj1)
  {
    Control control1 = new Control();
    Control control2 = (Control) obj0;
    if (control2.Name == ((F_Material) this).btn_ok.Name)
    {
      \u0007.\u0001.\u0001((F_PerpendicularSelection) this);
      ((F_LayerTufting) this).PropertiesForm.Result = DialogResult.OK;
      if (((F_LayerTufting) this).PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
        this.Dispose();
      if (((F_LayerTufting) this).PropertiesForm.FormCloseMode == FormCloseModeType.Invisible)
        this.Visible = false;
    }
    if (!(control2.Name == ((F_Material) this).btn_cancel.Name))
      return;
    ((F_LayerTufting) this).PropertiesForm.Result = DialogResult.Cancel;
    if (((F_LayerTufting) this).PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
      this.Dispose();
    if (((F_LayerTufting) this).PropertiesForm.FormCloseMode != FormCloseModeType.Invisible)
      return;
    this.Visible = false;
  }

  internal void \u0001([In] object obj0, [In] FormClosingEventArgs obj1)
  {
    if (((F_LayerTufting) this).PropertiesForm.Result == DialogResult.OK)
      return;
    obj1.Cancel = true;
    ((F_LayerTufting) this).PropertiesForm.Result = DialogResult.Cancel;
    if (((F_LayerTufting) this).PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
      this.Dispose();
    if (((F_LayerTufting) this).PropertiesForm.FormCloseMode != FormCloseModeType.Invisible)
      return;
    this.Visible = false;
  }

  protected override void Dispose(bool disposing)
  {
    if ((!disposing ? 0 : (((F_LayerTufting) this).\u0001 != null ? 1 : 0)) != 0)
      ((F_LayerTufting) this).\u0001.Dispose();
    base.Dispose(disposing);
  }

  static F_PanelCutNestSheetPartList() => F_LayerTufting.Captions = new List<string>();

  public F_PanelCutNestSheetPartList()
  {
    ((F_Material) this).PropertiesForm = new FormProperties();
    ((F_Material) this).varCamPars = (camParameters5) null;
    ((F_Material) this).Tools = new List<ToolBase5>();
    ((F_Material) this).ToolSelected = (ToolBase5) null;
    ((F_Material) this).strRemoveCaption = "Do You Want to Remove Item";
    ((F_Material) this).SelectedToolIndex = -1;
    ((F_Material) this).\u0001 = (IContainer) null;
    // ISSUE: explicit constructor call
    base.\u002Ector();
    \u0007.\u0001.\u0001((F_RouterOperations) this);
  }

  public void Init()
  {
    ((F_Material) this).PropertiesForm.Inited = false;
    if (((F_Material) this).PropertiesForm.Height > 10)
      this.Height = ((F_Material) this).PropertiesForm.Height;
    if (((F_Material) this).PropertiesForm.Width > 10)
      this.Width = ((F_Material) this).PropertiesForm.Width;
    this.TopMost = ((F_Material) this).PropertiesForm.TopMost;
    this.StartPosition = ((F_Material) this).PropertiesForm.FormPosition;
    ((F_Material) this).PropertiesForm.Result = DialogResult.None;
    \u0007.\u0001.\u0001((F_RouterOperations) this);
    ((F_Material) this).ToolSelected = (ToolBase5) null;
    ((F_Material) this).\u0001.Items.Clear();
    for (int index = 0; index <= ((F_Material) this).Tools.Count - 1; ++index)
      ((F_Material) this).\u0001.Items.Add((object) ((ToolCamData5) ((ToolGeometry5) ((F_Material) this).Tools[index]).Data).Name);
    if (((F_Material) this).SelectedToolIndex >= 0 & ((F_Material) this).Tools.Count > 0 & ((F_Material) this).SelectedToolIndex <= ((F_Material) this).Tools.Count - 1)
      ((F_Material) this).\u0001.SelectedIndex = ((F_Material) this).SelectedToolIndex;
    ((F_NestedResults) this).\u0001.Items.Clear();
    ((F_NestedResults) this).\u0001.Items.Add((object) "Level");
    ((F_NestedResults) this).\u0001.Items.Add((object) "Region");
    this.ParametersToControl();
    ((F_Material) this).PropertiesForm.Inited = true;
  }

  public void ParametersToControl()
  {
    if (((F_Material) this).SelectedToolIndex >= 0 & ((F_Material) this).Tools.Count > 0 & ((F_Material) this).SelectedToolIndex <= ((F_Material) this).Tools.Count - 1)
      ((F_Material) this).ToolSelected = (ToolBase5) new ToolGeometry5(((F_Material) this).Tools[((F_Material) this).SelectedToolIndex]);
    if (((F_Material) this).varCamPars.Strategy.MachiningAreaMode == CamMachiningAreaMode.MachByLanes)
      ((F_NestedResults) this).\u0001.SelectedIndex = 0;
    else
      ((F_NestedResults) this).\u0001.SelectedIndex = 1;
    ((F_NestedResults) this).\u0006.Checked = ((camOptions5) ((F_Material) this).varCamPars.Operations).SpiralMode;
    ((F_Material) this).\u0008.Value = (Decimal) ((camPocket5) ((camRuntime5) ((F_Material) this).varCamPars).Material).Thickness;
    ((F_Material) this).\u0002.Value = (Decimal) ((F_Material) this).varCamPars.Operations.Depth;
    ((F_Material) this).\u0007.Value = (Decimal) ((F_Material) this).varCamPars.Operations.BaseThickness;
    ((F_NestedResults) this).\u000E.Value = (Decimal) ((F_Material) this).varCamPars.Operations.Width;
    ((F_NestedResults) this).\u000F.Value = (Decimal) ((camSpeeds5) ((F_Material) this).varCamPars.Steps).Count;
    ((F_Material) this).\u0001.Checked = ((F_Material) this).varCamPars.Options.Vacuum1;
    ((F_NestedResults) this).\u0003.Checked = ((F_Material) this).varCamPars.Options.Vacuum2;
    ((F_Material) this).\u0002.Checked = ((F_Material) this).varCamPars.Options.Vacuum2;
    if (((F_Material) this).ToolSelected == null)
      return;
    ((F_Material) this).\u0005.Value = (Decimal) ((ToolLimits5) ((ToolGeometry5) ((F_Material) this).ToolSelected).CamData).FeedSpeed;
    ((F_Material) this).\u0004.Value = (Decimal) ((ToolPositions5) ((ToolGeometry5) ((F_Material) this).ToolSelected).CamData).PlungeSpeed;
    ((F_Material) this).\u0003.Value = (Decimal) ((LayerBase5) ((ToolGeometry5) ((F_Material) this).ToolSelected).CamData).SafeDistance;
    ((F_Material) this).\u0006.Value = (Decimal) ((ToolPositions5) ((ToolGeometry5) ((F_Material) this).ToolSelected).CamData).SpindleSpeed;
    ((F_Material) this).\u0001.Value = (Decimal) ((ToolCamData5) ((ToolGeometry5) ((F_Material) this).ToolSelected).Data).No;
    ((F_NestedResults) this).\u0005.Checked = ((LayerBase5) ((ToolGeometry5) ((F_Material) this).ToolSelected).CamData).Air;
    ((F_NestedResults) this).\u0004.Checked = ((LayerBase5) ((ToolGeometry5) ((F_Material) this).ToolSelected).CamData).Dust;
  }

  internal void \u0001([In] object obj0, [In] EventArgs obj1)
  {
    Control control1 = new Control();
    Control control2 = (Control) obj0;
    if (control2.Name == ((F_Material) this).btn_ok.Name)
    {
      \u0007.\u0001.\u0001((F_RouterOperations) this);
      ((F_Material) this).PropertiesForm.Result = DialogResult.OK;
      if (((F_Material) this).PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
        this.Dispose();
      if (((F_Material) this).PropertiesForm.FormCloseMode == FormCloseModeType.Invisible)
        this.Visible = false;
    }
    if (control2.Name == ((F_Material) this).btn_cancel.Name)
    {
      ((F_Material) this).PropertiesForm.Result = DialogResult.Cancel;
      if (((F_Material) this).PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
        this.Dispose();
      if (((F_Material) this).PropertiesForm.FormCloseMode == FormCloseModeType.Invisible)
        this.Visible = false;
    }
    if (!(control2.Name == ((F_NestedResults) this).btn_vacuumall.Name))
      return;
    ((F_Material) this).\u0001.Checked = true;
    ((F_NestedResults) this).\u0003.Checked = true;
    ((F_Material) this).\u0002.Checked = true;
  }

  internal void \u0001([In] object obj0, [In] FormClosingEventArgs obj1)
  {
    if (((F_Material) this).PropertiesForm.Result == DialogResult.OK)
      return;
    obj1.Cancel = true;
    ((F_Material) this).PropertiesForm.Result = DialogResult.Cancel;
    if (((F_Material) this).PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
      this.Dispose();
    if (((F_Material) this).PropertiesForm.FormCloseMode != FormCloseModeType.Invisible)
      return;
    this.Visible = false;
  }

  internal void \u0002([In] object obj0, [In] EventArgs obj1)
  {
    if (!((F_Material) this).PropertiesForm.Inited)
      return;
    ((F_Material) this).SelectedToolIndex = ((F_Material) this).\u0001.SelectedIndex;
    ((F_Material) this).ToolSelected = (ToolBase5) new ToolGeometry5(((F_Material) this).Tools[((F_Material) this).SelectedToolIndex]);
    if (((F_Material) this).ToolSelected == null)
      return;
    ((F_Material) this).\u0005.Value = (Decimal) ((ToolLimits5) ((ToolGeometry5) ((F_Material) this).ToolSelected).CamData).FeedSpeed;
    ((F_Material) this).\u0004.Value = (Decimal) ((ToolPositions5) ((ToolGeometry5) ((F_Material) this).ToolSelected).CamData).PlungeSpeed;
    ((F_Material) this).\u0003.Value = (Decimal) ((LayerBase5) ((ToolGeometry5) ((F_Material) this).ToolSelected).CamData).SafeDistance;
    ((F_Material) this).\u0006.Value = (Decimal) ((ToolPositions5) ((ToolGeometry5) ((F_Material) this).ToolSelected).CamData).SpindleSpeed;
    ((F_Material) this).\u0001.Value = (Decimal) ((ToolCamData5) ((ToolGeometry5) ((F_Material) this).ToolSelected).Data).No;
    ((F_NestedResults) this).\u0005.Checked = ((LayerBase5) ((ToolGeometry5) ((F_Material) this).ToolSelected).CamData).Air;
    ((F_NestedResults) this).\u0004.Checked = ((LayerBase5) ((ToolGeometry5) ((F_Material) this).ToolSelected).CamData).Dust;
  }

  protected override void Dispose(bool disposing)
  {
    if ((!disposing ? 0 : (((F_Material) this).\u0001 != null ? 1 : 0)) != 0)
      ((F_Material) this).\u0001.Dispose();
    base.Dispose(disposing);
  }

  static F_PanelCutNestSheetPartList() => F_Material.Captions = new List<string>();

  public F_PanelCutNestSheetPartList()
  {
    ((F_NestedResults) this).layer = (LayerBase5) new EntityShapeInfo();
    ((F_NestedResults) this).PropertiesForm = new FormProperties();
    ((F_NestedResults) this).\u0001 = (IContainer) null;
    // ISSUE: explicit constructor call
    base.\u002Ector();
    \u007B0e48b843\u002Dfb72\u002D498c\u002D834d\u002Dfc743ba0facc\u007D.\u0001((F_LayerRouter3X) this);
  }

  public void Init()
  {
    ((F_NestedResults) this).PropertiesForm.Inited = false;
    if (((F_NestedResults) this).PropertiesForm.Height > 10)
      this.Height = ((F_NestedResults) this).PropertiesForm.Height;
    if (((F_NestedResults) this).PropertiesForm.Width > 10)
      this.Width = ((F_NestedResults) this).PropertiesForm.Width;
    this.TopMost = ((F_NestedResults) this).PropertiesForm.TopMost;
    this.StartPosition = ((F_NestedResults) this).PropertiesForm.FormPosition;
    ((F_NestedResults) this).\u0008.BackColor = ((DevideEventFormVars) ((F_NestedResults) this).layer).LayerColor;
    ((F_NestedResults) this).\u0008.Text = buFile5.GetColorKnownName(((DevideEventFormVars) ((F_NestedResults) this).layer).LayerColor);
    ((F_NestedResults) this).\u0008.ForeColor = buFile5.InvertColorNoGray(((DevideEventFormVars) ((F_NestedResults) this).layer).LayerColor);
    ((F_NestedResults) this).\u0001.Value = (Decimal) ((DevideEventFormVars) ((F_NestedResults) this).layer).LayerThickness;
    ((F_NestedResults) this).\u0002.Value = (Decimal) ((DevideEventFormVars) ((F_NestedResults) this).layer).Transparency;
    ((F_NestedResults) this).\u0001.Text = ((DevideEventFormVars) ((F_NestedResults) this).layer).Name;
    ((F_NestedResults) this).\u0001.Checked = ((ScaleEventFormVars) ((F_NestedResults) this).layer).Enable;
    ((F_NestedResults) this).\u0002.Checked = ((ScaleEventFormVars) ((F_NestedResults) this).layer).Lock;
    ((F_NestedResults) this).\u0001.Enabled = true;
    if (((DeleteTypeEventFormVars) ((F_NestedResults) this).layer).Router3AX != null)
    {
      List<string> EnumItems = new List<string>();
      buCompare5.GetEnumTypeValues((object) ((DeleteTypeEventFormVars) ((F_NestedResults) this).layer).Router3AX.Purpose, ref EnumItems);
      ((F_NestedResults) this).\u0001.Items.Clear();
      for (int index = 0; index <= EnumItems.Count - 1; ++index)
        ((F_NestedResults) this).\u0001.Items.Add((object) EnumItems[index]);
      if (((DeleteTypeEventFormVars) ((F_NestedResults) this).layer).Router3AX != null)
        ((F_NestedResults) this).\u0001.Text = ((DeleteTypeEventFormVars) ((F_NestedResults) this).layer).Router3AX.Purpose.ToString();
    }
    if (((F_NestedResults) this).\u0001.Items.Count == 0)
      ((F_NestedResults) this).\u0001.Enabled = false;
    this.LoadLanguage();
    ((F_NestedResults) this).PropertiesForm.Result = DialogResult.None;
    ((F_NestedResults) this).PropertiesForm.Inited = true;
  }

  internal void \u0001([In] object obj0, [In] FormClosingEventArgs obj1)
  {
    if (((F_NestedResults) this).PropertiesForm.Result == DialogResult.OK)
      return;
    obj1.Cancel = true;
    ((F_NestedResults) this).PropertiesForm.Result = DialogResult.Cancel;
    if (((F_NestedResults) this).PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
      this.Dispose();
    if (((F_NestedResults) this).PropertiesForm.FormCloseMode != FormCloseModeType.Invisible)
      return;
    this.Visible = false;
  }

  public void LoadLanguage()
  {
    string callMethod = "Layer LoadLanguage";
    try
    {
      if (F_NestedResults.Captions.Count <= 6)
        return;
      this.Text = F_NestedResults.Captions[0];
      ((F_NestedResults) this).\u0003.Text = F_NestedResults.Captions[1];
      ((F_NestedResults) this).\u0004.Text = F_NestedResults.Captions[2];
      ((F_NestedResults) this).\u0005.Text = F_NestedResults.Captions[3];
      ((F_NestedResults) this).\u0002.Text = F_NestedResults.Captions[4];
      ((F_NestedResults) this).\u0001.Text = F_NestedResults.Captions[5];
      ((F_NestedResults) this).\u0006.Text = F_NestedResults.Captions[9];
      ((F_NestedResults) this).btn_ok.Text = F_NestedResults.Captions[10];
      ((F_NestedResults) this).btn_cancel.Text = F_NestedResults.Captions[11];
    }
    catch (Exception ex)
    {
      string str = "";
      buLog.addLog(str, "Not Ok", callMethod);
      buException.throwException(ex, callMethod, true, str);
    }
  }
}
