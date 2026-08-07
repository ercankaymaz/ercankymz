// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Forms.Customer.DincMak.F_RectangleShape
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using buEyeBaseVer5.Forms.Events;
using buEyeBaseVer5.Forms.Foam;
using dummy_ptr;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;

#nullable disable
namespace buEyeBaseVer5.Forms.Customer.DincMak;

public class F_RectangleShape : Form
{
  internal PictureBox \u0003;
  internal PictureBox \u0004;
  internal RadioButton \u0003;
  internal RadioButton \u0004;
  internal ImageList \u0003;
  internal PictureBox \u0005;
  internal RadioButton \u0005;
  public static byte f0031CF;
  public FormProperties PropertiesForm;
  public static List<string> Captions;
  public double Length;
  public double Angle;
  public bool isLeadIn;
  private IContainer \u0001;
  internal ImageList \u0001;
  public Button btn_cancel;
  public Button btn_ok;
  internal ImageList \u0002;
  internal Panel \u0001;
  internal Label \u0001;
  internal NumericUpDown \u0001;
  internal Label \u0002;
  internal NumericUpDown \u0002;
  internal Button \u0001;
  internal Button \u0002;
  internal Button \u0003;
  internal Button \u0004;
  internal Button \u0005;
  internal Button \u0006;
  internal Button \u0007;
  internal Button \u0008;
  internal PictureBox \u0001;
  public static byte f0031E8;
  public FormProperties PropertiesForm;
  public SizeObject FoamSize;

  public void Apply()
  {
  }

  internal void \u0001([In] object obj0, [In] FormClosingEventArgs obj1)
  {
    if (((F_EventAll) this).PropertiesForm.Result == DialogResult.OK)
      return;
    ((F_EventAll) this).foamType = FoamType.SlicesVertical;
    obj1.Cancel = true;
    ((F_EventAll) this).PropertiesForm.Result = DialogResult.Cancel;
    if (((F_EventAll) this).PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
      this.Dispose();
    if (((F_EventAll) this).PropertiesForm.FormCloseMode != FormCloseModeType.Invisible)
      return;
    this.Visible = false;
  }

  internal void \u0001([In] object obj0, [In] EventArgs obj1)
  {
    Control control1 = new Control();
    Control control2 = (Control) obj0;
    if (control2.Name == ((F_EventAll) this).\u0007.Name)
    {
      ((F_EventAll) this).PropertiesForm.Result = DialogResult.OK;
      if (((F_EventAll) this).PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
        this.Dispose();
      if (((F_EventAll) this).PropertiesForm.FormCloseMode == FormCloseModeType.Invisible)
        this.Visible = false;
      ((F_EventAll) this).foamType = FoamType.CForm;
    }
    else if (control2.Name == ((F_EventAll) this).\u0003.Name)
    {
      ((F_EventAll) this).PropertiesForm.Result = DialogResult.OK;
      if (((F_EventAll) this).PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
        this.Dispose();
      if (((F_EventAll) this).PropertiesForm.FormCloseMode == FormCloseModeType.Invisible)
        this.Visible = false;
      ((F_EventAll) this).foamType = FoamType.SForm;
    }
    else if (control2.Name == ((F_EventAll) this).\u0001.Name)
    {
      ((F_EventAll) this).PropertiesForm.Result = DialogResult.OK;
      if (((F_EventAll) this).PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
        this.Dispose();
      if (((F_EventAll) this).PropertiesForm.FormCloseMode == FormCloseModeType.Invisible)
        this.Visible = false;
      ((F_EventAll) this).foamType = FoamType.Pyramid;
    }
    else if (control2.Name == ((F_EventAll) this).\u0002.Name)
    {
      ((F_EventAll) this).PropertiesForm.Result = DialogResult.OK;
      if (((F_EventAll) this).PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
        this.Dispose();
      if (((F_EventAll) this).PropertiesForm.FormCloseMode == FormCloseModeType.Invisible)
        this.Visible = false;
      ((F_EventAll) this).foamType = FoamType.Rectangle;
    }
    else if (control2.Name == ((F_EventAll) this).\u0006.Name)
    {
      ((F_EventAll) this).PropertiesForm.Result = DialogResult.OK;
      if (((F_EventAll) this).PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
        this.Dispose();
      if (((F_EventAll) this).PropertiesForm.FormCloseMode == FormCloseModeType.Invisible)
        this.Visible = false;
      ((F_EventAll) this).foamType = FoamType.SlicesHorizontal;
    }
    else if (control2.Name == ((F_EventAll) this).\u0004.Name)
    {
      ((F_EventAll) this).PropertiesForm.Result = DialogResult.OK;
      if (((F_EventAll) this).PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
        this.Dispose();
      if (((F_EventAll) this).PropertiesForm.FormCloseMode == FormCloseModeType.Invisible)
        this.Visible = false;
      ((F_EventAll) this).foamType = FoamType.VForm;
    }
    else
    {
      if (!(control2.Name == ((F_EventAll) this).\u0005.Name))
        return;
      ((F_EventAll) this).PropertiesForm.Result = DialogResult.OK;
      if (((F_EventAll) this).PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
        this.Dispose();
      if (((F_EventAll) this).PropertiesForm.FormCloseMode == FormCloseModeType.Invisible)
        this.Visible = false;
      ((F_EventAll) this).foamType = FoamType.ZForm;
    }
  }

  protected override void Dispose(bool disposing)
  {
    if ((!disposing ? 0 : (((F_EventAll) this).\u0001 != null ? 1 : 0)) != 0)
      ((F_EventAll) this).\u0001.Dispose();
    base.Dispose(disposing);
  }

  static F_RectangleShape() => F_EventAll.Captions = new List<string>();

  public F_RectangleShape()
  {
    ((F_EventAll) this).PropertiesForm = new FormProperties();
    ((F_EventAll) this).FoamSize = new SizeObject();
    ((F_EventAll) this).ValueChanging = false;
    ((F_EventAll) this).\u0001 = (IContainer) null;
    // ISSUE: explicit constructor call
    base.\u002Ector();
    \u007B0e48b843\u002Dfb72\u002D498c\u002D834d\u002Dfc743ba0facc\u007D.\u0001((F_FoamSlices) this);
  }

  [CompilerGenerated]
  [SpecialName]
  public void add_DataChanged(OkCommandWithTwoDataEventHandler value)
  {
    // ISSUE: reference to a compiler-generated field
    OkCommandWithTwoDataEventHandler dataEventHandler = ((F_EventAll) this).\u0001;
    OkCommandWithTwoDataEventHandler comparand;
    do
    {
      comparand = dataEventHandler;
      // ISSUE: reference to a compiler-generated field
      dataEventHandler = Interlocked.CompareExchange<OkCommandWithTwoDataEventHandler>(ref ((F_EventAll) this).\u0001, comparand + value, comparand);
    }
    while (dataEventHandler != comparand);
  }
}
