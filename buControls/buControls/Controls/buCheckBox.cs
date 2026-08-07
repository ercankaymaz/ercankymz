// Decompiled with JetBrains decompiler
// Type: buControls.Controls.buCheckBox
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

[DefaultProperty("Text")]
[DefaultEvent("TextChanged")]
[ClassInterface(ClassInterfaceType.AutoDispatch)]
[ComVisible(true)]
[ToolboxBitmap(typeof (Label))]
[DefaultBindingProperty("Text")]
public class buCheckBox : buControl
{
  private buControlCheckTick buControlCheckTick_0 = new buControlCheckTick();
  private bool bool_0 = false;
  private bool bool_1 = false;
  private FlatStyle flatStyle_0;
  private bool bool_2;
  private ThemeType themeType_0 = ThemeType.Standart;
  private rectDraw rectDraw_0 = new rectDraw();
  internal HotkeyPrefix hotkeyPrefix_0 = HotkeyPrefix.None;
  private static object object_0 = new object();
  private static object object_1 = new object();

  public buCheckBox()
  {
    Class39.smethod_77();
    if (this.Parent != null)
      this.BackColor = this.Parent.BackColor;
    this.TabStop = false;
    this.TextAlign = ContentAlignment.MiddleCenter;
    this.Image = (Image) null;
    this.UseMnemonic = true;
    this.ImageList = (ImageList) null;
    this.contentAlignment_1 = ContentAlignment.MiddleCenter;
    Class39.smethod_579(this, this.UseMnemonic);
    this.flatStyle_0 = FlatStyle.Standard;
    this.CheckTick.TickDisplay.Parent = (Control) this;
    this.CheckTick.TickDisplay.BackColor = Color.WhiteSmoke;
    this.CheckTick.Visible = true;
    this.CheckTick.ColorModeDisplay.Parent = (Control) this;
    this.CheckTick.ColorModeDisplay.BackColor = Color.Green;
    this.Display.BackColor = Color.LightGray;
    this.Display.Parent = (Control) this;
    this.Geometry.Parent = (Control) this;
    this.Language.Parent = (Control) this;
    this.Theme.Parent = (Control) this;
    this.CheckTick.Parent = (Control) this;
    this.CheckTick.TickDisplay.Parent = (Control) this;
    this.CheckTick.TickDisplay.BackColor = Color.WhiteSmoke;
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
    add => this.Events.AddHandler(buCheckBox.object_1, (Delegate) value);
    remove => this.Events.RemoveHandler(buCheckBox.object_1, (Delegate) value);
  }

  public event buControlEvents.buCheckedChangedEventHandler CheckedChanged;

  public event buControlEvents.buClickAfterEventHandler ClickAfter;

  [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
  [Browsable(true)]
  public buControlCheckTick CheckTick
  {
    get => this.buControlCheckTick_0;
    set
    {
      this.buControlCheckTick_0 = value;
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
    get => this.bool_2;
    set
    {
      if (this.bool_2 == value)
        return;
      this.bool_2 = value;
      Class39.smethod_579(this, this.bool_2);
      this.Invalidate();
    }
  }

  [DefaultValue(false)]
  [EditorBrowsable(EditorBrowsableState.Always)]
  [NotifyParentProperty(true)]
  [Browsable(true)]
  public bool Check
  {
    get => this.bool_0;
    set
    {
      this.bool_0 = value;
      this.Invalidate();
    }
  }

  [DefaultValue(false)]
  [EditorBrowsable(EditorBrowsableState.Always)]
  [NotifyParentProperty(true)]
  [Browsable(true)]
  public bool ReadOnly
  {
    get => this.bool_1;
    set
    {
      this.bool_1 = value;
      this.Invalidate();
    }
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
      buControlCommands.smethod_0(nameof (buCheckBox));
      if (!buControlCommands.bool_0)
      {
        int num = (int) MessageBox.Show("License Error");
        return;
      }
    }
    if (!this.Enabled)
      return;
    if (!this.ReadOnly)
    {
      this.bool_0 = this.CheckTick.OnlyClickMode || !this.bool_0;
      // ISSUE: reference to a compiler-generated field
      if (this.buCheckedChangedEventHandler_0 != null)
      {
        // ISSUE: reference to a compiler-generated field
        this.buCheckedChangedEventHandler_0((object) this, this.Check);
      }
      // ISSUE: reference to a compiler-generated field
      if (this.buClickAfterEventHandler_0 != null)
      {
        // ISSUE: reference to a compiler-generated field
        this.buClickAfterEventHandler_0((object) this, this.Check);
      }
    }
    this.Invalidate();
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
    EventHandler eventHandler = (EventHandler) this.Events[buCheckBox.object_1];
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
    if (!buControlCommands.bool_0)
    {
      buControlCommands.smethod_0(nameof (buCheckBox));
      if (!buControlCommands.bool_0)
      {
        int num = (int) MessageBox.Show("License Error");
        return;
      }
    }
    if (!this.ReadOnly)
      ;
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

  protected override void OnGotFocus(EventArgs e) => base.OnGotFocus(e);

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

  public static buCheckBox CopyVisual(buCheckBox refCheck, buCheckBox copyCheck)
  {
    copyCheck.Display = buControlDisplay.Copy(refCheck.Display, copyCheck.Display);
    copyCheck.CheckTick.TickDisplay = buControlDisplay.Copy(refCheck.CheckTick.TickDisplay, copyCheck.CheckTick.TickDisplay);
    copyCheck.CheckTick.ColorModeDisplay = buControlDisplay.Copy(refCheck.CheckTick.ColorModeDisplay, copyCheck.CheckTick.ColorModeDisplay);
    copyCheck.CheckTick.ColorModeEnable = refCheck.CheckTick.ColorModeEnable;
    copyCheck.CheckTick.Visible = refCheck.CheckTick.Visible;
    copyCheck.CheckTick.Shape = refCheck.CheckTick.Shape;
    copyCheck.CheckTick.BoxSize = refCheck.CheckTick.BoxSize;
    copyCheck.CheckTick.ArcDiameter = refCheck.CheckTick.ArcDiameter;
    copyCheck.Geometry.Space = refCheck.Geometry.Space;
    copyCheck.Geometry.ArcDiameter = refCheck.Geometry.ArcDiameter;
    copyCheck.Geometry.ShapeMode = refCheck.Geometry.ShapeMode;
    copyCheck.ImageAlign = refCheck.ImageAlign;
    return copyCheck;
  }

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
    RectangleF rect;
    ref RectangleF local2 = ref rect;
    Rectangle clientRectangle2 = this.ClientRectangle;
    double left2 = (double) clientRectangle2.Left;
    clientRectangle2 = this.ClientRectangle;
    double top2 = (double) clientRectangle2.Top;
    clientRectangle2 = this.ClientRectangle;
    double width2 = (double) clientRectangle2.Width;
    clientRectangle2 = this.ClientRectangle;
    double height2 = (double) clientRectangle2.Height;
    local2 = new RectangleF((float) left2, (float) top2, (float) width2, (float) height2);
    Rectangle clientRectangle3 = this.ClientRectangle;
    double left3 = (double) clientRectangle3.Left;
    clientRectangle3 = this.ClientRectangle;
    double top3 = (double) clientRectangle3.Top;
    clientRectangle3 = this.ClientRectangle;
    double width3 = (double) clientRectangle3.Width;
    clientRectangle3 = this.ClientRectangle;
    double height3 = (double) clientRectangle3.Height;
    this.rectDraw_0 = new rectDraw(new RectangleF((float) left3, (float) top3, (float) width3, (float) height3), RoundRectangleType.RoundRectAll);
    Graphics graphics = e.Graphics;
    string Text = ControlGeometry.LanguageSelect(this.Language, text);
    if (this.CheckTick.Visible)
    {
      if (!this.CheckTick.RightSide)
      {
        this.rectDraw_0.RoundType = RoundRectangleType.RoundRectAll;
        this.rectDraw_0.rect.X = (float) ((int) this.Geometry.Space + this.CheckTick.Space);
        this.rectDraw_0.rect.Y = (float) (int) ((double) (this.Height - this.CheckTick.BoxSize) / 2.0);
        this.rectDraw_0.rect.Width = (float) this.CheckTick.BoxSize;
        this.rectDraw_0.rect.Height = (float) this.CheckTick.BoxSize;
        rect.X = (float) ((double) this.rectDraw_0.rect.X + (double) this.rectDraw_0.rect.Width + (double) this.Geometry.Space * 2.0);
        rect.Width = (float) this.Width - rect.X;
      }
      else
      {
        this.rectDraw_0.RoundType = RoundRectangleType.RoundRectAll;
        this.rectDraw_0.rect.X = (float) (this.Width - this.CheckTick.BoxSize - 1 - this.CheckTick.Space);
        this.rectDraw_0.rect.Y = (float) (int) (((double) rect.Height - (double) this.CheckTick.BoxSize) / 2.0);
        this.rectDraw_0.rect.Width = (float) this.CheckTick.BoxSize;
        this.rectDraw_0.rect.Height = (float) this.CheckTick.BoxSize;
        rect.X = 1f + this.Geometry.Space;
        rect.Width = (float) ((double) this.Width - (double) rect.X - (double) this.rectDraw_0.rect.Width - (double) this.CheckTick.Space - 1.0);
      }
    }
    if (this.Theme.Type != this.themeType_0)
    {
      buControlThemeVars Vars = new buControlThemeVars();
      buControlTheme.UpdateTheme(this.Theme.Type, ref Vars);
      this.Geometry = new buControlGeometry(Vars.Geometry);
      this.Display = new buControlDisplay(Vars.Display);
      this.CheckTick.TickDisplay = new buControlDisplay(Vars.DisplayCheckTick);
      this.Display.Parent = (Control) this;
      this.CheckTick.Parent = (Control) this;
      this.CheckTick.TickDisplay.Parent = (Control) this;
    }
    buControlDisplay Display = new buControlDisplay(this.Display);
    if (!this.Enabled)
    {
      Display.GradientType = GradientMode.Solid;
      Display.BackColor = Display.DisableColor;
    }
    if (!this.CheckTick.ColorModeEnable)
      ControlGeometry.drawGeometry((RectangleF) this.ClientRectangle, this.Geometry, Display, RoundRectangleType.RoundRectAll, ref graphics);
    else if (this.Check)
      ControlGeometry.drawGeometry((RectangleF) this.ClientRectangle, this.Geometry, this.CheckTick.ColorModeDisplay, RoundRectangleType.RoundRectAll, ref graphics);
    else
      ControlGeometry.drawGeometry((RectangleF) this.ClientRectangle, this.Geometry, Display, RoundRectangleType.RoundRectAll, ref graphics);
    ControlGeometry.drawString(rect, Text, Display, this.hotkeyPrefix_0, ref graphics);
    if (this.CheckTick.Visible)
    {
      ControlGeometry.drawGeometry(this.rectDraw_0.rect, this.CheckTick.ArcDiameter, this.CheckTick.Shape, this.CheckTick.TickDisplay, this.rectDraw_0.RoundType, ref graphics);
      if (this.Check)
        graphics.DrawString("ü", new Font("Wingdings", (float) Convert.ToInt32((double) this.CheckTick.BoxSize * 1.5)), (Brush) new SolidBrush(this.CheckTick.TickDisplay.Fonts.ForeColor), new RectangleF(this.rectDraw_0.rect.X - 8f, this.rectDraw_0.rect.Y, this.rectDraw_0.rect.Width + 15f, this.rectDraw_0.rect.Height), new StringFormat()
        {
          LineAlignment = StringAlignment.Center
        });
    }
    Rectangle r;
    ref Rectangle local3 = ref r;
    int x = this.ClientRectangle.X + this.ImageBorderOffset;
    Rectangle clientRectangle4 = this.ClientRectangle;
    int y = clientRectangle4.Y + this.ImageBorderOffset;
    clientRectangle4 = this.ClientRectangle;
    int width4 = clientRectangle4.Width - this.ImageBorderOffset * 2;
    int height4 = this.ClientRectangle.Height - this.ImageBorderOffset * 2;
    local3 = new Rectangle(x, y, width4, height4);
    this.DrawImage(e.Graphics, this.Image, r, this.ImageAlign);
    this.themeType_0 = this.Theme.Type;
    base.OnPaint(e);
  }

  [SettingsBindable(true)]
  public override string Text
  {
    get => base.Text;
    set
    {
      if (this.Security.Enable && this.Security.Level < buControl.SecurityActive)
        return;
      base.Text = value;
    }
  }
}
