#define DEBUG
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using ComponentFactory.Krypton.Toolkit;

namespace ComponentFactory.Krypton.Ribbon;

internal class ViewDrawRibbonGroupSeparator : ViewLeaf, IRibbonViewGroupContainerView
{
	private static readonly Size _preferredSize2007 = new Size(4, 4);

	private static readonly Size _preferredSize2010 = new Size(7, 4);

	private KryptonRibbon _ribbon;

	private KryptonRibbonGroupSeparator _ribbonSeparator;

	private NeedPaintHandler _needPaint;

	private Size _preferredSize;

	private PaletteRibbonShape _lastShape;

	public ViewDrawRibbonGroupSeparator(KryptonRibbon ribbon, KryptonRibbonGroupSeparator ribbonSeparator, NeedPaintHandler needPaint)
	{
		Debug.Assert(ribbon != null);
		Debug.Assert(ribbonSeparator != null);
		Debug.Assert(needPaint != null);
		_ribbon = ribbon;
		_ribbonSeparator = ribbonSeparator;
		_needPaint = needPaint;
		Component = _ribbonSeparator;
		if (_ribbon.InDesignMode)
		{
			ContextClickController contextClickController = new ContextClickController();
			contextClickController.ContextClick += OnContextClick;
			MouseController = contextClickController;
		}
		_ribbonSeparator.SeparatorView = this;
		_ribbonSeparator.PropertyChanged += OnSeparatorPropertyChanged;
		_lastShape = PaletteRibbonShape.Office2007;
		_preferredSize = _preferredSize2007;
	}

	public override string ToString()
	{
		return "ViewDrawRibbonGroupSeparator:" + base.Id;
	}

	protected override void Dispose(bool disposing)
	{
		if (disposing)
		{
			_ribbonSeparator.PropertyChanged -= OnSeparatorPropertyChanged;
			_ribbonSeparator.SeparatorView = null;
			_ribbonSeparator = null;
		}
		base.Dispose(disposing);
	}

	public ViewBase GetFirstFocusItem()
	{
		return null;
	}

	public ViewBase GetLastFocusItem()
	{
		return null;
	}

	public ViewBase GetNextFocusItem(ViewBase current, ref bool matched)
	{
		return null;
	}

	public ViewBase GetPreviousFocusItem(ViewBase current, ref bool matched)
	{
		return null;
	}

	public void GetGroupKeyTips(KeyTipInfoList keyTipList)
	{
	}

	public ItemSizeWidth[] GetPossibleSizes(ViewLayoutContext context)
	{
		if (_lastShape != _ribbon.RibbonShape)
		{
			PaletteRibbonShape ribbonShape = _ribbon.RibbonShape;
			PaletteRibbonShape paletteRibbonShape = ribbonShape;
			if (paletteRibbonShape == PaletteRibbonShape.Office2007 || paletteRibbonShape != PaletteRibbonShape.Office2010)
			{
				_lastShape = PaletteRibbonShape.Office2007;
				_preferredSize = _preferredSize2007;
			}
			else
			{
				_lastShape = PaletteRibbonShape.Office2010;
				_preferredSize = _preferredSize2010;
			}
		}
		return new ItemSizeWidth[1]
		{
			new ItemSizeWidth(GroupItemSize.Large, _preferredSize.Width)
		};
	}

	public void SetSolutionSize(ItemSizeWidth size)
	{
		Debug.Assert(size.GroupItemSize == GroupItemSize.Large);
	}

	public void ResetSolutionSize()
	{
	}

	public override Size GetPreferredSize(ViewLayoutContext context)
	{
		return _preferredSize;
	}

	public override void Layout(ViewLayoutContext context)
	{
		Debug.Assert(context != null);
		ClientRectangle = context.DisplayRectangle;
	}

	public override void RenderBefore(RenderContext context)
	{
		context.Renderer.RenderGlyph.DrawRibbonGroupSeparator(_ribbon.RibbonShape, context, ClientRectangle, _ribbon.StateCommon.RibbonGeneral, State);
	}

	protected virtual void OnNeedPaint(bool needLayout)
	{
		if (_needPaint != null)
		{
			_needPaint(this, new NeedLayoutEventArgs(needLayout));
			if (needLayout)
			{
				_ribbon.PerformLayout();
			}
		}
	}

	private void OnContextClick(object sender, MouseEventArgs e)
	{
		_ribbonSeparator.OnDesignTimeContextMenu(e);
	}

	private void OnSeparatorPropertyChanged(object sender, PropertyChangedEventArgs e)
	{
		string propertyName = e.PropertyName;
		string text = propertyName;
		if (text == "Visible" && _ribbonSeparator.RibbonTab != null && _ribbon.SelectedTab == _ribbonSeparator.RibbonTab)
		{
			OnNeedPaint(needLayout: true);
		}
	}
}
