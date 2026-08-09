using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Text;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows.Forms;
using ns27;

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

	[CompilerGenerated]
	private MouseEventHandler mouseEventHandler_0;

	[CompilerGenerated]
	private MouseEventHandler mouseEventHandler_1;

	[CompilerGenerated]
	private buControlEvents.buButtonPlusMinusClickEventHandler buButtonPlusMinusClickEventHandler_0;

	[CompilerGenerated]
	private buControlEvents.buButtonPlusMinusMouseEventHandler buButtonPlusMinusMouseEventHandler_0;

	[CompilerGenerated]
	private buControlEvents.buButtonPlusMinusMouseEventHandler buButtonPlusMinusMouseEventHandler_1;

	[CompilerGenerated]
	private buControlEvents.buButtonPlusMinusMouseEventHandler buButtonPlusMinusMouseEventHandler_2;

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	[Browsable(true)]
	public buControlDisplay ButtonPlusOverDisplay
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
	public buControlDisplay ButtonPlusNormalDisplay
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
	public buControlDisplay ButtonPlusDownDisplay
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

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	[Browsable(true)]
	public buControlDisplay ButtonMinusOverDisplay
	{
		get
		{
			return buControlDisplay_4;
		}
		set
		{
			buControlDisplay_4 = value;
			if (base.Parent != null)
			{
				base.Parent.Invalidate();
			}
		}
	}

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	[Browsable(true)]
	public buControlDisplay ButtonMinusNormalDisplay
	{
		get
		{
			return buControlDisplay_5;
		}
		set
		{
			buControlDisplay_5 = value;
			if (base.Parent != null)
			{
				base.Parent.Invalidate();
			}
		}
	}

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	[Browsable(true)]
	public buControlDisplay ButtonMinusDownDisplay
	{
		get
		{
			return buControlDisplay_6;
		}
		set
		{
			buControlDisplay_6 = value;
			if (base.Parent != null)
			{
				base.Parent.Invalidate();
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

	[DefaultValue(PlusMinusButtonStyle.Horizontal)]
	public PlusMinusButtonStyle ButtonStyle
	{
		get
		{
			return plusMinusButtonStyle_0;
		}
		set
		{
			plusMinusButtonStyle_0 = value;
			if (base.Parent != null)
			{
				base.Parent.Invalidate();
			}
			Invalidate();
		}
	}

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
			return bool_0;
		}
		set
		{
			if (bool_0 != value)
			{
				bool_0 = value;
				Class76.smethod_151(bool_0, this);
				Invalidate();
			}
		}
	}

	[SettingsBindable(true)]
	public override string Text
	{
		get
		{
			return base.Text;
		}
		set
		{
			base.Text = value;
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
	public new event KeyEventHandler KeyDown
	{
		add
		{
			base.KeyDown += value;
		}
		remove
		{
			base.KeyDown -= value;
		}
	}

	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public new event KeyPressEventHandler KeyPress
	{
		add
		{
			base.KeyPress += value;
		}
		remove
		{
			base.KeyPress -= value;
		}
	}

	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public new event KeyEventHandler KeyUp
	{
		add
		{
			base.KeyUp += value;
		}
		remove
		{
			base.KeyUp -= value;
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

	public event MouseEventHandler MouseDownWithWndProc
	{
		[CompilerGenerated]
		add
		{
			MouseEventHandler mouseEventHandler = mouseEventHandler_0;
			MouseEventHandler mouseEventHandler2;
			do
			{
				mouseEventHandler2 = mouseEventHandler;
				MouseEventHandler value2 = (MouseEventHandler)Delegate.Combine(mouseEventHandler2, value);
				mouseEventHandler = Interlocked.CompareExchange(ref mouseEventHandler_0, value2, mouseEventHandler2);
			}
			while ((object)mouseEventHandler != mouseEventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			MouseEventHandler mouseEventHandler = mouseEventHandler_0;
			MouseEventHandler mouseEventHandler2;
			do
			{
				mouseEventHandler2 = mouseEventHandler;
				MouseEventHandler value2 = (MouseEventHandler)Delegate.Remove(mouseEventHandler2, value);
				mouseEventHandler = Interlocked.CompareExchange(ref mouseEventHandler_0, value2, mouseEventHandler2);
			}
			while ((object)mouseEventHandler != mouseEventHandler2);
		}
	}

	public event MouseEventHandler MouseUpWithWndProc
	{
		[CompilerGenerated]
		add
		{
			MouseEventHandler mouseEventHandler = mouseEventHandler_1;
			MouseEventHandler mouseEventHandler2;
			do
			{
				mouseEventHandler2 = mouseEventHandler;
				MouseEventHandler value2 = (MouseEventHandler)Delegate.Combine(mouseEventHandler2, value);
				mouseEventHandler = Interlocked.CompareExchange(ref mouseEventHandler_1, value2, mouseEventHandler2);
			}
			while ((object)mouseEventHandler != mouseEventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			MouseEventHandler mouseEventHandler = mouseEventHandler_1;
			MouseEventHandler mouseEventHandler2;
			do
			{
				mouseEventHandler2 = mouseEventHandler;
				MouseEventHandler value2 = (MouseEventHandler)Delegate.Remove(mouseEventHandler2, value);
				mouseEventHandler = Interlocked.CompareExchange(ref mouseEventHandler_1, value2, mouseEventHandler2);
			}
			while ((object)mouseEventHandler != mouseEventHandler2);
		}
	}

	public event buControlEvents.buButtonPlusMinusClickEventHandler ClickPlusMinus
	{
		[CompilerGenerated]
		add
		{
			buControlEvents.buButtonPlusMinusClickEventHandler buButtonPlusMinusClickEventHandler = buButtonPlusMinusClickEventHandler_0;
			buControlEvents.buButtonPlusMinusClickEventHandler buButtonPlusMinusClickEventHandler2;
			do
			{
				buButtonPlusMinusClickEventHandler2 = buButtonPlusMinusClickEventHandler;
				buControlEvents.buButtonPlusMinusClickEventHandler value2 = (buControlEvents.buButtonPlusMinusClickEventHandler)Delegate.Combine(buButtonPlusMinusClickEventHandler2, value);
				buButtonPlusMinusClickEventHandler = Interlocked.CompareExchange(ref buButtonPlusMinusClickEventHandler_0, value2, buButtonPlusMinusClickEventHandler2);
			}
			while ((object)buButtonPlusMinusClickEventHandler != buButtonPlusMinusClickEventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			buControlEvents.buButtonPlusMinusClickEventHandler buButtonPlusMinusClickEventHandler = buButtonPlusMinusClickEventHandler_0;
			buControlEvents.buButtonPlusMinusClickEventHandler buButtonPlusMinusClickEventHandler2;
			do
			{
				buButtonPlusMinusClickEventHandler2 = buButtonPlusMinusClickEventHandler;
				buControlEvents.buButtonPlusMinusClickEventHandler value2 = (buControlEvents.buButtonPlusMinusClickEventHandler)Delegate.Remove(buButtonPlusMinusClickEventHandler2, value);
				buButtonPlusMinusClickEventHandler = Interlocked.CompareExchange(ref buButtonPlusMinusClickEventHandler_0, value2, buButtonPlusMinusClickEventHandler2);
			}
			while ((object)buButtonPlusMinusClickEventHandler != buButtonPlusMinusClickEventHandler2);
		}
	}

	public event buControlEvents.buButtonPlusMinusMouseEventHandler MouseDownPlusMinus
	{
		[CompilerGenerated]
		add
		{
			buControlEvents.buButtonPlusMinusMouseEventHandler buButtonPlusMinusMouseEventHandler = buButtonPlusMinusMouseEventHandler_0;
			buControlEvents.buButtonPlusMinusMouseEventHandler buButtonPlusMinusMouseEventHandler2;
			do
			{
				buButtonPlusMinusMouseEventHandler2 = buButtonPlusMinusMouseEventHandler;
				buControlEvents.buButtonPlusMinusMouseEventHandler value2 = (buControlEvents.buButtonPlusMinusMouseEventHandler)Delegate.Combine(buButtonPlusMinusMouseEventHandler2, value);
				buButtonPlusMinusMouseEventHandler = Interlocked.CompareExchange(ref buButtonPlusMinusMouseEventHandler_0, value2, buButtonPlusMinusMouseEventHandler2);
			}
			while ((object)buButtonPlusMinusMouseEventHandler != buButtonPlusMinusMouseEventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			buControlEvents.buButtonPlusMinusMouseEventHandler buButtonPlusMinusMouseEventHandler = buButtonPlusMinusMouseEventHandler_0;
			buControlEvents.buButtonPlusMinusMouseEventHandler buButtonPlusMinusMouseEventHandler2;
			do
			{
				buButtonPlusMinusMouseEventHandler2 = buButtonPlusMinusMouseEventHandler;
				buControlEvents.buButtonPlusMinusMouseEventHandler value2 = (buControlEvents.buButtonPlusMinusMouseEventHandler)Delegate.Remove(buButtonPlusMinusMouseEventHandler2, value);
				buButtonPlusMinusMouseEventHandler = Interlocked.CompareExchange(ref buButtonPlusMinusMouseEventHandler_0, value2, buButtonPlusMinusMouseEventHandler2);
			}
			while ((object)buButtonPlusMinusMouseEventHandler != buButtonPlusMinusMouseEventHandler2);
		}
	}

	public event buControlEvents.buButtonPlusMinusMouseEventHandler MouseUpPlusMinus
	{
		[CompilerGenerated]
		add
		{
			buControlEvents.buButtonPlusMinusMouseEventHandler buButtonPlusMinusMouseEventHandler = buButtonPlusMinusMouseEventHandler_1;
			buControlEvents.buButtonPlusMinusMouseEventHandler buButtonPlusMinusMouseEventHandler2;
			do
			{
				buButtonPlusMinusMouseEventHandler2 = buButtonPlusMinusMouseEventHandler;
				buControlEvents.buButtonPlusMinusMouseEventHandler value2 = (buControlEvents.buButtonPlusMinusMouseEventHandler)Delegate.Combine(buButtonPlusMinusMouseEventHandler2, value);
				buButtonPlusMinusMouseEventHandler = Interlocked.CompareExchange(ref buButtonPlusMinusMouseEventHandler_1, value2, buButtonPlusMinusMouseEventHandler2);
			}
			while ((object)buButtonPlusMinusMouseEventHandler != buButtonPlusMinusMouseEventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			buControlEvents.buButtonPlusMinusMouseEventHandler buButtonPlusMinusMouseEventHandler = buButtonPlusMinusMouseEventHandler_1;
			buControlEvents.buButtonPlusMinusMouseEventHandler buButtonPlusMinusMouseEventHandler2;
			do
			{
				buButtonPlusMinusMouseEventHandler2 = buButtonPlusMinusMouseEventHandler;
				buControlEvents.buButtonPlusMinusMouseEventHandler value2 = (buControlEvents.buButtonPlusMinusMouseEventHandler)Delegate.Remove(buButtonPlusMinusMouseEventHandler2, value);
				buButtonPlusMinusMouseEventHandler = Interlocked.CompareExchange(ref buButtonPlusMinusMouseEventHandler_1, value2, buButtonPlusMinusMouseEventHandler2);
			}
			while ((object)buButtonPlusMinusMouseEventHandler != buButtonPlusMinusMouseEventHandler2);
		}
	}

	public event buControlEvents.buButtonPlusMinusMouseEventHandler MouseMovePlusMinus
	{
		[CompilerGenerated]
		add
		{
			buControlEvents.buButtonPlusMinusMouseEventHandler buButtonPlusMinusMouseEventHandler = buButtonPlusMinusMouseEventHandler_2;
			buControlEvents.buButtonPlusMinusMouseEventHandler buButtonPlusMinusMouseEventHandler2;
			do
			{
				buButtonPlusMinusMouseEventHandler2 = buButtonPlusMinusMouseEventHandler;
				buControlEvents.buButtonPlusMinusMouseEventHandler value2 = (buControlEvents.buButtonPlusMinusMouseEventHandler)Delegate.Combine(buButtonPlusMinusMouseEventHandler2, value);
				buButtonPlusMinusMouseEventHandler = Interlocked.CompareExchange(ref buButtonPlusMinusMouseEventHandler_2, value2, buButtonPlusMinusMouseEventHandler2);
			}
			while ((object)buButtonPlusMinusMouseEventHandler != buButtonPlusMinusMouseEventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			buControlEvents.buButtonPlusMinusMouseEventHandler buButtonPlusMinusMouseEventHandler = buButtonPlusMinusMouseEventHandler_2;
			buControlEvents.buButtonPlusMinusMouseEventHandler buButtonPlusMinusMouseEventHandler2;
			do
			{
				buButtonPlusMinusMouseEventHandler2 = buButtonPlusMinusMouseEventHandler;
				buControlEvents.buButtonPlusMinusMouseEventHandler value2 = (buControlEvents.buButtonPlusMinusMouseEventHandler)Delegate.Remove(buButtonPlusMinusMouseEventHandler2, value);
				buButtonPlusMinusMouseEventHandler = Interlocked.CompareExchange(ref buButtonPlusMinusMouseEventHandler_2, value2, buButtonPlusMinusMouseEventHandler2);
			}
			while ((object)buButtonPlusMinusMouseEventHandler != buButtonPlusMinusMouseEventHandler2);
		}
	}

	public buButtonPlusMinus()
	{
		Class76.smethod_839();
		base.Display.Parent = this;
		base.Display.Parent = this;
		ButtonPlusDownDisplay.Parent = this;
		ButtonPlusNormalDisplay.Parent = this;
		ButtonPlusOverDisplay.Parent = this;
		ButtonMinusDownDisplay.Parent = this;
		ButtonMinusNormalDisplay.Parent = this;
		ButtonMinusOverDisplay.Parent = this;
		base.Display.Parent = this;
		ButtonPlusDownDisplay.BackColor = Color.DimGray;
		ButtonPlusNormalDisplay.BackColor = Color.LightGray;
		ButtonPlusOverDisplay.BackColor = Color.Gray;
		ButtonMinusDownDisplay.BackColor = Color.DimGray;
		ButtonMinusNormalDisplay.BackColor = Color.LightGray;
		ButtonMinusOverDisplay.BackColor = Color.Gray;
		base.Geometry.Parent = this;
		base.Language.Parent = this;
		base.Theme.Parent = this;
		TabStop = false;
		TextAlign = ContentAlignment.MiddleCenter;
		UseMnemonic = true;
		base.Image = null;
		base.ImageList = null;
		base.ImageAlign = ContentAlignment.MiddleLeft;
		Class76.smethod_151(UseMnemonic, this);
		flatStyle_0 = FlatStyle.Standard;
		SetStyle(ControlStyles.Selectable, value: false);
		SetStyle(ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.SupportsTransparentBackColor | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, value: true);
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
		if (!base.Enabled)
		{
			return;
		}
		if (!base.Security.Enable || base.Security.Level >= buControl.SecurityActive)
		{
			if (buButtonPlusMinusClickEventHandler_0 != null)
			{
				buButtonPlusMinusClickEventHandler_0(this, int_3);
			}
			base.OnClick(e);
		}
		else
		{
			MessageBox.Show("You Level Not Enought This Operation", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
		mouseState_0 = MouseState.None;
		mouseState_1 = MouseState.None;
		if (buButtonPlusMinusMouseEventHandler_1 != null)
		{
			buButtonPlusMinusMouseEventHandler_1(this, e, int_3);
		}
		Invalidate();
		base.OnMouseUp(e);
	}

	protected override void OnMouseDown(MouseEventArgs e)
	{
		if (ButtonStyle == PlusMinusButtonStyle.Horizontal)
		{
			if (!((e.X > base.ClientRectangle.Left) & (e.X < base.ClientRectangle.Width / 2)))
			{
				mouseState_1 = MouseState.None;
				mouseState_0 = MouseState.Down;
				int_3 = 1;
			}
			else
			{
				mouseState_1 = MouseState.Down;
				mouseState_0 = MouseState.None;
				int_3 = -1;
			}
		}
		if (ButtonStyle == PlusMinusButtonStyle.Vertical)
		{
			if (!((e.Y > base.ClientRectangle.Top) & (e.Y < base.ClientRectangle.Height / 2)))
			{
				mouseState_1 = MouseState.Down;
				mouseState_0 = MouseState.None;
				int_3 = -1;
			}
			else
			{
				mouseState_1 = MouseState.None;
				mouseState_0 = MouseState.Down;
				int_3 = 1;
			}
		}
		if (buButtonPlusMinusMouseEventHandler_0 != null)
		{
			buButtonPlusMinusMouseEventHandler_0(this, e, int_3);
		}
		Invalidate();
		base.OnMouseDown(e);
	}

	protected override void OnMouseMove(MouseEventArgs e)
	{
		Cursor = Cursors.Default;
		if (ButtonStyle == PlusMinusButtonStyle.Horizontal)
		{
			if (!((e.X > base.ClientRectangle.Left) & (e.X < base.ClientRectangle.Width / 2)))
			{
				mouseState_1 = MouseState.None;
				mouseState_0 = MouseState.Move;
				int_3 = 1;
			}
			else
			{
				mouseState_1 = MouseState.Move;
				mouseState_0 = MouseState.None;
				int_3 = -1;
			}
		}
		if (ButtonStyle == PlusMinusButtonStyle.Vertical)
		{
			if (!((e.Y > base.ClientRectangle.Top) & (e.Y < base.ClientRectangle.Height / 2)))
			{
				mouseState_1 = MouseState.Move;
				mouseState_0 = MouseState.None;
				int_3 = -1;
			}
			else
			{
				mouseState_1 = MouseState.None;
				mouseState_0 = MouseState.Move;
				int_3 = 1;
			}
		}
		if (buButtonPlusMinusMouseEventHandler_2 != null)
		{
			buButtonPlusMinusMouseEventHandler_2(this, e, int_3);
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
		mouseState_0 = MouseState.None;
		mouseState_1 = MouseState.None;
		base.OnMouseLeave(e);
		Invalidate();
	}

	protected override void OnHandleDestroyed(EventArgs e)
	{
		base.OnHandleDestroyed(e);
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

	protected override void WndProc(ref Message m)
	{
		if (m.Msg == 513 && mouseEventHandler_0 != null)
		{
			MouseEventArgs e = new MouseEventArgs(MouseButtons.Left, 1, 0, 0, 0);
			mouseEventHandler_0(this, e);
		}
		if (m.Msg == 514 && mouseEventHandler_1 != null)
		{
			MouseEventArgs e2 = new MouseEventArgs(MouseButtons.Left, 1, 0, 0, 0);
			mouseEventHandler_1(this, e2);
		}
		base.WndProc(ref m);
	}

	public override string ToString()
	{
		return base.ToString() + ", Text: " + Text;
	}

	protected override void OnPaint(PaintEventArgs e)
	{
		string s = Text;
		RectangleF rect = new RectangleF(base.ClientRectangle.Left, base.ClientRectangle.Top, base.ClientRectangle.Width, base.ClientRectangle.Height);
		RectangleF rect2 = new RectangleF(base.ClientRectangle.Left, base.ClientRectangle.Top, base.ClientRectangle.Width, base.ClientRectangle.Height);
		RectangleF layoutRectangle = new RectangleF(base.ClientRectangle.Left, base.ClientRectangle.Top, base.ClientRectangle.Width, base.ClientRectangle.Height);
		Graphics Grph = e.Graphics;
		if (base.Theme.Type != themeType_0)
		{
			buControlThemeVars Vars = new buControlThemeVars();
			buControlTheme.UpdateTheme(base.Theme.Type, ref Vars);
			base.Geometry = new buControlGeometry(Vars.Geometry);
			base.Display = new buControlDisplay(Vars.Display);
			ButtonPlusDownDisplay = new buControlDisplay(Vars.DisplayButtonDown);
			ButtonPlusNormalDisplay = new buControlDisplay(Vars.DisplayButtonNormal);
			ButtonPlusOverDisplay = new buControlDisplay(Vars.DisplayButtonOver);
			ButtonMinusDownDisplay = new buControlDisplay(Vars.DisplayButton2Down);
			ButtonMinusNormalDisplay = new buControlDisplay(Vars.DisplayButton2Normal);
			ButtonMinusOverDisplay = new buControlDisplay(Vars.DisplayButton2Over);
			base.Display.Parent = this;
			ButtonPlusDownDisplay.Parent = this;
			ButtonPlusNormalDisplay.Parent = this;
			ButtonPlusOverDisplay.Parent = this;
			ButtonMinusDownDisplay.Parent = this;
			ButtonMinusNormalDisplay.Parent = this;
			ButtonMinusOverDisplay.Parent = this;
		}
		if (ButtonStyle == PlusMinusButtonStyle.Horizontal)
		{
			rect2 = new RectangleF(base.ClientRectangle.Left, base.ClientRectangle.Top, (float)base.ClientRectangle.Width / 2f, base.ClientRectangle.Height);
			rect = new RectangleF((float)base.ClientRectangle.Width / 2f, base.ClientRectangle.Top, (float)base.ClientRectangle.Width / 2f, base.ClientRectangle.Height);
		}
		if (ButtonStyle == PlusMinusButtonStyle.Vertical)
		{
			rect2 = new RectangleF(base.ClientRectangle.Left, (float)base.ClientRectangle.Height / 2f, base.ClientRectangle.Width, (float)base.ClientRectangle.Height / 2f);
			rect = new RectangleF(base.ClientRectangle.Left, base.ClientRectangle.Top, base.ClientRectangle.Width, (float)base.ClientRectangle.Height / 2f);
		}
		buControlDisplay buControlDisplay2 = new buControlDisplay(ButtonPlusNormalDisplay);
		if (mouseState_0 == MouseState.Move)
		{
			buControlDisplay2 = new buControlDisplay(ButtonPlusOverDisplay);
		}
		if (mouseState_0 == MouseState.Down)
		{
			buControlDisplay2 = new buControlDisplay(ButtonPlusDownDisplay);
		}
		buControlDisplay buControlDisplay3 = new buControlDisplay(ButtonMinusNormalDisplay);
		if (mouseState_1 == MouseState.Move)
		{
			buControlDisplay3 = new buControlDisplay(ButtonMinusOverDisplay);
		}
		if (mouseState_1 == MouseState.Down)
		{
			buControlDisplay3 = new buControlDisplay(ButtonMinusDownDisplay);
		}
		if (!base.Enabled)
		{
			ControlPaint.DrawStringDisabled(e.Graphics, s, buControlDisplay2.Fonts.Font, buControlDisplay2.Fonts.ForeColor, layoutRectangle, ControlGeometry.AlignmentToStringFormat(buControlDisplay3.Fonts.Alignment));
		}
		else
		{
			ControlGeometry.drawGeometry(rect, base.Geometry.ArcDiameter, base.Geometry.ShapeMode, buControlDisplay2, RoundRectangleType.RoundRectAll, ref Grph);
			ControlGeometry.drawString(rect, "+", buControlDisplay2, hotkeyPrefix_0, ref Grph);
			ControlGeometry.drawGeometry(rect2, base.Geometry.ArcDiameter, base.Geometry.ShapeMode, buControlDisplay3, RoundRectangleType.RoundRectAll, ref Grph);
			ControlGeometry.drawString(rect2, "-", buControlDisplay3, hotkeyPrefix_0, ref Grph);
		}
		DrawImage(e.Graphics, base.Image, base.ClientRectangle, base.ImageAlign);
		themeType_0 = base.Theme.Type;
		base.OnPaint(e);
	}
}
