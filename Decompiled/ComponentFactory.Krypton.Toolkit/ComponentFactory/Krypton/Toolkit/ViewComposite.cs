#define DEBUG
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;

namespace ComponentFactory.Krypton.Toolkit;

public abstract class ViewComposite : ViewBase
{
	private List<ViewBase> _views;

	private bool _reverseRenderOrder;

	public bool ReverseRenderOrder
	{
		get
		{
			return _reverseRenderOrder;
		}
		set
		{
			_reverseRenderOrder = value;
		}
	}

	public override int Count
	{
		get
		{
			if (_views != null)
			{
				return _views.Count;
			}
			return 0;
		}
	}

	public override ViewBase this[int index]
	{
		get
		{
			if (_views != null)
			{
				return _views[index];
			}
			return null;
		}
		set
		{
			if (value == null)
			{
				throw new ArgumentNullException("Cannot set a null view into a composite view.");
			}
			if (_views != null)
			{
				ViewBase viewBase = _views[index];
				_views[index] = value;
				viewBase.Parent = null;
				value.Parent = this;
			}
		}
	}

	public override PaletteState FixedState
	{
		get
		{
			return base.FixedState;
		}
		set
		{
			base.FixedState = value;
			using IEnumerator<ViewBase> enumerator = GetEnumerator();
			while (enumerator.MoveNext())
			{
				ViewBase current = enumerator.Current;
				current.FixedState = value;
			}
		}
	}

	protected ViewComposite()
	{
		_views = new List<ViewBase>();
	}

	protected override void Dispose(bool disposing)
	{
		while (Count > 0)
		{
			this[0].Dispose();
			RemoveAt(0);
		}
		_views.Clear();
		base.Dispose(disposing);
	}

	public override string ToString()
	{
		return "ViewComposite:" + base.Id;
	}

	public override bool EvalTransparentPaint(ViewContext context)
	{
		Debug.Assert(context != null);
		using (IEnumerator<ViewBase> enumerator = GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				ViewBase current = enumerator.Current;
				if (current.Visible && current.EvalTransparentPaint(context))
				{
					return true;
				}
			}
		}
		return false;
	}

	public override Size GetPreferredSize(ViewLayoutContext context)
	{
		Debug.Assert(context != null);
		Size empty = Size.Empty;
		using (IEnumerator<ViewBase> enumerator = GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				ViewBase current = enumerator.Current;
				if (current.Visible)
				{
					Size preferredSize = current.GetPreferredSize(context);
					if (preferredSize.Width > empty.Width)
					{
						empty.Width = preferredSize.Width;
					}
					if (preferredSize.Height > empty.Height)
					{
						empty.Height = preferredSize.Height;
					}
				}
			}
		}
		return empty;
	}

	public override void Layout(ViewLayoutContext context)
	{
		Debug.Assert(context != null);
		using IEnumerator<ViewBase> enumerator = GetEnumerator();
		while (enumerator.MoveNext())
		{
			ViewBase current = enumerator.Current;
			if (current.Visible)
			{
				current.Layout(context);
			}
		}
	}

	public override void Render(RenderContext context)
	{
		Debug.Assert(context != null);
		RenderBefore(context);
		IEnumerable<ViewBase> enumerable = ((!ReverseRenderOrder) ? this : Reverse());
		foreach (ViewBase item in enumerable)
		{
			if (item.Visible && item.ClientRectangle.IntersectsWith(context.ClipRect))
			{
				item.Render(context);
			}
		}
		RenderAfter(context);
	}

	public override void Add(ViewBase item)
	{
		if (item == null)
		{
			throw new ArgumentNullException("Cannot add a null view into a composite view.");
		}
		if (_views != null)
		{
			_views.Add(item);
			item.Parent = this;
		}
	}

	public override void Clear()
	{
		if (_views == null)
		{
			return;
		}
		foreach (ViewBase view in _views)
		{
			view.Parent = null;
		}
		_views.Clear();
	}

	public override bool Contains(ViewBase item)
	{
		if (_views != null)
		{
			return _views.Contains(item);
		}
		return false;
	}

	public override bool ContainsRecurse(ViewBase item)
	{
		if (this == item)
		{
			return true;
		}
		using (IEnumerator<ViewBase> enumerator = GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				ViewBase current = enumerator.Current;
				if (current.ContainsRecurse(item))
				{
					return true;
				}
			}
		}
		return false;
	}

	public override void CopyTo(ViewBase[] array, int arrayIndex)
	{
		if (_views != null)
		{
			_views.CopyTo(array, arrayIndex);
		}
	}

	public override bool Remove(ViewBase item)
	{
		bool flag = _views != null && _views.Remove(item);
		if (flag)
		{
			item.Parent = null;
		}
		return flag;
	}

	public override int IndexOf(ViewBase item)
	{
		if (_views != null)
		{
			return _views.IndexOf(item);
		}
		return -1;
	}

	public override void Insert(int index, ViewBase item)
	{
		if (item == null)
		{
			throw new ArgumentNullException("Cannot insert a null view inside a composite view.");
		}
		if (_views != null)
		{
			_views.Insert(index, item);
			item.Parent = this;
		}
	}

	public override void RemoveAt(int index)
	{
		if (_views != null)
		{
			ViewBase viewBase = _views[index];
			_views.RemoveAt(index);
			viewBase.Parent = null;
		}
	}

	public override IEnumerator<ViewBase> GetEnumerator()
	{
		if (_views != null)
		{
			return _views.GetEnumerator();
		}
		return new List<ViewBase>().GetEnumerator();
	}

	public override IEnumerable<ViewBase> Recurse()
	{
		if (_views == null)
		{
			yield break;
		}
		foreach (ViewBase view in _views)
		{
			foreach (ViewBase item in view.Recurse())
			{
				yield return item;
			}
			yield return view;
		}
	}

	public override IEnumerable<ViewBase> Reverse()
	{
		if (_views != null)
		{
			for (int i = _views.Count - 1; i >= 0; i--)
			{
				yield return _views[i];
			}
		}
	}

	public override IEnumerable<ViewBase> ReverseRecurse()
	{
		if (_views == null)
		{
			yield break;
		}
		for (int i = _views.Count - 1; i >= 0; i--)
		{
			yield return _views[i];
			foreach (ViewBase item in _views[i].Recurse())
			{
				yield return item;
			}
		}
	}

	public override void ClearFixedState()
	{
		base.ClearFixedState();
		using IEnumerator<ViewBase> enumerator = GetEnumerator();
		while (enumerator.MoveNext())
		{
			ViewBase current = enumerator.Current;
			current.ClearFixedState();
		}
	}

	public override ViewBase ViewFromPoint(Point pt)
	{
		ViewBase viewBase = null;
		if (ClientRectangle.Contains(pt))
		{
			foreach (ViewBase item in Reverse())
			{
				if (item.Visible && item.ClientRectangle.Contains(pt))
				{
					viewBase = item.ViewFromPoint(pt);
					break;
				}
			}
			if (viewBase == null)
			{
				viewBase = this;
			}
		}
		return viewBase;
	}
}
