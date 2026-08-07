// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Forms.Marble.F_MarbleColumns
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using buControls.Controls;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;

#nullable disable
namespace buEyeBaseVer5.Forms.Marble;

public class F_MarbleColumns : Form
{
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
  public buButton btn_DI12;
  public buButton btn_DI11;
  public buButton btn_DI10;
  public buButton btn_DI9;
  public buButton btn_DI8;
  public buButton btn_DI7;
  public buButton btn_DI6;
  public buButton btn_DI5;

  public void Apply()
  {
  }

  internal void \u0001([In] object obj0, [In] EventArgs obj1)
  {
    ((F_MarbleDigitalInputOutput) this).PropertiesForm.Result = DialogResult.Cancel;
    if (((F_MarbleDigitalInputOutput) this).PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
      this.Dispose();
    if (((F_MarbleDigitalInputOutput) this).PropertiesForm.FormCloseMode != FormCloseModeType.Invisible)
      return;
    this.Visible = false;
  }

  internal void \u0001([In] object obj0, [In] bool obj1)
  {
    // ISSUE: unable to decompile the method.
  }

  protected override void Dispose(bool disposing)
  {
    if ((!disposing ? 0 : (((F_MarbleDigitalInputOutput) this).\u0001 != null ? 1 : 0)) != 0)
      ((F_MarbleDigitalInputOutput) this).\u0001.Dispose();
    base.Dispose(disposing);
  }

  static F_MarbleColumns() => F_MarbleDigitalInputOutput.Captions = new List<string>();

  public F_MarbleColumns()
  {
    // ISSUE: unable to decompile the method.
  }

  [CompilerGenerated]
  [SpecialName]
  public void add_CommandExecute(OkCommandWithFiveDataEventHandler value)
  {
    // ISSUE: reference to a compiler-generated field
    OkCommandWithFiveDataEventHandler dataEventHandler = ((F_MarbleDigitalInputOutput) this).\u0001;
    OkCommandWithFiveDataEventHandler comparand;
    do
    {
      comparand = dataEventHandler;
      // ISSUE: reference to a compiler-generated field
      dataEventHandler = Interlocked.CompareExchange<OkCommandWithFiveDataEventHandler>(ref ((F_MarbleDigitalInputOutput) this).\u0001, comparand + value, comparand);
    }
    while (dataEventHandler != comparand);
  }
}
