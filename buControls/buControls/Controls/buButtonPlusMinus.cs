// Decompiled with JetBrains decompiler
// Type: buControls.Controls.buButtonPlusMinus
// Assembly: buControls, Version=5.1.1.4, Culture=neutral, PublicKeyToken=null
// MVID: 8B369C0A-23E7-45ED-9051-267DACDF7858
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buControls.dll

using ns7;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Text;
using System.Windows.Forms;

#nullable disable
namespace buControls.Controls;

[DefaultEvent("Click")]
public class buButtonPlusMinus : buControl
{
  private buControlDisplay buControlDisplay_1 = new buControlDisplay();
  private buControlDisplay buControlDisplay_2 = new buControlDisplay();
  private buControlDisplay buControlDisplay_3 = new buControlDisplay();
  private buControlDisplay buControlDisplay_4 = new buControlDisplay();
  private buControlDisplay buControlDisplay_5 = new buControlDisplay();
  private buControlDisplay buControlDisplay_6 = new buControlDisplay();
  private PlusMinusButtonStyle plusMinusButtonStyle_0 = PlusMinusButtonStyle.Horizontal;
  private FlatStyle flatStyle_0;
  private bool bool_0;
  private ThemeType themeType_0 = ThemeType.Standart;
  private MouseState mouseState_0;
  private MouseState mouseState_1;
  private int int_3 = 0;
  internal HotkeyPrefix hotkeyPrefix_0 = HotkeyPrefix.None;
  private static object object_0 = new object();
  private static object object_1 = new object();

  public buButtonPlusMinus()
  {
    Class39.smethod_839();
    this.Display.Parent = (Control) this;
    this.Display.Parent = (Control) this;
    this.ButtonPlusDownDisplay.Parent = (Control) this;
    this.ButtonPlusNormalDisplay.Parent = (Control) this;
    this.ButtonPlusOverDisplay.Parent = (Control) this;
    this.ButtonMinusDownDisplay.Parent = (Control) this;
    this.ButtonMinusNormalDisplay.Parent = (Control) this;
    this.ButtonMinusOverDisplay.Parent = (Control) this;
    this.Display.Parent = (Control) this;
    this.ButtonPlusDownDisplay.BackColor = Color.DimGray;
    this.ButtonPlusNormalDisplay.BackColor = Color.LightGray;
    this.ButtonPlusOverDisplay.BackColor = Color.Gray;
    this.ButtonMinusDownDisplay.BackColor = Color.DimGray;
    this.ButtonMinusNormalDisplay.BackColor = Color.LightGray;
    this.ButtonMinusOverDisplay.BackColor = Color.Gray;
    this.Geometry.Parent = (Control) this;
    this.Language.Parent = (Control) this;
    this.Theme.Parent = (Control) this;
    this.TabStop = false;
    this.TextAlign = ContentAlignment.MiddleCenter;
    this.UseMnemonic = true;
    this.Image = (Image) null;
    this.ImageList = (ImageList) null;
    this.ImageAlign = ContentAlignment.MiddleLeft;
    Class39.smethod_151(this.UseMnemonic, this);
    this.flatStyle_0 = FlatStyle.Standard;
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
    add => this.Events.AddHandler(buButtonPlusMinus.object_1, (Delegate) value);
    remove => this.Events.RemoveHandler(buButtonPlusMinus.object_1, (Delegate) value);
  }

  public event MouseEventHandler MouseDownWithWndProc;

  public event MouseEventHandler MouseUpWithWndProc;

  public event buControlEvents.buButtonPlusMinusClickEventHandler ClickPlusMinus;

  public event buControlEvents.buButtonPlusMinusMouseEventHandler MouseDownPlusMinus;

  public event buControlEvents.buButtonPlusMinusMouseEventHandler MouseUpPlusMinus;

  public event buControlEvents.buButtonPlusMinusMouseEventHandler MouseMovePlusMinus;

  [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
  [Browsable(true)]
  public buControlDisplay ButtonPlusOverDisplay
  {
    get => this.buControlDisplay_1;
    set
    {
      this.buControlDisplay_1 = value;
      if (this.Parent == null)
        return;
      this.Parent.Invalidate();
    }
  }

  [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
  [Browsable(true)]
  public buControlDisplay ButtonPlusNormalDisplay
  {
    get => this.buControlDisplay_2;
    set
    {
      this.buControlDisplay_2 = value;
      if (this.Parent == null)
        return;
      this.Parent.Invalidate();
    }
  }

  [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
  [Browsable(true)]
  public buControlDisplay ButtonPlusDownDisplay
  {
    get => this.buControlDisplay_3;
    set
    {
      this.buControlDisplay_3 = value;
      if (this.Parent == null)
        return;
      this.Parent.Invalidate();
    }
  }

  [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
  [Browsable(true)]
  public buControlDisplay ButtonMinusOverDisplay
  {
    get => this.buControlDisplay_4;
    set
    {
      this.buControlDisplay_4 = value;
      if (this.Parent == null)
        return;
      this.Parent.Invalidate();
    }
  }

  [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
  [Browsable(true)]
  public buControlDisplay ButtonMinusNormalDisplay
  {
    get => this.buControlDisplay_5;
    set
    {
      this.buControlDisplay_5 = value;
      if (this.Parent == null)
        return;
      this.Parent.Invalidate();
    }
  }

  [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
  [Browsable(true)]
  public buControlDisplay ButtonMinusDownDisplay
  {
    get => this.buControlDisplay_6;
    set
    {
      this.buControlDisplay_6 = value;
      if (this.Parent == null)
        return;
      this.Parent.Invalidate();
    }
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

  [DefaultValue(PlusMinusButtonStyle.Horizontal)]
  public PlusMinusButtonStyle ButtonStyle
  {
    get => this.plusMinusButtonStyle_0;
    set
    {
      this.plusMinusButtonStyle_0 = value;
      if (this.Parent != null)
        this.Parent.Invalidate();
      this.Invalidate();
    }
  }

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

  [DefaultValue(true)]
  public bool UseMnemonic
  {
    get => this.bool_0;
    set
    {
      if (this.bool_0 == value)
        return;
      this.bool_0 = value;
      Class39.smethod_151(this.bool_0, this);
      this.Invalidate();
    }
  }

  [SettingsBindable(true)]
  public override string Text
  {
    get => base.Text;
    set => base.Text = value;
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
    if (this.Security.Enable && this.Security.Level < buControl.SecurityActive)
    {
      int num = (int) MessageBox.Show("You Level Not Enought This Operation", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
    }
    else
    {
      // ISSUE: reference to a compiler-generated field
      if (this.buButtonPlusMinusClickEventHandler_0 != null)
      {
        // ISSUE: reference to a compiler-generated field
        this.buButtonPlusMinusClickEventHandler_0((object) this, this.int_3);
      }
      base.OnClick(e);
    }
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
    EventHandler eventHandler = (EventHandler) this.Events[buButtonPlusMinus.object_1];
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
    this.mouseState_0 = MouseState.None;
    this.mouseState_1 = MouseState.None;
    // ISSUE: reference to a compiler-generated field
    if (this.buButtonPlusMinusMouseEventHandler_1 != null)
    {
      // ISSUE: reference to a compiler-generated field
      this.buButtonPlusMinusMouseEventHandler_1((object) this, e, this.int_3);
    }
    this.Invalidate();
    base.OnMouseUp(e);
  }

  protected override void OnMouseDown(MouseEventArgs e)
  {
    Rectangle clientRectangle;
    if (this.ButtonStyle == PlusMinusButtonStyle.Horizontal)
    {
      int x1 = e.X;
      clientRectangle = this.ClientRectangle;
      int left = clientRectangle.Left;
      int num1 = x1 > left ? 1 : 0;
      int x2 = e.X;
      clientRectangle = this.ClientRectangle;
      int num2 = clientRectangle.Width / 2;
      int num3 = x2 < num2 ? 1 : 0;
      if ((num1 & num3) != 0)
      {
        this.mouseState_1 = MouseState.Down;
        this.mouseState_0 = MouseState.None;
        this.int_3 = -1;
      }
      else
      {
        this.mouseState_1 = MouseState.None;
        this.mouseState_0 = MouseState.Down;
        this.int_3 = 1;
      }
    }
    if (this.ButtonStyle == PlusMinusButtonStyle.Vertical)
    {
      int y1 = e.Y;
      clientRectangle = this.ClientRectangle;
      int top = clientRectangle.Top;
      int num4 = y1 > top ? 1 : 0;
      int y2 = e.Y;
      clientRectangle = this.ClientRectangle;
      int num5 = clientRectangle.Height / 2;
      int num6 = y2 < num5 ? 1 : 0;
      if ((num4 & num6) != 0)
      {
        this.mouseState_1 = MouseState.None;
        this.mouseState_0 = MouseState.Down;
        this.int_3 = 1;
      }
      else
      {
        this.mouseState_1 = MouseState.Down;
        this.mouseState_0 = MouseState.None;
        this.int_3 = -1;
      }
    }
    // ISSUE: reference to a compiler-generated field
    if (this.buButtonPlusMinusMouseEventHandler_0 != null)
    {
      // ISSUE: reference to a compiler-generated field
      this.buButtonPlusMinusMouseEventHandler_0((object) this, e, this.int_3);
    }
    this.Invalidate();
    base.OnMouseDown(e);
  }

  protected override void OnMouseMove(MouseEventArgs e)
  {
    this.Cursor = Cursors.Default;
    if (this.ButtonStyle == PlusMinusButtonStyle.Horizontal)
    {
      if (e.X > this.ClientRectangle.Left & e.X < this.ClientRectangle.Width / 2)
      {
        this.mouseState_1 = MouseState.Move;
        this.mouseState_0 = MouseState.None;
        this.int_3 = -1;
      }
      else
      {
        this.mouseState_1 = MouseState.None;
        this.mouseState_0 = MouseState.Move;
        this.int_3 = 1;
      }
    }
    if (this.ButtonStyle == PlusMinusButtonStyle.Vertical)
    {
      if (e.Y > this.ClientRectangle.Top & e.Y < this.ClientRectangle.Height / 2)
      {
        this.mouseState_1 = MouseState.None;
        this.mouseState_0 = MouseState.Move;
        this.int_3 = 1;
      }
      else
      {
        this.mouseState_1 = MouseState.Move;
        this.mouseState_0 = MouseState.None;
        this.int_3 = -1;
      }
    }
    // ISSUE: reference to a compiler-generated field
    if (this.buButtonPlusMinusMouseEventHandler_2 != null)
    {
      // ISSUE: reference to a compiler-generated field
      this.buButtonPlusMinusMouseEventHandler_2((object) this, e, this.int_3);
    }
    this.Invalidate();
    base.OnMouseMove(e);
  }

  protected override void OnMouseEnter(EventArgs e) => base.OnMouseEnter(e);

  protected override void OnMouseLeave(EventArgs e)
  {
    this.mouseState_0 = MouseState.None;
    this.mouseState_1 = MouseState.None;
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

  protected override void WndProc(ref Message m)
  {
    // ISSUE: reference to a compiler-generated field
    if (m.Msg == 513 && this.mouseEventHandler_0 != null)
    {
      // ISSUE: reference to a compiler-generated field
      this.mouseEventHandler_0((object) this, new MouseEventArgs(MouseButtons.Left, 1, 0, 0, 0));
    }
    // ISSUE: reference to a compiler-generated field
    if (m.Msg == 514 && this.mouseEventHandler_1 != null)
    {
      // ISSUE: reference to a compiler-generated field
      this.mouseEventHandler_1((object) this, new MouseEventArgs(MouseButtons.Left, 1, 0, 0, 0));
    }
    base.WndProc(ref m);
  }

  public override string ToString() => $"{base.ToString()}, Text: {this.Text}";

  protected override void OnPaint(PaintEventArgs e)
  {
    string text = this.Text;
    RectangleF rect1;
    ref RectangleF local1 = ref rect1;
    Rectangle clientRectangle1 = this.ClientRectangle;
    double left1 = (double) clientRectangle1.Left;
    clientRectangle1 = this.ClientRectangle;
    double top1 = (double) clientRectangle1.Top;
    clientRectangle1 = this.ClientRectangle;
    double width1 = (double) clientRectangle1.Width;
    clientRectangle1 = this.ClientRectangle;
    double height1 = (double) clientRectangle1.Height;
    local1 = new RectangleF((float) left1, (float) top1, (float) width1, (float) height1);
    RectangleF rect2;
    ref RectangleF local2 = ref rect2;
    Rectangle clientRectangle2 = this.ClientRectangle;
    double left2 = (double) clientRectangle2.Left;
    clientRectangle2 = this.ClientRectangle;
    double top2 = (double) clientRectangle2.Top;
    clientRectangle2 = this.ClientRectangle;
    double width2 = (double) clientRectangle2.Width;
    clientRectangle2 = this.ClientRectangle;
    double height2 = (double) clientRectangle2.Height;
    local2 = new RectangleF((float) left2, (float) top2, (float) width2, (float) height2);
    RectangleF layoutRectangle;
    ref RectangleF local3 = ref layoutRectangle;
    Rectangle clientRectangle3 = this.ClientRectangle;
    double left3 = (double) clientRectangle3.Left;
    clientRectangle3 = this.ClientRectangle;
    double top3 = (double) clientRectangle3.Top;
    clientRectangle3 = this.ClientRectangle;
    double width3 = (double) clientRectangle3.Width;
    clientRectangle3 = this.ClientRectangle;
    double height3 = (double) clientRectangle3.Height;
    local3 = new RectangleF((float) left3, (float) top3, (float) width3, (float) height3);
    Graphics graphics = e.Graphics;
    if (this.Theme.Type != this.themeType_0)
    {
      buControlThemeVars Vars = new buControlThemeVars();
      buControlTheme.UpdateTheme(this.Theme.Type, ref Vars);
      this.Geometry = new buControlGeometry(Vars.Geometry);
      this.Display = new buControlDisplay(Vars.Display);
      this.ButtonPlusDownDisplay = new buControlDisplay(Vars.DisplayButtonDown);
      this.ButtonPlusNormalDisplay = new buControlDisplay(Vars.DisplayButtonNormal);
      this.ButtonPlusOverDisplay = new buControlDisplay(Vars.DisplayButtonOver);
      this.ButtonMinusDownDisplay = new buControlDisplay(Vars.DisplayButton2Down);
      this.ButtonMinusNormalDisplay = new buControlDisplay(Vars.DisplayButton2Normal);
      this.ButtonMinusOverDisplay = new buControlDisplay(Vars.DisplayButton2Over);
      this.Display.Parent = (Control) this;
      this.ButtonPlusDownDisplay.Parent = (Control) this;
      this.ButtonPlusNormalDisplay.Parent = (Control) this;
      this.ButtonPlusOverDisplay.Parent = (Control) this;
      this.ButtonMinusDownDisplay.Parent = (Control) this;
      this.ButtonMinusNormalDisplay.Parent = (Control) this;
      this.ButtonMinusOverDisplay.Parent = (Control) this;
    }
    Rectangle clientRectangle4;
    if (this.ButtonStyle == PlusMinusButtonStyle.Horizontal)
    {
      rect2 = new RectangleF((float) this.ClientRectangle.Left, (float) this.ClientRectangle.Top, (float) this.ClientRectangle.Width / 2f, (float) this.ClientRectangle.Height);
      ref RectangleF local4 = ref rect1;
      clientRectangle4 = this.ClientRectangle;
      double x = (double) clientRectangle4.Width / 2.0;
      clientRectangle4 = this.ClientRectangle;
      double top4 = (double) clientRectangle4.Top;
      clientRectangle4 = this.ClientRectangle;
      double width4 = (double) clientRectangle4.Width / 2.0;
      clientRectangle4 = this.ClientRectangle;
      double height4 = (double) clientRectangle4.Height;
      local4 = new RectangleF((float) x, (float) top4, (float) width4, (float) height4);
    }
    if (this.ButtonStyle == PlusMinusButtonStyle.Vertical)
    {
      ref RectangleF local5 = ref rect2;
      clientRectangle4 = this.ClientRectangle;
      double left4 = (double) clientRectangle4.Left;
      clientRectangle4 = this.ClientRectangle;
      double y = (double) clientRectangle4.Height / 2.0;
      clientRectangle4 = this.ClientRectangle;
      double width5 = (double) clientRectangle4.Width;
      clientRectangle4 = this.ClientRectangle;
      double height5 = (double) clientRectangle4.Height / 2.0;
      local5 = new RectangleF((float) left4, (float) y, (float) width5, (float) height5);
      ref RectangleF local6 = ref rect1;
      clientRectangle4 = this.ClientRectangle;
      double left5 = (double) clientRectangle4.Left;
      clientRectangle4 = this.ClientRectangle;
      double top5 = (double) clientRectangle4.Top;
      clientRectangle4 = this.ClientRectangle;
      double width6 = (double) clientRectangle4.Width;
      clientRectangle4 = this.ClientRectangle;
      double height6 = (double) clientRectangle4.Height / 2.0;
      local6 = new RectangleF((float) left5, (float) top5, (float) width6, (float) height6);
    }
    buControlDisplay Display1 = new buControlDisplay(this.ButtonPlusNormalDisplay);
    if (this.mouseState_0 == MouseState.Move)
      Display1 = new buControlDisplay(this.ButtonPlusOverDisplay);
    if (this.mouseState_0 == MouseState.Down)
      Display1 = new buControlDisplay(this.ButtonPlusDownDisplay);
    buControlDisplay Display2 = new buControlDisplay(this.ButtonMinusNormalDisplay);
    if (this.mouseState_1 == MouseState.Move)
      Display2 = new buControlDisplay(this.ButtonMinusOverDisplay);
    if (this.mouseState_1 == MouseState.Down)
      Display2 = new buControlDisplay(this.ButtonMinusDownDisplay);
    if (this.Enabled)
    {
      ControlGeometry.drawGeometry(rect1, this.Geometry.ArcDiameter, this.Geometry.ShapeMode, Display1, RoundRectangleType.RoundRectAll, ref graphics);
      ControlGeometry.drawString(rect1, "+", Display1, this.hotkeyPrefix_0, ref graphics);
      ControlGeometry.drawGeometry(rect2, this.Geometry.ArcDiameter, this.Geometry.ShapeMode, Display2, RoundRectangleType.RoundRectAll, ref graphics);
      ControlGeometry.drawString(rect2, "-", Display2, this.hotkeyPrefix_0, ref graphics);
    }
    else
      ControlPaint.DrawStringDisabled(e.Graphics, text, Display1.Fonts.Font, Display1.Fonts.ForeColor, layoutRectangle, ControlGeometry.AlignmentToStringFormat(Display2.Fonts.Alignment));
    this.DrawImage(e.Graphics, this.Image, this.ClientRectangle, this.ImageAlign);
    this.themeType_0 = this.Theme.Type;
    base.OnPaint(e);
  }
}
