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

	[CompilerGenerated]
	private buControlEvents.buCheckedChangedEventHandler buCheckedChangedEventHandler_0;

	[CompilerGenerated]
	private buControlEvents.buClickAfterEventHandler buClickAfterEventHandler_0;

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	[Browsable(true)]
	public buControlCheckTick CheckTick
	{
		get
		{
			return buControlCheckTick_0;
		}
		set
		{
			buControlCheckTick_0 = value;
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
			return bool_2;
		}
		set
		{
			if (bool_2 != value)
			{
				bool_2 = value;
				Class76.smethod_579(this, bool_2);
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
			Invalidate();
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
			if (!base.Security.Enable || base.Security.Level >= buControl.SecurityActive)
			{
				base.Text = value;
			}
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

	public buCheckBox()
	{
		Class76.smethod_77();
		if (base.Parent != null)
		{
			BackColor = base.Parent.BackColor;
		}
		TabStop = false;
		TextAlign = ContentAlignment.MiddleCenter;
		base.Image = null;
		UseMnemonic = true;
		base.ImageList = null;
		contentAlignment_1 = ContentAlignment.MiddleCenter;
		Class76.smethod_579(this, UseMnemonic);
		flatStyle_0 = FlatStyle.Standard;
		CheckTick.TickDisplay.Parent = this;
		CheckTick.TickDisplay.BackColor = Color.WhiteSmoke;
		CheckTick.Visible = true;
		CheckTick.ColorModeDisplay.Parent = this;
		CheckTick.ColorModeDisplay.BackColor = Color.Green;
		base.Display.BackColor = Color.LightGray;
		base.Display.Parent = this;
		base.Geometry.Parent = this;
		base.Language.Parent = this;
		base.Theme.Parent = this;
		CheckTick.Parent = this;
		CheckTick.TickDisplay.Parent = this;
		CheckTick.TickDisplay.BackColor = Color.WhiteSmoke;
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
		if (!buControlCommands.bool_0)
		{
			buControlCommands.smethod_0("buCheckBox");
			if (!buControlCommands.bool_0)
			{
				MessageBox.Show("License Error");
				return;
			}
		}
		if (!base.Enabled)
		{
			return;
		}
		if (!ReadOnly)
		{
			if (CheckTick.OnlyClickMode)
			{
				bool_0 = true;
			}
			else
			{
				bool_0 = !bool_0;
			}
			if (buCheckedChangedEventHandler_0 != null)
			{
				buCheckedChangedEventHandler_0(this, Check);
			}
			if (buClickAfterEventHandler_0 != null)
			{
				buClickAfterEventHandler_0(this, Check);
			}
		}
		Invalidate();
		base.OnClick(e);
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
			buControlCommands.smethod_0("buCheckBox");
			if (!buControlCommands.bool_0)
			{
				MessageBox.Show("License Error");
				return;
			}
		}
		if (ReadOnly)
		{
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
		string orjText = Text;
		RectangleF rectangleF = new RectangleF(base.ClientRectangle.Left, base.ClientRectangle.Top, base.ClientRectangle.Width, base.ClientRectangle.Height);
		RectangleF rect = new RectangleF(base.ClientRectangle.Left, base.ClientRectangle.Top, base.ClientRectangle.Width, base.ClientRectangle.Height);
		rectDraw_0 = new rectDraw(new RectangleF(base.ClientRectangle.Left, base.ClientRectangle.Top, base.ClientRectangle.Width, base.ClientRectangle.Height), RoundRectangleType.RoundRectAll);
		Graphics Grph = e.Graphics;
		orjText = ControlGeometry.LanguageSelect(base.Language, orjText);
		if (CheckTick.Visible)
		{
			if (CheckTick.RightSide)
			{
				rectDraw_0.RoundType = RoundRectangleType.RoundRectAll;
				rectDraw_0.rect.X = base.Width - CheckTick.BoxSize - 1 - CheckTick.Space;
				rectDraw_0.rect.Y = (int)((rect.Height - (float)CheckTick.BoxSize) / 2f);
				rectDraw_0.rect.Width = CheckTick.BoxSize;
				rectDraw_0.rect.Height = CheckTick.BoxSize;
				rect.X = 1f + base.Geometry.Space;
				rect.Width = (float)base.Width - rect.X - rectDraw_0.rect.Width - (float)CheckTick.Space - 1f;
			}
			else
			{
				rectDraw_0.RoundType = RoundRectangleType.RoundRectAll;
				rectDraw_0.rect.X = (int)base.Geometry.Space + CheckTick.Space;
				rectDraw_0.rect.Y = (int)((float)(base.Height - CheckTick.BoxSize) / 2f);
				rectDraw_0.rect.Width = CheckTick.BoxSize;
				rectDraw_0.rect.Height = CheckTick.BoxSize;
				rect.X = rectDraw_0.rect.X + rectDraw_0.rect.Width + base.Geometry.Space * 2f;
				rect.Width = (float)base.Width - rect.X;
			}
		}
		if (base.Theme.Type != themeType_0)
		{
			buControlThemeVars Vars = new buControlThemeVars();
			buControlTheme.UpdateTheme(base.Theme.Type, ref Vars);
			base.Geometry = new buControlGeometry(Vars.Geometry);
			base.Display = new buControlDisplay(Vars.Display);
			CheckTick.TickDisplay = new buControlDisplay(Vars.DisplayCheckTick);
			base.Display.Parent = this;
			CheckTick.Parent = this;
			CheckTick.TickDisplay.Parent = this;
		}
		buControlDisplay buControlDisplay2 = new buControlDisplay(base.Display);
		if (!base.Enabled)
		{
			buControlDisplay2.GradientType = GradientMode.Solid;
			buControlDisplay2.BackColor = buControlDisplay2.DisableColor;
		}
		if (CheckTick.ColorModeEnable)
		{
			if (!Check)
			{
				ControlGeometry.drawGeometry(base.ClientRectangle, base.Geometry, buControlDisplay2, RoundRectangleType.RoundRectAll, ref Grph);
			}
			else
			{
				ControlGeometry.drawGeometry(base.ClientRectangle, base.Geometry, CheckTick.ColorModeDisplay, RoundRectangleType.RoundRectAll, ref Grph);
			}
		}
		else
		{
			ControlGeometry.drawGeometry(base.ClientRectangle, base.Geometry, buControlDisplay2, RoundRectangleType.RoundRectAll, ref Grph);
		}
		ControlGeometry.drawString(rect, orjText, buControlDisplay2, hotkeyPrefix_0, ref Grph);
		if (CheckTick.Visible)
		{
			ControlGeometry.drawGeometry(rectDraw_0.rect, CheckTick.ArcDiameter, CheckTick.Shape, CheckTick.TickDisplay, rectDraw_0.RoundType, ref Grph);
			if (Check)
			{
				Grph.DrawString("ü", new Font("Wingdings", Convert.ToInt32((double)CheckTick.BoxSize * 1.5)), new SolidBrush(CheckTick.TickDisplay.Fonts.ForeColor), new RectangleF(rectDraw_0.rect.X - 8f, rectDraw_0.rect.Y, rectDraw_0.rect.Width + 15f, rectDraw_0.rect.Height), new StringFormat
				{
					LineAlignment = StringAlignment.Center
				});
			}
		}
		Rectangle r = new Rectangle(base.ClientRectangle.X + base.ImageBorderOffset, base.ClientRectangle.Y + base.ImageBorderOffset, base.ClientRectangle.Width - base.ImageBorderOffset * 2, base.ClientRectangle.Height - base.ImageBorderOffset * 2);
		DrawImage(e.Graphics, base.Image, r, base.ImageAlign);
		themeType_0 = base.Theme.Type;
		base.OnPaint(e);
	}
}
