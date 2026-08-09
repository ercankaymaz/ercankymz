using System;
using System.Collections.Generic;
using System.Text;
using ACadSharp.Attributes;
using CSMath;

namespace ACadSharp.Entities;

[DxfSubClass("AcDbModelerGeometry")]
public abstract class ModelerGeometry : Entity
{
	public class Silhouette
	{
		public XYZ ViewportDirectionFromTarget { get; internal set; }

		public long ViewportId { get; internal set; }

		public bool ViewportPerspective { get; internal set; }

		public XYZ ViewportTarget { get; internal set; }

		public XYZ ViewportUpDirection { get; internal set; }

		public List<Wire> Wires { get; } = new List<Wire>();
	}

	public class Wire
	{
		internal bool HasReflection;

		public int AcisIndex { get; set; }

		public bool ApplyTransformPresent { get; internal set; }

		public Color Color { get; set; }

		public bool HasRotation { get; internal set; }

		public bool HasShear { get; internal set; }

		public List<XYZ> Points { get; } = new List<XYZ>();

		public double Scale { get; internal set; }

		public int SelectionMarker { get; set; }

		public XYZ Translation { get; internal set; }

		public byte Type { get; set; }

		public XYZ XAxis { get; internal set; }

		public XYZ YAxis { get; internal set; }

		public XYZ ZAxis { get; internal set; }
	}

	public XYZ Point { get; set; }

	public List<Silhouette> Silhouettes { get; } = new List<Silhouette>();

	public override string SubclassMarker => "AcDbModelerGeometry";

	public List<Wire> Wires { get; } = new List<Wire>();

	[DxfCodeValue(new int[] { 2 })]
	internal Guid Guid { get; set; }

	[DxfCodeValue(new int[] { 70 })]
	public short ModelerFormatVersion { get; set; }

	[DxfCodeValue(new int[] { 1 })]
	public StringBuilder ProprietaryData { get; } = new StringBuilder();

	public override void ApplyTransform(Transform transform)
	{
	}

	public override BoundingBox GetBoundingBox()
	{
		return BoundingBox.Null;
	}
}
