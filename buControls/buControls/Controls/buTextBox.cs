// Decompiled with JetBrains decompiler
// Type: buControls.Controls.buTextBox
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
public class buTextBox : buCaptionBaseControl
{
  private bool bool_0 = false;
  private bool bool_1 = false;
  private int int_3 = 32000;
  private ScrollBars scrollBars_0 = ScrollBars.None;
  private bool bool_2 = true;
  private bool bool_3 = false;
  private char char_0 = char.MinValue;
  private FlatStyle flatStyle_0;
  private bool bool_4;
  private bool bool_5 = false;
  internal RectangleF rectangleF_0 = new RectangleF();
  private rectDraw rectDraw_0 = new rectDraw();
  private rectDraw rectDraw_1 = new rectDraw();
  private rectDraw rectDraw_2 = new rectDraw();
  internal bool bool_6 = false;
  private ThemeType themeType_0 = ThemeType.Standart;
  internal HotkeyPrefix hotkeyPrefix_0 = HotkeyPrefix.None;
  public TextBox txt = new TextBox();
  private static object object_0 = new object();
  private static object object_1 = new object();

  public buTextBox()
  {
    Class39.smethod_608();
    if (this.Parent != null)
      this.BackColor = this.Parent.BackColor;
    this.TabStop = false;
    this.TextAlign = ContentAlignment.MiddleCenter;
    this.Image = (Image) null;
    this.UseMnemonic = true;
    this.ImageList = (ImageList) null;
    this.ImageAlign = ContentAlignment.MiddleCenter;
    Class39.smethod_802(this.UseMnemonic, this);
    this.flatStyle_0 = FlatStyle.Standard;
    this.Display.BackColor = Color.WhiteSmoke;
    this.Display.Parent = (Control) this;
    this.Geometry.Parent = (Control) this;
    this.Language.Parent = (Control) this;
    this.Caption.Parent = (Control) this;
    this.Caption.Display.Parent = (Control) this;
    this.Unit.Parent = (Control) this;
    this.Unit.Display.Parent = (Control) this;
    this.Theme.Parent = (Control) this;
    this.Aux.Parent = (Control) this;
    this.CheckTick.Parent = (Control) this;
    this.CheckTick.TickDisplay.Parent = (Control) this;
    this.CheckTick.ColorModeDisplay.Parent = (Control) this;
    this.FocusControl.Parent = (Control) this;
    this.CheckTick.TickDisplay.BackColor = Color.WhiteSmoke;
    Class39.smethod_423(this);
    this.txt.KeyPress += new KeyPressEventHandler(this.txt_KeyPress);
    this.txt.KeyDown += new KeyEventHandler(this.txt_KeyDown);
    this.txt.KeyUp += new KeyEventHandler(this.txt_KeyUp);
    this.txt.TextChanged += new EventHandler(this.txt_TextChanged);
    this.txt.Enter += new EventHandler(this.txt_Enter);
    this.txt.Leave += new EventHandler(this.txt_Leave);
    this.txt.Click += new EventHandler(this.txt_Click);
    this.txt.DoubleClick += new EventHandler(this.txt_DoubleClick);
    this.Controls.Add((Control) this.txt);
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
  public new event EventHandler TabStopChanged
  {
    add => base.TabStopChanged += value;
    remove => base.TabStopChanged -= value;
  }

  public event EventHandler TextAlignChanged
  {
    add => this.Events.AddHandler(buTextBox.object_1, (Delegate) value);
    remove => this.Events.RemoveHandler(buTextBox.object_1, (Delegate) value);
  }

  public event buControlEvents.buCheckedChangedEventHandler CheckedChanged;

  public event buControlEvents.buClickAfterEventHandler ClickAfter;

  public event KeyEventHandler TextKeyDown;

  public event buControlEvents.buTextChangedEvent TextEditChanged;

  public event EventHandler ValueClicked;

  public event EventHandler ValueDoubleClicked;

  public event EventHandler CaptionClicked;

  [SettingsBindable(true)]
  public override string Text
  {
    get => base.Text;
    set
    {
      if (this.Security.Enable && this.Security.Level < buControl.SecurityActive)
        return;
      this.txt.Text = value;
      base.Text = value;
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
    get => this.bool_4;
    set
    {
      if (this.bool_4 == value)
        return;
      this.bool_4 = value;
      Class39.smethod_802(this.bool_4, this);
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
    get => this.bool_3;
    set
    {
      this.bool_3 = value;
      this.txt.ReadOnly = this.bool_3;
      this.Invalidate();
    }
  }

  [DefaultValue(true)]
  [EditorBrowsable(EditorBrowsableState.Always)]
  [NotifyParentProperty(true)]
  [Browsable(true)]
  public int MaxLength
  {
    get => this.int_3;
    set
    {
      this.int_3 = value;
      this.txt.MaxLength = this.MaxLength;
      this.Invalidate();
    }
  }

  [DefaultValue(ScrollBars.None)]
  [EditorBrowsable(EditorBrowsableState.Always)]
  [NotifyParentProperty(true)]
  [Browsable(true)]
  public ScrollBars ScrollBar
  {
    get => this.scrollBars_0;
    set
    {
      this.scrollBars_0 = value;
      this.txt.ScrollBars = this.scrollBars_0;
      this.Invalidate();
    }
  }

  [DefaultValue(true)]
  [EditorBrowsable(EditorBrowsableState.Always)]
  [NotifyParentProperty(true)]
  [Browsable(true)]
  public bool WordWrap
  {
    get => this.bool_2;
    set
    {
      this.bool_2 = value;
      this.txt.WordWrap = this.bool_2;
      this.Invalidate();
    }
  }

  [DefaultValue('\0')]
  [EditorBrowsable(EditorBrowsableState.Always)]
  [NotifyParentProperty(true)]
  [Browsable(true)]
  public char PasswordChar
  {
    get => this.char_0;
    set
    {
      this.char_0 = value;
      this.txt.PasswordChar = this.char_0;
      this.Invalidate();
    }
  }

  [DefaultValue(false)]
  [EditorBrowsable(EditorBrowsableState.Always)]
  [NotifyParentProperty(true)]
  [Browsable(true)]
  public bool Multiline
  {
    get => this.bool_1;
    set
    {
      this.bool_1 = value;
      if (this.txt != null)
        this.txt.Multiline = value;
      Class39.smethod_423(this);
    }
  }

  public void SelectAll()
  {
    this.txt.SelectAll();
    this.txt.Focus();
  }

  public void CursorToEnd()
  {
    this.txt.SelectionStart = this.txt.Text.Length;
    this.txt.SelectionLength = 0;
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
      buControlCommands.smethod_0(nameof (buTextBox));
      if (!buControlCommands.bool_0)
      {
        int num = (int) MessageBox.Show("License Error");
        return;
      }
    }
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
    EventHandler eventHandler = (EventHandler) this.Events[buTextBox.object_1];
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
      buControlCommands.smethod_0(nameof (buTextBox));
      if (!buControlCommands.bool_0)
      {
        int num = (int) MessageBox.Show("License Error");
        return;
      }
    }
    if (!this.ReadOnly)
    {
      if ((double) e.X >= (double) this.rectDraw_0.rect.X & (double) e.X <= (double) this.rectDraw_0.rect.X + (double) this.rectDraw_0.rect.Width && (double) e.Y >= (double) this.rectDraw_0.rect.Y & (double) e.Y <= (double) this.rectDraw_0.rect.Y + (double) this.rectDraw_0.rect.Height)
      {
        this.Check = !this.Check;
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
      // ISSUE: reference to a compiler-generated field
      if ((double) e.X >= (double) this.rectDraw_2.rect.X & (double) e.X <= (double) this.rectDraw_2.rect.X + (double) this.rectDraw_2.rect.Width && (double) e.Y >= (double) this.rectDraw_2.rect.Y & (double) e.Y <= (double) this.rectDraw_2.rect.Y + (double) this.rectDraw_2.rect.Height && this.eventHandler_2 != null)
      {
        // ISSUE: reference to a compiler-generated field
        this.eventHandler_2((object) this, new EventArgs());
      }
    }
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

  protected override void OnGotFocus(EventArgs e)
  {
    this.txt.Focus();
    base.OnGotFocus(e);
  }

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

  private void txt_KeyPress(object sender, KeyPressEventArgs e)
  {
    if (e.KeyChar == '\r')
      ;
    this.OnKeyPress(e);
  }

  private void txt_KeyUp(object sender, KeyEventArgs e) => this.OnKeyUp(e);

  private void txt_KeyDown(object sender, KeyEventArgs e)
  {
    if (e.KeyCode == Keys.Return)
      ;
    // ISSUE: reference to a compiler-generated field
    if (this.keyEventHandler_0 != null)
    {
      // ISSUE: reference to a compiler-generated field
      this.keyEventHandler_0((object) this, e);
    }
    this.OnKeyDown(e);
  }

  private void txt_Enter(object sender, EventArgs e) => this.Invalidate();

  private void txt_Leave(object sender, EventArgs e)
  {
    this.bool_6 = false;
    this.Invalidate();
  }

  private void txt_Click(object sender, EventArgs e)
  {
    this.bool_6 = true;
    // ISSUE: reference to a compiler-generated field
    if (this.eventHandler_0 != null)
    {
      // ISSUE: reference to a compiler-generated field
      this.eventHandler_0((object) this, e);
    }
    this.Invalidate();
    this.OnClick(e);
  }

  private void txt_DoubleClick(object sender, EventArgs e)
  {
    if (!buControlCommands.bool_0)
    {
      buControlCommands.smethod_0(nameof (buTextBox));
      if (!buControlCommands.bool_0)
      {
        int num = (int) MessageBox.Show("License Error");
        return;
      }
    }
    // ISSUE: reference to a compiler-generated field
    if (this.eventHandler_1 != null)
    {
      // ISSUE: reference to a compiler-generated field
      this.eventHandler_1((object) this, e);
    }
    this.OnDoubleClick(e);
  }

  private void txt_TextChanged(object sender, EventArgs e)
  {
    this.Text = this.txt.Text;
    // ISSUE: reference to a compiler-generated field
    if (this.buTextChangedEvent_0 == null)
      return;
    // ISSUE: reference to a compiler-generated field
    this.buTextChangedEvent_0((object) this, this.txt.Text);
  }

  public static buTextBox CopyVisual(buTextBox refText, buTextBox copyText)
  {
    copyText.Display = buControlDisplay.Copy(refText.Display, copyText.Display);
    copyText.Caption.Display = buControlDisplay.Copy(refText.Caption.Display, copyText.Caption.Display);
    copyText.Geometry.Space = refText.Geometry.Space;
    copyText.Geometry.ArcDiameter = refText.Geometry.ArcDiameter;
    copyText.Geometry.ShapeMode = refText.Geometry.ShapeMode;
    copyText.ImageAlign = refText.ImageAlign;
    return copyText;
  }

  protected override void OnPaint(PaintEventArgs e)
  {
    string caption = this.Caption.Caption;
    Graphics graphics = e.Graphics;
    if (this.Theme.Type != this.themeType_0)
    {
      buControlThemeVars Vars = new buControlThemeVars();
      buControlTheme.UpdateTheme(this.Theme.Type, ref Vars);
      this.Geometry = new buControlGeometry(Vars.Geometry);
      this.Display = new buControlDisplay(Vars.DisplayText);
      this.Caption.Display = new buControlDisplay(Vars.Caption.Display);
      this.Caption.Parent = (Control) this;
      this.Caption.Display.Parent = (Control) this;
      this.Display.Parent = (Control) this;
      this.CheckTick.Parent = (Control) this;
      this.CheckTick.ColorModeDisplay.Parent = (Control) this;
      this.CheckTick.TickDisplay.Parent = (Control) this;
      this.Language.Parent = (Control) this;
      this.Theme.Parent = (Control) this;
      this.Unit.Parent = (Control) this;
      this.Unit.Display.Parent = (Control) this;
      this.Aux.Parent = (Control) this;
      this.FocusControl.Parent = (Control) this;
    }
    buControlDisplay Display = new buControlDisplay(this.Display);
    if (this.Enabled & this.bool_6 & this.FocusControl.Enable)
    {
      Display.BackColor = this.FocusControl.FocusColor;
      Display.GradientType = GradientMode.Solid;
    }
    string Text = ControlGeometry.LanguageSelect(this.Language, caption);
    this.bool_5 = false;
    if (this.Width > 0 & this.Height > 0)
    {
      ControlGeometry.CalcMainArea((float) this.Width, (float) this.Height, this.Geometry, this.Caption, ref this.rectDraw_2, ref this.rectangleF_0);
      Class39.smethod_423(this);
      if (!this.Enabled)
      {
        Display.GradientType = GradientMode.Solid;
        Display.BackColor = Display.DisableColor;
      }
      ControlGeometry.drawGeometry((RectangleF) this.ClientRectangle, this.Geometry, Display, RoundRectangleType.RoundRectAll, ref graphics);
      if (this.Caption.Visible)
      {
        if (this.Caption.OnTop)
        {
          --this.rectDraw_2.rect.X;
          --this.rectDraw_2.rect.Y;
          ++this.rectDraw_2.rect.Width;
          ++this.rectDraw_2.rect.Height;
          ControlGeometry.drawGeometry(this.rectDraw_2.rect, this.Geometry, this.Caption.Display, this.rectDraw_2.RoundType, ref graphics);
          ControlGeometry.drawString(this.rectDraw_2.rectText, Text, this.Caption.Display, this.hotkeyPrefix_0, ref graphics);
        }
        else
        {
          --this.rectDraw_2.rect.X;
          --this.rectDraw_2.rect.Y;
          this.rectDraw_2.rect.Width += 2f;
          this.rectDraw_2.rect.Height += 2f;
          ControlGeometry.drawGeometry(this.rectDraw_2.rect, this.Geometry, this.Caption.Display, this.rectDraw_2.RoundType, ref graphics);
          ControlGeometry.drawString(this.rectDraw_2.rectText, Text, this.Caption.Display, this.hotkeyPrefix_0, ref graphics);
        }
      }
      if ((this.Unit.Visible & !this.Caption.OnTop | this.bool_5) & this.Caption.Visible)
      {
        ControlGeometry.drawGeometry(this.rectDraw_1.rect, this.Geometry, this.Unit.Display, this.rectDraw_1.RoundType, ref graphics);
        if (this.Unit.Visible & !this.Caption.OnTop & this.Caption.Visible)
          ControlGeometry.drawString(this.rectDraw_1.rectText, this.Unit.Caption, this.Unit.Display, this.hotkeyPrefix_0, ref graphics);
      }
      if (this.CheckTick.Visible & this.Caption.Visible)
      {
        ControlGeometry.drawGeometry(this.rectDraw_0.rect, this.CheckTick.ArcDiameter, this.CheckTick.Shape, this.CheckTick.TickDisplay, this.rectDraw_0.RoundType, ref graphics);
        if (this.Check)
          graphics.DrawString("ü", new Font("Wingdings", (float) Convert.ToInt32((double) this.CheckTick.BoxSize * 1.5)), (Brush) new SolidBrush(this.CheckTick.TickDisplay.Fonts.ForeColor), new RectangleF(this.rectDraw_0.rect.X - 8f, this.rectDraw_0.rect.Y, this.rectDraw_0.rect.Width + 15f, this.rectDraw_0.rect.Height), new StringFormat()
          {
            LineAlignment = StringAlignment.Center
          });
      }
      this.DrawImage(e.Graphics, this.Image, new Rectangle((int) this.rectDraw_2.rect.X, (int) this.rectDraw_2.rect.Y, (int) this.rectDraw_2.rect.Width, (int) this.rectDraw_2.rect.Height), this.ImageAlign);
    }
    this.themeType_0 = this.Theme.Type;
    base.OnPaint(e);
  }
}
