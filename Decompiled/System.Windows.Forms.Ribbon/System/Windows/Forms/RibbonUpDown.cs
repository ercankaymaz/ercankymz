using System.ComponentModel;
using System.Drawing;

namespace System.Windows.Forms;

public class RibbonUpDown : RibbonTextBox
{
	private const int spacing = 3;

	private readonly int _UpDownSize = 16;

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public bool UpButtonPressed { get; private set; }

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public bool DownButtonPressed { get; private set; }

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public bool UpButtonSelected { get; private set; }

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public bool DownButtonSelected { get; private set; }

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public Rectangle UpButtonBounds { get; private set; }

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public Rectangle DownButtonBounds { get; private set; }

	public event MouseEventHandler UpButtonClicked;

	public event MouseEventHandler DownButtonClicked;

	public RibbonUpDown()
	{
		_textboxWidth = 50;
		_UpDownSize = 16;
	}

	public override int MeasureHeight()
	{
		return 16 + base.Owner.ItemMargin.Vertical;
	}

	public override void OnPaint(object sender, RibbonElementPaintEventArgs e)
	{
		if (base.Owner == null)
		{
			return;
		}
		base.Owner.Renderer.OnRenderRibbonItem(new RibbonItemRenderEventArgs(base.Owner, e.Graphics, base.Bounds, this));
		if (base.ImageVisible)
		{
			base.Owner.Renderer.OnRenderRibbonItemImage(new RibbonItemBoundsEventArgs(base.Owner, e.Graphics, e.Clip, this, _imageBounds));
		}
		using StringFormat stringFormat = StringFormatFactory.NearCenterNoWrap(StringTrimming.None);
		stringFormat.Alignment = StringAlignment.Near;
		stringFormat.LineAlignment = StringAlignment.Center;
		stringFormat.Trimming = StringTrimming.None;
		stringFormat.FormatFlags |= StringFormatFlags.NoWrap;
		base.Owner.Renderer.OnRenderRibbonItemText(new RibbonTextEventArgs(base.Owner, e.Graphics, base.Bounds, this, TextBoxTextBounds, base.TextBoxText, stringFormat));
		if (base.LabelVisible)
		{
			stringFormat.Alignment = (StringAlignment)base.TextAlignment;
			base.Owner.Renderer.OnRenderRibbonItemText(new RibbonTextEventArgs(base.Owner, e.Graphics, base.Bounds, this, LabelBounds, Text, stringFormat));
		}
	}

	public override void SetBounds(Rectangle bounds)
	{
		base.SetBounds(bounds);
		_textBoxBounds = Rectangle.FromLTRB(bounds.Right - base.TextBoxWidth - _UpDownSize, bounds.Top, bounds.Right - _UpDownSize, bounds.Bottom);
		if (Image != null)
		{
			_imageBounds = new Rectangle(bounds.Left + base.Owner.ItemMargin.Left, bounds.Top + base.Owner.ItemMargin.Top, Image.Width, Image.Height);
		}
		else
		{
			_imageBounds = new Rectangle(bounds.Location, Size.Empty);
		}
		_labelBounds = Rectangle.FromLTRB(_imageBounds.Right + ((_imageBounds.Width > 0) ? 3 : 0), bounds.Top, _textBoxBounds.Left - 3, bounds.Bottom - base.Owner.ItemMargin.Bottom);
		UpButtonBounds = new Rectangle(bounds.Right - _UpDownSize, bounds.Top, _UpDownSize, bounds.Height / 2);
		DownButtonBounds = new Rectangle(UpButtonBounds.X, UpButtonBounds.Bottom + 1, UpButtonBounds.Width, bounds.Height - UpButtonBounds.Height);
		if (base.SizeMode == RibbonElementSizeMode.Large)
		{
			_imageVisible = true;
			_labelVisible = true;
		}
		else if (base.SizeMode == RibbonElementSizeMode.Medium)
		{
			_imageVisible = true;
			_labelVisible = false;
			_labelBounds = Rectangle.Empty;
		}
		else if (base.SizeMode == RibbonElementSizeMode.Compact)
		{
			_imageBounds = Rectangle.Empty;
			_imageVisible = false;
			_labelBounds = Rectangle.Empty;
			_labelVisible = false;
		}
	}

	public override Size MeasureSize(object sender, RibbonElementMeasureSizeEventArgs e)
	{
		if (!Visible && !base.Owner.IsDesignMode())
		{
			SetLastMeasuredSize(new Size(0, 0));
			return base.LastMeasuredSize;
		}
		_ = Size.Empty;
		int num = 0;
		int num2 = ((Image != null) ? (Image.Width + 3) : 0);
		int num3 = ((!string.IsNullOrEmpty(Text)) ? ((_labelWidth > 0) ? _labelWidth : (e.Graphics.MeasureString(Text, base.Owner.Font).ToSize().Width + 3)) : 0);
		_ = base.TextBoxWidth;
		num += base.TextBoxWidth + _UpDownSize;
		switch (e.SizeMode)
		{
		case RibbonElementSizeMode.Large:
			num += num2 + num3;
			break;
		case RibbonElementSizeMode.Medium:
			num += num2;
			break;
		}
		SetLastMeasuredSize(new Size(num, MeasureHeight()));
		return base.LastMeasuredSize;
	}

	public override void OnMouseEnter(MouseEventArgs e)
	{
		if (Enabled)
		{
			base.OnMouseEnter(e);
			if (TextBoxBounds.Contains(e.Location))
			{
				base.Canvas.Cursor = Cursors.IBeam;
			}
		}
	}

	public override void OnMouseLeave(MouseEventArgs e)
	{
		if (Enabled)
		{
			base.OnMouseLeave(e);
			UpButtonPressed = false;
			DownButtonPressed = false;
			UpButtonSelected = false;
			DownButtonSelected = false;
			base.Canvas.Cursor = Cursors.Default;
		}
	}

	public override void OnMouseUp(MouseEventArgs e)
	{
		if (Enabled)
		{
			base.OnMouseUp(e);
			bool flag = false;
			if (UpButtonPressed || DownButtonPressed)
			{
				flag = true;
			}
			UpButtonPressed = false;
			DownButtonPressed = false;
			if (flag)
			{
				RedrawItem();
			}
		}
	}

	public override void OnMouseDown(MouseEventArgs e)
	{
		if (!Enabled)
		{
			return;
		}
		if (UpButtonBounds.Contains(e.Location))
		{
			UpButtonPressed = true;
			DownButtonPressed = false;
			DownButtonSelected = false;
			if (this.UpButtonClicked != null)
			{
				this.UpButtonClicked(this, e);
			}
		}
		else if (DownButtonBounds.Contains(e.Location))
		{
			DownButtonPressed = true;
			UpButtonPressed = false;
			UpButtonSelected = false;
			if (this.DownButtonClicked != null)
			{
				this.DownButtonClicked(this, e);
			}
		}
		else if (TextBoxBounds.Contains(e.X, e.Y) && base.AllowTextEdit)
		{
			StartEdit();
		}
	}

	public override void OnMouseMove(MouseEventArgs e)
	{
		if (Enabled)
		{
			base.OnMouseMove(e);
			bool flag = false;
			if (UpButtonBounds.Contains(e.Location))
			{
				base.Owner.Cursor = Cursors.Default;
				flag = !UpButtonSelected || DownButtonSelected || DownButtonPressed;
				UpButtonSelected = true;
				DownButtonSelected = false;
				DownButtonPressed = false;
			}
			else if (DownButtonBounds.Contains(e.Location))
			{
				base.Owner.Cursor = Cursors.Default;
				flag = !DownButtonSelected || UpButtonSelected || UpButtonPressed;
				DownButtonSelected = true;
				UpButtonSelected = false;
				UpButtonPressed = false;
			}
			else if (TextBoxBounds.Contains(e.X, e.Y))
			{
				base.Owner.Cursor = Cursors.IBeam;
				flag = DownButtonSelected || DownButtonPressed || UpButtonSelected || UpButtonPressed;
				UpButtonSelected = false;
				UpButtonPressed = false;
				DownButtonSelected = false;
				DownButtonPressed = false;
			}
			else
			{
				base.Owner.Cursor = Cursors.Default;
			}
			if (flag)
			{
				RedrawItem();
			}
		}
	}
}
