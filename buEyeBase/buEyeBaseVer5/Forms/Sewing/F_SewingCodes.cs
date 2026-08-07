// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Forms.Sewing.F_SewingCodes
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using buControls.Controls;
using buEyeBaseVer5.Apps;
using buEyeBaseVer5.buClipperLib;
using buEyeBaseVer5.buEntities;
using buEyeBaseVer5.Forms.Shape;
using devDept.Geometry;
using System;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;

#nullable disable
namespace buEyeBaseVer5.Forms.Sewing;

public class F_SewingCodes : Form
{
  public buSpin spn_polygondiameter;
  public buSpin spn_polygonside;
  internal PictureBox \u0005;
  public buSpin spn_trianglewidth;
  public buSpin spn_triangleheight;
  internal PictureBox \u0006;
  public buSpin spn_trapezlength1;
  public buSpin spn_trapezlength2;
  public buSpin spn_trapezheight;
  internal PictureBox \u0007;
  public TabPage tabPage_roundrect;
  public TabPage tabPage_ellipse;
  public TabPage tabPage_polygon;
  public TabPage tabPage_triangle;
  public TabPage tabPage_trapez;
  internal buCheckBox \u0001;
  public buSpin spn_slotheight;
  public buSpin spn_slotwidth;
  internal PictureBox \u0008;
  public TabPage tabPage_keyhole;
  public buSpin spn_keyholelength;

  [CompilerGenerated]
  [SpecialName]
  public void remove_DataOk(OkCommandWithTwoDataEventHandler value)
  {
    // ISSUE: reference to a compiler-generated field
    OkCommandWithTwoDataEventHandler dataEventHandler = ((F_ShapeAll) this).\u0001;
    OkCommandWithTwoDataEventHandler comparand;
    do
    {
      comparand = dataEventHandler;
      // ISSUE: reference to a compiler-generated field
      dataEventHandler = Interlocked.CompareExchange<OkCommandWithTwoDataEventHandler>(ref ((F_ShapeAll) this).\u0001, comparand - value, comparand);
    }
    while (dataEventHandler != comparand);
  }

  [CompilerGenerated]
  [SpecialName]
  public void add_DataCancel(CancelCommandEventHandler value)
  {
    // ISSUE: reference to a compiler-generated field
    CancelCommandEventHandler commandEventHandler = ((F_ShapeAll) this).\u0001;
    CancelCommandEventHandler comparand;
    do
    {
      comparand = commandEventHandler;
      // ISSUE: reference to a compiler-generated field
      commandEventHandler = Interlocked.CompareExchange<CancelCommandEventHandler>(ref ((F_ShapeAll) this).\u0001, comparand + value, comparand);
    }
    while (commandEventHandler != comparand);
  }

  [CompilerGenerated]
  [SpecialName]
  public void remove_DataCancel(CancelCommandEventHandler value)
  {
    // ISSUE: reference to a compiler-generated field
    CancelCommandEventHandler commandEventHandler = ((F_ShapeAll) this).\u0001;
    CancelCommandEventHandler comparand;
    do
    {
      comparand = commandEventHandler;
      // ISSUE: reference to a compiler-generated field
      commandEventHandler = Interlocked.CompareExchange<CancelCommandEventHandler>(ref ((F_ShapeAll) this).\u0001, comparand - value, comparand);
    }
    while (commandEventHandler != comparand);
  }

  public void Init()
  {
    ((F_ShapeAll) this).PropertiesForm.Inited = false;
    if (((F_ShapeAll) this).PropertiesForm.Height > 10)
      this.Height = ((F_ShapeAll) this).PropertiesForm.Height;
    if (((F_ShapeAll) this).PropertiesForm.Width > 10)
      this.Width = ((F_ShapeAll) this).PropertiesForm.Width;
    this.TopMost = ((F_ShapeAll) this).PropertiesForm.TopMost;
    this.StartPosition = ((F_ShapeAll) this).PropertiesForm.FormPosition;
    ((F_ShapeAll) this).\u0001 = 0;
    ((F_ShapeAll) this).pnl_model.Visible = ((F_ShapeAll) this).ShowViewport;
    ((F_ShapeEdit) this).cmb_tools.Visible = ((F_ShapeAll) this).ShowTool;
    ((F_ShapeEdit) this).btn_camsettings.Visible = ((F_ShapeAll) this).ShowCamSettings;
    ((F_ShapeEdit) this).btn_toolsettings.Visible = ((F_ShapeAll) this).ShowTool;
    ((F_ShapeEdit) this).\u0002.Visible = ((F_ShapeAll) this).ShowObjectPosition;
    ((F_ShapeEdit) this).\u0001.Visible = ((F_ShapeAll) this).ShowCornerLocation;
    ((F_ShapeEdit) this).\u0002.ImageIndex = Convert.ToInt32((object) ((F_ShapeAll) this).parShape.objectAlignment);
    ((F_ShapeEdit) this).\u0001.ImageIndex = Convert.ToInt32((object) ((F_ShapeAll) this).parShape.selectedCorner);
    ((F_ShapeAll) this).btn_back.Enabled = ((F_ShapeAll) this).EnableBacktPlane;
    ((F_ShapeAll) this).btn_front.Enabled = ((F_ShapeAll) this).EnableFrontPlane;
    ((F_ShapeEdit) this).btn_top.Enabled = ((F_ShapeAll) this).EnableTopPlane;
    ((F_ShapeEdit) this).btn_bottom.Enabled = ((F_ShapeAll) this).EnableBottomPlane;
    ((F_ShapeEdit) this).btn_left.Enabled = ((F_ShapeAll) this).EnableLeftPlane;
    ((F_ShapeAll) this).btn_right.Enabled = ((F_ShapeAll) this).EnableRightPlane;
    if (((F_ShapeAll) this).\u0001.Columns.Count == 0)
    {
      DataGridViewColumn dataGridViewColumn1 = new DataGridViewColumn();
      dataGridViewColumn1.SortMode = DataGridViewColumnSortMode.NotSortable;
      dataGridViewColumn1.Width = Convert.ToInt32((double) ((F_ShapeAll) this).\u0001.Width * 0.65);
      dataGridViewColumn1.HeaderText = "Name";
      dataGridViewColumn1.Name = "Name";
      dataGridViewColumn1.ReadOnly = true;
      dataGridViewColumn1.DefaultCellStyle.Font = new Font("Arial", 10f, FontStyle.Bold);
      dataGridViewColumn1.CellTemplate = (DataGridViewCell) new DataGridViewTextBoxCell();
      ((F_ShapeAll) this).\u0001.Columns.Add(dataGridViewColumn1);
      DataGridViewColumn dataGridViewColumn2 = new DataGridViewColumn();
      dataGridViewColumn2.SortMode = DataGridViewColumnSortMode.NotSortable;
      dataGridViewColumn2.Width = ((F_ShapeAll) this).\u0001.Width - dataGridViewColumn1.Width - 20;
      dataGridViewColumn2.HeaderText = "Value";
      dataGridViewColumn2.Name = "Value";
      dataGridViewColumn2.ReadOnly = false;
      dataGridViewColumn2.DefaultCellStyle.Font = new Font("Arial", 10f, FontStyle.Bold);
      dataGridViewColumn2.CellTemplate = (DataGridViewCell) new DataGridViewTextBoxCell();
      ((F_ShapeAll) this).\u0001.Columns.Add(dataGridViewColumn2);
      ((F_ShapeAll) this).\u0001.CellValueChanged += new DataGridViewCellEventHandler(this.\u0001);
      ((F_ShapeAll) this).\u0001.CellClick += new DataGridViewCellEventHandler(this.\u0002);
      ((F_ShapeAll) this).\u0001.CellEnter += new DataGridViewCellEventHandler(this.\u0003);
    }
    ((F_ShapeAll) this).\u0001.RowHeadersVisible = false;
    ((F_ShapeAll) this).\u0001.ColumnHeadersVisible = false;
    ((F_ShapeAll) this).\u0001.AllowUserToAddRows = false;
    ((F_ShapeAll) this).\u0001.AllowUserToResizeColumns = false;
    ((F_ShapeAll) this).\u0001.AllowUserToResizeRows = false;
    ((F_ShapeEdit) this).cmb_tools.Items.Clear();
    if (((F_ShapeAll) this).ShowTool)
    {
      int num = -1;
      for (int index = 0; index <= ((F_ShapeAll) this).Tools.Count - 1; ++index)
      {
        ((F_ShapeEdit) this).cmb_tools.Items.Add((object) $"{((ToolCamData5) ((ToolGeometry5) ((F_ShapeAll) this).Tools[index]).Data).Name} - T{((ToolCamData5) ((ToolGeometry5) ((F_ShapeAll) this).Tools[index]).Data).No.ToString()} - D: {((ToolGeometry5) ((F_ShapeAll) this).Tools[index]).Geometry.Diameter.ToString("f1")}");
        if (((F_ShapeAll) this).activeTool != null && ((ToolCamData5) ((ToolGeometry5) ((F_ShapeAll) this).Tools[index]).Data).Name == ((ToolCamData5) ((ToolGeometry5) ((F_ShapeAll) this).activeTool).Data).Name)
          num = index;
      }
      if (((F_ShapeEdit) this).cmb_tools.Items.Count > 0)
        ((F_ShapeEdit) this).cmb_tools.SelectedIndex = num;
      else
        ((F_ShapeAll) this).ShowTool = false;
    }
    if (!((F_ShapeAll) this).\u0001)
    {
      if (!((F_ShapeAll) this).ShowViewport & !((F_ShapeAll) this).ShowTool)
        ((F_ShapeAll) this).\u0001.Height = ((F_ShapeAll) this).\u0001.Height + ((F_ShapeAll) this).pnl_model.Height + ((F_ShapeEdit) this).btn_toolsettings.Height;
      else if (!((F_ShapeAll) this).ShowViewport & ((F_ShapeAll) this).ShowTool)
        ((F_ShapeAll) this).\u0001.Height = ((F_ShapeAll) this).\u0001.Height + ((F_ShapeAll) this).pnl_model.Height;
      else if (((F_ShapeAll) this).ShowViewport & !((F_ShapeAll) this).ShowTool)
        ((F_ShapeAll) this).pnl_model.Height = ((F_ShapeAll) this).pnl_model.Height + ((F_ShapeEdit) this).btn_toolsettings.Height;
      int int32 = Convert.ToInt32((double) this.Width / 6.0);
      ((F_ShapeAll) this).btn_back.Width = int32 - 10;
      ((F_ShapeEdit) this).\u0005.Width = int32 - 10;
      ((F_ShapeEdit) this).btn_bottom.Width = int32 - 10;
      ((F_ShapeEdit) this).\u0007.Width = int32 - 10;
      ((F_ShapeAll) this).btn_front.Width = int32 - 10;
      ((F_ShapeEdit) this).\u0006.Width = int32 - 10;
      ((F_ShapeEdit) this).btn_left.Width = int32 - 10;
      ((F_ShapeEdit) this).\u0004.Width = int32 - 10;
      ((F_ShapeAll) this).btn_right.Width = int32 - 10;
      ((F_ShapeEdit) this).\u0002.Width = int32 - 10;
      ((F_ShapeEdit) this).btn_top.Width = int32 - 10;
      ((F_ShapeEdit) this).\u0003.Width = int32 - 10;
      ((F_ShapeEdit) this).\u0003.Left = ((F_ShapeEdit) this).btn_top.Left;
      ((F_ShapeEdit) this).btn_bottom.Left = ((F_ShapeEdit) this).btn_top.Left + ((F_ShapeEdit) this).btn_top.Width + 5;
      ((F_ShapeEdit) this).\u0007.Left = ((F_ShapeEdit) this).btn_bottom.Left;
      ((F_ShapeAll) this).btn_front.Left = ((F_ShapeEdit) this).btn_bottom.Left + ((F_ShapeEdit) this).btn_bottom.Width + 5;
      ((F_ShapeEdit) this).\u0006.Left = ((F_ShapeAll) this).btn_front.Left;
      ((F_ShapeAll) this).btn_back.Left = ((F_ShapeAll) this).btn_front.Left + ((F_ShapeAll) this).btn_front.Width + 5;
      ((F_ShapeEdit) this).\u0005.Left = ((F_ShapeAll) this).btn_back.Left;
      ((F_ShapeEdit) this).btn_left.Left = ((F_ShapeAll) this).btn_back.Left + ((F_ShapeAll) this).btn_back.Width + 5;
      ((F_ShapeEdit) this).\u0004.Left = ((F_ShapeEdit) this).btn_left.Left;
      ((F_ShapeAll) this).btn_right.Left = ((F_ShapeEdit) this).btn_left.Left + ((F_ShapeEdit) this).btn_left.Width + 5;
      ((F_ShapeEdit) this).\u0002.Left = ((F_ShapeAll) this).btn_right.Left;
      ((F_ShapeAll) this).\u0001 = true;
    }
    this.LoadLanguage();
    this.PlaneColorUpdate();
    ((F_ShapeAll) this).\u0001.Enabled = true;
    ((F_ShapeAll) this).PropertiesForm.Result = DialogResult.None;
  }

  private void \u0001([In] object obj0, [In] EventArgs obj1)
  {
    \u0007.\u0001.\u0001((F_EngraveList) this);
    ((F_ShapeAll) this).btn_ok.Enabled = true;
    ((F_ShapeAll) this).\u0001.Enabled = false;
    if (((F_ShapeAll) this).parShape.selectedPlane == planeBoxNames.Top)
      ((F_SewingSpeed) this).\u0002((object) ((F_ShapeEdit) this).btn_top, obj1);
    if (((F_ShapeAll) this).parShape.selectedPlane == planeBoxNames.Bottom)
      ((F_SewingSpeed) this).\u0002((object) ((F_ShapeEdit) this).btn_bottom, obj1);
    if (((F_ShapeAll) this).parShape.selectedPlane == planeBoxNames.Front)
      ((F_SewingSpeed) this).\u0002((object) ((F_ShapeAll) this).btn_front, obj1);
    if (((F_ShapeAll) this).parShape.selectedPlane == planeBoxNames.Back)
      ((F_SewingSpeed) this).\u0002((object) ((F_ShapeAll) this).btn_back, obj1);
    if (((F_ShapeAll) this).parShape.selectedPlane == planeBoxNames.Left)
      ((F_SewingSpeed) this).\u0002((object) ((F_ShapeEdit) this).btn_left, obj1);
    if (((F_ShapeAll) this).parShape.selectedPlane == planeBoxNames.Right)
      ((F_SewingSpeed) this).\u0002((object) ((F_ShapeAll) this).btn_right, obj1);
    ((F_ShapeAll) this).PropertiesForm.Inited = true;
  }

  internal void \u0001([In] object obj0, [In] FormClosingEventArgs obj1)
  {
    obj1.Cancel = true;
    ((F_ShapeAll) this).PropertiesForm.Result = DialogResult.Cancel;
    if (((F_ShapeAll) this).PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
      this.Dispose();
    if (((F_ShapeAll) this).PropertiesForm.FormCloseMode == FormCloseModeType.Invisible)
    {
      this.Visible = false;
      if (this.Owner != null)
        this.Owner.Focus();
    }
    // ISSUE: reference to a compiler-generated field
    if (((F_ShapeAll) this).\u0001 == null)
      return;
    // ISSUE: reference to a compiler-generated field
    ((F_ShapeAll) this).\u0001();
  }

  public void LoadLanguage()
  {
    string callMethod = nameof (LoadLanguage);
    try
    {
      this.Text = buLangTranslate.preDef.Engraving;
      ((F_ShapeEdit) this).\u0003.Text = buLangTranslate.preDef.Top;
      ((F_ShapeEdit) this).\u0005.Text = buLangTranslate.preDef.Back;
      ((F_ShapeEdit) this).\u0007.Text = buLangTranslate.preDef.Bottom;
      ((F_ShapeEdit) this).\u0001.Text = buLangTranslate.preDef.Command;
      ((F_ShapeEdit) this).\u0006.Text = buLangTranslate.preDef.Front;
      ((F_ShapeEdit) this).\u0004.Text = buLangTranslate.preDef.Left;
      ((F_ShapeEdit) this).\u0002.Text = buLangTranslate.preDef.Right;
      ((F_ShapeEdit) this).btn_camsettings.Text = buLangTranslate.preDef.Cam;
      ((F_ShapeAll) this).btn_ok.Text = buLangTranslate.preDef.Ok;
      ((F_ShapeAll) this).btn_cancel.Text = buLangTranslate.preDef.Cancel;
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
    ((F_ShapeAll) this).btn_back.BackColor = Color.Gainsboro;
    ((F_ShapeEdit) this).btn_bottom.BackColor = Color.Gainsboro;
    ((F_ShapeAll) this).btn_front.BackColor = Color.Gainsboro;
    ((F_ShapeEdit) this).btn_left.BackColor = Color.Gainsboro;
    ((F_ShapeAll) this).btn_right.BackColor = Color.Gainsboro;
    ((F_ShapeEdit) this).btn_top.BackColor = Color.Gainsboro;
    if (((F_ShapeAll) this).parShape.selectedPlane == planeBoxNames.Top)
      ((F_ShapeEdit) this).btn_top.BackColor = Color.PaleGreen;
    if (((F_ShapeAll) this).parShape.selectedPlane == planeBoxNames.Bottom)
      ((F_ShapeEdit) this).btn_bottom.BackColor = Color.PaleGreen;
    if (((F_ShapeAll) this).parShape.selectedPlane == planeBoxNames.Front)
      ((F_ShapeAll) this).btn_front.BackColor = Color.PaleGreen;
    if (((F_ShapeAll) this).parShape.selectedPlane == planeBoxNames.Back)
      ((F_ShapeAll) this).btn_back.BackColor = Color.PaleGreen;
    if (((F_ShapeAll) this).parShape.selectedPlane == planeBoxNames.Left)
      ((F_ShapeEdit) this).btn_left.BackColor = Color.PaleGreen;
    if (((F_ShapeAll) this).parShape.selectedPlane != planeBoxNames.Right)
      return;
    ((F_ShapeAll) this).btn_right.BackColor = Color.PaleGreen;
  }

  public void Apply()
  {
  }

  public void DataGridValuesToShape(int ColumnIndex, int RowIndex)
  {
    if (((F_ShapeAll) this).\u0001.Rows.Count < 2)
      return;
    if (((F_ShapeAll) this).parShape.selectedPlane == planeBoxNames.Top | ((F_ShapeAll) this).parShape.selectedPlane == planeBoxNames.Bottom)
    {
      ((buClipper) ((F_ShapeAll) this).selectedShape).BasePoint.X = Convert.ToDouble(((F_ShapeAll) this).\u0001.Rows[0].Cells[1].Value);
      ((buClipper) ((F_ShapeAll) this).selectedShape).BasePoint.Y = Convert.ToDouble(((F_ShapeAll) this).\u0001.Rows[1].Cells[1].Value);
    }
    if (((F_ShapeAll) this).parShape.selectedPlane == planeBoxNames.Front | ((F_ShapeAll) this).parShape.selectedPlane == planeBoxNames.Back)
    {
      ((buClipper) ((F_ShapeAll) this).selectedShape).BasePoint.X = Convert.ToDouble(((F_ShapeAll) this).\u0001.Rows[0].Cells[1].Value);
      ((buClipper) ((F_ShapeAll) this).selectedShape).BasePoint.Z = Convert.ToDouble(((F_ShapeAll) this).\u0001.Rows[1].Cells[1].Value);
    }
    if (((F_ShapeAll) this).parShape.selectedPlane == planeBoxNames.Left | ((F_ShapeAll) this).parShape.selectedPlane == planeBoxNames.Right)
    {
      ((buClipper) ((F_ShapeAll) this).selectedShape).BasePoint.Y = Convert.ToDouble(((F_ShapeAll) this).\u0001.Rows[0].Cells[1].Value);
      ((buClipper) ((F_ShapeAll) this).selectedShape).BasePoint.Z = Convert.ToDouble(((F_ShapeAll) this).\u0001.Rows[1].Cells[1].Value);
    }
    ((CutterIsoEntities) ((F_ShapeAll) this).selectedShape).Width = Convert.ToDouble(((F_ShapeAll) this).\u0001.Rows[2].Cells[1].Value);
    ((CutterIsoEntities) ((F_ShapeAll) this).selectedShape).Height = Convert.ToDouble(((F_ShapeAll) this).\u0001.Rows[3].Cells[1].Value);
    ((\u0012.\u0002) ((F_ShapeAll) this).selectedShape).Depth = Convert.ToDouble(((F_ShapeAll) this).\u0001.Rows[4].Cells[1].Value);
    ((buClipper) ((F_ShapeAll) this).selectedShape).Offset.Z = Convert.ToDouble(((F_ShapeAll) this).\u0001.Rows[5].Cells[1].Value);
    ((buClipperBase) ((F_ShapeAll) this).selectedShape).isPocket = ((F_ShapeEdit) this).\u0001.Checked;
    ((CustomDataAdd) ((F_ShapeAll) this).parShape).EngravingWidth = ((CutterIsoEntities) ((F_ShapeAll) this).selectedShape).Width;
    ((CustomDataAdd) ((F_ShapeAll) this).parShape).EngravingHeight = ((CutterIsoEntities) ((F_ShapeAll) this).selectedShape).Height;
    ((CustomDataAdd) ((F_ShapeAll) this).parShape).EngravingDepth = ((\u0012.\u0002) ((F_ShapeAll) this).selectedShape).Depth;
    ((CustomDataAdd) ((F_ShapeAll) this).parShape).EngravingOffsetZ = ((buClipper) ((F_ShapeAll) this).selectedShape).Offset.Z;
    ((F_ShapeAll) this).parShape.isEngravePocket = ((buClipperBase) ((F_ShapeAll) this).selectedShape).isPocket;
    ((F_ShapeAll) this).parShape.pntBase.X = ((buClipper) ((F_ShapeAll) this).selectedShape).BasePoint.X;
    ((F_ShapeAll) this).parShape.pntBase.Y = ((buClipper) ((F_ShapeAll) this).selectedShape).BasePoint.Y;
    ((F_ShapeAll) this).parShape.pntBase.Z = ((buClipper) ((F_ShapeAll) this).selectedShape).BasePoint.Z;
  }

  public void ShapeToDataGrid(int Index)
  {
    ((F_ShapeAll) this).\u0001.Rows.Clear();
    if (((F_ShapeAll) this).parShape.selectedPlane == planeBoxNames.Top | ((F_ShapeAll) this).parShape.selectedPlane == planeBoxNames.Bottom)
    {
      ((F_ShapeAll) this).\u0001.Rows.Add(\u0007.\u0001.\u0001("X", ((F_ShapeAll) this).parShape.pntBase.X, (F_EngraveList) this));
      ((F_ShapeAll) this).\u0001.Rows.Add(\u0007.\u0001.\u0001("Y", ((F_ShapeAll) this).parShape.pntBase.Y, (F_EngraveList) this));
    }
    if (((F_ShapeAll) this).parShape.selectedPlane == planeBoxNames.Left | ((F_ShapeAll) this).parShape.selectedPlane == planeBoxNames.Right)
    {
      ((F_ShapeAll) this).\u0001.Rows.Add(\u0007.\u0001.\u0001("Y", ((F_ShapeAll) this).parShape.pntBase.Y, (F_EngraveList) this));
      ((F_ShapeAll) this).\u0001.Rows.Add(\u0007.\u0001.\u0001("Z", ((F_ShapeAll) this).parShape.pntBase.Z, (F_EngraveList) this));
    }
    if (((F_ShapeAll) this).parShape.selectedPlane == planeBoxNames.Front | ((F_ShapeAll) this).parShape.selectedPlane == planeBoxNames.Back)
    {
      ((F_ShapeAll) this).\u0001.Rows.Add(\u0007.\u0001.\u0001("X", ((F_ShapeAll) this).parShape.pntBase.X, (F_EngraveList) this));
      ((F_ShapeAll) this).\u0001.Rows.Add(\u0007.\u0001.\u0001("Z", ((F_ShapeAll) this).parShape.pntBase.Z, (F_EngraveList) this));
    }
    if (Index == 0)
    {
      ((F_ShapeAll) this).selectedShape = (buShape) new buSelectionPoint(((CustomDataAdd) ((F_ShapeAll) this).parShape).EngravingDepth, ((CustomDataAdd) ((F_ShapeAll) this).parShape).EngravingWidth, ((CustomDataAdd) ((F_ShapeAll) this).parShape).EngravingHeight, ((F_ShapeAll) this).entMesh);
      ((buClipperBase) ((F_ShapeAll) this).selectedShape).isPocket = ((F_ShapeAll) this).parShape.isEngravePocket;
      ((buClipper) ((F_ShapeAll) this).selectedShape).Offset.Z = ((CustomDataAdd) ((F_ShapeAll) this).parShape).EngravingOffsetZ;
      ((buClipper) ((F_ShapeAll) this).selectedShape).BasePoint = new Point3D(((F_ShapeAll) this).parShape.pntBase.X, ((F_ShapeAll) this).parShape.pntBase.Y, ((F_ShapeAll) this).parShape.pntBase.Z);
      ((buClipperBase) ((F_ShapeAll) this).selectedShape).planeName = ((F_ShapeAll) this).parShape.selectedPlane;
      ((buClipper) ((F_ShapeAll) this).selectedShape).planeOperation = buCall.\u0001.PlaneNameToPlane(((buClipperBase) ((F_ShapeAll) this).selectedShape).planeName);
      ((buClipperBase) ((F_ShapeAll) this).selectedShape).Corner = ((F_ShapeAll) this).parShape.selectedCorner;
      ((buClipperBase) ((F_ShapeAll) this).selectedShape).Alignment = ((F_ShapeAll) this).parShape.objectAlignment;
      ((F_ShapeAll) this).\u0001.Rows.Add(\u0007.\u0001.\u0001(buLangTranslate.preDef.Width, ((CutterIsoEntities) ((F_ShapeAll) this).selectedShape).Width, (F_EngraveList) this));
      ((F_ShapeAll) this).\u0001.Rows.Add(\u0007.\u0001.\u0001(buLangTranslate.preDef.Height, ((CutterIsoEntities) ((F_ShapeAll) this).selectedShape).Height, (F_EngraveList) this));
      ((F_ShapeAll) this).\u0001.Rows.Add(\u0007.\u0001.\u0001(buLangTranslate.preDef.Depth, ((\u0012.\u0002) ((F_ShapeAll) this).selectedShape).Depth, (F_EngraveList) this));
      ((F_ShapeAll) this).\u0001.Rows.Add(\u0007.\u0001.\u0001("Z " + buLangTranslate.preDef.Offset, ((buClipper) ((F_ShapeAll) this).selectedShape).Offset.Z, (F_EngraveList) this));
    }
    ((F_ShapeEdit) this).\u0001.Checked = ((F_ShapeAll) this).parShape.isEngravePocket;
    ((buClipper) ((F_ShapeAll) this).selectedShape).CamPar = (camParameters5) new camRuntime5(((F_ShapeAll) this).CamPar);
    ((F_ShapeEdit) this).\u0001.Text = ((buNestedSheet) buCall.\u0001).JobItemCommandToString(((F_ShapeAll) this).selectedShape);
  }

  private void \u0001([In] object obj0, [In] DataGridViewCellEventArgs obj1)
  {
    if (!((F_ShapeAll) this).PropertiesForm.Inited || !(obj1.ColumnIndex >= 0 & obj1.RowIndex >= 0))
      return;
    ShapeUpdateArg Data2 = (ShapeUpdateArg) new hmiUICommands();
    this.DataGridValuesToShape(obj1.ColumnIndex, obj1.RowIndex);
    // ISSUE: reference to a compiler-generated field
    if (((F_ShapeAll) this).\u0001 == null)
      return;
    ((ShapeRuntimeData) Data2).Parameters = (ShapeRuntimeData) new hmiUICommands(((F_ShapeAll) this).parShape);
    // ISSUE: reference to a compiler-generated field
    ((F_ShapeAll) this).\u0001((object) ((F_ShapeAll) this).selectedShape, (object) Data2);
  }

  private void \u0002([In] object obj0, [In] DataGridViewCellEventArgs obj1)
  {
    if (!((F_ShapeAll) this).PropertiesForm.Inited || !(obj1.ColumnIndex >= 0 & obj1.RowIndex >= 0))
      return;
    ShapeUpdateArg Data2 = (ShapeUpdateArg) new hmiUICommands();
    this.DataGridValuesToShape(obj1.ColumnIndex, obj1.RowIndex);
    ((dynamicInfo) F_NotchEdit.ShapeTempPar).ValueGridIndex = obj1.RowIndex;
    buCall.\u0001.FindShapeDataValueType(((F_ShapeAll) this).selectedShape, obj1.RowIndex, ref ((dynamicInfo) F_NotchEdit.ShapeTempPar).ValueType);
    // ISSUE: reference to a compiler-generated field
    if (((F_ShapeAll) this).\u0001 == null)
      return;
    ((ShapeRuntimeData) Data2).Parameters = (ShapeRuntimeData) new hmiUICommands(((F_ShapeAll) this).parShape);
    // ISSUE: reference to a compiler-generated field
    ((F_ShapeAll) this).\u0001((object) ((F_ShapeAll) this).selectedShape, (object) Data2);
  }

  private void \u0003([In] object obj0, [In] DataGridViewCellEventArgs obj1)
  {
    if (!((F_ShapeAll) this).PropertiesForm.Inited || !(obj1.ColumnIndex >= 0 & obj1.RowIndex >= 0))
      return;
    ShapeUpdateArg Data2 = (ShapeUpdateArg) new hmiUICommands();
    this.DataGridValuesToShape(obj1.ColumnIndex, obj1.RowIndex);
    ((dynamicInfo) F_NotchEdit.ShapeTempPar).ValueGridIndex = obj1.RowIndex;
    buCall.\u0001.FindShapeDataValueType(((F_ShapeAll) this).selectedShape, obj1.RowIndex, ref ((dynamicInfo) F_NotchEdit.ShapeTempPar).ValueType);
    // ISSUE: reference to a compiler-generated field
    if (((F_ShapeAll) this).\u0001 == null)
      return;
    ((ShapeRuntimeData) Data2).Parameters = (ShapeRuntimeData) new hmiUICommands(((F_ShapeAll) this).parShape);
    // ISSUE: reference to a compiler-generated field
    ((F_ShapeAll) this).\u0001((object) ((F_ShapeAll) this).selectedShape, (object) Data2);
  }

  public event OkCommandWithTwoDataEventHandler RotateCommad;

  public event CancelCommandEventHandler CancelCommad;
}
