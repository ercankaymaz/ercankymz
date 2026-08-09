using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using SourceGrid;

namespace QuadTreeLib;

public class QuadTreeNode
{
	[CompilerGenerated]
	private int int_0;

	[CompilerGenerated]
	private QuadTree quadTree_0;

	private Range bounds;

	private List<Range> list_0 = new List<Range>();

	private List<QuadTreeNode> list_1 = new List<QuadTreeNode>(4);

	public int Depth
	{
		[CompilerGenerated]
		get
		{
			return int_0;
		}
		[CompilerGenerated]
		set
		{
			int_0 = value;
		}
	}

	public QuadTree QuadTree
	{
		[CompilerGenerated]
		get
		{
			return quadTree_0;
		}
		[CompilerGenerated]
		set
		{
			quadTree_0 = value;
		}
	}

	public List<QuadTreeNode> Nodes => list_1;

	public bool IsEmpty => list_1.Count == 0 && list_0.Count == 0;

	public Range Bounds => bounds;

	public int MaxDepth
	{
		get
		{
			int num = Depth;
			foreach (QuadTreeNode item in list_1)
			{
				int maxDepth = item.MaxDepth;
				if (maxDepth > num)
				{
					num = maxDepth;
				}
			}
			return num;
		}
	}

	public int Count
	{
		get
		{
			int num = 0;
			foreach (QuadTreeNode item in list_1)
			{
				num += item.Count;
			}
			return num + Contents.Count;
		}
	}

	public List<Range> SubTreeContents
	{
		get
		{
			List<Range> list = new List<Range>();
			foreach (QuadTreeNode item in list_1)
			{
				list.AddRange(item.SubTreeContents);
			}
			list.AddRange(Contents);
			return list;
		}
	}

	public List<Range> Contents => list_0;

	public QuadTreeNode(Range bounds)
	{
		this.bounds = bounds;
	}

	public QuadTreeNode(Range bounds, int currentDepth, QuadTree quadTree)
		: this(bounds)
	{
		this.bounds = bounds;
		QuadTree = quadTree;
		Depth = currentDepth + 1;
	}

	public List<Range> Query(Range queryArea)
	{
		return QueryInternal(queryArea, stopOnFirst: false);
	}

	public Range? QueryFirst(Range queryArea)
	{
		List<Range> list = QueryInternal(queryArea, stopOnFirst: true);
		if (list.Count != 0)
		{
			return list[0];
		}
		return null;
	}

	public List<Range> QueryInternal(Range queryArea, bool stopOnFirst)
	{
		List<Range> list = new List<Range>();
		foreach (Range content in Contents)
		{
			if (queryArea.IntersectsWith(content))
			{
				list.Add(content);
				if (stopOnFirst)
				{
					return list;
				}
			}
		}
		foreach (QuadTreeNode item in list_1)
		{
			if (item.IsEmpty)
			{
				continue;
			}
			if (!item.Bounds.Contains(queryArea))
			{
				if (!queryArea.Contains(item.Bounds))
				{
					if (item.Bounds.IntersectsWith(queryArea))
					{
						list.AddRange(item.QueryInternal(queryArea, stopOnFirst));
					}
				}
				else
				{
					list.AddRange(item.SubTreeContents);
				}
				continue;
			}
			list.AddRange(item.QueryInternal(queryArea, stopOnFirst));
			break;
		}
		return list;
	}

	public List<Range> Query(Position queryArea)
	{
		List<Range> list = new List<Range>();
		foreach (Range content in Contents)
		{
			if (content.Contains(queryArea))
			{
				list.Add(content);
			}
		}
		foreach (QuadTreeNode item in list_1)
		{
			if (!item.IsEmpty && item.Bounds.Contains(queryArea))
			{
				list.AddRange(item.Query(queryArea));
				break;
			}
		}
		return list;
	}

	public Range? QueryFirst(Position queryArea)
	{
		foreach (Range content in Contents)
		{
			if (content.Contains(queryArea))
			{
				return content;
			}
		}
		foreach (QuadTreeNode item in list_1)
		{
			if (!item.IsEmpty && item.Bounds.Contains(queryArea))
			{
				return item.QueryFirst(queryArea);
			}
		}
		return null;
	}

	public bool Remove(Range range)
	{
		if (bounds.Contains(range))
		{
			foreach (QuadTreeNode item in list_1)
			{
				if (item.Bounds.Contains(range))
				{
					return item.Remove(range);
				}
			}
			for (int i = 0; i < Contents.Count; i++)
			{
				if (Contents[i].Equals(range))
				{
					Contents.RemoveAt(i);
					return true;
				}
			}
			return false;
		}
		throw new ArgumentException("range is out of the bounds of this quadtree node");
	}

	public void Insert(Range item)
	{
		if (bounds.Contains(item))
		{
			if (list_1.Count == 0)
			{
				QuadTree.QuadTreeNodeDivider.CreateSubNodes(this);
			}
			foreach (QuadTreeNode item2 in list_1)
			{
				if (item2.Bounds.Contains(item))
				{
					item2.Insert(item);
					return;
				}
			}
			Contents.Add(item);
			return;
		}
		throw new ArgumentException("range is out of the bounds of this quadtree node");
	}

	public void ForEach(QuadTree.QTAction action)
	{
		action(this);
		foreach (QuadTreeNode item in list_1)
		{
			item.ForEach(action);
		}
	}
}
