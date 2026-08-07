// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Forms.Shape.F_ProfilingList
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using buControls.Controls;
using buCore;
using buEyeBaseVer5.Forms.Watch;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;

#nullable disable
namespace buEyeBaseVer5.Forms.Shape;

public class F_ProfilingList : Form
{
  public static List<string> Captions;
  internal IContainer \u0001;
  internal Button \u0001;
  internal ImageList \u0001;
  internal Button \u0002;
  internal Label \u0001;
  internal Panel \u0001;
  internal RadioButton \u0001;
  internal RadioButton \u0002;
  internal RadioButton \u0003;
  internal Panel \u0002;
  internal RadioButton \u0004;
  internal RadioButton \u0005;
  internal RadioButton \u0006;
  internal Label \u0002;
  internal Label \u0003;
  internal Panel \u0003;
  internal RadioButton \u0007;
  internal RadioButton \u0008;
  internal RadioButton \u000E;
  internal Panel \u0004;
  internal RadioButton \u000F;
  internal RadioButton \u0010;
  internal RadioButton \u0011;
  internal Label \u0004;
  internal Panel \u0005;
  internal RadioButton \u0012;
  internal RadioButton \u0013;
  internal RadioButton \u0014;
  internal Panel \u0006;
  internal RadioButton \u0015;
  internal RadioButton \u0016;
  internal RadioButton \u0017;
  internal Label \u0005;
  public static byte f00116A;
  public FormProperties Properties;
  public static List<string> Captions;
  public double TextHeight;
  public string TextString;
  internal IContainer \u0001;
  internal ImageList \u0001;
  internal buGround \u0001;
  public buButton btn_ok;
  public buButton btn_cancel;
  internal buButton \u0001;
  public buSpin spn_textheight;
  internal buTextBox \u0001;
  public static byte f001177;
  public System.Windows.Forms.Timer timWarning;
  public static List<string> Captions;
  public FormProperties PropertiesForm;
  private IContainer \u0001;
  internal buGround \u0001;
  public buButton btn_start;
  public buButton btn_close;
  public buSpin spn_step;
  public buButton btn_next;
  public buButton btn_pre;

  public void Apply()
  {
    ((F_JunctionList) this).Settings.RandomPatternColorNumber = (int) ((F_JunctionList) this).\u0002.Value;
    ((F_JunctionList) this).Settings.RandomPatternColorLineNumber = (int) ((F_JunctionList) this).\u0003.Value;
    ((F_JunctionList) this).Settings.StraightRowSpace = (double) ((F_JunctionList) this).\u0001.Value;
  }

  protected override void Dispose(bool disposing)
  {
    if ((!disposing ? 0 : (((F_JunctionList) this).\u0001 != null ? 1 : 0)) != 0)
      ((F_JunctionList) this).\u0001.Dispose();
    base.Dispose(disposing);
  }

  static F_ProfilingList() => F_JunctionList.Captions = new List<string>();

  public F_ProfilingList()
  {
    ((F_EngraveList) this).AddString = "";
    ((F_EngraveList) this).PropertiesForm = new FormProperties();
    ((F_EngraveList) this).Items = new List<WatchItem>();
    ((F_EngraveList) this).HideNewValueColumb = false;
    ((F_EngraveList) this).HideExplanationColumb = true;
    ((F_EngraveList) this).HideStatusColumb = true;
    ((F_EngraveList) this).HideMinVal = false;
    ((F_EngraveList) this).HideMaxVal = false;
    ((F_EngraveList) this).Editing = false;
    ((F_EngraveList) this).\u0001 = -1;
    ((F_EngraveList) this).\u0002 = -1;
    ((F_EngraveList) this).\u0001 = (IContainer) null;
    // ISSUE: explicit constructor call
    base.\u002Ector();
    \u0007.\u0001.\u0001((F_WatchByGrid) this);
  }

  [CompilerGenerated]
  [SpecialName]
  public void add_ResetClick(WatchItemResetClickEventHandler value)
  {
    // ISSUE: reference to a compiler-generated field
    WatchItemResetClickEventHandler clickEventHandler = ((F_EngraveList) this).\u0001;
    WatchItemResetClickEventHandler comparand;
    do
    {
      comparand = clickEventHandler;
      // ISSUE: reference to a compiler-generated field
      clickEventHandler = Interlocked.CompareExchange<WatchItemResetClickEventHandler>(ref ((F_EngraveList) this).\u0001, comparand + value, comparand);
    }
    while (clickEventHandler != comparand);
  }

  [CompilerGenerated]
  [SpecialName]
  public void remove_ResetClick(WatchItemResetClickEventHandler value)
  {
    // ISSUE: reference to a compiler-generated field
    WatchItemResetClickEventHandler clickEventHandler = ((F_EngraveList) this).\u0001;
    WatchItemResetClickEventHandler comparand;
    do
    {
      comparand = clickEventHandler;
      // ISSUE: reference to a compiler-generated field
      clickEventHandler = Interlocked.CompareExchange<WatchItemResetClickEventHandler>(ref ((F_EngraveList) this).\u0001, comparand - value, comparand);
    }
    while (clickEventHandler != comparand);
  }

  [CompilerGenerated]
  [SpecialName]
  public void add_RemoveAllClick(WatchItemRemoveAllClickEventHandler value)
  {
    // ISSUE: reference to a compiler-generated field
    WatchItemRemoveAllClickEventHandler clickEventHandler = ((F_EngraveList) this).\u0001;
    WatchItemRemoveAllClickEventHandler comparand;
    do
    {
      comparand = clickEventHandler;
      // ISSUE: reference to a compiler-generated field
      clickEventHandler = Interlocked.CompareExchange<WatchItemRemoveAllClickEventHandler>(ref ((F_EngraveList) this).\u0001, comparand + value, comparand);
    }
    while (clickEventHandler != comparand);
  }

  [CompilerGenerated]
  [SpecialName]
  public void remove_RemoveAllClick(WatchItemRemoveAllClickEventHandler value)
  {
    // ISSUE: reference to a compiler-generated field
    WatchItemRemoveAllClickEventHandler clickEventHandler = ((F_EngraveList) this).\u0001;
    WatchItemRemoveAllClickEventHandler comparand;
    do
    {
      comparand = clickEventHandler;
      // ISSUE: reference to a compiler-generated field
      clickEventHandler = Interlocked.CompareExchange<WatchItemRemoveAllClickEventHandler>(ref ((F_EngraveList) this).\u0001, comparand - value, comparand);
    }
    while (clickEventHandler != comparand);
  }

  [CompilerGenerated]
  [SpecialName]
  public void add_RemoveClick(WatchItemRemoveClickEventHandler value)
  {
    // ISSUE: reference to a compiler-generated field
    WatchItemRemoveClickEventHandler clickEventHandler = ((F_EngraveList) this).\u0001;
    WatchItemRemoveClickEventHandler comparand;
    do
    {
      comparand = clickEventHandler;
      // ISSUE: reference to a compiler-generated field
      clickEventHandler = Interlocked.CompareExchange<WatchItemRemoveClickEventHandler>(ref ((F_EngraveList) this).\u0001, comparand + value, comparand);
    }
    while (clickEventHandler != comparand);
  }

  [CompilerGenerated]
  [SpecialName]
  public void remove_RemoveClick(WatchItemRemoveClickEventHandler value)
  {
    // ISSUE: reference to a compiler-generated field
    WatchItemRemoveClickEventHandler clickEventHandler = ((F_EngraveList) this).\u0001;
    WatchItemRemoveClickEventHandler comparand;
    do
    {
      comparand = clickEventHandler;
      // ISSUE: reference to a compiler-generated field
      clickEventHandler = Interlocked.CompareExchange<WatchItemRemoveClickEventHandler>(ref ((F_EngraveList) this).\u0001, comparand - value, comparand);
    }
    while (clickEventHandler != comparand);
  }

  [CompilerGenerated]
  [SpecialName]
  public void add_ListChanged(WatchItemListChangedEventHandler value)
  {
    // ISSUE: reference to a compiler-generated field
    WatchItemListChangedEventHandler changedEventHandler = ((F_EngraveList) this).\u0001;
    WatchItemListChangedEventHandler comparand;
    do
    {
      comparand = changedEventHandler;
      // ISSUE: reference to a compiler-generated field
      changedEventHandler = Interlocked.CompareExchange<WatchItemListChangedEventHandler>(ref ((F_EngraveList) this).\u0001, comparand + value, comparand);
    }
    while (changedEventHandler != comparand);
  }

  [CompilerGenerated]
  [SpecialName]
  public void remove_ListChanged(WatchItemListChangedEventHandler value)
  {
    // ISSUE: reference to a compiler-generated field
    WatchItemListChangedEventHandler changedEventHandler = ((F_EngraveList) this).\u0001;
    WatchItemListChangedEventHandler comparand;
    do
    {
      comparand = changedEventHandler;
      // ISSUE: reference to a compiler-generated field
      changedEventHandler = Interlocked.CompareExchange<WatchItemListChangedEventHandler>(ref ((F_EngraveList) this).\u0001, comparand - value, comparand);
    }
    while (changedEventHandler != comparand);
  }

  [CompilerGenerated]
  [SpecialName]
  public void add_WriteItems(WatchItemWriteEventHandler value)
  {
    // ISSUE: reference to a compiler-generated field
    WatchItemWriteEventHandler writeEventHandler = ((F_EngraveList) this).\u0001;
    WatchItemWriteEventHandler comparand;
    do
    {
      comparand = writeEventHandler;
      // ISSUE: reference to a compiler-generated field
      writeEventHandler = Interlocked.CompareExchange<WatchItemWriteEventHandler>(ref ((F_EngraveList) this).\u0001, comparand + value, comparand);
    }
    while (writeEventHandler != comparand);
  }

  [CompilerGenerated]
  [SpecialName]
  public void remove_WriteItems(WatchItemWriteEventHandler value)
  {
    // ISSUE: reference to a compiler-generated field
    WatchItemWriteEventHandler writeEventHandler = ((F_EngraveList) this).\u0001;
    WatchItemWriteEventHandler comparand;
    do
    {
      comparand = writeEventHandler;
      // ISSUE: reference to a compiler-generated field
      writeEventHandler = Interlocked.CompareExchange<WatchItemWriteEventHandler>(ref ((F_EngraveList) this).\u0001, comparand - value, comparand);
    }
    while (writeEventHandler != comparand);
  }

  public void Init()
  {
    try
    {
      ((F_EngraveList) this).PropertiesForm.Inited = false;
      if (((F_EngraveList) this).PropertiesForm.Height > 10)
        this.Height = ((F_EngraveList) this).PropertiesForm.Height;
      if (((F_EngraveList) this).PropertiesForm.Width > 10)
        this.Width = ((F_EngraveList) this).PropertiesForm.Width;
      this.TopMost = ((F_EngraveList) this).PropertiesForm.TopMost;
      this.StartPosition = ((F_EngraveList) this).PropertiesForm.FormPosition;
      ((F_EngraveList) this).DGV.Columns.Clear();
      if (((F_EngraveList) this).DGV.Columns.Count == 0)
      {
        DataGridViewColumn dataGridViewColumn1 = new DataGridViewColumn();
        dataGridViewColumn1.SortMode = DataGridViewColumnSortMode.NotSortable;
        dataGridViewColumn1.Width = 40;
        dataGridViewColumn1.HeaderText = buLangTranslate.preDef.No;
        dataGridViewColumn1.Name = "No";
        dataGridViewColumn1.ReadOnly = true;
        dataGridViewColumn1.DefaultCellStyle.Font = new Font("Arial", 10f, FontStyle.Bold);
        dataGridViewColumn1.CellTemplate = (DataGridViewCell) new DataGridViewTextBoxCell();
        ((F_EngraveList) this).DGV.Columns.Add(dataGridViewColumn1);
        DataGridViewColumn dataGridViewColumn2 = new DataGridViewColumn();
        dataGridViewColumn2.SortMode = DataGridViewColumnSortMode.NotSortable;
        dataGridViewColumn2.Width = 400;
        dataGridViewColumn2.HeaderText = buLangTranslate.preDef.Name;
        dataGridViewColumn2.Name = buLangTranslate.preDef.Name;
        dataGridViewColumn2.ReadOnly = false;
        dataGridViewColumn2.DefaultCellStyle.Font = new Font("Arial", 10f, FontStyle.Bold);
        dataGridViewColumn2.CellTemplate = (DataGridViewCell) new DataGridViewTextBoxCell();
        ((F_EngraveList) this).DGV.Columns.Add(dataGridViewColumn2);
        DataGridViewColumn dataGridViewColumn3 = new DataGridViewColumn();
        dataGridViewColumn3.SortMode = DataGridViewColumnSortMode.NotSortable;
        dataGridViewColumn3.Width = 100;
        dataGridViewColumn3.HeaderText = buLangTranslate.preDef.Value;
        dataGridViewColumn3.Name = buLangTranslate.preDef.Value;
        dataGridViewColumn3.ReadOnly = false;
        dataGridViewColumn3.DefaultCellStyle.Font = new Font("Arial", 10f, FontStyle.Bold);
        dataGridViewColumn3.CellTemplate = (DataGridViewCell) new DataGridViewTextBoxCell();
        ((F_EngraveList) this).DGV.Columns.Add(dataGridViewColumn3);
        DataGridViewColumn dataGridViewColumn4 = new DataGridViewColumn();
        dataGridViewColumn4.SortMode = DataGridViewColumnSortMode.NotSortable;
        dataGridViewColumn4.Width = 100;
        dataGridViewColumn4.HeaderText = $"{buLangTranslate.preDef.New} {buLangTranslate.preDef.Value}";
        dataGridViewColumn4.Name = $"{buLangTranslate.preDef.New} {buLangTranslate.preDef.Value}";
        dataGridViewColumn4.ReadOnly = false;
        dataGridViewColumn4.DefaultCellStyle.Font = new Font("Arial", 10f, FontStyle.Bold);
        dataGridViewColumn4.CellTemplate = (DataGridViewCell) new DataGridViewTextBoxCell();
        ((F_EngraveList) this).DGV.Columns.Add(dataGridViewColumn4);
        DataGridViewColumn dataGridViewColumn5 = new DataGridViewColumn();
        dataGridViewColumn5.SortMode = DataGridViewColumnSortMode.NotSortable;
        dataGridViewColumn5.Width = 80 /*0x50*/;
        dataGridViewColumn5.HeaderText = buLangTranslate.preDef.Type;
        dataGridViewColumn5.Name = buLangTranslate.preDef.Type;
        dataGridViewColumn5.ReadOnly = false;
        dataGridViewColumn5.DefaultCellStyle.Font = new Font("Arial", 10f, FontStyle.Bold);
        dataGridViewColumn5.CellTemplate = (DataGridViewCell) new DataGridViewTextBoxCell();
        ((F_EngraveList) this).DGV.Columns.Add(dataGridViewColumn5);
        DataGridViewColumn dataGridViewColumn6 = new DataGridViewColumn();
        dataGridViewColumn6.SortMode = DataGridViewColumnSortMode.NotSortable;
        dataGridViewColumn6.Width = 80 /*0x50*/;
        dataGridViewColumn6.HeaderText = buLangTranslate.preDef.Min;
        dataGridViewColumn6.Name = buLangTranslate.preDef.Min;
        dataGridViewColumn6.ReadOnly = false;
        dataGridViewColumn6.DefaultCellStyle.Font = new Font("Arial", 10f, FontStyle.Bold);
        dataGridViewColumn6.CellTemplate = (DataGridViewCell) new DataGridViewTextBoxCell();
        ((F_EngraveList) this).DGV.Columns.Add(dataGridViewColumn6);
        DataGridViewColumn dataGridViewColumn7 = new DataGridViewColumn();
        dataGridViewColumn7.SortMode = DataGridViewColumnSortMode.NotSortable;
        dataGridViewColumn7.Width = 80 /*0x50*/;
        dataGridViewColumn7.HeaderText = buLangTranslate.preDef.Max;
        dataGridViewColumn7.Name = buLangTranslate.preDef.Max;
        dataGridViewColumn7.ReadOnly = false;
        dataGridViewColumn7.DefaultCellStyle.Font = new Font("Arial", 10f, FontStyle.Bold);
        dataGridViewColumn7.CellTemplate = (DataGridViewCell) new DataGridViewTextBoxCell();
        ((F_EngraveList) this).DGV.Columns.Add(dataGridViewColumn7);
        DataGridViewColumn dataGridViewColumn8 = new DataGridViewColumn();
        dataGridViewColumn8.SortMode = DataGridViewColumnSortMode.NotSortable;
        dataGridViewColumn8.Width = 100;
        dataGridViewColumn8.HeaderText = buLangTranslate.preDef.Explanation;
        dataGridViewColumn8.Name = buLangTranslate.preDef.Explanation;
        dataGridViewColumn8.ReadOnly = false;
        dataGridViewColumn8.DefaultCellStyle.Font = new Font("Arial", 10f, FontStyle.Bold);
        dataGridViewColumn8.CellTemplate = (DataGridViewCell) new DataGridViewTextBoxCell();
        ((F_EngraveList) this).DGV.Columns.Add(dataGridViewColumn8);
        DataGridViewColumn dataGridViewColumn9 = new DataGridViewColumn();
        dataGridViewColumn9.SortMode = DataGridViewColumnSortMode.NotSortable;
        dataGridViewColumn9.Width = 100;
        dataGridViewColumn9.HeaderText = buLangTranslate.preDef.Status;
        dataGridViewColumn9.Name = buLangTranslate.preDef.Status;
        dataGridViewColumn9.ReadOnly = false;
        dataGridViewColumn9.DefaultCellStyle.Font = new Font("Arial", 10f, FontStyle.Bold);
        dataGridViewColumn9.CellTemplate = (DataGridViewCell) new DataGridViewTextBoxCell();
        ((F_EngraveList) this).DGV.Columns.Add(dataGridViewColumn9);
      }
      ((F_EngraveList) this).DGV.RowHeadersVisible = false;
      ((F_EngraveList) this).DGV.AllowUserToAddRows = false;
      ((F_EngraveList) this).DGV.AllowUserToResizeColumns = true;
      if (((F_EngraveList) this).HideNewValueColumb)
      {
        ((F_EngraveList) this).DGV.Columns[3].Visible = false;
        ((F_EngraveList) this).DGV.Columns[3].Width = 0;
      }
      if (((F_EngraveList) this).HideExplanationColumb)
      {
        ((F_EngraveList) this).DGV.Columns[7].Visible = false;
        ((F_EngraveList) this).DGV.Columns[7].Width = 0;
      }
      if (((F_EngraveList) this).HideStatusColumb)
      {
        ((F_EngraveList) this).DGV.Columns[8].Visible = false;
        ((F_EngraveList) this).DGV.Columns[8].Width = 0;
      }
      if (((F_EngraveList) this).HideMaxVal)
      {
        ((F_EngraveList) this).DGV.Columns[6].Visible = false;
        ((F_EngraveList) this).DGV.Columns[6].Width = 0;
      }
      if (((F_EngraveList) this).HideMinVal)
      {
        ((F_EngraveList) this).DGV.Columns[5].Visible = false;
        ((F_EngraveList) this).DGV.Columns[5].Width = 0;
      }
      for (int index = 0; index <= ((F_EngraveList) this).Items.Count - 1; ++index)
      {
        DataGridViewRowCollection rows = ((F_EngraveList) this).DGV.Rows;
        string name = ((F_EngraveList) this).Items[index].Name;
        string str1 = ((F_EngraveList) this).Items[index].ValueString.ToString();
        string str2 = "";
        string str3 = ((F_EngraveList) this).Items[index].VarType.ToString();
        string str4 = "";
        string str5 = "";
        string explanation = ((F_EngraveList) this).Items[index].Explanation;
        string str6 = "";
        object[] objArray = \u0007.\u0001.\u0001(str4, explanation, (F_WatchByGrid) this, index + 1, str1, str5, str3, str6, name, str2);
        rows.Add(objArray);
      }
      ((F_EngraveList) this).PropertiesForm.Result = DialogResult.None;
      ((F_EngraveList) this).PropertiesForm.Inited = true;
    }
    catch (Exception ex)
    {
      string str = "";
      buLog.addLog(str, "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, true, str);
    }
  }

  public void LoadLanguage()
  {
    try
    {
      if (F_EngraveList.Captions.Count <= 0)
        return;
      this.Text = F_EngraveList.Captions[0];
      ((F_EngraveList) this).btn_reset.Text = F_EngraveList.Captions[0];
      ((F_EngraveList) this).btn_write.Text = F_EngraveList.Captions[0];
      ((F_EngraveList) this).btn_add.Text = F_EngraveList.Captions[0];
      ((F_EngraveList) this).btn_remove.Text = F_EngraveList.Captions[0];
      ((F_EngraveList) this).btn_removeall.Text = F_EngraveList.Captions[0];
      ((F_EngraveList) this).btn_save.Text = F_EngraveList.Captions[0];
      ((F_EngraveList) this).btn_cancel.Text = F_EngraveList.Captions[0];
    }
    catch (Exception ex)
    {
      string str = "";
      buLog.addLog(str, "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, true, str);
    }
  }

  internal void \u0001([In] object obj0, [In] FormClosingEventArgs obj1)
  {
    if (((F_EngraveList) this).PropertiesForm.Result == DialogResult.OK)
      return;
    obj1.Cancel = true;
    ((F_EngraveList) this).PropertiesForm.Result = DialogResult.Cancel;
    if (((F_EngraveList) this).PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
      this.Dispose();
    if (((F_EngraveList) this).PropertiesForm.FormCloseMode != FormCloseModeType.Invisible)
      return;
    this.Visible = false;
  }

  public void UpdateWatchList(List<WatchItem> Items)
  {
    try
    {
      if (((F_EngraveList) this).Editing)
        return;
      for (int index = 0; index <= Items.Count - 1; ++index)
      {
        if (index <= ((F_EngraveList) this).DGV.Rows.Count - 1)
        {
          if (((F_EngraveList) this).DGV.Rows[index].Cells[2].Value.ToString() != Items[index].ValueString.ToString())
          {
            ((F_EngraveList) this).DGV.Rows[index].Cells[2].Value = (object) Items[index].ValueString.ToString();
            ((F_EngraveList) this).DGV.Rows[index].Cells[5].Value = (object) Items[index].MinValue.ToString();
            ((F_EngraveList) this).DGV.Rows[index].Cells[6].Value = (object) Items[index].MaxValue.ToString();
            ((F_EngraveList) this).DGV.Rows[index].Cells[8].Value = (object) Items[index].Status.ToString();
          }
          ((F_EngraveList) this).DGV.Rows[index].Cells[8].Value = (object) Items[index].Status;
          if (!Items[index].CommStatus)
            ((F_EngraveList) this).DGV.Rows[index].Cells[2].Style.BackColor = Color.LightCoral;
          else
            ((F_EngraveList) this).DGV.Rows[index].Cells[2].Style.BackColor = Color.White;
        }
      }
    }
    catch (Exception ex)
    {
      string str = "";
      buLog.addLog(str, "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, true, str);
    }
  }

  internal void \u0001([In] object obj0, [In] DataGridViewCellEventArgs obj1)
  {
    try
    {
      ((F_EngraveList) this).\u0001 = obj1.RowIndex;
      ((F_EngraveList) this).\u0002 = obj1.ColumnIndex;
    }
    catch (Exception ex)
    {
      string str = "";
      buLog.addLog(str, "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, true, str);
    }
  }

  internal void \u0002([In] object obj0, [In] DataGridViewCellEventArgs obj1)
  {
    try
    {
      if (!(obj1.RowIndex >= 0 & obj1.RowIndex <= ((F_EngraveList) this).Items.Count - 1))
        return;
      if (obj1.ColumnIndex == 1)
      {
        ((F_EngraveList) this).Items[obj1.RowIndex].Name = ((F_EngraveList) this).DGV.Rows[obj1.RowIndex].Cells[obj1.ColumnIndex].Value.ToString();
        // ISSUE: reference to a compiler-generated field
        if (((F_EngraveList) this).\u0001 != null)
        {
          // ISSUE: reference to a compiler-generated field
          ((F_EngraveList) this).\u0001(((F_EngraveList) this).Items);
        }
      }
      if (obj1.ColumnIndex == 3)
        ((F_EngraveList) this).Items[obj1.RowIndex].NewValue = ((F_EngraveList) this).DGV.Rows[obj1.RowIndex].Cells[obj1.ColumnIndex].Value.ToString();
      ((F_EngraveList) this).btn_write.Focus();
    }
    catch (Exception ex)
    {
      string str = "";
      buLog.addLog(str, "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, true, str);
    }
  }

  internal void \u0001([In] object obj0, [In] EventArgs obj1)
  {
    try
    {
      // ISSUE: reference to a compiler-generated field
      if (((F_EngraveList) this).\u0001 == null)
        return;
      // ISSUE: reference to a compiler-generated field
      ((F_EngraveList) this).\u0001();
    }
    catch (Exception ex)
    {
      string str = "";
      buLog.addLog(str, "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, true, str);
    }
  }

  internal void \u0002([In] object obj0, [In] EventArgs obj1)
  {
    try
    {
      SaveFileDialog saveFileDialog = new SaveFileDialog();
      saveFileDialog.InitialDirectory = Application.StartupPath;
      saveFileDialog.Filter = "Watch Item Files (*.watch)|*.watch";
      saveFileDialog.FilterIndex = 1;
      saveFileDialog.FileName = "";
      if (saveFileDialog.ShowDialog() != DialogResult.OK)
        return;
      List<string> StringList = new List<string>();
      StringList.Add("Name ; Value ; MinValue ; MaxValue ; AvarageValue ; Explanation");
      for (int index = 0; index <= ((F_EngraveList) this).Items.Count - 1; ++index)
      {
        string str = $"{((F_EngraveList) this).Items[index].Name} ; {((F_EngraveList) this).Items[index].Value.ToString()} ; {((F_EngraveList) this).Items[index].MinValue.ToString()} ; {((F_EngraveList) this).Items[index].MaxValue.ToString()} ; {((F_EngraveList) this).Items[index].AvarageValue.ToString()} ; {((F_EngraveList) this).Items[index].Explanation}";
        StringList.Add(str);
      }
      buFile.SaveToFile(StringList, saveFileDialog.FileName);
    }
    catch (Exception ex)
    {
      string str = "";
      buLog.addLog(str, "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, true, str);
    }
  }

  public event OkCommandWithTwoDataEventHandler DataOk;

  public event CancelCommandEventHandler DataCancel;
}
