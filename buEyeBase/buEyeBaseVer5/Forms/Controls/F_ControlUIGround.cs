// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Forms.Controls.F_ControlUIGround
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using buEyeBaseVer5.Forms.Customer.DincMak;
using buEyeBaseVer5.Forms.Foam;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;

#nullable disable
namespace buEyeBaseVer5.Forms.Controls;

public class F_ControlUIGround : Form
{
  private System.Windows.Forms.Timer \u0001;
  internal IContainer \u0001;
  internal TextBox \u0001;
  internal Label \u0001;
  internal Panel \u0001;
  internal Label \u0002;
  internal Panel \u0002;
  internal Button \u0001;
  internal ImageList \u0001;
  internal Button \u0002;
  internal Button \u0003;
  internal Button \u0004;
  internal Button \u0005;
  internal Button \u0006;
  internal Button \u0007;
  internal NumericUpDown \u0001;
  internal Button \u0008;
  internal Label \u0003;

  public void LoadLanguage()
  {
    string callMethod = nameof (LoadLanguage);
    try
    {
      if (F_RectangleShape.Captions.Count >= 9)
        ;
    }
    catch (Exception ex)
    {
      string str = "";
      buLog.addLog(str, "Not Ok", callMethod);
      buException.throwException(ex, callMethod, true, str);
    }
  }

  public void ControlUpdate()
  {
    ((F_RectangleShape) this).\u0001.Value = (Decimal) ((F_RectangleShape) this).Length;
    ((F_RectangleShape) this).\u0002.Value = (Decimal) ((F_RectangleShape) this).Angle;
  }

  public void Apply()
  {
    ((F_RectangleShape) this).Length = (double) ((F_RectangleShape) this).\u0001.Value;
    ((F_RectangleShape) this).Angle = (double) ((F_RectangleShape) this).\u0002.Value;
  }

  internal void \u0001([In] object obj0, [In] FormClosingEventArgs obj1)
  {
    if (((F_RectangleShape) this).PropertiesForm.Result == DialogResult.OK)
      return;
    obj1.Cancel = true;
    ((F_RectangleShape) this).PropertiesForm.Result = DialogResult.Cancel;
    if (((F_RectangleShape) this).PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
      this.Dispose();
    if (((F_RectangleShape) this).PropertiesForm.FormCloseMode != FormCloseModeType.Invisible)
      return;
    this.Visible = false;
  }

  internal void \u0001([In] object obj0, [In] EventArgs obj1)
  {
    Control control1 = new Control();
    Control control2 = (Control) obj0;
    if (control2.Name == ((F_RectangleShape) this).btn_ok.Name)
    {
      this.Apply();
      ((F_RectangleShape) this).PropertiesForm.Result = DialogResult.OK;
      if (((F_RectangleShape) this).PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
        this.Dispose();
      if (((F_RectangleShape) this).PropertiesForm.FormCloseMode != FormCloseModeType.Invisible)
        return;
      this.Visible = false;
    }
    else if (control2.Name == ((F_RectangleShape) this).btn_cancel.Name)
    {
      ((F_RectangleShape) this).PropertiesForm.Result = DialogResult.Cancel;
      if (((F_RectangleShape) this).PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
        this.Dispose();
      if (((F_RectangleShape) this).PropertiesForm.FormCloseMode != FormCloseModeType.Invisible)
        return;
      this.Visible = false;
    }
    else
    {
      if (control2.Name == ((F_RectangleShape) this).\u0008.Name)
        ((F_RectangleShape) this).\u0002.Value = 0M;
      if (control2.Name == ((F_RectangleShape) this).\u0007.Name)
        ((F_RectangleShape) this).\u0002.Value = 180M;
      if (control2.Name == ((F_RectangleShape) this).\u0006.Name)
        ((F_RectangleShape) this).\u0002.Value = 180M;
      if (control2.Name == ((F_RectangleShape) this).\u0005.Name)
        ((F_RectangleShape) this).\u0002.Value = 0M;
      if (control2.Name == ((F_RectangleShape) this).\u0001.Name)
        ((F_RectangleShape) this).\u0002.Value = -90M;
      if (control2.Name == ((F_RectangleShape) this).\u0002.Name)
        ((F_RectangleShape) this).\u0002.Value = 90M;
      if (control2.Name == ((F_RectangleShape) this).\u0003.Name)
        ((F_RectangleShape) this).\u0002.Value = 90M;
      if (!(control2.Name == ((F_RectangleShape) this).\u0004.Name))
        return;
      ((F_RectangleShape) this).\u0002.Value = -90M;
    }
  }

  protected override void Dispose(bool disposing)
  {
    if ((!disposing ? 0 : (((F_RectangleShape) this).\u0001 != null ? 1 : 0)) != 0)
      ((F_RectangleShape) this).\u0001.Dispose();
    base.Dispose(disposing);
  }

  static F_ControlUIGround() => F_RectangleShape.Captions = new List<string>();

  public F_ControlUIGround()
  {
    ((F_RectangleShape) this).PropertiesForm = new FormProperties();
    ((F_RectangleShape) this).FoamSize = new SizeObject();
    ((F_SlotShape) this).ValueChanging = false;
    ((F_SlotShape) this).\u0001 = (IContainer) null;
    // ISSUE: explicit constructor call
    base.\u002Ector();
    \u0007.\u0001.\u0001((F_FoamPattern) this);
  }

  [CompilerGenerated]
  [SpecialName]
  public void add_DataChanged(OkCommandWithTwoDataEventHandler value)
  {
    // ISSUE: reference to a compiler-generated field
    OkCommandWithTwoDataEventHandler dataEventHandler = ((F_RectangleShape) this).\u0001;
    OkCommandWithTwoDataEventHandler comparand;
    do
    {
      comparand = dataEventHandler;
      // ISSUE: reference to a compiler-generated field
      dataEventHandler = Interlocked.CompareExchange<OkCommandWithTwoDataEventHandler>(ref ((F_RectangleShape) this).\u0001, comparand + value, comparand);
    }
    while (dataEventHandler != comparand);
  }

  [CompilerGenerated]
  [SpecialName]
  public void remove_DataChanged(OkCommandWithTwoDataEventHandler value)
  {
    // ISSUE: reference to a compiler-generated field
    OkCommandWithTwoDataEventHandler dataEventHandler = ((F_RectangleShape) this).\u0001;
    OkCommandWithTwoDataEventHandler comparand;
    do
    {
      comparand = dataEventHandler;
      // ISSUE: reference to a compiler-generated field
      dataEventHandler = Interlocked.CompareExchange<OkCommandWithTwoDataEventHandler>(ref ((F_RectangleShape) this).\u0001, comparand - value, comparand);
    }
    while (dataEventHandler != comparand);
  }

  [CompilerGenerated]
  [SpecialName]
  public void add_ParameterChanged(OkCommandWithTwoDataEventHandler value)
  {
    // ISSUE: reference to a compiler-generated field
    OkCommandWithTwoDataEventHandler dataEventHandler = ((F_RectangleShape) this).\u0002;
    OkCommandWithTwoDataEventHandler comparand;
    do
    {
      comparand = dataEventHandler;
      // ISSUE: reference to a compiler-generated field
      dataEventHandler = Interlocked.CompareExchange<OkCommandWithTwoDataEventHandler>(ref ((F_RectangleShape) this).\u0002, comparand + value, comparand);
    }
    while (dataEventHandler != comparand);
  }
}
