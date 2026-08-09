using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Threading;
using devDept.Eyeshot.Entities;
using devDept.Eyeshot.Fem;
using devDept.Geometry;

namespace devDept.Eyeshot.Meshing;

public class SurfaceMesher : Mesher, ICurveMesherCreator
{
	internal sealed class _0023_003Dz17deN5RpyVgyaMlfHQ_003D_003D : IndexLine
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public DelaunayTriangle _0023_003DzwTeMRYA_003D;

		public _0023_003Dz17deN5RpyVgyaMlfHQ_003D_003D(int _0023_003DzffqPLNQ_003D, int _0023_003Dz5Azd7L8_003D, DelaunayTriangle _0023_003DzwTeMRYA_003D)
			: base(_0023_003DzffqPLNQ_003D, _0023_003Dz5Azd7L8_003D)
		{
			this._0023_003DzwTeMRYA_003D = _0023_003DzwTeMRYA_003D;
		}

		public override string ToString()
		{
			return string.Format(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302990903), base.ToString(), _0023_003DzwTeMRYA_003D.ToString());
		}
	}

	[Serializable]
	private sealed class _0023_003Dz2IEmqow_003D
	{
		public static readonly _0023_003Dz2IEmqow_003D _0023_003DzJ5g3Rwo_003D = new _0023_003Dz2IEmqow_003D();

		public static Func<_0023_003DzaNdK2SNh78xbyVoyjA_003D_003D, Point3D> _0023_003Dzlm2lrQMxP9Z4cmGPiw_003D_003D;

		internal Point3D _0023_003DzJAj1rOHWIfSovQBLCqHgCZBR0fx9ur5fjA_003D_003D(_0023_003DzaNdK2SNh78xbyVoyjA_003D_003D _0023_003DzB68dg9Q_003D)
		{
			return (Point3D)_0023_003DzB68dg9Q_003D._0023_003DzIHt45I8_003D;
		}
	}

	private enum _0023_003DzNMAnai2Cws9l
	{

	}

	internal sealed class _0023_003DzaNdK2SNh78xbyVoyjA_003D_003D : _0023_003DzRV5GhlIkprjwXRkNGMknXBOYrewR09oqf_lNIvRxwZpVBQ6mcQ_003D_003D
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public LinkedListNode<DelaunayTriangle> _0023_003DzDCjBZK4_003D;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public double _0023_003DzOxKU6GM_003D;

		public _0023_003DzaNdK2SNh78xbyVoyjA_003D_003D(Point2D _0023_003DzMlCq3wk_003D)
			: base(_0023_003DzMlCq3wk_003D)
		{
		}

		public _0023_003DzaNdK2SNh78xbyVoyjA_003D_003D(int _0023_003DzyzK8swU_003D, Point2D _0023_003DzMlCq3wk_003D)
			: base(_0023_003DzyzK8swU_003D, _0023_003DzMlCq3wk_003D)
		{
		}

		public _0023_003DzaNdK2SNh78xbyVoyjA_003D_003D(int _0023_003DzyzK8swU_003D, Point2D _0023_003DzMlCq3wk_003D, long _0023_003Dz1rZ3w2I_003D, long _0023_003DzNGFpltQ_003D)
			: base(_0023_003DzyzK8swU_003D, _0023_003DzMlCq3wk_003D, _0023_003Dz1rZ3w2I_003D, _0023_003DzNGFpltQ_003D)
		{
		}

		public _0023_003DzaNdK2SNh78xbyVoyjA_003D_003D(int _0023_003DzyzK8swU_003D, long _0023_003Dz1rZ3w2I_003D, long _0023_003DzNGFpltQ_003D, IntegerGrid _0023_003DzOSo8vaE_003D)
			: base(_0023_003DzyzK8swU_003D, _0023_003Dz1rZ3w2I_003D, _0023_003DzNGFpltQ_003D, _0023_003DzOSo8vaE_003D)
		{
		}

		public _0023_003DzaNdK2SNh78xbyVoyjA_003D_003D(Point3D _0023_003DzkEYxO1SuR1Kw, Point3D _0023_003DzF7v9r2A_003D, Size2D _0023_003DzNnmvTM0_003D, int _0023_003DzaOnlhyY_003D)
			: base(_0023_003DzkEYxO1SuR1Kw, _0023_003DzF7v9r2A_003D, _0023_003DzNnmvTM0_003D, _0023_003DzaOnlhyY_003D)
		{
		}

		public _0023_003DzaNdK2SNh78xbyVoyjA_003D_003D(int _0023_003DzBJFJHwk_003D, int _0023_003Dz40R7bAU_003D, Point3D _0023_003DzF7v9r2A_003D, Size2D _0023_003DzNnmvTM0_003D, int _0023_003DzaOnlhyY_003D)
			: base(_0023_003DzBJFJHwk_003D, _0023_003Dz40R7bAU_003D, _0023_003DzF7v9r2A_003D, _0023_003DzNnmvTM0_003D, _0023_003DzaOnlhyY_003D)
		{
		}

		public _0023_003DzaNdK2SNh78xbyVoyjA_003D_003D(int _0023_003DzqhsKlJc_003D, _0023_003DzRV5GhlIkprjwXRkNGMknXBOYrewR09oqf_lNIvRxwZpVBQ6mcQ_003D_003D _0023_003Dz1NtQM9wHyYaT)
			: base(_0023_003DzqhsKlJc_003D, _0023_003Dz1NtQM9wHyYaT)
		{
		}
	}

	protected internal class DelaunayTriangle(int v1, int v2, int v3) : IndexTriangle(v1, v2, v3)
	{
		public int visited;

		public readonly HashSet<int> points = new HashSet<int>();

		public new int this[int i] => i switch
		{
			0 => V1, 
			1 => V2, 
			_ => V3, 
		};
	}

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	internal List<_0023_003DzaNdK2SNh78xbyVoyjA_003D_003D> _0023_003Dzk98RESByZO6KwZuGTA_003D_003D;

	protected LinkedList<DelaunayTriangle> triangles;

	protected List<LinkedList<LinkedListNode<DelaunayTriangle>>> adjacency;

	protected Point3D[][] loops;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private string _0023_003Dzp_00242ikS9_0024_lpS9O9f3qoajOg_003D = _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302990892);

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private string _0023_003DzC8196goTwYfhnCvExzrTc4uyKkSzDdYOxQ_003D_003D = _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302990849);

	protected Point3D brMin;

	protected Size2D brRange;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Mesh.natureType _0023_003DzSCp_i6HgfNf6K9v6CQ_003D_003D = Mesh.natureType.Plain;

	protected int gridSize = 1048576;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private HashSet<int> _0023_003Dz3FWG2xGNeNNc3oC6ig_003D_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private int _0023_003Dzvv6HrWo_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private mesherSmoothingType _0023_003Dz6nI_0024Dws7UcfXwITeCS6io_VXDOIk;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private int _0023_003Dz91HGJEsGIzcV;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private double _0023_003DzlCJ6DabnbVnjzDbCNIb5mv0_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private _0023_003DzQPpqutXPAMxkvsO0YWAcAYUJI4mwt8FtTTdI2Zc_003D _0023_003Dz_xHzQQk_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private readonly double _0023_003DzmlSoH_d5_pgF = -1.0;

	public string TriangulatingText
	{
		[CompilerGenerated]
		get
		{
			return _0023_003DzC8196goTwYfhnCvExzrTc4uyKkSzDdYOxQ_003D_003D;
		}
		[CompilerGenerated]
		set
		{
			_0023_003DzC8196goTwYfhnCvExzrTc4uyKkSzDdYOxQ_003D_003D = value;
		}
	}

	public Mesh.natureType OutputType
	{
		[CompilerGenerated]
		get
		{
			return _0023_003DzSCp_i6HgfNf6K9v6CQ_003D_003D;
		}
		[CompilerGenerated]
		set
		{
			_0023_003DzSCp_i6HgfNf6K9v6CQ_003D_003D = value;
		}
	}

	public mesherSmoothingType SmoothingMode
	{
		[CompilerGenerated]
		get
		{
			return _0023_003Dz6nI_0024Dws7UcfXwITeCS6io_VXDOIk;
		}
		[CompilerGenerated]
		set
		{
			_0023_003Dz6nI_0024Dws7UcfXwITeCS6io_VXDOIk = value;
		}
	}

	internal SurfaceMesher(Surface _0023_003DzF7GfYSI_003D, Polygon2D[] _0023_003Dzzh09U4K0Sr5xS0I14A_003D_003D, double _0023_003Dz2AZ_kpw_003D, double _0023_003Dza2Pq9PQ_003D, double _0023_003DzB7lAodg_003D)
	{
		if (_0023_003Dzzh09U4K0Sr5xS0I14A_003D_003D.Length == 0)
		{
			throw new EyeshotException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302991102));
		}
		_0023_003DzmlSoH_d5_pgF = _0023_003DzB7lAodg_003D;
		_0023_003DztGdcVOA_003D(_0023_003DzF7GfYSI_003D, _0023_003Dzzh09U4K0Sr5xS0I14A_003D_003D, _0023_003Dz2AZ_kpw_003D, _0023_003Dza2Pq9PQ_003D);
	}

	public SurfaceMesher(Surface surface, SizesOnCurve[][] size, bool quadratic = false, MaterialKeyedCollection materials = null)
	{
		_0023_003DztGdcVOA_003D(surface, size, quadratic, materials);
	}

	public SurfaceMesher(Surface surface, double elementSize, bool quadratic = false, MaterialKeyedCollection materials = null)
	{
		SizesOnCurve[][] array = new SizesOnCurve[surface.Trimming.ContourList.Count][];
		for (int i = 0; i < surface.Trimming.ContourList.Count; i++)
		{
			ICurve curve = surface.Trimming.ContourList[i];
			array[i] = new SizesOnCurve[curve.GetIndividualCurves().Length];
			for (int j = 0; j < array[i].Length; j++)
			{
				array[i][j] = new SizesOnCurve(elementSize);
			}
		}
		_0023_003DztGdcVOA_003D(surface, array, quadratic, materials);
	}

	private void _0023_003Dzz1c7nApJ4_o5(Point3D _0023_003DzF7v9r2A_003D, Point3D _0023_003Dz8dK2uhU_003D)
	{
		brRange = new Size2D(_0023_003DzF7v9r2A_003D, _0023_003Dz8dK2uhU_003D);
		brMin = (Point3D)_0023_003DzF7v9r2A_003D.Clone();
		Point3D point3D = new Point3D(brMin.X + brRange.X / 2.0, brMin.Y + brRange.Y / 2.0);
		double num = 1.05 * brRange.Max;
		Point3D point3D2 = new Point3D(point3D.X - num / 2.0, point3D.Y - num / 2.0);
		brMin = point3D2;
		brRange.X = (brRange.Y = num);
	}

	public override void DoWork(IProgress<ProgressChangedEventArgs> progress, CancellationToken ct)
	{
		bool flag = true;
		byte b = 4;
		object[] array = null;
		array = new object[3] { b, this, flag };
		_0023_003DzWt6eyPOE44Jm1kt8t7xd_1OQVV5oXNkh39_0024rNGXvPLnSb0yR5w_003D_003D._0023_003DzV8Qoap2BA2e7ihDorf63UrBqJsHfxy8392Oay0RbYfZ4Z2b43A_003D_003D()._0023_003DzNXHD1f5m4vUdaYpGv25IefO5Nwsu(_0023_003DzWt6eyPOE44Jm1kt8t7xd_1OQVV5oXNkh39_0024rNGXvPLnSb0yR5w_003D_003D._0023_003DzBbbipLzVnuz3UMTaQrsmBHEULT9zYjvZXH2nU2CHpMurqdPqXQ_003D_003D(), "$N9u(q\"acA", array);
		if (_0023_003Dz5bTQ1u9UVidehQ86Hw_003D_003D(progress, ct))
		{
			base.Result = ToFemMesh();
			base.Result.ElementShapeQualities = _0023_003Dz3wn_0024EN2MWgTa();
		}
	}

	protected void ProcessContours(IList<Point3D> points, IList<Point3D> outer, IList<IList<Point3D>> inners, IList<IList<Point3D>> internals, bool checkDir, double[][] sizes)
	{
		if (outer == null && points == null)
		{
			throw new ArgumentException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302991030));
		}
		_0023_003Dzk98RESByZO6KwZuGTA_003D_003D = new List<_0023_003DzaNdK2SNh78xbyVoyjA_003D_003D>();
		adjacency = new List<LinkedList<LinkedListNode<DelaunayTriangle>>>();
		int num = 0;
		Point3D boxMin;
		Point3D boxMax;
		if (outer != null)
		{
			_0023_003DzRV5GhlIkprjwXRkNGMknXBOYrewR09oqf_lNIvRxwZpVBQ6mcQ_003D_003D[] array = new _0023_003DzRV5GhlIkprjwXRkNGMknXBOYrewR09oqf_lNIvRxwZpVBQ6mcQ_003D_003D[outer.Count];
			Utility.ComputeBoundingBox(outer, out boxMin, out boxMax);
			_0023_003Dzz1c7nApJ4_o5(boxMin, boxMax);
			if (checkDir && Utility.IsOrientedClockwise(outer))
			{
				Point3D[] array2 = new Point3D[outer.Count];
				outer.CopyTo(array2, 0);
				Array.Reverse(array2);
				outer = array2;
			}
			loops = new Point3D[1 + (inners?.Count ?? 0)][];
			loops[0] = outer.ToArray();
			_0023_003Dzk98RESByZO6KwZuGTA_003D_003D.Capacity += outer.Count;
			for (int i = 0; i < outer.Count; i++)
			{
				_0023_003DzRV5GhlIkprjwXRkNGMknXBOYrewR09oqf_lNIvRxwZpVBQ6mcQ_003D_003D _0023_003DzRV5GhlIkprjwXRkNGMknXBOYrewR09oqf_lNIvRxwZpVBQ6mcQ_003D_003D2 = new _0023_003DzRV5GhlIkprjwXRkNGMknXBOYrewR09oqf_lNIvRxwZpVBQ6mcQ_003D_003D(outer[i], brMin, brRange, gridSize);
				_0023_003DzRV5GhlIkprjwXRkNGMknXBOYrewR09oqf_lNIvRxwZpVBQ6mcQ_003D_003D2._0023_003Dz_0024pfZB54_003D = sizes[0][i];
				_0023_003DzRV5GhlIkprjwXRkNGMknXBOYrewR09oqf_lNIvRxwZpVBQ6mcQ_003D_003D2._0023_003DzyzK8swU_003D = num++;
				array[i] = _0023_003DzRV5GhlIkprjwXRkNGMknXBOYrewR09oqf_lNIvRxwZpVBQ6mcQ_003D_003D2;
			}
			List<_0023_003DzRV5GhlIkprjwXRkNGMknXBOYrewR09oqf_lNIvRxwZpVBQ6mcQ_003D_003D[]> list = new List<_0023_003DzRV5GhlIkprjwXRkNGMknXBOYrewR09oqf_lNIvRxwZpVBQ6mcQ_003D_003D[]>();
			if (inners != null)
			{
				for (int j = 0; j < inners.Count; j++)
				{
					IList<Point3D> list2 = inners[j];
					_0023_003Dzk98RESByZO6KwZuGTA_003D_003D.Capacity += list2.Count;
					loops[j + 1] = list2.ToArray();
					if (checkDir && !Utility.IsOrientedClockwise(list2))
					{
						Point3D[] array3 = new Point3D[list2.Count];
						list2.CopyTo(array3, 0);
						Array.Reverse(array3);
						list2 = array3;
					}
					int count = list.Count;
					list.Add(new _0023_003DzRV5GhlIkprjwXRkNGMknXBOYrewR09oqf_lNIvRxwZpVBQ6mcQ_003D_003D[inners[j].Count]);
					for (int k = 0; k < list2.Count; k++)
					{
						_0023_003DzRV5GhlIkprjwXRkNGMknXBOYrewR09oqf_lNIvRxwZpVBQ6mcQ_003D_003D _0023_003DzRV5GhlIkprjwXRkNGMknXBOYrewR09oqf_lNIvRxwZpVBQ6mcQ_003D_003D3 = new _0023_003DzRV5GhlIkprjwXRkNGMknXBOYrewR09oqf_lNIvRxwZpVBQ6mcQ_003D_003D(list2[k], brMin, brRange, gridSize);
						_0023_003DzRV5GhlIkprjwXRkNGMknXBOYrewR09oqf_lNIvRxwZpVBQ6mcQ_003D_003D3._0023_003Dz_0024pfZB54_003D = sizes[j + 1][k];
						_0023_003DzRV5GhlIkprjwXRkNGMknXBOYrewR09oqf_lNIvRxwZpVBQ6mcQ_003D_003D3._0023_003DzyzK8swU_003D = num++;
						list[count][k] = _0023_003DzRV5GhlIkprjwXRkNGMknXBOYrewR09oqf_lNIvRxwZpVBQ6mcQ_003D_003D3;
					}
				}
			}
			triangles = new LinkedList<DelaunayTriangle>();
			new _0023_003DzYR1TgTYWxCuyYJkKILoYCEU5W7OEtMUVAjiRLBQ_O1HhL5mt0Q_003D_003D(array, list.ToArray(), _0023_003DzaYhgSnxqAWC7: false)._0023_003Dz5bTQ1u9UVidehQ86Hw_003D_003D(out _0023_003DzRV5GhlIkprjwXRkNGMknXBOYrewR09oqf_lNIvRxwZpVBQ6mcQ_003D_003D[] _0023_003DzY3ahEmgbxOhjQjTWbA_003D_003D, out IndexTriangle[] _0023_003DzXT3BRSZezblHON7QOg_003D_003D);
			_0023_003DzRV5GhlIkprjwXRkNGMknXBOYrewR09oqf_lNIvRxwZpVBQ6mcQ_003D_003D[] array4 = _0023_003DzY3ahEmgbxOhjQjTWbA_003D_003D;
			foreach (_0023_003DzRV5GhlIkprjwXRkNGMknXBOYrewR09oqf_lNIvRxwZpVBQ6mcQ_003D_003D _0023_003DzRV5GhlIkprjwXRkNGMknXBOYrewR09oqf_lNIvRxwZpVBQ6mcQ_003D_003D4 in array4)
			{
				_0023_003DzaNdK2SNh78xbyVoyjA_003D_003D _0023_003DzaNdK2SNh78xbyVoyjA_003D_003D2 = new _0023_003DzaNdK2SNh78xbyVoyjA_003D_003D((Point3D)_0023_003DzRV5GhlIkprjwXRkNGMknXBOYrewR09oqf_lNIvRxwZpVBQ6mcQ_003D_003D4._0023_003DzIHt45I8_003D, brMin, brRange, gridSize);
				_0023_003DzaNdK2SNh78xbyVoyjA_003D_003D2._0023_003Dz_0024pfZB54_003D = _0023_003DzRV5GhlIkprjwXRkNGMknXBOYrewR09oqf_lNIvRxwZpVBQ6mcQ_003D_003D4._0023_003Dz_0024pfZB54_003D;
				if (_0023_003DzaNdK2SNh78xbyVoyjA_003D_003D2._0023_003Dz_0024pfZB54_003D < 0.0)
				{
					throw new EyeshotException(string.Format(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302990986), _0023_003DzaNdK2SNh78xbyVoyjA_003D_003D2._0023_003Dz_0024pfZB54_003D));
				}
				_0023_003Dzk98RESByZO6KwZuGTA_003D_003D.Add(_0023_003DzaNdK2SNh78xbyVoyjA_003D_003D2);
				adjacency.Add(new LinkedList<LinkedListNode<DelaunayTriangle>>());
			}
			IndexTriangle[] array5 = _0023_003DzXT3BRSZezblHON7QOg_003D_003D;
			foreach (IndexTriangle indexTriangle in array5)
			{
				DelaunayTriangle value = new DelaunayTriangle(indexTriangle.V1, indexTriangle.V2, indexTriangle.V3);
				LinkedListNode<DelaunayTriangle> value2 = triangles.AddLast(value);
				adjacency[indexTriangle.V1].AddLast(value2);
				adjacency[indexTriangle.V2].AddLast(value2);
				adjacency[indexTriangle.V3].AddLast(value2);
			}
		}
		if (internals != null)
		{
			if (outer == null)
			{
				Utility.ComputeBoundingBox(points, out boxMin, out boxMax);
				_0023_003Dzz1c7nApJ4_o5(boxMin, boxMax);
			}
			foreach (IList<Point3D> @internal in internals)
			{
				for (int m = 0; m < @internal.Count; m++)
				{
					Point3D point3D = @internal[m];
					if (loops == null || _0023_003DzXIeu2Xg_003D(point3D))
					{
						_0023_003DzaNdK2SNh78xbyVoyjA_003D_003D item = new _0023_003DzaNdK2SNh78xbyVoyjA_003D_003D(point3D, brMin, brRange, gridSize);
						_0023_003Dzk98RESByZO6KwZuGTA_003D_003D.Add(item);
						adjacency.Add(new LinkedList<LinkedListNode<DelaunayTriangle>>());
					}
				}
			}
		}
		if (points == null)
		{
			return;
		}
		if (outer == null && internals == null)
		{
			Utility.ComputeBoundingBox(points, out boxMin, out boxMax);
			_0023_003Dzz1c7nApJ4_o5(boxMin, boxMax);
		}
		_0023_003Dzk98RESByZO6KwZuGTA_003D_003D.Capacity += points.Count;
		for (int n = 0; n < points.Count; n++)
		{
			Point3D point3D2 = points[n];
			if (loops == null || _0023_003DzXIeu2Xg_003D(point3D2))
			{
				_0023_003DzaNdK2SNh78xbyVoyjA_003D_003D item2 = new _0023_003DzaNdK2SNh78xbyVoyjA_003D_003D(point3D2, brMin, brRange, gridSize);
				_0023_003Dzk98RESByZO6KwZuGTA_003D_003D.Add(item2);
				adjacency.Add(new LinkedList<LinkedListNode<DelaunayTriangle>>());
			}
		}
	}

	protected FemMesh ToFemMesh()
	{
		FemMesh femMesh;
		if (_0023_003Dz0ed6dmFMTxDQWwqeBg_003D_003D)
		{
			Surface _0023_003DzejDtVY0_003D = _0023_003Dz_xHzQQk_003D._0023_003DzejDtVY0_003D;
			Point3D[] array = new Point3D[_0023_003Dzk98RESByZO6KwZuGTA_003D_003D.Count];
			for (int i = 0; i < _0023_003Dzk98RESByZO6KwZuGTA_003D_003D.Count; i++)
			{
				Point3D _0023_003Dzyjwk8PdbSXxQ = _0023_003Dzk98RESByZO6KwZuGTA_003D_003D[i]._0023_003Dzyjwk8PdbSXxQ;
				Point2D _0023_003DzIHt45I8_003D = _0023_003Dzk98RESByZO6KwZuGTA_003D_003D[i]._0023_003DzIHt45I8_003D;
				_0023_003DzIHt45I8_003D.TransformBy(_0023_003Dz_xHzQQk_003D._0023_003DzAOlcrIqv6aDt());
				array[i] = new PointUv(_0023_003Dzyjwk8PdbSXxQ.X, _0023_003Dzyjwk8PdbSXxQ.Y, _0023_003Dzyjwk8PdbSXxQ.Z, _0023_003DzIHt45I8_003D.X, _0023_003DzIHt45I8_003D.Y);
			}
			Mesh mesh = new Mesh(array, triangles.ToArray());
			if (_0023_003Dz_xHzQQk_003D._0023_003Dzbse2nfoNwRvN())
			{
				mesh.Weld(_0023_003DzlCJ6DabnbVnjzDbCNIb5mv0_003D);
			}
			List<ICurve> list = new List<ICurve>(_0023_003DzejDtVY0_003D.Trimming.ContourList.Count);
			foreach (ICurve contour in _0023_003DzejDtVY0_003D.Trimming.ContourList)
			{
				ICurve[] individualCurves = contour.GetIndividualCurves();
				for (int j = 0; j < individualCurves.Length; j++)
				{
					TrimCurve trimCurve = (TrimCurve)individualCurves[j];
					list.Add(trimCurve.Edge);
				}
			}
			Mesh mesh2 = Surface._0023_003DzqONH5KoLjeGW(_0023_003DzejDtVY0_003D, mesh, list, null);
			if (mesh2 == null)
			{
				return null;
			}
			int num = mesh2.Vertices.Length;
			int num2 = mesh2.Triangles.Length;
			femMesh = new FemMesh(num, num2);
			for (uint num3 = 0u; num3 < num; num3++)
			{
				femMesh.Vertices[num3] = new Node(mesh2.Vertices[num3].X, mesh2.Vertices[num3].Y, mesh2.Vertices[num3].Z);
			}
			for (uint num4 = 0u; num4 < num2; num4++)
			{
				femMesh.Elements[num4] = new Tria6(mesh2.Triangles[num4].V1, ((QuadraticTriangle)mesh2.Triangles[num4]).V4, mesh2.Triangles[num4].V2, ((QuadraticTriangle)mesh2.Triangles[num4]).V5, mesh2.Triangles[num4].V3, ((QuadraticTriangle)mesh2.Triangles[num4]).V6, _0023_003Dzv2Pxl9dvjF66aL2_0024_A_003D_003D);
			}
		}
		else
		{
			Point3D[] array2 = new Point3D[_0023_003Dzk98RESByZO6KwZuGTA_003D_003D.Count];
			for (int k = 0; k < _0023_003Dzk98RESByZO6KwZuGTA_003D_003D.Count; k++)
			{
				Point3D _0023_003Dzyjwk8PdbSXxQ2 = _0023_003Dzk98RESByZO6KwZuGTA_003D_003D[k]._0023_003Dzyjwk8PdbSXxQ;
				array2[k] = new NodeBeam(_0023_003Dzyjwk8PdbSXxQ2.X, _0023_003Dzyjwk8PdbSXxQ2.Y, _0023_003Dzyjwk8PdbSXxQ2.Z);
			}
			Mesh mesh3 = new Mesh(array2, triangles.ToArray());
			if (_0023_003Dz_xHzQQk_003D._0023_003Dzbse2nfoNwRvN())
			{
				mesh3.Weld(_0023_003DzlCJ6DabnbVnjzDbCNIb5mv0_003D);
			}
			Element[] array3 = new Element[mesh3.Triangles.Length];
			int num5 = 0;
			IndexTriangle[] array4 = mesh3.Triangles;
			foreach (IndexTriangle indexTriangle in array4)
			{
				array3[num5++] = new Tria3(indexTriangle.V1, indexTriangle.V2, indexTriangle.V3, _0023_003Dzv2Pxl9dvjF66aL2_0024_A_003D_003D);
			}
			femMesh = new FemMesh(mesh3.Vertices, array3);
		}
		return femMesh;
	}

	protected bool TriangulateInternal(IProgress<ProgressChangedEventArgs> progress, CancellationToken ct)
	{
		int num = _0023_003Dzk98RESByZO6KwZuGTA_003D_003D.Count - 1;
		bool flag = triangles == null;
		if (flag)
		{
			triangles = new LinkedList<DelaunayTriangle>();
			_0023_003Dzk98RESByZO6KwZuGTA_003D_003D.Add(new _0023_003DzaNdK2SNh78xbyVoyjA_003D_003D(0, 0, brMin, brRange, gridSize));
			_0023_003Dzk98RESByZO6KwZuGTA_003D_003D.Add(new _0023_003DzaNdK2SNh78xbyVoyjA_003D_003D(gridSize, 0, brMin, brRange, gridSize));
			_0023_003Dzk98RESByZO6KwZuGTA_003D_003D.Add(new _0023_003DzaNdK2SNh78xbyVoyjA_003D_003D(gridSize, gridSize, brMin, brRange, gridSize));
			_0023_003Dzk98RESByZO6KwZuGTA_003D_003D.Add(new _0023_003DzaNdK2SNh78xbyVoyjA_003D_003D(0, gridSize, brMin, brRange, gridSize));
			adjacency = new List<LinkedList<LinkedListNode<DelaunayTriangle>>>();
			for (int i = 0; i < _0023_003Dzk98RESByZO6KwZuGTA_003D_003D.Count; i++)
			{
				adjacency.Add(new LinkedList<LinkedListNode<DelaunayTriangle>>());
			}
			DelaunayTriangle value = new DelaunayTriangle(num + 1, num + 2, num + 3);
			LinkedListNode<DelaunayTriangle> value2 = triangles.AddLast(value);
			adjacency[num + 1].AddLast(value2);
			adjacency[num + 2].AddLast(value2);
			adjacency[num + 3].AddLast(value2);
			DelaunayTriangle value3 = new DelaunayTriangle(num + 1, num + 3, num + 4);
			LinkedListNode<DelaunayTriangle> value4 = triangles.AddLast(value3);
			adjacency[num + 1].AddLast(value4);
			adjacency[num + 3].AddLast(value4);
			adjacency[num + 4].AddLast(value4);
		}
		if (ProcessTriangulation(0, flag ? (num + 1) : _0023_003Dzk98RESByZO6KwZuGTA_003D_003D.Count, _0023_003Dzp_00242ikS9_0024_lpS9O9f3qoajOg_003D, checkInside: true, progress, ct))
		{
			if (flag)
			{
				LinkedListNode<DelaunayTriangle> linkedListNode = triangles.First;
				do
				{
					DelaunayTriangle value5 = linkedListNode.Value;
					LinkedListNode<DelaunayTriangle> next = linkedListNode.Next;
					if (value5.V1 > num || value5.V2 > num || value5.V3 > num)
					{
						triangles.Remove(linkedListNode);
						adjacency[value5.V1].Remove(linkedListNode);
						adjacency[value5.V2].Remove(linkedListNode);
						adjacency[value5.V3].Remove(linkedListNode);
					}
					linkedListNode = next;
				}
				while (linkedListNode != null);
				_0023_003Dzk98RESByZO6KwZuGTA_003D_003D.RemoveRange(_0023_003Dzk98RESByZO6KwZuGTA_003D_003D.Count - 4, 4);
				adjacency.RemoveRange(adjacency.Count - 4, 4);
			}
			return true;
		}
		return false;
	}

	protected bool ProcessTriangulation(int startFrom, int endAt, string title, bool checkInside, IProgress<ProgressChangedEventArgs> progress, CancellationToken ct)
	{
		LinkedList<IndexLine> linkedList = new LinkedList<IndexLine>();
		for (int i = startFrom; i < endAt; i++)
		{
			if (adjacency[i].Count > 0)
			{
				continue;
			}
			_0023_003DzaNdK2SNh78xbyVoyjA_003D_003D _0023_003DzaNdK2SNh78xbyVoyjA_003D_003D2 = _0023_003Dzk98RESByZO6KwZuGTA_003D_003D[i];
			long _0023_003DzFuXfk4k_003D = _0023_003DzaNdK2SNh78xbyVoyjA_003D_003D2._0023_003DzFuXfk4k_003D;
			long _0023_003DzZ_0024Wvtoc_003D = _0023_003DzaNdK2SNh78xbyVoyjA_003D_003D2._0023_003DzZ_0024Wvtoc_003D;
			if (_0023_003DzoRypQSV2e4iw(_0023_003DzaNdK2SNh78xbyVoyjA_003D_003D2, i))
			{
				continue;
			}
			_0023_003Dz3FWG2xGNeNNc3oC6ig_003D_003D = new HashSet<int>();
			linkedList.Clear();
			LinkedListNode<DelaunayTriangle> _0023_003DzDCjBZK4_003D = _0023_003DzaNdK2SNh78xbyVoyjA_003D_003D2._0023_003DzDCjBZK4_003D;
			DelaunayTriangle value = _0023_003DzaNdK2SNh78xbyVoyjA_003D_003D2._0023_003DzDCjBZK4_003D.Value;
			_0023_003DzRV5GhlIkprjwXRkNGMknXBOYrewR09oqf_lNIvRxwZpVBQ6mcQ_003D_003D _0023_003DzRV5GhlIkprjwXRkNGMknXBOYrewR09oqf_lNIvRxwZpVBQ6mcQ_003D_003D2 = _0023_003Dzk98RESByZO6KwZuGTA_003D_003D[value.V1];
			_0023_003DzRV5GhlIkprjwXRkNGMknXBOYrewR09oqf_lNIvRxwZpVBQ6mcQ_003D_003D _0023_003DzRV5GhlIkprjwXRkNGMknXBOYrewR09oqf_lNIvRxwZpVBQ6mcQ_003D_003D3 = _0023_003Dzk98RESByZO6KwZuGTA_003D_003D[value.V2];
			_0023_003DzRV5GhlIkprjwXRkNGMknXBOYrewR09oqf_lNIvRxwZpVBQ6mcQ_003D_003D _0023_003DzRV5GhlIkprjwXRkNGMknXBOYrewR09oqf_lNIvRxwZpVBQ6mcQ_003D_003D4 = _0023_003Dzk98RESByZO6KwZuGTA_003D_003D[value.V3];
			if (!_0023_003DzZMh1kcHo8mkQ7Skys6V3plk_003D(_0023_003DzFuXfk4k_003D, _0023_003DzZ_0024Wvtoc_003D, _0023_003DzRV5GhlIkprjwXRkNGMknXBOYrewR09oqf_lNIvRxwZpVBQ6mcQ_003D_003D2._0023_003DzFuXfk4k_003D, _0023_003DzRV5GhlIkprjwXRkNGMknXBOYrewR09oqf_lNIvRxwZpVBQ6mcQ_003D_003D2._0023_003DzZ_0024Wvtoc_003D, _0023_003DzRV5GhlIkprjwXRkNGMknXBOYrewR09oqf_lNIvRxwZpVBQ6mcQ_003D_003D3._0023_003DzFuXfk4k_003D, _0023_003DzRV5GhlIkprjwXRkNGMknXBOYrewR09oqf_lNIvRxwZpVBQ6mcQ_003D_003D3._0023_003DzZ_0024Wvtoc_003D, _0023_003DzRV5GhlIkprjwXRkNGMknXBOYrewR09oqf_lNIvRxwZpVBQ6mcQ_003D_003D4._0023_003DzFuXfk4k_003D, _0023_003DzRV5GhlIkprjwXRkNGMknXBOYrewR09oqf_lNIvRxwZpVBQ6mcQ_003D_003D4._0023_003DzZ_0024Wvtoc_003D))
			{
				throw new EyeshotException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302991699));
			}
			_0023_003DzJmw5altPzN6B(_0023_003DzFuXfk4k_003D, _0023_003DzZ_0024Wvtoc_003D, linkedList, _0023_003DzDCjBZK4_003D, 0, i);
			_0023_003DzzYMR9YI5l4XFn5ae2FyF9HQNv279(_0023_003DzFuXfk4k_003D, _0023_003DzZ_0024Wvtoc_003D, linkedList);
			_0023_003Dz1PyH3yaLy7qzmxw6nrysNYwvAvT6(i, linkedList);
			if (!UpdateProgressAndCheckCancelled(i - startFrom, _0023_003Dzk98RESByZO6KwZuGTA_003D_003D.Count - startFrom, title, progress, ct))
			{
				return false;
			}
			if (_0023_003Dz3FWG2xGNeNNc3oC6ig_003D_003D.Any((int _0023_003DzTSeNR8Q_003D) => _0023_003Dzk98RESByZO6KwZuGTA_003D_003D[_0023_003DzTSeNR8Q_003D]._0023_003DzDCjBZK4_003D == null))
			{
				int num = _0023_003Dz3FWG2xGNeNNc3oC6ig_003D_003D.First((int _0023_003DzTSeNR8Q_003D) => _0023_003Dzk98RESByZO6KwZuGTA_003D_003D[_0023_003DzTSeNR8Q_003D]._0023_003DzDCjBZK4_003D == null);
				throw new EyeshotException(string.Format(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302991656), num));
			}
			if (!adjacency[i].Any())
			{
				throw new EyeshotException(string.Format(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302991821), i));
			}
		}
		UpdateProgressTo100(title, progress);
		return true;
	}

	private bool _0023_003DzoRypQSV2e4iw(_0023_003DzRV5GhlIkprjwXRkNGMknXBOYrewR09oqf_lNIvRxwZpVBQ6mcQ_003D_003D _0023_003DzXrexKjY_003D, int _0023_003Dz9JZgoew_003D)
	{
		for (int i = 0; i < _0023_003Dz9JZgoew_003D; i++)
		{
			_0023_003DzRV5GhlIkprjwXRkNGMknXBOYrewR09oqf_lNIvRxwZpVBQ6mcQ_003D_003D _0023_003DzRV5GhlIkprjwXRkNGMknXBOYrewR09oqf_lNIvRxwZpVBQ6mcQ_003D_003D2 = _0023_003Dzk98RESByZO6KwZuGTA_003D_003D[i];
			if (_0023_003DzRV5GhlIkprjwXRkNGMknXBOYrewR09oqf_lNIvRxwZpVBQ6mcQ_003D_003D2._0023_003DzFuXfk4k_003D == _0023_003DzXrexKjY_003D._0023_003DzFuXfk4k_003D && _0023_003DzRV5GhlIkprjwXRkNGMknXBOYrewR09oqf_lNIvRxwZpVBQ6mcQ_003D_003D2._0023_003DzZ_0024Wvtoc_003D == _0023_003DzXrexKjY_003D._0023_003DzZ_0024Wvtoc_003D)
			{
				return true;
			}
		}
		return false;
	}

	private void _0023_003DzzYMR9YI5l4XFn5ae2FyF9HQNv279(long _0023_003DzaQ_y9PQ_003D, long _0023_003DzD47R4_0_003D, LinkedList<IndexLine> _0023_003DzU3hosSAzkxO7)
	{
		List<IndexLine> list = new List<IndexLine>();
		bool flag;
		do
		{
			flag = false;
			LinkedListNode<IndexLine> linkedListNode = _0023_003DzU3hosSAzkxO7.First;
			if (linkedListNode == null)
			{
				break;
			}
			do
			{
				_0023_003Dz17deN5RpyVgyaMlfHQ_003D_003D _0023_003Dz17deN5RpyVgyaMlfHQ_003D_003D2 = (_0023_003Dz17deN5RpyVgyaMlfHQ_003D_003D)linkedListNode.Value;
				Segment2D segment2D = new Segment2D(new Point2D(_0023_003Dzk98RESByZO6KwZuGTA_003D_003D[_0023_003Dz17deN5RpyVgyaMlfHQ_003D_003D2.V1]._0023_003DzFuXfk4k_003D, _0023_003Dzk98RESByZO6KwZuGTA_003D_003D[_0023_003Dz17deN5RpyVgyaMlfHQ_003D_003D2.V1]._0023_003DzZ_0024Wvtoc_003D), new Point2D(_0023_003Dzk98RESByZO6KwZuGTA_003D_003D[_0023_003Dz17deN5RpyVgyaMlfHQ_003D_003D2.V2]._0023_003DzFuXfk4k_003D, _0023_003Dzk98RESByZO6KwZuGTA_003D_003D[_0023_003Dz17deN5RpyVgyaMlfHQ_003D_003D2.V2]._0023_003DzZ_0024Wvtoc_003D));
				Point2D point2D = new Point2D(_0023_003DzaQ_y9PQ_003D, _0023_003DzD47R4_0_003D);
				double t = segment2D.Project(point2D);
				Vector2D vector2D = Vector2D.Subtract(segment2D.PointAt(t), point2D);
				Vector2D vector2D2 = Vector2D.Subtract(segment2D.P1, segment2D.P0);
				vector2D.Normalize();
				vector2D2.Normalize();
				if (Vector2D.PerpDotProduct(vector2D, vector2D2) < 0.0 || _0023_003DzhL_0024JiaSwzQwiE8U_yQ_003D_003D(_0023_003Dz17deN5RpyVgyaMlfHQ_003D_003D2._0023_003DzwTeMRYA_003D, list))
				{
					flag = true;
					DelaunayTriangle _0023_003DzwTeMRYA_003D = _0023_003Dz17deN5RpyVgyaMlfHQ_003D_003D2._0023_003DzwTeMRYA_003D;
					list.Add(new IndexLine(_0023_003DzwTeMRYA_003D.V1, _0023_003DzwTeMRYA_003D.V2));
					list.Add(new IndexLine(_0023_003DzwTeMRYA_003D.V2, _0023_003DzwTeMRYA_003D.V3));
					list.Add(new IndexLine(_0023_003DzwTeMRYA_003D.V3, _0023_003DzwTeMRYA_003D.V1));
					LinkedListNode<DelaunayTriangle> linkedListNode2 = triangles.AddLast(_0023_003DzwTeMRYA_003D);
					adjacency[_0023_003Dz17deN5RpyVgyaMlfHQ_003D_003D2._0023_003DzwTeMRYA_003D.V1].AddLast(linkedListNode2);
					adjacency[_0023_003Dz17deN5RpyVgyaMlfHQ_003D_003D2._0023_003DzwTeMRYA_003D.V2].AddLast(linkedListNode2);
					adjacency[_0023_003Dz17deN5RpyVgyaMlfHQ_003D_003D2._0023_003DzwTeMRYA_003D.V3].AddLast(linkedListNode2);
					_0023_003Dzf6epnNwy9t_0024T(linkedListNode2);
					LinkedListNode<IndexLine> linkedListNode3 = _0023_003DzU3hosSAzkxO7.Find(new IndexLine(_0023_003Dz17deN5RpyVgyaMlfHQ_003D_003D2._0023_003DzwTeMRYA_003D.V1, _0023_003Dz17deN5RpyVgyaMlfHQ_003D_003D2._0023_003DzwTeMRYA_003D.V2));
					if (linkedListNode3 != null)
					{
						_0023_003DzU3hosSAzkxO7.Remove(linkedListNode3);
					}
					linkedListNode3 = _0023_003DzU3hosSAzkxO7.Find(new IndexLine(_0023_003Dz17deN5RpyVgyaMlfHQ_003D_003D2._0023_003DzwTeMRYA_003D.V2, _0023_003Dz17deN5RpyVgyaMlfHQ_003D_003D2._0023_003DzwTeMRYA_003D.V3));
					if (linkedListNode3 != null)
					{
						_0023_003DzU3hosSAzkxO7.Remove(linkedListNode3);
					}
					linkedListNode3 = _0023_003DzU3hosSAzkxO7.Find(new IndexLine(_0023_003Dz17deN5RpyVgyaMlfHQ_003D_003D2._0023_003DzwTeMRYA_003D.V3, _0023_003Dz17deN5RpyVgyaMlfHQ_003D_003D2._0023_003DzwTeMRYA_003D.V1));
					if (linkedListNode3 != null)
					{
						_0023_003DzU3hosSAzkxO7.Remove(linkedListNode3);
					}
				}
				linkedListNode = linkedListNode.Next;
			}
			while (linkedListNode != null);
		}
		while (flag);
	}

	private bool _0023_003DzhL_0024JiaSwzQwiE8U_yQ_003D_003D(DelaunayTriangle _0023_003DzwTeMRYA_003D, List<IndexLine> _0023_003DzLfVAUFtIiASrBnr5bQ_003D_003D)
	{
		foreach (IndexLine item in _0023_003DzLfVAUFtIiASrBnr5bQ_003D_003D)
		{
			if (item.V1 == _0023_003DzwTeMRYA_003D.V2 && item.V2 == _0023_003DzwTeMRYA_003D.V1)
			{
				return true;
			}
			if (item.V1 == _0023_003DzwTeMRYA_003D.V3 && item.V2 == _0023_003DzwTeMRYA_003D.V2)
			{
				return true;
			}
			if (item.V1 == _0023_003DzwTeMRYA_003D.V1 && item.V2 == _0023_003DzwTeMRYA_003D.V3)
			{
				return true;
			}
		}
		return false;
	}

	private void _0023_003Dz1PyH3yaLy7qzmxw6nrysNYwvAvT6(int _0023_003Dz437_00244ak_003D, LinkedList<IndexLine> _0023_003DzU3hosSAzkxO7)
	{
		foreach (IndexLine item in _0023_003DzU3hosSAzkxO7)
		{
			DelaunayTriangle delaunayTriangle = new DelaunayTriangle(item.V1, item.V2, _0023_003Dz437_00244ak_003D);
			if (_0023_003Dzn_jttcxAXmO7(delaunayTriangle) > 0.0)
			{
				LinkedListNode<DelaunayTriangle> linkedListNode = triangles.AddLast(delaunayTriangle);
				adjacency[item.V1].AddLast(linkedListNode);
				adjacency[item.V2].AddLast(linkedListNode);
				adjacency[_0023_003Dz437_00244ak_003D].AddLast(linkedListNode);
				_0023_003Dzf6epnNwy9t_0024T(linkedListNode);
			}
		}
	}

	private static double _0023_003DzGNup_IfECT6e(Vector2 _0023_003DzB68dg9Q_003D, Vector2 _0023_003DzDVubtvo_003D, Vector2 _0023_003DzFj_0024IqDQ_003D, Vector2 _0023_003DzjdeMMkk_003D)
	{
		Vector2 vector = _0023_003DzFj_0024IqDQ_003D - _0023_003DzDVubtvo_003D;
		Vector2 vector2 = _0023_003DzjdeMMkk_003D - _0023_003DzFj_0024IqDQ_003D;
		Vector2 vector3 = _0023_003DzDVubtvo_003D - _0023_003DzjdeMMkk_003D;
		Vector2 vector4 = _0023_003DzB68dg9Q_003D - _0023_003DzDVubtvo_003D;
		Vector2 vector5 = _0023_003DzB68dg9Q_003D - _0023_003DzFj_0024IqDQ_003D;
		Vector2 vector6 = _0023_003DzB68dg9Q_003D - _0023_003DzjdeMMkk_003D;
		Vector2 vector7 = vector4 - vector * Utility.Clamp(Vector2.Dot(vector4, vector) / Vector2.Dot(vector, vector), 0f, 1f);
		Vector2 vector8 = vector5 - vector2 * Utility.Clamp(Vector2.Dot(vector5, vector2) / Vector2.Dot(vector2, vector2), 0f, 1f);
		Vector2 vector9 = vector6 - vector3 * Utility.Clamp(Vector2.Dot(vector6, vector3) / Vector2.Dot(vector3, vector3), 0f, 1f);
		float num = Math.Sign(vector.X * vector3.Y - vector.Y * vector3.X);
		Vector2 vector10 = new Vector2(Vector2.Dot(vector7, vector7), num * (vector4.X * vector.Y - vector4.Y * vector.X));
		Vector2 vector11 = new Vector2(Vector2.Dot(vector8, vector8), num * (vector5.X * vector2.Y - vector5.Y * vector2.X));
		Vector2 vector12 = new Vector2(Vector2.Dot(vector9, vector9), num * (vector6.X * vector3.Y - vector6.Y * vector3.X));
		double d = Math.Min(vector10.X, Math.Min(vector11.X, vector12.X));
		double value = Math.Min(vector10.Y, Math.Min(vector11.Y, vector12.Y));
		return (0.0 - Math.Sqrt(d)) * (double)Math.Sign(value);
	}

	private double _0023_003DzGNup_IfECT6e(_0023_003DzRV5GhlIkprjwXRkNGMknXBOYrewR09oqf_lNIvRxwZpVBQ6mcQ_003D_003D _0023_003DzB68dg9Q_003D, _0023_003DzRV5GhlIkprjwXRkNGMknXBOYrewR09oqf_lNIvRxwZpVBQ6mcQ_003D_003D _0023_003DzDVubtvo_003D, _0023_003DzRV5GhlIkprjwXRkNGMknXBOYrewR09oqf_lNIvRxwZpVBQ6mcQ_003D_003D _0023_003DzFj_0024IqDQ_003D, _0023_003DzRV5GhlIkprjwXRkNGMknXBOYrewR09oqf_lNIvRxwZpVBQ6mcQ_003D_003D _0023_003DzjdeMMkk_003D)
	{
		return _0023_003DzGNup_IfECT6e(new Vector2(_0023_003DzB68dg9Q_003D._0023_003DzFuXfk4k_003D, _0023_003DzB68dg9Q_003D._0023_003DzZ_0024Wvtoc_003D), new Vector2(_0023_003DzDVubtvo_003D._0023_003DzFuXfk4k_003D, _0023_003DzDVubtvo_003D._0023_003DzZ_0024Wvtoc_003D), new Vector2(_0023_003DzFj_0024IqDQ_003D._0023_003DzFuXfk4k_003D, _0023_003DzFj_0024IqDQ_003D._0023_003DzZ_0024Wvtoc_003D), new Vector2(_0023_003DzjdeMMkk_003D._0023_003DzFuXfk4k_003D, _0023_003DzjdeMMkk_003D._0023_003DzZ_0024Wvtoc_003D));
	}

	private void _0023_003Dzf6epnNwy9t_0024T(LinkedListNode<DelaunayTriangle> _0023_003DzRXJWLHs_003D)
	{
		DelaunayTriangle value = _0023_003DzRXJWLHs_003D.Value;
		value.points.Clear();
		_0023_003DzRV5GhlIkprjwXRkNGMknXBOYrewR09oqf_lNIvRxwZpVBQ6mcQ_003D_003D _0023_003DzRV5GhlIkprjwXRkNGMknXBOYrewR09oqf_lNIvRxwZpVBQ6mcQ_003D_003D2 = _0023_003Dzk98RESByZO6KwZuGTA_003D_003D[value.V1];
		_0023_003DzRV5GhlIkprjwXRkNGMknXBOYrewR09oqf_lNIvRxwZpVBQ6mcQ_003D_003D _0023_003DzRV5GhlIkprjwXRkNGMknXBOYrewR09oqf_lNIvRxwZpVBQ6mcQ_003D_003D3 = _0023_003Dzk98RESByZO6KwZuGTA_003D_003D[value.V2];
		_0023_003DzRV5GhlIkprjwXRkNGMknXBOYrewR09oqf_lNIvRxwZpVBQ6mcQ_003D_003D _0023_003DzRV5GhlIkprjwXRkNGMknXBOYrewR09oqf_lNIvRxwZpVBQ6mcQ_003D_003D4 = _0023_003Dzk98RESByZO6KwZuGTA_003D_003D[value.V3];
		foreach (int item in _0023_003Dz3FWG2xGNeNNc3oC6ig_003D_003D)
		{
			_0023_003DzaNdK2SNh78xbyVoyjA_003D_003D _0023_003DzaNdK2SNh78xbyVoyjA_003D_003D2 = _0023_003Dzk98RESByZO6KwZuGTA_003D_003D[item];
			if ((_0023_003DzaNdK2SNh78xbyVoyjA_003D_003D2._0023_003DzDCjBZK4_003D == null || !(_0023_003DzaNdK2SNh78xbyVoyjA_003D_003D2._0023_003DzOxKU6GM_003D <= 0.0)) && _0023_003DzZMh1kcHo8mkQ7Skys6V3plk_003D(_0023_003DzaNdK2SNh78xbyVoyjA_003D_003D2._0023_003DzFuXfk4k_003D, _0023_003DzaNdK2SNh78xbyVoyjA_003D_003D2._0023_003DzZ_0024Wvtoc_003D, _0023_003DzRV5GhlIkprjwXRkNGMknXBOYrewR09oqf_lNIvRxwZpVBQ6mcQ_003D_003D2._0023_003DzFuXfk4k_003D, _0023_003DzRV5GhlIkprjwXRkNGMknXBOYrewR09oqf_lNIvRxwZpVBQ6mcQ_003D_003D2._0023_003DzZ_0024Wvtoc_003D, _0023_003DzRV5GhlIkprjwXRkNGMknXBOYrewR09oqf_lNIvRxwZpVBQ6mcQ_003D_003D3._0023_003DzFuXfk4k_003D, _0023_003DzRV5GhlIkprjwXRkNGMknXBOYrewR09oqf_lNIvRxwZpVBQ6mcQ_003D_003D3._0023_003DzZ_0024Wvtoc_003D, _0023_003DzRV5GhlIkprjwXRkNGMknXBOYrewR09oqf_lNIvRxwZpVBQ6mcQ_003D_003D4._0023_003DzFuXfk4k_003D, _0023_003DzRV5GhlIkprjwXRkNGMknXBOYrewR09oqf_lNIvRxwZpVBQ6mcQ_003D_003D4._0023_003DzZ_0024Wvtoc_003D))
			{
				double num = _0023_003DzGNup_IfECT6e(_0023_003DzaNdK2SNh78xbyVoyjA_003D_003D2, _0023_003DzRV5GhlIkprjwXRkNGMknXBOYrewR09oqf_lNIvRxwZpVBQ6mcQ_003D_003D2, _0023_003DzRV5GhlIkprjwXRkNGMknXBOYrewR09oqf_lNIvRxwZpVBQ6mcQ_003D_003D3, _0023_003DzRV5GhlIkprjwXRkNGMknXBOYrewR09oqf_lNIvRxwZpVBQ6mcQ_003D_003D4);
				if (_0023_003DzaNdK2SNh78xbyVoyjA_003D_003D2._0023_003DzDCjBZK4_003D == null || num < _0023_003DzaNdK2SNh78xbyVoyjA_003D_003D2._0023_003DzOxKU6GM_003D)
				{
					_0023_003Dzk98RESByZO6KwZuGTA_003D_003D[item]._0023_003DzDCjBZK4_003D = _0023_003DzRXJWLHs_003D;
					_0023_003Dzk98RESByZO6KwZuGTA_003D_003D[item]._0023_003DzOxKU6GM_003D = num;
					value.points.Add(item);
				}
			}
		}
	}

	private void _0023_003DzSjqHkNn6s9q7(LinkedListNode<DelaunayTriangle> _0023_003DzEzv5_0024vo_003D, int _0023_003Dz3Ftsho0_003D)
	{
		foreach (int point in _0023_003DzEzv5_0024vo_003D.Value.points)
		{
			_0023_003Dzk98RESByZO6KwZuGTA_003D_003D[point]._0023_003DzDCjBZK4_003D = null;
			_0023_003Dzk98RESByZO6KwZuGTA_003D_003D[point]._0023_003DzOxKU6GM_003D = 0.0;
			if (point != _0023_003Dz3Ftsho0_003D)
			{
				_0023_003Dz3FWG2xGNeNNc3oC6ig_003D_003D.Add(point);
			}
		}
		_0023_003DzEzv5_0024vo_003D.Value.points.Clear();
	}

	private double _0023_003Dzn_jttcxAXmO7(IndexTriangle _0023_003DzwTeMRYA_003D)
	{
		double num = _0023_003Dzk98RESByZO6KwZuGTA_003D_003D[_0023_003DzwTeMRYA_003D.V1]._0023_003DzFuXfk4k_003D;
		double num2 = _0023_003Dzk98RESByZO6KwZuGTA_003D_003D[_0023_003DzwTeMRYA_003D.V1]._0023_003DzZ_0024Wvtoc_003D;
		double num3 = _0023_003Dzk98RESByZO6KwZuGTA_003D_003D[_0023_003DzwTeMRYA_003D.V2]._0023_003DzFuXfk4k_003D;
		double num4 = _0023_003Dzk98RESByZO6KwZuGTA_003D_003D[_0023_003DzwTeMRYA_003D.V2]._0023_003DzZ_0024Wvtoc_003D;
		double num5 = _0023_003Dzk98RESByZO6KwZuGTA_003D_003D[_0023_003DzwTeMRYA_003D.V3]._0023_003DzFuXfk4k_003D;
		double num6 = _0023_003Dzk98RESByZO6KwZuGTA_003D_003D[_0023_003DzwTeMRYA_003D.V3]._0023_003DzZ_0024Wvtoc_003D;
		return num * (num4 - num6) + num3 * (num6 - num2) + num5 * (num2 - num4);
	}

	private void _0023_003Dzq4m22jg_003D(long _0023_003DzBJFJHwk_003D, long _0023_003Dz40R7bAU_003D, LinkedList<IndexLine> _0023_003DzU3hosSAzkxO7, LinkedListNode<DelaunayTriangle> _0023_003DzUIa_00246i0_003D, int _0023_003DzfNi7d4A_003D, int _0023_003Dz437_00244ak_003D)
	{
		DelaunayTriangle value = _0023_003DzUIa_00246i0_003D.Value;
		value.visited = _0023_003Dzvv6HrWo_003D++;
		_0023_003DzRV5GhlIkprjwXRkNGMknXBOYrewR09oqf_lNIvRxwZpVBQ6mcQ_003D_003D _0023_003DzRV5GhlIkprjwXRkNGMknXBOYrewR09oqf_lNIvRxwZpVBQ6mcQ_003D_003D2 = _0023_003Dzk98RESByZO6KwZuGTA_003D_003D[value.V1];
		_0023_003DzRV5GhlIkprjwXRkNGMknXBOYrewR09oqf_lNIvRxwZpVBQ6mcQ_003D_003D _0023_003DzRV5GhlIkprjwXRkNGMknXBOYrewR09oqf_lNIvRxwZpVBQ6mcQ_003D_003D3 = _0023_003Dzk98RESByZO6KwZuGTA_003D_003D[value.V2];
		_0023_003DzRV5GhlIkprjwXRkNGMknXBOYrewR09oqf_lNIvRxwZpVBQ6mcQ_003D_003D _0023_003DzRV5GhlIkprjwXRkNGMknXBOYrewR09oqf_lNIvRxwZpVBQ6mcQ_003D_003D4 = _0023_003Dzk98RESByZO6KwZuGTA_003D_003D[value.V3];
		if (_0023_003DzZMh1kcHo8mkQ7Skys6V3plk_003D(_0023_003DzBJFJHwk_003D, _0023_003Dz40R7bAU_003D, _0023_003DzRV5GhlIkprjwXRkNGMknXBOYrewR09oqf_lNIvRxwZpVBQ6mcQ_003D_003D2._0023_003DzFuXfk4k_003D, _0023_003DzRV5GhlIkprjwXRkNGMknXBOYrewR09oqf_lNIvRxwZpVBQ6mcQ_003D_003D2._0023_003DzZ_0024Wvtoc_003D, _0023_003DzRV5GhlIkprjwXRkNGMknXBOYrewR09oqf_lNIvRxwZpVBQ6mcQ_003D_003D3._0023_003DzFuXfk4k_003D, _0023_003DzRV5GhlIkprjwXRkNGMknXBOYrewR09oqf_lNIvRxwZpVBQ6mcQ_003D_003D3._0023_003DzZ_0024Wvtoc_003D, _0023_003DzRV5GhlIkprjwXRkNGMknXBOYrewR09oqf_lNIvRxwZpVBQ6mcQ_003D_003D4._0023_003DzFuXfk4k_003D, _0023_003DzRV5GhlIkprjwXRkNGMknXBOYrewR09oqf_lNIvRxwZpVBQ6mcQ_003D_003D4._0023_003DzZ_0024Wvtoc_003D))
		{
			_0023_003DzJmw5altPzN6B(_0023_003DzBJFJHwk_003D, _0023_003Dz40R7bAU_003D, _0023_003DzU3hosSAzkxO7, _0023_003DzUIa_00246i0_003D, _0023_003DzfNi7d4A_003D, _0023_003Dz437_00244ak_003D);
		}
	}

	private LinkedListNode<DelaunayTriangle> _0023_003Dz1Li5KfggoZNN(int _0023_003DzffqPLNQ_003D, int _0023_003Dz5Azd7L8_003D, int _0023_003DzZ2irb9I_003D)
	{
		foreach (LinkedListNode<DelaunayTriangle> item in adjacency[_0023_003DzffqPLNQ_003D])
		{
			DelaunayTriangle value = item.Value;
			if ((value.V1 == _0023_003Dz5Azd7L8_003D || value.V2 == _0023_003Dz5Azd7L8_003D || value.V3 == _0023_003Dz5Azd7L8_003D) && value.V1 != _0023_003DzZ2irb9I_003D && value.V2 != _0023_003DzZ2irb9I_003D && value.V3 != _0023_003DzZ2irb9I_003D)
			{
				return item;
			}
		}
		foreach (LinkedListNode<DelaunayTriangle> item2 in adjacency[_0023_003Dz5Azd7L8_003D])
		{
			DelaunayTriangle value2 = item2.Value;
			if ((value2.V1 == _0023_003DzffqPLNQ_003D || value2.V2 == _0023_003DzffqPLNQ_003D || value2.V3 == _0023_003DzffqPLNQ_003D) && value2.V1 != _0023_003DzZ2irb9I_003D && value2.V2 != _0023_003DzZ2irb9I_003D && value2.V3 != _0023_003DzZ2irb9I_003D)
			{
				return item2;
			}
		}
		return null;
	}

	private void _0023_003DzJmw5altPzN6B(long _0023_003DzBJFJHwk_003D, long _0023_003Dz40R7bAU_003D, LinkedList<IndexLine> _0023_003DzU3hosSAzkxO7, LinkedListNode<DelaunayTriangle> _0023_003DzUIa_00246i0_003D, int _0023_003DzfNi7d4A_003D, int _0023_003Dz437_00244ak_003D)
	{
		DelaunayTriangle value = _0023_003DzUIa_00246i0_003D.Value;
		value.visited = _0023_003Dzvv6HrWo_003D++;
		IndexTriangle _0023_003DzwTeMRYA_003D = new IndexTriangle(value.V1, value.V2, _0023_003Dz437_00244ak_003D);
		IndexTriangle _0023_003DzwTeMRYA_003D2 = new IndexTriangle(value.V2, value.V3, _0023_003Dz437_00244ak_003D);
		IndexTriangle _0023_003DzwTeMRYA_003D3 = new IndexTriangle(value.V3, value.V1, _0023_003Dz437_00244ak_003D);
		IndexTriangle indexTriangle = null;
		double num = _0023_003Dzn_jttcxAXmO7(_0023_003DzwTeMRYA_003D);
		double num2 = _0023_003Dzn_jttcxAXmO7(_0023_003DzwTeMRYA_003D2);
		double num3 = _0023_003Dzn_jttcxAXmO7(_0023_003DzwTeMRYA_003D3);
		double value2 = 0.0;
		LinkedListNode<DelaunayTriangle> linkedListNode = null;
		if (num == 0.0)
		{
			linkedListNode = _0023_003Dz1Li5KfggoZNN(value.V1, value.V2, value.V3);
			if (linkedListNode != null)
			{
				DelaunayTriangle value3 = linkedListNode.Value;
				int num4 = ((value3.V1 != value.V1 && value3.V1 != value.V2) ? value3.V1 : ((value3.V2 == value.V1 || value3.V2 == value.V2) ? value3.V3 : value3.V2));
				_0023_003DzwTeMRYA_003D = new IndexTriangle(_0023_003Dz437_00244ak_003D, value.V1, num4);
				num = _0023_003Dzn_jttcxAXmO7(_0023_003DzwTeMRYA_003D);
				indexTriangle = new IndexTriangle(_0023_003Dz437_00244ak_003D, num4, value.V2);
				value2 = _0023_003Dzn_jttcxAXmO7(indexTriangle);
			}
		}
		if (num2 == 0.0)
		{
			linkedListNode = _0023_003Dz1Li5KfggoZNN(value.V2, value.V3, value.V1);
			if (linkedListNode != null)
			{
				DelaunayTriangle value4 = linkedListNode.Value;
				int num4 = ((value4.V1 != value.V2 && value4.V1 != value.V3) ? value4.V1 : ((value4.V2 == value.V2 || value4.V2 == value.V3) ? value4.V3 : value4.V2));
				_0023_003DzwTeMRYA_003D2 = new IndexTriangle(_0023_003Dz437_00244ak_003D, value.V2, num4);
				num2 = _0023_003Dzn_jttcxAXmO7(_0023_003DzwTeMRYA_003D2);
				indexTriangle = new IndexTriangle(_0023_003Dz437_00244ak_003D, num4, value.V3);
				value2 = _0023_003Dzn_jttcxAXmO7(indexTriangle);
			}
		}
		if (num3 == 0.0)
		{
			linkedListNode = _0023_003Dz1Li5KfggoZNN(value.V3, value.V1, value.V2);
			if (linkedListNode != null)
			{
				DelaunayTriangle value5 = linkedListNode.Value;
				int num4 = ((value5.V1 != value.V3 && value5.V1 != value.V1) ? value5.V1 : ((value5.V2 == value.V3 || value5.V2 == value.V1) ? value5.V3 : value5.V2));
				_0023_003DzwTeMRYA_003D3 = new IndexTriangle(_0023_003Dz437_00244ak_003D, value.V3, num4);
				num3 = _0023_003Dzn_jttcxAXmO7(_0023_003DzwTeMRYA_003D3);
				indexTriangle = new IndexTriangle(_0023_003Dz437_00244ak_003D, num4, value.V1);
				value2 = _0023_003Dzn_jttcxAXmO7(indexTriangle);
			}
		}
		double num5 = Math.Sign(num);
		double num6 = Math.Sign(num2);
		double num7 = Math.Sign(num3);
		double num8 = Math.Sign(value2);
		if (num5 + num6 + num7 + num8 >= -2.0)
		{
			_0023_003DzPCPLzWk_003D(value, _0023_003DzU3hosSAzkxO7);
			triangles.Remove(_0023_003DzUIa_00246i0_003D);
			_0023_003DzSjqHkNn6s9q7(_0023_003DzUIa_00246i0_003D, _0023_003Dz437_00244ak_003D);
			if (linkedListNode != null)
			{
				DelaunayTriangle value6 = linkedListNode.Value;
				_0023_003DzPCPLzWk_003D(value6, _0023_003DzU3hosSAzkxO7);
				triangles.Remove(linkedListNode);
				_0023_003DzSjqHkNn6s9q7(linkedListNode, _0023_003Dz437_00244ak_003D);
				adjacency[value6.V1].Remove(linkedListNode);
				adjacency[value6.V2].Remove(linkedListNode);
				adjacency[value6.V3].Remove(linkedListNode);
			}
			adjacency[value.V1].Remove(_0023_003DzUIa_00246i0_003D);
			adjacency[value.V2].Remove(_0023_003DzUIa_00246i0_003D);
			adjacency[value.V3].Remove(_0023_003DzUIa_00246i0_003D);
			int _0023_003Dz_0024QrwhVA_003D = _0023_003Dzvv6HrWo_003D;
			if (adjacency[value.V1].Count > 0)
			{
				_0023_003DzPdK_2Co_003D(_0023_003DzBJFJHwk_003D, _0023_003Dz40R7bAU_003D, value.V1, _0023_003DzU3hosSAzkxO7, _0023_003DzfNi7d4A_003D + 1, _0023_003Dz437_00244ak_003D, _0023_003Dz_0024QrwhVA_003D);
			}
			if (adjacency[value.V2].Count > 0)
			{
				_0023_003DzPdK_2Co_003D(_0023_003DzBJFJHwk_003D, _0023_003Dz40R7bAU_003D, value.V2, _0023_003DzU3hosSAzkxO7, _0023_003DzfNi7d4A_003D + 1, _0023_003Dz437_00244ak_003D, _0023_003Dz_0024QrwhVA_003D);
			}
			if (adjacency[value.V3].Count > 0)
			{
				_0023_003DzPdK_2Co_003D(_0023_003DzBJFJHwk_003D, _0023_003Dz40R7bAU_003D, value.V3, _0023_003DzU3hosSAzkxO7, _0023_003DzfNi7d4A_003D + 1, _0023_003Dz437_00244ak_003D, _0023_003Dz_0024QrwhVA_003D);
			}
		}
	}

	private void _0023_003DzPCPLzWk_003D(DelaunayTriangle _0023_003Dz3Ftsho0_003D, LinkedList<IndexLine> _0023_003DzU3hosSAzkxO7)
	{
		bool flag = false;
		bool flag2 = false;
		bool flag3 = false;
		LinkedListNode<IndexLine> linkedListNode = _0023_003DzU3hosSAzkxO7.First;
		while (linkedListNode != null && (!flag || !flag2 || !flag3))
		{
			IndexLine value = linkedListNode.Value;
			LinkedListNode<IndexLine> linkedListNode2 = null;
			if (!flag && value.V1 == _0023_003Dz3Ftsho0_003D.V2 && value.V2 == _0023_003Dz3Ftsho0_003D.V1)
			{
				flag = true;
				linkedListNode2 = linkedListNode;
			}
			else if (!flag2 && value.V1 == _0023_003Dz3Ftsho0_003D.V3 && value.V2 == _0023_003Dz3Ftsho0_003D.V2)
			{
				flag2 = true;
				linkedListNode2 = linkedListNode;
			}
			else if (!flag3 && value.V1 == _0023_003Dz3Ftsho0_003D.V1 && value.V2 == _0023_003Dz3Ftsho0_003D.V3)
			{
				flag3 = true;
				linkedListNode2 = linkedListNode;
			}
			linkedListNode = linkedListNode.Next;
			if (linkedListNode2 != null)
			{
				_0023_003DzU3hosSAzkxO7.Remove(linkedListNode2);
			}
		}
		if (!flag)
		{
			_0023_003DzU3hosSAzkxO7.AddLast(new _0023_003Dz17deN5RpyVgyaMlfHQ_003D_003D(_0023_003Dz3Ftsho0_003D.V1, _0023_003Dz3Ftsho0_003D.V2, _0023_003Dz3Ftsho0_003D));
		}
		if (!flag2)
		{
			_0023_003DzU3hosSAzkxO7.AddLast(new _0023_003Dz17deN5RpyVgyaMlfHQ_003D_003D(_0023_003Dz3Ftsho0_003D.V2, _0023_003Dz3Ftsho0_003D.V3, _0023_003Dz3Ftsho0_003D));
		}
		if (!flag3)
		{
			_0023_003DzU3hosSAzkxO7.AddLast(new _0023_003Dz17deN5RpyVgyaMlfHQ_003D_003D(_0023_003Dz3Ftsho0_003D.V3, _0023_003Dz3Ftsho0_003D.V1, _0023_003Dz3Ftsho0_003D));
		}
	}

	private void _0023_003DzPdK_2Co_003D(long _0023_003DzBJFJHwk_003D, long _0023_003Dz40R7bAU_003D, int _0023_003DzqDTr2JY_003D, LinkedList<IndexLine> _0023_003DzU3hosSAzkxO7, int _0023_003DzfNi7d4A_003D, int _0023_003Dz437_00244ak_003D, int _0023_003Dz_0024QrwhVA_003D)
	{
		LinkedListNode<LinkedListNode<DelaunayTriangle>> linkedListNode = adjacency[_0023_003DzqDTr2JY_003D].First;
		do
		{
			if (linkedListNode.Value.Value.visited < _0023_003Dz_0024QrwhVA_003D)
			{
				linkedListNode.Value.Value.visited = _0023_003Dz_0024QrwhVA_003D;
				_0023_003Dzq4m22jg_003D(_0023_003DzBJFJHwk_003D, _0023_003Dz40R7bAU_003D, _0023_003DzU3hosSAzkxO7, linkedListNode.Value, _0023_003DzfNi7d4A_003D, _0023_003Dz437_00244ak_003D);
			}
			linkedListNode = linkedListNode.Next;
		}
		while (linkedListNode != null);
	}

	private bool _0023_003DzXIeu2Xg_003D(Point3D _0023_003DzB68dg9Q_003D)
	{
		bool flag = false;
		for (int i = 0; i < loops.Length; i++)
		{
			Point3D[] polygon = loops[i];
			flag ^= Utility.PointInPolygon(_0023_003DzB68dg9Q_003D, polygon);
		}
		return flag;
	}

	private static bool _0023_003DzZMh1kcHo8mkQ7Skys6V3plk_003D(double _0023_003DzaQ_y9PQ_003D, double _0023_003DzD47R4_0_003D, double _0023_003DzC82wi0s_003D, double _0023_003Dzbo_lp2U_003D, double _0023_003DzWK94pPk_003D, double _0023_003DzEYwU9Dk_003D, double _0023_003Dzz0HVFKY_003D, double _0023_003DzvMKCVbs_003D)
	{
		double num = _0023_003DzC82wi0s_003D - _0023_003DzaQ_y9PQ_003D;
		double num2 = _0023_003DzWK94pPk_003D - _0023_003DzaQ_y9PQ_003D;
		double num3 = _0023_003Dzz0HVFKY_003D - _0023_003DzaQ_y9PQ_003D;
		double num4 = _0023_003Dzbo_lp2U_003D - _0023_003DzD47R4_0_003D;
		double num5 = _0023_003DzEYwU9Dk_003D - _0023_003DzD47R4_0_003D;
		double num6 = _0023_003DzvMKCVbs_003D - _0023_003DzD47R4_0_003D;
		double num7 = _0023_003DzaQ_y9PQ_003D * _0023_003DzaQ_y9PQ_003D;
		double num8 = _0023_003DzD47R4_0_003D * _0023_003DzD47R4_0_003D;
		double num9 = _0023_003DzC82wi0s_003D * _0023_003DzC82wi0s_003D - num7 + (_0023_003Dzbo_lp2U_003D * _0023_003Dzbo_lp2U_003D - num8);
		double num10 = _0023_003DzWK94pPk_003D * _0023_003DzWK94pPk_003D - num7 + (_0023_003DzEYwU9Dk_003D * _0023_003DzEYwU9Dk_003D - num8);
		double num11 = _0023_003Dzz0HVFKY_003D * _0023_003Dzz0HVFKY_003D - num7 + (_0023_003DzvMKCVbs_003D * _0023_003DzvMKCVbs_003D - num8);
		return num * (num5 * num11 - num6 * num10) - num4 * (num2 * num11 - num3 * num10) + num9 * (num2 * num6 - num3 * num5) > 0.0;
	}

	private void _0023_003DztGdcVOA_003D(Surface _0023_003DzF7GfYSI_003D, SizesOnCurve[][] _0023_003Dz14lzA48_003D, bool _0023_003DzFwalihjMriJGyFaGGg_003D_003D, MaterialKeyedCollection _0023_003DzhCnRkiIFA4RATyn_0024Lg_003D_003D)
	{
		PolyRegion2D polyRegion2D = _0023_003DzF7GfYSI_003D._0023_003DzhQpzdmkVcMiA(_0023_003Dz14lzA48_003D, this);
		Surface.Reparametrize(_0023_003DzF7GfYSI_003D, out var uScale, out var vScale, out var _);
		Scaling t = new Scaling(uScale, vScale);
		foreach (Polygon2D contour in polyRegion2D.ContourList)
		{
			contour.TransformBy(t);
		}
		_0023_003Dz0ed6dmFMTxDQWwqeBg_003D_003D = _0023_003DzFwalihjMriJGyFaGGg_003D_003D;
		if (!string.IsNullOrEmpty(_0023_003DzF7GfYSI_003D.MaterialName) && _0023_003DzhCnRkiIFA4RATyn_0024Lg_003D_003D != null)
		{
			_0023_003Dzv2Pxl9dvjF66aL2_0024_A_003D_003D = _0023_003DzhCnRkiIFA4RATyn_0024Lg_003D_003D[_0023_003DzF7GfYSI_003D.MaterialName];
		}
		_0023_003DztGdcVOA_003D(_0023_003DzF7GfYSI_003D, polyRegion2D.ContourList, uScale, vScale);
	}

	private void _0023_003DztGdcVOA_003D(Surface _0023_003DzF7GfYSI_003D, IList<Polygon2D> _0023_003Dzzh09U4K0Sr5xS0I14A_003D_003D, double _0023_003Dz2AZ_kpw_003D, double _0023_003Dza2Pq9PQ_003D)
	{
		_0023_003Dz_xHzQQk_003D = new _0023_003DzQPpqutXPAMxkvsO0YWAcAYUJI4mwt8FtTTdI2Zc_003D(_0023_003DzF7GfYSI_003D, _0023_003Dz2AZ_kpw_003D, _0023_003Dza2Pq9PQ_003D);
		_0023_003DzlCJ6DabnbVnjzDbCNIb5mv0_003D = _0023_003DzF7GfYSI_003D.ControlBoundingBox().Diagonal * Utility._0023_003DzxhnLabVjXjPg;
		double[][] array = _0023_003Dz966ZJtirWumH(_0023_003Dzzh09U4K0Sr5xS0I14A_003D_003D, Math.PI / 4.0);
		Point3D[] array2 = null;
		Point3D[][] array3 = new Point3D[_0023_003Dzzh09U4K0Sr5xS0I14A_003D_003D.Count - 1][];
		for (int i = 0; i < _0023_003Dzzh09U4K0Sr5xS0I14A_003D_003D.Count; i++)
		{
			Point2D[] points = _0023_003Dzzh09U4K0Sr5xS0I14A_003D_003D[i].Points;
			Point3D[] array4 = new Point3D[points.Length];
			for (int j = 0; j < points.Length; j++)
			{
				Point3D point3D = points[j] as Point3D;
				if (point3D == null)
				{
					point3D = new Point3D(points[j].X, points[j].Y);
				}
				array4[j] = point3D;
			}
			if (i == 0)
			{
				array2 = array4;
			}
			else
			{
				array3[i - 1] = array4;
			}
		}
		_0023_003DzaEqDYasb0H3yVAOD0w_003D_003D(array2, array[0]);
		for (int k = 0; k < array3.Length; k++)
		{
			_0023_003DzaEqDYasb0H3yVAOD0w_003D_003D(array3[k], array[k + 1]);
		}
		ProcessContours(null, array2, array3, null, checkDir: true, array);
	}

	private void _0023_003DzaEqDYasb0H3yVAOD0w_003D_003D(Point3D[] _0023_003Dz06A5WivSSyUp, double[] _0023_003DzU7WRl9I_003D)
	{
		double length = _0023_003Dz_xHzQQk_003D._0023_003Dzc2sIpYmbrSSe().Length;
		double length2 = _0023_003Dz_xHzQQk_003D._0023_003Dz6I0VonsHpxSm().Length;
		double num = Math.Sqrt(length * length + length2 * length2) * Utility._0023_003DzheSR8QM7q9ya;
		for (int i = 0; i < _0023_003Dz06A5WivSSyUp.Length - 1; i++)
		{
			Segment2D segment2D = new Segment2D(_0023_003Dz06A5WivSSyUp[i], _0023_003Dz06A5WivSSyUp[i + 1]);
			Segment3D segment3D = new Segment3D(_0023_003DzMEXpAaVkFlpl(segment2D.P0), _0023_003DzMEXpAaVkFlpl(segment2D.P1));
			if (segment2D.Length < num || (!_0023_003Dz_xHzQQk_003D._0023_003DzgXk8Ru_iJQUJ(segment3D.P0, _0023_003DzlCJ6DabnbVnjzDbCNIb5mv0_003D, out var _) && segment3D.Length < _0023_003DzlCJ6DabnbVnjzDbCNIb5mv0_003D))
			{
				throw new EyeshotException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302991458));
			}
			double num2 = Math.Min(_0023_003DzU7WRl9I_003D[i], _0023_003DzU7WRl9I_003D[i + 1]);
			Point3D point3D = _0023_003DzMEXpAaVkFlpl(segment2D.PointAt(0.5));
			if (point3D.DistanceTo(segment3D.P0) >= num2 || point3D.DistanceTo(segment3D.P1) >= num2)
			{
				throw new EyeshotException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302991400));
			}
		}
	}

	private double[][] _0023_003Dz966ZJtirWumH(IList<Polygon2D> _0023_003DzLGMvY_0024rw9syHNAZu5g_003D_003D, double _0023_003DzJZgKl_0024PuDaYi)
	{
		double[][] array = new double[_0023_003DzLGMvY_0024rw9syHNAZu5g_003D_003D.Count][];
		for (int i = 0; i < _0023_003DzLGMvY_0024rw9syHNAZu5g_003D_003D.Count; i++)
		{
			Point3D[] points = _0023_003DzLGMvY_0024rw9syHNAZu5g_003D_003D[i].Points.Select(_0023_003DzMEXpAaVkFlpl).ToArray();
			array[i] = SizePerPoint(points, _0023_003DzlCJ6DabnbVnjzDbCNIb5mv0_003D, _0023_003DzJZgKl_0024PuDaYi, _0023_003DzmlSoH_d5_pgF);
		}
		return array;
	}

	public static double[] SizePerPoint(Point3D[] points, double tolerance, double minAngle = Math.PI / 4.0, double minimumSize = -1.0)
	{
		if (points.Last().DistanceTo(points.First()) > tolerance)
		{
			throw new ArgumentException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302992210));
		}
		if (points.Length < 3)
		{
			throw new ArgumentException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302992164));
		}
		double num = 1.0 / (2.0 * Math.Cos(minAngle));
		double[] array = new double[points.Length];
		Point3D point3D = points[^2];
		Point3D point3D2 = points[0];
		for (int i = 0; i < points.Length - 1; i++)
		{
			int num2 = (i + 1) % (points.Length - 1);
			Point3D point3D3 = point3D2;
			point3D2 = points[num2];
			if (point3D3.DistanceTo(point3D) < tolerance || point3D3.DistanceTo(point3D2) < tolerance)
			{
				array[i] = -1.0;
				point3D = point3D3;
				continue;
			}
			double num3 = Math.Max(point3D.DistanceTo(point3D3), minimumSize);
			double num4 = Math.Max(point3D3.DistanceTo(point3D2), minimumSize);
			double num5 = Math.Max(num3, num4) * num;
			double num6 = (num3 + num4) / 2.0;
			if (num6 < num5)
			{
				num6 = num5;
			}
			array[i] = num6;
			point3D = point3D3;
		}
		array[points.Length - 1] = array[0];
		for (int j = 0; j < array.Length; j++)
		{
			int num7 = j;
			int num8 = j;
			while (array[num7] < 0.0)
			{
				num7 = (array.Length + num7 - 1) % array.Length;
				if (num7 == j)
				{
					throw new Exception(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302992384));
				}
			}
			while (array[num8] < 0.0)
			{
				num8 = (num8 + 1) % array.Length;
				if (num8 == j)
				{
					throw new Exception(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302992384));
				}
			}
			if (num7 != num8)
			{
				array[j] = (array[num7] + array[num8]) / 2.0;
			}
		}
		return array;
	}

	private bool _0023_003Dz5bTQ1u9UVidehQ86Hw_003D_003D(IProgress<ProgressChangedEventArgs> _0023_003DzmHS7frs_003D, CancellationToken _0023_003Dzjvn7P10_003D)
	{
		if (!TriangulateInternal(_0023_003DzmHS7frs_003D, _0023_003Dzjvn7P10_003D))
		{
			return false;
		}
		if (triangles.First == null)
		{
			return false;
		}
		if (!_0023_003Dz8Er3zyI46rYZCZQ6qmFrSe0_003D(_0023_003DzmHS7frs_003D, _0023_003Dzjvn7P10_003D))
		{
			return false;
		}
		foreach (_0023_003DzaNdK2SNh78xbyVoyjA_003D_003D item in _0023_003Dzk98RESByZO6KwZuGTA_003D_003D)
		{
			_0023_003DzCmPmvf8_003D(item);
		}
		_0023_003DzSFv50Wsoag5Gw_vk8tNvcl7ZZreiri9gzg_003D_003D _0023_003DzSFv50Wsoag5Gw_vk8tNvcl7ZZreiri9gzg_003D_003D2 = new _0023_003DzSFv50Wsoag5Gw_vk8tNvcl7ZZreiri9gzg_003D_003D(_0023_003Dzk98RESByZO6KwZuGTA_003D_003D.Select(_0023_003Dz2IEmqow_003D._0023_003DzJ5g3Rwo_003D._0023_003DzJAj1rOHWIfSovQBLCqHgCZBR0fx9ur5fjA_003D_003D).ToArray(), triangles.Cast<IndexTriangle>().ToArray());
		_0023_003DziJZSaHfJ_0024N9x(_0023_003DzSFv50Wsoag5Gw_vk8tNvcl7ZZreiri9gzg_003D_003D2);
		if (!_0023_003DzEvi_vHGD2CnDwwfABA_003D_003D(_0023_003DzSFv50Wsoag5Gw_vk8tNvcl7ZZreiri9gzg_003D_003D2, _0023_003DzmHS7frs_003D, _0023_003Dzjvn7P10_003D))
		{
			return false;
		}
		_0023_003DzSFv50Wsoag5Gw_vk8tNvcl7ZZreiri9gzg_003D_003D2.Apply(out var vertexMap, out var _, updateData: false);
		vertexMap.Map(_0023_003Dzk98RESByZO6KwZuGTA_003D_003D);
		triangles = new LinkedList<DelaunayTriangle>();
		IndexTriangle[] array = _0023_003DzSFv50Wsoag5Gw_vk8tNvcl7ZZreiri9gzg_003D_003D2.Triangles;
		foreach (IndexTriangle indexTriangle in array)
		{
			triangles.AddLast(new DelaunayTriangle(indexTriangle.V1, indexTriangle.V2, indexTriangle.V3));
		}
		return true;
	}

	private void _0023_003DziJZSaHfJ_0024N9x(_0023_003DzSFv50Wsoag5Gw_vk8tNvcl7ZZreiri9gzg_003D_003D _0023_003DzkpDLfk0_003D)
	{
		bool flag = true;
		while (flag)
		{
			bool flag2 = false;
			while (_0023_003DzLLRCUS5usPt5EFPRLQ_003D_003D(_0023_003DzkpDLfk0_003D, null))
			{
				flag2 = true;
			}
			bool flag3 = _0023_003Dz46iWwIQ_003D(_0023_003DzkpDLfk0_003D, (_0023_003DzNMAnai2Cws9l)0, Math.PI / 2.0);
			bool num = _0023_003DzEIHMNTj2TktX(_0023_003DzkpDLfk0_003D);
			_0023_003DzhMRyqCPtCkg0najGtg_003D_003D(_0023_003DzkpDLfk0_003D, SmoothingMode);
			flag = num || flag3 || flag2;
			if (flag)
			{
				_0023_003Dz46iWwIQ_003D(_0023_003DzkpDLfk0_003D, (_0023_003DzNMAnai2Cws9l)1, Math.PI / 2.0);
			}
		}
		_0023_003DzLLRCUS5usPt5EFPRLQ_003D_003D(_0023_003DzkpDLfk0_003D, Math.PI / 6.0);
	}

	private _0023_003DzaNdK2SNh78xbyVoyjA_003D_003D _0023_003Dz6zQrAVStav9O(_0023_003DzRV5GhlIkprjwXRkNGMknXBOYrewR09oqf_lNIvRxwZpVBQ6mcQ_003D_003D _0023_003DzFj_0024IqDQ_003D, _0023_003DzRV5GhlIkprjwXRkNGMknXBOYrewR09oqf_lNIvRxwZpVBQ6mcQ_003D_003D _0023_003DzjdeMMkk_003D)
	{
		_0023_003DzaNdK2SNh78xbyVoyjA_003D_003D _0023_003DzaNdK2SNh78xbyVoyjA_003D_003D2 = new _0023_003DzaNdK2SNh78xbyVoyjA_003D_003D(Point3D.MidPoint((Point3D)_0023_003DzFj_0024IqDQ_003D._0023_003DzIHt45I8_003D, (Point3D)_0023_003DzjdeMMkk_003D._0023_003DzIHt45I8_003D))
		{
			_0023_003Dz_0024pfZB54_003D = (_0023_003DzFj_0024IqDQ_003D._0023_003Dz_0024pfZB54_003D + _0023_003DzjdeMMkk_003D._0023_003Dz_0024pfZB54_003D) / 2.0
		};
		_0023_003DzCmPmvf8_003D(_0023_003DzaNdK2SNh78xbyVoyjA_003D_003D2);
		return _0023_003DzaNdK2SNh78xbyVoyjA_003D_003D2;
	}

	private bool _0023_003DzEIHMNTj2TktX(_0023_003DzSFv50Wsoag5Gw_vk8tNvcl7ZZreiri9gzg_003D_003D _0023_003DzKpJk9wk_003D)
	{
		bool result = false;
		Random _0023_003Dzlraf5vU_003D = new Random(1);
		foreach (int item in Utility._0023_003Dzv1eJ6yKpWyWB(_0023_003Dz91HGJEsGIzcV, _0023_003DzKpJk9wk_003D.SharedEdges.Length, _0023_003Dzlraf5vU_003D))
		{
			LinkedListNode<SharedEdge> linkedListNode = _0023_003DzKpJk9wk_003D.SharedEdges[item].First;
			while (linkedListNode != null)
			{
				SharedEdge value = linkedListNode.Value;
				linkedListNode = linkedListNode.Next;
				if (value.V2 < _0023_003Dz91HGJEsGIzcV)
				{
					continue;
				}
				_0023_003DzaNdK2SNh78xbyVoyjA_003D_003D _0023_003DzaNdK2SNh78xbyVoyjA_003D_003D2 = _0023_003Dz6zQrAVStav9O(_0023_003Dzk98RESByZO6KwZuGTA_003D_003D[item], _0023_003Dzk98RESByZO6KwZuGTA_003D_003D[value.V2]);
				int[] _0023_003DzzRR2S30_003D = _0023_003DzKpJk9wk_003D.Cell(item);
				int[] _0023_003DzzRR2S30_003D2 = _0023_003DzKpJk9wk_003D.Cell(value.V2);
				int[] _0023_003DzzRR2S30_003D3 = _0023_003DzKpJk9wk_003D.Cell(item, value.V2);
				if (_0023_003DzKpJk9wk_003D._0023_003DzFPEj_mZrLVDn(_0023_003DzaNdK2SNh78xbyVoyjA_003D_003D2._0023_003DzIHt45I8_003D, _0023_003DzzRR2S30_003D3))
				{
					int[] array = MeshEditor.Quad(_0023_003DzKpJk9wk_003D.Triangles[value.Mum], _0023_003DzKpJk9wk_003D.Triangles[value.Dad], item, value.V2);
					int _0023_003Dzi8IjSk4_003D = array[1];
					int _0023_003Dzg44zAiE_003D = array[3];
					if (_0023_003DzEkzsCJBf5SWplCTejw_003D_003D(item, value.V2, _0023_003Dzi8IjSk4_003D, _0023_003Dzg44zAiE_003D, _0023_003DzzRR2S30_003D, _0023_003DzaNdK2SNh78xbyVoyjA_003D_003D2) && _0023_003DzEkzsCJBf5SWplCTejw_003D_003D(value.V2, item, _0023_003Dzi8IjSk4_003D, _0023_003Dzg44zAiE_003D, _0023_003DzzRR2S30_003D2, _0023_003DzaNdK2SNh78xbyVoyjA_003D_003D2) && _0023_003DzKpJk9wk_003D.Collapse(item, value, (Point3D)_0023_003DzaNdK2SNh78xbyVoyjA_003D_003D2._0023_003DzIHt45I8_003D))
					{
						_0023_003Dzk98RESByZO6KwZuGTA_003D_003D[item] = _0023_003DzaNdK2SNh78xbyVoyjA_003D_003D2;
						_0023_003Dzk98RESByZO6KwZuGTA_003D_003D[value.V2] = null;
						result = true;
					}
				}
			}
		}
		return result;
	}

	private bool _0023_003DzEkzsCJBf5SWplCTejw_003D_003D(int _0023_003DzffqPLNQ_003D, int _0023_003Dz5Azd7L8_003D, int _0023_003Dzi8IjSk4_003D, int _0023_003Dzg44zAiE_003D, int[] _0023_003DzzRR2S30_003D, _0023_003DzRV5GhlIkprjwXRkNGMknXBOYrewR09oqf_lNIvRxwZpVBQ6mcQ_003D_003D _0023_003DzaA_FhnNUXoi7)
	{
		double num = 0.0;
		double num2 = 0.0;
		foreach (int num3 in _0023_003DzzRR2S30_003D)
		{
			if (num3 != _0023_003Dz5Azd7L8_003D && num3 != _0023_003Dzi8IjSk4_003D && num3 != _0023_003Dzg44zAiE_003D)
			{
				double num4 = _0023_003Dz2IIjOuI_003D(_0023_003Dzk98RESByZO6KwZuGTA_003D_003D[_0023_003DzffqPLNQ_003D], _0023_003Dzk98RESByZO6KwZuGTA_003D_003D[num3]);
				double num5 = _0023_003Dz2IIjOuI_003D(_0023_003Dzk98RESByZO6KwZuGTA_003D_003D[num3], _0023_003DzaA_FhnNUXoi7);
				if (num5 * 0.9 > num4)
				{
					return false;
				}
				num += num4;
				num2 += num5;
			}
		}
		if (num2 > num)
		{
			return false;
		}
		return true;
	}

	private bool _0023_003DzLLRCUS5usPt5EFPRLQ_003D_003D(_0023_003DzSFv50Wsoag5Gw_vk8tNvcl7ZZreiri9gzg_003D_003D _0023_003DzKpJk9wk_003D, double? _0023_003Dz0mZ4_0024fFWxsTX)
	{
		bool result = false;
		for (int i = _0023_003Dz91HGJEsGIzcV; i < _0023_003DzKpJk9wk_003D.Vertices.Length; i++)
		{
			if (_0023_003DzKpJk9wk_003D.IsVertexDead(i))
			{
				continue;
			}
			double _0023_003Dz_0024pfZB54_003D = _0023_003Dzk98RESByZO6KwZuGTA_003D_003D[i]._0023_003Dz_0024pfZB54_003D;
			int[] quad;
			if (_0023_003DzKpJk9wk_003D.Dissolvable3(i, out var v, out var v2, out var v3))
			{
				if (!((_0023_003Dzk98RESByZO6KwZuGTA_003D_003D[i]._0023_003Dzyjwk8PdbSXxQ.DistanceTo(_0023_003Dzk98RESByZO6KwZuGTA_003D_003D[v]._0023_003Dzyjwk8PdbSXxQ) + _0023_003Dzk98RESByZO6KwZuGTA_003D_003D[i]._0023_003Dzyjwk8PdbSXxQ.DistanceTo(_0023_003Dzk98RESByZO6KwZuGTA_003D_003D[v2]._0023_003Dzyjwk8PdbSXxQ) + _0023_003Dzk98RESByZO6KwZuGTA_003D_003D[i]._0023_003Dzyjwk8PdbSXxQ.DistanceTo(_0023_003Dzk98RESByZO6KwZuGTA_003D_003D[v3]._0023_003Dzyjwk8PdbSXxQ)) / _0023_003Dz_0024pfZB54_003D > 3.0))
				{
					_0023_003DzKpJk9wk_003D.Dissolve3(i);
					result = true;
				}
			}
			else if (_0023_003DzKpJk9wk_003D.Dissolvable4(i, out quad) && _0023_003DzS4odsNXSyeZknHaOCwQo6Pc_003D(i, quad, _0023_003DzKpJk9wk_003D) && _0023_003DzPgZ4R5eJ9gnWPv7j7Q_003D_003D(i, quad, _0023_003Dz0mZ4_0024fFWxsTX))
			{
				_0023_003DzKpJk9wk_003D.Dissolve4(i);
				result = true;
			}
		}
		return result;
	}

	private bool _0023_003DzS4odsNXSyeZknHaOCwQo6Pc_003D(int _0023_003Dz437_00244ak_003D, int[] _0023_003DzzRR2S30_003D, _0023_003DzSFv50Wsoag5Gw_vk8tNvcl7ZZreiri9gzg_003D_003D _0023_003DzKpJk9wk_003D)
	{
		if (!_0023_003DzKpJk9wk_003D._0023_003DzFPEj_mZrLVDn(_0023_003Dz437_00244ak_003D, _0023_003DzzRR2S30_003D))
		{
			return false;
		}
		if (!_0023_003DzKpJk9wk_003D._0023_003Dzl3Q_0024_0024QA_003D(_0023_003DzzRR2S30_003D[0], _0023_003DzzRR2S30_003D[1], _0023_003DzzRR2S30_003D[2]))
		{
			return false;
		}
		if (!_0023_003DzKpJk9wk_003D._0023_003Dzl3Q_0024_0024QA_003D(_0023_003DzzRR2S30_003D[2], _0023_003DzzRR2S30_003D[3], _0023_003DzzRR2S30_003D[0]))
		{
			return false;
		}
		return true;
	}

	private bool _0023_003DzPgZ4R5eJ9gnWPv7j7Q_003D_003D(int _0023_003DzkEYxO1SuR1Kw, int[] _0023_003DzzRR2S30_003D, double? _0023_003Dz0mZ4_0024fFWxsTX)
	{
		if (_0023_003Dz0mZ4_0024fFWxsTX.HasValue)
		{
			Vector3D u = _0023_003Dz9T2qChw_003D(_0023_003DzzRR2S30_003D[0], _0023_003DzzRR2S30_003D[1], _0023_003DzkEYxO1SuR1Kw);
			Vector3D v = _0023_003Dz9T2qChw_003D(_0023_003DzzRR2S30_003D[2], _0023_003DzzRR2S30_003D[3], _0023_003DzkEYxO1SuR1Kw);
			return Vector3D.AngleBetween(u, v) > _0023_003Dz0mZ4_0024fFWxsTX.Value;
		}
		double num = _0023_003DzQXPy7rY_003D(_0023_003DzkEYxO1SuR1Kw, _0023_003DzzRR2S30_003D) / 4.0;
		double num2 = _0023_003Dz2IIjOuI_003D(_0023_003Dzk98RESByZO6KwZuGTA_003D_003D[_0023_003DzzRR2S30_003D[0]], _0023_003Dzk98RESByZO6KwZuGTA_003D_003D[_0023_003DzzRR2S30_003D[2]]);
		double num3 = _0023_003Dz2IIjOuI_003D(_0023_003Dzk98RESByZO6KwZuGTA_003D_003D[_0023_003DzzRR2S30_003D[1]], _0023_003Dzk98RESByZO6KwZuGTA_003D_003D[_0023_003DzzRR2S30_003D[3]]);
		if (!(num2 <= num))
		{
			return num3 <= num;
		}
		return true;
	}

	private bool _0023_003Dz46iWwIQ_003D(_0023_003DzSFv50Wsoag5Gw_vk8tNvcl7ZZreiri9gzg_003D_003D _0023_003DzKpJk9wk_003D, _0023_003DzNMAnai2Cws9l _0023_003DznXXM9vk_003D, double _0023_003Dz0mZ4_0024fFWxsTX)
	{
		bool result = false;
		for (int i = 0; i < _0023_003DzKpJk9wk_003D.SharedEdges.Length; i++)
		{
			LinkedListNode<SharedEdge> linkedListNode = _0023_003DzKpJk9wk_003D.SharedEdges[i].First;
			while (linkedListNode != null)
			{
				SharedEdge value = linkedListNode.Value;
				linkedListNode = linkedListNode.Next;
				if (_0023_003DzKpJk9wk_003D._0023_003Dz3Wlh2oaz6fuw(i, value, out var _0023_003DzCjKvDZD851nk) && !(_0023_003DznTraai60KiIt(new int[4]
				{
					_0023_003DzCjKvDZD851nk[1],
					_0023_003DzCjKvDZD851nk[2],
					_0023_003DzCjKvDZD851nk[3],
					_0023_003DzCjKvDZD851nk[0]
				}) > _0023_003Dz0mZ4_0024fFWxsTX) && _0023_003DzgowBLL9B26j6(_0023_003DzKpJk9wk_003D, _0023_003DzCjKvDZD851nk, i, value, _0023_003DznXXM9vk_003D))
				{
					_0023_003DzKpJk9wk_003D.Flip(i, value);
					result = true;
				}
			}
		}
		return result;
	}

	private bool _0023_003DzgowBLL9B26j6(_0023_003DzSFv50Wsoag5Gw_vk8tNvcl7ZZreiri9gzg_003D_003D _0023_003DzKpJk9wk_003D, int[] _0023_003DzCjKvDZD851nk, int _0023_003DzffqPLNQ_003D, SharedEdge _0023_003DzTx2aqr8_003D, _0023_003DzNMAnai2Cws9l _0023_003DznXXM9vk_003D)
	{
		switch (_0023_003DznXXM9vk_003D)
		{
		case (_0023_003DzNMAnai2Cws9l)0:
		{
			double num = _0023_003Dz8DKq4APig_W1(new int[4]
			{
				_0023_003DzCjKvDZD851nk[0],
				_0023_003DzCjKvDZD851nk[1],
				_0023_003DzCjKvDZD851nk[2],
				_0023_003DzCjKvDZD851nk[3]
			});
			return _0023_003Dz8DKq4APig_W1(new int[4]
			{
				_0023_003DzCjKvDZD851nk[1],
				_0023_003DzCjKvDZD851nk[2],
				_0023_003DzCjKvDZD851nk[3],
				_0023_003DzCjKvDZD851nk[0]
			}) > num;
		}
		case (_0023_003DzNMAnai2Cws9l)1:
		{
			int[] quad;
			return (!_0023_003DzKpJk9wk_003D.Dissolvable4(_0023_003DzffqPLNQ_003D, out quad) && !_0023_003DzKpJk9wk_003D.Dissolvable4(_0023_003DzTx2aqr8_003D.V2, out quad)) & (_0023_003DzibmU43C0njzF(_0023_003DzffqPLNQ_003D, _0023_003DzTx2aqr8_003D.V2, _0023_003DzKpJk9wk_003D) || _0023_003DzibmU43C0njzF(_0023_003DzTx2aqr8_003D.V2, _0023_003DzffqPLNQ_003D, _0023_003DzKpJk9wk_003D));
		}
		default:
			throw new NotImplementedException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302992337));
		}
	}

	private bool _0023_003DzibmU43C0njzF(int _0023_003DzffqPLNQ_003D, int _0023_003Dz5Azd7L8_003D, _0023_003DzSFv50Wsoag5Gw_vk8tNvcl7ZZreiri9gzg_003D_003D _0023_003DzKpJk9wk_003D)
	{
		int[] array = _0023_003DzKpJk9wk_003D.Cell(_0023_003DzffqPLNQ_003D);
		if (array.Length != 5)
		{
			return false;
		}
		int[] array2 = new int[4];
		int num = 0;
		int[] array3 = array;
		foreach (int num2 in array3)
		{
			if (num2 != _0023_003Dz5Azd7L8_003D)
			{
				array2[num++] = num2;
			}
		}
		if (_0023_003DzS4odsNXSyeZknHaOCwQo6Pc_003D(_0023_003DzffqPLNQ_003D, array2, _0023_003DzKpJk9wk_003D))
		{
			return _0023_003DzPgZ4R5eJ9gnWPv7j7Q_003D_003D(_0023_003DzffqPLNQ_003D, array2, null);
		}
		return false;
	}

	private double _0023_003Dz8DKq4APig_W1(int[] _0023_003DzzRR2S30_003D)
	{
		double num = _0023_003DzgrFrLHUatf4J(_0023_003DzzRR2S30_003D[0], _0023_003DzzRR2S30_003D[1], _0023_003DzzRR2S30_003D[2]);
		double num2 = _0023_003DzgrFrLHUatf4J(_0023_003DzzRR2S30_003D[2], _0023_003DzzRR2S30_003D[3], _0023_003DzzRR2S30_003D[0]);
		return (num + num2) / 2.0;
	}

	private double _0023_003DzgrFrLHUatf4J(int _0023_003DzffqPLNQ_003D, int _0023_003Dz5Azd7L8_003D, int _0023_003DzZe6oCrQ_003D)
	{
		return Triangle.Quality(_0023_003Dzk98RESByZO6KwZuGTA_003D_003D[_0023_003DzffqPLNQ_003D]._0023_003Dzyjwk8PdbSXxQ, _0023_003Dzk98RESByZO6KwZuGTA_003D_003D[_0023_003Dz5Azd7L8_003D]._0023_003Dzyjwk8PdbSXxQ, _0023_003Dzk98RESByZO6KwZuGTA_003D_003D[_0023_003DzZe6oCrQ_003D]._0023_003Dzyjwk8PdbSXxQ);
	}

	private Vector3D _0023_003Dz9T2qChw_003D(int _0023_003DzffqPLNQ_003D, int _0023_003Dz5Azd7L8_003D, int _0023_003DzZe6oCrQ_003D)
	{
		Point3D _0023_003Dzyjwk8PdbSXxQ = _0023_003Dzk98RESByZO6KwZuGTA_003D_003D[_0023_003DzffqPLNQ_003D]._0023_003Dzyjwk8PdbSXxQ;
		Point3D _0023_003Dzyjwk8PdbSXxQ2 = _0023_003Dzk98RESByZO6KwZuGTA_003D_003D[_0023_003Dz5Azd7L8_003D]._0023_003Dzyjwk8PdbSXxQ;
		Vector3D asVector = (_0023_003Dzk98RESByZO6KwZuGTA_003D_003D[_0023_003DzZe6oCrQ_003D]._0023_003Dzyjwk8PdbSXxQ - _0023_003Dzyjwk8PdbSXxQ).AsVector;
		Vector3D asVector2 = (_0023_003Dzyjwk8PdbSXxQ2 - _0023_003Dzyjwk8PdbSXxQ).AsVector;
		Vector3D vector3D = Vector3D.Cross(asVector, asVector2);
		vector3D.Normalize();
		return vector3D;
	}

	private double _0023_003DznTraai60KiIt(int[] _0023_003DzzRR2S30_003D)
	{
		Vector3D u = _0023_003Dz9T2qChw_003D(_0023_003DzzRR2S30_003D[0], _0023_003DzzRR2S30_003D[1], _0023_003DzzRR2S30_003D[2]);
		Vector3D v = _0023_003Dz9T2qChw_003D(_0023_003DzzRR2S30_003D[2], _0023_003DzzRR2S30_003D[3], _0023_003DzzRR2S30_003D[0]);
		return Vector3D.AngleBetween(u, v);
	}

	private bool _0023_003DzEvi_vHGD2CnDwwfABA_003D_003D(_0023_003DzSFv50Wsoag5Gw_vk8tNvcl7ZZreiri9gzg_003D_003D _0023_003DzKpJk9wk_003D, IProgress<ProgressChangedEventArgs> _0023_003DzmHS7frs_003D, CancellationToken _0023_003Dzjvn7P10_003D)
	{
		int num = 0;
		while (num < base.SmoothingPasses)
		{
			_0023_003DzhMRyqCPtCkg0najGtg_003D_003D(_0023_003DzKpJk9wk_003D, SmoothingMode);
			num++;
			UpdateProgress(num, base.SmoothingPasses, string.Format(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302966662), base.SmoothingText, num), _0023_003DzmHS7frs_003D);
			if (Cancelled(_0023_003Dzjvn7P10_003D))
			{
				return false;
			}
		}
		return true;
	}

	private void _0023_003DzhMRyqCPtCkg0najGtg_003D_003D(_0023_003DzSFv50Wsoag5Gw_vk8tNvcl7ZZreiri9gzg_003D_003D _0023_003DzKpJk9wk_003D, mesherSmoothingType _0023_003DzuKZ6x2udYX1p_Yz47g_003D_003D)
	{
		bool flag = _0023_003Dz_xHzQQk_003D._0023_003Dzbse2nfoNwRvN();
		for (int i = _0023_003Dz91HGJEsGIzcV; i < _0023_003Dzk98RESByZO6KwZuGTA_003D_003D.Count; i++)
		{
			if (_0023_003DzKpJk9wk_003D.Adjacency[i].Count < 1)
			{
				continue;
			}
			double num = 0.0;
			double num2 = 0.0;
			double num3 = 0.0;
			_0023_003DzRV5GhlIkprjwXRkNGMknXBOYrewR09oqf_lNIvRxwZpVBQ6mcQ_003D_003D _0023_003DzRV5GhlIkprjwXRkNGMknXBOYrewR09oqf_lNIvRxwZpVBQ6mcQ_003D_003D2 = _0023_003Dzk98RESByZO6KwZuGTA_003D_003D[i];
			int[] array = _0023_003DzKpJk9wk_003D.Cell(i);
			if (flag)
			{
				bool flag2 = false;
				int[] array2 = array;
				foreach (int num4 in array2)
				{
					if (num4 < _0023_003Dz91HGJEsGIzcV && _0023_003Dz_xHzQQk_003D._0023_003DzgXk8Ru_iJQUJ(_0023_003Dzk98RESByZO6KwZuGTA_003D_003D[num4]._0023_003Dzyjwk8PdbSXxQ, _0023_003DzlCJ6DabnbVnjzDbCNIb5mv0_003D, out var _))
					{
						flag2 = true;
						break;
					}
				}
				if (flag2)
				{
					continue;
				}
			}
			switch (_0023_003DzuKZ6x2udYX1p_Yz47g_003D_003D)
			{
			case mesherSmoothingType.Laplacian:
			{
				int[] array2 = array;
				foreach (int index in array2)
				{
					_0023_003DzRV5GhlIkprjwXRkNGMknXBOYrewR09oqf_lNIvRxwZpVBQ6mcQ_003D_003D _0023_003DzRV5GhlIkprjwXRkNGMknXBOYrewR09oqf_lNIvRxwZpVBQ6mcQ_003D_003D5 = _0023_003Dzk98RESByZO6KwZuGTA_003D_003D[index];
					double num6 = _0023_003DzRV5GhlIkprjwXRkNGMknXBOYrewR09oqf_lNIvRxwZpVBQ6mcQ_003D_003D2._0023_003Dzyjwk8PdbSXxQ.DistanceTo(_0023_003DzRV5GhlIkprjwXRkNGMknXBOYrewR09oqf_lNIvRxwZpVBQ6mcQ_003D_003D5._0023_003Dzyjwk8PdbSXxQ);
					double num7 = 2.0 * num6 / (_0023_003DzRV5GhlIkprjwXRkNGMknXBOYrewR09oqf_lNIvRxwZpVBQ6mcQ_003D_003D2._0023_003Dz_0024pfZB54_003D + _0023_003DzRV5GhlIkprjwXRkNGMknXBOYrewR09oqf_lNIvRxwZpVBQ6mcQ_003D_003D5._0023_003Dz_0024pfZB54_003D);
					Point2D point2D2 = _0023_003DzRV5GhlIkprjwXRkNGMknXBOYrewR09oqf_lNIvRxwZpVBQ6mcQ_003D_003D5._0023_003DzIHt45I8_003D + (_0023_003DzRV5GhlIkprjwXRkNGMknXBOYrewR09oqf_lNIvRxwZpVBQ6mcQ_003D_003D2._0023_003DzIHt45I8_003D - _0023_003DzRV5GhlIkprjwXRkNGMknXBOYrewR09oqf_lNIvRxwZpVBQ6mcQ_003D_003D5._0023_003DzIHt45I8_003D) / num7;
					num += point2D2.X;
					num2 += point2D2.Y;
					num3 += 1.0;
				}
				break;
			}
			case mesherSmoothingType.AreaCentroidWeighted:
				foreach (int item3 in _0023_003DzKpJk9wk_003D.Adjacency[i])
				{
					(int, int) tuple = _0023_003DzKpJk9wk_003D.Triangles[item3]._0023_003DzI2fnrdw_003D(i);
					int item = tuple.Item1;
					int item2 = tuple.Item2;
					_0023_003DzRV5GhlIkprjwXRkNGMknXBOYrewR09oqf_lNIvRxwZpVBQ6mcQ_003D_003D _0023_003DzRV5GhlIkprjwXRkNGMknXBOYrewR09oqf_lNIvRxwZpVBQ6mcQ_003D_003D3 = _0023_003Dzk98RESByZO6KwZuGTA_003D_003D[item];
					_0023_003DzRV5GhlIkprjwXRkNGMknXBOYrewR09oqf_lNIvRxwZpVBQ6mcQ_003D_003D _0023_003DzRV5GhlIkprjwXRkNGMknXBOYrewR09oqf_lNIvRxwZpVBQ6mcQ_003D_003D4 = _0023_003Dzk98RESByZO6KwZuGTA_003D_003D[item2];
					Point2D point2D = _0023_003DzYyJ0cMHBMtAouJHA0w_003D_003D(_0023_003DzRV5GhlIkprjwXRkNGMknXBOYrewR09oqf_lNIvRxwZpVBQ6mcQ_003D_003D3, _0023_003DzRV5GhlIkprjwXRkNGMknXBOYrewR09oqf_lNIvRxwZpVBQ6mcQ_003D_003D4, _0023_003DzRV5GhlIkprjwXRkNGMknXBOYrewR09oqf_lNIvRxwZpVBQ6mcQ_003D_003D2);
					double num5 = Triangle._0023_003Dz1Adjqfhc_0024Cyh(_0023_003DzRV5GhlIkprjwXRkNGMknXBOYrewR09oqf_lNIvRxwZpVBQ6mcQ_003D_003D3._0023_003Dzyjwk8PdbSXxQ, _0023_003DzRV5GhlIkprjwXRkNGMknXBOYrewR09oqf_lNIvRxwZpVBQ6mcQ_003D_003D4._0023_003Dzyjwk8PdbSXxQ, _0023_003DzRV5GhlIkprjwXRkNGMknXBOYrewR09oqf_lNIvRxwZpVBQ6mcQ_003D_003D2._0023_003Dzyjwk8PdbSXxQ);
					num += num5 * point2D.X;
					num2 += num5 * point2D.Y;
					num3 += num5;
				}
				break;
			default:
				throw new ArgumentOutOfRangeException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302992332));
			}
			Point3D point3D = new Point3D(num / num3, num2 / num3);
			Point2D point2D3 = 0.0 * _0023_003DzRV5GhlIkprjwXRkNGMknXBOYrewR09oqf_lNIvRxwZpVBQ6mcQ_003D_003D2._0023_003DzIHt45I8_003D + 1.0 * point3D;
			if (!_0023_003DzKpJk9wk_003D._0023_003DzFPEj_mZrLVDn(point2D3, array))
			{
				continue;
			}
			double? num8 = null;
			if (Point2D.DistanceSquared(point2D3, _0023_003DzRV5GhlIkprjwXRkNGMknXBOYrewR09oqf_lNIvRxwZpVBQ6mcQ_003D_003D2._0023_003DzIHt45I8_003D) > 1E-12)
			{
				foreach (int item4 in _0023_003DzKpJk9wk_003D.Adjacency[i])
				{
					IndexTriangle indexTriangle = _0023_003DzKpJk9wk_003D.Triangles[item4];
					if (Utility.PointInTriangle(point2D3, _0023_003Dzk98RESByZO6KwZuGTA_003D_003D[indexTriangle.V1]._0023_003DzIHt45I8_003D, _0023_003Dzk98RESByZO6KwZuGTA_003D_003D[indexTriangle.V2]._0023_003DzIHt45I8_003D, _0023_003Dzk98RESByZO6KwZuGTA_003D_003D[indexTriangle.V3]._0023_003DzIHt45I8_003D))
					{
						num8 = _0023_003DzPiN1LjJIcmriaUrYeA_003D_003D(indexTriangle, point2D3, _0023_003Dzk98RESByZO6KwZuGTA_003D_003D[indexTriangle.V1]._0023_003Dz_0024pfZB54_003D, _0023_003Dzk98RESByZO6KwZuGTA_003D_003D[indexTriangle.V2]._0023_003Dz_0024pfZB54_003D, _0023_003Dzk98RESByZO6KwZuGTA_003D_003D[indexTriangle.V3]._0023_003Dz_0024pfZB54_003D);
					}
				}
			}
			else
			{
				num8 = _0023_003DzRV5GhlIkprjwXRkNGMknXBOYrewR09oqf_lNIvRxwZpVBQ6mcQ_003D_003D2._0023_003Dz_0024pfZB54_003D;
			}
			if (num8.HasValue)
			{
				_0023_003DzRV5GhlIkprjwXRkNGMknXBOYrewR09oqf_lNIvRxwZpVBQ6mcQ_003D_003D2._0023_003DzIHt45I8_003D.X = point2D3.X;
				_0023_003DzRV5GhlIkprjwXRkNGMknXBOYrewR09oqf_lNIvRxwZpVBQ6mcQ_003D_003D2._0023_003DzIHt45I8_003D.Y = point2D3.Y;
				_0023_003DzRV5GhlIkprjwXRkNGMknXBOYrewR09oqf_lNIvRxwZpVBQ6mcQ_003D_003D2._0023_003Dz_0024pfZB54_003D = num8.Value;
				_0023_003DzCmPmvf8_003D(_0023_003DzRV5GhlIkprjwXRkNGMknXBOYrewR09oqf_lNIvRxwZpVBQ6mcQ_003D_003D2);
			}
		}
	}

	private Point2D _0023_003DzYyJ0cMHBMtAouJHA0w_003D_003D(_0023_003DzRV5GhlIkprjwXRkNGMknXBOYrewR09oqf_lNIvRxwZpVBQ6mcQ_003D_003D _0023_003DzFj_0024IqDQ_003D, _0023_003DzRV5GhlIkprjwXRkNGMknXBOYrewR09oqf_lNIvRxwZpVBQ6mcQ_003D_003D _0023_003DzjdeMMkk_003D, _0023_003DzRV5GhlIkprjwXRkNGMknXBOYrewR09oqf_lNIvRxwZpVBQ6mcQ_003D_003D _0023_003Dzm4eSPQQ_003D)
	{
		Point3D _0023_003DzlY77YgY_003D = (_0023_003DzFj_0024IqDQ_003D._0023_003Dzyjwk8PdbSXxQ + _0023_003DzjdeMMkk_003D._0023_003Dzyjwk8PdbSXxQ + _0023_003Dzm4eSPQQ_003D._0023_003Dzyjwk8PdbSXxQ) / 3.0;
		Point2D point2D = (_0023_003DzFj_0024IqDQ_003D._0023_003DzIHt45I8_003D + _0023_003DzjdeMMkk_003D._0023_003DzIHt45I8_003D + _0023_003Dzm4eSPQQ_003D._0023_003DzIHt45I8_003D) / 3.0;
		if (!_0023_003Dz_xHzQQk_003D._0023_003DzKWdaQi8_003D(_0023_003DzlY77YgY_003D, _0023_003DzlCJ6DabnbVnjzDbCNIb5mv0_003D, _0023_003Dz0ZT3gEddQ5QD: false, point2D, out var _0023_003DzOLHnb2M_003D))
		{
			return point2D;
		}
		return _0023_003DzOLHnb2M_003D;
	}

	private double _0023_003DzPiN1LjJIcmriaUrYeA_003D_003D(IndexTriangle _0023_003DznnnQx3RwjThsBRPB9w_003D_003D, Point2D _0023_003DzB68dg9Q_003D, double _0023_003Dzt38nTwk_003D, double _0023_003DzRZmqfkw_003D, double _0023_003DzKZleN9c_003D)
	{
		Point2D _0023_003DzIHt45I8_003D = _0023_003Dzk98RESByZO6KwZuGTA_003D_003D[_0023_003DznnnQx3RwjThsBRPB9w_003D_003D.V1]._0023_003DzIHt45I8_003D;
		Point2D _0023_003DzIHt45I8_003D2 = _0023_003Dzk98RESByZO6KwZuGTA_003D_003D[_0023_003DznnnQx3RwjThsBRPB9w_003D_003D.V2]._0023_003DzIHt45I8_003D;
		Point2D _0023_003DzIHt45I8_003D3 = _0023_003Dzk98RESByZO6KwZuGTA_003D_003D[_0023_003DznnnQx3RwjThsBRPB9w_003D_003D.V3]._0023_003DzIHt45I8_003D;
		return Triangle._0023_003DzPiN1LjJIcmriaUrYeA_003D_003D(_0023_003DzIHt45I8_003D, _0023_003DzIHt45I8_003D2, _0023_003DzIHt45I8_003D3, _0023_003DzB68dg9Q_003D, _0023_003Dzt38nTwk_003D, _0023_003DzRZmqfkw_003D, _0023_003DzKZleN9c_003D);
	}

	internal Mesh _0023_003DzPPg9HW_0024f0k0711gnEcM6RAU_003D(bool _0023_003DzoMBKEgY_003D)
	{
		if (!_0023_003Dz5bTQ1u9UVidehQ86Hw_003D_003D(null, default(CancellationToken)))
		{
			return null;
		}
		Point3D[] array = new Point3D[_0023_003Dzk98RESByZO6KwZuGTA_003D_003D.Count];
		IndexTriangle[] array2 = new IndexTriangle[triangles.Count];
		for (int i = 0; i < array.Length; i++)
		{
			array[i] = (Point3D)_0023_003Dzk98RESByZO6KwZuGTA_003D_003D[i]._0023_003DzIHt45I8_003D;
		}
		int num = 0;
		foreach (DelaunayTriangle triangle in triangles)
		{
			array2[num++] = triangle;
		}
		Mesh mesh = new Mesh(array, array2);
		if (_0023_003DzoMBKEgY_003D)
		{
			mesh.TransformBy(_0023_003Dz_xHzQQk_003D._0023_003DzAOlcrIqv6aDt());
		}
		return mesh;
	}

	public Mesh GetParametricMesh()
	{
		return _0023_003DzPPg9HW_0024f0k0711gnEcM6RAU_003D(_0023_003DzoMBKEgY_003D: true);
	}

	private bool _0023_003Dz8Er3zyI46rYZCZQ6qmFrSe0_003D(IProgress<ProgressChangedEventArgs> _0023_003DzmHS7frs_003D, CancellationToken _0023_003Dzjvn7P10_003D)
	{
		int num = 0;
		int count = _0023_003Dzk98RESByZO6KwZuGTA_003D_003D.Count;
		_0023_003Dz91HGJEsGIzcV = _0023_003Dzk98RESByZO6KwZuGTA_003D_003D.Count;
		int _0023_003DzObi_SsU_003D;
		do
		{
			_0023_003DzObi_SsU_003D = 0;
			List<IndexLine> list = new List<IndexLine>();
			_0023_003DzQL0bYhLdzA8Y(list);
			if (list.Count > 0)
			{
				foreach (IndexLine item in list)
				{
					_0023_003DzSfHp2f0VMafHtB94Pw_003D_003D(item, ref _0023_003DzObi_SsU_003D);
				}
			}
			string text = TriangulatingText + (num + 1);
			if (!ProcessTriangulation(count, _0023_003Dzk98RESByZO6KwZuGTA_003D_003D.Count, text, checkInside: false, _0023_003DzmHS7frs_003D, _0023_003Dzjvn7P10_003D))
			{
				return false;
			}
			UpdateProgressTo100(text, _0023_003DzmHS7frs_003D);
			num++;
			count = _0023_003Dzk98RESByZO6KwZuGTA_003D_003D.Count;
		}
		while (_0023_003DzObi_SsU_003D > 0);
		return true;
	}

	private void _0023_003DzQL0bYhLdzA8Y(List<IndexLine> _0023_003DzOfbk2Fc_003D)
	{
		int[,] array = new int[triangles.Count, 3];
		LinkedListNode<DelaunayTriangle> linkedListNode = triangles.First;
		int num = 0;
		do
		{
			DelaunayTriangle value = linkedListNode.Value;
			array[num, 0] = value.V1;
			array[num, 1] = value.V2;
			array[num, 2] = value.V3;
			num++;
			linkedListNode = linkedListNode.Next;
		}
		while (linkedListNode != null);
		LinkedList<SharedEdge>[] edgesPerVertex;
		int[,] edgesWithoutDuplicates = Utility.GetEdgesWithoutDuplicates(array, _0023_003Dzk98RESByZO6KwZuGTA_003D_003D.Count, out edgesPerVertex);
		int length = edgesWithoutDuplicates.GetLength(0);
		for (int i = 0; i < length; i++)
		{
			if (edgesWithoutDuplicates[i, 3] != -1)
			{
				int v = edgesWithoutDuplicates[i, 0];
				int v2 = edgesWithoutDuplicates[i, 1];
				_0023_003DzOfbk2Fc_003D.Add(new IndexLine(v, v2));
			}
		}
	}

	private void _0023_003DzSfHp2f0VMafHtB94Pw_003D_003D(IndexLine _0023_003Dz3Ftsho0_003D, ref int _0023_003DzObi_SsU_003D)
	{
		_0023_003Dzk98RESByZO6KwZuGTA_003D_003D[_0023_003Dz3Ftsho0_003D.V1]._0023_003DzDCjBZK4_003D = null;
		_0023_003Dzk98RESByZO6KwZuGTA_003D_003D[_0023_003Dz3Ftsho0_003D.V2]._0023_003DzDCjBZK4_003D = null;
		_0023_003DzaNdK2SNh78xbyVoyjA_003D_003D[] array = _0023_003Dzh7hGHKctKQZFDBseCg_003D_003D(_0023_003Dz3Ftsho0_003D);
		if (array.Length < 1)
		{
			return;
		}
		LinkedListNode<DelaunayTriangle> linkedListNode = null;
		LinkedListNode<DelaunayTriangle> linkedListNode2 = null;
		foreach (LinkedListNode<DelaunayTriangle> item in adjacency[_0023_003Dz3Ftsho0_003D.V1])
		{
			if (item.Value._0023_003DzXscMLpk_003D(_0023_003Dz3Ftsho0_003D.V2))
			{
				if (linkedListNode == null)
				{
					linkedListNode = item;
				}
				else if (linkedListNode2 == null)
				{
					linkedListNode2 = item;
				}
			}
		}
		_0023_003DzaNdK2SNh78xbyVoyjA_003D_003D[] array2 = array;
		foreach (_0023_003DzaNdK2SNh78xbyVoyjA_003D_003D _0023_003DzaNdK2SNh78xbyVoyjA_003D_003D2 in array2)
		{
			_0023_003DzaNdK2SNh78xbyVoyjA_003D_003D2._0023_003DzDCjBZK4_003D = linkedListNode;
			linkedListNode.Value.points.Add(_0023_003Dzk98RESByZO6KwZuGTA_003D_003D.Count);
			linkedListNode2?.Value.points.Add(_0023_003Dzk98RESByZO6KwZuGTA_003D_003D.Count);
			_0023_003Dzk98RESByZO6KwZuGTA_003D_003D.Add(_0023_003DzaNdK2SNh78xbyVoyjA_003D_003D2);
			adjacency.Add(new LinkedList<LinkedListNode<DelaunayTriangle>>());
			_0023_003DzObi_SsU_003D++;
		}
	}

	private _0023_003DzaNdK2SNh78xbyVoyjA_003D_003D[] _0023_003Dzh7hGHKctKQZFDBseCg_003D_003D(IndexLine _0023_003DzTx2aqr8_003D)
	{
		List<_0023_003DzaNdK2SNh78xbyVoyjA_003D_003D> list = new List<_0023_003DzaNdK2SNh78xbyVoyjA_003D_003D>();
		_0023_003Dzh7hGHKctKQZFDBseCg_003D_003D(_0023_003Dzk98RESByZO6KwZuGTA_003D_003D[_0023_003DzTx2aqr8_003D.V1], _0023_003Dzk98RESByZO6KwZuGTA_003D_003D[_0023_003DzTx2aqr8_003D.V2], list);
		return list.ToArray();
	}

	private void _0023_003Dzh7hGHKctKQZFDBseCg_003D_003D(_0023_003DzRV5GhlIkprjwXRkNGMknXBOYrewR09oqf_lNIvRxwZpVBQ6mcQ_003D_003D _0023_003DzAqOpw0w_003D, _0023_003DzRV5GhlIkprjwXRkNGMknXBOYrewR09oqf_lNIvRxwZpVBQ6mcQ_003D_003D _0023_003Dzk64JNOo_003D, List<_0023_003DzaNdK2SNh78xbyVoyjA_003D_003D> _0023_003DzrdSL0CI_003D)
	{
		double num = _0023_003DzMEXpAaVkFlpl(_0023_003DzAqOpw0w_003D._0023_003DzIHt45I8_003D).DistanceTo(_0023_003DzMEXpAaVkFlpl(_0023_003Dzk64JNOo_003D._0023_003DzIHt45I8_003D));
		double _0023_003Dz_0024pfZB54_003D = _0023_003DzAqOpw0w_003D._0023_003Dz_0024pfZB54_003D;
		double _0023_003Dz_0024pfZB54_003D2 = _0023_003Dzk64JNOo_003D._0023_003Dz_0024pfZB54_003D;
		_0023_003DzRV5GhlIkprjwXRkNGMknXBOYrewR09oqf_lNIvRxwZpVBQ6mcQ_003D_003D _0023_003DzRV5GhlIkprjwXRkNGMknXBOYrewR09oqf_lNIvRxwZpVBQ6mcQ_003D_003D2 = _0023_003Dz6zQrAVStav9O(_0023_003DzAqOpw0w_003D, _0023_003Dzk64JNOo_003D);
		if (!(num <= _0023_003Dz_0024pfZB54_003D) || !(num <= _0023_003Dz_0024pfZB54_003D2))
		{
			_0023_003DzaNdK2SNh78xbyVoyjA_003D_003D _0023_003DzaNdK2SNh78xbyVoyjA_003D_003D2 = new _0023_003DzaNdK2SNh78xbyVoyjA_003D_003D((Point3D)_0023_003DzRV5GhlIkprjwXRkNGMknXBOYrewR09oqf_lNIvRxwZpVBQ6mcQ_003D_003D2._0023_003DzIHt45I8_003D, brMin, brRange, gridSize);
			_0023_003DzaNdK2SNh78xbyVoyjA_003D_003D2._0023_003Dz_0024pfZB54_003D = _0023_003DzRV5GhlIkprjwXRkNGMknXBOYrewR09oqf_lNIvRxwZpVBQ6mcQ_003D_003D2._0023_003Dz_0024pfZB54_003D;
			_0023_003DzrdSL0CI_003D.Add(_0023_003DzaNdK2SNh78xbyVoyjA_003D_003D2);
			_0023_003Dzh7hGHKctKQZFDBseCg_003D_003D(_0023_003DzAqOpw0w_003D, _0023_003DzaNdK2SNh78xbyVoyjA_003D_003D2, _0023_003DzrdSL0CI_003D);
			_0023_003Dzh7hGHKctKQZFDBseCg_003D_003D(_0023_003DzaNdK2SNh78xbyVoyjA_003D_003D2, _0023_003Dzk64JNOo_003D, _0023_003DzrdSL0CI_003D);
		}
	}

	private void _0023_003DzCmPmvf8_003D(_0023_003DzRV5GhlIkprjwXRkNGMknXBOYrewR09oqf_lNIvRxwZpVBQ6mcQ_003D_003D _0023_003DzlY77YgY_003D)
	{
		_0023_003DzlY77YgY_003D._0023_003Dzyjwk8PdbSXxQ = _0023_003DzMEXpAaVkFlpl(_0023_003DzlY77YgY_003D._0023_003DzIHt45I8_003D);
	}

	private Point3D _0023_003DzMEXpAaVkFlpl(Point2D _0023_003DzlY77YgY_003D)
	{
		return _0023_003Dz_xHzQQk_003D._0023_003DzMEXpAaVkFlpl(_0023_003DzlY77YgY_003D);
	}

	private double _0023_003DzQXPy7rY_003D(int _0023_003DzkEYxO1SuR1Kw, IEnumerable _0023_003DzzRR2S30_003D)
	{
		double num = 0.0;
		foreach (int item in _0023_003DzzRR2S30_003D)
		{
			num += _0023_003Dz2IIjOuI_003D(_0023_003Dzk98RESByZO6KwZuGTA_003D_003D[_0023_003DzkEYxO1SuR1Kw], _0023_003Dzk98RESByZO6KwZuGTA_003D_003D[item]);
		}
		return num;
	}

	private double _0023_003Dz2IIjOuI_003D(_0023_003DzRV5GhlIkprjwXRkNGMknXBOYrewR09oqf_lNIvRxwZpVBQ6mcQ_003D_003D _0023_003DzjR_8wWk_003D, _0023_003DzRV5GhlIkprjwXRkNGMknXBOYrewR09oqf_lNIvRxwZpVBQ6mcQ_003D_003D _0023_003DzC_0024S_002404o_003D)
	{
		double _0023_003DzdC3TxFk_003D = _0023_003DzjR_8wWk_003D._0023_003Dzyjwk8PdbSXxQ.DistanceTo(_0023_003DzC_0024S_002404o_003D._0023_003Dzyjwk8PdbSXxQ);
		return (_0023_003Dz2IIjOuI_003D(_0023_003DzdC3TxFk_003D, _0023_003DzjR_8wWk_003D._0023_003Dz_0024pfZB54_003D) + _0023_003Dz2IIjOuI_003D(_0023_003DzdC3TxFk_003D, _0023_003DzC_0024S_002404o_003D._0023_003Dz_0024pfZB54_003D)) / 2.0;
	}

	private static double _0023_003Dz2IIjOuI_003D(double _0023_003DzdC3TxFk_003D, double _0023_003DzAPYOMXE_003D)
	{
		double num = _0023_003DzdC3TxFk_003D / _0023_003DzAPYOMXE_003D;
		if (!(num < 1.0))
		{
			return num;
		}
		return 1.0 / num;
	}

	public CurveMesher CreateCurveMesher(ICurve curve, SizesOnCurve sizes)
	{
		return new CurveMesher(curve, sizes);
	}

	public static double EstimateSizeByNumber(int numberOfTris, Surface surf)
	{
		if (surf.Triangles == null || surf.Triangles.Length == 0)
		{
			Utility.ComputeBoundingBox(surf.EstimateBoundingBox(null, null), out var boxMin, out var boxMax);
			double deviation = new Size3D(boxMin, boxMax).Diagonal / 100.0;
			surf.Regen(deviation);
		}
		Point3D centroid;
		double num = surf.GetArea(out centroid) / (double)numberOfTris;
		return 2.0 * Math.Sqrt(num / 1.7320508075688772);
	}

	public double GetSizeAtVertex(int vertex)
	{
		return _0023_003Dzk98RESByZO6KwZuGTA_003D_003D[vertex]._0023_003Dz_0024pfZB54_003D;
	}

	private bool _0023_003DzFjJJZr690_00240B4C78lz1x8knnhoFoY74V6g_003D_003D(int _0023_003DzTSeNR8Q_003D)
	{
		return _0023_003Dzk98RESByZO6KwZuGTA_003D_003D[_0023_003DzTSeNR8Q_003D]._0023_003DzDCjBZK4_003D == null;
	}

	private bool _0023_003DzspBSNH9faVCQ5rFZBHs_0024uzbLvzuZAjb2Hg_003D_003D(int _0023_003DzTSeNR8Q_003D)
	{
		return _0023_003Dzk98RESByZO6KwZuGTA_003D_003D[_0023_003DzTSeNR8Q_003D]._0023_003DzDCjBZK4_003D == null;
	}
}
