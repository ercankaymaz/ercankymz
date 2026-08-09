using System.ComponentModel;
using System.Drawing;

namespace System.Windows.Forms;

public class RibbonDescriptionMenuItem : RibbonButton
{
	public Rectangle DescriptionBounds { get; set; }

	[Browsable(false)]
	public override Image LargeImage
	{
		get
		{
			return base.Image;
		}
		set
		{
			base.Image = value;
		}
	}

	[DefaultValue(null)]
	[Browsable(true)]
	[Category("Appearance")]
	public override Image Image
	{
		get
		{
			return base.Image;
		}
		set
		{
			base.Image = value;
			SmallImage = value;
		}
	}

	[Browsable(false)]
	public override Image SmallImage
	{
		get
		{
			return base.SmallImage;
		}
		set
		{
			base.SmallImage = value;
		}
	}

	[DefaultValue(null)]
	public string Description { get; set; }

	public RibbonDescriptionMenuItem()
	{
		base.DropDownArrowDirection = RibbonArrowDirection.Left;
		SetDropDownMargin(new Padding(10));
	}

	public RibbonDescriptionMenuItem(string text)
		: this(null, text, null)
	{
	}

	public RibbonDescriptionMenuItem(string text, string description)
		: this(null, text, description)
	{
	}

	public RibbonDescriptionMenuItem(Image image, string text, string description)
	{
		Image = image;
		Text = text;
		Description = description;
	}

	protected override void OnPaintText(RibbonElementPaintEventArgs e)
	{
		if (e.Mode == RibbonElementSizeMode.DropDown)
		{
			StringFormat stringFormat = StringFormatFactory.NearCenter();
			base.Owner.Renderer.OnRenderRibbonItemText(new RibbonTextEventArgs(base.Owner, e.Graphics, e.Clip, this, base.TextBounds, Text, Color.Empty, FontStyle.Bold, stringFormat));
			stringFormat.Alignment = StringAlignment.Near;
			base.Owner.Renderer.OnRenderRibbonItemText(new RibbonTextEventArgs(base.Owner, e.Graphics, e.Clip, this, DescriptionBounds, Description, stringFormat));
		}
		else
		{
			base.OnPaintText(e);
		}
	}

	public override Size MeasureSize(object sender, RibbonElementMeasureSizeEventArgs e)
	{
		if (!Visible && !base.Owner.IsDesignMode())
		{
			SetLastMeasuredSize(new Size(0, 0));
			return base.LastMeasuredSize;
		}
		Size size = base.MeasureSize(sender, e);
		size.Height = 52;
		SetLastMeasuredSize(size);
		return size;
	}

	internal override Rectangle OnGetTextBounds(RibbonElementSizeMode sMode, Rectangle bounds)
	{
		Rectangle result = (DescriptionBounds = base.OnGetTextBounds(sMode, bounds));
		result.Height = 20;
		DescriptionBounds = Rectangle.FromLTRB(DescriptionBounds.Left, result.Bottom, DescriptionBounds.Right, DescriptionBounds.Bottom);
		return result;
	}
}
