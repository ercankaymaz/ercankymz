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

[DefaultProperty("Text")]
[DefaultEvent("TextChanged")]
[ClassInterface(ClassInterfaceType.AutoDispatch)]
[ComVisible(true)]
[ToolboxBitmap(typeof(Label))]
[DefaultBindingProperty("Text")]
public class buTextBox : buCaptionBaseControl
{
	private bool bool_0 = false;

	private bool bool_1 = false;

	private int int_3 = 32000;

	private ScrollBars scrollBars_0 = ScrollBars.None;

	private bool bool_2 = true;

	private bool bool_3 = false;

	private char char_0 = '\0';

	private FlatStyle flatStyle_0;

	private bool bool_4;

	private bool bool_5 = false;

	internal RectangleF rectangleF_0 = default(RectangleF);

	private rectDraw rectDraw_0 = new rectDraw();

	private rectDraw rectDraw_1 = new rectDraw();

	private rectDraw rectDraw_2 = new rectDraw();

	internal bool bool_6 = false;

	private ThemeType themeType_0 = ThemeType.Standart;

	internal HotkeyPrefix hotkeyPrefix_0 = HotkeyPrefix.None;

	public TextBox txt = new TextBox();

	private static object object_0 = new object();

	private static object object_1 = new object();

	[CompilerGenerated]
	private buControlEvents.buCheckedChangedEventHandler buCheckedChangedEventHandler_0;

	[CompilerGenerated]
	private buControlEvents.buClickAfterEventHandler buClickAfterEventHandler_0;

	[CompilerGenerated]
	private KeyEventHandler keyEventHandler_0;

	[CompilerGenerated]
	private buControlEvents.buTextChangedEvent buTextChangedEvent_0;

	[CompilerGenerated]
	private EventHandler eventHandler_0;

	[CompilerGenerated]
	private EventHandler eventHandler_1;

	[CompilerGenerated]
	private EventHandler eventHandler_2;

	[SettingsBindable(true)]
	public override string Text
	{
		get
		{
			return base.Text;
		}
		set
		{
			if (!base.Security.Enable || base.Security.Level >= buControl.SecurityActive)
			{
				txt.Text = value;
				base.Text = value;
			}
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
			return bool_4;
		}
		set
		{
			if (bool_4 != value)
			{
				bool_4 = value;
				Class76.smethod_802(bool_4, this);
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
			return bool_3;
		}
		set
		{
			bool_3 = value;
			txt.ReadOnly = bool_3;
			Invalidate();
		}
	}

	[DefaultValue(true)]
	[EditorBrowsable(EditorBrowsableState.Always)]
	[NotifyParentProperty(true)]
	[Browsable(true)]
	public int MaxLength
	{
		get
		{
			return int_3;
		}
		set
		{
			int_3 = value;
			txt.MaxLength = MaxLength;
			Invalidate();
		}
	}

	[DefaultValue(ScrollBars.None)]
	[EditorBrowsable(EditorBrowsableState.Always)]
	[NotifyParentProperty(true)]
	[Browsable(true)]
	public ScrollBars ScrollBar
	{
		get
		{
			return scrollBars_0;
		}
		set
		{
			scrollBars_0 = value;
			txt.ScrollBars = scrollBars_0;
			Invalidate();
		}
	}

	[DefaultValue(true)]
	[EditorBrowsable(EditorBrowsableState.Always)]
	[NotifyParentProperty(true)]
	[Browsable(true)]
	public bool WordWrap
	{
		get
		{
			return bool_2;
		}
		set
		{
			bool_2 = value;
			txt.WordWrap = bool_2;
			Invalidate();
		}
	}

	[DefaultValue('\0')]
	[EditorBrowsable(EditorBrowsableState.Always)]
	[NotifyParentProperty(true)]
	[Browsable(true)]
	public char PasswordChar
	{
		get
		{
			return char_0;
		}
		set
		{
			char_0 = value;
			txt.PasswordChar = char_0;
			Invalidate();
		}
	}

	[DefaultValue(false)]
	[EditorBrowsable(EditorBrowsableState.Always)]
	[NotifyParentProperty(true)]
	[Browsable(true)]
	public bool Multiline
	{
		get
		{
			return bool_1;
		}
		set
		{
			bool_1 = value;
			if (txt != null)
			{
				txt.Multiline = value;
			}
			Class76.smethod_423(this);
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

	public event KeyEventHandler TextKeyDown
	{
		[CompilerGenerated]
		add
		{
			KeyEventHandler keyEventHandler = keyEventHandler_0;
			KeyEventHandler keyEventHandler2;
			do
			{
				keyEventHandler2 = keyEventHandler;
				KeyEventHandler value2 = (KeyEventHandler)Delegate.Combine(keyEventHandler2, value);
				keyEventHandler = Interlocked.CompareExchange(ref keyEventHandler_0, value2, keyEventHandler2);
			}
			while ((object)keyEventHandler != keyEventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			KeyEventHandler keyEventHandler = keyEventHandler_0;
			KeyEventHandler keyEventHandler2;
			do
			{
				keyEventHandler2 = keyEventHandler;
				KeyEventHandler value2 = (KeyEventHandler)Delegate.Remove(keyEventHandler2, value);
				keyEventHandler = Interlocked.CompareExchange(ref keyEventHandler_0, value2, keyEventHandler2);
			}
			while ((object)keyEventHandler != keyEventHandler2);
		}
	}

	public event buControlEvents.buTextChangedEvent TextEditChanged
	{
		[CompilerGenerated]
		add
		{
			buControlEvents.buTextChangedEvent buTextChangedEvent = buTextChangedEvent_0;
			buControlEvents.buTextChangedEvent buTextChangedEvent2;
			do
			{
				buTextChangedEvent2 = buTextChangedEvent;
				buControlEvents.buTextChangedEvent value2 = (buControlEvents.buTextChangedEvent)Delegate.Combine(buTextChangedEvent2, value);
				buTextChangedEvent = Interlocked.CompareExchange(ref buTextChangedEvent_0, value2, buTextChangedEvent2);
			}
			while ((object)buTextChangedEvent != buTextChangedEvent2);
		}
		[CompilerGenerated]
		remove
		{
			buControlEvents.buTextChangedEvent buTextChangedEvent = buTextChangedEvent_0;
			buControlEvents.buTextChangedEvent buTextChangedEvent2;
			do
			{
				buTextChangedEvent2 = buTextChangedEvent;
				buControlEvents.buTextChangedEvent value2 = (buControlEvents.buTextChangedEvent)Delegate.Remove(buTextChangedEvent2, value);
				buTextChangedEvent = Interlocked.CompareExchange(ref buTextChangedEvent_0, value2, buTextChangedEvent2);
			}
			while ((object)buTextChangedEvent != buTextChangedEvent2);
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

	public event EventHandler ValueDoubleClicked
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

	public event EventHandler CaptionClicked
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

	public buTextBox()
	{
		Class76.smethod_608();
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
		Class76.smethod_802(UseMnemonic, this);
		flatStyle_0 = FlatStyle.Standard;
		base.Display.BackColor = Color.WhiteSmoke;
		base.Display.Parent = this;
		base.Geometry.Parent = this;
		base.Language.Parent = this;
		base.Caption.Parent = this;
		base.Caption.Display.Parent = this;
		base.Unit.Parent = this;
		base.Unit.Display.Parent = this;
		base.Theme.Parent = this;
		base.Aux.Parent = this;
		base.CheckTick.Parent = this;
		base.CheckTick.TickDisplay.Parent = this;
		base.CheckTick.ColorModeDisplay.Parent = this;
		base.FocusControl.Parent = this;
		base.CheckTick.TickDisplay.BackColor = Color.WhiteSmoke;
		Class76.smethod_423(this);
		txt.KeyPress += txt_KeyPress;
		txt.KeyDown += txt_KeyDown;
		txt.KeyUp += txt_KeyUp;
		txt.TextChanged += txt_TextChanged;
		txt.Enter += txt_Enter;
		txt.Leave += txt_Leave;
		txt.Click += txt_Click;
		txt.DoubleClick += txt_DoubleClick;
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
			buControlCommands.smethod_0("buTextBox");
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
		base.OnMouseUp(e);
	}

	protected override void OnMouseDown(MouseEventArgs e)
	{
		if (!buControlCommands.bool_0)
		{
			buControlCommands.smethod_0("buTextBox");
			if (!buControlCommands.bool_0)
			{
				MessageBox.Show("License Error");
				return;
			}
		}
		if (!ReadOnly)
		{
			if ((((float)e.X >= rectDraw_0.rect.X) & ((float)e.X <= rectDraw_0.rect.X + rectDraw_0.rect.Width)) && (((float)e.Y >= rectDraw_0.rect.Y) & ((float)e.Y <= rectDraw_0.rect.Y + rectDraw_0.rect.Height)))
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
			if ((((float)e.X >= rectDraw_2.rect.X) & ((float)e.X <= rectDraw_2.rect.X + rectDraw_2.rect.Width)) && (((float)e.Y >= rectDraw_2.rect.Y) & ((float)e.Y <= rectDraw_2.rect.Y + rectDraw_2.rect.Height)) && eventHandler_2 != null)
			{
				eventHandler_2(this, new EventArgs());
			}
		}
		Invalidate();
		base.OnMouseDown(e);
	}

	protected override void OnMouseMove(MouseEventArgs e)
	{
		Cursor = Cursors.Default;
		Invalidate();
		base.OnMouseMove(e);
	}

	protected override void OnMouseEnter(EventArgs e)
	{
		base.OnMouseEnter(e);
	}

	protected override void OnMouseLeave(EventArgs e)
	{
		base.OnMouseLeave(e);
		Invalidate();
	}

	protected override void OnHandleDestroyed(EventArgs e)
	{
		base.OnHandleDestroyed(e);
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
		if (e.KeyChar != '\r')
		{
		}
		OnKeyPress(e);
	}

	private void txt_KeyUp(object sender, KeyEventArgs e)
	{
		OnKeyUp(e);
	}

	private void txt_KeyDown(object sender, KeyEventArgs e)
	{
		if (e.KeyCode != Keys.Return)
		{
		}
		if (keyEventHandler_0 != null)
		{
			keyEventHandler_0(this, e);
		}
		OnKeyDown(e);
	}

	private void txt_Enter(object sender, EventArgs e)
	{
		Invalidate();
	}

	private void txt_Leave(object sender, EventArgs e)
	{
		bool_6 = false;
		Invalidate();
	}

	private void txt_Click(object sender, EventArgs e)
	{
		bool_6 = true;
		if (eventHandler_0 != null)
		{
			eventHandler_0(this, e);
		}
		Invalidate();
		OnClick(e);
	}

	private void txt_DoubleClick(object sender, EventArgs e)
	{
		if (!buControlCommands.bool_0)
		{
			buControlCommands.smethod_0("buTextBox");
			if (!buControlCommands.bool_0)
			{
				MessageBox.Show("License Error");
				return;
			}
		}
		if (eventHandler_1 != null)
		{
			eventHandler_1(this, e);
		}
		OnDoubleClick(e);
	}

	private void txt_TextChanged(object sender, EventArgs e)
	{
		Text = txt.Text;
		if (buTextChangedEvent_0 != null)
		{
			buTextChangedEvent_0(this, txt.Text);
		}
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
		string caption = base.Caption.Caption;
		Graphics Grph = e.Graphics;
		if (base.Theme.Type != themeType_0)
		{
			buControlThemeVars Vars = new buControlThemeVars();
			buControlTheme.UpdateTheme(base.Theme.Type, ref Vars);
			base.Geometry = new buControlGeometry(Vars.Geometry);
			base.Display = new buControlDisplay(Vars.DisplayText);
			base.Caption.Display = new buControlDisplay(Vars.Caption.Display);
			base.Caption.Parent = this;
			base.Caption.Display.Parent = this;
			base.Display.Parent = this;
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
		if (base.Enabled & bool_6 & base.FocusControl.Enable)
		{
			buControlDisplay2.BackColor = base.FocusControl.FocusColor;
			buControlDisplay2.GradientType = GradientMode.Solid;
		}
		caption = ControlGeometry.LanguageSelect(base.Language, caption);
		bool_5 = false;
		if ((base.Width > 0) & (base.Height > 0))
		{
			ControlGeometry.CalcMainArea(base.Width, base.Height, base.Geometry, base.Caption, ref rectDraw_2, ref rectangleF_0);
			Class76.smethod_423(this);
			if (!base.Enabled)
			{
				buControlDisplay2.GradientType = GradientMode.Solid;
				buControlDisplay2.BackColor = buControlDisplay2.DisableColor;
			}
			ControlGeometry.drawGeometry(base.ClientRectangle, base.Geometry, buControlDisplay2, RoundRectangleType.RoundRectAll, ref Grph);
			if (base.Caption.Visible)
			{
				if (!base.Caption.OnTop)
				{
					rectDraw_2.rect.X = rectDraw_2.rect.X - 1f;
					rectDraw_2.rect.Y = rectDraw_2.rect.Y - 1f;
					rectDraw_2.rect.Width = rectDraw_2.rect.Width + 2f;
					rectDraw_2.rect.Height = rectDraw_2.rect.Height + 2f;
					ControlGeometry.drawGeometry(rectDraw_2.rect, base.Geometry, base.Caption.Display, rectDraw_2.RoundType, ref Grph);
					ControlGeometry.drawString(rectDraw_2.rectText, caption, base.Caption.Display, hotkeyPrefix_0, ref Grph);
				}
				else
				{
					rectDraw_2.rect.X = rectDraw_2.rect.X - 1f;
					rectDraw_2.rect.Y = rectDraw_2.rect.Y - 1f;
					rectDraw_2.rect.Width = rectDraw_2.rect.Width + 1f;
					rectDraw_2.rect.Height = rectDraw_2.rect.Height + 1f;
					ControlGeometry.drawGeometry(rectDraw_2.rect, base.Geometry, base.Caption.Display, rectDraw_2.RoundType, ref Grph);
					ControlGeometry.drawString(rectDraw_2.rectText, caption, base.Caption.Display, hotkeyPrefix_0, ref Grph);
				}
			}
			if (((base.Unit.Visible & !base.Caption.OnTop) | bool_5) & base.Caption.Visible)
			{
				ControlGeometry.drawGeometry(rectDraw_1.rect, base.Geometry, base.Unit.Display, rectDraw_1.RoundType, ref Grph);
				if (base.Unit.Visible & !base.Caption.OnTop & base.Caption.Visible)
				{
					ControlGeometry.drawString(rectDraw_1.rectText, base.Unit.Caption, base.Unit.Display, hotkeyPrefix_0, ref Grph);
				}
			}
			if (base.CheckTick.Visible & base.Caption.Visible)
			{
				ControlGeometry.drawGeometry(rectDraw_0.rect, base.CheckTick.ArcDiameter, base.CheckTick.Shape, base.CheckTick.TickDisplay, rectDraw_0.RoundType, ref Grph);
				if (Check)
				{
					Grph.DrawString("ü", new Font("Wingdings", Convert.ToInt32((double)base.CheckTick.BoxSize * 1.5)), new SolidBrush(base.CheckTick.TickDisplay.Fonts.ForeColor), new RectangleF(rectDraw_0.rect.X - 8f, rectDraw_0.rect.Y, rectDraw_0.rect.Width + 15f, rectDraw_0.rect.Height), new StringFormat
					{
						LineAlignment = StringAlignment.Center
					});
				}
			}
			DrawImage(e.Graphics, base.Image, new Rectangle((int)rectDraw_2.rect.X, (int)rectDraw_2.rect.Y, (int)rectDraw_2.rect.Width, (int)rectDraw_2.rect.Height), base.ImageAlign);
		}
		themeType_0 = base.Theme.Type;
		base.OnPaint(e);
	}
}
