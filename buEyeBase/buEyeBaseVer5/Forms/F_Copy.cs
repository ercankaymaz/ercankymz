// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Forms.F_Copy
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using buEyeBaseVer5.Apps;
using buEyeBaseVer5.Events;
using devDept.Eyeshot;
using devDept.Eyeshot.Control;
using devDept.Eyeshot.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Windows.Forms;

#nullable disable
namespace buEyeBaseVer5.Forms;

public class F_Copy : Form
{
  public NumericUpDown spn_intersectiongap;
  internal Label \u0005;
  public static byte f000B16;
  public FormProperties PropertiesForm;
  public List<Entity> Entities;
  public LayerKeyedCollection Layers;
  public static List<string> Captions;
  public Design viewportPort;
  private int \u0001;
  internal IContainer \u0001;
  public DataGridView DGV_entitiesprops;
  internal Panel \u0001;
  internal ImageList \u0001;
  internal Button \u0001;
  internal ListBox \u0001;
  public static byte f000B23;
  public FormProperties Properties;
  public static List<string> Captions;
  public DeleteTypeEventFormVars Settings;
  internal IContainer \u0001;
  public Button btn_cancel;
  internal ImageList \u0001;
  public Button btn_ok;
  internal CheckBox \u0001;
  internal CheckBox \u0002;
  internal CheckBox \u0003;
  internal CheckBox \u0004;

  public abstract void m000970();

  [MethodImpl(MethodCodeType = MethodCodeType.Runtime)]
  public extern F_Copy(object @object, IntPtr method);

  [MethodImpl(MethodCodeType = MethodCodeType.Runtime)]
  public virtual extern void Invoke(DrawingFinisedEventArgs Data);

  [MethodImpl(MethodCodeType = MethodCodeType.Runtime)]
  public virtual extern IAsyncResult BeginInvoke(
    DrawingFinisedEventArgs Data,
    AsyncCallback callback,
    object @object);

  [MethodImpl(MethodCodeType = MethodCodeType.Runtime)]
  public virtual extern void EndInvoke(IAsyncResult result);

  public F_Copy()
  {
    ((F_DeleteType) this).DrawingIndex = -1;
    ((F_DeleteType) this).FinshedEntity = (Entity) null;
    // ISSUE: explicit constructor call
    base.\u002Ector();
  }

  internal F_Copy()
  {
  }

  public F_Copy()
  {
    ((F_DeleteType) this).Settings = (CutterProgramSettings) new buFoamCalc();
    ((F_DeleteType) this).PropertiesForm = new FormProperties();
    ((F_DeleteType) this).\u0001 = (IContainer) null;
    // ISSUE: explicit constructor call
    base.\u002Ector();
    buCompare5.CultureSettings();
    \u0007.\u0001.\u0001((F_CutterMachineSettings) this);
  }

  internal void \u0001([In] object obj0, [In] EventArgs obj1)
  {
  }

  public void Init()
  {
    ((F_DeleteType) this).PropertiesForm.Inited = false;
    if (((F_DeleteType) this).PropertiesForm.Height > 10)
      this.Height = ((F_DeleteType) this).PropertiesForm.Height;
    if (((F_DeleteType) this).PropertiesForm.Width > 10)
      this.Width = ((F_DeleteType) this).PropertiesForm.Width;
    this.TopMost = ((F_DeleteType) this).PropertiesForm.TopMost;
    this.StartPosition = ((F_DeleteType) this).PropertiesForm.FormPosition;
    ((F_DeleteType) this).\u0001.Value = (Decimal) ((Printer3DSettings) ((F_DeleteType) this).Settings).DrillAuxDaimeterValue;
    ((F_DeleteType) this).\u0002.Value = (Decimal) ((Printer3DSettings) ((F_DeleteType) this).Settings).DrillMainDaimeterValue;
    this.LoadLanguage();
    ((F_DeleteType) this).PropertiesForm.Inited = true;
  }

  public void LoadLanguage()
  {
    string callMethod = "NestRectPartAdd LoadLanguage";
    try
    {
      if (F_DeleteType.Captions.Count < 4)
        return;
      this.Text = F_DeleteType.Captions[0];
      ((F_DeleteType) this).\u0003.Text = F_DeleteType.Captions[1];
      ((F_DeleteType) this).\u0002.Text = F_DeleteType.Captions[2];
      ((F_DeleteType) this).\u0001.Text = F_DeleteType.Captions[3];
      ((F_DeleteType) this).\u0002.Text = F_DeleteType.Captions[4];
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
    System.Windows.Forms.Control control1 = new System.Windows.Forms.Control();
    System.Windows.Forms.Control control2 = (System.Windows.Forms.Control) obj0;
    if (control2.Name == ((F_DeleteType) this).\u0001.Name)
    {
      ((Printer3DSettings) ((F_DeleteType) this).Settings).DrillAuxDaimeterValue = (double) ((F_DeleteType) this).\u0001.Value;
      ((Printer3DSettings) ((F_DeleteType) this).Settings).DrillMainDaimeterValue = (double) ((F_DeleteType) this).\u0002.Value;
      ((F_DeleteType) this).PropertiesForm.Result = DialogResult.OK;
      if (((F_DeleteType) this).PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
        this.Dispose();
      if (((F_DeleteType) this).PropertiesForm.FormCloseMode == FormCloseModeType.Close)
        this.Close();
      if (((F_DeleteType) this).PropertiesForm.FormCloseMode == FormCloseModeType.Invisible)
        this.Visible = false;
    }
    if (!(control2.Name == ((F_DeleteType) this).\u0002.Name))
      return;
    if (((F_DeleteType) this).PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
      this.Dispose();
    if (((F_DeleteType) this).PropertiesForm.FormCloseMode == FormCloseModeType.Close)
      this.Close();
    if (((F_DeleteType) this).PropertiesForm.FormCloseMode != FormCloseModeType.Invisible)
      return;
    this.Visible = false;
  }

  internal void \u0001([In] object obj0, [In] FormClosingEventArgs obj1)
  {
    if (((F_DeleteType) this).PropertiesForm.Result == DialogResult.OK)
      return;
    obj1.Cancel = true;
    ((F_DeleteType) this).PropertiesForm.Result = DialogResult.Cancel;
    if (((F_DeleteType) this).PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
      this.Dispose();
    if (((F_DeleteType) this).PropertiesForm.FormCloseMode == FormCloseModeType.Invisible)
      this.Visible = false;
    if (((F_DeleteType) this).PropertiesForm.FormCloseMode != FormCloseModeType.Close)
      return;
    this.Close();
  }

  public event OkCommandWithDataEventHandler CommandOk;

  public event CancelCommandEventHandler CommandCancel;

  public event ApplyCommandWithDataEventHandler CommandApply;
}
