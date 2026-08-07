// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Forms.Shape.F_ShapeList
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using buControls.Controls;
using buEyeBaseVer5.Apps;
using buEyeBaseVer5.buClipperLib;
using buEyeBaseVer5.buEntities;
using buEyeBaseVer5.Forms.Cam;
using buEyeBaseVer5.Forms.Holes;
using buEyeBaseVer5.Forms.KeyPad;
using buEyeBaseVer5.Forms.Location;
using buEyeBaseVer5.Forms.Sewing;
using devDept.Eyeshot.Entities;
using devDept.Geometry;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;

#nullable disable
namespace buEyeBaseVer5.Forms.Shape;

public class F_ShapeList : Form
{
  public Panel pnl_model;
  internal ImageList \u0001;
  internal ListView \u0001;
  internal ImageList \u0002;
  internal DataGridView \u0001;
  internal Panel \u0001;
  public Button btn_front;
  public Button btn_back;
  public Button btn_right;
  public Button btn_left;
  public Button btn_top;
  public Button btn_bottom;
  internal PictureBox \u0001;
  internal Button \u0001;
  public Button btn_camsettings;
  public Button btn_toolsettings;
  public ComboBox cmb_tools;
  internal Button \u0002;
  internal ImageList \u0003;
  internal ImageList \u0004;
  internal ImageList \u0005;
  internal ImageList \u0006;
  internal Button \u0003;
  internal CheckBox \u0001;
  internal Label \u0001;
  internal Label \u0002;
  internal Label \u0003;
  internal Label \u0004;
  internal Label \u0005;
  internal Label \u0006;
  internal Label \u0007;
  public static byte f001285;
  public Color SpinBaseColor;
  public Color SpinFocusColor;
  public ShapeAllData Data;
  public static List<string> Captions;
  public FormProperties PropertiesForm;
  private IContainer \u0001;
  internal buGround \u0001;
  internal buButton \u0001;
  public buButton btn_ok;
  public buButton btn_cancel;
  public buTab buTab_shape;
  public TabPage tabPage_rectangle;
  public TabPage tabPage_circle;
  internal PictureBox \u0001;
  internal buLabel \u0001;
  public buSpin spn_rotation;
  public buSpin spn_rectheight;
  public buSpin spn_rectwidth;
  public buSpin spn_circlediameter;
  internal PictureBox \u0002;
  public buSpin spn_roundrectrad;
  public buSpin spn_roundrectheight;
  public buSpin spn_roundrectwidth;
  internal PictureBox \u0003;
  public buSpin spn_ellipseheight;
  public buSpin spn_ellipsewidth;
  internal PictureBox \u0004;

  [CompilerGenerated]
  [SpecialName]
  public void add_DataOk(OkCommandWithTwoDataEventHandler value)
  {
    // ISSUE: reference to a compiler-generated field
    OkCommandWithTwoDataEventHandler dataEventHandler = ((F_CutList) this).\u0001;
    OkCommandWithTwoDataEventHandler comparand;
    do
    {
      comparand = dataEventHandler;
      // ISSUE: reference to a compiler-generated field
      dataEventHandler = Interlocked.CompareExchange<OkCommandWithTwoDataEventHandler>(ref ((F_CutList) this).\u0001, comparand + value, comparand);
    }
    while (dataEventHandler != comparand);
  }

  [CompilerGenerated]
  [SpecialName]
  public void remove_DataOk(OkCommandWithTwoDataEventHandler value)
  {
    // ISSUE: reference to a compiler-generated field
    OkCommandWithTwoDataEventHandler dataEventHandler = ((F_CutList) this).\u0001;
    OkCommandWithTwoDataEventHandler comparand;
    do
    {
      comparand = dataEventHandler;
      // ISSUE: reference to a compiler-generated field
      dataEventHandler = Interlocked.CompareExchange<OkCommandWithTwoDataEventHandler>(ref ((F_CutList) this).\u0001, comparand - value, comparand);
    }
    while (dataEventHandler != comparand);
  }

  [CompilerGenerated]
  [SpecialName]
  public void add_DataCancel(CancelCommandEventHandler value)
  {
    // ISSUE: reference to a compiler-generated field
    CancelCommandEventHandler commandEventHandler = ((F_CutList) this).\u0001;
    CancelCommandEventHandler comparand;
    do
    {
      comparand = commandEventHandler;
      // ISSUE: reference to a compiler-generated field
      commandEventHandler = Interlocked.CompareExchange<CancelCommandEventHandler>(ref ((F_CutList) this).\u0001, comparand + value, comparand);
    }
    while (commandEventHandler != comparand);
  }

  [CompilerGenerated]
  [SpecialName]
  public void remove_DataCancel(CancelCommandEventHandler value)
  {
    // ISSUE: reference to a compiler-generated field
    CancelCommandEventHandler commandEventHandler = ((F_CutList) this).\u0001;
    CancelCommandEventHandler comparand;
    do
    {
      comparand = commandEventHandler;
      // ISSUE: reference to a compiler-generated field
      commandEventHandler = Interlocked.CompareExchange<CancelCommandEventHandler>(ref ((F_CutList) this).\u0001, comparand - value, comparand);
    }
    while (commandEventHandler != comparand);
  }

  public void Init()
  {
    ((F_CutList) this).PropertiesForm.Inited = false;
    if (((F_CutList) this).PropertiesForm.Height > 10)
      this.Height = ((F_CutList) this).PropertiesForm.Height;
    if (((F_CutList) this).PropertiesForm.Width > 10)
      this.Width = ((F_CutList) this).PropertiesForm.Width;
    this.TopMost = ((F_CutList) this).PropertiesForm.TopMost;
    this.StartPosition = ((F_CutList) this).PropertiesForm.FormPosition;
    ((F_CutList) this).\u0001.Items.Clear();
    ((F_CutList) this).\u0001.Items.Add($"{buLangTranslate.preDef.Horizontal} 3 {buLangTranslate.preDef.Hole}{buLangTranslate.preDef.Junction}", 0);
    ((F_CutList) this).\u0001.Items.Add($"{buLangTranslate.preDef.Vertical} 3 {buLangTranslate.preDef.Hole}{buLangTranslate.preDef.Junction}", 1);
    ((F_CutList) this).\u0001.Items.Add($"{buLangTranslate.preDef.Horizontal} 2 {buLangTranslate.preDef.Hole}{buLangTranslate.preDef.Junction}", 2);
    ((F_CutList) this).\u0001.Items.Add($"{buLangTranslate.preDef.Vertical} 2 {buLangTranslate.preDef.Hole}{buLangTranslate.preDef.Junction}", 3);
    ((F_CutList) this).pnl_model.Visible = ((F_CutList) this).ShowViewport;
    ((F_ShapeAll) this).cmb_tools.Visible = ((F_CutList) this).ShowTool;
    ((F_ShapeAll) this).btn_camsettings.Visible = ((F_CutList) this).ShowCamSettings;
    ((F_ShapeAll) this).btn_toolsettings.Visible = ((F_CutList) this).ShowTool;
    ((F_ShapeAll) this).\u0002.Visible = ((F_CutList) this).ShowObjectPosition;
    ((F_ShapeAll) this).\u0001.Visible = ((F_CutList) this).ShowCornerLocation;
    ((F_ShapeAll) this).\u0002.ImageIndex = Convert.ToInt32((object) ((F_CutList) this).parShape.objectAlignment);
    ((F_ShapeAll) this).\u0001.ImageIndex = Convert.ToInt32((object) ((F_CutList) this).parShape.selectedCorner);
    ((F_CutList) this).btn_back.Enabled = ((F_CutList) this).EnableBacktPlane;
    ((F_CutList) this).btn_front.Enabled = ((F_CutList) this).EnableFrontPlane;
    ((F_CutList) this).btn_top.Enabled = ((F_CutList) this).EnableTopPlane;
    ((F_CutList) this).btn_bottom.Enabled = ((F_CutList) this).EnableBottomPlane;
    ((F_CutList) this).btn_left.Enabled = ((F_CutList) this).EnableLeftPlane;
    ((F_CutList) this).btn_right.Enabled = ((F_CutList) this).EnableRightPlane;
    if (((F_CutList) this).\u0001.Columns.Count == 0)
    {
      DataGridViewColumn dataGridViewColumn1 = new DataGridViewColumn();
      dataGridViewColumn1.SortMode = DataGridViewColumnSortMode.NotSortable;
      dataGridViewColumn1.Width = Convert.ToInt32((double) ((F_CutList) this).\u0001.Width * 0.65);
      dataGridViewColumn1.HeaderText = "Name";
      dataGridViewColumn1.Name = "Name";
      dataGridViewColumn1.ReadOnly = true;
      dataGridViewColumn1.DefaultCellStyle.Font = new Font("Arial", 10f, FontStyle.Bold);
      dataGridViewColumn1.CellTemplate = (DataGridViewCell) new DataGridViewTextBoxCell();
      ((F_CutList) this).\u0001.Columns.Add(dataGridViewColumn1);
      DataGridViewColumn dataGridViewColumn2 = new DataGridViewColumn();
      dataGridViewColumn2.SortMode = DataGridViewColumnSortMode.NotSortable;
      dataGridViewColumn2.Width = ((F_CutList) this).\u0001.Width - dataGridViewColumn1.Width - 20;
      dataGridViewColumn2.HeaderText = "Value";
      dataGridViewColumn2.Name = "Value";
      dataGridViewColumn2.ReadOnly = false;
      dataGridViewColumn2.DefaultCellStyle.Font = new Font("Arial", 10f, FontStyle.Bold);
      dataGridViewColumn2.CellTemplate = (DataGridViewCell) new DataGridViewTextBoxCell();
      ((F_CutList) this).\u0001.Columns.Add(dataGridViewColumn2);
      ((F_CutList) this).\u0001.CellValueChanged += new DataGridViewCellEventHandler(this.\u0001);
      ((F_CutList) this).\u0001.CellClick += new DataGridViewCellEventHandler(this.\u0002);
      ((F_CutList) this).\u0001.CellEnter += new DataGridViewCellEventHandler(this.\u0003);
    }
    ((F_CutList) this).\u0001.RowHeadersVisible = false;
    ((F_CutList) this).\u0001.ColumnHeadersVisible = false;
    ((F_CutList) this).\u0001.AllowUserToAddRows = false;
    ((F_CutList) this).\u0001.AllowUserToResizeColumns = false;
    ((F_CutList) this).\u0001.AllowUserToResizeRows = false;
    ((F_CutList) this).\u0001.ForeColor = Color.Red;
    if (((F_CutList) this).parShape.JunctionType == JunctionTypes.Junction3HoleIntersectHorizontal)
    {
      ((F_CutList) this).\u0001.Items[0].Focused = true;
      ((F_CutList) this).\u0001.Items[0].Selected = true;
      ((F_CutList) this).\u0001.FocusedItem = ((F_CutList) this).\u0001.Items[0];
      ((F_CutList) this).\u0001 = 0;
    }
    else if (((F_CutList) this).parShape.JunctionType == JunctionTypes.Junction3HoleIntersectVertical)
    {
      ((F_CutList) this).\u0001.Items[1].Focused = true;
      ((F_CutList) this).\u0001.Items[1].Selected = true;
      ((F_CutList) this).\u0001.FocusedItem = ((F_CutList) this).\u0001.Items[1];
      ((F_CutList) this).\u0001 = 1;
    }
    else if (((F_CutList) this).parShape.JunctionType == JunctionTypes.Junction2HoleNearByHorizontal)
    {
      ((F_CutList) this).\u0001.Items[2].Focused = true;
      ((F_CutList) this).\u0001.Items[2].Selected = true;
      ((F_CutList) this).\u0001.FocusedItem = ((F_CutList) this).\u0001.Items[2];
      ((F_CutList) this).\u0001 = 2;
    }
    else if (((F_CutList) this).parShape.JunctionType == JunctionTypes.Junction2HoleNearByVertical)
    {
      ((F_CutList) this).\u0001.Items[3].Focused = true;
      ((F_CutList) this).\u0001.Items[3].Selected = true;
      ((F_CutList) this).\u0001.FocusedItem = ((F_CutList) this).\u0001.Items[3];
      ((F_CutList) this).\u0001 = 3;
    }
    this.ShapeToDataGrid(((F_CutList) this).\u0001);
    ((F_ShapeAll) this).cmb_tools.Items.Clear();
    if (((F_CutList) this).ShowTool)
    {
      int num = -1;
      for (int index = 0; index <= ((F_CutList) this).Tools.Count - 1; ++index)
      {
        ((F_ShapeAll) this).cmb_tools.Items.Add((object) $"{((ToolCamData5) ((ToolGeometry5) ((F_CutList) this).Tools[index]).Data).Name} - T{((ToolCamData5) ((ToolGeometry5) ((F_CutList) this).Tools[index]).Data).No.ToString()} - D: {((ToolGeometry5) ((F_CutList) this).Tools[index]).Geometry.Diameter.ToString("f1")}");
        if (((F_CutList) this).activeTool != null && ((ToolCamData5) ((ToolGeometry5) ((F_CutList) this).Tools[index]).Data).Name == ((ToolCamData5) ((ToolGeometry5) ((F_CutList) this).activeTool).Data).Name)
          num = index;
      }
      if (((F_ShapeAll) this).cmb_tools.Items.Count > 0)
        ((F_ShapeAll) this).cmb_tools.SelectedIndex = num;
      else
        ((F_CutList) this).ShowTool = false;
    }
    if (!((F_CutList) this).\u0001)
    {
      if (!((F_CutList) this).ShowViewport & !((F_CutList) this).ShowTool)
        ((F_CutList) this).\u0001.Height = ((F_CutList) this).\u0001.Height + ((F_CutList) this).pnl_model.Height + ((F_ShapeAll) this).btn_toolsettings.Height;
      else if (!((F_CutList) this).ShowViewport & ((F_CutList) this).ShowTool)
        ((F_CutList) this).\u0001.Height = ((F_CutList) this).\u0001.Height + ((F_CutList) this).pnl_model.Height;
      else if (((F_CutList) this).ShowViewport & !((F_CutList) this).ShowTool)
        ((F_CutList) this).pnl_model.Height = ((F_CutList) this).pnl_model.Height + ((F_ShapeAll) this).btn_toolsettings.Height;
      int int32 = Convert.ToInt32((double) this.Width / 6.0);
      ((F_CutList) this).btn_back.Width = int32 - 10;
      ((F_ShapeAll) this).\u0005.Width = int32 - 10;
      ((F_CutList) this).btn_bottom.Width = int32 - 10;
      ((F_ShapeAll) this).\u0007.Width = int32 - 10;
      ((F_CutList) this).btn_front.Width = int32 - 10;
      ((F_ShapeAll) this).\u0006.Width = int32 - 10;
      ((F_CutList) this).btn_left.Width = int32 - 10;
      ((F_ShapeAll) this).\u0004.Width = int32 - 10;
      ((F_CutList) this).btn_right.Width = int32 - 10;
      ((F_ShapeAll) this).\u0002.Width = int32 - 10;
      ((F_CutList) this).btn_top.Width = int32 - 10;
      ((F_ShapeAll) this).\u0003.Width = int32 - 10;
      ((F_ShapeAll) this).\u0003.Left = ((F_CutList) this).btn_top.Left;
      ((F_CutList) this).btn_bottom.Left = ((F_CutList) this).btn_top.Left + ((F_CutList) this).btn_top.Width + 5;
      ((F_ShapeAll) this).\u0007.Left = ((F_CutList) this).btn_bottom.Left;
      ((F_CutList) this).btn_front.Left = ((F_CutList) this).btn_bottom.Left + ((F_CutList) this).btn_bottom.Width + 5;
      ((F_ShapeAll) this).\u0006.Left = ((F_CutList) this).btn_front.Left;
      ((F_CutList) this).btn_back.Left = ((F_CutList) this).btn_front.Left + ((F_CutList) this).btn_front.Width + 5;
      ((F_ShapeAll) this).\u0005.Left = ((F_CutList) this).btn_back.Left;
      ((F_CutList) this).btn_left.Left = ((F_CutList) this).btn_back.Left + ((F_CutList) this).btn_back.Width + 5;
      ((F_ShapeAll) this).\u0004.Left = ((F_CutList) this).btn_left.Left;
      ((F_CutList) this).btn_right.Left = ((F_CutList) this).btn_left.Left + ((F_CutList) this).btn_left.Width + 5;
      ((F_ShapeAll) this).\u0002.Left = ((F_CutList) this).btn_right.Left;
      ((F_CutList) this).\u0001 = true;
    }
    this.LoadLanguage();
    this.PlaneColorUpdate();
    ((F_CutList) this).\u0001.Enabled = true;
    ((F_CutList) this).PropertiesForm.Result = DialogResult.None;
  }

  private void \u0001([In] object obj0, [In] EventArgs obj1)
  {
    \u0007.\u0001.\u0001((F_JunctionList) this);
    ((F_CutList) this).btn_ok.Enabled = true;
    ((F_CutList) this).\u0001.Enabled = false;
    if (((F_CutList) this).parShape.selectedPlane == planeBoxNames.Top)
      this.\u0002((object) ((F_CutList) this).btn_top, obj1);
    if (((F_CutList) this).parShape.selectedPlane == planeBoxNames.Bottom)
      this.\u0002((object) ((F_CutList) this).btn_bottom, obj1);
    if (((F_CutList) this).parShape.selectedPlane == planeBoxNames.Front)
      this.\u0002((object) ((F_CutList) this).btn_front, obj1);
    if (((F_CutList) this).parShape.selectedPlane == planeBoxNames.Back)
      this.\u0002((object) ((F_CutList) this).btn_back, obj1);
    if (((F_CutList) this).parShape.selectedPlane == planeBoxNames.Left)
      this.\u0002((object) ((F_CutList) this).btn_left, obj1);
    if (((F_CutList) this).parShape.selectedPlane == planeBoxNames.Right)
      this.\u0002((object) ((F_CutList) this).btn_right, obj1);
    ((F_CutList) this).PropertiesForm.Inited = true;
  }

  internal void \u0001([In] object obj0, [In] FormClosingEventArgs obj1)
  {
    obj1.Cancel = true;
    ((F_CutList) this).PropertiesForm.Result = DialogResult.Cancel;
    if (((F_CutList) this).PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
      this.Dispose();
    if (((F_CutList) this).PropertiesForm.FormCloseMode == FormCloseModeType.Invisible)
    {
      this.Visible = false;
      if (this.Owner != null)
        this.Owner.Focus();
    }
    // ISSUE: reference to a compiler-generated field
    if (((F_CutList) this).\u0001 == null)
      return;
    // ISSUE: reference to a compiler-generated field
    ((F_CutList) this).\u0001();
  }

  public void LoadLanguage()
  {
    string callMethod = nameof (LoadLanguage);
    try
    {
      this.Text = buLangTranslate.preDef.Junction;
      ((F_ShapeAll) this).\u0003.Text = buLangTranslate.preDef.Top;
      ((F_ShapeAll) this).\u0005.Text = buLangTranslate.preDef.Back;
      ((F_ShapeAll) this).\u0007.Text = buLangTranslate.preDef.Bottom;
      ((F_ShapeAll) this).\u0001.Text = buLangTranslate.preDef.Command;
      ((F_ShapeAll) this).\u0006.Text = buLangTranslate.preDef.Front;
      ((F_ShapeAll) this).\u0004.Text = buLangTranslate.preDef.Left;
      ((F_ShapeAll) this).\u0002.Text = buLangTranslate.preDef.Right;
      ((F_ShapeAll) this).btn_camsettings.Text = buLangTranslate.preDef.Cam;
      ((F_CutList) this).btn_ok.Text = buLangTranslate.preDef.Ok;
      ((F_CutList) this).btn_cancel.Text = buLangTranslate.preDef.Cancel;
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
    ((F_CutList) this).btn_back.BackColor = Color.Gainsboro;
    ((F_CutList) this).btn_bottom.BackColor = Color.Gainsboro;
    ((F_CutList) this).btn_front.BackColor = Color.Gainsboro;
    ((F_CutList) this).btn_left.BackColor = Color.Gainsboro;
    ((F_CutList) this).btn_right.BackColor = Color.Gainsboro;
    ((F_CutList) this).btn_top.BackColor = Color.Gainsboro;
    if (((F_CutList) this).parShape.selectedPlane == planeBoxNames.Top)
      ((F_CutList) this).btn_top.BackColor = Color.PaleGreen;
    if (((F_CutList) this).parShape.selectedPlane == planeBoxNames.Bottom)
      ((F_CutList) this).btn_bottom.BackColor = Color.PaleGreen;
    if (((F_CutList) this).parShape.selectedPlane == planeBoxNames.Front)
      ((F_CutList) this).btn_front.BackColor = Color.PaleGreen;
    if (((F_CutList) this).parShape.selectedPlane == planeBoxNames.Back)
      ((F_CutList) this).btn_back.BackColor = Color.PaleGreen;
    if (((F_CutList) this).parShape.selectedPlane == planeBoxNames.Left)
      ((F_CutList) this).btn_left.BackColor = Color.PaleGreen;
    if (((F_CutList) this).parShape.selectedPlane != planeBoxNames.Right)
      return;
    ((F_CutList) this).btn_right.BackColor = Color.PaleGreen;
  }

  public void Apply()
  {
  }

  public void DataGridValuesToShape(int ColumnIndex, int RowIndex)
  {
    if (((F_CutList) this).\u0001.Rows.Count < 2 || ColumnIndex >= 0 & RowIndex >= 0 && !buFile5.IsNumeric(((F_CutList) this).\u0001.Rows[RowIndex].Cells[ColumnIndex].Value.ToString()))
      return;
    if (((F_CutList) this).parShape.selectedPlane == planeBoxNames.Top | ((F_CutList) this).parShape.selectedPlane == planeBoxNames.Bottom)
    {
      ((buClipper) ((F_CutList) this).selectedShape).BasePoint.X = Convert.ToDouble(((F_CutList) this).\u0001.Rows[0].Cells[1].Value);
      ((buClipper) ((F_CutList) this).selectedShape).BasePoint.Y = Convert.ToDouble(((F_CutList) this).\u0001.Rows[1].Cells[1].Value);
    }
    if (((F_CutList) this).parShape.selectedPlane == planeBoxNames.Front | ((F_CutList) this).parShape.selectedPlane == planeBoxNames.Back)
    {
      ((buClipper) ((F_CutList) this).selectedShape).BasePoint.X = Convert.ToDouble(((F_CutList) this).\u0001.Rows[0].Cells[1].Value);
      ((buClipper) ((F_CutList) this).selectedShape).BasePoint.Z = Convert.ToDouble(((F_CutList) this).\u0001.Rows[1].Cells[1].Value);
    }
    if (((F_CutList) this).parShape.selectedPlane == planeBoxNames.Left | ((F_CutList) this).parShape.selectedPlane == planeBoxNames.Right)
    {
      ((buClipper) ((F_CutList) this).selectedShape).BasePoint.Y = Convert.ToDouble(((F_CutList) this).\u0001.Rows[0].Cells[1].Value);
      ((buClipper) ((F_CutList) this).selectedShape).BasePoint.Z = Convert.ToDouble(((F_CutList) this).\u0001.Rows[1].Cells[1].Value);
    }
    if (((F_CutList) this).parShape.JunctionType == JunctionTypes.Junction3HoleIntersectHorizontal | ((F_CutList) this).parShape.JunctionType == JunctionTypes.Junction3HoleIntersectVertical)
    {
      ((CutterIsoFileSettings) ((F_CutList) this).selectedShape).Diameter = Convert.ToDouble(((F_CutList) this).\u0001.Rows[2].Cells[1].Value);
      ((CutterIsoFileSettings) ((F_CutList) this).selectedShape).Distance = Convert.ToDouble(((F_CutList) this).\u0001.Rows[3].Cells[1].Value);
      ((\u0012.\u0002) ((F_CutList) this).selectedShape).Depth = Convert.ToDouble(((F_CutList) this).\u0001.Rows[4].Cells[1].Value);
      ((CutterIsoFileItems) ((F_CutList) this).selectedShape).JunctionType = ((F_CutList) this).parShape.JunctionType;
      ((CustomDataAdd) ((F_CutList) this).parShape).JunctionDiameter = ((CutterIsoFileSettings) ((F_CutList) this).selectedShape).Diameter;
      ((CustomDataAdd) ((F_CutList) this).parShape).JunctionDistance = ((CutterIsoFileSettings) ((F_CutList) this).selectedShape).Distance;
      ((CustomDataAdd) ((F_CutList) this).parShape).JunctionDepth = ((\u0012.\u0002) ((F_CutList) this).selectedShape).Depth;
    }
    else if (((F_CutList) this).parShape.JunctionType == JunctionTypes.Junction2HoleNearByHorizontal | ((F_CutList) this).parShape.JunctionType == JunctionTypes.Junction2HoleNearByVertical)
    {
      ((CutterIsoFileSettings) ((F_CutList) this).selectedShape).Diameter = Convert.ToDouble(((F_CutList) this).\u0001.Rows[2].Cells[1].Value);
      ((CutterIsoFileSettings) ((F_CutList) this).selectedShape).DiameterOutside = Convert.ToDouble(((F_CutList) this).\u0001.Rows[3].Cells[1].Value);
      ((CutterIsoFileSettings) ((F_CutList) this).selectedShape).Distance = Convert.ToDouble(((F_CutList) this).\u0001.Rows[4].Cells[1].Value);
      ((\u0012.\u0002) ((F_CutList) this).selectedShape).Depth = Convert.ToDouble(((F_CutList) this).\u0001.Rows[5].Cells[1].Value);
      ((CutterIsoFileItems) ((F_CutList) this).selectedShape).JunctionType = ((F_CutList) this).parShape.JunctionType;
      ((CustomDataAdd) ((F_CutList) this).parShape).JunctionDiameter = ((CutterIsoFileSettings) ((F_CutList) this).selectedShape).Diameter;
      ((CustomDataAdd) ((F_CutList) this).parShape).JunctionDiameterOutside = ((CutterIsoFileSettings) ((F_CutList) this).selectedShape).DiameterOutside;
      ((CustomDataAdd) ((F_CutList) this).parShape).JunctionDistance = ((CutterIsoFileSettings) ((F_CutList) this).selectedShape).Distance;
      ((CustomDataAdd) ((F_CutList) this).parShape).JunctionDepth = ((\u0012.\u0002) ((F_CutList) this).selectedShape).Depth;
    }
    ((CutterRuntimeSettings) ((F_CutList) this).selectedShape).isMilling = ((F_ShapeAll) this).\u0001.Checked;
    ((F_CutList) this).parShape.isMillingJunction = ((F_ShapeAll) this).\u0001.Checked;
    ((F_CutList) this).parShape.pntBase.X = ((buClipper) ((F_CutList) this).selectedShape).BasePoint.X;
    ((F_CutList) this).parShape.pntBase.Y = ((buClipper) ((F_CutList) this).selectedShape).BasePoint.Y;
    ((F_CutList) this).parShape.pntBase.Z = ((buClipper) ((F_CutList) this).selectedShape).BasePoint.Z;
  }

  public void ShapeToDataGrid(int Index)
  {
    ((F_CutList) this).\u0001.Rows.Clear();
    if (((F_CutList) this).parShape.selectedPlane == planeBoxNames.Top | ((F_CutList) this).parShape.selectedPlane == planeBoxNames.Bottom)
    {
      ((F_CutList) this).\u0001.Rows.Add(\u0007.\u0001.\u0001(((F_CutList) this).parShape.pntBase.X, (F_JunctionList) this, "X"));
      ((F_CutList) this).\u0001.Rows.Add(\u0007.\u0001.\u0001(((F_CutList) this).parShape.pntBase.Y, (F_JunctionList) this, "Y"));
    }
    if (((F_CutList) this).parShape.selectedPlane == planeBoxNames.Left | ((F_CutList) this).parShape.selectedPlane == planeBoxNames.Right)
    {
      ((F_CutList) this).\u0001.Rows.Add(\u0007.\u0001.\u0001(((F_CutList) this).parShape.pntBase.Y, (F_JunctionList) this, "Y"));
      ((F_CutList) this).\u0001.Rows.Add(\u0007.\u0001.\u0001(((F_CutList) this).parShape.pntBase.Z, (F_JunctionList) this, "Z"));
    }
    if (((F_CutList) this).parShape.selectedPlane == planeBoxNames.Front | ((F_CutList) this).parShape.selectedPlane == planeBoxNames.Back)
    {
      ((F_CutList) this).\u0001.Rows.Add(\u0007.\u0001.\u0001(((F_CutList) this).parShape.pntBase.X, (F_JunctionList) this, "X"));
      ((F_CutList) this).\u0001.Rows.Add(\u0007.\u0001.\u0001(((F_CutList) this).parShape.pntBase.Z, (F_JunctionList) this, "Z"));
    }
    if (Index == 0 | Index == 1)
    {
      JunctionTypes junctionType = JunctionTypes.Junction3HoleIntersectHorizontal;
      if (Index == 0)
      {
        ((F_CutList) this).parShape.JunctionType = JunctionTypes.Junction3HoleIntersectHorizontal;
        junctionType = JunctionTypes.Junction3HoleIntersectHorizontal;
      }
      if (Index == 1)
      {
        ((F_CutList) this).parShape.JunctionType = JunctionTypes.Junction3HoleIntersectVertical;
        junctionType = JunctionTypes.Junction3HoleIntersectVertical;
      }
      ((F_CutList) this).selectedShape = (buShape) new buSelectionPoint(junctionType, ((CustomDataAdd) ((F_CutList) this).parShape).JunctionDiameter, ((CustomDataAdd) ((F_CutList) this).parShape).JunctionDepth, ((CustomDataAdd) ((F_CutList) this).parShape).JunctionDiameterOutside, ((CustomDataAdd) ((F_CutList) this).parShape).JunctionDistance, ((F_CutList) this).parShape.isMillingJunction);
      ((CutterIsoFileItems) ((F_CutList) this).selectedShape).JunctionType = junctionType;
      ((CutterRuntimeSettings) ((F_CutList) this).selectedShape).isMilling = ((F_CutList) this).parShape.isMillingCut;
      ((F_CutList) this).parShape.JunctionType = junctionType;
      ((buClipper) ((F_CutList) this).selectedShape).BasePoint = new Point3D(((F_CutList) this).parShape.pntBase.X, ((F_CutList) this).parShape.pntBase.Y, ((F_CutList) this).parShape.pntBase.Z);
      ((buClipperBase) ((F_CutList) this).selectedShape).planeName = ((F_CutList) this).parShape.selectedPlane;
      ((buClipper) ((F_CutList) this).selectedShape).planeOperation = buCall.\u0001.PlaneNameToPlane(((buClipperBase) ((F_CutList) this).selectedShape).planeName);
      ((buClipperBase) ((F_CutList) this).selectedShape).Corner = ((F_CutList) this).parShape.selectedCorner;
      ((buClipperBase) ((F_CutList) this).selectedShape).Alignment = ((F_CutList) this).parShape.objectAlignment;
      ((F_CutList) this).\u0001.Rows.Add(\u0007.\u0001.\u0001(((CutterIsoFileSettings) ((F_CutList) this).selectedShape).Diameter, (F_JunctionList) this, buLangTranslate.preDef.Diameter));
      ((F_CutList) this).\u0001.Rows.Add(\u0007.\u0001.\u0001(((CutterIsoFileSettings) ((F_CutList) this).selectedShape).Distance, (F_JunctionList) this, buLangTranslate.preDef.Distance));
      ((F_CutList) this).\u0001.Rows.Add(\u0007.\u0001.\u0001(((\u0012.\u0002) ((F_CutList) this).selectedShape).Depth, (F_JunctionList) this, buLangTranslate.preDef.Depth));
    }
    else if (Index == 2 | Index == 3)
    {
      JunctionTypes junctionType = JunctionTypes.Junction2HoleNearByHorizontal;
      if (Index == 2)
      {
        ((F_CutList) this).parShape.JunctionType = JunctionTypes.Junction2HoleNearByHorizontal;
        junctionType = JunctionTypes.Junction2HoleNearByHorizontal;
      }
      if (Index == 3)
      {
        ((F_CutList) this).parShape.JunctionType = JunctionTypes.Junction2HoleNearByVertical;
        junctionType = JunctionTypes.Junction2HoleNearByVertical;
      }
      ((F_CutList) this).selectedShape = (buShape) new buSelectionPoint(junctionType, ((CustomDataAdd) ((F_CutList) this).parShape).JunctionDiameter, ((CustomDataAdd) ((F_CutList) this).parShape).JunctionDepth, ((CustomDataAdd) ((F_CutList) this).parShape).JunctionDiameterOutside, ((CustomDataAdd) ((F_CutList) this).parShape).JunctionDistance, ((F_CutList) this).parShape.isMillingJunction);
      ((CutterIsoFileItems) ((F_CutList) this).selectedShape).JunctionType = junctionType;
      ((CutterRuntimeSettings) ((F_CutList) this).selectedShape).isMilling = ((F_CutList) this).parShape.isMillingCut;
      ((F_CutList) this).parShape.JunctionType = junctionType;
      ((buClipper) ((F_CutList) this).selectedShape).BasePoint = new Point3D(((F_CutList) this).parShape.pntBase.X, ((F_CutList) this).parShape.pntBase.Y, ((F_CutList) this).parShape.pntBase.Z);
      ((buClipperBase) ((F_CutList) this).selectedShape).planeName = ((F_CutList) this).parShape.selectedPlane;
      ((buClipper) ((F_CutList) this).selectedShape).planeOperation = buCall.\u0001.PlaneNameToPlane(((buClipperBase) ((F_CutList) this).selectedShape).planeName);
      ((buClipperBase) ((F_CutList) this).selectedShape).Corner = ((F_CutList) this).parShape.selectedCorner;
      ((buClipperBase) ((F_CutList) this).selectedShape).Alignment = ((F_CutList) this).parShape.objectAlignment;
      ((F_CutList) this).\u0001.Rows.Add(\u0007.\u0001.\u0001(((CutterIsoFileSettings) ((F_CutList) this).selectedShape).Diameter, (F_JunctionList) this, buLangTranslate.preDef.Diameter));
      ((F_CutList) this).\u0001.Rows.Add(\u0007.\u0001.\u0001(((CutterIsoFileSettings) ((F_CutList) this).selectedShape).DiameterOutside, (F_JunctionList) this, $"{buLangTranslate.preDef.Diameter} {buLangTranslate.preDef.Outside}"));
      ((F_CutList) this).\u0001.Rows.Add(\u0007.\u0001.\u0001(((CutterIsoFileSettings) ((F_CutList) this).selectedShape).Distance, (F_JunctionList) this, buLangTranslate.preDef.Distance));
      ((F_CutList) this).\u0001.Rows.Add(\u0007.\u0001.\u0001(((\u0012.\u0002) ((F_CutList) this).selectedShape).Depth, (F_JunctionList) this, buLangTranslate.preDef.Depth));
    }
    ((F_ShapeAll) this).\u0001.Checked = ((F_CutList) this).parShape.isMillingJunction;
    ((buClipper) ((F_CutList) this).selectedShape).CamPar = (camParameters5) new camRuntime5(((F_CutList) this).CamPar);
    ((F_ShapeAll) this).\u0001.Text = ((buNestedSheet) buCall.\u0001).JobItemCommandToString(((F_CutList) this).selectedShape);
  }

  private void \u0001([In] object obj0, [In] DataGridViewCellEventArgs obj1)
  {
    if (!((F_CutList) this).PropertiesForm.Inited || !(obj1.ColumnIndex >= 0 & obj1.RowIndex >= 0))
      return;
    ShapeUpdateArg Data2 = (ShapeUpdateArg) new hmiUICommands();
    this.DataGridValuesToShape(obj1.ColumnIndex, obj1.RowIndex);
    // ISSUE: reference to a compiler-generated field
    if (((F_CutList) this).\u0001 == null)
      return;
    ((ShapeRuntimeData) Data2).Parameters = (ShapeRuntimeData) new hmiUICommands(((F_CutList) this).parShape);
    // ISSUE: reference to a compiler-generated field
    ((F_CutList) this).\u0001((object) ((F_CutList) this).selectedShape, (object) Data2);
  }

  private void \u0002([In] object obj0, [In] DataGridViewCellEventArgs obj1)
  {
    if (!((F_CutList) this).PropertiesForm.Inited || !(obj1.ColumnIndex >= 0 & obj1.RowIndex >= 0))
      return;
    ShapeUpdateArg Data2 = (ShapeUpdateArg) new hmiUICommands();
    this.DataGridValuesToShape(obj1.ColumnIndex, obj1.RowIndex);
    ((dynamicInfo) F_NotchEdit.ShapeTempPar).ValueGridIndex = obj1.RowIndex;
    buCall.\u0001.FindShapeDataValueType(((F_CutList) this).selectedShape, obj1.RowIndex, ref ((dynamicInfo) F_NotchEdit.ShapeTempPar).ValueType);
    // ISSUE: reference to a compiler-generated field
    if (((F_CutList) this).\u0001 == null)
      return;
    ((ShapeRuntimeData) Data2).Parameters = (ShapeRuntimeData) new hmiUICommands(((F_CutList) this).parShape);
    // ISSUE: reference to a compiler-generated field
    ((F_CutList) this).\u0001((object) ((F_CutList) this).selectedShape, (object) Data2);
  }

  private void \u0003([In] object obj0, [In] DataGridViewCellEventArgs obj1)
  {
    if (!((F_CutList) this).PropertiesForm.Inited || !(obj1.ColumnIndex >= 0 & obj1.RowIndex >= 0))
      return;
    ShapeUpdateArg Data2 = (ShapeUpdateArg) new hmiUICommands();
    this.DataGridValuesToShape(obj1.ColumnIndex, obj1.RowIndex);
    ((dynamicInfo) F_NotchEdit.ShapeTempPar).ValueGridIndex = obj1.RowIndex;
    buCall.\u0001.FindShapeDataValueType(((F_CutList) this).selectedShape, obj1.RowIndex, ref ((dynamicInfo) F_NotchEdit.ShapeTempPar).ValueType);
    // ISSUE: reference to a compiler-generated field
    if (((F_CutList) this).\u0001 == null)
      return;
    ((ShapeRuntimeData) Data2).Parameters = (ShapeRuntimeData) new hmiUICommands(((F_CutList) this).parShape);
    // ISSUE: reference to a compiler-generated field
    ((F_CutList) this).\u0001((object) ((F_CutList) this).selectedShape, (object) Data2);
  }

  internal void \u0002([In] object obj0, [In] EventArgs obj1)
  {
    Control control = obj0 as Control;
    if (control.Name == ((F_CutList) this).btn_ok.Name)
    {
      ((F_CutList) this).PropertiesForm.Result = DialogResult.OK;
      if (((F_CutList) this).ClosePageAfterOk)
      {
        if (((F_CutList) this).PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
          this.Dispose();
        if (((F_CutList) this).PropertiesForm.FormCloseMode == FormCloseModeType.Invisible)
          this.Visible = false;
      }
      // ISSUE: reference to a compiler-generated field
      if (((F_CutList) this).\u0001 != null)
      {
        this.DataGridValuesToShape(-1, -1);
        ShapeUpdateArg Data2 = (ShapeUpdateArg) new hmiUICommands(((F_CutList) this).parShape);
        ((ShapeRuntimeData) Data2).Finished = true;
        // ISSUE: reference to a compiler-generated field
        ((F_CutList) this).\u0001((object) ((F_CutList) this).selectedShape, (object) Data2);
      }
      if (this.Owner != null)
        this.Owner.Focus();
    }
    if (control.Name == ((F_CutList) this).btn_cancel.Name)
    {
      ((F_CutList) this).PropertiesForm.Result = DialogResult.Cancel;
      if (((F_CutList) this).PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
        this.Dispose();
      if (((F_CutList) this).PropertiesForm.FormCloseMode == FormCloseModeType.Invisible)
        this.Visible = false;
      if (this.Owner != null)
        this.Owner.Focus();
      // ISSUE: reference to a compiler-generated field
      if (((F_CutList) this).\u0001 != null)
      {
        // ISSUE: reference to a compiler-generated field
        ((F_CutList) this).\u0001();
      }
    }
    if (control.Name == ((F_ShapeAll) this).\u0001.Name)
    {
      F_CornerLocation fCornerLocation = (F_CornerLocation) new F_Contour();
      ((F_CabinetSettings) fCornerLocation).Corner = ((F_CutList) this).parShape.selectedCorner;
      ((F_CabinetSettings) fCornerLocation).Properties.FormCloseMode = FormCloseModeType.Dispose;
      ((F_Contour) fCornerLocation).Init();
      int num = (int) fCornerLocation.ShowDialog((IWin32Window) this);
      if (((F_CabinetSettings) fCornerLocation).Properties.Result == DialogResult.OK)
      {
        ((buClipperBase) ((F_CutList) this).selectedShape).Corner = ((F_CabinetSettings) fCornerLocation).Corner;
        ((F_CutList) this).parShape.selectedCorner = ((F_CabinetSettings) fCornerLocation).Corner;
        ((F_ShapeAll) this).\u0001.ImageIndex = Convert.ToInt32((object) ((F_CutList) this).parShape.selectedCorner);
        // ISSUE: reference to a compiler-generated field
        if (((F_CutList) this).\u0001 != null)
        {
          this.DataGridValuesToShape(-1, -1);
          ShapeUpdateArg Data2 = (ShapeUpdateArg) new hmiUICommands(((F_CutList) this).parShape);
          ((ShapeRuntimeData) Data2).Finished = false;
          // ISSUE: reference to a compiler-generated field
          ((F_CutList) this).\u0001((object) ((F_CutList) this).selectedShape, (object) Data2);
        }
      }
      this.Focus();
      if (this.Owner != null)
        this.Owner.Focus();
    }
    if (control.Name == ((F_ShapeAll) this).\u0002.Name)
    {
      F_ObjectLocation fObjectLocation = (F_ObjectLocation) new F_Contour();
      ((F_KeyPadNumV1) fObjectLocation).Alingnment = ((F_CutList) this).parShape.objectAlignment;
      ((F_KeyPadNumV1) fObjectLocation).Properties.FormCloseMode = FormCloseModeType.Dispose;
      ((F_Contour) fObjectLocation).Init();
      int num = (int) fObjectLocation.ShowDialog((IWin32Window) this);
      if (((F_KeyPadNumV1) fObjectLocation).Properties.Result == DialogResult.OK)
      {
        ((buClipperBase) ((F_CutList) this).selectedShape).Alignment = ((F_KeyPadNumV1) fObjectLocation).Alingnment;
        ((F_CutList) this).parShape.objectAlignment = ((F_KeyPadNumV1) fObjectLocation).Alingnment;
        ((F_ShapeAll) this).\u0002.ImageIndex = Convert.ToInt32((object) ((F_CutList) this).parShape.objectAlignment);
        // ISSUE: reference to a compiler-generated field
        if (((F_CutList) this).\u0001 != null)
        {
          this.DataGridValuesToShape(-1, -1);
          ShapeUpdateArg Data2 = (ShapeUpdateArg) new hmiUICommands(((F_CutList) this).parShape);
          ((ShapeRuntimeData) Data2).Finished = false;
          // ISSUE: reference to a compiler-generated field
          ((F_CutList) this).\u0001((object) ((F_CutList) this).selectedShape, (object) Data2);
        }
      }
      this.Focus();
      if (this.Owner != null)
        this.Owner.Focus();
    }
    if (control.Name == ((F_ShapeAll) this).\u0003.Name && ((F_CutList) this).selectedShape is buShapeJunction)
    {
      buShapeJunction selectedShape = ((F_CutList) this).selectedShape as buShapeJunction;
      if (!((CutterRuntimeSettings) selectedShape).isMilling)
        ((CutterRuntimeSettings) selectedShape).isMilling = true;
      else
        ((CutterRuntimeSettings) selectedShape).isMilling = false;
      ((F_ShapeAll) this).\u0001.Checked = ((CutterRuntimeSettings) selectedShape).isMilling;
      ((F_CutList) this).parShape.isMillingJunction = ((CutterRuntimeSettings) selectedShape).isMilling;
      this.ShapeToDataGrid(((F_CutList) this).\u0001);
      // ISSUE: reference to a compiler-generated field
      if (((F_CutList) this).\u0001 != null)
      {
        ShapeUpdateArg Data2 = (ShapeUpdateArg) new hmiUICommands();
        ((ShapeRuntimeData) Data2).Parameters = (ShapeRuntimeData) new hmiUICommands(((F_CutList) this).parShape);
        // ISSUE: reference to a compiler-generated field
        ((F_CutList) this).\u0001((object) ((F_CutList) this).selectedShape, (object) Data2);
      }
    }
    if (control.Name == ((F_ShapeAll) this).btn_camsettings.Name)
    {
      F_CamSettings1 fCamSettings1 = (F_CamSettings1) new buEntity();
      ((buMultilineText) fCamSettings1).Properties.FormCloseMode = FormCloseModeType.Dispose;
      ((buMultilineText) fCamSettings1).CamPar = (camParameters5) new camRuntime5(((F_CutList) this).CamPar);
      ((buEntity) fCamSettings1).Init();
      int num = (int) fCamSettings1.ShowDialog((IWin32Window) this);
      if (((buMultilineText) fCamSettings1).Properties.Result == DialogResult.OK)
      {
        ((buClipper) ((F_CutList) this).selectedShape).CamPar = (camParameters5) new camRuntime5(((buMultilineText) fCamSettings1).CamPar);
        ((F_CutList) this).CamPar = (camParameters5) new camRuntime5(((buMultilineText) fCamSettings1).CamPar);
      }
      this.Focus();
    }
    if (!(control.Name == ((F_CutList) this).btn_top.Name | control.Name == ((F_CutList) this).btn_bottom.Name | control.Name == ((F_CutList) this).btn_left.Name | control.Name == ((F_CutList) this).btn_right.Name | control.Name == ((F_CutList) this).btn_front.Name | control.Name == ((F_CutList) this).btn_back.Name))
      return;
    if (control.Name == ((F_CutList) this).btn_top.Name)
      ((F_CutList) this).parShape.selectedPlane = planeBoxNames.Top;
    if (control.Name == ((F_CutList) this).btn_bottom.Name)
      ((F_CutList) this).parShape.selectedPlane = planeBoxNames.Bottom;
    if (control.Name == ((F_CutList) this).btn_left.Name)
      ((F_CutList) this).parShape.selectedPlane = planeBoxNames.Left;
    if (control.Name == ((F_CutList) this).btn_right.Name)
      ((F_CutList) this).parShape.selectedPlane = planeBoxNames.Right;
    if (control.Name == ((F_CutList) this).btn_front.Name)
      ((F_CutList) this).parShape.selectedPlane = planeBoxNames.Front;
    if (control.Name == ((F_CutList) this).btn_back.Name)
      ((F_CutList) this).parShape.selectedPlane = planeBoxNames.Back;
    this.PlaneColorUpdate();
    int valueGridIndex = ((dynamicInfo) F_NotchEdit.ShapeTempPar).ValueGridIndex;
    if (valueGridIndex >= 0 & valueGridIndex <= ((F_CutList) this).\u0001.Rows.Count - 1)
    {
      ((buClipperBase) ((F_CutList) this).selectedShape).planeName = ((F_CutList) this).parShape.selectedPlane;
      ((buClipper) ((F_CutList) this).selectedShape).planeOperation = buCall.\u0001.PlaneNameToPlane(((buClipperBase) ((F_CutList) this).selectedShape).planeName);
      this.ShapeToDataGrid(((F_CutList) this).\u0001);
      ((dynamicInfo) F_NotchEdit.ShapeTempPar).ValueGridIndex = valueGridIndex;
      for (int index = 0; index <= ((F_CutList) this).\u0001.Rows.Count - 1; ++index)
      {
        ((F_CutList) this).\u0001.Rows[index].Cells[0].Selected = false;
        ((F_CutList) this).\u0001.Rows[index].Cells[1].Selected = false;
      }
      ((F_CutList) this).\u0001.Rows[valueGridIndex].Cells[0].Selected = true;
    }
    // ISSUE: reference to a compiler-generated field
    if (((F_CutList) this).\u0001 == null)
      return;
    ShapeUpdateArg Data2_1 = (ShapeUpdateArg) new hmiUICommands(((F_CutList) this).parShape);
    ((buClipperBase) ((F_CutList) this).selectedShape).planeName = ((F_CutList) this).parShape.selectedPlane;
    ((buClipper) ((F_CutList) this).selectedShape).planeOperation = buCall.\u0001.PlaneNameToPlane(((F_CutList) this).parShape.selectedPlane);
    ((buClipperBase) ((F_CutList) this).selectedShape).Corner = ((F_CutList) this).parShape.selectedCorner;
    ((buClipperBase) ((F_CutList) this).selectedShape).Alignment = ((F_CutList) this).parShape.objectAlignment;
    // ISSUE: reference to a compiler-generated field
    ((F_CutList) this).\u0001((object) ((F_CutList) this).selectedShape, (object) Data2_1);
  }

  internal void \u0003([In] object obj0, [In] EventArgs obj1)
  {
    Control control = obj0 as Control;
    if (!((F_CutList) this).PropertiesForm.Inited)
      return;
    if (control.Name == ((F_ShapeAll) this).\u0001.Name && ((F_CutList) this).selectedShape is buShapeJunction)
    {
      buShapeJunction selectedShape = ((F_CutList) this).selectedShape as buShapeJunction;
      ((CutterRuntimeSettings) selectedShape).isMilling = ((F_ShapeAll) this).\u0001.Checked;
      ((F_CutList) this).parShape.isMillingJunction = ((CutterRuntimeSettings) selectedShape).isMilling;
      this.ShapeToDataGrid(((F_CutList) this).\u0001);
      // ISSUE: reference to a compiler-generated field
      if (((F_CutList) this).\u0001 != null)
      {
        ShapeUpdateArg Data2 = (ShapeUpdateArg) new hmiUICommands();
        ((ShapeRuntimeData) Data2).Parameters = (ShapeRuntimeData) new hmiUICommands(((F_CutList) this).parShape);
        // ISSUE: reference to a compiler-generated field
        ((F_CutList) this).\u0001((object) ((F_CutList) this).selectedShape, (object) Data2);
      }
    }
    ((F_CutList) this).PropertiesForm.Inited = false;
    this.Apply();
    ((F_CutList) this).PropertiesForm.Inited = true;
    \u0007.\u0001.\u0001(obj0, (F_JunctionList) this, (EventArgs) null);
  }

  internal void \u0001([In] object obj0, [In] ListViewItemSelectionChangedEventArgs obj1)
  {
    if (!((F_CutList) this).PropertiesForm.Inited || !(obj1.ItemIndex >= 0 & obj1.IsSelected))
      return;
    this.ShapeToDataGrid(obj1.ItemIndex);
    ((F_CutList) this).\u0001 = obj1.ItemIndex;
    // ISSUE: reference to a compiler-generated field
    if (((F_CutList) this).\u0001 == null)
      return;
    ShapeUpdateArg Data2 = (ShapeUpdateArg) new hmiUICommands();
    ((ShapeRuntimeData) Data2).Parameters = (ShapeRuntimeData) new hmiUICommands(((F_CutList) this).parShape);
    // ISSUE: reference to a compiler-generated field
    ((F_CutList) this).\u0001((object) ((F_CutList) this).selectedShape, (object) Data2);
  }

  protected override void Dispose(bool disposing)
  {
    if ((!disposing ? 0 : (((F_CutList) this).\u0001 != null ? 1 : 0)) != 0)
      ((F_CutList) this).\u0001.Dispose();
    base.Dispose(disposing);
  }

  static F_ShapeList() => F_CutList.Captions = new List<string>();

  public F_ShapeList()
  {
    ((F_ShapeAll) this).PropertiesForm = new FormProperties();
    ((F_ShapeAll) this).ShowViewport = true;
    ((F_ShapeAll) this).ShowCamSettings = true;
    ((F_ShapeAll) this).ShowTool = false;
    ((F_ShapeAll) this).ShowObjectPosition = true;
    ((F_ShapeAll) this).ShowCornerLocation = true;
    ((F_ShapeAll) this).EnableTopPlane = true;
    ((F_ShapeAll) this).EnableBottomPlane = true;
    ((F_ShapeAll) this).EnableLeftPlane = true;
    ((F_ShapeAll) this).EnableRightPlane = true;
    ((F_ShapeAll) this).EnableFrontPlane = true;
    ((F_ShapeAll) this).EnableBacktPlane = true;
    ((F_ShapeAll) this).ClosePageAfterOk = true;
    ((F_ShapeAll) this).entMesh = (Entity) null;
    ((F_ShapeAll) this).Tools = new List<ToolBase5>();
    ((F_ShapeAll) this).activeTool = (ToolBase5) null;
    ((F_ShapeAll) this).selectedShape = (buShape) null;
    ((F_ShapeAll) this).CamPar = (camParameters5) null;
    ((F_ShapeAll) this).parShape = (ShapeRuntimeData) new hmiUICommands();
    ((F_ShapeAll) this).\u0001 = new System.Windows.Forms.Timer();
    ((F_ShapeAll) this).\u0001 = -1;
    ((F_ShapeAll) this).\u0001 = false;
    ((F_ShapeAll) this).\u0001 = (IContainer) null;
    // ISSUE: explicit constructor call
    base.\u002Ector();
    \u0007.\u0001.\u0001((F_EngraveList) this);
    ((F_ShapeAll) this).\u0001.Interval = 100;
    ((F_ShapeAll) this).\u0001.Tick += new EventHandler(((F_SewingCodes) this).\u0001);
  }

  [CompilerGenerated]
  [SpecialName]
  public void add_DataOk(OkCommandWithTwoDataEventHandler value)
  {
    // ISSUE: reference to a compiler-generated field
    OkCommandWithTwoDataEventHandler dataEventHandler = ((F_ShapeAll) this).\u0001;
    OkCommandWithTwoDataEventHandler comparand;
    do
    {
      comparand = dataEventHandler;
      // ISSUE: reference to a compiler-generated field
      dataEventHandler = Interlocked.CompareExchange<OkCommandWithTwoDataEventHandler>(ref ((F_ShapeAll) this).\u0001, comparand + value, comparand);
    }
    while (dataEventHandler != comparand);
  }

  public event OkCommandWithTwoDataEventHandler DataOk;

  public event CancelCommandEventHandler DataCancel;
}
