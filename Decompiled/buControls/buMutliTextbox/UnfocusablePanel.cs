using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace buMutliTextbox;

[ToolboxItem(false)]
public class UnfocusablePanel : UserControl
{
	[CompilerGenerated]
	private Color color_0;

	[CompilerGenerated]
	private Color color_1;

	[CompilerGenerated]
	private string string_0;

	[CompilerGenerated]
	private StringAlignment stringAlignment_0;

	public Color BackColor2
	{
		[CompilerGenerated]
		get
		{
			return color_0;
		}
		[CompilerGenerated]
		set
		{
			color_0 = value;
		}
	}

	public Color BorderColor
	{
		[CompilerGenerated]
		get
		{
			return color_1;
		}
		[CompilerGenerated]
		set
		{
			color_1 = value;
		}
	}

	public new string Text
	{
		[CompilerGenerated]
		get
		{
			return string_0;
		}
		[CompilerGenerated]
		set
		{
			string_0 = value;
		}
	}

	public StringAlignment TextAlignment
	{
		[CompilerGenerated]
		get
		{
			return stringAlignment_0;
		}
		[CompilerGenerated]
		set
		{
			stringAlignment_0 = value;
		}
	}

	public UnfocusablePanel()
	{
		SetStyle(ControlStyles.Selectable, value: false);
		SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, value: true);
	}

	protected override void OnPaint(PaintEventArgs e)
	{
		using (LinearGradientBrush brush = new LinearGradientBrush(base.ClientRectangle, BackColor2, BackColor, 90f))
		{
			e.Graphics.FillRectangle(brush, 0, 0, base.ClientSize.Width - 1, base.ClientSize.Height - 1);
		}
		using (Pen pen = new Pen(BorderColor))
		{
			e.Graphics.DrawRectangle(pen, 0, 0, base.ClientSize.Width - 1, base.ClientSize.Height - 1);
		}
		if (!string.IsNullOrEmpty(Text))
		{
			StringFormat stringFormat = new StringFormat();
			stringFormat.Alignment = TextAlignment;
			stringFormat.LineAlignment = StringAlignment.Center;
			using SolidBrush brush2 = new SolidBrush(ForeColor);
			e.Graphics.DrawString(Text, Font, brush2, new RectangleF(1f, 1f, base.ClientSize.Width - 2, base.ClientSize.Height - 2), stringFormat);
		}
	}
}
