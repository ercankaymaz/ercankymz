#define DEBUG
using System;
using System.Diagnostics;

namespace ComponentFactory.Krypton.Toolkit;

internal class ViewDrawMenuHeading : ViewComposite
{
	private FixedContentValue _contentValues;

	private ViewDrawDocker _drawDocker;

	private ViewDrawContent _drawContent;

	public ViewDrawMenuHeading(KryptonContextMenuHeading heading, PaletteTripleRedirect palette)
	{
		_contentValues = new FixedContentValue(heading.Text, heading.ExtraText, heading.Image, heading.ImageTransparentColor);
		heading.SetPaletteRedirect(palette);
		_drawContent = new ViewDrawContent(heading.StateNormal.Content, _contentValues, VisualOrientation.Top);
		_drawDocker = new ViewDrawDocker(heading.StateNormal.Back, heading.StateNormal.Border);
		_drawDocker.Add(_drawContent, ViewDockStyle.Fill);
		Add(_drawDocker);
	}

	public override string ToString()
	{
		return "ViewDrawMenuHeading:" + base.Id;
	}

	public override void Layout(ViewLayoutContext context)
	{
		Debug.Assert(context != null);
		if (context == null)
		{
			throw new ArgumentNullException("context");
		}
		ClientRectangle = context.DisplayRectangle;
		base.Layout(context);
	}
}
