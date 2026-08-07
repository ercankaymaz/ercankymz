// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Forms.RollerBend.F_RollerTable
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using buEyeBaseVer5.buEntities;
using buEyeBaseVer5.Forms.Shape;
using devDept.Eyeshot.Control;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;

#nullable disable
namespace buEyeBaseVer5.Forms.RollerBend;

public class F_RollerTable : Form
{
  public FormProperties PropertiesForm;
  public Design viewportLayout;
  public static List<string> Captions;
  public bool ShowViewport;
  public bool ShowCamSettings;
  public bool ShowTool;
  public bool ShowObjectPosition;
  public bool ShowCornerLocation;

  [CompilerGenerated]
  [SpecialName]
  public void add_DataCancel(CancelCommandEventHandler value)
  {
    // ISSUE: reference to a compiler-generated field
    CancelCommandEventHandler commandEventHandler = this.\u0001;
    CancelCommandEventHandler comparand;
    do
    {
      comparand = commandEventHandler;
      // ISSUE: reference to a compiler-generated field
      commandEventHandler = Interlocked.CompareExchange<CancelCommandEventHandler>(ref this.\u0001, comparand + value, comparand);
    }
    while (commandEventHandler != comparand);
  }

  [CompilerGenerated]
  [SpecialName]
  public void remove_DataCancel(CancelCommandEventHandler value)
  {
    // ISSUE: reference to a compiler-generated field
    CancelCommandEventHandler commandEventHandler = this.\u0001;
    CancelCommandEventHandler comparand;
    do
    {
      comparand = commandEventHandler;
      // ISSUE: reference to a compiler-generated field
      commandEventHandler = Interlocked.CompareExchange<CancelCommandEventHandler>(ref this.\u0001, comparand - value, comparand);
    }
    while (commandEventHandler != comparand);
  }

  public void Init()
  {
    this.PropertiesForm.Inited = false;
    if (this.PropertiesForm.Height > 10)
      this.Height = this.PropertiesForm.Height;
    if (this.PropertiesForm.Width > 10)
      this.Width = this.PropertiesForm.Width;
    this.TopMost = this.PropertiesForm.TopMost;
    this.StartPosition = this.PropertiesForm.FormPosition;
    ((F_RollerMenu) this).\u0001.Items.Clear();
    ((F_RollerMenu) this).\u0001.Items.Add(buLangTranslate.preDef.Rect, 0);
    ((F_RollerMenu) this).\u0001.Items.Add(buLangTranslate.preDef.Cirlce, 1);
    ((F_RollerMenu) this).\u0001.Items.Add(buLangTranslate.preDef.Ellipse, 2);
    ((F_RollerMenu) this).\u0001.Items.Add(buLangTranslate.preDef.KeyHole, 3);
    ((F_RollerMenu) this).\u0001.Items.Add(buLangTranslate.preDef.Polygon, 4);
    ((F_RollerMenu) this).\u0001.Items.Add(buLangTranslate.preDef.Slot, 5);
    ((F_RollerMenu) this).\u0001.Items.Add(buLangTranslate.preDef.FreeDraw, 6);
    ((F_RollerRectangle) this).pnl_model.Visible = this.ShowViewport;
    ((F_RollerCircle) this).cmb_tools.Visible = this.ShowTool;
    ((F_RollerCircle) this).btn_camsettings.Visible = this.ShowCamSettings;
    ((F_RollerCircle) this).btn_toolsettings.Visible = this.ShowTool;
    ((F_RollerCircle) this).\u0002.Visible = this.ShowObjectPosition;
    ((F_RollerCircle) this).\u0001.Visible = this.ShowCornerLocation;
    ((F_RollerCircle) this).\u0002.ImageIndex = Convert.ToInt32((object) ((F_RollerRectangle) this).parShape.objectAlignment);
    ((F_RollerCircle) this).\u0001.ImageIndex = Convert.ToInt32((object) ((F_RollerRectangle) this).parShape.selectedCorner);
    ((F_RollerMenu) this).btn_back.Enabled = ((F_RollerRectangle) this).EnableBacktPlane;
    ((F_RollerMenu) this).btn_front.Enabled = ((F_RollerRectangle) this).EnableFrontPlane;
    ((F_RollerMenu) this).btn_top.Enabled = ((F_RollerRectangle) this).EnableTopPlane;
    ((F_RollerCircle) this).btn_bottom.Enabled = ((F_RollerRectangle) this).EnableBottomPlane;
    ((F_RollerMenu) this).btn_left.Enabled = ((F_RollerRectangle) this).EnableLeftPlane;
    ((F_RollerMenu) this).btn_right.Enabled = ((F_RollerRectangle) this).EnableRightPlane;
    ((F_RollerMenu) this).\u0001.Columns.Clear();
    if (((F_RollerMenu) this).\u0001.Columns.Count == 0)
    {
      DataGridViewColumn dataGridViewColumn1 = new DataGridViewColumn();
      dataGridViewColumn1.SortMode = DataGridViewColumnSortMode.NotSortable;
      dataGridViewColumn1.Width = Convert.ToInt32((double) ((F_RollerMenu) this).\u0001.Width * 0.65);
      dataGridViewColumn1.HeaderText = "Name";
      dataGridViewColumn1.Name = "Name";
      dataGridViewColumn1.ReadOnly = true;
      dataGridViewColumn1.DefaultCellStyle.Font = new Font("Arial", 10f, FontStyle.Bold);
      dataGridViewColumn1.CellTemplate = (DataGridViewCell) new DataGridViewTextBoxCell();
      ((F_RollerMenu) this).\u0001.Columns.Add(dataGridViewColumn1);
      DataGridViewColumn dataGridViewColumn2 = new DataGridViewColumn();
      dataGridViewColumn2.SortMode = DataGridViewColumnSortMode.NotSortable;
      dataGridViewColumn2.Width = ((F_RollerMenu) this).\u0001.Width - dataGridViewColumn1.Width - 20;
      dataGridViewColumn2.HeaderText = "Value";
      dataGridViewColumn2.Name = "Value";
      dataGridViewColumn2.ReadOnly = false;
      dataGridViewColumn2.DefaultCellStyle.Font = new Font("Arial", 10f, FontStyle.Bold);
      dataGridViewColumn2.CellTemplate = (DataGridViewCell) new DataGridViewTextBoxCell();
      ((F_RollerMenu) this).\u0001.Columns.Add(dataGridViewColumn2);
      ((F_RollerMenu) this).\u0001.CellValueChanged += new DataGridViewCellEventHandler(((F_RollerRectangle) this).\u0001);
      ((F_RollerMenu) this).\u0001.CellClick += new DataGridViewCellEventHandler(((F_RollerRectangle) this).\u0002);
      ((F_RollerMenu) this).\u0001.CellEnter += new DataGridViewCellEventHandler(((F_RollerRectangle) this).\u0003);
    }
    ((F_RollerMenu) this).\u0001.RowHeadersVisible = false;
    ((F_RollerMenu) this).\u0001.ColumnHeadersVisible = false;
    ((F_RollerMenu) this).\u0001.AllowUserToAddRows = false;
    ((F_RollerMenu) this).\u0001.AllowUserToResizeColumns = false;
    ((F_RollerMenu) this).\u0001.AllowUserToResizeRows = false;
    ((F_RollerMenu) this).\u0001.ForeColor = Color.Red;
    if (((F_RollerRectangle) this).selectedShape.GetType() == typeof (buShapeRectangle))
    {
      ((F_RollerMenu) this).\u0001.Items[0].Focused = true;
      ((F_RollerMenu) this).\u0001.Items[0].Selected = true;
      ((F_RollerMenu) this).\u0001.FocusedItem = ((F_RollerMenu) this).\u0001.Items[0];
      ((F_RollerRectangle) this).\u0001 = 0;
    }
    else if (((F_RollerRectangle) this).selectedShape.GetType() == typeof (buShapeCircle))
    {
      ((F_RollerMenu) this).\u0001.Items[1].Focused = true;
      ((F_RollerMenu) this).\u0001.Items[1].Selected = true;
      ((F_RollerMenu) this).\u0001.FocusedItem = ((F_RollerMenu) this).\u0001.Items[1];
      ((F_RollerRectangle) this).\u0001 = 1;
    }
    else if (((F_RollerRectangle) this).selectedShape.GetType() == typeof (buShapeEllipse))
    {
      ((F_RollerMenu) this).\u0001.Items[2].Focused = true;
      ((F_RollerMenu) this).\u0001.Items[2].Selected = true;
      ((F_RollerMenu) this).\u0001.FocusedItem = ((F_RollerMenu) this).\u0001.Items[2];
      ((F_RollerRectangle) this).\u0001 = 2;
    }
    else if (((F_RollerRectangle) this).selectedShape.GetType() == typeof (buShapeKeyHole))
    {
      ((F_RollerMenu) this).\u0001.Items[3].Focused = true;
      ((F_RollerMenu) this).\u0001.Items[3].Selected = true;
      ((F_RollerMenu) this).\u0001.FocusedItem = ((F_RollerMenu) this).\u0001.Items[3];
      ((F_RollerRectangle) this).\u0001 = 3;
    }
    else if (((F_RollerRectangle) this).selectedShape.GetType() == typeof (buShapePolygon))
    {
      ((F_RollerMenu) this).\u0001.Items[4].Focused = true;
      ((F_RollerMenu) this).\u0001.Items[4].Selected = true;
      ((F_RollerMenu) this).\u0001.FocusedItem = ((F_RollerMenu) this).\u0001.Items[4];
      ((F_RollerRectangle) this).\u0001 = 4;
    }
    else if (((F_RollerRectangle) this).selectedShape.GetType() == typeof (buShapeSlot))
    {
      ((F_RollerMenu) this).\u0001.Items[5].Focused = true;
      ((F_RollerMenu) this).\u0001.Items[5].Selected = true;
      ((F_RollerMenu) this).\u0001.FocusedItem = ((F_RollerMenu) this).\u0001.Items[5];
      ((F_RollerRectangle) this).\u0001 = 5;
    }
    else if (((F_RollerRectangle) this).selectedShape.GetType() == typeof (buShapeFreeDraw))
    {
      ((F_RollerMenu) this).\u0001.Items[6].Focused = true;
      ((F_RollerMenu) this).\u0001.Items[6].Selected = true;
      ((F_RollerMenu) this).\u0001.FocusedItem = ((F_RollerMenu) this).\u0001.Items[6];
      ((F_RollerRectangle) this).\u0001 = 6;
    }
    ((F_RollerRectangle) this).ShapeToDataGrid(((F_RollerRectangle) this).\u0001);
    ((F_RollerCircle) this).cmb_tools.Items.Clear();
    if (this.ShowTool)
    {
      int num = -1;
      for (int index = 0; index <= ((F_RollerRectangle) this).Tools.Count - 1; ++index)
      {
        ((F_RollerCircle) this).cmb_tools.Items.Add((object) $"{((ToolCamData5) ((ToolGeometry5) ((F_RollerRectangle) this).Tools[index]).Data).Name} - T{((ToolCamData5) ((ToolGeometry5) ((F_RollerRectangle) this).Tools[index]).Data).No.ToString()} - D: {((ToolGeometry5) ((F_RollerRectangle) this).Tools[index]).Geometry.Diameter.ToString("f1")}");
        if (((F_RollerRectangle) this).activeTool != null && ((ToolCamData5) ((ToolGeometry5) ((F_RollerRectangle) this).Tools[index]).Data).Name == ((ToolCamData5) ((ToolGeometry5) ((F_RollerRectangle) this).activeTool).Data).Name)
          num = index;
      }
      if (((F_RollerCircle) this).cmb_tools.Items.Count > 0)
        ((F_RollerCircle) this).cmb_tools.SelectedIndex = num;
      else
        this.ShowTool = false;
    }
    if (!((F_RollerRectangle) this).\u0001)
    {
      if (!this.ShowViewport & !this.ShowTool)
        ((F_RollerMenu) this).\u0001.Height = ((F_RollerMenu) this).\u0001.Height + ((F_RollerRectangle) this).pnl_model.Height + ((F_RollerCircle) this).btn_toolsettings.Height;
      else if (!this.ShowViewport & this.ShowTool)
        ((F_RollerMenu) this).\u0001.Height = ((F_RollerMenu) this).\u0001.Height + ((F_RollerRectangle) this).pnl_model.Height;
      else if (this.ShowViewport & !this.ShowTool)
        ((F_RollerRectangle) this).pnl_model.Height = ((F_RollerRectangle) this).pnl_model.Height + ((F_RollerCircle) this).btn_toolsettings.Height;
      int int32 = Convert.ToInt32((double) this.Width / 6.0);
      ((F_RollerMenu) this).btn_back.Width = int32 - 10;
      ((F_RollerMenu) this).\u0004.Width = int32 - 10;
      ((F_RollerCircle) this).btn_bottom.Width = int32 - 10;
      ((F_RollerMenu) this).\u0006.Width = int32 - 10;
      ((F_RollerMenu) this).btn_front.Width = int32 - 10;
      ((F_RollerMenu) this).\u0005.Width = int32 - 10;
      ((F_RollerMenu) this).btn_left.Width = int32 - 10;
      ((F_RollerMenu) this).\u0003.Width = int32 - 10;
      ((F_RollerMenu) this).btn_right.Width = int32 - 10;
      ((F_RollerMenu) this).\u0001.Width = int32 - 10;
      ((F_RollerMenu) this).btn_top.Width = int32 - 10;
      ((F_RollerMenu) this).\u0002.Width = int32 - 10;
      ((F_RollerMenu) this).\u0002.Left = ((F_RollerMenu) this).btn_top.Left;
      ((F_RollerCircle) this).btn_bottom.Left = ((F_RollerMenu) this).btn_top.Left + ((F_RollerMenu) this).btn_top.Width + 5;
      ((F_RollerMenu) this).\u0006.Left = ((F_RollerCircle) this).btn_bottom.Left;
      ((F_RollerMenu) this).btn_front.Left = ((F_RollerCircle) this).btn_bottom.Left + ((F_RollerCircle) this).btn_bottom.Width + 5;
      ((F_RollerMenu) this).\u0005.Left = ((F_RollerMenu) this).btn_front.Left;
      ((F_RollerMenu) this).btn_back.Left = ((F_RollerMenu) this).btn_front.Left + ((F_RollerMenu) this).btn_front.Width + 5;
      ((F_RollerMenu) this).\u0004.Left = ((F_RollerMenu) this).btn_back.Left;
      ((F_RollerMenu) this).btn_left.Left = ((F_RollerMenu) this).btn_back.Left + ((F_RollerMenu) this).btn_back.Width + 5;
      ((F_RollerMenu) this).\u0003.Left = ((F_RollerMenu) this).btn_left.Left;
      ((F_RollerMenu) this).btn_right.Left = ((F_RollerMenu) this).btn_left.Left + ((F_RollerMenu) this).btn_left.Width + 5;
      ((F_RollerMenu) this).\u0001.Left = ((F_RollerMenu) this).btn_right.Left;
      ((F_RollerRectangle) this).\u0001 = true;
    }
    this.LoadLanguage();
    this.PlaneColorUpdate();
    this.PropertiesForm.Inited = false;
    ((F_RollerRectangle) this).\u0001.Enabled = true;
    this.PropertiesForm.Result = DialogResult.None;
  }

  internal void \u0001([In] object obj0, [In] FormClosingEventArgs obj1)
  {
    obj1.Cancel = true;
    this.PropertiesForm.Result = DialogResult.Cancel;
    if (this.PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
      this.Dispose();
    if (this.PropertiesForm.FormCloseMode == FormCloseModeType.Invisible)
    {
      this.Visible = false;
      if (this.Owner != null)
        this.Owner.Focus();
    }
    // ISSUE: reference to a compiler-generated field
    if (this.\u0001 == null)
      return;
    // ISSUE: reference to a compiler-generated field
    this.\u0001();
  }

  private void \u0001([In] object obj0, [In] EventArgs obj1)
  {
    \u0007.\u0001.\u0001((F_ShapeList) this);
    ((F_RollerRectangle) this).btn_ok.Enabled = true;
    ((F_RollerRectangle) this).\u0001.Enabled = false;
    if (((F_RollerRectangle) this).parShape.selectedPlane == planeBoxNames.Top)
      ((F_RollerRectangle) this).\u0002((object) ((F_RollerMenu) this).btn_top, obj1);
    if (((F_RollerRectangle) this).parShape.selectedPlane == planeBoxNames.Bottom)
      ((F_RollerRectangle) this).\u0002((object) ((F_RollerCircle) this).btn_bottom, obj1);
    if (((F_RollerRectangle) this).parShape.selectedPlane == planeBoxNames.Front)
      ((F_RollerRectangle) this).\u0002((object) ((F_RollerMenu) this).btn_front, obj1);
    if (((F_RollerRectangle) this).parShape.selectedPlane == planeBoxNames.Back)
      ((F_RollerRectangle) this).\u0002((object) ((F_RollerMenu) this).btn_back, obj1);
    if (((F_RollerRectangle) this).parShape.selectedPlane == planeBoxNames.Left)
      ((F_RollerRectangle) this).\u0002((object) ((F_RollerMenu) this).btn_left, obj1);
    if (((F_RollerRectangle) this).parShape.selectedPlane == planeBoxNames.Right)
      ((F_RollerRectangle) this).\u0002((object) ((F_RollerMenu) this).btn_right, obj1);
    this.PropertiesForm.Inited = true;
  }

  public void LoadLanguage()
  {
    string callMethod = nameof (LoadLanguage);
    try
    {
      this.Text = buLangTranslate.preDef.Shape;
      ((F_RollerMenu) this).\u0002.Text = buLangTranslate.preDef.Top;
      ((F_RollerMenu) this).\u0004.Text = buLangTranslate.preDef.Back;
      ((F_RollerMenu) this).\u0006.Text = buLangTranslate.preDef.Bottom;
      ((F_RollerMenu) this).\u0005.Text = buLangTranslate.preDef.Front;
      ((F_RollerMenu) this).\u0003.Text = buLangTranslate.preDef.Left;
      ((F_RollerMenu) this).\u0001.Text = buLangTranslate.preDef.Right;
      ((F_RollerCircle) this).btn_camsettings.Text = buLangTranslate.preDef.Cam;
      ((F_RollerRectangle) this).btn_ok.Text = buLangTranslate.preDef.Ok;
      ((F_RollerRectangle) this).btn_cancel.Text = buLangTranslate.preDef.Cancel;
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
    ((F_RollerMenu) this).btn_back.BackColor = Color.Gainsboro;
    ((F_RollerCircle) this).btn_bottom.BackColor = Color.Gainsboro;
    ((F_RollerMenu) this).btn_front.BackColor = Color.Gainsboro;
    ((F_RollerMenu) this).btn_left.BackColor = Color.Gainsboro;
    ((F_RollerMenu) this).btn_right.BackColor = Color.Gainsboro;
    ((F_RollerMenu) this).btn_top.BackColor = Color.Gainsboro;
    if (((F_RollerRectangle) this).parShape.selectedPlane == planeBoxNames.Top)
      ((F_RollerMenu) this).btn_top.BackColor = Color.PaleGreen;
    if (((F_RollerRectangle) this).parShape.selectedPlane == planeBoxNames.Bottom)
      ((F_RollerCircle) this).btn_bottom.BackColor = Color.PaleGreen;
    if (((F_RollerRectangle) this).parShape.selectedPlane == planeBoxNames.Front)
      ((F_RollerMenu) this).btn_front.BackColor = Color.PaleGreen;
    if (((F_RollerRectangle) this).parShape.selectedPlane == planeBoxNames.Back)
      ((F_RollerMenu) this).btn_back.BackColor = Color.PaleGreen;
    if (((F_RollerRectangle) this).parShape.selectedPlane == planeBoxNames.Left)
      ((F_RollerMenu) this).btn_left.BackColor = Color.PaleGreen;
    if (((F_RollerRectangle) this).parShape.selectedPlane != planeBoxNames.Right)
      return;
    ((F_RollerMenu) this).btn_right.BackColor = Color.PaleGreen;
  }
}
