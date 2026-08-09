using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using devDept.Eyeshot.Entities;

namespace devDept.Geometry;

public class QuadEntityDataNode : NodeBase
{
	protected internal QuadTree root;

	protected internal QuadEntityDataNode[] children;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	internal HashSet<int> _0023_003DzVEHDNk4QG1L8;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private bool? _0023_003DzcoAcV2dT2LmQ;

	public QuadTree TreeSource => root;

	public QuadEntityDataNode[] Children => children;

	public int[] ElementsIndices => _0023_003DzVEHDNk4QG1L8.ToArray();

	public bool HasChildren
	{
		get
		{
			if (!_0023_003DzcoAcV2dT2LmQ.HasValue)
			{
				_0023_003DzcoAcV2dT2LmQ = children != null && children.Length != 0;
			}
			return _0023_003DzcoAcV2dT2LmQ.Value;
		}
	}

	public QuadEntityDataNode(Point2D min, Point2D max, QuadTree root)
		: base(min, max)
	{
		_0023_003DzVEHDNk4QG1L8 = new HashSet<int>();
		children = null;
		this.root = root;
	}

	public QuadEntityDataNode(Point2D min, Point2D max, QuadTree root, IList<int> indicesElements)
		: this(min, max, root)
	{
		_0023_003DzVEHDNk4QG1L8 = ((indicesElements == null) ? new HashSet<int>() : new HashSet<int>(indicesElements));
	}

	public QuadEntityDataNode(Point2D min, Point2D max, QuadTree root, int elementsCount)
		: this(min, max, root)
	{
		_0023_003DzVEHDNk4QG1L8 = new HashSet<int>();
		for (int i = 0; i < elementsCount; i++)
		{
			_0023_003DzVEHDNk4QG1L8.Add(i);
		}
	}

	protected internal virtual void createChildren()
	{
		children = new QuadEntityDataNode[4];
		Point2D point2D = (localMax - localMin) / 2.0;
		children[0] = new QuadEntityDataNode(localMin + point2D, localMax, root);
		children[1] = new QuadEntityDataNode(new Point2D(localMin.X, localMin.Y + point2D.Y), new Point2D(localMin.X + point2D.X, localMax.Y), root);
		children[2] = new QuadEntityDataNode(localMin, localMin + point2D, root);
		children[3] = new QuadEntityDataNode(new Point2D(localMin.X + point2D.X, localMin.Y), new Point2D(localMax.X, localMin.Y + point2D.Y), root);
		_0023_003DzcoAcV2dT2LmQ = true;
	}

	internal virtual void _0023_003DztyoAaSif4k7X()
	{
		children = null;
		_0023_003DzcoAcV2dT2LmQ = false;
	}

	internal void _0023_003DzldfomBPL1GS2(IList<int> _0023_003DzbLpRrBKdO_mb)
	{
		if (_0023_003DzVEHDNk4QG1L8 == null)
		{
			_0023_003DzVEHDNk4QG1L8 = new HashSet<int>(_0023_003DzbLpRrBKdO_mb);
			return;
		}
		for (int i = 0; i < _0023_003DzbLpRrBKdO_mb.Count; i++)
		{
			_0023_003DzVEHDNk4QG1L8.Add(_0023_003DzbLpRrBKdO_mb[i]);
		}
	}

	protected internal virtual bool IsElemInsideNode(int elemIndex)
	{
		Point2D[] array = new Point2D[0];
		Entity _0023_003DzHzDfhpY_003D = root._0023_003DzHzDfhpY_003D;
		if (_0023_003DzHzDfhpY_003D is Mesh)
		{
			Mesh mesh = (Mesh)_0023_003DzHzDfhpY_003D;
			array = new Point2D[3]
			{
				mesh.Vertices[mesh.Triangles[elemIndex].V1],
				mesh.Vertices[mesh.Triangles[elemIndex].V2],
				mesh.Vertices[mesh.Triangles[elemIndex].V3]
			};
		}
		else if (_0023_003DzHzDfhpY_003D is LinearPath linearPath)
		{
			array = new Point2D[2]
			{
				linearPath.Vertices[elemIndex],
				linearPath.Vertices[(elemIndex + 1) % linearPath.Vertices.Length]
			};
		}
		for (int i = 0; i < array.Length; i++)
		{
			if (!Utility.IsPointInsideOrOntoBBox2D(array[i], localMin, localMax))
			{
				return false;
			}
		}
		return true;
	}

	internal virtual List<int> _0023_003Dz4r7WGxYJAX7JWBwXtA_003D_003D(IList<int> _0023_003Dz3WY1M_0024IcItOL, WorkUnit _0023_003DziQzrFitgMY0spryRGA_003D_003D, IProgress<WorkUnit.ProgressChangedEventArgs> _0023_003DzmHS7frs_003D)
	{
		List<int> list = new List<int>(_0023_003Dz3WY1M_0024IcItOL.Count);
		List<int> list2 = new List<int>(_0023_003Dz3WY1M_0024IcItOL.Count);
		for (int i = 0; i < _0023_003Dz3WY1M_0024IcItOL.Count; i++)
		{
			if (IsElemInsideNode(_0023_003Dz3WY1M_0024IcItOL[i]))
			{
				list2.Add(_0023_003Dz3WY1M_0024IcItOL[i]);
			}
			else
			{
				list.Add(_0023_003Dz3WY1M_0024IcItOL[i]);
			}
		}
		int count = list2.Count;
		if (count > 0)
		{
			if (count > root._0023_003Dzvlg4h6lbB1d2GimClA_003D_003D)
			{
				if (children == null || children.Length == 0)
				{
					createChildren();
				}
				for (int j = 0; j < children.Length; j++)
				{
					list2 = children[j]._0023_003Dz4r7WGxYJAX7JWBwXtA_003D_003D(list2, _0023_003DziQzrFitgMY0spryRGA_003D_003D, _0023_003DzmHS7frs_003D);
				}
				if (list2.Count == count)
				{
					_0023_003DztyoAaSif4k7X();
				}
			}
			if (list2.Count > 0)
			{
				_0023_003DzldfomBPL1GS2(list2);
			}
			_0023_003DziQzrFitgMY0spryRGA_003D_003D.UpdateProgress(count, root._0023_003DzA66kyog1BniW, _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302659879), _0023_003DzmHS7frs_003D);
		}
		return list;
	}
}
