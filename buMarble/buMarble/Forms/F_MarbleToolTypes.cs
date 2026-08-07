// Decompiled with JetBrains decompiler
// Type: buMarble.Forms.F_MarbleToolTypes
// Assembly: buMarble, Version=5.1.1.2, Culture=neutral, PublicKeyToken=null
// MVID: D6F2AAC2-9013-4D8E-A4D2-15511BAB107F
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buMarble.dll

using buClass;
using buControls.Controls;
using buEyeBaseVer5;
using SmartAssembly.HouseOfCards;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Windows.Forms;

#nullable disable
namespace buMarble.Forms;

public class F_MarbleToolTypes : Form
{
  public buSpin spn_imageoffsetX;
  public buSpin spn_imageoffsety;
  public buCheckBox chk_sameimagetoArchive;
  public buCheckBox chk_autolenscalibrationfromslabthickness;
  public buSpin spn_imageheight;
  public buSpin spn_imagewidth;
  public static byte f000B45;
  public static List<string> Captions = new List<string>();
  public FormProperties PropertiesForm;
  private IContainer \u0001;
  public buButton btn_close;
  public buGround buGround1;
  public buCheckBox chk_washbeforevacuum;
  public buCheckBox chk_pointanglecorrection;
  public buCheckBox chk_startsafedistance;
  public buCheckBox chk_dryrun;
  internal RadioButton \u0001;
  internal RadioButton \u0002;
  internal RadioButton \u0003;
  internal buLabel \u0001;
  internal buLabel \u0002;
  internal buLabel \u0003;
  internal buLabel \u0004;
  internal buLabel \u0005;
  public buButton btn_parklist;
  public buButton btn_canceloption;
  public buButton btn_startoption;
  public static List<string> Captions;
  public FormProperties PropertiesForm = new FormProperties();
  public ToolBase5 Tool = new ToolBase5();
  private IContainer \u0001 = (IContainer) null;
  public buButton btn_close;
  public buGround buGround1;
  public buButton btn_ok;
  public buButton btn_cancel;
  internal buLabel \u0001;

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
    clsAppMarbleVars.varRuntime.isDryRunActivated = this.chk_dryrun.Check;
    clsAppMarbleVars.varApp.PointAngleCorrection = this.chk_pointanglecorrection.Check;
    clsAppMarbleVars.varApp.GoZUpPositionWhenStart = this.chk_startsafedistance.Check;
    clsAppMarbleVars.varApp.VacuumWashBeforeMaterialTake = this.chk_washbeforevacuum.Check;
    if (this.\u0002.Checked)
      clsAppMarbleVars.varApp.ParkPositionAfterFinishType = (MarbleParkModeAfterJob) 1;
    else if (this.\u0003.Checked)
      clsAppMarbleVars.varApp.ParkPositionAfterFinishType = MarbleParkModeAfterJob.Saw;
    else
      clsAppMarbleVars.varApp.ParkPositionAfterFinishType = (MarbleParkModeAfterJob) 2;
  }

  internal void \u0001([In] object obj0, [In] EventArgs obj1)
  {
    try
    {
      Control control1 = new Control();
      Control control2 = (Control) obj0;
      if (control2.Name == this.btn_startoption.Name)
      {
        this.Apply();
        this.PropertiesForm.Result = DialogResult.OK;
        if (this.PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
          this.Dispose();
        if (this.PropertiesForm.FormCloseMode == FormCloseModeType.Invisible)
          this.Visible = false;
      }
      if (control2.Name == this.btn_close.Name | control2.Name == this.btn_canceloption.Name)
      {
        this.PropertiesForm.Result = DialogResult.Cancel;
        if (this.PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
          this.Dispose();
        if (this.PropertiesForm.FormCloseMode == FormCloseModeType.Invisible)
          this.Visible = false;
      }
      if (!(control2.Name == this.btn_parklist.Name))
        return;
      clsAppMarbleVars.cmdMarble.ShowParkList();
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
    if ((!disposing ? 0 : (this.\u0001 != null ? 1 : 0)) != 0)
      this.\u0001.Dispose();
    base.Dispose(disposing);
  }

  public F_MarbleToolTypes() => \u0005.\u0003.\u0001(this);

  public void Init()
  {
    this.PropertiesForm.Inited = false;
    if (this.PropertiesForm.Height > 10)
      this.Height = this.PropertiesForm.Height;
    if (this.PropertiesForm.Width > 10)
      this.Width = this.PropertiesForm.Width;
    this.TopMost = this.PropertiesForm.TopMost;
    this.StartPosition = this.PropertiesForm.FormPosition;
    ((\u0002.\u0001.\u0001) this).\u0001.Text = this.Tool.Data.Name;
    ((\u0002.\u0001) this).spn_toollength.Value = this.Tool.Geometry.Length;
    ((\u0002.\u0001.\u0001) this).spn_tooldia.Value = this.Tool.Geometry.Diameter;
    ((\u0002.\u0001) this).spn_toolcuttinglen.Value = this.Tool.Geometry.CutLength;
    ((\u0002.\u0001) this).spn_toollowerradius.Value = this.Tool.Geometry.LowerRadius;
    ((F_MarbleWagonSettings) this).spn_tooloutsidedia.Value = this.Tool.Geometry.OutsideDiameter;
    ((F_MarbleWagonSettings) this).spn_tooltaperangle.Value = this.Tool.Geometry.TaperAngle;
    ((MemberRefsProxy) this).spn_toolspeed.Value = this.Tool.CamData.SpindleSpeed;
    ((F_MarbleWagonSettings) this).chk_flat.Check = false;
    ((F_MarbleWagonSettings) this).chk_sphare.Check = false;
    ((F_MarbleWagonSettings) this).chk_boolnose.Check = false;
    ((F_MarbleWagonSettings) this).chk_taper.Check = false;
    ((F_MarbleWagonSettings) this).chk_chamfer.Check = false;
    ((F_MarbleWagonSettings) this).chk_grinding.Check = false;
    ((F_MarbleWagonSettings) this).chk_barrel.Check = false;
    ((F_MarbleWagonSettings) this).chk_lollipop.Check = false;
    ((F_MarbleWagonSettings) this).chk_slot.Check = false;
    ((F_MarbleWagonSettings) this).chk_dove.Check = false;
    if (this.Tool.Geometry.GeometryType == ToolType.Flat)
      ((F_MarbleWagonSettings) this).chk_flat.Check = true;
    else if (this.Tool.Geometry.GeometryType == ToolType.Sphere)
      ((F_MarbleWagonSettings) this).chk_sphare.Check = true;
    else if (this.Tool.Geometry.GeometryType == ToolType.Bullnose)
      ((F_MarbleWagonSettings) this).chk_boolnose.Check = true;
    else if (this.Tool.Geometry.GeometryType == ToolType.Taper)
      ((F_MarbleWagonSettings) this).chk_taper.Check = true;
    else if (this.Tool.Geometry.GeometryType == ToolType.Dove)
      ((F_MarbleWagonSettings) this).chk_dove.Check = true;
    else if (this.Tool.Geometry.GeometryType == ToolType.Chamfer)
      ((F_MarbleWagonSettings) this).chk_chamfer.Check = true;
    else if (this.Tool.Geometry.GeometryType == ToolType.Lollipop)
      ((F_MarbleWagonSettings) this).chk_lollipop.Check = true;
    else if (this.Tool.Geometry.GeometryType == ToolType.Barrel)
      ((F_MarbleWagonSettings) this).chk_barrel.Check = true;
    else if (this.Tool.Geometry.GeometryType == ToolType.Slot)
      ((F_MarbleWagonSettings) this).chk_slot.Check = true;
    else if (this.Tool.Geometry.GeometryType == ToolType.Grinding)
      ((F_MarbleWagonSettings) this).chk_grinding.Check = true;
    ((F_MarbleWagonSettings) this).chk_cornercorner.Check = false;
    ((F_MarbleWagonSettings) this).chk_cornerfull.Check = false;
    ((F_MarbleWagonSettings) this).chk_cornernone.Check = false;
    if (this.Tool.Geometry.CornerRadiusType == ToolCornerRadiusType.None)
      ((F_MarbleWagonSettings) this).chk_cornernone.Check = true;
    if (this.Tool.Geometry.CornerRadiusType == ToolCornerRadiusType.Full)
      ((F_MarbleWagonSettings) this).chk_cornerfull.Check = true;
    if (this.Tool.Geometry.CornerRadiusType == ToolCornerRadiusType.Corner)
      ((F_MarbleWagonSettings) this).chk_cornercorner.Check = true;
    \u0005.\u0003.\u0001(this);
    this.ControlUpdate();
    clsAppMarbleVars.cmdMarble.DrawTool(this.Tool);
    this.PropertiesForm.Result = DialogResult.None;
    this.PropertiesForm.Inited = true;
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

  public void ControlUpdate()
  {
    ((\u0002.\u0001.\u0001) this).spn_tooldia.Caption.Caption = $"{buLangTranslate.preDef.Tool} {buLangTranslate.preDef.Diameter}";
    ((\u0002.\u0001) this).spn_toollength.Caption.Caption = $"{buLangTranslate.preDef.Tool} {buLangTranslate.preDef.Length}";
    ((F_MarbleWagonSettings) this).spn_tooloutsidedia.Caption.Caption = $"{buLangTranslate.preDef.Tool} {buLangTranslate.preDef.Outside} {buLangTranslate.preDef.Diameter}";
    ((\u0002.\u0001) this).spn_toolcuttinglen.Visible = true;
    ((\u0002.\u0001) this).spn_toollowerradius.Visible = false;
    ((F_MarbleWagonSettings) this).spn_tooloutsidedia.Visible = false;
    ((F_MarbleWagonSettings) this).spn_tooltaperangle.Visible = false;
    ((\u0002.\u0001.\u0001) this).\u0001.Visible = false;
    ((F_MarbleWagonSettings) this).chk_cornerfull.Visible = true;
    if (this.Tool.Geometry.GeometryType == ToolType.Bullnose)
      ((\u0002.\u0001) this).spn_toollowerradius.Visible = true;
    else if (this.Tool.Geometry.GeometryType == ToolType.Slot)
    {
      ((\u0002.\u0001) this).spn_toollowerradius.Visible = true;
      ((\u0002.\u0001.\u0001) this).\u0001.Visible = true;
    }
    else if (this.Tool.Geometry.GeometryType == ToolType.Taper | this.Tool.Geometry.GeometryType == ToolType.Dove)
    {
      ((\u0002.\u0001) this).spn_toollowerradius.Visible = true;
      ((F_MarbleWagonSettings) this).spn_tooltaperangle.Visible = true;
      ((\u0002.\u0001.\u0001) this).\u0001.Visible = true;
    }
    else if (this.Tool.Geometry.GeometryType == ToolType.Dove)
    {
      ((\u0002.\u0001) this).spn_toollowerradius.Visible = true;
      ((F_MarbleWagonSettings) this).spn_tooltaperangle.Visible = true;
      ((\u0002.\u0001.\u0001) this).\u0001.Visible = true;
      ((F_MarbleWagonSettings) this).chk_cornerfull.Visible = false;
    }
    else if (this.Tool.Geometry.GeometryType == ToolType.Chamfer)
    {
      ((\u0002.\u0001) this).spn_toollowerradius.Visible = true;
      ((F_MarbleWagonSettings) this).spn_tooltaperangle.Visible = true;
      ((F_MarbleWagonSettings) this).spn_tooloutsidedia.Visible = true;
      ((\u0002.\u0001.\u0001) this).\u0001.Visible = true;
    }
    else if (this.Tool.Geometry.GeometryType == ToolType.Lollipop)
    {
      ((F_MarbleWagonSettings) this).spn_tooloutsidedia.Visible = true;
    }
    else
    {
      if (this.Tool.Geometry.GeometryType != ToolType.Grinding)
        return;
      ((F_MarbleWagonSettings) this).spn_tooloutsidedia.Caption.Caption = $"{buLangTranslate.preDef.Tool} {buLangTranslate.preDef.Inside} {buLangTranslate.preDef.Diameter}";
      ((F_MarbleWagonSettings) this).spn_tooloutsidedia.Visible = true;
    }
  }

  public void Apply()
  {
    this.Tool.Data.Name = ((\u0002.\u0001.\u0001) this).\u0001.Text;
    this.Tool.CamData.SpindleSpeed = ((MemberRefsProxy) this).spn_toolspeed.Value;
    this.Tool.Geometry.Length = ((\u0002.\u0001) this).spn_toollength.Value;
    this.Tool.Geometry.Diameter = ((\u0002.\u0001.\u0001) this).spn_tooldia.Value;
    this.Tool.Geometry.CutLength = ((\u0002.\u0001) this).spn_toolcuttinglen.Value;
    this.Tool.Geometry.LowerRadius = ((\u0002.\u0001) this).spn_toollowerradius.Value;
    this.Tool.Geometry.RoundRadius = ((\u0002.\u0001) this).spn_toollowerradius.Value;
    this.Tool.Geometry.OutsideDiameter = ((F_MarbleWagonSettings) this).spn_tooloutsidedia.Value;
    this.Tool.Geometry.TaperAngle = ((F_MarbleWagonSettings) this).spn_tooltaperangle.Value;
    this.Tool.Geometry.DrawArbor = false;
    this.Tool.Geometry.DrawHolder = false;
    if (this.Tool.Geometry.CutLength <= 0.0)
      this.Tool.Geometry.CutLength = this.Tool.Geometry.Length * 0.75;
    if (this.Tool.Geometry.Diameter <= 0.0)
      return;
    if (((F_MarbleWagonSettings) this).chk_flat.Check)
    {
      this.Tool.Geometry.GeometryType = ToolType.Flat;
      this.Tool.Purpose = ToolPurpose.Milling;
    }
    else if (((F_MarbleWagonSettings) this).chk_sphare.Check)
    {
      this.Tool.Geometry.GeometryType = ToolType.Sphere;
      this.Tool.Purpose = ToolPurpose.Milling;
    }
    else if (((F_MarbleWagonSettings) this).chk_boolnose.Check)
    {
      this.Tool.Geometry.GeometryType = ToolType.Bullnose;
      this.Tool.Purpose = ToolPurpose.Milling;
    }
    else if (((F_MarbleWagonSettings) this).chk_taper.Check)
    {
      this.Tool.Geometry.GeometryType = ToolType.Taper;
      this.Tool.Purpose = ToolPurpose.Milling;
    }
    else if (((F_MarbleWagonSettings) this).chk_lollipop.Check)
    {
      this.Tool.Geometry.GeometryType = ToolType.Lollipop;
      this.Tool.Purpose = ToolPurpose.Milling;
    }
    else if (((F_MarbleWagonSettings) this).chk_chamfer.Check)
    {
      this.Tool.Geometry.GeometryType = ToolType.Chamfer;
      this.Tool.Purpose = ToolPurpose.Milling;
    }
    else if (((F_MarbleWagonSettings) this).chk_dove.Check)
    {
      this.Tool.Geometry.GeometryType = ToolType.Dove;
      this.Tool.Purpose = ToolPurpose.Milling;
    }
    else if (((F_MarbleWagonSettings) this).chk_barrel.Check)
    {
      this.Tool.Geometry.GeometryType = ToolType.Barrel;
      this.Tool.Purpose = ToolPurpose.Milling;
    }
    else if (((F_MarbleWagonSettings) this).chk_slot.Check)
    {
      this.Tool.Geometry.GeometryType = ToolType.Slot;
      this.Tool.Purpose = ToolPurpose.Milling;
    }
    else if (((F_MarbleWagonSettings) this).chk_grinding.Check)
    {
      this.Tool.Geometry.GeometryType = ToolType.Grinding;
      this.Tool.Purpose = ToolPurpose.Milling;
    }
    this.Tool.Geometry.CornerRadiusType = !((F_MarbleWagonSettings) this).chk_cornercorner.Check ? (!((F_MarbleWagonSettings) this).chk_cornerfull.Check ? ToolCornerRadiusType.None : ToolCornerRadiusType.Full) : ToolCornerRadiusType.Corner;
    clsAppMarbleVars.cmdMarble.DrawTool(this.Tool);
  }

  internal void \u0001([In] object obj0, [In] EventArgs obj1)
  {
    try
    {
      Control control1 = new Control();
      Control control2 = (Control) obj0;
      if (control2.Name == this.btn_ok.Name)
      {
        this.Apply();
        ((\u0002.\u0001.\u0001) this).pnl_preview.Controls.Clear();
        this.PropertiesForm.Result = DialogResult.OK;
        if (this.PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
          this.Dispose();
        if (this.PropertiesForm.FormCloseMode == FormCloseModeType.Invisible)
          this.Visible = false;
      }
      if (!(control2.Name == this.btn_close.Name | control2.Name == this.btn_cancel.Name))
        return;
      ((\u0002.\u0001.\u0001) this).pnl_preview.Controls.Clear();
      this.PropertiesForm.Result = DialogResult.Cancel;
      if (this.PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
        this.Dispose();
      if (this.PropertiesForm.FormCloseMode != FormCloseModeType.Invisible)
        return;
      this.Visible = false;
    }
    catch (Exception ex)
    {
    }
  }

  internal void \u0002([In] object obj0, [In] EventArgs obj1)
  {
    try
    {
      Control control1 = new Control();
      Control control2 = (Control) obj0;
      ((F_MarbleWagonSettings) this).chk_flat.Check = false;
      ((F_MarbleWagonSettings) this).chk_sphare.Check = false;
      ((F_MarbleWagonSettings) this).chk_boolnose.Check = false;
      ((F_MarbleWagonSettings) this).chk_taper.Check = false;
      ((F_MarbleWagonSettings) this).chk_chamfer.Check = false;
      ((F_MarbleWagonSettings) this).chk_grinding.Check = false;
      ((F_MarbleWagonSettings) this).chk_barrel.Check = false;
      ((F_MarbleWagonSettings) this).chk_lollipop.Check = false;
      ((F_MarbleWagonSettings) this).chk_slot.Check = false;
      ((F_MarbleWagonSettings) this).chk_dove.Check = false;
      if (control2.Name == ((F_MarbleWagonSettings) this).chk_flat.Name)
      {
        this.Tool.Geometry.GeometryType = ToolType.Flat;
        this.Tool.Purpose = ToolPurpose.Milling;
        ((F_MarbleWagonSettings) this).chk_flat.Check = true;
      }
      else if (control2.Name == ((F_MarbleWagonSettings) this).chk_sphare.Name)
      {
        this.Tool.Geometry.GeometryType = ToolType.Sphere;
        this.Tool.Purpose = ToolPurpose.Milling;
        ((F_MarbleWagonSettings) this).chk_sphare.Check = true;
      }
      else if (control2.Name == ((F_MarbleWagonSettings) this).chk_boolnose.Name)
      {
        this.Tool.Geometry.GeometryType = ToolType.Bullnose;
        if (this.Tool.Geometry.Diameter < this.Tool.Geometry.RoundRadius * 2.0)
        {
          this.Tool.Geometry.Diameter = this.Tool.Geometry.RoundRadius * 2.5;
          ((\u0002.\u0001.\u0001) this).spn_tooldia.Value = this.Tool.Geometry.Diameter;
        }
        this.Tool.Purpose = ToolPurpose.Milling;
        if (this.Tool.Geometry.CornerRadiusType == ToolCornerRadiusType.Corner && this.Tool.Geometry.RoundRadius > this.Tool.Geometry.Diameter / 2.0)
        {
          this.Tool.Geometry.RoundRadius = this.Tool.Geometry.Diameter * 0.4;
          ((\u0002.\u0001) this).spn_toollowerradius.Value = this.Tool.Geometry.RoundRadius;
        }
        ((F_MarbleWagonSettings) this).chk_boolnose.Check = true;
      }
      else if (control2.Name == ((F_MarbleWagonSettings) this).chk_taper.Name)
      {
        this.Tool.Geometry.GeometryType = ToolType.Taper;
        this.Tool.Purpose = ToolPurpose.Milling;
        if (this.Tool.Geometry.CornerRadiusType == ToolCornerRadiusType.Corner && this.Tool.Geometry.LowerRadius > this.Tool.Geometry.Diameter / 2.0)
        {
          this.Tool.Geometry.LowerRadius = this.Tool.Geometry.Diameter * 0.4;
          ((\u0002.\u0001) this).spn_toollowerradius.Value = this.Tool.Geometry.LowerRadius;
        }
        ((F_MarbleWagonSettings) this).chk_taper.Check = true;
      }
      else if (control2.Name == ((F_MarbleWagonSettings) this).chk_dove.Name)
      {
        this.Tool.Geometry.GeometryType = ToolType.Dove;
        this.Tool.Purpose = ToolPurpose.Milling;
        if (this.Tool.Geometry.CornerRadiusType == ToolCornerRadiusType.Corner && this.Tool.Geometry.LowerRadius > this.Tool.Geometry.Diameter / 2.0)
        {
          this.Tool.Geometry.LowerRadius = this.Tool.Geometry.Diameter * 0.4;
          ((\u0002.\u0001) this).spn_toollowerradius.Value = this.Tool.Geometry.LowerRadius;
        }
        ((F_MarbleWagonSettings) this).chk_dove.Check = true;
      }
      else if (control2.Name == ((F_MarbleWagonSettings) this).chk_chamfer.Name)
      {
        this.Tool.Geometry.GeometryType = ToolType.Chamfer;
        this.Tool.Purpose = ToolPurpose.Milling;
        ((F_MarbleWagonSettings) this).chk_chamfer.Check = true;
      }
      else if (control2.Name == ((F_MarbleWagonSettings) this).chk_barrel.Name)
      {
        this.Tool.Geometry.GeometryType = ToolType.Barrel;
        this.Tool.Purpose = ToolPurpose.Milling;
        ((F_MarbleWagonSettings) this).chk_barrel.Check = true;
      }
      else if (control2.Name == ((F_MarbleWagonSettings) this).chk_slot.Name)
      {
        this.Tool.Geometry.GeometryType = ToolType.Slot;
        this.Tool.Purpose = ToolPurpose.Milling;
        ((F_MarbleWagonSettings) this).chk_slot.Check = true;
      }
      else if (control2.Name == ((F_MarbleWagonSettings) this).chk_grinding.Name)
      {
        this.Tool.Geometry.GeometryType = ToolType.Grinding;
        this.Tool.Purpose = ToolPurpose.Milling;
        ((F_MarbleWagonSettings) this).chk_grinding.Check = true;
      }
      else if (control2.Name == ((F_MarbleWagonSettings) this).chk_lollipop.Name)
      {
        this.Tool.Geometry.GeometryType = ToolType.Lollipop;
        this.Tool.Purpose = ToolPurpose.Milling;
        if (this.Tool.Geometry.OutsideDiameter > this.Tool.Geometry.Diameter / 2.0)
        {
          this.Tool.Geometry.OutsideDiameter = this.Tool.Geometry.Diameter * 0.3;
          ((F_MarbleWagonSettings) this).spn_tooloutsidedia.Value = this.Tool.Geometry.OutsideDiameter;
        }
        ((F_MarbleWagonSettings) this).chk_lollipop.Check = true;
      }
      this.ControlUpdate();
      this.Apply();
    }
    catch (Exception ex)
    {
    }
  }

  internal void \u0003([In] object obj0, [In] EventArgs obj1)
  {
    try
    {
      Control control1 = new Control();
      Control control2 = (Control) obj0;
      ((F_MarbleWagonSettings) this).chk_cornercorner.Check = false;
      ((F_MarbleWagonSettings) this).chk_cornerfull.Check = false;
      ((F_MarbleWagonSettings) this).chk_cornernone.Check = false;
      if (control2.Name == ((F_MarbleWagonSettings) this).chk_cornercorner.Name)
      {
        this.Tool.Geometry.CornerRadiusType = ToolCornerRadiusType.Corner;
        if (this.Tool.Geometry.LowerRadius > this.Tool.Geometry.Diameter / 2.0)
        {
          this.Tool.Geometry.LowerRadius = this.Tool.Geometry.Diameter * 0.4;
          ((\u0002.\u0001) this).spn_toollowerradius.Value = this.Tool.Geometry.LowerRadius;
        }
        ((F_MarbleWagonSettings) this).chk_cornercorner.Check = true;
      }
      else if (control2.Name == ((F_MarbleWagonSettings) this).chk_cornerfull.Name)
      {
        this.Tool.Geometry.CornerRadiusType = ToolCornerRadiusType.Full;
        ((F_MarbleWagonSettings) this).chk_cornerfull.Check = true;
      }
      else
      {
        this.Tool.Geometry.CornerRadiusType = ToolCornerRadiusType.None;
        ((F_MarbleWagonSettings) this).chk_cornernone.Check = true;
      }
      this.ControlUpdate();
      this.Apply();
    }
    catch (Exception ex)
    {
    }
  }
}
