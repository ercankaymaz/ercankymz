using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using devDept.Eyeshot.Entities;
using devDept.Geometry;

namespace devDept.Eyeshot.Milling;

public class Geometry3D : GeometryBase
{
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private readonly List<IFace> _0023_003Dz8TpHtIjptvm6;

	public Geometry3D(IFace face, double deviation = 0.0, double angleInRadians = 0.0)
		: this(new IFace[1] { face }, deviation, angleInRadians)
	{
	}

	public Geometry3D(IList<IFace> faces, double deviation = 0.0, double angleInRadians = 0.0)
	{
		base.deviation = deviation;
		angle = angleInRadians;
		_0023_003Dz8TpHtIjptvm6 = new List<IFace>(faces);
	}

	public Geometry3D(IList<Entity> entList, double deviation = 0.0, double angleInRadians = 0.0)
	{
		base.deviation = deviation;
		angle = angleInRadians;
		_0023_003Dz8TpHtIjptvm6 = new List<IFace>(entList.Count);
		foreach (Entity ent in entList)
		{
			if (ent is IFace item)
			{
				_0023_003Dz8TpHtIjptvm6.Add(item);
			}
		}
	}

	public Geometry3D(Document document, double deviation = 0.0, double angleInRadians = 0.0)
	{
		base.deviation = deviation;
		angle = angleInRadians;
		List<Entity> list = new List<Entity>();
		foreach (Entity entity in document.Entities)
		{
			if (entity is BlockReference blockReference)
			{
				bool keepTessellation = deviation == 0.0 && angleInRadians == 0.0;
				list.AddRange(blockReference.ExplodeDeep(document.Blocks, keepTessellation));
			}
			else
			{
				list.Add(entity);
			}
		}
		_0023_003Dz8TpHtIjptvm6 = new List<IFace>(list.Count);
		foreach (Entity item2 in list)
		{
			if (item2 is IFace item)
			{
				_0023_003Dz8TpHtIjptvm6.Add(item);
			}
		}
	}

	public Geometry3D(BlockReference br, BlockKeyedCollection blocks, double deviation = 0.0, double angleInRadians = 0.0)
	{
		base.deviation = deviation;
		angle = angleInRadians;
		Entity[] array = br.ExplodeDeep(blocks, deviation == 0.0 && angleInRadians == 0.0);
		_0023_003Dz8TpHtIjptvm6 = new List<IFace>(array.Length);
		Entity[] array2 = array;
		for (int i = 0; i < array2.Length; i++)
		{
			if (array2[i] is IFace item)
			{
				_0023_003Dz8TpHtIjptvm6.Add(item);
			}
		}
	}

	public double[] GetFlatZ(Setup setup)
	{
		return ((_0023_003DzcD_4B_0024jG8Sw_0024VKDeNr6LCoyK66_00243h4BoiJYiR9O9G3S7)_0023_003Dz0uCq1ns_003D[setup.Transformation])._0023_003Dz1ofti8KYjWYC;
	}

	private protected override void _0023_003DzjMq_0024wgdZc_00245l(Setup _0023_003Dz9cS3uG0_003D)
	{
		List<Point3D> list = new List<Point3D>();
		List<IndexTriangle> list2 = new List<IndexTriangle>();
		HashSet<double> hashSet = new HashSet<double>();
		_0023_003DzcD_4B_0024jG8Sw_0024VKDeNr6LCoyK66_00243h4BoiJYiR9O9G3S7 _0023_003DzcD_4B_0024jG8Sw_0024VKDeNr6LCoyK66_00243h4BoiJYiR9O9G3S8 = new _0023_003DzcD_4B_0024jG8Sw_0024VKDeNr6LCoyK66_00243h4BoiJYiR9O9G3S7();
		_0023_003DzcD_4B_0024jG8Sw_0024VKDeNr6LCoyK66_00243h4BoiJYiR9O9G3S8._0023_003DzLXv_WdC_s03R = new List<Entity>();
		_0023_003DzcD_4B_0024jG8Sw_0024VKDeNr6LCoyK66_00243h4BoiJYiR9O9G3S8._0023_003DzDPcjoBJLcqli = Point3D.MaxValue;
		_0023_003DzcD_4B_0024jG8Sw_0024VKDeNr6LCoyK66_00243h4BoiJYiR9O9G3S8._0023_003Dz_0024N_0024yKptW9BoC = Point3D.MinValue;
		foreach (IFace item in _0023_003Dz8TpHtIjptvm6)
		{
			IFace face = item;
			if (deviation != 0.0 || angle != 0.0)
			{
				face = (IFace)item.Clone();
				((Entity)face).Regen(new RegenParams(deviation, angle));
			}
			Mesh[] tessellation = face.GetTessellation();
			for (int i = 0; i < tessellation.Length; i++)
			{
				_0023_003DzcD_4B_0024jG8Sw_0024VKDeNr6LCoyK66_00243h4BoiJYiR9O9G3S8._0023_003DzLXv_WdC_s03R.Add(tessellation[i]);
				if (!_0023_003Dz9cS3uG0_003D._0023_003DzylonwpI_003D.IsIdentity())
				{
					tessellation[i] = (Mesh)tessellation[i].Clone();
					tessellation[i].TransformBy(_0023_003Dz9cS3uG0_003D._0023_003DzylonwpI_003D);
				}
			}
			Mesh[] array = tessellation;
			foreach (Mesh mesh in array)
			{
				int count = list.Count;
				list.AddRange(mesh.Vertices);
				IndexTriangle[] triangles = mesh.Triangles;
				foreach (IndexTriangle indexTriangle in triangles)
				{
					Point3D point3D = mesh.Vertices[indexTriangle.V1];
					Point3D point3D2 = mesh.Vertices[indexTriangle.V2];
					Point3D point3D3 = mesh.Vertices[indexTriangle.V3];
					Vector3D u = new Vector3D(point3D, point3D2, point3D3);
					_0023_003DzegNcgA4_003D(point3D, _0023_003DzcD_4B_0024jG8Sw_0024VKDeNr6LCoyK66_00243h4BoiJYiR9O9G3S8._0023_003DzDPcjoBJLcqli, _0023_003DzcD_4B_0024jG8Sw_0024VKDeNr6LCoyK66_00243h4BoiJYiR9O9G3S8._0023_003Dz_0024N_0024yKptW9BoC);
					_0023_003DzegNcgA4_003D(point3D2, _0023_003DzcD_4B_0024jG8Sw_0024VKDeNr6LCoyK66_00243h4BoiJYiR9O9G3S8._0023_003DzDPcjoBJLcqli, _0023_003DzcD_4B_0024jG8Sw_0024VKDeNr6LCoyK66_00243h4BoiJYiR9O9G3S8._0023_003Dz_0024N_0024yKptW9BoC);
					_0023_003DzegNcgA4_003D(point3D3, _0023_003DzcD_4B_0024jG8Sw_0024VKDeNr6LCoyK66_00243h4BoiJYiR9O9G3S8._0023_003DzDPcjoBJLcqli, _0023_003DzcD_4B_0024jG8Sw_0024VKDeNr6LCoyK66_00243h4BoiJYiR9O9G3S8._0023_003Dz_0024N_0024yKptW9BoC);
					_0023_003DzJSv_IuScKRfn _0023_003DzJSv_IuScKRfn2 = new _0023_003DzJSv_IuScKRfn(indexTriangle.V1 + count, indexTriangle.V2 + count, indexTriangle.V3 + count, list);
					if (Vector3D.AreParallel(u, Vector3D.AxisZ, Utility._0023_003DzxhnLabVjXjPg))
					{
						_0023_003DzJSv_IuScKRfn2._0023_003DzbmrKN9c_003D = true;
						hashSet.Add(point3D.Z);
					}
					list2.Add(_0023_003DzJSv_IuScKRfn2);
				}
			}
		}
		_0023_003DzcD_4B_0024jG8Sw_0024VKDeNr6LCoyK66_00243h4BoiJYiR9O9G3S8._0023_003DzYgig3E0mPH5X = list.ToArray();
		_0023_003DzcD_4B_0024jG8Sw_0024VKDeNr6LCoyK66_00243h4BoiJYiR9O9G3S8._0023_003Dzut6ZIMT6NDmd = list2.ToArray();
		_0023_003DzcD_4B_0024jG8Sw_0024VKDeNr6LCoyK66_00243h4BoiJYiR9O9G3S8._0023_003Dz1ofti8KYjWYC = _0023_003DzF4oOnFoXU6iK(hashSet, _0023_003DzcD_4B_0024jG8Sw_0024VKDeNr6LCoyK66_00243h4BoiJYiR9O9G3S8._0023_003DzmJUUXcrV4cbj().Z);
		_0023_003Dz0uCq1ns_003D.Add(_0023_003Dz9cS3uG0_003D.Transformation, _0023_003DzcD_4B_0024jG8Sw_0024VKDeNr6LCoyK66_00243h4BoiJYiR9O9G3S8);
	}

	public double[] GetInsideFlatZ(Setup setup, PolyRegion2D boundary, double tol)
	{
		HashSet<double> hashSet = new HashSet<double>();
		_0023_003DzcD_4B_0024jG8Sw_0024VKDeNr6LCoyK66_00243h4BoiJYiR9O9G3S7 _0023_003DzcD_4B_0024jG8Sw_0024VKDeNr6LCoyK66_00243h4BoiJYiR9O9G3S8 = _0023_003DztMJhNE87k67F(setup);
		Point3D _0023_003Dz_0024N_0024yKptW9BoC = _0023_003DzcD_4B_0024jG8Sw_0024VKDeNr6LCoyK66_00243h4BoiJYiR9O9G3S8._0023_003Dz_0024N_0024yKptW9BoC;
		Point3D[] _0023_003DzYgig3E0mPH5X = _0023_003DzcD_4B_0024jG8Sw_0024VKDeNr6LCoyK66_00243h4BoiJYiR9O9G3S8._0023_003DzYgig3E0mPH5X;
		IndexTriangle[] _0023_003Dzut6ZIMT6NDmd = _0023_003DzcD_4B_0024jG8Sw_0024VKDeNr6LCoyK66_00243h4BoiJYiR9O9G3S8._0023_003Dzut6ZIMT6NDmd;
		for (int i = 0; i < _0023_003Dzut6ZIMT6NDmd.Length; i++)
		{
			_0023_003DzJSv_IuScKRfn _0023_003DzJSv_IuScKRfn2 = (_0023_003DzJSv_IuScKRfn)_0023_003Dzut6ZIMT6NDmd[i];
			if (_0023_003DzJSv_IuScKRfn2._0023_003DzbmrKN9c_003D && !Machining.AreEqualZ(_0023_003DzYgig3E0mPH5X[_0023_003DzJSv_IuScKRfn2.V1].Z, _0023_003Dz_0024N_0024yKptW9BoC.Z, tol))
			{
				if (boundary.IsPointInside(_0023_003DzYgig3E0mPH5X[_0023_003DzJSv_IuScKRfn2.V1]))
				{
					hashSet.Add(_0023_003DzYgig3E0mPH5X[_0023_003DzJSv_IuScKRfn2.V1].Z);
				}
				else if (boundary.IsPointInside(_0023_003DzYgig3E0mPH5X[_0023_003DzJSv_IuScKRfn2.V2]))
				{
					hashSet.Add(_0023_003DzYgig3E0mPH5X[_0023_003DzJSv_IuScKRfn2.V2].Z);
				}
				else if (boundary.IsPointInside(_0023_003DzYgig3E0mPH5X[_0023_003DzJSv_IuScKRfn2.V3]))
				{
					hashSet.Add(_0023_003DzYgig3E0mPH5X[_0023_003DzJSv_IuScKRfn2.V3].Z);
				}
			}
		}
		return _0023_003DzF4oOnFoXU6iK(hashSet, _0023_003DzcD_4B_0024jG8Sw_0024VKDeNr6LCoyK66_00243h4BoiJYiR9O9G3S8._0023_003DzmJUUXcrV4cbj().Z);
	}

	internal static double[] _0023_003DzF4oOnFoXU6iK(IEnumerable<double> _0023_003DzCc4ZFO9199Rwc_0024RmhA_003D_003D, Interval _0023_003DzA4HfEuA_003D)
	{
		return _0023_003DzF4oOnFoXU6iK(_0023_003DzCc4ZFO9199Rwc_0024RmhA_003D_003D, _0023_003DzA4HfEuA_003D.Length);
	}

	internal static double[] _0023_003DzF4oOnFoXU6iK(IEnumerable<double> _0023_003DzCc4ZFO9199Rwc_0024RmhA_003D_003D, double _0023_003DzA4HfEuA_003D)
	{
		HashSet<double> hashSet = new HashSet<double>();
		int num = _0023_003Dz9AfN_TRv_0024HgPy9WmXQ_003D_003D(_0023_003DzA4HfEuA_003D);
		double num2 = Math.Pow(10.0, num);
		foreach (double item in _0023_003DzCc4ZFO9199Rwc_0024RmhA_003D_003D)
		{
			double num3 = Math.Round(item * num2);
			hashSet.Add(num3 / num2);
		}
		return hashSet.ToArray();
	}

	private static int _0023_003Dz9AfN_TRv_0024HgPy9WmXQ_003D_003D(double _0023_003DzPzO_0024GUk_003D)
	{
		if (_0023_003DzPzO_0024GUk_003D == 0.0)
		{
			return 0;
		}
		return (int)Math.Log10(Math.Abs(_0023_003DzPzO_0024GUk_003D));
	}

	private static void _0023_003DzegNcgA4_003D(Point3D _0023_003DzMlCq3wk_003D, Point3D _0023_003DzDPcjoBJLcqli, Point3D _0023_003Dz_0024N_0024yKptW9BoC)
	{
		if (_0023_003DzMlCq3wk_003D.X > _0023_003Dz_0024N_0024yKptW9BoC.X)
		{
			_0023_003Dz_0024N_0024yKptW9BoC.X = _0023_003DzMlCq3wk_003D.X;
		}
		if (_0023_003DzMlCq3wk_003D.X < _0023_003DzDPcjoBJLcqli.X)
		{
			_0023_003DzDPcjoBJLcqli.X = _0023_003DzMlCq3wk_003D.X;
		}
		if (_0023_003DzMlCq3wk_003D.Y > _0023_003Dz_0024N_0024yKptW9BoC.Y)
		{
			_0023_003Dz_0024N_0024yKptW9BoC.Y = _0023_003DzMlCq3wk_003D.Y;
		}
		if (_0023_003DzMlCq3wk_003D.Y < _0023_003DzDPcjoBJLcqli.Y)
		{
			_0023_003DzDPcjoBJLcqli.Y = _0023_003DzMlCq3wk_003D.Y;
		}
		if (_0023_003DzMlCq3wk_003D.Z > _0023_003Dz_0024N_0024yKptW9BoC.Z)
		{
			_0023_003Dz_0024N_0024yKptW9BoC.Z = _0023_003DzMlCq3wk_003D.Z;
		}
		if (_0023_003DzMlCq3wk_003D.Z < _0023_003DzDPcjoBJLcqli.Z)
		{
			_0023_003DzDPcjoBJLcqli.Z = _0023_003DzMlCq3wk_003D.Z;
		}
	}

	public Point3D[] GetVertices(Setup setup)
	{
		return _0023_003DztMJhNE87k67F(setup)._0023_003DzYgig3E0mPH5X;
	}

	public bool IsReadyParallel(Setup setup)
	{
		return _0023_003DztMJhNE87k67F(setup)._0023_003DzT0K_bDkwifYH;
	}

	public bool IsReadyWaterline(Setup setup)
	{
		return _0023_003DztMJhNE87k67F(setup)._0023_003DzgYpVuoifkCOePshqJ1vBFQQ_003D;
	}

	public void PreProcessParallel(Setup setup)
	{
		_0023_003DzcD_4B_0024jG8Sw_0024VKDeNr6LCoyK66_00243h4BoiJYiR9O9G3S7 _0023_003DzcD_4B_0024jG8Sw_0024VKDeNr6LCoyK66_00243h4BoiJYiR9O9G3S8 = _0023_003DztMJhNE87k67F(setup);
		IndexTriangle[] array = _0023_003DzcD_4B_0024jG8Sw_0024VKDeNr6LCoyK66_00243h4BoiJYiR9O9G3S8._0023_003Dzut6ZIMT6NDmd.ToArray();
		int _0023_003DzYGGMaJKVDWjo = (int)Math.Sqrt(array.Length);
		_0023_003DzcD_4B_0024jG8Sw_0024VKDeNr6LCoyK66_00243h4BoiJYiR9O9G3S8._0023_003DzQGR2MAMeTziV = new global::_0023_003Dz8Inhoy3521Lo4Ll5uw_003D_003D<_0023_003DzR0pHse6hl8ZsnAwb9Q_003D_003D>(_0023_003DzYGGMaJKVDWjo);
		List<_0023_003DzR0pHse6hl8ZsnAwb9Q_003D_003D> list = new List<_0023_003DzR0pHse6hl8ZsnAwb9Q_003D_003D>(array.Length);
		Point3D[] _0023_003DzYgig3E0mPH5X = _0023_003DzcD_4B_0024jG8Sw_0024VKDeNr6LCoyK66_00243h4BoiJYiR9O9G3S8._0023_003DzYgig3E0mPH5X;
		for (int i = 0; i < array.Length; i++)
		{
			_0023_003DzJSv_IuScKRfn _0023_003DzJSv_IuScKRfn2 = (_0023_003DzJSv_IuScKRfn)array[i];
			Point3D p = _0023_003DzYgig3E0mPH5X[_0023_003DzJSv_IuScKRfn2.V1];
			Point3D p2 = _0023_003DzYgig3E0mPH5X[_0023_003DzJSv_IuScKRfn2.V2];
			Point3D p3 = _0023_003DzYgig3E0mPH5X[_0023_003DzJSv_IuScKRfn2.V3];
			if (!Vector3D.AreOrthogonal(new Vector3D(p, p2, p3), Vector3D.AxisZ))
			{
				list.Add(new _0023_003DzR0pHse6hl8ZsnAwb9Q_003D_003D(_0023_003DzJSv_IuScKRfn2, 0));
			}
		}
		_0023_003DzcD_4B_0024jG8Sw_0024VKDeNr6LCoyK66_00243h4BoiJYiR9O9G3S8._0023_003DzQGR2MAMeTziV._0023_003Dz50A2mj71iWuX(list);
		_0023_003DzcD_4B_0024jG8Sw_0024VKDeNr6LCoyK66_00243h4BoiJYiR9O9G3S8._0023_003DzT0K_bDkwifYH = true;
	}

	public void PreProcessWaterline(Setup setup)
	{
		_0023_003DzcD_4B_0024jG8Sw_0024VKDeNr6LCoyK66_00243h4BoiJYiR9O9G3S7 _0023_003DzcD_4B_0024jG8Sw_0024VKDeNr6LCoyK66_00243h4BoiJYiR9O9G3S8 = _0023_003DztMJhNE87k67F(setup);
		IndexTriangle[] array = _0023_003DzcD_4B_0024jG8Sw_0024VKDeNr6LCoyK66_00243h4BoiJYiR9O9G3S8._0023_003Dzut6ZIMT6NDmd.ToArray();
		int _0023_003DzYGGMaJKVDWjo = (int)Math.Sqrt(array.Length);
		_0023_003DzcD_4B_0024jG8Sw_0024VKDeNr6LCoyK66_00243h4BoiJYiR9O9G3S8._0023_003DzcDVIi3x5N3_a = new global::_0023_003Dz8Inhoy3521Lo4Ll5uw_003D_003D<_0023_003DzR0pHse6hl8ZsnAwb9Q_003D_003D>(_0023_003DzYGGMaJKVDWjo);
		_0023_003DzR0pHse6hl8ZsnAwb9Q_003D_003D[] array2 = new _0023_003DzR0pHse6hl8ZsnAwb9Q_003D_003D[array.Length];
		for (int i = 0; i < array.Length; i++)
		{
			array2[i] = new _0023_003DzR0pHse6hl8ZsnAwb9Q_003D_003D((_0023_003DzJSv_IuScKRfn)array[i], 1);
		}
		_0023_003DzcD_4B_0024jG8Sw_0024VKDeNr6LCoyK66_00243h4BoiJYiR9O9G3S8._0023_003DzcDVIi3x5N3_a._0023_003Dz50A2mj71iWuX(array2);
		_0023_003DzcD_4B_0024jG8Sw_0024VKDeNr6LCoyK66_00243h4BoiJYiR9O9G3S8._0023_003DzXUCtsuFWp7nj = new global::_0023_003Dz8Inhoy3521Lo4Ll5uw_003D_003D<_0023_003DzR0pHse6hl8ZsnAwb9Q_003D_003D>(_0023_003DzYGGMaJKVDWjo);
		for (int j = 0; j < array.Length; j++)
		{
			array2[j] = new _0023_003DzR0pHse6hl8ZsnAwb9Q_003D_003D((_0023_003DzJSv_IuScKRfn)array[j], 2);
		}
		_0023_003DzcD_4B_0024jG8Sw_0024VKDeNr6LCoyK66_00243h4BoiJYiR9O9G3S8._0023_003DzXUCtsuFWp7nj._0023_003Dz50A2mj71iWuX(array2);
		_0023_003DzcD_4B_0024jG8Sw_0024VKDeNr6LCoyK66_00243h4BoiJYiR9O9G3S8._0023_003DzgYpVuoifkCOePshqJ1vBFQQ_003D = true;
	}

	internal IEnumerable<_0023_003DzR0pHse6hl8ZsnAwb9Q_003D_003D> _0023_003Dzqjt65kap4ZyB(Setup _0023_003Dz9cS3uG0_003D, _0023_003DzBhBGHtMU6jbT _0023_003DzAdkfXSo_003D)
	{
		return _0023_003DztMJhNE87k67F(_0023_003Dz9cS3uG0_003D)._0023_003DzQGR2MAMeTziV._0023_003DzM_Ie8ic_003D(_0023_003DzAdkfXSo_003D);
	}

	internal IEnumerable<_0023_003DzR0pHse6hl8ZsnAwb9Q_003D_003D> _0023_003Dzu8c_0024Qa7dROnn(Setup _0023_003Dz9cS3uG0_003D, _0023_003DzBhBGHtMU6jbT _0023_003DzAdkfXSo_003D)
	{
		return _0023_003DztMJhNE87k67F(_0023_003Dz9cS3uG0_003D)._0023_003DzcDVIi3x5N3_a._0023_003DzM_Ie8ic_003D(_0023_003DzAdkfXSo_003D);
	}

	internal IEnumerable<_0023_003DzR0pHse6hl8ZsnAwb9Q_003D_003D> _0023_003Dzv7thx1d7ANpN(Setup _0023_003Dz9cS3uG0_003D, _0023_003DzBhBGHtMU6jbT _0023_003DzAdkfXSo_003D)
	{
		return _0023_003DztMJhNE87k67F(_0023_003Dz9cS3uG0_003D)._0023_003DzXUCtsuFWp7nj._0023_003DzM_Ie8ic_003D(_0023_003DzAdkfXSo_003D);
	}

	internal Mesh _0023_003Dz5dGcIxd3bgq7(Setup _0023_003Dz9cS3uG0_003D)
	{
		_0023_003DzcD_4B_0024jG8Sw_0024VKDeNr6LCoyK66_00243h4BoiJYiR9O9G3S7 obj = _0023_003DztMJhNE87k67F(_0023_003Dz9cS3uG0_003D);
		Point3D[] _0023_003DzYgig3E0mPH5X = obj._0023_003DzYgig3E0mPH5X;
		IndexTriangle[] _0023_003Dzut6ZIMT6NDmd = obj._0023_003Dzut6ZIMT6NDmd;
		Point3D[] array = new Point3D[_0023_003Dzut6ZIMT6NDmd.Length * 3];
		IndexTriangle[] array2 = new IndexTriangle[_0023_003Dzut6ZIMT6NDmd.Length];
		if (_0023_003Dzut6ZIMT6NDmd.Length != 0)
		{
			int num = 0;
			IndexTriangle[] array3 = _0023_003Dzut6ZIMT6NDmd;
			for (int i = 0; i < array3.Length; i++)
			{
				_0023_003DzJSv_IuScKRfn _0023_003DzJSv_IuScKRfn2 = (_0023_003DzJSv_IuScKRfn)array3[i];
				array[num * 3] = _0023_003DzYgig3E0mPH5X[_0023_003DzJSv_IuScKRfn2.V1];
				array[num * 3 + 1] = _0023_003DzYgig3E0mPH5X[_0023_003DzJSv_IuScKRfn2.V2];
				array[num * 3 + 2] = _0023_003DzYgig3E0mPH5X[_0023_003DzJSv_IuScKRfn2.V3];
				array2[num] = new IndexTriangle(num * 3, num * 3 + 1, num * 3 + 2);
				num++;
			}
			Utility.Compact(array, array2, out var compacted);
			return new Mesh(compacted, array2);
		}
		return new Mesh(new Point3D[0], new IndexTriangle[0]);
	}

	private _0023_003DzcD_4B_0024jG8Sw_0024VKDeNr6LCoyK66_00243h4BoiJYiR9O9G3S7 _0023_003DztMJhNE87k67F(Setup _0023_003Dz9cS3uG0_003D)
	{
		return (_0023_003DzcD_4B_0024jG8Sw_0024VKDeNr6LCoyK66_00243h4BoiJYiR9O9G3S7)_0023_003Dz0uCq1ns_003D[_0023_003Dz9cS3uG0_003D.Transformation];
	}

	public override string ToString()
	{
		return string.Format(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302994580), ((_0023_003DzcD_4B_0024jG8Sw_0024VKDeNr6LCoyK66_00243h4BoiJYiR9O9G3S7)_0023_003Dz0uCq1ns_003D.Values.First())._0023_003Dzut6ZIMT6NDmd.Length);
	}
}
