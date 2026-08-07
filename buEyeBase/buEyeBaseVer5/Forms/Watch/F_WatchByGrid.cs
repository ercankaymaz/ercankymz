// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Forms.Watch.F_WatchByGrid
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using buControls.ClassViewer;
using buControls.DialogBox;
using buCore;
using buEyeBaseVer5.Apps;
using buEyeBaseVer5.Forms.Text;
using buEyeBaseVer5.Forms.Viewport;
using buEyeBaseVer5.Variables;
using devDept.Eyeshot.Entities;
using devDept.Geometry;
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
namespace buEyeBaseVer5.Forms.Watch;

public class F_WatchByGrid : Form
{
  internal Button \u0004;
  internal Button \u0005;
  internal Button \u0006;
  internal Button \u0007;
  internal NumericUpDown \u0001;
  internal Label \u0001;
  public static byte f001055;
  public static List<string> Captions;
  public List<object> Classes = new List<object>();
  public List<string> CaptionHeader = new List<string>();
  public List<List<string>> CaptionSubHeader = new List<List<string>>();
  public List<List<List<string>>> CaptionVariables = new List<List<List<string>>>();
  public DialogResult Result = DialogResult.Cancel;
  public TouchPadType TouchPadStyle = TouchPadType.buControlStyleBasic;
  public int AccessPasswordLevel = 0;
  private buClassViewer \u0001 = new buClassViewer();
  private bool \u0001 = false;
  public bool FormTopMost = false;
  public bool ReadOnly = false;
  public bool ScreenCenter = true;
  public bool TouchPad = false;
  public List<object> tempClasses = new List<object>();
  internal IContainer \u0001 = (IContainer) null;
  internal ImageList \u0001;
  internal TreeView \u0001;
  public Button btn_default;
  public Button btn_cancel;
  public Button btn_ok;
  public Button btn_apply;
  public Button btn_saveastext;
  internal ContextMenuStrip \u0001;
  internal ToolStripMenuItem \u0001;
  internal Panel \u0001;
  public static byte f001072;
  public string Tag;
  public static byte f001074;
  public int ClassIndex;
  public int ClassSubIndex;
  public FormProperties PropertiesForm;
  public SortSettings SortSetting;
  public static List<string> Captions;
  internal IContainer \u0001;
  internal Panel \u0001;

  public void Apply()
  {
    if (((F_TuftingSetProps) this).\u0002.Checked)
      ((DrillCNCSettings) ((F_TuftingSetProps) this).Setting).Heads = quiltingHeadType.First;
    else if (((F_TuftingSetProps) this).\u0003.Checked)
    {
      ((DrillCNCSettings) ((F_TuftingSetProps) this).Setting).Heads = quiltingHeadType.Second;
    }
    else
    {
      if (!((F_TuftingSetProps) this).\u0001.Checked)
        return;
      ((DrillCNCSettings) ((F_TuftingSetProps) this).Setting).Heads = quiltingHeadType.Both;
    }
  }

  protected override void Dispose(bool disposing)
  {
    if ((!disposing ? 0 : (((F_TuftingSetProps) this).\u0001 != null ? 1 : 0)) != 0)
      ((F_TuftingSetProps) this).\u0001.Dispose();
    base.Dispose(disposing);
  }

  static F_WatchByGrid() => F_TuftingSetProps.Captions = new List<string>();

  public F_WatchByGrid()
  {
    ((F_TuftingSort) this).PropertiesForm = new FormProperties();
    ((F_TuftingSort) this).SortSetting = (SortSettings) new ShapeRuntimeData();
    ((F_TuftingSort) this).\u0001 = (IContainer) null;
    // ISSUE: explicit constructor call
    base.\u002Ector();
    \u007B0e48b843\u002Dfb72\u002D498c\u002D834d\u002Dfc743ba0facc\u007D.\u0001((F_QuiltingSettings) this);
  }

  public void Init()
  {
    ((F_TuftingSort) this).PropertiesForm.Inited = false;
    if (((F_TuftingSort) this).PropertiesForm.Height > 10)
      this.Height = ((F_TuftingSort) this).PropertiesForm.Height;
    if (((F_TuftingSort) this).PropertiesForm.Width > 10)
      this.Width = ((F_TuftingSort) this).PropertiesForm.Width;
    this.TopMost = ((F_TuftingSort) this).PropertiesForm.TopMost;
    this.StartPosition = ((F_TuftingSort) this).PropertiesForm.FormPosition;
    ((F_TuftingSort) this).\u0001.Items.Clear();
    ((F_TuftingSort) this).\u0001.Items.Add((object) buClassLanguage.SortingNextGroupFindRulesType[0]);
    ((F_TuftingSort) this).\u0001.Items.Add((object) buClassLanguage.SortingNextGroupFindRulesType[1]);
    ((F_TuftingSort) this).\u0001.Items.Add((object) buClassLanguage.SortingNextGroupFindRulesType[2]);
    ((F_TuftingSort) this).\u0001.Items.Add((object) buClassLanguage.SortingNextGroupFindRulesType[3]);
    ((F_TuftingSort) this).\u0001.Items.Add((object) buClassLanguage.SortingNextGroupFindRulesType[4]);
    ((F_TuftingSort) this).\u0001.Items.Add((object) buClassLanguage.SortingNextGroupFindRulesType[5]);
    ((F_TuftingSort) this).\u0001.Items.Add((object) buClassLanguage.SortingNextGroupFindRulesType[6]);
    ((F_TuftingSort) this).\u0001.Items.Add((object) buClassLanguage.SortingNextGroupFindRulesType[7]);
    ((F_TuftingSort) this).\u0001.Items.Add((object) buClassLanguage.SortingNextGroupFindRulesType[8]);
    ((F_TuftingSort) this).\u0001.Items.Add((object) buClassLanguage.SortingNextGroupFindRulesType[9]);
    ((F_TuftingSort) this).\u0001.Items.Add((object) buClassLanguage.SortingNextGroupFindRulesType[10]);
    ((F_TuftingSort) this).\u0001.Items.Add((object) buClassLanguage.SortingNextGroupFindRulesType[11]);
    ((F_TuftingSort) this).\u0001.Items.Add((object) buClassLanguage.SortingNextGroupFindRulesType[12]);
    ((F_TuftingSort) this).\u0001.Items.Add((object) buClassLanguage.SortingNextGroupFindRulesType[13]);
    ((F_TuftingSort) this).\u0001.SelectedIndex = Convert.ToInt32((object) ((SortbuOptions) ((SortbuFilter) ((F_TuftingSort) this).SortSetting).Option).NextGroupRules);
    ((F_TuftingSort) this).\u0002.Items.Clear();
    ((F_TuftingSort) this).\u0002.Items.Add((object) buClassLanguage.SortingIntersectionRulesType[0]);
    ((F_TuftingSort) this).\u0002.Items.Add((object) buClassLanguage.SortingIntersectionRulesType[1]);
    ((F_TuftingSort) this).\u0002.Items.Add((object) buClassLanguage.SortingIntersectionRulesType[2]);
    ((F_TuftingSort) this).\u0002.Items.Add((object) buClassLanguage.SortingIntersectionRulesType[3]);
    ((F_TuftingSort) this).\u0002.Items.Add((object) buClassLanguage.SortingIntersectionRulesType[4]);
    ((F_TuftingSort) this).\u0002.Items.Add((object) buClassLanguage.SortingIntersectionRulesType[5]);
    ((F_TuftingSort) this).\u0002.Items.Add((object) buClassLanguage.SortingIntersectionRulesType[6]);
    ((F_TuftingSort) this).\u0002.Items.Add((object) buClassLanguage.SortingIntersectionRulesType[7]);
    ((F_TuftingSort) this).\u0002.Items.Add((object) buClassLanguage.SortingIntersectionRulesType[8]);
    ((F_TuftingSort) this).\u0002.SelectedIndex = Convert.ToInt32((object) ((SortbuOptions) ((SortbuFilter) ((F_TuftingSort) this).SortSetting).Option).IntersectionRules);
    ((F_TuftingSort) this).\u0002.Checked = ((SortbuOptions) ((SortbuFilter) ((F_TuftingSort) this).SortSetting).Option).isFirstPointCatchFromStartPointForDrawSequence;
    ((F_TuftingSort) this).\u0004.Value = (Decimal) ((SortbuOptions) ((SortbuFilter) ((F_TuftingSort) this).SortSetting).Option).Resolution;
    ((F_TuftingSort) this).\u0003.Value = (Decimal) ((SortbuOptions) ((SortbuFilter) ((F_TuftingSort) this).SortSetting).Option).ConstantPoint.X;
    ((F_TuftingSort) this).\u0002.Value = (Decimal) ((SortbuOptions) ((SortbuFilter) ((F_TuftingSort) this).SortSetting).Option).ConstantPoint.Y;
    ((F_TuftingSort) this).\u0001.Value = (Decimal) ((SortbuOptions) ((SortbuFilter) ((F_TuftingSort) this).SortSetting).Option).ConstantPoint.Z;
    this.ControlUpdate();
    this.LoadLanguage();
    ((F_TuftingSort) this).\u0001.Image = (Image) null;
    ((F_TuftingSort) this).PropertiesForm.Result = DialogResult.None;
    ((F_TuftingSort) this).PropertiesForm.Inited = true;
  }

  public void LoadLanguage()
  {
    string callMethod = nameof (LoadLanguage);
    try
    {
      if (F_TuftingSort.Captions.Count >= 9)
        ;
    }
    catch (Exception ex)
    {
      string str = "";
      buLog.addLog(str, "Not Ok", callMethod);
      buException.throwException(ex, callMethod, true, str);
    }
  }

  internal void \u0001([In] object obj0, [In] EventArgs obj1)
  {
    Control control1 = new Control();
    Control control2 = (Control) obj0;
    if (control2.Name == ((F_TuftingSort) this).btn_ok.Name)
    {
      this.Apply();
      ((F_TuftingSort) this).PropertiesForm.Result = DialogResult.OK;
      if (((F_TuftingSort) this).PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
        this.Dispose();
      if (((F_TuftingSort) this).PropertiesForm.FormCloseMode == FormCloseModeType.Invisible)
        this.Visible = false;
    }
    if (!(control2.Name == ((F_TuftingSort) this).btn_cancel.Name))
      return;
    ((F_TuftingSort) this).PropertiesForm.Result = DialogResult.Cancel;
    if (((F_TuftingSort) this).PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
      this.Dispose();
    if (((F_TuftingSort) this).PropertiesForm.FormCloseMode != FormCloseModeType.Invisible)
      return;
    this.Visible = false;
  }

  public void ControlUpdate()
  {
    ((F_TuftingSort) this).\u0002.Enabled = false;
    if (((F_TuftingSort) this).\u0001.SelectedIndex == 11)
      ((F_TuftingSort) this).\u0002.Enabled = true;
    ((F_TuftingSort) this).\u0002.Enabled = false;
    if (!(((F_TuftingSort) this).\u0001.SelectedIndex == 12 | ((F_TuftingSort) this).\u0001.SelectedIndex == 13))
      return;
    ((F_TuftingSort) this).\u0002.Enabled = true;
  }

  public void Apply()
  {
    ((SortbuOptions) ((SortbuFilter) ((F_TuftingSort) this).SortSetting).Option).NextGroupRules = (SortingNextGroupFindRulesType) ((F_TuftingSort) this).\u0001.SelectedIndex;
    ((SortbuOptions) ((SortbuFilter) ((F_TuftingSort) this).SortSetting).Option).IntersectionRules = (SortingIntersectionRulesType) ((F_TuftingSort) this).\u0002.SelectedIndex;
    ((SortbuOptions) ((SortbuFilter) ((F_TuftingSort) this).SortSetting).Option).isFirstPointCatchFromStartPointForDrawSequence = ((F_TuftingSort) this).\u0002.Checked;
    ((SortbuOptions) ((SortbuFilter) ((F_TuftingSort) this).SortSetting).Option).Resolution = (double) ((F_TuftingSort) this).\u0004.Value;
    ((SortbuOptions) ((SortbuFilter) ((F_TuftingSort) this).SortSetting).Option).ConstantPoint = new Point3D((double) ((F_TuftingSort) this).\u0003.Value, (double) ((F_TuftingSort) this).\u0002.Value, (double) ((F_TuftingSort) this).\u0001.Value);
  }

  internal void \u0002([In] object obj0, [In] EventArgs obj1)
  {
  }

  internal void \u0003([In] object obj0, [In] EventArgs obj1)
  {
    Control control = new Control();
    if (!((F_TuftingSort) this).PropertiesForm.Inited)
      return;
    ((F_TuftingSort) this).PropertiesForm.Inited = false;
    this.Apply();
    this.ControlUpdate();
    ((F_TuftingSort) this).PropertiesForm.Inited = true;
  }

  protected override void Dispose(bool disposing)
  {
    if ((!disposing ? 0 : (((F_TuftingSort) this).\u0001 != null ? 1 : 0)) != 0)
      ((F_TuftingSort) this).\u0001.Dispose();
    base.Dispose(disposing);
  }

  static F_WatchByGrid() => F_TuftingSort.Captions = new List<string>();

  public F_WatchByGrid()
  {
    ((F_TuftingRandomPattern) this).PropertiesForm = new FormProperties();
    ((F_TuftingRandomPattern) this).SurfPoints = new List<RoboticSurfacePoint>();
    ((F_TuftingRandomPattern) this).isTangent = false;
    ((F_TuftingRandomPattern) this).\u0001 = -1;
    ((F_TuftingRandomPattern) this).\u0002 = -1;
    ((F_TuftingRandomPattern) this).\u0001 = (IContainer) null;
    // ISSUE: explicit constructor call
    base.\u002Ector();
    \u0007.\u0001.\u0001((F_RoboticSurfacePoints) this);
  }

  [CompilerGenerated]
  [SpecialName]
  public void add_DataValueChanged(ApplyCommandWithDataEventHandler value)
  {
    // ISSUE: reference to a compiler-generated field
    ApplyCommandWithDataEventHandler dataEventHandler = ((F_TuftingRandomPattern) this).\u0001;
    ApplyCommandWithDataEventHandler comparand;
    do
    {
      comparand = dataEventHandler;
      // ISSUE: reference to a compiler-generated field
      dataEventHandler = Interlocked.CompareExchange<ApplyCommandWithDataEventHandler>(ref ((F_TuftingRandomPattern) this).\u0001, comparand + value, comparand);
    }
    while (dataEventHandler != comparand);
  }

  [CompilerGenerated]
  [SpecialName]
  public void remove_DataValueChanged(ApplyCommandWithDataEventHandler value)
  {
    // ISSUE: reference to a compiler-generated field
    ApplyCommandWithDataEventHandler dataEventHandler = ((F_TuftingRandomPattern) this).\u0001;
    ApplyCommandWithDataEventHandler comparand;
    do
    {
      comparand = dataEventHandler;
      // ISSUE: reference to a compiler-generated field
      dataEventHandler = Interlocked.CompareExchange<ApplyCommandWithDataEventHandler>(ref ((F_TuftingRandomPattern) this).\u0001, comparand - value, comparand);
    }
    while (dataEventHandler != comparand);
  }

  [CompilerGenerated]
  [SpecialName]
  public void add_SelectedIndexChanged(ApplyCommandWithDataEventHandler value)
  {
    // ISSUE: reference to a compiler-generated field
    ApplyCommandWithDataEventHandler dataEventHandler = ((F_TuftingRandomPattern) this).\u0002;
    ApplyCommandWithDataEventHandler comparand;
    do
    {
      comparand = dataEventHandler;
      // ISSUE: reference to a compiler-generated field
      dataEventHandler = Interlocked.CompareExchange<ApplyCommandWithDataEventHandler>(ref ((F_TuftingRandomPattern) this).\u0002, comparand + value, comparand);
    }
    while (dataEventHandler != comparand);
  }

  [CompilerGenerated]
  [SpecialName]
  public void remove_SelectedIndexChanged(ApplyCommandWithDataEventHandler value)
  {
    // ISSUE: reference to a compiler-generated field
    ApplyCommandWithDataEventHandler dataEventHandler = ((F_TuftingRandomPattern) this).\u0002;
    ApplyCommandWithDataEventHandler comparand;
    do
    {
      comparand = dataEventHandler;
      // ISSUE: reference to a compiler-generated field
      dataEventHandler = Interlocked.CompareExchange<ApplyCommandWithDataEventHandler>(ref ((F_TuftingRandomPattern) this).\u0002, comparand - value, comparand);
    }
    while (dataEventHandler != comparand);
  }

  public void Init()
  {
    ((F_TuftingRandomPattern) this).PropertiesForm.Inited = false;
    string str1 = "No";
    string str2 = "Sel";
    string str3 = "X Pos";
    string str4 = "Y Pos";
    string str5 = "Z Pos";
    string str6 = "A Angle";
    string str7 = "B Angle";
    string str8 = "C Angle";
    if (((F_TuftingRandomPattern) this).\u0001.Columns.Count == 0)
    {
      DataGridViewColumn dataGridViewColumn1 = new DataGridViewColumn();
      dataGridViewColumn1.SortMode = DataGridViewColumnSortMode.NotSortable;
      dataGridViewColumn1.Width = 40;
      dataGridViewColumn1.HeaderText = str1;
      dataGridViewColumn1.Name = "No";
      dataGridViewColumn1.ReadOnly = true;
      dataGridViewColumn1.DefaultCellStyle.Font = new Font("Arial", 10f, FontStyle.Bold);
      dataGridViewColumn1.CellTemplate = (DataGridViewCell) new DataGridViewTextBoxCell();
      ((F_TuftingRandomPattern) this).\u0001.Columns.Add(dataGridViewColumn1);
      DataGridViewColumn dataGridViewColumn2 = new DataGridViewColumn();
      dataGridViewColumn2.SortMode = DataGridViewColumnSortMode.NotSortable;
      dataGridViewColumn2.Width = 50;
      dataGridViewColumn2.HeaderText = str2;
      dataGridViewColumn2.Name = "Sel";
      dataGridViewColumn2.ReadOnly = false;
      dataGridViewColumn2.DefaultCellStyle.Font = new Font("Arial", 10f, FontStyle.Bold);
      dataGridViewColumn2.CellTemplate = (DataGridViewCell) new DataGridViewCheckBoxCell();
      ((F_TuftingRandomPattern) this).\u0001.Columns.Add(dataGridViewColumn2);
      DataGridViewColumn dataGridViewColumn3 = new DataGridViewColumn();
      dataGridViewColumn3.SortMode = DataGridViewColumnSortMode.NotSortable;
      dataGridViewColumn3.Width = 100;
      dataGridViewColumn3.HeaderText = str3;
      dataGridViewColumn3.Name = "XPos";
      dataGridViewColumn3.ReadOnly = false;
      dataGridViewColumn3.DefaultCellStyle.Font = new Font("Arial", 10f, FontStyle.Bold);
      dataGridViewColumn3.CellTemplate = (DataGridViewCell) new DataGridViewTextBoxCell();
      ((F_TuftingRandomPattern) this).\u0001.Columns.Add(dataGridViewColumn3);
      DataGridViewColumn dataGridViewColumn4 = new DataGridViewColumn();
      dataGridViewColumn4.SortMode = DataGridViewColumnSortMode.NotSortable;
      dataGridViewColumn4.Width = 100;
      dataGridViewColumn4.HeaderText = str4;
      dataGridViewColumn4.Name = "YPos";
      dataGridViewColumn4.ReadOnly = false;
      dataGridViewColumn4.DefaultCellStyle.Font = new Font("Arial", 10f, FontStyle.Bold);
      dataGridViewColumn4.CellTemplate = (DataGridViewCell) new DataGridViewTextBoxCell();
      ((F_TuftingRandomPattern) this).\u0001.Columns.Add(dataGridViewColumn4);
      DataGridViewColumn dataGridViewColumn5 = new DataGridViewColumn();
      dataGridViewColumn5.SortMode = DataGridViewColumnSortMode.NotSortable;
      dataGridViewColumn5.Width = 100;
      dataGridViewColumn5.HeaderText = str5;
      dataGridViewColumn5.Name = "ZPos";
      dataGridViewColumn5.ReadOnly = false;
      dataGridViewColumn5.DefaultCellStyle.Font = new Font("Arial", 10f, FontStyle.Bold);
      dataGridViewColumn5.CellTemplate = (DataGridViewCell) new DataGridViewTextBoxCell();
      ((F_TuftingRandomPattern) this).\u0001.Columns.Add(dataGridViewColumn5);
      DataGridViewColumn dataGridViewColumn6 = new DataGridViewColumn();
      dataGridViewColumn6.SortMode = DataGridViewColumnSortMode.NotSortable;
      dataGridViewColumn6.Width = 100;
      dataGridViewColumn6.HeaderText = str6;
      dataGridViewColumn6.Name = "APos";
      dataGridViewColumn6.ReadOnly = false;
      dataGridViewColumn6.DefaultCellStyle.Font = new Font("Arial", 10f, FontStyle.Bold);
      dataGridViewColumn6.CellTemplate = (DataGridViewCell) new DataGridViewTextBoxCell();
      ((F_TuftingRandomPattern) this).\u0001.Columns.Add(dataGridViewColumn6);
      DataGridViewColumn dataGridViewColumn7 = new DataGridViewColumn();
      dataGridViewColumn7.SortMode = DataGridViewColumnSortMode.NotSortable;
      dataGridViewColumn7.Width = 100;
      dataGridViewColumn7.HeaderText = str7;
      dataGridViewColumn7.Name = "BPos";
      dataGridViewColumn7.ReadOnly = false;
      dataGridViewColumn7.DefaultCellStyle.Font = new Font("Arial", 10f, FontStyle.Bold);
      dataGridViewColumn7.CellTemplate = (DataGridViewCell) new DataGridViewTextBoxCell();
      ((F_TuftingRandomPattern) this).\u0001.Columns.Add(dataGridViewColumn7);
      DataGridViewColumn dataGridViewColumn8 = new DataGridViewColumn();
      dataGridViewColumn8.SortMode = DataGridViewColumnSortMode.NotSortable;
      dataGridViewColumn8.Width = 100;
      dataGridViewColumn8.HeaderText = str8;
      dataGridViewColumn8.Name = "CPos";
      dataGridViewColumn8.ReadOnly = false;
      dataGridViewColumn8.DefaultCellStyle.Font = new Font("Arial", 10f, FontStyle.Bold);
      dataGridViewColumn8.CellTemplate = (DataGridViewCell) new DataGridViewTextBoxCell();
      ((F_TuftingRandomPattern) this).\u0001.Columns.Add(dataGridViewColumn8);
    }
    ((F_TuftingRandomPattern) this).\u0001.RowHeadersVisible = false;
    ((F_TuftingRandomPattern) this).\u0001.AllowUserToAddRows = false;
    ((F_TuftingRandomPattern) this).\u0001.AllowUserToResizeColumns = false;
    \u0007.\u0001.\u0001((F_RoboticSurfacePoints) this);
    this.LoadLanguage();
    ((F_TuftingRandomPattern) this).PropertiesForm.Result = DialogResult.None;
    ((F_TuftingRandomPattern) this).PropertiesForm.Inited = false;
  }

  public void LoadLanguage()
  {
    string callMethod = "NestSheetPart LoadLanguage";
    try
    {
      if (F_TuftingRandomPattern.Captions.Count < 33)
        return;
      this.Text = F_TuftingRandomPattern.Captions[0];
    }
    catch (Exception ex)
    {
      string str = "";
      buLog.addLog(str, "Not Ok", callMethod);
      buException.throwException(ex, callMethod, true, str);
    }
  }

  internal void \u0001([In] object obj0, [In] EventArgs obj1)
  {
    Control control = new Control();
    string str = "";
    if (obj0.GetType() == typeof (Control) | obj0.GetType() == typeof (Button))
    {
      control = (Control) obj0;
      str = control.Name;
    }
    if (obj0.GetType() == typeof (ToolStripMenuItem))
      str = ((ToolStripItem) obj0).Name;
    if (str == this.\u0004.Name)
      ;
    if (str == ((F_TuftingRandomPattern) this).\u0003.Name)
      ;
    if (str == this.\u0007.Name && ((F_TuftingRandomPattern) this).\u0001 >= 0 & ((F_TuftingRandomPattern) this).\u0002 >= 2)
    {
      ((F_TuftingRandomPattern) this).\u0001.Rows[((F_TuftingRandomPattern) this).\u0001].Cells[((F_TuftingRandomPattern) this).\u0002].Value = (object) (Convert.ToDouble(((F_TuftingRandomPattern) this).\u0001.Rows[((F_TuftingRandomPattern) this).\u0001].Cells[((F_TuftingRandomPattern) this).\u0002].Value.ToString()) - (double) this.\u0001.Value).ToString();
      this.\u0001((object) this.\u0005, (EventArgs) null);
    }
    if (str == this.\u0006.Name && ((F_TuftingRandomPattern) this).\u0001 >= 0 & ((F_TuftingRandomPattern) this).\u0002 >= 2)
    {
      ((F_TuftingRandomPattern) this).\u0001.Rows[((F_TuftingRandomPattern) this).\u0001].Cells[((F_TuftingRandomPattern) this).\u0002].Value = (object) (Convert.ToDouble(((F_TuftingRandomPattern) this).\u0001.Rows[((F_TuftingRandomPattern) this).\u0001].Cells[((F_TuftingRandomPattern) this).\u0002].Value.ToString()) + (double) this.\u0001.Value).ToString();
      this.\u0001((object) this.\u0005, (EventArgs) null);
    }
    if (control.Name == ((F_TuftingRandomPattern) this).\u0001.Name)
    {
      ((F_TuftingRandomPattern) this).PropertiesForm.Result = DialogResult.OK;
      if (((F_TuftingRandomPattern) this).PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
        this.Dispose();
      if (((F_TuftingRandomPattern) this).PropertiesForm.FormCloseMode == FormCloseModeType.Invisible)
        this.Visible = false;
    }
    if (control.Name == ((F_TuftingRandomPattern) this).\u0002.Name)
    {
      ((F_TuftingRandomPattern) this).PropertiesForm.Result = DialogResult.Cancel;
      if (((F_TuftingRandomPattern) this).PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
        this.Dispose();
      if (((F_TuftingRandomPattern) this).PropertiesForm.FormCloseMode == FormCloseModeType.Invisible)
        this.Visible = false;
    }
    // ISSUE: reference to a compiler-generated field
    if (!(str == this.\u0005.Name) || ((F_TuftingRandomPattern) this).\u0001 == null)
      return;
    double num = 30.0;
    for (int index = 0; index <= ((F_TuftingRandomPattern) this).\u0001.Rows.Count - 1; ++index)
    {
      bool boolean = Convert.ToBoolean(((F_TuftingRandomPattern) this).\u0001.Rows[index].Cells[1].Value.ToString());
      double x = Convert.ToDouble(((F_TuftingRandomPattern) this).\u0001.Rows[index].Cells[2].Value.ToString());
      double y = Convert.ToDouble(((F_TuftingRandomPattern) this).\u0001.Rows[index].Cells[3].Value.ToString());
      double z = Convert.ToDouble(((F_TuftingRandomPattern) this).\u0001.Rows[index].Cells[4].Value.ToString());
      double a = Convert.ToDouble(((F_TuftingRandomPattern) this).\u0001.Rows[index].Cells[5].Value.ToString());
      double b = Convert.ToDouble(((F_TuftingRandomPattern) this).\u0001.Rows[index].Cells[6].Value.ToString());
      double c = Convert.ToDouble(((F_TuftingRandomPattern) this).\u0001.Rows[index].Cells[7].Value.ToString());
      Point3D point3D = new Point3D(x, y, z);
      buCall.\u0001.PointAngle(new Point3D(((EyeCreateProps) ((F_TuftingRandomPattern) this).SurfPoints[index]).vecNormal.X, ((EyeCreateProps) ((F_TuftingRandomPattern) this).SurfPoints[index]).vecNormal.Y, ((EyeCreateProps) ((F_TuftingRandomPattern) this).SurfPoints[index]).vecNormal.Z), new Point3D(), Plane.XY);
      buCall.\u0001.PointAngle(new Point3D(((EyeCreateProps) ((F_TuftingRandomPattern) this).SurfPoints[index]).vecNormal.X, ((EyeCreateProps) ((F_TuftingRandomPattern) this).SurfPoints[index]).vecNormal.Y, ((EyeCreateProps) ((F_TuftingRandomPattern) this).SurfPoints[index]).vecNormal.Z), new Point3D(), Plane.XZ);
      buCall.\u0001.PointAngle(new Point3D(((EyeCreateProps) ((F_TuftingRandomPattern) this).SurfPoints[index]).vecNormal.X, ((EyeCreateProps) ((F_TuftingRandomPattern) this).SurfPoints[index]).vecNormal.Y, ((EyeCreateProps) ((F_TuftingRandomPattern) this).SurfPoints[index]).vecNormal.Z), new Point3D(), Plane.YZ);
      Line refEnt = new Line(new Point3D(point3D.X, point3D.Y, point3D.Z), new Point3D(point3D.X + num * ((EyeCreateProps) ((F_TuftingRandomPattern) this).SurfPoints[index]).vecNormal.X, point3D.Y + num * ((EyeCreateProps) ((F_TuftingRandomPattern) this).SurfPoints[index]).vecNormal.Y, point3D.Z + num * ((EyeCreateProps) ((F_TuftingRandomPattern) this).SurfPoints[index]).vecNormal.Z));
      ((CreateModelProperties) ((F_TuftingRandomPattern) this).SurfPoints[index]).entNormal = (Entity) refEnt;
      ((CreateModelProperties) ((F_TuftingRandomPattern) this).SurfPoints[index]).entTangent = buVector5.CopyEntities((Entity) refEnt);
      if (!((EyeCreateProps) ((F_TuftingRandomPattern) this).SurfPoints[index]).isLast)
        ((CreateModelProperties) ((F_TuftingRandomPattern) this).SurfPoints[index]).entTangent.Rotate(buString5.DegreeToRadian(-90.0), new Vector3D(((CreateModelProperties) ((F_TuftingRandomPattern) this).SurfPoints[index]).pntBase, ((CreateModelProperties) ((F_TuftingRandomPattern) this).SurfPoints[index]).pntNext), new Point3D(point3D.X, point3D.Y, point3D.Z));
      else
        ((CreateModelProperties) ((F_TuftingRandomPattern) this).SurfPoints[index]).entTangent.Rotate(buString5.DegreeToRadian(-90.0), new Vector3D(((CreateModelProperties) ((F_TuftingRandomPattern) this).SurfPoints[index]).pntPre, ((CreateModelProperties) ((F_TuftingRandomPattern) this).SurfPoints[index]).pntBase), new Point3D(point3D.X, point3D.Y, point3D.Z));
      buCall.\u0001.PointAngle(((Line) ((CreateModelProperties) ((F_TuftingRandomPattern) this).SurfPoints[index]).entTangent).EndPoint, ((Line) ((CreateModelProperties) ((F_TuftingRandomPattern) this).SurfPoints[index]).entTangent).StartPoint, Plane.XY);
      buCall.\u0001.PointAngle(((Line) ((CreateModelProperties) ((F_TuftingRandomPattern) this).SurfPoints[index]).entTangent).EndPoint, ((Line) ((CreateModelProperties) ((F_TuftingRandomPattern) this).SurfPoints[index]).entTangent).StartPoint, Plane.XZ);
      buCall.\u0001.PointAngle(((Line) ((CreateModelProperties) ((F_TuftingRandomPattern) this).SurfPoints[index]).entTangent).EndPoint, ((Line) ((CreateModelProperties) ((F_TuftingRandomPattern) this).SurfPoints[index]).entTangent).StartPoint, Plane.YZ);
      if (!((F_TuftingRandomPattern) this).isTangent)
        ((CreateModelProperties) ((F_TuftingRandomPattern) this).SurfPoints[index]).pntNormal = new Pnt6D(point3D.X, point3D.Y, point3D.Z, a, b, c);
      else
        ((CreateModelProperties) ((F_TuftingRandomPattern) this).SurfPoints[index]).pntTangent = new Pnt6D(point3D.X, point3D.Y, point3D.Z, a, b, c);
      ((EyeCreateProps) ((F_TuftingRandomPattern) this).SurfPoints[index]).Enable = boolean;
    }
    // ISSUE: reference to a compiler-generated field
    ((F_TuftingRandomPattern) this).\u0001((object) ((F_TuftingRandomPattern) this).SurfPoints);
  }

  internal void \u0001([In] object obj0, [In] DataGridViewCellEventArgs obj1)
  {
    if (!(obj1.RowIndex >= 0 & obj1.RowIndex <= ((F_TuftingRandomPattern) this).SurfPoints.Count - 1))
      return;
    ((F_TuftingRandomPattern) this).\u0001 = obj1.RowIndex;
    ((F_TuftingRandomPattern) this).\u0002 = obj1.ColumnIndex;
    // ISSUE: reference to a compiler-generated field
    if (((F_TuftingRandomPattern) this).\u0002 == null)
      return;
    // ISSUE: reference to a compiler-generated field
    ((F_TuftingRandomPattern) this).\u0002((object) ((F_TuftingRandomPattern) this).\u0001);
  }

  internal void \u0002([In] object obj0, [In] DataGridViewCellEventArgs obj1)
  {
    if (obj1.RowIndex >= 0 & obj1.RowIndex <= ((F_TuftingRandomPattern) this).SurfPoints.Count - 1)
      ;
  }

  internal void \u0003([In] object obj0, [In] DataGridViewCellEventArgs obj1)
  {
    if (!(obj1.ColumnIndex >= 0 & obj1.RowIndex >= 0))
      return;
    if (obj1.ColumnIndex == 1 & obj1.RowIndex <= ((F_TuftingRandomPattern) this).SurfPoints.Count - 1)
      ((EyeCreateProps) ((F_TuftingRandomPattern) this).SurfPoints[obj1.RowIndex]).Enable = Convert.ToBoolean(((F_TuftingRandomPattern) this).\u0001.Rows[obj1.RowIndex].Cells[obj1.ColumnIndex].Value);
    if (obj1.ColumnIndex == 2 & obj1.RowIndex <= ((F_TuftingRandomPattern) this).SurfPoints.Count - 1)
      ;
  }

  protected override void Dispose(bool disposing)
  {
    if ((!disposing ? 0 : (((F_TuftingRandomPattern) this).\u0001 != null ? 1 : 0)) != 0)
      ((F_TuftingRandomPattern) this).\u0001.Dispose();
    base.Dispose(disposing);
  }

  static F_WatchByGrid() => F_TuftingRandomPattern.Captions = new List<string>();

  public F_WatchByGrid()
  {
    \u007B0e48b843\u002Dfb72\u002D498c\u002D834d\u002Dfc743ba0facc\u007D.\u0001((F_SettingTreeView) this);
    this.\u0001.Dock = DockStyle.Fill;
  }

  internal void \u0001([In] object obj0, [In] EventArgs obj1)
  {
  }

  internal void \u0002([In] object obj0, [In] EventArgs obj1)
  {
    this.\u0001((object) this.\u0001, (TreeViewEventArgs) null);
  }

  internal void \u0001([In] object obj0, [In] FormClosingEventArgs obj1)
  {
    obj1.Cancel = true;
    this.Visible = false;
  }

  public void Init()
  {
    this.\u0001.TouchPayStyle = this.TouchPadStyle;
    this.\u0001.OwnerForm = (Form) this;
    this.tempClasses.Clear();
    this.tempClasses = new List<object>();
    for (int index = 0; index <= this.Classes.Count - 1; ++index)
    {
      object ObjPar = new object();
      ObjPar = Activator.CreateInstance(this.Classes[index].GetType());
      List<cParameter5> Vars = new List<cParameter5>();
      buSerilization5.GetClassVariables(this.Classes[index], ref Vars);
      buSerilization5.SetClassVariables(ref ObjPar, Vars);
      this.tempClasses.Add(ObjPar);
    }
    this.\u0001.Nodes.Clear();
    if (AppSecurity.PasswordLevel < this.AccessPasswordLevel)
    {
      this.\u0001.Enabled = false;
      this.btn_apply.Enabled = false;
      this.btn_ok.Enabled = false;
      this.btn_default.Enabled = false;
    }
    else
    {
      this.\u0001.Enabled = true;
      this.btn_apply.Enabled = true;
      this.btn_ok.Enabled = true;
      this.btn_default.Enabled = true;
    }
    this.\u0001.SelectedNode = (TreeNode) null;
    List<string> stringList = new List<string>();
    for (int index1 = 0; index1 <= this.tempClasses.Count - 1; ++index1)
    {
      if (this.tempClasses[index1] != null)
      {
        List<cParameter5> Vars1 = new List<cParameter5>();
        string name = this.tempClasses[index1].GetType().Name;
        if (this.CaptionHeader.Count > 0 & index1 <= this.CaptionHeader.Count - 1)
          name = this.CaptionHeader[index1];
        TreeNodeSettings node1 = (TreeNodeSettings) new F_TextWireframe();
        buSerilization5.GetClassVariables(this.tempClasses[index1], ref Vars1);
        for (int index2 = 0; index2 <= Vars1.Count - 1; ++index2)
        {
          System.Type type1 = ((EditorRuntimeSettings) Vars1[index2]).Value.GetType();
          if (type1.IsClass)
          {
            bool flag = false;
            if (type1.Name.ToLower() == "SolidItemDisplay")
              flag = true;
            if (type1.Name.ToLower() == "drawpropertiestype")
              flag = true;
            if (type1.Name == "MouseKeyboardConfigration" | type1.Name == "EntityResolution")
              flag = true;
            if (type1.BaseType.Namespace == "buClass" & !flag)
            {
              List<cParameter5> Vars2 = new List<cParameter5>();
              buSerilization5.GetClassVariables(((EditorRuntimeSettings) Vars1[index2]).Value, ref Vars2);
              TreeNodeSettings node2 = (TreeNodeSettings) new F_TextWireframe();
              for (int index3 = 0; index3 <= Vars2.Count - 1; ++index3)
              {
                System.Type type2 = ((EditorRuntimeSettings) Vars2[index3]).Value.GetType();
                if (type2.IsClass && type2.BaseType.Namespace == "buClass")
                {
                  TreeNodeSettings node3 = (TreeNodeSettings) new F_TextWireframe();
                  node3.Text = ((EditorRuntimeSettings) Vars2[index3]).Name;
                  node3.Tag = ((EditorRuntimeSettings) Vars2[index3]).Value;
                  node3.ImageIndex = 1;
                  node3.SelectedImageIndex = 1;
                  ((F_WatchByGrid) node3).ClassIndex = index1;
                  ((F_WatchByGrid) node3).ClassSubIndex = index2;
                  node2.Nodes.Add((TreeNode) node3);
                }
              }
              node2.Text = ((EditorRuntimeSettings) Vars1[index2]).Name;
              node2.Tag = ((EditorRuntimeSettings) Vars1[index2]).Value;
              node2.ImageIndex = 1;
              node2.SelectedImageIndex = 1;
              ((F_WatchByGrid) node2).ClassIndex = index1;
              ((F_WatchByGrid) node2).ClassSubIndex = index2;
              node1.Nodes.Add((TreeNode) node2);
            }
          }
        }
        node1.Text = name;
        node1.Tag = this.tempClasses[index1];
        node1.ImageIndex = 2;
        node1.SelectedImageIndex = 2;
        ((F_WatchByGrid) node1).ClassIndex = index1;
        ((F_WatchByGrid) node1).ClassSubIndex = 0;
        this.\u0001.Nodes.Add((TreeNode) node1);
      }
    }
    if (this.tempClasses.Count > 0)
      this.\u0001.SelectedNode = this.\u0001.Nodes[0];
    this.TopMost = this.FormTopMost;
    if (this.ScreenCenter)
      this.StartPosition = FormStartPosition.CenterScreen;
    this.\u0001 = true;
    this.LoadLangueage();
  }

  public void LoadLangueage()
  {
    string callMethod = "SettingsTreeView LoadLanguage";
    try
    {
      if (F_WatchByGrid.Captions.Count < 7)
        return;
      this.Text = F_WatchByGrid.Captions[0];
      this.btn_default.Text = F_WatchByGrid.Captions[1];
      this.btn_saveastext.Text = F_WatchByGrid.Captions[2];
      this.btn_apply.Text = F_WatchByGrid.Captions[3];
      this.btn_ok.Text = F_WatchByGrid.Captions[4];
      this.btn_cancel.Text = F_WatchByGrid.Captions[5];
      this.\u0001.Text = F_WatchByGrid.Captions[6];
    }
    catch (Exception ex)
    {
      string str = "";
      buLog.addLog(str, "Not Ok", callMethod);
      buException.throwException(ex, callMethod, true, str);
    }
  }

  internal void \u0001([In] object obj0, [In] TreeViewEventArgs obj1)
  {
    if (!this.\u0001 || obj1 == null || this.\u0001.SelectedNode.Tag == null || this.\u0001.SelectedNode.Nodes == null)
      return;
    this.\u0001.ClassObject = this.\u0001.SelectedNode.Tag;
    this.\u0001.Init();
  }

  internal void \u0003([In] object obj0, [In] EventArgs obj1)
  {
    if (this.\u0001.SelectedNode == null)
    {
      this.Visible = false;
    }
    else
    {
      this.\u0005(obj0, obj1);
      this.tempClasses = new List<object>();
      object tag = this.\u0001.SelectedNode.Tag;
      this.Result = DialogResult.OK;
      this.Visible = false;
    }
  }

  internal void \u0004([In] object obj0, [In] EventArgs obj1)
  {
    this.tempClasses = new List<object>();
    this.Result = DialogResult.Cancel;
    this.Visible = false;
  }

  internal void \u0005([In] object obj0, [In] EventArgs obj1)
  {
    if (this.\u0001.SelectedNode == null)
    {
      this.Visible = false;
    }
    else
    {
      this.btn_apply.Focus();
      for (int index1 = 0; index1 <= this.\u0001.Nodes.Count - 1; ++index1)
      {
        object tempClass = this.tempClasses[index1];
        if (this.\u0001.Nodes[index1].Nodes != null)
        {
          for (int index2 = 0; index2 <= this.\u0001.Nodes[index1].Nodes.Count - 1; ++index2)
          {
            List<cParameter5> Vars = new List<cParameter5>();
            object tag = this.\u0001.Nodes[index1].Nodes[index2].Tag;
            buSerilization5.GetClassVariables(tag, ref Vars);
            buSerilization5.SetClassVariables(ref tag, Vars);
          }
        }
        object tag1 = this.\u0001.Nodes[index1].Tag;
        this.tempClasses[index1] = tempClass;
      }
      for (int index = 0; index <= this.tempClasses.Count - 1; ++index)
      {
        object CopiedClass = new object();
        CopiedClass = Activator.CreateInstance(this.tempClasses[index].GetType());
        buSerilization5.CopyClass(this.tempClasses[index], ref CopiedClass);
        this.Classes[index] = CopiedClass;
      }
      // ISSUE: reference to a compiler-generated field
      if (this.\u0001 == null)
        return;
      // ISSUE: reference to a compiler-generated field
      ((F_ViewportMouseCfg) this.\u0001).Invoke();
    }
  }

  internal void \u0006([In] object obj0, [In] EventArgs obj1)
  {
    // ISSUE: reference to a compiler-generated field
    if (this.\u0001 != null)
    {
      // ISSUE: reference to a compiler-generated field
      ((F_ViewportMouseCfg) this.\u0001).Invoke();
    }
    this.Visible = false;
  }

  internal void \u0007([In] object obj0, [In] EventArgs obj1)
  {
    List<string> StringList = new List<string>();
    SaveFileDialog saveFileDialog = new SaveFileDialog();
    saveFileDialog.InitialDirectory = Application.StartupPath;
    saveFileDialog.Filter = "Settings CSV Files (*.csv)|*.csv";
    saveFileDialog.FilterIndex = 1;
    saveFileDialog.FileName = "";
    if (saveFileDialog.ShowDialog() != DialogResult.OK)
      return;
    for (int index1 = 0; index1 <= this.\u0001.Nodes.Count - 1; ++index1)
    {
      object tempClass = this.tempClasses[index1];
      if (this.\u0001.Nodes[index1].Nodes != null)
      {
        if (this.\u0001.Nodes[index1].Nodes.Count > 0)
        {
          for (int index2 = 0; index2 <= this.\u0001.Nodes[index1].Nodes.Count - 1; ++index2)
          {
            List<cParameter5> Vars = new List<cParameter5>();
            buSerilization5.GetClassVariables(this.\u0001.Nodes[index1].Nodes[index2].Tag, ref Vars);
            for (int index3 = 0; index3 <= Vars.Count - 1; ++index3)
            {
              string str = $"{this.\u0001.Nodes[index1].Text} ; {this.\u0001.Nodes[index1].Nodes[index2].Text}; {((EditorRuntimeSettings) Vars[index3]).Name} ; {((EditorRuntimeSettings) Vars[index3]).ValueAsString.ToString()}";
              StringList.Add(str);
            }
          }
        }
        else
        {
          List<cParameter5> Vars = new List<cParameter5>();
          buSerilization5.GetClassVariables(this.\u0001.Nodes[index1].Tag, ref Vars);
          for (int index4 = 0; index4 <= Vars.Count - 1; ++index4)
          {
            string str = $"{this.\u0001.Nodes[index1].Text} ;  - ; {((EditorRuntimeSettings) Vars[index4]).Name} ; {((EditorRuntimeSettings) Vars[index4]).ValueAsString.ToString()}";
            StringList.Add(str);
          }
        }
      }
      object tag = this.\u0001.Nodes[index1].Tag;
      this.tempClasses[index1] = tempClass;
    }
    buFile.SaveToFile(StringList, saveFileDialog.FileName);
  }

  internal void \u0008([In] object obj0, [In] EventArgs obj1)
  {
    DialogBoxList dialogBoxList = new DialogBoxList();
    CodesysAxis data = (CodesysAxis) null;
    if (this.\u0001.SelectedNode.Parent == null && this.\u0001.SelectedNode.Tag.GetType() == typeof (CodesysAxis))
      data = new CodesysAxis((CodesysAxis) this.\u0001.SelectedNode.Tag);
    if (data == null)
      return;
    for (int index = 0; index <= this.Classes.Count - 1; ++index)
    {
      if (this.Classes[index].GetType() == typeof (CodesysAxis))
        dialogBoxList.Items.Add(((CodesysAxis) this.Classes[index]).Base.baseChar);
    }
    dialogBoxList.Init();
    int num = (int) dialogBoxList.ShowDialog();
    if (dialogBoxList.Result != DialogResult.OK)
      return;
    if (this.Classes[dialogBoxList.SelectedIndex].GetType() == typeof (CodesysAxis))
      this.Classes[dialogBoxList.SelectedIndex] = (object) new CodesysAxis(data);
    this.Init();
  }

  public event WatchItemResetClickEventHandler ResetClick;

  public event WatchItemRemoveAllClickEventHandler RemoveAllClick;

  public event WatchItemRemoveClickEventHandler RemoveClick;

  public event WatchItemListChangedEventHandler ListChanged;

  public event WatchItemWriteEventHandler WriteItems;
}
