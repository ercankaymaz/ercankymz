// Decompiled with JetBrains decompiler
// Type: buMarble.Forms.F_MarbleKinematic
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
using System.Reflection;
using System.Runtime.InteropServices;
using System.Windows.Forms;

#nullable disable
namespace buMarble.Forms;

public class F_MarbleKinematic : Form
{
  public buButton btn_stopgantry;
  public buGround buGround1;
  public buButton btn_disableallgantry;
  public buButton btn_enableallgantry;
  public buButton btn_disabley2gantry;
  public buButton btn_enabley2gantry;
  public buSpin spn_gantryoffset;
  public buButton btn_gantrydisable;
  public buButton btn_gantryenable;
  public Color SpinBaseColor = Color.LightGreen;
  public Color SpinFocusColor = Color.MistyRose;
  public static List<string> Captions;
  public KinematicBase5 Kinematic = new KinematicBase5();
  public FormProperties PropertiesForm = new FormProperties();
  private IContainer \u0001 = (IContainer) null;
  internal buGround \u0001;
  public buSpin spn_A_AxisSawDistance;
  public buSpin spn_motor_A_AxisZDistance;
  public buSpin spn_C_AxisSawDistance;
  internal PictureBox \u0001;
  internal buLabel \u0001;
  internal buLabel \u0002;
  public buButton btn_ok;
  public buButton btn_cancel;
  public buButton btn_openkinematic;
  public buButton btn_savekinemtic;
  public buButton btn_options;
  internal buPanel \u0001;
  public buButton btn_closeadvanced;
  internal buLabel \u0003;
  public buSpin spn_c0ZDisA0;
  internal buLabel \u0004;
  internal buLabel \u0005;
  internal buLabel \u0006;
  internal buLabel \u0007;
  internal buLabel \u0008;
  internal buLabel \u000E;
  internal buLabel \u000F;
  public buSpin spn_c270ZDisA45;
  public buSpin spn_c180ZDisA45;
  public buSpin spn_c90ZDisA45;
  public buSpin spn_c0ZDisA45;
  public buSpin spn_c270ADisA45;
  public buSpin spn_c180ADisA45;
  public buSpin spn_c90ADisA45;
  public buSpin spn_c0ADisA45;
  public buSpin spn_c270ZDisA0;
  public buSpin spn_c180ZDisA0;
  public buSpin spn_c90ZDisA0;
  internal buPanel \u0002;
  internal buLabel \u0010;
  internal buLabel \u0011;
  public buSpin spn_measuredYDistanceA0A45;
  public buButton btn_adistancecalc;
  internal buLabel \u0012;
  public buSpin spn_ACalculated;
  public buButton btn_acentercalcshow;
  public buButton btn_closeAcalc;
  public buButton btn_A45ZPosGet;
  internal buLabel \u0013;
  public buSpin spn_A45ZPos;
  public buButton btn_A0ZPosGet;
  internal buLabel \u0014;
  public buSpin spn_A0ZPos;

  public void Apply()
  {
  }

  internal void \u0001([In] object obj0, [In] EventArgs obj1)
  {
    try
    {
      if (!((obj0 as Control).Name == ((F_MarbleGantryMove) this).btn_close.Name))
        return;
      ((F_MarbleGantryMove) this).PropertiesForm.Result = DialogResult.Cancel;
      if (((F_MarbleGantryMove) this).PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
        this.Dispose();
      if (((F_MarbleGantryMove) this).PropertiesForm.FormCloseMode != FormCloseModeType.Invisible)
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
    if ((!disposing ? 0 : (((F_MarbleGantryMove) this).\u0001 != null ? 1 : 0)) != 0)
      ((F_MarbleGantryMove) this).\u0001.Dispose();
    base.Dispose(disposing);
  }

  static F_MarbleKinematic() => F_MarbleGantryMove.Captions = new List<string>();

  public F_MarbleKinematic() => \u0005.\u0003.\u0001(this);

  public void Init()
  {
    this.PropertiesForm.Inited = false;
    if (this.PropertiesForm.Height > 10)
      this.Height = this.PropertiesForm.Height;
    if (this.PropertiesForm.Width > 10)
      this.Width = this.PropertiesForm.Width;
    this.TopMost = this.PropertiesForm.TopMost;
    this.StartPosition = this.PropertiesForm.FormPosition;
    this.spn_A_AxisSawDistance.Value = this.Kinematic.RotateCenterOffsetOfA.Y;
    this.spn_motor_A_AxisZDistance.Value = this.Kinematic.RotateCenterOffsetOfA.Z;
    this.spn_C_AxisSawDistance.Value = this.Kinematic.RotateCenterOffsetOfC.Y;
    this.spn_c0ZDisA0.Value = this.Kinematic.ZDistanceForA0AtC0;
    this.spn_c90ZDisA0.Value = this.Kinematic.ZDistanceForA0AtC90;
    this.spn_c180ZDisA0.Value = this.Kinematic.ZDistanceForA0AtC180;
    this.spn_c270ZDisA0.Value = this.Kinematic.ZDistanceForA0AtC270;
    this.spn_c0ZDisA45.Value = this.Kinematic.ZDistanceForA45AtC0;
    this.spn_c90ZDisA45.Value = this.Kinematic.ZDistanceForA45AtC90;
    this.spn_c180ZDisA45.Value = this.Kinematic.ZDistanceForA45AtC180;
    this.spn_c270ZDisA45.Value = this.Kinematic.ZDistanceForA45AtC270;
    this.spn_c0ADisA45.Value = this.Kinematic.ADistanceForA45AtC0;
    this.spn_c90ADisA45.Value = this.Kinematic.ADistanceForA45AtC90;
    this.spn_c180ADisA45.Value = this.Kinematic.ADistanceForA45AtC180;
    this.spn_c270ADisA45.Value = this.Kinematic.ADistanceForA45AtC270;
    ((F_MarblePartZero) this).spn_c0CDis.Value = this.Kinematic.CDistanceAtC0;
    ((F_MarblePartZero) this).spn_c90CDis.Value = this.Kinematic.CDistanceAtC90;
    ((F_MarblePartZero) this).spn_c180CDis.Value = this.Kinematic.CDistanceAtC180;
    ((F_MarblePartZero) this).spn_c270CDis.Value = this.Kinematic.CDistanceAtC270;
    this.LoadLanguage();
    this.PropertiesForm.Result = DialogResult.None;
    this.PropertiesForm.Inited = true;
  }

  public void LoadLanguage()
  {
    try
    {
      this.\u0001.Text = buLangTranslate.preDef.Kinematic;
      this.\u0001.Text = buLangTranslate.preCaptionMarble.CRotateCenter;
      this.spn_C_AxisSawDistance.Caption.Caption = buLangTranslate.preCaptionMarble.CAxisToSawEdgeDistance;
      this.spn_motor_A_AxisZDistance.Caption.Caption = buLangTranslate.preCaptionMarble.MotorShaftAndAAxisZDistance;
      this.spn_A_AxisSawDistance.Caption.Caption = buLangTranslate.preCaptionMarble.AAxisToSawEdgeDistance;
      this.btn_cancel.Text = buLangTranslate.preDef.Cancel;
      this.btn_ok.Text = buLangTranslate.preDef.Ok;
      this.btn_openkinematic.Text = buLangTranslate.preDef.Open;
      this.btn_savekinemtic.Text = buLangTranslate.preDef.Save;
      this.btn_options.Text = buLangTranslate.preDef.Option;
      this.btn_acentercalcshow.Text = $"A {buLangTranslate.preDef.Distance} {buLangTranslate.preDef.Calculate}";
      ((F_MarblePartZero) this).btn_jog.Text = $"{buLangTranslate.preDef.Jog} {buLangTranslate.preDef.Page}";
      ((F_MarblePartZero) this).btn_mdi.Text = "MDI";
      this.btn_A0ZPosGet.Text = buLangTranslate.preDef.GetPosition;
      this.btn_A45ZPosGet.Text = buLangTranslate.preDef.GetPosition;
      this.btn_adistancecalc.Text = $"A {buLangTranslate.preDef.Distance} {buLangTranslate.preDef.Calculate}";
      this.\u0003.Text = buLangTranslate.preDef.Option;
      this.\u0004.Text = $"Z {buLangTranslate.preDef.Distance} [A0]: ";
      this.\u000E.Text = $"Z {buLangTranslate.preDef.Distance} [A45]: ";
      this.\u000F.Text = $"A {buLangTranslate.preDef.Distance} [A45]: ";
      this.\u0011.Text = $"A {buLangTranslate.preDef.Distance} {buLangTranslate.preDef.Calculate}";
      ((F_MarblePartZero) this).\u0015.Text = "LC " + buLangTranslate.preDef.Distance;
      this.\u0014.Text = $"Z {buLangTranslate.preDef.Position} [A0]";
      this.\u0013.Text = $"Z {buLangTranslate.preDef.Position} [A45]";
      this.\u0010.Text = "Z " + buLangTranslate.preCaptionMarble.MeasuredYDistanceforA0andA45;
      this.\u0012.Text = "Z " + buLangTranslate.preCaptionMarble.CalculatedARotationDistance;
    }
    catch (Exception ex)
    {
    }
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

  internal void \u0001([In] object obj0, [In] EventArgs obj1)
  {
    try
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
    catch (Exception ex)
    {
      string message = "";
      buException.throwException(new CalculationErrorEventArg(true, MethodBase.GetCurrentMethod().Name, message, "Exception", "", "", -1, ex), true);
    }
  }

  public void Apply()
  {
    this.Kinematic.RotateCenterOffsetOfA.Y = this.spn_A_AxisSawDistance.Value;
    this.Kinematic.RotateCenterOffsetOfA.Z = this.spn_motor_A_AxisZDistance.Value;
    this.Kinematic.RotateCenterOffsetOfC.Y = this.spn_C_AxisSawDistance.Value;
    this.Kinematic.OffsetXYZ.Y = -this.Kinematic.RotateCenterOffsetOfC.Y;
    this.Kinematic.ZDistanceForA0AtC0 = this.spn_c0ZDisA0.Value;
    this.Kinematic.ZDistanceForA0AtC90 = this.spn_c90ZDisA0.Value;
    this.Kinematic.ZDistanceForA0AtC180 = this.spn_c180ZDisA0.Value;
    this.Kinematic.ZDistanceForA0AtC270 = this.spn_c270ZDisA0.Value;
    this.Kinematic.ZDistanceForA45AtC0 = this.spn_c0ZDisA45.Value;
    this.Kinematic.ZDistanceForA45AtC90 = this.spn_c90ZDisA45.Value;
    this.Kinematic.ZDistanceForA45AtC180 = this.spn_c180ZDisA45.Value;
    this.Kinematic.ZDistanceForA45AtC270 = this.spn_c270ZDisA45.Value;
    this.Kinematic.ADistanceForA45AtC0 = this.spn_c0ADisA45.Value;
    this.Kinematic.ADistanceForA45AtC90 = this.spn_c90ADisA45.Value;
    this.Kinematic.ADistanceForA45AtC180 = this.spn_c180ADisA45.Value;
    this.Kinematic.ADistanceForA45AtC270 = this.spn_c270ADisA45.Value;
    this.Kinematic.CDistanceAtC0 = ((F_MarblePartZero) this).spn_c0CDis.Value;
    this.Kinematic.CDistanceAtC90 = ((F_MarblePartZero) this).spn_c90CDis.Value;
    this.Kinematic.CDistanceAtC180 = ((F_MarblePartZero) this).spn_c180CDis.Value;
    this.Kinematic.CDistanceAtC270 = ((F_MarblePartZero) this).spn_c270CDis.Value;
  }

  internal void \u0002([In] object obj0, [In] EventArgs obj1)
  {
    this.Apply();
    this.PropertiesForm.Result = DialogResult.OK;
    if (this.PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
      this.Dispose();
    if (this.PropertiesForm.FormCloseMode != FormCloseModeType.Invisible)
      return;
    this.Visible = false;
  }
}
