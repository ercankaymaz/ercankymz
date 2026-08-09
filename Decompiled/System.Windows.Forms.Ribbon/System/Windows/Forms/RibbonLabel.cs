using System.ComponentModel;
using System.Drawing;

namespace System.Windows.Forms;

public class RibbonLabel : RibbonItem
{
	private int _labelWidth;

	private const int spacing = 3;

	[Description("Sets the width of the label portion of the control")]
	[Category("Appearance")]
	[DefaultValue(0)]
	public int LabelWidth
	{
		get
		{
			return _labelWidth;
		}
		set
		{
			if (_labelWidth != value)
			{
				_labelWidth = value;
				NotifyOwnerRegionsChanged();
			}
		}
	}

	protected virtual int MeasureHeight()
	{
		if (base.Owner != null)
		{
			return 16 + base.Owner.ItemMargin.Vertical;
		}
		return 20;
	}

	public override Size MeasureSize(object sender, RibbonElementMeasureSizeEventArgs e)
	{
		if (!Visible && (Site == null || !Site.DesignMode))
		{
			return new Size(0, 0);
		}
		Font font = new Font("Microsoft Sans Serif", 8f);
		if (base.Owner != null)
		{
			font = base.Owner.Font;
		}
		int width = ((!string.IsNullOrEmpty(Text)) ? ((_labelWidth > 0) ? _labelWidth : (e.Graphics.MeasureString(Text, font).ToSize().Width + 6)) : 0);
		SetLastMeasuredSize(new Size(width, MeasureHeight()));
		return base.LastMeasuredSize;
	}

	public override void OnPaint(object sender, RibbonElementPaintEventArgs e)
	{
		if (base.Owner != null)
		{
			base.Owner.Renderer.OnRenderRibbonItem(new RibbonItemRenderEventArgs(base.Owner, e.Graphics, base.Bounds, this));
			StringFormat stringFormat = StringFormatFactory.CenterNoWrap(StringTrimming.None);
			stringFormat.Alignment = (StringAlignment)base.TextAlignment;
			Rectangle bounds = Rectangle.FromLTRB(base.Bounds.Left + 3, base.Bounds.Top + base.Owner.ItemMargin.Top, base.Bounds.Right - 3, base.Bounds.Bottom - base.Owner.ItemMargin.Bottom);
			base.Owner.Renderer.OnRenderRibbonItemText(new RibbonTextEventArgs(base.Owner, e.Graphics, base.Bounds, this, bounds, Text, stringFormat));
		}
	}

	public override void SetBounds(Rectangle bounds)
	{
		base.SetBounds(bounds);
	}
}
