using System.Windows.Forms;

namespace ComponentFactory.Krypton.Toolkit;

internal class KryptonStandardRenderer : KryptonProfessionalRenderer
{
	public KryptonStandardRenderer(KryptonColorTable kct)
		: base(kct)
	{
	}

	protected override void OnRenderItemText(ToolStripItemTextRenderEventArgs e)
	{
		if (e.ToolStrip is MenuStrip)
		{
			e.TextColor = base.KCT.MenuStripText;
		}
		else if (e.ToolStrip is StatusStrip)
		{
			e.TextColor = base.KCT.StatusStripText;
		}
		else if (e.ToolStrip is ContextMenuStrip || e.ToolStrip is ToolStripDropDown)
		{
			e.TextColor = base.KCT.MenuItemText;
		}
		else if (e.ToolStrip != null)
		{
			e.TextColor = base.KCT.ToolStripText;
		}
		base.OnRenderItemText(e);
	}

	protected override void OnRenderToolStripBackground(ToolStripRenderEventArgs e)
	{
		if (e.ToolStrip is MenuStrip || e.ToolStrip is ContextMenuStrip || e.ToolStrip is ToolStripDropDown)
		{
			if (e.ToolStrip.Font != base.KCT.MenuStripFont)
			{
				e.ToolStrip.Font = base.KCT.MenuStripFont;
			}
		}
		else if (e.ToolStrip is StatusStrip)
		{
			if (e.ToolStrip.Font != base.KCT.StatusStripFont)
			{
				e.ToolStrip.Font = base.KCT.StatusStripFont;
			}
		}
		else if (e.ToolStrip != null && e.ToolStrip.Font != base.KCT.ToolStripFont)
		{
			e.ToolStrip.Font = base.KCT.ToolStripFont;
		}
		base.OnRenderToolStripBackground(e);
	}
}
