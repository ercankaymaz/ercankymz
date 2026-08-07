// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Forms.Profile.F_SelectedPlanes
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;

#nullable disable
namespace buEyeBaseVer5.Forms.Profile;

public class F_SelectedPlanes : Form
{
  public Button btn_cancel;
  public Button btn_ok;
  internal Button \u0003;
  internal Button \u0004;
  internal ListBox \u0001;
  public Button btn_settings;
  internal Button \u0005;
  internal ImageList \u0001;
  public static byte f00168B;
  public FormProperties Properties;
  public WorkPlane Plane;
  internal IContainer \u0001;
  internal Label \u0001;
  internal NumericUpDown \u0001;
  internal Label \u0002;
  internal NumericUpDown \u0002;
  internal Label \u0003;
  internal NumericUpDown \u0003;
  internal Label \u0004;
  internal NumericUpDown \u0004;
  public Button btn_cancel;
  internal ImageList \u0001;
  public Button btn_ok;
  internal CheckBox \u0001;
  internal Label \u0005;
  internal Label \u0006;
  internal CheckBox \u0002;
  internal PictureBox \u0001;
  internal PictureBox \u0002;
  internal Label \u0007;
  internal NumericUpDown \u0005;
  public FormProperties Properties;
  internal IContainer \u0001;
  public Button btn_movezminus;
  internal ImageList \u0001;
  public Button btn_movezplus;
  public Button btn_rotateplus;
  public Button btn_rotateminus;
  public Button btn_moveyminus;
  public Button btn_moveyplus;
  internal ImageList \u0002;
  public NumericUpDown spn_value;
  public Button btn_ok;
  internal Label \u0001;
  internal Label \u0002;
  internal Label \u0003;
  internal Label \u0004;
  internal Label \u0005;
  public static byte f0016B4;
  public FormProperties Properties;
  public static List<string> Captions;
  internal IContainer \u0001;
  internal Label \u0001;

  [CompilerGenerated]
  [SpecialName]
  public void add_DataCancel(CancelCommandEventHandler value)
  {
    // ISSUE: reference to a compiler-generated field
    CancelCommandEventHandler commandEventHandler = ((F_PlaneMoveRotate) this).\u0001;
    CancelCommandEventHandler comparand;
    do
    {
      comparand = commandEventHandler;
      // ISSUE: reference to a compiler-generated field
      commandEventHandler = Interlocked.CompareExchange<CancelCommandEventHandler>(ref ((F_PlaneMoveRotate) this).\u0001, comparand + value, comparand);
    }
    while (commandEventHandler != comparand);
  }

  [CompilerGenerated]
  [SpecialName]
  public void remove_DataCancel(CancelCommandEventHandler value)
  {
    // ISSUE: reference to a compiler-generated field
    CancelCommandEventHandler commandEventHandler = ((F_PlaneMoveRotate) this).\u0001;
    CancelCommandEventHandler comparand;
    do
    {
      comparand = commandEventHandler;
      // ISSUE: reference to a compiler-generated field
      commandEventHandler = Interlocked.CompareExchange<CancelCommandEventHandler>(ref ((F_PlaneMoveRotate) this).\u0001, comparand - value, comparand);
    }
    while (commandEventHandler != comparand);
  }

  public void Init()
  {
    ((F_PlaneMoveRotate) this).PropertiesForm.Inited = false;
    if (((F_PlaneMoveRotate) this).PropertiesForm.Height > 10)
      this.Height = ((F_PlaneMoveRotate) this).PropertiesForm.Height;
    if (((F_PlaneMoveRotate) this).PropertiesForm.Width > 10)
      this.Width = ((F_PlaneMoveRotate) this).PropertiesForm.Width;
    this.TopMost = ((F_PlaneMoveRotate) this).PropertiesForm.TopMost;
    this.StartPosition = ((F_PlaneMoveRotate) this).PropertiesForm.FormPosition;
    ((F_ProfilePriority) this).\u0001.Items.Clear();
    ((F_ProfilePriority) this).\u0001.Items.Add($"{buLangTranslate.preDef.Notch} {buLangTranslate.preDef.Side}", 0);
    ((F_ProfilePriority) this).\u0001.Items.Add($"{buLangTranslate.preDef.Notch} {buLangTranslate.preDef.Length}", 1);
    ((F_ProfilePriority) this).\u0001.Items.Add($"{buLangTranslate.preDef.Notch} {buLangTranslate.preDef.Vertical}", 2);
    ((F_ProfilePriority) this).\u0001.Items.Add($"{buLangTranslate.preDef.Notch} {buLangTranslate.preDef.Horizontal}", 3);
    ((F_ProfilePriority) this).pnl_model.Visible = ((F_PlaneMoveRotate) this).ShowViewport;
    ((F_ProfilePriority) this).cmb_tools.Visible = ((F_ProfileFreeDrawCmd) this).ShowTool;
    ((F_ProfilePriority) this).btn_camsettings.Visible = ((F_ProfileFreeDrawCmd) this).ShowCamSettings;
    ((F_ProfilePriority) this).btn_toolsettings.Visible = ((F_ProfileFreeDrawCmd) this).ShowTool;
    ((F_ProfileTemplate) this).btn_back.Enabled = ((F_ProfileFreeDrawCmd) this).EnableBackPlane;
    ((F_ProfileTemplate) this).btn_front.Enabled = ((F_ProfileFreeDrawCmd) this).EnableFrontPlane;
    ((F_ProfileTemplate) this).btn_left.Enabled = ((F_ProfileFreeDrawCmd) this).EnableLeftPlane;
    ((F_ProfileTemplate) this).btn_right.Enabled = ((F_ProfileFreeDrawCmd) this).EnableRightPlane;
    if (((F_ProfileTemplate) this).dgv_data.Columns.Count == 0)
    {
      DataGridViewColumn dataGridViewColumn1 = new DataGridViewColumn();
      dataGridViewColumn1.SortMode = DataGridViewColumnSortMode.NotSortable;
      dataGridViewColumn1.Width = Convert.ToInt32((double) ((F_ProfileTemplate) this).dgv_data.Width * 0.65);
      dataGridViewColumn1.HeaderText = "Name";
      dataGridViewColumn1.Name = "Name";
      dataGridViewColumn1.ReadOnly = true;
      dataGridViewColumn1.DefaultCellStyle.Font = new Font("Arial", 10f, FontStyle.Bold);
      dataGridViewColumn1.CellTemplate = (DataGridViewCell) new DataGridViewTextBoxCell();
      ((F_ProfileTemplate) this).dgv_data.Columns.Add(dataGridViewColumn1);
      DataGridViewColumn dataGridViewColumn2 = new DataGridViewColumn();
      dataGridViewColumn2.SortMode = DataGridViewColumnSortMode.NotSortable;
      dataGridViewColumn2.Width = ((F_ProfileTemplate) this).dgv_data.Width - dataGridViewColumn1.Width - 20;
      dataGridViewColumn2.HeaderText = "Value";
      dataGridViewColumn2.Name = "Value";
      dataGridViewColumn2.ReadOnly = false;
      dataGridViewColumn2.DefaultCellStyle.Font = new Font("Arial", 10f, FontStyle.Bold);
      dataGridViewColumn2.CellTemplate = (DataGridViewCell) new DataGridViewTextBoxCell();
      ((F_ProfileTemplate) this).dgv_data.Columns.Add(dataGridViewColumn2);
      ((F_ProfileTemplate) this).dgv_data.CellValueChanged += new DataGridViewCellEventHandler(((F_NewProfile) this).\u0001);
      ((F_ProfileTemplate) this).dgv_data.CellClick += new DataGridViewCellEventHandler(((F_NewProfile) this).\u0002);
      ((F_ProfileTemplate) this).dgv_data.CellDoubleClick += new DataGridViewCellEventHandler(((F_NewProfile) this).\u0003);
      ((F_ProfileTemplate) this).dgv_data.CellEnter += new DataGridViewCellEventHandler(((F_NewProfile) this).\u0004);
      ((F_ProfileTemplate) this).dgv_data.RowHeadersVisible = false;
      ((F_ProfileTemplate) this).dgv_data.ColumnHeadersVisible = false;
      ((F_ProfileTemplate) this).dgv_data.AllowUserToAddRows = false;
      ((F_ProfileTemplate) this).dgv_data.AllowUserToResizeColumns = false;
      ((F_ProfileTemplate) this).dgv_data.AllowUserToResizeRows = false;
      ((F_ProfileTemplate) this).dgv_data.MultiSelect = false;
    }
    if (((F_ProfileMirror) this).dgv_list.Columns.Count == 0)
    {
      DataGridViewColumn dataGridViewColumn3 = new DataGridViewColumn();
      dataGridViewColumn3.SortMode = DataGridViewColumnSortMode.NotSortable;
      dataGridViewColumn3.Width = 1;
      dataGridViewColumn3.HeaderText = "Name";
      dataGridViewColumn3.Name = "Name";
      dataGridViewColumn3.ReadOnly = true;
      dataGridViewColumn3.DefaultCellStyle.Font = new Font("Arial", 10f, FontStyle.Bold);
      dataGridViewColumn3.CellTemplate = (DataGridViewCell) new DataGridViewTextBoxCell();
      ((F_ProfileMirror) this).dgv_list.Columns.Add(dataGridViewColumn3);
      DataGridViewColumn dataGridViewColumn4 = new DataGridViewColumn();
      dataGridViewColumn4.SortMode = DataGridViewColumnSortMode.NotSortable;
      dataGridViewColumn4.Width = Convert.ToInt32(((F_ProfileMirror) this).dgv_list.Width - 2);
      dataGridViewColumn4.HeaderText = "Name";
      dataGridViewColumn4.Name = "Name";
      dataGridViewColumn4.ReadOnly = true;
      dataGridViewColumn4.DefaultCellStyle.Font = new Font("Arial", 9f, FontStyle.Bold);
      dataGridViewColumn4.CellTemplate = (DataGridViewCell) new DataGridViewTextBoxCell();
      ((F_ProfileMirror) this).dgv_list.Columns.Add(dataGridViewColumn4);
      ((F_ProfileMirror) this).dgv_list.ScrollBars = ScrollBars.None;
      ((F_ProfileMirror) this).dgv_list.RowTemplate.Height = 15;
      ((F_ProfileMirror) this).dgv_list.RowTemplate.DefaultCellStyle.Font = new Font("Arial", 9f, FontStyle.Bold);
      ((F_ProfileMirror) this).dgv_list.DefaultCellStyle.Font = new Font("Arial", 9f, FontStyle.Bold);
      ((F_ProfileMirror) this).dgv_list.DefaultCellStyle.SelectionBackColor = Color.Transparent;
      ((F_ProfileMirror) this).dgv_list.DefaultCellStyle.SelectionForeColor = Color.Black;
      ((F_ProfileMirror) this).dgv_list.RowHeadersVisible = false;
      ((F_ProfileMirror) this).dgv_list.ColumnHeadersVisible = false;
      ((F_ProfileMirror) this).dgv_list.AllowUserToAddRows = false;
      ((F_ProfileMirror) this).dgv_list.AllowUserToResizeColumns = false;
      ((F_ProfileMirror) this).dgv_list.AllowUserToResizeRows = false;
      ((F_ProfileMirror) this).dgv_list.MultiSelect = false;
    }
    ((F_ProfilePriority) this).\u0001.ForeColor = Color.Red;
    if (((F_ProfileFreeDrawCmd) this).parShape.ShapeType == ShapeTypes.Notch)
    {
      if (((dynamicInfo) ((F_ProfileFreeDrawCmd) this).parShape).NotchOPType == ProfileNotchOperationType.Side)
      {
        ((F_ProfilePriority) this).\u0001.Items[0].Focused = true;
        ((F_ProfilePriority) this).\u0001.Items[0].Selected = true;
        ((F_ProfilePriority) this).\u0001.FocusedItem = ((F_ProfilePriority) this).\u0001.Items[0];
        ((F_ProfileClamperSet) this).\u0001 = 0;
      }
      if (((dynamicInfo) ((F_ProfileFreeDrawCmd) this).parShape).NotchOPType == ProfileNotchOperationType.Length)
      {
        ((F_ProfilePriority) this).\u0001.Items[1].Focused = true;
        ((F_ProfilePriority) this).\u0001.Items[1].Selected = true;
        ((F_ProfilePriority) this).\u0001.FocusedItem = ((F_ProfilePriority) this).\u0001.Items[1];
        ((F_ProfileClamperSet) this).\u0001 = 1;
      }
      if (((dynamicInfo) ((F_ProfileFreeDrawCmd) this).parShape).NotchOPType == ProfileNotchOperationType.Vertical)
      {
        ((F_ProfilePriority) this).\u0001.Items[2].Focused = true;
        ((F_ProfilePriority) this).\u0001.Items[2].Selected = true;
        ((F_ProfilePriority) this).\u0001.FocusedItem = ((F_ProfilePriority) this).\u0001.Items[2];
        ((F_ProfileClamperSet) this).\u0001 = 2;
      }
      if (((dynamicInfo) ((F_ProfileFreeDrawCmd) this).parShape).NotchOPType == ProfileNotchOperationType.Horizontal)
      {
        ((F_ProfilePriority) this).\u0001.Items[3].Focused = true;
        ((F_ProfilePriority) this).\u0001.Items[3].Selected = true;
        ((F_ProfilePriority) this).\u0001.FocusedItem = ((F_ProfilePriority) this).\u0001.Items[3];
        ((F_ProfileClamperSet) this).\u0001 = 3;
      }
    }
    ((F_NewProfile) this).ShapeToDataGrid(((F_ProfileClamperSet) this).\u0001);
    ((F_ProfilePriority) this).cmb_tools.Items.Clear();
    if (((F_ProfileFreeDrawCmd) this).ShowTool)
    {
      int num1 = -1;
      int num2 = -1;
      for (int index = 0; index <= ((F_ProfileFreeDrawCmd) this).Tools.Count - 1; ++index)
      {
        ((F_ProfilePriority) this).cmb_tools.Items.Add((object) buCall.\u0001.ToolToString(((F_ProfileFreeDrawCmd) this).Tools[index]));
        if (((ToolData5) ((ToolGeometry5) ((F_ProfileFreeDrawCmd) this).Tools[index]).Geometry).GeometryType == ToolType.Saw)
          num2 = -1;
        if (((F_ProfileFreeDrawCmd) this).activeTool != null && ((ToolCamData5) ((ToolGeometry5) ((F_ProfileFreeDrawCmd) this).Tools[index]).Data).Name == ((ToolCamData5) ((ToolGeometry5) ((F_ProfileFreeDrawCmd) this).activeTool).Data).Name && ((ToolData5) ((ToolGeometry5) ((F_ProfileFreeDrawCmd) this).Tools[index]).Geometry).GeometryType == ToolType.Saw)
          num1 = index;
      }
      if (((F_ProfilePriority) this).cmb_tools.Items.Count > 0)
      {
        if (num1 >= 0)
          ((F_ProfilePriority) this).cmb_tools.SelectedIndex = num1;
        else if (num2 >= 0)
          ((F_ProfilePriority) this).cmb_tools.SelectedIndex = num1;
      }
      else
        ((F_ProfileFreeDrawCmd) this).ShowTool = false;
    }
    if (!((F_ProfileClamperSet) this).\u0001)
    {
      if (!((F_PlaneMoveRotate) this).ShowViewport & !((F_ProfileFreeDrawCmd) this).ShowTool)
        ((F_ProfileTemplate) this).dgv_data.Height = ((F_ProfileTemplate) this).dgv_data.Height + ((F_ProfilePriority) this).pnl_model.Height + ((F_ProfilePriority) this).btn_toolsettings.Height;
      else if (!((F_PlaneMoveRotate) this).ShowViewport & ((F_ProfileFreeDrawCmd) this).ShowTool)
        ((F_ProfileTemplate) this).dgv_data.Height = ((F_ProfileTemplate) this).dgv_data.Height + ((F_ProfilePriority) this).pnl_model.Height;
      else if (((F_PlaneMoveRotate) this).ShowViewport & !((F_ProfileFreeDrawCmd) this).ShowTool)
        ((F_ProfilePriority) this).pnl_model.Height = ((F_ProfilePriority) this).pnl_model.Height + ((F_ProfilePriority) this).btn_toolsettings.Height;
      int int32 = Convert.ToInt32((double) this.Width / 6.0);
      ((F_ProfileTemplate) this).btn_back.Width = int32 - 10;
      ((F_ProfileTemplate) this).\u0002.Width = int32 - 10;
      ((F_ProfileTemplate) this).btn_right.Width = int32 - 10;
      ((F_ProfileTemplate) this).\u0004.Width = int32 - 10;
      ((F_ProfileTemplate) this).btn_front.Width = int32 - 10;
      ((F_ProfileTemplate) this).\u0003.Width = int32 - 10;
      ((F_ProfileTemplate) this).btn_left.Width = int32 - 10;
      ((F_ProfileTemplate) this).\u0001.Width = int32 - 10;
      ((F_ProfileTemplate) this).\u0001.Left = ((F_ProfileTemplate) this).btn_left.Left;
      ((F_ProfileTemplate) this).btn_right.Left = ((F_ProfileTemplate) this).btn_left.Left + ((F_ProfileTemplate) this).btn_left.Width + 5;
      ((F_ProfileTemplate) this).\u0004.Left = ((F_ProfileTemplate) this).btn_right.Left;
      ((F_ProfileTemplate) this).btn_front.Left = ((F_ProfileTemplate) this).btn_right.Left + ((F_ProfileTemplate) this).btn_right.Width + 5;
      ((F_ProfileTemplate) this).\u0003.Left = ((F_ProfileTemplate) this).btn_front.Left;
      ((F_ProfileTemplate) this).btn_back.Left = ((F_ProfileTemplate) this).btn_front.Left + ((F_ProfileTemplate) this).btn_front.Width + 5;
      ((F_ProfileTemplate) this).\u0002.Left = ((F_ProfileTemplate) this).btn_back.Left;
      ((F_ProfileClamperSet) this).\u0001 = true;
    }
    this.LoadLanguage();
    this.PlaneColorUpdate();
    ((F_PlaneMoveRotate) this).PropertiesForm.Inited = false;
    ((F_ProfileClamperSet) this).\u0001.Enabled = true;
    ((F_PlaneMoveRotate) this).PropertiesForm.Result = DialogResult.None;
  }

  internal void \u0001([In] object obj0, [In] FormClosingEventArgs obj1)
  {
    if (((F_PlaneMoveRotate) this).PropertiesForm.Result == DialogResult.OK)
      return;
    obj1.Cancel = true;
    ((F_PlaneMoveRotate) this).PropertiesForm.Result = DialogResult.Cancel;
    if (((F_PlaneMoveRotate) this).PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
      this.Dispose();
    if (((F_PlaneMoveRotate) this).PropertiesForm.FormCloseMode != FormCloseModeType.Invisible)
      return;
    this.Visible = false;
    if (this.Owner == null)
      return;
    this.Owner.Focus();
  }

  private void \u0001([In] object obj0, [In] EventArgs obj1)
  {
    \u0007.\u0001.\u0001((F_NotchList) this);
    ((F_ProfileTemplate) this).btn_ok.Enabled = true;
    ((F_ProfileClamperSet) this).\u0001.Enabled = false;
    if (((dynamicInfo) ((F_ProfileFreeDrawCmd) this).parShape).NotchOPType == ProfileNotchOperationType.Side)
    {
      if (((dynamicInfo) ((F_ProfileFreeDrawCmd) this).parShape).NotchSideLocation == ProfileNotchLocationType.Left)
        ((F_NewProfile) this).\u0003((object) ((F_ProfileTemplate) this).btn_left, obj1);
      else
        ((F_NewProfile) this).\u0003((object) ((F_ProfileTemplate) this).btn_right, obj1);
    }
    else if (((dynamicInfo) ((F_ProfileFreeDrawCmd) this).parShape).NotchOPType == ProfileNotchOperationType.Length)
    {
      if (((dynamicInfo) ((F_ProfileFreeDrawCmd) this).parShape).NotchLengthLocation == ProfileNotchLocationType.Front)
        ((F_NewProfile) this).\u0003((object) ((F_ProfileTemplate) this).btn_front, obj1);
      else
        ((F_NewProfile) this).\u0003((object) ((F_ProfileTemplate) this).btn_back, obj1);
    }
    else if (((dynamicInfo) ((F_ProfileFreeDrawCmd) this).parShape).NotchOPType == ProfileNotchOperationType.Vertical)
    {
      if (((dynamicInfo) ((F_ProfileFreeDrawCmd) this).parShape).NotchSideLocation == ProfileNotchLocationType.Left)
        ((F_NewProfile) this).\u0003((object) ((F_ProfileTemplate) this).btn_left, obj1);
      else
        ((F_NewProfile) this).\u0003((object) ((F_ProfileTemplate) this).btn_right, obj1);
    }
    else if (((dynamicInfo) ((F_ProfileFreeDrawCmd) this).parShape).NotchOPType == ProfileNotchOperationType.Horizontal)
    {
      if (((dynamicInfo) ((F_ProfileFreeDrawCmd) this).parShape).NotchSideLocation == ProfileNotchLocationType.Left)
        ((F_NewProfile) this).\u0003((object) ((F_ProfileTemplate) this).btn_left, obj1);
      else
        ((F_NewProfile) this).\u0003((object) ((F_ProfileTemplate) this).btn_right, obj1);
    }
    ((F_PlaneMoveRotate) this).PropertiesForm.Inited = true;
  }

  public void LoadLanguage()
  {
    string callMethod = nameof (LoadLanguage);
    try
    {
      ((F_ProfileTemplate) this).\u0001.Text = buLangTranslate.preDef.Left;
      ((F_ProfileTemplate) this).\u0004.Text = buLangTranslate.preDef.Right;
      ((F_ProfileTemplate) this).\u0002.Text = buLangTranslate.preDef.Back;
      ((F_ProfileTemplate) this).\u0003.Text = buLangTranslate.preDef.Front;
      this.Text = buLangTranslate.preDef.Notch;
      ((F_ProfileMirror) this).\u0005.Text = buLangTranslate.preDef.Profile;
      ((F_ProfileMirror) this).radio_kertmeLdown.Text = buLangTranslate.preDef.Down;
      ((F_ProfileMirror) this).radio_kertmeLup.Text = buLangTranslate.preDef.Up;
      ((F_ProfilePriority) this).btn_camsettings.Text = buLangTranslate.preDef.Cam;
      ((F_ProfileTemplate) this).btn_ok.Text = buLangTranslate.preDef.Ok;
      ((F_ProfileTemplate) this).btn_cancel.Text = buLangTranslate.preDef.Cancel;
      ((F_ProfileMirror) this).radio_front.Text = buLangTranslate.preDef.Front;
      ((F_ProfileMirror) this).radio_back.Text = buLangTranslate.preDef.Back;
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
    if (((dynamicInfo) ((F_ProfileFreeDrawCmd) this).parShape).NotchOPType == ProfileNotchOperationType.Side | ((dynamicInfo) ((F_ProfileFreeDrawCmd) this).parShape).NotchOPType == ProfileNotchOperationType.Length)
    {
      ((F_ProfileMirror) this).\u0004.Enabled = true;
      ((F_ProfileMirror) this).\u0003.Enabled = false;
    }
    if (((dynamicInfo) ((F_ProfileFreeDrawCmd) this).parShape).NotchOPType == ProfileNotchOperationType.Vertical)
    {
      ((F_ProfileMirror) this).\u0004.Enabled = false;
      ((F_ProfileMirror) this).\u0003.Enabled = true;
    }
    if (((dynamicInfo) ((F_ProfileFreeDrawCmd) this).parShape).NotchOPType == ProfileNotchOperationType.Horizontal)
    {
      ((F_ProfileMirror) this).\u0004.Enabled = false;
      ((F_ProfileMirror) this).\u0003.Enabled = false;
    }
    ((F_ProfileTemplate) this).btn_back.BackColor = Color.Gainsboro;
    ((F_ProfileTemplate) this).btn_right.BackColor = Color.Gainsboro;
    ((F_ProfileTemplate) this).btn_front.BackColor = Color.Gainsboro;
    ((F_ProfileTemplate) this).btn_left.BackColor = Color.Gainsboro;
    if (((dynamicInfo) ((F_ProfileFreeDrawCmd) this).parShape).NotchOPType == ProfileNotchOperationType.Side | ((dynamicInfo) ((F_ProfileFreeDrawCmd) this).parShape).NotchOPType == ProfileNotchOperationType.Vertical)
    {
      if (((dynamicInfo) ((F_ProfileFreeDrawCmd) this).parShape).NotchSideLocation != 0 & ((dynamicInfo) ((F_ProfileFreeDrawCmd) this).parShape).NotchSideLocation != ProfileNotchLocationType.Right)
        ((dynamicInfo) ((F_ProfileFreeDrawCmd) this).parShape).NotchSideLocation = ProfileNotchLocationType.Left;
      if (((dynamicInfo) ((F_ProfileFreeDrawCmd) this).parShape).NotchSideLocation == ProfileNotchLocationType.Left)
        ((F_ProfileTemplate) this).btn_left.BackColor = Color.PaleGreen;
      else
        ((F_ProfileTemplate) this).btn_right.BackColor = Color.PaleGreen;
    }
    else if (((dynamicInfo) ((F_ProfileFreeDrawCmd) this).parShape).NotchOPType == ProfileNotchOperationType.Length)
    {
      if (((dynamicInfo) ((F_ProfileFreeDrawCmd) this).parShape).NotchSideLocation != ProfileNotchLocationType.Front & ((dynamicInfo) ((F_ProfileFreeDrawCmd) this).parShape).NotchSideLocation != ProfileNotchLocationType.Back)
        ((dynamicInfo) ((F_ProfileFreeDrawCmd) this).parShape).NotchSideLocation = ProfileNotchLocationType.Front;
      if (((dynamicInfo) ((F_ProfileFreeDrawCmd) this).parShape).NotchLengthLocation == ProfileNotchLocationType.Front)
        ((F_ProfileTemplate) this).btn_front.BackColor = Color.PaleGreen;
      else
        ((F_ProfileTemplate) this).btn_back.BackColor = Color.PaleGreen;
    }
    else
    {
      if (((dynamicInfo) ((F_ProfileFreeDrawCmd) this).parShape).NotchOPType != ProfileNotchOperationType.Horizontal)
        return;
      if (((dynamicInfo) ((F_ProfileFreeDrawCmd) this).parShape).NotchSideLocation != 0 & ((dynamicInfo) ((F_ProfileFreeDrawCmd) this).parShape).NotchSideLocation != ProfileNotchLocationType.Right)
        ((dynamicInfo) ((F_ProfileFreeDrawCmd) this).parShape).NotchSideLocation = ProfileNotchLocationType.Left;
      if (((dynamicInfo) ((F_ProfileFreeDrawCmd) this).parShape).NotchSideLocation == ProfileNotchLocationType.Left)
        ((F_ProfileTemplate) this).btn_left.BackColor = Color.PaleGreen;
      else
        ((F_ProfileTemplate) this).btn_right.BackColor = Color.PaleGreen;
    }
  }

  public void Apply()
  {
  }

  public void DataGridValuesToShape(int ColumnIndex, int RowIndex)
  {
    if (((F_ProfileTemplate) this).dgv_data.Rows.Count < 2)
      return;
    ((F_ProfileFreeDrawCmd) this).parShape.ShapeType = ShapeTypes.Notch;
    if (((dynamicInfo) ((F_ProfileFreeDrawCmd) this).parShape).NotchOPType == ProfileNotchOperationType.Side)
    {
      ((MachineConfigSettings) ((F_ProfileFreeDrawCmd) this).parShape).NotchStartHeight = Convert.ToDouble(((F_ProfileTemplate) this).dgv_data.Rows[0].Cells[1].Value);
      ((CustomDataAdd) ((F_ProfileFreeDrawCmd) this).parShape).NotchHeight = Convert.ToDouble(((F_ProfileTemplate) this).dgv_data.Rows[1].Cells[1].Value);
      ((MachineConfigSettings) ((F_ProfileFreeDrawCmd) this).parShape).NotchDepth = Convert.ToDouble(((F_ProfileTemplate) this).dgv_data.Rows[2].Cells[1].Value);
      ((F_ProfileFreeDrawCmd) this).parShape.pntBase.Z = ((MachineConfigSettings) ((F_ProfileFreeDrawCmd) this).parShape).NotchStartHeight;
      ((F_ProfileFreeDrawCmd) this).parShape.ShapeGroup = ShapeGroup.Notch;
    }
    if (((dynamicInfo) ((F_ProfileFreeDrawCmd) this).parShape).NotchOPType == ProfileNotchOperationType.Length)
    {
      ((F_ProfileFreeDrawCmd) this).parShape.pntBase.X = Convert.ToDouble(((F_ProfileTemplate) this).dgv_data.Rows[0].Cells[1].Value);
      ((MachineConfigSettings) ((F_ProfileFreeDrawCmd) this).parShape).NotchStartHeight = Convert.ToDouble(((F_ProfileTemplate) this).dgv_data.Rows[1].Cells[1].Value);
      ((CustomDataAdd) ((F_ProfileFreeDrawCmd) this).parShape).NotchWidth = Convert.ToDouble(((F_ProfileTemplate) this).dgv_data.Rows[2].Cells[1].Value);
      ((CustomDataAdd) ((F_ProfileFreeDrawCmd) this).parShape).NotchHeight = Convert.ToDouble(((F_ProfileTemplate) this).dgv_data.Rows[3].Cells[1].Value);
      ((MachineConfigSettings) ((F_ProfileFreeDrawCmd) this).parShape).NotchDepth = Convert.ToDouble(((F_ProfileTemplate) this).dgv_data.Rows[4].Cells[1].Value);
      ((F_ProfileFreeDrawCmd) this).parShape.pntBase.Z = ((MachineConfigSettings) ((F_ProfileFreeDrawCmd) this).parShape).NotchStartHeight;
      ((F_ProfileFreeDrawCmd) this).parShape.ShapeGroup = ShapeGroup.Notch;
    }
    if (((dynamicInfo) ((F_ProfileFreeDrawCmd) this).parShape).NotchOPType == ProfileNotchOperationType.Vertical)
    {
      ((MachineConfigSettings) ((F_ProfileFreeDrawCmd) this).parShape).NotchStartHeight = Convert.ToDouble(((F_ProfileTemplate) this).dgv_data.Rows[0].Cells[1].Value);
      ((CustomDataAdd) ((F_ProfileFreeDrawCmd) this).parShape).NotchHeight = Convert.ToDouble(((F_ProfileTemplate) this).dgv_data.Rows[1].Cells[1].Value);
      ((MachineConfigSettings) ((F_ProfileFreeDrawCmd) this).parShape).NotchDepth = Convert.ToDouble(((F_ProfileTemplate) this).dgv_data.Rows[2].Cells[1].Value);
      ((F_ProfileFreeDrawCmd) this).parShape.pntBase.Y = ((MachineConfigSettings) ((F_ProfileFreeDrawCmd) this).parShape).NotchStartHeight;
      ((F_ProfileFreeDrawCmd) this).parShape.ShapeGroup = ShapeGroup.Notch;
    }
    if (((dynamicInfo) ((F_ProfileFreeDrawCmd) this).parShape).NotchOPType != ProfileNotchOperationType.Horizontal)
      return;
    ((F_ProfileFreeDrawCmd) this).parShape.pntBase.X = Convert.ToDouble(((F_ProfileTemplate) this).dgv_data.Rows[0].Cells[1].Value);
    ((F_ProfileFreeDrawCmd) this).parShape.pntBase.Y = Convert.ToDouble(((F_ProfileTemplate) this).dgv_data.Rows[1].Cells[1].Value);
    ((CustomDataAdd) ((F_ProfileFreeDrawCmd) this).parShape).NotchWidth = Convert.ToDouble(((F_ProfileTemplate) this).dgv_data.Rows[2].Cells[1].Value);
    ((CustomDataAdd) ((F_ProfileFreeDrawCmd) this).parShape).NotchHeight = Convert.ToDouble(((F_ProfileTemplate) this).dgv_data.Rows[3].Cells[1].Value);
    ((MachineConfigSettings) ((F_ProfileFreeDrawCmd) this).parShape).NotchDepth = Convert.ToDouble(((F_ProfileTemplate) this).dgv_data.Rows[4].Cells[1].Value);
    ((F_ProfileFreeDrawCmd) this).parShape.ShapeGroup = ShapeGroup.Notch;
  }
}
