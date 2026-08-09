using System;
using System.Collections.Generic;
using System.Linq;
using ACadSharp.Entities;
using CSMath;

namespace ACadSharp.Extensions;

public static class PolylineExtensions
{
	public static IEnumerable<Entity> Explode(this IPolyline polyline)
	{
		List<Entity> list = new List<Entity>();
		for (int i = 0; i < polyline.Vertices.Count(); i++)
		{
			IVertex vertex = polyline.Vertices.ElementAt(i);
			IVertex vertex2 = polyline.Vertices.ElementAtOrDefault(i + 1);
			if (vertex2 == null && polyline.IsClosed)
			{
				vertex2 = polyline.Vertices.First();
			}
			else if (vertex2 == null)
			{
				break;
			}
			Entity entity = null;
			if (vertex.Bulge == 0.0)
			{
				entity = new Line
				{
					StartPoint = vertex.Location.Convert<XYZ>(),
					EndPoint = vertex2.Location.Convert<XYZ>(),
					Normal = polyline.Normal,
					Thickness = polyline.Thickness
				};
			}
			else
			{
				XY p = vertex.Location.Convert<XY>();
				XY p2 = vertex2.Location.Convert<XY>();
				Arc arc = Arc.CreateFromBulge(p, p2, vertex.Bulge);
				arc.Center = new XYZ(arc.Center.X, arc.Center.Y, polyline.Elevation);
				arc.Normal = polyline.Normal;
				arc.Thickness = polyline.Thickness;
				entity = arc;
			}
			polyline.MatchProperties(entity);
			list.Add(entity);
		}
		return list;
	}

	public static IEnumerable<T> GetPoints<T>(this IPolyline polyline) where T : IVector, new()
	{
		return polyline.Vertices.Select((IVertex v) => v.Location.Convert<T>());
	}

	public static IEnumerable<T> GetPoints<T>(this IPolyline polyline, int precision) where T : IVector, new()
	{
		if (precision < 2)
		{
			throw new ArgumentOutOfRangeException("precision", precision, "The arc precision must be equal or greater than two.");
		}
		List<T> list = new List<T>();
		for (int i = 0; i < polyline.Vertices.Count(); i++)
		{
			IVertex vertex = polyline.Vertices.ElementAt(i);
			IVertex vertex2 = polyline.Vertices.ElementAtOrDefault(i + 1);
			if (vertex2 == null && polyline.IsClosed)
			{
				vertex2 = polyline.Vertices.First();
			}
			else if (vertex2 == null)
			{
				break;
			}
			if (vertex.Bulge == 0.0)
			{
				if (i == 0)
				{
					list.Add(vertex.Location.Convert<T>());
				}
				list.Add(vertex2.Location.Convert<T>());
				continue;
			}
			XY p = vertex.Location.Convert<XY>();
			XY p2 = vertex2.Location.Convert<XY>();
			IEnumerable<T> source = from xYZ in Arc.CreateFromBulge(p, p2, vertex.Bulge).PolygonalVertexes(precision)
				select xYZ.Convert<T>();
			T val = source.First().Round(8);
			T val2 = source.Last().Round(8);
			ref T reference = ref val;
			T val3 = default(T);
			if (val3 == null)
			{
				val3 = reference;
				reference = ref val3;
			}
			object obj = vertex.Location.Convert<T>().Round(8);
			if (reference.Equals(obj))
			{
				list.AddRange(source.Skip(1));
				continue;
			}
			ref T reference2 = ref val2;
			val3 = default(T);
			if (val3 == null)
			{
				val3 = reference2;
				reference2 = ref val3;
			}
			object obj2 = vertex.Location.Convert<T>().Round(8);
			if (reference2.Equals(obj2))
			{
				source = source.Reverse();
				list.AddRange(source.Skip(1));
			}
		}
		return list;
	}
}
