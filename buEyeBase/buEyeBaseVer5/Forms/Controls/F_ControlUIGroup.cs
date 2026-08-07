// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Forms.Controls.F_ControlUIGroup
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using buControls;
using buControls.Controls;
using buEyeBaseVer5.Forms.Events;
using dummy_ptr;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Windows.Forms;

#nullable disable
namespace buEyeBaseVer5.Forms.Controls;

public class F_ControlUIGroup : Form
{
  public Button btn_cancel;
  public Button btn_ok;
  internal NumericUpDown \u0001;
  internal Label \u0001;
  internal Label \u0002;
  internal NumericUpDown \u0002;
  internal Label \u0003;
  internal NumericUpDown \u0003;
  internal Label \u0004;
  internal NumericUpDown \u0004;
  internal Label \u0005;
  internal NumericUpDown \u0005;
  public Panel pnl_model;
  internal RadioButton \u0001;
  internal RadioButton \u0002;
  internal Label \u0006;

  internal void \u0001([In] object obj0, [In] DataGridViewCellEventArgs obj1)
  {
    ((F_ControlUICoordinate) this).\u0001 = obj1.ColumnIndex;
    ((F_ControlUICoordinate) this).\u0002 = obj1.RowIndex;
    if (((F_ControlUICoordinate) this).\u0002 < 0)
      return;
    string[] strArray = ((F_ControlUIBasic) this).grid_files.Rows[((F_ControlUICoordinate) this).\u0002].Cells[1].Value.ToString().Split('|');
    if (strArray.Length >= 1)
      ((F_ControlUIDataGridView) this).\u0001($"{((F_ControlUICoordinate) this).Path}\\{strArray[0].Trim()}");
    else
      ((F_ControlUICoordinate) this).\u0001 = ((F_ControlUIBasic) this).grid_files.Rows[((F_ControlUICoordinate) this).\u0002].Cells[1].Value.ToString();
    ((F_ControlUICoordinate) this).\u0001.Clear();
    ((F_ControlUICoordinate) this).\u0001 = new List<string>();
  }

  protected override void Dispose(bool disposing)
  {
    if ((!disposing ? 0 : (((F_ControlUIGround) this).\u0001 != null ? 1 : 0)) != 0)
      ((F_ControlUIGround) this).\u0001.Dispose();
    base.Dispose(disposing);
  }

  public abstract void m0015B3();

  public F_ControlUIGroup()
  {
    ((F_ControlUIBasic) this).SpinBaseColor = Color.LightGreen;
    ((F_ControlUIPanel) this).SpinFocusColor = Color.MistyRose;
    ((F_ControlUIPanel) this).Data = new ShapeAllData();
    ((F_ControlUIPanel) this).PropertiesForm = new FormProperties();
    ((F_ControlUIPanel) this).\u0001 = (IContainer) null;
    // ISSUE: explicit constructor call
    base.\u002Ector();
    \u007B0e48b843\u002Dfb72\u002D498c\u002D834d\u002Dfc743ba0facc\u007D.\u0001((F_EventAll) this);
  }

  public void Init()
  {
    ((F_ControlUIPanel) this).PropertiesForm.Inited = false;
    if (((F_ControlUIPanel) this).PropertiesForm.Height > 10)
      this.Height = ((F_ControlUIPanel) this).PropertiesForm.Height;
    if (((F_ControlUIPanel) this).PropertiesForm.Width > 10)
      this.Width = ((F_ControlUIPanel) this).PropertiesForm.Width;
    this.TopMost = ((F_ControlUIPanel) this).PropertiesForm.TopMost;
    this.StartPosition = ((F_ControlUIPanel) this).PropertiesForm.FormPosition;
    this.LoadLanguage();
    ((F_ControlUIListbox) this).spn_movex.Value = ((F_ControlUIPanel) this).Data.MoveX;
    ((F_ControlUIPanel) this).spn_movey.Value = ((F_ControlUIPanel) this).Data.MoveY;
    ((F_ControlUIDataGridView) this).spn_copyx.Value = ((F_ControlUIPanel) this).Data.CopyX;
    ((F_ControlUIDataGridView) this).spn_copyy.Value = ((F_ControlUIPanel) this).Data.CopyY;
    ((F_ControlUIListbox) this).spn_scalex.Value = ((F_ControlUIPanel) this).Data.ScaleX;
    ((F_ControlUIListbox) this).spn_scaley.Value = ((F_ControlUIPanel) this).Data.ScaleY;
    ((F_ControlUIDataGridView) this).spn_rotate.Value = ((F_ControlUIPanel) this).Data.RotateAngle;
    ((F_ControlUIDataGridView) this).spn_mirrordis.Value = ((F_ControlUIPanel) this).Data.MirrorDistance;
    ((F_ControlUIListbox) this).spn_lineararraycountx.Value = ((F_ControlUIPanel) this).Data.LinearArrayXCount;
    ((F_ControlUIListbox) this).spn_lineararraycounty.Value = ((F_ControlUIPanel) this).Data.LinearArrayYCount;
    ((F_ControlUIListbox) this).spn_lineararraydisx.Value = ((F_ControlUIPanel) this).Data.LinearArrayXDistance;
    ((F_ControlUIListbox) this).spn_lineararraydisy.Value = ((F_ControlUIPanel) this).Data.LinearArrayYDistance;
    ((F_ControlUIDataGridView) this).spn_circulararrayangle.Value = ((F_ControlUIPanel) this).Data.CircularArrarAngle;
    ((F_ControlUIDataGridView) this).spn_circulararraycount.Value = ((F_ControlUIPanel) this).Data.CircularArrayCount;
    if (((F_ControlUIPanel) this).Data.MirrorAxis == MirrorAxisXYType.X)
    {
      ((F_ControlUIDataGridView) this).\u0001.Check = true;
      ((F_ControlUIDataGridView) this).\u0002.Check = false;
    }
    else
    {
      ((F_ControlUIDataGridView) this).\u0001.Check = false;
      ((F_ControlUIDataGridView) this).\u0002.Check = true;
    }
    ((F_ControlUIPanel) this).PropertiesForm.Result = DialogResult.None;
    ((F_ControlUIPanel) this).PropertiesForm.Inited = true;
  }

  public void LoadLanguage()
  {
    try
    {
      if (F_ControlUIPanel.Captions.Count <= 14)
        return;
      ((F_ControlUIPanel) this).\u0001.Text = F_ControlUIPanel.Captions[0];
      ((F_ControlUIPanel) this).btn_ok.Text = F_ControlUIPanel.Captions[13];
      ((F_ControlUIPanel) this).btn_cancel.Text = F_ControlUIPanel.Captions[14];
    }
    catch (Exception ex)
    {
    }
  }

  internal void \u0001([In] object obj0, [In] FormClosingEventArgs obj1)
  {
    if (((F_ControlUIPanel) this).PropertiesForm.Result == DialogResult.OK)
      return;
    obj1.Cancel = true;
    ((F_ControlUIPanel) this).PropertiesForm.Result = DialogResult.Cancel;
    if (((F_ControlUIPanel) this).PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
      this.Dispose();
    if (((F_ControlUIPanel) this).PropertiesForm.FormCloseMode != FormCloseModeType.Invisible)
      return;
    this.Visible = false;
  }

  internal void \u0001([In] object obj0, [In] EventArgs obj1)
  {
    try
    {
      if (!AppBool.TouchPad)
        return;
      buSpin buSpin = new buSpin();
      buControlCommands.ShowKeyPad((Form) this, (Control) obj0);
    }
    catch (Exception ex)
    {
      string message = "";
      buException.throwException(new CalculationErrorEventArg(true, MethodBase.GetCurrentMethod().Name, message, "Exception", "", "", -1, ex), true);
    }
  }

  public void Apply()
  {
    ((F_ControlUIPanel) this).Data.MoveX = ((F_ControlUIListbox) this).spn_movex.Value;
    ((F_ControlUIPanel) this).Data.MoveY = ((F_ControlUIPanel) this).spn_movey.Value;
    ((F_ControlUIPanel) this).Data.CopyX = ((F_ControlUIDataGridView) this).spn_copyx.Value;
    ((F_ControlUIPanel) this).Data.CopyY = ((F_ControlUIDataGridView) this).spn_copyy.Value;
    ((F_ControlUIPanel) this).Data.ScaleX = ((F_ControlUIListbox) this).spn_scalex.Value;
    ((F_ControlUIPanel) this).Data.ScaleY = ((F_ControlUIListbox) this).spn_scaley.Value;
    ((F_ControlUIPanel) this).Data.RotateAngle = ((F_ControlUIDataGridView) this).spn_rotate.Value;
    ((F_ControlUIPanel) this).Data.MirrorDistance = ((F_ControlUIDataGridView) this).spn_mirrordis.Value;
    ((F_ControlUIPanel) this).Data.LinearArrayXCount = ((F_ControlUIListbox) this).spn_lineararraycountx.Value;
    ((F_ControlUIPanel) this).Data.LinearArrayYCount = ((F_ControlUIListbox) this).spn_lineararraycounty.Value;
    ((F_ControlUIPanel) this).Data.LinearArrayXDistance = ((F_ControlUIListbox) this).spn_lineararraydisx.Value;
    ((F_ControlUIPanel) this).Data.LinearArrayYDistance = ((F_ControlUIListbox) this).spn_lineararraydisy.Value;
    ((F_ControlUIPanel) this).Data.CircularArrarAngle = ((F_ControlUIDataGridView) this).spn_circulararrayangle.Value;
    ((F_ControlUIPanel) this).Data.CircularArrayCount = ((F_ControlUIDataGridView) this).spn_circulararraycount.Value;
    if (((F_ControlUIDataGridView) this).\u0001.Check)
      ((F_ControlUIPanel) this).Data.MirrorAxis = MirrorAxisXYType.X;
    else
      ((F_ControlUIPanel) this).Data.MirrorAxis = MirrorAxisXYType.Y;
  }

  internal void \u0002([In] object obj0, [In] EventArgs obj1)
  {
    this.Apply();
    ((F_ControlUIPanel) this).PropertiesForm.Result = DialogResult.OK;
    if (((F_ControlUIPanel) this).PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
      this.Dispose();
    if (((F_ControlUIPanel) this).PropertiesForm.FormCloseMode != FormCloseModeType.Invisible)
      return;
    this.Visible = false;
  }

  internal void \u0003([In] object obj0, [In] EventArgs obj1)
  {
    ((F_ControlUIPanel) this).PropertiesForm.Result = DialogResult.Cancel;
    if (((F_ControlUIPanel) this).PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
      this.Dispose();
    if (((F_ControlUIPanel) this).PropertiesForm.FormCloseMode != FormCloseModeType.Invisible)
      return;
    this.Visible = false;
  }
}
