// Decompiled with JetBrains decompiler
// Type: buMarble.Forms.F_MarbleVideoPlayer
// Assembly: buMarble, Version=5.1.1.2, Culture=neutral, PublicKeyToken=null
// MVID: D6F2AAC2-9013-4D8E-A4D2-15511BAB107F
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buMarble.dll

using \u0005;
using Basler.Pylon;
using buClass;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

#nullable disable
namespace buMarble.Forms;

public class F_MarbleVideoPlayer : Form
{
  public static Action \u003C\u003E9__92_0;
  public static byte f0002E9;
  public int CameraNumber = 0;
  public static bool isCameraStarted;
  private Basler.Pylon.Camera \u0001;
  internal PixelDataConverter \u0001 = new PixelDataConverter();
  private bool \u0001 = false;
  public Color SpinBaseColor;

  public void DestroyCamera()
  {
    if (this.\u0001 == null)
      return;
    this.\u0001.Close();
    this.\u0001.Dispose();
    this.\u0001 = (Basler.Pylon.Camera) null;
  }

  public F_MarbleVideoPlayer()
  {
  }

  [MethodImpl(MethodCodeType = MethodCodeType.Runtime)]
  public extern F_MarbleVideoPlayer(object @object, IntPtr method);

  [MethodImpl(MethodCodeType = MethodCodeType.Runtime)]
  public virtual extern void Invoke(Bitmap bmp);

  [MethodImpl(MethodCodeType = MethodCodeType.Runtime)]
  public virtual extern IAsyncResult BeginInvoke(
    Bitmap bmp,
    AsyncCallback callback,
    object @object);

  [MethodImpl(MethodCodeType = MethodCodeType.Runtime)]
  public virtual extern void EndInvoke(IAsyncResult result);

  public F_MarbleVideoPlayer()
  {
    ((F_MarbleCalculators) this).SpinFocusColor = Color.MistyRose;
    ((F_MarbleCalculators) this).PropertiesForm = new FormProperties();
    ((F_MarbleCalculators) this).SelectedTab = 0;
    ((F_MarbleCalculators) this).\u0001 = (IContainer) null;
    // ISSUE: explicit constructor call
    base.\u002Ector();
    \u0003.\u0001(this);
  }

  public void Init()
  {
    ((F_MarbleCalculators) this).PropertiesForm.Inited = false;
    if (((F_MarbleCalculators) this).PropertiesForm.Height > 10)
      this.Height = ((F_MarbleCalculators) this).PropertiesForm.Height;
    if (((F_MarbleCalculators) this).PropertiesForm.Width > 10)
      this.Width = ((F_MarbleCalculators) this).PropertiesForm.Width;
    this.TopMost = ((F_MarbleCalculators) this).PropertiesForm.TopMost;
    this.StartPosition = ((F_MarbleCalculators) this).PropertiesForm.FormPosition;
    this.LoadLanguage();
    ((F_MarbleCalculators) this).MenuButtonColors(((F_MarbleCalculators) this).SelectedTab);
    ((F_MarbleCalculators) this).PropertiesForm.Result = DialogResult.None;
    ((F_MarbleCalculators) this).PropertiesForm.Inited = true;
  }

  public void LoadLanguage()
  {
    try
    {
      ((F_MarbleCalculators) this).\u0001.Text = buLangTranslate.preDef.Calculate;
    }
    catch (Exception ex)
    {
    }
  }
}
