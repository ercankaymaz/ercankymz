// Decompiled with JetBrains decompiler
// Type: buMarble.Forms.F_MarbleInfoList
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

public class F_MarbleInfoList : Form
{
  public buButton btn_aplus;
  public buButton btn_zminus;
  public buButton btn_aminus;
  public buButton btn_zplus;
  public buButton btn_cminus;
  public buButton btn_cplus;
  public buButton btn_stop;
  public buLabel lbl_Aposition;
  public buLabel lbl_Cpositions;
  public buButton btn_A46;

  public void Apply()
  {
  }

  internal void \u0001([In] object obj0, [In] EventArgs obj1)
  {
    try
    {
      if (!((obj0 as Control).Name == ((F_MarbleJogs) this).btn_close.Name))
        return;
      ((F_MarbleJogs) this).PropertiesForm.Result = DialogResult.Cancel;
      if (((F_MarbleJogs) this).PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
        this.Dispose();
      if (((F_MarbleJogs) this).PropertiesForm.FormCloseMode != FormCloseModeType.Invisible)
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

  internal void \u0002([In] object obj0, [In] EventArgs obj1)
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

  protected override void Dispose(bool disposing)
  {
    if ((!disposing ? 0 : (((F_MarbleJogs) this).\u0001 != null ? 1 : 0)) != 0)
      ((F_MarbleJogs) this).\u0001.Dispose();
    base.Dispose(disposing);
  }

  static F_MarbleInfoList() => F_MarbleJogs.Captions = new List<string>();

  public F_MarbleInfoList()
  {
    ((F_MarbleMotorWarmUp) this).PropertiesForm = new FormProperties();
    ((F_MarbleMotorWarmUp) this).InfoList = new List<InfoType>();
    ((F_MarbleMotorWarmUp) this).\u0001 = (IContainer) null;
    // ISSUE: explicit constructor call
    base.\u002Ector();
    \u0005.\u0003.\u0001(this);
  }

  public void Init(List<InfoType> infoList)
  {
    ((F_MarbleMotorWarmUp) this).PropertiesForm.Inited = false;
    if (((F_MarbleMotorWarmUp) this).PropertiesForm.Height > 10)
      this.Height = ((F_MarbleMotorWarmUp) this).PropertiesForm.Height;
    if (((F_MarbleMotorWarmUp) this).PropertiesForm.Width > 10)
      this.Width = ((F_MarbleMotorWarmUp) this).PropertiesForm.Width;
    this.TopMost = ((F_MarbleMotorWarmUp) this).PropertiesForm.TopMost;
    this.StartPosition = ((F_MarbleMotorWarmUp) this).PropertiesForm.FormPosition;
    ((F_MarbleMotorWarmUp) this).InfoList.Clear();
    if ((infoList == null ? 0 : (infoList.Count > 0 ? 1 : 0)) != 0)
      InfoType.Copy(infoList, ref ((F_MarbleMotorWarmUp) this).InfoList);
    if (((F_MarbleMotorWarmUp) this).\u0001.Columns.Count == 0)
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
      ((F_MarbleMotorWarmUp) this).\u0001.Columns.Add(dataGridViewColumn1);
      DataGridViewColumn dataGridViewColumn2 = new DataGridViewColumn();
      dataGridViewColumn2.SortMode = DataGridViewColumnSortMode.NotSortable;
      dataGridViewColumn2.Width = 60;
      dataGridViewColumn2.HeaderText = buLangTranslate.preDef.Image;
      dataGridViewColumn2.Name = "Image";
      dataGridViewColumn2.ReadOnly = true;
      dataGridViewColumn2.DefaultCellStyle.Font = new Font("Arial", 10f, FontStyle.Bold);
      dataGridViewColumn2.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
      dataGridViewColumn2.CellTemplate = (DataGridViewCell) new DataGridViewImageCell();
      dataGridViewColumn2.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
      ((F_MarbleMotorWarmUp) this).\u0001.Columns.Add(dataGridViewColumn2);
      DataGridViewColumn dataGridViewColumn3 = new DataGridViewColumn();
      dataGridViewColumn3.SortMode = DataGridViewColumnSortMode.NotSortable;
      dataGridViewColumn3.Width = 680;
      dataGridViewColumn3.HeaderText = buLangTranslate.preDef.Explanation;
      dataGridViewColumn3.Name = "Name";
      dataGridViewColumn3.ReadOnly = false;
      dataGridViewColumn3.DefaultCellStyle.Font = new Font("Arial", 10f, FontStyle.Bold);
      dataGridViewColumn3.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
      dataGridViewColumn3.CellTemplate = (DataGridViewCell) new DataGridViewTextBoxCell();
      dataGridViewColumn3.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
      ((F_MarbleMotorWarmUp) this).\u0001.Columns.Add(dataGridViewColumn3);
    }
    ((F_MarbleMotorWarmUp) this).\u0001.RowHeadersVisible = false;
    ((F_MarbleMotorWarmUp) this).\u0001.AllowUserToAddRows = false;
    ((F_MarbleMotorWarmUp) this).\u0001.AllowUserToResizeColumns = false;
    ((F_MarbleMotorWarmUp) this).\u0001.ColumnHeadersVisible = false;
    ((F_MarbleMotorWarmUp) this).FillInfo();
    ((F_MarbleMotorWarmUp) this).PropertiesForm.Result = DialogResult.None;
    ((F_MarbleMotorWarmUp) this).PropertiesForm.Inited = true;
    \u0005.\u0003.\u0001(this);
  }

  internal void \u0001([In] object obj0, [In] FormClosingEventArgs obj1)
  {
    if (((F_MarbleMotorWarmUp) this).PropertiesForm.Result == DialogResult.OK)
      return;
    obj1.Cancel = true;
    ((F_MarbleMotorWarmUp) this).PropertiesForm.Result = DialogResult.Cancel;
    if (((F_MarbleMotorWarmUp) this).PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
      this.Dispose();
    if (((F_MarbleMotorWarmUp) this).PropertiesForm.FormCloseMode != FormCloseModeType.Invisible)
      return;
    this.Visible = false;
  }

  public void Apply()
  {
  }
}
