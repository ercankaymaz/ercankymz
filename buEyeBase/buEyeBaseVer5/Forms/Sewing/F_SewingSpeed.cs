// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Forms.Sewing.F_SewingSpeed
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using buControls.Controls;
using buEyeBaseVer5.buClipperLib;
using buEyeBaseVer5.buEntities;
using buEyeBaseVer5.Forms.Cam;
using buEyeBaseVer5.Forms.Holes;
using buEyeBaseVer5.Forms.KeyPad;
using buEyeBaseVer5.Forms.Location;
using buEyeBaseVer5.Forms.Shape;
using dummy_ptr;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;

#nullable disable
namespace buEyeBaseVer5.Forms.Sewing;

public class F_SewingSpeed : Form
{
  public buSpin spn_keyholediameter;
  public buSpin spn_keyholewidth;
  internal PictureBox \u000E;
  public TabPage tabPage_slot;
  public buSpin spn_arcbigradius;
  public buSpin spn_arcsmallradius;
  internal PictureBox \u000F;
  public buSpin spn_arcsweeoangle;
  public TabPage tabPage_arc;
  public static byte f0012BF;
  public FormProperties Properties;

  internal void \u0002([In] object obj0, [In] EventArgs obj1)
  {
    Control control = obj0 as Control;
    if (control.Name == ((F_ShapeAll) this).btn_ok.Name)
    {
      ((F_ShapeAll) this).PropertiesForm.Result = DialogResult.OK;
      if (((F_ShapeAll) this).ClosePageAfterOk)
      {
        if (((F_ShapeAll) this).PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
          this.Dispose();
        if (((F_ShapeAll) this).PropertiesForm.FormCloseMode == FormCloseModeType.Invisible)
          this.Visible = false;
      }
      // ISSUE: reference to a compiler-generated field
      if (((F_ShapeAll) this).\u0001 != null)
      {
        ((F_SewingCodes) this).DataGridValuesToShape(-1, -1);
        ShapeUpdateArg Data2 = (ShapeUpdateArg) new hmiUICommands(((F_ShapeAll) this).parShape);
        ((ShapeRuntimeData) Data2).Finished = true;
        // ISSUE: reference to a compiler-generated field
        ((F_ShapeAll) this).\u0001((object) ((F_ShapeAll) this).selectedShape, (object) Data2);
      }
      if (this.Owner != null)
        this.Owner.Focus();
    }
    if (control.Name == ((F_ShapeAll) this).btn_cancel.Name)
    {
      ((F_ShapeAll) this).PropertiesForm.Result = DialogResult.Cancel;
      if (((F_ShapeAll) this).PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
        this.Dispose();
      if (((F_ShapeAll) this).PropertiesForm.FormCloseMode == FormCloseModeType.Invisible)
        this.Visible = false;
      if (this.Owner != null)
        this.Owner.Focus();
      // ISSUE: reference to a compiler-generated field
      if (((F_ShapeAll) this).\u0001 != null)
      {
        // ISSUE: reference to a compiler-generated field
        ((F_ShapeAll) this).\u0001();
      }
    }
    if (control.Name == ((F_ShapeEdit) this).\u0001.Name)
    {
      F_CornerLocation fCornerLocation = (F_CornerLocation) new F_Contour();
      ((F_CabinetSettings) fCornerLocation).Corner = ((F_ShapeAll) this).parShape.selectedCorner;
      ((F_CabinetSettings) fCornerLocation).Properties.FormCloseMode = FormCloseModeType.Dispose;
      ((F_Contour) fCornerLocation).Init();
      int num = (int) fCornerLocation.ShowDialog((IWin32Window) this);
      if (((F_CabinetSettings) fCornerLocation).Properties.Result == DialogResult.OK)
      {
        ((buClipperBase) ((F_ShapeAll) this).selectedShape).Corner = ((F_CabinetSettings) fCornerLocation).Corner;
        ((F_ShapeAll) this).parShape.selectedCorner = ((F_CabinetSettings) fCornerLocation).Corner;
        ((F_ShapeEdit) this).\u0001.ImageIndex = Convert.ToInt32((object) ((F_ShapeAll) this).parShape.selectedCorner);
        // ISSUE: reference to a compiler-generated field
        if (((F_ShapeAll) this).\u0001 != null)
        {
          ((F_SewingCodes) this).DataGridValuesToShape(-1, -1);
          ShapeUpdateArg Data2 = (ShapeUpdateArg) new hmiUICommands(((F_ShapeAll) this).parShape);
          ((ShapeRuntimeData) Data2).Finished = false;
          // ISSUE: reference to a compiler-generated field
          ((F_ShapeAll) this).\u0001((object) ((F_ShapeAll) this).selectedShape, (object) Data2);
        }
      }
      this.Focus();
      if (this.Owner != null)
        this.Owner.Focus();
    }
    if (control.Name == ((F_ShapeEdit) this).\u0002.Name)
    {
      F_ObjectLocation fObjectLocation = (F_ObjectLocation) new F_Contour();
      ((F_KeyPadNumV1) fObjectLocation).Alingnment = ((F_ShapeAll) this).parShape.objectAlignment;
      ((F_KeyPadNumV1) fObjectLocation).Properties.FormCloseMode = FormCloseModeType.Dispose;
      ((F_Contour) fObjectLocation).Init();
      int num = (int) fObjectLocation.ShowDialog((IWin32Window) this);
      if (((F_KeyPadNumV1) fObjectLocation).Properties.Result == DialogResult.OK)
      {
        ((buClipperBase) ((F_ShapeAll) this).selectedShape).Alignment = ((F_KeyPadNumV1) fObjectLocation).Alingnment;
        ((F_ShapeAll) this).parShape.objectAlignment = ((F_KeyPadNumV1) fObjectLocation).Alingnment;
        ((F_ShapeEdit) this).\u0002.ImageIndex = Convert.ToInt32((object) ((F_ShapeAll) this).parShape.objectAlignment);
        // ISSUE: reference to a compiler-generated field
        if (((F_ShapeAll) this).\u0001 != null)
        {
          ((F_SewingCodes) this).DataGridValuesToShape(-1, -1);
          ShapeUpdateArg Data2 = (ShapeUpdateArg) new hmiUICommands(((F_ShapeAll) this).parShape);
          ((ShapeRuntimeData) Data2).Finished = false;
          // ISSUE: reference to a compiler-generated field
          ((F_ShapeAll) this).\u0001((object) ((F_ShapeAll) this).selectedShape, (object) Data2);
        }
      }
      this.Focus();
      if (this.Owner != null)
        this.Owner.Focus();
    }
    if (control.Name == ((F_ShapeEdit) this).\u0003.Name && ((F_ShapeAll) this).selectedShape is buShapeEngrave)
    {
      buShapeEngrave selectedShape = ((F_ShapeAll) this).selectedShape as buShapeEngrave;
      if (!((buClipperBase) selectedShape).isPocket)
        ((buClipperBase) selectedShape).isPocket = true;
      else
        ((buClipperBase) selectedShape).isPocket = false;
      ((F_ShapeEdit) this).\u0001.Checked = ((buClipperBase) selectedShape).isPocket;
      ((F_ShapeAll) this).parShape.isEngravePocket = ((buClipperBase) selectedShape).isPocket;
      ((F_SewingCodes) this).ShapeToDataGrid(((F_ShapeAll) this).\u0001);
      // ISSUE: reference to a compiler-generated field
      if (((F_ShapeAll) this).\u0001 != null)
      {
        ShapeUpdateArg Data2 = (ShapeUpdateArg) new hmiUICommands();
        ((ShapeRuntimeData) Data2).Parameters = (ShapeRuntimeData) new hmiUICommands(((F_ShapeAll) this).parShape);
        // ISSUE: reference to a compiler-generated field
        ((F_ShapeAll) this).\u0001((object) ((F_ShapeAll) this).selectedShape, (object) Data2);
      }
    }
    if (control.Name == ((F_ShapeEdit) this).btn_camsettings.Name)
    {
      F_CamSettings1 fCamSettings1 = (F_CamSettings1) new buEntity();
      ((buMultilineText) fCamSettings1).Properties.FormCloseMode = FormCloseModeType.Dispose;
      ((buMultilineText) fCamSettings1).CamPar = (camParameters5) new camRuntime5(((F_ShapeAll) this).CamPar);
      ((buEntity) fCamSettings1).Init();
      int num = (int) fCamSettings1.ShowDialog((IWin32Window) this);
      if (((buMultilineText) fCamSettings1).Properties.Result == DialogResult.OK)
      {
        ((buClipper) ((F_ShapeAll) this).selectedShape).CamPar = (camParameters5) new camRuntime5(((buMultilineText) fCamSettings1).CamPar);
        ((F_ShapeAll) this).CamPar = (camParameters5) new camRuntime5(((buMultilineText) fCamSettings1).CamPar);
      }
      this.Focus();
    }
    if (!(control.Name == ((F_ShapeEdit) this).btn_top.Name | control.Name == ((F_ShapeEdit) this).btn_bottom.Name | control.Name == ((F_ShapeEdit) this).btn_left.Name | control.Name == ((F_ShapeAll) this).btn_right.Name | control.Name == ((F_ShapeAll) this).btn_front.Name | control.Name == ((F_ShapeAll) this).btn_back.Name))
      return;
    if (control.Name == ((F_ShapeEdit) this).btn_top.Name)
      ((F_ShapeAll) this).parShape.selectedPlane = planeBoxNames.Top;
    if (control.Name == ((F_ShapeEdit) this).btn_bottom.Name)
      ((F_ShapeAll) this).parShape.selectedPlane = planeBoxNames.Bottom;
    if (control.Name == ((F_ShapeEdit) this).btn_left.Name)
      ((F_ShapeAll) this).parShape.selectedPlane = planeBoxNames.Left;
    if (control.Name == ((F_ShapeAll) this).btn_right.Name)
      ((F_ShapeAll) this).parShape.selectedPlane = planeBoxNames.Right;
    if (control.Name == ((F_ShapeAll) this).btn_front.Name)
      ((F_ShapeAll) this).parShape.selectedPlane = planeBoxNames.Front;
    if (control.Name == ((F_ShapeAll) this).btn_back.Name)
      ((F_ShapeAll) this).parShape.selectedPlane = planeBoxNames.Back;
    ((F_SewingCodes) this).PlaneColorUpdate();
    int valueGridIndex = ((dynamicInfo) F_NotchEdit.ShapeTempPar).ValueGridIndex;
    if (valueGridIndex >= 0 & valueGridIndex <= ((F_ShapeAll) this).\u0001.Rows.Count - 1)
    {
      ((buClipperBase) ((F_ShapeAll) this).selectedShape).planeName = ((F_ShapeAll) this).parShape.selectedPlane;
      ((buClipper) ((F_ShapeAll) this).selectedShape).planeOperation = buCall.\u0001.PlaneNameToPlane(((buClipperBase) ((F_ShapeAll) this).selectedShape).planeName);
      ((F_SewingCodes) this).ShapeToDataGrid(((F_ShapeAll) this).\u0001);
      ((dynamicInfo) F_NotchEdit.ShapeTempPar).ValueGridIndex = valueGridIndex;
      for (int index = 0; index <= ((F_ShapeAll) this).\u0001.Rows.Count - 1; ++index)
      {
        ((F_ShapeAll) this).\u0001.Rows[index].Cells[0].Selected = false;
        ((F_ShapeAll) this).\u0001.Rows[index].Cells[1].Selected = false;
      }
      ((F_ShapeAll) this).\u0001.Rows[valueGridIndex].Cells[0].Selected = true;
    }
    // ISSUE: reference to a compiler-generated field
    if (((F_ShapeAll) this).\u0001 == null)
      return;
    ShapeUpdateArg Data2_1 = (ShapeUpdateArg) new hmiUICommands(((F_ShapeAll) this).parShape);
    ((buClipperBase) ((F_ShapeAll) this).selectedShape).planeName = ((F_ShapeAll) this).parShape.selectedPlane;
    ((buClipper) ((F_ShapeAll) this).selectedShape).planeOperation = buCall.\u0001.PlaneNameToPlane(((F_ShapeAll) this).parShape.selectedPlane);
    ((buClipperBase) ((F_ShapeAll) this).selectedShape).Corner = ((F_ShapeAll) this).parShape.selectedCorner;
    ((buClipperBase) ((F_ShapeAll) this).selectedShape).Alignment = ((F_ShapeAll) this).parShape.objectAlignment;
    // ISSUE: reference to a compiler-generated field
    ((F_ShapeAll) this).\u0001((object) ((F_ShapeAll) this).selectedShape, (object) Data2_1);
  }

  protected override void Dispose(bool disposing)
  {
    if ((!disposing ? 0 : (((F_ShapeAll) this).\u0001 != null ? 1 : 0)) != 0)
      ((F_ShapeAll) this).\u0001.Dispose();
    base.Dispose(disposing);
  }

  static F_SewingSpeed() => F_ShapeAll.Captions = new List<string>();

  public F_SewingSpeed()
  {
    ((F_ShapeEdit) this).PropertiesForm = new FormProperties();
    ((F_ShapeEdit) this).ShowViewport = true;
    ((F_ShapeEdit) this).ShowCamSettings = true;
    ((F_ShapeEdit) this).ShowTool = false;
    ((F_ShapeEdit) this).ShowObjectPosition = true;
    ((F_ShapeEdit) this).ShowCornerLocation = true;
    ((F_ShapeEdit) this).EnableTopPlane = true;
    ((F_ShapeEdit) this).EnableBottomPlane = true;
    ((F_ShapeEdit) this).EnableLeftPlane = true;
    ((F_ShapeEdit) this).EnableRightPlane = true;
    ((F_ShapeEdit) this).EnableFrontPlane = true;
    ((F_ShapeEdit) this).EnableBacktPlane = true;
    ((F_ShapeEdit) this).ClosePageAfterOk = false;
    ((F_ShapeEdit) this).Tools = new List<ToolBase5>();
    ((F_ShapeEdit) this).activeTool = (ToolBase5) null;
    ((F_ShapeEdit) this).selectedShape = (buShape) null;
    ((F_ShapeEdit) this).CamPar = (camParameters5) null;
    ((F_ShapeEdit) this).parShape = (ShapeRuntimeData) new hmiUICommands();
    ((F_ShapeEdit) this).\u0001 = new System.Windows.Forms.Timer();
    ((F_ShapeEdit) this).\u0001 = -1;
    ((F_ShapeEdit) this).\u0001 = false;
    ((F_ShapeEdit) this).\u0001 = (IContainer) null;
    // ISSUE: explicit constructor call
    base.\u002Ector();
    \u0007.\u0001.\u0001((F_ProfilingList) this);
    ((F_ShapeEdit) this).\u0001.Interval = 100;
    ((F_ShapeEdit) this).\u0001.Tick += new EventHandler(this.\u0001);
  }

  [CompilerGenerated]
  [SpecialName]
  public void add_DataOk(OkCommandWithTwoDataEventHandler value)
  {
    // ISSUE: reference to a compiler-generated field
    OkCommandWithTwoDataEventHandler dataEventHandler = ((F_ShapeEdit) this).\u0001;
    OkCommandWithTwoDataEventHandler comparand;
    do
    {
      comparand = dataEventHandler;
      // ISSUE: reference to a compiler-generated field
      dataEventHandler = Interlocked.CompareExchange<OkCommandWithTwoDataEventHandler>(ref ((F_ShapeEdit) this).\u0001, comparand + value, comparand);
    }
    while (dataEventHandler != comparand);
  }

  [CompilerGenerated]
  [SpecialName]
  public void remove_DataOk(OkCommandWithTwoDataEventHandler value)
  {
    // ISSUE: reference to a compiler-generated field
    OkCommandWithTwoDataEventHandler dataEventHandler = ((F_ShapeEdit) this).\u0001;
    OkCommandWithTwoDataEventHandler comparand;
    do
    {
      comparand = dataEventHandler;
      // ISSUE: reference to a compiler-generated field
      dataEventHandler = Interlocked.CompareExchange<OkCommandWithTwoDataEventHandler>(ref ((F_ShapeEdit) this).\u0001, comparand - value, comparand);
    }
    while (dataEventHandler != comparand);
  }

  [CompilerGenerated]
  [SpecialName]
  public void add_DataCancel(CancelCommandEventHandler value)
  {
    // ISSUE: reference to a compiler-generated field
    CancelCommandEventHandler commandEventHandler = ((F_ShapeEdit) this).\u0001;
    CancelCommandEventHandler comparand;
    do
    {
      comparand = commandEventHandler;
      // ISSUE: reference to a compiler-generated field
      commandEventHandler = Interlocked.CompareExchange<CancelCommandEventHandler>(ref ((F_ShapeEdit) this).\u0001, comparand + value, comparand);
    }
    while (commandEventHandler != comparand);
  }

  [CompilerGenerated]
  [SpecialName]
  public void remove_DataCancel(CancelCommandEventHandler value)
  {
    // ISSUE: reference to a compiler-generated field
    CancelCommandEventHandler commandEventHandler = ((F_ShapeEdit) this).\u0001;
    CancelCommandEventHandler comparand;
    do
    {
      comparand = commandEventHandler;
      // ISSUE: reference to a compiler-generated field
      commandEventHandler = Interlocked.CompareExchange<CancelCommandEventHandler>(ref ((F_ShapeEdit) this).\u0001, comparand - value, comparand);
    }
    while (commandEventHandler != comparand);
  }

  public void Init()
  {
    ((F_ShapeEdit) this).PropertiesForm.Inited = false;
    if (((F_ShapeEdit) this).PropertiesForm.Height > 10)
      this.Height = ((F_ShapeEdit) this).PropertiesForm.Height;
    if (((F_ShapeEdit) this).PropertiesForm.Width > 10)
      this.Width = ((F_ShapeEdit) this).PropertiesForm.Width;
    this.TopMost = ((F_ShapeEdit) this).PropertiesForm.TopMost;
    this.StartPosition = ((F_ShapeEdit) this).PropertiesForm.FormPosition;
    ((F_DrillList) this).\u0001.Items.Clear();
    ((F_DrillList) this).\u0001.Items.Add($"{buLangTranslate.preDef.Rect} {buLangTranslate.preDef.Corner}", 0);
    ((F_DrillList) this).\u0001.Items.Add($"{buLangTranslate.preDef.Round} {buLangTranslate.preDef.Corner}", 1);
    ((F_DrillList) this).\u0001.Items.Add($"{buLangTranslate.preDef.Chamfer} {buLangTranslate.preDef.Corner}", 2);
    ((F_DrillList) this).\u0001.Items.Add($"{buLangTranslate.preDef.Concave} {buLangTranslate.preDef.Corner}", 3);
    ((F_DrillList) this).pnl_model.Visible = ((F_ShapeEdit) this).ShowViewport;
    ((F_DrillList) this).cmb_tools.Visible = ((F_ShapeEdit) this).ShowTool;
    ((F_DrillList) this).btn_camsettings.Visible = ((F_ShapeEdit) this).ShowCamSettings;
    ((F_DrillList) this).btn_toolsettings.Visible = ((F_ShapeEdit) this).ShowTool;
    ((F_DrillList) this).\u0002.Visible = ((F_ShapeEdit) this).ShowObjectPosition;
    ((F_DrillList) this).\u0001.Visible = ((F_ShapeEdit) this).ShowCornerLocation;
    ((F_DrillList) this).\u0002.ImageIndex = Convert.ToInt32((object) ((F_ShapeEdit) this).parShape.objectAlignment);
    ((F_DrillList) this).\u0001.ImageIndex = Convert.ToInt32((object) ((F_ShapeEdit) this).parShape.selectedCorner);
    ((F_DrillList) this).btn_back.Enabled = ((F_ShapeEdit) this).EnableBacktPlane;
    ((F_DrillList) this).btn_front.Enabled = ((F_ShapeEdit) this).EnableFrontPlane;
    ((F_DrillList) this).btn_top.Enabled = ((F_ShapeEdit) this).EnableTopPlane;
    ((F_DrillList) this).btn_bottom.Enabled = ((F_ShapeEdit) this).EnableBottomPlane;
    ((F_DrillList) this).btn_left.Enabled = ((F_ShapeEdit) this).EnableLeftPlane;
    ((F_DrillList) this).btn_right.Enabled = ((F_ShapeEdit) this).EnableRightPlane;
    if (((F_DrillList) this).\u0001.Columns.Count == 0)
    {
      DataGridViewColumn dataGridViewColumn1 = new DataGridViewColumn();
      dataGridViewColumn1.SortMode = DataGridViewColumnSortMode.NotSortable;
      dataGridViewColumn1.Width = Convert.ToInt32((double) ((F_DrillList) this).\u0001.Width * 0.65);
      dataGridViewColumn1.HeaderText = "Name";
      dataGridViewColumn1.Name = "Name";
      dataGridViewColumn1.ReadOnly = true;
      dataGridViewColumn1.DefaultCellStyle.Font = new Font("Arial", 10f, FontStyle.Bold);
      dataGridViewColumn1.CellTemplate = (DataGridViewCell) new DataGridViewTextBoxCell();
      ((F_DrillList) this).\u0001.Columns.Add(dataGridViewColumn1);
      DataGridViewColumn dataGridViewColumn2 = new DataGridViewColumn();
      dataGridViewColumn2.SortMode = DataGridViewColumnSortMode.NotSortable;
      dataGridViewColumn2.Width = ((F_DrillList) this).\u0001.Width - dataGridViewColumn1.Width - 20;
      dataGridViewColumn2.HeaderText = "Value";
      dataGridViewColumn2.Name = "Value";
      dataGridViewColumn2.ReadOnly = false;
      dataGridViewColumn2.DefaultCellStyle.Font = new Font("Arial", 10f, FontStyle.Bold);
      dataGridViewColumn2.CellTemplate = (DataGridViewCell) new DataGridViewTextBoxCell();
      ((F_DrillList) this).\u0001.Columns.Add(dataGridViewColumn2);
      ((F_DrillList) this).\u0001.CellValueChanged += new DataGridViewCellEventHandler(((F_SewingFootHeight) this).\u0001);
      ((F_DrillList) this).\u0001.CellClick += new DataGridViewCellEventHandler(((F_SewingFootHeight) this).\u0002);
      ((F_DrillList) this).\u0001.CellEnter += new DataGridViewCellEventHandler(((F_SewingFootHeight) this).\u0003);
    }
    ((F_DrillList) this).\u0001.RowHeadersVisible = false;
    ((F_DrillList) this).\u0001.ColumnHeadersVisible = false;
    ((F_DrillList) this).\u0001.AllowUserToAddRows = false;
    ((F_DrillList) this).\u0001.AllowUserToResizeColumns = false;
    ((F_DrillList) this).\u0001.AllowUserToResizeRows = false;
    ((F_DrillList) this).\u0001.ForeColor = Color.Red;
    if (((F_ShapeEdit) this).parShape.ProfilingType == ProfilingTypes.ProfilingRectangle)
    {
      ((F_DrillList) this).\u0001.Items[0].Focused = true;
      ((F_DrillList) this).\u0001.Items[0].Selected = true;
      ((F_DrillList) this).\u0001.FocusedItem = ((F_DrillList) this).\u0001.Items[0];
      ((F_ShapeEdit) this).\u0001 = 0;
    }
    else if (((F_ShapeEdit) this).parShape.ProfilingType == ProfilingTypes.ProfilingRound)
    {
      ((F_DrillList) this).\u0001.Items[1].Focused = true;
      ((F_DrillList) this).\u0001.Items[1].Selected = true;
      ((F_DrillList) this).\u0001.FocusedItem = ((F_DrillList) this).\u0001.Items[1];
      ((F_ShapeEdit) this).\u0001 = 1;
    }
    else if (((F_ShapeEdit) this).parShape.ProfilingType == ProfilingTypes.ProfilingChamfer)
    {
      ((F_DrillList) this).\u0001.Items[2].Focused = true;
      ((F_DrillList) this).\u0001.Items[2].Selected = true;
      ((F_DrillList) this).\u0001.FocusedItem = ((F_DrillList) this).\u0001.Items[2];
      ((F_ShapeEdit) this).\u0001 = 2;
    }
    else if (((F_ShapeEdit) this).parShape.ProfilingType == ProfilingTypes.ProfilingRoundConcave)
    {
      ((F_DrillList) this).\u0001.Items[3].Focused = true;
      ((F_DrillList) this).\u0001.Items[3].Selected = true;
      ((F_DrillList) this).\u0001.FocusedItem = ((F_DrillList) this).\u0001.Items[3];
      ((F_ShapeEdit) this).\u0001 = 3;
    }
    ((F_SewingFootHeight) this).ShapeToDataGrid(((F_ShapeEdit) this).\u0001);
    ((F_DrillList) this).cmb_tools.Items.Clear();
    if (((F_ShapeEdit) this).ShowTool)
    {
      int num = -1;
      for (int index = 0; index <= ((F_ShapeEdit) this).Tools.Count - 1; ++index)
      {
        ((F_DrillList) this).cmb_tools.Items.Add((object) $"{((ToolCamData5) ((ToolGeometry5) ((F_ShapeEdit) this).Tools[index]).Data).Name} - T{((ToolCamData5) ((ToolGeometry5) ((F_ShapeEdit) this).Tools[index]).Data).No.ToString()} - D: {((ToolGeometry5) ((F_ShapeEdit) this).Tools[index]).Geometry.Diameter.ToString("f1")}");
        if (((F_ShapeEdit) this).activeTool != null && ((ToolCamData5) ((ToolGeometry5) ((F_ShapeEdit) this).Tools[index]).Data).Name == ((ToolCamData5) ((ToolGeometry5) ((F_ShapeEdit) this).activeTool).Data).Name)
          num = index;
      }
      if (((F_DrillList) this).cmb_tools.Items.Count > 0)
        ((F_DrillList) this).cmb_tools.SelectedIndex = num;
      else
        ((F_ShapeEdit) this).ShowTool = false;
    }
    if (!((F_ShapeEdit) this).\u0001)
    {
      if (!((F_ShapeEdit) this).ShowViewport & !((F_ShapeEdit) this).ShowTool)
        ((F_DrillList) this).\u0001.Height = ((F_DrillList) this).\u0001.Height + ((F_DrillList) this).pnl_model.Height + ((F_DrillList) this).btn_toolsettings.Height;
      else if (!((F_ShapeEdit) this).ShowViewport & ((F_ShapeEdit) this).ShowTool)
        ((F_DrillList) this).\u0001.Height = ((F_DrillList) this).\u0001.Height + ((F_DrillList) this).pnl_model.Height;
      else if (((F_ShapeEdit) this).ShowViewport & !((F_ShapeEdit) this).ShowTool)
        ((F_DrillList) this).pnl_model.Height = ((F_DrillList) this).pnl_model.Height + ((F_DrillList) this).btn_toolsettings.Height;
      int int32 = Convert.ToInt32((double) this.Width / 6.0);
      ((F_DrillList) this).btn_back.Width = int32 - 10;
      ((F_DrillList) this).\u0005.Width = int32 - 10;
      ((F_DrillList) this).btn_bottom.Width = int32 - 10;
      ((F_DrillList) this).\u0007.Width = int32 - 10;
      ((F_DrillList) this).btn_front.Width = int32 - 10;
      ((F_DrillList) this).\u0006.Width = int32 - 10;
      ((F_DrillList) this).btn_left.Width = int32 - 10;
      ((F_DrillList) this).\u0004.Width = int32 - 10;
      ((F_DrillList) this).btn_right.Width = int32 - 10;
      ((F_DrillList) this).\u0002.Width = int32 - 10;
      ((F_DrillList) this).btn_top.Width = int32 - 10;
      ((F_DrillList) this).\u0003.Width = int32 - 10;
      ((F_DrillList) this).\u0003.Left = ((F_DrillList) this).btn_top.Left;
      ((F_DrillList) this).btn_bottom.Left = ((F_DrillList) this).btn_top.Left + ((F_DrillList) this).btn_top.Width + 5;
      ((F_DrillList) this).\u0007.Left = ((F_DrillList) this).btn_bottom.Left;
      ((F_DrillList) this).btn_front.Left = ((F_DrillList) this).btn_bottom.Left + ((F_DrillList) this).btn_bottom.Width + 5;
      ((F_DrillList) this).\u0006.Left = ((F_DrillList) this).btn_front.Left;
      ((F_DrillList) this).btn_back.Left = ((F_DrillList) this).btn_front.Left + ((F_DrillList) this).btn_front.Width + 5;
      ((F_DrillList) this).\u0005.Left = ((F_DrillList) this).btn_back.Left;
      ((F_DrillList) this).btn_left.Left = ((F_DrillList) this).btn_back.Left + ((F_DrillList) this).btn_back.Width + 5;
      ((F_DrillList) this).\u0004.Left = ((F_DrillList) this).btn_left.Left;
      ((F_DrillList) this).btn_right.Left = ((F_DrillList) this).btn_left.Left + ((F_DrillList) this).btn_left.Width + 5;
      ((F_DrillList) this).\u0002.Left = ((F_DrillList) this).btn_right.Left;
      ((F_ShapeEdit) this).\u0001 = true;
    }
    ((F_SewingFootHeight) this).LoadLanguage();
    ((F_SewingFootHeight) this).PlaneColorUpdate();
    ((F_ShapeEdit) this).\u0001.Enabled = true;
    ((F_ShapeEdit) this).PropertiesForm.Result = DialogResult.None;
  }

  private void \u0001([In] object obj0, [In] EventArgs obj1)
  {
    \u007B0e48b843\u002Dfb72\u002D498c\u002D834d\u002Dfc743ba0facc\u007D.\u0001((F_ProfilingList) this);
    ((F_ShapeEdit) this).btn_ok.Enabled = true;
    ((F_ShapeEdit) this).\u0001.Enabled = false;
    if (((F_ShapeEdit) this).parShape.selectedPlane == planeBoxNames.Top)
      ((F_SewingFootHeight) this).\u0002((object) ((F_DrillList) this).btn_top, obj1);
    if (((F_ShapeEdit) this).parShape.selectedPlane == planeBoxNames.Bottom)
      ((F_SewingFootHeight) this).\u0002((object) ((F_DrillList) this).btn_bottom, obj1);
    if (((F_ShapeEdit) this).parShape.selectedPlane == planeBoxNames.Front)
      ((F_SewingFootHeight) this).\u0002((object) ((F_DrillList) this).btn_front, obj1);
    if (((F_ShapeEdit) this).parShape.selectedPlane == planeBoxNames.Back)
      ((F_SewingFootHeight) this).\u0002((object) ((F_DrillList) this).btn_back, obj1);
    if (((F_ShapeEdit) this).parShape.selectedPlane == planeBoxNames.Left)
      ((F_SewingFootHeight) this).\u0002((object) ((F_DrillList) this).btn_left, obj1);
    if (((F_ShapeEdit) this).parShape.selectedPlane == planeBoxNames.Right)
      ((F_SewingFootHeight) this).\u0002((object) ((F_DrillList) this).btn_right, obj1);
    ((F_ShapeEdit) this).PropertiesForm.Inited = true;
  }

  internal void \u0001([In] object obj0, [In] FormClosingEventArgs obj1)
  {
    obj1.Cancel = true;
    ((F_ShapeEdit) this).PropertiesForm.Result = DialogResult.Cancel;
    if (((F_ShapeEdit) this).PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
      this.Dispose();
    if (((F_ShapeEdit) this).PropertiesForm.FormCloseMode == FormCloseModeType.Invisible)
    {
      this.Visible = false;
      if (this.Owner != null)
        this.Owner.Focus();
    }
    // ISSUE: reference to a compiler-generated field
    if (((F_ShapeEdit) this).\u0001 == null)
      return;
    // ISSUE: reference to a compiler-generated field
    ((F_ShapeEdit) this).\u0001();
  }

  public event OkCommandWithTwoDataEventHandler MoveCommad;

  public event CancelCommandEventHandler CancelCommad;
}
