using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using DevAge.Drawing;
using DevAge.Drawing.VisualElements;
using ns27;

namespace DevAge.Windows.Forms;

[ToolboxItem(false)]
[DefaultEvent("Click")]
public class DropDownButton : Control
{
	private System.ComponentModel.Container container_0 = null;

	private DropDownButtonThemed dropDownButtonThemed_0 = new DropDownButtonThemed();

	private bool bool_0 = false;

	private bool bool_1 = false;

	[Browsable(false)]
	public new Color BackColor
	{
		get
		{
			return base.BackColor;
		}
		set
		{
			base.BackColor = value;
		}
	}

	public DropDownButton()
	{
		Class76.smethod_135(this);
		SetStyle(ControlStyles.AllPaintingInWmPaint, value: true);
		SetStyle(ControlStyles.UserMouse, value: true);
		SetStyle(ControlStyles.UserPaint, value: true);
		SetStyle(ControlStyles.DoubleBuffer, value: true);
		SetStyle(ControlStyles.SupportsTransparentBackColor, value: true);
		SetStyle(ControlStyles.ResizeRedraw, value: true);
		SetStyle(ControlStyles.Selectable, value: false);
		SetStyle(ControlStyles.StandardClick, value: true);
		SetStyle(ControlStyles.StandardDoubleClick, value: true);
		base.BackColor = Color.Transparent;
	}

	protected override void Dispose(bool disposing)
	{
		if (disposing && container_0 != null)
		{
			container_0.Dispose();
		}
		base.Dispose(disposing);
	}

	protected override void OnPaint(PaintEventArgs e)
	{
		base.OnPaint(e);
		if (!base.Enabled)
		{
			dropDownButtonThemed_0.Style = ButtonStyle.Disabled;
		}
		else if (!bool_1)
		{
			if (!bool_0)
			{
				dropDownButtonThemed_0.Style = ButtonStyle.Normal;
			}
			else
			{
				dropDownButtonThemed_0.Style = ButtonStyle.Hot;
			}
		}
		else
		{
			dropDownButtonThemed_0.Style = ButtonStyle.Pressed;
		}
		using GraphicsCache graphics = new GraphicsCache(e.Graphics, e.ClipRectangle);
		dropDownButtonThemed_0.Draw(graphics, Rectangle.Round(base.ClientRectangle));
	}

	protected override void OnMouseEnter(EventArgs e)
	{
		base.OnMouseEnter(e);
		bool_0 = true;
		Invalidate();
	}

	protected override void OnMouseLeave(EventArgs e)
	{
		base.OnMouseLeave(e);
		bool_0 = false;
		Invalidate();
	}

	protected override void OnMouseDown(MouseEventArgs e)
	{
		bool_1 = true;
		Invalidate();
		base.OnMouseDown(e);
	}

	protected override void OnMouseUp(MouseEventArgs e)
	{
		base.OnMouseUp(e);
		bool_1 = false;
		Invalidate();
	}

	protected override void OnKeyDown(KeyEventArgs e)
	{
		if (e.KeyCode == Keys.Space)
		{
			bool_1 = true;
			OnClick(EventArgs.Empty);
			e.Handled = true;
		}
		base.OnKeyDown(e);
	}

	protected override void OnKeyUp(KeyEventArgs e)
	{
		bool_1 = false;
		Invalidate();
		base.OnKeyUp(e);
	}

	protected override void OnClick(EventArgs e)
	{
		base.OnClick(e);
		Invalidate();
	}
}
