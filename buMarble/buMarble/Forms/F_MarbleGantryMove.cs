// Decompiled with JetBrains decompiler
// Type: buMarble.Forms.F_MarbleGantryMove
// Assembly: buMarble, Version=5.1.1.2, Culture=neutral, PublicKeyToken=null
// MVID: D6F2AAC2-9013-4D8E-A4D2-15511BAB107F
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buMarble.dll

using buCadCamResVer5;
using buClass;
using buControls.Controls;
using buControls.Forms.buControlForms.KeyPad;
using buEyeBaseVer5;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Windows.Forms;

#nullable disable
namespace buMarble.Forms;

public class F_MarbleGantryMove : Form
{
  public buButton btn_closecross;
  internal ImageList \u0001;
  public buSpin spn_sawdiscalculatedvalue;
  public buSpin spn_sawdissafedistance;
  public buSpin spn_sawdisAAngle;
  public buSpin spn_sawdistargetz;
  public buSpin spn_sawdismaterialdistance;
  public buButton btn_pointmovecalc;
  public static byte f000313;
  public static List<string> Captions;
  public FormProperties PropertiesForm = new FormProperties();
  internal IContainer \u0001 = (IContainer) null;
  public ImageList IC32;
  public buButton btn_close;
  public buButton btn_y2minusgantry;
  public buButton btn_y2plusgantry;
  public buSpin spn_ypos;

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
  }

  public void MenuButtonColors(int PageIndex)
  {
    hmiUICommands.SetVisualItem(((F_MarbleCalculators) this).\u0001.Controls);
    if (PageIndex == 0)
    {
      ((F_MarbleCalculators) this).btn_sawdistance.Display.LineerGradient.FirstColor = buEyeVars.parVisual.hmiButtonMenu2.ButtonNormal.SelectionColor;
      ((F_MarbleCalculators) this).btn_sawdistance.Display.LineerGradient.SecondColor = buEyeVars.parVisual.hmiButtonMenu2.ButtonNormal.SelectionColor;
    }
    if (PageIndex == 1)
    {
      ((F_MarbleCalculators) this).btn_pointmove.Display.LineerGradient.FirstColor = buEyeVars.parVisual.hmiButtonMenu2.ButtonNormal.SelectionColor;
      ((F_MarbleCalculators) this).btn_pointmove.Display.LineerGradient.SecondColor = buEyeVars.parVisual.hmiButtonMenu2.ButtonNormal.SelectionColor;
    }
    ((F_MarbleCalculators) this).SelectedTab = PageIndex;
  }

  internal void \u0002([In] object obj0, [In] EventArgs obj1)
  {
    Control control = obj0 as Control;
    if (control.Name == ((F_MarbleCalculators) this).btn_cancel.Name | control.Name == this.btn_closecross.Name)
    {
      ((F_MarbleCalculators) this).PropertiesForm.Result = DialogResult.Cancel;
      if (((F_MarbleCalculators) this).PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
        this.Dispose();
      if (((F_MarbleCalculators) this).PropertiesForm.FormCloseMode == FormCloseModeType.Invisible)
        this.Visible = false;
    }
    if (control.Name == ((F_MarbleCalculators) this).btn_ok.Name)
    {
      this.Apply();
      ((F_MarbleCalculators) this).PropertiesForm.Result = DialogResult.OK;
      if (((F_MarbleCalculators) this).PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
        this.Dispose();
      if (((F_MarbleCalculators) this).PropertiesForm.FormCloseMode == FormCloseModeType.Invisible)
        this.Visible = false;
    }
    if (control.Name == ((F_MarbleCalculators) this).btn_sawdiscalculate.Name)
      this.spn_sawdiscalculatedvalue.Value = clsInit.cMarble.DistanceCalcFromToolDiameterAndThickness(((F_MarbleCalculators) this).spn_sawdistooldiameter.Value, this.spn_sawdismaterialdistance.Value, this.spn_sawdistargetz.Value, this.spn_sawdissafedistance.Value, this.spn_sawdisAAngle.Value);
    if (control.Name == this.btn_pointmovecalc.Name)
    {
      clsAppMarbleVars.cmdMarble.DebugCreateRTCPCodesFromPointList();
      this.\u0002((object) ((F_MarbleCalculators) this).btn_cancel, (EventArgs) null);
    }
    if (control.Name == ((F_MarbleCalculators) this).btn_sawdistance.Name)
    {
      ((F_MarbleCalculators) this).buTab_tools.SelectedIndex = 0;
      this.MenuButtonColors(0);
    }
    if (!(control.Name == ((F_MarbleCalculators) this).btn_pointmove.Name))
      return;
    ((F_MarbleCalculators) this).buTab_tools.SelectedIndex = 1;
    this.MenuButtonColors(1);
  }

  protected override void Dispose(bool disposing)
  {
    if ((!disposing ? 0 : (((F_MarbleCalculators) this).\u0001 != null ? 1 : 0)) != 0)
      ((F_MarbleCalculators) this).\u0001.Dispose();
    base.Dispose(disposing);
  }

  static F_MarbleGantryMove() => F_MarbleCalculators.Captions = new List<string>();

  public F_MarbleGantryMove() => \u0005.\u0003.\u0001(this);

  public void Init()
  {
    this.PropertiesForm.Inited = false;
    if (this.PropertiesForm.Height > 10)
      this.Height = this.PropertiesForm.Height;
    if (this.PropertiesForm.Width > 10)
      this.Width = this.PropertiesForm.Width;
    this.TopMost = this.PropertiesForm.TopMost;
    this.StartPosition = this.PropertiesForm.FormPosition;
    this.PropertiesForm.Result = DialogResult.None;
    this.PropertiesForm.Inited = true;
    clsAppMarbleIOVar.\u0001(this);
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
}
