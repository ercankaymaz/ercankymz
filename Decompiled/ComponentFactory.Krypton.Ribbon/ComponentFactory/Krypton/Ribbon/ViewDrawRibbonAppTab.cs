#define DEBUG
using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using ComponentFactory.Krypton.Toolkit;

namespace ComponentFactory.Krypton.Ribbon;

internal class ViewDrawRibbonAppTab : ViewComposite, IContentValues
{
	private static Padding _preferredBorder = new Padding(17, 4, 17, 3);

	private KryptonRibbon _ribbon;

	private IDisposable[] _mementos;

	private PaletteRibbonGeneral _paletteGeneral;

	private ApplicationTabToContent _contentProvider;

	public ViewDrawRibbonAppTab(KryptonRibbon ribbon)
	{
		Debug.Assert(ribbon != null);
		_ribbon = ribbon;
		_mementos = new IDisposable[4];
		_paletteGeneral = ribbon.StateCommon.RibbonGeneral;
		_contentProvider = new ApplicationTabToContent(ribbon, _paletteGeneral);
		Add(new ViewDrawContent(_contentProvider, this, VisualOrientation.Top));
	}

	public override string ToString()
	{
		return "ViewDrawRibbonAppTab:" + base.Id;
	}

	protected override void Dispose(bool disposing)
	{
		if (disposing && _mementos != null)
		{
			IDisposable[] mementos = _mementos;
			for (int i = 0; i < mementos.Length; i++)
			{
				mementos[i]?.Dispose();
			}
			_mementos = null;
		}
		base.Dispose(disposing);
	}

	public override Size GetPreferredSize(ViewLayoutContext context)
	{
		Debug.Assert(context != null);
		Size preferredSize = base.GetPreferredSize(context);
		preferredSize.Width += _preferredBorder.Horizontal;
		preferredSize.Height += _preferredBorder.Vertical;
		return preferredSize;
	}

	public override void Layout(ViewLayoutContext context)
	{
		Debug.Assert(context != null);
		ClientRectangle = context.DisplayRectangle;
		base.Layout(context);
	}

	public override void RenderBefore(RenderContext context)
	{
		int num = State switch
		{
			PaletteState.Tracking => 1, 
			PaletteState.FocusOverride | PaletteState.Tracking => 2, 
			PaletteState.Pressed => 3, 
			_ => 0, 
		};
		_mementos[num] = context.Renderer.RenderRibbon.DrawRibbonApplicationTab(_ribbon.RibbonShape, context, ClientRectangle, State, _ribbon.RibbonAppButton.AppButtonBaseColorDark, _ribbon.RibbonAppButton.AppButtonBaseColorLight, _mementos[num]);
	}

	public Image GetImage(PaletteState state)
	{
		return null;
	}

	public Color GetImageTransparentColor(PaletteState state)
	{
		return Color.Empty;
	}

	public string GetShortText()
	{
		return _ribbon.RibbonAppButton.AppButtonText;
	}

	public string GetLongText()
	{
		return string.Empty;
	}
}
