// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Forms.Sewing.F_SewingSelectVertex
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using buEyeBaseVer5.buEntities;
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

public class F_SewingSelectVertex : Form
{
  internal ImageList \u0001;
  internal RadioButton \u0001;
  internal RadioButton \u0002;
  internal CheckBox \u0001;
  internal Panel \u0001;
  internal Panel \u0002;
  internal Label \u0001;
  internal NumericUpDown \u0001;
  internal Label \u0002;
  internal NumericUpDown \u0002;
  internal Label \u0003;

  internal void \u0001([In] object obj0, [In] ListViewItemSelectionChangedEventArgs obj1)
  {
    if (!((F_ShapeEdit) this).PropertiesForm.Inited || !(obj1.ItemIndex >= 0 & obj1.IsSelected))
      return;
    ((F_SewingFootHeight) this).ShapeToDataGrid(obj1.ItemIndex);
    ((F_ShapeEdit) this).\u0001 = obj1.ItemIndex;
    // ISSUE: reference to a compiler-generated field
    if (((F_ShapeEdit) this).\u0001 == null)
      return;
    ShapeUpdateArg Data2 = (ShapeUpdateArg) new hmiUICommands();
    ((ShapeRuntimeData) Data2).Parameters = (ShapeRuntimeData) new hmiUICommands(((F_ShapeEdit) this).parShape);
    // ISSUE: reference to a compiler-generated field
    ((F_ShapeEdit) this).\u0001((object) ((F_ShapeEdit) this).selectedShape, (object) Data2);
  }

  protected override void Dispose(bool disposing)
  {
    if ((!disposing ? 0 : (((F_ShapeEdit) this).\u0001 != null ? 1 : 0)) != 0)
      ((F_ShapeEdit) this).\u0001.Dispose();
    base.Dispose(disposing);
  }

  static F_SewingSelectVertex() => F_ShapeEdit.Captions = new List<string>();

  public F_SewingSelectVertex()
  {
    ((F_DrillList) this).PropertiesForm = new FormProperties();
    ((F_DrillList) this).ShowViewport = true;
    ((F_DrillList) this).ShowCamSettings = true;
    ((F_DrillList) this).ShowTool = false;
    ((F_DrillList) this).ShowObjectPosition = true;
    ((F_DrillList) this).ShowCornerLocation = true;
    ((F_DrillList) this).EnableTopPlane = true;
    ((F_DrillList) this).EnableBottomPlane = true;
    ((F_DrillList) this).EnableLeftPlane = true;
    ((F_DrillList) this).EnableRightPlane = true;
    ((F_DrillList) this).EnableFrontPlane = true;
    ((F_DrillList) this).EnableBacktPlane = true;
    ((F_DrillList) this).ClosePageAfterOk = false;
    ((F_DrillList) this).Tools = new List<ToolBase5>();
    ((F_DrillList) this).activeTool = (ToolBase5) null;
    ((F_DrillList) this).selectedShape = (buShape) null;
    ((F_DrillList) this).CamPar = (camParameters5) null;
    ((F_DrillList) this).parShape = (ShapeRuntimeData) new hmiUICommands();
    ((F_DrillList) this).\u0001 = new System.Windows.Forms.Timer();
    ((F_DrillList) this).\u0001 = -1;
    ((F_DrillList) this).\u0001 = false;
    ((F_DrillList) this).\u0001 = (IContainer) null;
    // ISSUE: explicit constructor call
    base.\u002Ector();
    \u007B0e48b843\u002Dfb72\u002D498c\u002D834d\u002Dfc743ba0facc\u007D.\u0001((F_CutList) this);
    ((F_DrillList) this).\u0001.Interval = 100;
    ((F_DrillList) this).\u0001.Tick += new EventHandler(this.\u0001);
  }

  [CompilerGenerated]
  [SpecialName]
  public void add_DataOk(OkCommandWithTwoDataEventHandler value)
  {
    // ISSUE: reference to a compiler-generated field
    OkCommandWithTwoDataEventHandler dataEventHandler = ((F_DrillList) this).\u0001;
    OkCommandWithTwoDataEventHandler comparand;
    do
    {
      comparand = dataEventHandler;
      // ISSUE: reference to a compiler-generated field
      dataEventHandler = Interlocked.CompareExchange<OkCommandWithTwoDataEventHandler>(ref ((F_DrillList) this).\u0001, comparand + value, comparand);
    }
    while (dataEventHandler != comparand);
  }

  [CompilerGenerated]
  [SpecialName]
  public void remove_DataOk(OkCommandWithTwoDataEventHandler value)
  {
    // ISSUE: reference to a compiler-generated field
    OkCommandWithTwoDataEventHandler dataEventHandler = ((F_DrillList) this).\u0001;
    OkCommandWithTwoDataEventHandler comparand;
    do
    {
      comparand = dataEventHandler;
      // ISSUE: reference to a compiler-generated field
      dataEventHandler = Interlocked.CompareExchange<OkCommandWithTwoDataEventHandler>(ref ((F_DrillList) this).\u0001, comparand - value, comparand);
    }
    while (dataEventHandler != comparand);
  }

  [CompilerGenerated]
  [SpecialName]
  public void add_DataCancel(CancelCommandEventHandler value)
  {
    // ISSUE: reference to a compiler-generated field
    CancelCommandEventHandler commandEventHandler = ((F_DrillList) this).\u0001;
    CancelCommandEventHandler comparand;
    do
    {
      comparand = commandEventHandler;
      // ISSUE: reference to a compiler-generated field
      commandEventHandler = Interlocked.CompareExchange<CancelCommandEventHandler>(ref ((F_DrillList) this).\u0001, comparand + value, comparand);
    }
    while (commandEventHandler != comparand);
  }

  [CompilerGenerated]
  [SpecialName]
  public void remove_DataCancel(CancelCommandEventHandler value)
  {
    // ISSUE: reference to a compiler-generated field
    CancelCommandEventHandler commandEventHandler = ((F_DrillList) this).\u0001;
    CancelCommandEventHandler comparand;
    do
    {
      comparand = commandEventHandler;
      // ISSUE: reference to a compiler-generated field
      commandEventHandler = Interlocked.CompareExchange<CancelCommandEventHandler>(ref ((F_DrillList) this).\u0001, comparand - value, comparand);
    }
    while (commandEventHandler != comparand);
  }

  public void Init()
  {
    ((F_DrillList) this).PropertiesForm.Inited = false;
    if (((F_DrillList) this).PropertiesForm.Height > 10)
      this.Height = ((F_DrillList) this).PropertiesForm.Height;
    if (((F_DrillList) this).PropertiesForm.Width > 10)
      this.Width = ((F_DrillList) this).PropertiesForm.Width;
    this.TopMost = ((F_DrillList) this).PropertiesForm.TopMost;
    this.StartPosition = ((F_DrillList) this).PropertiesForm.FormPosition;
    ((F_ShapeList) this).\u0001.Items.Clear();
    ((F_ShapeList) this).\u0001.Items.Add($"{buLangTranslate.preDef.Horizontal} {buLangTranslate.preDef.Slot}", 0);
    ((F_ShapeList) this).\u0001.Items.Add($"{buLangTranslate.preDef.Horizontal} {buLangTranslate.preDef.Line} {buLangTranslate.preDef.Slot}", 1);
    ((F_ShapeList) this).\u0001.Items.Add($"{buLangTranslate.preDef.Vertical} {buLangTranslate.preDef.Slot}", 2);
    ((F_ShapeList) this).\u0001.Items.Add($"{buLangTranslate.preDef.Vertical} {buLangTranslate.preDef.Line} {buLangTranslate.preDef.Slot}", 3);
    ((F_ShapeList) this).\u0001.Items.Add($"{buLangTranslate.preDef.Free} {buLangTranslate.preDef.Slot}", 4);
    ((F_ShapeList) this).pnl_model.Visible = ((F_DrillList) this).ShowViewport;
    ((F_ShapeList) this).cmb_tools.Visible = ((F_DrillList) this).ShowTool;
    ((F_ShapeList) this).btn_camsettings.Visible = ((F_DrillList) this).ShowCamSettings;
    ((F_ShapeList) this).btn_toolsettings.Visible = ((F_DrillList) this).ShowTool;
    ((F_ShapeList) this).\u0002.Visible = ((F_DrillList) this).ShowObjectPosition;
    ((F_ShapeList) this).\u0001.Visible = ((F_DrillList) this).ShowCornerLocation;
    ((F_ShapeList) this).\u0002.ImageIndex = Convert.ToInt32((object) ((F_DrillList) this).parShape.objectAlignment);
    ((F_ShapeList) this).\u0001.ImageIndex = Convert.ToInt32((object) ((F_DrillList) this).parShape.selectedCorner);
    ((F_ShapeList) this).btn_back.Enabled = ((F_DrillList) this).EnableBacktPlane;
    ((F_ShapeList) this).btn_front.Enabled = ((F_DrillList) this).EnableFrontPlane;
    ((F_ShapeList) this).btn_top.Enabled = ((F_DrillList) this).EnableTopPlane;
    ((F_ShapeList) this).btn_bottom.Enabled = ((F_DrillList) this).EnableBottomPlane;
    ((F_ShapeList) this).btn_left.Enabled = ((F_DrillList) this).EnableLeftPlane;
    ((F_ShapeList) this).btn_right.Enabled = ((F_DrillList) this).EnableRightPlane;
    if (((F_ShapeList) this).\u0001.Columns.Count == 0)
    {
      DataGridViewColumn dataGridViewColumn1 = new DataGridViewColumn();
      dataGridViewColumn1.SortMode = DataGridViewColumnSortMode.NotSortable;
      dataGridViewColumn1.Width = Convert.ToInt32((double) ((F_ShapeList) this).\u0001.Width * 0.65);
      dataGridViewColumn1.HeaderText = "Name";
      dataGridViewColumn1.Name = "Name";
      dataGridViewColumn1.ReadOnly = true;
      dataGridViewColumn1.DefaultCellStyle.Font = new Font("Arial", 10f, FontStyle.Bold);
      dataGridViewColumn1.CellTemplate = (DataGridViewCell) new DataGridViewTextBoxCell();
      ((F_ShapeList) this).\u0001.Columns.Add(dataGridViewColumn1);
      DataGridViewColumn dataGridViewColumn2 = new DataGridViewColumn();
      dataGridViewColumn2.SortMode = DataGridViewColumnSortMode.NotSortable;
      dataGridViewColumn2.Width = ((F_ShapeList) this).\u0001.Width - dataGridViewColumn1.Width - 20;
      dataGridViewColumn2.HeaderText = "Value";
      dataGridViewColumn2.Name = "Value";
      dataGridViewColumn2.ReadOnly = false;
      dataGridViewColumn2.DefaultCellStyle.Font = new Font("Arial", 10f, FontStyle.Bold);
      dataGridViewColumn2.CellTemplate = (DataGridViewCell) new DataGridViewTextBoxCell();
      ((F_ShapeList) this).\u0001.Columns.Add(dataGridViewColumn2);
      ((F_ShapeList) this).\u0001.CellValueChanged += new DataGridViewCellEventHandler(((F_SewingRotate) this).\u0001);
      ((F_ShapeList) this).\u0001.CellClick += new DataGridViewCellEventHandler(((F_SewingRotate) this).\u0002);
      ((F_ShapeList) this).\u0001.CellEnter += new DataGridViewCellEventHandler(((F_SewingRotate) this).\u0003);
    }
    ((F_ShapeList) this).\u0001.RowHeadersVisible = false;
    ((F_ShapeList) this).\u0001.ColumnHeadersVisible = false;
    ((F_ShapeList) this).\u0001.AllowUserToAddRows = false;
    ((F_ShapeList) this).\u0001.AllowUserToResizeColumns = false;
    ((F_ShapeList) this).\u0001.AllowUserToResizeRows = false;
    ((F_ShapeList) this).\u0001.ForeColor = Color.Red;
    if (((F_DrillList) this).parShape.CutType == CutTypes.CutHorizontal)
    {
      ((F_ShapeList) this).\u0001.Items[0].Focused = true;
      ((F_ShapeList) this).\u0001.Items[0].Selected = true;
      ((F_ShapeList) this).\u0001.FocusedItem = ((F_ShapeList) this).\u0001.Items[0];
      ((F_DrillList) this).\u0001 = 0;
    }
    else if (((F_DrillList) this).parShape.CutType == CutTypes.CutHorizontalLine)
    {
      ((F_ShapeList) this).\u0001.Items[1].Focused = true;
      ((F_ShapeList) this).\u0001.Items[1].Selected = true;
      ((F_ShapeList) this).\u0001.FocusedItem = ((F_ShapeList) this).\u0001.Items[1];
      ((F_DrillList) this).\u0001 = 1;
    }
    else if (((F_DrillList) this).parShape.CutType == CutTypes.CutVertical)
    {
      ((F_ShapeList) this).\u0001.Items[2].Focused = true;
      ((F_ShapeList) this).\u0001.Items[2].Selected = true;
      ((F_ShapeList) this).\u0001.FocusedItem = ((F_ShapeList) this).\u0001.Items[2];
      ((F_DrillList) this).\u0001 = 2;
    }
    else if (((F_DrillList) this).parShape.CutType == CutTypes.CutVerticalLine)
    {
      ((F_ShapeList) this).\u0001.Items[3].Focused = true;
      ((F_ShapeList) this).\u0001.Items[3].Selected = true;
      ((F_ShapeList) this).\u0001.FocusedItem = ((F_ShapeList) this).\u0001.Items[3];
      ((F_DrillList) this).\u0001 = 3;
    }
    else if (((F_DrillList) this).parShape.CutType == CutTypes.CutFree)
    {
      ((F_ShapeList) this).\u0001.Items[4].Focused = true;
      ((F_ShapeList) this).\u0001.Items[4].Selected = true;
      ((F_ShapeList) this).\u0001.FocusedItem = ((F_ShapeList) this).\u0001.Items[4];
      ((F_DrillList) this).\u0001 = 4;
    }
    ((F_SewingRotate) this).ShapeToDataGrid(((F_DrillList) this).\u0001);
    ((F_ShapeList) this).cmb_tools.Items.Clear();
    if (((F_DrillList) this).ShowTool)
    {
      int num = -1;
      for (int index = 0; index <= ((F_DrillList) this).Tools.Count - 1; ++index)
      {
        ((F_ShapeList) this).cmb_tools.Items.Add((object) $"{((ToolCamData5) ((ToolGeometry5) ((F_DrillList) this).Tools[index]).Data).Name} - T{((ToolCamData5) ((ToolGeometry5) ((F_DrillList) this).Tools[index]).Data).No.ToString()} - D: {((ToolGeometry5) ((F_DrillList) this).Tools[index]).Geometry.Diameter.ToString("f1")}");
        if (((F_DrillList) this).activeTool != null && ((ToolCamData5) ((ToolGeometry5) ((F_DrillList) this).Tools[index]).Data).Name == ((ToolCamData5) ((ToolGeometry5) ((F_DrillList) this).activeTool).Data).Name)
          num = index;
      }
      if (((F_ShapeList) this).cmb_tools.Items.Count > 0)
        ((F_ShapeList) this).cmb_tools.SelectedIndex = num;
      else
        ((F_DrillList) this).ShowTool = false;
    }
    if (!((F_DrillList) this).\u0001)
    {
      if (!((F_DrillList) this).ShowViewport & !((F_DrillList) this).ShowTool)
        ((F_ShapeList) this).\u0001.Height = ((F_ShapeList) this).\u0001.Height + ((F_ShapeList) this).pnl_model.Height + ((F_ShapeList) this).btn_toolsettings.Height;
      else if (!((F_DrillList) this).ShowViewport & ((F_DrillList) this).ShowTool)
        ((F_ShapeList) this).\u0001.Height = ((F_ShapeList) this).\u0001.Height + ((F_ShapeList) this).pnl_model.Height;
      else if (((F_DrillList) this).ShowViewport & !((F_DrillList) this).ShowTool)
        ((F_ShapeList) this).pnl_model.Height = ((F_ShapeList) this).pnl_model.Height + ((F_ShapeList) this).btn_toolsettings.Height;
      int int32 = Convert.ToInt32((double) this.Width / 6.0);
      ((F_ShapeList) this).btn_back.Width = int32 - 10;
      ((F_ShapeList) this).\u0005.Width = int32 - 10;
      ((F_ShapeList) this).btn_bottom.Width = int32 - 10;
      ((F_ShapeList) this).\u0007.Width = int32 - 10;
      ((F_ShapeList) this).btn_front.Width = int32 - 10;
      ((F_ShapeList) this).\u0006.Width = int32 - 10;
      ((F_ShapeList) this).btn_left.Width = int32 - 10;
      ((F_ShapeList) this).\u0004.Width = int32 - 10;
      ((F_ShapeList) this).btn_right.Width = int32 - 10;
      ((F_ShapeList) this).\u0002.Width = int32 - 10;
      ((F_ShapeList) this).btn_top.Width = int32 - 10;
      ((F_ShapeList) this).\u0003.Width = int32 - 10;
      ((F_ShapeList) this).\u0003.Left = ((F_ShapeList) this).btn_top.Left;
      ((F_ShapeList) this).btn_bottom.Left = ((F_ShapeList) this).btn_top.Left + ((F_ShapeList) this).btn_top.Width + 5;
      ((F_ShapeList) this).\u0007.Left = ((F_ShapeList) this).btn_bottom.Left;
      ((F_ShapeList) this).btn_front.Left = ((F_ShapeList) this).btn_bottom.Left + ((F_ShapeList) this).btn_bottom.Width + 5;
      ((F_ShapeList) this).\u0006.Left = ((F_ShapeList) this).btn_front.Left;
      ((F_ShapeList) this).btn_back.Left = ((F_ShapeList) this).btn_front.Left + ((F_ShapeList) this).btn_front.Width + 5;
      ((F_ShapeList) this).\u0005.Left = ((F_ShapeList) this).btn_back.Left;
      ((F_ShapeList) this).btn_left.Left = ((F_ShapeList) this).btn_back.Left + ((F_ShapeList) this).btn_back.Width + 5;
      ((F_ShapeList) this).\u0004.Left = ((F_ShapeList) this).btn_left.Left;
      ((F_ShapeList) this).btn_right.Left = ((F_ShapeList) this).btn_left.Left + ((F_ShapeList) this).btn_left.Width + 5;
      ((F_ShapeList) this).\u0002.Left = ((F_ShapeList) this).btn_right.Left;
      ((F_DrillList) this).\u0001 = true;
    }
    ((F_SewingRotate) this).LoadLanguage();
    ((F_SewingRotate) this).PlaneColorUpdate();
    ((F_DrillList) this).\u0001.Enabled = true;
    ((F_DrillList) this).PropertiesForm.Result = DialogResult.None;
  }

  private void \u0001([In] object obj0, [In] EventArgs obj1)
  {
    \u0008.\u0002.\u0001((F_CutList) this);
    ((F_DrillList) this).btn_ok.Enabled = true;
    ((F_DrillList) this).\u0001.Enabled = false;
    if (((F_DrillList) this).parShape.selectedPlane == planeBoxNames.Top)
      ((F_SewingRotate) this).\u0002((object) ((F_ShapeList) this).btn_top, obj1);
    if (((F_DrillList) this).parShape.selectedPlane == planeBoxNames.Bottom)
      ((F_SewingRotate) this).\u0002((object) ((F_ShapeList) this).btn_bottom, obj1);
    if (((F_DrillList) this).parShape.selectedPlane == planeBoxNames.Front)
      ((F_SewingRotate) this).\u0002((object) ((F_ShapeList) this).btn_front, obj1);
    if (((F_DrillList) this).parShape.selectedPlane == planeBoxNames.Back)
      ((F_SewingRotate) this).\u0002((object) ((F_ShapeList) this).btn_back, obj1);
    if (((F_DrillList) this).parShape.selectedPlane == planeBoxNames.Left)
      ((F_SewingRotate) this).\u0002((object) ((F_ShapeList) this).btn_left, obj1);
    if (((F_DrillList) this).parShape.selectedPlane == planeBoxNames.Right)
      ((F_SewingRotate) this).\u0002((object) ((F_ShapeList) this).btn_right, obj1);
    ((F_DrillList) this).PropertiesForm.Inited = true;
  }

  internal void \u0001([In] object obj0, [In] FormClosingEventArgs obj1)
  {
    obj1.Cancel = true;
    ((F_DrillList) this).PropertiesForm.Result = DialogResult.Cancel;
    if (((F_DrillList) this).PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
      this.Dispose();
    if (((F_DrillList) this).PropertiesForm.FormCloseMode == FormCloseModeType.Invisible)
    {
      this.Visible = false;
      if (this.Owner != null)
        this.Owner.Focus();
    }
    // ISSUE: reference to a compiler-generated field
    if (((F_DrillList) this).\u0001 == null)
      return;
    // ISSUE: reference to a compiler-generated field
    ((F_DrillList) this).\u0001();
  }

  public event OkCommandWithThreeDataEventHandler SelectCommad;

  public event CancelCommandEventHandler CancelCommad;
}
