// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Forms.Controls.F_ControlUICombo
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using buControls.Controls;
using buEyeBaseVer5.Forms.Customer.DincMak;
using dummy_ptr;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Windows.Forms;

#nullable disable
namespace buEyeBaseVer5.Forms.Controls;

public class F_ControlUICombo : Form
{
  public NumericUpDown spn_targetangle;
  internal Label \u0004;
  internal Panel \u0001;
  internal RadioButton \u0001;
  internal RadioButton \u0002;
  internal RadioButton \u0003;
  internal Label \u0005;
  public NumericUpDown spn_angle_finishspindlespeed;
  internal Label \u0006;
  internal Label \u0007;
  public NumericUpDown spn_angle_roughdepth;
  public NumericUpDown spn_angle_roughspindlespeed;
  internal Label \u0008;
  internal Label \u000E;
  public NumericUpDown spn_angle_width;
  public NumericUpDown spn_angle_finishvel;
  internal Label \u000F;
  internal Label \u0010;
  public NumericUpDown spn_angle_finishdepth;
  public NumericUpDown spn_angle_roughtvel;
  internal Label \u0011;
  internal Panel \u0002;

  protected override void Dispose(bool disposing)
  {
    if ((!disposing ? 0 : (((F_ControlUIProgress) this).\u0001 != null ? 1 : 0)) != 0)
      ((F_ControlUIProgress) this).\u0001.Dispose();
    base.Dispose(disposing);
  }

  public F_ControlUICombo()
  {
    ((F_ControlUIText) this).Properties = new FormProperties();
    ((F_ControlUIText) this).OPWidth = 0.0;
    ((F_ControlUIText) this).OPHeight = 0.0;
    ((F_ControlUISpin) this).Depth = 0.0;
    ((F_ControlUISpin) this).Radius = 0.0;
    ((F_ControlUISpin) this).XPos = 0.0;
    ((F_ControlUISpin) this).YPos = 0.0;
    ((F_ControlUISpin) this).SafeDis = 0.0;
    ((F_ControlUISpin) this).RapidDis = 0.0;
    ((F_ControlUISpin) this).PlungeFeed = 0.0;
    ((F_ControlUISpin) this).CuttingFeed = 0.0;
    ((F_ControlUISpin) this).CamType = CamClosedContourType.Outter;
    ((F_ControlUISpin) this).ToolNo = 1;
    ((F_ControlUISpin) this).\u0001 = (IContainer) null;
    // ISSUE: explicit constructor call
    base.\u002Ector();
    \u0007.\u0001.\u0001((F_RectangleShape) this);
  }

  public void Init()
  {
    ((F_ControlUIText) this).Properties.Inited = false;
    if (((F_ControlUIText) this).Properties.Height > 10)
      this.Height = ((F_ControlUIText) this).Properties.Height;
    if (((F_ControlUIText) this).Properties.Width > 10)
      this.Width = ((F_ControlUIText) this).Properties.Width;
    this.TopMost = ((F_ControlUIText) this).Properties.TopMost;
    this.StartPosition = ((F_ControlUIText) this).Properties.FormPosition;
    ((F_ControlUIText) this).Properties.Result = DialogResult.None;
    ((F_ControlUIText) this).Properties.Inited = true;
    ((F_ControlUIButton) this).spn_safedis.Value = ((F_ControlUISpin) this).SafeDis;
    ((F_ControlUIButton) this).spn_rapiddis.Value = ((F_ControlUISpin) this).RapidDis;
    ((F_ControlUIButton) this).spn_plungefeed.Value = ((F_ControlUISpin) this).PlungeFeed;
    ((F_ControlUILabel) this).spn_cuttingfeed.Value = ((F_ControlUISpin) this).CuttingFeed;
    ((F_ControlUILabel) this).spn_slotdepth.Value = ((F_ControlUISpin) this).Depth;
    ((F_ControlUILabel) this).spn_slotheight.Value = ((F_ControlUIText) this).OPHeight;
    ((F_ControlUILabel) this).spn_slotwidth.Value = ((F_ControlUIText) this).OPWidth;
    ((F_ControlUILabel) this).spn_slotradius.Value = ((F_ControlUISpin) this).Radius;
    ((F_ControlUILabel) this).spn_XPos.Value = ((F_ControlUISpin) this).XPos;
    ((F_ControlUILabel) this).spn_ZPos.Value = ((F_ControlUISpin) this).YPos;
    ((F_ControlUILabel) this).chk_contourcenter.Check = false;
    ((F_ControlUILabel) this).chk_contourinside.Check = false;
    ((F_ControlUILabel) this).chk_contouroutside.Check = false;
    ((F_ControlUILabel) this).chk_tool1.Check = false;
    ((F_ControlUILabel) this).chk_tool2.Check = false;
    ((F_ControlUILabel) this).chk_tool3.Check = false;
    if (((F_ControlUISpin) this).CamType == CamClosedContourType.Outter)
      ((F_ControlUILabel) this).chk_contouroutside.Check = true;
    if (((F_ControlUISpin) this).CamType == CamClosedContourType.Inner)
      ((F_ControlUILabel) this).chk_contourinside.Check = true;
    if (((F_ControlUISpin) this).CamType == CamClosedContourType.Center)
      ((F_ControlUILabel) this).chk_contourcenter.Check = true;
    if (((F_ControlUISpin) this).ToolNo == 0 | ((F_ControlUISpin) this).ToolNo == 1)
      ((F_ControlUILabel) this).chk_tool1.Check = true;
    if (((F_ControlUISpin) this).ToolNo == 2)
      ((F_ControlUILabel) this).chk_tool2.Check = true;
    if (((F_ControlUISpin) this).ToolNo == 3)
      ((F_ControlUILabel) this).chk_tool3.Check = true;
    \u0007.\u0001.\u0001((F_RectangleShape) this);
  }

  internal void \u0001([In] object obj0, [In] FormClosingEventArgs obj1)
  {
    if (((F_ControlUIText) this).Properties.Result == DialogResult.OK)
      return;
    obj1.Cancel = true;
    ((F_ControlUIText) this).Properties.Result = DialogResult.Cancel;
    if (((F_ControlUIText) this).Properties.FormCloseMode == FormCloseModeType.Dispose)
      this.Dispose();
    if (((F_ControlUIText) this).Properties.FormCloseMode != FormCloseModeType.Invisible)
      return;
    this.Visible = false;
  }

  internal void \u0001([In] object obj0, [In] EventArgs obj1)
  {
    try
    {
      Control control1 = new Control();
      Control control2 = (Control) obj0;
      if (control2.Name == ((F_ControlUISpin) this).btn_ok.Name)
      {
        \u0007.\u0001.\u0001((F_RectangleShape) this);
        ((F_ControlUIText) this).Properties.Result = DialogResult.OK;
        if (((F_ControlUIText) this).Properties.FormCloseMode == FormCloseModeType.Dispose)
          this.Dispose();
        if (((F_ControlUIText) this).Properties.FormCloseMode == FormCloseModeType.Invisible)
          this.Visible = false;
      }
      if (!(control2.Name == ((F_ControlUISpin) this).btn_cancel.Name | control2.Name == ((F_ControlUISpin) this).\u0001.Name))
        return;
      ((F_ControlUIText) this).Properties.Result = DialogResult.Cancel;
      if (((F_ControlUIText) this).Properties.FormCloseMode == FormCloseModeType.Dispose)
        this.Dispose();
      if (((F_ControlUIText) this).Properties.FormCloseMode != FormCloseModeType.Invisible)
        return;
      this.Visible = false;
    }
    catch (Exception ex)
    {
    }
  }

  internal void \u0002([In] object obj0, [In] EventArgs obj1)
  {
    if (!((F_ControlUIText) this).Properties.Inited)
      return;
    buCheckBox buCheckBox = obj0 as buCheckBox;
    if (buCheckBox.Name == ((F_ControlUILabel) this).chk_contourcenter.Name | buCheckBox.Name == ((F_ControlUILabel) this).chk_contourinside.Name | buCheckBox.Name == ((F_ControlUILabel) this).chk_contouroutside.Name)
    {
      ((F_ControlUILabel) this).chk_contourcenter.Check = false;
      ((F_ControlUILabel) this).chk_contourinside.Check = false;
      ((F_ControlUILabel) this).chk_contouroutside.Check = false;
      if (buCheckBox.Name == ((F_ControlUILabel) this).chk_contourcenter.Name)
        ((F_ControlUILabel) this).chk_contourcenter.Check = true;
      if (buCheckBox.Name == ((F_ControlUILabel) this).chk_contourinside.Name)
        ((F_ControlUILabel) this).chk_contourinside.Check = true;
      if (buCheckBox.Name == ((F_ControlUILabel) this).chk_contouroutside.Name)
        ((F_ControlUILabel) this).chk_contouroutside.Check = true;
    }
    if (!(buCheckBox.Name == ((F_ControlUILabel) this).chk_tool1.Name | buCheckBox.Name == ((F_ControlUILabel) this).chk_tool2.Name | buCheckBox.Name == ((F_ControlUILabel) this).chk_tool3.Name))
      return;
    ((F_ControlUILabel) this).chk_tool1.Check = false;
    ((F_ControlUILabel) this).chk_tool2.Check = false;
    ((F_ControlUILabel) this).chk_tool3.Check = false;
    if (buCheckBox.Name == ((F_ControlUILabel) this).chk_tool1.Name)
      ((F_ControlUILabel) this).chk_tool1.Check = true;
    if (buCheckBox.Name == ((F_ControlUILabel) this).chk_tool2.Name)
      ((F_ControlUILabel) this).chk_tool2.Check = true;
    if (!(buCheckBox.Name == ((F_ControlUILabel) this).chk_tool3.Name))
      return;
    ((F_ControlUILabel) this).chk_tool3.Check = true;
  }

  protected override void Dispose(bool disposing)
  {
    if ((!disposing ? 0 : (((F_ControlUISpin) this).\u0001 != null ? 1 : 0)) != 0)
      ((F_ControlUISpin) this).\u0001.Dispose();
    base.Dispose(disposing);
  }

  static F_ControlUICombo() => F_ControlUIText.Captions = new List<string>();

  public F_ControlUICombo()
  {
    ((F_ControlUIButton) this).Properties = new FormProperties();
    ((F_ControlUIButton) this).Width = 0.0;
    ((F_ControlUIButton) this).Diameter = 0.0;
    ((F_ControlUIButton) this).Depth = 0.0;
    ((F_ControlUIButton) this).XPos = 0.0;
    ((F_ControlUIButton) this).YPos = 0.0;
    ((F_ControlUIButton) this).Step = 0.0;
    ((F_ControlUIButton) this).SafeDis = 0.0;
    ((F_ControlUIButton) this).RapidDis = 0.0;
    ((F_ControlUIButton) this).PlungeFeed = 0.0;
    ((F_ControlUIButton) this).CuttingFeed = 0.0;
    ((F_ControlUIButton) this).CamType = CamClosedContourType.Outter;
    ((F_ControlUIButton) this).ToolNo = 1;
    ((F_ControlUIButton) this).\u0001 = (IContainer) null;
    // ISSUE: explicit constructor call
    base.\u002Ector();
    \u0007.\u0001.\u0001((F_SlotShape) this);
  }

  public void Init()
  {
    ((F_ControlUIButton) this).Properties.Inited = false;
    if (((F_ControlUIButton) this).Properties.Height > 10)
      this.Height = ((F_ControlUIButton) this).Properties.Height;
    if (((F_ControlUIButton) this).Properties.Width > 10)
      ((F_ControlUIButton) this).Width = (double) ((F_ControlUIButton) this).Properties.Width;
    this.TopMost = ((F_ControlUIButton) this).Properties.TopMost;
    this.StartPosition = ((F_ControlUIButton) this).Properties.FormPosition;
    ((F_ControlUIButton) this).Properties.Result = DialogResult.None;
    ((F_ControlUIButton) this).Properties.Inited = true;
    ((F_ControlUISettings) this).spn_safedis.Value = ((F_ControlUIButton) this).SafeDis;
    ((F_ControlUISettings) this).spn_rapiddis.Value = ((F_ControlUIButton) this).RapidDis;
    ((F_ControlUISettings) this).spn_plungefeed.Value = ((F_ControlUIButton) this).PlungeFeed;
    ((F_ControlUISettings) this).spn_cuttingfeed.Value = ((F_ControlUIButton) this).CuttingFeed;
    ((F_ControlUISettings) this).spn_slotdepth.Value = ((F_ControlUIButton) this).Depth;
    ((F_ControlUISettings) this).spn_slotheight.Value = ((F_ControlUIButton) this).Diameter;
    ((F_ControlUISettings) this).spn_slotwidth.Value = ((F_ControlUIButton) this).Width;
    ((F_ControlUISettings) this).spn_XPos.Value = ((F_ControlUIButton) this).XPos;
    ((F_ControlUISettings) this).spn_ZPos.Value = ((F_ControlUIButton) this).YPos;
    ((F_ControlUISettings) this).spn_step.Value = ((F_ControlUIButton) this).Step;
    ((F_ControlUISettings) this).chk_contourcenter.Check = false;
    ((F_ControlUISettings) this).chk_contourinside.Check = false;
    ((F_ControlUISettings) this).chk_contouroutside.Check = false;
    ((F_ControlUISettings) this).chk_tool1.Check = false;
    ((F_ControlUISettings) this).chk_tool2.Check = false;
    ((F_ControlUISettings) this).chk_tool3.Check = false;
    if (((F_ControlUIButton) this).CamType == CamClosedContourType.Outter)
      ((F_ControlUISettings) this).chk_contouroutside.Check = true;
    if (((F_ControlUIButton) this).CamType == CamClosedContourType.Inner)
      ((F_ControlUISettings) this).chk_contourinside.Check = true;
    if (((F_ControlUIButton) this).CamType == CamClosedContourType.Center)
      ((F_ControlUISettings) this).chk_contourcenter.Check = true;
    if (((F_ControlUIButton) this).ToolNo == 0 | ((F_ControlUIButton) this).ToolNo == 1)
      ((F_ControlUISettings) this).chk_tool1.Check = true;
    if (((F_ControlUIButton) this).ToolNo == 2)
      ((F_ControlUISettings) this).chk_tool2.Check = true;
    if (((F_ControlUIButton) this).ToolNo == 3)
      ((F_ControlUISettings) this).chk_tool3.Check = true;
    \u007B0e48b843\u002Dfb72\u002D498c\u002D834d\u002Dfc743ba0facc\u007D.\u0001((F_SlotShape) this);
  }

  internal void \u0001([In] object obj0, [In] FormClosingEventArgs obj1)
  {
    if (((F_ControlUIButton) this).Properties.Result == DialogResult.OK)
      return;
    obj1.Cancel = true;
    ((F_ControlUIButton) this).Properties.Result = DialogResult.Cancel;
    if (((F_ControlUIButton) this).Properties.FormCloseMode == FormCloseModeType.Dispose)
      this.Dispose();
    if (((F_ControlUIButton) this).Properties.FormCloseMode != FormCloseModeType.Invisible)
      return;
    this.Visible = false;
  }

  internal void \u0001([In] object obj0, [In] EventArgs obj1)
  {
    try
    {
      Control control1 = new Control();
      Control control2 = (Control) obj0;
      if (control2.Name == ((F_ControlUISettings) this).btn_ok.Name)
      {
        \u0014.\u0002.\u0001((F_SlotShape) this);
        ((F_ControlUIButton) this).Properties.Result = DialogResult.OK;
        if (((F_ControlUIButton) this).Properties.FormCloseMode == FormCloseModeType.Dispose)
          this.Dispose();
        if (((F_ControlUIButton) this).Properties.FormCloseMode == FormCloseModeType.Invisible)
          this.Visible = false;
      }
      if (!(control2.Name == ((F_ControlUISettings) this).btn_cancel.Name | control2.Name == ((F_ControlUISettings) this).\u0001.Name))
        return;
      ((F_ControlUIButton) this).Properties.Result = DialogResult.Cancel;
      if (((F_ControlUIButton) this).Properties.FormCloseMode == FormCloseModeType.Dispose)
        this.Dispose();
      if (((F_ControlUIButton) this).Properties.FormCloseMode != FormCloseModeType.Invisible)
        return;
      this.Visible = false;
    }
    catch (Exception ex)
    {
    }
  }
}
