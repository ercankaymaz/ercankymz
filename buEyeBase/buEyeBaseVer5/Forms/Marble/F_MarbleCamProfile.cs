// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Forms.Marble.F_MarbleCamProfile
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using buEyeBaseVer5.Apps;
using buEyeBaseVer5.Apps.Marble;
using buEyeBaseVer5.Forms.MortiseTenon;
using buEyeBaseVer5.Forms.PanelCut;
using buEyeBaseVer5.Forms.Popup;
using devDept.Eyeshot.Control;
using devDept.Eyeshot.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Windows.Forms;

#nullable disable
namespace buEyeBaseVer5.Forms.Marble;

public class F_MarbleCamProfile : Form
{
  internal NumericUpDown \u0005;
  internal Label \u0007;
  internal NumericUpDown \u0006;
  public static byte f00191A;
  public FormProperties PropertiesForm;
  internal Timer \u0001;
  private int \u0001;
  private int \u0002;
  private Design \u0001;
  public buNestingVar Settings;
  public string AddPartFromFileExtender;
  public string AddSheetFromFileExtender;
  public string SaveFileExtender;
  public bool AddPartFromFileExtenderAsCsvType;
  public bool SendToCad;
  public int AddSheetFromFileExtensionIndex;
  public int SaveFileExtensionIndex;
  public string AddSheetFromFileFolder;
  public string SaveFileFolder;
  public nestCsvPartImportType CsvOpenTypeForAddNestingFromFile;
  public nestPartRotateType PartRotationDefault;
  public List<buNestingSheet> Sheets;
  public List<Entity> SendToCadEntities;
  public static List<string> Captions;
  public static List<string> CaptionGrid;
  internal IContainer \u0001;

  internal void \u0005([In] object obj0, [In] EventArgs obj1)
  {
    if (!((F_PanelCutSheetList) this).PropertiesForm.Inited)
      return;
    if (((F_PanelCutMaterials) this).cmb_tools.SelectedIndex >= 0 & ((F_PanelCutMaterials) this).cmb_tools.SelectedIndex <= ((F_PanelCutSheetList) this).Tools.Count - 1)
      ((F_PanelCutMaterials) this).activeTool = (ToolBase5) new ToolGeometry5(((F_PanelCutSheetList) this).Tools[((F_PanelCutMaterials) this).cmb_tools.SelectedIndex]);
    // ISSUE: reference to a compiler-generated field
    if (((F_PanelCutSheetList) this).\u0001 != null & ((F_PanelCutMaterials) this).activeTool != null)
    {
      ((MarbleTempVars) ProfileSettings.varProfileRunSettings).ShapeDataParameters.CamPars.Speeds.Feed = ((ToolLimits5) ((ToolGeometry5) ((F_PanelCutMaterials) this).activeTool).CamData).FeedSpeed;
      ((MarbleTempVars) ProfileSettings.varProfileRunSettings).ShapeDataParameters.CamPars.Speeds.Plunge = ((ToolPositions5) ((ToolGeometry5) ((F_PanelCutMaterials) this).activeTool).CamData).PlungeSpeed;
      ((buEyeBaseVer5.camSpeedsEnable) ((MarbleTempVars) ProfileSettings.varProfileRunSettings).ShapeDataParameters.CamPars.Speeds).Leave = ((ToolPositions5) ((ToolGeometry5) ((F_PanelCutMaterials) this).activeTool).CamData).LeaveSpeed;
      ((buEyeBaseVer5.camSpeedsEnable) ((MarbleTempVars) ProfileSettings.varProfileRunSettings).ShapeDataParameters.CamPars.Speeds).Finish = ((ToolLimits5) ((ToolGeometry5) ((F_PanelCutMaterials) this).activeTool).CamData).FinishSpeed;
      ((buEyeBaseVer5.camSpeedsEnable) ((MarbleTempVars) ProfileSettings.varProfileRunSettings).ShapeDataParameters.CamPars.Speeds).SpindleSpeed = ((ToolPositions5) ((ToolGeometry5) ((F_PanelCutMaterials) this).activeTool).CamData).SpindleSpeed;
      MarbleItem.CamAssinged = false;
      ShapeUpdateArg Data2 = (ShapeUpdateArg) new hmiUICommands();
      ((ShapeRuntimeData) Data2).Parameters = (ShapeRuntimeData) new hmiUICommands(((MarbleTempVars) ProfileSettings.varProfileRunSettings).ShapeDataParameters);
      ((ShapeRuntimeData) Data2).ToolName = ((ToolCamData5) ((ToolGeometry5) ((F_PanelCutMaterials) this).activeTool).Data).Name;
      ((ShapeRuntimeData) Data2).ToolChangeForced = true;
      ((ShapeRuntimeData) Data2).ToolIndex = ((F_PanelCutMaterials) this).cmb_tools.SelectedIndex;
      // ISSUE: reference to a compiler-generated field
      ((F_PanelCutSheetList) this).\u0001((object) null, (object) Data2, (object) null);
    }
    ((F_PanelCutSheetList) this).PropertiesForm.Inited = false;
    ((F_MarbleCam3DEngrave) this).Apply();
    ((F_PanelCutSheetList) this).PropertiesForm.Inited = true;
  }

  internal void \u0001([In] object obj0, [In] ListViewItemSelectionChangedEventArgs obj1)
  {
    if (!((F_PanelCutSheetList) this).PropertiesForm.Inited || !(obj1.ItemIndex >= 0 & obj1.IsSelected))
      return;
    ((F_PanelCutSheetList) this).PropertiesForm.Inited = false;
    ((F_MarbleCam3DEngrave) this).ShapeToDataGrid(obj1.ItemIndex);
    ((F_PanelCutMaterials) this).\u0001 = obj1.ItemIndex;
    ((F_PanelCutSheetList) this).PropertiesForm.Inited = true;
    ((dynamicInfo) F_NotchEdit.ShapeTempPar).ValueGridIndex = 0;
    ((ProfileSettings) buCall.\u0001).FindShapeDataValueType(((MarbleTempVars) ProfileSettings.varProfileRunSettings).ShapeDataParameters, 0, ref ((dynamicInfo) F_NotchEdit.ShapeTempPar).ValueType);
    ((MarbleTempVars) ProfileSettings.varProfileRunSettings).ShapeDataParameters.isTapping = false;
    ((SelectionEntity) ((MarbleTempVars) ProfileSettings.varProfileRunSettings).ShapeDataParameters).TextIsWire = false;
    if (obj1.ItemIndex == 10 && ((MarbleTempVars) ProfileSettings.varProfileRunSettings).ShapeDataParameters.ShapeType == ShapeTypes.Text)
      ((SelectionEntity) ((MarbleTempVars) ProfileSettings.varProfileRunSettings).ShapeDataParameters).TextIsWire = true;
    if (obj1.ItemIndex == 11 && ((MarbleTempVars) ProfileSettings.varProfileRunSettings).ShapeDataParameters.ShapeType == ShapeTypes.Hole)
      ((MarbleTempVars) ProfileSettings.varProfileRunSettings).ShapeDataParameters.isTapping = true;
    // ISSUE: reference to a compiler-generated field
    if (((F_PanelCutSheetList) this).\u0001 == null)
      return;
    ShapeUpdateArg Data2 = (ShapeUpdateArg) new hmiUICommands();
    ((MarbleTempVars) ProfileSettings.varProfileRunSettings).ShapeDataParameters.ValueType = ((dynamicInfo) F_NotchEdit.ShapeTempPar).ValueType;
    ((ShapeRuntimeData) Data2).Parameters = (ShapeRuntimeData) new hmiUICommands(((MarbleTempVars) ProfileSettings.varProfileRunSettings).ShapeDataParameters);
    // ISSUE: reference to a compiler-generated field
    ((F_PanelCutSheetList) this).\u0001((object) null, (object) Data2, (object) null);
  }

  public void GetRowColIndex(ref int indexRow, ref int indexCol)
  {
    indexCol = -1;
    indexRow = -1;
    if (((F_PanelCutMaterials) this).dgv_data.CurrentCell == null)
      return;
    indexRow = ((F_PanelCutMaterials) this).dgv_data.CurrentCell.RowIndex;
    indexCol = ((F_PanelCutMaterials) this).dgv_data.CurrentCell.ColumnIndex;
  }

  public void SetRowColIndex(int indexRow, int indexCol)
  {
    if (!(indexRow >= 0 & indexRow <= ((F_PanelCutMaterials) this).dgv_data.Rows.Count - 1) || !(indexCol >= 0 & indexCol <= ((F_PanelCutMaterials) this).dgv_data.Columns.Count - 1))
      return;
    ((F_PanelCutMaterials) this).dgv_data.CurrentCell = ((F_PanelCutMaterials) this).dgv_data.Rows[indexRow].Cells[indexCol];
  }

  protected override void Dispose(bool disposing)
  {
    if ((!disposing ? 0 : (((F_PanelCutMaterials) this).\u0001 != null ? 1 : 0)) != 0)
      ((F_PanelCutMaterials) this).\u0001.Dispose();
    base.Dispose(disposing);
  }

  static F_MarbleCamProfile() => F_PanelCutSheetList.Captions = new List<string>();

  public F_MarbleCamProfile()
  {
    ((F_SlotNoDepth) this).\u0001 = "F_PopupPreview";
    ((F_SlotNoDepth) this).PropertiesForm = new FormProperties();
    ((F_SlotNoDepth) this).\u0001 = (IContainer) null;
    // ISSUE: explicit constructor call
    base.\u002Ector();
    \u0007.\u0001.\u0001((F_PopupPreview) this);
  }

  public void UpdateVisuals()
  {
    string str = nameof (UpdateVisuals);
    try
    {
      if (clsVisualVars.parVisual == null)
        return;
      this.LoadLanguage();
    }
    catch (Exception ex)
    {
      buLogVer5.addToLog(((F_SlotNoDepth) this).\u0001, str, "Exception", ex.Message, ex.Data.ToString(), AddException: true);
      buException.throwException(ex, str, true, "");
    }
  }

  public void Init()
  {
    ((F_SlotNoDepth) this).PropertiesForm.Inited = false;
    if (((F_SlotNoDepth) this).PropertiesForm.Height > 10)
      this.Height = ((F_SlotNoDepth) this).PropertiesForm.Height;
    if (((F_SlotNoDepth) this).PropertiesForm.Width > 10)
      this.Width = ((F_SlotNoDepth) this).PropertiesForm.Width;
    this.TopMost = ((F_SlotNoDepth) this).PropertiesForm.TopMost;
    this.StartPosition = ((F_SlotNoDepth) this).PropertiesForm.FormPosition;
    this.LoadLanguage();
    ((F_SlotNoDepth) this).PropertiesForm.Result = DialogResult.None;
    ((F_SlotNoDepth) this).PropertiesForm.Inited = true;
  }

  public void LoadLanguage()
  {
    try
    {
    }
    catch (Exception ex)
    {
    }
  }

  internal void \u0001([In] object obj0, [In] FormClosingEventArgs obj1)
  {
    if (((F_SlotNoDepth) this).PropertiesForm.Result == DialogResult.OK)
      return;
    obj1.Cancel = true;
    ((F_SlotNoDepth) this).PropertiesForm.Result = DialogResult.Cancel;
    if (((F_SlotNoDepth) this).PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
      this.Dispose();
    if (((F_SlotNoDepth) this).PropertiesForm.FormCloseMode != FormCloseModeType.Invisible)
      return;
    this.Visible = false;
  }

  public event OkCommandWithFiveDataEventHandler CommandExecute;
}
