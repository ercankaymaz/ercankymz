using System.Collections.Generic;
using System.Runtime.CompilerServices;
using SourceGrid;

namespace QuadTreeLib;

public class QuadTree
{
	public delegate void QTAction(QuadTreeNode obj);

	private QuadTreeNode quadTreeNode_0;

	private Range rectangle;

	[CompilerGenerated]
	private IQuadTreeNodeDivider iquadTreeNodeDivider_0;

	public IQuadTreeNodeDivider QuadTreeNodeDivider
	{
		[CompilerGenerated]
		get
		{
			return iquadTreeNodeDivider_0;
		}
		[CompilerGenerated]
		set
		{
			iquadTreeNodeDivider_0 = value;
		}
	}

	public Range Bounds => rectangle;

	public QuadTreeNode Root => quadTreeNode_0;

	public List<Range> Contents => Query(Bounds);

	public int Count => quadTreeNode_0.Count;

	public int MaxDepth => quadTreeNode_0.MaxDepth;

	public void Grow()
	{
		quadTreeNode_0 = QuadTreeNodeDivider.CreateNewRoot(quadTreeNode_0);
		rectangle = quadTreeNode_0.Bounds;
	}

	public QuadTree(int rows, int columns)
		: this(new Range(1, 1, rows, columns))
	{
	}

	public QuadTree(Range rectangle)
	{
		this.rectangle = rectangle;
		quadTreeNode_0 = new QuadTreeNode(this.rectangle, 0, this);
		QuadTreeNodeDivider = new ProportioanteSizeNodeDivider();
	}

	public QuadTree Insert(Range item)
	{
		quadTreeNode_0.Insert(item);
		return this;
	}

	public QuadTree Remove(Range range)
	{
		quadTreeNode_0.Remove(range);
		return this;
	}

	public QuadTree Insert(IEnumerable<Range> items)
	{
		foreach (Range item in items)
		{
			quadTreeNode_0.Insert(item);
		}
		return this;
	}

	public List<Range> Query(Range area)
	{
		return quadTreeNode_0.Query(area);
	}

	public List<Range> Query(Position area)
	{
		return quadTreeNode_0.Query(area);
	}

	public Range? QueryFirst(Position area)
	{
		return quadTreeNode_0.QueryFirst(area);
	}

	public Range? QueryFirst(Range area)
	{
		return quadTreeNode_0.QueryFirst(area);
	}

	public void ForEach(QTAction action)
	{
		quadTreeNode_0.ForEach(action);
	}
}
