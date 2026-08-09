using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using devDept.Eyeshot;
using devDept.Eyeshot.Entities;

namespace devDept.Geometry;

public class QuadTree : WorkUnit
{
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	internal int _0023_003Dzvlg4h6lbB1d2GimClA_003D_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	internal int _0023_003DzA66kyog1BniW;

	protected HashSet<int> _elementsToAnalyze;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	internal readonly Entity _0023_003DzHzDfhpY_003D;

	protected QuadEntityDataNode _root;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	internal int _0023_003Dzb8IXw0k2JoqtsBIQ0Q_003D_003D;

	public Entity OriginalDataSource => _0023_003DzHzDfhpY_003D;

	public QuadEntityDataNode Root => _root;

	public QuadTree(Entity entity, double chordalError = 0.0)
	{
		bool flag = entity is IFace;
		if (entity is Mesh || entity is LinearPath)
		{
			_0023_003DzHzDfhpY_003D = entity;
		}
		else
		{
			if (chordalError == 0.0 && !(entity is Solid))
			{
				throw new EyeshotException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302659843));
			}
			if (flag)
			{
				RegenParams data = new RegenParams(chordalError);
				entity.Regen(data);
				_0023_003DzHzDfhpY_003D = Mesh._0023_003Dz_0024QJlr0pItQh7PH05vQ_003D_003D(((IFace)entity).GetTessellation(), Mesh.natureType.Plain, _0023_003DzgM38qBg_003D: false);
			}
			else
			{
				entity.Regen(chordalError);
				_0023_003DzHzDfhpY_003D = new LinearPath(entity.Vertices);
			}
		}
		_0023_003DzA66kyog1BniW = (flag ? ((Mesh)_0023_003DzHzDfhpY_003D).Triangles.Length : ((LinearPath)_0023_003DzHzDfhpY_003D).Vertices.Length);
		_0023_003Dzvlg4h6lbB1d2GimClA_003D_003D = 1 + _0023_003DzA66kyog1BniW / 100;
		_root = new QuadEntityDataNode(entity.BoxMin, entity.BoxMax, this);
		int num = (flag ? _0023_003DzA66kyog1BniW : (_0023_003DzA66kyog1BniW - 1));
		_elementsToAnalyze = new HashSet<int>(num);
		for (int i = 0; i < num; i++)
		{
			_elementsToAnalyze.Add(i);
		}
	}

	protected internal QuadTree()
	{
	}

	protected internal QuadTree(QuadTree other)
	{
		if (other != null)
		{
			_0023_003Dzvlg4h6lbB1d2GimClA_003D_003D = other._0023_003Dzvlg4h6lbB1d2GimClA_003D_003D;
			_0023_003Dzb8IXw0k2JoqtsBIQ0Q_003D_003D = other._0023_003Dzb8IXw0k2JoqtsBIQ0Q_003D_003D;
			_root = other._root;
			_0023_003DzHzDfhpY_003D = other._0023_003DzHzDfhpY_003D;
			_0023_003DzA66kyog1BniW = other._0023_003DzA66kyog1BniW;
			_elementsToAnalyze = other._elementsToAnalyze;
		}
	}

	public QuadTree(Entity Entity, int limit)
		: this(Entity)
	{
		_0023_003Dzvlg4h6lbB1d2GimClA_003D_003D = limit;
	}

	public override void DoWork(IProgress<ProgressChangedEventArgs> progress, CancellationToken ct)
	{
		int trCount = 0;
		SpatialSubdivision(_root, _elementsToAnalyze, _0023_003Dzvlg4h6lbB1d2GimClA_003D_003D, ref trCount, progress);
	}

	protected virtual void SpatialSubdivision(QuadEntityDataNode parent, HashSet<int> indexOfElements, int maxTriCount, ref int trCount, IProgress<ProgressChangedEventArgs> progress)
	{
		_0023_003Dzb8IXw0k2JoqtsBIQ0Q_003D_003D += 4;
		parent.GetBoudingBox(out var _, out var _);
		parent.createChildren();
		parent._0023_003Dz4r7WGxYJAX7JWBwXtA_003D_003D(indexOfElements.ToList(), this, progress);
		if (parent._0023_003DzVEHDNk4QG1L8.Count == indexOfElements.Count)
		{
			parent._0023_003DztyoAaSif4k7X();
		}
	}
}
