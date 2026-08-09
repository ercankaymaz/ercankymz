using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using ACadSharp.Attributes;
using ACadSharp.Extensions;
using CSMath;
using CSUtilities.Extensions;

namespace ACadSharp.Entities;

[DxfName("HATCH")]
[DxfSubClass("AcDbHatch")]
public class Hatch : Entity
{
	public class BoundaryPath : IGeometricEntity
	{
		public class Arc : Edge
		{
			[DxfCodeValue(new int[] { 10, 20 })]
			public XY Center { get; set; }

			[DxfCodeValue(new int[] { 73 })]
			public bool CounterClockWise { get; set; }

			[DxfCodeValue(new int[] { 51 })]
			public double EndAngle { get; set; }

			[DxfCodeValue(new int[] { 40 })]
			public double Radius { get; set; }

			[DxfCodeValue(new int[] { 50 })]
			public double StartAngle { get; set; }

			public override EdgeType Type => EdgeType.CircularArc;

			public override void ApplyTransform(Transform transform)
			{
				_ = Radius;
				_ = StartAngle;
				_ = EndAngle;
				_ = CounterClockWise;
				Center = transform.ApplyTransform(Center.Convert<XYZ>()).Convert<XY>();
				Radius = transform.ApplyTransform(new XYZ(Radius, 0.0, 0.0)).GetLength();
				if (!CounterClockWise)
				{
					StartAngle = 0.0 - StartAngle;
					EndAngle = 0.0 - EndAngle;
				}
				XYZ xyz = new XYZ(Math.Cos(StartAngle), Math.Sin(StartAngle), 0.0);
				XYZ xyz2 = new XYZ(Math.Cos(EndAngle), Math.Sin(EndAngle), 0.0);
				xyz = transform.ApplyTransform(xyz);
				StartAngle = Math.Atan2(xyz.Y, xyz.X);
				xyz2 = transform.ApplyTransform(xyz2);
				EndAngle = Math.Atan2(xyz2.Y, xyz2.X);
				if (!CounterClockWise)
				{
					StartAngle = 0.0 - StartAngle;
					EndAngle = 0.0 - EndAngle;
				}
			}

			public override BoundingBox GetBoundingBox()
			{
				return ((ACadSharp.Entities.Arc)ToEntity()).GetBoundingBox();
			}

			public List<XYZ> PolygonalVertexes(int precision)
			{
				return ((ACadSharp.Entities.Arc)ToEntity()).PolygonalVertexes(precision);
			}

			public override Entity ToEntity()
			{
				if (CounterClockWise)
				{
					return new ACadSharp.Entities.Arc
					{
						Center = (XYZ)Center,
						Radius = Radius,
						StartAngle = StartAngle,
						EndAngle = EndAngle
					};
				}
				return new ACadSharp.Entities.Arc
				{
					Center = (XYZ)Center,
					Radius = Radius,
					StartAngle = Math.PI * 2.0 - EndAngle,
					EndAngle = Math.PI * 2.0 - StartAngle
				};
			}
		}

		public enum EdgeType
		{
			Polyline,
			Line,
			CircularArc,
			EllipticArc,
			Spline
		}

		public abstract class Edge : IGeometricEntity
		{
			public abstract EdgeType Type { get; }

			public abstract void ApplyTransform(Transform transform);

			public virtual Edge Clone()
			{
				return (Edge)MemberwiseClone();
			}

			public abstract BoundingBox GetBoundingBox();

			public abstract Entity ToEntity();
		}

		public class Ellipse : Edge
		{
			[DxfCodeValue(new int[] { 10, 20 })]
			public XY Center { get; set; }

			[DxfCodeValue(new int[] { 73 })]
			public bool CounterClockWise { get; set; }

			[DxfCodeValue(new int[] { 51 })]
			public double EndAngle { get; set; }

			[DxfCodeValue(new int[] { 11, 21 })]
			public XY MajorAxisEndPoint { get; set; }

			[DxfCodeValue(new int[] { 40 })]
			public double MinorToMajorRatio { get; set; }

			[DxfCodeValue(new int[] { 50 })]
			public double StartAngle { get; set; }

			public override EdgeType Type => EdgeType.EllipticArc;

			public override void ApplyTransform(Transform transform)
			{
				Center = transform.ApplyTransform(Center.Convert<XYZ>()).Convert<XY>();
				MajorAxisEndPoint = transform.ApplyTransform(MajorAxisEndPoint.Convert<XYZ>()).Convert<XY>();
			}

			public override BoundingBox GetBoundingBox()
			{
				return ToEntity().GetBoundingBox();
			}

			public override Entity ToEntity()
			{
				return new ACadSharp.Entities.Ellipse
				{
					Center = Center.Convert<XYZ>(),
					StartParameter = (CounterClockWise ? StartAngle : (Math.PI * 2.0 - EndAngle)),
					EndParameter = (CounterClockWise ? EndAngle : (Math.PI * 2.0 - StartAngle)),
					MajorAxisEndPoint = MajorAxisEndPoint.Convert<XYZ>(),
					RadiusRatio = MinorToMajorRatio
				};
			}

			public List<XYZ> PolygonalVertexes(int precision)
			{
				return ((ACadSharp.Entities.Ellipse)ToEntity()).PolygonalVertexes(precision);
			}
		}

		public class Line : Edge
		{
			[DxfCodeValue(new int[] { 11, 21 })]
			public XY End { get; set; }

			[DxfCodeValue(new int[] { 10, 20 })]
			public XY Start { get; set; }

			public override EdgeType Type => EdgeType.Line;

			public override void ApplyTransform(Transform transform)
			{
				Start = transform.ApplyTransform(Start.Convert<XYZ>()).Convert<XY>();
				End = transform.ApplyTransform(End.Convert<XYZ>()).Convert<XY>();
			}

			public override BoundingBox GetBoundingBox()
			{
				return BoundingBox.FromPoints(new _003C_003Ez__ReadOnlyArray<XYZ>(new XYZ[2]
				{
					(XYZ)Start,
					(XYZ)End
				}));
			}

			public override Entity ToEntity()
			{
				return new ACadSharp.Entities.Line(Start, End);
			}
		}

		public class Polyline : Edge
		{
			[DxfCodeValue(DxfReferenceType.Optional, new int[] { 42 })]
			public IEnumerable<double> Bulges => Vertices.Select((XYZ v) => v.Z);

			[DxfCodeValue(new int[] { 72 })]
			public bool HasBulge => Bulges.Any((double b) => b != 0.0);

			[DxfCodeValue(new int[] { 73 })]
			public bool IsClosed { get; set; }

			public override EdgeType Type => EdgeType.Polyline;

			[DxfCodeValue(DxfReferenceType.Count, new int[] { 93 })]
			public List<XYZ> Vertices { get; private set; } = new List<XYZ>();

			public Polyline()
			{
			}

			public Polyline(IEnumerable<XYZ> vertices, bool isClosed = true)
			{
				Vertices.AddRange(vertices);
				IsClosed = isClosed;
			}

			public override void ApplyTransform(Transform transform)
			{
				XYZ[] array = Vertices.ToArray();
				Vertices.Clear();
				for (int i = 0; i < array.Length; i++)
				{
					double z = array[i].Z;
					XYZ item = transform.ApplyTransform(array[i]);
					item.Z = z;
					Vertices.Add(item);
				}
			}

			public override Edge Clone()
			{
				Polyline obj = (Polyline)base.Clone();
				obj.Vertices = new List<XYZ>(Vertices);
				return obj;
			}

			public override BoundingBox GetBoundingBox()
			{
				return BoundingBox.FromPoints(Vertices);
			}

			public override Entity ToEntity()
			{
				List<Vertex> list = new List<Vertex>();
				foreach (XYZ vertex in Vertices)
				{
					Vertex2D item = new Vertex2D(vertex.Convert<XY>())
					{
						Bulge = vertex.Z
					};
					list.Add(item);
				}
				return new Polyline2D(list.Cast<Vertex2D>(), IsClosed);
			}
		}

		public class Spline : Edge
		{
			[DxfCodeValue(new int[] { 96 })]
			public List<XYZ> ControlPoints { get; private set; } = new List<XYZ>();

			[DxfCodeValue(new int[] { 94 })]
			public int Degree { get; set; }

			[DxfCodeValue(new int[] { 13, 23 })]
			public XY EndTangent { get; set; }

			[DxfCodeValue(new int[] { 97 })]
			public List<XY> FitPoints { get; private set; } = new List<XY>();

			[DxfCodeValue(new int[] { 95 })]
			public List<double> Knots { get; private set; } = new List<double>();

			[DxfCodeValue(new int[] { 74 })]
			public bool Periodic { get; set; }

			[DxfCodeValue(new int[] { 73 })]
			public bool Rational { get; set; }

			[DxfCodeValue(new int[] { 12, 22 })]
			public XY StartTangent { get; set; }

			public override EdgeType Type => EdgeType.Spline;

			public IEnumerable<double> Weights => ControlPoints.Select((XYZ c) => c.Z);

			public override void ApplyTransform(Transform transform)
			{
				XYZ[] array = ControlPoints.ToArray();
				ControlPoints.Clear();
				for (int i = 0; i < array.Length; i++)
				{
					double z = array[i].Z;
					XYZ item = transform.ApplyTransform(array[i]);
					item.Z = z;
					ControlPoints.Add(item);
				}
				for (int j = 0; j < FitPoints.Count; j++)
				{
					FitPoints[j] = transform.ApplyTransform(FitPoints[j].Convert<XYZ>()).Convert<XY>();
				}
			}

			public override Edge Clone()
			{
				Spline obj = (Spline)base.Clone();
				obj.ControlPoints = new List<XYZ>(ControlPoints);
				obj.FitPoints = new List<XY>(FitPoints);
				obj.Knots = new List<double>(Knots);
				return obj;
			}

			public override BoundingBox GetBoundingBox()
			{
				return BoundingBox.FromPoints(ControlPoints);
			}

			public List<XYZ> PolygonalVertexes(int precision)
			{
				return ((ACadSharp.Entities.Spline)ToEntity()).PolygonalVertexes(precision);
			}

			public override Entity ToEntity()
			{
				ACadSharp.Entities.Spline spline = new ACadSharp.Entities.Spline();
				spline.Degree = Degree;
				spline.Flags = (Periodic ? (spline.Flags |= SplineFlags.Periodic) : spline.Flags);
				spline.Flags = (Rational ? (spline.Flags |= SplineFlags.Rational) : spline.Flags);
				spline.StartTangent = StartTangent.Convert<XYZ>();
				spline.EndTangent = EndTangent.Convert<XYZ>();
				spline.ControlPoints.AddRange(ControlPoints);
				spline.Weights.AddRange(ControlPoints.Select((XYZ x) => x.Z));
				spline.FitPoints.AddRange(FitPoints.Select((XY x) => x.Convert<XYZ>()));
				spline.Knots.AddRange(Knots);
				return spline;
			}
		}

		private BoundaryPathFlags _flags;

		[DxfCodeValue(DxfReferenceType.Count, new int[] { 93 })]
		public ObservableCollection<Edge> Edges { get; private set; } = new ObservableCollection<Edge>();

		[DxfCodeValue(DxfReferenceType.Count, new int[] { 97 })]
		public List<Entity> Entities { get; set; } = new List<Entity>();

		[DxfCodeValue(new int[] { 92 })]
		public BoundaryPathFlags Flags
		{
			get
			{
				if (IsPolyline)
				{
					_flags.AddFlag(BoundaryPathFlags.Polyline);
				}
				else
				{
					_flags.RemoveFlag(BoundaryPathFlags.Polyline);
				}
				return _flags;
			}
			set
			{
				_flags = value;
			}
		}

		public bool IsPolyline => Edges.OfType<Polyline>().Any();

		public BoundaryPath()
		{
			Edges.CollectionChanged += onEdgesCollectionChanged;
		}

		public void ApplyTransform(Transform transform)
		{
			foreach (Edge edge in Edges)
			{
				edge.ApplyTransform(transform);
			}
		}

		public BoundaryPath Clone()
		{
			BoundaryPath obj = (BoundaryPath)MemberwiseClone();
			obj.Entities = new List<Entity>();
			obj.Entities.AddRange(Entities.Select((Entity e) => (Entity)e.Clone()));
			obj.Edges = new ObservableCollection<Edge>(Edges.Select((Edge e) => e.Clone()));
			return obj;
		}

		public BoundingBox GetBoundingBox()
		{
			BoundingBox result = BoundingBox.Null;
			foreach (Edge edge in Edges)
			{
				result = result.Merge(edge.GetBoundingBox());
			}
			foreach (Entity entity in Entities)
			{
				result = result.Merge(entity.GetBoundingBox());
			}
			return result;
		}

		public IEnumerable<XYZ> GetPoints(int precision = 256)
		{
			List<XYZ> list = new List<XYZ>();
			foreach (Edge edge in Edges)
			{
				if (!(edge is Arc arc))
				{
					if (!(edge is Ellipse ellipse))
					{
						if (!(edge is Line line))
						{
							if (!(edge is Polyline polyline))
							{
								if (edge is Spline spline)
								{
									list.AddRange(spline.PolygonalVertexes(precision));
								}
							}
							else
							{
								Polyline2D polyline2 = (Polyline2D)polyline.ToEntity();
								list.AddRange(polyline2.GetPoints<XYZ>(precision));
							}
						}
						else
						{
							list.Add((XYZ)line.Start);
							list.Add((XYZ)line.End);
						}
					}
					else
					{
						list.AddRange(ellipse.PolygonalVertexes(precision));
					}
				}
				else
				{
					list.AddRange(arc.PolygonalVertexes(precision));
				}
			}
			return list;
		}

		private void onAdd(NotifyCollectionChangedEventArgs e)
		{
			foreach (Edge newItem in e.NewItems)
			{
				_ = newItem;
				if (Edges.Count > 1 && IsPolyline)
				{
					throw new InvalidOperationException();
				}
			}
		}

		private void onEdgesCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
		{
			switch (e.Action)
			{
			case NotifyCollectionChangedAction.Add:
				onAdd(e);
				break;
			case NotifyCollectionChangedAction.Remove:
			case NotifyCollectionChangedAction.Replace:
			case NotifyCollectionChangedAction.Move:
			case NotifyCollectionChangedAction.Reset:
				break;
			}
		}
	}

	private double _patternAngle;

	private double _patternScale;

	[DxfCodeValue(new int[] { 30 })]
	public double Elevation { get; set; }

	[DxfCodeValue(DxfReferenceType.Name, new int[] { 470 })]
	public HatchGradientPattern GradientColor { get; set; } = new HatchGradientPattern();

	[DxfCodeValue(new int[] { 71 })]
	public bool IsAssociative { get; set; }

	[DxfCodeValue(new int[] { 77 })]
	public bool IsDouble { get; set; }

	[DxfCodeValue(new int[] { 70 })]
	public bool IsSolid { get; set; }

	[DxfCodeValue(new int[] { 210, 220, 230 })]
	public XYZ Normal { get; set; } = XYZ.AxisZ;

	public override string ObjectName => "HATCH";

	public override ObjectType ObjectType => ObjectType.HATCH;

	[DxfCodeValue(DxfReferenceType.Count, new int[] { 91 })]
	public List<BoundaryPath> Paths { get; set; } = new List<BoundaryPath>();

	[DxfCodeValue(DxfReferenceType.Name, new int[] { 2 })]
	public HatchPattern Pattern { get; set; } = HatchPattern.Solid;

	[DxfCodeValue(DxfReferenceType.IsAngle, new int[] { 52 })]
	public double PatternAngle
	{
		get
		{
			return _patternAngle;
		}
		set
		{
			_patternAngle = value;
			Pattern?.Update(XY.Zero, _patternAngle, 1.0);
		}
	}

	[DxfCodeValue(new int[] { 41 })]
	public double PatternScale
	{
		get
		{
			return _patternScale;
		}
		set
		{
			_patternScale = value;
			Pattern?.Update(XY.Zero, 0.0, _patternScale);
		}
	}

	[DxfCodeValue(new int[] { 76 })]
	public HatchPatternType PatternType { get; set; }

	[DxfCodeValue(new int[] { 47 })]
	public double PixelSize { get; set; }

	[DxfCodeValue(DxfReferenceType.Count, new int[] { 98 })]
	[DxfCollectionCodeValue(new int[] { 10, 20 })]
	public List<XY> SeedPoints { get; set; } = new List<XY>();

	[DxfCodeValue(new int[] { 75 })]
	public HatchStyleType Style { get; set; }

	public override string SubclassMarker => "AcDbHatch";

	public override void ApplyTransform(Transform transform)
	{
		_ = IsAssociative;
		XYZ xYZ = transformNormal(transform, Normal);
		Matrix3 transOW;
		Matrix3 transWO;
		Matrix3 worldMatrix = getWorldMatrix(transform, Normal, xYZ, out transOW, out transWO);
		foreach (BoundaryPath path in Paths)
		{
			path.ApplyTransform(transform);
		}
		XY xY = XY.Rotate(XY.AxisX, _patternAngle);
		xY = _patternScale * xY;
		XYZ xYZ2 = transOW * new XYZ(xY.X, xY.Y, 0.0);
		xYZ2 = worldMatrix * xYZ2;
		xYZ2 = transWO * xYZ2;
		XY vector = new XY(xYZ2.X, xYZ2.Y);
		_patternAngle = vector.GetAngle();
		double length = vector.GetLength();
		_patternScale = (MathHelper.IsZero(length) ? 1E-12 : length);
		Pattern?.Update(transform.Translation.Convert<XY>(), _patternAngle, _patternScale);
		Normal = xYZ;
	}

	public override CadObject Clone()
	{
		Hatch hatch = base.Clone() as Hatch;
		hatch.GradientColor = GradientColor?.Clone();
		hatch.Pattern = Pattern?.Clone();
		hatch.Paths = new List<BoundaryPath>();
		foreach (BoundaryPath path in Paths)
		{
			hatch.Paths.Add(path.Clone());
		}
		return hatch;
	}

	public IEnumerable<Entity> Explode()
	{
		List<Entity> list = new List<Entity>();
		foreach (BoundaryPath path in Paths)
		{
			foreach (BoundaryPath.Edge edge in path.Edges)
			{
				list.Add(edge.ToEntity());
			}
		}
		return list;
	}

	public override BoundingBox GetBoundingBox()
	{
		BoundingBox result = BoundingBox.Null;
		foreach (BoundaryPath path in Paths)
		{
			result = result.Merge(path.GetBoundingBox());
		}
		return result;
	}
}
