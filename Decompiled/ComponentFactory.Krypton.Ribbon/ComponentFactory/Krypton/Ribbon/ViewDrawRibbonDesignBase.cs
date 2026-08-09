#define DEBUG
using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using ComponentFactory.Krypton.Toolkit;

namespace ComponentFactory.Krypton.Ribbon;

internal class ViewDrawRibbonDesignBase : ViewComposite, IContentValues
{
	private KryptonRibbon _ribbon;

	private NeedPaintHandler _needPaint;

	private DesignTextToContent _contentProvider;

	public KryptonRibbon Ribbon => _ribbon;

	protected virtual Padding PreferredPadding => Padding.Empty;

	protected virtual Padding LayoutPadding => Padding.Empty;

	protected virtual Padding OuterPadding => Padding.Empty;

	public ViewDrawRibbonDesignBase(KryptonRibbon ribbon, NeedPaintHandler needPaint)
	{
		Debug.Assert(ribbon != null);
		Debug.Assert(needPaint != null);
		_ribbon = ribbon;
		_needPaint = needPaint;
		_contentProvider = new DesignTextToContent(ribbon);
		Add(new ViewDrawContent(_contentProvider, this, VisualOrientation.Top));
		ViewHightlightController viewHightlightController = new ViewHightlightController(this, needPaint);
		viewHightlightController.Click += OnClick;
		MouseController = viewHightlightController;
	}

	public override string ToString()
	{
		return "ViewDrawRibbonDesignBase:" + base.Id;
	}

	public override Size GetPreferredSize(ViewLayoutContext context)
	{
		Size preferredSize = base.GetPreferredSize(context);
		return CommonHelper.ApplyPadding(Orientation.Horizontal, preferredSize, PreferredPadding);
	}

	public override void Layout(ViewLayoutContext context)
	{
		Debug.Assert(context != null);
		ClientRectangle = context.DisplayRectangle;
		ClientRectangle = new Rectangle(ClientLocation.X + OuterPadding.Left, ClientLocation.Y + OuterPadding.Top, ClientWidth - OuterPadding.Horizontal, ClientHeight - OuterPadding.Vertical);
		context.DisplayRectangle = new Rectangle(ClientLocation.X + LayoutPadding.Left, ClientLocation.Y + LayoutPadding.Top, ClientWidth - LayoutPadding.Horizontal, ClientHeight - LayoutPadding.Vertical);
		base.Layout(context);
		context.DisplayRectangle = ClientRectangle;
	}

	public override void RenderBefore(RenderContext context)
	{
		this[0].ElementState = ElementState;
		DesignTimeDraw.DrawArea(_ribbon, context, ClientRectangle, State);
		base.RenderBefore(context);
	}

	public Image GetImage(PaletteState state)
	{
		return null;
	}

	public Color GetImageTransparentColor(PaletteState state)
	{
		return Color.Empty;
	}

	public virtual string GetShortText()
	{
		return "Unknown";
	}

	public string GetLongText()
	{
		return string.Empty;
	}

	protected virtual void OnClick(object sender, EventArgs e)
	{
	}
}
