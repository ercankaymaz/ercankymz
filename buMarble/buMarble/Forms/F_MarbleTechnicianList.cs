// Decompiled with JetBrains decompiler
// Type: buMarble.Forms.F_MarbleTechnicianList
// Assembly: buMarble, Version=5.1.1.2, Culture=neutral, PublicKeyToken=null
// MVID: D6F2AAC2-9013-4D8E-A4D2-15511BAB107F
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buMarble.dll

using \u0005;
using buClass;
using buControls.Controls;
using buMotion;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

#nullable disable
namespace buMarble.Forms;

public class F_MarbleTechnicianList : Form
{
  public buButton btn_vacuumopen;
  public buButton btn_vacuumup;
  public buButton btn_vacuumdown;
  public buLabel lblvacum;
  public Panel pnl_command;
  public Panel pnl_position;
  public Panel pnl_tools;
  public Panel pnl_photo;
  public Panel pnl_vacuum;
  public buButton btn_cameraenable;
  public buButton btn_cameradisable;
  public static byte f00039F;
  public static List<string> Captions;
  public FormProperties PropertiesForm = new FormProperties();
  public List<TechnicianLoginInfo> UserList = new List<TechnicianLoginInfo>();
  public int SelectedRow = -1;
  internal IContainer \u0001 = (IContainer) null;

  internal void \u0001([In] object obj0, [In] FormClosingEventArgs obj1)
  {
    if (((F_MarbleMDIV2) this).PropertiesForm.Result == DialogResult.OK)
      return;
    obj1.Cancel = true;
    ((F_MarbleMDIV2) this).PropertiesForm.Result = DialogResult.Cancel;
    if (((F_MarbleMDIV2) this).PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
      this.Dispose();
    if (((F_MarbleMDIV2) this).PropertiesForm.FormCloseMode != FormCloseModeType.Invisible)
      return;
    this.Visible = false;
  }

  public void Apply()
  {
  }

  internal void \u0001([In] object obj0, [In] EventArgs obj1)
  {
    try
    {
      if (!((obj0 as Control).Name == ((F_MarbleMDIV2) this).btn_close.Name))
        return;
      ((F_MarbleMDIV2) this).PropertiesForm.Result = DialogResult.Cancel;
      if (((F_MarbleMDIV2) this).PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
        this.Dispose();
      if (((F_MarbleMDIV2) this).PropertiesForm.FormCloseMode != FormCloseModeType.Invisible)
        return;
      this.Visible = false;
    }
    catch (Exception ex)
    {
    }
  }

  public void spn_Leave(object sender, EventArgs e)
  {
  }

  protected override void Dispose(bool disposing)
  {
    if ((!disposing ? 0 : (((F_MarbleMDIV2) this).\u0001 != null ? 1 : 0)) != 0)
      ((F_MarbleMDIV2) this).\u0001.Dispose();
    base.Dispose(disposing);
  }

  static F_MarbleTechnicianList() => F_MarbleMDIV2.Captions = new List<string>();

  public F_MarbleTechnicianList() => \u0003.\u0001(this);

  public void Init(List<TechnicianLoginInfo> infoList)
  {
    this.PropertiesForm.Inited = false;
    if (this.PropertiesForm.Height > 10)
      this.Height = this.PropertiesForm.Height;
    if (this.PropertiesForm.Width > 10)
      this.Width = this.PropertiesForm.Width;
    this.TopMost = this.PropertiesForm.TopMost;
    this.StartPosition = this.PropertiesForm.FormPosition;
    this.UserList.Clear();
    if ((infoList == null ? 0 : (infoList.Count > 0 ? 1 : 0)) != 0)
    {
      for (int index = 0; index <= infoList.Count - 1; ++index)
        this.UserList.Add(new TechnicianLoginInfo(infoList[index]));
    }
    if (((F_MarbleToolCurrentAllV2) this).\u0001.Columns.Count == 0)
    {
      DataGridViewColumn dataGridViewColumn1 = new DataGridViewColumn();
      dataGridViewColumn1.SortMode = DataGridViewColumnSortMode.NotSortable;
      dataGridViewColumn1.Width = 35;
      dataGridViewColumn1.HeaderText = buLangTranslate.preDef.Number;
      dataGridViewColumn1.Name = "No";
      dataGridViewColumn1.ReadOnly = true;
      dataGridViewColumn1.DefaultCellStyle.Font = new Font("Arial", 10f, FontStyle.Bold);
      dataGridViewColumn1.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
      dataGridViewColumn1.CellTemplate = (DataGridViewCell) new DataGridViewTextBoxCell();
      dataGridViewColumn1.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
      ((F_MarbleToolCurrentAllV2) this).\u0001.Columns.Add(dataGridViewColumn1);
      DataGridViewColumn dataGridViewColumn2 = new DataGridViewColumn();
      dataGridViewColumn2.SortMode = DataGridViewColumnSortMode.NotSortable;
      dataGridViewColumn2.Width = 250;
      dataGridViewColumn2.HeaderText = buLangTranslate.preDef.Name;
      dataGridViewColumn2.Name = "Name";
      dataGridViewColumn2.ReadOnly = false;
      dataGridViewColumn2.DefaultCellStyle.Font = new Font("Arial", 10f, FontStyle.Bold);
      dataGridViewColumn2.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
      dataGridViewColumn2.CellTemplate = (DataGridViewCell) new DataGridViewTextBoxCell();
      dataGridViewColumn2.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
      ((F_MarbleToolCurrentAllV2) this).\u0001.Columns.Add(dataGridViewColumn2);
      DataGridViewColumn dataGridViewColumn3 = new DataGridViewColumn();
      dataGridViewColumn3.SortMode = DataGridViewColumnSortMode.NotSortable;
      dataGridViewColumn3.Width = 150;
      dataGridViewColumn3.HeaderText = buLangTranslate.preChar.ID;
      dataGridViewColumn3.Name = "ID";
      dataGridViewColumn3.ReadOnly = false;
      dataGridViewColumn3.DefaultCellStyle.Font = new Font("Arial", 10f, FontStyle.Bold);
      dataGridViewColumn3.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
      dataGridViewColumn3.CellTemplate = (DataGridViewCell) new DataGridViewTextBoxCell();
      dataGridViewColumn3.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
      ((F_MarbleToolCurrentAllV2) this).\u0001.Columns.Add(dataGridViewColumn3);
      DataGridViewColumn dataGridViewColumn4 = new DataGridViewColumn();
      dataGridViewColumn4.SortMode = DataGridViewColumnSortMode.NotSortable;
      dataGridViewColumn4.Width = 150;
      dataGridViewColumn4.HeaderText = buLangTranslate.preDef.Password;
      dataGridViewColumn4.Name = "Pasword";
      dataGridViewColumn4.ReadOnly = false;
      dataGridViewColumn4.DefaultCellStyle.Font = new Font("Arial", 10f, FontStyle.Bold);
      dataGridViewColumn4.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
      dataGridViewColumn4.CellTemplate = (DataGridViewCell) new DataGridViewTextBoxCell();
      dataGridViewColumn4.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
      ((F_MarbleToolCurrentAllV2) this).\u0001.Columns.Add(dataGridViewColumn4);
      DataGridViewColumn dataGridViewColumn5 = new DataGridViewColumn();
      dataGridViewColumn5.SortMode = DataGridViewColumnSortMode.NotSortable;
      dataGridViewColumn5.Width = 60;
      dataGridViewColumn5.HeaderText = buLangTranslate.preDef.Level;
      dataGridViewColumn5.Name = "Level";
      dataGridViewColumn5.ReadOnly = false;
      dataGridViewColumn5.DefaultCellStyle.Font = new Font("Arial", 10f, FontStyle.Bold);
      dataGridViewColumn5.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
      dataGridViewColumn5.CellTemplate = (DataGridViewCell) new DataGridViewTextBoxCell();
      dataGridViewColumn5.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
      ((F_MarbleToolCurrentAllV2) this).\u0001.Columns.Add(dataGridViewColumn5);
    }
    ((F_MarbleToolCurrentAllV2) this).\u0001.RowHeadersVisible = false;
    ((F_MarbleToolCurrentAllV2) this).\u0001.AllowUserToAddRows = false;
    ((F_MarbleToolCurrentAllV2) this).\u0001.AllowUserToResizeColumns = false;
    ((F_MarbleToolCurrentAllV2) this).\u0001.ColumnHeadersVisible = true;
    this.FillInfo();
    this.PropertiesForm.Result = DialogResult.None;
    this.PropertiesForm.Inited = true;
    \u0003.\u0001(this);
  }

  internal void \u0001([In] object obj0, [In] FormClosingEventArgs obj1)
  {
    if (this.PropertiesForm.Result == DialogResult.OK)
      return;
    obj1.Cancel = true;
    this.PropertiesForm.Result = DialogResult.Cancel;
    if (this.PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
      this.Dispose();
    if (this.PropertiesForm.FormCloseMode != FormCloseModeType.Invisible)
      return;
    this.Visible = false;
  }

  public void Apply()
  {
    try
    {
      for (int index = 0; index <= ((F_MarbleToolCurrentAllV2) this).\u0001.Rows.Count - 1; ++index)
      {
        if (index <= this.UserList.Count - 1)
        {
          UserLoginInfo userLoginInfo = new UserLoginInfo();
          this.UserList[index].TechName = ((F_MarbleToolCurrentAllV2) this).\u0001.Rows[index].Cells[1].Value.ToString();
          this.UserList[index].TechID = int.Parse(((F_MarbleToolCurrentAllV2) this).\u0001.Rows[index].Cells[2].Value.ToString());
          this.UserList[index].TechPassword = int.Parse(((F_MarbleToolCurrentAllV2) this).\u0001.Rows[index].Cells[3].Value.ToString());
          this.UserList[index].TechLevel = int.Parse(((F_MarbleToolCurrentAllV2) this).\u0001.Rows[index].Cells[4].Value.ToString());
        }
      }
    }
    catch (Exception ex)
    {
    }
  }

  public void FillInfo()
  {
    // ISSUE: unable to decompile the method.
  }
}
