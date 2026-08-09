#define DEBUG
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;

namespace ComponentFactory.Krypton.Toolkit;

public abstract class ViewLeaf : ViewBase
{
	public override int Count => 0;

	public override ViewBase this[int index]
	{
		get
		{
			throw new ArgumentOutOfRangeException("index");
		}
		set
		{
			throw new ArgumentOutOfRangeException("index");
		}
	}

	public override string ToString()
	{
		return "ViewLeaf:" + base.Id;
	}

	public override bool EvalTransparentPaint(ViewContext context)
	{
		Debug.Assert(context != null);
		return false;
	}

	public override void Render(RenderContext context)
	{
		Debug.Assert(context != null);
		if (Visible)
		{
			RenderBefore(context);
			RenderAfter(context);
		}
	}

	public override void Add(ViewBase item)
	{
		throw new NotSupportedException("Cannot add to a leaf view.");
	}

	public override void Clear()
	{
	}

	public override bool Contains(ViewBase item)
	{
		return false;
	}

	public override bool ContainsRecurse(ViewBase item)
	{
		return this == item;
	}

	public override void CopyTo(ViewBase[] array, int arrayIndex)
	{
	}

	public override bool Remove(ViewBase item)
	{
		return false;
	}

	public override int IndexOf(ViewBase item)
	{
		return -1;
	}

	public override void Insert(int index, ViewBase item)
	{
		throw new NotSupportedException("Cannot insert to a leaf view.");
	}

	public override void RemoveAt(int index)
	{
		throw new NotSupportedException("Cannot remove a view from a leaf view.");
	}

	public override IEnumerator<ViewBase> GetEnumerator()
	{
		yield break;
	}

	public override IEnumerable<ViewBase> Recurse()
	{
		yield break;
	}

	public override IEnumerable<ViewBase> Reverse()
	{
		yield break;
	}

	public override IEnumerable<ViewBase> ReverseRecurse()
	{
		yield break;
	}

	public override ViewBase ViewFromPoint(Point pt)
	{
		if (ClientRectangle.Contains(pt))
		{
			return this;
		}
		return null;
	}
}
