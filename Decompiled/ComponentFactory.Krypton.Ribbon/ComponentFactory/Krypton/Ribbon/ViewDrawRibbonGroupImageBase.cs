#define DEBUG
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using ComponentFactory.Krypton.Toolkit;

namespace ComponentFactory.Krypton.Ribbon;

internal abstract class ViewDrawRibbonGroupImageBase : ViewLeaf
{
	private KryptonRibbon _ribbon;

	protected KryptonRibbon Ribbon => _ribbon;

	protected abstract Size DrawSize { get; }

	protected abstract Image DrawImage { get; }

	public ViewDrawRibbonGroupImageBase(KryptonRibbon ribbon)
	{
		Debug.Assert(ribbon != null);
		_ribbon = ribbon;
	}

	public override string ToString()
	{
		return "ViewDrawRibbonGroupImageBase:" + base.Id;
	}

	public override Size GetPreferredSize(ViewLayoutContext context)
	{
		return DrawSize;
	}

	public override void Layout(ViewLayoutContext context)
	{
		ClientRectangle = context.DisplayRectangle;
	}

	public override void RenderBefore(RenderContext context)
	{
		if (DrawImage == null)
		{
			return;
		}
		if (Enabled)
		{
			context.Graphics.DrawImage(DrawImage, ClientRectangle);
			return;
		}
		using ImageAttributes imageAttributes = new ImageAttributes();
		imageAttributes.SetColorMatrix(CommonHelper.MatrixDisabled);
		context.Graphics.DrawImage(DrawImage, ClientRectangle, 0, 0, DrawImage.Width, DrawImage.Height, GraphicsUnit.Pixel, imageAttributes);
	}
}
