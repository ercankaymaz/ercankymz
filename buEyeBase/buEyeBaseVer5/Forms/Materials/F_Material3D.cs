// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Forms.Materials.F_Material3D
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using buEyeBaseVer5.Apps;
using buEyeBaseVer5.Apps.Marble;
using buEyeBaseVer5.Forms.Marble;
using buEyeBaseVer5.Forms.MortiseTenon;
using buEyeBaseVer5.Forms.PanelCut;
using buEyeBaseVer5.Forms.Profile;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;

#nullable disable
namespace buEyeBaseVer5.Forms.Materials;

public class F_Material3D : Form
{
  internal ContextMenuStrip \u0001;
  internal ToolStripMenuItem \u0001;
  internal ToolStripMenuItem \u0002;
  internal ToolStripSeparator \u0001;
  internal ToolStripMenuItem \u0003;
  internal TabPage \u0001;
  internal Label \u0001;
  internal TextBox \u0001;
  internal Label \u0002;
  internal TextBox \u0002;
  internal Button \u0001;
  internal Button \u0002;
  internal Button \u0003;
  internal Button \u0004;
  internal DataGridView \u0001;
  internal ContextMenuStrip \u0002;
  internal ToolStripMenuItem \u0004;
  internal ToolStripMenuItem \u0005;
  internal ToolStripSeparator \u0002;
  internal ToolStripMenuItem \u0006;
  internal Button \u0005;
  internal Button \u0006;
  internal Button \u0007;
  internal Button \u0008;
  internal Panel \u0002;

  public abstract void m000DD7();

  public F_Material3D()
  {
    ((F_PanelCutSheetList) this).PropertiesForm = new FormProperties();
    ((F_PanelCutSheetList) this).ShowViewport = true;
    ((F_PanelCutSheetList) this).ShowCamSettings = true;
    ((F_PanelCutSheetList) this).ShowTool = false;
    ((F_PanelCutSheetList) this).ShowObjectPosition = true;
    ((F_PanelCutSheetList) this).ShowCornerLocation = true;
    ((F_PanelCutSheetList) this).EnableTopPlane = true;
    ((F_PanelCutSheetList) this).EnableBottomPlane = true;
    ((F_PanelCutSheetList) this).EnableFrontPlane = true;
    ((F_PanelCutSheetList) this).EnableBackPlane = true;
    ((F_PanelCutSheetList) this).EnableFreePlane = true;
    ((F_PanelCutSheetList) this).ClosePageAfterOk = false;
    ((F_PanelCutSheetList) this).CellFirstSelected = false;
    ((F_PanelCutSheetList) this).Tools = new List<ToolBase5>();
    ((F_PanelCutMaterials) this).activeTool = (ToolBase5) null;
    ((F_PanelCutMaterials) this).selectedPlanes = new List<SelectedPlaneInfo>();
    ((F_PanelCutMaterials) this).\u0001 = new System.Windows.Forms.Timer();
    ((F_PanelCutMaterials) this).\u0001 = -1;
    ((F_PanelCutMaterials) this).\u0001 = false;
    ((F_PanelCutMaterials) this).\u0001 = (IContainer) null;
    // ISSUE: explicit constructor call
    base.\u002Ector();
    \u0007.\u0001.\u0001((F_OperationList) this);
    ((F_PanelCutMaterials) this).\u0001.Interval = 100;
    ((F_PanelCutMaterials) this).\u0001.Tick += new EventHandler(this.\u0001);
  }

  [CompilerGenerated]
  [SpecialName]
  public void add_DataOk(OkCommandWithThreeDataEventHandler value)
  {
    // ISSUE: reference to a compiler-generated field
    OkCommandWithThreeDataEventHandler dataEventHandler = ((F_PanelCutSheetList) this).\u0001;
    OkCommandWithThreeDataEventHandler comparand;
    do
    {
      comparand = dataEventHandler;
      // ISSUE: reference to a compiler-generated field
      dataEventHandler = Interlocked.CompareExchange<OkCommandWithThreeDataEventHandler>(ref ((F_PanelCutSheetList) this).\u0001, comparand + value, comparand);
    }
    while (dataEventHandler != comparand);
  }

  [CompilerGenerated]
  [SpecialName]
  public void remove_DataOk(OkCommandWithThreeDataEventHandler value)
  {
    // ISSUE: reference to a compiler-generated field
    OkCommandWithThreeDataEventHandler dataEventHandler = ((F_PanelCutSheetList) this).\u0001;
    OkCommandWithThreeDataEventHandler comparand;
    do
    {
      comparand = dataEventHandler;
      // ISSUE: reference to a compiler-generated field
      dataEventHandler = Interlocked.CompareExchange<OkCommandWithThreeDataEventHandler>(ref ((F_PanelCutSheetList) this).\u0001, comparand - value, comparand);
    }
    while (dataEventHandler != comparand);
  }

  [CompilerGenerated]
  [SpecialName]
  public void add_CommandOk(OkCommandWithTwoDataEventHandler value)
  {
    // ISSUE: reference to a compiler-generated field
    OkCommandWithTwoDataEventHandler dataEventHandler = ((F_PanelCutSheetList) this).\u0001;
    OkCommandWithTwoDataEventHandler comparand;
    do
    {
      comparand = dataEventHandler;
      // ISSUE: reference to a compiler-generated field
      dataEventHandler = Interlocked.CompareExchange<OkCommandWithTwoDataEventHandler>(ref ((F_PanelCutSheetList) this).\u0001, comparand + value, comparand);
    }
    while (dataEventHandler != comparand);
  }

  [CompilerGenerated]
  [SpecialName]
  public void remove_CommandOk(OkCommandWithTwoDataEventHandler value)
  {
    // ISSUE: reference to a compiler-generated field
    OkCommandWithTwoDataEventHandler dataEventHandler = ((F_PanelCutSheetList) this).\u0001;
    OkCommandWithTwoDataEventHandler comparand;
    do
    {
      comparand = dataEventHandler;
      // ISSUE: reference to a compiler-generated field
      dataEventHandler = Interlocked.CompareExchange<OkCommandWithTwoDataEventHandler>(ref ((F_PanelCutSheetList) this).\u0001, comparand - value, comparand);
    }
    while (dataEventHandler != comparand);
  }

  [CompilerGenerated]
  [SpecialName]
  public void add_DataCancel(CancelCommandEventHandler value)
  {
    // ISSUE: reference to a compiler-generated field
    CancelCommandEventHandler commandEventHandler = ((F_PanelCutSheetList) this).\u0001;
    CancelCommandEventHandler comparand;
    do
    {
      comparand = commandEventHandler;
      // ISSUE: reference to a compiler-generated field
      commandEventHandler = Interlocked.CompareExchange<CancelCommandEventHandler>(ref ((F_PanelCutSheetList) this).\u0001, comparand + value, comparand);
    }
    while (commandEventHandler != comparand);
  }

  [CompilerGenerated]
  [SpecialName]
  public void remove_DataCancel(CancelCommandEventHandler value)
  {
    // ISSUE: reference to a compiler-generated field
    CancelCommandEventHandler commandEventHandler = ((F_PanelCutSheetList) this).\u0001;
    CancelCommandEventHandler comparand;
    do
    {
      comparand = commandEventHandler;
      // ISSUE: reference to a compiler-generated field
      commandEventHandler = Interlocked.CompareExchange<CancelCommandEventHandler>(ref ((F_PanelCutSheetList) this).\u0001, comparand - value, comparand);
    }
    while (commandEventHandler != comparand);
  }

  [CompilerGenerated]
  [SpecialName]
  public void add_PlaneEdit(OkCommandWithTwoDataEventHandler value)
  {
    // ISSUE: reference to a compiler-generated field
    OkCommandWithTwoDataEventHandler dataEventHandler = ((F_PanelCutSheetList) this).\u0002;
    OkCommandWithTwoDataEventHandler comparand;
    do
    {
      comparand = dataEventHandler;
      // ISSUE: reference to a compiler-generated field
      dataEventHandler = Interlocked.CompareExchange<OkCommandWithTwoDataEventHandler>(ref ((F_PanelCutSheetList) this).\u0002, comparand + value, comparand);
    }
    while (dataEventHandler != comparand);
  }

  [CompilerGenerated]
  [SpecialName]
  public void remove_PlaneEdit(OkCommandWithTwoDataEventHandler value)
  {
    // ISSUE: reference to a compiler-generated field
    OkCommandWithTwoDataEventHandler dataEventHandler = ((F_PanelCutSheetList) this).\u0002;
    OkCommandWithTwoDataEventHandler comparand;
    do
    {
      comparand = dataEventHandler;
      // ISSUE: reference to a compiler-generated field
      dataEventHandler = Interlocked.CompareExchange<OkCommandWithTwoDataEventHandler>(ref ((F_PanelCutSheetList) this).\u0002, comparand - value, comparand);
    }
    while (dataEventHandler != comparand);
  }

  public void Init()
  {
    ((F_PanelCutSheetList) this).PropertiesForm.Inited = false;
    if (((F_PanelCutSheetList) this).PropertiesForm.Height > 10)
      this.Height = ((F_PanelCutSheetList) this).PropertiesForm.Height;
    if (((F_PanelCutSheetList) this).PropertiesForm.Width > 10)
      this.Width = ((F_PanelCutSheetList) this).PropertiesForm.Width;
    ((F_PanelCutSheetList) this).CellFirstSelected = false;
    this.TopMost = ((F_PanelCutSheetList) this).PropertiesForm.TopMost;
    this.StartPosition = ((F_PanelCutSheetList) this).PropertiesForm.FormPosition;
    ((F_PanelCutMaterials) this).\u0001.Items.Clear();
    ((F_PanelCutMaterials) this).\u0001.Items.Add(buLangTranslate.preDef.Rect, 0);
    ((F_PanelCutMaterials) this).\u0001.Items.Add(buLangTranslate.preDef.Cirlce, 1);
    ((F_PanelCutMaterials) this).\u0001.Items.Add(buLangTranslate.preDef.Ellipse, 2);
    ((F_PanelCutMaterials) this).\u0001.Items.Add(buLangTranslate.preDef.KeyHole, 3);
    ((F_PanelCutMaterials) this).\u0001.Items.Add(buLangTranslate.preDef.Polygon, 4);
    ((F_PanelCutMaterials) this).\u0001.Items.Add(buLangTranslate.preDef.Slot, 5);
    ((F_PanelCutMaterials) this).\u0001.Items.Add(buLangTranslate.preDef.Hole, 6);
    ((F_PanelCutMaterials) this).\u0001.Items.Add(buLangTranslate.preDef.Cut, 7);
    ((F_PanelCutMaterials) this).\u0001.Items.Add(buLangTranslate.preDef.FreeDraw, 8);
    ((F_PanelCutMaterials) this).\u0001.Items.Add(buLangTranslate.preDef.Text, 9);
    ((F_PanelCutMaterials) this).\u0001.Items.Add($"{buLangTranslate.preDef.Wireframe} {buLangTranslate.preDef.Text}", 10);
    ((F_PanelCutMaterials) this).\u0001.Items.Add(buLangTranslate.preDef.Tapping, 11);
    ((F_PanelCutMaterials) this).pnl_model.Visible = ((F_PanelCutSheetList) this).ShowViewport;
    ((F_PanelCutMaterials) this).cmb_tools.Visible = ((F_PanelCutSheetList) this).ShowTool;
    ((F_PanelCutMaterials) this).btn_camsettings.Visible = ((F_PanelCutSheetList) this).ShowCamSettings;
    ((F_PanelCutMaterials) this).btn_toolsettings.Visible = ((F_PanelCutSheetList) this).ShowTool;
    ((F_PanelCutMaterials) this).\u0002.Visible = ((F_PanelCutSheetList) this).ShowObjectPosition;
    ((F_PanelCutMaterials) this).\u0005.Visible = ((F_PanelCutSheetList) this).ShowCornerLocation;
    ((F_PanelCutMaterials) this).\u0002.ImageIndex = Convert.ToInt32((object) ((MarbleTempVars) ProfileSettings.varProfileRunSettings).ShapeDataParameters.objectAlignment);
    ((F_PanelCutMaterials) this).\u0005.ImageIndex = Convert.ToInt32((object) ((MarbleTempVars) ProfileSettings.varProfileRunSettings).ShapeDataParameters.selectedCorner);
    ((F_PanelCutMaterials) this).btn_back.Enabled = ((F_PanelCutSheetList) this).EnableBackPlane;
    ((F_PanelCutMaterials) this).btn_front.Enabled = ((F_PanelCutSheetList) this).EnableFrontPlane;
    ((F_PanelCutMaterials) this).btn_top.Enabled = ((F_PanelCutSheetList) this).EnableTopPlane;
    ((F_PanelCutMaterials) this).btn_bottom.Enabled = ((F_PanelCutSheetList) this).EnableBottomPlane;
    ((F_PanelCutMaterials) this).btn_free.Enabled = ((F_PanelCutSheetList) this).EnableFreePlane;
    if (((F_PanelCutMaterials) this).dgv_data.Columns.Count == 0)
    {
      DataGridViewColumn dataGridViewColumn1 = new DataGridViewColumn();
      dataGridViewColumn1.SortMode = DataGridViewColumnSortMode.NotSortable;
      dataGridViewColumn1.Width = Convert.ToInt32((double) ((F_PanelCutMaterials) this).dgv_data.Width * 0.65);
      dataGridViewColumn1.HeaderText = "Name";
      dataGridViewColumn1.Name = "Name";
      dataGridViewColumn1.ReadOnly = true;
      dataGridViewColumn1.DefaultCellStyle.Font = new Font("Arial", 10f, FontStyle.Bold);
      dataGridViewColumn1.CellTemplate = (DataGridViewCell) new DataGridViewTextBoxCell();
      ((F_PanelCutMaterials) this).dgv_data.Columns.Add(dataGridViewColumn1);
      DataGridViewColumn dataGridViewColumn2 = new DataGridViewColumn();
      dataGridViewColumn2.SortMode = DataGridViewColumnSortMode.NotSortable;
      dataGridViewColumn2.Width = ((F_PanelCutMaterials) this).dgv_data.Width - dataGridViewColumn1.Width - 20;
      dataGridViewColumn2.HeaderText = "Value";
      dataGridViewColumn2.Name = "Value";
      dataGridViewColumn2.ReadOnly = false;
      dataGridViewColumn2.DefaultCellStyle.Font = new Font("Arial", 10f, FontStyle.Bold);
      dataGridViewColumn2.CellTemplate = (DataGridViewCell) new DataGridViewTextBoxCell();
      ((F_PanelCutMaterials) this).dgv_data.Columns.Add(dataGridViewColumn2);
      ((F_PanelCutMaterials) this).dgv_data.CellValueChanged += new DataGridViewCellEventHandler(((F_MarbleCam3DEngrave) this).\u0001);
      ((F_PanelCutMaterials) this).dgv_data.CellClick += new DataGridViewCellEventHandler(((F_MarbleCam3DEngrave) this).\u0002);
      ((F_PanelCutMaterials) this).dgv_data.CellDoubleClick += new DataGridViewCellEventHandler(((F_MarbleCam3DEngrave) this).\u0003);
      ((F_PanelCutMaterials) this).dgv_data.CellEnter += new DataGridViewCellEventHandler(((F_MarbleCam3DEngrave) this).\u0004);
      ((F_PanelCutMaterials) this).dgv_data.RowHeadersVisible = false;
      ((F_PanelCutMaterials) this).dgv_data.ColumnHeadersVisible = false;
      ((F_PanelCutMaterials) this).dgv_data.AllowUserToAddRows = false;
      ((F_PanelCutMaterials) this).dgv_data.AllowUserToResizeColumns = false;
      ((F_PanelCutMaterials) this).dgv_data.AllowUserToResizeRows = false;
      ((F_PanelCutMaterials) this).dgv_data.MultiSelect = false;
    }
    if (((F_SlotNoDepth) this).dgv_list.Columns.Count == 0)
    {
      DataGridViewColumn dataGridViewColumn3 = new DataGridViewColumn();
      dataGridViewColumn3.SortMode = DataGridViewColumnSortMode.NotSortable;
      dataGridViewColumn3.Width = 1;
      dataGridViewColumn3.HeaderText = "Name";
      dataGridViewColumn3.Name = "Name";
      dataGridViewColumn3.ReadOnly = true;
      dataGridViewColumn3.DefaultCellStyle.Font = new Font("Arial", 10f, FontStyle.Bold);
      dataGridViewColumn3.CellTemplate = (DataGridViewCell) new DataGridViewTextBoxCell();
      ((F_SlotNoDepth) this).dgv_list.Columns.Add(dataGridViewColumn3);
      DataGridViewColumn dataGridViewColumn4 = new DataGridViewColumn();
      dataGridViewColumn4.SortMode = DataGridViewColumnSortMode.NotSortable;
      dataGridViewColumn4.Width = Convert.ToInt32(((F_SlotNoDepth) this).dgv_list.Width - 2);
      dataGridViewColumn4.HeaderText = "Name";
      dataGridViewColumn4.Name = "Name";
      dataGridViewColumn4.ReadOnly = true;
      dataGridViewColumn4.DefaultCellStyle.Font = new Font("Arial", 9f, FontStyle.Bold);
      dataGridViewColumn4.CellTemplate = (DataGridViewCell) new DataGridViewTextBoxCell();
      ((F_SlotNoDepth) this).dgv_list.Columns.Add(dataGridViewColumn4);
      ((F_SlotNoDepth) this).dgv_list.ScrollBars = ScrollBars.None;
      ((F_SlotNoDepth) this).dgv_list.RowTemplate.Height = 15;
      ((F_SlotNoDepth) this).dgv_list.RowTemplate.DefaultCellStyle.Font = new Font("Arial", 9f, FontStyle.Bold);
      ((F_SlotNoDepth) this).dgv_list.DefaultCellStyle.Font = new Font("Arial", 9f, FontStyle.Bold);
      ((F_SlotNoDepth) this).dgv_list.DefaultCellStyle.SelectionBackColor = Color.Transparent;
      ((F_SlotNoDepth) this).dgv_list.DefaultCellStyle.SelectionForeColor = Color.Black;
      ((F_SlotNoDepth) this).dgv_list.RowHeadersVisible = false;
      ((F_SlotNoDepth) this).dgv_list.ColumnHeadersVisible = false;
      ((F_SlotNoDepth) this).dgv_list.AllowUserToAddRows = false;
      ((F_SlotNoDepth) this).dgv_list.AllowUserToResizeColumns = false;
      ((F_SlotNoDepth) this).dgv_list.AllowUserToResizeRows = false;
      ((F_SlotNoDepth) this).dgv_list.MultiSelect = false;
    }
    ((F_PanelCutMaterials) this).\u0001.ForeColor = Color.Red;
    if (((MarbleTempVars) ProfileSettings.varProfileRunSettings).ShapeDataParameters.ShapeType == ShapeTypes.Rectangle)
    {
      ((F_PanelCutMaterials) this).\u0001.Items[0].Focused = true;
      ((F_PanelCutMaterials) this).\u0001.Items[0].Selected = true;
      ((F_PanelCutMaterials) this).\u0001.FocusedItem = ((F_PanelCutMaterials) this).\u0001.Items[0];
      ((F_PanelCutMaterials) this).\u0001 = 0;
    }
    else if (((MarbleTempVars) ProfileSettings.varProfileRunSettings).ShapeDataParameters.ShapeType == ShapeTypes.Circle)
    {
      ((F_PanelCutMaterials) this).\u0001.Items[1].Focused = true;
      ((F_PanelCutMaterials) this).\u0001.Items[1].Selected = true;
      ((F_PanelCutMaterials) this).\u0001.FocusedItem = ((F_PanelCutMaterials) this).\u0001.Items[1];
      ((F_PanelCutMaterials) this).\u0001 = 1;
    }
    else if (((MarbleTempVars) ProfileSettings.varProfileRunSettings).ShapeDataParameters.ShapeType == ShapeTypes.Ellipse)
    {
      ((F_PanelCutMaterials) this).\u0001.Items[2].Focused = true;
      ((F_PanelCutMaterials) this).\u0001.Items[2].Selected = true;
      ((F_PanelCutMaterials) this).\u0001.FocusedItem = ((F_PanelCutMaterials) this).\u0001.Items[2];
      ((F_PanelCutMaterials) this).\u0001 = 2;
    }
    else if (((MarbleTempVars) ProfileSettings.varProfileRunSettings).ShapeDataParameters.ShapeType == ShapeTypes.KeyHole)
    {
      ((F_PanelCutMaterials) this).\u0001.Items[3].Focused = true;
      ((F_PanelCutMaterials) this).\u0001.Items[3].Selected = true;
      ((F_PanelCutMaterials) this).\u0001.FocusedItem = ((F_PanelCutMaterials) this).\u0001.Items[3];
      ((F_PanelCutMaterials) this).\u0001 = 3;
    }
    else if (((MarbleTempVars) ProfileSettings.varProfileRunSettings).ShapeDataParameters.ShapeType == ShapeTypes.Polygon)
    {
      ((F_PanelCutMaterials) this).\u0001.Items[4].Focused = true;
      ((F_PanelCutMaterials) this).\u0001.Items[4].Selected = true;
      ((F_PanelCutMaterials) this).\u0001.FocusedItem = ((F_PanelCutMaterials) this).\u0001.Items[4];
      ((F_PanelCutMaterials) this).\u0001 = 4;
    }
    else if (((MarbleTempVars) ProfileSettings.varProfileRunSettings).ShapeDataParameters.ShapeType == ShapeTypes.Slot)
    {
      ((F_PanelCutMaterials) this).\u0001.Items[5].Focused = true;
      ((F_PanelCutMaterials) this).\u0001.Items[5].Selected = true;
      ((F_PanelCutMaterials) this).\u0001.FocusedItem = ((F_PanelCutMaterials) this).\u0001.Items[5];
      ((F_PanelCutMaterials) this).\u0001 = 5;
    }
    else if (((MarbleTempVars) ProfileSettings.varProfileRunSettings).ShapeDataParameters.ShapeType == ShapeTypes.Hole)
    {
      if (((MarbleTempVars) ProfileSettings.varProfileRunSettings).ShapeDataParameters.isTapping)
      {
        ((F_PanelCutMaterials) this).\u0001 = 11;
        ((F_PanelCutMaterials) this).\u0001.Items[11].Focused = true;
        ((F_PanelCutMaterials) this).\u0001.Items[11].Selected = true;
        ((F_PanelCutMaterials) this).\u0001.FocusedItem = ((F_PanelCutMaterials) this).\u0001.Items[11];
      }
      else
      {
        ((F_PanelCutMaterials) this).\u0001.Items[6].Focused = true;
        ((F_PanelCutMaterials) this).\u0001.Items[6].Selected = true;
        ((F_PanelCutMaterials) this).\u0001.FocusedItem = ((F_PanelCutMaterials) this).\u0001.Items[6];
        ((F_PanelCutMaterials) this).\u0001 = 6;
      }
    }
    else if (((MarbleTempVars) ProfileSettings.varProfileRunSettings).ShapeDataParameters.ShapeType == ShapeTypes.Cut)
    {
      ((F_PanelCutMaterials) this).\u0001.Items[7].Focused = true;
      ((F_PanelCutMaterials) this).\u0001.Items[7].Selected = true;
      ((F_PanelCutMaterials) this).\u0001.FocusedItem = ((F_PanelCutMaterials) this).\u0001.Items[7];
      ((F_PanelCutMaterials) this).\u0001 = 7;
    }
    else if (((MarbleTempVars) ProfileSettings.varProfileRunSettings).ShapeDataParameters.ShapeType == ShapeTypes.FreeDraw)
    {
      ((F_PanelCutMaterials) this).\u0001.Items[8].Focused = true;
      ((F_PanelCutMaterials) this).\u0001.Items[8].Selected = true;
      ((F_PanelCutMaterials) this).\u0001.FocusedItem = ((F_PanelCutMaterials) this).\u0001.Items[8];
      ((F_PanelCutMaterials) this).\u0001 = 8;
    }
    else if (((MarbleTempVars) ProfileSettings.varProfileRunSettings).ShapeDataParameters.ShapeType == ShapeTypes.Text)
    {
      if (!((SelectionEntity) ((MarbleTempVars) ProfileSettings.varProfileRunSettings).ShapeDataParameters).TextIsWire)
      {
        ((F_PanelCutMaterials) this).\u0001.Items[9].Focused = true;
        ((F_PanelCutMaterials) this).\u0001.Items[9].Selected = true;
        ((F_PanelCutMaterials) this).\u0001.FocusedItem = ((F_PanelCutMaterials) this).\u0001.Items[9];
        ((F_PanelCutMaterials) this).\u0001 = 9;
      }
      else
      {
        ((F_PanelCutMaterials) this).\u0001.Items[10].Focused = true;
        ((F_PanelCutMaterials) this).\u0001.Items[10].Selected = true;
        ((F_PanelCutMaterials) this).\u0001.FocusedItem = ((F_PanelCutMaterials) this).\u0001.Items[10];
        ((F_PanelCutMaterials) this).\u0001 = 10;
      }
    }
    ((F_MarbleCam3DEngrave) this).ShapeToDataGrid(((F_PanelCutMaterials) this).\u0001);
    ((F_PanelCutMaterials) this).cmb_tools.Items.Clear();
    if (((F_PanelCutSheetList) this).ShowTool)
    {
      int num = -1;
      for (int index = 0; index <= ((F_PanelCutSheetList) this).Tools.Count - 1; ++index)
      {
        ((F_PanelCutMaterials) this).cmb_tools.Items.Add((object) buCall.\u0001.ToolToString(((F_PanelCutSheetList) this).Tools[index]));
        if (((F_PanelCutMaterials) this).activeTool != null && ((ToolCamData5) ((ToolGeometry5) ((F_PanelCutSheetList) this).Tools[index]).Data).Name == ((ToolCamData5) ((ToolGeometry5) ((F_PanelCutMaterials) this).activeTool).Data).Name)
          num = index;
      }
      if (((F_PanelCutMaterials) this).cmb_tools.Items.Count > 0)
        ((F_PanelCutMaterials) this).cmb_tools.SelectedIndex = num;
      else
        ((F_PanelCutSheetList) this).ShowTool = false;
    }
    if (!((F_PanelCutMaterials) this).\u0001)
    {
      if (!((F_PanelCutSheetList) this).ShowViewport & !((F_PanelCutSheetList) this).ShowTool)
        ((F_PanelCutMaterials) this).dgv_data.Height = ((F_PanelCutMaterials) this).dgv_data.Height + ((F_PanelCutMaterials) this).pnl_model.Height + ((F_PanelCutMaterials) this).btn_toolsettings.Height;
      else if (!((F_PanelCutSheetList) this).ShowViewport & ((F_PanelCutSheetList) this).ShowTool)
        ((F_PanelCutMaterials) this).dgv_data.Height = ((F_PanelCutMaterials) this).dgv_data.Height + ((F_PanelCutMaterials) this).pnl_model.Height;
      else if (((F_PanelCutSheetList) this).ShowViewport & !((F_PanelCutSheetList) this).ShowTool)
        ((F_PanelCutMaterials) this).pnl_model.Height = ((F_PanelCutMaterials) this).pnl_model.Height + ((F_PanelCutMaterials) this).btn_toolsettings.Height;
      int int32 = Convert.ToInt32((double) this.Width / 6.0);
      ((F_PanelCutMaterials) this).btn_back.Width = int32 - 10;
      ((F_PanelCutMaterials) this).\u0004.Width = int32 - 10;
      ((F_PanelCutMaterials) this).btn_bottom.Width = int32 - 10;
      ((F_PanelCutMaterials) this).\u0006.Width = int32 - 10;
      ((F_PanelCutMaterials) this).btn_front.Width = int32 - 10;
      ((F_PanelCutMaterials) this).\u0005.Width = int32 - 10;
      ((F_PanelCutMaterials) this).btn_top.Width = int32 - 10;
      ((F_PanelCutMaterials) this).\u0003.Width = int32 - 10;
      ((F_PanelCutMaterials) this).\u0003.Left = ((F_PanelCutMaterials) this).btn_top.Left;
      ((F_PanelCutMaterials) this).btn_bottom.Left = ((F_PanelCutMaterials) this).btn_top.Left + ((F_PanelCutMaterials) this).btn_top.Width + 5;
      ((F_PanelCutMaterials) this).\u0006.Left = ((F_PanelCutMaterials) this).btn_bottom.Left;
      ((F_PanelCutMaterials) this).btn_front.Left = ((F_PanelCutMaterials) this).btn_bottom.Left + ((F_PanelCutMaterials) this).btn_bottom.Width + 5;
      ((F_PanelCutMaterials) this).\u0005.Left = ((F_PanelCutMaterials) this).btn_front.Left;
      ((F_PanelCutMaterials) this).btn_back.Left = ((F_PanelCutMaterials) this).btn_front.Left + ((F_PanelCutMaterials) this).btn_front.Width + 5;
      ((F_PanelCutMaterials) this).\u0004.Left = ((F_PanelCutMaterials) this).btn_back.Left;
      ((F_PanelCutMaterials) this).\u0001 = true;
    }
    this.LoadLanguage();
    this.PlaneColorUpdate();
    ((F_PanelCutSheetList) this).PropertiesForm.Inited = false;
    ((F_PanelCutMaterials) this).\u0001.Enabled = true;
    ((F_PanelCutSheetList) this).PropertiesForm.Result = DialogResult.None;
  }

  internal void \u0001([In] object obj0, [In] FormClosingEventArgs obj1)
  {
    if (((F_PanelCutSheetList) this).PropertiesForm.Result == DialogResult.OK)
      return;
    obj1.Cancel = true;
    ((F_PanelCutSheetList) this).PropertiesForm.Result = DialogResult.Cancel;
    if (((F_PanelCutSheetList) this).PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
      this.Dispose();
    if (((F_PanelCutSheetList) this).PropertiesForm.FormCloseMode != FormCloseModeType.Invisible)
      return;
    this.Visible = false;
    if (this.Owner == null)
      return;
    this.Owner.Focus();
  }

  private void \u0001([In] object obj0, [In] EventArgs obj1)
  {
    \u0007.\u0001.\u0001((F_OperationList) this);
    ((F_PanelCutMaterials) this).btn_ok.Enabled = true;
    ((F_PanelCutMaterials) this).\u0001.Enabled = false;
    // ISSUE: reference to a compiler-generated field
    ((F_PanelCutSheetList) this).\u0001((object) null, (object) (ShapeUpdateArg) new hmiUICommands(((MarbleTempVars) ProfileSettings.varProfileRunSettings).ShapeDataParameters), (object) null);
    ((F_PanelCutSheetList) this).CellFirstSelected = true;
    ((F_PanelCutSheetList) this).PropertiesForm.Inited = true;
  }

  public void LoadLanguage()
  {
    string callMethod = nameof (LoadLanguage);
    try
    {
      ((F_PanelCutMaterials) this).\u0003.Text = buLangTranslate.preDef.Top;
      ((F_PanelCutMaterials) this).\u0006.Text = buLangTranslate.preDef.Bottom;
      ((F_PanelCutMaterials) this).\u0004.Text = buLangTranslate.preDef.Back;
      ((F_PanelCutMaterials) this).\u0005.Text = buLangTranslate.preDef.Front;
      ((F_PanelCutMaterials) this).\u0002.Text = buLangTranslate.preDef.Free;
      ((F_PanelCutMaterials) this).\u0001.Text = buLangTranslate.preDef.Plane;
      ((F_PanelCutMaterials) this).\u000E.Text = buLangTranslate.preDef.Corner;
      ((F_PanelCutMaterials) this).\u0007.Text = buLangTranslate.preDef.Object;
      ((F_PanelCutMaterials) this).\u0008.Text = buLangTranslate.preDef.Edit;
      ((F_SlotNoDepth) this).\u000F.Text = buLangTranslate.preDef.Cam;
      ((F_PanelCutMaterials) this).\u0003.Text = $"{buLangTranslate.preDef.Each} {buLangTranslate.preDef.Layer}";
      ((F_PanelCutMaterials) this).\u0002.Text = $"{buLangTranslate.preDef.Incremental} {buLangTranslate.preDef.Mode}";
      ((F_SlotNoDepth) this).chk_manuelmode.Text = buLangTranslate.preDef.Manuel;
      this.Text = buLangTranslate.preDef.Shape;
      ((F_PanelCutMaterials) this).btn_camsettings.Text = $"{buLangTranslate.preDef.Cam} {buLangTranslate.preDef.Setting}";
      ((F_PanelCutMaterials) this).btn_ok.Text = buLangTranslate.preDef.Ok;
      ((F_PanelCutMaterials) this).btn_cancel.Text = buLangTranslate.preDef.Cancel;
    }
    catch (Exception ex)
    {
      string str = "";
      buLog.addLog(str, "Not Ok", callMethod);
      buException.throwException(ex, callMethod, true, str);
    }
  }

  public void PlaneColorUpdate()
  {
    ((F_PanelCutMaterials) this).btn_back.BackColor = Color.Gainsboro;
    ((F_PanelCutMaterials) this).btn_bottom.BackColor = Color.Gainsboro;
    ((F_PanelCutMaterials) this).btn_front.BackColor = Color.Gainsboro;
    ((F_PanelCutMaterials) this).btn_free.BackColor = Color.Gainsboro;
    ((F_PanelCutMaterials) this).btn_top.BackColor = Color.Gainsboro;
    if (((MarbleTempVars) ProfileSettings.varProfileRunSettings).ShapeDataParameters.selectedPlane == planeBoxNames.Top)
    {
      ((F_PanelCutMaterials) this).btn_top.BackColor = Color.PaleGreen;
      ((F_SlotNoDepth) this).chk_manuelmode.Text = $"{buLangTranslate.preDef.Manuel} {buLangTranslate.preDef.Depth} Z {buLangTranslate.preDef.Top} {buLangTranslate.preChar.Position}";
    }
    if (((MarbleTempVars) ProfileSettings.varProfileRunSettings).ShapeDataParameters.selectedPlane == planeBoxNames.Bottom)
    {
      ((F_PanelCutMaterials) this).btn_bottom.BackColor = Color.PaleGreen;
      ((F_SlotNoDepth) this).chk_manuelmode.Text = $"{buLangTranslate.preDef.Manuel} {buLangTranslate.preDef.Depth} Z {buLangTranslate.preDef.Bottom} {buLangTranslate.preChar.Position}";
    }
    if (((MarbleTempVars) ProfileSettings.varProfileRunSettings).ShapeDataParameters.selectedPlane == planeBoxNames.Front)
    {
      ((F_PanelCutMaterials) this).btn_front.BackColor = Color.PaleGreen;
      ((F_SlotNoDepth) this).chk_manuelmode.Text = $"{buLangTranslate.preDef.Manuel} {buLangTranslate.preDef.Depth} Y {buLangTranslate.preDef.Front} {buLangTranslate.preChar.Position}";
    }
    if (((MarbleTempVars) ProfileSettings.varProfileRunSettings).ShapeDataParameters.selectedPlane == planeBoxNames.Back)
    {
      ((F_PanelCutMaterials) this).btn_back.BackColor = Color.PaleGreen;
      ((F_SlotNoDepth) this).chk_manuelmode.Text = $"{buLangTranslate.preDef.Manuel} {buLangTranslate.preDef.Depth} Y {buLangTranslate.preDef.Back} {buLangTranslate.preChar.Position}";
    }
    if (((MarbleTempVars) ProfileSettings.varProfileRunSettings).ShapeDataParameters.selectedPlane != planeBoxNames.Free)
      return;
    ((F_PanelCutMaterials) this).btn_free.BackColor = Color.PaleGreen;
    ((F_SlotNoDepth) this).chk_manuelmode.Text = $"{buLangTranslate.preDef.Manuel} {buLangTranslate.preDef.Depth} Z {buLangTranslate.preDef.Top} {buLangTranslate.preChar.Position}";
  }
}
