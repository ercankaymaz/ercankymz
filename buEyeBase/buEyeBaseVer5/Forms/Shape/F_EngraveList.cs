// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Forms.Shape.F_EngraveList
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using buClass.Apps;
using buClass.UserFiles.buCad;
using buControls.Controls;
using buEyeBaseVer5.Forms.SheetBending;
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
namespace buEyeBaseVer5.Forms.Shape;

public class F_EngraveList : Form
{
  public string AddString;
  public static List<string> Captions;
  public FormProperties PropertiesForm;
  public List<WatchItem> Items;
  public bool HideNewValueColumb;
  public bool HideExplanationColumb;
  public bool HideStatusColumb;
  public bool HideMinVal;
  public bool HideMaxVal;
  public bool Editing;
  private int \u0001;
  private int \u0002;
  private IContainer \u0001;
  internal buGround \u0001;
  public DataGridView DGV;
  public buButton btn_add;
  public buButton btn_cancel;
  public buButton btn_write;
  public buButton btn_save;
  public buButton btn_load;
  public buButton btn_addstring;
  public buButton btn_reset;
  public buButton btn_removeall;
  public buButton btn_remove;
  public buButton btn_minimize;
  public buButton btn_maximize;
  public buButton btn_closecross;
  internal buGround \u0002;
  internal RadioButton \u0001;
  internal RadioButton \u0002;
  internal RadioButton \u0003;
  internal RadioButton \u0004;
  internal RadioButton \u0005;
  public buButton btn_varok;
  public buButton btn_varclose;
  internal buGround \u0003;
  public buButton btnN_stringglobal;
  public buButton btn_cancelstring;
  public buButton btn_stringIO;
  public buButton btn_stringpersist;
  public static byte f00113A;
  public FormProperties PropertiesForm;
  public static List<string> Captions;
  internal IContainer \u0001;
  internal Button \u0001;
  internal ImageList \u0001;
  internal Button \u0002;
  public PictureBox pic_camera;
  public Button btn_camerastart;
  public Button btn_camerastop;
  public Button btn_cameratakeshot;
  public static byte f001145;
  public FormProperties PropertiesForm;
  public setMouse Settings;

  protected override void Dispose(bool disposing)
  {
    if ((!disposing ? 0 : (((F_JunctionList) this).\u0001 != null ? 1 : 0)) != 0)
      ((F_JunctionList) this).\u0001.Dispose();
    base.Dispose(disposing);
  }

  static F_EngraveList() => F_SheetBendData.Captions = new List<string>();

  public F_EngraveList()
  {
    ((F_JunctionList) this).PropertiesForm = new FormProperties();
    ((F_JunctionList) this).Settings = new TuftingSettings();
    ((F_JunctionList) this).SelectedLayerIndex = -1;
    ((F_JunctionList) this).SelectedLayerName = "";
    ((F_JunctionList) this).Layers = new List<LayerBase5>();
    ((F_JunctionList) this).\u0001 = (IContainer) null;
    // ISSUE: explicit constructor call
    base.\u002Ector();
    \u007B0e48b843\u002Dfb72\u002D498c\u002D834d\u002Dfc743ba0facc\u007D.\u0001((F_TuftingSort) this);
  }

  [CompilerGenerated]
  [SpecialName]
  public void add_DataValueChanged(ApplyCommandWithDataEventHandler value)
  {
    // ISSUE: reference to a compiler-generated field
    ApplyCommandWithDataEventHandler dataEventHandler = ((F_JunctionList) this).\u0001;
    ApplyCommandWithDataEventHandler comparand;
    do
    {
      comparand = dataEventHandler;
      // ISSUE: reference to a compiler-generated field
      dataEventHandler = Interlocked.CompareExchange<ApplyCommandWithDataEventHandler>(ref ((F_JunctionList) this).\u0001, comparand + value, comparand);
    }
    while (dataEventHandler != comparand);
  }

  [CompilerGenerated]
  [SpecialName]
  public void remove_DataValueChanged(ApplyCommandWithDataEventHandler value)
  {
    // ISSUE: reference to a compiler-generated field
    ApplyCommandWithDataEventHandler dataEventHandler = ((F_JunctionList) this).\u0001;
    ApplyCommandWithDataEventHandler comparand;
    do
    {
      comparand = dataEventHandler;
      // ISSUE: reference to a compiler-generated field
      dataEventHandler = Interlocked.CompareExchange<ApplyCommandWithDataEventHandler>(ref ((F_JunctionList) this).\u0001, comparand - value, comparand);
    }
    while (dataEventHandler != comparand);
  }

  [CompilerGenerated]
  [SpecialName]
  public void add_SelectedIndexChanged(ApplyCommandWithDataEventHandler value)
  {
    // ISSUE: reference to a compiler-generated field
    ApplyCommandWithDataEventHandler dataEventHandler = ((F_JunctionList) this).\u0002;
    ApplyCommandWithDataEventHandler comparand;
    do
    {
      comparand = dataEventHandler;
      // ISSUE: reference to a compiler-generated field
      dataEventHandler = Interlocked.CompareExchange<ApplyCommandWithDataEventHandler>(ref ((F_JunctionList) this).\u0002, comparand + value, comparand);
    }
    while (dataEventHandler != comparand);
  }

  [CompilerGenerated]
  [SpecialName]
  public void remove_SelectedIndexChanged(ApplyCommandWithDataEventHandler value)
  {
    // ISSUE: reference to a compiler-generated field
    ApplyCommandWithDataEventHandler dataEventHandler = ((F_JunctionList) this).\u0002;
    ApplyCommandWithDataEventHandler comparand;
    do
    {
      comparand = dataEventHandler;
      // ISSUE: reference to a compiler-generated field
      dataEventHandler = Interlocked.CompareExchange<ApplyCommandWithDataEventHandler>(ref ((F_JunctionList) this).\u0002, comparand - value, comparand);
    }
    while (dataEventHandler != comparand);
  }

  public void Init()
  {
    ((F_JunctionList) this).PropertiesForm.Inited = false;
    if (((F_JunctionList) this).Settings.SortType == tuftingSelectionModeType.Auto)
    {
      ((F_JunctionList) this).\u0008.Checked = true;
      ((F_JunctionList) this).\u0007.Checked = false;
    }
    else
    {
      ((F_JunctionList) this).\u0008.Checked = false;
      ((F_JunctionList) this).\u0007.Checked = true;
    }
    ((F_JunctionList) this).\u0006.Checked = false;
    ((F_JunctionList) this).\u0005.Checked = false;
    ((F_JunctionList) this).\u0003.Checked = false;
    ((F_JunctionList) this).\u0004.Checked = false;
    ((F_JunctionList) this).\u0001.Checked = false;
    ((F_JunctionList) this).\u0002.Checked = false;
    if (((F_JunctionList) this).Settings.SortAutoNextGroupRules == SortingNextGroupFindRulesType.ClosestLength)
      ((F_JunctionList) this).\u0006.Checked = true;
    else if (((F_JunctionList) this).Settings.SortAutoNextGroupRules == SortingNextGroupFindRulesType.DrawingSequence)
      ((F_JunctionList) this).\u0005.Checked = true;
    else if (((F_JunctionList) this).Settings.SortAutoNextGroupRules == SortingNextGroupFindRulesType.MinXMinY)
      ((F_JunctionList) this).\u0004.Checked = true;
    else if (((F_JunctionList) this).Settings.SortAutoNextGroupRules == SortingNextGroupFindRulesType.MaxXMinY)
      ((F_JunctionList) this).\u0003.Checked = true;
    else if (((F_JunctionList) this).Settings.SortAutoNextGroupRules == SortingNextGroupFindRulesType.MinYMinX)
      ((F_JunctionList) this).\u0002.Checked = true;
    else if (((F_JunctionList) this).Settings.SortAutoNextGroupRules == SortingNextGroupFindRulesType.MaxYMinX)
      ((F_JunctionList) this).\u0001.Checked = true;
    ((F_JunctionList) this).\u0001.Checked = ((F_JunctionList) this).Settings.SortOutlineFirst;
    ((F_JunctionList) this).\u0002.Checked = ((F_JunctionList) this).Settings.SortBoxBounding;
    ((F_JunctionList) this).\u0001.HeaderStyle = ColumnHeaderStyle.None;
    ((F_JunctionList) this).\u0001.View = View.Details;
    ((F_JunctionList) this).\u0001.FullRowSelect = true;
    ((F_JunctionList) this).\u0001.Columns.Add("", -2);
    ((F_JunctionList) this).\u0001.Columns[0].Width = ((F_JunctionList) this).\u0001.Width - 5;
    for (int index = 0; index <= ((F_JunctionList) this).Layers.Count - 1; ++index)
    {
      if (((DevideEventFormVars) ((F_JunctionList) this).Layers[index]).Name.IndexOf("T_") >= 0)
      {
        ListViewItem listViewItem = new ListViewItem(((DevideEventFormVars) ((F_JunctionList) this).Layers[index]).Name);
        listViewItem.BackColor = Color.White;
        listViewItem.ForeColor = ((DevideEventFormVars) ((F_JunctionList) this).Layers[index]).LayerColor;
        if (buFile5.isColorSimilar(listViewItem.ForeColor, Color.White, 5.0))
          listViewItem.ForeColor = Color.Black;
        ((F_JunctionList) this).\u0001.Items.Add(listViewItem);
      }
    }
    if (((F_JunctionList) this).\u0001.Items.Count > 0)
      ;
    for (int index = 0; index <= ((F_JunctionList) this).\u0001.Items.Count - 1; ++index)
    {
      if (((F_JunctionList) this).\u0001.Items[index].Text == ((F_JunctionList) this).SelectedLayerName)
        ((F_JunctionList) this).\u0001.Items[index].Selected = true;
    }
    ((F_JunctionList) this).\u0001.Select();
    this.LoadLanguage();
    ((F_JunctionList) this).PropertiesForm.Result = DialogResult.None;
    ((F_JunctionList) this).PropertiesForm.Inited = false;
  }

  public void LoadLanguage()
  {
    string callMethod = "NestSheetPart LoadLanguage";
    try
    {
      if (F_JunctionList.Captions.Count < 33)
        return;
      this.Text = F_JunctionList.Captions[0];
    }
    catch (Exception ex)
    {
      string str = "";
      buLog.addLog(str, "Not Ok", callMethod);
      buException.throwException(ex, callMethod, true, str);
    }
  }

  public void Apply()
  {
    if (((F_JunctionList) this).\u0008.Checked)
      ((F_JunctionList) this).Settings.SortType = tuftingSelectionModeType.Auto;
    else
      ((F_JunctionList) this).Settings.SortType = tuftingSelectionModeType.Manuel;
    if (((F_JunctionList) this).\u0006.Checked)
      ((F_JunctionList) this).Settings.SortAutoNextGroupRules = SortingNextGroupFindRulesType.ClosestLength;
    else if (((F_JunctionList) this).\u0005.Checked)
      ((F_JunctionList) this).Settings.SortAutoNextGroupRules = SortingNextGroupFindRulesType.DrawingSequence;
    else if (((F_JunctionList) this).\u0004.Checked)
      ((F_JunctionList) this).Settings.SortAutoNextGroupRules = SortingNextGroupFindRulesType.MinXMinY;
    else if (((F_JunctionList) this).\u0003.Checked)
      ((F_JunctionList) this).Settings.SortAutoNextGroupRules = SortingNextGroupFindRulesType.MaxXMinY;
    else if (((F_JunctionList) this).\u0002.Checked)
      ((F_JunctionList) this).Settings.SortAutoNextGroupRules = SortingNextGroupFindRulesType.MinYMinX;
    else if (((F_JunctionList) this).\u0001.Checked)
      ((F_JunctionList) this).Settings.SortAutoNextGroupRules = SortingNextGroupFindRulesType.MaxYMinX;
    ((F_JunctionList) this).Settings.SortBoxBounding = ((F_JunctionList) this).\u0002.Checked;
    ((F_JunctionList) this).Settings.SortOutlineFirst = ((F_JunctionList) this).\u0001.Checked;
    ((F_JunctionList) this).SelectedLayerName = ((F_JunctionList) this).\u0001.SelectedItems[0].Text;
  }

  internal void \u0001([In] object obj0, [In] EventArgs obj1)
  {
    Control control = new Control();
    if (obj0.GetType() == typeof (Control) | obj0.GetType() == typeof (Button))
    {
      control = (Control) obj0;
      string name = control.Name;
    }
    if (obj0.GetType() == typeof (ToolStripMenuItem))
    {
      string name1 = ((ToolStripItem) obj0).Name;
    }
    if (control.Name == ((F_JunctionList) this).\u0001.Name)
    {
      this.Apply();
      ((F_JunctionList) this).PropertiesForm.Result = DialogResult.OK;
      if (((F_JunctionList) this).PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
        this.Dispose();
      if (((F_JunctionList) this).PropertiesForm.FormCloseMode == FormCloseModeType.Invisible)
        this.Visible = false;
    }
    if (!(control.Name == ((F_JunctionList) this).\u0002.Name))
      return;
    ((F_JunctionList) this).PropertiesForm.Result = DialogResult.Cancel;
    if (((F_JunctionList) this).PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
      this.Dispose();
    if (((F_JunctionList) this).PropertiesForm.FormCloseMode != FormCloseModeType.Invisible)
      return;
    this.Visible = false;
  }

  protected override void Dispose(bool disposing)
  {
    if ((!disposing ? 0 : (((F_JunctionList) this).\u0001 != null ? 1 : 0)) != 0)
      ((F_JunctionList) this).\u0001.Dispose();
    base.Dispose(disposing);
  }

  static F_EngraveList() => F_JunctionList.Captions = new List<string>();

  public F_EngraveList()
  {
    ((F_JunctionList) this).PropertiesForm = new FormProperties();
    ((F_JunctionList) this).Settings = new TuftingSettings();
    ((F_JunctionList) this).\u0001 = (IContainer) null;
    // ISSUE: explicit constructor call
    base.\u002Ector();
    \u0007.\u0001.\u0001((F_TuftingRandomPattern) this);
  }

  public void Init()
  {
    ((F_JunctionList) this).PropertiesForm.Inited = false;
    if (((F_JunctionList) this).PropertiesForm.Height > 10)
      this.Height = ((F_JunctionList) this).PropertiesForm.Height;
    if (((F_JunctionList) this).PropertiesForm.Width > 10)
      this.Width = ((F_JunctionList) this).PropertiesForm.Width;
    this.TopMost = ((F_JunctionList) this).PropertiesForm.TopMost;
    this.StartPosition = ((F_JunctionList) this).PropertiesForm.FormPosition;
    ((F_JunctionList) this).\u0002.Value = (Decimal) ((F_JunctionList) this).Settings.RandomPatternColorNumber;
    ((F_JunctionList) this).\u0003.Value = (Decimal) ((F_JunctionList) this).Settings.RandomPatternColorLineNumber;
    ((F_JunctionList) this).\u0001.Value = (Decimal) ((F_JunctionList) this).Settings.StraightRowSpace;
    this.ControlUpdate();
    this.LoadLanguage();
    ((F_JunctionList) this).PropertiesForm.Result = DialogResult.None;
    ((F_JunctionList) this).PropertiesForm.Inited = true;
  }

  public void LoadLanguage()
  {
    string callMethod = nameof (LoadLanguage);
    try
    {
      if (F_JunctionList.Captions.Count >= 9)
        ;
    }
    catch (Exception ex)
    {
      string str = "";
      buLog.addLog(str, "Not Ok", callMethod);
      buException.throwException(ex, callMethod, true, str);
    }
  }

  internal void \u0001([In] object obj0, [In] FormClosingEventArgs obj1)
  {
    if (((F_JunctionList) this).PropertiesForm.Result == DialogResult.OK)
      return;
    obj1.Cancel = true;
    ((F_JunctionList) this).PropertiesForm.Result = DialogResult.Cancel;
    if (((F_JunctionList) this).PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
      this.Dispose();
    if (((F_JunctionList) this).PropertiesForm.FormCloseMode != FormCloseModeType.Invisible)
      return;
    this.Visible = false;
  }

  internal void \u0001([In] object obj0, [In] EventArgs obj1)
  {
    Control control1 = new Control();
    Control control2 = (Control) obj0;
    if (control2.Name == ((F_JunctionList) this).btn_ok.Name)
    {
      ((F_ProfilingList) this).Apply();
      ((F_JunctionList) this).PropertiesForm.Result = DialogResult.OK;
      if (((F_JunctionList) this).PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
        this.Dispose();
      if (((F_JunctionList) this).PropertiesForm.FormCloseMode == FormCloseModeType.Invisible)
        this.Visible = false;
      ((F_JunctionList) this).Settings.RandomPatternColorNumber = (int) ((F_JunctionList) this).\u0002.Value;
      ((F_JunctionList) this).Settings.RandomPatternColorLineNumber = (int) ((F_JunctionList) this).\u0003.Value;
      ((F_JunctionList) this).Settings.StraightRowSpace = (double) ((F_JunctionList) this).\u0001.Value;
    }
    if (!(control2.Name == ((F_JunctionList) this).btn_cancel.Name))
      return;
    ((F_JunctionList) this).PropertiesForm.Result = DialogResult.Cancel;
    if (((F_JunctionList) this).PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
      this.Dispose();
    if (((F_JunctionList) this).PropertiesForm.FormCloseMode != FormCloseModeType.Invisible)
      return;
    this.Visible = false;
  }

  public void ControlUpdate()
  {
  }

  public event OkCommandWithTwoDataEventHandler DataOk;

  public event CancelCommandEventHandler DataCancel;
}
