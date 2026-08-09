using System.ComponentModel;
using System.Drawing;

namespace System.Windows.Forms;

public sealed class RibbonSeparator : RibbonItem
{
	[DefaultValue(true)]
	[Category("Appearance")]
	[Description("Background drawing should be avoided when group contains only TextBoxes and ComboBoxes")]
	public bool DrawBackground { get; set; } = true;

	[DefaultValue(0)]
	[Category("Appearance")]
	[Description("The width of the Separator bar when displayed on a drop down")]
	public RibbonSeparatorDropDownWidth DropDownWidth { get; set; }

	public RibbonSeparator()
	{
		DropDownWidth = RibbonSeparatorDropDownWidth.Partial;
	}

	public RibbonSeparator(string text)
		: this()
	{
		Text = text;
	}

	public override void OnPaint(object sender, RibbonElementPaintEventArgs e)
	{
		if ((base.Owner != null && DrawBackground) || base.Owner.IsDesignMode())
		{
			base.Owner.Renderer.OnRenderRibbonItem(new RibbonItemRenderEventArgs(base.Owner, e.Graphics, e.Clip, this));
			if (!string.IsNullOrEmpty(Text))
			{
				base.Owner.Renderer.OnRenderRibbonItemText(new RibbonTextEventArgs(base.Owner, e.Graphics, e.Clip, this, Rectangle.FromLTRB(base.Bounds.Left + base.Owner.ItemMargin.Left, base.Bounds.Top + base.Owner.ItemMargin.Top, base.Bounds.Right - base.Owner.ItemMargin.Right, base.Bounds.Bottom - base.Owner.ItemMargin.Bottom), Text, FontStyle.Bold));
			}
		}
	}

	public override void SetBounds(Rectangle bounds)
	{
		base.SetBounds(bounds);
	}

	public override Size MeasureSize(object sender, RibbonElementMeasureSizeEventArgs e)
	{
		if (e.SizeMode == RibbonElementSizeMode.DropDown)
		{
			if (string.IsNullOrEmpty(Text))
			{
				SetLastMeasuredSize(new Size(1, 2));
			}
			else
			{
				Size size = e.Graphics.MeasureString(Text, new Font(base.Owner.Font, FontStyle.Bold)).ToSize();
				SetLastMeasuredSize(new Size(size.Width + base.Owner.ItemMargin.Horizontal + 1, size.Height + base.Owner.ItemMargin.Vertical));
			}
		}
		else if (base.OwnerPanel == null)
		{
			SetLastMeasuredSize(new Size(7, base.Owner.QuickAccessToolbar.ContentBounds.Height - base.Owner.QuickAccessToolbar.Padding.Vertical));
		}
		else
		{
			SetLastMeasuredSize(new Size(4, base.OwnerPanel.ContentBounds.Height - base.Owner.ItemPadding.Vertical - base.Owner.ItemMargin.Vertical));
		}
		return base.LastMeasuredSize;
	}
}
