// Decompiled with JetBrains decompiler
// Type: buControls.Controls.buGroup
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
[DefaultEvent("Click")]
[ClassInterface(ClassInterfaceType.AutoDispatch)]
[ComVisible(true)]
[ToolboxBitmap(typeof (Label))]
[DefaultBindingProperty("Text")]
public class buGroup : buContainerControl
{
  private buControlDisplay buControlDisplay_1 = new buControlDisplay();
  private buControlLanguage buControlLanguage_0 = new buControlLanguage();
  private int int_2 = 25;
  private bool bool_0;
  private ThemeType themeType_0 = ThemeType.Standart;
  internal HotkeyPrefix hotkeyPrefix_0 = HotkeyPrefix.None;
  private string string_1;
  private static object object_0 = new object();
  private static object object_1 = new object();

  public buGroup()
  {
    Class39.smethod_438();
    this.TabStop = false;
    this.TextAlign = ContentAlignment.MiddleCenter;
    this.Image = (Image) null;
    this.UseMnemonic = true;
    this.ImageList = (ImageList) null;
    this.contentAlignment_1 = ContentAlignment.MiddleCenter;
    this.TitleDisplay.BackColor = Color.Gray;
    Class39.smethod_523(this, this.UseMnemonic);
    this.Display.Parent = (Control) this;
    this.Geometry.Parent = (Control) this;
    this.TitleDisplay.Parent = (Control) this;
    this.Language.Parent = (Control) this;
    this.Theme.Parent = (Control) this;
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
    add => this.Events.AddHandler(buGroup.object_1, (Delegate) value);
    remove => this.Events.RemoveHandler(buGroup.object_1, (Delegate) value);
  }

  [EditorBrowsable(EditorBrowsableState.Always)]
  [DefaultValue("")]
  [NotifyParentProperty(true)]
  [Browsable(true)]
  public string AuxInfo
  {
    get => this.string_1;
    set
    {
      this.string_1 = value;
      if (this.Parent == null)
        return;
      this.Parent.Invalidate();
    }
  }

  [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
  [Browsable(true)]
  public buControlLanguage Language
  {
    get => this.buControlLanguage_0;
    set
    {
      this.buControlLanguage_0 = value;
      if (this.Parent == null)
        return;
      this.Parent.Invalidate();
    }
  }

  [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
  [Browsable(true)]
  public buControlDisplay TitleDisplay
  {
    get => this.buControlDisplay_1;
    set
    {
      this.buControlDisplay_1 = value;
      if (this.Parent != null)
        this.Parent.Invalidate();
      this.Invalidate();
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

  [EditorBrowsable(EditorBrowsableState.Always)]
  [DefaultValue(25)]
  [NotifyParentProperty(true)]
  [Browsable(true)]
  public int TitleHeight
  {
    get => this.int_2;
    set
    {
      this.int_2 = value;
      if (this.Parent != null)
        this.Parent.Invalidate();
      this.Invalidate();
    }
  }

  [SettingsBindable(true)]
  public override string Text
  {
    get => base.Text;
    set => base.Text = value;
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
      Class39.smethod_523(this, this.bool_0);
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
    EventHandler eventHandler = (EventHandler) this.Events[buGroup.object_1];
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
    ref RectangleF local = ref rectangleF;
    Rectangle clientRectangle1 = this.ClientRectangle;
    double left1 = (double) clientRectangle1.Left;
    clientRectangle1 = this.ClientRectangle;
    double top1 = (double) clientRectangle1.Top;
    clientRectangle1 = this.ClientRectangle;
    double width1 = (double) clientRectangle1.Width;
    clientRectangle1 = this.ClientRectangle;
    double height = (double) clientRectangle1.Height;
    local = new RectangleF((float) left1, (float) top1, (float) width1, (float) height);
    Rectangle clientRectangle2 = this.ClientRectangle;
    double left2 = (double) clientRectangle2.Left;
    clientRectangle2 = this.ClientRectangle;
    double top2 = (double) clientRectangle2.Top;
    clientRectangle2 = this.ClientRectangle;
    double width2 = (double) clientRectangle2.Width;
    double titleHeight1 = (double) this.TitleHeight;
    rectDraw rectDraw = new rectDraw(new RectangleF((float) left2, (float) top2, (float) width2, (float) titleHeight1), RoundRectangleType.RoundRectAll);
    Graphics graphics1 = e.Graphics;
    if (this.Theme.Type != this.themeType_0)
    {
      buControlThemeVars Vars = new buControlThemeVars();
      buControlTheme.UpdateTheme(this.Theme.Type, ref Vars);
      this.Geometry = new buControlGeometry(Vars.Geometry);
      this.Display = new buControlDisplay(Vars.Display);
      this.TitleDisplay = new buControlDisplay(Vars.DisplayGroupTitle);
      this.Display.Parent = (Control) this;
      this.Geometry.Parent = (Control) this;
      this.Theme.Parent = (Control) this;
      this.TitleDisplay.Parent = (Control) this;
      this.Language.Parent = (Control) this;
    }
    string Text = ControlGeometry.LanguageSelect(this.Language, text);
    if (this.Width > 0 & this.Height > 0)
    {
      if (this.Image != null)
        rectDraw.rectText = ControlGeometry.GetTextRectangleFromImage(this.Image, this.ImageAlign, rectDraw.rectText, this.Geometry, this.ImageBorderOffset);
      if (this.Enabled)
      {
        ControlGeometry.drawGeometry((RectangleF) this.ClientRectangle, this.Geometry.ArcDiameter, this.Geometry.ShapeMode, this.Display, RoundRectangleType.RoundRectAll, ref graphics1);
        ControlGeometry.drawGeometry(rectDraw.rect, this.Geometry.ArcDiameter, this.Geometry.ShapeMode, this.TitleDisplay, RoundRectangleType.RoundRectDown, ref graphics1);
        ControlGeometry.drawString(rectDraw.rectText, Text, this.TitleDisplay, this.hotkeyPrefix_0, ref graphics1);
      }
      else
        ControlPaint.DrawStringDisabled(e.Graphics, this.Text, this.Font, this.BackColor, rectDraw.rect, ControlGeometry.AlignmentToStringFormat(this.TitleDisplay.Fonts.Alignment));
      Graphics graphics2 = e.Graphics;
      Image image = this.Image;
      Rectangle clientRectangle3 = this.ClientRectangle;
      int left3 = clientRectangle3.Left;
      clientRectangle3 = this.ClientRectangle;
      int top3 = clientRectangle3.Top;
      clientRectangle3 = this.ClientRectangle;
      int width3 = clientRectangle3.Width;
      int titleHeight2 = this.TitleHeight;
      Rectangle r = new Rectangle(left3, top3, width3, titleHeight2);
      int imageAlign = (int) this.ImageAlign;
      this.DrawImage(graphics2, image, r, (ContentAlignment) imageAlign);
    }
    this.themeType_0 = this.Theme.Type;
    base.OnPaint(e);
  }

  public static buGroup CopyVisual(buGroup refGroup, buGroup copyGroup)
  {
    copyGroup.Display = buControlDisplay.Copy(refGroup.Display, copyGroup.Display);
    copyGroup.TitleDisplay = buControlDisplay.Copy(refGroup.TitleDisplay, copyGroup.TitleDisplay);
    copyGroup.Geometry.Space = refGroup.Geometry.Space;
    copyGroup.Geometry.ArcDiameter = refGroup.Geometry.ArcDiameter;
    copyGroup.Geometry.ShapeMode = refGroup.Geometry.ShapeMode;
    copyGroup.TitleHeight = refGroup.TitleHeight;
    copyGroup.ImageAlign = refGroup.ImageAlign;
    return copyGroup;
  }
}
