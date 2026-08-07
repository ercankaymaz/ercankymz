// Decompiled with JetBrains decompiler
// Type: buControls.Controls.buSpin
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

[DefaultProperty("Value")]
[DefaultEvent("ValueChanged")]
[ClassInterface(ClassInterfaceType.AutoDispatch)]
[ComVisible(true)]
[ToolboxBitmap(typeof (Label))]
[DefaultBindingProperty("Value")]
public class buSpin : buCaptionBaseControl
{
  private bool bool_0 = false;
  private bool bool_1 = false;
  private bool bool_2 = false;
  private FlatStyle flatStyle_0;
  private bool bool_3;
  private bool bool_4 = false;
  private double double_0 = double.MaxValue;
  private double double_1 = 0.0;
  private double double_2 = 1000000000.0;
  private double double_3 = -1000000000.0;
  private double double_4 = 1.0;
  private int int_3 = 3;
  private bool bool_5 = true;
  private int int_4 = 200;
  private int int_5 = 1000;
  private bool bool_6 = false;
  private bool bool_7 = true;
  private int int_6 = 20;
  private int int_7 = 0;
  private bool bool_8 = false;
  internal RectangleF rectangleF_0 = new RectangleF();
  internal rectDraw rectDraw_0 = new rectDraw();
  internal rectDraw rectDraw_1 = new rectDraw();
  private rectDraw rectDraw_2 = new rectDraw();
  private rectDraw rectDraw_3 = new rectDraw();
  private rectDraw rectDraw_4 = new rectDraw();
  private Timer timer_0 = new Timer();
  private Timer timer_1 = new Timer();
  private buControlDisplay buControlDisplay_1 = new buControlDisplay();
  private buControlDisplay buControlDisplay_2 = new buControlDisplay();
  private buControlDisplay buControlDisplay_3 = new buControlDisplay();
  private SpinButtonType spinButtonType_0 = SpinButtonType.LeftRight;
  private bool bool_9 = false;
  internal bool bool_10 = false;
  private ThemeType themeType_0 = ThemeType.Standart;
  internal HotkeyPrefix hotkeyPrefix_0 = HotkeyPrefix.None;
  private bool bool_11 = false;
  private bool bool_12 = false;
  public TextBox txt = new TextBox();
  public MouseState MouseStatePlus = MouseState.None;
  public MouseState MouseStateMinus = MouseState.None;
  private static object object_0 = new object();
  private static object object_1 = new object();

  public buSpin()
  {
    Class39.smethod_549();
    if (this.Parent != null)
      this.BackColor = this.Parent.BackColor;
    this.TabStop = false;
    this.TextAlign = ContentAlignment.MiddleCenter;
    this.Image = (Image) null;
    this.UseMnemonic = true;
    this.ImageList = (ImageList) null;
    this.ImageAlign = ContentAlignment.MiddleCenter;
    Class39.smethod_843(this.UseMnemonic, this);
    this.flatStyle_0 = FlatStyle.Standard;
    this.Display.BackColor = Color.WhiteSmoke;
    this.Display.Parent = (Control) this;
    this.Geometry.Parent = (Control) this;
    this.Language.Parent = (Control) this;
    this.Caption.Parent = (Control) this;
    this.Caption.Display.Parent = (Control) this;
    this.Unit.Parent = (Control) this;
    this.Unit.Display.Parent = (Control) this;
    this.ButtonDownDisplay.Parent = (Control) this;
    this.ButtonNormalDisplay.Parent = (Control) this;
    this.ButtonOverDisplay.Parent = (Control) this;
    this.Theme.Parent = (Control) this;
    this.Aux.Parent = (Control) this;
    this.CheckTick.Parent = (Control) this;
    this.CheckTick.TickDisplay.Parent = (Control) this;
    this.CheckTick.ColorModeDisplay.Parent = (Control) this;
    this.FocusControl.Parent = (Control) this;
    this.ButtonDownDisplay.Fonts.Alignment = ContentAlignment.MiddleCenter;
    this.ButtonNormalDisplay.Fonts.Alignment = ContentAlignment.MiddleCenter;
    this.ButtonOverDisplay.Fonts.Alignment = ContentAlignment.MiddleCenter;
    this.ButtonOverDisplay.BackColor = Color.Gray;
    this.ButtonDownDisplay.BackColor = Color.DimGray;
    this.CheckTick.Visible = false;
    this.CheckTick.TickDisplay.BackColor = Color.WhiteSmoke;
    Class39.smethod_771(this);
    this.txt.KeyPress += new KeyPressEventHandler(this.txt_KeyPress);
    this.txt.KeyDown += new KeyEventHandler(this.txt_KeyDown);
    this.txt.KeyUp += new KeyEventHandler(this.txt_KeyUp);
    this.txt.TextChanged += new EventHandler(this.txt_TextChanged);
    this.txt.Enter += new EventHandler(this.txt_Enter);
    this.txt.Leave += new EventHandler(this.txt_Leave);
    this.txt.Click += new EventHandler(this.txt_Click);
    this.txt.DoubleClick += new EventHandler(this.txt_DoubleClick);
    this.timer_1 = new Timer();
    this.timer_1.Interval = this.LongTimePressTime;
    this.timer_1.Tick += new EventHandler(this.timer_1_Tick);
    this.timer_0 = new Timer();
    this.timer_0.Interval = this.LongTimeIncreaseTime;
    this.timer_0.Tick += new EventHandler(this.timer_0_Tick);
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
    add => this.Events.AddHandler(buSpin.object_1, (Delegate) value);
    remove => this.Events.RemoveHandler(buSpin.object_1, (Delegate) value);
  }

  public event buControlEvents.buCheckedChangedEventHandler CheckedChanged;

  public event buControlEvents.buClickAfterEventHandler ClickAfter;

  public event buControlEvents.buValueChangedEvent ValueChanged;

  public event EventHandler ValueClicked;

  public event EventHandler CaptionClicked;

  public event EventHandler ValueDoubleClicked;

  [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
  [Browsable(true)]
  public buControlDisplay ButtonNormalDisplay
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
  public buControlDisplay ButtonOverDisplay
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
  public buControlDisplay ButtonDownDisplay
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

  [DefaultValue(0)]
  [EditorBrowsable(EditorBrowsableState.Always)]
  [NotifyParentProperty(true)]
  [Browsable(true)]
  public double Value
  {
    get => this.double_1;
    set
    {
      if (this.Security.Enable && this.Security.Level < buControl.SecurityActive)
        return;
      if (value <= this.double_2 & value >= this.double_3)
      {
        this.double_1 = value;
        try
        {
          this.txt.Text = value.ToString("f" + this.DecimalPoint.ToString());
        }
        catch (Exception ex)
        {
        }
      }
      if (this.buValueChangedEvent_0 != null)
      {
        if (this.Value != this.double_0)
          this.buValueChangedEvent_0((object) this, this.Value);
        this.double_0 = this.Value;
      }
      this.Invalidate();
    }
  }

  [DefaultValue(1000000000.0)]
  [EditorBrowsable(EditorBrowsableState.Always)]
  [NotifyParentProperty(true)]
  [Browsable(true)]
  public double MaxValue
  {
    get => this.double_2;
    set
    {
      this.double_2 = value;
      this.Invalidate();
    }
  }

  [DefaultValue(-1000000000.0)]
  [EditorBrowsable(EditorBrowsableState.Always)]
  [NotifyParentProperty(true)]
  [Browsable(true)]
  public double MinValue
  {
    get => this.double_3;
    set
    {
      this.double_3 = value;
      this.Invalidate();
    }
  }

  [DefaultValue(SpinButtonType.LeftRight)]
  [EditorBrowsable(EditorBrowsableState.Always)]
  [NotifyParentProperty(true)]
  [Browsable(true)]
  public SpinButtonType ButtonType
  {
    get => this.spinButtonType_0;
    set
    {
      this.spinButtonType_0 = value;
      this.Invalidate();
      if (this.Parent == null)
        return;
      this.Parent.Invalidate();
    }
  }

  [DefaultValue(false)]
  [EditorBrowsable(EditorBrowsableState.Always)]
  [NotifyParentProperty(true)]
  [Browsable(true)]
  public bool ChangeColorWhenFocusEnable
  {
    get => this.bool_9;
    set
    {
      this.bool_9 = value;
      this.Invalidate();
      if (this.Parent == null)
        return;
      this.Parent.Invalidate();
    }
  }

  [DefaultValue(true)]
  [EditorBrowsable(EditorBrowsableState.Always)]
  [NotifyParentProperty(true)]
  [Browsable(true)]
  public bool ButtonShow
  {
    get => this.bool_7;
    set
    {
      this.bool_7 = value;
      this.Invalidate();
      if (this.Parent == null)
        return;
      this.Parent.Invalidate();
    }
  }

  [DefaultValue(20)]
  [EditorBrowsable(EditorBrowsableState.Always)]
  [NotifyParentProperty(true)]
  [Browsable(true)]
  public int ButtonWidth
  {
    get => this.int_6;
    set
    {
      this.int_6 = value;
      this.Invalidate();
      if (this.Parent == null)
        return;
      this.Parent.Invalidate();
    }
  }

  [DefaultValue(0)]
  [EditorBrowsable(EditorBrowsableState.Always)]
  [NotifyParentProperty(true)]
  [Browsable(true)]
  public int ButtonSpace
  {
    get => this.int_7;
    set
    {
      this.int_7 = value;
      this.Invalidate();
      if (this.Parent == null)
        return;
      this.Parent.Invalidate();
    }
  }

  [DefaultValue(false)]
  [EditorBrowsable(EditorBrowsableState.Always)]
  [NotifyParentProperty(true)]
  [Browsable(true)]
  public bool MouseWheelEnable
  {
    get => this.bool_6;
    set
    {
      this.bool_6 = value;
      this.Invalidate();
    }
  }

  [DefaultValue(true)]
  [EditorBrowsable(EditorBrowsableState.Always)]
  [NotifyParentProperty(true)]
  [Browsable(true)]
  public bool LongTimePressEnable
  {
    get => this.bool_5;
    set
    {
      this.bool_5 = value;
      this.Invalidate();
    }
  }

  [DefaultValue(200)]
  public int LongTimeIncreaseTime
  {
    get => this.int_4;
    set
    {
      this.int_4 = value;
      this.timer_0.Interval = this.int_4;
      this.Invalidate();
    }
  }

  [DefaultValue(1000)]
  [EditorBrowsable(EditorBrowsableState.Always)]
  [NotifyParentProperty(true)]
  [Browsable(true)]
  public int LongTimePressTime
  {
    get => this.int_5;
    set
    {
      this.int_5 = value;
      this.timer_1.Interval = this.int_5;
      this.Invalidate();
    }
  }

  [DefaultValue(1)]
  [EditorBrowsable(EditorBrowsableState.Always)]
  [NotifyParentProperty(true)]
  [Browsable(true)]
  public double IncrementStep
  {
    get => this.double_4;
    set
    {
      if (value <= this.double_2 & value >= this.double_3)
        this.double_4 = value;
      this.Invalidate();
    }
  }

  [DefaultValue(3)]
  [EditorBrowsable(EditorBrowsableState.Always)]
  [NotifyParentProperty(true)]
  [Browsable(true)]
  public int DecimalPoint
  {
    get => this.int_3;
    set
    {
      if (value >= 0)
        this.int_3 = value;
      this.txt.Text = this.Value.ToString("f" + this.DecimalPoint.ToString());
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
    get => this.bool_3;
    set
    {
      if (this.bool_3 == value)
        return;
      this.bool_3 = value;
      Class39.smethod_843(this.bool_3, this);
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
      this.txt.ReadOnly = this.bool_1;
      this.Invalidate();
    }
  }

  [DefaultValue(false)]
  [EditorBrowsable(EditorBrowsableState.Always)]
  [NotifyParentProperty(true)]
  [Browsable(true)]
  public bool KeyDownValueChangeEvent
  {
    get => this.bool_2;
    set
    {
      this.bool_2 = value;
      this.Invalidate();
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
      buControlCommands.smethod_0(nameof (buSpin));
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
    EventHandler eventHandler = (EventHandler) this.Events[buSpin.object_1];
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
    this.timer_1.Stop();
    this.timer_0.Stop();
    base.OnMouseUp(e);
  }

  protected override void OnMouseDown(MouseEventArgs e)
  {
    this.bool_4 = false;
    if (!buControlCommands.bool_0)
    {
      buControlCommands.smethod_0(nameof (buSpin));
      if (!buControlCommands.bool_0)
      {
        int num = (int) MessageBox.Show("License Error");
        return;
      }
    }
    if (this.ReadOnly || !this.Enabled)
      return;
    this.bool_4 = true;
    if (!this.ReadOnly & this.Enabled)
    {
      if ((double) e.X >= (double) this.rectDraw_2.rect.X & (double) e.X <= (double) this.rectDraw_2.rect.X + (double) this.rectDraw_2.rect.Width && (double) e.Y >= (double) this.rectDraw_2.rect.Y & (double) e.Y <= (double) this.rectDraw_2.rect.Y + (double) this.rectDraw_2.rect.Height)
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
      if ((double) e.X >= (double) this.rectDraw_4.rect.X & (double) e.X <= (double) this.rectDraw_4.rect.X + (double) this.rectDraw_4.rect.Width && (double) e.Y >= (double) this.rectDraw_4.rect.Y & (double) e.Y <= (double) this.rectDraw_4.rect.Y + (double) this.rectDraw_4.rect.Height && this.eventHandler_1 != null)
      {
        // ISSUE: reference to a compiler-generated field
        this.eventHandler_1((object) this, new EventArgs());
      }
    }
    if (!this.ButtonShow)
      return;
    if ((double) e.X >= (double) this.rectDraw_1.rect.X & (double) e.X <= (double) this.rectDraw_1.rect.X + (double) this.rectDraw_1.rect.Width && (double) e.Y >= (double) this.rectDraw_1.rect.Y & (double) e.Y <= (double) this.rectDraw_1.rect.Y + (double) this.rectDraw_1.rect.Height)
    {
      this.MouseStateMinus = MouseState.Down;
      this.MouseStatePlus = MouseState.None;
      this.Value -= this.IncrementStep;
      if (this.LongTimePressEnable)
        this.timer_1.Start();
    }
    if ((double) e.X >= (double) this.rectDraw_0.rect.X & (double) e.X <= (double) this.rectDraw_0.rect.X + (double) this.rectDraw_0.rect.Width && (double) e.Y >= (double) this.rectDraw_0.rect.Y & (double) e.Y <= (double) this.rectDraw_0.rect.Y + (double) this.rectDraw_0.rect.Height)
    {
      this.MouseStateMinus = MouseState.None;
      this.MouseStatePlus = MouseState.Down;
      this.Value += this.IncrementStep;
      if (this.LongTimePressEnable)
        this.timer_1.Start();
    }
    this.Invalidate();
    base.OnMouseDown(e);
  }

  protected override void OnMouseMove(MouseEventArgs e)
  {
    bool flag1 = false;
    bool flag2 = false;
    this.Cursor = Cursors.Default;
    if ((double) e.X >= (double) this.rectDraw_1.rect.X & (double) e.X <= (double) this.rectDraw_1.rect.X + (double) this.rectDraw_1.rect.Width && (double) e.Y >= (double) this.rectDraw_1.rect.Y & (double) e.Y <= (double) this.rectDraw_1.rect.Y + (double) this.rectDraw_1.rect.Height)
    {
      this.MouseStateMinus = MouseState.Move;
      this.MouseStatePlus = MouseState.None;
      flag2 = true;
    }
    if (!flag2)
      this.MouseStateMinus = MouseState.None;
    if ((double) e.X >= (double) this.rectDraw_0.rect.X & (double) e.X <= (double) this.rectDraw_0.rect.X + (double) this.rectDraw_0.rect.Width && (double) e.Y >= (double) this.rectDraw_0.rect.Y & (double) e.Y <= (double) this.rectDraw_0.rect.Y + (double) this.rectDraw_0.rect.Height)
    {
      this.MouseStateMinus = MouseState.None;
      this.MouseStatePlus = MouseState.Move;
      flag1 = true;
    }
    if (!flag1)
      this.MouseStatePlus = MouseState.None;
    this.Invalidate();
    base.OnMouseMove(e);
  }

  protected override void OnMouseEnter(EventArgs e) => base.OnMouseEnter(e);

  protected override void OnMouseLeave(EventArgs e)
  {
    this.MouseStateMinus = MouseState.None;
    this.MouseStatePlus = MouseState.None;
    this.bool_4 = false;
    this.Invalidate();
    base.OnMouseLeave(e);
  }

  protected override void OnMouseWheel(MouseEventArgs e)
  {
    base.OnMouseWheel(e);
    if (!this.MouseWheelEnable || this.ReadOnly)
      return;
    if (e.Delta > 0)
    {
      if (this.Value + this.IncrementStep <= this.MaxValue)
      {
        this.Value += this.IncrementStep;
        this.txt.Text = this.Value.ToString("f" + this.DecimalPoint.ToString());
      }
      this.Invalidate();
    }
    else
    {
      if (this.Value - this.IncrementStep >= this.MinValue)
      {
        this.Value -= this.IncrementStep;
        this.txt.Text = this.Value.ToString("f" + this.DecimalPoint.ToString());
      }
      this.Invalidate();
    }
  }

  protected override void OnHandleDestroyed(EventArgs e) => base.OnHandleDestroyed(e);

  protected override void OnKeyPress(KeyPressEventArgs e)
  {
    if (this.Value > this.MaxValue)
      this.Value = this.MaxValue;
    base.OnKeyPress(e);
  }

  protected override void OnKeyDown(KeyEventArgs e) => base.OnKeyDown(e);

  protected override void OnKeyUp(KeyEventArgs e)
  {
    if (e.KeyCode == Keys.Back)
      ;
    base.OnKeyUp(e);
  }

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
    if ((char.IsControl(e.KeyChar) || char.IsDigit(e.KeyChar) || e.KeyChar == '.' ? 0 : (e.KeyChar != '-' ? 1 : 0)) != 0)
      e.Handled = true;
    if ((e.KeyChar != '.' ? 0 : ((sender as TextBox).Text.IndexOf('.') > -1 ? 1 : 0)) != 0)
      e.Handled = true;
    if (e.KeyChar == '\r')
      ;
    this.OnKeyPress(e);
  }

  private void txt_KeyDown(object sender, KeyEventArgs e)
  {
    if (e.KeyCode != Keys.Return)
      return;
    double result = 0.0;
    double.TryParse(this.txt.Text.Trim(), out result);
    if (result > this.MaxValue)
    {
      result = this.MaxValue;
      this.Value = result;
      this.txt.Text = this.Value.ToString("f" + this.DecimalPoint.ToString());
    }
    if (result < this.MinValue)
    {
      result = this.MinValue;
      this.Value = result;
      this.txt.Text = this.Value.ToString("f" + this.DecimalPoint.ToString());
    }
    this.Value = result;
    // ISSUE: reference to a compiler-generated field
    if (this.buValueChangedEvent_0 != null && this.KeyDownValueChangeEvent)
    {
      // ISSUE: reference to a compiler-generated field
      this.buValueChangedEvent_0((object) this, this.Value);
      this.double_0 = this.Value;
    }
    this.OnKeyDown(e);
  }

  private void txt_KeyUp(object sender, KeyEventArgs e) => this.OnKeyUp(e);

  private void txt_Enter(object sender, EventArgs e) => this.Invalidate();

  private void txt_Leave(object sender, EventArgs e)
  {
    this.bool_10 = false;
    double result = 0.0;
    double.TryParse(this.txt.Text.Trim(), out result);
    double num;
    int decimalPoint;
    if (result > this.MaxValue)
    {
      result = this.MaxValue;
      this.Value = result;
      TextBox txt = this.txt;
      num = this.Value;
      ref double local = ref num;
      decimalPoint = this.DecimalPoint;
      string format = "f" + decimalPoint.ToString();
      string str = local.ToString(format);
      txt.Text = str;
    }
    if (result < this.MinValue)
    {
      result = this.MinValue;
      this.Value = result;
      TextBox txt = this.txt;
      num = this.Value;
      ref double local = ref num;
      decimalPoint = this.DecimalPoint;
      string format = "f" + decimalPoint.ToString();
      string str = local.ToString(format);
      txt.Text = str;
    }
    this.Value = result;
    TextBox txt1 = this.txt;
    num = this.Value;
    ref double local1 = ref num;
    decimalPoint = this.DecimalPoint;
    string format1 = "f" + decimalPoint.ToString();
    string str1 = local1.ToString(format1);
    txt1.Text = str1;
    this.Invalidate();
  }

  private void txt_Click(object sender, EventArgs e)
  {
    this.bool_10 = true;
    if (!buControlCommands.bool_0)
    {
      buControlCommands.smethod_0(nameof (buSpin));
      if (!buControlCommands.bool_0)
      {
        int num = (int) MessageBox.Show("License Error");
        return;
      }
    }
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
    // ISSUE: reference to a compiler-generated field
    if (this.eventHandler_2 != null)
    {
      // ISSUE: reference to a compiler-generated field
      this.eventHandler_2((object) this, e);
    }
    this.OnDoubleClick(e);
  }

  private void txt_TextChanged(object sender, EventArgs e)
  {
    if (this.txt.Text.Trim().Length <= 0)
      return;
    double result = 0.0;
    double.TryParse(this.txt.Text.Trim(), out result);
    if (result > this.MaxValue)
    {
      result = this.MaxValue;
      this.double_1 = result;
      if (this.DecimalPoint > 0)
        this.txt.Text = this.double_1.ToString("f" + this.DecimalPoint.ToString());
      else
        this.txt.Text = Convert.ToInt32(this.double_1).ToString();
    }
    if (result < this.MinValue)
    {
      result = this.MinValue;
      this.double_1 = result;
      if (this.DecimalPoint > 0)
        this.txt.Text = this.double_1.ToString("f" + this.DecimalPoint.ToString());
      else
        this.txt.Text = Convert.ToInt32(this.double_1).ToString();
    }
    this.double_1 = result;
    // ISSUE: reference to a compiler-generated field
    if (this.buValueChangedEvent_0 == null)
      return;
    if (!this.KeyDownValueChangeEvent | this.bool_4 && this.Value != this.double_0)
    {
      // ISSUE: reference to a compiler-generated field
      this.buValueChangedEvent_0((object) this, this.Value);
    }
    this.double_0 = this.Value;
  }

  private void timer_1_Tick(object sender, EventArgs e)
  {
    this.timer_0.Start();
    this.timer_1.Stop();
  }

  private void timer_0_Tick(object sender, EventArgs e)
  {
    if (this.MouseStatePlus == MouseState.Down)
      this.Value += this.IncrementStep;
    if (this.MouseStateMinus != MouseState.Down)
      return;
    this.Value -= this.IncrementStep;
  }

  public static buSpin CopyVisual(buSpin refSpin, buSpin copySpin)
  {
    copySpin.Display = buControlDisplay.Copy(refSpin.Display, copySpin.Display);
    copySpin.Caption.Display = buControlDisplay.Copy(refSpin.Caption.Display, copySpin.Caption.Display);
    copySpin.ButtonNormalDisplay = buControlDisplay.Copy(refSpin.ButtonNormalDisplay, copySpin.ButtonNormalDisplay);
    copySpin.ButtonDownDisplay = buControlDisplay.Copy(refSpin.ButtonDownDisplay, copySpin.ButtonDownDisplay);
    copySpin.ButtonOverDisplay = buControlDisplay.Copy(refSpin.ButtonOverDisplay, copySpin.ButtonOverDisplay);
    copySpin.Geometry.Space = refSpin.Geometry.Space;
    copySpin.Geometry.ArcDiameter = refSpin.Geometry.ArcDiameter;
    copySpin.Geometry.ShapeMode = refSpin.Geometry.ShapeMode;
    copySpin.ImageAlign = refSpin.ImageAlign;
    return copySpin;
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
      this.ButtonDownDisplay = new buControlDisplay(Vars.DisplayButtonDown);
      this.ButtonNormalDisplay = new buControlDisplay(Vars.DisplayButtonNormal);
      this.ButtonOverDisplay = new buControlDisplay(Vars.DisplayButtonOver);
      this.Caption.Display = new buControlDisplay(Vars.Caption.Display);
      this.Caption.Parent = (Control) this;
      this.Caption.Display.Parent = (Control) this;
      this.Display.Parent = (Control) this;
      this.ButtonDownDisplay.Parent = (Control) this;
      this.ButtonNormalDisplay.Parent = (Control) this;
      this.ButtonOverDisplay.Parent = (Control) this;
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
    buControlDisplay Display1 = new buControlDisplay(this.Display);
    buControlDisplay Display2 = new buControlDisplay(this.ButtonNormalDisplay);
    buControlDisplay Display3 = new buControlDisplay(this.ButtonNormalDisplay);
    if (this.MouseStatePlus == MouseState.Move)
      Display2 = new buControlDisplay(this.ButtonOverDisplay);
    if (this.MouseStatePlus == MouseState.Down)
      Display2 = new buControlDisplay(this.ButtonDownDisplay);
    if (this.MouseStateMinus == MouseState.Move)
      Display3 = new buControlDisplay(this.ButtonOverDisplay);
    if (this.MouseStateMinus == MouseState.Down)
      Display3 = new buControlDisplay(this.ButtonDownDisplay);
    if (this.Enabled & this.bool_10 & this.FocusControl.Enable)
    {
      Display1.BackColor = this.FocusControl.FocusColor;
      Display1.GradientType = GradientMode.Solid;
    }
    string Text = ControlGeometry.LanguageSelect(this.Language, caption);
    this.bool_8 = false;
    if (this.Width > 0 & this.Height > 0)
    {
      if (!this.Enabled && !this.bool_12 | this.Enabled != this.bool_11)
      {
        Display1.GradientType = GradientMode.Solid;
        Display1.BackColor = Display1.DisableColor;
      }
      this.bool_11 = this.Enabled;
      ControlGeometry.CalcMainArea((float) this.Width, (float) this.Height, this.Geometry, this.Caption, ref this.rectDraw_4, ref this.rectangleF_0);
      if (this.ButtonShow)
      {
        if (this.ButtonType == SpinButtonType.LeftRight)
        {
          if (this.Caption.OnTop)
          {
            this.rectDraw_1 = new rectDraw(new RectangleF(this.rectangleF_0.X + (float) this.ButtonSpace, (float) ((double) this.rectangleF_0.Y + (double) this.ButtonSpace - 1.0), (float) this.ButtonWidth, (float) ((double) this.rectangleF_0.Height - (double) (this.ButtonSpace * 2) + 1.0)), RoundRectangleType.RoundRectLeft);
            this.rectDraw_0 = new rectDraw(new RectangleF(this.rectangleF_0.X + this.rectangleF_0.Width - (float) this.ButtonWidth - (float) this.ButtonSpace, (float) ((double) this.rectangleF_0.Y + (double) this.ButtonSpace - 1.0), (float) this.ButtonWidth, (float) ((double) this.rectangleF_0.Height - (double) (this.ButtonSpace * 2) + 1.0)), RoundRectangleType.RoundRectRight);
            this.rectDraw_1.RoundType = RoundRectangleType.RoundRectLeftDown;
            this.rectDraw_0.RoundType = RoundRectangleType.RoundRectRightDown;
          }
          else
          {
            this.rectDraw_1 = new rectDraw(new RectangleF(this.rectangleF_0.X + (float) this.ButtonSpace, (float) ((double) this.rectangleF_0.Y + (double) this.ButtonSpace - 0.0), (float) this.ButtonWidth, (float) ((double) this.rectangleF_0.Height - (double) (this.ButtonSpace * 2) + 0.0)), RoundRectangleType.RoundRectLeft);
            this.rectDraw_0 = new rectDraw(new RectangleF(this.rectangleF_0.X + this.rectangleF_0.Width - (float) this.ButtonWidth - (float) this.ButtonSpace, (float) ((double) this.rectangleF_0.Y + (double) this.ButtonSpace - 0.0), (float) this.ButtonWidth, (float) ((double) this.rectangleF_0.Height - (double) (this.ButtonSpace * 2) + 0.0)), RoundRectangleType.RoundRectRight);
          }
        }
        if (this.ButtonType == SpinButtonType.UpDown)
        {
          if (this.Caption.OnTop)
          {
            this.rectDraw_0 = new rectDraw(new RectangleF(this.rectangleF_0.X + this.rectangleF_0.Width - (float) this.ButtonWidth - (float) this.ButtonSpace, (float) ((double) this.rectangleF_0.Y + (double) this.ButtonSpace - 1.0), (float) this.ButtonWidth, this.rectangleF_0.Height / 2f - (float) (this.ButtonSpace * 2)), RoundRectangleType.RoundRectUp);
            this.rectDraw_1 = new rectDraw(new RectangleF(this.rectangleF_0.X + this.rectangleF_0.Width - (float) this.ButtonWidth - (float) this.ButtonSpace, (float) ((double) this.rectDraw_0.rect.Y + (double) this.rectDraw_0.rect.Height - 1.0), (float) this.ButtonWidth, (float) ((double) this.rectangleF_0.Height / 2.0 - (double) (this.ButtonSpace * 2) + 2.0)), RoundRectangleType.RoundRectDown);
            this.rectDraw_0.RoundType = RoundRectangleType.RoundRectNone;
            this.rectDraw_1.RoundType = RoundRectangleType.RoundRectRightDown;
          }
          else
          {
            this.rectDraw_0 = new rectDraw(new RectangleF(this.rectangleF_0.X + this.rectangleF_0.Width - (float) this.ButtonWidth - (float) this.ButtonSpace, this.rectangleF_0.Y + (float) this.ButtonSpace, (float) this.ButtonWidth, this.rectangleF_0.Height / 2f - (float) (this.ButtonSpace * 2)), RoundRectangleType.RoundRectUp);
            this.rectDraw_1 = new rectDraw(new RectangleF(this.rectangleF_0.X + this.rectangleF_0.Width - (float) this.ButtonWidth - (float) this.ButtonSpace, (float) ((double) this.rectDraw_0.rect.Y + (double) this.rectDraw_0.rect.Height - 1.0), (float) this.ButtonWidth, (float) ((double) this.rectangleF_0.Height / 2.0 - (double) (this.ButtonSpace * 2) + 1.0)), RoundRectangleType.RoundRectDown);
            this.rectDraw_0.RoundType = RoundRectangleType.RoundRectRightUp;
            this.rectDraw_1.RoundType = RoundRectangleType.RoundRectRightDown;
          }
        }
      }
      else
      {
        this.rectDraw_1 = new rectDraw();
        this.rectDraw_0 = new rectDraw();
      }
      Class39.smethod_771(this);
      ControlGeometry.drawGeometry((RectangleF) this.ClientRectangle, this.Geometry, Display1, RoundRectangleType.RoundRectAll, ref graphics);
      if (this.Caption.Visible)
      {
        if (this.Caption.OnTop)
        {
          --this.rectDraw_4.rect.X;
          --this.rectDraw_4.rect.Y;
          ++this.rectDraw_4.rect.Width;
          ++this.rectDraw_4.rect.Height;
          ControlGeometry.drawGeometry(this.rectDraw_4.rect, this.Geometry, this.Caption.Display, this.rectDraw_4.RoundType, ref graphics);
          ControlGeometry.drawString(this.rectDraw_4.rectText, Text, this.Caption.Display, this.hotkeyPrefix_0, ref graphics);
        }
        else
        {
          int num = 2;
          if (this.Geometry.ShapeMode == ShapeType.Arc)
            num = this.ButtonWidth / 2;
          --this.rectDraw_4.rect.X;
          --this.rectDraw_4.rect.Y;
          this.rectDraw_4.rect.Width += (float) num;
          this.rectDraw_4.rect.Height += 2f;
          ControlGeometry.drawGeometry(this.rectDraw_4.rect, this.Geometry, this.Caption.Display, this.rectDraw_4.RoundType, ref graphics);
          ControlGeometry.drawString(this.rectDraw_4.rectText, Text, this.Caption.Display, this.hotkeyPrefix_0, ref graphics);
        }
      }
      if ((this.Unit.Visible & !this.Caption.OnTop | this.bool_8) & this.Caption.Visible)
      {
        ControlGeometry.drawGeometry(this.rectDraw_3.rect, this.Geometry, this.Unit.Display, this.rectDraw_3.RoundType, ref graphics);
        if (this.Unit.Visible & !this.Caption.OnTop & this.Caption.Visible)
          ControlGeometry.drawString(this.rectDraw_3.rectText, this.Unit.Caption, this.Unit.Display, this.hotkeyPrefix_0, ref graphics);
      }
      if (this.CheckTick.Visible & this.Caption.Visible)
      {
        this.rectDraw_2 = new rectDraw(new RectangleF((float) (this.Width - this.CheckTick.BoxSize - this.CheckTick.Space), (float) ((double) this.Height / 2.0 - (double) this.CheckTick.BoxSize / 2.0), (float) this.CheckTick.BoxSize, (float) this.CheckTick.BoxSize), RoundRectangleType.RoundRectNone);
        if (this.Check)
          graphics.DrawString("ü", new Font("Wingdings", (float) Convert.ToInt32((double) this.CheckTick.BoxSize * 1.5)), (Brush) new SolidBrush(this.CheckTick.TickDisplay.Fonts.ForeColor), new RectangleF(this.rectDraw_2.rect.X - 8f, this.rectDraw_2.rect.Y, this.rectDraw_2.rect.Width + 15f, this.rectDraw_2.rect.Height), new StringFormat()
          {
            LineAlignment = StringAlignment.Center
          });
      }
      if (this.ButtonShow)
      {
        ControlGeometry.drawGeometry(this.rectDraw_1.rect, this.Geometry, Display3, this.rectDraw_1.RoundType, ref graphics);
        ControlGeometry.drawString(this.rectDraw_1.rect, "-", Display3, this.hotkeyPrefix_0, ref graphics);
        ControlGeometry.drawGeometry(this.rectDraw_0.rect, this.Geometry, Display2, this.rectDraw_0.RoundType, ref graphics);
        ControlGeometry.drawString(this.rectDraw_0.rect, "+", Display2, this.hotkeyPrefix_0, ref graphics);
      }
      this.DrawImage(e.Graphics, this.Image, new Rectangle((int) this.rectDraw_4.rect.X, (int) this.rectDraw_4.rect.Y, (int) this.rectDraw_4.rect.Width, (int) this.rectDraw_4.rect.Height), this.ImageAlign);
    }
    this.themeType_0 = this.Theme.Type;
    this.bool_12 = true;
    base.OnPaint(e);
  }
}
