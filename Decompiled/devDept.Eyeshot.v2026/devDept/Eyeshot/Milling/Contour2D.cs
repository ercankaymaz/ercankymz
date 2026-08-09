using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using devDept.Eyeshot.Entities;
using devDept.Geometry;

namespace devDept.Eyeshot.Milling;

public class Contour2D : Machining
{
	private sealed class _0023_003DzsltMXTiISeGlAv_0024UcQ_003D_003D
	{
		public bool _0023_003DzEXLcE10_003D;

		public Func<Entity, bool> _0023_003DzkqbsCVPMJ_0024g6;

		internal bool _0023_003DznNIpgRawjSAVJ7V0bQ_003D_003D(Entity _0023_003Dzs_0024uS8LA_003D)
		{
			return _0023_003DzEXLcE10_003D;
		}
	}

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private bool _0023_003DzcSl0AvNzoUMk2BC0Lmxtz70_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Point2D[] _0023_003DzJe3CohHcZJUi4I9cqEM9oNM_003D = new Point2D[0];

	public bool OrderByDepth
	{
		[CompilerGenerated]
		get
		{
			return _0023_003DzcSl0AvNzoUMk2BC0Lmxtz70_003D;
		}
		[CompilerGenerated]
		set
		{
			_0023_003DzcSl0AvNzoUMk2BC0Lmxtz70_003D = value;
		}
	}

	public Point2D[] EntryPoints
	{
		[CompilerGenerated]
		get
		{
			return _0023_003DzJe3CohHcZJUi4I9cqEM9oNM_003D;
		}
		[CompilerGenerated]
		set
		{
			_0023_003DzJe3CohHcZJUi4I9cqEM9oNM_003D = value;
		}
	}

	public Contour2D(Setup setup, EndMill cutter, Geometry2D geometry, Interval zRange, double stepDown)
		: base(setup, cutter, geometry, zRange, stepDown)
	{
		double defaultCircularLeadRadius = GetDefaultCircularLeadRadius(cutter);
		base.LeadIn = new CircularLead(defaultCircularLeadRadius);
		base.LeadOut = new CircularLead(defaultCircularLeadRadius);
	}

	public override void DoWork(IProgress<ProgressChangedEventArgs> progress, CancellationToken ct)
	{
		_0023_003DzsltMXTiISeGlAv_0024UcQ_003D_003D _0023_003DzsltMXTiISeGlAv_0024UcQ_003D_003D2 = new _0023_003DzsltMXTiISeGlAv_0024UcQ_003D_003D();
		double[] array = Machining.ComputeStepsZ(zRange.Low, zRange.High, stepDown, tolerance, 0.0);
		Point2D[][] polylines = ((Geometry2D)geometry).GetPolylines(_0023_003Dz9cS3uG0_003D);
		int num = polylines.Length;
		_0023_003DzsltMXTiISeGlAv_0024UcQ_003D_003D2._0023_003DzEXLcE10_003D = base.CutDirectionMode != cutDirectionType.Conventional;
		List<Entity> list = new List<Entity>(num);
		Region region = new Region(new ICurve[0], Plane.XY);
		List<Point2D[]> list2 = new List<Point2D[]>();
		for (int i = 0; i < num; i++)
		{
			Point2D[] array2 = polylines[i];
			if (array2.First().Equals(array2.Last()))
			{
				region.ContourList.Add(new LinearPath(Plane.XY, array2));
			}
			else
			{
				list2.Add(array2);
			}
		}
		double num2 = cutter.Diameter / 2.0 + base.RadialStockToLeave;
		if (((Geometry2D)geometry).Flip)
		{
			num2 *= -1.0;
		}
		if (region.ContourList.Count > 0)
		{
			ICurve[] source = region.QuickOffset(num2, cornerType.Miter, 0.0);
			_0023_003DzrFThhKQ9hBQG(source.Cast<Entity>().ToArray());
			list.AddRange(source.Cast<Entity>());
		}
		for (int j = 0; j < list2.Count; j++)
		{
			list.Add((Entity)new LinearPath(Plane.XY, list2[j]).QuickOffset(num2, Plane.XY)[0]);
		}
		Entity[] array3 = list.ToArray();
		foreach (Entity item in array3.Where(_0023_003DzsltMXTiISeGlAv_0024UcQ_003D_003D2._0023_003DznNIpgRawjSAVJ7V0bQ_003D_003D))
		{
			Array.Reverse(item.Vertices);
		}
		int num3 = array3.Length;
		_0023_003Dzi_002412OVOc9hQdh7qT5DqhxqX0fLgxhXPIBSZ0u4Q_003D[][] array4;
		if (!OrderByDepth)
		{
			array4 = new _0023_003Dzi_002412OVOc9hQdh7qT5DqhxqX0fLgxhXPIBSZ0u4Q_003D[num3][];
			for (int k = 0; k < num3; k++)
			{
				Entity entity = array3[k];
				array4[k] = new _0023_003Dzi_002412OVOc9hQdh7qT5DqhxqX0fLgxhXPIBSZ0u4Q_003D[array.Length];
				for (int l = 0; l < array.Length; l++)
				{
					Point3D[] array5 = new Point3D[entity.Vertices.Length];
					for (int m = 0; m < entity.Vertices.Length; m++)
					{
						Point3D point3D = entity.Vertices[m];
						array5[m] = new Point3D(point3D.X, point3D.Y, array[l]);
					}
					array4[k][l] = (Machining._0023_003DzySfSteI_003D(array5) ? ((_0023_003Dzi_002412OVOc9hQdh7qT5DqhxqX0fLgxhXPIBSZ0u4Q_003D)new _0023_003DzR3WVQCEzz65noi1VChQukA3MK1cC5qLbFFOoDLFLl4lyg2_0024DGA_003D_003D(array5)) : ((_0023_003Dzi_002412OVOc9hQdh7qT5DqhxqX0fLgxhXPIBSZ0u4Q_003D)new _0023_003DzV2oSLtcAc39qqlMrcWLrfmdnDGqva37BJrJ8NzI_003D(array5, _0023_003DzcaGByDs7xCqDXTICQFdDcOs_003D: true)));
				}
				if (!UpdateProgressAndCheckCancelled(k, array.Length, base.ComputingPassesText, progress, ct))
				{
					return;
				}
			}
		}
		else
		{
			array4 = new _0023_003Dzi_002412OVOc9hQdh7qT5DqhxqX0fLgxhXPIBSZ0u4Q_003D[array.Length][];
			for (int n = 0; n < array.Length; n++)
			{
				array4[n] = new _0023_003Dzi_002412OVOc9hQdh7qT5DqhxqX0fLgxhXPIBSZ0u4Q_003D[num3];
				for (int num4 = 0; num4 < num3; num4++)
				{
					Entity entity2 = array3[num4];
					if (entity2 != null)
					{
						Point3D[] array6 = new Point3D[entity2.Vertices.Length];
						for (int num5 = 0; num5 < entity2.Vertices.Length; num5++)
						{
							Point3D point3D2 = entity2.Vertices[num5];
							array6[num5] = new Point3D(point3D2.X, point3D2.Y, array[n]);
						}
						array4[n][num4] = (Machining._0023_003DzySfSteI_003D(array6) ? ((_0023_003Dzi_002412OVOc9hQdh7qT5DqhxqX0fLgxhXPIBSZ0u4Q_003D)new _0023_003DzR3WVQCEzz65noi1VChQukA3MK1cC5qLbFFOoDLFLl4lyg2_0024DGA_003D_003D(array6)) : ((_0023_003Dzi_002412OVOc9hQdh7qT5DqhxqX0fLgxhXPIBSZ0u4Q_003D)new _0023_003DzV2oSLtcAc39qqlMrcWLrfmdnDGqva37BJrJ8NzI_003D(array6, _0023_003DzcaGByDs7xCqDXTICQFdDcOs_003D: true)));
						if (!UpdateProgressAndCheckCancelled(n, array.Length, base.ComputingPassesText, progress, ct))
						{
							return;
						}
					}
				}
			}
		}
		_0023_003DzZxtbOpnFrGnWMjYnCQ_003D_003D(array4, log, OrderByDepth, 0.0, ((Geometry2D)geometry).Flip);
	}

	private static bool _0023_003Dz_00244E5pPWRVBCE(Point2D[] _0023_003DzRStSB1rsoNKYaya4kg_003D_003D)
	{
		Point2D point2D = _0023_003DzRStSB1rsoNKYaya4kg_003D_003D[0];
		Point2D point2D2 = _0023_003DzRStSB1rsoNKYaya4kg_003D_003D[^1];
		if (Utility.Compare(point2D.X, point2D2.X) == 0)
		{
			return Utility.Compare(point2D.Y, point2D2.Y) == 0;
		}
		return false;
	}

	private void _0023_003DzrFThhKQ9hBQG(Entity[] _0023_003Dzy4_GAgYXNpqw)
	{
		if (EntryPoints.Length == 0)
		{
			return;
		}
		for (int i = 0; i < _0023_003Dzy4_GAgYXNpqw.Length; i++)
		{
			double num = double.MaxValue;
			int num2 = -1;
			double num3 = 0.0;
			Point2D[] vertices = _0023_003Dzy4_GAgYXNpqw[i].Vertices;
			Point2D[] array = vertices;
			vertices = EntryPoints;
			for (int j = 0; j < vertices.Length; j++)
			{
				Point2D point2D = (Point2D)vertices[j].Clone();
				point2D.TransformBy(_0023_003Dz9cS3uG0_003D._0023_003DzylonwpI_003D);
				for (int k = 0; k < array.Length - 1; k++)
				{
					Segment2D segment2D = new Segment2D(array[k], array[k + 1]);
					double num4 = segment2D.ClosestPointTo(point2D);
					double num5 = Point2D.DistanceSquared(segment2D.PointAt(num4), point2D);
					if (num5 < num)
					{
						num = num5;
						num2 = k;
						num3 = num4;
					}
				}
			}
			Segment2D segment2D2 = new Segment2D(_0023_003Dzy4_GAgYXNpqw[i].Vertices[num2], _0023_003Dzy4_GAgYXNpqw[i].Vertices[num2 + 1]);
			if (Utility.Compare(Utility._0023_003DzxhnLabVjXjPg, num3, 0.0) != 0 && Utility.Compare(Utility._0023_003DzxhnLabVjXjPg, num3, 1.0) != 0)
			{
				List<Point3D> list = _0023_003Dzy4_GAgYXNpqw[i].Vertices.ToList();
				Point2D point2D2 = segment2D2.PointAt(num3);
				list.Insert(num2 + 1, new Point3D(point2D2.X, point2D2.Y));
				_0023_003Dzy4_GAgYXNpqw[i].Vertices = list.ToArray();
				num2++;
			}
			else
			{
				num2 += ((Utility.Compare(Utility._0023_003DzxhnLabVjXjPg, num3, 0.0) != 0) ? 1 : 0);
			}
			Point3D[] array2 = _0023_003Dzy4_GAgYXNpqw[i].Vertices.Take(_0023_003Dzy4_GAgYXNpqw[i].Vertices.Length - 1).ToArray();
			Utility.RotateLeft(array2, num2);
			array2 = array2.Append(array2[0]).ToArray();
			_0023_003Dzy4_GAgYXNpqw[i].Vertices = array2;
		}
	}
}
