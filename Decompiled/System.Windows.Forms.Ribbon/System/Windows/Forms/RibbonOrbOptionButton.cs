using System.ComponentModel;
using System.Drawing;

namespace System.Windows.Forms;

public class RibbonOrbOptionButton : RibbonButton
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

	public RibbonOrbOptionButton()
	{
	}

	public RibbonOrbOptionButton(string text)
		: this()
	{
		Text = text;
	}
}
