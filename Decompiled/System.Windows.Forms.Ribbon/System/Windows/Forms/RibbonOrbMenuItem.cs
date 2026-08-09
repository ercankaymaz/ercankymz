using System.ComponentModel;
using System.Drawing;

namespace System.Windows.Forms;

[Designer(typeof(RibbonOrbMenuItemDesigner))]
public class RibbonOrbMenuItem : RibbonButton
{
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

	public RibbonOrbMenuItem()
	{
		base.DropDownArrowDirection = RibbonArrowDirection.Left;
		SetDropDownMargin(new Padding(10));
		base.DropDownShowing += RibbonOrbMenuItem_DropDownShowing;
	}

	public RibbonOrbMenuItem(string text)
		: this()
	{
		Text = text;
	}

	private void RibbonOrbMenuItem_DropDownShowing(object sender, EventArgs e)
	{
		if (base.DropDown != null)
		{
			base.DropDown.DrawIconsBar = false;
		}
	}

	public override void OnMouseEnter(MouseEventArgs e)
	{
		base.OnMouseEnter(e);
		if (RibbonDesigner.Current == null)
		{
			if (base.Owner.OrbDropDown.LastPoppedMenuItem != null)
			{
				base.Owner.OrbDropDown.LastPoppedMenuItem.CloseDropDown();
			}
			if (base.Style == RibbonButtonStyle.DropDown || base.Style == RibbonButtonStyle.SplitDropDown)
			{
				ShowDropDown();
				base.Owner.OrbDropDown.LastPoppedMenuItem = this;
			}
		}
	}

	public override void OnMouseLeave(MouseEventArgs e)
	{
		base.OnMouseLeave(e);
	}

	internal override Point OnGetDropDownMenuLocation()
	{
		if (base.Owner == null)
		{
			return base.OnGetDropDownMenuLocation();
		}
		Rectangle rectangle = base.Owner.RectangleToScreen(base.Bounds);
		Rectangle rectangle2 = base.Owner.OrbDropDown.RectangleToScreen(base.Owner.OrbDropDown.ContentRecentItemsBounds);
		return new Point(rectangle.Right, rectangle2.Top);
	}

	internal override Size OnGetDropDownMenuSize()
	{
		Rectangle contentRecentItemsBounds = base.Owner.OrbDropDown.ContentRecentItemsBounds;
		contentRecentItemsBounds.Inflate(-1, -1);
		return contentRecentItemsBounds.Size;
	}

	public override void OnClick(EventArgs e)
	{
		base.OnClick(e);
	}
}
