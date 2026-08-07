// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Forms.Viewport.F_ViewportMouseCfg
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using buEyeBaseVer5.Apps;
using devDept.Eyeshot.Control;
using devDept.Eyeshot.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

#nullable disable
namespace buEyeBaseVer5.Forms.Viewport;

public class F_ViewportMouseCfg : Form
{
  public Button btn_ok;
  internal ComboBox \u0002;
  internal Label \u0004;
  internal Label \u0005;
  internal NumericUpDown \u0002;
  internal Panel \u0002;
  internal NumericUpDown \u0003;
  internal Label \u0006;
  internal NumericUpDown \u0004;
  internal Label \u0007;
  internal Label \u0008;
  public static byte f001091;
  public static List<string> Captions;
  public FormProperties PropertiesForm;
  public List<ToolBase5> Tools;
  public ToolBase5 SelectedTool;
  private IContainer \u0001;
  internal ImageList \u0001;
  public Button btn_cancel;
  public Button btn_ok;
  internal ListView \u0001;
  internal TextBox \u0001;
  public FormProperties PropertiesForm;
  public static List<string> Captions;
  public TuftingSequenceItem TuftSequence;
  public List<Entity> AllEntities;
  public LayerBase5 layerSelected;
  private Design \u0001;
  private Color \u0001;
  private int \u0001;
  private int \u0002;
  private int \u0003;
  private int \u0004;
  private Timer \u0001;
  private IContainer \u0001;
  internal Button \u0001;

  [MethodImpl(MethodCodeType = MethodCodeType.Runtime)]
  public extern F_ViewportMouseCfg(object @object, IntPtr method);

  [MethodImpl(MethodCodeType = MethodCodeType.Runtime)]
  public virtual extern void Invoke();

  [MethodImpl(MethodCodeType = MethodCodeType.Runtime)]
  public virtual extern IAsyncResult BeginInvoke(AsyncCallback callback, object @object);

  [MethodImpl(MethodCodeType = MethodCodeType.Runtime)]
  public virtual extern void EndInvoke(IAsyncResult result);

  [MethodImpl(MethodCodeType = MethodCodeType.Runtime)]
  public extern F_ViewportMouseCfg(object @object, IntPtr method);

  [MethodImpl(MethodCodeType = MethodCodeType.Runtime)]
  public virtual extern void Invoke();

  [MethodImpl(MethodCodeType = MethodCodeType.Runtime)]
  public virtual extern IAsyncResult BeginInvoke(AsyncCallback callback, object @object);

  [MethodImpl(MethodCodeType = MethodCodeType.Runtime)]
  public virtual extern void EndInvoke(IAsyncResult result);
}
