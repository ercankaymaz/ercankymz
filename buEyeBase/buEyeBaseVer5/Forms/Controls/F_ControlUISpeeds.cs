// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Forms.Controls.F_ControlUISpeeds
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

public class F_ControlUISpeeds : Form
{
  internal RadioButton \u0004;
  internal RadioButton \u0005;
  internal RadioButton \u0006;
  internal Label \u0012;
  public NumericUpDown spn_height_finishspindlespeed;
  internal Label \u0013;
  internal Label \u0014;
  public NumericUpDown spn_height_roughtdepth;
  public NumericUpDown spn_height_roughspindlespeed;
  internal Label \u0015;
  internal Label \u0016;
  public NumericUpDown spn_height_width;
  public NumericUpDown spn_height_finishvel;
  internal Label \u0017;
  internal Label \u0018;
  public NumericUpDown spn_height_finishdepth;
  public NumericUpDown spn_height_roughtvel;
  internal Label \u0019;
  internal Panel \u0003;
  internal Label \u001A;
  internal Button \u0003;
  public NumericUpDown spn_targetHeight;
  internal Label \u001B;
  internal Label \u001C;
  public NumericUpDown spn_feeddistance;
  internal Panel \u0004;
  internal CheckBox \u0001;
  internal RadioButton \u0007;

  internal void \u0002([In] object obj0, [In] EventArgs obj1)
  {
    if (!((F_ControlUIButton) this).Properties.Inited)
      return;
    buCheckBox buCheckBox = obj0 as buCheckBox;
    if (buCheckBox.Name == ((F_ControlUISettings) this).chk_contourcenter.Name | buCheckBox.Name == ((F_ControlUISettings) this).chk_contourinside.Name | buCheckBox.Name == ((F_ControlUISettings) this).chk_contouroutside.Name)
    {
      ((F_ControlUISettings) this).chk_contourcenter.Check = false;
      ((F_ControlUISettings) this).chk_contourinside.Check = false;
      ((F_ControlUISettings) this).chk_contouroutside.Check = false;
      if (buCheckBox.Name == ((F_ControlUISettings) this).chk_contourcenter.Name)
        ((F_ControlUISettings) this).chk_contourcenter.Check = true;
      if (buCheckBox.Name == ((F_ControlUISettings) this).chk_contourinside.Name)
        ((F_ControlUISettings) this).chk_contourinside.Check = true;
      if (buCheckBox.Name == ((F_ControlUISettings) this).chk_contouroutside.Name)
        ((F_ControlUISettings) this).chk_contouroutside.Check = true;
    }
    if (!(buCheckBox.Name == ((F_ControlUISettings) this).chk_tool1.Name | buCheckBox.Name == ((F_ControlUISettings) this).chk_tool2.Name | buCheckBox.Name == ((F_ControlUISettings) this).chk_tool3.Name))
      return;
    ((F_ControlUISettings) this).chk_tool1.Check = false;
    ((F_ControlUISettings) this).chk_tool2.Check = false;
    ((F_ControlUISettings) this).chk_tool3.Check = false;
    if (buCheckBox.Name == ((F_ControlUISettings) this).chk_tool1.Name)
      ((F_ControlUISettings) this).chk_tool1.Check = true;
    if (buCheckBox.Name == ((F_ControlUISettings) this).chk_tool2.Name)
      ((F_ControlUISettings) this).chk_tool2.Check = true;
    if (!(buCheckBox.Name == ((F_ControlUISettings) this).chk_tool3.Name))
      return;
    ((F_ControlUISettings) this).chk_tool3.Check = true;
  }

  protected override void Dispose(bool disposing)
  {
    if ((!disposing ? 0 : (((F_ControlUIButton) this).\u0001 != null ? 1 : 0)) != 0)
      ((F_ControlUIButton) this).\u0001.Dispose();
    base.Dispose(disposing);
  }

  static F_ControlUISpeeds() => F_ControlUIButton.Captions = new List<string>();

  public F_ControlUISpeeds()
  {
    ((F_ControlUISettings) this).Properties = new FormProperties();
    ((F_ControlUISettings) this).ZPos = 0.0;
    ((F_ControlUISettings) this).Depth = 0.0;
    ((F_ControlUISettings) this).X1Pos = 0.0;
    ((F_ControlUISettings) this).X2Pos = 0.0;
    ((F_ControlUISettings) this).SafeDis = 0.0;
    ((F_ControlUISettings) this).RapidDis = 0.0;
    ((F_ControlUISettings) this).PlungeFeed = 0.0;
    ((F_ControlUISettings) this).CuttingFeed = 0.0;
    ((F_ControlUISettings) this).Dir = HorizontalDirectionType.LeftToRight;
    ((F_ControlUISettings) this).\u0001 = (IContainer) null;
    // ISSUE: explicit constructor call
    base.\u002Ector();
    \u007B0e48b843\u002Dfb72\u002D498c\u002D834d\u002Dfc743ba0facc\u007D.\u0001((F_LineShape) this);
  }

  public void Init()
  {
    ((F_ControlUISettings) this).Properties.Inited = false;
    if (((F_ControlUISettings) this).Properties.Height > 10)
      this.Height = ((F_ControlUISettings) this).Properties.Height;
    if (((F_ControlUISettings) this).Properties.Width > 10)
      this.Width = ((F_ControlUISettings) this).Properties.Width;
    this.TopMost = ((F_ControlUISettings) this).Properties.TopMost;
    this.StartPosition = ((F_ControlUISettings) this).Properties.FormPosition;
    ((F_ControlUISettings) this).Properties.Result = DialogResult.None;
    ((F_ControlUISettings) this).Properties.Inited = true;
    ((F_ControlUISettings) this).spn_safedis.Value = ((F_ControlUISettings) this).SafeDis;
    ((F_ControlUISettings) this).spn_rapiddis.Value = ((F_ControlUISettings) this).RapidDis;
    ((F_ControlUISettings) this).spn_plungefeed.Value = ((F_ControlUISettings) this).PlungeFeed;
    ((F_ControlUISettings) this).spn_cuttingfeed.Value = ((F_ControlUISettings) this).CuttingFeed;
    ((F_ControlUISettings) this).spn_linedepth.Value = ((F_ControlUISettings) this).Depth;
    ((F_ControlUISettings) this).spn_zpos.Value = ((F_ControlUISettings) this).ZPos;
    ((F_ControlUISettings) this).spn_x2Pos.Value = ((F_ControlUISettings) this).X2Pos;
    ((F_ControlUISettings) this).spn_x1pos.Value = ((F_ControlUISettings) this).X1Pos;
    ((F_ControlUISettings) this).chk_linelefttorigth.Check = false;
    ((F_ControlUISettings) this).chk_linerighttoleft.Check = false;
    if (((F_ControlUISettings) this).Dir == HorizontalDirectionType.LeftToRight)
      ((F_ControlUISettings) this).chk_linelefttorigth.Check = true;
    if (((F_ControlUISettings) this).Dir == HorizontalDirectionType.RigthToLeft)
      ((F_ControlUISettings) this).chk_linerighttoleft.Check = true;
    \u007B0e48b843\u002Dfb72\u002D498c\u002D834d\u002Dfc743ba0facc\u007D.\u0001((F_LineShape) this);
  }

  internal void \u0001([In] object obj0, [In] FormClosingEventArgs obj1)
  {
    if (((F_ControlUISettings) this).Properties.Result == DialogResult.OK)
      return;
    obj1.Cancel = true;
    ((F_ControlUISettings) this).Properties.Result = DialogResult.Cancel;
    if (((F_ControlUISettings) this).Properties.FormCloseMode == FormCloseModeType.Dispose)
      this.Dispose();
    if (((F_ControlUISettings) this).Properties.FormCloseMode != FormCloseModeType.Invisible)
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
        \u0007.\u0001.\u0001((F_LineShape) this);
        ((F_ControlUISettings) this).Properties.Result = DialogResult.OK;
        if (((F_ControlUISettings) this).Properties.FormCloseMode == FormCloseModeType.Dispose)
          this.Dispose();
        if (((F_ControlUISettings) this).Properties.FormCloseMode == FormCloseModeType.Invisible)
          this.Visible = false;
      }
      if (!(control2.Name == ((F_ControlUISettings) this).btn_cancel.Name | control2.Name == ((F_ControlUISettings) this).\u0001.Name))
        return;
      ((F_ControlUISettings) this).Properties.Result = DialogResult.Cancel;
      if (((F_ControlUISettings) this).Properties.FormCloseMode == FormCloseModeType.Dispose)
        this.Dispose();
      if (((F_ControlUISettings) this).Properties.FormCloseMode != FormCloseModeType.Invisible)
        return;
      this.Visible = false;
    }
    catch (Exception ex)
    {
    }
  }

  internal void \u0001([In] object obj0, [In] bool obj1)
  {
    if (!((F_ControlUISettings) this).Properties.Inited)
      ;
  }

  internal void \u0002([In] object obj0, [In] EventArgs obj1)
  {
    if (!((F_ControlUISettings) this).Properties.Inited)
      return;
    buCheckBox buCheckBox = obj0 as buCheckBox;
    ((F_ControlUISettings) this).chk_linelefttorigth.Check = false;
    ((F_ControlUISettings) this).chk_linerighttoleft.Check = false;
    if (buCheckBox.Name == ((F_ControlUISettings) this).chk_linelefttorigth.Name)
      ((F_ControlUISettings) this).chk_linelefttorigth.Check = true;
    if (!(buCheckBox.Name == ((F_ControlUISettings) this).chk_linerighttoleft.Name))
      return;
    ((F_ControlUISettings) this).chk_linerighttoleft.Check = true;
  }

  protected override void Dispose(bool disposing)
  {
    if ((!disposing ? 0 : (((F_ControlUISettings) this).\u0001 != null ? 1 : 0)) != 0)
      ((F_ControlUISettings) this).\u0001.Dispose();
    base.Dispose(disposing);
  }

  static F_ControlUISpeeds() => F_ControlUISettings.Captions = new List<string>();

  public F_ControlUISpeeds()
  {
    ((F_ControlUISettings) this).Properties = new FormProperties();
    ((F_ControlUISettings) this).Width = 0.0;
    ((F_ControlUISettings) this).StartHeight = 0.0;
    ((F_ControlUISettings) this).EndHeight = 0.0;
    ((F_ControlUISettings) this).Depth = 0.0;
    ((F_ControlUISettings) this).XPos = 0.0;
    ((F_ControlUISettings) this).ZOffset = 0.0;
    ((F_ControlUISettings) this).XOffset = 0.0;
    ((F_ControlUISettings) this).SafeDis = 0.0;
    ((F_ControlUISettings) this).RapidDis = 0.0;
    ((F_ControlUISettings) this).PlungeFeed = 0.0;
    ((F_ControlUISettings) this).CuttingFeed = 0.0;
    ((F_ControlUISettings) this).OpLocation = LeftMiddleRightLocationType.Middle;
    ((F_ControlUISettings) this).\u0001 = (IContainer) null;
    // ISSUE: explicit constructor call
    base.\u002Ector();
    \u0007.\u0001.\u0001((F_VShapePocket) this);
  }

  public void Init()
  {
    ((F_ControlUISettings) this).Properties.Inited = false;
    if (((F_ControlUISettings) this).Properties.Height > 10)
      this.Height = ((F_ControlUISettings) this).Properties.Height;
    if (((F_ControlUISettings) this).Properties.Width > 10)
      ((F_ControlUISettings) this).Width = (double) ((F_ControlUISettings) this).Properties.Width;
    this.TopMost = ((F_ControlUISettings) this).Properties.TopMost;
    this.StartPosition = ((F_ControlUISettings) this).Properties.FormPosition;
    ((F_ControlUISettings) this).Properties.Result = DialogResult.None;
    ((F_ControlUISettings) this).Properties.Inited = true;
    ((F_ControlUISettings) this).spn_safedis.Value = ((F_ControlUISettings) this).SafeDis;
    ((F_ControlUISettings) this).spn_rapiddis.Value = ((F_ControlUISettings) this).RapidDis;
    ((F_ControlUISettings) this).spn_plungefeed.Value = ((F_ControlUISettings) this).PlungeFeed;
    ((F_ControlUISettings) this).spn_cuttingfeed.Value = ((F_ControlUISettings) this).CuttingFeed;
    ((F_ControlUISettings) this).spn_vcleaningdepth.Value = ((F_ControlUISettings) this).Depth;
    ((F_ControlUISettings) this).spn_vcleaningendheight.Value = ((F_ControlUISettings) this).EndHeight;
    ((F_ControlUISettings) this).spn_vcleaningstartheight.Value = ((F_ControlUISettings) this).StartHeight;
    ((F_ControlUISettings) this).spn_vcleaningwidth.Value = ((F_ControlUISettings) this).Width;
    ((F_ControlUISettings) this).spn_xpos.Value = ((F_ControlUISettings) this).XPos;
    ((F_ControlUISettings) this).spn_ZOffset.Value = ((F_ControlUISettings) this).ZOffset;
    ((F_ControlUISettings) this).spn_xoffset.Value = ((F_ControlUISettings) this).XOffset;
    ((F_ControlUISettings) this).chk_vleft.Check = false;
    ((F_ControlUISettings) this).chk_vmiddle.Check = false;
    ((F_ControlUISettings) this).chk_vright.Check = false;
    if (((F_ControlUISettings) this).OpLocation == LeftMiddleRightLocationType.Left)
      ((F_ControlUISettings) this).chk_vleft.Check = true;
    if (((F_ControlUISettings) this).OpLocation == LeftMiddleRightLocationType.Right)
      ((F_ControlUISettings) this).chk_vright.Check = true;
    if (((F_ControlUISettings) this).OpLocation == LeftMiddleRightLocationType.Middle)
      ((F_ControlUISettings) this).chk_vmiddle.Check = true;
    \u0007.\u0001.\u0001((F_VShapePocket) this);
  }
}
