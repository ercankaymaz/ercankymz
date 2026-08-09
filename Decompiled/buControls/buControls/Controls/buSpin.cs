using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;
using ns27;

namespace buControls.Controls;

[DefaultProperty("Value")]
[DefaultEvent("ValueChanged")]
[ClassInterface(ClassInterfaceType.AutoDispatch)]
[ComVisible(true)]
[ToolboxBitmap(typeof(Label))]
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

	internal RectangleF rectangleF_0 = default(RectangleF);

	internal rectDraw rectDraw_0 = new rectDraw();

	internal rectDraw rectDraw_1 = new rectDraw();

	private rectDraw rectDraw_2 = new rectDraw();

	private rectDraw rectDraw_3 = new rectDraw();

	private rectDraw rectDraw_4 = new rectDraw();

	private System.Windows.Forms.Timer timer_0 = new System.Windows.Forms.Timer();

	private System.Windows.Forms.Timer timer_1 = new System.Windows.Forms.Timer();

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

	[CompilerGenerated]
	private buControlEvents.buCheckedChangedEventHandler buCheckedChangedEventHandler_0;

	[CompilerGenerated]
	private buControlEvents.buClickAfterEventHandler buClickAfterEventHandler_0;

	[CompilerGenerated]
	private buControlEvents.buValueChangedEvent buValueChangedEvent_0;

	[CompilerGenerated]
	private EventHandler eventHandler_0;

	[CompilerGenerated]
	private EventHandler eventHandler_1;

	[CompilerGenerated]
	private EventHandler eventHandler_2;

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	[Browsable(true)]
	public buControlDisplay ButtonNormalDisplay
	{
		get
		{
			return buControlDisplay_1;
		}
		set
		{
			buControlDisplay_1 = value;
			if (base.Parent != null)
			{
				base.Parent.Invalidate();
			}
		}
	}

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	[Browsable(true)]
	public buControlDisplay ButtonOverDisplay
	{
		get
		{
			return buControlDisplay_2;
		}
		set
		{
			buControlDisplay_2 = value;
			if (base.Parent != null)
			{
				base.Parent.Invalidate();
			}
		}
	}

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	[Browsable(true)]
	public buControlDisplay ButtonDownDisplay
	{
		get
		{
			return buControlDisplay_3;
		}
		set
		{
			buControlDisplay_3 = value;
			if (base.Parent != null)
			{
				base.Parent.Invalidate();
			}
		}
	}

	[DefaultValue(0)]
	[EditorBrowsable(EditorBrowsableState.Always)]
	[NotifyParentProperty(true)]
	[Browsable(true)]
	public double Value
	{
		get
		{
			return double_1;
		}
		set
		{
			if (base.Security.Enable && base.Security.Level < buControl.SecurityActive)
			{
				return;
			}
			if ((value <= double_2) & (value >= double_3))
			{
				double_1 = value;
				try
				{
					txt.Text = value.ToString("f" + DecimalPoint);
				}
				catch (Exception)
				{
				}
			}
			if (buValueChangedEvent_0 != null)
			{
				if (Value != double_0)
				{
					buValueChangedEvent_0(this, Value);
				}
				double_0 = Value;
			}
			Invalidate();
		}
	}

	[DefaultValue(1000000000.0)]
	[EditorBrowsable(EditorBrowsableState.Always)]
	[NotifyParentProperty(true)]
	[Browsable(true)]
	public double MaxValue
	{
		get
		{
			return double_2;
		}
		set
		{
			double_2 = value;
			Invalidate();
		}
	}

	[DefaultValue(-1000000000.0)]
	[EditorBrowsable(EditorBrowsableState.Always)]
	[NotifyParentProperty(true)]
	[Browsable(true)]
	public double MinValue
	{
		get
		{
			return double_3;
		}
		set
		{
			double_3 = value;
			Invalidate();
		}
	}

	[DefaultValue(SpinButtonType.LeftRight)]
	[EditorBrowsable(EditorBrowsableState.Always)]
	[NotifyParentProperty(true)]
	[Browsable(true)]
	public SpinButtonType ButtonType
	{
		get
		{
			return spinButtonType_0;
		}
		set
		{
			spinButtonType_0 = value;
			Invalidate();
			if (base.Parent != null)
			{
				base.Parent.Invalidate();
			}
		}
	}

	[DefaultValue(false)]
	[EditorBrowsable(EditorBrowsableState.Always)]
	[NotifyParentProperty(true)]
	[Browsable(true)]
	public bool ChangeColorWhenFocusEnable
	{
		get
		{
			return bool_9;
		}
		set
		{
			bool_9 = value;
			Invalidate();
			if (base.Parent != null)
			{
				base.Parent.Invalidate();
			}
		}
	}

	[DefaultValue(true)]
	[EditorBrowsable(EditorBrowsableState.Always)]
	[NotifyParentProperty(true)]
	[Browsable(true)]
	public bool ButtonShow
	{
		get
		{
			return bool_7;
		}
		set
		{
			bool_7 = value;
			Invalidate();
			if (base.Parent != null)
			{
				base.Parent.Invalidate();
			}
		}
	}

	[DefaultValue(20)]
	[EditorBrowsable(EditorBrowsableState.Always)]
	[NotifyParentProperty(true)]
	[Browsable(true)]
	public int ButtonWidth
	{
		get
		{
			return int_6;
		}
		set
		{
			int_6 = value;
			Invalidate();
			if (base.Parent != null)
			{
				base.Parent.Invalidate();
			}
		}
	}

	[DefaultValue(0)]
	[EditorBrowsable(EditorBrowsableState.Always)]
	[NotifyParentProperty(true)]
	[Browsable(true)]
	public int ButtonSpace
	{
		get
		{
			return int_7;
		}
		set
		{
			int_7 = value;
			Invalidate();
			if (base.Parent != null)
			{
				base.Parent.Invalidate();
			}
		}
	}

	[DefaultValue(false)]
	[EditorBrowsable(EditorBrowsableState.Always)]
	[NotifyParentProperty(true)]
	[Browsable(true)]
	public bool MouseWheelEnable
	{
		get
		{
			return bool_6;
		}
		set
		{
			bool_6 = value;
			Invalidate();
		}
	}

	[DefaultValue(true)]
	[EditorBrowsable(EditorBrowsableState.Always)]
	[NotifyParentProperty(true)]
	[Browsable(true)]
	public bool LongTimePressEnable
	{
		get
		{
			return bool_5;
		}
		set
		{
			bool_5 = value;
			Invalidate();
		}
	}

	[DefaultValue(200)]
	public int LongTimeIncreaseTime
	{
		get
		{
			return int_4;
		}
		set
		{
			int_4 = value;
			timer_0.Interval = int_4;
			Invalidate();
		}
	}

	[DefaultValue(1000)]
	[EditorBrowsable(EditorBrowsableState.Always)]
	[NotifyParentProperty(true)]
	[Browsable(true)]
	public int LongTimePressTime
	{
		get
		{
			return int_5;
		}
		set
		{
			int_5 = value;
			timer_1.Interval = int_5;
			Invalidate();
		}
	}

	[DefaultValue(1)]
	[EditorBrowsable(EditorBrowsableState.Always)]
	[NotifyParentProperty(true)]
	[Browsable(true)]
	public double IncrementStep
	{
		get
		{
			return double_4;
		}
		set
		{
			if ((value <= double_2) & (value >= double_3))
			{
				double_4 = value;
			}
			Invalidate();
		}
	}

	[DefaultValue(3)]
	[EditorBrowsable(EditorBrowsableState.Always)]
	[NotifyParentProperty(true)]
	[Browsable(true)]
	public int DecimalPoint
	{
		get
		{
			return int_3;
		}
		set
		{
			if (value >= 0)
			{
				int_3 = value;
			}
			txt.Text = Value.ToString("f" + DecimalPoint);
			Invalidate();
		}
	}

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override Image BackgroundImage
	{
		get
		{
			return base.BackgroundImage;
		}
		set
		{
			base.BackgroundImage = value;
			Invalidate();
		}
	}

	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override ImageLayout BackgroundImageLayout
	{
		get
		{
			return base.BackgroundImageLayout;
		}
		set
		{
			base.BackgroundImageLayout = value;
		}
	}

	protected override ImeMode DefaultImeMode => ImeMode.Disable;

	protected override Padding DefaultMargin => new Padding(3, 0, 3, 0);

	[DefaultValue(FlatStyle.Standard)]
	public FlatStyle FlatStyle
	{
		get
		{
			return flatStyle_0;
		}
		set
		{
			if (Enum.IsDefined(typeof(FlatStyle), value))
			{
				if (flatStyle_0 != value)
				{
					flatStyle_0 = value;
					if (base.Parent != null)
					{
						base.Parent.PerformLayout(this, "FlatStyle");
					}
					Invalidate();
				}
				return;
			}
			throw new InvalidEnumArgumentException($"Enum argument value '{value}' is not valid for FlatStyle");
		}
	}

	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public new ImeMode ImeMode
	{
		get
		{
			return base.ImeMode;
		}
		set
		{
			base.ImeMode = value;
		}
	}

	[Browsable(false)]
	[DefaultValue(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public new bool TabStop
	{
		get
		{
			return base.TabStop;
		}
		set
		{
			base.TabStop = value;
		}
	}

	[DefaultValue(true)]
	public bool UseMnemonic
	{
		get
		{
			return bool_3;
		}
		set
		{
			if (bool_3 != value)
			{
				bool_3 = value;
				Class76.smethod_843(bool_3, this);
				Invalidate();
			}
		}
	}

	[DefaultValue(false)]
	[EditorBrowsable(EditorBrowsableState.Always)]
	[NotifyParentProperty(true)]
	[Browsable(true)]
	public bool Check
	{
		get
		{
			return bool_0;
		}
		set
		{
			bool_0 = value;
			Invalidate();
		}
	}

	[DefaultValue(false)]
	[EditorBrowsable(EditorBrowsableState.Always)]
	[NotifyParentProperty(true)]
	[Browsable(true)]
	public bool ReadOnly
	{
		get
		{
			return bool_1;
		}
		set
		{
			bool_1 = value;
			txt.ReadOnly = bool_1;
			Invalidate();
		}
	}

	[DefaultValue(false)]
	[EditorBrowsable(EditorBrowsableState.Always)]
	[NotifyParentProperty(true)]
	[Browsable(true)]
	public bool KeyDownValueChangeEvent
	{
		get
		{
			return bool_2;
		}
		set
		{
			bool_2 = value;
			Invalidate();
		}
	}

	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public new event EventHandler BackgroundImageChanged
	{
		add
		{
			base.BackgroundImageChanged += value;
		}
		remove
		{
			base.BackgroundImageChanged -= value;
		}
	}

	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public new event EventHandler BackgroundImageLayoutChanged
	{
		add
		{
			base.BackgroundImageLayoutChanged += value;
		}
		remove
		{
			base.BackgroundImageLayoutChanged -= value;
		}
	}

	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public new event EventHandler ImeModeChanged
	{
		add
		{
			base.ImeModeChanged += value;
		}
		remove
		{
			base.ImeModeChanged -= value;
		}
	}

	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public new event EventHandler TabStopChanged
	{
		add
		{
			base.TabStopChanged += value;
		}
		remove
		{
			base.TabStopChanged -= value;
		}
	}

	public event EventHandler TextAlignChanged
	{
		add
		{
			base.Events.AddHandler(object_1, value);
		}
		remove
		{
			base.Events.RemoveHandler(object_1, value);
		}
	}

	public event buControlEvents.buCheckedChangedEventHandler CheckedChanged
	{
		[CompilerGenerated]
		add
		{
			buControlEvents.buCheckedChangedEventHandler buCheckedChangedEventHandler = buCheckedChangedEventHandler_0;
			buControlEvents.buCheckedChangedEventHandler buCheckedChangedEventHandler2;
			do
			{
				buCheckedChangedEventHandler2 = buCheckedChangedEventHandler;
				buControlEvents.buCheckedChangedEventHandler value2 = (buControlEvents.buCheckedChangedEventHandler)Delegate.Combine(buCheckedChangedEventHandler2, value);
				buCheckedChangedEventHandler = Interlocked.CompareExchange(ref buCheckedChangedEventHandler_0, value2, buCheckedChangedEventHandler2);
			}
			while ((object)buCheckedChangedEventHandler != buCheckedChangedEventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			buControlEvents.buCheckedChangedEventHandler buCheckedChangedEventHandler = buCheckedChangedEventHandler_0;
			buControlEvents.buCheckedChangedEventHandler buCheckedChangedEventHandler2;
			do
			{
				buCheckedChangedEventHandler2 = buCheckedChangedEventHandler;
				buControlEvents.buCheckedChangedEventHandler value2 = (buControlEvents.buCheckedChangedEventHandler)Delegate.Remove(buCheckedChangedEventHandler2, value);
				buCheckedChangedEventHandler = Interlocked.CompareExchange(ref buCheckedChangedEventHandler_0, value2, buCheckedChangedEventHandler2);
			}
			while ((object)buCheckedChangedEventHandler != buCheckedChangedEventHandler2);
		}
	}

	public event buControlEvents.buClickAfterEventHandler ClickAfter
	{
		[CompilerGenerated]
		add
		{
			buControlEvents.buClickAfterEventHandler buClickAfterEventHandler = buClickAfterEventHandler_0;
			buControlEvents.buClickAfterEventHandler buClickAfterEventHandler2;
			do
			{
				buClickAfterEventHandler2 = buClickAfterEventHandler;
				buControlEvents.buClickAfterEventHandler value2 = (buControlEvents.buClickAfterEventHandler)Delegate.Combine(buClickAfterEventHandler2, value);
				buClickAfterEventHandler = Interlocked.CompareExchange(ref buClickAfterEventHandler_0, value2, buClickAfterEventHandler2);
			}
			while ((object)buClickAfterEventHandler != buClickAfterEventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			buControlEvents.buClickAfterEventHandler buClickAfterEventHandler = buClickAfterEventHandler_0;
			buControlEvents.buClickAfterEventHandler buClickAfterEventHandler2;
			do
			{
				buClickAfterEventHandler2 = buClickAfterEventHandler;
				buControlEvents.buClickAfterEventHandler value2 = (buControlEvents.buClickAfterEventHandler)Delegate.Remove(buClickAfterEventHandler2, value);
				buClickAfterEventHandler = Interlocked.CompareExchange(ref buClickAfterEventHandler_0, value2, buClickAfterEventHandler2);
			}
			while ((object)buClickAfterEventHandler != buClickAfterEventHandler2);
		}
	}

	public event buControlEvents.buValueChangedEvent ValueChanged
	{
		[CompilerGenerated]
		add
		{
			buControlEvents.buValueChangedEvent buValueChangedEvent = buValueChangedEvent_0;
			buControlEvents.buValueChangedEvent buValueChangedEvent2;
			do
			{
				buValueChangedEvent2 = buValueChangedEvent;
				buControlEvents.buValueChangedEvent value2 = (buControlEvents.buValueChangedEvent)Delegate.Combine(buValueChangedEvent2, value);
				buValueChangedEvent = Interlocked.CompareExchange(ref buValueChangedEvent_0, value2, buValueChangedEvent2);
			}
			while ((object)buValueChangedEvent != buValueChangedEvent2);
		}
		[CompilerGenerated]
		remove
		{
			buControlEvents.buValueChangedEvent buValueChangedEvent = buValueChangedEvent_0;
			buControlEvents.buValueChangedEvent buValueChangedEvent2;
			do
			{
				buValueChangedEvent2 = buValueChangedEvent;
				buControlEvents.buValueChangedEvent value2 = (buControlEvents.buValueChangedEvent)Delegate.Remove(buValueChangedEvent2, value);
				buValueChangedEvent = Interlocked.CompareExchange(ref buValueChangedEvent_0, value2, buValueChangedEvent2);
			}
			while ((object)buValueChangedEvent != buValueChangedEvent2);
		}
	}

	public event EventHandler ValueClicked
	{
		[CompilerGenerated]
		add
		{
			EventHandler eventHandler = eventHandler_0;
			EventHandler eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler value2 = (EventHandler)Delegate.Combine(eventHandler2, value);
				eventHandler = Interlocked.CompareExchange(ref eventHandler_0, value2, eventHandler2);
			}
			while ((object)eventHandler != eventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			EventHandler eventHandler = eventHandler_0;
			EventHandler eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler value2 = (EventHandler)Delegate.Remove(eventHandler2, value);
				eventHandler = Interlocked.CompareExchange(ref eventHandler_0, value2, eventHandler2);
			}
			while ((object)eventHandler != eventHandler2);
		}
	}

	public event EventHandler CaptionClicked
	{
		[CompilerGenerated]
		add
		{
			EventHandler eventHandler = eventHandler_1;
			EventHandler eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler value2 = (EventHandler)Delegate.Combine(eventHandler2, value);
				eventHandler = Interlocked.CompareExchange(ref eventHandler_1, value2, eventHandler2);
			}
			while ((object)eventHandler != eventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			EventHandler eventHandler = eventHandler_1;
			EventHandler eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler value2 = (EventHandler)Delegate.Remove(eventHandler2, value);
				eventHandler = Interlocked.CompareExchange(ref eventHandler_1, value2, eventHandler2);
			}
			while ((object)eventHandler != eventHandler2);
		}
	}

	public event EventHandler ValueDoubleClicked
	{
		[CompilerGenerated]
		add
		{
			EventHandler eventHandler = eventHandler_2;
			EventHandler eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler value2 = (EventHandler)Delegate.Combine(eventHandler2, value);
				eventHandler = Interlocked.CompareExchange(ref eventHandler_2, value2, eventHandler2);
			}
			while ((object)eventHandler != eventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			EventHandler eventHandler = eventHandler_2;
			EventHandler eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler value2 = (EventHandler)Delegate.Remove(eventHandler2, value);
				eventHandler = Interlocked.CompareExchange(ref eventHandler_2, value2, eventHandler2);
			}
			while ((object)eventHandler != eventHandler2);
		}
	}

	public buSpin()
	{
		Class76.smethod_549();
		if (base.Parent != null)
		{
			BackColor = base.Parent.BackColor;
		}
		TabStop = false;
		TextAlign = ContentAlignment.MiddleCenter;
		base.Image = null;
		UseMnemonic = true;
		base.ImageList = null;
		base.ImageAlign = ContentAlignment.MiddleCenter;
		Class76.smethod_843(UseMnemonic, this);
		flatStyle_0 = FlatStyle.Standard;
		base.Display.BackColor = Color.WhiteSmoke;
		base.Display.Parent = this;
		base.Geometry.Parent = this;
		base.Language.Parent = this;
		base.Caption.Parent = this;
		base.Caption.Display.Parent = this;
		base.Unit.Parent = this;
		base.Unit.Display.Parent = this;
		ButtonDownDisplay.Parent = this;
		ButtonNormalDisplay.Parent = this;
		ButtonOverDisplay.Parent = this;
		base.Theme.Parent = this;
		base.Aux.Parent = this;
		base.CheckTick.Parent = this;
		base.CheckTick.TickDisplay.Parent = this;
		base.CheckTick.ColorModeDisplay.Parent = this;
		base.FocusControl.Parent = this;
		ButtonDownDisplay.Fonts.Alignment = ContentAlignment.MiddleCenter;
		ButtonNormalDisplay.Fonts.Alignment = ContentAlignment.MiddleCenter;
		ButtonOverDisplay.Fonts.Alignment = ContentAlignment.MiddleCenter;
		ButtonOverDisplay.BackColor = Color.Gray;
		ButtonDownDisplay.BackColor = Color.DimGray;
		base.CheckTick.Visible = false;
		base.CheckTick.TickDisplay.BackColor = Color.WhiteSmoke;
		Class76.smethod_771(this);
		txt.KeyPress += txt_KeyPress;
		txt.KeyDown += txt_KeyDown;
		txt.KeyUp += txt_KeyUp;
		txt.TextChanged += txt_TextChanged;
		txt.Enter += txt_Enter;
		txt.Leave += txt_Leave;
		txt.Click += txt_Click;
		txt.DoubleClick += txt_DoubleClick;
		timer_1 = new System.Windows.Forms.Timer();
		timer_1.Interval = LongTimePressTime;
		timer_1.Tick += timer_1_Tick;
		timer_0 = new System.Windows.Forms.Timer();
		timer_0.Interval = LongTimeIncreaseTime;
		timer_0.Tick += timer_0_Tick;
		base.Controls.Add(txt);
		SetStyle(ControlStyles.Selectable, value: false);
		SetStyle(ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.SupportsTransparentBackColor | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, value: true);
	}

	public void SelectAll()
	{
		txt.SelectAll();
		txt.Focus();
	}

	public void CursorToEnd()
	{
		txt.SelectionStart = txt.Text.Length;
		txt.SelectionLength = 0;
	}

	protected override AccessibleObject CreateAccessibilityInstance()
	{
		return base.CreateAccessibilityInstance();
	}

	protected override void Dispose(bool disposing)
	{
		base.Dispose(disposing);
	}

	protected override void OnClick(EventArgs e)
	{
		if (!buControlCommands.bool_0)
		{
			buControlCommands.smethod_0("buSpin");
			if (!buControlCommands.bool_0)
			{
				MessageBox.Show("License Error");
				return;
			}
		}
		if (base.Enabled)
		{
			base.OnClick(e);
		}
	}

	protected override void OnEnabledChanged(EventArgs e)
	{
		base.OnEnabledChanged(e);
	}

	protected override void OnFontChanged(EventArgs e)
	{
		base.OnFontChanged(e);
		Invalidate();
	}

	protected override void OnPaddingChanged(EventArgs e)
	{
		base.OnPaddingChanged(e);
	}

	protected override void OnParentChanged(EventArgs e)
	{
		base.OnParentChanged(e);
	}

	protected override void OnRightToLeftChanged(EventArgs e)
	{
		base.OnRightToLeftChanged(e);
	}

	protected virtual void OnTextAlignChanged(EventArgs e)
	{
		((EventHandler)base.Events[object_1])?.Invoke(this, e);
	}

	protected override void OnTextChanged(EventArgs e)
	{
		base.OnTextChanged(e);
		Invalidate();
	}

	protected override void OnVisibleChanged(EventArgs e)
	{
		base.OnVisibleChanged(e);
	}

	protected override void OnMouseUp(MouseEventArgs e)
	{
		Invalidate();
		timer_1.Stop();
		timer_0.Stop();
		base.OnMouseUp(e);
	}

	protected override void OnMouseDown(MouseEventArgs e)
	{
		bool_4 = false;
		if (!buControlCommands.bool_0)
		{
			buControlCommands.smethod_0("buSpin");
			if (!buControlCommands.bool_0)
			{
				MessageBox.Show("License Error");
				return;
			}
		}
		if (ReadOnly || !base.Enabled)
		{
			return;
		}
		bool_4 = true;
		if (!ReadOnly & base.Enabled)
		{
			if ((((float)e.X >= rectDraw_2.rect.X) & ((float)e.X <= rectDraw_2.rect.X + rectDraw_2.rect.Width)) && (((float)e.Y >= rectDraw_2.rect.Y) & ((float)e.Y <= rectDraw_2.rect.Y + rectDraw_2.rect.Height)))
			{
				Check = !Check;
				if (buCheckedChangedEventHandler_0 != null)
				{
					buCheckedChangedEventHandler_0(this, Check);
				}
				if (buClickAfterEventHandler_0 != null)
				{
					buClickAfterEventHandler_0(this, Check);
				}
			}
			if ((((float)e.X >= rectDraw_4.rect.X) & ((float)e.X <= rectDraw_4.rect.X + rectDraw_4.rect.Width)) && (((float)e.Y >= rectDraw_4.rect.Y) & ((float)e.Y <= rectDraw_4.rect.Y + rectDraw_4.rect.Height)) && eventHandler_1 != null)
			{
				eventHandler_1(this, new EventArgs());
			}
		}
		if (!ButtonShow)
		{
			return;
		}
		if ((((float)e.X >= rectDraw_1.rect.X) & ((float)e.X <= rectDraw_1.rect.X + rectDraw_1.rect.Width)) && (((float)e.Y >= rectDraw_1.rect.Y) & ((float)e.Y <= rectDraw_1.rect.Y + rectDraw_1.rect.Height)))
		{
			MouseStateMinus = MouseState.Down;
			MouseStatePlus = MouseState.None;
			Value -= IncrementStep;
			if (LongTimePressEnable)
			{
				timer_1.Start();
			}
		}
		if ((((float)e.X >= rectDraw_0.rect.X) & ((float)e.X <= rectDraw_0.rect.X + rectDraw_0.rect.Width)) && (((float)e.Y >= rectDraw_0.rect.Y) & ((float)e.Y <= rectDraw_0.rect.Y + rectDraw_0.rect.Height)))
		{
			MouseStateMinus = MouseState.None;
			MouseStatePlus = MouseState.Down;
			Value += IncrementStep;
			if (LongTimePressEnable)
			{
				timer_1.Start();
			}
		}
		Invalidate();
		base.OnMouseDown(e);
	}

	protected override void OnMouseMove(MouseEventArgs e)
	{
		bool flag = false;
		bool flag2 = false;
		Cursor = Cursors.Default;
		if ((((float)e.X >= rectDraw_1.rect.X) & ((float)e.X <= rectDraw_1.rect.X + rectDraw_1.rect.Width)) && (((float)e.Y >= rectDraw_1.rect.Y) & ((float)e.Y <= rectDraw_1.rect.Y + rectDraw_1.rect.Height)))
		{
			MouseStateMinus = MouseState.Move;
			MouseStatePlus = MouseState.None;
			flag2 = true;
		}
		if (!flag2)
		{
			MouseStateMinus = MouseState.None;
		}
		if ((((float)e.X >= rectDraw_0.rect.X) & ((float)e.X <= rectDraw_0.rect.X + rectDraw_0.rect.Width)) && (((float)e.Y >= rectDraw_0.rect.Y) & ((float)e.Y <= rectDraw_0.rect.Y + rectDraw_0.rect.Height)))
		{
			MouseStateMinus = MouseState.None;
			MouseStatePlus = MouseState.Move;
			flag = true;
		}
		if (!flag)
		{
			MouseStatePlus = MouseState.None;
		}
		Invalidate();
		base.OnMouseMove(e);
	}

	protected override void OnMouseEnter(EventArgs e)
	{
		base.OnMouseEnter(e);
	}

	protected override void OnMouseLeave(EventArgs e)
	{
		MouseStateMinus = MouseState.None;
		MouseStatePlus = MouseState.None;
		bool_4 = false;
		Invalidate();
		base.OnMouseLeave(e);
	}

	protected override void OnMouseWheel(MouseEventArgs e)
	{
		base.OnMouseWheel(e);
		if (!MouseWheelEnable || ReadOnly)
		{
			return;
		}
		if (e.Delta <= 0)
		{
			if (Value - IncrementStep >= MinValue)
			{
				Value -= IncrementStep;
				txt.Text = Value.ToString("f" + DecimalPoint);
			}
			Invalidate();
		}
		else
		{
			if (Value + IncrementStep <= MaxValue)
			{
				Value += IncrementStep;
				txt.Text = Value.ToString("f" + DecimalPoint);
			}
			Invalidate();
		}
	}

	protected override void OnHandleDestroyed(EventArgs e)
	{
		base.OnHandleDestroyed(e);
	}

	protected override void OnKeyPress(KeyPressEventArgs e)
	{
		if (Value > MaxValue)
		{
			Value = MaxValue;
		}
		base.OnKeyPress(e);
	}

	protected override void OnKeyDown(KeyEventArgs e)
	{
		base.OnKeyDown(e);
	}

	protected override void OnKeyUp(KeyEventArgs e)
	{
		if (e.KeyCode != Keys.Back)
		{
		}
		base.OnKeyUp(e);
	}

	protected override void OnGotFocus(EventArgs e)
	{
		txt.Focus();
		base.OnGotFocus(e);
	}

	protected override bool ProcessMnemonic(char charCode)
	{
		if (!Control.IsMnemonic(charCode, Text))
		{
			return base.ProcessMnemonic(charCode);
		}
		if (base.Parent != null)
		{
			base.Parent.SelectNextControl(this, forward: true, tabStopOnly: false, nested: false, wrap: false);
		}
		return true;
	}

	protected override void SetBoundsCore(int x, int y, int width, int height, BoundsSpecified specified)
	{
		base.SetBoundsCore(x, y, width, height, specified);
	}

	public override string ToString()
	{
		return base.ToString() + ", Text: " + Text;
	}

	private void txt_KeyPress(object sender, KeyPressEventArgs e)
	{
		if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.' && e.KeyChar != '-')
		{
			e.Handled = true;
		}
		if (e.KeyChar == '.' && (sender as TextBox).Text.IndexOf('.') > -1)
		{
			e.Handled = true;
		}
		if (e.KeyChar == '\r')
		{
		}
		OnKeyPress(e);
	}

	private void txt_KeyDown(object sender, KeyEventArgs e)
	{
		if (e.KeyCode == Keys.Return)
		{
			double result = 0.0;
			double.TryParse(txt.Text.Trim(), out result);
			if (result > MaxValue)
			{
				result = (Value = MaxValue);
				txt.Text = Value.ToString("f" + DecimalPoint);
			}
			if (result < MinValue)
			{
				result = (Value = MinValue);
				txt.Text = Value.ToString("f" + DecimalPoint);
			}
			Value = result;
			if (buValueChangedEvent_0 != null && KeyDownValueChangeEvent)
			{
				buValueChangedEvent_0(this, Value);
				double_0 = Value;
			}
			OnKeyDown(e);
		}
	}

	private void txt_KeyUp(object sender, KeyEventArgs e)
	{
		OnKeyUp(e);
	}

	private void txt_Enter(object sender, EventArgs e)
	{
		Invalidate();
	}

	private void txt_Leave(object sender, EventArgs e)
	{
		bool_10 = false;
		double result = 0.0;
		double.TryParse(txt.Text.Trim(), out result);
		if (result > MaxValue)
		{
			result = (Value = MaxValue);
			txt.Text = Value.ToString("f" + DecimalPoint);
		}
		if (result < MinValue)
		{
			result = (Value = MinValue);
			txt.Text = Value.ToString("f" + DecimalPoint);
		}
		Value = result;
		txt.Text = Value.ToString("f" + DecimalPoint);
		Invalidate();
	}

	private void txt_Click(object sender, EventArgs e)
	{
		bool_10 = true;
		if (!buControlCommands.bool_0)
		{
			buControlCommands.smethod_0("buSpin");
			if (!buControlCommands.bool_0)
			{
				MessageBox.Show("License Error");
				return;
			}
		}
		if (eventHandler_0 != null)
		{
			eventHandler_0(this, e);
		}
		Invalidate();
		OnClick(e);
	}

	private void txt_DoubleClick(object sender, EventArgs e)
	{
		if (eventHandler_2 != null)
		{
			eventHandler_2(this, e);
		}
		OnDoubleClick(e);
	}

	private void txt_TextChanged(object sender, EventArgs e)
	{
		if (txt.Text.Trim().Length <= 0)
		{
			return;
		}
		double result = 0.0;
		double.TryParse(txt.Text.Trim(), out result);
		if (result > MaxValue)
		{
			result = (double_1 = MaxValue);
			if (DecimalPoint <= 0)
			{
				txt.Text = Convert.ToInt32(double_1).ToString();
			}
			else
			{
				txt.Text = double_1.ToString("f" + DecimalPoint);
			}
		}
		if (result < MinValue)
		{
			result = (double_1 = MinValue);
			if (DecimalPoint <= 0)
			{
				txt.Text = Convert.ToInt32(double_1).ToString();
			}
			else
			{
				txt.Text = double_1.ToString("f" + DecimalPoint);
			}
		}
		double_1 = result;
		if (buValueChangedEvent_0 != null)
		{
			if ((!KeyDownValueChangeEvent | bool_4) && Value != double_0)
			{
				buValueChangedEvent_0(this, Value);
			}
			double_0 = Value;
		}
	}

	private void timer_1_Tick(object sender, EventArgs e)
	{
		timer_0.Start();
		timer_1.Stop();
	}

	private void timer_0_Tick(object sender, EventArgs e)
	{
		if (MouseStatePlus == MouseState.Down)
		{
			Value += IncrementStep;
		}
		if (MouseStateMinus == MouseState.Down)
		{
			Value -= IncrementStep;
		}
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
		string caption = base.Caption.Caption;
		Graphics Grph = e.Graphics;
		if (base.Theme.Type != themeType_0)
		{
			buControlThemeVars Vars = new buControlThemeVars();
			buControlTheme.UpdateTheme(base.Theme.Type, ref Vars);
			base.Geometry = new buControlGeometry(Vars.Geometry);
			base.Display = new buControlDisplay(Vars.DisplayText);
			ButtonDownDisplay = new buControlDisplay(Vars.DisplayButtonDown);
			ButtonNormalDisplay = new buControlDisplay(Vars.DisplayButtonNormal);
			ButtonOverDisplay = new buControlDisplay(Vars.DisplayButtonOver);
			base.Caption.Display = new buControlDisplay(Vars.Caption.Display);
			base.Caption.Parent = this;
			base.Caption.Display.Parent = this;
			base.Display.Parent = this;
			ButtonDownDisplay.Parent = this;
			ButtonNormalDisplay.Parent = this;
			ButtonOverDisplay.Parent = this;
			base.CheckTick.Parent = this;
			base.CheckTick.ColorModeDisplay.Parent = this;
			base.CheckTick.TickDisplay.Parent = this;
			base.Language.Parent = this;
			base.Theme.Parent = this;
			base.Unit.Parent = this;
			base.Unit.Display.Parent = this;
			base.Aux.Parent = this;
			base.FocusControl.Parent = this;
		}
		buControlDisplay buControlDisplay2 = new buControlDisplay(base.Display);
		buControlDisplay display = new buControlDisplay(ButtonNormalDisplay);
		buControlDisplay display2 = new buControlDisplay(ButtonNormalDisplay);
		if (MouseStatePlus == MouseState.Move)
		{
			display = new buControlDisplay(ButtonOverDisplay);
		}
		if (MouseStatePlus == MouseState.Down)
		{
			display = new buControlDisplay(ButtonDownDisplay);
		}
		if (MouseStateMinus == MouseState.Move)
		{
			display2 = new buControlDisplay(ButtonOverDisplay);
		}
		if (MouseStateMinus == MouseState.Down)
		{
			display2 = new buControlDisplay(ButtonDownDisplay);
		}
		if (base.Enabled & bool_10 & base.FocusControl.Enable)
		{
			buControlDisplay2.BackColor = base.FocusControl.FocusColor;
			buControlDisplay2.GradientType = GradientMode.Solid;
		}
		caption = ControlGeometry.LanguageSelect(base.Language, caption);
		bool_8 = false;
		if ((base.Width > 0) & (base.Height > 0))
		{
			if (!base.Enabled && (!bool_12 | (base.Enabled != bool_11)))
			{
				buControlDisplay2.GradientType = GradientMode.Solid;
				buControlDisplay2.BackColor = buControlDisplay2.DisableColor;
			}
			bool_11 = base.Enabled;
			ControlGeometry.CalcMainArea(base.Width, base.Height, base.Geometry, base.Caption, ref rectDraw_4, ref rectangleF_0);
			if (!ButtonShow)
			{
				rectDraw_1 = new rectDraw();
				rectDraw_0 = new rectDraw();
			}
			else
			{
				if (ButtonType == SpinButtonType.LeftRight)
				{
					if (!base.Caption.OnTop)
					{
						rectDraw_1 = new rectDraw(new RectangleF(rectangleF_0.X + (float)ButtonSpace, rectangleF_0.Y + (float)ButtonSpace - 0f, ButtonWidth, rectangleF_0.Height - (float)(ButtonSpace * 2) + 0f), RoundRectangleType.RoundRectLeft);
						rectDraw_0 = new rectDraw(new RectangleF(rectangleF_0.X + rectangleF_0.Width - (float)ButtonWidth - (float)ButtonSpace, rectangleF_0.Y + (float)ButtonSpace - 0f, ButtonWidth, rectangleF_0.Height - (float)(ButtonSpace * 2) + 0f), RoundRectangleType.RoundRectRight);
					}
					else
					{
						rectDraw_1 = new rectDraw(new RectangleF(rectangleF_0.X + (float)ButtonSpace, rectangleF_0.Y + (float)ButtonSpace - 1f, ButtonWidth, rectangleF_0.Height - (float)(ButtonSpace * 2) + 1f), RoundRectangleType.RoundRectLeft);
						rectDraw_0 = new rectDraw(new RectangleF(rectangleF_0.X + rectangleF_0.Width - (float)ButtonWidth - (float)ButtonSpace, rectangleF_0.Y + (float)ButtonSpace - 1f, ButtonWidth, rectangleF_0.Height - (float)(ButtonSpace * 2) + 1f), RoundRectangleType.RoundRectRight);
						rectDraw_1.RoundType = RoundRectangleType.RoundRectLeftDown;
						rectDraw_0.RoundType = RoundRectangleType.RoundRectRightDown;
					}
				}
				if (ButtonType == SpinButtonType.UpDown)
				{
					if (!base.Caption.OnTop)
					{
						rectDraw_0 = new rectDraw(new RectangleF(rectangleF_0.X + rectangleF_0.Width - (float)ButtonWidth - (float)ButtonSpace, rectangleF_0.Y + (float)ButtonSpace, ButtonWidth, rectangleF_0.Height / 2f - (float)(ButtonSpace * 2)), RoundRectangleType.RoundRectUp);
						rectDraw_1 = new rectDraw(new RectangleF(rectangleF_0.X + rectangleF_0.Width - (float)ButtonWidth - (float)ButtonSpace, rectDraw_0.rect.Y + rectDraw_0.rect.Height - 1f, ButtonWidth, rectangleF_0.Height / 2f - (float)(ButtonSpace * 2) + 1f), RoundRectangleType.RoundRectDown);
						rectDraw_0.RoundType = RoundRectangleType.RoundRectRightUp;
						rectDraw_1.RoundType = RoundRectangleType.RoundRectRightDown;
					}
					else
					{
						rectDraw_0 = new rectDraw(new RectangleF(rectangleF_0.X + rectangleF_0.Width - (float)ButtonWidth - (float)ButtonSpace, rectangleF_0.Y + (float)ButtonSpace - 1f, ButtonWidth, rectangleF_0.Height / 2f - (float)(ButtonSpace * 2)), RoundRectangleType.RoundRectUp);
						rectDraw_1 = new rectDraw(new RectangleF(rectangleF_0.X + rectangleF_0.Width - (float)ButtonWidth - (float)ButtonSpace, rectDraw_0.rect.Y + rectDraw_0.rect.Height - 1f, ButtonWidth, rectangleF_0.Height / 2f - (float)(ButtonSpace * 2) + 2f), RoundRectangleType.RoundRectDown);
						rectDraw_0.RoundType = RoundRectangleType.RoundRectNone;
						rectDraw_1.RoundType = RoundRectangleType.RoundRectRightDown;
					}
				}
			}
			Class76.smethod_771(this);
			ControlGeometry.drawGeometry(base.ClientRectangle, base.Geometry, buControlDisplay2, RoundRectangleType.RoundRectAll, ref Grph);
			if (base.Caption.Visible)
			{
				if (!base.Caption.OnTop)
				{
					int num = 2;
					if (base.Geometry.ShapeMode == ShapeType.Arc)
					{
						num = ButtonWidth / 2;
					}
					rectDraw_4.rect.X = rectDraw_4.rect.X - 1f;
					rectDraw_4.rect.Y = rectDraw_4.rect.Y - 1f;
					rectDraw_4.rect.Width = rectDraw_4.rect.Width + (float)num;
					rectDraw_4.rect.Height = rectDraw_4.rect.Height + 2f;
					ControlGeometry.drawGeometry(rectDraw_4.rect, base.Geometry, base.Caption.Display, rectDraw_4.RoundType, ref Grph);
					ControlGeometry.drawString(rectDraw_4.rectText, caption, base.Caption.Display, hotkeyPrefix_0, ref Grph);
				}
				else
				{
					rectDraw_4.rect.X = rectDraw_4.rect.X - 1f;
					rectDraw_4.rect.Y = rectDraw_4.rect.Y - 1f;
					rectDraw_4.rect.Width = rectDraw_4.rect.Width + 1f;
					rectDraw_4.rect.Height = rectDraw_4.rect.Height + 1f;
					ControlGeometry.drawGeometry(rectDraw_4.rect, base.Geometry, base.Caption.Display, rectDraw_4.RoundType, ref Grph);
					ControlGeometry.drawString(rectDraw_4.rectText, caption, base.Caption.Display, hotkeyPrefix_0, ref Grph);
				}
			}
			if (((base.Unit.Visible & !base.Caption.OnTop) | bool_8) & base.Caption.Visible)
			{
				ControlGeometry.drawGeometry(rectDraw_3.rect, base.Geometry, base.Unit.Display, rectDraw_3.RoundType, ref Grph);
				if (base.Unit.Visible & !base.Caption.OnTop & base.Caption.Visible)
				{
					ControlGeometry.drawString(rectDraw_3.rectText, base.Unit.Caption, base.Unit.Display, hotkeyPrefix_0, ref Grph);
				}
			}
			if (base.CheckTick.Visible & base.Caption.Visible)
			{
				int num2 = base.Width - base.CheckTick.BoxSize - base.CheckTick.Space;
				rectDraw_2 = new rectDraw(new RectangleF(num2, (float)base.Height / 2f - (float)base.CheckTick.BoxSize / 2f, base.CheckTick.BoxSize, base.CheckTick.BoxSize), RoundRectangleType.RoundRectNone);
				if (Check)
				{
					Grph.DrawString("ü", new Font("Wingdings", Convert.ToInt32((double)base.CheckTick.BoxSize * 1.5)), new SolidBrush(base.CheckTick.TickDisplay.Fonts.ForeColor), new RectangleF(rectDraw_2.rect.X - 8f, rectDraw_2.rect.Y, rectDraw_2.rect.Width + 15f, rectDraw_2.rect.Height), new StringFormat
					{
						LineAlignment = StringAlignment.Center
					});
				}
			}
			if (ButtonShow)
			{
				ControlGeometry.drawGeometry(rectDraw_1.rect, base.Geometry, display2, rectDraw_1.RoundType, ref Grph);
				ControlGeometry.drawString(rectDraw_1.rect, "-", display2, hotkeyPrefix_0, ref Grph);
				ControlGeometry.drawGeometry(rectDraw_0.rect, base.Geometry, display, rectDraw_0.RoundType, ref Grph);
				ControlGeometry.drawString(rectDraw_0.rect, "+", display, hotkeyPrefix_0, ref Grph);
			}
			DrawImage(e.Graphics, base.Image, new Rectangle((int)rectDraw_4.rect.X, (int)rectDraw_4.rect.Y, (int)rectDraw_4.rect.Width, (int)rectDraw_4.rect.Height), base.ImageAlign);
		}
		themeType_0 = base.Theme.Type;
		bool_12 = true;
		base.OnPaint(e);
	}
}
