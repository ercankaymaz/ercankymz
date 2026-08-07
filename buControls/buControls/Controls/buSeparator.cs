// Decompiled with JetBrains decompiler
// Type: buControls.Controls.buSeparator
// Assembly: buControls, Version=5.1.1.4, Culture=neutral, PublicKeyToken=null
// MVID: 8B369C0A-23E7-45ED-9051-267DACDF7858
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buControls.dll

using ns7;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

#nullable disable
namespace buControls.Controls;

[DefaultProperty("Display")]
[DefaultEvent("Click")]
[ClassInterface(ClassInterfaceType.AutoDispatch)]
[ComVisible(true)]
[ToolboxBitmap(typeof (Label))]
public class buSeparator : buControl
{
  private FlatStyle flatStyle_0;
  private ThemeType themeType_0 = ThemeType.Standart;
  private static object object_0 = new object();
  private static object object_1 = new object();

  public buSeparator()
  {
    Class39.smethod_507();
    this.TabStop = false;
    this.TextAlign = ContentAlignment.MiddleCenter;
    this.Image = (Image) null;
    this.ImageList = (ImageList) null;
    this.ImageAlign = ContentAlignment.MiddleLeft;
    this.flatStyle_0 = FlatStyle.Standard;
    this.Display.Parent = (Control) this;
    this.Geometry.Parent = (Control) this;
    this.Theme.Parent = (Control) this;
    this.Display.BackColor = Color.Black;
    this.SetStyle(ControlStyles.Selectable, false);
    this.SetStyle(ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.SupportsTransparentBackColor | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
  }

  [Browsable(false)]
  [EditorBrowsable(EditorBrowsableState.Never)]
  public new event EventHandler BackgroundImageChanged
  {
    add => base.BackgroundImageChanged += value;
    remove => base.BackgroundImageChanged -= value;
  }

  [Browsable(false)]
  [EditorBrowsable(EditorBrowsableState.Never)]
  public new event EventHandler BackgroundImageLayoutChanged
  {
    add => base.BackgroundImageLayoutChanged += value;
    remove => base.BackgroundImageLayoutChanged -= value;
  }

  [Browsable(false)]
  [EditorBrowsable(EditorBrowsableState.Never)]
  public new event EventHandler ImeModeChanged
  {
    add => base.ImeModeChanged += value;
    remove => base.ImeModeChanged -= value;
  }

  [Browsable(false)]
  [EditorBrowsable(EditorBrowsableState.Never)]
  public new event KeyEventHandler KeyDown
  {
    add => base.KeyDown += value;
    remove => base.KeyDown -= value;
  }

  [Browsable(false)]
  [EditorBrowsable(EditorBrowsableState.Never)]
  public new event KeyPressEventHandler KeyPress
  {
    add => base.KeyPress += value;
    remove => base.KeyPress -= value;
  }

  [Browsable(false)]
  [EditorBrowsable(EditorBrowsableState.Never)]
  public new event KeyEventHandler KeyUp
  {
    add => base.KeyUp += value;
    remove => base.KeyUp -= value;
  }

  [Browsable(false)]
  [EditorBrowsable(EditorBrowsableState.Never)]
  public new event EventHandler TabStopChanged
  {
    add => base.TabStopChanged += value;
    remove => base.TabStopChanged -= value;
  }

  public event EventHandler TextAlignChanged
  {
    add => this.Events.AddHandler(buSeparator.object_1, (Delegate) value);
    remove => this.Events.RemoveHandler(buSeparator.object_1, (Delegate) value);
  }

  [Browsable(false)]
  [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
  [EditorBrowsable(EditorBrowsableState.Never)]
  public override Image BackgroundImage
  {
    get => base.BackgroundImage;
    set
    {
      base.BackgroundImage = value;
      this.Invalidate();
    }
  }

  [Browsable(false)]
  [EditorBrowsable(EditorBrowsableState.Never)]
  public override ImageLayout BackgroundImageLayout
  {
    get => base.BackgroundImageLayout;
    set => base.BackgroundImageLayout = value;
  }

  protected override ImeMode DefaultImeMode => ImeMode.Disable;

  protected override Padding DefaultMargin => new Padding(3, 0, 3, 0);

  [DefaultValue(FlatStyle.Standard)]
  public FlatStyle FlatStyle
  {
    get => this.flatStyle_0;
    set
    {
      if (!Enum.IsDefined(typeof (FlatStyle), (object) value))
        throw new InvalidEnumArgumentException($"Enum argument value '{value}' is not valid for FlatStyle");
      if (this.flatStyle_0 == value)
        return;
      this.flatStyle_0 = value;
      if (this.Parent != null)
        this.Parent.PerformLayout((Control) this, nameof (FlatStyle));
      this.Invalidate();
    }
  }

  [Browsable(false)]
  [EditorBrowsable(EditorBrowsableState.Never)]
  public new ImeMode ImeMode
  {
    get => base.ImeMode;
    set => base.ImeMode = value;
  }

  [Browsable(false)]
  [DefaultValue(false)]
  [EditorBrowsable(EditorBrowsableState.Never)]
  public new bool TabStop
  {
    get => base.TabStop;
    set => base.TabStop = value;
  }

  protected override AccessibleObject CreateAccessibilityInstance()
  {
    return base.CreateAccessibilityInstance();
  }

  protected override void Dispose(bool disposing) => base.Dispose(disposing);

  protected override void OnClick(EventArgs e)
  {
    if (!this.Enabled)
      return;
    base.OnClick(e);
  }

  protected override void OnEnabledChanged(EventArgs e) => base.OnEnabledChanged(e);

  protected override void OnFontChanged(EventArgs e)
  {
    base.OnFontChanged(e);
    this.Invalidate();
  }

  protected override void OnPaddingChanged(EventArgs e) => base.OnPaddingChanged(e);

  protected override void OnParentChanged(EventArgs e) => base.OnParentChanged(e);

  protected override void OnRightToLeftChanged(EventArgs e) => base.OnRightToLeftChanged(e);

  protected virtual void OnTextAlignChanged(EventArgs e)
  {
    EventHandler eventHandler = (EventHandler) this.Events[buSeparator.object_1];
    if (eventHandler == null)
      return;
    eventHandler((object) this, e);
  }

  protected override void OnTextChanged(EventArgs e)
  {
    base.OnTextChanged(e);
    this.Invalidate();
  }

  protected override void OnVisibleChanged(EventArgs e) => base.OnVisibleChanged(e);

  protected override void OnMouseUp(MouseEventArgs e)
  {
    this.Invalidate();
    base.OnMouseUp(e);
  }

  protected override void OnMouseDown(MouseEventArgs e)
  {
    this.Invalidate();
    base.OnMouseDown(e);
  }

  protected override void OnMouseMove(MouseEventArgs e)
  {
    this.Cursor = Cursors.Default;
    this.Invalidate();
    base.OnMouseMove(e);
  }

  protected override void OnMouseEnter(EventArgs e) => base.OnMouseEnter(e);

  protected override void OnMouseLeave(EventArgs e)
  {
    base.OnMouseLeave(e);
    this.Invalidate();
  }

  protected override void OnHandleDestroyed(EventArgs e) => base.OnHandleDestroyed(e);

  protected override bool ProcessMnemonic(char charCode)
  {
    bool flag;
    if (Control.IsMnemonic(charCode, this.Text))
    {
      if (this.Parent != null)
        this.Parent.SelectNextControl((Control) this, true, false, false, false);
      flag = true;
    }
    else
      flag = base.ProcessMnemonic(charCode);
    return flag;
  }

  protected override void SetBoundsCore(
    int x,
    int y,
    int width,
    int height,
    BoundsSpecified specified)
  {
    base.SetBoundsCore(x, y, width, height, specified);
  }

  public override string ToString() => $"{base.ToString()}, Text: {this.Text}";

  protected override void OnPaint(PaintEventArgs e)
  {
    string text = this.Text;
    RectangleF rectangleF;
    ref RectangleF local1 = ref rectangleF;
    Rectangle clientRectangle1 = this.ClientRectangle;
    double left1 = (double) clientRectangle1.Left;
    clientRectangle1 = this.ClientRectangle;
    double top1 = (double) clientRectangle1.Top;
    clientRectangle1 = this.ClientRectangle;
    double width1 = (double) clientRectangle1.Width;
    clientRectangle1 = this.ClientRectangle;
    double height1 = (double) clientRectangle1.Height;
    local1 = new RectangleF((float) left1, (float) top1, (float) width1, (float) height1);
    RectangleF layoutRectangle;
    ref RectangleF local2 = ref layoutRectangle;
    Rectangle clientRectangle2 = this.ClientRectangle;
    double left2 = (double) clientRectangle2.Left;
    clientRectangle2 = this.ClientRectangle;
    double top2 = (double) clientRectangle2.Top;
    clientRectangle2 = this.ClientRectangle;
    double width2 = (double) clientRectangle2.Width;
    clientRectangle2 = this.ClientRectangle;
    double height2 = (double) clientRectangle2.Height;
    local2 = new RectangleF((float) left2, (float) top2, (float) width2, (float) height2);
    Graphics graphics = e.Graphics;
    if (this.Theme.Type != this.themeType_0)
    {
      buControlThemeVars Vars = new buControlThemeVars();
      buControlTheme.UpdateTheme(this.Theme.Type, ref Vars);
      this.Geometry = new buControlGeometry(Vars.Geometry);
      this.Display = new buControlDisplay(Vars.Display);
      this.Display.Parent = (Control) this;
    }
    if (this.Width > 0 & this.Height > 0)
    {
      if (this.Enabled)
        ControlGeometry.drawGeometry((RectangleF) this.ClientRectangle, this.Geometry, this.Display, RoundRectangleType.RoundRectAll, ref graphics);
      else
        ControlPaint.DrawStringDisabled(e.Graphics, this.Text, this.Font, this.BackColor, layoutRectangle, ControlGeometry.AlignmentToStringFormat(this.Display.Fonts.Alignment));
    }
    this.themeType_0 = this.Theme.Type;
    base.OnPaint(e);
  }
}
