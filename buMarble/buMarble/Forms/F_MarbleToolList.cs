// Decompiled with JetBrains decompiler
// Type: buMarble.Forms.F_MarbleToolList
// Assembly: buMarble, Version=5.1.1.2, Culture=neutral, PublicKeyToken=null
// MVID: D6F2AAC2-9013-4D8E-A4D2-15511BAB107F
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buMarble.dll

using buClass;
using buControls.Controls;
using buEyeBaseVer5;
using buEyeBaseVer5.Apps.Marble;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

#nullable disable
namespace buMarble.Forms;

public class F_MarbleToolList : Form
{
  public buButton btn_cancel;
  internal buLabel \u0001;
  internal buLabel \u0002;
  internal buLabel \u0003;
  public buButton btn_remove;
  public buButton btn_add;
  public buButton btn_edit;
  internal ImageList \u0001;
  public Panel pnl_preview;
  public buButton btn_toolsave;
  public buButton btn_toolopen;
  public buButton btn_millingtool;
  public buButton btn_sawtool;
  public buTab buTab_tools;
  public TabPage tabPage_mlling;
  internal DataGridView \u0001;
  internal TabPage \u0001;
  internal DataGridView \u0002;
  public buButton btn_millinghead;
  internal TabPage \u0002;

  public void MenuButtonColors(MarbleToolType PageIndex)
  {
    // ISSUE: unable to decompile the method.
  }

  internal void \u0001([In] object obj0, [In] EventArgs obj1)
  {
    // ISSUE: unable to decompile the method.
  }

  public void spn_Leave(object sender, EventArgs e)
  {
  }

  internal void \u0001([In] object obj0, [In] DataGridViewCellEventArgs obj1)
  {
    // ISSUE: unable to decompile the method.
  }

  protected override void Dispose(bool disposing)
  {
    if ((!disposing ? 0 : (((F_MarbleToolListTab) this).\u0001 != null ? 1 : 0)) != 0)
      ((F_MarbleToolListTab) this).\u0001.Dispose();
    base.Dispose(disposing);
  }

  static F_MarbleToolList() => F_MarbleToolListTab.Captions = new List<string>();

  public F_MarbleToolList()
  {
    ((F_MarbleToolCurrentAll) this).PropertiesForm = new FormProperties();
    ((F_MarbleToolCurrentAll) this).Tools = new List<ToolBase5>();
    ((F_MarbleToolCurrentAll) this).indexTool = -1;
    ((F_MarbleToolCurrentAll) this).\u0001 = (IContainer) null;
    // ISSUE: explicit constructor call
    base.\u002Ector();
    \u0005.\u0003.\u0001(this);
  }

  public void Init()
  {
    ((F_MarbleToolCurrentAll) this).PropertiesForm.Inited = false;
    if (((F_MarbleToolCurrentAll) this).PropertiesForm.Height > 10)
      this.Height = ((F_MarbleToolCurrentAll) this).PropertiesForm.Height;
    if (((F_MarbleToolCurrentAll) this).PropertiesForm.Width > 10)
      this.Width = ((F_MarbleToolCurrentAll) this).PropertiesForm.Width;
    this.TopMost = ((F_MarbleToolCurrentAll) this).PropertiesForm.TopMost;
    this.StartPosition = ((F_MarbleToolCurrentAll) this).PropertiesForm.FormPosition;
    if (((F_MarbleToolCurrentAll) this).\u0001.Columns.Count == 0)
    {
      DataGridViewColumn dataGridViewColumn1 = new DataGridViewColumn();
      dataGridViewColumn1.SortMode = DataGridViewColumnSortMode.NotSortable;
      dataGridViewColumn1.Width = 30;
      dataGridViewColumn1.HeaderText = buLangTranslate.preDef.No;
      dataGridViewColumn1.Name = "No";
      dataGridViewColumn1.ReadOnly = true;
      dataGridViewColumn1.DefaultCellStyle.Font = new Font("Arial", 10f, FontStyle.Bold);
      dataGridViewColumn1.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
      dataGridViewColumn1.CellTemplate = (DataGridViewCell) new DataGridViewTextBoxCell();
      ((F_MarbleToolCurrentAll) this).\u0001.Columns.Add(dataGridViewColumn1);
      DataGridViewColumn dataGridViewColumn2 = new DataGridViewColumn();
      dataGridViewColumn2.SortMode = DataGridViewColumnSortMode.NotSortable;
      dataGridViewColumn2.Width = 60;
      dataGridViewColumn2.HeaderText = buLangTranslate.preDef.Image;
      dataGridViewColumn2.Name = "Image";
      dataGridViewColumn2.ReadOnly = true;
      dataGridViewColumn2.DefaultCellStyle.Font = new Font("Arial", 10f, FontStyle.Bold);
      dataGridViewColumn2.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
      dataGridViewColumn2.CellTemplate = (DataGridViewCell) new DataGridViewImageCell();
      ((F_MarbleToolCurrentAll) this).\u0001.Columns.Add(dataGridViewColumn2);
      DataGridViewColumn dataGridViewColumn3 = new DataGridViewColumn();
      dataGridViewColumn3.SortMode = DataGridViewColumnSortMode.NotSortable;
      dataGridViewColumn3.Width = 120;
      dataGridViewColumn3.HeaderText = buLangTranslate.preDef.Type;
      dataGridViewColumn3.Name = "Type";
      dataGridViewColumn3.ReadOnly = false;
      dataGridViewColumn3.DefaultCellStyle.Font = new Font("Arial", 10f, FontStyle.Bold);
      dataGridViewColumn2.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
      dataGridViewColumn3.CellTemplate = (DataGridViewCell) new DataGridViewTextBoxCell();
      ((F_MarbleToolCurrentAll) this).\u0001.Columns.Add(dataGridViewColumn3);
      DataGridViewColumn dataGridViewColumn4 = new DataGridViewColumn();
      dataGridViewColumn4.SortMode = DataGridViewColumnSortMode.NotSortable;
      dataGridViewColumn4.Width = 240 /*0xF0*/;
      dataGridViewColumn4.HeaderText = buLangTranslate.preDef.Explanation;
      dataGridViewColumn4.Name = "Name";
      dataGridViewColumn4.ReadOnly = false;
      dataGridViewColumn4.DefaultCellStyle.Font = new Font("Arial", 10f, FontStyle.Bold);
      dataGridViewColumn4.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
      dataGridViewColumn4.CellTemplate = (DataGridViewCell) new DataGridViewTextBoxCell();
      ((F_MarbleToolCurrentAll) this).\u0001.Columns.Add(dataGridViewColumn4);
      DataGridViewColumn dataGridViewColumn5 = new DataGridViewColumn();
      dataGridViewColumn5.SortMode = DataGridViewColumnSortMode.NotSortable;
      dataGridViewColumn5.Width = 80 /*0x50*/;
      dataGridViewColumn5.HeaderText = buLangTranslate.preDef.Diameter;
      dataGridViewColumn5.Name = "Diameter";
      dataGridViewColumn5.ReadOnly = false;
      dataGridViewColumn5.DefaultCellStyle.Font = new Font("Arial", 10f, FontStyle.Bold);
      dataGridViewColumn5.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
      dataGridViewColumn5.CellTemplate = (DataGridViewCell) new DataGridViewTextBoxCell();
      ((F_MarbleToolCurrentAll) this).\u0001.Columns.Add(dataGridViewColumn5);
      DataGridViewColumn dataGridViewColumn6 = new DataGridViewColumn();
      dataGridViewColumn6.SortMode = DataGridViewColumnSortMode.NotSortable;
      dataGridViewColumn6.Width = 80 /*0x50*/;
      dataGridViewColumn6.HeaderText = buLangTranslate.preDef.Length;
      dataGridViewColumn6.Name = "Width";
      dataGridViewColumn6.ReadOnly = false;
      dataGridViewColumn6.DefaultCellStyle.Font = new Font("Arial", 10f, FontStyle.Bold);
      dataGridViewColumn6.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
      dataGridViewColumn6.CellTemplate = (DataGridViewCell) new DataGridViewTextBoxCell();
      ((F_MarbleToolCurrentAll) this).\u0001.Columns.Add(dataGridViewColumn6);
      DataGridViewColumn dataGridViewColumn7 = new DataGridViewColumn();
      dataGridViewColumn7.SortMode = DataGridViewColumnSortMode.NotSortable;
      dataGridViewColumn7.Width = 80 /*0x50*/;
      dataGridViewColumn7.HeaderText = buLangTranslate.preDef.Thickness;
      dataGridViewColumn7.Name = "Thickness";
      dataGridViewColumn7.ReadOnly = false;
      dataGridViewColumn7.DefaultCellStyle.Font = new Font("Arial", 10f, FontStyle.Bold);
      dataGridViewColumn7.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
      dataGridViewColumn7.CellTemplate = (DataGridViewCell) new DataGridViewTextBoxCell();
      ((F_MarbleToolCurrentAll) this).\u0001.Columns.Add(dataGridViewColumn7);
      DataGridViewColumn dataGridViewColumn8 = new DataGridViewColumn();
      dataGridViewColumn8.SortMode = DataGridViewColumnSortMode.NotSortable;
      dataGridViewColumn8.Width = 80 /*0x50*/;
      dataGridViewColumn8.HeaderText = buLangTranslate.preDef.Speed;
      dataGridViewColumn8.Name = "Speed";
      dataGridViewColumn8.ReadOnly = false;
      dataGridViewColumn8.DefaultCellStyle.Font = new Font("Arial", 10f, FontStyle.Bold);
      dataGridViewColumn8.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
      dataGridViewColumn8.CellTemplate = (DataGridViewCell) new DataGridViewTextBoxCell();
      ((F_MarbleToolCurrentAll) this).\u0001.Columns.Add(dataGridViewColumn7);
    }
    ((F_MarbleToolCurrentAll) this).\u0001.RowHeadersVisible = false;
    ((F_MarbleToolCurrentAll) this).\u0001.AllowUserToAddRows = false;
    ((F_MarbleToolCurrentAll) this).\u0001.AllowUserToResizeColumns = false;
    ((F_MarbleToolCurrentAll) this).\u0001.ColumnHeadersVisible = false;
    ((F_MarbleToolCurrentAll) this).FillTools();
    ((F_MarbleToolCurrentAll) this).indexTool = -1;
    if (((F_MarbleToolCurrentAll) this).Tools.Count > 0)
      ((F_MarbleToolCurrentAll) this).indexTool = 0;
    if (((F_MarbleToolCurrentAll) this).indexTool >= 0)
    {
      clsAppMarbleVars.cmdMarble.DrawTool(((F_MarbleToolCurrentAll) this).Tools[((F_MarbleToolCurrentAll) this).indexTool]);
      ((F_MarbleToolCurrentAll) this).\u0002.Text = clsAppMarbleVars.cmdMarble.ToolInfo(((F_MarbleToolCurrentAll) this).Tools[((F_MarbleToolCurrentAll) this).indexTool]);
    }
    ((F_MarbleToolCurrentAll) this).PropertiesForm.Result = DialogResult.None;
    ((F_MarbleToolCurrentAll) this).PropertiesForm.Inited = true;
    \u0005.\u0003.\u0001(this);
  }

  internal void \u0001([In] object obj0, [In] FormClosingEventArgs obj1)
  {
    if (((F_MarbleToolCurrentAll) this).PropertiesForm.Result == DialogResult.OK)
      return;
    obj1.Cancel = true;
    ((F_MarbleToolCurrentAll) this).PropertiesForm.Result = DialogResult.Cancel;
    if (((F_MarbleToolCurrentAll) this).PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
      this.Dispose();
    if (((F_MarbleToolCurrentAll) this).PropertiesForm.FormCloseMode != FormCloseModeType.Invisible)
      return;
    this.Visible = false;
  }

  public void Apply()
  {
  }
}
