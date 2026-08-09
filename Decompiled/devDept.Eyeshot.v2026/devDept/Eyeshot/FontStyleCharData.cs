using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using devDept.Eyeshot.Entities;
using devDept.Geometry;
using devDept.Graphics;

namespace devDept.Eyeshot;

[Serializable]
public class FontStyleCharData : IDisposable
{
	private sealed class _0023_003DzJdF4n0kEX8MUaUEYzuJIc_0024w_003D
	{
		public _0023_003DzwLm_GYGqGk7zQ_Ps8NOja9o_003D _0023_003DzTx2aqr8_003D;

		public _0023_003DzvfW21QWtGQPvLi57_W1rnfc_003D _0023_003Dq67X_icOyL2pbVg8MqeLnN9iyPisQmwHJyzSwPdBoj_0024I_003D;

		internal bool _0023_003Dz0ToGpH800cNKefG1iQvrwZQ_003D(Point2D[] _0023_003DzBJFJHwk_003D)
		{
			return _0023_003Dza0MP9CcEI7_w(_0023_003DzBJFJHwk_003D, _0023_003Dq67X_icOyL2pbVg8MqeLnN9iyPisQmwHJyzSwPdBoj_0024I_003D._0023_003DzWaFlkhfmYCja, _0023_003DzTx2aqr8_003D);
		}
	}

	private sealed class _0023_003DzvfW21QWtGQPvLi57_W1rnfc_003D
	{
		public Point2D[][] _0023_003DzWaFlkhfmYCja;
	}

	internal double Width;

	internal double Descend;

	private IList<Entity> entities;

	private FastPointCloud simplifiedFpc;

	private Point2D[][] fpcOuters;

	private Point2D[][][] fpcInners;

	internal Point3D boxMin;

	internal Point3D boxMax;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private static readonly char[] _0023_003DzE5Riy1SEddky = new char[6] { '?', '*', '#', '@', '&', ' ' };

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private static readonly char[] _0023_003DzU8nvDvXJrG_B = new char[13]
	{
		'Q', 'O', 'D', 'H', 'N', 'A', 'E', 'X', 'U', 'C',
		'8', '9', '6'
	};

	internal FontStyleCharData(string _0023_003DzuwH5j5s_003D, TextStyle _0023_003Dzgkctzk6d2IIh, RenderContextBase _0023_003DzQdnFby4_003D, double _0023_003DzuCzANmziTJld, bool _0023_003DzbamQ1mQWVhT9)
	{
		if (_0023_003Dzgkctzk6d2IIh.IsSHX())
		{
			_0023_003DzATdiUwVz2L_00249(_0023_003DzuwH5j5s_003D, _0023_003Dzgkctzk6d2IIh, _0023_003DzuCzANmziTJld);
			return;
		}
		entities = _0023_003DzQdnFby4_003D.GetCharMeshes(_0023_003DzuwH5j5s_003D, _0023_003Dzgkctzk6d2IIh.FontFamilyName, _0023_003Dzgkctzk6d2IIh.Style, _0023_003DzuCzANmziTJld, 0.0, _0023_003DzbamQ1mQWVhT9, out Width, out Descend, computeDataForFpc: true, out fpcOuters, out fpcInners);
		_0023_003DzI9tkmcDemGKs();
	}

	public FontStyleCharData(IList<Entity> entities)
	{
		this.entities = entities;
	}

	internal Entity[] _0023_003Dz0erUYWA_003D(bool _0023_003Dz_Gzfs9c_003D, bool _0023_003DzMq_3pL2oL0w4r1oLOw_003D_003D)
	{
		if (!_0023_003Dz_Gzfs9c_003D)
		{
			return entities.ToArray();
		}
		Entity[] array = new Entity[entities.Count];
		for (int i = 0; i < entities.Count; i++)
		{
			if (_0023_003DzMq_3pL2oL0w4r1oLOw_003D_003D)
			{
				if (entities[i] is Mesh)
				{
					Mesh mesh = (Mesh)entities[i];
					Point3D[] array2 = new Point3D[mesh._vertices.Length];
					for (int j = 0; j < mesh._vertices.Length; j++)
					{
						array2[j] = (Point3D)mesh._vertices[j].Clone();
					}
					IndexTriangle[] array3 = new IndexTriangle[mesh.Triangles.Length];
					for (int k = 0; k < mesh.Triangles.Length; k++)
					{
						array3[k] = (IndexTriangle)mesh.Triangles[k].Clone();
					}
					array[i] = new Mesh(array2, array3);
				}
			}
			else
			{
				array[i] = (Entity)entities[i].Clone();
			}
		}
		return array;
	}

	private void _0023_003DzWYTqKrPYeTk8SjO2Vw_003D_003D(ref Transformation _0023_003Dz9ZUzIX4xmsyA, out Point3D[][] _0023_003Dzk98RESByZO6KwZuGTA_003D_003D, out int[][] _0023_003DzJjA_gLscEShC_0024fCWrA_003D_003D)
	{
		_0023_003DzWYTqKrPYeTk8SjO2Vw_003D_003D(entities, ref _0023_003Dz9ZUzIX4xmsyA, out _0023_003Dzk98RESByZO6KwZuGTA_003D_003D, out _0023_003DzJjA_gLscEShC_0024fCWrA_003D_003D);
	}

	internal void _0023_003DzWYTqKrPYeTk8SjO2Vw_003D_003D(string _0023_003DzuwH5j5s_003D, RenderContextBase _0023_003DzQdnFby4_003D, string _0023_003DzUsjwj2w_003D, fontStyle _0023_003Dz_0024wQZnFQ_003D, double _0023_003DzWArtMuor9L71fptjtg_003D_003D, double _0023_003DzoZlCoZFOIHZX, bool _0023_003DzbamQ1mQWVhT9, ref Transformation _0023_003Dz9ZUzIX4xmsyA, out Point3D[][] _0023_003Dzk98RESByZO6KwZuGTA_003D_003D, out int[][] _0023_003DzJjA_gLscEShC_0024fCWrA_003D_003D)
	{
		if (_0023_003DzWArtMuor9L71fptjtg_003D_003D == 0.0)
		{
			_0023_003DzWYTqKrPYeTk8SjO2Vw_003D_003D(entities, ref _0023_003Dz9ZUzIX4xmsyA, out _0023_003Dzk98RESByZO6KwZuGTA_003D_003D, out _0023_003DzJjA_gLscEShC_0024fCWrA_003D_003D);
			return;
		}
		IList<Entity> charMeshes = _0023_003DzQdnFby4_003D.GetCharMeshes(_0023_003DzuwH5j5s_003D, _0023_003DzUsjwj2w_003D, _0023_003Dz_0024wQZnFQ_003D, _0023_003DzoZlCoZFOIHZX, _0023_003DzWArtMuor9L71fptjtg_003D_003D, _0023_003DzbamQ1mQWVhT9);
		_0023_003DzWYTqKrPYeTk8SjO2Vw_003D_003D(charMeshes, ref _0023_003Dz9ZUzIX4xmsyA, out _0023_003Dzk98RESByZO6KwZuGTA_003D_003D, out _0023_003DzJjA_gLscEShC_0024fCWrA_003D_003D);
		foreach (Entity item in charMeshes)
		{
			item.Dispose();
		}
	}

	private void _0023_003DzWYTqKrPYeTk8SjO2Vw_003D_003D(IList<Entity> _0023_003Dzv7xH9gk_003D, ref Transformation _0023_003Dz9ZUzIX4xmsyA, out Point3D[][] _0023_003Dzk98RESByZO6KwZuGTA_003D_003D, out int[][] _0023_003DzJjA_gLscEShC_0024fCWrA_003D_003D)
	{
		_0023_003Dzk98RESByZO6KwZuGTA_003D_003D = new Point3D[_0023_003Dzv7xH9gk_003D.Count][];
		_0023_003DzJjA_gLscEShC_0024fCWrA_003D_003D = new int[_0023_003Dzv7xH9gk_003D.Count][];
		for (int i = 0; i < _0023_003Dzv7xH9gk_003D.Count; i++)
		{
			Mesh mesh = (Mesh)_0023_003Dzv7xH9gk_003D[i];
			_0023_003Dzk98RESByZO6KwZuGTA_003D_003D[i] = new List<Point3D>(mesh.Vertices).ToArray();
			for (int j = 0; j < _0023_003Dzk98RESByZO6KwZuGTA_003D_003D[i].Length; j++)
			{
				_0023_003Dzk98RESByZO6KwZuGTA_003D_003D[i][j] = _0023_003Dz9ZUzIX4xmsyA * _0023_003Dzk98RESByZO6KwZuGTA_003D_003D[i][j];
			}
			_0023_003DzJjA_gLscEShC_0024fCWrA_003D_003D[i] = new int[mesh.Triangles.Length * 3];
			int num = 0;
			for (int k = 0; k < mesh.Triangles.Length; k++)
			{
				IndexTriangle indexTriangle = mesh.Triangles[k];
				_0023_003DzJjA_gLscEShC_0024fCWrA_003D_003D[i][num++] = indexTriangle.V1;
				_0023_003DzJjA_gLscEShC_0024fCWrA_003D_003D[i][num++] = indexTriangle.V2;
				_0023_003DzJjA_gLscEShC_0024fCWrA_003D_003D[i][num++] = indexTriangle.V3;
			}
		}
		_0023_003Dz9ZUzIX4xmsyA *= (Transformation)new Translation(Width, 0.0);
	}

	internal void _0023_003Dz_0024bJolnrorj7wQsl7reNoxZw_003D()
	{
		List<float> list = new List<float>();
		List<_0023_003DzwLm_GYGqGk7zQ_Ps8NOja9o_003D> list2 = new List<_0023_003DzwLm_GYGqGk7zQ_Ps8NOja9o_003D>();
		_0023_003DzspExml1j72mr_FI04NKW780_003D _0023_003DzspExml1j72mr_FI04NKW780_003D2 = new _0023_003DzspExml1j72mr_FI04NKW780_003D();
		try
		{
			for (int i = 0; i < fpcOuters.Length; i++)
			{
				for (int j = 0; j < fpcInners[i].Length; j++)
				{
					fpcInners[i][j] = Utility._0023_003DzJG8vopyBQob3(fpcInners[i][j]).ToArray();
				}
				list2.AddRange(_0023_003DzlzXvsgr6aOVA3lkwtQ_003D_003D(Utility._0023_003DzJG8vopyBQob3(fpcOuters[i]).ToArray(), fpcInners[i]));
			}
		}
		finally
		{
			((IDisposable)_0023_003DzspExml1j72mr_FI04NKW780_003D2).Dispose();
		}
		foreach (_0023_003DzwLm_GYGqGk7zQ_Ps8NOja9o_003D item in list2)
		{
			list.Add((float)item._0023_003Dz3YfTAqg_003D);
			list.Add((float)item._0023_003DzpilgH4E_003D);
			list.Add(0f);
			list.Add((float)item._0023_003DzRFb1SGo_003D);
			list.Add((float)item._0023_003Dz8qV981c_003D);
			list.Add(0f);
		}
		simplifiedFpc = new FastPointCloud(list.ToArray());
		simplifiedFpc.DrawingStyle = PointCloud.drawingStyleType.Lines;
		fpcOuters = null;
		fpcInners = null;
	}

	private static List<_0023_003DzwLm_GYGqGk7zQ_Ps8NOja9o_003D> _0023_003DzlzXvsgr6aOVA3lkwtQ_003D_003D(Point2D[] _0023_003Dz_SqBXz8_003D, Point2D[][] _0023_003DzWaFlkhfmYCja)
	{
		_0023_003DzvfW21QWtGQPvLi57_W1rnfc_003D _0023_003DzvfW21QWtGQPvLi57_W1rnfc_003D2 = new _0023_003DzvfW21QWtGQPvLi57_W1rnfc_003D();
		_0023_003DzvfW21QWtGQPvLi57_W1rnfc_003D2._0023_003DzWaFlkhfmYCja = _0023_003DzWaFlkhfmYCja;
		if (_0023_003Dz_SqBXz8_003D.Length == 0)
		{
			return new List<_0023_003DzwLm_GYGqGk7zQ_Ps8NOja9o_003D>();
		}
		_0023_003Dz0nFVQ6jDJeZtkWNyskirPJY_003D _0023_003Dz0nFVQ6jDJeZtkWNyskirPJY_003D2 = new _0023_003Dz0nFVQ6jDJeZtkWNyskirPJY_003D(Utility._0023_003DzheSR8QM7q9ya);
		List<Point2D> list = new List<Point2D>();
		list.AddRange(_0023_003Dz_SqBXz8_003D);
		Point2D[][] _0023_003DzWaFlkhfmYCja2 = _0023_003DzvfW21QWtGQPvLi57_W1rnfc_003D2._0023_003DzWaFlkhfmYCja;
		foreach (Point2D[] collection in _0023_003DzWaFlkhfmYCja2)
		{
			list.AddRange(collection);
		}
		double[] array = new double[list.Count];
		double[] array2 = new double[list.Count];
		for (int j = 0; j < list.Count; j++)
		{
			array[j] = list[j].X;
			array2[j] = list[j].Y;
		}
		List<_0023_003DzwLm_GYGqGk7zQ_Ps8NOja9o_003D> list2 = _0023_003Dz0nFVQ6jDJeZtkWNyskirPJY_003D2._0023_003DzFsDKG19gEaewA_0024XYcQ_003D_003D(array, array2, -2.0, 2.0, -2.0, 2.0);
		List<_0023_003DzwLm_GYGqGk7zQ_Ps8NOja9o_003D> list3 = new List<_0023_003DzwLm_GYGqGk7zQ_Ps8NOja9o_003D>();
		Point2D[][] source = _0023_003DzFK0vHNSa1Wn9(_0023_003Dz_SqBXz8_003D, -0.01);
		using List<_0023_003DzwLm_GYGqGk7zQ_Ps8NOja9o_003D>.Enumerator enumerator = list2.GetEnumerator();
		while (enumerator.MoveNext())
		{
			_0023_003DzJdF4n0kEX8MUaUEYzuJIc_0024w_003D _0023_003DzJdF4n0kEX8MUaUEYzuJIc_0024w_003D2 = new _0023_003DzJdF4n0kEX8MUaUEYzuJIc_0024w_003D();
			_0023_003DzJdF4n0kEX8MUaUEYzuJIc_0024w_003D2._0023_003Dq67X_icOyL2pbVg8MqeLnN9iyPisQmwHJyzSwPdBoj_0024I_003D = _0023_003DzvfW21QWtGQPvLi57_W1rnfc_003D2;
			_0023_003DzJdF4n0kEX8MUaUEYzuJIc_0024w_003D2._0023_003DzTx2aqr8_003D = enumerator.Current;
			if (source.Any(_0023_003DzJdF4n0kEX8MUaUEYzuJIc_0024w_003D2._0023_003Dz0ToGpH800cNKefG1iQvrwZQ_003D))
			{
				list3.Add(_0023_003DzJdF4n0kEX8MUaUEYzuJIc_0024w_003D2._0023_003DzTx2aqr8_003D);
			}
		}
		return list3;
	}

	private static Point2D[][] _0023_003DzFK0vHNSa1Wn9(Point2D[] _0023_003Dz_SqBXz8_003D, double _0023_003DzYNjcavt9guh2)
	{
		Point3D[] array = new Point3D[_0023_003Dz_SqBXz8_003D.Length + 1];
		for (int i = 0; i < _0023_003Dz_SqBXz8_003D.Length; i++)
		{
			array[i] = new Point3D(_0023_003Dz_SqBXz8_003D[i].X, _0023_003Dz_SqBXz8_003D[i].Y, 0.0);
		}
		array[_0023_003Dz_SqBXz8_003D.Length] = new Point3D(_0023_003Dz_SqBXz8_003D[0].X, _0023_003Dz_SqBXz8_003D[0].Y, 0.0);
		ICurve[] array2 = new LinearPath(array).QuickOffset(_0023_003DzYNjcavt9guh2, Plane.XY);
		Point2D[][] array3 = new Point2D[array2.Length][];
		for (int j = 0; j < array2.Length; j++)
		{
			LinearPath linearPath = array2[j] as LinearPath;
			int num = j;
			Point2D[] array4 = linearPath.Vertices.ToArray();
			array3[num] = array4;
		}
		return array3.ToArray();
	}

	private static Point2D[][][] _0023_003Dz8_0024ESGhF5cyZWRfzP7Q_003D_003D(Point2D[][] _0023_003DzWaFlkhfmYCja, double _0023_003DzYNjcavt9guh2)
	{
		Point2D[][][] array = new Point2D[_0023_003DzWaFlkhfmYCja.Length][][];
		for (int i = 0; i < _0023_003DzWaFlkhfmYCja.Length; i++)
		{
			array[i] = _0023_003DzFK0vHNSa1Wn9(_0023_003DzWaFlkhfmYCja[i], _0023_003DzYNjcavt9guh2);
		}
		return array;
	}

	private static bool _0023_003Dza0MP9CcEI7_w(Point2D[] _0023_003DzsdySxIlQLgFZ, Point2D[][] _0023_003DzWaFlkhfmYCja, _0023_003DzwLm_GYGqGk7zQ_Ps8NOja9o_003D _0023_003DzTx2aqr8_003D)
	{
		if (!IsPointInsideChar(_0023_003DzTx2aqr8_003D._0023_003Dz3YfTAqg_003D, _0023_003DzTx2aqr8_003D._0023_003DzpilgH4E_003D, _0023_003DzsdySxIlQLgFZ))
		{
			return false;
		}
		Point2D[][] array = _0023_003DzWaFlkhfmYCja;
		foreach (Point2D[] points in array)
		{
			if (IsPointInsideChar(_0023_003DzTx2aqr8_003D._0023_003Dz3YfTAqg_003D, _0023_003DzTx2aqr8_003D._0023_003DzpilgH4E_003D, points))
			{
				return false;
			}
		}
		if (!IsPointInsideChar(_0023_003DzTx2aqr8_003D._0023_003DzRFb1SGo_003D, _0023_003DzTx2aqr8_003D._0023_003Dz8qV981c_003D, _0023_003DzsdySxIlQLgFZ))
		{
			return false;
		}
		array = _0023_003DzWaFlkhfmYCja;
		foreach (Point2D[] points2 in array)
		{
			if (IsPointInsideChar(_0023_003DzTx2aqr8_003D._0023_003DzRFb1SGo_003D, _0023_003DzTx2aqr8_003D._0023_003Dz8qV981c_003D, points2))
			{
				return false;
			}
		}
		return true;
	}

	public static bool IsPointInsideChar(double x, double y, Point2D[] points)
	{
		int num = points.Length;
		if (num < 3)
		{
			return false;
		}
		int num2 = 0;
		Point2D point2D = points[num2];
		bool flag = false;
		for (int i = 0; i < num; i++)
		{
			Point2D point2D2 = points[num2];
			num2++;
			Point2D point2D3 = ((i == num - 1) ? point2D : points[num2]);
			if (((point2D2.Y < y && point2D3.Y >= y) || (point2D3.Y < y && point2D2.Y >= y)) && point2D2.X + (y - point2D2.Y) / (point2D3.Y - point2D2.Y) * (point2D3.X - point2D2.X) < x)
			{
				flag = !flag;
			}
		}
		return flag;
	}

	private void _0023_003DzI9tkmcDemGKs()
	{
		List<Point3D> list = new List<Point3D>();
		foreach (Entity entity in entities)
		{
			list.Add(entity.BoxMin);
			list.Add(entity.BoxMax);
		}
		if (list.Count > 0)
		{
			boxMin = Point3D.MaxValue;
			boxMax = Point3D.MinValue;
			Utility.UpdateMinMax(null, list, list.Count, boxMin, boxMax);
		}
		else
		{
			boxMin = (boxMax = null);
		}
	}

	private void _0023_003DzATdiUwVz2L_00249(string _0023_003DzuwH5j5s_003D, TextStyle _0023_003Dzgkctzk6d2IIh, double _0023_003DzuCzANmziTJld)
	{
		double _0023_003DzGTN79r_0024F30Xo = 0.0;
		double _0023_003DzNbj8rYZeWiA = 0.0;
		_0023_003DzR8aYWyXm6crFsaZUZBMtoMwCrSnf._0023_003Dzd_0024POhtlm_0024NUA(_0023_003Dz8IQjC8udJMXQ(_0023_003DzuwH5j5s_003D[0], _0023_003Dzgkctzk6d2IIh.shapeFile.Shapes), new Point3D(_0023_003DzGTN79r_0024F30Xo, _0023_003DzNbj8rYZeWiA, 0.0), 1.0, 1.0, out var _0023_003DzXcLkCuQ_003D, out _0023_003DzGTN79r_0024F30Xo, out _0023_003DzNbj8rYZeWiA, out var _0023_003DzyxnDTtrmIGfX, out var _0023_003Dz1WsMKJau85vH);
		entities = new List<Entity>(_0023_003DzXcLkCuQ_003D);
		RegenParams data = new RegenParams(0.01);
		Scaling xform = new Scaling(_0023_003DzuCzANmziTJld, _0023_003DzuCzANmziTJld, _0023_003DzuCzANmziTJld);
		foreach (Entity entity in entities)
		{
			entity.TransformBy(xform);
			entity.Regen(data);
		}
		_0023_003DzI9tkmcDemGKs();
		if (boxMax != null)
		{
			Width = boxMax.X - boxMin.X;
			Width += 1.0 / 3.0;
		}
		else
		{
			Width = (_0023_003Dz1WsMKJau85vH.X - _0023_003DzyxnDTtrmIGfX.X) * _0023_003DzuCzANmziTJld;
		}
	}

	private static ShapeSymbol _0023_003Dz_gkf_KTThnbn(char? _0023_003DzRYQm6GE_003D, Dictionary<char, ShapeSymbol> _0023_003DzBkmNfz2ZeFuT, ReadOnlySpan<char> _0023_003DzUpy8_Ws_003D)
	{
		if (_0023_003DzRYQm6GE_003D.HasValue && _0023_003DzBkmNfz2ZeFuT.TryGetValue(_0023_003DzRYQm6GE_003D.Value, out var value))
		{
			return value;
		}
		for (int i = 0; i < _0023_003DzUpy8_Ws_003D.Length; i++)
		{
			if (_0023_003DzBkmNfz2ZeFuT.TryGetValue(_0023_003DzUpy8_Ws_003D[i], out value))
			{
				return value;
			}
		}
		if (_0023_003DzBkmNfz2ZeFuT.Count > 0)
		{
			return _0023_003DzBkmNfz2ZeFuT.Values.First();
		}
		throw new EyeshotException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302986163));
	}

	private static ShapeSymbol _0023_003Dz8IQjC8udJMXQ(char _0023_003Dz6itnqSU_003D, Dictionary<char, ShapeSymbol> _0023_003DzBkmNfz2ZeFuT)
	{
		return _0023_003Dz_gkf_KTThnbn(_0023_003Dz6itnqSU_003D, _0023_003DzBkmNfz2ZeFuT, _0023_003DzE5Riy1SEddky);
	}

	private static ShapeSymbol _0023_003DzoSkJHI1kQ0De(Dictionary<char, ShapeSymbol> _0023_003DzBkmNfz2ZeFuT)
	{
		return _0023_003Dz_gkf_KTThnbn(null, _0023_003DzBkmNfz2ZeFuT, _0023_003DzU8nvDvXJrG_B);
	}

	internal void _0023_003DzmHTSerA_003D(CompileParams _0023_003DzELu0Pss_003D)
	{
		foreach (Entity entity in entities)
		{
			if (entity.RegenMode == regenType.CompileOnly)
			{
				entity.Compile(_0023_003DzELu0Pss_003D);
			}
		}
		if (simplifiedFpc != null && simplifiedFpc.RegenMode != regenType.NotNeeded)
		{
			simplifiedFpc.Compile(_0023_003DzELu0Pss_003D);
		}
	}

	public void Dispose()
	{
		if (entities != null)
		{
			foreach (Entity entity in entities)
			{
				entity.Dispose();
			}
			entities = null;
		}
		if (simplifiedFpc != null)
		{
			simplifiedFpc.Dispose();
			simplifiedFpc = null;
		}
	}

	internal static double _0023_003Dzjfb687zJyEZd(TextStyle _0023_003Dzgkctzk6d2IIh, RenderContextBase _0023_003DzQdnFby4_003D)
	{
		if (_0023_003Dzgkctzk6d2IIh.IsSHX())
		{
			return _0023_003Dzw_0024S6wcTfxb1IFYHnLw_003D_003D(_0023_003Dzgkctzk6d2IIh);
		}
		return _0023_003DzQdnFby4_003D.GetQScaleFactor(_0023_003Dzgkctzk6d2IIh.FontFamilyName, _0023_003Dzgkctzk6d2IIh.Style);
	}

	private static double _0023_003Dzw_0024S6wcTfxb1IFYHnLw_003D_003D(TextStyle _0023_003Dz_0024wQZnFQ_003D)
	{
		Point3D maxValue = Point3D.MaxValue;
		Point3D minValue = Point3D.MinValue;
		_0023_003Dz80fgFmbu7cAyVQaO5A_003D_003D(_0023_003DzoSkJHI1kQ0De(_0023_003Dz_0024wQZnFQ_003D.shapeFile.Shapes), maxValue, minValue);
		return 1.0 / minValue.Y;
	}

	private static void _0023_003Dz80fgFmbu7cAyVQaO5A_003D_003D(ShapeSymbol _0023_003Dz7TFjJCU_003D, Point3D _0023_003DzsL7_0024FfebF80U, Point3D _0023_003DzVHyD9gGcBpN7)
	{
		double _0023_003DzGTN79r_0024F30Xo = 0.0;
		double _0023_003DzNbj8rYZeWiA = 0.0;
		_0023_003DzR8aYWyXm6crFsaZUZBMtoMwCrSnf._0023_003Dzd_0024POhtlm_0024NUA(_0023_003Dz7TFjJCU_003D, new Point3D(_0023_003DzGTN79r_0024F30Xo, _0023_003DzNbj8rYZeWiA, 0.0), 1.0, 1.0, out var _0023_003DzXcLkCuQ_003D, out _0023_003DzGTN79r_0024F30Xo, out _0023_003DzNbj8rYZeWiA, out var _, out var _);
		RegenParams data = new RegenParams(0.1);
		foreach (Entity item in _0023_003DzXcLkCuQ_003D)
		{
			item.Regen(data);
		}
		foreach (Entity item2 in _0023_003DzXcLkCuQ_003D)
		{
			Utility.UpdateMinMax(null, new Point3D[2] { item2.BoxMin, item2.BoxMax }, 2, _0023_003DzsL7_0024FfebF80U, _0023_003DzVHyD9gGcBpN7);
		}
	}

	internal void _0023_003DzwuJjRo0_003D(DrawParams _0023_003DzELu0Pss_003D, bool _0023_003DzbNC7E4A_003D, bool _0023_003DzxdfvBHJggvdJlEJN_0024LIJs8Y_003D)
	{
		string lineTypeName = null;
		GfxAttributes attributes = _0023_003DzELu0Pss_003D.Attributes;
		if (_0023_003DzbNC7E4A_003D && attributes != null)
		{
			lineTypeName = attributes.LineTypeName;
			attributes.LineTypeName = null;
		}
		if (_0023_003DzxdfvBHJggvdJlEJN_0024LIJs8Y_003D && simplifiedFpc != null)
		{
			simplifiedFpc.Draw(_0023_003DzELu0Pss_003D);
		}
		else
		{
			foreach (Entity entity in entities)
			{
				entity.Draw(_0023_003DzELu0Pss_003D);
			}
		}
		if (_0023_003DzbNC7E4A_003D)
		{
			_0023_003DzELu0Pss_003D.RenderContext.EndDrawBufferedLines();
			if (attributes != null)
			{
				attributes.LineTypeName = lineTypeName;
			}
			_0023_003DzELu0Pss_003D.RenderContext.TranslateMatrixModelView(Width, 0.0, 0.0);
		}
		else
		{
			_0023_003DzELu0Pss_003D.RenderContext.TranslateMatrixModelView(Width, 0.0, 0.0);
		}
	}
}
