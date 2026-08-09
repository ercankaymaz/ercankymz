using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using devDept.Eyeshot;
using devDept.Eyeshot.Entities;
using devDept.Geometry.Blink;
using devDept.Graphics;

namespace devDept.Geometry;

public static class BlinkCommands
{
	[Serializable]
	private sealed class _0023_003Dz2IEmqow_003D
	{
		public static readonly _0023_003Dz2IEmqow_003D _0023_003DzJ5g3Rwo_003D = new _0023_003Dz2IEmqow_003D();

		public static Func<Polygon2D, ICurve> _0023_003DzDoSgWJdj1Kh_0024xAwwFQ_003D_003D;

		public static Func<Segment2D, IEnumerable<Point3D>> _0023_003DzCFS_oNGgfk77xyYYaw_003D_003D;

		public static Func<Segment3D, IEnumerable<Point3D>> _0023_003DzXPzGEwjBMtIuXM3_mg_003D_003D;

		internal ICurve _0023_003DzzurQukNExyHYAaKr41F3wJQ_003D(Polygon2D _0023_003Dz47M02QY_003D)
		{
			return new LinearPath(Plane.XY, _0023_003Dz47M02QY_003D.Points);
		}

		internal IEnumerable<Point3D> _0023_003DzmgSMoH5wugfrTdQ4KI9dui8_003D(Segment2D _0023_003DzuwH5j5s_003D)
		{
			return new Point3D[2]
			{
				_0023_003DzuwH5j5s_003D.P0._0023_003DzsGH6XgHddTc_0024(),
				_0023_003DzuwH5j5s_003D.P1._0023_003DzsGH6XgHddTc_0024()
			};
		}

		internal IEnumerable<Point3D> _0023_003DzXRuFanyPq2hKg_0024uaG2XegIs_003D(Segment3D _0023_003DzuwH5j5s_003D)
		{
			return new Point3D[2] { _0023_003DzuwH5j5s_003D.P0, _0023_003DzuwH5j5s_003D.P1 };
		}
	}

	private static class _0023_003DziLG3fxehpOKSqKdpO6f4TpQ_003D<_0023_003DzWWgGxds_003D> where _0023_003DzWWgGxds_003D : Point2D
	{
		public static Func<_0023_003DzWWgGxds_003D, Point3D> _0023_003DzrGgCvBW_0024Mx0jJVHxng_003D_003D;
	}

	private static class _0023_003DzrL_0024RpTYnanFWBuDsqtBpeqQEPkx4<_0023_003DzWWgGxds_003D> where _0023_003DzWWgGxds_003D : Point2D
	{
		public static Func<_0023_003DzWWgGxds_003D, Point3D> _0023_003DzrGgCvBW_0024Mx0jJVHxng_003D_003D;
	}

	public static void Clear(string layer = null)
	{
		Client.Clear(layer);
	}

	public static void SetView(viewType view)
	{
		Client.SetView(view);
	}

	public static void ZoomFit(IList<Entity> entList = null)
	{
		Client.ZoomFit(entList);
	}

	public static void SetBackfaceColorMethod(backfaceColorMethodType colorMethod)
	{
		Client.SetBackfaceColorMethod(colorMethod);
	}

	public static void ForceSend()
	{
		Client.ForceSend();
	}

	internal static bool _0023_003Dzt6sRNJEKlIH5()
	{
		return Server.AlreadyRunning();
	}

	public static void Blink<T>(this T entity, Color? color = null, float? lineWeight = null, string layerName = null) where T : Entity
	{
		Client.Blink(entity, color, lineWeight, layerName);
	}

	public static void Blink<T>(this IEnumerable<T> entities, Color? color = null, float? lineWeight = null, string layerName = null) where T : Entity
	{
		Client.Blink(entities, color, lineWeight, layerName);
	}

	public static void Blink(this ICurve curve, Color? color = null, float? lineWeight = null, string layerName = null)
	{
		Client.Blink((Entity)curve, color, lineWeight, layerName);
	}

	public static void Blink(this IEnumerable<ICurve> curves, Color? color = null, float? lineWeight = null, string layerName = null)
	{
		Client.Blink(curves.Cast<Entity>(), color, lineWeight, layerName);
	}

	public static void Blink(this TrimCurve trimCurve, Color? color = null, float? lineWeight = null, string layerName = null)
	{
		Client.Blink(new global::_0023_003DzQ7KJPYazFHsNmrIUbA_003D_003D<Entity>(new Entity[2]
		{
			trimCurve,
			(Entity)trimCurve.Edge
		}), color, lineWeight, layerName);
	}

	public static void Blink(this IEnumerable<TrimCurve> trimCurves, Color? color = null, float? lineWeight = null, string layerName = null)
	{
		TrimCurve[] array = trimCurves.ToArray();
		Entity[] array2 = new Entity[array.Length * 2];
		for (int i = 0; i < array.Length; i++)
		{
			int num = i * 2;
			array2[num] = array[i];
			array2[num + 1] = (Entity)array[i].Edge;
		}
		Client.Blink(array2, color, lineWeight, layerName);
	}

	public static void Blink(this devDept.Eyeshot.Entities.Region region, Color? color = null, float? lineWeight = null, string layerName = null)
	{
		Client.Blink(_0023_003DzTWJqyEkTfla1(region), color, lineWeight, layerName);
	}

	public static void Blink(this IEnumerable<devDept.Eyeshot.Entities.Region> regions, Color? color = null, float? lineWeight = null, string layerName = null)
	{
		List<Entity> list = new List<Entity>();
		foreach (devDept.Eyeshot.Entities.Region region in regions)
		{
			list.AddRange(_0023_003DzTWJqyEkTfla1(region));
		}
		Client.Blink(list, color, lineWeight, layerName);
	}

	private static List<Entity> _0023_003DzTWJqyEkTfla1(devDept.Eyeshot.Entities.Region _0023_003Dz7revxoQ_003D)
	{
		List<Entity> list = new List<Entity>(1) { _0023_003Dz7revxoQ_003D };
		foreach (ICurve contour in _0023_003Dz7revxoQ_003D.contourList)
		{
			ICurve[] individualCurves = contour.GetIndividualCurves();
			for (int i = 0; i < individualCurves.Length; i++)
			{
				if (individualCurves[i] is TrimCurve trimCurve)
				{
					list.Add((Entity)trimCurve.Edge);
				}
			}
		}
		return list;
	}

	public static void Blink(this CompositeCurve compositeCurve, Color? color = null, float? lineWeight = null, string layerName = null)
	{
		Client.Blink(_0023_003Dzf6xvjOmxj3nU(compositeCurve), color, lineWeight, layerName);
	}

	public static void Blink(this IEnumerable<CompositeCurve> compositeCurves, Color? color = null, float? lineWeight = null, string layerName = null)
	{
		List<Entity> list = new List<Entity>();
		foreach (CompositeCurve compositeCurf in compositeCurves)
		{
			list.AddRange(_0023_003Dzf6xvjOmxj3nU(compositeCurf));
		}
		Client.Blink(list, color, lineWeight, layerName);
	}

	private static List<Entity> _0023_003Dzf6xvjOmxj3nU(CompositeCurve _0023_003DzpnTqeBX8cyzS)
	{
		List<Entity> list = new List<Entity>(1) { _0023_003DzpnTqeBX8cyzS };
		ICurve[] individualCurves = _0023_003DzpnTqeBX8cyzS.GetIndividualCurves();
		for (int i = 0; i < individualCurves.Length; i++)
		{
			if (individualCurves[i] is TrimCurve trimCurve)
			{
				list.Add((Entity)trimCurve.Edge);
			}
		}
		return list;
	}

	private static Point3D _0023_003DzsGH6XgHddTc_0024<T>(this T _0023_003DzlY77YgY_003D) where T : Point2D
	{
		return (_0023_003DzlY77YgY_003D as Point4D)?.Euclid ?? (_0023_003DzlY77YgY_003D as Point3D) ?? new Point3D(_0023_003DzlY77YgY_003D.X, _0023_003DzlY77YgY_003D.Y);
	}

	private static Point3D[] _0023_003DzsGH6XgHddTc_0024<T>(this IEnumerable<T> _0023_003DzrdSL0CI_003D) where T : Point2D
	{
		return _0023_003DzrdSL0CI_003D.Select((T _0023_003DzlY77YgY_003D) => (_0023_003DzlY77YgY_003D as Point4D)?.Euclid ?? (_0023_003DzlY77YgY_003D as Point3D) ?? new Point3D(_0023_003DzlY77YgY_003D.X, _0023_003DzlY77YgY_003D.Y)).ToArray();
	}

	public static void BlinkCloud<T>(this IEnumerable<T> points, Color? color = null, float? lineWeight = 10f, string layerName = null) where T : Point2D
	{
		Client.Blink(new PointCloud(points._0023_003DzsGH6XgHddTc_0024()), color, lineWeight, layerName);
	}

	public static void BlinkCloud<T>(this T[,] points, Color? color = null, float? lineWeight = 10f, string layerName = null) where T : Point2D
	{
		(from T _0023_003DzlY77YgY_003D in points
			select (_0023_003DzlY77YgY_003D as Point4D)?.Euclid ?? (_0023_003DzlY77YgY_003D as Point3D) ?? new Point3D(_0023_003DzlY77YgY_003D.X, _0023_003DzlY77YgY_003D.Y)).ToArray().BlinkCloud(color, lineWeight, layerName);
	}

	public static void BlinkPath<T>(this IEnumerable<T> points, Color? color = null, float? lineWeight = null, string layerName = null) where T : Point2D
	{
		Client.Blink(new LinearPath(points._0023_003DzsGH6XgHddTc_0024()), color, lineWeight, layerName);
	}

	public static void BlinkPath<T>(this IEnumerable<IEnumerable<T>> points, Color? color = null, float? lineWeight = null, string layerName = null) where T : Point2D
	{
		foreach (IEnumerable<T> point in points)
		{
			point.BlinkPath(color, lineWeight, layerName);
		}
	}

	public static void Blink(this Vector3D vector, Color? color = null, string layerName = null)
	{
		Client.Blink(vector, null, color, layerName);
	}

	public static void Blink(this Vector2D vector, Color? color = null, string layerName = null)
	{
		Client.Blink(vector, null, color, layerName);
	}

	public static void Blink(this Vector3D vector, Point3D startPoint, Color? color = null, string layerName = null)
	{
		Client.Blink(vector, startPoint, color, layerName);
	}

	public static void Blink(this Vector2D vector, Point2D startPoint, Color? color = null, string layerName = null)
	{
		Client.Blink(vector, new Point3D(startPoint.X, startPoint.Y, 0.0), color, layerName);
	}

	public static void Blink(this Plane pln, double size = 100.0, Color? color = null, float? lineWeight = null, string layerName = null)
	{
		Client.Blink(new PlanarEntity(pln, size), color, lineWeight, layerName);
	}

	public static void Blink(this AnalyticSurf aSurf, double size = 100.0, Color? color = null, float? lineWeight = null, string layerName = null)
	{
		if (aSurf is RevolvedSurf revolvedSurf)
		{
			revolvedSurf.Generatrix.GetNurbsForm()._0023_003Dz2Ew9vDIo4RqEw9OnJ5wRuuQ_003D(new Segment3D(revolvedSurf.Plane.Origin, revolvedSurf.Plane.Origin + revolvedSurf.Plane.AxisZ), out var _0023_003Dz9ulfqf0M07_0024x);
			Client.Blink(new PlanarEntity(revolvedSurf.Plane, _0023_003Dz9ulfqf0M07_0024x * 1.1), color, lineWeight, layerName);
			Client.Blink(revolvedSurf.GetSurface(null)[0], color, lineWeight, layerName);
		}
		else if (aSurf is ToroidalSurf toroidalSurf)
		{
			Client.Blink(new PlanarEntity(toroidalSurf.Plane, (toroidalSurf.MajorRadius + toroidalSurf.MinorRadius) * 1.1), color, lineWeight, layerName);
			Client.Blink(toroidalSurf.GetSurface(null)[0], color, lineWeight, layerName);
		}
		else if (aSurf is SphericalSurf sphericalSurf)
		{
			Client.Blink(new PlanarEntity(sphericalSurf.Plane, sphericalSurf.Radius * 1.1), color, lineWeight, layerName);
			Client.Blink(sphericalSurf.GetSurface(null), color, lineWeight, layerName);
		}
		else if (aSurf is ConicalSurf conicalSurf)
		{
			Client.Blink(new PlanarEntity(conicalSurf.Plane, conicalSurf.Radius * 1.1), color, lineWeight, layerName);
			Circle circle = new Circle(conicalSurf.Plane, conicalSurf.Radius);
			Client.Blink(circle, color, lineWeight, layerName);
			new Line(circle.StartPoint, conicalSurf.Tip).Blink();
		}
		else if (aSurf is CylindricalSurf cylindricalSurf)
		{
			Client.Blink(new PlanarEntity(cylindricalSurf.Plane, cylindricalSurf.Radius * 1.1), color, lineWeight, layerName);
			Client.Blink(new Circle(cylindricalSurf.Plane, cylindricalSurf.Radius), color, lineWeight, layerName);
		}
		else if (aSurf is PlanarSurf planarSurf)
		{
			Client.Blink(new PlanarEntity(planarSurf.Plane, size), color, lineWeight, layerName);
		}
		else if (aSurf is TabulatedSurf tabulatedSurf)
		{
			tabulatedSurf.Directrix.Blink(color, lineWeight, layerName);
			tabulatedSurf.Generatrix.Blink(tabulatedSurf.Directrix.StartPoint, color, layerName);
		}
		else if (aSurf is NurbsSurf nurbsSurf)
		{
			Client.Blink(nurbsSurf.GetSurface(null)[0], color, lineWeight, layerName);
		}
	}

	public static void Blink(this Polygon2D polygon, Color? color = null, float? lineWeight = null, string layerName = null)
	{
		Client.Blink(new LinearPath(Plane.XY, polygon.Points), color, lineWeight, layerName);
	}

	public static void Blink(this IList<Polygon2D> polygons, Color? color = null, float? lineWeight = null, string layerName = null)
	{
		LinearPath[] array = new LinearPath[polygons.Count];
		for (int i = 0; i < polygons.Count; i++)
		{
			array[i] = new LinearPath(Plane.XY, polygons[i].Points);
		}
		Client.Blink(array, color, lineWeight, layerName);
	}

	public static void Blink(this PolyRegion2D region, Color? color = null, float? lineWeight = null, string layerName = null)
	{
		Client.Blink(new devDept.Eyeshot.Entities.Region(region.ContourList.Select(_0023_003Dz2IEmqow_003D._0023_003DzJ5g3Rwo_003D._0023_003DzzurQukNExyHYAaKr41F3wJQ_003D).ToArray()), color, lineWeight, layerName);
	}

	public static void Blink(this Point3D point, Color? color = null, float? lineWeight = 10f, string layerName = null)
	{
		Client.Blink(new devDept.Eyeshot.Entities.Point(point), color, lineWeight, layerName);
	}

	public static void Blink<T>(this IList<T> points, Color? color = null, float? lineWeight = 10f, string layerName = null) where T : Point2D
	{
		devDept.Eyeshot.Entities.Point[] array = new devDept.Eyeshot.Entities.Point[points.Count()];
		for (int i = 0; i < array.Length; i++)
		{
			array[i] = new devDept.Eyeshot.Entities.Point(points[i]._0023_003DzsGH6XgHddTc_0024());
		}
		Client.Blink(array, color, lineWeight, layerName);
	}

	public static void Blink(this Point2D point, Color? color = null, float? lineWeight = 10f, string layerName = null)
	{
		Client.Blink(new devDept.Eyeshot.Entities.Point(point), color, lineWeight, layerName);
	}

	public static void Blink(this Brep.Face face, Brep brep, Color? color = null, float? lineWeight = null, string layerName = null)
	{
		Client.Blink(_0023_003Dz5LeQTIJxzJ_0024o5SvLOOhTE6X3Tl3gwe0wBA_003D_003D(face, brep), color, lineWeight, layerName);
	}

	public static void Blink(this IEnumerable<Brep.Face> faces, Brep brep, Color? color = null, float? lineWeight = null, string layerName = null)
	{
		List<Surface> list = new List<Surface>();
		foreach (Brep.Face face in faces)
		{
			list.AddRange(_0023_003Dz5LeQTIJxzJ_0024o5SvLOOhTE6X3Tl3gwe0wBA_003D_003D(face, brep));
		}
		Client.Blink(list, color, lineWeight, layerName);
	}

	private static Surface[] _0023_003Dz5LeQTIJxzJ_0024o5SvLOOhTE6X3Tl3gwe0wBA_003D_003D(Brep.Face _0023_003DzHEpjcdg2hk9U, Brep _0023_003DzGb8kdyZ1x5nj)
	{
		if (_0023_003DzHEpjcdg2hk9U.Parametric != null)
		{
			return _0023_003DzHEpjcdg2hk9U.Parametric;
		}
		List<Brep.Vertex> list = new List<Brep.Vertex>();
		HashSet<int> hashSet = new HashSet<int>();
		List<Brep.Edge> list2 = new List<Brep.Edge>();
		Dictionary<int, int> dictionary = new Dictionary<int, int>();
		Brep.Face[] array = new Brep.Face[1] { (Brep.Face)_0023_003DzHEpjcdg2hk9U.CloneWithTessellation() };
		for (int i = 0; i < array[0].Loops.Length; i++)
		{
			for (int j = 0; j < array[0].Loops[i].Segments.Length; j++)
			{
				if (!dictionary.TryGetValue(array[0].Loops[i].Segments[j].CurveIndex, out var value))
				{
					Brep.Edge edge = (Brep.Edge)_0023_003DzGb8kdyZ1x5nj.Edges[array[0].Loops[i].Segments[j].CurveIndex].CloneWithTessellation();
					array[0].Loops[i].Segments[j].CurveIndex = list2.Count;
					edge.Curve.EdgeIndex = list2.Count;
					edge.Parents = null;
					list2.Add(edge);
					if (hashSet.Add(edge.StartPointIndex))
					{
						edge.StartPointIndex = list.Count;
						Brep.Vertex vertex = (Brep.Vertex)_0023_003DzGb8kdyZ1x5nj.Vertices[edge.StartPointIndex].Clone();
						vertex.Parents = null;
						list.Add(vertex);
					}
					if (hashSet.Add(edge.EndPointIndex))
					{
						edge.EndPointIndex = list.Count;
						Brep.Vertex vertex2 = (Brep.Vertex)_0023_003DzGb8kdyZ1x5nj.Vertices[edge.EndPointIndex].Clone();
						vertex2.Parents = null;
						list.Add(vertex2);
					}
				}
				else
				{
					array[0].Loops[i].Segments[j].CurveIndex = value;
				}
			}
		}
		Point3D[] _0023_003Dzk98RESByZO6KwZuGTA_003D_003D = list.ToArray();
		Brep brep = new Brep(_0023_003Dzk98RESByZO6KwZuGTA_003D_003D, list2.ToArray(), array.ToArray(), _0023_003DzqMxdROkOZ2gG: true, null, _0023_003DzPPoX8HETqTZN: false, _0023_003DzMcq9hcRIFsnaUZ3PgA_003D_003D: false);
		brep.Rebuild();
		return brep.Faces[0].Parametric;
	}

	public static void Blink(this Brep.Loop loop, IList<Brep.Edge> edges, Color? color = null, float? lineWeight = null, string layerName = null)
	{
		_0023_003DzXjBFDIin0abuYVBM_0024A_003D_003D(loop, edges, color, lineWeight, layerName);
	}

	public static void Blink(this Brep.Loop loop, Brep brep, Color? color = null, float? lineWeight = null, string layerName = null)
	{
		_0023_003DzXjBFDIin0abuYVBM_0024A_003D_003D(loop, brep.Edges, color, lineWeight, layerName);
	}

	public static void Blink(this IEnumerable<Brep.Loop> loops, IList<Brep.Edge> edges, Color? color = null, float? lineWeight = null, string layerName = null)
	{
		_0023_003DzXgasU7AgJRcUkcFnPw_003D_003D(loops, edges, color, lineWeight, layerName);
	}

	public static void Blink(this IEnumerable<Brep.Loop> loops, Brep brep, Color? color = null, float? lineWeight = null, string layerName = null)
	{
		_0023_003DzXgasU7AgJRcUkcFnPw_003D_003D(loops, brep.Edges, color, lineWeight, layerName);
	}

	private static void _0023_003DzXjBFDIin0abuYVBM_0024A_003D_003D(Brep.Loop _0023_003DzdEvMFOw_003D, IList<Brep.Edge> _0023_003DzU3hosSAzkxO7, Color? _0023_003Dz1MMYB1g_003D, float? _0023_003DzxOQTW6c4mcu_0024, string _0023_003DzaROjBYA_003D)
	{
		Entity[] array = new Entity[_0023_003DzdEvMFOw_003D.Segments.Length];
		for (int i = 0; i < _0023_003DzdEvMFOw_003D.Segments.Length; i++)
		{
			Brep.OrientedEdge orientedEdge = _0023_003DzdEvMFOw_003D.Segments[i];
			ICurve orientedCurve = orientedEdge.GetOrientedCurve(_0023_003DzU3hosSAzkxO7);
			if (!_0023_003DzdEvMFOw_003D.Sense)
			{
				orientedCurve.Reverse();
			}
			array[i] = (Entity)orientedCurve;
		}
		Client.Blink(array, _0023_003Dz1MMYB1g_003D, _0023_003DzxOQTW6c4mcu_0024, _0023_003DzaROjBYA_003D);
	}

	private static void _0023_003DzXgasU7AgJRcUkcFnPw_003D_003D(IEnumerable<Brep.Loop> _0023_003Dzcv8o5nO25OjS, IList<Brep.Edge> _0023_003DzU3hosSAzkxO7, Color? _0023_003Dz1MMYB1g_003D, float? _0023_003DzxOQTW6c4mcu_0024, string _0023_003DzaROjBYA_003D)
	{
		List<Entity> list = new List<Entity>();
		foreach (Brep.Loop _0023_003Dzcv8o5nO25Oj in _0023_003Dzcv8o5nO25OjS)
		{
			Brep.OrientedEdge[] segments = _0023_003Dzcv8o5nO25Oj.Segments;
			foreach (Brep.OrientedEdge orientedEdge in segments)
			{
				ICurve orientedCurve = orientedEdge.GetOrientedCurve(_0023_003DzU3hosSAzkxO7);
				if (!_0023_003Dzcv8o5nO25Oj.Sense)
				{
					orientedCurve.Reverse();
				}
				list.Add((Entity)orientedCurve);
			}
		}
		Client.Blink(list, _0023_003Dz1MMYB1g_003D, _0023_003DzxOQTW6c4mcu_0024, _0023_003DzaROjBYA_003D);
	}

	public static void Blink(this Brep.Edge edge, Color? color = null, float? lineWeight = null, string layerName = null)
	{
		Client.Blink((Entity)edge.Curve, color, lineWeight, layerName);
	}

	public static void Blink(this IEnumerable<Brep.Edge> edges, Color? color = null, float? lineWeight = null, string layerName = null)
	{
		List<Entity> list = new List<Entity>();
		foreach (Brep.Edge edge in edges)
		{
			list.Add((Entity)(edge?.Curve));
		}
		Client.Blink(list, color, lineWeight, layerName);
	}

	public static void Blink(this Brep.OrientedEdge orientedEdge, IList<Brep.Edge> edges, Color? color = null, float? lineWeight = null, string layerName = null)
	{
		Client.Blink((Entity)orientedEdge.GetOrientedCurve(edges), color, lineWeight, layerName);
	}

	public static void Blink(this Brep.OrientedEdge orientedEdge, Brep brep, Color? color = null, float? lineWeight = null, string layerName = null)
	{
		Client.Blink((Entity)orientedEdge.GetOrientedCurve(brep.Edges), color, lineWeight, layerName);
	}

	public static void Blink(this IEnumerable<Brep.OrientedEdge> orientedEdges, IList<Brep.Edge> edges, Color? color = null, float? lineWeight = null, string layerName = null)
	{
		_0023_003DzIvAPS_V4KHAYEWtAFLpBfFhWFVbc(orientedEdges, edges, color, lineWeight, layerName);
	}

	public static void Blink(this IEnumerable<Brep.OrientedEdge> orientedEdges, Brep brep, Color? color = null, float? lineWeight = null, string layerName = null)
	{
		_0023_003DzIvAPS_V4KHAYEWtAFLpBfFhWFVbc(orientedEdges, brep.Edges, color, lineWeight, layerName);
	}

	private static void _0023_003DzIvAPS_V4KHAYEWtAFLpBfFhWFVbc(IEnumerable<Brep.OrientedEdge> _0023_003DzP8sh_0024RnTCuDmlMKpiw_003D_003D, IList<Brep.Edge> _0023_003DzU3hosSAzkxO7, Color? _0023_003Dz1MMYB1g_003D, float? _0023_003DzxOQTW6c4mcu_0024, string _0023_003DzaROjBYA_003D)
	{
		List<Entity> list = new List<Entity>();
		foreach (Brep.OrientedEdge item in _0023_003DzP8sh_0024RnTCuDmlMKpiw_003D_003D)
		{
			list.Add((Entity)item.GetOrientedCurve(_0023_003DzU3hosSAzkxO7));
		}
		Client.Blink(list, _0023_003Dz1MMYB1g_003D, _0023_003DzxOQTW6c4mcu_0024, _0023_003DzaROjBYA_003D);
	}

	public static void Blink(this string text, Point3D position, Color? color = null, float? fontSize = null)
	{
		Client.Blink(text, position, color, fontSize);
	}

	public static void Blink(this Segment2D segment, Color? color = null, float? lineWeight = null, string layerName = null)
	{
		Client.Blink(new Line(segment), color, lineWeight, layerName);
	}

	public static void Blink(this Segment3D segment, Color? color = null, float? lineWeight = null, string layerName = null)
	{
		Client.Blink(new Line(segment), color, lineWeight, layerName);
	}

	public static void Blink(this IEnumerable<Segment2D> segments, Color? color = null, float? lineWeight = null, string layerName = null)
	{
		Client.Blink(new PointCloud(segments.SelectMany(_0023_003Dz2IEmqow_003D._0023_003DzJ5g3Rwo_003D._0023_003DzmgSMoH5wugfrTdQ4KI9dui8_003D).ToArray())
		{
			DrawingStyle = PointCloud.drawingStyleType.Lines
		}, color, lineWeight, layerName);
	}

	public static void Blink(this IEnumerable<Segment3D> segments, Color? color = null, float? lineWeight = null, string layerName = null)
	{
		Client.Blink(new PointCloud(segments.SelectMany((Segment3D _0023_003DzuwH5j5s_003D) => new Point3D[2] { _0023_003DzuwH5j5s_003D.P0, _0023_003DzuwH5j5s_003D.P1 }).ToArray())
		{
			DrawingStyle = PointCloud.drawingStyleType.Lines
		}, color, lineWeight, layerName);
	}

	public static void Blink<T>(this IndexTriangle triangle, IList<T> vertices, Color? color = null, string layerName = null) where T : Point2D
	{
		new Triangle(vertices[triangle.V1]._0023_003DzsGH6XgHddTc_0024(), vertices[triangle.V2]._0023_003DzsGH6XgHddTc_0024(), vertices[triangle.V3]._0023_003DzsGH6XgHddTc_0024()).Blink(color, null, layerName);
	}

	public static void Blink<T>(this IList<IndexTriangle> triangles, IList<T> vertices, Color? color = null, string layerName = null) where T : Point2D
	{
		Point3D[] array = new Point3D[vertices.Count];
		for (int i = 0; i < vertices.Count; i++)
		{
			array[i] = vertices[i]._0023_003DzsGH6XgHddTc_0024();
		}
		Utility.Compact(array, triangles, out var compacted);
		Client.Blink(new Mesh(compacted, triangles), color, null, layerName);
	}

	public static void Blink(this IndexTriangle triangle, Mesh mesh, Color? color = null)
	{
		triangle.Blink(mesh.Vertices, color);
	}

	public static void Blink(this IList<IndexTriangle> triangles, Mesh mesh, Color? color = null)
	{
		triangles.Blink(mesh.Vertices, color);
	}

	public static void Blink(this Toolpath.Motion motion, Color? color = null, float? lineWeight = null, string layerName = null)
	{
		Client.Blink(new Toolpath(new Toolpath.Motion[1] { motion }), color, lineWeight, layerName);
	}

	public static void Blink(this MaterialKeyedCollection materials)
	{
		Client.Blink(materials);
	}

	public static void Blink(this Material material)
	{
		Brep brep = Brep.CreateSphere(100.0);
		brep.MaterialName = material.Name;
		Material material2 = (Material)material.Clone();
		material2.TextureLength = (float)Math.PI * 100f;
		new MaterialKeyedCollection { material2 }.Blink();
		brep.Blink();
	}

	public static void Blink(this TextStyleKeyedCollection textStyles)
	{
		Client.Blink(textStyles);
	}

	public static void Blink(this TextStyle textStyle)
	{
		new TextStyleKeyedCollection { textStyle }.Blink();
		new Text(Plane.XY, Point2D.Origin, textStyle.Name + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302655313), 10.0)
		{
			StyleName = textStyle.Name
		}.Blink();
	}
}
