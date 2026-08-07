// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Forms.Marble.F_Marble2DCamStrategyMenu
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using buControls.Controls;
using buControls.Forms.buControlForms.KeyPad;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;

#nullable disable
namespace buEyeBaseVer5.Forms.Marble;

public class F_Marble2DCamStrategyMenu : Form
{
  public buButton btn_DI46;
  public buButton btn_DI33;
  public buButton btn_DI45;
  public buButton btn_DI34;
  public buButton btn_DI44;
  public buButton btn_DI35;
  public buButton btn_DI43;
  public buButton btn_DI36;
  public buButton btn_DI42;
  public buButton btn_DI37;
  public buButton btn_DI41;
  public buButton btn_DI38;
  public buButton btn_DI40;
  public buButton btn_DI39;
  public buPanel pnl_input1;
  public buButton btn_DI15;
  public buButton btn_DI14;
  public buButton btn_DI13;

  internal void \u0001([In] object obj0, [In] FormClosingEventArgs obj1)
  {
    if (((F_MarbleLatheMenu) this).PropertiesForm.Result == DialogResult.OK)
      return;
    obj1.Cancel = true;
    ((F_MarbleLatheMenu) this).PropertiesForm.Result = DialogResult.Cancel;
    if (((F_MarbleLatheMenu) this).PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
      this.Dispose();
    if (((F_MarbleLatheMenu) this).PropertiesForm.FormCloseMode != FormCloseModeType.Invisible)
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
  }

  internal void \u0002([In] object obj0, [In] EventArgs obj1)
  {
  }

  internal void \u0003([In] object obj0, [In] EventArgs obj1)
  {
    ((F_MarbleLatheMenu) this).PropertiesForm.Result = DialogResult.Cancel;
    if (((F_MarbleLatheMenu) this).PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
      this.Dispose();
    if (((F_MarbleLatheMenu) this).PropertiesForm.FormCloseMode != FormCloseModeType.Invisible)
      return;
    this.Visible = false;
  }

  protected override void Dispose(bool disposing)
  {
    if ((!disposing ? 0 : (((F_MarbleLatheMenu) this).\u0001 != null ? 1 : 0)) != 0)
      ((F_MarbleLatheMenu) this).\u0001.Dispose();
    base.Dispose(disposing);
  }

  static F_Marble2DCamStrategyMenu() => F_MarbleLatheMenu.Captions = new List<string>();

  public F_Marble2DCamStrategyMenu()
  {
    ((F_MarbleColumnsMenu) this).SpinBaseColor = Color.LightGreen;
    ((F_MarbleColumnsMenu) this).SpinFocusColor = Color.MistyRose;
    ((F_MarbleColumnsMenu) this).PropertiesForm = new FormProperties();
    ((F_MarbleColumnsMenu) this).\u0001 = (IContainer) null;
    // ISSUE: explicit constructor call
    base.\u002Ector();
    \u0007.\u0001.\u0001((F_MarbleAbsoluteSet) this);
  }

  [CompilerGenerated]
  [SpecialName]
  public void add_ResetCommand(OkCommandWithTwoDataEventHandler value)
  {
    // ISSUE: reference to a compiler-generated field
    OkCommandWithTwoDataEventHandler dataEventHandler = ((F_MarbleColumnsMenu) this).\u0001;
    OkCommandWithTwoDataEventHandler comparand;
    do
    {
      comparand = dataEventHandler;
      // ISSUE: reference to a compiler-generated field
      dataEventHandler = Interlocked.CompareExchange<OkCommandWithTwoDataEventHandler>(ref ((F_MarbleColumnsMenu) this).\u0001, comparand + value, comparand);
    }
    while (dataEventHandler != comparand);
  }
}
