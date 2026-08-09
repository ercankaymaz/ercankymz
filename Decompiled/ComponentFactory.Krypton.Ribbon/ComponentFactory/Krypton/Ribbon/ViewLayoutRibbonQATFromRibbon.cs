using ComponentFactory.Krypton.Toolkit;

namespace ComponentFactory.Krypton.Ribbon;

internal class ViewLayoutRibbonQATFromRibbon : ViewLayoutRibbonQATContents
{
	public override IQuickAccessToolbarButton[] QATButtons
	{
		get
		{
			IQuickAccessToolbarButton[] array = new IQuickAccessToolbarButton[base.Ribbon.QATButtons.Count];
			base.Ribbon.QATButtons.CopyTo(array, 0);
			return array;
		}
	}

	public ViewLayoutRibbonQATFromRibbon(KryptonRibbon ribbon, NeedPaintHandler needPaint, bool showExtraButton)
		: base(ribbon, needPaint, showExtraButton)
	{
	}
}
