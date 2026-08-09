using System;
using ComponentFactory.Krypton.Toolkit;

namespace ComponentFactory.Krypton.Ribbon;

internal class ViewDrawRibbonAppMenuDocs : ViewLayoutDocker
{
	private KryptonRibbon _ribbon;

	private IDisposable _memento;

	public ViewDrawRibbonAppMenuDocs(KryptonRibbon ribbon)
	{
		_ribbon = ribbon;
	}

	public override string ToString()
	{
		return "ViewDrawRibbonAppMenuRecentDocs:" + base.Id;
	}

	protected override void Dispose(bool disposing)
	{
		if (disposing && _memento != null)
		{
			_memento.Dispose();
			_memento = null;
		}
		base.Dispose(disposing);
	}

	public override void RenderBefore(RenderContext context)
	{
		_memento = context.Renderer.RenderRibbon.DrawRibbonBack(_ribbon.RibbonShape, context, ClientRectangle, State, _ribbon.StateCommon.RibbonAppMenuDocs, VisualOrientation.Top, composition: false, _memento);
	}
}
