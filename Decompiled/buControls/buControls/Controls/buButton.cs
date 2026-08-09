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

	[CompilerGenerated]
	private MouseEventHandler mouseEventHandler_0;

	[CompilerGenerated]
	private MouseEventHandler mouseEventHandler_1;

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
			return bool_1;
		}
		set
		{
			if (bool_1 != value)
			{
				bool_1 = value;
				Class76.smethod_193(bool_1, this);
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

	public buButton()
	{
		Class76.smethod_281();
		base.Display.Parent = this;
		base.ButtonDownDisplay.Parent = this;
		base.ButtonOverDisplay.Parent = this;
		base.ButtonOverDisplay.BackColor = Color.Gray;
		base.ButtonDownDisplay.BackColor = Color.DimGray;
		base.Geometry.Parent = this;
		base.Language.Parent = this;
		base.Theme.Parent = this;
		TabStop = false;
		TextAlign = ContentAlignment.MiddleCenter;
		base.Image = null;
		base.ImageList = null;
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
		if (!buControlCommands.bool_0)
		{
			buControlCommands.smethod_0("buButton");
			if (!buControlCommands.bool_0)
			{
				MessageBox.Show("License Error");
				return;
			}
		}
		if (base.Enabled)
		{
			if (!base.Security.Enable || base.Security.Level >= buControl.SecurityActive)
			{
				base.OnClick(e);
			}
			else
			{
				MessageBox.Show("You Level Not Enought This Operation", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
			}
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
		Invalidate();
		base.OnMouseUp(e);
	}

	protected override void OnMouseDown(MouseEventArgs e)
	{
		if (!buControlCommands.bool_0)
		{
			buControlCommands.smethod_0("buButton");
			if (!buControlCommands.bool_0)
			{
				MessageBox.Show("License Error");
				return;
			}
		}
		mouseState_0 = MouseState.Down;
		Invalidate();
		base.OnMouseDown(e);
	}

	protected override void OnMouseMove(MouseEventArgs e)
	{
		Cursor = Cursors.Default;
		mouseState_0 = MouseState.Move;
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
			string orjText = Text;
			RectangleF controlSize = new RectangleF(base.ClientRectangle.Left, base.ClientRectangle.Top, base.ClientRectangle.Width, base.ClientRectangle.Height);
			RectangleF rectangleF = new RectangleF(base.ClientRectangle.Left, base.ClientRectangle.Top, base.ClientRectangle.Width, base.ClientRectangle.Height);
			Graphics Grph = e.Graphics;
			if (base.Theme.Type != themeType_0)
			{
				buControlThemeVars Vars = new buControlThemeVars();
				buControlTheme.UpdateTheme(base.Theme.Type, ref Vars);
				base.Geometry = new buControlGeometry(Vars.Geometry);
				base.Display = new buControlDisplay(Vars.Display);
				base.ButtonOverDisplay = new buControlDisplay(Vars.DisplayButtonOver);
				base.ButtonDownDisplay = new buControlDisplay(Vars.DisplayButtonDown);
				base.Display.Parent = this;
				base.ButtonOverDisplay.Parent = this;
				base.ButtonDownDisplay.Parent = this;
			}
			buControlDisplay buControlDisplay2 = new buControlDisplay(base.Display);
			if (mouseState_0 == MouseState.Move)
			{
				buControlDisplay2 = new buControlDisplay(base.ButtonOverDisplay);
			}
			if (mouseState_0 == MouseState.Down)
			{
				buControlDisplay2 = new buControlDisplay(base.ButtonDownDisplay);
			}
			orjText = ControlGeometry.LanguageSelect(base.Language, orjText);
			if ((base.Width > 0) & (base.Height > 0))
			{
				if (base.Image != null)
				{
					rectangleF = ControlGeometry.GetTextRectangleFromImage(base.Image, base.ImageAlign, controlSize, base.Geometry, base.ImageBorderOffset);
				}
				if (!base.Enabled)
				{
					ControlPaint.DrawStringDisabled(e.Graphics, orjText, buControlDisplay2.Fonts.Font, buControlDisplay2.Fonts.ForeColor, rectangleF, ControlGeometry.AlignmentToStringFormat(buControlDisplay2.Fonts.Alignment));
				}
				else
				{
					ControlGeometry.drawGeometry(base.ClientRectangle, base.Geometry, buControlDisplay2, RoundRectangleType.RoundRectAll, ref Grph);
				}
				Rectangle r = new Rectangle(base.ClientRectangle.X + base.ImageBorderOffset, base.ClientRectangle.Y + base.ImageBorderOffset, base.ClientRectangle.Width - base.ImageBorderOffset * 2, base.ClientRectangle.Height - base.ImageBorderOffset * 2);
				DrawImage(e.Graphics, base.Image, r, base.ImageAlign);
				if (base.FontAngle == 0)
				{
					ControlGeometry.drawString(rectangleF, orjText, buControlDisplay2, hotkeyPrefix_0, ref Grph);
				}
				else
				{
					ControlGeometry.drawString(rectangleF, orjText, base.FontAngle, buControlDisplay2, hotkeyPrefix_0, ref Grph);
				}
				themeType_0 = base.Theme.Type;
			}
			base.OnPaint(e);
		}
		catch (Exception)
		{
		}
	}
}
