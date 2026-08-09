using System.ComponentModel;
using System.Drawing;

namespace ComponentFactory.Krypton.Toolkit;

public class KryptonPaletteTMSMenu : KryptonPaletteTMSBase
{
	[Browsable(false)]
	public override bool IsDefault => base.InternalKCT.InternalImageMarginGradientBegin == Color.Empty && base.InternalKCT.InternalImageMarginGradientEnd == Color.Empty && base.InternalKCT.InternalImageMarginGradientMiddle == Color.Empty && base.InternalKCT.InternalImageMarginRevealedGradientBegin == Color.Empty && base.InternalKCT.InternalImageMarginRevealedGradientEnd == Color.Empty && base.InternalKCT.InternalImageMarginRevealedGradientMiddle == Color.Empty && base.InternalKCT.InternalMenuBorder == Color.Empty && base.InternalKCT.InternalMenuItemText == Color.Empty && base.InternalKCT.InternalMenuItemBorder == Color.Empty && base.InternalKCT.InternalMenuItemPressedGradientBegin == Color.Empty && base.InternalKCT.InternalMenuItemPressedGradientEnd == Color.Empty && base.InternalKCT.InternalMenuItemPressedGradientMiddle == Color.Empty && base.InternalKCT.InternalMenuItemSelected == Color.Empty && base.InternalKCT.InternalMenuItemSelectedGradientBegin == Color.Empty && base.InternalKCT.InternalMenuItemSelectedGradientEnd == Color.Empty;

	[KryptonPersist(false)]
	[Category("ToolMenuStatus")]
	[Description("Staring color of the gradient used in the image margin of a ToolStripDropDownMenu.")]
	[KryptonDefaultColor]
	public Color ImageMarginGradientBegin
	{
		get
		{
			return base.InternalKCT.InternalImageMarginGradientBegin;
		}
		set
		{
			base.InternalKCT.InternalImageMarginGradientBegin = value;
			PerformNeedPaint(needLayout: false);
		}
	}

	[KryptonPersist(false)]
	[Category("ToolMenuStatus")]
	[Description("Ending color of the gradient used in the image margin of a ToolStripDropDownMenu.")]
	[KryptonDefaultColor]
	public Color ImageMarginGradientEnd
	{
		get
		{
			return base.InternalKCT.InternalImageMarginGradientEnd;
		}
		set
		{
			base.InternalKCT.InternalImageMarginGradientEnd = value;
			PerformNeedPaint(needLayout: false);
		}
	}

	[KryptonPersist(false)]
	[Category("ToolMenuStatus")]
	[Description("Middle color color of the gradient used in the image margin of a ToolStripDropDownMenu.")]
	[KryptonDefaultColor]
	public Color ImageMarginGradientMiddle
	{
		get
		{
			return base.InternalKCT.InternalImageMarginGradientMiddle;
		}
		set
		{
			base.InternalKCT.InternalImageMarginGradientMiddle = value;
			PerformNeedPaint(needLayout: false);
		}
	}

	[KryptonPersist(false)]
	[Category("ToolMenuStatus")]
	[Description("Starting color of the gradient used in the image margin of a ToolStripDropDownMenu when an item is revealed.")]
	[KryptonDefaultColor]
	public Color ImageMarginRevealedGradientBegin
	{
		get
		{
			return base.InternalKCT.InternalImageMarginRevealedGradientBegin;
		}
		set
		{
			base.InternalKCT.InternalImageMarginRevealedGradientBegin = value;
			PerformNeedPaint(needLayout: false);
		}
	}

	[KryptonPersist(false)]
	[Category("ToolMenuStatus")]
	[Description("Ending color of the gradient used in the image margin of a ToolStripDropDownMenu when an item is revealed.")]
	[KryptonDefaultColor]
	public Color ImageMarginRevealedGradientEnd
	{
		get
		{
			return base.InternalKCT.InternalImageMarginRevealedGradientEnd;
		}
		set
		{
			base.InternalKCT.InternalImageMarginRevealedGradientEnd = value;
			PerformNeedPaint(needLayout: false);
		}
	}

	[KryptonPersist(false)]
	[Category("ToolMenuStatus")]
	[Description("Middle color of the gradient used in the image margin of a ToolStripDropDownMenu when an item is revealed.")]
	[KryptonDefaultColor]
	public Color ImageMarginRevealedGradientMiddle
	{
		get
		{
			return base.InternalKCT.InternalImageMarginRevealedGradientMiddle;
		}
		set
		{
			base.InternalKCT.InternalImageMarginRevealedGradientMiddle = value;
			PerformNeedPaint(needLayout: false);
		}
	}

	[KryptonPersist(false)]
	[Category("ToolMenuStatus")]
	[Description("Color that is the border color to use on a MenuStrip.")]
	[KryptonDefaultColor]
	public Color MenuBorder
	{
		get
		{
			return base.InternalKCT.InternalMenuBorder;
		}
		set
		{
			base.InternalKCT.InternalMenuBorder = value;
			PerformNeedPaint(needLayout: false);
		}
	}

	[KryptonPersist(false)]
	[Category("ToolMenuStatus")]
	[Description("Color to draw text for individual a ToolStripMenuItem.")]
	[KryptonDefaultColor]
	public Color MenuItemText
	{
		get
		{
			return base.InternalKCT.InternalMenuItemText;
		}
		set
		{
			base.InternalKCT.InternalMenuItemText = value;
			PerformNeedPaint(needLayout: false);
		}
	}

	[KryptonPersist(false)]
	[Category("ToolMenuStatus")]
	[Description("Border color to use with a ToolStripMenuItem.")]
	[KryptonDefaultColor]
	public Color MenuItemBorder
	{
		get
		{
			return base.InternalKCT.InternalMenuItemBorder;
		}
		set
		{
			base.InternalKCT.InternalMenuItemBorder = value;
			PerformNeedPaint(needLayout: false);
		}
	}

	[KryptonPersist(false)]
	[Category("ToolMenuStatus")]
	[Description("Starting color of the gradient used when a top-level ToolStripMenuItem is pressed.")]
	[KryptonDefaultColor]
	public Color MenuItemPressedGradientBegin
	{
		get
		{
			return base.InternalKCT.InternalMenuItemPressedGradientBegin;
		}
		set
		{
			base.InternalKCT.InternalMenuItemPressedGradientBegin = value;
			PerformNeedPaint(needLayout: false);
		}
	}

	[KryptonPersist(false)]
	[Category("ToolMenuStatus")]
	[Description("Ending color of the gradient used when a top-level ToolStripMenuItem is pressed.")]
	[KryptonDefaultColor]
	public Color MenuItemPressedGradientEnd
	{
		get
		{
			return base.InternalKCT.InternalMenuItemPressedGradientEnd;
		}
		set
		{
			base.InternalKCT.InternalMenuItemPressedGradientEnd = value;
			PerformNeedPaint(needLayout: false);
		}
	}

	[KryptonPersist(false)]
	[Category("ToolMenuStatus")]
	[Description("Middle color of the gradient used when a top-level ToolStripMenuItem is pressed.")]
	[KryptonDefaultColor]
	public Color MenuItemPressedGradientMiddle
	{
		get
		{
			return base.InternalKCT.InternalMenuItemPressedGradientMiddle;
		}
		set
		{
			base.InternalKCT.InternalMenuItemPressedGradientMiddle = value;
			PerformNeedPaint(needLayout: false);
		}
	}

	[KryptonPersist(false)]
	[Category("ToolMenuStatus")]
	[Description("Solid color to use when a ToolStripMenuItem other than the top-level ToolStripMenuItem is selected.")]
	[KryptonDefaultColor]
	public Color MenuItemSelected
	{
		get
		{
			return base.InternalKCT.InternalMenuItemSelected;
		}
		set
		{
			base.InternalKCT.InternalMenuItemSelected = value;
			PerformNeedPaint(needLayout: false);
		}
	}

	[KryptonPersist(false)]
	[Category("ToolMenuStatus")]
	[Description("Starting color of the gradient used when the ToolStripMenuItem is selected.")]
	[KryptonDefaultColor]
	public Color MenuItemSelectedGradientBegin
	{
		get
		{
			return base.InternalKCT.InternalMenuItemSelectedGradientBegin;
		}
		set
		{
			base.InternalKCT.InternalMenuItemSelectedGradientBegin = value;
			PerformNeedPaint(needLayout: false);
		}
	}

	[KryptonPersist(false)]
	[Category("ToolMenuStatus")]
	[Description("Ending color of the gradient used when the ToolStripMenuItem is selected.")]
	[KryptonDefaultColor]
	public Color MenuItemSelectedGradientEnd
	{
		get
		{
			return base.InternalKCT.InternalMenuItemSelectedGradientEnd;
		}
		set
		{
			base.InternalKCT.InternalMenuItemSelectedGradientEnd = value;
			PerformNeedPaint(needLayout: false);
		}
	}

	internal KryptonPaletteTMSMenu(KryptonInternalKCT internalKCT, NeedPaintHandler needPaint)
		: base(internalKCT, needPaint)
	{
	}

	public void PopulateFromBase()
	{
		ImageMarginGradientBegin = base.InternalKCT.ImageMarginGradientBegin;
		ImageMarginGradientEnd = base.InternalKCT.ImageMarginGradientEnd;
		ImageMarginGradientMiddle = base.InternalKCT.ImageMarginGradientMiddle;
		ImageMarginRevealedGradientBegin = base.InternalKCT.ImageMarginRevealedGradientBegin;
		ImageMarginRevealedGradientEnd = base.InternalKCT.ImageMarginRevealedGradientEnd;
		ImageMarginRevealedGradientMiddle = base.InternalKCT.ImageMarginRevealedGradientMiddle;
		MenuBorder = base.InternalKCT.MenuBorder;
		MenuItemText = base.InternalKCT.MenuItemText;
		MenuItemBorder = base.InternalKCT.MenuItemBorder;
		MenuItemPressedGradientBegin = base.InternalKCT.MenuItemPressedGradientBegin;
		MenuItemPressedGradientEnd = base.InternalKCT.MenuItemPressedGradientEnd;
		MenuItemPressedGradientMiddle = base.InternalKCT.MenuItemPressedGradientMiddle;
		MenuItemSelected = base.InternalKCT.MenuItemSelected;
		MenuItemSelectedGradientBegin = base.InternalKCT.MenuItemSelectedGradientBegin;
		MenuItemSelectedGradientEnd = base.InternalKCT.MenuItemSelectedGradientEnd;
	}

	public void ResetImageMarginGradientBegin()
	{
		ImageMarginGradientBegin = Color.Empty;
	}

	public void ResetImageMarginGradientEnd()
	{
		ImageMarginGradientEnd = Color.Empty;
	}

	public void ResetImageMarginGradientMiddle()
	{
		ImageMarginGradientMiddle = Color.Empty;
	}

	public void ResetImageMarginRevealedGradientBegin()
	{
		ImageMarginRevealedGradientBegin = Color.Empty;
	}

	public void ResetImageMarginRevealedGradientEnd()
	{
		ImageMarginRevealedGradientEnd = Color.Empty;
	}

	public void ResetImageMarginRevealedGradientMiddle()
	{
		ImageMarginRevealedGradientMiddle = Color.Empty;
	}

	public void ResetMenuBorder()
	{
		MenuBorder = Color.Empty;
	}

	public void ResetMenuItemText()
	{
		MenuItemText = Color.Empty;
	}

	public void ResetMenuItemBorder()
	{
		MenuItemBorder = Color.Empty;
	}

	public void ResetMenuItemPressedGradientBegin()
	{
		MenuItemPressedGradientBegin = Color.Empty;
	}

	public void ResetMenuItemPressedGradientEnd()
	{
		MenuItemPressedGradientEnd = Color.Empty;
	}

	public void ResetMenuItemPressedGradientMiddle()
	{
		MenuItemPressedGradientMiddle = Color.Empty;
	}

	public void ResetMenuItemSelected()
	{
		MenuItemSelected = Color.Empty;
	}

	public void ResetMenuItemSelectedGradientBegin()
	{
		MenuItemSelectedGradientBegin = Color.Empty;
	}

	public void ResetMenuItemSelectedGradientEnd()
	{
		MenuItemSelectedGradientEnd = Color.Empty;
	}
}
