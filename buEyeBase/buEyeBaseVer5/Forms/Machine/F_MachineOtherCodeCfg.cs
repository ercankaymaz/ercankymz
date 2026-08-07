// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Forms.Machine.F_MachineOtherCodeCfg
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using buControls.Controls;
using buControls.Forms.buControlForms.KeyPad;
using buEyeBaseVer5.Forms.Marble;
using System;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Windows.Forms;

#nullable disable
namespace buEyeBaseVer5.Forms.Machine;

public class F_MachineOtherCodeCfg : Form
{
  public buSpin spn_roughsteplen;
  internal TabPage \u0003;
  internal TabPage \u0004;
  internal TabPage \u0005;
  internal buLabel \u0002;
  public buSpin spn_contoursafedistance;
  public buSpin spn_contourrapiddis;
  public buSpin spn_contourplungevel;
  public buSpin spn_contourcuttingvel;
  internal buLabel \u0003;
  public buSpin spn_centersafedis;
  public buSpin spn_centerrapiddis;
  public buSpin spn_centerplungevel;
  public buSpin spn_centercuttingvel;
  internal buLabel \u0004;
  public buSpin spn_facesafedis;

  public void Init()
  {
    ((F_MarbleSawMillingContourSetting) this).PropertiesForm.Inited = false;
    if (((F_MarbleSawMillingContourSetting) this).PropertiesForm.Height > 10)
      this.Height = ((F_MarbleSawMillingContourSetting) this).PropertiesForm.Height;
    if (((F_MarbleSawMillingContourSetting) this).PropertiesForm.Width > 10)
      this.Width = ((F_MarbleSawMillingContourSetting) this).PropertiesForm.Width;
    this.TopMost = ((F_MarbleSawMillingContourSetting) this).PropertiesForm.TopMost;
    this.StartPosition = ((F_MarbleSawMillingContourSetting) this).PropertiesForm.FormPosition;
    ((F_MarbleSawMillingContourSetting) this).spn_cutangle.Value = ((F_MarbleSawMillingContourSetting) this).AngleValue;
    this.LoadLanguage();
    ((F_MarbleSawMillingContourSetting) this).PropertiesForm.Result = DialogResult.None;
    ((F_MarbleSawMillingContourSetting) this).PropertiesForm.Inited = true;
  }

  public void LoadLanguage()
  {
    try
    {
      if (F_MarbleSawMillingContourSetting.Captions.Count <= 14)
        return;
      ((F_MarbleSawMillingContourSetting) this).\u0001.Text = buLangTranslate.preDef.Angle;
      ((F_MarbleSawMillingContourSetting) this).btn_ok.Text = buLangTranslate.preDef.Ok;
      ((F_MarbleSawMillingContourSetting) this).btn_cancel.Text = buLangTranslate.preDef.Cancel;
      ((F_MarbleSawMillingContourSetting) this).spn_cutangle.Caption.Caption = $"{buLangTranslate.preDef.Cutting} {buLangTranslate.preDef.Angle}";
    }
    catch (Exception ex)
    {
    }
  }

  internal void \u0001([In] object obj0, [In] FormClosingEventArgs obj1)
  {
    if (((F_MarbleSawMillingContourSetting) this).PropertiesForm.Result == DialogResult.OK)
      return;
    obj1.Cancel = true;
    ((F_MarbleSawMillingContourSetting) this).PropertiesForm.Result = DialogResult.Cancel;
    if (((F_MarbleSawMillingContourSetting) this).PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
      this.Dispose();
    if (((F_MarbleSawMillingContourSetting) this).PropertiesForm.FormCloseMode != FormCloseModeType.Invisible)
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
      if (!buFile5.IsNumeric(fKeyPadNumV1.Value))
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
    ((F_MarbleSawMillingContourSetting) this).AngleValue = ((F_MarbleSawMillingContourSetting) this).spn_cutangle.Value;
  }

  internal void \u0002([In] object obj0, [In] EventArgs obj1)
  {
    this.Apply();
    ((F_MarbleSawMillingContourSetting) this).PropertiesForm.Result = DialogResult.OK;
    if (((F_MarbleSawMillingContourSetting) this).PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
      this.Dispose();
    if (((F_MarbleSawMillingContourSetting) this).PropertiesForm.FormCloseMode != FormCloseModeType.Invisible)
      return;
    this.Visible = false;
  }

  internal void \u0003([In] object obj0, [In] EventArgs obj1)
  {
    ((F_MarbleSawMillingContourSetting) this).PropertiesForm.Result = DialogResult.Cancel;
    if (((F_MarbleSawMillingContourSetting) this).PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
      this.Dispose();
    if (((F_MarbleSawMillingContourSetting) this).PropertiesForm.FormCloseMode != FormCloseModeType.Invisible)
      return;
    this.Visible = false;
  }
}
