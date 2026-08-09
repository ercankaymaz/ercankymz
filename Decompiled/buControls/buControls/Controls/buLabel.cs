using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Text;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using ns27;

namespace buControls.Controls;

[DefaultProperty("Text")]
[DefaultEvent("Click")]
[ClassInterface(ClassInterfaceType.AutoDispatch)]
[ComVisible(true)]
[ToolboxBitmap(typeof(Label))]
[DefaultBindingProperty("Text")]
public class buLabel : buControl
{
	private FlatStyle flatStyle_0;

	private bool bool_0;

	private ThemeType themeType_0 = ThemeType.Standart;

	internal HotkeyPrefix hotkeyPrefix_0 = HotkeyPrefix.None;

	private static object object_0 = new object();

	private static object object_1 = new object();

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
			return bool_0;
		}
		set
		{
			if (bool_0 != value)
			{
				bool_0 = value;
				Class76.smethod_349(bool_0, this);
				Invalidate();
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

	public buLabel()
	{
		Class76.smethod_414();
		TabStop = false;
		TextAlign = ContentAlignment.MiddleCenter;
		base.Image = null;
		UseMnemonic = true;
		base.ImageList = null;
		contentAlignment_1 = ContentAlignment.MiddleCenter;
		Class76.smethod_349(UseMnemonic, this);
		flatStyle_0 = FlatStyle.Standard;
		base.Display.Parent = this;
		base.Geometry.Parent = this;
		base.Language.Parent = this;
		base.Theme.Parent = this;
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
			buControlCommands.smethod_0("buLabel");
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
			buControlCommands.smethod_0("buLabel");
			if (!buControlCommands.bool_0)
			{
				MessageBox.Show("License Error");
				return;
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

	public static buLabel CopyVisual(buLabel refLabel, buLabel copyLabel)
	{
		copyLabel.Display = buControlDisplay.Copy(refLabel.Display, copyLabel.Display);
		copyLabel.Geometry.Space = refLabel.Geometry.Space;
		copyLabel.Geometry.ArcDiameter = refLabel.Geometry.ArcDiameter;
		copyLabel.Geometry.ShapeMode = refLabel.Geometry.ShapeMode;
		copyLabel.ImageAlign = refLabel.ImageAlign;
		return copyLabel;
	}

	protected override void OnPaint(PaintEventArgs e)
	{
		string orjText = Text;
		RectangleF rectangleF = new RectangleF(base.ClientRectangle.Left, base.ClientRectangle.Top, base.ClientRectangle.Width, base.ClientRectangle.Height);
		rectDraw rectDraw2 = new rectDraw(new RectangleF(base.ClientRectangle.Left, base.ClientRectangle.Top, base.ClientRectangle.Width, base.ClientRectangle.Height), RoundRectangleType.RoundRectAll);
		Graphics Grph = e.Graphics;
		orjText = ControlGeometry.LanguageSelect(base.Language, orjText);
		if (base.Theme.Type != themeType_0)
		{
			buControlThemeVars Vars = new buControlThemeVars();
			buControlTheme.UpdateTheme(base.Theme.Type, ref Vars);
			base.Geometry = new buControlGeometry(Vars.Geometry);
			base.Display = new buControlDisplay(Vars.Display);
			base.Display.Parent = this;
		}
		if ((base.Width > 0) & (base.Height > 0))
		{
			if (base.Image != null)
			{
				rectDraw2.rectText = ControlGeometry.GetTextRectangleFromImage(base.Image, base.ImageAlign, rectDraw2.rectText, base.Geometry, base.ImageBorderOffset);
			}
			if (!base.Enabled)
			{
				ControlPaint.DrawStringDisabled(e.Graphics, Text, base.Display.Fonts.Font, base.Display.DisableColor, rectDraw2.rect, ControlGeometry.AlignmentToStringFormat(base.Display.Fonts.Alignment));
			}
			else
			{
				ControlGeometry.drawGeometry(base.ClientRectangle, base.Geometry, base.Display, RoundRectangleType.RoundRectAll, ref Grph);
			}
			DrawImage(e.Graphics, base.Image, base.ClientRectangle, base.ImageAlign);
			if (base.FontAngle == 0)
			{
				ControlGeometry.drawString(rectDraw2.rectText, orjText, base.Display, hotkeyPrefix_0, ref Grph);
			}
			else
			{
				ControlGeometry.drawString(rectDraw2.rectText, orjText, base.FontAngle, base.Display, hotkeyPrefix_0, ref Grph);
			}
		}
		themeType_0 = base.Theme.Type;
		base.OnPaint(e);
	}
}
