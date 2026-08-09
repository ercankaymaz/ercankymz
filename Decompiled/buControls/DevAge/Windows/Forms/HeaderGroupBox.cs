using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace DevAge.Windows.Forms;

[ToolboxItem(false)]
public class HeaderGroupBox : GroupBox
{
	private Image image_0 = null;

	public Image Image
	{
		get
		{
			return image_0;
		}
		set
		{
			image_0 = value;
		}
	}

	protected override void OnPaint(PaintEventArgs e)
	{
		StringFormat stringFormat = new StringFormat();
		stringFormat.Trimming = StringTrimming.Character;
		stringFormat.Alignment = StringAlignment.Near;
		if (RightToLeft == RightToLeft.Yes)
		{
			stringFormat.FormatFlags |= StringFormatFlags.DirectionRightToLeft;
		}
		SizeF sizeF = e.Graphics.MeasureString(Text, Font, base.ClientRectangle.Size, stringFormat);
		if (!base.Enabled)
		{
			ControlPaint.DrawStringDisabled(e.Graphics, Text, Font, BackColor, base.ClientRectangle, stringFormat);
		}
		else
		{
			using Brush brush = new SolidBrush(ForeColor);
			e.Graphics.DrawString(Text, Font, brush, base.ClientRectangle, stringFormat);
		}
		Pen pen = new Pen(ControlPaint.LightLight(BackColor), SystemInformation.BorderSize.Height);
		Pen pen2 = new Pen(ControlPaint.Dark(BackColor), SystemInformation.BorderSize.Height);
		Point pt = new Point(base.ClientRectangle.Left, base.ClientRectangle.Top + (int)((float)Font.Height / 2f));
		Point pt2 = new Point(base.ClientRectangle.Right, base.ClientRectangle.Top + (int)((float)Font.Height / 2f));
		if (RightToLeft == RightToLeft.Yes)
		{
			pt2.X -= (int)sizeF.Width;
			if (image_0 != null)
			{
				pt.X += 17;
			}
			if (image_0 != null)
			{
				e.Graphics.DrawImage(image_0, 0, 0, 16, 16);
			}
		}
		else
		{
			pt.X += (int)sizeF.Width;
			if (image_0 != null)
			{
				pt2.X -= 17;
			}
			if (image_0 != null)
			{
				e.Graphics.DrawImage(image_0, pt2.X + 1, 0, 16, 16);
			}
		}
		if (base.FlatStyle != FlatStyle.Flat)
		{
			e.Graphics.DrawLine(pen2, pt, pt2);
			pt.Offset(0, (int)Math.Ceiling((float)SystemInformation.BorderSize.Height / 2f));
			pt2.Offset(0, (int)Math.Ceiling((float)SystemInformation.BorderSize.Height / 2f));
			e.Graphics.DrawLine(pen, pt, pt2);
		}
		else
		{
			e.Graphics.DrawLine(pen2, pt, pt2);
		}
		pen.Dispose();
		pen2.Dispose();
	}
}
