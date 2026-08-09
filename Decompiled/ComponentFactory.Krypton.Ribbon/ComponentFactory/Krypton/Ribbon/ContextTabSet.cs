#define DEBUG
using System.Diagnostics;
using System.Drawing;

namespace ComponentFactory.Krypton.Ribbon;

internal class ContextTabSet
{
	private ViewDrawRibbonTab _firstTab;

	private ViewDrawRibbonTab _lastTab;

	private KryptonRibbonContext _context;

	public ViewDrawRibbonTab FirstTab => _firstTab;

	public KryptonRibbonContext Context => _context;

	public string ContextName => _context.ContextName;

	public Color ContextColor => _context.ContextColor;

	public string ContextTitle => _context.ContextTitle;

	public ContextTabSet(ViewDrawRibbonTab tab, KryptonRibbonContext context)
	{
		Debug.Assert(tab != null);
		Debug.Assert(context != null);
		_firstTab = tab;
		_lastTab = tab;
		_context = context;
	}

	public bool IsFirstTab(ViewDrawRibbonTab tab)
	{
		return tab == _firstTab;
	}

	public bool IsLastTab(ViewDrawRibbonTab tab)
	{
		return tab == _lastTab;
	}

	public bool IsFirstOrLastTab(ViewDrawRibbonTab tab)
	{
		return tab == _firstTab || tab == _lastTab;
	}

	public void UpdateLastTab(ViewDrawRibbonTab tab)
	{
		Debug.Assert(tab != null);
		_lastTab = tab;
	}

	public Point GetLeftScreenPosition()
	{
		Point point = new Point(_firstTab.ClientLocation.X - 1, _firstTab.ClientLocation.Y);
		if (_firstTab.OwningControl != null)
		{
			return _firstTab.OwningControl.PointToScreen(point);
		}
		return point;
	}

	public Point GetRightScreenPosition()
	{
		Point point = new Point(_lastTab.ClientRectangle.Right + 1, _lastTab.ClientLocation.Y);
		if (_lastTab.OwningControl != null)
		{
			return _lastTab.OwningControl.PointToScreen(point);
		}
		return point;
	}
}
