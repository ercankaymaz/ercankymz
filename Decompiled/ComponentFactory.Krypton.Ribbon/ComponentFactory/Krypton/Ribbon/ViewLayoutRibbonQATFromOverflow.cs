#define DEBUG
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows.Forms;
using ComponentFactory.Krypton.Toolkit;

namespace ComponentFactory.Krypton.Ribbon;

internal class ViewLayoutRibbonQATFromOverflow : ViewLayoutRibbonQATContents
{
	private Control _parentControl;

	private ViewLayoutRibbonQATContents _contents;

	public override IQuickAccessToolbarButton[] QATButtons
	{
		get
		{
			List<IQuickAccessToolbarButton> list = new List<IQuickAccessToolbarButton>();
			foreach (IQuickAccessToolbarButton qATButton in base.Ribbon.QATButtons)
			{
				if (qATButton.GetVisible())
				{
					ViewBase viewBase = _contents.ViewForButton(qATButton);
					if (viewBase != null && !viewBase.Visible)
					{
						list.Add(qATButton);
					}
				}
			}
			return list.ToArray();
		}
	}

	public override Control ParentControl => _parentControl;

	public ViewLayoutRibbonQATFromOverflow(Control parentControl, KryptonRibbon ribbon, NeedPaintHandler needPaint, bool showExtraButton, ViewLayoutRibbonQATContents contents)
		: base(ribbon, needPaint, showExtraButton)
	{
		Debug.Assert(parentControl != null);
		Debug.Assert(contents != null);
		_contents = contents;
		_parentControl = parentControl;
	}
}
