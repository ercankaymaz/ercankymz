// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Forms.Marble.F_MarbleSawCutParameters
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using buControls.Controls;
using buEyeBaseVer5.Apps.Marble;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Windows.Forms;

#nullable disable
namespace buEyeBaseVer5.Forms.Marble;

public class F_MarbleSawCutParameters : Form
{
  public buLabel lbl_6;
  public buSpin spn_itemEA6;
  public buSpin spn_itemSA6;
  public buSpin spn_itemcount6;
  public buSpin spn_itemlen6;
  public Panel pnl_base;
  public buButton btn_itemclearall;
  public buSpin spn_angle;
  public buButton btn_save;
  internal buLabel \u0001;
  public TextBox txt_info;
  public Panel pnl_data;
  public buSpin spn_xoffset;
  public buSpin spn_yoffset;
  public buButton btn_itemstartpos;
  public buButton btn_itemendpos;
  public buButton btn_addtolist;
  public buCheckBox chk_horlefttop;
  public buCheckBox chk_horleftbottom;
  public Panel pnl_viewport;
  public buCheckBox chk_cutend;
  public buCheckBox chk_cutstart;
  public ImageList IC32;
  public buLabel lbl_EAimg1;
  public buLabel lbl_EAimg7;
  public buLabel lbl_SAimg7;

  public void LoadLanguage()
  {
    ((F_MarbleMilling5AxisMenu) this).lbl_count.Text = buLangTranslate.preDef.Count;
    ((F_MarbleMilling5AxisMenu) this).lbl_endangle.Text = buLangTranslate.preDef.EndAngle;
    ((F_MarbleMilling5AxisMenu) this).lbl_width.Text = buLangTranslate.preDef.Width;
    ((F_MarbleMilling5AxisMenu) this).lbl_startangle.Text = buLangTranslate.preDef.StartAngle;
    ((F_MarbleMilling5AxisMenu) this).btn_cancel.Text = buLangTranslate.preDef.Cancel;
    ((F_MarbleMilling5AxisMenu) this).btn_itemendpos.Text = buLangTranslate.preDef.EndPoint;
    ((F_MarbleMilling5AxisMenu) this).btn_itemok.Text = buLangTranslate.preDef.Ok;
    ((F_MarbleMilling5AxisMenu) this).btn_itemstartpos.Text = buLangTranslate.preDef.StartPoint;
    ((F_MarbleMilling5AxisMenu) this).spn_angle.Caption.Caption = buLangTranslate.preDef.Angle;
    ((F_MarbleMilling5AxisMenu) this).spn_length.Caption.Caption = buLangTranslate.preDef.Length;
    ((F_MarbleMilling5AxisMenu) this).chk_cutend.Text = $"{buLangTranslate.preDef.End} {buLangTranslate.preDef.Cutting}";
    ((F_MarbleMilling5AxisMenu) this).chk_cutstart.Text = $"{buLangTranslate.preDef.Start} {buLangTranslate.preDef.Cutting}";
    this.Text = $"{buLangTranslate.preDef.Horizontal} {buLangTranslate.preDef.Cutting}";
  }

  internal void \u0001([In] object obj0, [In] FormClosingEventArgs obj1)
  {
    if (((F_Marble5DCamStrategyMenu) this).Properties.Result == DialogResult.OK)
      return;
    obj1.Cancel = true;
    ((F_Marble5DCamStrategyMenu) this).Properties.Result = DialogResult.Cancel;
    if (((F_Marble5DCamStrategyMenu) this).Properties.FormCloseMode == FormCloseModeType.Dispose)
      this.Dispose();
    if (((F_Marble5DCamStrategyMenu) this).Properties.FormCloseMode != FormCloseModeType.Invisible)
      return;
    this.Visible = false;
  }

  internal void \u0001([In] object obj0, [In] EventArgs obj1)
  {
    try
    {
      Control control1 = new Control();
      Control control2 = (Control) obj0;
      if (!((F_Marble5DCamStrategyMenu) this).isDialog)
        return;
      if (control2.Name == ((F_MarbleMilling5AxisMenu) this).btn_itemok.Name)
      {
        ((F_Marble5DCamStrategyMenu) this).Properties.Result = DialogResult.OK;
        if (((F_Marble5DCamStrategyMenu) this).Properties.FormCloseMode == FormCloseModeType.Dispose)
          this.Dispose();
        if (((F_Marble5DCamStrategyMenu) this).Properties.FormCloseMode == FormCloseModeType.Invisible)
          this.Visible = false;
      }
      if (control2.Name == ((F_Marble5DCamStrategyMenu) this).btn_close.Name)
      {
        ((F_Marble5DCamStrategyMenu) this).Properties.Result = DialogResult.Cancel;
        if (((F_Marble5DCamStrategyMenu) this).Properties.FormCloseMode == FormCloseModeType.Dispose)
          this.Dispose();
        if (((F_Marble5DCamStrategyMenu) this).Properties.FormCloseMode == FormCloseModeType.Invisible)
          this.Visible = false;
      }
      if (control2.Name == ((F_Marble5DCamStrategyMenu) this).btn_maximize.Name)
        this.WindowState = FormWindowState.Maximized;
      if (!(control2.Name == ((F_Marble5DCamStrategyMenu) this).btn_minimise.Name))
        return;
      this.WindowState = FormWindowState.Normal;
    }
    catch (Exception ex)
    {
    }
  }

  internal void \u0001([In] object obj0, [In] DataGridViewCellEventArgs obj1)
  {
    Control control = obj0 as Control;
    if (control.Tag == null)
      return;
    if (control.Tag.ToString() == "Hor")
    {
      MarbleColorSettings.HorizontalItemSelectedRowIndex = obj1.RowIndex;
      MarbleColorSettings.HorizontalItemSelectedColIndex = obj1.ColumnIndex;
    }
    if (control.Tag.ToString() == "Ver")
    {
      MarbleColorSettings.VerticalItemSelectedRowIndex = obj1.RowIndex;
      MarbleColorSettings.VerticalItemSelectedColIndex = obj1.ColumnIndex;
    }
    if (control.Tag.ToString() == "HorVerHor")
    {
      MarbleColorSettings.HorVerHorizontalItemSelectedRowIndex = obj1.RowIndex;
      MarbleColorSettings.HorVerHorizontalItemSelectedColIndex = obj1.ColumnIndex;
    }
    if (!(control.Tag.ToString() == "HorVerVer"))
      return;
    MarbleColorSettings.HorVerVerticalItemSelectedRowIndex = obj1.RowIndex;
    MarbleColorSettings.HorVerVerticalItemSelectedColIndex = obj1.ColumnIndex;
  }

  internal void \u0002([In] object obj0, [In] DataGridViewCellEventArgs obj1)
  {
    if (!AppBool.TouchPad)
      return;
    string str = ((F_MarbleMilling5AxisMenu) this).DGV_items.Rows[obj1.RowIndex].Cells[obj1.ColumnIndex].Value.ToString();
    buCompare5.ShowKeyPad((Form) this, (Control) null, ref str, ((F_MarbleMilling5AxisMenu) this).DGV_items.Columns[obj1.ColumnIndex].HeaderText);
    ((F_MarbleMilling5AxisMenu) this).DGV_items.Rows[obj1.RowIndex].Cells[obj1.ColumnIndex].Value = (object) str;
    ((F_MarbleMilling5AxisMenu) this).DGV_items.Rows[obj1.RowIndex].Cells[obj1.ColumnIndex].DataGridView.EndEdit();
  }

  protected override void Dispose(bool disposing)
  {
    if ((!disposing ? 0 : (((F_Marble5DCamStrategyMenu) this).\u0001 != null ? 1 : 0)) != 0)
      ((F_Marble5DCamStrategyMenu) this).\u0001.Dispose();
    base.Dispose(disposing);
  }

  static F_MarbleSawCutParameters() => F_Marble5DCamStrategyMenu.Captions = new List<string>();

  public F_MarbleSawCutParameters()
  {
    ((F_MarbleMilling5AxisMenu) this).Properties = new FormProperties();
    ((F_MarbleMilling5AxisMenu) this).isHorizontal = false;
    ((F_MarbleMilling5AxisMenu) this).isDialog = false;
    ((F_MarbleMilling5AxisMenu) this).\u0001 = (IContainer) null;
    // ISSUE: explicit constructor call
    base.\u002Ector();
    \u0007.\u0001.\u0001((F_MarbleSingleCutV2) this);
  }

  public void Init()
  {
    ((F_MarbleMilling5AxisMenu) this).Properties.Inited = false;
    if (((F_MarbleMilling5AxisMenu) this).Properties.Height > 10)
      this.Height = ((F_MarbleMilling5AxisMenu) this).Properties.Height;
    if (((F_MarbleMilling5AxisMenu) this).Properties.Width > 10)
      this.Width = ((F_MarbleMilling5AxisMenu) this).Properties.Width;
    this.TopMost = ((F_MarbleMilling5AxisMenu) this).Properties.TopMost;
    this.StartPosition = ((F_MarbleMilling5AxisMenu) this).Properties.FormPosition;
    ((F_MarbleMilling5AxisMenu) this).Properties.Result = DialogResult.None;
    ((F_MarbleMilling5AxisMenu) this).Properties.Inited = true;
    this.LoadLanguage();
  }

  public void LoadLanguage()
  {
    ((F_MarbleToolSawMillingMillingHeadMenu) this).btn_cancel.Text = buLangTranslate.preDef.Cancel;
    ((F_MarbleToolSawMillingMillingHeadMenu) this).btn_itemsinglecutok.Text = buLangTranslate.preDef.Ok;
    ((F_MarbleToolSawMillingMillingHeadMenu) this).spn_signlecutAAngle.Caption.Caption = "A " + buLangTranslate.preDef.Angle;
    ((F_MarbleToolSawMillingMillingHeadMenu) this).spn_signlecutCAngle.Caption.Caption = "C " + buLangTranslate.preDef.Angle;
    ((F_MarbleToolSawMillingMillingHeadMenu) this).spn_signlecutlength.Caption.Caption = buLangTranslate.preDef.Length;
    this.Text = $"{buLangTranslate.preDef.Horizontal} {buLangTranslate.preDef.Cutting}";
  }

  internal void \u0001([In] object obj0, [In] FormClosingEventArgs obj1)
  {
    if (((F_MarbleMilling5AxisMenu) this).Properties.Result == DialogResult.OK)
      return;
    obj1.Cancel = true;
    ((F_MarbleMilling5AxisMenu) this).Properties.Result = DialogResult.Cancel;
    if (((F_MarbleMilling5AxisMenu) this).Properties.FormCloseMode == FormCloseModeType.Dispose)
      this.Dispose();
    if (((F_MarbleMilling5AxisMenu) this).Properties.FormCloseMode != FormCloseModeType.Invisible)
      return;
    this.Visible = false;
  }

  internal void \u0001([In] object obj0, [In] EventArgs obj1)
  {
    try
    {
      Control control1 = new Control();
      Control control2 = (Control) obj0;
      if (!((F_MarbleMilling5AxisMenu) this).isDialog)
        return;
      if (control2.Name == ((F_MarbleToolSawMillingMillingHeadMenu) this).btn_itemsinglecutok.Name)
      {
        ((F_MarbleMilling5AxisMenu) this).Properties.Result = DialogResult.OK;
        if (((F_MarbleMilling5AxisMenu) this).Properties.FormCloseMode == FormCloseModeType.Dispose)
          this.Dispose();
        if (((F_MarbleMilling5AxisMenu) this).Properties.FormCloseMode == FormCloseModeType.Invisible)
          this.Visible = false;
      }
      if (control2.Name == ((F_MarbleToolSawMillingMillingHeadMenu) this).btn_close.Name)
      {
        ((F_MarbleMilling5AxisMenu) this).Properties.Result = DialogResult.Cancel;
        if (((F_MarbleMilling5AxisMenu) this).Properties.FormCloseMode == FormCloseModeType.Dispose)
          this.Dispose();
        if (((F_MarbleMilling5AxisMenu) this).Properties.FormCloseMode == FormCloseModeType.Invisible)
          this.Visible = false;
      }
      if (control2.Name == ((F_MarbleToolSawMillingMillingHeadMenu) this).btn_maximize.Name)
        this.WindowState = FormWindowState.Maximized;
      if (!(control2.Name == ((F_MarbleMilling5AxisMenu) this).btn_minimise.Name))
        return;
      this.WindowState = FormWindowState.Normal;
    }
    catch (Exception ex)
    {
    }
  }
}
