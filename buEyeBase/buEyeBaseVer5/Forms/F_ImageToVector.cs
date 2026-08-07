// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Forms.F_ImageToVector
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using buEyeBaseVer5.Apps;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;

#nullable disable
namespace buEyeBaseVer5.Forms;

public class F_ImageToVector : Form
{
  public FormProperties Properties;
  public static List<string> Captions;
  public MoveEventFormVars Settings;
  internal IContainer \u0001;
  public Button btn_cancel;
  internal ImageList \u0001;
  public Button btn_ok;
  internal Label \u0001;
  internal NumericUpDown \u0001;
  internal Label \u0002;
  internal NumericUpDown \u0002;
  internal Label \u0003;
  internal NumericUpDown \u0003;
  internal Panel \u0001;
  internal Panel \u0002;
  internal Label \u0004;
  public Button btn_rightbottom;
  public Button btn_bottom;
  public Button btn_leftbottom;
  public Button btn_right;
  public Button btn_center;
  public Button btn_left;
  public Button btn_righttop;
  public Button btn_top;
  public Button btn_lefttop;
  public Button btn_aligment;
  internal CheckBox \u0001;
  public FormProperties Properties;
  public static List<string> Captions;
  public DevideEventFormVars Settings;
  private IContainer \u0001;
  public Button btn_cancel;
  internal ImageList \u0001;
  public Button btn_ok;
  internal NumericUpDown \u0001;
  internal Panel \u0001;
  internal CheckBox \u0001;

  static F_ImageToVector() => F_DeleteType.Captions = new List<string>();

  public F_ImageToVector()
  {
    ((F_Mirror) this).Notch = (CutterNotch) new buFoamCalc();
    ((F_Mirror) this).PropertiesForm = new FormProperties();
    ((F_Mirror) this).\u0001 = (IContainer) null;
    // ISSUE: explicit constructor call
    base.\u002Ector();
    buCompare5.CultureSettings();
    \u0007.\u0001.\u0001((F_NotchEdit) this);
  }

  internal void \u0001([In] object obj0, [In] EventArgs obj1)
  {
  }

  public void Init()
  {
    // ISSUE: unable to decompile the method.
  }

  public void LoadLanguage()
  {
    string callMethod = "NestRectPartAdd LoadLanguage";
    try
    {
      if (F_Mirror.Captions.Count < 6)
        return;
      this.Text = F_Mirror.Captions[0];
      ((F_Move) this).\u0006.Text = F_Mirror.Captions[1];
      ((F_Move) this).\u0003.Text = F_Mirror.Captions[2];
      ((F_Move) this).\u0008.Text = F_Mirror.Captions[3];
      ((F_Move) this).\u000F.Text = F_Mirror.Captions[4];
      ((F_Move) this).\u0001.Text = F_Mirror.Captions[5];
      ((F_Move) this).\u0002.Text = F_Mirror.Captions[6];
    }
    catch (Exception ex)
    {
      string str = "";
      buLog.addLog(str, "Not Ok", callMethod);
      buException.throwException(ex, callMethod, true, str);
    }
  }

  internal void \u0002([In] object obj0, [In] EventArgs obj1)
  {
    // ISSUE: unable to decompile the method.
  }

  internal void \u0001([In] object obj0, [In] FormClosingEventArgs obj1)
  {
    if (((F_Mirror) this).PropertiesForm.Result == DialogResult.OK)
      return;
    obj1.Cancel = true;
    ((F_Mirror) this).PropertiesForm.Result = DialogResult.Cancel;
    if (((F_Mirror) this).PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
      this.Dispose();
    if (((F_Mirror) this).PropertiesForm.FormCloseMode == FormCloseModeType.Invisible)
      this.Visible = false;
    if (((F_Mirror) this).PropertiesForm.FormCloseMode != FormCloseModeType.Close)
      return;
    this.Close();
  }

  protected override void Dispose(bool disposing)
  {
    if ((!disposing ? 0 : (((F_Mirror) this).\u0001 != null ? 1 : 0)) != 0)
      ((F_Mirror) this).\u0001.Dispose();
    base.Dispose(disposing);
  }

  static F_ImageToVector() => F_Mirror.Captions = new List<string>();

  public F_ImageToVector()
  {
    ((F_Move) this).PropertiesForm = new FormProperties();
    ((F_Move) this).\u0001 = -1;
    ((F_Move) this).\u0002 = -1;
    ((F_Move) this).Result = (AnalyseEntitiesResult) new Pnt6DSimMove();
    ((F_Devide) this).\u0001 = (IContainer) null;
    // ISSUE: explicit constructor call
    base.\u002Ector();
    buCompare5.CultureSettings();
    \u0007.\u0001.\u0001((F_AnalyseResult) this);
  }

  [CompilerGenerated]
  [SpecialName]
  public void add_Selected(OkCommandWithTwoDataEventHandler value)
  {
    // ISSUE: reference to a compiler-generated field
    OkCommandWithTwoDataEventHandler dataEventHandler = ((F_Move) this).\u0001;
    OkCommandWithTwoDataEventHandler comparand;
    do
    {
      comparand = dataEventHandler;
      // ISSUE: reference to a compiler-generated field
      dataEventHandler = Interlocked.CompareExchange<OkCommandWithTwoDataEventHandler>(ref ((F_Move) this).\u0001, comparand + value, comparand);
    }
    while (dataEventHandler != comparand);
  }

  [CompilerGenerated]
  [SpecialName]
  public void remove_Selected(OkCommandWithTwoDataEventHandler value)
  {
    // ISSUE: reference to a compiler-generated field
    OkCommandWithTwoDataEventHandler dataEventHandler = ((F_Move) this).\u0001;
    OkCommandWithTwoDataEventHandler comparand;
    do
    {
      comparand = dataEventHandler;
      // ISSUE: reference to a compiler-generated field
      dataEventHandler = Interlocked.CompareExchange<OkCommandWithTwoDataEventHandler>(ref ((F_Move) this).\u0001, comparand - value, comparand);
    }
    while (dataEventHandler != comparand);
  }
}
