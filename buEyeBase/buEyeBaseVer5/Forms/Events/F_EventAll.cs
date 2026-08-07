// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Forms.Events.F_EventAll
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using buEyeBaseVer5.Forms.File;
using buEyeBaseVer5.Forms.Foam;
using dummy_ptr;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

#nullable disable
namespace buEyeBaseVer5.Forms.Events;

public class F_EventAll : Form
{
  public Button btn_ok;
  internal ImageList \u0002;
  internal Panel \u0001;
  internal Label \u0001;
  internal NumericUpDown \u0001;
  internal Label \u0002;
  internal NumericUpDown \u0002;
  public DataGridView DGV_table;
  public Button btn_remove;
  public Button btn_add;
  public static byte f003121;
  public FormProperties PropertiesForm;
  public static List<string> Captions;
  public FoamType foamType;
  private IContainer \u0001;
  internal ImageList \u0001;
  internal Button \u0001;
  internal Button \u0002;
  internal Button \u0003;
  internal Button \u0004;
  internal Button \u0005;
  internal Button \u0006;
  internal Button \u0007;
  public static byte f00312E;
  public FormProperties PropertiesForm;
  public SizeObject FoamSize;
  public bool ValueChanging;
  internal IContainer \u0001;
  internal Button \u0001;
  internal Button \u0002;
  internal ImageList \u0001;
  internal ImageList \u0002;
  internal Button \u0003;
  internal ImageList \u0003;
  internal Button \u0004;
  public NumericUpDown spn_blocktotalwidth;
  public NumericUpDown spn_blocktotalheight;
  public NumericUpDown spn_blockwidthstartoffset;

  public void Apply()
  {
    ((UCSObjectData) ((F_AddImageFromFile) this).Converter).AMultiply = (double) ((F_AddFromFile) this).\u0008.Value;
    ((UCSObjectData) ((F_AddImageFromFile) this).Converter).BMultiply = (double) ((F_AddFromFile) this).\u000F.Value;
    ((UCSObjectData) ((F_AddImageFromFile) this).Converter).CMultiply = (double) ((F_AddFromFile) this).\u0011.Value;
    ((UCSObjectData) ((F_AddImageFromFile) this).Converter).XMultiply = (double) ((F_AddImageFromFile) this).\u0001.Value;
    ((UCSObjectData) ((F_AddImageFromFile) this).Converter).YMultiply = (double) ((F_AddFromFile) this).\u0004.Value;
    ((UCSObjectData) ((F_AddImageFromFile) this).Converter).ZMultiply = (double) ((F_AddFromFile) this).\u0006.Value;
    ((MacroItem) ((F_AddImageFromFile) this).Converter).SMultiply = (double) ((F_AddFromFile) this).\u0015.Value;
    ((MacroItem) ((F_AddImageFromFile) this).Converter).FMultiply = (double) ((F_AddFromFile) this).\u0013.Value;
    ((hmiUIDataGridView) ((F_AddImageFromFile) this).Converter).AOffset = (double) ((F_AddFromFile) this).\u0007.Value;
    ((hmiUIDataGridView) ((F_AddImageFromFile) this).Converter).BOffset = (double) ((F_AddFromFile) this).\u000E.Value;
    ((UCSObjectData) ((F_AddImageFromFile) this).Converter).COffset = (double) ((F_AddFromFile) this).\u0010.Value;
    ((hmiUIDataGridView) ((F_AddImageFromFile) this).Converter).XOffset = (double) ((F_AddFromFile) this).\u0002.Value;
    ((hmiUIDataGridView) ((F_AddImageFromFile) this).Converter).YOffset = (double) ((F_AddFromFile) this).\u0003.Value;
    ((hmiUIDataGridView) ((F_AddImageFromFile) this).Converter).ZOffset = (double) ((F_AddFromFile) this).\u0005.Value;
    ((UCSObjectData) ((F_AddImageFromFile) this).Converter).FOffset = (double) ((F_AddFromFile) this).\u0012.Value;
    ((UCSObjectData) ((F_AddImageFromFile) this).Converter).SOffset = (double) ((F_AddFromFile) this).\u0014.Value;
    ((MacroItem) ((F_AddImageFromFile) this).Converter).FilterLength = (double) ((F_AddFromFile) this).\u0016.Value;
  }

  internal void \u0001([In] object obj0, [In] FormClosingEventArgs obj1)
  {
    if (((F_AddImageFromFile) this).PropertiesForm.Result == DialogResult.OK)
      return;
    obj1.Cancel = true;
    ((F_AddImageFromFile) this).PropertiesForm.Result = DialogResult.Cancel;
    if (((F_AddImageFromFile) this).PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
      this.Dispose();
    if (((F_AddImageFromFile) this).PropertiesForm.FormCloseMode != FormCloseModeType.Invisible)
      return;
    this.Visible = false;
  }

  internal void \u0001([In] object obj0, [In] EventArgs obj1)
  {
    Control control1 = new Control();
    Control control2 = (Control) obj0;
    if (control2.Name == ((F_AddImageFromFile) this).btn_ok.Name)
    {
      this.Apply();
      ((F_AddImageFromFile) this).PropertiesForm.Result = DialogResult.OK;
      if (((F_AddImageFromFile) this).PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
        this.Dispose();
      if (((F_AddImageFromFile) this).PropertiesForm.FormCloseMode != FormCloseModeType.Invisible)
        return;
      this.Visible = false;
    }
    else
    {
      if (!(control2.Name == ((F_AddImageFromFile) this).btn_cancel.Name))
        return;
      ((F_AddImageFromFile) this).PropertiesForm.Result = DialogResult.Cancel;
      if (((F_AddImageFromFile) this).PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
        this.Dispose();
      if (((F_AddImageFromFile) this).PropertiesForm.FormCloseMode != FormCloseModeType.Invisible)
        return;
      this.Visible = false;
    }
  }

  protected override void Dispose(bool disposing)
  {
    if ((!disposing ? 0 : (((F_AddImageFromFile) this).\u0001 != null ? 1 : 0)) != 0)
      ((F_AddImageFromFile) this).\u0001.Dispose();
    base.Dispose(disposing);
  }

  static F_EventAll() => F_AddImageFromFile.Captions = new List<string>();

  public F_EventAll()
  {
    ((F_AddFromFile) this).PropertiesForm = new FormProperties();
    ((F_AddFromFile) this).RadiusFeedList = new List<camRadiusFeed>();
    ((F_AddFromFile) this).LengthFeedList = new List<camLengthFeed>();
    ((F_AddFromFile) this).SelectedRadiusRowSheet = -1;
    ((F_AddFromFile) this).SelectedLengthRowSheet = -1;
    ((F_AddFromFile) this).\u0001 = (IContainer) null;
    // ISSUE: explicit constructor call
    base.\u002Ector();
    \u007B0e48b843\u002Dfb72\u002D498c\u002D834d\u002Dfc743ba0facc\u007D.\u0001((F_FoamSpeedList) this);
  }

  public void Init()
  {
    ((F_AddFromFile) this).PropertiesForm.Inited = false;
    if (((F_AddFromFile) this).PropertiesForm.Height > 10)
      this.Height = ((F_AddFromFile) this).PropertiesForm.Height;
    if (((F_AddFromFile) this).PropertiesForm.Width > 10)
      this.Width = ((F_AddFromFile) this).PropertiesForm.Width;
    this.TopMost = ((F_AddFromFile) this).PropertiesForm.TopMost;
    this.StartPosition = ((F_AddFromFile) this).PropertiesForm.FormPosition;
    this.ControlUpdate();
    this.LoadLanguage();
    if (((F_AddFromFile) this).\u0002.Columns.Count == 0)
    {
      DataGridViewColumn dataGridViewColumn1 = new DataGridViewColumn();
      dataGridViewColumn1.SortMode = DataGridViewColumnSortMode.NotSortable;
      dataGridViewColumn1.Width = 40;
      dataGridViewColumn1.HeaderText = buLangTranslate.preDef.No;
      dataGridViewColumn1.Name = buLangTranslate.preDef.No;
      dataGridViewColumn1.ReadOnly = true;
      dataGridViewColumn1.DefaultCellStyle.Font = new Font("Arial", 10f, FontStyle.Bold);
      dataGridViewColumn1.CellTemplate = (DataGridViewCell) new DataGridViewTextBoxCell();
      ((F_AddFromFile) this).\u0002.Columns.Add(dataGridViewColumn1);
      DataGridViewColumn dataGridViewColumn2 = new DataGridViewColumn();
      dataGridViewColumn2.SortMode = DataGridViewColumnSortMode.NotSortable;
      dataGridViewColumn2.Width = 120;
      dataGridViewColumn2.HeaderText = $"{buLangTranslate.preDef.Min} {buLangTranslate.preDef.Length}";
      dataGridViewColumn2.Name = $"{buLangTranslate.preDef.Min} {buLangTranslate.preDef.Length}";
      dataGridViewColumn2.ReadOnly = false;
      dataGridViewColumn2.DefaultCellStyle.Font = new Font("Arial", 10f, FontStyle.Bold);
      dataGridViewColumn2.CellTemplate = (DataGridViewCell) new DataGridViewTextBoxCell();
      ((F_AddFromFile) this).\u0002.Columns.Add(dataGridViewColumn2);
      DataGridViewColumn dataGridViewColumn3 = new DataGridViewColumn();
      dataGridViewColumn3.SortMode = DataGridViewColumnSortMode.NotSortable;
      dataGridViewColumn3.Width = 120;
      dataGridViewColumn2.HeaderText = $"{buLangTranslate.preDef.Max} {buLangTranslate.preDef.Length}";
      dataGridViewColumn3.Name = $"{buLangTranslate.preDef.Max} {buLangTranslate.preDef.Length}";
      dataGridViewColumn3.ReadOnly = false;
      dataGridViewColumn3.DefaultCellStyle.Font = new Font("Arial", 10f, FontStyle.Bold);
      dataGridViewColumn3.CellTemplate = (DataGridViewCell) new DataGridViewTextBoxCell();
      ((F_AddFromFile) this).\u0002.Columns.Add(dataGridViewColumn3);
      DataGridViewColumn dataGridViewColumn4 = new DataGridViewColumn();
      dataGridViewColumn4.SortMode = DataGridViewColumnSortMode.NotSortable;
      dataGridViewColumn4.Width = 120;
      dataGridViewColumn2.HeaderText = buLangTranslate.preDef.Speed;
      dataGridViewColumn4.Name = buLangTranslate.preDef.Speed;
      dataGridViewColumn4.ReadOnly = false;
      dataGridViewColumn4.DefaultCellStyle.Font = new Font("Arial", 10f, FontStyle.Bold);
      dataGridViewColumn4.CellTemplate = (DataGridViewCell) new DataGridViewTextBoxCell();
      ((F_AddFromFile) this).\u0002.Columns.Add(dataGridViewColumn4);
    }
    if (((F_AddFromFile) this).\u0001.Columns.Count == 0)
    {
      DataGridViewColumn dataGridViewColumn5 = new DataGridViewColumn();
      dataGridViewColumn5.SortMode = DataGridViewColumnSortMode.NotSortable;
      dataGridViewColumn5.Width = 40;
      dataGridViewColumn5.HeaderText = buLangTranslate.preDef.No;
      dataGridViewColumn5.Name = buLangTranslate.preDef.No;
      dataGridViewColumn5.ReadOnly = true;
      dataGridViewColumn5.DefaultCellStyle.Font = new Font("Arial", 10f, FontStyle.Bold);
      dataGridViewColumn5.CellTemplate = (DataGridViewCell) new DataGridViewTextBoxCell();
      ((F_AddFromFile) this).\u0001.Columns.Add(dataGridViewColumn5);
      DataGridViewColumn dataGridViewColumn6 = new DataGridViewColumn();
      dataGridViewColumn6.SortMode = DataGridViewColumnSortMode.NotSortable;
      dataGridViewColumn6.Width = 120;
      dataGridViewColumn6.HeaderText = $"{buLangTranslate.preDef.Min} {buLangTranslate.preDef.Radius}";
      dataGridViewColumn6.Name = $"{buLangTranslate.preDef.Min} {buLangTranslate.preDef.Radius}";
      dataGridViewColumn6.ReadOnly = false;
      dataGridViewColumn6.DefaultCellStyle.Font = new Font("Arial", 10f, FontStyle.Bold);
      dataGridViewColumn6.CellTemplate = (DataGridViewCell) new DataGridViewTextBoxCell();
      ((F_AddFromFile) this).\u0001.Columns.Add(dataGridViewColumn6);
      DataGridViewColumn dataGridViewColumn7 = new DataGridViewColumn();
      dataGridViewColumn7.SortMode = DataGridViewColumnSortMode.NotSortable;
      dataGridViewColumn7.Width = 120;
      dataGridViewColumn6.HeaderText = $"{buLangTranslate.preDef.Max} {buLangTranslate.preDef.Radius}";
      dataGridViewColumn7.Name = $"{buLangTranslate.preDef.Max} {buLangTranslate.preDef.Radius}";
      dataGridViewColumn7.ReadOnly = false;
      dataGridViewColumn7.DefaultCellStyle.Font = new Font("Arial", 10f, FontStyle.Bold);
      dataGridViewColumn7.CellTemplate = (DataGridViewCell) new DataGridViewTextBoxCell();
      ((F_AddFromFile) this).\u0001.Columns.Add(dataGridViewColumn7);
      DataGridViewColumn dataGridViewColumn8 = new DataGridViewColumn();
      dataGridViewColumn8.SortMode = DataGridViewColumnSortMode.NotSortable;
      dataGridViewColumn8.Width = 120;
      dataGridViewColumn6.HeaderText = buLangTranslate.preDef.Speed;
      dataGridViewColumn8.Name = buLangTranslate.preDef.Speed;
      dataGridViewColumn8.ReadOnly = false;
      dataGridViewColumn8.DefaultCellStyle.Font = new Font("Arial", 10f, FontStyle.Bold);
      dataGridViewColumn8.CellTemplate = (DataGridViewCell) new DataGridViewTextBoxCell();
      ((F_AddFromFile) this).\u0001.Columns.Add(dataGridViewColumn8);
    }
    for (int index = 0; index <= ((F_AddFromFile) this).RadiusFeedList.Count - 1; ++index)
    {
      DataGridViewRowCollection rows = ((F_AddFromFile) this).\u0001.Rows;
      double minRadius = ((ToolBase5) ((F_AddFromFile) this).RadiusFeedList[index]).MinRadius;
      double maxRadius = ((ToolBase5) ((F_AddFromFile) this).RadiusFeedList[index]).MaxRadius;
      double feed = ((ToolBase5) ((F_AddFromFile) this).RadiusFeedList[index]).Feed;
      object[] objArray = \u007B0e48b843\u002Dfb72\u002D498c\u002D834d\u002Dfc743ba0facc\u007D.\u0001(index + 1, minRadius, (F_FoamSpeedList) this, maxRadius, feed);
      rows.Add(objArray);
    }
    for (int index = 0; index <= ((F_AddFromFile) this).LengthFeedList.Count - 1; ++index)
    {
      DataGridViewRowCollection rows = ((F_AddFromFile) this).\u0002.Rows;
      double minLength = ((ToolBase5) ((F_AddFromFile) this).LengthFeedList[index]).MinLength;
      double maxLength = ((ToolBase5) ((F_AddFromFile) this).LengthFeedList[index]).MaxLength;
      double feed = ((ToolBase5) ((F_AddFromFile) this).LengthFeedList[index]).Feed;
      object[] objArray = \u0007.\u0001.\u0001(minLength, feed, maxLength, index + 1, (F_FoamSpeedList) this);
      rows.Add(objArray);
    }
    ((F_AddFromFile) this).\u0002.RowHeadersVisible = false;
    ((F_AddFromFile) this).\u0002.AllowUserToAddRows = false;
    ((F_AddFromFile) this).\u0002.AllowUserToResizeColumns = false;
    ((F_AddFromFile) this).\u0001.RowHeadersVisible = false;
    ((F_AddFromFile) this).\u0001.AllowUserToAddRows = false;
    ((F_AddFromFile) this).\u0001.AllowUserToResizeColumns = false;
    ((F_AddFromFile) this).PropertiesForm.Result = DialogResult.None;
    ((F_AddFromFile) this).PropertiesForm.Inited = true;
  }

  public void LoadLanguage()
  {
    string callMethod = nameof (LoadLanguage);
    try
    {
      if (F_AddFromFile.Captions.Count >= 9)
        ;
    }
    catch (Exception ex)
    {
      string str = "";
      buLog.addLog(str, "Not Ok", callMethod);
      buException.throwException(ex, callMethod, true, str);
    }
  }

  public void ControlUpdate()
  {
  }

  public void Apply()
  {
    ((F_AddFromFile) this).RadiusFeedList.Clear();
    ((F_AddFromFile) this).LengthFeedList.Clear();
    for (int index = 0; index <= ((F_AddFromFile) this).\u0001.Rows.Count - 1; ++index)
    {
      camRadiusFeed camRadiusFeed = (camRadiusFeed) new RegenResolutionData();
      ((ToolBase5) camRadiusFeed).MinRadius = Convert.ToDouble(((F_AddFromFile) this).\u0001.Rows[index].Cells[0].Value);
      ((ToolBase5) camRadiusFeed).MaxRadius = Convert.ToDouble(((F_AddFromFile) this).\u0001.Rows[index].Cells[1].Value);
      ((ToolBase5) camRadiusFeed).Feed = Convert.ToDouble(((F_AddFromFile) this).\u0001.Rows[index].Cells[2].Value);
      ((F_AddFromFile) this).RadiusFeedList.Add(camRadiusFeed);
    }
    for (int index = 0; index <= ((F_AddFromFile) this).\u0002.Rows.Count - 1; ++index)
    {
      camLengthFeed camLengthFeed = (camLengthFeed) new Pnt6DList();
      ((ToolBase5) camLengthFeed).MinLength = Convert.ToDouble(((F_AddFromFile) this).\u0002.Rows[index].Cells[0].Value);
      ((ToolBase5) camLengthFeed).MaxLength = Convert.ToDouble(((F_AddFromFile) this).\u0002.Rows[index].Cells[1].Value);
      ((ToolBase5) camLengthFeed).Feed = Convert.ToDouble(((F_AddFromFile) this).\u0002.Rows[index].Cells[2].Value);
      ((F_AddFromFile) this).LengthFeedList.Add(camLengthFeed);
    }
  }

  internal void \u0001([In] object obj0, [In] DataGridViewCellEventArgs obj1)
  {
    if (!(obj1.RowIndex >= 0 & obj1.RowIndex <= ((F_AddFromFile) this).\u0001.Rows.Count - 1))
      return;
    ((F_AddFromFile) this).SelectedRadiusRowSheet = obj1.RowIndex;
  }

  internal void \u0002([In] object obj0, [In] DataGridViewCellEventArgs obj1)
  {
    if (!(obj1.RowIndex >= 0 & obj1.RowIndex <= ((F_AddFromFile) this).\u0002.Rows.Count - 1))
      return;
    ((F_AddFromFile) this).SelectedLengthRowSheet = obj1.RowIndex;
  }
}
