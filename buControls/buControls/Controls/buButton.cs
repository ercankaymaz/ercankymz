// Decompiled with JetBrains decompiler
// Type: buControls.Controls.buButton
// Assembly: buControls, Version=5.1.1.4, Culture=neutral, PublicKeyToken=null
// MVID: 8B369C0A-23E7-45ED-9051-267DACDF7858
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buControls.dll

using ns7;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Text;
using System.Runtime.InteropServices;
using System.Windows.Forms;

#nullable disable
namespace buControls.Controls;

[ClassInterface(ClassInterfaceType.AutoDispatch)]
[ComVisible(true)]
public class buButton : buButtonBase
{
  private FlatStyle flatStyle_0;
  private bool bool_1;
  private MouseState mouseState_0;
  internal HotkeyPrefix hotkeyPrefix_0 = HotkeyPrefix.None;
  private ThemeType themeType_0 = ThemeType.Standart;
  private static object object_0 = new object();
  private static object object_1 = new object();

  public buButton()
  {
    Class39.smethod_281();
    this.Display.Parent = (Control) this;
    this.ButtonDownDisplay.Parent = (Control) this;
    this.ButtonOverDisplay.Parent = (Control) this;
    this.ButtonOverDisplay.BackColor = Color.Gray;
    this.ButtonDownDisplay.BackColor = Color.DimGray;
    this.Geometry.Parent = (Control) this;
    this.Language.Parent = (Control) this;
    this.Theme.Parent = (Control) this;
    this.TabStop = false;
    this.TextAlign = ContentAlignment.MiddleCenter;
    this.Image = (Image) null;
    this.ImageList = (ImageList) null;
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
    add => this.Events.AddHandler(buButton.object_1, (Delegate) value);
    remove => this.Events.RemoveHandler(buButton.object_1, (Delegate) value);
  }

  public event MouseEventHandler MouseDownWithWndProc;

  public event MouseEventHandler MouseUpWithWndProc;

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

  [DefaultValue(true)]
  public bool UseMnemonic
  {
    get => this.bool_1;
    set
    {
      if (this.bool_1 == value)
        return;
      this.bool_1 = value;
      Class39.smethod_193(this.bool_1, this);
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
    if (!buControlCommands.bool_0)
    {
      buControlCommands.smethod_0(nameof (buButton));
      if (!buControlCommands.bool_0)
      {
        int num = (int) MessageBox.Show("License Error");
        return;
      }
    }
    if (!this.Enabled)
      return;
    if (this.Security.Enable && this.Security.Level < buControl.SecurityActive)
    {
      int num1 = (int) MessageBox.Show("You Level Not Enought This Operation", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
    }
    else
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
    EventHandler eventHandler = (EventHandler) this.Events[buButton.object_1];
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
    this.Invalidate();
    base.OnMouseUp(e);
  }

  protected override void OnMouseDown(MouseEventArgs e)
  {
    if (!buControlCommands.bool_0)
    {
      buControlCommands.smethod_0(nameof (buButton));
      if (!buControlCommands.bool_0)
      {
        int num = (int) MessageBox.Show("License Error");
        return;
      }
    }
    this.mouseState_0 = MouseState.Down;
    this.Invalidate();
    base.OnMouseDown(e);
  }

  protected override void OnMouseMove(MouseEventArgs e)
  {
    this.Cursor = Cursors.Default;
    this.mouseState_0 = MouseState.Move;
    this.Invalidate();
    base.OnMouseMove(e);
  }

  protected override void OnMouseEnter(EventArgs e) => base.OnMouseEnter(e);

  protected override void OnMouseLeave(EventArgs e)
  {
    this.mouseState_0 = MouseState.None;
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

  public static buButton CopyVisual(buButton refButton, buButton copyButton)
  {
    copyButton.Display = buControlDisplay.Copy(refButton.Display, copyButton.Display);
    copyButton.ButtonDownDisplay = buControlDisplay.Copy(refButton.ButtonDownDisplay, copyButton.ButtonDownDisplay);
    copyButton.ButtonOverDisplay = buControlDisplay.Copy(refButton.ButtonOverDisplay, copyButton.ButtonOverDisplay);
    copyButton.Geometry.Space = refButton.Geometry.Space;
    copyButton.Geometry.ArcDiameter = refButton.Geometry.ArcDiameter;
    copyButton.Geometry.ShapeMode = refButton.Geometry.ShapeMode;
    copyButton.ImageAlign = refButton.ImageAlign;
    return copyButton;
  }

  protected override void OnPaint(PaintEventArgs e)
  {
    try
    {
      string text = this.Text;
      RectangleF ControlSize;
      ref RectangleF local1 = ref ControlSize;
      Rectangle clientRectangle1 = this.ClientRectangle;
      double left1 = (double) clientRectangle1.Left;
      clientRectangle1 = this.ClientRectangle;
      double top1 = (double) clientRectangle1.Top;
      clientRectangle1 = this.ClientRectangle;
      double width1 = (double) clientRectangle1.Width;
      clientRectangle1 = this.ClientRectangle;
      double height1 = (double) clientRectangle1.Height;
      local1 = new RectangleF((float) left1, (float) top1, (float) width1, (float) height1);
      RectangleF rectangleFromImage;
      ref RectangleF local2 = ref rectangleFromImage;
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
        this.ButtonOverDisplay = new buControlDisplay(Vars.DisplayButtonOver);
        this.ButtonDownDisplay = new buControlDisplay(Vars.DisplayButtonDown);
        this.Display.Parent = (Control) this;
        this.ButtonOverDisplay.Parent = (Control) this;
        this.ButtonDownDisplay.Parent = (Control) this;
      }
      buControlDisplay Display = new buControlDisplay(this.Display);
      if (this.mouseState_0 == MouseState.Move)
        Display = new buControlDisplay(this.ButtonOverDisplay);
      if (this.mouseState_0 == MouseState.Down)
        Display = new buControlDisplay(this.ButtonDownDisplay);
      string str = ControlGeometry.LanguageSelect(this.Language, text);
      if (this.Width > 0 & this.Height > 0)
      {
        if (this.Image != null)
          rectangleFromImage = ControlGeometry.GetTextRectangleFromImage(this.Image, this.ImageAlign, ControlSize, this.Geometry, this.ImageBorderOffset);
        if (this.Enabled)
          ControlGeometry.drawGeometry((RectangleF) this.ClientRectangle, this.Geometry, Display, RoundRectangleType.RoundRectAll, ref graphics);
        else
          ControlPaint.DrawStringDisabled(e.Graphics, str, Display.Fonts.Font, Display.Fonts.ForeColor, rectangleFromImage, ControlGeometry.AlignmentToStringFormat(Display.Fonts.Alignment));
        Rectangle r;
        ref Rectangle local3 = ref r;
        Rectangle clientRectangle3 = this.ClientRectangle;
        int x = clientRectangle3.X + this.ImageBorderOffset;
        clientRectangle3 = this.ClientRectangle;
        int y = clientRectangle3.Y + this.ImageBorderOffset;
        clientRectangle3 = this.ClientRectangle;
        int width3 = clientRectangle3.Width - this.ImageBorderOffset * 2;
        clientRectangle3 = this.ClientRectangle;
        int height3 = clientRectangle3.Height - this.ImageBorderOffset * 2;
        local3 = new Rectangle(x, y, width3, height3);
        this.DrawImage(e.Graphics, this.Image, r, this.ImageAlign);
        if (this.FontAngle != 0)
          ControlGeometry.drawString(rectangleFromImage, str, (float) this.FontAngle, Display, this.hotkeyPrefix_0, ref graphics);
        else
          ControlGeometry.drawString(rectangleFromImage, str, Display, this.hotkeyPrefix_0, ref graphics);
        this.themeType_0 = this.Theme.Type;
      }
      base.OnPaint(e);
    }
    catch (Exception ex)
    {
    }
  }
}
