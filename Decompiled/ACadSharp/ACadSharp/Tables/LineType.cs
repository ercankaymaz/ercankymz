using System;
using System.Collections.Generic;
using System.Linq;
using ACadSharp.Attributes;
using ACadSharp.Entities;
using ACadSharp.Extensions;
using CSMath;

namespace ACadSharp.Tables;

[DxfName("LTYPE")]
[DxfSubClass("AcDbLinetypeTableRecord")]
public class LineType : TableEntry
{
	public class Segment
	{
		private TextStyle _style;

		private string _text = string.Empty;

		[DxfCodeValue(new int[] { 74 })]
		public LineTypeShapeFlags Flags { get; set; }

		public bool IsLine => Length > 0.0;

		public bool IsPoint => Length == 0.0;

		public bool IsShape
		{
			get
			{
				return Flags.HasFlag(LineTypeShapeFlags.Shape);
			}
			set
			{
				if (value)
				{
					Flags |= LineTypeShapeFlags.Shape;
				}
				else
				{
					Flags &= ~LineTypeShapeFlags.Shape;
				}
			}
		}

		public bool IsSpace => Length < 0.0;

		public bool IsText
		{
			get
			{
				return Flags.HasFlag(LineTypeShapeFlags.Text);
			}
			set
			{
				if (value)
				{
					Flags |= LineTypeShapeFlags.Text;
				}
				else
				{
					Flags &= ~LineTypeShapeFlags.Text;
				}
			}
		}

		[DxfCodeValue(new int[] { 49 })]
		public double Length { get; set; }

		[DxfCodeValue(new int[] { 44, 45 })]
		public XY Offset { get; set; }

		public LineType Owner { get; internal set; }

		[DxfCodeValue(DxfReferenceType.IsAngle, new int[] { 50 })]
		public double Rotation { get; set; }

		[DxfCodeValue(new int[] { 46 })]
		public double Scale { get; set; } = 1.0;

		[DxfCodeValue(new int[] { 75 })]
		public short ShapeNumber { get; set; }

		[DxfCodeValue(DxfReferenceType.Handle, new int[] { 340 })]
		public TextStyle Style
		{
			get
			{
				return _style;
			}
			set
			{
				_style = CadObject.updateCollection(value, Owner?.Document?.TextStyles);
			}
		}

		[DxfCodeValue(new int[] { 9 })]
		public string Text
		{
			get
			{
				return _text;
			}
			set
			{
				_text = (string.IsNullOrEmpty(value) ? string.Empty : value);
			}
		}

		public Segment Clone()
		{
			Segment obj = MemberwiseClone() as Segment;
			obj.Owner = null;
			obj._style = (TextStyle)(Style?.Clone());
			return obj;
		}

		internal void AssignDocument(CadDocument doc)
		{
			_style = CadObject.updateCollection(_style, doc.TextStyles);
		}

		internal void UnassignDocument()
		{
			_style = _style.CloneTyped();
		}
	}

	public const string ByBlockName = "ByBlock";

	public const string ByLayerName = "ByLayer";

	public const string ContinuousName = "Continuous";

	private List<Segment> _segments = new List<Segment>();

	public static LineType ByBlock => new LineType("ByBlock");

	public static LineType ByLayer => new LineType("ByLayer");

	public static LineType Continuous => new LineType("Continuous");

	[DxfCodeValue(new int[] { 72 })]
	public char Alignment { get; internal set; } = 'A';

	[DxfCodeValue(new int[] { 3 })]
	public string Description { get; set; }

	public bool HasShapes => Segments.Any((Segment s) => s.IsShape);

	public bool IsComplex => _segments.Count > 0;

	public override string ObjectName => "LTYPE";

	public override ObjectType ObjectType => ObjectType.LTYPE;

	[DxfCodeValue(new int[] { 40 })]
	public double PatternLength => Segments.Sum((Segment s) => Math.Abs(s.Length));

	[DxfCodeValue(DxfReferenceType.Count, new int[] { 73 })]
	public IEnumerable<Segment> Segments => _segments;

	public override string SubclassMarker => "AcDbLinetypeTableRecord";

	public LineType(string name)
		: base(name)
	{
	}

	internal LineType()
	{
	}

	public void AddSegment(Segment segment)
	{
		if (segment.Owner != null)
		{
			throw new ArgumentException("Segment already assigned to a LineType: " + segment.Owner.Name);
		}
		segment.Style = CadObject.updateCollection(segment.Style, base.Document?.TextStyles);
		segment.Owner = this;
		_segments.Add(segment);
	}

	public override CadObject Clone()
	{
		LineType lineType = (LineType)base.Clone();
		lineType._segments = new List<Segment>();
		foreach (Segment segment in _segments)
		{
			lineType.AddSegment(segment.Clone());
		}
		return lineType;
	}

	public IEnumerable<Polyline3D> CreateLineTypeShape<T>(params IEnumerable<T> points) where T : IVector
	{
		return CreateLineTypeShape((double?)null, points);
	}

	public IEnumerable<Polyline3D> CreateLineTypeShape<T>(double? pointSize, params IEnumerable<T> points) where T : IVector
	{
		if (!points.Any() || points.Count() < 2)
		{
			throw new ArgumentException("The list must contain at least 2 points to create the shape.");
		}
		return CreateLineTypeShape(new Polyline3D(points.Select((T v) => v.Convert<XYZ>())), pointSize);
	}

	public IEnumerable<Polyline3D> CreateLineTypeShape(IPolyline polyline, double? pointSize = null)
	{
		if (!pointSize.HasValue)
		{
			pointSize = polyline.GetActiveLineWeightType().GetLineWeightValue();
		}
		List<Polyline3D> list = new List<Polyline3D>();
		if (!IsComplex)
		{
			list.Add(new Polyline3D(polyline.GetPoints<XYZ>(), polyline.IsClosed));
			return list;
		}
		XYZ[] array = polyline.GetPoints<XYZ>().ToArray();
		XYZ start = array[0];
		for (int i = 1; i < array.Length; i++)
		{
			XYZ xYZ = array[i];
			list.AddRange(createSegmentShape(start, xYZ, pointSize.Value));
			start = xYZ;
		}
		if (polyline.IsClosed)
		{
			list.AddRange(createSegmentShape(start, array[0], pointSize.Value));
		}
		return list;
	}

	internal override void AssignDocument(CadDocument doc)
	{
		base.AssignDocument(doc);
		foreach (Segment item in _segments.Where((Segment s) => s.Style != null))
		{
			item.AssignDocument(doc);
		}
		doc.TextStyles.OnRemove += tableOnRemove;
	}

	internal override void UnassignDocument()
	{
		base.Document.TextStyles.OnRemove -= tableOnRemove;
		foreach (Segment item in _segments.Where((Segment s) => s.Style != null))
		{
			item.UnassignDocument();
		}
		base.UnassignDocument();
	}

	protected void tableOnRemove(object sender, CollectionChangedEventArgs e)
	{
		if (!(e.Item is TextStyle textStyle))
		{
			return;
		}
		foreach (Segment item in _segments.Where((Segment s) => s.Style != null))
		{
			if (item.Style == textStyle)
			{
				item.Style = null;
			}
		}
	}

	private List<Polyline3D> createSegmentShape(XYZ start, XYZ end, double pointSize)
	{
		List<Polyline3D> list = new List<Polyline3D>();
		Polyline3D polyline3D = new Polyline3D(new _003C_003Ez__ReadOnlySingleElementList<XYZ>(start));
		double num = start.DistanceFrom(end);
		XYZ xYZ = start;
		Math.Floor(num / PatternLength);
		XYZ xYZ2 = (end - start).Normalize();
		while (num > 0.0)
		{
			foreach (Segment segment in Segments)
			{
				if (segment.Length < num)
				{
					xYZ += xYZ2 * Math.Abs(segment.Length);
					num -= Math.Abs(segment.Length);
				}
				else
				{
					xYZ += xYZ2 * Math.Abs(num);
					num -= Math.Abs(num);
				}
				if (segment.IsPoint)
				{
					Polyline3D item = new Polyline3D(new _003C_003Ez__ReadOnlyArray<XYZ>(new XYZ[2]
					{
						start,
						xYZ + xYZ2 * pointSize
					}));
					list.Add(item);
					if (polyline3D.Vertices.Any())
					{
						list.Add(polyline3D);
						polyline3D = new Polyline3D();
					}
				}
				else if (segment.IsLine)
				{
					polyline3D.Vertices.Add(new Vertex3D(xYZ));
				}
				else if (segment.IsSpace)
				{
					if (polyline3D.Vertices.Any())
					{
						list.Add(polyline3D);
					}
					polyline3D = new Polyline3D(new _003C_003Ez__ReadOnlySingleElementList<XYZ>(xYZ));
				}
				start = xYZ;
				if (num <= 0.0)
				{
					if (polyline3D.Vertices.Any())
					{
						list.Add(polyline3D);
					}
					break;
				}
			}
		}
		return list;
	}
}
