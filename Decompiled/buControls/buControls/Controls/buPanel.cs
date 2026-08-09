using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using ns27;

namespace buControls.Controls;

[DefaultProperty("Display")]
[DefaultEvent("Click")]
[ClassInterface(ClassInterfaceType.AutoDispatch)]
[ComVisible(true)]
[ToolboxBitmap(typeof(Label))]
[DefaultBindingProperty("Text")]
public class buPanel : buContainerControl
{
	private FlatStyle flatStyle_0;

	private ThemeType themeType_0 = ThemeType.Standart;

	private string string_1;

	private static object object_0 = new object();

	private static object object_1 = new object();

	[EditorBrowsable(EditorBrowsableState.Always)]
	[DefaultValue("")]
	[NotifyParentProperty(true)]
	[Browsable(true)]
	public string AuxInfo
	{
		get
		{
			return string_1;
		}
		set
		{
			string_1 = value;
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

	public buPanel()
	{
		Class76.smethod_61();
		TabStop = false;
		TextAlign = ContentAlignment.MiddleCenter;
		base.Image = null;
		base.ImageList = null;
		base.ImageAlign = ContentAlignment.MiddleCenter;
		flatStyle_0 = FlatStyle.Standard;
		base.Display.Parent = this;
		base.Geometry.Parent = this;
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

	protected override void OnPaint(PaintEventArgs e)
	{
		_ = Text;
		RectangleF controlSize = new RectangleF(base.ClientRectangle.Left, base.ClientRectangle.Top, base.ClientRectangle.Width, base.ClientRectangle.Height);
		RectangleF layoutRectangle = new RectangleF(base.ClientRectangle.Left, base.ClientRectangle.Top, base.ClientRectangle.Width, base.ClientRectangle.Height);
		Graphics Grph = e.Graphics;
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
				layoutRectangle = ControlGeometry.GetTextRectangleFromImage(base.Image, base.ImageAlign, controlSize, base.Geometry, base.ImageBorderOffset);
			}
			if (!base.Enabled)
			{
				ControlPaint.DrawStringDisabled(e.Graphics, Text, Font, BackColor, layoutRectangle, ControlGeometry.AlignmentToStringFormat(base.Display.Fonts.Alignment));
			}
			else
			{
				ControlGeometry.drawGeometry(base.ClientRectangle, base.Geometry.ArcDiameter, base.Geometry.ShapeMode, base.Display, RoundRectangleType.RoundRectAll, ref Grph);
			}
			DrawImage(e.Graphics, base.Image, base.ClientRectangle, base.ImageAlign);
		}
		themeType_0 = base.Theme.Type;
		base.OnPaint(e);
	}

	public static buPanel CopyVisual(buPanel refPanel, buPanel copyPanel)
	{
		copyPanel.Display = buControlDisplay.Copy(refPanel.Display, copyPanel.Display);
		copyPanel.Geometry.Space = refPanel.Geometry.Space;
		copyPanel.Geometry.ArcDiameter = refPanel.Geometry.ArcDiameter;
		copyPanel.Geometry.ShapeMode = refPanel.Geometry.ShapeMode;
		copyPanel.ImageAlign = refPanel.ImageAlign;
		return copyPanel;
	}
}
