using System;
using System.Collections.Generic;
using System.Linq;
using ACadSharp.Attributes;
using ACadSharp.Objects;
using CSMath;

namespace ACadSharp.Entities;

[DxfName("MLINE")]
[DxfSubClass("AcDbMline")]
public class MLine : Entity
{
	public class Vertex
	{
		public class Segment
		{
			[DxfCodeValue(DxfReferenceType.Count, new int[] { 74 })]
			[DxfCollectionCodeValue(new int[] { 41 })]
			public List<double> Parameters { get; set; } = new List<double>();

			[DxfCodeValue(DxfReferenceType.Count, new int[] { 75 })]
			[DxfCollectionCodeValue(new int[] { 42 })]
			public List<double> AreaFillParameters { get; set; } = new List<double>();

			public void ApplyScale(double scaleFactor)
			{
				for (int num = Parameters.Count - 1; num >= 0; num--)
				{
					Parameters[num] *= scaleFactor;
				}
				for (int num2 = AreaFillParameters.Count - 1; num2 >= 0; num2--)
				{
					AreaFillParameters[num2] *= scaleFactor;
				}
			}
		}

		[DxfCodeValue(new int[] { 11, 21, 31 })]
		public XYZ Position { get; set; }

		[DxfCodeValue(new int[] { 12, 22, 32 })]
		public XYZ Direction { get; set; }

		[DxfCodeValue(new int[] { 13, 23, 33 })]
		public XYZ Miter { get; set; }

		[DxfCodeValue(DxfReferenceType.Count, new int[] { 73 })]
		public List<Segment> Segments { get; set; } = new List<Segment>();

		public void ApplyTransform(Transform transform)
		{
			Position = transform.ApplyTransform(Position);
			Direction = transform.ApplyTransform(Direction);
			Miter = transform.ApplyTransform(Miter);
			foreach (Segment segment in Segments)
			{
				segment.ApplyScale(Miter.GetLength());
			}
		}

		public Vertex Clone()
		{
			Vertex vertex = (Vertex)MemberwiseClone();
			vertex.Segments.Clear();
			foreach (Segment segment2 in Segments)
			{
				Segment segment = new Segment();
				segment.Parameters.AddRange(segment2.Parameters);
				segment.AreaFillParameters.AddRange(segment2.AreaFillParameters);
				vertex.Segments.Add(segment);
			}
			return vertex;
		}
	}

	private MLineStyle _style = MLineStyle.Default;

	[DxfCodeValue(new int[] { 71 })]
	public MLineFlags Flags { get; set; }

	[DxfCodeValue(new int[] { 70 })]
	public MLineJustification Justification { get; set; }

	[DxfCodeValue(new int[] { 210, 220, 230 })]
	public XYZ Normal { get; set; } = XYZ.AxisZ;

	public override string ObjectName => "MLINE";

	public override ObjectType ObjectType => ObjectType.MLINE;

	[DxfCodeValue(new int[] { 40 })]
	public double ScaleFactor { get; set; } = 1.0;

	[DxfCodeValue(new int[] { 10, 20, 30 })]
	public XYZ StartPoint { get; set; }

	[DxfCodeValue(DxfReferenceType.Handle | DxfReferenceType.Name, new int[] { 340 })]
	public MLineStyle Style
	{
		get
		{
			return _style;
		}
		set
		{
			if (value == null)
			{
				throw new ArgumentNullException("value", "Multi line style cannot be null");
			}
			if (base.Document != null)
			{
				_style = CadObject.updateCollection(value, base.Document.MLineStyles);
			}
			else
			{
				_style = value;
			}
		}
	}

	public override string SubclassMarker => "AcDbMline";

	[DxfCodeValue(DxfReferenceType.Count, new int[] { 72 })]
	public List<Vertex> Vertices { get; set; } = new List<Vertex>();

	public override void ApplyTransform(Transform transform)
	{
		Normal = transformNormal(transform, Normal);
		StartPoint = transform.ApplyTransform(StartPoint);
		foreach (Vertex vertex in Vertices)
		{
			vertex.ApplyTransform(transform);
		}
	}

	public override CadObject Clone()
	{
		MLine mLine = (MLine)base.Clone();
		mLine.Style = (MLineStyle)(Style?.Clone());
		mLine.Vertices.Clear();
		foreach (Vertex vertex in Vertices)
		{
			mLine.Vertices.Add(vertex.Clone());
		}
		return mLine;
	}

	public override BoundingBox GetBoundingBox()
	{
		return BoundingBox.FromPoints(Vertices.Select((Vertex v) => v.Position));
	}

	internal override void AssignDocument(CadDocument doc)
	{
		base.AssignDocument(doc);
		_style = CadObject.updateCollection(Style, doc.MLineStyles);
		base.Document.MLineStyles.OnRemove += mLineStylesOnRemove;
	}

	internal override void UnassignDocument()
	{
		base.Document.MLineStyles.OnRemove -= mLineStylesOnRemove;
		base.UnassignDocument();
		_style = (MLineStyle)Style.Clone();
	}

	private void mLineStylesOnRemove(object sender, CollectionChangedEventArgs e)
	{
		if (e.Item.Equals(Style))
		{
			Style = base.Document.MLineStyles["Standard"];
		}
	}
}
