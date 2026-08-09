using System.Drawing;
using ComponentFactory.Krypton.Toolkit;

namespace ComponentFactory.Krypton.Ribbon;

internal class ViewDrawRibbonAppMenu : ViewDrawDocker
{
	private ViewBase _fixedElement;

	private Rectangle _fixedScreenRect;

	public ViewDrawRibbonAppMenu(IPaletteBack paletteBack, IPaletteBorder paletteBorder, ViewBase fixedElement, Rectangle fixedScreenRect)
		: base(paletteBack, paletteBorder)
	{
		_fixedElement = fixedElement;
		_fixedScreenRect = fixedScreenRect;
	}

	public override string ToString()
	{
		return "ViewDrawRibbonAppMenu:" + base.Id;
	}

	public override void RenderAfter(RenderContext renderContext)
	{
		base.RenderAfter(renderContext);
		Rectangle rectangle = renderContext.TopControl.RectangleToScreen(renderContext.TopControl.ClientRectangle);
		if (rectangle.Contains(_fixedScreenRect) && rectangle.Y == _fixedScreenRect.Y)
		{
			using (ViewLayoutContext viewLayoutContext = new ViewLayoutContext(renderContext.Control, renderContext.Renderer))
			{
				viewLayoutContext.DisplayRectangle = renderContext.TopControl.RectangleToClient(_fixedScreenRect);
				_fixedElement.Layout(viewLayoutContext);
			}
			_fixedElement.Render(renderContext);
		}
	}
}
