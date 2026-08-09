#define DEBUG
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using ComponentFactory.Krypton.Toolkit;

namespace ComponentFactory.Krypton.Ribbon;

internal class ViewLayoutRibbonRowCenter : ViewComposite
{
	private class ItemToView : Dictionary<IRibbonGroupItem, ViewBase>
	{
	}

	private class ViewToSize : Dictionary<ViewBase, Size>
	{
	}

	private GroupItemSize _currentSize;

	private ViewToSize _viewToSmall;

	private ViewToSize _viewToMedium;

	private ViewToSize _viewToLarge;

	private Size _preferredSizeSmall;

	private Size _preferredSizeMedium;

	private Size _preferredSizeLarge;

	public GroupItemSize CurrentSize
	{
		get
		{
			return _currentSize;
		}
		set
		{
			_currentSize = value;
		}
	}

	public ViewLayoutRibbonRowCenter()
	{
		_currentSize = GroupItemSize.Large;
		_viewToSmall = new ViewToSize();
		_viewToMedium = new ViewToSize();
		_viewToLarge = new ViewToSize();
	}

	public override string ToString()
	{
		return "ViewLayoutRibbonRowCenter:" + base.Id;
	}

	public override Size GetPreferredSize(ViewLayoutContext context)
	{
		Debug.Assert(context != null);
		switch (_currentSize)
		{
		case GroupItemSize.Small:
			_viewToSmall.Clear();
			break;
		case GroupItemSize.Medium:
			_viewToMedium.Clear();
			break;
		case GroupItemSize.Large:
			_viewToLarge.Clear();
			break;
		default:
			Debug.Assert(condition: false);
			break;
		}
		Size empty = Size.Empty;
		using (IEnumerator<ViewBase> enumerator = GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				ViewBase current = enumerator.Current;
				if (current.Visible)
				{
					Size preferredSize = current.GetPreferredSize(context);
					switch (_currentSize)
					{
					case GroupItemSize.Small:
						_viewToSmall.Add(current, preferredSize);
						break;
					case GroupItemSize.Medium:
						_viewToMedium.Add(current, preferredSize);
						break;
					case GroupItemSize.Large:
						_viewToLarge.Add(current, preferredSize);
						break;
					}
					empty.Width += preferredSize.Width;
					empty.Height = Math.Max(empty.Height, preferredSize.Height);
				}
			}
		}
		switch (_currentSize)
		{
		case GroupItemSize.Small:
			_preferredSizeSmall = empty;
			break;
		case GroupItemSize.Medium:
			_preferredSizeMedium = empty;
			break;
		case GroupItemSize.Large:
			_preferredSizeLarge = empty;
			break;
		}
		return empty;
	}

	public override void Layout(ViewLayoutContext context)
	{
		Debug.Assert(context != null);
		if (context == null)
		{
			throw new ArgumentNullException("context");
		}
		ClientRectangle = context.DisplayRectangle;
		Size size = Size.Empty;
		switch (_currentSize)
		{
		case GroupItemSize.Small:
			size = _preferredSizeSmall;
			break;
		case GroupItemSize.Medium:
			size = _preferredSizeMedium;
			break;
		case GroupItemSize.Large:
			size = _preferredSizeLarge;
			break;
		}
		int num = (ClientWidth - size.Width) / 2;
		using (IEnumerator<ViewBase> enumerator = GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				ViewBase current = enumerator.Current;
				if (current.Visible)
				{
					Size size2 = Size.Empty;
					switch (_currentSize)
					{
					case GroupItemSize.Small:
						size2 = ((!_viewToSmall.ContainsKey(current)) ? current.GetPreferredSize(context) : _viewToSmall[current]);
						break;
					case GroupItemSize.Medium:
						size2 = ((!_viewToMedium.ContainsKey(current)) ? current.GetPreferredSize(context) : _viewToMedium[current]);
						break;
					case GroupItemSize.Large:
						size2 = ((!_viewToLarge.ContainsKey(current)) ? current.GetPreferredSize(context) : _viewToLarge[current]);
						break;
					}
					int num2 = (ClientHeight - size2.Height) / 2;
					context.DisplayRectangle = new Rectangle(ClientRectangle.X + num, ClientRectangle.Y + num2, size2.Width, size2.Height);
					current.Layout(context);
					num += size2.Width;
				}
			}
		}
		context.DisplayRectangle = ClientRectangle;
	}
}
