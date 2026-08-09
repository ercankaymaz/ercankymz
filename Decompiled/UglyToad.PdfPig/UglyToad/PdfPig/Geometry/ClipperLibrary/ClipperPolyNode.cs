using System.Collections.Generic;

namespace UglyToad.PdfPig.Geometry.ClipperLibrary;

internal class ClipperPolyNode
{
	internal List<ClipperIntPoint> Polygon = new List<ClipperIntPoint>();

	internal int Index;

	internal ClipperJoinType JoinType;

	internal ClipperEndType EndType;

	internal List<ClipperPolyNode> Children = new List<ClipperPolyNode>();

	public ClipperPolyNode Parent { get; set; }

	public bool IsHole => IsHoleNode();

	public bool IsOpen { get; set; }

	public int ChildCount => Children.Count;

	public List<ClipperIntPoint> Contour => Polygon;

	private bool IsHoleNode()
	{
		bool flag = true;
		for (ClipperPolyNode parent = Parent; parent != null; parent = parent.Parent)
		{
			flag = !flag;
		}
		return flag;
	}

	internal void AddChild(ClipperPolyNode child)
	{
		int count = Children.Count;
		Children.Add(child);
		child.Parent = this;
		child.Index = count;
	}

	public ClipperPolyNode GetNext()
	{
		if (Children.Count > 0)
		{
			return Children[0];
		}
		return GetNextSiblingUp();
	}

	internal ClipperPolyNode GetNextSiblingUp()
	{
		if (Parent == null)
		{
			return null;
		}
		if (Index == Parent.Children.Count - 1)
		{
			return Parent.GetNextSiblingUp();
		}
		return Parent.Children[Index + 1];
	}
}
