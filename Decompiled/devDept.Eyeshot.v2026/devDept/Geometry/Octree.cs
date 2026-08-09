using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using devDept.Eyeshot.Entities;

namespace devDept.Geometry;

public class Octree : QuadTree
{
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private readonly bool[] _0023_003DzVrkp33jNF0awh3aKLfSaQDo_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private int _0023_003DzCEJ_kXFgkysXC4Wmjw_003D_003D;

	public new Octant Root => (Octant)_root;

	public Octree(Mesh mesh)
		: base(mesh)
	{
		_0023_003DzA66kyog1BniW = mesh.Triangles.Length;
		_0023_003Dzvlg4h6lbB1d2GimClA_003D_003D = 1 + _0023_003DzA66kyog1BniW / 100;
		_root = new Octant(mesh.BoxMin, mesh.BoxMax, this);
		_0023_003DzVrkp33jNF0awh3aKLfSaQDo_003D = new bool[_0023_003DzA66kyog1BniW];
		_elementsToAnalyze = new HashSet<int>(mesh.Triangles.Length);
		for (int i = 0; i < mesh.Triangles.Length; i++)
		{
			_elementsToAnalyze.Add(i);
		}
	}

	protected internal Octree()
	{
	}

	protected internal Octree(Octree other)
		: base(other)
	{
		if (other != null)
		{
			_0023_003DzVrkp33jNF0awh3aKLfSaQDo_003D = other._0023_003DzVrkp33jNF0awh3aKLfSaQDo_003D;
		}
	}

	public Octree(Mesh mesh, int limit)
		: this(mesh)
	{
		if (limit > 0)
		{
			_0023_003Dzvlg4h6lbB1d2GimClA_003D_003D = limit;
		}
	}

	public override void DoWork(IProgress<ProgressChangedEventArgs> progress, CancellationToken ct)
	{
		int trCount = 0;
		SpatialSubdivision(_root, _elementsToAnalyze, _0023_003Dzvlg4h6lbB1d2GimClA_003D_003D, ref trCount, progress);
		_0023_003Dz1IyDI8QE6T3n((Octant)_root, progress);
		for (int i = 0; i < _0023_003DzVrkp33jNF0awh3aKLfSaQDo_003D.Length; i++)
		{
			if (!_0023_003DzVrkp33jNF0awh3aKLfSaQDo_003D[i])
			{
				_root._0023_003DzVEHDNk4QG1L8.Add(i);
				_0023_003DzVrkp33jNF0awh3aKLfSaQDo_003D[i] = true;
			}
		}
	}

	public void FindClosestTriangle(Segment3D seg, Transformation transf, SortedList<double, HitTriangle> triList)
	{
		Segment3D _0023_003DzJ_0024N5unzMWdRB = seg;
		if (transf != null && !transf.IsIdentity())
		{
			Transformation transformation = (Transformation)transf.Clone();
			transformation.Invert();
			Point3D obj = (Point3D)seg.P0.Clone();
			obj.TransformBy(transformation);
			Point3D point3D = (Point3D)seg.P1.Clone();
			point3D.TransformBy(transformation);
			_0023_003DzJ_0024N5unzMWdRB = new Segment3D(obj, point3D);
		}
		_0023_003Dznc5LTlcIo2t9((Octant)_root, _0023_003DzJ_0024N5unzMWdRB, transf, triList, null, null);
	}

	private void _0023_003Dznc5LTlcIo2t9(Octant _0023_003Dzalvl9z8_003D, Segment3D _0023_003DzJ_0024N5unzMWdRB, Transformation _0023_003Dz9ZUzIX4xmsyA, SortedList<double, HitTriangle> _0023_003DzJMMhfoqq1zLk, int[] _0023_003DzMeLY8V4_003D, Vector3D _0023_003DzPcya_pvCQE38)
	{
		bool flag = _0023_003Dz9ZUzIX4xmsyA != null && !_0023_003Dz9ZUzIX4xmsyA.IsIdentity();
		if (_0023_003DzPcya_pvCQE38 == null || _0023_003DzPcya_pvCQE38.IsZero)
		{
			Vector3D vector3D = new Vector3D(_0023_003DzJ_0024N5unzMWdRB.P0, _0023_003DzJ_0024N5unzMWdRB.P1);
			_0023_003DzPcya_pvCQE38 = new Vector3D(1.0 / vector3D.X, 1.0 / vector3D.Y, 1.0 / vector3D.Z);
		}
		if (_0023_003DzMeLY8V4_003D == null)
		{
			_0023_003DzMeLY8V4_003D = new int[3]
			{
				(_0023_003DzPcya_pvCQE38.X < 0.0) ? 1 : 0,
				(_0023_003DzPcya_pvCQE38.Y < 0.0) ? 1 : 0,
				(_0023_003DzPcya_pvCQE38.Z < 0.0) ? 1 : 0
			};
		}
		_0023_003Dzalvl9z8_003D.GetBoudingBox(out var boxMin, out var boxMax);
		if (_0023_003DzJ_0024N5unzMWdRB.IntersectWithInternal(_0023_003DzMeLY8V4_003D, (Point3D)boxMin, (Point3D)boxMax, _0023_003DzPcya_pvCQE38, 0.0, double.PositiveInfinity))
		{
			foreach (int item in _0023_003Dzalvl9z8_003D._0023_003DzVEHDNk4QG1L8)
			{
				Mesh mesh = (Mesh)_0023_003DzHzDfhpY_003D;
				IndexTriangle[] triangles = mesh.Triangles;
				if (_0023_003DzJ_0024N5unzMWdRB.IntersectWith(mesh.Vertices[triangles[item].V1], mesh.Vertices[triangles[item].V2], mesh.Vertices[triangles[item].V3], out var intPoint))
				{
					double key = Point3D.Distance(intPoint, _0023_003DzJ_0024N5unzMWdRB.P0);
					if (flag)
					{
						intPoint.TransformBy(_0023_003Dz9ZUzIX4xmsyA);
					}
					_0023_003DzJMMhfoqq1zLk[key] = new HitTriangle(intPoint, item, 0, -1);
				}
			}
		}
		if (!_0023_003Dzalvl9z8_003D.HasChildren)
		{
			return;
		}
		QuadEntityDataNode[] children = _0023_003Dzalvl9z8_003D.children;
		for (int i = 0; i < children.Length; i++)
		{
			Octant octant = (Octant)children[i];
			if ((octant._0023_003DzVEHDNk4QG1L8 != null && octant._0023_003DzVEHDNk4QG1L8.Count > 0) || octant.HasChildren)
			{
				_0023_003Dznc5LTlcIo2t9(octant, _0023_003DzJ_0024N5unzMWdRB, _0023_003Dz9ZUzIX4xmsyA, _0023_003DzJMMhfoqq1zLk, _0023_003DzMeLY8V4_003D, _0023_003DzPcya_pvCQE38);
			}
		}
	}

	private HashSet<int> _0023_003DzAE0uDyL_yjaW(Octant _0023_003Dzalvl9z8_003D)
	{
		HashSet<int> hashSet = new HashSet<int>();
		if (_0023_003Dzalvl9z8_003D.HasChildren)
		{
			QuadEntityDataNode[] children = _0023_003Dzalvl9z8_003D.children;
			for (int i = 0; i < children.Length; i++)
			{
				Octant octant = (Octant)children[i];
				hashSet.UnionWith(octant._0023_003DzVEHDNk4QG1L8);
			}
		}
		return hashSet;
	}

	private void _0023_003Dz1IyDI8QE6T3n(Octant _0023_003Dzalvl9z8_003D, IProgress<ProgressChangedEventArgs> _0023_003DzmHS7frs_003D)
	{
		HashSet<int> other = _0023_003DzAE0uDyL_yjaW(_0023_003Dzalvl9z8_003D);
		_0023_003Dzalvl9z8_003D._0023_003DzVEHDNk4QG1L8.ExceptWith(other);
		_0023_003DzCEJ_kXFgkysXC4Wmjw_003D_003D++;
		UpdateProgress(_0023_003DzCEJ_kXFgkysXC4Wmjw_003D_003D, _0023_003Dzb8IXw0k2JoqtsBIQ0Q_003D_003D, _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302658599), _0023_003DzmHS7frs_003D);
		if (_0023_003Dzalvl9z8_003D.HasChildren)
		{
			QuadEntityDataNode[] children = _0023_003Dzalvl9z8_003D.children;
			for (int i = 0; i < children.Length; i++)
			{
				Octant _0023_003Dzalvl9z8_003D2 = (Octant)children[i];
				_0023_003Dz1IyDI8QE6T3n(_0023_003Dzalvl9z8_003D2, _0023_003DzmHS7frs_003D);
			}
		}
	}

	protected override void SpatialSubdivision(QuadEntityDataNode parent, HashSet<int> indexOfTriangles, int maxTriCount, ref int trCount, IProgress<ProgressChangedEventArgs> progress)
	{
		_0023_003Dzb8IXw0k2JoqtsBIQ0Q_003D_003D += 8;
		((Octant)parent).createChildren();
		foreach (int indexOfTriangle in indexOfTriangles)
		{
			QuadEntityDataNode[] children = parent.children;
			for (int i = 0; i < children.Length; i++)
			{
				Octant octant = (Octant)children[i];
				if (!_0023_003DzVrkp33jNF0awh3aKLfSaQDo_003D[indexOfTriangle] && octant.IsElemInsideNode(indexOfTriangle))
				{
					octant._0023_003DzVEHDNk4QG1L8.Add(indexOfTriangle);
					_0023_003DzVrkp33jNF0awh3aKLfSaQDo_003D[indexOfTriangle] = true;
					break;
				}
			}
		}
		for (int j = 0; j < 8; j++)
		{
			if (parent.children[j]._0023_003DzVEHDNk4QG1L8.Count > maxTriCount)
			{
				foreach (int item in parent.children[j]._0023_003DzVEHDNk4QG1L8)
				{
					_0023_003DzVrkp33jNF0awh3aKLfSaQDo_003D[item] = false;
				}
				SpatialSubdivision(parent.children[j], parent.children[j]._0023_003DzVEHDNk4QG1L8, maxTriCount, ref trCount, progress);
				foreach (int item2 in parent.children[j]._0023_003DzVEHDNk4QG1L8)
				{
					_0023_003DzVrkp33jNF0awh3aKLfSaQDo_003D[item2] = true;
				}
			}
			else if (parent.children[j]._0023_003DzVEHDNk4QG1L8.Count != 0)
			{
				trCount += parent.children[j]._0023_003DzVEHDNk4QG1L8.Count;
				UpdateProgress(trCount, _0023_003DzA66kyog1BniW, _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302658566), progress);
			}
		}
	}
}
