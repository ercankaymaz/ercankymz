using System.Collections.Generic;
using System.Runtime.CompilerServices;
using ns54;

namespace buCore.buClipperLib;

public class PolyNode
{
	internal PolyNode polyNode_0;

	internal List<IntPoint> list_0 = new List<IntPoint>();

	internal int int_0;

	internal JoinType joinType_0;

	internal EndType endType_0;

	internal List<PolyNode> list_1 = new List<PolyNode>();

	[CompilerGenerated]
	private bool bool_0;

	public int ChildCount => list_1.Count;

	public List<IntPoint> Contour => list_0;

	public List<PolyNode> Childs => list_1;

	public PolyNode Parent => polyNode_0;

	public bool IsHole => Class156.smethod_4(this);

	public bool IsOpen
	{
		[CompilerGenerated]
		get
		{
			return bool_0;
		}
		[CompilerGenerated]
		set
		{
			bool_0 = value;
		}
	}

	public PolyNode GetNext()
	{
		if (list_1.Count <= 0)
		{
			return Class156.smethod_77(this);
		}
		return list_1[0];
	}
}
