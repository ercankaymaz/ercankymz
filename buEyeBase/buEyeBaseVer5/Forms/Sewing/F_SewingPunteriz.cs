// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Forms.Sewing.F_SewingPunteriz
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using buEyeBaseVer5.buEntities;
using buEyeBaseVer5.Forms.Shape;
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

public class F_SewingPunteriz : Form
{
  public bool ClosePageAfterOk;
  public List<ToolBase5> Tools;
  public ToolBase5 activeTool;
  public buShape selectedShape;
  public camParameters5 CamPar;
  public ShapeRuntimeData parShape;
  private System.Windows.Forms.Timer \u0001;
  private int \u0001;
  private bool \u0001;
  internal IContainer \u0001;
  public Button btn_cancel;
  public Button btn_ok;
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

  [CompilerGenerated]
  [SpecialName]
  public void add_DataCancel(CancelCommandEventHandler value)
  {
    // ISSUE: reference to a compiler-generated field
    CancelCommandEventHandler commandEventHandler = ((F_SewingMove) this).\u0001;
    CancelCommandEventHandler comparand;
    do
    {
      comparand = commandEventHandler;
      // ISSUE: reference to a compiler-generated field
      commandEventHandler = Interlocked.CompareExchange<CancelCommandEventHandler>(ref ((F_SewingMove) this).\u0001, comparand + value, comparand);
    }
    while (commandEventHandler != comparand);
  }

  [CompilerGenerated]
  [SpecialName]
  public void remove_DataCancel(CancelCommandEventHandler value)
  {
    // ISSUE: reference to a compiler-generated field
    CancelCommandEventHandler commandEventHandler = ((F_SewingMove) this).\u0001;
    CancelCommandEventHandler comparand;
    do
    {
      comparand = commandEventHandler;
      // ISSUE: reference to a compiler-generated field
      commandEventHandler = Interlocked.CompareExchange<CancelCommandEventHandler>(ref ((F_SewingMove) this).\u0001, comparand - value, comparand);
    }
    while (commandEventHandler != comparand);
  }

  public void Init()
  {
    ((F_SewingExtend) this).PropertiesForm.Inited = false;
    if (((F_SewingExtend) this).PropertiesForm.Height > 10)
      this.Height = ((F_SewingExtend) this).PropertiesForm.Height;
    if (((F_SewingExtend) this).PropertiesForm.Width > 10)
      this.Width = ((F_SewingExtend) this).PropertiesForm.Width;
    this.TopMost = ((F_SewingExtend) this).PropertiesForm.TopMost;
    this.StartPosition = ((F_SewingExtend) this).PropertiesForm.FormPosition;
    this.\u0001.Items.Clear();
    this.\u0001.Items.Add($"{buLangTranslate.preDef.Single} {buLangTranslate.preDef.Hole}", 0);
    this.\u0001.Items.Add($"{buLangTranslate.preDef.Horizontal} {buLangTranslate.preDef.Hole}", 1);
    this.\u0001.Items.Add($"{buLangTranslate.preDef.Horizontal} {buLangTranslate.preDef.Line} {buLangTranslate.preDef.Hole}", 2);
    this.\u0001.Items.Add($"{buLangTranslate.preDef.Vertical} {buLangTranslate.preDef.Hole}", 3);
    this.\u0001.Items.Add($"{buLangTranslate.preDef.Vertical} {buLangTranslate.preDef.Line} {buLangTranslate.preDef.Hole}", 4);
    this.\u0001.Items.Add($"{buLangTranslate.preDef.Slope} {buLangTranslate.preDef.Hole}", 5);
    this.\u0001.Items.Add("3 " + buLangTranslate.preDef.Hole, 6);
    this.pnl_model.Visible = ((F_SewingExtend) this).ShowViewport;
    ((F_SewingStitchLen) this).cmb_tools.Visible = ((F_SewingExtend) this).ShowTool;
    ((F_SewingStitchLen) this).btn_camsettings.Visible = ((F_SewingExtend) this).ShowCamSettings;
    ((F_SewingStitchLen) this).btn_toolsettings.Visible = ((F_SewingExtend) this).ShowTool;
    ((F_SewingStitchLen) this).\u0002.Visible = ((F_SewingExtend) this).ShowObjectPosition;
    ((F_SewingStitchLen) this).\u0001.Visible = ((F_SewingExtend) this).ShowCornerLocation;
    ((F_SewingStitchLen) this).\u0002.ImageIndex = Convert.ToInt32((object) this.parShape.objectAlignment);
    ((F_SewingStitchLen) this).\u0001.ImageIndex = Convert.ToInt32((object) this.parShape.selectedCorner);
    this.btn_back.Enabled = ((F_SewingExtend) this).EnableBacktPlane;
    this.btn_front.Enabled = ((F_SewingExtend) this).EnableFrontPlane;
    ((F_SewingStitchLen) this).btn_top.Enabled = ((F_SewingExtend) this).EnableTopPlane;
    ((F_SewingStitchLen) this).btn_bottom.Enabled = ((F_SewingExtend) this).EnableBottomPlane;
    this.btn_left.Enabled = ((F_SewingExtend) this).EnableLeftPlane;
    this.btn_right.Enabled = ((F_SewingExtend) this).EnableRightPlane;
    if (this.\u0001.Columns.Count == 0)
    {
      DataGridViewColumn dataGridViewColumn1 = new DataGridViewColumn();
      dataGridViewColumn1.SortMode = DataGridViewColumnSortMode.NotSortable;
      dataGridViewColumn1.Width = Convert.ToInt32((double) this.\u0001.Width * 0.65);
      dataGridViewColumn1.HeaderText = "Name";
      dataGridViewColumn1.Name = "Name";
      dataGridViewColumn1.ReadOnly = true;
      dataGridViewColumn1.DefaultCellStyle.Font = new Font("Arial", 10f, FontStyle.Bold);
      dataGridViewColumn1.CellTemplate = (DataGridViewCell) new DataGridViewTextBoxCell();
      this.\u0001.Columns.Add(dataGridViewColumn1);
      DataGridViewColumn dataGridViewColumn2 = new DataGridViewColumn();
      dataGridViewColumn2.SortMode = DataGridViewColumnSortMode.NotSortable;
      dataGridViewColumn2.Width = this.\u0001.Width - dataGridViewColumn1.Width - 20;
      dataGridViewColumn2.HeaderText = "Value";
      dataGridViewColumn2.Name = "Value";
      dataGridViewColumn2.ReadOnly = false;
      dataGridViewColumn2.DefaultCellStyle.Font = new Font("Arial", 10f, FontStyle.Bold);
      dataGridViewColumn2.CellTemplate = (DataGridViewCell) new DataGridViewTextBoxCell();
      this.\u0001.Columns.Add(dataGridViewColumn2);
      this.\u0001.CellValueChanged += new DataGridViewCellEventHandler(((F_SewingStitchLen) this).\u0001);
      this.\u0001.CellClick += new DataGridViewCellEventHandler(((F_SewingStitchLen) this).\u0002);
      this.\u0001.CellEnter += new DataGridViewCellEventHandler(((F_SewingStitchLen) this).\u0003);
    }
    this.\u0001.RowHeadersVisible = false;
    this.\u0001.ColumnHeadersVisible = false;
    this.\u0001.AllowUserToAddRows = false;
    this.\u0001.AllowUserToResizeColumns = false;
    this.\u0001.AllowUserToResizeRows = false;
    this.\u0001.ForeColor = Color.Red;
    if (this.parShape.DrillType == drillTypes.SingleHole)
    {
      this.\u0001.Items[0].Focused = true;
      this.\u0001.Items[0].Selected = true;
      this.\u0001.FocusedItem = this.\u0001.Items[0];
      this.\u0001 = 0;
    }
    else if (this.parShape.DrillType == drillTypes.HorizontalHoles)
    {
      this.\u0001.Items[1].Focused = true;
      this.\u0001.Items[1].Selected = true;
      this.\u0001.FocusedItem = this.\u0001.Items[1];
      this.\u0001 = 1;
    }
    else if (this.parShape.DrillType == drillTypes.HorizontalLineHoles)
    {
      this.\u0001.Items[2].Focused = true;
      this.\u0001.Items[2].Selected = true;
      this.\u0001.FocusedItem = this.\u0001.Items[2];
      this.\u0001 = 2;
    }
    else if (this.parShape.DrillType == drillTypes.VerticalHoles)
    {
      this.\u0001.Items[3].Focused = true;
      this.\u0001.Items[3].Selected = true;
      this.\u0001.FocusedItem = this.\u0001.Items[3];
      this.\u0001 = 3;
    }
    else if (this.parShape.DrillType == drillTypes.VerticalLineHoles)
    {
      this.\u0001.Items[4].Focused = true;
      this.\u0001.Items[4].Selected = true;
      this.\u0001.FocusedItem = this.\u0001.Items[4];
      this.\u0001 = 4;
    }
    else if (this.parShape.DrillType == drillTypes.InclineHoles)
    {
      this.\u0001.Items[5].Focused = true;
      this.\u0001.Items[5].Selected = true;
      this.\u0001.FocusedItem = this.\u0001.Items[5];
      this.\u0001 = 5;
    }
    else if (this.parShape.DrillType == drillTypes.ThreeHole)
    {
      this.\u0001.Items[6].Focused = true;
      this.\u0001.Items[6].Selected = true;
      this.\u0001.FocusedItem = this.\u0001.Items[6];
      this.\u0001 = 6;
    }
    ((F_SewingStitchLen) this).ShapeToDataGrid(this.\u0001);
    ((F_SewingStitchLen) this).cmb_tools.Items.Clear();
    if (((F_SewingExtend) this).ShowTool)
    {
      int num = -1;
      for (int index = 0; index <= this.Tools.Count - 1; ++index)
      {
        ((F_SewingStitchLen) this).cmb_tools.Items.Add((object) $"{((ToolCamData5) ((ToolGeometry5) this.Tools[index]).Data).Name} - T{((ToolCamData5) ((ToolGeometry5) this.Tools[index]).Data).No.ToString()} - D: {((ToolGeometry5) this.Tools[index]).Geometry.Diameter.ToString("f1")}");
        if (this.activeTool != null && ((ToolCamData5) ((ToolGeometry5) this.Tools[index]).Data).Name == ((ToolCamData5) ((ToolGeometry5) this.activeTool).Data).Name)
          num = index;
      }
      if (((F_SewingStitchLen) this).cmb_tools.Items.Count > 0)
        ((F_SewingStitchLen) this).cmb_tools.SelectedIndex = num;
      else
        ((F_SewingExtend) this).ShowTool = false;
    }
    if (!this.\u0001)
    {
      if (!((F_SewingExtend) this).ShowViewport & !((F_SewingExtend) this).ShowTool)
        this.\u0001.Height = this.\u0001.Height + this.pnl_model.Height + ((F_SewingStitchLen) this).btn_toolsettings.Height;
      else if (!((F_SewingExtend) this).ShowViewport & ((F_SewingExtend) this).ShowTool)
        this.\u0001.Height += this.pnl_model.Height;
      else if (((F_SewingExtend) this).ShowViewport & !((F_SewingExtend) this).ShowTool)
        this.pnl_model.Height += ((F_SewingStitchLen) this).btn_toolsettings.Height;
      int int32 = Convert.ToInt32((double) this.Width / 6.0);
      this.btn_back.Width = int32 - 10;
      ((F_SewingSetProperties) this).\u0005.Width = int32 - 10;
      ((F_SewingStitchLen) this).btn_bottom.Width = int32 - 10;
      ((F_SewingSetProperties) this).\u0007.Width = int32 - 10;
      this.btn_front.Width = int32 - 10;
      ((F_SewingSetProperties) this).\u0006.Width = int32 - 10;
      this.btn_left.Width = int32 - 10;
      ((F_SewingSetProperties) this).\u0004.Width = int32 - 10;
      this.btn_right.Width = int32 - 10;
      ((F_SewingSetProperties) this).\u0002.Width = int32 - 10;
      ((F_SewingStitchLen) this).btn_top.Width = int32 - 10;
      ((F_SewingSetProperties) this).\u0003.Width = int32 - 10;
      ((F_SewingSetProperties) this).\u0003.Left = ((F_SewingStitchLen) this).btn_top.Left;
      ((F_SewingStitchLen) this).btn_bottom.Left = ((F_SewingStitchLen) this).btn_top.Left + ((F_SewingStitchLen) this).btn_top.Width + 5;
      ((F_SewingSetProperties) this).\u0007.Left = ((F_SewingStitchLen) this).btn_bottom.Left;
      this.btn_front.Left = ((F_SewingStitchLen) this).btn_bottom.Left + ((F_SewingStitchLen) this).btn_bottom.Width + 5;
      ((F_SewingSetProperties) this).\u0006.Left = this.btn_front.Left;
      this.btn_back.Left = this.btn_front.Left + this.btn_front.Width + 5;
      ((F_SewingSetProperties) this).\u0005.Left = this.btn_back.Left;
      this.btn_left.Left = this.btn_back.Left + this.btn_back.Width + 5;
      ((F_SewingSetProperties) this).\u0004.Left = this.btn_left.Left;
      this.btn_right.Left = this.btn_left.Left + this.btn_left.Width + 5;
      ((F_SewingSetProperties) this).\u0002.Left = this.btn_right.Left;
      this.\u0001 = true;
    }
    this.LoadLanguage();
    this.PlaneColorUpdate();
    this.\u0001.Enabled = true;
    ((F_SewingExtend) this).PropertiesForm.Result = DialogResult.None;
  }

  private void \u0001([In] object obj0, [In] EventArgs obj1)
  {
    \u0007.\u0001.\u0001((F_DrillList) this);
    this.btn_ok.Enabled = true;
    this.\u0001.Enabled = false;
    if (this.parShape.selectedPlane == planeBoxNames.Top)
      ((F_SewingStitchLen) this).\u0002((object) ((F_SewingStitchLen) this).btn_top, obj1);
    if (this.parShape.selectedPlane == planeBoxNames.Bottom)
      ((F_SewingStitchLen) this).\u0002((object) ((F_SewingStitchLen) this).btn_bottom, obj1);
    if (this.parShape.selectedPlane == planeBoxNames.Front)
      ((F_SewingStitchLen) this).\u0002((object) this.btn_front, obj1);
    if (this.parShape.selectedPlane == planeBoxNames.Back)
      ((F_SewingStitchLen) this).\u0002((object) this.btn_back, obj1);
    if (this.parShape.selectedPlane == planeBoxNames.Left)
      ((F_SewingStitchLen) this).\u0002((object) this.btn_left, obj1);
    if (this.parShape.selectedPlane == planeBoxNames.Right)
      ((F_SewingStitchLen) this).\u0002((object) this.btn_right, obj1);
    ((F_SewingExtend) this).PropertiesForm.Inited = true;
  }

  internal void \u0001([In] object obj0, [In] FormClosingEventArgs obj1)
  {
    obj1.Cancel = true;
    ((F_SewingExtend) this).PropertiesForm.Result = DialogResult.Cancel;
    if (((F_SewingExtend) this).PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
      this.Dispose();
    if (((F_SewingExtend) this).PropertiesForm.FormCloseMode == FormCloseModeType.Invisible)
    {
      this.Visible = false;
      if (this.Owner != null)
        this.Owner.Focus();
    }
    // ISSUE: reference to a compiler-generated field
    if (((F_SewingMove) this).\u0001 == null)
      return;
    // ISSUE: reference to a compiler-generated field
    ((F_SewingMove) this).\u0001();
  }

  public void LoadLanguage()
  {
    string callMethod = nameof (LoadLanguage);
    try
    {
      this.Text = buLangTranslate.preDef.Drill;
      ((F_SewingSetProperties) this).\u0003.Text = buLangTranslate.preDef.Top;
      ((F_SewingSetProperties) this).\u0005.Text = buLangTranslate.preDef.Back;
      ((F_SewingSetProperties) this).\u0007.Text = buLangTranslate.preDef.Bottom;
      ((F_SewingSetProperties) this).\u0001.Text = buLangTranslate.preDef.Command;
      ((F_SewingSetProperties) this).\u0006.Text = buLangTranslate.preDef.Front;
      ((F_SewingSetProperties) this).\u0004.Text = buLangTranslate.preDef.Left;
      ((F_SewingSetProperties) this).\u0002.Text = buLangTranslate.preDef.Right;
      ((F_SewingStitchLen) this).btn_camsettings.Text = buLangTranslate.preDef.Cam;
      this.btn_ok.Text = buLangTranslate.preDef.Ok;
      this.btn_cancel.Text = buLangTranslate.preDef.Cancel;
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
    this.btn_back.BackColor = Color.Gainsboro;
    ((F_SewingStitchLen) this).btn_bottom.BackColor = Color.Gainsboro;
    this.btn_front.BackColor = Color.Gainsboro;
    this.btn_left.BackColor = Color.Gainsboro;
    this.btn_right.BackColor = Color.Gainsboro;
    ((F_SewingStitchLen) this).btn_top.BackColor = Color.Gainsboro;
    if (this.parShape.selectedPlane == planeBoxNames.Top)
      ((F_SewingStitchLen) this).btn_top.BackColor = Color.PaleGreen;
    if (this.parShape.selectedPlane == planeBoxNames.Bottom)
      ((F_SewingStitchLen) this).btn_bottom.BackColor = Color.PaleGreen;
    if (this.parShape.selectedPlane == planeBoxNames.Front)
      this.btn_front.BackColor = Color.PaleGreen;
    if (this.parShape.selectedPlane == planeBoxNames.Back)
      this.btn_back.BackColor = Color.PaleGreen;
    if (this.parShape.selectedPlane == planeBoxNames.Left)
      this.btn_left.BackColor = Color.PaleGreen;
    if (this.parShape.selectedPlane != planeBoxNames.Right)
      return;
    this.btn_right.BackColor = Color.PaleGreen;
  }
}
