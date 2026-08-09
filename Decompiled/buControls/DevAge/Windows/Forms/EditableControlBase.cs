using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using DevAge.Drawing;
using DevAge.Drawing.VisualElements;

namespace DevAge.Windows.Forms;

[ToolboxItem(false)]
public class EditableControlBase : UserControl
{
	internal System.ComponentModel.Container container_0 = null;

	private DevAge.Drawing.VisualElements.Container container_1 = new DevAge.Drawing.VisualElements.Container();

	private EditablePanelThemed editablePanelThemed_0 = new EditablePanelThemed();

	private BackgroundSolid backgroundSolid_0 = new BackgroundSolid();

	private static Color color_0 = Color.FromKnownColor(KnownColor.Window);

	[DefaultValue(typeof(Color), "Window")]
	public new Color BackColor
	{
		get
		{
			return base.BackColor;
		}
		set
		{
			backgroundSolid_0.BackColor = value;
			base.BackColor = value;
		}
	}

	[DefaultValue(DevAge.Drawing.BorderStyle.System)]
	public new DevAge.Drawing.BorderStyle BorderStyle
	{
		get
		{
			return editablePanelThemed_0.BorderStyle;
		}
		set
		{
			editablePanelThemed_0.BorderStyle = value;
			OnBorderStyleChanged(EventArgs.Empty);
		}
	}

	public override Rectangle DisplayRectangle
	{
		get
		{
			using MeasureHelper measure = new MeasureHelper(this);
			return Rectangle.Round(container_1.GetContentRectangle(measure, base.DisplayRectangle));
		}
	}

	public EditableControlBase()
	{
		container_0 = new System.ComponentModel.Container();
		SetStyle(ControlStyles.AllPaintingInWmPaint, value: true);
		SetStyle(ControlStyles.UserMouse, value: true);
		SetStyle(ControlStyles.UserPaint, value: true);
		SetStyle(ControlStyles.DoubleBuffer, value: false);
		SetStyle(ControlStyles.SupportsTransparentBackColor, value: true);
		SetStyle(ControlStyles.ResizeRedraw, value: true);
		BackColor = color_0;
		container_1.Background = backgroundSolid_0;
		container_1.Border = editablePanelThemed_0;
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
		using GraphicsCache graphics = new GraphicsCache(e.Graphics, e.ClipRectangle);
		editablePanelThemed_0.Draw(graphics, base.ClientRectangle);
	}

	protected virtual void OnBorderStyleChanged(EventArgs e)
	{
		Invalidate();
	}

	protected void SetContentAndButtonLocation(Control content, Control rightButton)
	{
		Rectangle displayRectangle = DisplayRectangle;
		rightButton.Bounds = new Rectangle(displayRectangle.Right - 18, displayRectangle.Y, 18, displayRectangle.Height);
		int num = rightButton.Location.X - DisplayRectangle.X;
		content.Bounds = new Rectangle(displayRectangle.Location, new Size(num, displayRectangle.Height));
	}
}
