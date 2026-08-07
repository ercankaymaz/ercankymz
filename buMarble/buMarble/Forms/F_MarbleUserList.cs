// Decompiled with JetBrains decompiler
// Type: buMarble.Forms.F_MarbleUserList
// Assembly: buMarble, Version=5.1.1.2, Culture=neutral, PublicKeyToken=null
// MVID: D6F2AAC2-9013-4D8E-A4D2-15511BAB107F
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buMarble.dll

using buClass;
using buControls.Controls;
using buControls.Forms.buControlForms.KeyPad;
using buEyeBaseVer5;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

#nullable disable
namespace buMarble.Forms;

public class F_MarbleUserList : Form
{
  public ToolBase5 Tool;
  private IContainer \u0001;
  public buButton btn_close;
  public buGround buGround1;
  public buButton btn_ok;
  public buButton btn_cancel;
  internal buLabel \u0001;
  internal buLabel \u0002;
  internal buLabel \u0003;
  public buSpin spn_toolsocket;
  public buSpin spn_toolthickness;
  public buSpin spn_tooldia;
  internal buTextBox \u0001;

  public void spn_Leave(object sender, EventArgs e)
  {
  }

  internal void \u0002([In] object obj0, [In] EventArgs obj1)
  {
    if (!((F_MarbleToolSawTypes) this).PropertiesForm.Inited)
      return;
    buSpin buSpin = obj0 as buSpin;
    buSpin.Display.BackColor = buEyeVars.parVisual.colorDataFocus;
    buSpin.SelectAll();
  }

  internal void \u0003([In] object obj0, [In] EventArgs obj1)
  {
    buSpin buSpin = obj0 as buSpin;
    if (!AppBool.TouchPad)
      return;
    F_KeyPadNumV1 fKeyPadNumV1 = new F_KeyPadNumV1();
    fKeyPadNumV1.StartPosition = FormStartPosition.CenterParent;
    fKeyPadNumV1.Caption = buSpin.Caption.Caption;
    fKeyPadNumV1.ShowDialog(buSpin.Value.ToString());
    if (!buNumeric5.IsNumeric(fKeyPadNumV1.Value))
      return;
    buSpin.Value = double.Parse(fKeyPadNumV1.Value);
  }

  internal void \u0001([In] object obj0, [In] double obj1)
  {
    try
    {
      if (!((F_MarbleToolSawTypes) this).PropertiesForm.Inited)
        return;
      ((F_MarbleToolSawTypes) this).Apply();
    }
    catch (Exception ex)
    {
    }
  }

  protected override void Dispose(bool disposing)
  {
    if ((!disposing ? 0 : (this.\u0001 != null ? 1 : 0)) != 0)
      this.\u0001.Dispose();
    base.Dispose(disposing);
  }

  static F_MarbleUserList() => F_MarbleToolSawTypes.Captions = new List<string>();

  public F_MarbleUserList()
  {
    ((F_MarbleMDIV1) this).PropertiesForm = new FormProperties();
    ((F_MarbleMDIV1) this).UserList = new List<UserLoginInfo>();
    ((F_MarbleMDIV1) this).SelectedRow = -1;
    ((F_MarbleMDIV1) this).\u0001 = (IContainer) null;
    // ISSUE: explicit constructor call
    base.\u002Ector();
    \u0005.\u0003.\u0001(this);
  }

  public void Init(List<UserLoginInfo> infoList)
  {
    ((F_MarbleMDIV1) this).PropertiesForm.Inited = false;
    if (((F_MarbleMDIV1) this).PropertiesForm.Height > 10)
      this.Height = ((F_MarbleMDIV1) this).PropertiesForm.Height;
    if (((F_MarbleMDIV1) this).PropertiesForm.Width > 10)
      this.Width = ((F_MarbleMDIV1) this).PropertiesForm.Width;
    this.TopMost = ((F_MarbleMDIV1) this).PropertiesForm.TopMost;
    this.StartPosition = ((F_MarbleMDIV1) this).PropertiesForm.FormPosition;
    ((F_MarbleMDIV1) this).UserList.Clear();
    if ((infoList == null ? 0 : (infoList.Count > 0 ? 1 : 0)) != 0)
    {
      for (int index = 0; index <= infoList.Count - 1; ++index)
        ((F_MarbleMDIV1) this).UserList.Add(new UserLoginInfo(infoList[index]));
    }
    if (((F_MarbleMDIV1) this).\u0001.Columns.Count == 0)
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
      ((F_MarbleMDIV1) this).\u0001.Columns.Add(dataGridViewColumn1);
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
      ((F_MarbleMDIV1) this).\u0001.Columns.Add(dataGridViewColumn2);
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
      ((F_MarbleMDIV1) this).\u0001.Columns.Add(dataGridViewColumn3);
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
      ((F_MarbleMDIV1) this).\u0001.Columns.Add(dataGridViewColumn4);
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
      ((F_MarbleMDIV1) this).\u0001.Columns.Add(dataGridViewColumn5);
    }
    ((F_MarbleMDIV1) this).\u0001.RowHeadersVisible = false;
    ((F_MarbleMDIV1) this).\u0001.AllowUserToAddRows = false;
    ((F_MarbleMDIV1) this).\u0001.AllowUserToResizeColumns = false;
    ((F_MarbleMDIV1) this).\u0001.ColumnHeadersVisible = true;
    ((F_MarbleMDIV1) this).FillInfo();
    ((F_MarbleMDIV1) this).PropertiesForm.Result = DialogResult.None;
    ((F_MarbleMDIV1) this).PropertiesForm.Inited = true;
    \u0005.\u0003.\u0001(this);
  }

  internal void \u0001([In] object obj0, [In] FormClosingEventArgs obj1)
  {
    if (((F_MarbleMDIV1) this).PropertiesForm.Result == DialogResult.OK)
      return;
    obj1.Cancel = true;
    ((F_MarbleMDIV1) this).PropertiesForm.Result = DialogResult.Cancel;
    if (((F_MarbleMDIV1) this).PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
      this.Dispose();
    if (((F_MarbleMDIV1) this).PropertiesForm.FormCloseMode != FormCloseModeType.Invisible)
      return;
    this.Visible = false;
  }

  public void Apply()
  {
    try
    {
      ((F_MarbleMDIV1) this).UserList.Clear();
      for (int index = 0; index <= ((F_MarbleMDIV1) this).\u0001.Rows.Count - 1; ++index)
        ((F_MarbleMDIV1) this).UserList.Add(new UserLoginInfo()
        {
          UserName = ((F_MarbleMDIV1) this).\u0001.Rows[index].Cells[1].Value.ToString(),
          UserID = int.Parse(((F_MarbleMDIV1) this).\u0001.Rows[index].Cells[2].Value.ToString()),
          UserPassword = int.Parse(((F_MarbleMDIV1) this).\u0001.Rows[index].Cells[3].Value.ToString()),
          UserLevel = int.Parse(((F_MarbleMDIV1) this).\u0001.Rows[index].Cells[4].Value.ToString())
        });
    }
    catch (Exception ex)
    {
    }
  }
}
