// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Forms.Library.F_CharList
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using buControls.Controls;
using buEyeBaseVer5.Forms.Marble;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;

#nullable disable
namespace buEyeBaseVer5.Forms.Library;

public class F_CharList : Form
{
  public buSpin spn_cuttolerance;
  public buCheckBox chk_roughadaptive;
  public buCheckBox chk_roughparalel;
  public buCheckBox chk_roughoffset;
  public buCheckBox chk_roughuseramp;
  internal Panel \u0001;
  internal buLabel \u000E;
  public buCheckBox chk_roughremovecornerpeg;
  public buCheckBox chk_roughleadout;
  public buCheckBox chk_roughsharpcorner;
  public buSpin spn_roughrampdia;
  public buSpin spn_roughrampangle;
  public buCheckBox chk_roughminimizelink;
  public buButton btn_roughok;
  public buButton btn_roughsettings;
  public buButton btn_closecross;
  public buSpin spn_roughendheight;

  internal void \u0003([In] object obj0, [In] EventArgs obj1)
  {
    ((F_MarbleSawContourSettings) this).PropertiesForm.Result = DialogResult.Cancel;
    if (((F_MarbleSawContourSettings) this).PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
      this.Dispose();
    if (((F_MarbleSawContourSettings) this).PropertiesForm.FormCloseMode != FormCloseModeType.Invisible)
      return;
    this.Visible = false;
  }

  internal void \u0004([In] object obj0, [In] EventArgs obj1)
  {
    ((buControl) obj0).Display.BackColor = ((F_MarbleSawContourSettings) this).SpinFocusColor;
  }

  internal void \u0005([In] object obj0, [In] EventArgs obj1)
  {
    ((buControl) obj0).Display.BackColor = ((F_MarbleSawContourSettings) this).SpinBaseColor;
  }

  protected override void Dispose(bool disposing)
  {
    if ((!disposing ? 0 : (((F_MarbleSawContourSettings) this).\u0001 != null ? 1 : 0)) != 0)
      ((F_MarbleSawContourSettings) this).\u0001.Dispose();
    base.Dispose(disposing);
  }

  static F_CharList() => F_MarbleSawContourSettings.Captions = new List<string>();

  public F_CharList()
  {
    ((F_MarbleProfileSettings) this).\u0001 = (IContainer) null;
    // ISSUE: explicit constructor call
    base.\u002Ector();
    \u0007.\u0001.\u0001((F_MarbleHorizontalCut) this);
  }

  protected override void Dispose(bool disposing)
  {
    if ((!disposing ? 0 : (((F_MarbleProfileSettings) this).\u0001 != null ? 1 : 0)) != 0)
      ((F_MarbleProfileSettings) this).\u0001.Dispose();
    base.Dispose(disposing);
  }

  static F_CharList() => F_MarbleProfileSettings.Captions = new List<string>();

  public F_CharList()
  {
    ((F_MarbleTempCodes) this).SpinBaseColor = Color.LightGreen;
    ((F_MarbleTempCodes) this).SpinFocusColor = Color.MistyRose;
    ((F_MarbleTempCodes) this).PropertiesForm = new FormProperties();
    ((F_MarbleTempCodes) this).clrLabel = Color.DarkSeaGreen;
    ((F_MarbleTempCodes) this).clrFormCaption = Color.LightBlue;
    ((F_MarbleTempCodes) this).clrFormBackUpper = Color.Black;
    ((F_MarbleTempCodes) this).clrFormBackDown = Color.DarkGray;
    ((F_MarbleTempCodes) this).clrButtonDisplay = Color.DarkGray;
    ((F_MarbleTempCodes) this).clrButtonOver = Color.Gold;
    ((F_MarbleTempCodes) this).clrButtonDown = Color.Goldenrod;
    ((F_MarbleTempCodes) this).\u0001 = (IContainer) null;
    // ISSUE: explicit constructor call
    base.\u002Ector();
    \u0007.\u0001.\u0001((F_MarbleAxesSettings) this);
  }

  [CompilerGenerated]
  [SpecialName]
  public void add_CommandExecute(OkCommandWithFiveDataEventHandler value)
  {
    // ISSUE: reference to a compiler-generated field
    OkCommandWithFiveDataEventHandler dataEventHandler = ((F_MarbleTempCodes) this).\u0001;
    OkCommandWithFiveDataEventHandler comparand;
    do
    {
      comparand = dataEventHandler;
      // ISSUE: reference to a compiler-generated field
      dataEventHandler = Interlocked.CompareExchange<OkCommandWithFiveDataEventHandler>(ref ((F_MarbleTempCodes) this).\u0001, comparand + value, comparand);
    }
    while (dataEventHandler != comparand);
  }
}
