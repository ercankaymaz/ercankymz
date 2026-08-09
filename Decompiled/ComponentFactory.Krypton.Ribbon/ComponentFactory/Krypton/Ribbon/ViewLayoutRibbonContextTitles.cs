#define DEBUG
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using ComponentFactory.Krypton.Toolkit;

namespace ComponentFactory.Krypton.Ribbon;

internal class ViewLayoutRibbonContextTitles : ViewLayoutDocker
{
	private class ViewDrawRibbonContextTitleList : List<ViewDrawRibbonContextTitle>
	{
	}

	private KryptonRibbon _ribbon;

	private ViewDrawRibbonContextTitleList _contextTitlesCache;

	private ViewDrawRibbonCaptionArea _captionArea;

	public ViewLayoutRibbonContextTitles(KryptonRibbon ribbon, ViewDrawRibbonCaptionArea captionArea)
	{
		Debug.Assert(captionArea != null);
		Debug.Assert(ribbon != null);
		_ribbon = ribbon;
		_captionArea = captionArea;
		_contextTitlesCache = new ViewDrawRibbonContextTitleList();
	}

	public override string ToString()
	{
		return "ViewLayoutRibbonContextTitles:" + base.Id;
	}

	protected override void Dispose(bool disposing)
	{
		if (disposing)
		{
			Clear();
			foreach (ViewDrawRibbonContextTitle item in _contextTitlesCache)
			{
				item.Dispose();
			}
			_contextTitlesCache.Clear();
		}
		base.Dispose(disposing);
	}

	public override Size GetPreferredSize(ViewLayoutContext context)
	{
		return Size.Empty;
	}

	public override void Layout(ViewLayoutContext context)
	{
		Debug.Assert(context != null);
		SyncChildrenToContexts();
		ClientRectangle = context.DisplayRectangle;
		ViewBase viewBase = null;
		using (IEnumerator<ViewBase> enumerator = GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				ViewBase current = enumerator.Current;
				if (GetDock(current) == ViewDockStyle.Fill)
				{
					viewBase = current;
					break;
				}
			}
		}
		int num = ClientRectangle.Right;
		int num2 = ClientRectangle.Left;
		using (IEnumerator<ViewBase> enumerator2 = GetEnumerator())
		{
			while (enumerator2.MoveNext())
			{
				ViewBase current2 = enumerator2.Current;
				if (current2.Visible && current2 is ViewDrawRibbonContextTitle)
				{
					ViewDrawRibbonContextTitle viewDrawRibbonContextTitle = current2 as ViewDrawRibbonContextTitle;
					ContextTabSet contextTabSet = viewDrawRibbonContextTitle.ContextTabSet;
					Point leftScreenPosition = contextTabSet.GetLeftScreenPosition();
					Point rightScreenPosition = contextTabSet.GetRightScreenPosition();
					if (_captionArea.UsingCustomChrome && !_captionArea.KryptonForm.ApplyComposition)
					{
						int left = _captionArea.RealWindowBorders.Left;
						leftScreenPosition.X += left;
						rightScreenPosition.X += left;
					}
					leftScreenPosition = context.TopControl.PointToClient(leftScreenPosition);
					rightScreenPosition = context.TopControl.PointToClient(rightScreenPosition);
					context.DisplayRectangle = new Rectangle(leftScreenPosition.X, ClientLocation.Y, rightScreenPosition.X - leftScreenPosition.X, ClientHeight);
					viewDrawRibbonContextTitle.Layout(context);
					num = Math.Min(num, leftScreenPosition.X);
					num2 = Math.Max(num2, rightScreenPosition.X);
				}
			}
		}
		if (viewBase != null)
		{
			int num3 = num - ClientRectangle.Left;
			int num4 = ClientRectangle.Right - num2;
			if (num3 >= num4)
			{
				context.DisplayRectangle = new Rectangle(ClientLocation.X, ClientLocation.Y, num3, ClientHeight);
			}
			else
			{
				context.DisplayRectangle = new Rectangle(num2, ClientLocation.Y, num4, ClientHeight);
			}
			viewBase.Layout(context);
		}
		context.DisplayRectangle = ClientRectangle;
	}

	public override void Render(RenderContext context)
	{
		Rectangle clientRectangle = ClientRectangle;
		clientRectangle.Height++;
		using (new Clipping(context.Graphics, clientRectangle))
		{
			base.Render(context);
		}
	}

	private void SyncChildrenToContexts()
	{
		ViewBase viewBase = null;
		using (IEnumerator<ViewBase> enumerator = GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				ViewBase current = enumerator.Current;
				if (GetDock(current) == ViewDockStyle.Fill)
				{
					viewBase = current;
					break;
				}
			}
		}
		Clear();
		if (_contextTitlesCache.Count < ViewLayoutRibbonTabs.ContextTabSets.Count)
		{
			for (int i = _contextTitlesCache.Count; i < ViewLayoutRibbonTabs.ContextTabSets.Count; i++)
			{
				ViewDrawRibbonContextTitle viewDrawRibbonContextTitle = new ViewDrawRibbonContextTitle(_ribbon, _ribbon.StateContextCheckedNormal.RibbonTab);
				viewDrawRibbonContextTitle.MouseController = new ContextTitleController(_ribbon);
				_contextTitlesCache.Add(viewDrawRibbonContextTitle);
			}
		}
		for (int j = 0; j < ViewLayoutRibbonTabs.ContextTabSets.Count; j++)
		{
			ViewDrawRibbonContextTitle viewDrawRibbonContextTitle2 = _contextTitlesCache[j];
			ContextTitleController contextTitleController = (ContextTitleController)viewDrawRibbonContextTitle2.MouseController;
			viewDrawRibbonContextTitle2.ContextTabSet = ViewLayoutRibbonTabs.ContextTabSets[j];
			contextTitleController.ContextTabSet = viewDrawRibbonContextTitle2.ContextTabSet;
			Add(viewDrawRibbonContextTitle2);
		}
		if (viewBase != null)
		{
			Add(viewBase, ViewDockStyle.Fill);
		}
	}

	private Color CheckForContextColor(PaletteState state)
	{
		if (_ribbon.SelectedTab != null && !string.IsNullOrEmpty(_ribbon.SelectedTab.ContextName))
		{
			KryptonRibbonContext kryptonRibbonContext = _ribbon.RibbonContexts[_ribbon.SelectedTab.ContextName];
			if (kryptonRibbonContext != null)
			{
				return kryptonRibbonContext.ContextColor;
			}
		}
		return Color.Empty;
	}
}
