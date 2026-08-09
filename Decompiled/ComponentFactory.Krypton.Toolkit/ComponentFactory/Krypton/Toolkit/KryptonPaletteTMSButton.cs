using System.ComponentModel;
using System.Drawing;

namespace ComponentFactory.Krypton.Toolkit;

public class KryptonPaletteTMSButton : KryptonPaletteTMSBase
{
	[Browsable(false)]
	public override bool IsDefault => base.InternalKCT.InternalButtonCheckedGradientBegin == Color.Empty && base.InternalKCT.InternalButtonCheckedGradientEnd == Color.Empty && base.InternalKCT.InternalButtonCheckedGradientMiddle == Color.Empty && base.InternalKCT.InternalButtonCheckedHighlight == Color.Empty && base.InternalKCT.InternalButtonCheckedHighlightBorder == Color.Empty && base.InternalKCT.InternalButtonPressedBorder == Color.Empty && base.InternalKCT.InternalButtonPressedGradientBegin == Color.Empty && base.InternalKCT.InternalButtonPressedGradientEnd == Color.Empty && base.InternalKCT.InternalButtonPressedGradientMiddle == Color.Empty && base.InternalKCT.InternalButtonPressedHighlight == Color.Empty && base.InternalKCT.InternalButtonPressedHighlightBorder == Color.Empty && base.InternalKCT.InternalButtonSelectedBorder == Color.Empty && base.InternalKCT.InternalButtonSelectedGradientBegin == Color.Empty && base.InternalKCT.InternalButtonSelectedGradientEnd == Color.Empty && base.InternalKCT.InternalButtonSelectedGradientMiddle == Color.Empty && base.InternalKCT.InternalButtonSelectedHighlight == Color.Empty && base.InternalKCT.InternalButtonSelectedHighlightBorder == Color.Empty && base.InternalKCT.InternalCheckBackground == Color.Empty && base.InternalKCT.InternalCheckPressedBackground == Color.Empty && base.InternalKCT.InternalCheckSelectedBackground == Color.Empty && base.InternalKCT.InternalOverflowButtonGradientBegin == Color.Empty && base.InternalKCT.InternalOverflowButtonGradientEnd == Color.Empty && base.InternalKCT.InternalOverflowButtonGradientMiddle == Color.Empty;

	[KryptonPersist(false)]
	[Category("ToolMenuStatus")]
	[Description("Starting color of the gradient used when the button is checked.")]
	[KryptonDefaultColor]
	public Color ButtonCheckedGradientBegin
	{
		get
		{
			return base.InternalKCT.InternalButtonCheckedGradientBegin;
		}
		set
		{
			base.InternalKCT.InternalButtonCheckedGradientBegin = value;
			PerformNeedPaint(needLayout: false);
		}
	}

	[KryptonPersist(false)]
	[Category("ToolMenuStatus")]
	[Description("Ending color of the gradient used when the button is checked.")]
	[KryptonDefaultColor]
	public Color ButtonCheckedGradientEnd
	{
		get
		{
			return base.InternalKCT.InternalButtonCheckedGradientEnd;
		}
		set
		{
			base.InternalKCT.InternalButtonCheckedGradientEnd = value;
			PerformNeedPaint(needLayout: false);
		}
	}

	[KryptonPersist(false)]
	[Category("ToolMenuStatus")]
	[Description("Middle color of the gradient used when the button is checked.")]
	[KryptonDefaultColor]
	public Color ButtonCheckedGradientMiddle
	{
		get
		{
			return base.InternalKCT.InternalButtonCheckedGradientMiddle;
		}
		set
		{
			base.InternalKCT.InternalButtonCheckedGradientMiddle = value;
			PerformNeedPaint(needLayout: false);
		}
	}

	[KryptonPersist(false)]
	[Category("ToolMenuStatus")]
	[Description("Highlight color used when the button is checked.")]
	[KryptonDefaultColor]
	public Color ButtonCheckedHighlight
	{
		get
		{
			return base.InternalKCT.InternalButtonCheckedHighlight;
		}
		set
		{
			base.InternalKCT.InternalButtonCheckedHighlight = value;
			PerformNeedPaint(needLayout: false);
		}
	}

	[KryptonPersist(false)]
	[Category("ToolMenuStatus")]
	[Description("Border color to use with ButtonCheckedHighlight.")]
	[KryptonDefaultColor]
	public Color ButtonCheckedHighlightBorder
	{
		get
		{
			return base.InternalKCT.InternalButtonCheckedHighlightBorder;
		}
		set
		{
			base.InternalKCT.InternalButtonCheckedHighlightBorder = value;
			PerformNeedPaint(needLayout: false);
		}
	}

	[KryptonPersist(false)]
	[Category("ToolMenuStatus")]
	[Description("Border color to use with the ButtonPressedGradientBegin, ButtonPressedGradientMiddle, and ButtonPressedGradientEnd colors.")]
	[KryptonDefaultColor]
	public Color ButtonPressedBorder
	{
		get
		{
			return base.InternalKCT.InternalButtonPressedBorder;
		}
		set
		{
			base.InternalKCT.InternalButtonPressedBorder = value;
			PerformNeedPaint(needLayout: false);
		}
	}

	[KryptonPersist(false)]
	[Category("ToolMenuStatus")]
	[Description("Starting color of the gradient used when the button is pressed.")]
	[KryptonDefaultColor]
	public Color ButtonPressedGradientBegin
	{
		get
		{
			return base.InternalKCT.InternalButtonPressedGradientBegin;
		}
		set
		{
			base.InternalKCT.InternalButtonPressedGradientBegin = value;
			PerformNeedPaint(needLayout: false);
		}
	}

	[KryptonPersist(false)]
	[Category("ToolMenuStatus")]
	[Description("Ending color of the gradient used when the button is pressed.")]
	[KryptonDefaultColor]
	public Color ButtonPressedGradientEnd
	{
		get
		{
			return base.InternalKCT.InternalButtonPressedGradientEnd;
		}
		set
		{
			base.InternalKCT.InternalButtonPressedGradientEnd = value;
			PerformNeedPaint(needLayout: false);
		}
	}

	[KryptonPersist(false)]
	[Category("ToolMenuStatus")]
	[Description("Middle olor of the gradient used when the button is pressed.")]
	[KryptonDefaultColor]
	public Color ButtonPressedGradientMiddle
	{
		get
		{
			return base.InternalKCT.InternalButtonPressedGradientMiddle;
		}
		set
		{
			base.InternalKCT.InternalButtonPressedGradientMiddle = value;
			PerformNeedPaint(needLayout: false);
		}
	}

	[KryptonPersist(false)]
	[Category("ToolMenuStatus")]
	[Description("Solid color used when the button is pressed.")]
	[KryptonDefaultColor]
	public Color ButtonPressedHighlight
	{
		get
		{
			return base.InternalKCT.InternalButtonPressedHighlight;
		}
		set
		{
			base.InternalKCT.InternalButtonPressedHighlight = value;
			PerformNeedPaint(needLayout: false);
		}
	}

	[KryptonPersist(false)]
	[Category("ToolMenuStatus")]
	[Description("Border color to use with ButtonPressedHighlight.")]
	[KryptonDefaultColor]
	public Color ButtonPressedHighlightBorder
	{
		get
		{
			return base.InternalKCT.InternalButtonPressedHighlightBorder;
		}
		set
		{
			base.InternalKCT.InternalButtonPressedHighlightBorder = value;
			PerformNeedPaint(needLayout: false);
		}
	}

	[KryptonPersist(false)]
	[Category("ToolMenuStatus")]
	[Description("Border color to use with the ButtonSelectedGradientBegin, ButtonSelectedGradientMiddle, and ButtonSelectedGradientEnd colors.")]
	[KryptonDefaultColor]
	public Color ButtonSelectedBorder
	{
		get
		{
			return base.InternalKCT.InternalButtonSelectedBorder;
		}
		set
		{
			base.InternalKCT.InternalButtonSelectedBorder = value;
			PerformNeedPaint(needLayout: false);
		}
	}

	[KryptonPersist(false)]
	[Category("ToolMenuStatus")]
	[Description("Starting color of the gradient used when the button is selected.")]
	[KryptonDefaultColor]
	public Color ButtonSelectedGradientBegin
	{
		get
		{
			return base.InternalKCT.InternalButtonSelectedGradientBegin;
		}
		set
		{
			base.InternalKCT.InternalButtonSelectedGradientBegin = value;
			PerformNeedPaint(needLayout: false);
		}
	}

	[KryptonPersist(false)]
	[Category("ToolMenuStatus")]
	[Description("Ending color of the gradient used when the button is selected.")]
	[KryptonDefaultColor]
	public Color ButtonSelectedGradientEnd
	{
		get
		{
			return base.InternalKCT.InternalButtonSelectedGradientEnd;
		}
		set
		{
			base.InternalKCT.InternalButtonSelectedGradientEnd = value;
			PerformNeedPaint(needLayout: false);
		}
	}

	[KryptonPersist(false)]
	[Category("ToolMenuStatus")]
	[Description("Middle olor of the gradient used when the button is selected.")]
	[KryptonDefaultColor]
	public Color ButtonSelectedGradientMiddle
	{
		get
		{
			return base.InternalKCT.InternalButtonSelectedGradientMiddle;
		}
		set
		{
			base.InternalKCT.InternalButtonSelectedGradientMiddle = value;
			PerformNeedPaint(needLayout: false);
		}
	}

	[KryptonPersist(false)]
	[Category("ToolMenuStatus")]
	[Description("Solid color used when the button is selected.")]
	[KryptonDefaultColor]
	public Color ButtonSelectedHighlight
	{
		get
		{
			return base.InternalKCT.InternalButtonSelectedHighlight;
		}
		set
		{
			base.InternalKCT.InternalButtonSelectedHighlight = value;
			PerformNeedPaint(needLayout: false);
		}
	}

	[KryptonPersist(false)]
	[Category("ToolMenuStatus")]
	[Description("Border color to use with ButtonSelectedHighlight.")]
	[KryptonDefaultColor]
	public Color ButtonSelectedHighlightBorder
	{
		get
		{
			return base.InternalKCT.InternalButtonSelectedHighlightBorder;
		}
		set
		{
			base.InternalKCT.InternalButtonSelectedHighlightBorder = value;
			PerformNeedPaint(needLayout: false);
		}
	}

	[KryptonPersist(false)]
	[Category("ToolMenuStatus")]
	[Description("Solid color to use when the button is checked and gradients are being used.")]
	[KryptonDefaultColor]
	public Color CheckBackground
	{
		get
		{
			return base.InternalKCT.InternalCheckBackground;
		}
		set
		{
			base.InternalKCT.InternalCheckBackground = value;
			PerformNeedPaint(needLayout: false);
		}
	}

	[KryptonPersist(false)]
	[Category("ToolMenuStatus")]
	[Description("Solid color to use when the button is checked and selected and gradients are being used.")]
	[KryptonDefaultColor]
	public Color CheckPressedBackground
	{
		get
		{
			return base.InternalKCT.InternalCheckPressedBackground;
		}
		set
		{
			base.InternalKCT.InternalCheckPressedBackground = value;
			PerformNeedPaint(needLayout: false);
		}
	}

	[KryptonPersist(false)]
	[Category("ToolMenuStatus")]
	[Description("Solid color to use when the button is checked and selected and gradients are being used.")]
	[KryptonDefaultColor]
	public Color CheckSelectedBackground
	{
		get
		{
			return base.InternalKCT.InternalCheckSelectedBackground;
		}
		set
		{
			base.InternalKCT.InternalCheckSelectedBackground = value;
			PerformNeedPaint(needLayout: false);
		}
	}

	[KryptonPersist(false)]
	[Category("ToolMenuStatus")]
	[Description("Starting color of the gradient used in the ToolStripOverflowButton.")]
	[KryptonDefaultColor]
	public Color OverflowButtonGradientBegin
	{
		get
		{
			return base.InternalKCT.InternalOverflowButtonGradientBegin;
		}
		set
		{
			base.InternalKCT.InternalOverflowButtonGradientBegin = value;
			PerformNeedPaint(needLayout: false);
		}
	}

	[KryptonPersist(false)]
	[Category("ToolMenuStatus")]
	[Description("Ending color of the gradient used in the ToolStripOverflowButton.")]
	[KryptonDefaultColor]
	public Color OverflowButtonGradientEnd
	{
		get
		{
			return base.InternalKCT.InternalOverflowButtonGradientEnd;
		}
		set
		{
			base.InternalKCT.InternalOverflowButtonGradientEnd = value;
			PerformNeedPaint(needLayout: false);
		}
	}

	[KryptonPersist(false)]
	[Category("ToolMenuStatus")]
	[Description("Middle color of the gradient used in the ToolStripOverflowButton.")]
	[KryptonDefaultColor]
	public Color OverflowButtonGradientMiddle
	{
		get
		{
			return base.InternalKCT.InternalOverflowButtonGradientMiddle;
		}
		set
		{
			base.InternalKCT.InternalOverflowButtonGradientMiddle = value;
			PerformNeedPaint(needLayout: false);
		}
	}

	internal KryptonPaletteTMSButton(KryptonInternalKCT internalKCT, NeedPaintHandler needPaint)
		: base(internalKCT, needPaint)
	{
	}

	public void PopulateFromBase()
	{
		ButtonCheckedGradientBegin = base.InternalKCT.ButtonCheckedGradientBegin;
		ButtonCheckedGradientEnd = base.InternalKCT.ButtonCheckedGradientEnd;
		ButtonCheckedGradientMiddle = base.InternalKCT.ButtonCheckedGradientMiddle;
		ButtonCheckedHighlight = base.InternalKCT.ButtonCheckedHighlight;
		ButtonCheckedHighlightBorder = base.InternalKCT.ButtonCheckedHighlightBorder;
		ButtonPressedBorder = base.InternalKCT.ButtonPressedBorder;
		ButtonPressedGradientBegin = base.InternalKCT.ButtonPressedGradientBegin;
		ButtonPressedGradientEnd = base.InternalKCT.ButtonPressedGradientEnd;
		ButtonPressedGradientMiddle = base.InternalKCT.ButtonPressedGradientMiddle;
		ButtonPressedHighlight = base.InternalKCT.ButtonPressedHighlight;
		ButtonPressedHighlightBorder = base.InternalKCT.ButtonPressedHighlightBorder;
		ButtonSelectedBorder = base.InternalKCT.ButtonSelectedBorder;
		ButtonSelectedGradientBegin = base.InternalKCT.ButtonSelectedGradientBegin;
		ButtonSelectedGradientEnd = base.InternalKCT.ButtonSelectedGradientEnd;
		ButtonSelectedGradientMiddle = base.InternalKCT.ButtonSelectedGradientMiddle;
		ButtonSelectedHighlight = base.InternalKCT.ButtonSelectedHighlight;
		ButtonSelectedHighlightBorder = base.InternalKCT.ButtonSelectedHighlightBorder;
		CheckBackground = base.InternalKCT.CheckBackground;
		CheckPressedBackground = base.InternalKCT.CheckPressedBackground;
		CheckSelectedBackground = base.InternalKCT.CheckSelectedBackground;
		OverflowButtonGradientBegin = base.InternalKCT.OverflowButtonGradientBegin;
		OverflowButtonGradientEnd = base.InternalKCT.OverflowButtonGradientEnd;
		OverflowButtonGradientMiddle = base.InternalKCT.OverflowButtonGradientMiddle;
	}

	public void ResetButtonCheckedGradientBegin()
	{
		ButtonCheckedGradientBegin = Color.Empty;
	}

	public void ResetButtonCheckedGradientEnd()
	{
		ButtonCheckedGradientEnd = Color.Empty;
	}

	public void ResetButtonCheckedGradientMiddle()
	{
		ButtonCheckedGradientMiddle = Color.Empty;
	}

	public void ResetButtonCheckedHighlight()
	{
		ButtonCheckedHighlight = Color.Empty;
	}

	public void ResetButtonCheckedHighlightBorder()
	{
		ButtonCheckedHighlightBorder = Color.Empty;
	}

	public void ResetButtonPressedBorder()
	{
		ButtonPressedBorder = Color.Empty;
	}

	public void ResetButtonPressedGradientBegin()
	{
		ButtonPressedGradientBegin = Color.Empty;
	}

	public void ResetButtonPressedGradientEnd()
	{
		ButtonPressedGradientEnd = Color.Empty;
	}

	public void ResetButtonPressedGradientMiddle()
	{
		ButtonPressedGradientMiddle = Color.Empty;
	}

	public void ResetButtonPressedHighlight()
	{
		ButtonPressedHighlight = Color.Empty;
	}

	public void ResetButtonPressedHighlightBorder()
	{
		ButtonPressedHighlightBorder = Color.Empty;
	}

	public void ResetButtonSelectedBorder()
	{
		ButtonSelectedBorder = Color.Empty;
	}

	public void ResetButtonSelectedGradientBegin()
	{
		ButtonSelectedGradientBegin = Color.Empty;
	}

	public void ResetButtonSelectedGradientEnd()
	{
		ButtonSelectedGradientEnd = Color.Empty;
	}

	public void ResetButtonSelectedGradientMiddle()
	{
		ButtonSelectedGradientMiddle = Color.Empty;
	}

	public void ResetButtonSelectedHighlight()
	{
		ButtonSelectedHighlight = Color.Empty;
	}

	public void ResetButtonSelectedHighlightBorder()
	{
		ButtonSelectedHighlightBorder = Color.Empty;
	}

	public void ResetCheckBackground()
	{
		CheckBackground = Color.Empty;
	}

	public void ResetCheckPressedBackground()
	{
		CheckPressedBackground = Color.Empty;
	}

	public void ResetCheckSelectedBackground()
	{
		CheckSelectedBackground = Color.Empty;
	}

	public void ResetOverflowButtonGradientBegin()
	{
		OverflowButtonGradientBegin = Color.Empty;
	}

	public void ResetOverflowButtonGradientEnd()
	{
		OverflowButtonGradientEnd = Color.Empty;
	}

	public void ResetOverflowButtonGradientMiddle()
	{
		OverflowButtonGradientMiddle = Color.Empty;
	}
}
